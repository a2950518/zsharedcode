/*
 * wiki 成员参考:
 * http://code.google.com/p/zsharedcode/wiki/IEBrowser
 * http://code.google.com/p/zsharedcode/wiki/IEFlow
 * http://code.google.com/p/zsharedcode/wiki/IERecord
 * wiki 分析&示例:
 * http://code.google.com/p/zsharedcode/wiki/IEBrowserDoc
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/IEBrowser.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/RecordAction.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageAction.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageState.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageCondition.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/flow/Flow.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/io/StoreHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/StringCompareMode.cs
 * 合并下载:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/IEBrowser.all.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/IEBrowser.with.HtmlEditHelper.all.cs.cs (包含 HtmlEditHelper 类)
 * 版本: 2.1, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using zoyobar.shared.panzer.flow;
using zoyobar.shared.panzer.io;

namespace zoyobar.shared.panzer.web.ib
{

	#region " IERecord "
	/// <summary>
	/// 操作记录类.
	/// </summary>
	public sealed class IERecord
	{
		private readonly IEBrowser ieBrowser;
		private bool isRecording = false;
		private bool isReplaying = false;
		private string navigateUrl;
		private readonly List<RecordAction> actions = new List<RecordAction> ( );
		private readonly List<RecordAction> replayActions = new List<RecordAction> ( );

		/// <summary>
		/// 获取当前是否处于记录状态.
		/// </summary>
		public bool IsRecording
		{
			get { return this.isRecording; }
		}

		/// <summary>
		/// 获取当前是否处于回放状态.
		/// </summary>
		public bool IsReplaying
		{
			get { return this.isReplaying; }
		}

		/// <summary>
		/// 获取或设置导航到的地址.
		/// </summary>
		public string NavigateUrl
		{
			get { return this.navigateUrl; }
			set { this.navigateUrl = value; }
		}

		/// <summary>
		/// 获取记录的动作.
		/// </summary>
		public List<RecordAction> Actions
		{
			get { return this.actions; }
		}

		/// <summary>
		/// 创建一个操作记录类.
		/// </summary>
		/// <param name="ieBrowser">用于记录的 IEBrowser.</param>
		public IERecord ( IEBrowser ieBrowser )
		{

			if ( null == ieBrowser )
				throw new ArgumentNullException ( "ieBrowser", "IEBrowser 不能为空" );

			this.ieBrowser = ieBrowser;
		}

		/// <summary>
		/// 追加一个操作.
		/// </summary>
		/// <param name="action">追加的操作.</param>
		public void AppendAction ( RecordAction action )
		{

			if ( !this.isRecording || null == action )
				return;

			this.actions.Add ( action );
		}

		/// <summary>
		/// 保存动作到文件, 在记录和回放时执行无效.
		/// </summary>
		/// <param name="filePath">文件地址.</param>
		public void SaveAction ( string filePath )
		{

			if ( this.isRecording || this.isReplaying )
				return;

			string text = string.Empty;

			foreach ( RecordAction action in this.actions )
				text += action.ToString ( ) + ";";

			StoreHelper.Write ( filePath, text );
		}

		/// <summary>
		/// 从文件载入动作, 在记录和回放时执行无效.
		/// </summary>
		/// <param name="filePath">文件地址.</param>
		public void LoadAction ( string filePath )
		{

			if ( this.isRecording || this.isReplaying )
				return;

			this.actions.Clear ( );
			string text = StoreHelper.Read ( filePath );

			if ( string.IsNullOrEmpty ( text ) )
				return;

			foreach ( string expression in text.Split ( ';' ) )
				if ( expression.StartsWith ( RecordActionType.Navigate.ToString ( ) ) )
					this.actions.Add ( NavigateRecordAction.Create ( expression ) );
				else if ( expression.StartsWith ( RecordActionType.Custom.ToString ( ) ) )
					this.actions.Add ( CustomRecordAction.Create ( expression ) );

		}

		/// <summary>
		/// 从当前页面读取已经记录的操作, 需要首先调用 BeginRecord 方法.
		/// </summary>
		public void RecordCustomAction ( )
		{

			if ( !this.isRecording )
				return;

			string actionExpression = this.ieBrowser.__Get<string> ( "__actionExpression" );

			if ( string.IsNullOrEmpty ( actionExpression ) )
				return;

			foreach ( string expression in actionExpression.Split ( ';' ) )
			{

				if ( expression == string.Empty )
					continue;

				SortedList<string, string> attributes = new SortedList<string, string> ( );

				foreach ( string attribute in expression.Split ( '&' ) )
				{
					string[] parts = attribute.Split ( '=' );

					attributes.Add ( parts[0], parts[1] );
				}

				try
				{ this.actions.Add ( new CustomRecordAction ( attributes["type"], attributes["member"], attributes["condition"], attributes["path"], attributes.ContainsKey ( "value" ) ? attributes["value"] : null, Convert.ToInt32 ( attributes["wait"] ), Convert.ToInt32 ( attributes["index"] ) ) ); }
				catch { }

			}

		}

		#region " InstallRecord "
		/// <summary>
		/// 安装记录脚本到 WebBrowser, 可以使用记录相关的 javascript 函数.
		/// </summary>
		public void InstallRecord ( )
		{
			// HACK: 也可以去掉安装跟踪脚本.
			this.ieBrowser.InstallTrace ( );

			this.ieBrowser.InstallScript (
		"function __getElement(condition, document) {\n" +
		"	var results = new Array();\n" +
		"	var parts = condition.split('`');\n" +
		"	var element = document.getElementById(parts[0]);\n" +

		"	if (null != element)\n" +
		"		results.push(element);\n" +
		"	else {\n" +
		"		var elements = document.getElementsByTagName(parts[1]);\n" +

		"		for (var index = 0; index < elements.length; index++)\n" +
		"			if ((elements[index].name == parts[2] || null == elements[index].name) && (elements[index].className == parts[3] || null == elements[index].className) && (elements[index].type == parts[4] || null == elements[index].type) && (elements[index].value == parts[5] || null == elements[index].value || elements[index].type.toLowerCase() == 'text' || elements[index].type.toLowerCase() == 'radio' || elements[index].type.toLowerCase() == 'checkbox' || elements[index].tagName == 'TEXTAREA') && (elements[index].href == parts[6] || null == elements[index].href))\n" +
		"				results.push(elements[index]);\n" +

		"	}\n" +

		"	return results;\n" +
		"}\n" +
		"function __getElementIndex(condition, element, document) {\n" +
		"	var elements = __getElement(condition, document);\n" +

		"	for (var index = 0; index < elements.length; index++)\n" +
		"		if (elements[index] == element)\n" +
		"			return index;\n" +

		"	return 0;\n" +
		"}\n" +
		"function __beginRecord() {\n" +
		"	window.__actions = new Array();\n" +
		"	window.__actionExpression = '';\n" +
		"	window.__lastRecordTime = new Date();\n" +
		"	__installRecord(window);\n" +
		"}\n" +
		"function __installRecord(frame) {\n" +

		"	for (var index = 0; index < frame.document.all.length; index++)\n" +
		"		if (frame.document.all[index].tagName == 'INPUT' || frame.document.all[index].tagName == 'SELECT' || frame.document.all[index].tagName == 'TEXTAREA')\n" +
		"			frame.document.all[index].attachEvent('onchange', __window_onchange);\n" +

		"		frame.document.attachEvent('onclick', __window_onclick);\n" +

		"	for (index = 0; index < frame.frames.length; index++)\n" +
		"		__installRecord(frame.frames[index]);\n" +

		"}\n" +
		"function __endRecord() {\n" +
		"	__uninstallRecord(window);\n" +
		"}\n" +
		"function __uninstallRecord(frame) {\n" +

		"	for (var index = 0; index < frame.document.all.length; index++)\n" +
		"		if (frame.document.all[index].tagName == 'INPUT' || frame.document.all[index].tagName == 'SELECT' || frame.document.all[index].tagName == 'TEXTAREA')\n" +
		"			frame.document.all[index].detachEvent('onchange', __window_onchange);\n" +

		"	frame.document.detachEvent('onclick', __window_onclick);\n" +

		"	for (index = 0; index < frame.frames.length; index++)\n" +
		"		__uninstallRecord(frame.frames[index]);\n" +

		"}\n" +
		"function __getDocumentPath(element) {\n" +
		"	var path = 'document';\n" +
		"	var parent = element.document.parentWindow;\n" +

		"	while (parent != parent.parent) {\n" +

		"		for (var index = 0; index < parent.parent.frames.length; index++)\n" +
		"			if (parent == parent.parent.frames[index]) {\n" +
		"				path = 'window.frames[' + index + '].' + path;\n" +
		"				break;\n" +
		"			}\n" +

		"		parent = parent.parent;\n" +
		"	}\n" +

		"	return path;\n" +
		"}\n" +
		"function __getCondition(element) {\n" +
		"	return (null == element.id ? '' : element.id) + '`' + element.tagName + '`' + (null == element.name ? '' : element.name) + '`' + (null == element.className ? '' : element.className) + '`' + (null == element.type ? '' : element.type) + '`' + (null == element.value ? '' : element.value) + '`' + (null == element.href ? '' : element.href);\n" +
		"}\n" +
		"function __setActionExpression(expression) {\n" +
		"	if (null == expression)\n" +
		"		expression = '';\n" +

		"	window.__actions = new Array();\n" +
		"	window.__actionExpression = expression;\n" +

		"	var actions = expression.split(';');\n" +

		"	for (var actionIndex = 0; actionIndex < actions.length; actionIndex++) {\n" +

		"		if (actions[actionIndex] == '')\n" +
		"			continue;\n" +

		"		var attributes = actions[actionIndex].split('&');\n" +
		"		var action = new Object();\n" +

		"		for (var attributeIndex = 0; attributeIndex < attributes.length; attributeIndex++) {\n" +
		"			var parts = attributes[attributeIndex].split('=');\n" +

		"			switch (parts[0]) {\n" +
		"				case 'selectedIndex':\n" +
		"					action[parts[0]] = new Number(parts[1]);\n" +
		"					break;\n" +

		"				default:\n" +
		"					action[parts[0]] = parts[1];\n" +
		"					break;\n" +
		"			}\n" +

		"		}\n" +

		"		window.__actions.push(action);\n" +
		"	}\n" +

		"}\n" +
		"function __window_onchange(e) {\n" +
		"	var element = e.srcElement;\n" +
		"	var action;\n" +

		"	if (null == element)\n" +
		"		return;\n" +

		"	switch (element.tagName) {\n" +
		"		case 'INPUT':\n" +

		"			if (element.type.toLowerCase() == 'radio' || element.type.toLowerCase() == 'checkbox')\n" +
		"				action = { type: 'property', member: 'checked', value: escape(element.checked) };\n" +
		"			else\n" +
		"				action = { type: 'property', member: 'value', value: escape(element.value) };\n" +

		"			break;\n" +

		"		case 'SELECT':\n" +
		"			action = { type: 'property', member: 'selectedIndex', value: element.selectedIndex };\n" +
		"			break;\n" +

		"		case 'TEXTAREA':\n" +
		"			action = { type: 'property', member: 'innerText', value: escape(element.value) };\n" +
		"			break;\n" +
		"	}\n" +

		"	action.condition = __getCondition(element);\n" +
		"	action.path = __getDocumentPath(element);\n" +
		"	action.wait = new Date() - window.__lastRecordTime;\n" +
		"	action.index = __getElementIndex(action.condition, element, eval(action.path));\n" +

		"	if (null != action) {\n" +
		"		window.__actions.push(action);\n" +
		"		window.__actionExpression += 'type=' + action.type + '&member=' + action.member + '&condition=' + action.condition + '&path=' + action.path + '&value=' + action.value + '&wait=' + action.wait + '&index=' + action.index + ';';\n" +
		"	}\n" +

		"};\n" +
		"function __window_onclick(e) {\n" +
		"	var element = e.srcElement;\n" +

		"	if (null == element)\n" +
		"		return;\n" +

		"	var action = { type: 'method', member: 'click' };\n" +

		"	action.condition = __getCondition(element);\n" +
		"	action.path = __getDocumentPath(element);\n" +
		"	action.wait = new Date() - window.__lastRecordTime;\n" +
		"	action.index = __getElementIndex(action.condition, element, eval(action.path));\n" +

		"	window.__actions.push(action);\n" +
		"	window.__actionExpression += 'type=' + action.type + '&member=' + action.member + '&condition=' + action.condition + '&path=' + action.path + '&wait=' + action.wait + '&index=' + action.index + ';';\n" +
		"};\n" +
		"function __replayRecord() {\n" +

		"	if (null == window.__actions)\n" +
		"		return;\n" +

		"	var script = '';\n" +

		"	for (var index = 0; index < window.__actions.length; index++) {\n" +
		"		var action = window.__actions[index];\n" +

		"		switch (action.type) {\n" +
		"			case 'property':\n" +

		"				switch (action.member) {\n" +
		"					case 'checked':\n" +
		"					case 'value':\n" +
		"					case 'innerText':\n" +
		"						script += 'setTimeout(\"__getElement(\\'' + action.condition + '\\', ' + action.path + ')[' + action.index + '].' + action.member + ' = unescape(\\'' + action.value + '\\');\", ' + action.wait + ');';\n" +
		"						break;\n" +

		"					case 'selectedIndex':\n" +
		"						script += 'setTimeout(\"__getElement(\\'' + action.condition + '\\', ' + action.path + ')[' + action.index + '].' + action.member + ' = ' + action.value + ';\", ' + action.wait + ');';\n" +
		"						break;\n" +
		"				}\n" +

		"				break;\n" +

		"			case 'method':\n" +
		"				script += 'setTimeout(\"__getElement(\\'' + action.condition + '\\', ' + action.path + ')[' + action.index + '].' + action.member + '();\", ' + action.wait + ');';\n" +
		"				break;\n" +
		"		}\n" +

		"	}\n" +

		"	eval(script);\n" +
		"}",
				"__jsRecord",
				false
				);
		}
		#endregion

		/// <summary>
		/// 在当前页面上调用 __beginRecord 函数, 需要首先调用 InstallRecord 方法.
		/// </summary>
		public void __BeginRecord ( )
		{ this.ieBrowser.InvokeScript ( "__beginRecord" ); }

		/// <summary>
		/// 开始执行记录操作, 将记录用户在 WebBrowser 上的相关操作, 需要首先调用 InstallRecord 方法.
		/// </summary>
		public void BeginRecord ( )
		{

			if ( this.isRecording || this.isReplaying || this.ieBrowser.Url == string.Empty )
				return;

			this.isRecording = true;
			this.actions.Clear ( );
			this.AppendAction ( new NavigateRecordAction ( this.ieBrowser.Url ) );
			this.__BeginRecord ( );
		}

		/// <summary>
		/// 在当前页面上调用 __endRecord 函数, 需要首先调用 InstallRecord 方法.
		/// </summary>
		public void __EndRecord ( )
		{ this.ieBrowser.InvokeScript ( "__endRecord" ); }

		/// <summary>
		/// 结束执行记录操作, 将结束记录用户在 WebBrowser 上的相关操作, 需要首先调用 BeginRecord 方法.
		/// </summary>
		public void EndRecord ( )
		{

			if ( !this.isRecording )
				return;

			this.__EndRecord ( );
			this.RecordCustomAction ( );
			this.isRecording = false;
		}

		/// <summary>
		/// 在当前页面上调用 __replayRecord 函数, 需要首先调用 InstallRecord 方法.
		/// </summary>
		public void __ReplayRecord ( )
		{ this.ieBrowser.InvokeScript ( "__replayRecord" ); }

		/// <summary>
		/// 开始重播记录的用户在 WebBrowser 上的相关操作, 需要首先调用 EndRecord 方法.
		/// </summary>
		public void BeginReplay ( )
		{

			if ( this.isRecording || this.isReplaying || this.actions.Count == 0 || this.actions[0].Type != RecordActionType.Navigate )
				return;

			this.isReplaying = true;

			this.replayActions.Clear ( );
			this.replayActions.AddRange ( this.actions );

			this.navigateUrl = ( this.replayActions[0] as NavigateRecordAction ).Url;
			this.replayActions.RemoveAt ( 0 );
			this.ieBrowser.Navigate ( this.navigateUrl );
		}

		/// <summary>
		/// 结束重播记录.
		/// </summary>
		public void EndReplay ( )
		{

			if ( !this.isReplaying )
				return;

			this.isReplaying = false;
		}

		/// <summary>
		/// 回放用户操作直到遇上一条导航操作, 需要首先调用 ReplayRecord 方法.
		/// </summary>
		public void ReplayCustomAction ( )
		{

			if ( !this.isReplaying )
				return;

			if ( this.replayActions.Count == 0 )
			{
				this.EndReplay ( );
				return;
			}

			string expression = string.Empty;

			for ( int index = 0; index < this.replayActions.Count; )
			{

				if ( this.replayActions[0].Type == RecordActionType.Navigate )
					break;

				CustomRecordAction customAction = this.replayActions[0] as CustomRecordAction;

				expression += string.Format ( "type={0}&member={1}&condition={2}&path={3}&value={4}&wait={5}&index={6};", customAction.CustomType, customAction.Member, customAction.Condition, customAction.Path, customAction.Value, customAction.Wait, customAction.Index );

				this.replayActions.RemoveAt ( 0 );
			}

			this.navigateUrl = string.Empty;

			if ( this.replayActions.Count == 0 )
				this.EndReplay ( );
			else
				for ( int index = 0; index < this.replayActions.Count; )
				{

					if ( this.replayActions[0].Type == RecordActionType.Custom )
						break;

					this.navigateUrl += ( this.replayActions[0] as NavigateRecordAction ).Url;

					this.replayActions.RemoveAt ( 0 );
				}

			this.ieBrowser.InvokeScript ( "__setActionExpression", new object[] { expression } );
			this.__ReplayRecord ( );
		}

	}
	#endregion

	#region " IEFlow "
	/// <summary>
	/// 页面流程类, 包含了多个页面状态, 可以控制页面状态之间的跳转.
	/// </summary>
	public sealed class IEFlow
		: Flow<WebPageAction, WebPageCondition>
	{

		private readonly IEBrowser ieBrowser;

		private readonly List<string> completedUrls = new List<string> ( );

		/// <summary>
		/// 获取完成的地址条件.
		/// </summary>
		public List<string> CompletedUrls
		{
			get { return this.completedUrls; }
		}

		/// <summary>
		/// 创建一个页面流程类.
		/// </summary>
		/// <param name="ieBrowser">用于完成页面动作的 IEBrowser.</param>
		/// <param name="states">页面状态数组.</param>
		public IEFlow ( IEBrowser ieBrowser, WebPageState[] states )
			: base ( states )
		{

			if ( null == ieBrowser )
				throw new ArgumentNullException ( "ieBrowser", "IEBrowser 不能为空" );

			this.ieBrowser = ieBrowser;
		}

		protected override void executeAction ( WebPageAction action )
		{

			if ( null == action )
				return;

			switch ( action.Type )
			{
				case WebPageActionType.Navigate:
					NavigateAction navigateAction = action as NavigateAction;
					this.ieBrowser.Navigate ( navigateAction.Url );
					break;

				case WebPageActionType.ExecuteJQuery:
					ExecuteJQueryAction executeJQueryAction = action as ExecuteJQueryAction;
					this.ieBrowser.ExecuteJQuery ( executeJQueryAction.JQuery, executeJQueryAction.ResultName, executeJQueryAction.FramePath );
					break;

				case WebPageActionType.ExecuteJavaScript:
					ExecuteJavaScriptAction executeJavaScriptAction = action as ExecuteJavaScriptAction;
					this.ieBrowser.ExecuteScript ( executeJavaScriptAction.Code );
					break;

				case WebPageActionType.InstallTrace:
					this.ieBrowser.InstallTrace ( );
					break;

				case WebPageActionType.InstallJQuery:
					InstallJQueryAction installJQueryAction = action as InstallJQueryAction;
					this.ieBrowser.InstallTrace ( );

					try
					{ this.ieBrowser.InstallJQuery ( new Uri ( installJQueryAction.Url ) ); }
					catch { }

					break;

				case WebPageActionType.InstallJavaScript:
					InstallJavaScriptAction installJavaScriptAction = action as InstallJavaScriptAction;

					if ( string.IsNullOrEmpty ( installJavaScriptAction.Url ) )
						this.ieBrowser.InstallScript ( installJavaScriptAction.Code, installJavaScriptAction.ID );
					else
						try
						{ this.ieBrowser.InstallScript ( new Uri ( installJavaScriptAction.Url ), installJavaScriptAction.ID ); }
						catch { }

					break;

				case WebPageActionType.InvokeJavaScript:
					InvokeJavaScriptAction invokeJavaScriptAction = action as InvokeJavaScriptAction;
					this.ieBrowser.InvokeScript ( invokeJavaScriptAction.MethodName, invokeJavaScriptAction.Parameters.ToArray ( ), invokeJavaScriptAction.FramePath );
					break;

				case WebPageActionType.Refresh:
					this.ieBrowser.Refresh ( );
					break;
			}

		}

		/// <summary>
		/// 停止页面状态的跳转.
		/// </summary>
		public override void StopJump ( )
		{
			base.StopJump ( );
			this.completedUrls.Clear ( );
		}

		/// <summary>
		/// 检测某个条件是否成立.
		/// </summary>
		/// <param name="condition">检测的条件.</param>
		/// <returns>是否成立.</returns>
		public override bool CheckState ( WebPageCondition condition )
		{

			switch ( condition.Type )
			{
				case WebPageConditionType.Url:
					UrlCondition urlCondition = condition as UrlCondition;

					foreach ( string url in this.completedUrls )
					{

						switch ( urlCondition.CompareMode )
						{
							case StringCompareMode.StartWith:

								if ( url.StartsWith ( urlCondition.Url ) )
									return true;

								break;

							case StringCompareMode.Contain:

								if ( url.Contains ( urlCondition.Url ) )
									return true;

								break;

							case StringCompareMode.EndWith:

								if ( url.EndsWith ( urlCondition.Url ) )
									return true;

								break;

							case StringCompareMode.Equal:

								if ( url == urlCondition.Url )
									return true;

								break;
						}

					}

					break;

				case WebPageConditionType.JQuery:
					JQueryCondition jQueryCondition = condition as JQueryCondition;
					object result = this.ieBrowser.ExecuteJQuery ( jQueryCondition.JQuery );

					if ( null != result && result.ToString ( ) == jQueryCondition.Result.ToString ( ) )
					{
#if TRACE
						Console.WriteLine ( string.Format ( "\tok jquery: {0}={1}", jQueryCondition.JQuery.Code, result ) );
#endif
						return true;
					}

					break;
			}

			return false;
		}

	}
	#endregion

	#region " IEBrowser "
	/// <summary>
	/// IEBrowser 类用于控制调试 WebBrowser 浏览器控件, 可实现 jQuery 等功能.
	/// </summary>
	public sealed partial class IEBrowser
	{
		private static readonly string comObjectFullName = "System.__ComObject";

#if PARAM
		/// <summary>
		/// 对字符串编码, 以进行接下来的操作.
		/// </summary>
		/// <param name="text">需要编码的字符串.</param>
		/// <param name="isRemove">是否删除某些特殊字符, 如: 换行, 默认为 false.</param>
		/// <returns>编码后的字符串.</returns>
		public static string EscapeCharacter ( string text, bool isRemove = false )
#else
		/// <summary>
		/// 对字符串编码, 以进行接下来的操作.
		/// </summary>
		/// <param name="text">需要编码的字符串.</param>
		/// <param name="isRemove">是否删除某些特殊字符, 如: 换行.</param>
		/// <returns>编码后的字符串.</returns>
		public static string EscapeCharacter ( string text, bool isRemove )
#endif
		{

			if ( string.IsNullOrEmpty ( text ) )
				return string.Empty;

			if ( isRemove )
				text = text.Replace ( "\n", string.Empty ).Replace ( "\r", string.Empty ).Replace ( "\t", string.Empty );
			else
				text = text.Replace ( "\n", "\\n" ).Replace ( "\r", "\\r" ).Replace ( "\t", "\\t" );

			return text.Replace ( "\\", "\\\\" ).Replace ( "\'", "\\'" );
		}

		private readonly WebBrowser browser;

		private readonly IEFlow ieFlow;
		private readonly IERecord ieRecord;

		/// <summary>
		/// 获取当前页面地址.
		/// </summary>
		public string Url
		{
			get
			{

				if ( null == this.browser.Url )
					return string.Empty;

				return this.browser.Url.AbsoluteUri.ToLower ( );
			}
		}

		/// <summary>
		/// 获取页面流程类.
		/// </summary>
		public IEFlow IEFlow
		{
			get { return this.ieFlow; }
		}

		/// <summary>
		/// 获取操作记录类.
		/// </summary>
		public IERecord IERecord
		{
			get { return this.ieRecord; }
		}

		/// <summary>
		/// 获取用于在 javascript 中调用的 .NET 对象.
		/// </summary>
		public object Scripting
		{
			set { this.browser.ObjectForScripting = value; }
		}

#if PARAM
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组, 默认为空.</param>
		/// <param name="scripting">用于在 javascript 中调用的 .NET 对象.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states = null, object scripting = null )
#else
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组.</param>
		/// <param name="scripting">用于在 javascript 中调用的 .NET 对象.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states, object scripting )
#endif
		{

			if ( null == browser )
				throw new ArgumentNullException ( "browser", "浏览器控件不能为空" );

			browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler ( this.browserDocumentCompleted );
			browser.Navigating += new WebBrowserNavigatingEventHandler ( this.browserNavigating );
			browser.Navigated += new WebBrowserNavigatedEventHandler ( this.browserNavigated );

			this.browser = browser;
			this.ieFlow = new IEFlow ( this, states );
			this.ieRecord = new IERecord ( this );
			this.Scripting = scripting;
		}

		private void browserDocumentCompleted ( object sender, WebBrowserDocumentCompletedEventArgs e )
		{
#if TRACE
			Console.WriteLine ( string.Format ( "\tcompleted url: {0}", e.Url.AbsoluteUri.ToLower ( ) ) );
#endif

			if ( this.ieFlow.CompletedUrls.Count < 100 )
				this.ieFlow.CompletedUrls.Add ( e.Url.AbsoluteUri.ToLower ( ) );

			if ( this.ieRecord.IsRecording )
			{

				if ( this.ieRecord.NavigateUrl == e.Url.AbsoluteUri.ToLower ( ) )
				{
					this.ieRecord.InstallRecord ( );
					this.ieRecord.__BeginRecord ( );
				}

			}
			else if ( this.ieRecord.IsReplaying )
			{
				this.ieRecord.NavigateUrl = this.ieRecord.NavigateUrl.Replace ( e.Url.AbsoluteUri.ToLower ( ), string.Empty ).Replace ( e.Url.Host.ToLower ( ) + e.Url.AbsolutePath.ToLower ( ), string.Empty );

				if ( this.ieRecord.NavigateUrl == string.Empty )
				{
					this.ieRecord.InstallRecord ( );
					this.ieRecord.ReplayCustomAction ( );
				}

			}

		}

		private void browserNavigating ( object sender, WebBrowserNavigatingEventArgs e )
		{

			// 获取的方法转移到了 browserNavigated 中
			if ( this.ieRecord.IsRecording )
				this.ieRecord.RecordCustomAction ( );

		}

		private void browserNavigated ( object sender, WebBrowserNavigatedEventArgs e )
		{

			if ( this.ieRecord.IsRecording )
			{
				//this.ieRecord.RecordCustomAction ( );

				this.ieRecord.AppendAction ( new NavigateRecordAction ( e.Url.Host.ToLower ( ) + e.Url.AbsolutePath.ToLower ( ) ) );
				this.ieRecord.NavigateUrl = e.Url.AbsoluteUri.ToLower ( );
			}

		}

		private bool isScriptElementExist ( string id )
		{

			if ( null == this.browser.Document || string.IsNullOrEmpty ( id ) )
				return false;

			foreach ( HtmlElement element in this.browser.Document.GetElementsByTagName ( "script" ) )
				if ( element.Id == id )
					return true;

			return false;
		}

		private void installScript ( string id, Uri scriptUrl, string code, bool isOverWrite )
		{

			if ( null == this.browser.Document || ( null == scriptUrl && string.IsNullOrEmpty ( code ) ) )
				return;

			if ( string.IsNullOrEmpty ( id ) )
				id = ScriptHelper.MakeKey ( );

			HtmlElement scriptElement = null;

			foreach ( HtmlElement element in this.browser.Document.GetElementsByTagName ( "script" ) )
				if ( element.Id == id )
					if ( isOverWrite )
					{
						scriptElement = element;
						break;
					}
					else
						return;

			if ( null == scriptElement )
			{
				scriptElement = this.browser.Document.CreateElement ( "script" );

				HtmlElementCollection elements = this.browser.Document.GetElementsByTagName ( "head" );

				if ( elements.Count > 0 )
					this.browser.Document.GetElementsByTagName ( "head" )[0].AppendChild ( scriptElement );

			}

			scriptElement.SetAttribute ( "id", id );
			scriptElement.SetAttribute ( "type", "text/javascript" );
			scriptElement.SetAttribute ( "language", "javascript" );

			if ( null == scriptUrl )
				scriptElement.SetAttribute ( "text", code );
			else
				scriptElement.SetAttribute ( "src", scriptUrl.AbsoluteUri );

		}

#if PARAM
		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并指定脚本的地址.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		/// <param name="id">脚本 script 标签的 id 属性, 默认自动生成.</param>
		/// <param name="isOverWrite">是否重写, 默认重写.</param>
		public void InstallScript ( Uri scriptUrl, string id = null, bool isOverWrite = true )
#else
		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并指定脚本的地址.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		/// <param name="isOverWrite">是否重写.</param>
		public void InstallScript ( Uri scriptUrl, string id, bool isOverWrite )
#endif
		{ this.installScript ( id, scriptUrl, null, isOverWrite ); }

#if PARAM
		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并添加定义的 javascript  代码.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <param name="id">脚本 script 标签的 id 属性, 默认自动生成.</param>
		/// <param name="isOverWrite">是否重写, 默认重写.</param>
		public void InstallScript ( string code, string id = null, bool isOverWrite = true )
#else
		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并添加定义的 javascript  代码.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		/// <param name="isOverWrite">是否重写.</param>
		public void InstallScript ( string code, string id, bool isOverWrite )
#endif
		{ this.installScript ( id, null, code, isOverWrite ); }

		/// <summary>
		/// 安装跟踪脚本到 WebBrowser, 可以使用 __set(name, value) 和 __get(name) 两个 javascript 函数.
		/// </summary>
		public void InstallTrace ( )
		{ this.installScript ( "__jsTrace", null, "function __set(name, value){if(null == name){return;}window[name] = eval(value);}function __get(name){if(null == name){return null;}else{return window[name];}}", false ); }

		/// <summary>
		/// 安装智能脚本到 WebBrowser, 可以进行一些智能的编辑.
		/// </summary>
		public void InstallSmart ( )
		{ this.installScript ( "__jsSmart", null, "function __set(name, value){if(null == name){return;}window[name] = eval(value);}function __get(name){if(null == name){return null;}else{return window[name];}}", false ); }

#if PARAM
		/// <summary>
		/// 安装指定地址的 jQuery 脚本到 WebBrowser 控件.
		/// </summary>
		/// <param name="jQueryUrl">jQuery 脚本地址, 默认安装网络地址.</param>
		/// <param name="isOverWrite">是否重写, 默认不重写.</param>
		public void InstallJQuery ( Uri jQueryUrl = null, bool isOverWrite = false )
#else
		/// <summary>
		/// 安装指定地址的 jQuery 脚本到 WebBrowser 控件.
		/// </summary>
		/// <param name="jQueryUrl">jQuery 脚本地址.</param>
		/// <param name="isOverWrite">是否重写.</param>
		public void InstallJQuery ( Uri jQueryUrl, bool isOverWrite )
#endif
		{
			// HACK: 也可以去掉安装跟踪脚本.
			this.InstallTrace ( );

			if ( null == jQueryUrl )
				jQueryUrl = new Uri ( JQuery.Script_1_4_1_Url );

			this.installScript ( "__jsJQuery", jQueryUrl, null, isOverWrite );
		}

		/// <summary>
		/// 安装 jQuery 脚本到 WebBrowser 控件, 将覆盖已经安装的脚本.
		/// </summary>
		/// <param name="code">jQuery 脚本.</param>
		public void InstallJQuery ( string code )
		{
			// HACK: 也可以去掉安装跟踪脚本.
			this.InstallTrace ( );

			this.installScript ( "__jsJQuery", null, code, true );
		}

		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并添加执行的 javascript  代码.
		/// </summary>
		/// <param name="code">需要添加的 javascript 代码.</param>
		public void ExecuteScript ( string code )
		{ this.installScript ( "__executeScript", null, code, true ); }

#if PARAM
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架, 默认不指定路径.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object ExecuteJQuery ( JQuery jQuery, string resultName = null, string framePath = null )
		{ return this.ExecuteJQuery<object> ( jQuery, resultName, framePath ); }
#else
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object ExecuteJQuery ( JQuery jQuery, string resultName, string framePath )
		{ return this.ExecuteJQuery<object> ( framePath, jQuery, resultName ); }
#endif

#if PARAM
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架, 默认不指定路径.</param>
		/// <returns>执行 JQuery 后的返回值.</returns>
		public T ExecuteJQuery<T> ( JQuery jQuery, string resultName = null, string framePath = null )
#else
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>执行 JQuery 后的返回值.</returns>
		public T ExecuteJQuery<T> ( string framePath, JQuery jQuery, string resultName )
#endif
		{

			if ( null == jQuery )
				return default ( T );

			if ( string.IsNullOrEmpty ( resultName ) )
				resultName = "__tempJQuery";

			this.__Set ( resultName, jQuery.Code, framePath );
			return this.__Get<T> ( resultName, framePath );
		}

#if PARAM
		/// <summary>
		/// 调用 WebBrowser 中已经定义的 javascript 函数, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="parameters">参数数组, 默认没有参数.</param>
		/// <param name="framePath">函数所在的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架, 默认不使用路径.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object InvokeScript ( string methodName, object[] parameters = null, string framePath = null )
#else
		/// <summary>
		/// 调用 WebBrowser 中已经定义的 javascript 函数, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="parameters">参数数组.</param>
		/// <param name="framePath">函数所在的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object InvokeScript ( string methodName, object[] parameters, string framePath )
#endif
		{

			if ( null == this.browser.Document || string.IsNullOrEmpty ( methodName ) )
				return null;

			HtmlDocument document = this.browser.Document;

			if ( !string.IsNullOrEmpty ( framePath ) )
				foreach ( string path in framePath.Split ( '.' ) )
					if ( path != string.Empty )
					{
						int index;

						if ( int.TryParse ( path, out index ) )
							document = document.Window.Frames[index].Document;
						else
							document = document.Window.Frames[path].Document;

						if ( null == document )
							return null;

					}

			try
			{ return document.InvokeScript ( methodName, parameters ); }
			catch
			{ return null; }

		}

#if PARAM
		/// <summary>
		/// 调用 __get 函数, 获得一个值, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="framePath">__get 函数所在框架的路径, 默认不使用路径.</param>
		public T __Get<T> ( string name, string framePath = null )
#else
		/// <summary>
		/// 调用 __get 函数, 获得一个值, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="framePath">__get 函数所在框架的路径.</param>
		public T __Get<T> ( string name, string framePath )
#endif
		{

			if ( string.IsNullOrEmpty ( name ) )
				return default ( T );

			object value = this.InvokeScript ( "__get", new object[] { name }, framePath );

			if ( null == value || value.GetType ( ).FullName == comObjectFullName )
				return default ( T );

			try
			{ return ( T ) Convert.ChangeType ( value, typeof ( T ) ); }
			catch
			{ return default ( T ); }

		}

#if PARAM
		/// <summary>
		/// 调用 __set 函数, 设置一个值, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="value">值.</param>
		/// <param name="framePath">__set 函数所在框架的路径, 默认不使用路径.</param>
		public void __Set ( string name, string value, string framePath = null )
#else
		/// <summary>
		/// 调用 __set 函数, 设置一个值, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="value">值.</param>
		/// <param name="framePath">__set 函数所在框架的路径.</param>
		public void __Set ( string name, string value, string framePath )
#endif
		{

			if ( string.IsNullOrEmpty ( name ) || string.IsNullOrEmpty ( value ) )
				return;

			this.InvokeScript ( "__set", new object[] { name, value }, framePath );
		}

		/// <summary>
		/// 导航到地址.
		/// </summary>
		/// <param name="url">需要导航到的地址.</param>
		public void Navigate ( string url )
		{

			if ( string.IsNullOrEmpty ( url ) )
				return;

			this.ieFlow.CompletedUrls.Clear ( );

			try
			{ this.browser.Navigate ( url ); }
			catch { }

		}

		/// <summary>
		/// 刷新当前页面.
		/// </summary>
		public void Refresh ( )
		{ this.Navigate ( this.browser.Url.AbsoluteUri.ToLower ( ) ); }

		/// <summary>
		/// 复制并获取页面中的指定的图像.
		/// </summary>
		/// <param name="id">返回 img 标签 id 的表达式, 比如: "'myHead'".</param>
		/// <returns>图像.</returns>
		public Image CopyImage ( string id )
		{

			if ( string.IsNullOrEmpty ( id ) )
				return null;

			try
			{
				this.ExecuteScript ( string.Format ( "var __temp = document.body.createControlRange();__temp.add(document.getElementById({0}));__temp.execCommand('Copy', false, null);", id ) );

				return Clipboard.GetImage ( );
			}
			catch
			{ return null; }
		}

#if PARAM
		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <param name="resultName">保存托管代码执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <param name="parameters">传递给托管方法的参数, 比如: new string[] { "'jack'", "12" }</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public object ExecuteManaged ( string methodName, string resultName = null, string[] parameters = null )
#else
		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <param name="resultName">保存托管代码执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <param name="parameters">传递给托管方法的参数, 比如: new string[] { "'jack'", "12" }</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public object ExecuteManaged ( string methodName, string resultName, string[] parameters )
#endif
		{ return this.ExecuteManaged<object> ( methodName, resultName, parameters ); }

#if PARAM
		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">托管代码执行结果的类型.</typeparam>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <param name="resultName">保存托管代码执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <param name="parameters">传递给托管方法的参数, 比如: new string[] { "'jack'", "12" }</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public T ExecuteManaged<T> ( string methodName, string resultName = null, string[] parameters = null )
#else
		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">托管代码执行结果的类型.</typeparam>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <param name="resultName">保存托管代码执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <param name="parameters">传递给托管方法的参数, 比如: new string[] { "'jack'", "12" }</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public T ExecuteManaged<T> ( string methodName, string resultName, string[] parameters )
#endif
		{

			if ( string.IsNullOrEmpty ( methodName ) )
				return default ( T );

			if ( string.IsNullOrEmpty ( resultName ) )
				resultName = "__tempManaged";

			string parameterList = string.Empty;

			if ( null != parameters )
				foreach ( string parameter in parameters )
					if ( !string.IsNullOrEmpty ( parameter ) )
						parameterList += parameter + ",";

			this.__Set ( resultName, string.Format ( "window.external.{0}({1});", methodName, parameterList.TrimEnd ( ',' ) ) );

			return this.__Get<T> ( resultName );
		}

	}

	partial class IEBrowser
	{
#if !PARAM

		/// <summary>
		/// 对字符串编码, 不删除特殊字符, 如: 换行, 以进行接下来的操作.
		/// </summary>
		/// <param name="text">需要编码的字符串.</param>
		/// <returns>编码后的字符串.</returns>
		public static string EscapeCharacter ( string text )
		{ return EscapeCharacter ( text, false ); }

		/// <summary>
		/// 安装网络版本的 jQuery 脚本到 WebBrowser 控件, 如果已经安装不再重新安装.
		/// </summary>
		public void InstallJQuery ( )
		{ this.InstallJQuery ( null, false ); }

		/// <summary>
		/// 安装网络版本的 jQuery 脚本到 WebBrowser 控件.
		/// </summary>
		/// <param name="isOverWrite">是否重写.</param>
		public void InstallJQuery ( bool isOverWrite )
		{ this.InstallJQuery ( null, isOverWrite ); }

		/// <summary>
		/// 安装指定地址的 jQuery 脚本到 WebBrowser 控件, 如果已经安装不再重新安装.
		/// </summary>
		/// <param name="jQueryUrl">jQuery 脚本地址.</param>
		public void InstallJQuery ( Uri jQueryUrl )
		{ this.InstallJQuery ( jQueryUrl, false ); }

		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并指定脚本的地址, 如果已经安装则重新安装.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		public void InstallScript ( Uri scriptUrl )
		{ this.installScript ( null, scriptUrl, null, true ); }

		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并指定脚本的地址, 如果已经安装则重新安装.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		public void InstallScript ( Uri scriptUrl, string id )
		{ this.installScript ( id, scriptUrl, null, true ); }

		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并添加定义的 javascript  代码, 如果已经安装则重新安装.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		public void InstallScript ( string code )
		{ this.installScript ( null, null, code, true ); }

		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并添加定义的 javascript  代码, 如果已经安装则重新安装.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		public void InstallScript ( string code, string id )
		{ this.installScript ( id, null, code, true ); }

		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		public IEBrowser ( WebBrowser browser )
			: this ( browser, null, null )
		{ }
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="scripting">用于在 javascript 中调用的 .NET 对象.</param>
		public IEBrowser ( WebBrowser browser, object scripting )
			: this ( browser, null, scripting )
		{ }
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states )
			: this ( browser, states, null )
		{ }

		/// <summary>
		/// 调用 WebBrowser 中已经定义的 javascript 函数, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object InvokeScript ( string methodName )
		{ return this.InvokeScript ( methodName, null, null ); }
		/// <summary>
		/// 调用 WebBrowser 中已经定义的 javascript 函数, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="framePath">函数所在的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object InvokeScript ( string methodName, string framePath )
		{ return this.InvokeScript ( methodName, null, framePath ); }
		/// <summary>
		/// 调用 WebBrowser 中已经定义的 javascript 函数, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="parameters">参数数组.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object InvokeScript ( string methodName, object[] parameters )
		{ return this.InvokeScript ( methodName, parameters, null ); }

		/// <summary>
		/// 调用 __set 函数, 设置一个值, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="value">值.</param>
		public void __Set ( string name, string value )
		{ this.__Set ( name, value, null ); }

		/// <summary>
		/// 调用 __get 函数, 获得一个值, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		public T __Get<T> ( string name )
		{ return this.__Get<T> ( name, null ); }

		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <returns>执行 JQuery 后的返回值.</returns>
		public T ExecuteJQuery<T> ( JQuery jQuery )
		{ return this.ExecuteJQuery<T> ( null, jQuery, null ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <returns>执行 JQuery 后的返回值.</returns>
		public T ExecuteJQuery<T> ( string framePath, JQuery jQuery )
		{ return this.ExecuteJQuery<T> ( framePath, jQuery, null ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>执行 JQuery 后的返回值.</returns>
		public T ExecuteJQuery<T> ( JQuery jQuery, string resultName )
		{ return this.ExecuteJQuery<T> ( null, jQuery, resultName ); }

		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <returns>执行 JQuery 后的返回值.</returns>
		public object ExecuteJQuery ( JQuery jQuery )
		{ return this.ExecuteJQuery<object> ( null, jQuery, null ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <returns>执行 JQuery 后的返回值.</returns>
		public object ExecuteJQuery ( string framePath, JQuery jQuery )
		{ return this.ExecuteJQuery<object> ( framePath, jQuery, null ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>执行 JQuery 后的返回值.</returns>
		public object ExecuteJQuery ( JQuery jQuery, string resultName )
		{ return this.ExecuteJQuery<object> ( null, jQuery, resultName ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>执行 JQuery 后的返回值.</returns>
		public object ExecuteJQuery ( string framePath, JQuery jQuery, string resultName )
		{ return this.ExecuteJQuery<object> ( framePath, jQuery, resultName ); }

		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">托管代码执行结果的类型.</typeparam>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public T ExecuteManaged<T> ( string methodName )
		{ return this.ExecuteManaged<T> ( methodName, null, null ); }
		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">托管代码执行结果的类型.</typeparam>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <param name="resultName">保存托管代码执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public T ExecuteManaged<T> ( string methodName, string resultName )
		{ return this.ExecuteManaged<T> ( methodName, resultName, null ); }
		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">托管代码执行结果的类型.</typeparam>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <param name="parameters">传递给托管方法的参数, 比如: new string[] { "'jack'", "12" }</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public T ExecuteManaged<T> ( string methodName, string[] parameters )
		{ return this.ExecuteManaged<T> ( methodName, null, parameters ); }

		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public object ExecuteManaged ( string methodName )
		{ return this.ExecuteManaged<object> ( methodName, null, null ); }
		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <param name="resultName">保存托管代码执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public object ExecuteManaged ( string methodName, string resultName )
		{ return this.ExecuteManaged<object> ( methodName, resultName, null ); }
		/// <summary>
		/// 在 javascript 脚本中调用托管代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="methodName">托管对象的方法名称.</param>
		/// <param name="parameters">传递给托管方法的参数, 比如: new string[] { "'jack'", "12" }</param>
		/// <returns>调用托管代码后的返回值.</returns>
		public object ExecuteManaged ( string methodName, string[] parameters )
		{ return this.ExecuteManaged<object> ( methodName, null, parameters ); }
#endif
	}
	#endregion

}

/* allinone合并了多个文件,下载使用多个allinone代码,可能会遇到重复的类型定义,http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/IEBrowser.with.HtmlEditHelper.all.cs */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using zoyobar.shared.panzer.flow;
using zoyobar.shared.panzer.io;
using System.ComponentModel;
using System.Threading;
using NTimer = System.Windows.Forms.Timer;
using System.Web.UI;
using NControl = System.Web.UI.Control;
using System.IO;
using System.Text;
// ../.class/web/ib/IEBrowser.cs
/*
 * wiki 成员参考:
 * http://code.google.com/p/zsharedcode/wiki/IEBrowser
 * http://code.google.com/p/zsharedcode/wiki/IEFlow
 * http://code.google.com/p/zsharedcode/wiki/IERecord
 * wiki 分析&示例:
 * http://code.google.com/p/zsharedcode/wiki/IEBrowserDoc
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/IEBrowser.cs
 * 合并下载:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/IEBrowser.all.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/IEBrowser.with.HtmlEditHelper.all.cs.cs (包含 HtmlEditHelper 类)
 * 版本: 2.1, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.



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
// ../.class/web/ib/RecordAction.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/IBCustomRecordAction
 * http://code.google.com/p/zsharedcode/wiki/IBNavigateRecordAction
 * http://code.google.com/p/zsharedcode/wiki/IBRecordAction
 * http://code.google.com/p/zsharedcode/wiki/IBRecordActionType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/RecordAction.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.



namespace zoyobar.shared.panzer.web.ib
{

	#region " RecordActionType "
	/// <summary>
	/// 记录行为类型.
	/// </summary>
	public enum RecordActionType
	{
		/// <summary>
		/// 地址跳转记录.
		/// </summary>
		Navigate = 1,
		/// <summary>
		/// 用户操作记录.
		/// </summary>
		Custom = 2,
	}
	#endregion

	#region " RecordAction "
	/// <summary>
	/// 记录操作的基础类.
	/// </summary>
	public abstract class RecordAction
	{
		private readonly RecordActionType type;

		/// <summary>
		/// 获取记录行为类型.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "记录行为类型" )]
		public RecordActionType Type
		{
			get { return this.type; }
		}

		protected RecordAction ( RecordActionType type )
		{ this.type = type; }

	}
	#endregion

	#region " NavigateRecordAction "
	/// <summary>
	/// 导航操作记录.
	/// </summary>
	public sealed class NavigateRecordAction
		: RecordAction
	{

		/// <summary>
		/// 创建一个导航操作记录.
		/// </summary>
		/// <param name="expression">表达式.</param>
		/// <returns>导航操作记录.</returns>
		public static NavigateRecordAction Create ( string expression )
		{

			if ( string.IsNullOrEmpty ( expression ) )
				return null;

			try
			{ return new NavigateRecordAction ( expression.Substring( expression.IndexOf('&') + 1) ); }
			catch
			{ return null; }

		}

		private string url;

		/// <summary>
		/// 获取或设置导航的地址.
		/// </summary>
		[Category ( "行为" )]
		[Description ( "导航的地址" )]
		public string Url
		{
			get { return this.url; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.url = value;

			}
		}

		/// <summary>
		/// 创建一个导航操作记录.
		/// </summary>
		/// <param name="url">导航的地址.</param>
		public NavigateRecordAction ( string url )
			: base ( RecordActionType.Navigate )
		{

			if ( string.IsNullOrEmpty ( url ) )
				throw new ArgumentNullException ( "url", "地址不能为空" );

			this.url = url;
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>字符串.</returns>
		public override string ToString ( )
		{
			return string.Format ( "{0}&{1}", RecordActionType.Navigate, this.url );
		}

	}
	#endregion

	#region " CustomRecordAction "
	/// <summary>
	/// 用户操作记录.
	/// </summary>
	public sealed class CustomRecordAction
		: RecordAction
	{

		/// <summary>
		/// 创建一个用户操作记录.
		/// </summary>
		/// <param name="expression">表达式.</param>
		/// <returns>用户操作记录.</returns>
		public static CustomRecordAction Create ( string expression )
		{

			if ( string.IsNullOrEmpty ( expression ) )
				return null;

			string[] parts = expression.Split ( '&' );

			try
			{ return new CustomRecordAction ( parts[1], parts[2], parts[3], parts[4], parts[5], Convert.ToInt32 ( parts[6] ), Convert.ToInt32 ( parts[7] ) ); }
			catch
			{ return null; }

		}

		private string customType;
		private string member;
		private int index;
		private string path;
		private string value;
		private int wait;
		private string condition;

		/// <summary>
		/// 获取或设置用户操作的类型.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "用户操作的类型" )]
		public string CustomType
		{
			get { return this.customType; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.customType = value;

			}
		}

		/// <summary>
		/// 获取或设置操作的成员.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "操作的成员" )]
		public string Member
		{
			get { return this.member; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.member = value;

			}
		}

		/// <summary>
		/// 获取或设置操作目标的索引.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "目标的索引" )]
		public int Index
		{
			get { return this.index; }
			set
			{

				if ( value >= 0 )
					this.index = value;

			}
		}

		/// <summary>
		/// 获取或设置操作目标的路径.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "操作目标的路径" )]
		public string Path
		{
			get { return this.path; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.path = value;

			}
		}

		/// <summary>
		/// 获取或设置操作的值.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "操作的值" )]
		public string Value
		{
			get { return this.value; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.value = value;

			}
		}

		/// <summary>
		/// 获取或设置操作的等待时间.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "操作的等待时间" )]
		public int Wait
		{
			get { return this.wait; }
			set
			{

				if ( value >= 0 )
					this.wait = value;

			}
		}

		/// <summary>
		/// 获取或设置确定搜索目标的条件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "确定搜索目标的条件" )]
		public string Condition
		{
			get { return this.condition; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.condition = value;

			}
		}

		/// <summary>
		/// 创建一个用户操作记录.
		/// </summary>
		/// <param name="customType">用户操作的类型.</param>
		/// <param name="memeber">操作的成员.</param>
		/// <param name="condition">确定搜索目标的条件.</param>
		/// <param name="path">操作目标的路径.</param>
		/// <param name="value">操作的值.</param>
		/// <param name="wait">操作的等待时间.</param>
		/// <param name="index">操作目标的索引.</param>
		public CustomRecordAction ( string customType, string memeber, string condition, string path, string value, int wait, int index )
			: base ( RecordActionType.Custom )
		{

			if ( string.IsNullOrEmpty ( customType ) || string.IsNullOrEmpty ( memeber ) || string.IsNullOrEmpty ( condition ) || string.IsNullOrEmpty ( path ) )
				throw new ArgumentNullException ( "customType, memeber, condition, path", "相关参数不能为空" );

			this.customType = customType;
			this.member = memeber;
			this.condition = condition;
			this.path = path;
			this.value = string.IsNullOrEmpty ( value ) ? "null" : value;
			this.wait = wait < 1 ? 1 : wait;
			this.index = index < 0 ? 0 : index;
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>字符串.</returns>
		public override string ToString ( )
		{ return string.Format ( "{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}", RecordActionType.Custom, this.customType, this.member, this.condition, this.path, this.value, this.wait, this.index ); }

	}
	#endregion

}
// ../.class/flow/Flow.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/FlowAction
 * http://code.google.com/p/zsharedcode/wiki/FlowCondition
 * http://code.google.com/p/zsharedcode/wiki/FlowState
 * http://code.google.com/p/zsharedcode/wiki/Flow
 * http://code.google.com/p/zsharedcode/wiki/NextStateSetting
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/flow/Flow.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.


// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.flow
{

	/// <summary>
	/// 剩余等待时间改变时.
	/// </summary>
	/// <param name="remainSecond">所剩的秒数.</param>
	public delegate void RemainWaitTimeChangedEventHandler ( int remainSecond );

	/// <summary>
	/// 状态改变时.
	/// </summary>
	/// <param name="state">改变的状态.</param>
	/// <param name="isStop">是否停止状态的自动跳转, 默认为 false.</param>
	/// <typeparam name="A">行为类型.</typeparam>
	/// <typeparam name="C">条件类型.</typeparam>
	public delegate void StateChangedEventHandler<A, C> ( FlowState<A, C> state, ref bool isStop )
		where A : FlowAction
		where C : FlowCondition;

	/// <summary>
	/// 当一个条件完成时.
	/// </summary>
	/// <param name="condition">完成的条件.</param>
	/// <param name="conditionCount">条件总数.</param>
	/// <param name="completedConditionCount">已经完成的条件个数.</param>
	public delegate void ConditionCompletedEventHandler<C> ( C condition, int conditionCount, int completedConditionCount )
		where C : FlowCondition;

	#region " FlowAction "
	/// <summary>
	/// 流程的某个环节执行的行为.
	/// </summary>
	public abstract class FlowAction
	{
		/// <summary>
		/// 行为执行后等待的时间.
		/// </summary>
		public readonly int WaitSecond;

		protected FlowAction ( int waitSecond )
		{

			if ( waitSecond < 0 )
				waitSecond = 0;

			this.WaitSecond = waitSecond;
		}

	}
	#endregion

	#region " FlowCondition "
	/// <summary>
	/// 判断状态是否成功的条件.
	/// </summary>
	public abstract class FlowCondition : IComparable
	{
		/// <summary>
		/// 条件的名称.
		/// </summary>
		public readonly string Name;

		protected FlowCondition ( string name )
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", "名称不能为空" );

			this.Name = name;
		}

		/// <summary>
		/// 比较两个条件.
		/// </summary>
		/// <param name="obj">被对比的地址条件.</param>
		/// <returns>对比后的值.</returns>
		int IComparable.CompareTo ( object obj )
		{

			if ( !( obj is FlowCondition ) )
				return 1;

			return this.Name.CompareTo ( ( ( FlowCondition ) obj ).Name );
		}

	}
	#endregion

	#region " NextStateSetting "
	/// <summary>
	/// 跳转状态设置.
	/// </summary>
	/// <typeparam name="A">行为类型.</typeparam>
	/// <typeparam name="C">条件类型.</typeparam>
	public class NextStateSetting<A, C>
		where A : FlowAction
		where C : FlowCondition
	{
		/// <summary>
		/// 转到的状态的名称.
		/// </summary>
		public readonly string StateName;
		/// <summary>
		/// 转到的状态.
		/// </summary>
		public FlowState<A, C> State;

		/// <summary>
		/// 是否跳自动转到下一状态.
		/// </summary>
		public readonly bool IsAutoJump;

		/// <summary>
		/// 创建跳转状态设置.
		/// </summary>
		/// <param name="stateName">转到的状态的名称.</param>
		/// <param name="isAutoJump">是否跳自动转到下一状态.</param>
		public NextStateSetting ( string stateName, bool isAutoJump )
		{

			if ( string.IsNullOrEmpty ( stateName ) )
				throw new ArgumentNullException ( "stateName", "转到的状态的名称不能为空" );

			this.StateName = stateName;
			this.IsAutoJump = isAutoJump;
		}

	}
	#endregion

	#region " FlowState "
	/// <summary>
	/// 流程中的某个状态.
	/// </summary>
	/// <typeparam name="A">行为类型.</typeparam>
	/// <typeparam name="C">条件类型.</typeparam>
	public partial class FlowState<A, C>
		where A : FlowAction
		where C : FlowCondition
	{
		/// <summary>
		/// 状态的名称.
		/// </summary>
		public readonly string Name;
		/// <summary>
		/// 状态开始时的行为.
		/// </summary>
		public readonly List<A> StartActions = new List<A> ( );
		/// <summary>
		/// 状态完成后的行为.
		/// </summary>
		public readonly List<A> CompletedActions = new List<A> ( );
		/// <summary>
		/// 状态失败后的行为.
		/// </summary>
		public readonly List<A> FailedActions = new List<A> ( );

		/// <summary>
		/// 完成跳转的状态的设置.
		/// </summary>
		public readonly NextStateSetting<A, C> CompletedStateSetting;
		/// <summary>
		/// 失败跳转的状态的设置.
		/// </summary>
		public readonly NextStateSetting<A, C> FailedStateSetting;

		/// <summary>
		/// 完成此状态的条件.
		/// </summary>
		public readonly SortedList<C, bool> Conditions = new SortedList<C, bool> ( );

		/// <summary>
		/// 超时秒数.
		/// </summary>
		public readonly int Timeout;

		/// <summary>
		/// 获取已经完成的条件个数.
		/// </summary>
		public int CompletedConditionCount
		{
			get
			{
				int count = 0;

				foreach ( bool value in this.Conditions.Values )
					if ( value )
						count++;

				return count;
			}
		}

		/// <summary>
		/// 获取状态完成后是否有转到的状态.
		/// </summary>
		public bool IsCompletedStateEmpty
		{
			get { return ( null == this.CompletedStateSetting ) || ( null == this.CompletedStateSetting.State ); }
		}

		/// <summary>
		/// 获取状态失败后是否有转到的状态.
		/// </summary>
		public bool IsFailedStateEmpty
		{
			get { return ( null == this.FailedStateSetting ) || ( null == this.FailedStateSetting.State ); }
		}

		#region " ctor "

#if PARAM
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedAction">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A[] startActions = null, A completedAction = null, NextStateSetting<A, C> completedStateSetting = null, A failedAction = null, NextStateSetting<A, C> failedStateSetting = null, C condition = null, int timeout = 0 )
			: this ( name, startActions, new A[] { completedAction }, completedStateSetting, new A[] { failedAction }, failedStateSetting, new C[] { condition }, timeout )
		{ }
#endif

#if PARAM
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedAction">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction = null, A completedAction = null, NextStateSetting<A, C> completedStateSetting = null, A failedAction = null, NextStateSetting<A, C> failedStateSetting = null, C condition = null, int timeout = 0 )
#else
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedAction">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction, A completedAction, NextStateSetting<A, C> completedStateSetting, A failedAction, NextStateSetting<A, C> failedStateSetting, C condition, int timeout )
#endif
			: this ( name, new A[] { startAction }, new A[] { completedAction }, completedStateSetting, new A[] { failedAction }, failedStateSetting, new C[] { condition }, timeout )
		{ }

#if PARAM
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedActions">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedActions">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="conditions">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A[] startActions = null, A[] completedActions = null, NextStateSetting<A, C> completedStateSetting = null, A[] failedActions = null, NextStateSetting<A, C> failedStateSetting = null, C[] conditions = null, int timeout = 0 )
#else
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedActions">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedActions">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="conditions">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A[] startActions, A[] completedActions, NextStateSetting<A, C> completedStateSetting, A[] failedActions, NextStateSetting<A, C> failedStateSetting, C[] conditions, int timeout )
#endif
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", "状态的名称不能为空" );

			if ( null != startActions )
				foreach ( A action in startActions )
					if ( null != action )
						this.StartActions.Add ( action );

			if ( null != completedActions )
				foreach ( A action in completedActions )
					if ( null != action )
						this.CompletedActions.Add ( action );

			if ( null != failedActions )
				foreach ( A action in failedActions )
					if ( null != action )
						this.FailedActions.Add ( action );

			if ( null != conditions )
				foreach ( C condition in conditions )
					if ( null != condition )
						this.Conditions.Add ( condition, false );

			if ( timeout < 0 )
				timeout = 0;

			this.Name = name;
			this.CompletedStateSetting = completedStateSetting;
			this.FailedStateSetting = failedStateSetting;
			this.Timeout = timeout;
		}
		#endregion

	}

	partial class FlowState<A, C>
	{
#if !PARAM
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		public FlowState ( string name, A[] startActions, NextStateSetting<A, C> completedStateSetting, C condition )
			: this ( name, startActions, null, completedStateSetting, null, null, new C[] { condition }, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A[] startActions, NextStateSetting<A, C> completedStateSetting, NextStateSetting<A, C> failedStateSetting, C condition, int timeout )
			: this ( name, startActions, null, completedStateSetting, null, failedStateSetting, new C[] { condition }, timeout )
		{ }

		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		public FlowState ( string name, A startAction )
			: this ( name, new A[] { startAction }, null, null, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">状态失败后的行为.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, NextStateSetting<A, C> completedStateSetting, A failedAction, C condition, int timeout )
			: this ( name, null, null, completedStateSetting, new A[] { failedAction }, null, new C[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction, C condition, int timeout )
			: this ( name, new A[] { startAction }, null, null, null, null, new C[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		public FlowState ( string name, A startAction, NextStateSetting<A, C> completedStateSetting )
			: this ( name, new A[] { startAction }, null, completedStateSetting, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction, NextStateSetting<A, C> completedStateSetting, NextStateSetting<A, C> failedStateSetting, int timeout )
			: this ( name, new A[] { startAction }, null, completedStateSetting, null, failedStateSetting, null, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, NextStateSetting<A, C> completedStateSetting, NextStateSetting<A, C> failedStateSetting, C condition, int timeout )
			: this ( name, null, null, completedStateSetting, null, failedStateSetting, new C[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction, NextStateSetting<A, C> completedStateSetting, NextStateSetting<A, C> failedStateSetting, C condition, int timeout )
			: this ( name, new A[] { startAction }, null, completedStateSetting, null, failedStateSetting, new C[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		public FlowState ( string name, A startAction, NextStateSetting<A, C> completedStateSetting, C condition )
			: this ( name, new A[] { startAction }, null, completedStateSetting, null, null, new C[] { condition }, 0 )
		{ }

		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		public FlowState ( string name, A[] startActions )
			: this ( name, startActions, null, null, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		public FlowState ( string name, A[] startActions, NextStateSetting<A, C> completedStateSetting )
			: this ( name, startActions, null, completedStateSetting, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedActions">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="conditions">成此状态的条件.</param>
		public FlowState ( string name, A[] startActions, A[] completedActions, NextStateSetting<A, C> completedStateSetting, C[] conditions )
			: this ( name, startActions, completedActions, completedStateSetting, null, null, conditions, 0 )
		{ }
#endif
	}

	#endregion

	#region " Flow "
	/// <summary>
	/// 流程类, 包含了多个状态, 可以控制状态之间的跳转.
	/// </summary>
	/// <typeparam name="A">行为类型.</typeparam>
	/// <typeparam name="C">条件类型.</typeparam>
	public abstract partial class Flow<A, C>
		where A : FlowAction
		where C : FlowCondition
	{

		/// <summary>
		/// 剩余等待时间改变时.
		/// </summary>
		public event RemainWaitTimeChangedEventHandler RemainWaitTimeChanged;

		/// <summary>
		/// 状态完成时.
		/// </summary>
		public event StateChangedEventHandler<A, C> StateCompleted;

		/// <summary>
		/// 状态失败时.
		/// </summary>
		public event StateChangedEventHandler<A, C> StateFailed;

		/// <summary>
		/// 当一个条件完成时.
		/// </summary>
		public event ConditionCompletedEventHandler<C> ConditionCompleted;

		private readonly SortedList<string, FlowState<A, C>> states = new SortedList<string, FlowState<A, C>> ( );
		private FlowState<A, C> currentState;

		private NTimer checkStateTimer = new NTimer ( );
		private NTimer checkTimeoutTimer = new NTimer ( );
		private bool checkStateTimerLocker;
		private bool checkTimeoutTimerLocker;

		/// <summary>
		/// 创建一个流程类.
		/// </summary>
		/// <param name="states">状态数组.</param>
		public Flow ( FlowState<A, C>[] states )
		{

			if ( null != states )
			{

				foreach ( FlowState<A, C> state in states )
					if ( null != state && !this.states.ContainsKey ( state.Name ) )
						this.states.Add ( state.Name, state );

				foreach ( FlowState<A, C> state in this.states.Values )
				{

					if ( null != state.CompletedStateSetting && !string.IsNullOrEmpty ( state.CompletedStateSetting.StateName ) && this.states.ContainsKey ( state.CompletedStateSetting.StateName ) )
						state.CompletedStateSetting.State = this.states[state.CompletedStateSetting.StateName];

					if ( null != state.FailedStateSetting && !string.IsNullOrEmpty ( state.FailedStateSetting.StateName ) && this.states.ContainsKey ( state.FailedStateSetting.StateName ) )
						state.FailedStateSetting.State = this.states[state.FailedStateSetting.StateName];

				}

			}

			this.checkStateTimer.Enabled = false;
			this.checkTimeoutTimer.Enabled = false;
			this.checkStateTimer.Tick += new EventHandler ( this.checkState );
			this.checkTimeoutTimer.Tick += new EventHandler ( this.checkTimeout );
		}

#if PARAM
		/// <summary>
		/// 等待条件的成立, 如果指定时间内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="condition">等待成立的条件.</param>
		/// <param name="second">等待的秒数, 默认 60 秒.</param>
		public void Wait ( C condition, int second = 60 )
#else
		/// <summary>
		/// 等待条件的成立, 如果指定时间内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="condition">等待成立的条件.</param>
		/// <param name="second">等待的秒数.</param>
		public void Wait ( C condition, int second )
#endif
		{ this.Wait ( second, new C[] { condition } ); }

#if PARAM
		/// <summary>
		/// 等待条件的成立, 如果指定时间内没有成立则, 抛出异常. 如果没有指定条件, 则只等待指定的时间, 不抛出异常.
		/// </summary>
		/// <param name="second">等待的秒数, 默认 60 秒.</param>
		/// <param name="conditions">等待成立的条件.</param>
		public void Wait ( int second = 60, C[] conditions = null )
#else
		/// <summary>
		/// 等待条件的成立, 如果指定时间内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="second">等待的秒数.</param>
		/// <param name="conditions">等待成立的条件.</param>
		public void Wait ( int second, C[] conditions )
#endif
		{

			if ( second <= 0 )
				return;

			int time = Environment.TickCount + ( second * 1000 );
			int oldRemainSecond = -1;

			while ( true )
			{
				int remainSecond = ( int ) ( ( time - Environment.TickCount ) / 1000 ) + 1;

				if ( oldRemainSecond == -1 || oldRemainSecond != remainSecond )
				{
					oldRemainSecond = remainSecond;

					if ( null != this.RemainWaitTimeChanged )
						this.RemainWaitTimeChanged ( remainSecond );

				}

				Application.DoEvents ( );
				Thread.Sleep ( 100 );

				if ( null != conditions )
				{
					bool isSuccess = true;

					foreach ( C condition in conditions )
						if ( !this.CheckState ( condition ) )
						{
							isSuccess = false;
							break;
						}

					if ( isSuccess )
						break;

				}

				if ( remainSecond <= 0 )
					if ( null == conditions )
						break;
					else
						throw new TimeoutException ( string.Format ( "在 {0} 秒内条件没有达成", second ) );

			}

		}

		private FlowState<A, C> getCompletedState ( )
		{

			if ( null != this.currentState && !this.currentState.Conditions.ContainsValue ( false ) )
				return this.currentState;

			return null;
		}

		protected abstract void executeAction ( A action );

		private void executeAction ( List<A> actions )
		{

			if ( null == actions )
				return;

			foreach ( A action in actions )
			{
				this.executeAction ( action );

				this.Wait ( action.WaitSecond );
			}

		}

		/// <summary>
		/// 停止状态的跳转.
		/// </summary>
		public virtual void StopJump ( )
		{
			this.currentState = null;
			this.checkStateTimer.Enabled = false;
			this.checkTimeoutTimer.Enabled = false;

			this.checkStateTimerLocker = false;
			this.checkTimeoutTimerLocker = false;
		}

		private void jumpToState ( FlowState<A, C> state )
		{

			if ( null == state )
				return;

			this.StopJump ( );
			this.currentState = state;

#if TRACE
			Console.WriteLine ( string.Format ( "jump to: <{0}>", state.Name ) );
#endif

			for ( int index = 0; index < state.Conditions.Count; index++ )
				state.Conditions[state.Conditions.Keys[index]] = false;

			this.executeAction ( state.StartActions );

			this.checkStateTimer.Interval = 1000;
			this.checkStateTimer.Enabled = true;

			if ( state.Timeout != 0 )
			{
				this.checkTimeoutTimer.Interval = state.Timeout * 1000;
				this.checkTimeoutTimer.Enabled = true;
			}

		}

		/// <summary>
		/// 跳转到指定的状态, 这些状态在声明时定义.
		/// </summary>
		/// <param name="stateName">状态的名称.</param>
		public void JumpToState ( string stateName )
		{

			if ( string.IsNullOrEmpty ( stateName ) || !this.states.ContainsKey ( stateName ) )
				return;

			this.jumpToState ( this.states[stateName] );
		}

		/// <summary>
		/// 检测某个条件是否成立.
		/// </summary>
		/// <param name="condition">检测的条件.</param>
		/// <returns>是否成立.</returns>
		public abstract bool CheckState ( C condition );

		private void checkState ( object sender, EventArgs e )
		{

			if ( this.checkStateTimerLocker )
				return;

			this.checkStateTimerLocker = true;

			try
			{

				if ( null == this.currentState )
					return;

#if TRACE
				Console.WriteLine ( string.Format ( "check state: <{0}>", this.currentState.Name ) );
#endif

				#region " 测试条件 "
				for ( int index = 0; index < this.currentState.Conditions.Count; index++ )
				{
					C condition = this.currentState.Conditions.Keys[index];

					if ( this.currentState.Conditions[condition] )
						continue;

					this.currentState.Conditions[condition] = this.CheckState ( condition );

					if ( this.currentState.Conditions[condition] && null != this.ConditionCompleted )
					{
#if TRACE
						Console.WriteLine ( string.Format ( "\tok condition: {0}", condition.Name ) );
#endif
						this.ConditionCompleted ( condition, this.currentState.Conditions.Count, this.currentState.CompletedConditionCount );
					}

				}
				#endregion

				FlowState<A, C> completedState = this.getCompletedState ( );

				if ( null == completedState )
					return;
#if TRACE
				Console.WriteLine ( string.Format ( "completed state: <{0}>", completedState.Name ) );
#endif

				this.executeAction ( completedState.CompletedActions );

				bool isStop = false;

				if ( null != this.StateCompleted )
					this.StateCompleted ( completedState, ref isStop );

				if ( isStop || completedState.IsCompletedStateEmpty || !completedState.CompletedStateSetting.IsAutoJump )
					this.StopJump ( );
				else
					this.jumpToState ( completedState.CompletedStateSetting.State );

			}
			catch ( Exception err )
			{ Console.WriteLine ( err.Message ); }
			finally
			{ this.checkStateTimerLocker = false; }

		}

		private void checkTimeout ( object sender, EventArgs e )
		{

			if ( this.checkTimeoutTimerLocker )
				return;

			this.checkTimeoutTimerLocker = true;

			try
			{

				if ( null == this.currentState )
					return;

#if TRACE
				Console.WriteLine ( string.Format ( "timeout: <{0}>", this.currentState.Name ) );
#endif

				this.executeAction ( this.currentState.FailedActions );

				bool isStop = false;

				if ( null != this.StateFailed )
					this.StateFailed ( this.currentState, ref isStop );

				if ( isStop || this.currentState.IsFailedStateEmpty || !this.currentState.FailedStateSetting.IsAutoJump )
					this.StopJump ( );
				else
					this.jumpToState ( this.currentState.FailedStateSetting.State );

			}
			catch ( Exception err )
			{ Console.WriteLine ( err.Message ); }
			finally
			{ this.checkTimeoutTimerLocker = false; }

		}

	}

	partial class Flow<A, C>
	{

#if !PARAM
		/// <summary>
		/// 等待条件的成立, 如果 60 秒内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="conditions">等待成立的条件.</param>
		public void Wait ( C[] conditions )
		{ this.Wait ( 60, conditions ); }
		/// <summary>
		/// 等待指定时间.
		/// </summary>
		/// <param name="second">等待的秒数.</param>
		public void Wait ( int second )
		{ this.Wait ( second, null ); }

		/// <summary>
		/// 等待条件的成立, 如果 60 秒内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="condition">等待成立的条件.</param>
		public void Wait ( C condition )
		{ this.Wait ( condition, 60 ); }
#endif

	}

	#endregion

}
// ../.class/web/ib/WebPageAction.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/WPAEmptyAction
 * http://code.google.com/p/zsharedcode/wiki/ExecuteJavaScriptAction
 * http://code.google.com/p/zsharedcode/wiki/ExecuteJQueryAction
 * http://code.google.com/p/zsharedcode/wiki/InstallJavaScriptAction
 * http://code.google.com/p/zsharedcode/wiki/InstallJQueryAction
 * http://code.google.com/p/zsharedcode/wiki/InstallTraceAction
 * http://code.google.com/p/zsharedcode/wiki/InvokeJavaScriptAction
 * http://code.google.com/p/zsharedcode/wiki/WPANavigateAction
 * http://code.google.com/p/zsharedcode/wiki/WPARefreshAction
 * http://code.google.com/p/zsharedcode/wiki/WebPageActionType
 * http://code.google.com/p/zsharedcode/wiki/WebPageAction
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageAction.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.



namespace zoyobar.shared.panzer.web.ib
{

	#region " WebPageActionType "
	/// <summary>
	/// 浏览器的行为类型.
	/// </summary>
	public enum WebPageActionType
	{
		/// <summary>
		/// 执行地址跳转.
		/// </summary>
		Navigate = 1,
		/// <summary>
		/// 执行 jQuery 命令.
		/// </summary>
		ExecuteJQuery = 2,
		/// <summary>
		/// 执行 javascript 脚本.
		/// </summary>
		ExecuteJavaScript = 3,
		/// <summary>
		/// 安装跟踪脚本.
		/// </summary>
		InstallTrace = 4,
		/// <summary>
		/// 安装 jQuery 脚本以及跟踪脚本.
		/// </summary>
		InstallJQuery = 5,
		/// <summary>
		/// 安装 javascript 脚本.
		/// </summary>
		InstallJavaScript = 6,
		/// <summary>
		/// 调用 javascript 脚本函数.
		/// </summary>
		InvokeJavaScript = 7,
		/// <summary>
		/// 刷新页面.
		/// </summary>
		Refresh = 8,
		/// <summary>
		/// 不执行任何操作.
		/// </summary>
		None = 9
	}
	#endregion

	#region " WebPageAction "
	/// <summary>
	/// 浏览器的行为.
	/// </summary>
	public abstract class WebPageAction
		: FlowAction
	{
		/// <summary>
		/// 浏览器行为类型.
		/// </summary>
		public readonly WebPageActionType Type;

		protected WebPageAction ( WebPageActionType type, int waitSecond )
			: base ( ( type == WebPageActionType.InstallJQuery && waitSecond < 1 ) ? 1 : waitSecond )
		{ this.Type = type; }

	}
	#endregion

	#region " EmptyAction "
	/// <summary>
	/// 不执行任何操作的行为.
	/// </summary>
	public sealed class EmptyAction
		: WebPageAction
	{

		/// <summary>
		/// 创建一个不执行任何操作的行为.
		/// </summary>
		public EmptyAction ( )
			: base ( WebPageActionType.None, 0 )
		{ }

	}
	#endregion

	#region " NavigateAction "
	/// <summary>
	/// 地址跳转行为.
	/// </summary>
	public sealed partial class NavigateAction
		: WebPageAction
	{
		/// <summary>
		/// 跳转到的地址.
		/// </summary>
		public string Url;

#if PARAM
		/// <summary>
		/// 创建一个地址跳转的行为.
		/// </summary>
		/// <param name="url">跳转到的地址.</param>
		/// <param name="waitSecond">行为执行后等待的时间, 默认等待 0 秒.</param>
		/// <returns>地址跳转的行为.</returns>
		public NavigateAction ( string url, int waitSecond = 0 )
#else
		/// <summary>
		/// 创建一个地址跳转的行为.
		/// </summary>
		/// <param name="url">跳转到的地址.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>地址跳转的行为.</returns>
		public NavigateAction ( string url, int waitSecond )
#endif
			: base ( WebPageActionType.Navigate, waitSecond )
		{ this.Url = url; }

	}

	partial class NavigateAction
	{
#if !PARAM
		/// <summary>
		/// 创建一个地址跳转的行为.
		/// </summary>
		/// <param name="url">跳转到的地址.</param>
		/// <returns>地址跳转的行为.</returns>
		public NavigateAction ( string url )
			: this ( url, 0 )
		{ }
#endif
	}
	#endregion

	#region " RefreshAction "
	/// <summary>
	/// 页面刷新行为.
	/// </summary>
	public sealed partial class RefreshAction
		: WebPageAction
	{

#if PARAM
		/// <summary>
		/// 创建一个刷新页面的行为.
		/// </summary>
		/// <param name="waitSecond">行为执行后等待的时间, 默认 0 秒.</param>
		/// <returns>刷新页面的行为.</returns>
		public RefreshAction ( int waitSecond = 0 )
#else
		/// <summary>
		/// 创建一个刷新页面的行为.
		/// </summary>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>刷新页面的行为.</returns>
		public RefreshAction ( int waitSecond )
#endif
			: base ( WebPageActionType.Refresh, waitSecond )
		{ }

	}

	partial class RefreshAction
	{
#if !PARAM
		/// <summary>
		/// 创建一个刷新页面的行为.
		/// </summary>
		/// <returns>刷新页面的行为.</returns>
		public RefreshAction ( )
			: this ( 0 )
		{ }
#endif
	}
	#endregion

	#region " InvokeJavaScriptAction "
	/// <summary>
	/// 调用 javascript 函数的行为.
	/// </summary>
	public sealed partial class InvokeJavaScriptAction
		: WebPageAction
	{

		/// <summary>
		/// 脚本执行路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.
		/// </summary>
		public string FramePath;
		/// <summary>
		/// 脚本函数名称.
		/// </summary>
		public string MethodName;
		/// <summary>
		/// 脚本函数执行参数.
		/// </summary>
		public readonly List<object> Parameters = new List<object> ( );

#if PARAM
		/// <summary>
		/// 创建一个调用 javascript 脚本函数的行为.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="parameters">参数数组, 默认没有参数.</param>
		/// <param name="framePath">函数所在的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架, 默认不设置路径.</param>
		/// <param name="waitSecond">行为执行后等待的时间, 默认等待 0 秒.</param>
		/// <returns>调用 javascript 脚本函数的行为</returns>
		public InvokeJavaScriptAction ( string methodName, object[] parameters = null, string framePath = null, int waitSecond = 0 )
#else
		/// <summary>
		/// 创建一个调用 javascript 脚本函数的行为.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="parameters">参数数组.</param>
		/// <param name="framePath">函数所在的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>调用 javascript 脚本函数的行为</returns>
		public InvokeJavaScriptAction ( string methodName, object[] parameters, string framePath, int waitSecond )
#endif
			: base ( WebPageActionType.InvokeJavaScript, waitSecond )
		{

			if ( null != parameters )
				this.Parameters.AddRange ( parameters );

			this.MethodName = methodName;
			this.FramePath = framePath;
		}

	}

	partial class InvokeJavaScriptAction
	{
#if !PARAM
		/// <summary>
		/// 创建一个调用 javascript 脚本函数的行为.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <returns>调用 javascript 脚本函数的行为</returns>
		public InvokeJavaScriptAction ( string methodName )
			: this ( methodName, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个调用 javascript 脚本函数的行为.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>调用 javascript 脚本函数的行为</returns>
		public InvokeJavaScriptAction ( string methodName, int waitSecond )
			: this ( methodName, null, null, waitSecond )
		{ }
		/// <summary>
		/// 创建一个调用 javascript 脚本函数的行为.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="framePath">函数所在的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <returns>调用 javascript 脚本函数的行为</returns>
		public InvokeJavaScriptAction ( string methodName, string framePath )
			: this ( methodName, null, framePath, 0 )
		{ }
		/// <summary>
		/// 创建一个调用 javascript 脚本函数的行为.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="framePath">函数所在的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>调用 javascript 脚本函数的行为</returns>
		public InvokeJavaScriptAction ( string methodName, string framePath, int waitSecond )
			: this ( methodName, null, framePath, waitSecond )
		{ }
		/// <summary>
		/// 创建一个调用 javascript 脚本函数的行为.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="parameters">参数数组.</param>
		/// <returns>调用 javascript 脚本函数的行为</returns>
		public InvokeJavaScriptAction ( string methodName, object[] parameters )
			: this ( methodName, parameters, null, 0 )
		{ }
		/// <summary>
		/// 创建一个调用 javascript 脚本函数的行为.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="parameters">参数数组.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>调用 javascript 脚本函数的行为</returns>
		public InvokeJavaScriptAction ( string methodName, object[] parameters, int waitSecond )
			: this ( methodName, parameters, null, waitSecond )
		{ }
		/// <summary>
		/// 创建一个调用 javascript 脚本函数的行为.
		/// </summary>
		/// <param name="methodName">javascript 函数名称.</param>
		/// <param name="parameters">参数数组.</param>
		/// <param name="framePath">函数所在的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <returns>调用 javascript 脚本函数的行为</returns>
		public InvokeJavaScriptAction ( string methodName, object[] parameters, string framePath )
			: this ( methodName, parameters, framePath, 0 )
		{ }
#endif
	}
	#endregion

	#region " InstallTraceAction "
	/// <summary>
	/// 安装跟踪脚本的行为.
	/// </summary>
	public sealed partial class InstallTraceAction
		: WebPageAction
	{

#if PARAM
		/// <summary>
		/// 创建一个安装跟踪脚本的行为.
		/// </summary>
		/// <param name="waitSecond">行为执行后等待的时间, 默认 0 秒.</param>
		/// <returns>安装跟踪脚本的行为.</returns>
		public InstallTraceAction ( int waitSecond = 0 )
#else
		/// <summary>
		/// 创建一个安装跟踪脚本的行为.
		/// </summary>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>安装跟踪脚本的行为.</returns>
		public InstallTraceAction ( int waitSecond )
#endif
			: base ( WebPageActionType.InstallTrace, waitSecond )
		{ }

	}

	partial class InstallTraceAction
	{
#if !PARAM
		/// <summary>
		/// 创建一个安装跟踪脚本的行为.
		/// </summary>
		/// <returns>安装跟踪脚本的行为.</returns>
		public InstallTraceAction ( )
			: this ( 0 )
		{ }
#endif
	}
	#endregion

	#region " InstallJavaScriptAction "
	/// <summary>
	/// 安装 javascript 脚本的行为.
	/// </summary>
	public sealed partial class InstallJavaScriptAction
		: WebPageAction
	{
		/// <summary>
		/// 页面元素 ID.
		/// </summary>
		public string ID;
		/// <summary>
		/// 执行的 javascript 代码.
		/// </summary>
		public string Code;
		/// <summary>
		/// javascript 脚本地址.
		/// </summary>
		public string Url;

#if PARAM
		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		/// <param name="id">脚本 script 标签的 id 属性, 默认自动生成.</param>
		/// <param name="waitSecond">行为执行后等待的时间, 默认 0 秒.</param>
		/// <returns>安装 javascript 脚本的行为.</returns>
		public InstallJavaScriptAction ( Uri scriptUrl, string id = null, int waitSecond = 0 )
#else
		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>安装 javascript 脚本的行为.</returns>
		public InstallJavaScriptAction ( Uri scriptUrl, string id, int waitSecond )
#endif
			: base ( WebPageActionType.InstallJavaScript, waitSecond )
		{
			this.ID = id;
			this.Url = ( null == scriptUrl ) ? null : scriptUrl.AbsoluteUri;
		}

#if PARAM
		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <param name="id">脚本 script 标签的 id 属性, 默认自动生成.</param>
		/// <param name="waitSecond">行为执行后等待的时间, 默认 0 秒.</param>
		/// <returns>安装 javascript 脚本的行为.</returns>
		public InstallJavaScriptAction ( string code, string id = null, int waitSecond = 0 )
#else
		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>安装 javascript 脚本的行为.</returns>
		public InstallJavaScriptAction ( string code, string id, int waitSecond )
#endif
			: base ( WebPageActionType.InstallJavaScript, waitSecond )
		{
			this.ID = id;
			this.Code = code;
		}

	}

	partial class InstallJavaScriptAction
	{
#if !PARAM
		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		/// <returns>安装 javascript 脚本的行为</returns>
		public InstallJavaScriptAction ( Uri scriptUrl )
			: this ( scriptUrl, null, 0 )
		{ }
		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>安装 javascript 脚本的行为</returns>
		public InstallJavaScriptAction ( Uri scriptUrl, int waitSecond )
			: this ( scriptUrl, null, waitSecond )
		{ }
		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		/// <returns>安装 javascript 脚本的行为</returns>
		public InstallJavaScriptAction ( Uri scriptUrl, string id )
			: this ( scriptUrl, id, 0 )
		{ }

		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <returns>安装 javascript 脚本的行为.</returns>
		public InstallJavaScriptAction ( string code )
			: this ( code, null, 0 )
		{ }
		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>安装 javascript 脚本的行为.</returns>
		public InstallJavaScriptAction ( string code, int waitSecond )
			: this ( code, null, waitSecond )
		{ }
		/// <summary>
		/// 创建一个安装 javascript 脚本的行为.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		/// <returns>安装 javascript 脚本的行为.</returns>
		public InstallJavaScriptAction ( string code, string id )
			: this ( code, id, 0 )
		{ }
#endif
	}
	#endregion

	#region " InstallJQueryAction "
	/// <summary>
	/// 安装 jQuery 和跟踪脚本的行为.
	/// </summary>
	public sealed partial class InstallJQueryAction
		: WebPageAction
	{
		/// <summary>
		/// jQuery 脚本地址, 可以是网络或者本地地址.
		/// </summary>
		public string Url;

#if PARAM
		/// <summary>
		/// 创建一个安装指定地址的 jQuery 脚本以及跟踪脚本的行为.
		/// </summary>
		/// <param name="url">jQuery 脚本地址, 默认网络地址.</param>
		/// <param name="waitSecond">行为执行后等待的时间, 如小于 1 秒, 则默认 1 秒钟, 默认 5 秒钟.</param>
		/// <returns>安装指定地址的 jQuery 脚本以及跟踪脚本的行为.</returns>
		public InstallJQueryAction ( string url = null, int waitSecond = 1 )
#else
		/// <summary>
		/// 创建一个安装指定地址的 jQuery 脚本以及跟踪脚本的行为.
		/// </summary>
		/// <param name="url">jQuery 脚本地址.</param>
		/// <param name="waitSecond">行为执行后等待的时间, 如小于 1 秒, 则默认 1 秒钟.</param>
		/// <returns>安装指定地址的 jQuery 脚本以及跟踪脚本的行为.</returns>
		public InstallJQueryAction ( string url, int waitSecond )
#endif
			: base ( WebPageActionType.InstallJQuery, waitSecond )
		{ this.Url = url; }

	}

	partial class InstallJQueryAction
	{
#if !PARAM
		/// <summary>
		/// 创建一个安装网络地址的 jQuery 脚本以及跟踪脚本的行为, 并在完成后等待 5 秒钟.
		/// </summary>
		/// <returns>安装网络地址的 jQuery 脚本以及跟踪脚本的行为.</returns>
		public InstallJQueryAction ( )
			: this ( null, 5 )
		{ }
		/// <summary>
		/// 创建一个安装网络地址的 jQuery 脚本以及跟踪脚本的行为.
		/// </summary>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>安装网络地址的 jQuery 脚本以及跟踪脚本的行为.</returns>
		public InstallJQueryAction ( int waitSecond )
			: this ( null, waitSecond )
		{ }
		/// <summary>
		/// 创建一个安装指定地址的 jQuery 脚本以及跟踪脚本的行为, 并在完成后等待 5 秒钟.
		/// </summary>
		/// <param name="url">jQuery 脚本地址.</param>
		/// <returns>安装指定地址的 jQuery 脚本以及跟踪脚本的行为.</returns>
		public InstallJQueryAction ( string url )
			: this ( url, 5 )
		{ }
#endif
	}
	#endregion

	#region " ExecuteJQueryAction "
	/// <summary>
	/// 执行 jQuery 命令的行为.
	/// </summary>
	public sealed partial class ExecuteJQueryAction
		: WebPageAction
	{
		/// <summary>
		/// 脚本执行路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.
		/// </summary>
		public string FramePath;
		/// <summary>
		/// 返回结果的保存名称.
		/// </summary>
		public string ResultName;
		/// <summary>
		/// 执行的 jQuery 命令.
		/// </summary>
		public JQuery JQuery;

		// HACK: 切换编译符号 PARAM 时, ExecuteJQueryAction 构造函数将需要修改参数.
#if PARAM
		/// <summary>
		/// 创建一个执行 jQuery 命令的行为.
		/// </summary>
		/// <param name="jQuery">执行的 jQuery 命令.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <param name="framePath">jQuery 执行的路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架, 默认不指定路径.</param>
		/// <param name="waitSecond">行为执行后等待的时间, 默认 0 秒.</param>
		/// <returns>执行 jQuery 命令的行为.</returns>
		public ExecuteJQueryAction ( JQuery jQuery, string resultName = null, string framePath = null, int waitSecond = 0 )
#else
		/// <summary>
		/// 创建一个执行 jQuery 命令的行为.
		/// </summary>
		/// <param name="framePath">jQuery 执行的路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">执行的 jQuery 命令.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>执行 jQuery 命令的行为.</returns>
		public ExecuteJQueryAction ( string framePath, JQuery jQuery, string resultName, int waitSecond )
#endif
			: base ( WebPageActionType.ExecuteJQuery, waitSecond )
		{
			this.FramePath = framePath;
			this.ResultName = resultName;
			this.JQuery = jQuery;
		}

	}

	partial class ExecuteJQueryAction
	{
#if !PARAM
		/// <summary>
		/// 创建一个执行 jQuery 命令的行为.
		/// </summary>
		/// <param name="jQuery">执行的 jQuery 命令.</param>
		/// <returns>执行 jQuery 命令的行为.</returns>
		public ExecuteJQueryAction ( JQuery jQuery )
			: this ( null, jQuery, null, 0 )
		{ }
		/// <summary>
		/// 创建一个执行 jQuery 命令的行为.
		/// </summary>
		/// <param name="jQuery">执行的 jQuery 命令.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>执行 jQuery 命令的行为.</returns>
		public ExecuteJQueryAction ( JQuery jQuery, int waitSecond )
			: this ( null, jQuery, null, waitSecond )
		{ }
		/// <summary>
		/// 创建一个执行 jQuery 命令的行为.
		/// </summary>
		/// <param name="framePath">jQuery 执行的路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">执行的 jQuery 命令.</param>
		/// <returns>执行 jQuery 命令的行为.</returns>
		public ExecuteJQueryAction ( string framePath, JQuery jQuery )
			: this ( framePath, jQuery, null, 0 )
		{ }
		/// <summary>
		/// 创建一个执行 jQuery 命令的行为.
		/// </summary>
		/// <param name="framePath">jQuery 执行的路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">执行的 jQuery 命令.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>执行 jQuery 命令的行为.</returns>
		public ExecuteJQueryAction ( string framePath, JQuery jQuery, int waitSecond )
			: this ( framePath, jQuery, null, waitSecond )
		{ }
		/// <summary>
		/// 创建一个执行 jQuery 命令的行为.
		/// </summary>
		/// <param name="jQuery">执行的 jQuery 命令.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>执行 jQuery 命令的行为.</returns>
		public ExecuteJQueryAction ( JQuery jQuery, string resultName )
			: this ( null, jQuery, resultName, 0 )
		{ }
		/// <summary>
		/// 创建一个执行 jQuery 命令的行为.
		/// </summary>
		/// <param name="jQuery">执行的 jQuery 命令.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>执行 jQuery 命令的行为.</returns>
		public ExecuteJQueryAction ( JQuery jQuery, string resultName, int waitSecond )
			: this ( null, jQuery, resultName, waitSecond )
		{ }
		/// <summary>
		/// 创建一个执行 jQuery 命令的行为.
		/// </summary>
		/// <param name="framePath">jQuery 执行的路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">执行的 jQuery 命令.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>执行 jQuery 命令的行为.</returns>
		public ExecuteJQueryAction ( string framePath, JQuery jQuery, string resultName )
			: this ( framePath, jQuery, resultName, 0 )
		{ }
#endif
	}
	#endregion

	#region " ExecuteJavaScriptAction "
	/// <summary>
	/// 执行 javascript 脚本的行为.
	/// </summary>
	public sealed partial class ExecuteJavaScriptAction
		: WebPageAction
	{
		/// <summary>
		/// 执行的 javascript 代码.
		/// </summary>
		public string Code;

#if PARAM
		/// <summary>
		/// 创建一个执行 javascript 代码的行为.
		/// </summary>
		/// <param name="code">执行的 javascript 代码.</param>
		/// <param name="waitSecond">行为执行后等待的时间, 默认 0 秒.</param>
		/// <returns>执行 javascript 代码的行为.</returns>
		public ExecuteJavaScriptAction ( string code, int waitSecond = 0 )
#else
		/// <summary>
		/// 创建一个执行 javascript 代码的行为.
		/// </summary>
		/// <param name="code">执行的 javascript 代码.</param>
		/// <param name="waitSecond">行为执行后等待的时间.</param>
		/// <returns>执行 javascript 代码的行为.</returns>
		public ExecuteJavaScriptAction ( string code, int waitSecond )
#endif
			: base ( WebPageActionType.ExecuteJavaScript, waitSecond )
		{ this.Code = code; }

	}

	partial class ExecuteJavaScriptAction
	{
#if !PARAM
		/// <summary>
		/// 创建一个执行 javascript 代码的行为.
		/// </summary>
		/// <param name="code">执行的 javascript 代码.</param>
		/// <returns>执行 javascript 代码的行为.</returns>
		public ExecuteJavaScriptAction ( string code )
			: this ( code, 0 )
		{ }
#endif
	}
	#endregion

}
// ../.class/web/ib/WebPageCondition.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryCondition
 * http://code.google.com/p/zsharedcode/wiki/UrlCondition
 * http://code.google.com/p/zsharedcode/wiki/WebPageConditionType
 * http://code.google.com/p/zsharedcode/wiki/WebPageCondition
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageCondition.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.web.ib
{

	#region " WebPageConditionType "
	/// <summary>
	/// 条件类型.
	/// </summary>
	public enum WebPageConditionType
	{
		/// <summary>
		/// 地址条件.
		/// </summary>
		Url = 1,
		/// <summary>
		/// jQuery 条件.
		/// </summary>
		JQuery = 2
	}
	#endregion

	#region " WebPageCondition "
	/// <summary>
	/// 用于 IEBrowser 判断状态是否成功的条件.
	/// </summary>
	public abstract class WebPageCondition
		: FlowCondition
	{
		/// <summary>
		/// 条件的类型.
		/// </summary>
		public readonly WebPageConditionType Type;

		protected WebPageCondition ( WebPageConditionType type, string name )
			: base ( name )
		{ this.Type = type; }

	}
	#endregion

	#region " UrlCondition "
	/// <summary>
	/// IEBrowser 判断页面是否载入的地址条件.
	/// </summary>
	public sealed class UrlCondition
		: WebPageCondition
	{
		/// <summary>
		/// 用于判断的地址.
		/// </summary>
		public readonly string Url;
		/// <summary>
		/// 地址的判断模式.
		/// </summary>
		public readonly StringCompareMode CompareMode;

		/// <summary>
		/// 创建一个判断页面是否载入的地址条件.
		/// </summary>
		/// <param name="name">条件的名称.</param>
		/// <param name="url">用于判断的地址.</param>
		/// <param name="compareMode">地址的判断模式.</param>
		public UrlCondition ( string name, string url, StringCompareMode compareMode )
			: base ( WebPageConditionType.Url, name )
		{

			if ( null == url )
				url = string.Empty;

			this.Url = url.ToLower ( );
			this.CompareMode = compareMode;
		}

	}
	#endregion

	#region " JQueryCondition "
	/// <summary>
	/// IEBrowser 判断页面是否载入的 jQuery 测试条件.
	/// </summary>
	public sealed class JQueryCondition
		: WebPageCondition
	{
		/// <summary>
		/// 用于测试执行的 jQuery 命令.
		/// </summary>
		public readonly JQuery JQuery;
		/// <summary>
		/// 期望结果.
		/// </summary>
		public readonly object Result;

		/// <summary>
		/// 创建一个 jQuery 测试条件.
		/// </summary>
		/// <param name="name">条件的名称.</param>
		/// <param name="jQuery">用于测试执行的 jQuery 命令.</param>
		/// <param name="result">期望结果.</param>
		public JQueryCondition ( string name, JQuery jQuery, object result )
			: base ( WebPageConditionType.JQuery, name )
		{

			if ( null == jQuery || null == result )
				throw new ArgumentNullException ( "jQuery, result", "jQuery 命令或者期望结果不能为空" );

			this.JQuery = jQuery;
			this.Result = result;
		}

	}
	#endregion

}
// ../.class/web/ib/WebPageState.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/WebPageNextStateSetting
 * http://code.google.com/p/zsharedcode/wiki/WebPageState
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageCondition.cs
 * 版本: 1.2, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.ib
{

	#region " WebPageNextStateSetting"
	/// <summary>
	/// 跳转状态设置.
	/// </summary>
	public sealed class WebPageNextStateSetting
		: NextStateSetting<WebPageAction, WebPageCondition>
	{

		/// <summary>
		/// 创建跳转状态设置.
		/// </summary>
		/// <param name="stateName">转到的状态的名称.</param>
		/// <param name="isAutoJump">是否跳自动转到下一状态.</param>
		public WebPageNextStateSetting ( string stateName, bool isAutoJump )
			: base ( stateName, isAutoJump )
		{ }

	}
	#endregion

	#region " WebPageState "
	/// <summary>
	/// 页面状态, IEBrowser 可以通过此状态控制浏览器.
	/// </summary>
	public sealed partial class WebPageState
		: FlowState<WebPageAction, WebPageCondition>
	{

		#region " ctor "

#if PARAM
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedAction">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">页面状态失败后的行为.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction[] startActions = null, WebPageAction completedAction = null, WebPageNextStateSetting completedStateSetting = null, WebPageAction failedAction = null, WebPageNextStateSetting failedStateSetting = null, WebPageCondition condition = null, int timeout = 0 )
			: this ( name, startActions, new WebPageAction[] { completedAction }, completedStateSetting, new WebPageAction[] { failedAction }, failedStateSetting, new WebPageCondition[] { condition }, 0 )
		{ }
#endif

#if PARAM
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedAction">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">页面状态失败后的行为.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction startAction = null, WebPageAction completedAction = null, WebPageNextStateSetting completedStateSetting = null, WebPageAction failedAction = null, WebPageNextStateSetting failedStateSetting = null, WebPageCondition condition = null, int timeout = 0 )
			: this ( name, new WebPageAction[] { startAction }, new WebPageAction[] { completedAction }, completedStateSetting, new WebPageAction[] { failedAction }, failedStateSetting, new WebPageCondition[] { condition }, 0 )
		{ }
#endif

#if PARAM
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedActions">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedActions">页面状态失败后的行为.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="conditions">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction[] startActions = null, WebPageAction[] completedActions = null, WebPageNextStateSetting completedStateSetting = null, WebPageAction[] failedActions = null, WebPageNextStateSetting failedStateSetting = null, WebPageCondition[] conditions = null, int timeout = 0 )
#else
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedActions">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedActions">页面状态失败后的行为.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="conditions">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageAction[] completedActions, WebPageNextStateSetting completedStateSetting, WebPageAction[] failedActions, WebPageNextStateSetting failedStateSetting, WebPageCondition[] conditions, int timeout )
#endif
			: base ( name, startActions, completedActions, completedStateSetting, failedActions, failedStateSetting, conditions, timeout )
		{ }
		#endregion

	}

	partial class WebPageState
	{
#if !PARAM
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		public WebPageState ( string name, WebPageAction[] startActions )
			: this ( name, startActions, null, null, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		public WebPageState ( string name, WebPageAction startAction )
			: this ( name, new WebPageAction[] { startAction }, null, null, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">页面状态失败后的行为.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageNextStateSetting completedStateSetting, WebPageAction failedAction, WebPageCondition condition, int timeout )
			: this ( name, null, null, completedStateSetting, new WebPageAction[] { failedAction }, null, new WebPageCondition[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageCondition condition, int timeout )
			: this ( name, new WebPageAction[] { startAction }, null, null, null, null, new WebPageCondition[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageNextStateSetting completedStateSetting, WebPageCondition condition )
			: this ( name, startActions, null, completedStateSetting, null, null, new WebPageCondition[] { condition }, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageNextStateSetting completedStateSetting, WebPageNextStateSetting failedStateSetting, WebPageCondition condition, int timeout )
			: this ( name, startActions, null, completedStateSetting, null, failedStateSetting, new WebPageCondition[] { condition }, timeout )
		{ }

		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting, WebPageNextStateSetting failedStateSetting, int timeout )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, failedStateSetting, null, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageNextStateSetting completedStateSetting, WebPageNextStateSetting failedStateSetting, WebPageCondition condition, int timeout )
			: this ( name, null, null, completedStateSetting, null, failedStateSetting, new WebPageCondition[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting, WebPageNextStateSetting failedStateSetting, WebPageCondition condition, int timeout )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, failedStateSetting, new WebPageCondition[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting, WebPageCondition condition )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, null, new WebPageCondition[] { condition }, 0 )
		{ }

		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageNextStateSetting completedStateSetting )
			: this ( name, startActions, null, completedStateSetting, null, null, null, 0 )
		{ }

		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedActions">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="conditions">成此页面状态的条件.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageAction[] completedActions, WebPageNextStateSetting completedStateSetting, WebPageCondition[] conditions )
			: this ( name, startActions, completedActions, completedStateSetting, null, null, conditions, 0 )
		{ }
#endif
	}
	#endregion

}
// ../.class/web/JQuery.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQuery
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// JQuery 用于编写构造 jQuery 脚本, 包含了 jQuery 中的方法等, 支持 1.6 版本. (尚未包含 Effects, Utilities 的部分方法)
	/// </summary>
	public class JQuery
		: ScriptHelper
	{

		/// <summary>
		/// 获取 jQuery 脚本的压缩版本.
		/// </summary>
		public static string CodeMin
		{
			get
			{
				#region " Code "
				return "(function(a,b){function cy(a){return f.isWindow(a)?a:a.nodeType===9?a.defaultView||a.parentWindow:!1}function cv(a){if(!cj[a]){var b=f(\"<\"+a+\">\").appendTo(\"body\"),d=b.css(\"display\");b.remove();if(d===\"none\"||d===\"\"){ck||(ck=c.createElement(\"iframe\"),ck.frameBorder=ck.width=ck.height=0),c.body.appendChild(ck);if(!cl||!ck.createElement)cl=(ck.contentWindow||ck.contentDocument).document,cl.write(\"<!doctype><html><body></body></html>\");b=cl.createElement(a),cl.body.appendChild(b),d=f.css(b,\"display\"),c.body.removeChild(ck)}cj[a]=d}return cj[a]}function cu(a,b){var c={};f.each(cp.concat.apply([],cp.slice(0,b)),function(){c[this]=a});return c}function ct(){cq=b}function cs(){setTimeout(ct,0);return cq=f.now()}function ci(){try{return new a.ActiveXObject(\"Microsoft.XMLHTTP\")}catch(b){}}function ch(){try{return new a.XMLHttpRequest}catch(b){}}function cb(a,c){a.dataFilter&&(c=a.dataFilter(c,a.dataType));var d=a.dataTypes,e={},g,h,i=d.length,j,k=d[0],l,m,n,o,p;for(g=1;g<i;g++){if(g===1)for(h in a.converters)typeof h==\"string\"&&(e[h.toLowerCase()]=a.converters[h]);l=k,k=d[g];if(k===\"*\")k=l;else if(l!==\"*\"&&l!==k){m=l+\" \"+k,n=e[m]||e[\"* \"+k];if(!n){p=b;for(o in e){j=o.split(\" \");if(j[0]===l||j[0]===\"*\"){p=e[j[1]+\" \"+k];if(p){o=e[o],o===!0?n=p:p===!0&&(n=o);break}}}}!n&&!p&&f.error(\"No conversion from \"+m.replace(\" \",\" to \")),n!==!0&&(c=n?n(c):p(o(c)))}}return c}function ca(a,c,d){var e=a.contents,f=a.dataTypes,g=a.responseFields,h,i,j,k;for(i in g)i in d&&(c[g[i]]=d[i]);while(f[0]===\"*\")f.shift(),h===b&&(h=a.mimeType||c.getResponseHeader(\"content-type\"));if(h)for(i in e)if(e[i]&&e[i].test(h)){f.unshift(i);break}if(f[0]in d)j=f[0];else{for(i in d){if(!f[0]||a.converters[i+\" \"+f[0]]){j=i;break}k||(k=i)}j=j||k}if(j){j!==f[0]&&f.unshift(j);return d[j]}}function b_(a,b,c,d){if(f.isArray(b))f.each(b,function(b,e){c||bF.test(a)?d(a,e):b_(a+\"[\"+(typeof e==\"object\"||f.isArray(e)?b:\"\")+\"]\",e,c,d)});else if(!c&&b!=null&&typeof b==\"object\")for(var e in b)b_(a+\"[\"+e+\"]\",b[e],c,d);else d(a,b)}function b$(a,c,d,e,f,g){f=f||c.dataTypes[0],g=g||{},g[f]=!0;var h=a[f],i=0,j=h?h.length:0,k=a===bU,l;for(;i<j&&(k||!l);i++)l=h[i](c,d,e),typeof l==\"string\"&&(!k||g[l]?l=b:(c.dataTypes.unshift(l),l=b$(a,c,d,e,l,g)));(k||!l)&&!g[\"*\"]&&(l=b$(a,c,d,e,\"*\",g));return l}function bZ(a){return function(b,c){typeof b!=\"string\"&&(c=b,b=\"*\");if(f.isFunction(c)){var d=b.toLowerCase().split(bQ),e=0,g=d.length,h,i,j;for(;e<g;e++)h=d[e],j=/^\\+/.test(h),j&&(h=h.substr(1)||\"*\"),i=a[h]=a[h]||[],i[j?\"unshift\":\"push\"](c)}}}function bD(a,b,c){var d=b===\"width\"?bx:by,e=b===\"width\"?a.offsetWidth:a.offsetHeight;if(c===\"border\")return e;f.each(d,function(){c||(e-=parseFloat(f.css(a,\"padding\"+this))||0),c===\"margin\"?e+=parseFloat(f.css(a,\"margin\"+this))||0:e-=parseFloat(f.css(a,\"border\"+this+\"Width\"))||0});return e}function bn(a,b){b.src?f.ajax({url:b.src,async:!1,dataType:\"script\"}):f.globalEval((b.text||b.textContent||b.innerHTML||\"\").replace(bf,\"/*$0*/\")),b.parentNode&&b.parentNode.removeChild(b)}function bm(a){f.nodeName(a,\"input\")?bl(a):a.getElementsByTagName&&f.grep(a.getElementsByTagName(\"input\"),bl)}function bl(a){if(a.type===\"checkbox\"||a.type===\"radio\")a.defaultChecked=a.checked}function bk(a){return\"getElementsByTagName\"in a?a.getElementsByTagName(\"*\"):\"querySelectorAll\"in a?a.querySelectorAll(\"*\"):[]}function bj(a,b){var c;if(b.nodeType===1){b.clearAttributes&&b.clearAttributes(),b.mergeAttributes&&b.mergeAttributes(a),c=b.nodeName.toLowerCase();if(c===\"object\")b.outerHTML=a.outerHTML;else if(c!==\"input\"||a.type!==\"checkbox\"&&a.type!==\"radio\"){if(c===\"option\")b.selected=a.defaultSelected;else if(c===\"input\"||c===\"textarea\")b.defaultValue=a.defaultValue}else a.checked&&(b.defaultChecked=b.checked=a.checked),b.value!==a.value&&(b.value=a.value);b.removeAttribute(f.expando)}}function bi(a,b){if(b.nodeType===1&&!!f.hasData(a)){var c=f.expando,d=f.data(a),e=f.data(b,d);if(d=d[c]){var g=d.events;e=e[c]=f.extend({},d);if(g){delete e.handle,e.events={};for(var h in g)for(var i=0,j=g[h].length;i<j;i++)f.event.add(b,h+(g[h][i].namespace?\".\":\"\")+g[h][i].namespace,g[h][i],g[h][i].data)}}}}function bh(a,b){return f.nodeName(a,\"table\")?a.getElementsByTagName(\"tbody\")[0]||a.appendChild(a.ownerDocument.createElement(\"tbody\")):a}function X(a,b,c){b=b||0;if(f.isFunction(b))return f.grep(a,function(a,d){var e=!!b.call(a,d,a);return e===c});if(b.nodeType)return f.grep(a,function(a,d){return a===b===c});if(typeof b==\"string\"){var d=f.grep(a,function(a){return a.nodeType===1});if(S.test(b))return f.filter(b,d,!c);b=f.filter(b,d)}return f.grep(a,function(a,d){return f.inArray(a,b)>=0===c})}function W(a){return!a||!a.parentNode||a.parentNode.nodeType===11}function O(a,b){return(a&&a!==\"*\"?a+\".\":\"\")+b.replace(A,\"`\").replace(B,\"&\")}function N(a){var b,c,d,e,g,h,i,j,k,l,m,n,o,p=[],q=[],r=f._data(this,\"events\");if(!(a.liveFired===this||!r||!r.live||a.target.disabled||a.button&&a.type===\"click\")){a.namespace&&(n=new RegExp(\"(^|\\\\.)\"+a.namespace.split(\".\").join(\"\\\\.(?:.*\\\\.)?\")+\"(\\\\.|$)\")),a.liveFired=this;var s=r.live.slice(0);for(i=0;i<s.length;i++)g=s[i],g.origType.replace(y,\"\")===a.type?q.push(g.selector):s.splice(i--,1);e=f(a.target).closest(q,a.currentTarget);for(j=0,k=e.length;j<k;j++){m=e[j];for(i=0;i<s.length;i++){g=s[i];if(m.selector===g.selector&&(!n||n.test(g.namespace))&&!m.elem.disabled){h=m.elem,d=null;if(g.preType===\"mouseenter\"||g.preType===\"mouseleave\")a.type=g.preType,d=f(a.relatedTarget).closest(g.selector)[0],d&&f.contains(h,d)&&(d=h);(!d||d!==h)&&p.push({elem:h,handleObj:g,level:m.level})}}}for(j=0,k=p.length;j<k;j++){e=p[j];if(c&&e.level>c)break;a.currentTarget=e.elem,a.data=e.handleObj.data,a.handleObj=e.handleObj,o=e.handleObj.origHandler.apply(e.elem,arguments);if(o===!1||a.isPropagationStopped()){c=e.level,o===!1&&(b=!1);if(a.isImmediatePropagationStopped())break}}return b}}function L(a,c,d){var e=f.extend({},d[0]);e.type=a,e.originalEvent={},e.liveFired=b,f.event.handle.call(c,e),e.isDefaultPrevented()&&d[0].preventDefault()}function F(){return!0}function E(){return!1}function m(a,c,d){var e=c+\"defer\",g=c+\"queue\",h=c+\"mark\",i=f.data(a,e,b,!0);i&&(d===\"queue\"||!f.data(a,g,b,!0))&&(d===\"mark\"||!f.data(a,h,b,!0))&&setTimeout(function(){!f.data(a,g,b,!0)&&!f.data(a,h,b,!0)&&(f.removeData(a,e,!0),i.resolve())},0)}function l(a){for(var b in a)if(b!==\"toJSON\")return!1;return!0}function k(a,c,d){if(d===b&&a.nodeType===1){var e=\"data-\"+c.replace(j,\"$1-$2\").toLowerCase();d=a.getAttribute(e);if(typeof d==\"string\"){try{d=d===\"true\"?!0:d===\"false\"?!1:d===\"null\"?null:f.isNaN(d)?i.test(d)?f.parseJSON(d):d:parseFloat(d)}catch(g){}f.data(a,c,d)}else d=b}return d}var c=a.document,d=a.navigator,e=a.location,f=function(){function H(){if(!e.isReady){try{c.documentElement.doScroll(\"left\")}catch(a){setTimeout(H,1);return}e.ready()}}var e=function(a,b){return new e.fn.init(a,b,h)},f=a.jQuery,g=a.$,h,i=/^(?:[^<]*(<[\\w\\W]+>)[^>]*$|#([\\w\\-]*)$)/,j=/\\S/,k=/^\\s+/,l=/\\s+$/,m=/\\d/,n=/^<(\\w+)\\s*\\/?>(?:<\\/\\1>)?$/,o=/^[\\],:{}\\s]*$/,p=/\\\\(?:[\"\\\\\\/bfnrt]|u[0-9a-fA-F]{4})/g,q=/\"[^\"\\\\\\n\\r]*\"|true|false|null|-?\\d+(?:\\.\\d*)?(?:[eE][+\\-]?\\d+)?/g,r=/(?:^|:|,)(?:\\s*\\[)+/g,s=/(webkit)[ \\/]([\\w.]+)/,t=/(opera)(?:.*version)?[ \\/]([\\w.]+)/,u=/(msie) ([\\w.]+)/,v=/(mozilla)(?:.*? rv:([\\w.]+))?/,w=d.userAgent,x,y,z,A=Object.prototype.toString,B=Object.prototype.hasOwnProperty,C=Array.prototype.push,D=Array.prototype.slice,E=String.prototype.trim,F=Array.prototype.indexOf,G={};e.fn=e.prototype={constructor:e,init:function(a,d,f){var g,h,j,k;if(!a)return this;if(a.nodeType){this.context=this[0]=a,this.length=1;return this}if(a===\"body\"&&!d&&c.body){this.context=c,this[0]=c.body,this.selector=a,this.length=1;return this}if(typeof a==\"string\"){a.charAt(0)!==\"<\"||a.charAt(a.length-1)!==\">\"||a.length<3?g=i.exec(a):g=[null,a,null];if(g&&(g[1]||!d)){if(g[1]){d=d instanceof e?d[0]:d,k=d?d.ownerDocument||d:c,j=n.exec(a),j?e.isPlainObject(d)?(a=[c.createElement(j[1])],e.fn.attr.call(a,d,!0)):a=[k.createElement(j[1])]:(j=e.buildFragment([g[1]],[k]),a=(j.cacheable?e.clone(j.fragment):j.fragment).childNodes);return e.merge(this,a)}h=c.getElementById(g[2]);if(h&&h.parentNode){if(h.id!==g[2])return f.find(a);this.length=1,this[0]=h}this.context=c,this.selector=a;return this}return!d||d.jquery?(d||f).find(a):this.constructor(d).find(a)}if(e.isFunction(a))return f.ready(a);a.selector!==b&&(this.selector=a.selector,this.context=a.context);return e.makeArray(a,this)},selector:\"\",jquery:\"1.6.1\",length:0,size:function(){return this.length},toArray:function(){return D.call(this,0)},get:function(a){return a==null?this.toArray():a<0?this[this.length+a]:this[a]},pushStack:function(a,b,c){var d=this.constructor();e.isArray(a)?C.apply(d,a):e.merge(d,a),d.prevObject=this,d.context=this.context,b===\"find\"?d.selector=this.selector+(this.selector?\" \":\"\")+c:b&&(d.selector=this.selector+\".\"+b+\"(\"+c+\")\");return d},each:function(a,b){return e.each(this,a,b)},ready:function(a){e.bindReady(),y.done(a);return this},eq:function(a){return a===-1?this.slice(a):this.slice(a,+a+1)},first:function(){return this.eq(0)},last:function(){return this.eq(-1)},slice:function(){return this.pushStack(D.apply(this,arguments),\"slice\",D.call(arguments).join(\",\"))},map:function(a){return this.pushStack(e.map(this,function(b,c){return a.call(b,c,b)}))},end:function(){return this.prevObject||this.constructor(null)},push:C,sort:[].sort,splice:[].splice},e.fn.init.prototype=e.fn,e.extend=e.fn.extend=function(){var a,c,d,f,g,h,i=arguments[0]||{},j=1,k=arguments.length,l=!1;typeof i==\"boolean\"&&(l=i,i=arguments[1]||{},j=2),typeof i!=\"object\"&&!e.isFunction(i)&&(i={}),k===j&&(i=this,--j);for(;j<k;j++)if((a=arguments[j])!=null)for(c in a){d=i[c],f=a[c];if(i===f)continue;l&&f&&(e.isPlainObject(f)||(g=e.isArray(f)))?(g?(g=!1,h=d&&e.isArray(d)?d:[]):h=d&&e.isPlainObject(d)?d:{},i[c]=e.extend(l,h,f)):f!==b&&(i[c]=f)}return i},e.extend({noConflict:function(b){a.$===e&&(a.$=g),b&&a.jQuery===e&&(a.jQuery=f);return e},isReady:!1,readyWait:1,holdReady:function(a){a?e.readyWait++:e.ready(!0)},ready:function(a){if(a===!0&&!--e.readyWait||a!==!0&&!e.isReady){if(!c.body)return setTimeout(e.ready,1);e.isReady=!0;if(a!==!0&&--e.readyWait>0)return;y.resolveWith(c,[e]),e.fn.trigger&&e(c).trigger(\"ready\").unbind(\"ready\")}},bindReady:function(){if(!y){y=e._Deferred();if(c.readyState===\"complete\")return setTimeout(e.ready,1);if(c.addEventListener)c.addEventListener(\"DOMContentLoaded\",z,!1),a.addEventListener(\"load\",e.ready,!1);else if(c.attachEvent){c.attachEvent(\"onreadystatechange\",z),a.attachEvent(\"onload\",e.ready);var b=!1;try{b=a.frameElement==null}catch(d){}c.documentElement.doScroll&&b&&H()}}},isFunction:function(a){return e.type(a)===\"function\"},isArray:Array.isArray||function(a){return e.type(a)===\"array\"},isWindow:function(a){return a&&typeof a==\"object\"&&\"setInterval\"in a},isNaN:function(a){return a==null||!m.test(a)||isNaN(a)},type:function(a){return a==null?String(a):G[A.call(a)]||\"object\"},isPlainObject:function(a){if(!a||e.type(a)!==\"object\"||a.nodeType||e.isWindow(a))return!1;if(a.constructor&&!B.call(a,\"constructor\")&&!B.call(a.constructor.prototype,\"isPrototypeOf\"))return!1;var c;for(c in a);return c===b||B.call(a,c)},isEmptyObject:function(a){for(var b in a)return!1;return!0},error:function(a){throw a},parseJSON:function(b){if(typeof b!=\"string\"||!b)return null;b=e.trim(b);if(a.JSON&&a.JSON.parse)return a.JSON.parse(b);if(o.test(b.replace(p,\"@\").replace(q,\"]\").replace(r,\"\")))return(new Function(\"return \"+b))();e.error(\"Invalid JSON: \"+b)},parseXML:function(b,c,d){a.DOMParser?(d=new DOMParser,c=d.parseFromString(b,\"text/xml\")):(c=new ActiveXObject(\"Microsoft.XMLDOM\"),c.async=\"false\",c.loadXML(b)),d=c.documentElement,(!d||!d.nodeName||d.nodeName===\"parsererror\")&&e.error(\"Invalid XML: \"+b);return c},noop:function(){},globalEval:function(b){b&&j.test(b)&&(a.execScript||function(b){a.eval.call(a,b)})(b)},nodeName:function(a,b){return a.nodeName&&a.nodeName.toUpperCase()===b.toUpperCase()},each:function(a,c,d){var f,g=0,h=a.length,i=h===b||e.isFunction(a);if(d){if(i){for(f in a)if(c.apply(a[f],d)===!1)break}else for(;g<h;)if(c.apply(a[g++],d)===!1)break}else if(i){for(f in a)if(c.call(a[f],f,a[f])===!1)break}else for(;g<h;)if(c.call(a[g],g,a[g++])===!1)break;return a},trim:E?function(a){return a==null?\"\":E.call(a)}:function(a){return a==null?\"\":(a+\"\").replace(k,\"\").replace(l,\"\")},makeArray:function(a,b){var c=b||[];if(a!=null){var d=e.type(a);a.length==null||d===\"string\"||d===\"function\"||d===\"regexp\"||e.isWindow(a)?C.call(c,a):e.merge(c,a)}return c},inArray:function(a,b){if(F)return F.call(b,a);for(var c=0,d=b.length;c<d;c++)if(b[c]===a)return c;return-1},merge:function(a,c){var d=a.length,e=0;if(typeof c.length==\"number\")for(var f=c.length;e<f;e++)a[d++]=c[e];else while(c[e]!==b)a[d++]=c[e++];a.length=d;return a},grep:function(a,b,c){var d=[],e;c=!!c;for(var f=0,g=a.length;f<g;f++)e=!!b(a[f],f),c!==e&&d.push(a[f]);return d},map:function(a,c,d){var f,g,h=[],i=0,j=a.length,k=a instanceof e||j!==b&&typeof j==\"number\"&&(j>0&&a[0]&&a[j-1]||j===0||e.isArray(a));if(k)for(;i<j;i++)f=c(a[i],i,d),f!=null&&(h[h.length]=f);else for(g in a)f=c(a[g],g,d),f!=null&&(h[h.length]=f);return h.concat.apply([],h)},guid:1,proxy:function(a,c){if(typeof c==\"string\"){var d=a[c];c=a,a=d}if(!e.isFunction(a))return b;var f=D.call(arguments,2),g=function(){return a.apply(c,f.concat(D.call(arguments)))};g.guid=a.guid=a.guid||g.guid||e.guid++;return g},access:function(a,c,d,f,g,h){var i=a.length;if(typeof c==\"object\"){for(var j in c)e.access(a,j,c[j],f,g,d);return a}if(d!==b){f=!h&&f&&e.isFunction(d);for(var k=0;k<i;k++)g(a[k],c,f?d.call(a[k],k,g(a[k],c)):d,h);return a}return i?g(a[0],c):b},now:function(){return(new Date).getTime()},uaMatch:function(a){a=a.toLowerCase();var b=s.exec(a)||t.exec(a)||u.exec(a)||a.indexOf(\"compatible\")<0&&v.exec(a)||[];return{browser:b[1]||\"\",version:b[2]||\"0\"}},sub:function(){function a(b,c){return new a.fn.init(b,c)}e.extend(!0,a,this),a.superclass=this,a.fn=a.prototype=this(),a.fn.constructor=a,a.sub=this.sub,a.fn.init=function(d,f){f&&f instanceof e&&!(f instanceof a)&&(f=a(f));return e.fn.init.call(this,d,f,b)},a.fn.init.prototype=a.fn;var b=a(c);return a},browser:{}}),e.each(\"Boolean Number String Function Array Date RegExp Object\".split(\" \"),function(a,b){G[\"[object \"+b+\"]\"]=b.toLowerCase()}),x=e.uaMatch(w),x.browser&&(e.browser[x.browser]=!0,e.browser.version=x.version),e.browser.webkit&&(e.browser.safari=!0),j.test(\" \")&&(k=/^[\\s\\xA0]+/,l=/[\\s\\xA0]+$/),h=e(c),c.addEventListener?z=function(){c.removeEventListener(\"DOMContentLoaded\",z,!1),e.ready()}:c.attachEvent&&(z=function(){c.readyState===\"complete\"&&(c.detachEvent(\"onreadystatechange\",z),e.ready())});return e}(),g=\"done fail isResolved isRejected promise then always pipe\".split(\" \"),h=[].slice;f.extend({_Deferred:function(){var a=[],b,c,d,e={done:function(){if(!d){var c=arguments,g,h,i,j,k;b&&(k=b,b=0);for(g=0,h=c.length;g<h;g++)i=c[g],j=f.type(i),j===\"array\"?e.done.apply(e,i):j===\"function\"&&a.push(i);k&&e.resolveWith(k[0],k[1])}return this},resolveWith:function(e,f){if(!d&&!b&&!c){f=f||[],c=1;try{while(a[0])a.shift().apply(e,f)}finally{b=[e,f],c=0}}return this},resolve:function(){e.resolveWith(this,arguments);return this},isResolved:function(){return!!c||!!b},cancel:function(){d=1,a=[];return this}};return e},Deferred:function(a){var b=f._Deferred(),c=f._Deferred(),d;f.extend(b,{then:function(a,c){b.done(a).fail(c);return this},always:function(){return b.done.apply(b,arguments).fail.apply(this,arguments)},fail:c.done,rejectWith:c.resolveWith,reject:c.resolve,isRejected:c.isResolved,pipe:function(a,c){return f.Deferred(function(d){f.each({done:[a,\"resolve\"],fail:[c,\"reject\"]},function(a,c){var e=c[0],g=c[1],h;f.isFunction(e)?b[a](function(){h=e.apply(this,arguments),h&&f.isFunction(h.promise)?h.promise().then(d.resolve,d.reject):d[g](h)}):b[a](d[g])})}).promise()},promise:function(a){if(a==null){if(d)return d;d=a={}}var c=g.length;while(c--)a[g[c]]=b[g[c]];return a}}),b.done(c.cancel).fail(b.cancel),delete b.cancel,a&&a.call(b,b);return b},when:function(a){function i(a){return function(c){b[a]=arguments.length>1?h.call(arguments,0):c,--e||g.resolveWith(g,h.call(b,0))}}var b=arguments,c=0,d=b.length,e=d,g=d<=1&&a&&f.isFunction(a.promise)?a:f.Deferred();if(d>1){for(;c<d;c++)b[c]&&f.isFunction(b[c].promise)?b[c].promise().then(i(c),g.reject):--e;e||g.resolveWith(g,b)}else g!==a&&g.resolveWith(g,d?[a]:[]);return g.promise()}}),f.support=function(){var a=c.createElement(\"div\"),b=c.documentElement,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r;a.setAttribute(\"className\",\"t\"),a.innerHTML=\"   <link/><table></table><a href='/a' style='top:1px;float:left;opacity:.55;'>a</a><input type='checkbox'/>\",d=a.getElementsByTagName(\"*\"),e=a.getElementsByTagName(\"a\")[0];if(!d||!d.length||!e)return{};f=c.createElement(\"select\"),g=f.appendChild(c.createElement(\"option\")),h=a.getElementsByTagName(\"input\")[0],j={leadingWhitespace:a.firstChild.nodeType===3,tbody:!a.getElementsByTagName(\"tbody\").length,htmlSerialize:!!a.getElementsByTagName(\"link\").length,style:/top/.test(e.getAttribute(\"style\")),hrefNormalized:e.getAttribute(\"href\")===\"/a\",opacity:/^0.55$/.test(e.style.opacity),cssFloat:!!e.style.cssFloat,checkOn:h.value===\"on\",optSelected:g.selected,getSetAttribute:a.className!==\"t\",submitBubbles:!0,changeBubbles:!0,focusinBubbles:!1,deleteExpando:!0,noCloneEvent:!0,inlineBlockNeedsLayout:!1,shrinkWrapBlocks:!1,reliableMarginRight:!0},h.checked=!0,j.noCloneChecked=h.cloneNode(!0).checked,f.disabled=!0,j.optDisabled=!g.disabled;try{delete a.test}catch(s){j.deleteExpando=!1}!a.addEventListener&&a.attachEvent&&a.fireEvent&&(a.attachEvent(\"onclick\",function b(){j.noCloneEvent=!1,a.detachEvent(\"onclick\",b)}),a.cloneNode(!0).fireEvent(\"onclick\")),h=c.createElement(\"input\"),h.value=\"t\",h.setAttribute(\"type\",\"radio\"),j.radioValue=h.value===\"t\",h.setAttribute(\"checked\",\"checked\"),a.appendChild(h),k=c.createDocumentFragment(),k.appendChild(a.firstChild),j.checkClone=k.cloneNode(!0).cloneNode(!0).lastChild.checked,a.innerHTML=\"\",a.style.width=a.style.paddingLeft=\"1px\",l=c.createElement(\"body\"),m={visibility:\"hidden\",width:0,height:0,border:0,margin:0,background:\"none\"};for(q in m)l.style[q]=m[q];l.appendChild(a),b.insertBefore(l,b.firstChild),j.appendChecked=h.checked,j.boxModel=a.offsetWidth===2,\"zoom\"in a.style&&(a.style.display=\"inline\",a.style.zoom=1,j.inlineBlockNeedsLayout=a.offsetWidth===2,a.style.display=\"\",a.innerHTML=\"<div style='width:4px;'></div>\",j.shrinkWrapBlocks=a.offsetWidth!==2),a.innerHTML=\"<table><tr><td style='padding:0;border:0;display:none'></td><td>t</td></tr></table>\",n=a.getElementsByTagName(\"td\"),r=n[0].offsetHeight===0,n[0].style.display=\"\",n[1].style.display=\"none\",j.reliableHiddenOffsets=r&&n[0].offsetHeight===0,a.innerHTML=\"\",c.defaultView&&c.defaultView.getComputedStyle&&(i=c.createElement(\"div\"),i.style.width=\"0\",i.style.marginRight=\"0\",a.appendChild(i),j.reliableMarginRight=(parseInt((c.defaultView.getComputedStyle(i,null)||{marginRight:0}).marginRight,10)||0)===0),l.innerHTML=\"\",b.removeChild(l);if(a.attachEvent)for(q in{submit:1,change:1,focusin:1})p=\"on\"+q,r=p in a,r||(a.setAttribute(p,\"return;\"),r=typeof a[p]==\"function\"),j[q+\"Bubbles\"]=r;return j}(),f.boxModel=f.support.boxModel;var i=/^(?:\\{.*\\}|\\[.*\\])$/,j=/([a-z])([A-Z])/g;f.extend({cache:{},uuid:0,expando:\"jQuery\"+(f.fn.jquery+Math.random()).replace(/\\D/g,\"\"),noData:{embed:!0,object:\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\",applet:!0},hasData:function(a){a=a.nodeType?f.cache[a[f.expando]]:a[f.expando];return!!a&&!l(a)},data:function(a,c,d,e){if(!!f.acceptData(a)){var g=f.expando,h=typeof c==\"string\",i,j=a.nodeType,k=j?f.cache:a,l=j?a[f.expando]:a[f.expando]&&f.expando;if((!l||e&&l&&!k[l][g])&&h&&d===b)return;l||(j?a[f.expando]=l=++f.uuid:l=f.expando),k[l]||(k[l]={},j||(k[l].toJSON=f.noop));if(typeof c==\"object\"||typeof c==\"function\")e?k[l][g]=f.extend(k[l][g],c):k[l]=f.extend(k[l],c);i=k[l],e&&(i[g]||(i[g]={}),i=i[g]),d!==b&&(i[f.camelCase(c)]=d);if(c===\"events\"&&!i[c])return i[g]&&i[g].events;return h?i[f.camelCase(c)]:i}},removeData:function(b,c,d){if(!!f.acceptData(b)){var e=f.expando,g=b.nodeType,h=g?f.cache:b,i=g?b[f.expando]:f.expando;if(!h[i])return;if(c){var j=d?h[i][e]:h[i];if(j){delete j[c];if(!l(j))return}}if(d){delete h[i][e];if(!l(h[i]))return}var k=h[i][e];f.support.deleteExpando||h!=a?delete h[i]:h[i]=null,k?(h[i]={},g||(h[i].toJSON=f.noop),h[i][e]=k):g&&(f.support.deleteExpando?delete b[f.expando]:b.removeAttribute?b.removeAttribute(f.expando):b[f.expando]=null)}},_data:function(a,b,c){return f.data(a,b,c,!0)},acceptData:function(a){if(a.nodeName){var b=f.noData[a.nodeName.toLowerCase()];if(b)return b!==!0&&a.getAttribute(\"classid\")===b}return!0}}),f.fn.extend({data:function(a,c){var d=null;if(typeof a==\"undefined\"){if(this.length){d=f.data(this[0]);if(this[0].nodeType===1){var e=this[0].attributes,g;for(var h=0,i=e.length;h<i;h++)g=e[h].name,g.indexOf(\"data-\")===0&&(g=f.camelCase(g.substring(5)),k(this[0],g,d[g]))}}return d}if(typeof a==\"object\")return this.each(function(){f.data(this,a)});var j=a.split(\".\");j[1]=j[1]?\".\"+j[1]:\"\";if(c===b){d=this.triggerHandler(\"getData\"+j[1]+\"!\",[j[0]]),d===b&&this.length&&(d=f.data(this[0],a),d=k(this[0],a,d));return d===b&&j[1]?this.data(j[0]):d}return this.each(function(){var b=f(this),d=[j[0],c];b.triggerHandler(\"setData\"+j[1]+\"!\",d),f.data(this,a,c),b.triggerHandler(\"changeData\"+j[1]+\"!\",d)})},removeData:function(a){return this.each(function(){f.removeData(this,a)})}}),f.extend({_mark:function(a,c){a&&(c=(c||\"fx\")+\"mark\",f.data(a,c,(f.data(a,c,b,!0)||0)+1,!0))},_unmark:function(a,c,d){a!==!0&&(d=c,c=a,a=!1);if(c){d=d||\"fx\";var e=d+\"mark\",g=a?0:(f.data(c,e,b,!0)||1)-1;g?f.data(c,e,g,!0):(f.removeData(c,e,!0),m(c,d,\"mark\"))}},queue:function(a,c,d){if(a){c=(c||\"fx\")+\"queue\";var e=f.data(a,c,b,!0);d&&(!e||f.isArray(d)?e=f.data(a,c,f.makeArray(d),!0):e.push(d));return e||[]}},dequeue:function(a,b){b=b||\"fx\";var c=f.queue(a,b),d=c.shift(),e;d===\"inprogress\"&&(d=c.shift()),d&&(b===\"fx\"&&c.unshift(\"inprogress\"),d.call(a,function(){f.dequeue(a,b)})),c.length||(f.removeData(a,b+\"queue\",!0),m(a,b,\"queue\"))}}),f.fn.extend({queue:function(a,c){typeof a!=\"string\"&&(c=a,a=\"fx\");if(c===b)return f.queue(this[0],a);return this.each(function(){var b=f.queue(this,a,c);a===\"fx\"&&b[0]!==\"inprogress\"&&f.dequeue(this,a)})},dequeue:function(a){return this.each(function(){f.dequeue(this,a)})},delay:function(a,b){a=f.fx?f.fx.speeds[a]||a:a,b=b||\"fx\";return this.queue(b,function(){var c=this;setTimeout(function(){f.dequeue(c,b)},a)})},clearQueue:function(a){return this.queue(a||\"fx\",[])},promise:function(a,c){function m(){--h||d.resolveWith(e,[e])}typeof a!=\"string\"&&(c=a,a=b),a=a||\"fx\";var d=f.Deferred(),e=this,g=e.length,h=1,i=a+\"defer\",j=a+\"queue\",k=a+\"mark\",l;while(g--)if(l=f.data(e[g],i,b,!0)||(f.data(e[g],j,b,!0)||f.data(e[g],k,b,!0))&&f.data(e[g],i,f._Deferred(),!0))h++,l.done(m);m();return d.promise()}});var n=/[\\n\\t\\r]/g,o=/\\s+/,p=/\\r/g,q=/^(?:button|input)$/i,r=/^(?:button|input|object|select|textarea)$/i,s=/^a(?:rea)?$/i,t=/^(?:autofocus|autoplay|async|checked|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped|selected)$/i,u=/\\:/,v,w;f.fn.extend({attr:function(a,b){return f.access(this,a,b,!0,f.attr)},removeAttr:function(a){return this.each(function(){f.removeAttr(this,a)})},prop:function(a,b){return f.access(this,a,b,!0,f.prop)},removeProp:function(a){a=f.propFix[a]||a;return this.each(function(){try{this[a]=b,delete this[a]}catch(c){}})},addClass:function(a){if(f.isFunction(a))return this.each(function(b){var c=f(this);c.addClass(a.call(this,b,c.attr(\"class\")||\"\"))});if(a&&typeof a==\"string\"){var b=(a||\"\").split(o);for(var c=0,d=this.length;c<d;c++){var e=this[c];if(e.nodeType===1)if(!e.className)e.className=a;else{var g=\" \"+e.className+\" \",h=e.className;for(var i=0,j=b.length;i<j;i++)g.indexOf(\" \"+b[i]+\" \")<0&&(h+=\" \"+b[i]);e.className=f.trim(h)}}}return this},removeClass:function(a){if(f.isFunction(a))return this.each(function(b){var c=f(this);c.removeClass(a.call(this,b,c.attr(\"class\")))});if(a&&typeof a==\"string\"||a===b){var c=(a||\"\").split(o);for(var d=0,e=this.length;d<e;d++){var g=this[d];if(g.nodeType===1&&g.className)if(a){var h=(\" \"+g.className+\" \").replace(n,\" \");for(var i=0,j=c.length;i<j;i++)h=h.replace(\" \"+c[i]+\" \",\" \");g.className=f.trim(h)}else g.className=\"\"}}return this},toggleClass:function(a,b){var c=typeof a,d=typeof b==\"boolean\";if(f.isFunction(a))return this.each(function(c){var d=f(this);d.toggleClass(a.call(this,c,d.attr(\"class\"),b),b)});return this.each(function(){if(c===\"string\"){var e,g=0,h=f(this),i=b,j=a.split(o);while(e=j[g++])i=d?i:!h.hasClass(e),h[i?\"addClass\":\"removeClass\"](e)}else if(c===\"undefined\"||c===\"boolean\")this.className&&f._data(this,\"__className__\",this.className),this.className=this.className||a===!1?\"\":f._data(this,\"__className__\")||\"\"})},hasClass:function(a){var b=\" \"+a+\" \";for(var c=0,d=this.length;c<d;c++)if((\" \"+this[c].className+\" \").replace(n,\" \").indexOf(b)>-1)return!0;return!1},val:function(a){var c,d,e=this[0];if(!arguments.length){if(e){c=f.valHooks[e.nodeName.toLowerCase()]||f.valHooks[e.type];if(c&&\"get\"in c&&(d=c.get(e,\"value\"))!==b)return d;return(e.value||\"\").replace(p,\"\")}return b}var g=f.isFunction(a);return this.each(function(d){var e=f(this),h;if(this.nodeType===1){g?h=a.call(this,d,e.val()):h=a,h==null?h=\"\":typeof h==\"number\"?h+=\"\":f.isArray(h)&&(h=f.map(h,function(a){return a==null?\"\":a+\"\"})),c=f.valHooks[this.nodeName.toLowerCase()]||f.valHooks[this.type];if(!c||!(\"set\"in c)||c.set(this,h,\"value\")===b)this.value=h}})}}),f.extend({valHooks:{option:{get:function(a){var b=a.attributes.value;return!b||b.specified?a.value:a.text}},select:{get:function(a){var b,c=a.selectedIndex,d=[],e=a.options,g=a.type===\"select-one\";if(c<0)return null;for(var h=g?c:0,i=g?c+1:e.length;h<i;h++){var j=e[h];if(j.selected&&(f.support.optDisabled?!j.disabled:j.getAttribute(\"disabled\")===null)&&(!j.parentNode.disabled||!f.nodeName(j.parentNode,\"optgroup\"))){b=f(j).val();if(g)return b;d.push(b)}}if(g&&!d.length&&e.length)return f(e[c]).val();return d},set:function(a,b){var c=f.makeArray(b);f(a).find(\"option\").each(function(){this.selected=f.inArray(f(this).val(),c)>=0}),c.length||(a.selectedIndex=-1);return c}}},attrFn:{val:!0,css:!0,html:!0,text:!0,data:!0,width:!0,height:!0,offset:!0},attrFix:{tabindex:\"tabIndex\"},attr:function(a,c,d,e){var g=a.nodeType;if(!a||g===3||g===8||g===2)return b;if(e&&c in f.attrFn)return f(a)[c](d);if(!(\"getAttribute\"in a))return f.prop(a,c,d);var h,i,j=g!==1||!f.isXMLDoc(a);c=j&&f.attrFix[c]||c,i=f.attrHooks[c],i||(!t.test(c)||typeof d!=\"boolean\"&&d!==b&&d.toLowerCase()!==c.toLowerCase()?v&&(f.nodeName(a,\"form\")||u.test(c))&&(i=v):i=w);if(d!==b){if(d===null){f.removeAttr(a,c);return b}if(i&&\"set\"in i&&j&&(h=i.set(a,d,c))!==b)return h;a.setAttribute(c,\"\"+d);return d}if(i&&\"get\"in i&&j)return i.get(a,c);h=a.getAttribute(c);return h===null?b:h},removeAttr:function(a,b){var c;a.nodeType===1&&(b=f.attrFix[b]||b,f.support.getSetAttribute?a.removeAttribute(b):(f.attr(a,b,\"\"),a.removeAttributeNode(a.getAttributeNode(b))),t.test(b)&&(c=f.propFix[b]||b)in a&&(a[c]=!1))},attrHooks:{type:{set:function(a,b){if(q.test(a.nodeName)&&a.parentNode)f.error(\"type property can't be changed\");else if(!f.support.radioValue&&b===\"radio\"&&f.nodeName(a,\"input\")){var c=a.value;a.setAttribute(\"type\",b),c&&(a.value=c);return b}}},tabIndex:{get:function(a){var c=a.getAttributeNode(\"tabIndex\");return c&&c.specified?parseInt(c.value,10):r.test(a.nodeName)||s.test(a.nodeName)&&a.href?0:b}}},propFix:{tabindex:\"tabIndex\",readonly:\"readOnly\",\"for\":\"htmlFor\",\"class\":\"className\",maxlength:\"maxLength\",cellspacing:\"cellSpacing\",cellpadding:\"cellPadding\",rowspan:\"rowSpan\",colspan:\"colSpan\",usemap:\"useMap\",frameborder:\"frameBorder\",contenteditable:\"contentEditable\"},prop:function(a,c,d){var e=a.nodeType;if(!a||e===3||e===8||e===2)return b;var g,h,i=e!==1||!f.isXMLDoc(a);c=i&&f.propFix[c]||c,h=f.propHooks[c];return d!==b?h&&\"set\"in h&&(g=h.set(a,d,c))!==b?g:a[c]=d:h&&\"get\"in h&&(g=h.get(a,c))!==b?g:a[c]},propHooks:{}}),w={get:function(a,c){return a[f.propFix[c]||c]?c.toLowerCase():b},set:function(a,b,c){var d;b===!1?f.removeAttr(a,c):(d=f.propFix[c]||c,d in a&&(a[d]=b),a.setAttribute(c,c.toLowerCase()));return c}},f.attrHooks.value={get:function(a,b){if(v&&f.nodeName(a,\"button\"))return v.get(a,b);return a.value},set:function(a,b,c){if(v&&f.nodeName(a,\"button\"))return v.set(a,b,c);a.value=b}},f.support.getSetAttribute||(f.attrFix=f.propFix,v=f.attrHooks.name=f.valHooks.button={get:function(a,c){var d;d=a.getAttributeNode(c);return d&&d.nodeValue!==\"\"?d.nodeValue:b},set:function(a,b,c){var d=a.getAttributeNode(c);if(d){d.nodeValue=b;return b}}},f.each([\"width\",\"height\"],function(a,b){f.attrHooks[b]=f.extend(f.attrHooks[b],{set:function(a,c){if(c===\"\"){a.setAttribute(b,\"auto\");return c}}})})),f.support.hrefNormalized||f.each([\"href\",\"src\",\"width\",\"height\"],function(a,c){f.attrHooks[c]=f.extend(f.attrHooks[c],{get:function(a){var d=a.getAttribute(c,2);return d===null?b:d}})}),f.support.style||(f.attrHooks.style={get:function(a){return a.style.cssText.toLowerCase()||b},set:function(a,b){return a.style.cssText=\"\"+b}}),f.support.optSelected||(f.propHooks.selected=f.extend(f.propHooks.selected,{get:function(a){var b=a.parentNode;b&&(b.selectedIndex,b.parentNode&&b.parentNode.selectedIndex)}})),f.support.checkOn||f.each([\"radio\",\"checkbox\"],function(){f.valHooks[this]={get:function(a){return a.getAttribute(\"value\")===null?\"on\":a.value}}}),f.each([\"radio\",\"checkbox\"],function(){f.valHooks[this]=f.extend(f.valHooks[this],{set:function(a,b){if(f.isArray(b))return a.checked=f.inArray(f(a).val(),b)>=0}})});var x=Object.prototype.hasOwnProperty,y=/\\.(.*)$/,z=/^(?:textarea|input|select)$/i,A=/\\./g,B=/ /g,C=/[^\\w\\s.|`]/g,D=function(a){return a.replace(C,\"\\\\$&\")};f.event={add:function(a,c,d,e){if(a.nodeType!==3&&a.nodeType!==8){if(d===!1)d=E;else if(!d)return;var g,h;d.handler&&(g=d,d=g.handler),d.guid||(d.guid=f.guid++);var i=f._data(a);if(!i)return;var j=i.events,k=i.handle;j||(i.events=j={}),k||(i.handle=k=function(a){return typeof f!=\"undefined\"&&(!a||f.event.triggered!==a.type)?f.event.handle.apply(k.elem,arguments):b}),k.elem=a,c=c.split(\" \");var l,m=0,n;while(l=c[m++]){h=g?f.extend({},g):{handler:d,data:e},l.indexOf(\".\")>-1?(n=l.split(\".\"),l=n.shift(),h.namespace=n.slice(0).sort().join(\".\")):(n=[],h.namespace=\"\"),h.type=l,h.guid||(h.guid=d.guid);var o=j[l],p=f.event.special[l]||{};if(!o){o=j[l]=[];if(!p.setup||p.setup.call(a,e,n,k)===!1)a.addEventListener?a.addEventListener(l,k,!1):a.attachEvent&&a.attachEvent(\"on\"+l,k)}p.add&&(p.add.call(a,h),h.handler.guid||(h.handler.guid=d.guid)),o.push(h),f.event.global[l]=!0}a=null}},global:{},remove:function(a,c,d,e){if(a.nodeType!==3&&a.nodeType!==8){d===!1&&(d=E);var g,h,i,j,k=0,l,m,n,o,p,q,r,s=f.hasData(a)&&f._data(a),t=s&&s.events;if(!s||!t)return;c&&c.type&&(d=c.handler,c=c.type);if(!c||typeof c==\"string\"&&c.charAt(0)===\".\"){c=c||\"\";for(h in t)f.event.remove(a,h+c);return}c=c.split(\" \");while(h=c[k++]){r=h,q=null,l=h.indexOf(\".\")<0,m=[],l||(m=h.split(\".\"),h=m.shift(),n=new RegExp(\"(^|\\\\.)\"+f.map(m.slice(0).sort(),D).join(\"\\\\.(?:.*\\\\.)?\")+\"(\\\\.|$)\")),p=t[h];if(!p)continue;if(!d){for(j=0;j<p.length;j++){q=p[j];if(l||n.test(q.namespace))f.event.remove(a,r,q.handler,j),p.splice(j--,1)}continue}o=f.event.special[h]||{};for(j=e||0;j<p.length;j++){q=p[j];if(d.guid===q.guid){if(l||n.test(q.namespace))e==null&&p.splice(j--,1),o.remove&&o.remove.call(a,q);if(e!=null)break}}if(p.length===0||e!=null&&p.length===1)(!o.teardown||o.teardown.call(a,m)===!1)&&f.removeEvent(a,h,s.handle),g=null,delete t[h]}if(f.isEmptyObject(t)){var u=s.handle;u&&(u.elem=null),delete s.events,delete s.handle,f.isEmptyObject(s)&&f.removeData(a,b,!0)}}},customEvent:{getData:!0,setData:!0,changeData:!0},trigger:function(c,d,e,g){var h=c.type||c,i=[],j;h.indexOf(\"!\")>=0&&(h=h.slice(0,-1),j=!0),h.indexOf(\".\")>=0&&(i=h.split(\".\"),h=i.shift(),i.sort());if(!!e&&!f.event.customEvent[h]||!!f.event.global[h]){c=typeof c==\"object\"?c[f.expando]?c:new f.Event(h,c):new f.Event(h),c.type=h,c.exclusive=j,c.namespace=i.join(\".\"),c.namespace_re=new RegExp(\"(^|\\\\.)\"+i.join(\"\\\\.(?:.*\\\\.)?\")+\"(\\\\.|$)\");if(g||!e)c.preventDefault(),c.stopPropagation();if(!e){f.each(f.cache,function(){var a=f.expando,b=this[a];b&&b.events&&b.events[h]&&f.event.trigger(c,d,b.handle.elem" +
					")});return}if(e.nodeType===3||e.nodeType===8)return;c.result=b,c.target=e,d=d?f.makeArray(d):[],d.unshift(c);var k=e,l=h.indexOf(\":\")<0?\"on\"+h:\"\";do{var m=f._data(k,\"handle\");c.currentTarget=k,m&&m.apply(k,d),l&&f.acceptData(k)&&k[l]&&k[l].apply(k,d)===!1&&(c.result=!1,c.preventDefault()),k=k.parentNode||k.ownerDocument||k===c.target.ownerDocument&&a}while(k&&!c.isPropagationStopped());if(!c.isDefaultPrevented()){var n,o=f.event.special[h]||{};if((!o._default||o._default.call(e.ownerDocument,c)===!1)&&(h!==\"click\"||!f.nodeName(e,\"a\"))&&f.acceptData(e)){try{l&&e[h]&&(n=e[l],n&&(e[l]=null),f.event.triggered=h,e[h]())}catch(p){}n&&(e[l]=n),f.event.triggered=b}}return c.result}},handle:function(c){c=f.event.fix(c||a.event);var d=((f._data(this,\"events\")||{})[c.type]||[]).slice(0),e=!c.exclusive&&!c.namespace,g=Array.prototype.slice.call(arguments,0);g[0]=c,c.currentTarget=this;for(var h=0,i=d.length;h<i;h++){var j=d[h];if(e||c.namespace_re.test(j.namespace)){c.handler=j.handler,c.data=j.data,c.handleObj=j;var k=j.handler.apply(this,g);k!==b&&(c.result=k,k===!1&&(c.preventDefault(),c.stopPropagation()));if(c.isImmediatePropagationStopped())break}}return c.result},props:\"altKey attrChange attrName bubbles button cancelable charCode clientX clientY ctrlKey currentTarget data detail eventPhase fromElement handler keyCode layerX layerY metaKey newValue offsetX offsetY pageX pageY prevValue relatedNode relatedTarget screenX screenY shiftKey srcElement target toElement view wheelDelta which\".split(\" \"),fix:function(a){if(a[f.expando])return a;var d=a;a=f.Event(d);for(var e=this.props.length,g;e;)g=this.props[--e],a[g]=d[g];a.target||(a.target=a.srcElement||c),a.target.nodeType===3&&(a.target=a.target.parentNode),!a.relatedTarget&&a.fromElement&&(a.relatedTarget=a.fromElement===a.target?a.toElement:a.fromElement);if(a.pageX==null&&a.clientX!=null){var h=a.target.ownerDocument||c,i=h.documentElement,j=h.body;a.pageX=a.clientX+(i&&i.scrollLeft||j&&j.scrollLeft||0)-(i&&i.clientLeft||j&&j.clientLeft||0),a.pageY=a.clientY+(i&&i.scrollTop||j&&j.scrollTop||0)-(i&&i.clientTop||j&&j.clientTop||0)}a.which==null&&(a.charCode!=null||a.keyCode!=null)&&(a.which=a.charCode!=null?a.charCode:a.keyCode),!a.metaKey&&a.ctrlKey&&(a.metaKey=a.ctrlKey),!a.which&&a.button!==b&&(a.which=a.button&1?1:a.button&2?3:a.button&4?2:0);return a},guid:1e8,proxy:f.proxy,special:{ready:{setup:f.bindReady,teardown:f.noop},live:{add:function(a){f.event.add(this,O(a.origType,a.selector),f.extend({},a,{handler:N,guid:a.handler.guid}))},remove:function(a){f.event.remove(this,O(a.origType,a.selector),a)}},beforeunload:{setup:function(a,b,c){f.isWindow(this)&&(this.onbeforeunload=c)},teardown:function(a,b){this.onbeforeunload===b&&(this.onbeforeunload=null)}}}},f.removeEvent=c.removeEventListener?function(a,b,c){a.removeEventListener&&a.removeEventListener(b,c,!1)}:function(a,b,c){a.detachEvent&&a.detachEvent(\"on\"+b,c)},f.Event=function(a,b){if(!this.preventDefault)return new f.Event(a,b);a&&a.type?(this.originalEvent=a,this.type=a.type,this.isDefaultPrevented=a.defaultPrevented||a.returnValue===!1||a.getPreventDefault&&a.getPreventDefault()?F:E):this.type=a,b&&f.extend(this,b),this.timeStamp=f.now(),this[f.expando]=!0},f.Event.prototype={preventDefault:function(){this.isDefaultPrevented=F;var a=this.originalEvent;!a||(a.preventDefault?a.preventDefault():a.returnValue=!1)},stopPropagation:function(){this.isPropagationStopped=F;var a=this.originalEvent;!a||(a.stopPropagation&&a.stopPropagation(),a.cancelBubble=!0)},stopImmediatePropagation:function(){this.isImmediatePropagationStopped=F,this.stopPropagation()},isDefaultPrevented:E,isPropagationStopped:E,isImmediatePropagationStopped:E};var G=function(a){var b=a.relatedTarget;a.type=a.data;try{if(b&&b!==c&&!b.parentNode)return;while(b&&b!==this)b=b.parentNode;b!==this&&f.event.handle.apply(this,arguments)}catch(d){}},H=function(a){a.type=a.data,f.event.handle.apply(this,arguments)};f.each({mouseenter:\"mouseover\",mouseleave:\"mouseout\"},function(a,b){f.event.special[a]={setup:function(c){f.event.add(this,b,c&&c.selector?H:G,a)},teardown:function(a){f.event.remove(this,b,a&&a.selector?H:G)}}}),f.support.submitBubbles||(f.event.special.submit={setup:function(a,b){if(!f.nodeName(this,\"form\"))f.event.add(this,\"click.specialSubmit\",function(a){var b=a.target,c=b.type;(c===\"submit\"||c===\"image\")&&f(b).closest(\"form\").length&&L(\"submit\",this,arguments)}),f.event.add(this,\"keypress.specialSubmit\",function(a){var b=a.target,c=b.type;(c===\"text\"||c===\"password\")&&f(b).closest(\"form\").length&&a.keyCode===13&&L(\"submit\",this,arguments)});else return!1},teardown:function(a){f.event.remove(this,\".specialSubmit\")}});if(!f.support.changeBubbles){var I,J=function(a){var b=a.type,c=a.value;b===\"radio\"||b===\"checkbox\"?c=a.checked:b===\"select-multiple\"?c=a.selectedIndex>-1?f.map(a.options,function(a){return a.selected}).join(\"-\"):\"\":f.nodeName(a,\"select\")&&(c=a.selectedIndex);return c},K=function(c){var d=c.target,e,g;if(!!z.test(d.nodeName)&&!d.readOnly){e=f._data(d,\"_change_data\"),g=J(d),(c.type!==\"focusout\"||d.type!==\"radio\")&&f._data(d,\"_change_data\",g);if(e===b||g===e)return;if(e!=null||g)c.type=\"change\",c.liveFired=b,f.event.trigger(c,arguments[1],d)}};f.event.special.change={filters:{focusout:K,beforedeactivate:K,click:function(a){var b=a.target,c=f.nodeName(b,\"input\")?b.type:\"\";(c===\"radio\"||c===\"checkbox\"||f.nodeName(b,\"select\"))&&K.call(this,a)},keydown:function(a){var b=a.target,c=f.nodeName(b,\"input\")?b.type:\"\";(a.keyCode===13&&!f.nodeName(b,\"textarea\")||a.keyCode===32&&(c===\"checkbox\"||c===\"radio\")||c===\"select-multiple\")&&K.call(this,a)},beforeactivate:function(a){var b=a.target;f._data(b,\"_change_data\",J(b))}},setup:function(a,b){if(this.type===\"file\")return!1;for(var c in I)f.event.add(this,c+\".specialChange\",I[c]);return z.test(this.nodeName)},teardown:function(a){f.event.remove(this,\".specialChange\");return z.test(this.nodeName)}},I=f.event.special.change.filters,I.focus=I.beforeactivate}f.support.focusinBubbles||f.each({focus:\"focusin\",blur:\"focusout\"},function(a,b){function e(a){var c=f.event.fix(a);c.type=b,c.originalEvent={},f.event.trigger(c,null,c.target),c.isDefaultPrevented()&&a.preventDefault()}var d=0;f.event.special[b]={setup:function(){d++===0&&c.addEventListener(a,e,!0)},teardown:function(){--d===0&&c.removeEventListener(a,e,!0)}}}),f.each([\"bind\",\"one\"],function(a,c){f.fn[c]=function(a,d,e){var g;if(typeof a==\"object\"){for(var h in a)this[c](h,d,a[h],e);return this}if(arguments.length===2||d===!1)e=d,d=b;c===\"one\"?(g=function(a){f(this).unbind(a,g);return e.apply(this,arguments)},g.guid=e.guid||f.guid++):g=e;if(a===\"unload\"&&c!==\"one\")this.one(a,d,e);else for(var i=0,j=this.length;i<j;i++)f.event.add(this[i],a,g,d);return this}}),f.fn.extend({unbind:function(a,b){if(typeof a==\"object\"&&!a.preventDefault)for(var c in a)this.unbind(c,a[c]);else for(var d=0,e=this.length;d<e;d++)f.event.remove(this[d],a,b);return this},delegate:function(a,b,c,d){return this.live(b,c,d,a)},undelegate:function(a,b,c){return arguments.length===0?this.unbind(\"live\"):this.die(b,null,c,a)},trigger:function(a,b){return this.each(function(){f.event.trigger(a,b,this)})},triggerHandler:function(a,b){if(this[0])return f.event.trigger(a,b,this[0],!0)},toggle:function(a){var b=arguments,c=a.guid||f.guid++,d=0,e=function(c){var e=(f.data(this,\"lastToggle\"+a.guid)||0)%d;f.data(this,\"lastToggle\"+a.guid,e+1),c.preventDefault();return b[e].apply(this,arguments)||!1};e.guid=c;while(d<b.length)b[d++].guid=c;return this.click(e)},hover:function(a,b){return this.mouseenter(a).mouseleave(b||a)}});var M={focus:\"focusin\",blur:\"focusout\",mouseenter:\"mouseover\",mouseleave:\"mouseout\"};f.each([\"live\",\"die\"],function(a,c){f.fn[c]=function(a,d,e,g){var h,i=0,j,k,l,m=g||this.selector,n=g?this:f(this.context);if(typeof a==\"object\"&&!a.preventDefault){for(var o in a)n[c](o,d,a[o],m);return this}if(c===\"die\"&&!a&&g&&g.charAt(0)===\".\"){n.unbind(g);return this}if(d===!1||f.isFunction(d))e=d||E,d=b;a=(a||\"\").split(\" \");while((h=a[i++])!=null){j=y.exec(h),k=\"\",j&&(k=j[0],h=h.replace(y,\"\"));if(h===\"hover\"){a.push(\"mouseenter\"+k,\"mouseleave\"+k);continue}l=h,M[h]?(a.push(M[h]+k),h=h+k):h=(M[h]||h)+k;if(c===\"live\")for(var p=0,q=n.length;p<q;p++)f.event.add(n[p],\"live.\"+O(h,m),{data:d,selector:m,handler:e,origType:h,origHandler:e,preType:l});else n.unbind(\"live.\"+O(h,m),e)}return this}}),f.each(\"blur focus focusin focusout load resize scroll unload click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup error\".split(\" \"),function(a,b){f.fn[b]=function(a,c){c==null&&(c=a,a=null);return arguments.length>0?this.bind(b,a,c):this.trigger(b)},f.attrFn&&(f.attrFn[b]=!0)}),function(){function u(a,b,c,d,e,f){for(var g=0,h=d.length;g<h;g++){var i=d[g];if(i){var j=!1;i=i[a];while(i){if(i.sizcache===c){j=d[i.sizset];break}if(i.nodeType===1){f||(i.sizcache=c,i.sizset=g);if(typeof b!=\"string\"){if(i===b){j=!0;break}}else if(k.filter(b,[i]).length>0){j=i;break}}i=i[a]}d[g]=j}}}function t(a,b,c,d,e,f){for(var g=0,h=d.length;g<h;g++){var i=d[g];if(i){var j=!1;i=i[a];while(i){if(i.sizcache===c){j=d[i.sizset];break}i.nodeType===1&&!f&&(i.sizcache=c,i.sizset=g);if(i.nodeName.toLowerCase()===b){j=i;break}i=i[a]}d[g]=j}}}var a=/((?:\\((?:\\([^()]+\\)|[^()]+)+\\)|\\[(?:\\[[^\\[\\]]*\\]|['\"][^'\"]*['\"]|[^\\[\\]'\"]+)+\\]|\\\\.|[^ >+~,(\\[\\\\]+)+|[>+~])(\\s*,\\s*)?((?:.|\\r|\\n)*)/g,d=0,e=Object.prototype.toString,g=!1,h=!0,i=/\\\\/g,j=/\\W/;[0,0].sort(function(){h=!1;return 0});var k=function(b,d,f,g){f=f||[],d=d||c;var h=d;if(d.nodeType!==1&&d.nodeType!==9)return[];if(!b||typeof b!=\"string\")return f;var i,j,n,o,q,r,s,t,u=!0,w=k.isXML(d),x=[],y=b;do{a.exec(\"\"),i=a.exec(y);if(i){y=i[3],x.push(i[1]);if(i[2]){o=i[3];break}}}while(i);if(x.length>1&&m.exec(b))if(x.length===2&&l.relative[x[0]])j=v(x[0]+x[1],d);else{j=l.relative[x[0]]?[d]:k(x.shift(),d);while(x.length)b=x.shift(),l.relative[b]&&(b+=x.shift()),j=v(b,j)}else{!g&&x.length>1&&d.nodeType===9&&!w&&l.match.ID.test(x[0])&&!l.match.ID.test(x[x.length-1])&&(q=k.find(x.shift(),d,w),d=q.expr?k.filter(q.expr,q.set)[0]:q.set[0]);if(d){q=g?{expr:x.pop(),set:p(g)}:k.find(x.pop(),x.length===1&&(x[0]===\"~\"||x[0]===\"+\")&&d.parentNode?d.parentNode:d,w),j=q.expr?k.filter(q.expr,q.set):q.set,x.length>0?n=p(j):u=!1;while(x.length)r=x.pop(),s=r,l.relative[r]?s=x.pop():r=\"\",s==null&&(s=d),l.relative[r](n,s,w)}else n=x=[]}n||(n=j),n||k.error(r||b);if(e.call(n)===\"[object Array]\")if(!u)f.push.apply(f,n);else if(d&&d.nodeType===1)for(t=0;n[t]!=null;t++)n[t]&&(n[t]===!0||n[t].nodeType===1&&k.contains(d,n[t]))&&f.push(j[t]);else for(t=0;n[t]!=null;t++)n[t]&&n[t].nodeType===1&&f.push(j[t]);else p(n,f);o&&(k(o,h,f,g),k.uniqueSort(f));return f};k.uniqueSort=function(a){if(r){g=h,a.sort(r);if(g)for(var b=1;b<a.length;b++)a[b]===a[b-1]&&a.splice(b--,1)}return a},k.matches=function(a,b){return k(a,null,null,b)},k.matchesSelector=function(a,b){return k(b,null,null,[a]).length>0},k.find=function(a,b,c){var d;if(!a)return[];for(var e=0,f=l.order.length;e<f;e++){var g,h=l.order[e];if(g=l.leftMatch[h].exec(a)){var j=g[1];g.splice(1,1);if(j.substr(j.length-1)!==\"\\\\\"){g[1]=(g[1]||\"\").replace(i,\"\"),d=l.find[h](g,b,c);if(d!=null){a=a.replace(l.match[h],\"\");break}}}}d||(d=typeof b.getElementsByTagName!=\"undefined\"?b.getElementsByTagName(\"*\"):[]);return{set:d,expr:a}},k.filter=function(a,c,d,e){var f,g,h=a,i=[],j=c,m=c&&c[0]&&k.isXML(c[0]);while(a&&c.length){for(var n in l.filter)if((f=l.leftMatch[n].exec(a))!=null&&f[2]){var o,p,q=l.filter[n],r=f[1];g=!1,f.splice(1,1);if(r.substr(r.length-1)===\"\\\\\")continue;j===i&&(i=[]);if(l.preFilter[n]){f=l.preFilter[n](f,j,d,i,e,m);if(!f)g=o=!0;else if(f===!0)continue}if(f)for(var s=0;(p=j[s])!=null;s++)if(p){o=q(p,f,s,j);var t=e^!!o;d&&o!=null?t?g=!0:j[s]=!1:t&&(i.push(p),g=!0)}if(o!==b){d||(j=i),a=a.replace(l.match[n],\"\");if(!g)return[];break}}if(a===h)if(g==null)k.error(a);else break;h=a}return j},k.error=function(a){throw\"Syntax error, unrecognized expression: \"+a};var l=k.selectors={order:[\"ID\",\"NAME\",\"TAG\"],match:{ID:/#((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)/,CLASS:/\\.((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)/,NAME:/\\[name=['\"]*((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)['\"]*\\]/,ATTR:/\\[\\s*((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)\\s*(?:(\\S?=)\\s*(?:(['\"])(.*?)\\3|(#?(?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)*)|)|)\\s*\\]/,TAG:/^((?:[\\w\\u00c0-\\uFFFF\\*\\-]|\\\\.)+)/,CHILD:/:(only|nth|last|first)-child(?:\\(\\s*(even|odd|(?:[+\\-]?\\d+|(?:[+\\-]?\\d*)?n\\s*(?:[+\\-]\\s*\\d+)?))\\s*\\))?/,POS:/:(nth|eq|gt|lt|first|last|even|odd)(?:\\((\\d*)\\))?(?=[^\\-]|$)/,PSEUDO:/:((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)(?:\\((['\"]?)((?:\\([^\\)]+\\)|[^\\(\\)]*)+)\\2\\))?/},leftMatch:{},attrMap:{\"class\":\"className\",\"for\":\"htmlFor\"},attrHandle:{href:function(a){return a.getAttribute(\"href\")},type:function(a){return a.getAttribute(\"type\")}},relative:{\"+\":function(a,b){var c=typeof b==\"string\",d=c&&!j.test(b),e=c&&!d;d&&(b=b.toLowerCase());for(var f=0,g=a.length,h;f<g;f++)if(h=a[f]){while((h=h.previousSibling)&&h.nodeType!==1);a[f]=e||h&&h.nodeName.toLowerCase()===b?h||!1:h===b}e&&k.filter(b,a,!0)},\">\":function(a,b){var c,d=typeof b==\"string\",e=0,f=a.length;if(d&&!j.test(b)){b=b.toLowerCase();for(;e<f;e++){c=a[e];if(c){var g=c.parentNode;a[e]=g.nodeName.toLowerCase()===b?g:!1}}}else{for(;e<f;e++)c=a[e],c&&(a[e]=d?c.parentNode:c.parentNode===b);d&&k.filter(b,a,!0)}},\"\":function(a,b,c){var e,f=d++,g=u;typeof b==\"string\"&&!j.test(b)&&(b=b.toLowerCase(),e=b,g=t),g(\"parentNode\",b,f,a,e,c)},\"~\":function(a,b,c){var e,f=d++,g=u;typeof b==\"string\"&&!j.test(b)&&(b=b.toLowerCase(),e=b,g=t),g(\"previousSibling\",b,f,a,e,c)}},find:{ID:function(a,b,c){if(typeof b.getElementById!=\"undefined\"&&!c){var d=b.getElementById(a[1]);return d&&d.parentNode?[d]:[]}},NAME:function(a,b){if(typeof b.getElementsByName!=\"undefined\"){var c=[],d=b.getElementsByName(a[1]);for(var e=0,f=d.length;e<f;e++)d[e].getAttribute(\"name\")===a[1]&&c.push(d[e]);return c.length===0?null:c}},TAG:function(a,b){if(typeof b.getElementsByTagName!=\"undefined\")return b.getElementsByTagName(a[1])}},preFilter:{CLASS:function(a,b,c,d,e,f){a=\" \"+a[1].replace(i,\"\")+\" \";if(f)return a;for(var g=0,h;(h=b[g])!=null;g++)h&&(e^(h.className&&(\" \"+h.className+\" \").replace(/[\\t\\n\\r]/g,\" \").indexOf(a)>=0)?c||d.push(h):c&&(b[g]=!1));return!1},ID:function(a){return a[1].replace(i,\"\")},TAG:function(a,b){return a[1].replace(i,\"\").toLowerCase()},CHILD:function(a){if(a[1]===\"nth\"){a[2]||k.error(a[0]),a[2]=a[2].replace(/^\\+|\\s*/g,\"\");var b=/(-?)(\\d*)(?:n([+\\-]?\\d*))?/.exec(a[2]===\"even\"&&\"2n\"||a[2]===\"odd\"&&\"2n+1\"||!/\\D/.test(a[2])&&\"0n+\"+a[2]||a[2]);a[2]=b[1]+(b[2]||1)-0,a[3]=b[3]-0}else a[2]&&k.error(a[0]);a[0]=d++;return a},ATTR:function(a,b,c,d,e,f){var g=a[1]=a[1].replace(i,\"\");!f&&l.attrMap[g]&&(a[1]=l.attrMap[g]),a[4]=(a[4]||a[5]||\"\").replace(i,\"\"),a[2]===\"~=\"&&(a[4]=\" \"+a[4]+\" \");return a},PSEUDO:function(b,c,d,e,f){if(b[1]===\"not\")if((a.exec(b[3])||\"\").length>1||/^\\w/.test(b[3]))b[3]=k(b[3],null,null,c);else{var g=k.filter(b[3],c,d,!0^f);d||e.push.apply(e,g);return!1}else if(l.match.POS.test(b[0])||l.match.CHILD.test(b[0]))return!0;return b},POS:function(a){a.unshift(!0);return a}},filters:{enabled:function(a){return a.disabled===!1&&a.type!==\"hidden\"},disabled:function(a){return a.disabled===!0},checked:function(a){return a.checked===!0},selected:function(a){a.parentNode&&a.parentNode.selectedIndex;return a.selected===!0},parent:function(a){return!!a.firstChild},empty:function(a){return!a.firstChild},has:function(a,b,c){return!!k(c[3],a).length},header:function(a){return/h\\d/i.test(a.nodeName)},text:function(a){var b=a.getAttribute(\"type\"),c=a.type;return a.nodeName.toLowerCase()===\"input\"&&\"text\"===c&&(b===c||b===null)},radio:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"radio\"===a.type},checkbox:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"checkbox\"===a.type},file:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"file\"===a.type},password:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"password\"===a.type},submit:function(a){var b=a.nodeName.toLowerCase();return(b===\"input\"||b===\"button\")&&\"submit\"===a.type},image:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"image\"===a.type},reset:function(a){var b=a.nodeName.toLowerCase();return(b===\"input\"||b===\"button\")&&\"reset\"===a.type},button:function(a){var b=a.nodeName.toLowerCase();return b===\"input\"&&\"button\"===a.type||b===\"button\"},input:function(a){return/input|select|textarea|button/i.test(a.nodeName)},focus:function(a){return a===a.ownerDocument.activeElement}},setFilters:{first:function(a,b){return b===0},last:function(a,b,c,d){return b===d.length-1},even:function(a,b){return b%2===0},odd:function(a,b){return b%2===1},lt:function(a,b,c){return b<c[3]-0},gt:function(a,b,c){return b>c[3]-0},nth:function(a,b,c){return c[3]-0===b},eq:function(a,b,c){return c[3]-0===b}},filter:{PSEUDO:function(a,b,c,d){var e=b[1],f=l.filters[e];if(f)return f(a,c,b,d);if(e===\"contains\")return(a.textContent||a.innerText||k.getText([a])||\"\").indexOf(b[3])>=0;if(e===\"not\"){var g=b[3];for(var h=0,i=g.length;h<i;h++)if(g[h]===a)return!1;return!0}k.error(e)},CHILD:function(a,b){var c=b[1],d=a;switch(c){case\"only\":case\"first\":while(d=d.previousSibling)if(d.nodeType===1)return!1;if(c===\"first\")return!0;d=a;case\"last\":while(d=d.nextSibling)if(d.nodeType===1)return!1;return!0;case\"nth\":var e=b[2],f=b[3];if(e===1&&f===0)return!0;var g=b[0],h=a.parentNode;if(h&&(h.sizcache!==g||!a.nodeIndex)){var i=0;for(d=h.firstChild;d;d=d.nextSibling)d.nodeType===1&&(d.nodeIndex=++i);h.sizcache=g}var j=a.nodeIndex-f;return e===0?j===0:j%e===0&&j/e>=0}},ID:function(a,b){return a.nodeType===1&&a.getAttribute(\"id\")===b},TAG:function(a,b){return b===\"*\"&&a.nodeType===1||a.nodeName.toLowerCase()===b},CLASS:function(a,b){return(\" \"+(a.className||a.getAttribute(\"class\"))+\" \").indexOf(b)>-1},ATTR:function(a,b){var c=b[1],d=l.attrHandle[c]?l.attrHandle[c](a):a[c]!=null?a[c]:a.getAttribute(c),e=d+\"\",f=b[2],g=b[4];return d==null?f===\"!=\":f===\"=\"?e===g:f===\"*=\"?e.indexOf(g)>=0:f===\"~=\"?(\" \"+e+\" \").indexOf(g)>=0:g?f===\"!=\"?e!==g:f===\"^=\"?e.indexOf(g)===0:f===\"$=\"?e.substr(e.length-g.length)===g:f===\"|=\"?e===g||e.substr(0,g.length+1)===g+\"-\":!1:e&&d!==!1},POS:function(a,b,c,d){var e=b[2],f=l.setFilters[e];if(f)return f(a,c,b,d)}}},m=l.match.POS,n=function(a,b){return\"\\\\\"+(b-0+1)};for(var o in l.match)l.match[o]=new RegExp(l.match[o].source+/(?![^\\[]*\\])(?![^\\(]*\\))/.source),l.leftMatch[o]=new RegExp(/(^(?:.|\\r|\\n)*?)/.source+l.match[o].source.replace(/\\\\(\\d+)/g,n));var p=function(a,b){a=Array.prototype.slice.call(a,0);if(b){b.push.apply(b,a);return b}return a};try{Array.prototype.slice.call(c.documentElement.childNodes,0)[0].nodeType}catch(q){p=function(a,b){var c=0,d=b||[];if(e.call(a)===\"[object Array]\")Array.prototype.push.apply(d,a);else if(typeof a.length==\"number\")for(var f=a.length;c<f;c++)d.push(a[c]);else for(;a[c];c++)d.push(a[c]);return d}}var r,s;c.documentElement.compareDocumentPosition?r=function(a,b){if(a===b){g=!0;return 0}if(!a.compareDocumentPosition||!b.compareDocumentPosition)return a.compareDocumentPosition?-1:1;return a.compareDocumentPosition(b)&4?-1:1}:(r=function(a,b){if(a===b){g=!0;return 0}if(a.sourceIndex&&b.sourceIndex)return a.sourceIndex-b.sourceIndex;var c,d,e=[],f=[],h=a.parentNode,i=b.parentNode,j=h;if(h===i)return s(a,b);if(!h)return-1;if(!i)return 1;while(j)e.unshift(j),j=j.parentNode;j=i;while(j)f.unshift(j),j=j.parentNode;c=e.length,d=f.length;for(var k=0;k<c&&k<d;k++)if(e[k]!==f[k])return s(e[k],f[k]);return k===c?s(a,f[k],-1):s(e[k],b,1)},s=function(a,b,c){if(a===b)return c;var d=a.nextSibling;while(d){if(d===b)return-1;d=d.nextSibling}return 1}),k.getText=function(a){var b=\"\",c;for(var d=0;a[d];d++)c=a[d],c.nodeType===3||c.nodeType===4?b+=c.nodeValue:c.nodeType!==8&&(b+=k.getText(c.childNodes));return b},function(){var a=c.createElement(\"div\"),d=\"script\"+(new Date).getTime(),e=c.documentElement;a.innerHTML=\"<a name='\"+d+\"'/>\",e.insertBefore(a,e.firstChild),c.getElementById(d)&&(l.find.ID=function(a,c,d){if(typeof c.getElementById!=\"undefined\"&&!d){var e=c.getElementById(a[1]);return e?e.id===a[1]||typeof e.getAttributeNode!=\"undefined\"&&e.getAttributeNode(\"id\").nodeValue===a[1]?[e]:b:[]}},l.filter.ID=function(a,b){var c=typeof a.getAttributeNode!=\"undefined\"&&a.getAttributeNode(\"id\");return a.nodeType===1&&c&&c.nodeValue===b}),e.removeChild(a),e=a=null}(),function(){var a=c.createElement(\"div\");a.appendChild(c.createComment(\"\")),a.getElementsByTagName(\"*\").length>0&&(l.find.TAG=function(a,b){var c=b.getElementsByTagName(a[1]);if(a[1]===\"*\"){var d=[];for(var e=0;c[e];e++)c[e].nodeType===1&&d.push(c[e]);c=d}return c}),a.innerHTML=\"<a href='#'></a>\",a.firstChild&&typeof a.firstChild.getAttribute!=\"undefined\"&&a.firstChild.getAttribute(\"href\")!==\"#\"&&(l.attrHandle.href=function(a){return a.getAttribute(\"href\",2)}),a=null}(),c.querySelectorAll&&function(){var a=k,b=c.createElement(\"div\"),d=\"__sizzle__\";b.innerHTML=\"<p class='TEST'></p>\";if(!b.querySelectorAll||b.querySelectorAll(\".TEST\").length!==0){k=function(b,e,f,g){e=e||c;if(!g&&!k.isXML(e)){var h=/^(\\w+$)|^\\.([\\w\\-]+$)|^#([\\w\\-]+$)/.exec(b);if(h&&(e.nodeType===1||e.nodeType===9)){if(h[1])return p(e.getElementsByTagName(b),f);if(h[2]&&l.find.CLASS&&e.getElementsByClassName)return p(e.getElementsByClassName(h[2]),f)}if(e.nodeType===9){if(b===\"body\"&&e.body)return p([e.body],f);if(h&&h[3]){var i=e.getElementById(h[3]);if(!i||!i.parentNode)return p([],f);if(i.id===h[3])return p([i],f)}try{return p(e.querySelectorAll(b),f)}catch(j){}}else if(e.nodeType===1&&e.nodeName.toLowerCase()!==\"object\"){var m=e,n=e.getAttribute(\"id\"),o=n||d,q=e.parentNode,r=/^\\s*[+~]/.test(b);n?o=o.replace(/'/g,\"\\\\$&\"):e.setAttribute(\"id\",o),r&&q&&(e=e.parentNode);try{if(!r||q)return p(e.querySelectorAll(\"[id='\"+o+\"'] \"+b),f)}catch(s){}finally{n||m.removeAttribute(\"id\")}}}return a(b,e,f,g)};for(var e in a)k[e]=a[e];b=null}}(),function(){var a=c.documentElement,b=a.matchesSelector||a.mozMatchesSelector||a.webkitMatchesSelector||a.msMatchesSelector;if(b){var d=!b.call(c.createElement(\"div\"),\"div\"),e=!1;try{b.call(c.documentElement,\"[test!='']:sizzle\")}catch(f){e=!0}k.matchesSelector=function(a,c){c=c.replace(/\\=\\s*([^'\"\\]]*)\\s*\\]/g,\"='$1']\");if(!k.isXML(a))try{if(e||!l.match.PSEUDO.test(c)&&!/!=/.test(c)){var f=b.call(a,c);if(f||!d||a.document&&a.document.nodeType!==11)return f}}catch(g){}return k(c,null,null,[a]).length>0}}}(),function(){var a=c.createElement(\"div\");a.innerHTML=\"<div class='test e'></div><div class='test'></div>\";if(!!a.getElementsByClassName&&a.getElementsByClassName(\"e\").length!==0){a.lastChild.className=\"e\";if(a.getElementsByClassName(\"e\").length===1)return;l.order.splice(1,0,\"CLASS\"),l.find.CLASS=function(a,b,c){if(typeof b.getElementsByClassName!=\"undefined\"&&!c)return b.getElementsByClassName(a[1])},a=null}}(),c.documentElement.contains?k.contains=function(a,b){return a!==b&&(a.contains?a.contains(b):!0)}:c.documentElement.compareDocumentPosition?k.contains=function(a,b){return!!(a.compareDocumentPosition(b)&16)}:k.contains=function(){return!1},k.isXML=function(a){var b=(a?a.ownerDocument||a:0).documentElement;return b?b.nodeName!==\"HTML\":!1};var v=function(a,b){var c,d=[],e=\"\",f=b.nodeType?[b]:b;while(c=l.match.PSEUDO.exec(a))e+=c[0],a=a.replace(l.match.PSEUDO,\"\");a=l.relative[a]?a+\"*\":a;for(var g=0,h=f.length;g<h;g++)k(a,f[g],d);return k.filter(e,d)};f.find=k,f.expr=k.selectors,f.expr[\":\"]=f.expr.filters,f.unique=k.uniqueSort,f.text=k.getText,f.isXMLDoc=k.isXML,f.contains=k.contains}();var P=/Until$/,Q=/^(?:parents|prevUntil|prevAll)/,R=/,/,S=/^.[^:#\\[\\.,]*$/,T=Array.prototype.slice,U=f.expr.match.POS,V={children:!0,contents:!0,next:!0,prev:!0};f.fn.extend({find:function(a){var b=this,c,d;if(typeof a!=\"string\")return f(a).filter(function(){for(c=0,d=b.length;c<d;c++)if(f.contains(b[c],this))return!0});var e=this.pushStack(\"\",\"find\",a),g,h,i;for(c=0,d=this.length;c<d;c++){g=e.length,f.find(a,this[c],e);if(c>0)for(h=g;h<e.length;h++)for(i=0;i<g;i++)if(e[i]===e[h]){e.splice(h--,1);break}}return e},has:function(a){var b=f(a);return this.filter(function(){for(var a=0,c=b.length;a<c;a++)if(f.contains(this,b[a]))return!0})},not:function(a){return this.pushStack(X(this,a,!1),\"not\",a)},filter:function(a){return this.pushStack(X(this,a,!0),\"filter\",a)},is:function(a){return!!a&&(typeof a==\"string\"?f.filter(a,this).length>0:this.filter(a).length>0)},closest:function(a,b){var c=[],d,e,g=this[0];if(f.isArray(a)){var h,i,j={},k=1;if(g&&a.length){for(d=0,e=a.length;d<e;d++)i=a[d],j[i]||(j[i]=U.test(i)?f(i,b||this.context):i);while(g&&g.ownerDocument&&g!==b){for(i in j)h=j[i],(h.jquery?h.index(g)>-1:f(g).is(h))&&c.push({selector:i,elem:g,level:k});g=g.parentNode,k++}}return c}var l=U.test(a)||typeof a!=\"string\"?f(a,b||this.context):0;for(d=0,e=this.length;d<e;d++){g=this[d];while(g){if(l?l.index(g)>-1:f.find.matchesSelector(g,a)){c.push(g);break}g=g.parentNode;if(!g||!g.ownerDocument||g===b||g.nodeType===11)break}}c=c.length>1?f.unique(c):c;return this.pushStack(c,\"closest\",a)},index:function(a){if(!a||typeof a==\"string\")return f.inArray(this[0],a?f(a):this.parent().children());return f.inArray(a.jquery?a[0]:a,this)},add:function(a,b){var c=typeof a==\"string\"?f(a,b):f.makeArray(a&&a.nodeType?[a]:a),d=f.merge(this.get(),c);return this.pushStack(W(c[0])||W(d[0])?d:f.unique(d))},andSelf:function(){return this.add(this.prevObject)}}),f.each({parent:function(a){var b=a.parentNode;return b&&b.nodeType!==11?b:null},parents:function(a){return f.dir(a,\"parentNode\")},parentsUntil:function(a,b,c){return f.dir(a,\"parentNode\",c)},next:function(a){return f.nth(a,2,\"nextSibling\")},prev:function(a){return f.nth(a,2,\"previousSibling\")},nextAll:function(a){return f.dir(a,\"nextSibling\")},prevAll:function(a){return f.dir(a,\"previousSibling\")},nextUntil:function(a,b,c){return f.dir(a,\"nextSibling\",c)},prevUntil:function(a,b,c){return f.dir(a,\"previousSibling\",c)},siblings:function(a){return f.sibling(a.parentNode.firstChild,a)},children:function(a){return f.sibling(a.firstChild)},contents:function(a){return f.nodeName(a,\"iframe\")?a.contentDocument||a.contentWindow.document:f.makeArray(a.childNodes)}},function(a,b){f.fn[a]=function(c,d){var e=f.map(this,b,c),g=T.call(arguments);P.test(a)||(d=c),d&&typeof d==\"string\"&&(e=f.filter(d,e)),e=this.length>1&&!V[a]?f.unique(e):e,(this.length>1||R.test(d))&&Q.test(a)&&(e=e.reverse());return this.pushStack(e,a,g.join(\",\"))}}),f.extend({filter:function(a,b,c){c&&(a=\":not(\"+a+\")\");return b.length===1?f.find.matchesSelector(b[0],a)?[b[0]]:[]:f.find.matches(a,b)},dir:function(a,c,d){var e=[],g=a[c];while(g&&g.nodeType!==9&&(d===b||g.nodeType!==1||!f(g).is(d)))g.nodeType===1&&e.push(g),g=g[c];return e},nth:function(a,b,c,d){b=b||1;var e=0;for(;a;a=a[c])if(a.nodeType===1&&++e===b)break;return a},sibling:function(a,b){var c=[];for(;a;a=a.nextSibling)a.nodeType===1&&a!==b&&c.push(a);return c}});var Y=/ jQuery\\d+=\"(?:\\d+|null)\"/g,Z=/^\\s+/,$=/<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\\w:]+)[^>]*)\\/>/ig,_=/<([\\w:]+)/,ba=/<tbody/i,bb=/<|&#?\\w+;/,bc=/<(?:script|object|embed|option|style)/i,bd=/checked\\s*(?:[^=]|=\\s*.checked.)/i,be=/\\/(java|ecma)script/i,bf=/^\\s*<!(?:\\[CDATA\\[|\\-\\-)/,bg={option:[1,\"<select multiple='multiple'>\",\"</select>\"],legend:[1,\"<fieldset>\",\"</fieldset>\"],thead:[1,\"<table>\",\"</table>\"],tr:[2,\"<table><tbody>\",\"</tbody></table>\"],td:[3,\"<table><tbody><tr>\",\"</tr></tbody></table>\"],col:[2,\"<table><tbody></tbody><colgroup>\",\"</colgroup></table>\"],area:[1,\"<map>\",\"</map>\"],_default:[0,\"\",\"\"]};bg.optgroup=bg.option,bg.tbody=bg.tfoot=bg.colgroup=bg.caption=bg.thead,bg.th=bg.td,f.support.htmlSerialize||(bg._default=[1,\"div<div>\",\"</div>\"]),f.fn.extend({text:function(a){if(f.isFunction(a))return this.each(function(b){var c=f(this);c.text(a.call(this,b,c.text()))});if(typeof a!=\"object\"&&a!==b)return this.empty().append((this[0]&&this[0].ownerDocument||c).createTextNode(a));return f.text(this)},wrapAll:function(a){if(f.isFunction(a))return this.each(function(b){f(this).wrapAll(a.call(this,b))});if(this[0]){var b=f(a,this[0].ownerDocument).eq(0).clone(!0);this[0].parentNode&&b.insertBefore(this[0]),b.map(function(){var a=this;while(a.firstChild&&a.firstChild.nodeType===1)a=a.firstChild;return a}).append(this)}return this},wrapInner:function(a){if(f.isFunction(a))return this.each(function(b){f(this).wrapInner(a.call(this,b))});return this.each(function(){var b=f(this),c=b.contents();c.length?c.wrapAll(a):b.append(a)})},wrap:function(a){return this.each(function(){f(this).wrapAll(a)})},unwrap:function(){return this.parent().each(function(){f.nodeName(this,\"body\")||f(this).replaceWith(this.childNodes)}).end()},append:function(){return this.domManip(arguments,!0,function(a){this.nodeType===1&&this.appendChild(a)})},prepend:function(){return this.domManip(arguments,!0,function(a){this.nodeType===1&&this.insertBefore(a,this.firstChild)})},before:function(){if(this[0]&&this[0].parentNode)return this.domManip(arguments,!1,function(a){this.parentNode.insertBefore(a,this)});if(arguments.length){var a=f(arguments[0]);a.push.apply(a,this.toArray());return this.pushStack(a,\"before\",arguments)}},after:function(){if(this[0]&&this[0].parentNode)return this.domManip(arguments,!1,function(a){this.parentNode.insertBefore(a,this.nextSibling)});if(arguments.length){var a=this.pushStack(this,\"after\",arguments);a.push.apply(a,f(arguments[0]).toArray());return a}},remove:function(a,b){for(var c=0,d;(d=this[c])!=null;c++)if(!a||f.filter(a,[d]).length)!b&&d.nodeType===1&&(f.cleanData(d.getElementsByTagName(\"*\")),f.cleanData([d])),d.parentNode&&d.parentNode.removeChild(d);return this},empty:function(){for(var a=0,b;(b=this[a])!=null;a++){b.nodeType===1&&f.cleanData(b.getElementsByTagName(\"*\"));while(b.firstChild)b.removeChild(b.firstChild)}return this},clone:function(a,b){a=a==null?!1:a,b=b==null?a:b;return this.map(function(){return f.clone(this,a,b)})},html:function(a){if(a===b)return this[0]&&this[0].nodeType===1?this[0].innerHTML.replace(Y,\"\"):null;if(typeof a==\"string\"&&!bc.test(a)&&(f.support.leadingWhitespace||!Z.test(a))&&!bg[(_.exec(a)||[\"\",\"\"])[1].toLowerCase()]){a=a.replace($,\"<$1></$2>\");try{for(var c=0,d=this.length;c<d;c++)this[c].nodeType===1&&(f.cleanData(this[c].getElementsByTagName(\"*\")),this[c].innerHTML=a)}catch(e){this.empty().append(a)}}else f.isFunction(a)?this.each(function(b){var c=f(this);c.html(a.call(this,b,c.html()))}):this.empty().append(a);return this},replaceWith:function(a){if(this[0]&&this[0].parentNode){if(f.isFunction(a))return this.each(function(b){var c=f(this),d=c.html();c.replaceWith(a.call(this,b,d))});typeof a!=\"string\"&&(a=f(a).detach());return this.each(function(){var b=this.nextSibling,c=this.parentNode;f(this).remove(),b?f(b).before(a):f(c).append(a)})}return this.length?this.pushStack(f(f.isFunction(a)?a():a),\"replaceWith\",a):this},detach:function(a){return this.remove(a,!0)},domManip:function(a,c,d){var e,g,h,i,j=a[0],k=[];if(!f.support.checkClone&&arguments.length===3&&typeof j==\"string\"&&bd.test(j))return this.each(function(){f(this).domManip(a,c,d,!0)});if(f.isFunction(j))return this.each(function(e){var g=f(this);a[0]=j.call(this,e,c?g.html():b),g.domManip(a,c,d)});if(this[0]){i=j&&j.parentNode,f.support.parentNode&&i&&i.nodeType===11&&i.childNodes.length===this.length?e={fragment:i}:e=f.buildFragment(a,this,k),h=e.fragment,h.childNodes.length===1?g=h=h.firstChild:g=h.firstChild;if(g){c=c&&f.nodeName(g,\"tr\");for(var l=0,m=this.length,n=m-1;l<m;l++)d.call(c?bh(this[l],g):this[l],e.cacheable||m>1&&l<n?f.clone(h,!0,!0):h)}k.length&&f.each(k,bn)}return this}}),f.buildFragment=function(a,b,d){var e,g,h,i=b&&b[0]?b[0].ownerDocument||b[0]:c;a.length===1&&typeof a[0]==\"string\"&&a[0].length<512&&i===c&&a[0].charAt(0)===\"<\"&&!bc.test(a[0])&&(f.support.checkClone||!bd.test(a[0]))&&(g=!0,h=f.fragments[a[0]],h&&h!==1&&(e=h)),e||(e=i.createDocumentFragment(),f.clean(a,i,e,d)),g&&(f.fragments[a[0]]=h?e:1);return{fragment:e,cacheable:g}},f.fragments={},f.each({appendTo:\"append\",prependTo:\"prepend\",insertBefore:\"before\",insertAfter:\"after\",replaceAll:\"replaceWith\"},function(a,b){f.fn[a]=function(c){var d=[],e=f(c),g=this.length===1&&this[0].parentNode;if(g&&g.nodeType===11&&g.childNodes.length===1&&e.length===1){e[b](this[0]);return this}for(var h=0,i=e.length;h<i;h++){var j=(h>0?this.clone(!0):this).get();f(e[h])[b](j),d=d.concat(j)}return this.pushStack(d,a,e.selector)}}),f.extend({clone:function(a,b,c){var d=a.cloneNode(!0),e,g,h;if((!f.support.noCloneEvent||!f.support.noCloneChecked)&&(a.nodeType===1||a.nodeType===11)&&!f.isXMLDoc(a)){bj(a,d),e=bk(a),g=bk(d);for(h=0;e[h];++h)bj(e[h],g[h])}if(b){bi(a,d);if(c){e=bk(a),g=bk(d);for(h=0;e[h];++h)bi(e[h],g[h])}}return d},clean:function(a,b,d,e){var g;b=b||c,typeof b.createElement==\"undefined\"&&(b=b.ownerDocument||" +
					"b[0]&&b[0].ownerDocument||c);var h=[],i;for(var j=0,k;(k=a[j])!=null;j++){typeof k==\"number\"&&(k+=\"\");if(!k)continue;if(typeof k==\"string\")if(!bb.test(k))k=b.createTextNode(k);else{k=k.replace($,\"<$1></$2>\");var l=(_.exec(k)||[\"\",\"\"])[1].toLowerCase(),m=bg[l]||bg._default,n=m[0],o=b.createElement(\"div\");o.innerHTML=m[1]+k+m[2];while(n--)o=o.lastChild;if(!f.support.tbody){var p=ba.test(k),q=l===\"table\"&&!p?o.firstChild&&o.firstChild.childNodes:m[1]===\"<table>\"&&!p?o.childNodes:[];for(i=q.length-1;i>=0;--i)f.nodeName(q[i],\"tbody\")&&!q[i].childNodes.length&&q[i].parentNode.removeChild(q[i])}!f.support.leadingWhitespace&&Z.test(k)&&o.insertBefore(b.createTextNode(Z.exec(k)[0]),o.firstChild),k=o.childNodes}var r;if(!f.support.appendChecked)if(k[0]&&typeof (r=k.length)==\"number\")for(i=0;i<r;i++)bm(k[i]);else bm(k);k.nodeType?h.push(k):h=f.merge(h,k)}if(d){g=function(a){return!a.type||be.test(a.type)};for(j=0;h[j];j++)if(e&&f.nodeName(h[j],\"script\")&&(!h[j].type||h[j].type.toLowerCase()===\"text/javascript\"))e.push(h[j].parentNode?h[j].parentNode.removeChild(h[j]):h[j]);else{if(h[j].nodeType===1){var s=f.grep(h[j].getElementsByTagName(\"script\"),g);h.splice.apply(h,[j+1,0].concat(s))}d.appendChild(h[j])}}return h},cleanData:function(a){var b,c,d=f.cache,e=f.expando,g=f.event.special,h=f.support.deleteExpando;for(var i=0,j;(j=a[i])!=null;i++){if(j.nodeName&&f.noData[j.nodeName.toLowerCase()])continue;c=j[f.expando];if(c){b=d[c]&&d[c][e];if(b&&b.events){for(var k in b.events)g[k]?f.event.remove(j,k):f.removeEvent(j,k,b.handle);b.handle&&(b.handle.elem=null)}h?delete j[f.expando]:j.removeAttribute&&j.removeAttribute(f.expando),delete d[c]}}}});var bo=/alpha\\([^)]*\\)/i,bp=/opacity=([^)]*)/,bq=/-([a-z])/ig,br=/([A-Z]|^ms)/g,bs=/^-?\\d+(?:px)?$/i,bt=/^-?\\d/,bu=/^[+\\-]=/,bv=/[^+\\-\\.\\de]+/g,bw={position:\"absolute\",visibility:\"hidden\",display:\"block\"},bx=[\"Left\",\"Right\"],by=[\"Top\",\"Bottom\"],bz,bA,bB,bC=function(a,b){return b.toUpperCase()};f.fn.css=function(a,c){if(arguments.length===2&&c===b)return this;return f.access(this,a,c,!0,function(a,c,d){return d!==b?f.style(a,c,d):f.css(a,c)})},f.extend({cssHooks:{opacity:{get:function(a,b){if(b){var c=bz(a,\"opacity\",\"opacity\");return c===\"\"?\"1\":c}return a.style.opacity}}},cssNumber:{zIndex:!0,fontWeight:!0,opacity:!0,zoom:!0,lineHeight:!0,widows:!0,orphans:!0},cssProps:{\"float\":f.support.cssFloat?\"cssFloat\":\"styleFloat\"},style:function(a,c,d,e){if(!!a&&a.nodeType!==3&&a.nodeType!==8&&!!a.style){var g,h,i=f.camelCase(c),j=a.style,k=f.cssHooks[i];c=f.cssProps[i]||i;if(d===b){if(k&&\"get\"in k&&(g=k.get(a,!1,e))!==b)return g;return j[c]}h=typeof d;if(h===\"number\"&&isNaN(d)||d==null)return;h===\"string\"&&bu.test(d)&&(d=+d.replace(bv,\"\")+parseFloat(f.css(a,c))),h===\"number\"&&!f.cssNumber[i]&&(d+=\"px\");if(!k||!(\"set\"in k)||(d=k.set(a,d))!==b)try{j[c]=d}catch(l){}}},css:function(a,c,d){var e,g;c=f.camelCase(c),g=f.cssHooks[c],c=f.cssProps[c]||c,c===\"cssFloat\"&&(c=\"float\");if(g&&\"get\"in g&&(e=g.get(a,!0,d))!==b)return e;if(bz)return bz(a,c)},swap:function(a,b,c){var d={};for(var e in b)d[e]=a.style[e],a.style[e]=b[e];c.call(a);for(e in b)a.style[e]=d[e]},camelCase:function(a){return a.replace(bq,bC)}}),f.curCSS=f.css,f.each([\"height\",\"width\"],function(a,b){f.cssHooks[b]={get:function(a,c,d){var e;if(c){a.offsetWidth!==0?e=bD(a,b,d):f.swap(a,bw,function(){e=bD(a,b,d)});if(e<=0){e=bz(a,b,b),e===\"0px\"&&bB&&(e=bB(a,b,b));if(e!=null)return e===\"\"||e===\"auto\"?\"0px\":e}if(e<0||e==null){e=a.style[b];return e===\"\"||e===\"auto\"?\"0px\":e}return typeof e==\"string\"?e:e+\"px\"}},set:function(a,b){if(!bs.test(b))return b;b=parseFloat(b);if(b>=0)return b+\"px\"}}}),f.support.opacity||(f.cssHooks.opacity={get:function(a,b){return bp.test((b&&a.currentStyle?a.currentStyle.filter:a.style.filter)||\"\")?parseFloat(RegExp.$1)/100+\"\":b?\"1\":\"\"},set:function(a,b){var c=a.style,d=a.currentStyle;c.zoom=1;var e=f.isNaN(b)?\"\":\"alpha(opacity=\"+b*100+\")\",g=d&&d.filter||c.filter||\"\";c.filter=bo.test(g)?g.replace(bo,e):g+\" \"+e}}),f(function(){f.support.reliableMarginRight||(f.cssHooks.marginRight={get:function(a,b){var c;f.swap(a,{display:\"inline-block\"},function(){b?c=bz(a,\"margin-right\",\"marginRight\"):c=a.style.marginRight});return c}})}),c.defaultView&&c.defaultView.getComputedStyle&&(bA=function(a,c){var d,e,g;c=c.replace(br,\"-$1\").toLowerCase();if(!(e=a.ownerDocument.defaultView))return b;if(g=e.getComputedStyle(a,null))d=g.getPropertyValue(c),d===\"\"&&!f.contains(a.ownerDocument.documentElement,a)&&(d=f.style(a,c));return d}),c.documentElement.currentStyle&&(bB=function(a,b){var c,d=a.currentStyle&&a.currentStyle[b],e=a.runtimeStyle&&a.runtimeStyle[b],f=a.style;!bs.test(d)&&bt.test(d)&&(c=f.left,e&&(a.runtimeStyle.left=a.currentStyle.left),f.left=b===\"fontSize\"?\"1em\":d||0,d=f.pixelLeft+\"px\",f.left=c,e&&(a.runtimeStyle.left=e));return d===\"\"?\"auto\":d}),bz=bA||bB,f.expr&&f.expr.filters&&(f.expr.filters.hidden=function(a){var b=a.offsetWidth,c=a.offsetHeight;return b===0&&c===0||!f.support.reliableHiddenOffsets&&(a.style.display||f.css(a,\"display\"))===\"none\"},f.expr.filters.visible=function(a){return!f.expr.filters.hidden(a)});var bE=/%20/g,bF=/\\[\\]$/,bG=/\\r?\\n/g,bH=/#.*$/,bI=/^(.*?):[ \\t]*([^\\r\\n]*)\\r?$/mg,bJ=/^(?:color|date|datetime|email|hidden|month|number|password|range|search|tel|text|time|url|week)$/i,bK=/^(?:about|app|app\\-storage|.+\\-extension|file|widget):$/,bL=/^(?:GET|HEAD)$/,bM=/^\\/\\//,bN=/\\?/,bO=/<script\\b[^<]*(?:(?!<\\/script>)<[^<]*)*<\\/script>/gi,bP=/^(?:select|textarea)/i,bQ=/\\s+/,bR=/([?&])_=[^&]*/,bS=/^([\\w\\+\\.\\-]+:)(?:\\/\\/([^\\/?#:]*)(?::(\\d+))?)?/,bT=f.fn.load,bU={},bV={},bW,bX;try{bW=e.href}catch(bY){bW=c.createElement(\"a\"),bW.href=\"\",bW=bW.href}bX=bS.exec(bW.toLowerCase())||[],f.fn.extend({load:function(a,c,d){if(typeof a!=\"string\"&&bT)return bT.apply(this,arguments);if(!this.length)return this;var e=a.indexOf(\" \");if(e>=0){var g=a.slice(e,a.length);a=a.slice(0,e)}var h=\"GET\";c&&(f.isFunction(c)?(d=c,c=b):typeof c==\"object\"&&(c=f.param(c,f.ajaxSettings.traditional),h=\"POST\"));var i=this;f.ajax({url:a,type:h,dataType:\"html\",data:c,complete:function(a,b,c){c=a.responseText,a.isResolved()&&(a.done(function(a){c=a}),i.html(g?f(\"<div>\").append(c.replace(bO,\"\")).find(g):c)),d&&i.each(d,[c,b,a])}});return this},serialize:function(){return f.param(this.serializeArray())},serializeArray:function(){return this.map(function(){return this.elements?f.makeArray(this.elements):this}).filter(function(){return this.name&&!this.disabled&&(this.checked||bP.test(this.nodeName)||bJ.test(this.type))}).map(function(a,b){var c=f(this).val();return c==null?null:f.isArray(c)?f.map(c,function(a,c){return{name:b.name,value:a.replace(bG,\"\\r\\n\")}}):{name:b.name,value:c.replace(bG,\"\\r\\n\")}}).get()}}),f.each(\"ajaxStart ajaxStop ajaxComplete ajaxError ajaxSuccess ajaxSend\".split(\" \"),function(a,b){f.fn[b]=function(a){return this.bind(b,a)}}),f.each([\"get\",\"post\"],function(a,c){f[c]=function(a,d,e,g){f.isFunction(d)&&(g=g||e,e=d,d=b);return f.ajax({type:c,url:a,data:d,success:e,dataType:g})}}),f.extend({getScript:function(a,c){return f.get(a,b,c,\"script\")},getJSON:function(a,b,c){return f.get(a,b,c,\"json\")},ajaxSetup:function(a,b){b?f.extend(!0,a,f.ajaxSettings,b):(b=a,a=f.extend(!0,f.ajaxSettings,b));for(var c in{context:1,url:1})c in b?a[c]=b[c]:c in f.ajaxSettings&&(a[c]=f.ajaxSettings[c]);return a},ajaxSettings:{url:bW,isLocal:bK.test(bX[1]),global:!0,type:\"GET\",contentType:\"application/x-www-form-urlencoded\",processData:!0,async:!0,accepts:{xml:\"application/xml, text/xml\",html:\"text/html\",text:\"text/plain\",json:\"application/json, text/javascript\",\"*\":\"*/*\"},contents:{xml:/xml/,html:/html/,json:/json/},responseFields:{xml:\"responseXML\",text:\"responseText\"},converters:{\"* text\":a.String,\"text html\":!0,\"text json\":f.parseJSON,\"text xml\":f.parseXML}},ajaxPrefilter:bZ(bU),ajaxTransport:bZ(bV),ajax:function(a,c){function w(a,c,l,m){if(s!==2){s=2,q&&clearTimeout(q),p=b,n=m||\"\",v.readyState=a?4:0;var o,r,u,w=l?ca(d,v,l):b,x,y;if(a>=200&&a<300||a===304){if(d.ifModified){if(x=v.getResponseHeader(\"Last-Modified\"))f.lastModified[k]=x;if(y=v.getResponseHeader(\"Etag\"))f.etag[k]=y}if(a===304)c=\"notmodified\",o=!0;else try{r=cb(d,w),c=\"success\",o=!0}catch(z){c=\"parsererror\",u=z}}else{u=c;if(!c||a)c=\"error\",a<0&&(a=0)}v.status=a,v.statusText=c,o?h.resolveWith(e,[r,c,v]):h.rejectWith(e,[v,c,u]),v.statusCode(j),j=b,t&&g.trigger(\"ajax\"+(o?\"Success\":\"Error\"),[v,d,o?r:u]),i.resolveWith(e,[v,c]),t&&(g.trigger(\"ajaxComplete\",[v,d]),--f.active||f.event.trigger(\"ajaxStop\"))}}typeof a==\"object\"&&(c=a,a=b),c=c||{};var d=f.ajaxSetup({},c),e=d.context||d,g=e!==d&&(e.nodeType||e instanceof f)?f(e):f.event,h=f.Deferred(),i=f._Deferred(),j=d.statusCode||{},k,l={},m={},n,o,p,q,r,s=0,t,u,v={readyState:0,setRequestHeader:function(a,b){if(!s){var c=a.toLowerCase();a=m[c]=m[c]||a,l[a]=b}return this},getAllResponseHeaders:function(){return s===2?n:null},getResponseHeader:function(a){var c;if(s===2){if(!o){o={};while(c=bI.exec(n))o[c[1].toLowerCase()]=c[2]}c=o[a.toLowerCase()]}return c===b?null:c},overrideMimeType:function(a){s||(d.mimeType=a);return this},abort:function(a){a=a||\"abort\",p&&p.abort(a),w(0,a);return this}};h.promise(v),v.success=v.done,v.error=v.fail,v.complete=i.done,v.statusCode=function(a){if(a){var b;if(s<2)for(b in a)j[b]=[j[b],a[b]];else b=a[v.status],v.then(b,b)}return this},d.url=((a||d.url)+\"\").replace(bH,\"\").replace(bM,bX[1]+\"//\"),d.dataTypes=f.trim(d.dataType||\"*\").toLowerCase().split(bQ),d.crossDomain==null&&(r=bS.exec(d.url.toLowerCase()),d.crossDomain=!(!r||r[1]==bX[1]&&r[2]==bX[2]&&(r[3]||(r[1]===\"http:\"?80:443))==(bX[3]||(bX[1]===\"http:\"?80:443)))),d.data&&d.processData&&typeof d.data!=\"string\"&&(d.data=f.param(d.data,d.traditional)),b$(bU,d,c,v);if(s===2)return!1;t=d.global,d.type=d.type.toUpperCase(),d.hasContent=!bL.test(d.type),t&&f.active++===0&&f.event.trigger(\"ajaxStart\");if(!d.hasContent){d.data&&(d.url+=(bN.test(d.url)?\"&\":\"?\")+d.data),k=d.url;if(d.cache===!1){var x=f.now(),y=d.url.replace(bR,\"$1_=\"+x);d.url=y+(y===d.url?(bN.test(d.url)?\"&\":\"?\")+\"_=\"+x:\"\")}}(d.data&&d.hasContent&&d.contentType!==!1||c.contentType)&&v.setRequestHeader(\"Content-Type\",d.contentType),d.ifModified&&(k=k||d.url,f.lastModified[k]&&v.setRequestHeader(\"If-Modified-Since\",f.lastModified[k]),f.etag[k]&&v.setRequestHeader(\"If-None-Match\",f.etag[k])),v.setRequestHeader(\"Accept\",d.dataTypes[0]&&d.accepts[d.dataTypes[0]]?d.accepts[d.dataTypes[0]]+(d.dataTypes[0]!==\"*\"?\", */*; q=0.01\":\"\"):d.accepts[\"*\"]);for(u in d.headers)v.setRequestHeader(u,d.headers[u]);if(d.beforeSend&&(d.beforeSend.call(e,v,d)===!1||s===2)){v.abort();return!1}for(u in{success:1,error:1,complete:1})v[u](d[u]);p=b$(bV,d,c,v);if(!p)w(-1,\"No Transport\");else{v.readyState=1,t&&g.trigger(\"ajaxSend\",[v,d]),d.async&&d.timeout>0&&(q=setTimeout(function(){v.abort(\"timeout\")},d.timeout));try{s=1,p.send(l,w)}catch(z){status<2?w(-1,z):f.error(z)}}return v},param:function(a,c){var d=[],e=function(a,b){b=f.isFunction(b)?b():b,d[d.length]=encodeURIComponent(a)+\"=\"+encodeURIComponent(b)};c===b&&(c=f.ajaxSettings.traditional);if(f.isArray(a)||a.jquery&&!f.isPlainObject(a))f.each(a,function(){e(this.name,this.value)});else for(var g in a)b_(g,a[g],c,e);return d.join(\"&\").replace(bE,\"+\")}}),f.extend({active:0,lastModified:{},etag:{}});var cc=f.now(),cd=/(\\=)\\?(&|$)|\\?\\?/i;f.ajaxSetup({jsonp:\"callback\",jsonpCallback:function(){return f.expando+\"_\"+cc++}}),f.ajaxPrefilter(\"json jsonp\",function(b,c,d){var e=b.contentType===\"application/x-www-form-urlencoded\"&&typeof b.data==\"string\";if(b.dataTypes[0]===\"jsonp\"||b.jsonp!==!1&&(cd.test(b.url)||e&&cd.test(b.data))){var g,h=b.jsonpCallback=f.isFunction(b.jsonpCallback)?b.jsonpCallback():b.jsonpCallback,i=a[h],j=b.url,k=b.data,l=\"$1\"+h+\"$2\";b.jsonp!==!1&&(j=j.replace(cd,l),b.url===j&&(e&&(k=k.replace(cd,l)),b.data===k&&(j+=(/\\?/.test(j)?\"&\":\"?\")+b.jsonp+\"=\"+h))),b.url=j,b.data=k,a[h]=function(a){g=[a]},d.always(function(){a[h]=i,g&&f.isFunction(i)&&a[h](g[0])}),b.converters[\"script json\"]=function(){g||f.error(h+\" was not called\");return g[0]},b.dataTypes[0]=\"json\";return\"script\"}}),f.ajaxSetup({accepts:{script:\"text/javascript, application/javascript, application/ecmascript, application/x-ecmascript\"},contents:{script:/javascript|ecmascript/},converters:{\"text script\":function(a){f.globalEval(a);return a}}}),f.ajaxPrefilter(\"script\",function(a){a.cache===b&&(a.cache=!1),a.crossDomain&&(a.type=\"GET\",a.global=!1)}),f.ajaxTransport(\"script\",function(a){if(a.crossDomain){var d,e=c.head||c.getElementsByTagName(\"head\")[0]||c.documentElement;return{send:function(f,g){d=c.createElement(\"script\"),d.async=\"async\",a.scriptCharset&&(d.charset=a.scriptCharset),d.src=a.url,d.onload=d.onreadystatechange=function(a,c){if(c||!d.readyState||/loaded|complete/.test(d.readyState))d.onload=d.onreadystatechange=null,e&&d.parentNode&&e.removeChild(d),d=b,c||g(200,\"success\")},e.insertBefore(d,e.firstChild)},abort:function(){d&&d.onload(0,1)}}}});var ce=a.ActiveXObject?function(){for(var a in cg)cg[a](0,1)}:!1,cf=0,cg;f.ajaxSettings.xhr=a.ActiveXObject?function(){return!this.isLocal&&ch()||ci()}:ch,function(a){f.extend(f.support,{ajax:!!a,cors:!!a&&\"withCredentials\"in a})}(f.ajaxSettings.xhr()),f.support.ajax&&f.ajaxTransport(function(c){if(!c.crossDomain||f.support.cors){var d;return{send:function(e,g){var h=c.xhr(),i,j;c.username?h.open(c.type,c.url,c.async,c.username,c.password):h.open(c.type,c.url,c.async);if(c.xhrFields)for(j in c.xhrFields)h[j]=c.xhrFields[j];c.mimeType&&h.overrideMimeType&&h.overrideMimeType(c.mimeType),!c.crossDomain&&!e[\"X-Requested-With\"]&&(e[\"X-Requested-With\"]=\"XMLHttpRequest\");try{for(j in e)h.setRequestHeader(j,e[j])}catch(k){}h.send(c.hasContent&&c.data||null),d=function(a,e){var j,k,l,m,n;try{if(d&&(e||h.readyState===4)){d=b,i&&(h.onreadystatechange=f.noop,ce&&delete cg[i]);if(e)h.readyState!==4&&h.abort();else{j=h.status,l=h.getAllResponseHeaders(),m={},n=h.responseXML,n&&n.documentElement&&(m.xml=n),m.text=h.responseText;try{k=h.statusText}catch(o){k=\"\"}!j&&c.isLocal&&!c.crossDomain?j=m.text?200:404:j===1223&&(j=204)}}}catch(p){e||g(-1,p)}m&&g(j,k,m,l)},!c.async||h.readyState===4?d():(i=++cf,ce&&(cg||(cg={},f(a).unload(ce)),cg[i]=d),h.onreadystatechange=d)},abort:function(){d&&d(0,1)}}}});var cj={},ck,cl,cm=/^(?:toggle|show|hide)$/,cn=/^([+\\-]=)?([\\d+.\\-]+)([a-z%]*)$/i,co,cp=[[\"height\",\"marginTop\",\"marginBottom\",\"paddingTop\",\"paddingBottom\"],[\"width\",\"marginLeft\",\"marginRight\",\"paddingLeft\",\"paddingRight\"],[\"opacity\"]],cq,cr=a.webkitRequestAnimationFrame||a.mozRequestAnimationFrame||a.oRequestAnimationFrame;f.fn.extend({show:function(a,b,c){var d,e;if(a||a===0)return this.animate(cu(\"show\",3),a,b,c);for(var g=0,h=this.length;g<h;g++)d=this[g],d.style&&(e=d.style.display,!f._data(d,\"olddisplay\")&&e===\"none\"&&(e=d.style.display=\"\"),e===\"\"&&f.css(d,\"display\")===\"none\"&&f._data(d,\"olddisplay\",cv(d.nodeName)));for(g=0;g<h;g++){d=this[g];if(d.style){e=d.style.display;if(e===\"\"||e===\"none\")d.style.display=f._data(d,\"olddisplay\")||\"\"}}return this},hide:function(a,b,c){if(a||a===0)return this.animate(cu(\"hide\",3),a,b,c);for(var d=0,e=this.length;d<e;d++)if(this[d].style){var g=f.css(this[d],\"display\");g!==\"none\"&&!f._data(this[d],\"olddisplay\")&&f._data(this[d],\"olddisplay\",g)}for(d=0;d<e;d++)this[d].style&&(this[d].style.display=\"none\");return this},_toggle:f.fn.toggle,toggle:function(a,b,c){var d=typeof a==\"boolean\";f.isFunction(a)&&f.isFunction(b)?this._toggle.apply(this,arguments):a==null||d?this.each(function(){var b=d?a:f(this).is(\":hidden\");f(this)[b?\"show\":\"hide\"]()}):this.animate(cu(\"toggle\",3),a,b,c);return this},fadeTo:function(a,b,c,d){return this.filter(\":hidden\").css(\"opacity\",0).show().end().animate({opacity:b},a,c,d)},animate:function(a,b,c,d){var e=f.speed(b,c,d);if(f.isEmptyObject(a))return this.each(e.complete,[!1]);a=f.extend({},a);return this[e.queue===!1?\"each\":\"queue\"](function(){e.queue===!1&&f._mark(this);var b=f.extend({},e),c=this.nodeType===1,d=c&&f(this).is(\":hidden\"),g,h,i,j,k,l,m,n,o;b.animatedProperties={};for(i in a){g=f.camelCase(i),i!==g&&(a[g]=a[i],delete a[i]),h=a[g],f.isArray(h)?(b.animatedProperties[g]=h[1],h=a[g]=h[0]):b.animatedProperties[g]=b.specialEasing&&b.specialEasing[g]||b.easing||\"swing\";if(h===\"hide\"&&d||h===\"show\"&&!d)return b.complete.call(this);c&&(g===\"height\"||g===\"width\")&&(b.overflow=[this.style.overflow,this.style.overflowX,this.style.overflowY],f.css(this,\"display\")===\"inline\"&&f.css(this,\"float\")===\"none\"&&(f.support.inlineBlockNeedsLayout?(j=cv(this.nodeName),j===\"inline\"?this.style.display=\"inline-block\":(this.style.display=\"inline\",this.style.zoom=1)):this.style.display=\"inline-block\"))}b.overflow!=null&&(this.style.overflow=\"hidden\");for(i in a)k=new f.fx(this,b,i),h=a[i],cm.test(h)?k[h===\"toggle\"?d?\"show\":\"hide\":h]():(l=cn.exec(h),m=k.cur(),l?(n=parseFloat(l[2]),o=l[3]||(f.cssNumber[i]?\"\":\"px\"),o!==\"px\"&&(f.style(this,i,(n||1)+o),m=(n||1)/k.cur()*m,f.style(this,i,m+o)),l[1]&&(n=(l[1]===\"-=\"?-1:1)*n+m),k.custom(m,n,o)):k.custom(m,h,\"\"));return!0})},stop:function(a,b){a&&this.queue([]),this.each(function(){var a=f.timers,c=a.length;b||f._unmark(!0,this);while(c--)a[c].elem===this&&(b&&a[c](!0),a.splice(c,1))}),b||this.dequeue();return this}}),f.each({slideDown:cu(\"show\",1),slideUp:cu(\"hide\",1),slideToggle:cu(\"toggle\",1),fadeIn:{opacity:\"show\"},fadeOut:{opacity:\"hide\"},fadeToggle:{opacity:\"toggle\"}},function(a,b){f.fn[a]=function(a,c,d){return this.animate(b,a,c,d)}}),f.extend({speed:function(a,b,c){var d=a&&typeof a==\"object\"?f.extend({},a):{complete:c||!c&&b||f.isFunction(a)&&a,duration:a,easing:c&&b||b&&!f.isFunction(b)&&b};d.duration=f.fx.off?0:typeof d.duration==\"number\"?d.duration:d.duration in f.fx.speeds?f.fx.speeds[d.duration]:f.fx.speeds._default,d.old=d.complete,d.complete=function(a){d.queue!==!1?f.dequeue(this):a!==!1&&f._unmark(this),f.isFunction(d.old)&&d.old.call(this)};return d},easing:{linear:function(a,b,c,d){return c+d*a},swing:function(a,b,c,d){return(-Math.cos(a*Math.PI)/2+.5)*d+c}},timers:[],fx:function(a,b,c){this.options=b,this.elem=a,this.prop=c,b.orig=b.orig||{}}}),f.fx.prototype={update:function(){this.options.step&&this.options.step.call(this.elem,this.now,this),(f.fx.step[this.prop]||f.fx.step._default)(this)},cur:function(){if(this.elem[this.prop]!=null&&(!this.elem.style||this.elem.style[this.prop]==null))return this.elem[this.prop];var a,b=f.css(this.elem,this.prop);return isNaN(a=parseFloat(b))?!b||b===\"auto\"?0:b:a},custom:function(a,b,c){function h(a){return d.step(a)}var d=this,e=f.fx,g;this.startTime=cq||cs(),this.start=a,this.end=b,this.unit=c||this.unit||(f.cssNumber[this.prop]?\"\":\"px\"),this.now=this.start,this.pos=this.state=0,h.elem=this.elem,h()&&f.timers.push(h)&&!co&&(cr?(co=1,g=function(){co&&(cr(g),e.tick())},cr(g)):co=setInterval(e.tick,e.interval))},show:function(){this.options.orig[this.prop]=f.style(this.elem,this.prop),this.options.show=!0,this.custom(this.prop===\"width\"||this.prop===\"height\"?1:0,this.cur()),f(this.elem).show()},hide:function(){this.options.orig[this.prop]=f.style(this.elem,this.prop),this.options.hide=!0,this.custom(this.cur(),0)},step:function(a){var b=cq||cs(),c=!0,d=this.elem,e=this.options,g,h;if(a||b>=e.duration+this.startTime){this.now=this.end,this.pos=this.state=1,this.update(),e.animatedProperties[this.prop]=!0;for(g in e.animatedProperties)e.animatedProperties[g]!==!0&&(c=!1);if(c){e.overflow!=null&&!f.support.shrinkWrapBlocks&&f.each([\"\",\"X\",\"Y\"],function(a,b){d.style[\"overflow\"+b]=e.overflow[a]}),e.hide&&f(d).hide();if(e.hide||e.show)for(var i in e.animatedProperties)f.style(d,i,e.orig[i]);e.complete.call(d)}return!1}e.duration==Infinity?this.now=b:(h=b-this.startTime,this.state=h/e.duration,this.pos=f.easing[e.animatedProperties[this.prop]](this.state,h,0,1,e.duration),this.now=this.start+(this.end-this.start)*this.pos),this.update();return!0}},f.extend(f.fx,{tick:function(){for(var a=f.timers,b=0;b<a.length;++b)a[b]()||a.splice(b--,1);a.length||f.fx.stop()},interval:13,stop:function(){clearInterval(co),co=null},speeds:{slow:600,fast:200,_default:400},step:{opacity:function(a){f.style(a.elem,\"opacity\",a.now)},_default:function(a){a.elem.style&&a.elem.style[a.prop]!=null?a.elem.style[a.prop]=(a.prop===\"width\"||a.prop===\"height\"?Math.max(0,a.now):a.now)+a.unit:a.elem[a.prop]=a.now}}}),f.expr&&f.expr.filters&&(f.expr.filters.animated=function(a){return f.grep(f.timers,function(b){return a===b.elem}).length});var cw=/^t(?:able|d|h)$/i,cx=/^(?:body|html)$/i;\"getBoundingClientRect\"in c.documentElement?f.fn.offset=function(a){var b=this[0],c;if(a)return this.each(function(b){f.offset.setOffset(this,a,b)});if(!b||!b.ownerDocument)return null;if(b===b.ownerDocument.body)return f.offset.bodyOffset(b);try{c=b.getBoundingClientRect()}catch(d){}var e=b.ownerDocument,g=e.documentElement;if(!c||!f.contains(g,b))return c?{top:c.top,left:c.left}:{top:0,left:0};var h=e.body,i=cy(e),j=g.clientTop||h.clientTop||0,k=g.clientLeft||h.clientLeft||0,l=i.pageYOffset||f.support.boxModel&&g.scrollTop||h.scrollTop,m=i.pageXOffset||f.support.boxModel&&g.scrollLeft||h.scrollLeft,n=c.top+l-j,o=c.left+m-k;return{top:n,left:o}}:f.fn.offset=function(a){var b=this[0];if(a)return this.each(function(b){f.offset.setOffset(this,a,b)});if(!b||!b.ownerDocument)return null;if(b===b.ownerDocument.body)return f.offset.bodyOffset(b);f.offset.initialize();var c,d=b.offsetParent,e=b,g=b.ownerDocument,h=g.documentElement,i=g.body,j=g.defaultView,k=j?j.getComputedStyle(b,null):b.currentStyle,l=b.offsetTop,m=b.offsetLeft;while((b=b.parentNode)&&b!==i&&b!==h){if(f.offset.supportsFixedPosition&&k.position===\"fixed\")break;c=j?j.getComputedStyle(b,null):b.currentStyle,l-=b.scrollTop,m-=b.scrollLeft,b===d&&(l+=b.offsetTop,m+=b.offsetLeft,f.offset.doesNotAddBorder&&(!f.offset.doesAddBorderForTableAndCells||!cw.test(b.nodeName))&&(l+=parseFloat(c.borderTopWidth)||0,m+=parseFloat(c.borderLeftWidth)||0),e=d,d=b.offsetParent),f.offset.subtractsBorderForOverflowNotVisible&&c.overflow!==\"visible\"&&(l+=parseFloat(c.borderTopWidth)||0,m+=parseFloat(c.borderLeftWidth)||0),k=c}if(k.position===\"relative\"||k.position===\"static\")l+=i.offsetTop,m+=i.offsetLeft;f.offset.supportsFixedPosition&&k.position===\"fixed\"&&(l+=Math.max(h.scrollTop,i.scrollTop),m+=Math.max(h.scrollLeft,i.scrollLeft));return{top:l,left:m}},f.offset={initialize:function(){var a=c.body,b=c.createElement(\"div\"),d,e,g,h,i=parseFloat(f.css(a,\"marginTop\"))||0,j=\"<div style='position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;'><div></div></div><table style='position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;' cellpadding='0' cellspacing='0'><tr><td></td></tr></table>\";f.extend(b.style,{position:\"absolute\",top:0,left:0,margin:0,border:0,width:\"1px\",height:\"1px\",visibility:\"hidden\"}),b.innerHTML=j,a.insertBefore(b,a.firstChild),d=b.firstChild,e=d.firstChild,h=d.nextSibling.firstChild.firstChild,this.doesNotAddBorder=e.offsetTop!==5,this.doesAddBorderForTableAndCells=h.offsetTop===5,e.style.position=\"fixed\",e.style.top=\"20px\",this.supportsFixedPosition=e.offsetTop===20||e.offsetTop===15,e.style.position=e.style.top=\"\",d.style.overflow=\"hidden\",d.style.position=\"relative\",this.subtractsBorderForOverflowNotVisible=e.offsetTop===-5,this.doesNotIncludeMarginInBodyOffset=a.offsetTop!==i,a.removeChild(b),f.offset.initialize=f.noop},bodyOffset:function(a){var b=a.offsetTop,c=a.offsetLeft;f.offset.initialize(),f.offset.doesNotIncludeMarginInBodyOffset&&(b+=parseFloat(f.css(a,\"marginTop\"))||0,c+=parseFloat(f.css(a,\"marginLeft\"))||0);return{top:b,left:c}},setOffset:function(a,b,c){var d=f.css(a,\"position\");d===\"static\"&&(a.style.position=\"relative\");var e=f(a),g=e.offset(),h=f.css(a,\"top\"),i=f.css(a,\"left\"),j=(d===\"absolute\"||d===\"fixed\")&&f.inArray(\"auto\",[h,i])>-1,k={},l={},m,n;j?(l=e.position(),m=l.top,n=l.left):(m=parseFloat(h)||0,n=parseFloat(i)||0),f.isFunction(b)&&(b=b.call(a,c,g)),b.top!=null&&(k.top=b.top-g.top+m),b.left!=null&&(k.left=b.left-g.left+n),\"using\"in b?b.using.call(a,k):e.css(k)}},f.fn.extend({position:function(){if(!this[0])return null;var a=this[0],b=this.offsetParent(),c=this.offset(),d=cx.test(b[0].nodeName)?{top:0,left:0}:b.offset();c.top-=parseFloat(f.css(a,\"marginTop\"))||0,c.left-=parseFloat(f.css(a,\"marginLeft\"))||0,d.top+=parseFloat(f.css(b[0],\"borderTopWidth\"))||0,d.left+=parseFloat(f.css(b[0],\"borderLeftWidth\"))||0;return{top:c.top-d.top,left:c.left-d.left}},offsetParent:function(){return this.map(function(){var a=this.offsetParent||c.body;while(a&&!cx.test(a.nodeName)&&f.css(a,\"position\")===\"static\")a=a.offsetParent;return a})}}),f.each([\"Left\",\"Top\"],function(a,c){var d=\"scroll\"+c;f.fn[d]=function(c){var e,g;if(c===b){e=this[0];if(!e)return null;g=cy(e);return g?\"pageXOffset\"in g?g[a?\"pageYOffset\":\"pageXOffset\"]:f.support.boxModel&&g.document.documentElement[d]||g.document.body[d]:e[d]}return this.each(function(){g=cy(this),g?g.scrollTo(a?f(g).scrollLeft():c,a?c:f(g).scrollTop()):this[d]=c})}}),f.each([\"Height\",\"Width\"],function(a,c){var d=c.toLowerCase();f.fn[\"inner\"+c]=function(){return this[0]?parseFloat(f.css(this[0],d,\"padding\")):null},f.fn[\"outer\"+c]=function(a){return this[0]?parseFloat(f.css(this[0],d,a?\"margin\":\"border\")):null},f.fn[d]=function(a){var e=this[0];if(!e)return a==null?null:this;if(f.isFunction(a))return this.each(function(b){var c=f(this);c[d](a.call(this,b,c[d]()))});if(f.isWindow(e)){var g=e.document.documentElement[\"client\"+c];return e.document.compatMode===\"CSS1Compat\"&&g||e.document.body[\"client\"+c]||g}if(e.nodeType===9)return Math.max(e.documentElement[\"client\"+c],e.body[\"scroll\"+c],e.documentElement[\"scroll\"+c],e.body[\"offset\"+c],e.documentElement[\"offset\"+c]);if(a===b){var h=f.css(e,d),i=parseFloat(h);return f.isNaN(i)?h:i}return this.css(d,typeof a==\"string\"?a:a+\"px\")}}),a.jQuery=a.$=f})(window);";
				#endregion
			}
		}

		/// <summary>
		/// 获取 1.4.2 版本的 jQuery 脚本官方地址.
		/// </summary>
		public static string Script_1_4_2_Url
		{
			get { return "http://code.jquery.com/jquery-1.4.2.min.js"; }
		}

		/// <summary>
		/// 获取 1.4.1 版本的 jQuery 脚本 zoyobar.googlecode.com 地址.
		/// </summary>
		public static string Script_1_4_1_Url
		{
			get { return "http://zoyobar.googlecode.com/files/jquery-1.4.1.min.js"; }
		}

		#region " 构造 "

		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( JQuery jQuery )
		{ return new JQuery ( jQuery ); }

		/// <summary>
		/// 创建使用别名的空的 JQuery.
		/// </summary>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( )
		{ return Create ( null, null, true ); }
		/// <summary>
		/// 创建空的 JQuery.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( bool isAlias )
		{ return Create ( null, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI )
		{ return Create ( expressionI, null, true ); }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, bool isAlias )
		{ return Create ( expressionI, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, string expressionII )
		{ return Create ( expressionI, expressionII, true ); }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, string expressionII, bool isAlias )
		{ return new JQuery ( expressionI, expressionII, isAlias ); }

		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( bool isInstance, bool isAlias )
		{ return new JQuery ( isInstance, isAlias ); }


		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		public JQuery ( JQuery jQuery )
			: base ( ScriptType.JavaScript )
		{

			if ( null == jQuery )
				return;

			this.code = jQuery.code;
		}

		/// <summary>
		/// 创建使用别名的空的 JQuery.
		/// </summary>
		public JQuery ( )
			: this ( null, null, true )
		{ }
		/// <summary>
		/// 创建空的 JQuery.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( bool isAlias )
			: this ( null, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		public JQuery ( string expressionI )
			: this ( expressionI, null, true )
		{ }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( string expressionI, bool isAlias )
			: this ( expressionI, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		public JQuery ( string expressionI, string expressionII )
			: this ( expressionI, expressionII, true )
		{ }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( string expressionI, string expressionII, bool isAlias )
			: base ( ScriptType.JavaScript )
		{

			string constructor;

			if ( isAlias )
				constructor = "$";
			else
				constructor = "jQuery";

			if ( string.IsNullOrEmpty ( expressionI ) )
				this.AppendCode ( string.Format ( "{0}()", constructor ) );
			else
				if ( string.IsNullOrEmpty ( expressionII ) )
					this.AppendCode ( string.Format ( "{0}({1})", constructor, expressionI ) );
				else
					this.AppendCode ( string.Format ( "{0}({1}, {2})", constructor, expressionI, expressionII ) );

		}

		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( bool isInstance, bool isAlias )
			: base ( ScriptType.JavaScript )
		{

			if ( isAlias )
				this.AppendCode ( "$" );
			else
				this.AppendCode ( "jQuery" );

			if ( isInstance )
				this.AppendCode ( "()" );

		}

		#endregion

		#region " 基本 "

		/// <summary>
		/// 创建当前 JQuery 的副本, 拥有相同的 Code 属性.
		/// </summary>
		/// <returns>JQuery 的副本.</returns>
		public JQuery Copy ( )
		{ return new JQuery ( this ); }

		/// <summary>
		/// 添加语句的结尾符号.
		/// </summary>
		/// <returns>添加结尾符号后的 JQuery.</returns>
		public JQuery EndLine ( )
		{
			this.AppendCode ( this.EndOfLine );
			return this;
		}

		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName )
		{ return this.Execute ( methodName, null, null, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI )
		{ return this.Execute ( methodName, expressionI, null, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII )
		{ return this.Execute ( methodName, expressionI, expressionII, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <param name="expressionIII">方法的第 3 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( methodName, expressionI, expressionII, expressionIII, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <param name="expressionIII">方法的第 3 个参数的表达式.</param>
		/// <param name="expressionIV">方法的第 4 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII, string expressionIII, string expressionIV )
		{

			if ( string.IsNullOrEmpty ( methodName ) )
				return this;

			if ( string.IsNullOrEmpty ( expressionI ) )
				this.AppendCode ( string.Format ( ".{0}()", methodName ) );
			else
				if ( string.IsNullOrEmpty ( expressionII ) )
					this.AppendCode ( string.Format ( ".{0}({1})", methodName, expressionI ) );
				else
					if ( string.IsNullOrEmpty ( expressionIII ) )
						this.AppendCode ( string.Format ( ".{0}({1}, {2})", methodName, expressionI, expressionII ) );
					else
						if ( string.IsNullOrEmpty ( expressionIV ) )
							this.AppendCode ( string.Format ( ".{0}({1}, {2}, {3})", methodName, expressionI, expressionII, expressionIII ) );
						else
							this.AppendCode ( string.Format ( ".{0}({1}, {2}, {3}, {4})", methodName, expressionI, expressionII, expressionIII, expressionIV ) );

			return this;
		}

		#endregion

		#region " 方法 A "

		/// <summary>
		/// 合并新的元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 或者是一段 html 代码, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Add ( string expressionI )
		{ return this.Add ( expressionI, null ); }
		/// <summary>
		/// 合并新的元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">选择器, 比如: "'body table .red'".</param>
		/// <param name="expressionII">document 元素, 指定选择器搜索的文档.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Add ( string expressionI, string expressionII )
		{ return this.Execute ( "add", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的包含的页面元素添加新的样式.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 可以是多个样式的名称, 比如: "'box red'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AddClass ( string expression )
		{ return this.Execute ( "addClass", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i) { return this.className + i.toString;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery After ( string expressionI )
		{ return this.After ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery After ( string expressionI, string expressionII )
		{ return this.Execute ( "after", expressionI, expressionII ); }

		/// <summary>
		/// 执行 ajax 操作, 并返回 jqXHR javascript 对象.
		/// </summary>
		/// <param name="expressionI">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ajax ( string expressionI )
		{ return this.Ajax ( expressionI, null ); }
		/// <summary>
		/// 执行 ajax 操作, 并返回 jqXHR javascript 对象. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "'js/test.js'".</param>
		/// <param name="expressionII">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ajax ( string expressionI, string expressionII )
		{ return this.Execute ( "ajax", expressionI, expressionII ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求完成的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxComplete ( string expression )
		{ return this.Execute ( "ajaxComplete", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求失败的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, g, a, t){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxError ( string expression )
		{ return this.Execute ( "ajaxError", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求发出的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSend ( string expression )
		{ return this.Execute ( "ajaxSend", expression ); }

		/// <summary>
		/// 设置之后 ajax 操作的默认设置. (需要 1.1 版本以上)
		/// </summary>
		/// <param name="expression">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSetup ( string expression )
		{ return this.Execute ( "ajaxSetup", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加第一个 ajax 请求的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxStart ( string expression )
		{ return this.Execute ( "ajaxStart", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加所有 ajax 请求结束的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxStop ( string expression )
		{ return this.Execute ( "ajaxStop", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加所有 ajax 请求成功的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSuccess ( string expression )
		{ return this.Execute ( "ajaxSuccess", expression ); }

		/// <summary>
		/// 合并 jQuery 匹配到的上一批元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AndSelf ( )
		{ return this.Execute ( "andSelf" ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i, h) { return 'old html is ' + h;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Append ( string expressionI )
		{ return this.Append ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Append ( string expressionI, string expressionII )
		{ return this.Execute ( "append", expressionI, expressionII ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素追加到指定目标之后.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'.red'", 可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AppendTo ( string expression )
		{ return this.Execute ( "appendTo", expression ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的属性, 或者设置所有元素的多个属性.
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'", 也可以是属性集合, 比如: "{type: 'text', title: 'test'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Attr ( string expressionI )
		{ return this.Attr ( expressionI, null ); }
		/// <summary>
		/// 设置 jQuery 中元素的属性.
		/// </summary>
		/// <param name="expressionI">可以是属性名称, 比如: "'title'".</param>
		/// <param name="expressionII">返回属性名称的表达式, 比如: "'just test'", 或者返回属性值的函数, 比如: "function(i, a){ return 'my_' + i.toString(); }". (如果使用函数需要 1.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Attr ( string expressionI, string expressionII )
		{ return this.Execute ( "attr", expressionI, expressionII ); }

		#endregion

		#region " 方法 B "

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i) { return this.className + i.toString;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Before ( string expressionI )
		{ return this.Before ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Before ( string expressionI, string expressionII )
		{ return this.Execute ( "before", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加事件. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI )
		{ return this.Bind ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示停止事件的冒泡. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI, string expressionII )
		{ return this.Bind ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示停止事件的冒泡. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "bind", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加失去焦点事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( )
		{ return this.Blur ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加失去焦点的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( string expressionI )
		{ return this.Blur ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加失去焦点的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( string expressionI, string expressionII )
		{ return this.Execute ( "blur", expressionI, expressionII ); }

		#endregion

		#region " 方法 C "

		/// <summary>
		/// 触发 jQuery 中的元素的添加数据改变事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( )
		{ return this.Change ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加数据改变的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( string expressionI )
		{ return this.Change ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加数据改变的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( string expressionI, string expressionII )
		{ return this.Execute ( "change", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级子元素, 不包含文本元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Children ( )
		{ return this.Children ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素中符合选择器的第一级子元素, 不包含文本元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Children ( string expression )
		{ return this.Execute ( "children", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加单击事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( )
		{ return this.Click ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加单击的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( string expressionI )
		{ return this.Click ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加单击的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( string expressionI, string expressionII )
		{ return this.Execute ( "click", expressionI, expressionII ); }

		/// <summary>
		/// 复制当前 jQuery 中包含的元素, 对于是否复制元素的事件和数据, 1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false, 不复制元素的子元素的事件和数据.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( )
		{ return this.Clone ( null, null ); }
		/// <summary>
		/// 复制当前 jQuery 中包含的元素, 不复制元素的子元素的事件和数据.
		/// </summary>
		/// <param name="expressionI">一个布尔表达式, 比如: "true", 表示是否复制元素的事件和数据. (1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( string expressionI )
		{ return this.Clone ( expressionI, null ); }
		/// <summary>
		/// 复制当前 jQuery 中包含的元素. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expressionI">一个布尔表达式, 比如: "true", 表示是否复制元素的事件和数据. (1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false)</param>
		/// <param name="expressionII">一个布尔表达式, 比如: "true", 表示是否复制元素的子元素的事件和数据.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( string expressionI, string expressionII )
		{ return this.Execute ( "clone", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中元素的第一个符合选择器的父元素, 从当前 jQuery 元素开始搜索. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是一个选择器, 比如: "'strong'", 或者选择器的数组, 比如: "['body', 'ul']", 也可以是一个 jQuery, 比如: "__myJQuery", 也可以是 DOM 元素, 比如: "document.getElementById('name')". (如果使用数组需要 1.4 版本以上, 如果使用 jQuery 或者 DOM 元素需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Closest ( string expressionI )
		{ return this.Closest ( expressionI, null ); }
		/// <summary>
		/// 获取当前 jQuery 中元素的第一个符合选择器的父元素, 从当前 jQuery 元素开始搜索. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是一个选择器, 比如: "'strong'", 或者选择器的数组, 比如: "['body', 'ul']".</param>
		/// <param name="expressionII">返回页面元素的表达式, 指定搜索的位置.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Closest ( string expressionI, string expressionII )
		{ return this.Execute ( "closest", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有子元素, 包含文本和注释. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Contents ( )
		{ return this.Execute ( "contents" ); }

		/// <summary>
		/// 获取当前 jQuery 中第一个元素的样式或者设置所有元素的多个样式.
		/// </summary>
		/// <param name="expressionI">返回要获取的样式名称的表达式, 比如: "'color'", 或者要设置的多个样式, 比如: "{'background-color' : '#ddd', 'font-weight' : '', 'color' : 'rgb(0,40,244)'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Css ( string expressionI )
		{ return this.Css ( expressionI, null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的样式.
		/// </summary>
		/// <param name="expressionI">返回要设置的样式名称的表达式, 比如: "'color'".</param>
		/// <param name="expressionII">返回样式值的表达式, 比如: "'red'", 或者返回值的函数, 比如: "function(i, v){return i.toString() + 'px';}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Css ( string expressionI, string expressionII )
		{ return this.Execute ( "css", expressionI, expressionII ); }

		/// <summary>
		/// 获得 jQuery 的 cssHooks 属性, 用于设置新的样式规则. (需要 1.4.3 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery CssHooks ( )
		{
			this.AppendCode ( ".cssHooks" );
			return this;
		}

		#endregion

		#region " 方法 D "

		/// <summary>
		/// 触发 jQuery 中的元素的添加双击事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( )
		{ return this.Dblclick ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加双击的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( string expressionI )
		{ return this.Dblclick ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加双击的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( string expressionI, string expressionII )
		{ return this.Execute ( "dblclick", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Delegate ( string expressionI, string expressionII, string expressionIII )
		{ return this.Delegate ( expressionI, expressionII, expressionIII, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIV">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Delegate ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "delegate", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 将当前 jQuery 中的元素从页面中删除, 但仍保存在 jQuery 中. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Detach ( )
		{ return this.Detach ( null ); }
		/// <summary>
		/// 将当前 jQuery 中符合选择器的元素从页面中删除, 但仍保存在 jQuery 中. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择删除元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Detach ( string expression )
		{ return this.Execute ( "detach", expression ); }

		/// <summary>
		/// 取消所有使用 live 方法绑定的事件. (需要 1.4.1 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( )
		{ return this.Die ( null, null ); }
		/// <summary>
		/// 取消使用 live 方法绑定的指定事件. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( string expressionI )
		{ return this.Die ( expressionI, null ); }
		/// <summary>
		/// 取消使用 live 方法绑定的指定事件的某个函数. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "clickfunction", 将取消函数作为事件的处理.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( string expressionI, string expressionII )
		{ return this.Execute ( "die", expressionI, expressionII ); }

		#endregion

		#region " 方法 E "

		/// <summary>
		/// 对当前 jQuery 中包含的元素执行对应的 javascript 函数.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(i, e){ $(e).html(i.toString()); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Each ( string expression )
		{ return this.Execute ( "each", expression ); }

		/// <summary>
		/// 将当前 jQuery 中元素的子元素从页面中删除, 包含文本.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Empty ( )
		{ return this.Execute ( "empty" ); }

		/// <summary>
		/// 将最初搜索的一批元素恢复到 jQuery 中. 
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery End ( )
		{ return this.Execute ( "end" ); }

		/// <summary>
		/// 获取当前 jQuery 中指定索引的元素. (需要 1.1.2 版本以上)
		/// </summary>
		/// <param name="expression">返回元素的索引值的表达式, 比如: "0", 如果是 "-1", 则表示最后一个元素. (如果使用负数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Eq ( string expression )
		{ return this.Execute ( "eq", expression ); }

		/// <summary>
		/// 为 jQuery 中的元素添加处理错误的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Error ( string expressionI )
		{ return this.Error ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加处理错误的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Error ( string expressionI, string expressionII )
		{ return this.Execute ( "error", expressionI, expressionII ); }

		#endregion

		#region " 方法 F "

		/// <summary>
		/// 选择当前 jQuery 中符合选择器, 筛选函数, 元素或者 jQuery 中元素的元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')", 或者是另一个 jQuery 对象, 比如: "$('#li64')". (如果元素或者 jQuery 需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Filter ( string expression )
		{ return this.Execute ( "filter", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中包含元素的符合选择器的子元素.
		/// </summary>
		/// <param name="expression">用于筛选子元素的选择器, 比如: "'strong'", 也可以是一个 jQuery, 比如: "__myJQuery", 也可以是 DOM 元素, 比如: "document.getElementById('name')". (如果使用 jQuery 或者 DOM 元素需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Find ( string expression )
		{ return this.Execute ( "find", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中第一个元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery First ( )
		{ return this.Execute ( "first" ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加获取焦点事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( )
		{ return this.Focus ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取焦点的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( string expressionI )
		{ return this.Focus ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取焦点的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( string expressionI, string expressionII )
		{ return this.Execute ( "focus", expressionI, expressionII ); }

		#endregion

		#region " 方法 G "

		/// <summary>
		/// 使用 GET 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Get ( string expressionI )
		{ return this.Get ( expressionI, null, null, null ); }
		/// <summary>
		/// 使用 GET 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <param name="expressionIV">指定获取数据类型的字符串, "'xml'", "'json'", "'script'", "'html'" 中的一种.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Get ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "get", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 使用 GET 获取请求 json 数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "test.aspx".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetJSON ( string expressionI )
		{ return this.GetJSON ( expressionI, null, null ); }
		/// <summary>
		/// 使用 GET 获取请求 json 数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "test.aspx".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetJSON ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "getJSON", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 使用 GET 获取请求 javascript 脚本并执行.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetScript ( string expressionI )
		{ return this.GetScript ( expressionI, null ); }
		/// <summary>
		/// 使用 GET 获取请求 javascript 脚本并执行.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回成功时回调函数的表达式, 比如: "function(d, t){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetScript ( string expressionI, string expressionII )
		{ return this.Execute ( "getScript", expressionI, expressionII ); }

		#endregion

		#region " 方法 H "

		/// <summary>
		/// 选择 jQuery 中元素, 其子元素符合选择器或者元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 或者是元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Has ( string expression )
		{ return this.Execute ( "has", expression ); }

		/// <summary>
		/// 判断样式是否存在.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 比如: "'box'", 将判断样式是否存在.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery HasClass ( string expression )
		{ return this.Execute ( "hasClass", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Height ( )
		{ return this.Height ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的高度.
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110", 或者一个返回数值的函数, 比如: "function(i, h){ return i + h; }". (如果使用函数需要 1.4.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Height ( string expression )
		{ return this.Execute ( "height", expression ); }

		/// <summary>
		/// 是否让 ready 等待执行. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expression">返回布尔值的表达式, 比如: "true", 表示阻止 ready 执行.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery HoldReady ( string expression )
		{ return this.Execute ( "holdReady", expression ); }

		/// <summary>
		/// 设置当前 jQuery 元素的鼠标进入和离开的事件. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标进入和离开的共同事件.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Hover ( string expressionI )
		{ return this.Hover ( expressionI, null ); }
		/// <summary>
		/// 设置当前 jQuery 元素的鼠标进入和离开的事件. (需要 1.4.1 版本以上)
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标进入事件.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标离开事件.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Hover ( string expressionI, string expressionII )
		{ return this.Execute ( "hover", expressionI, expressionII ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 innerHTML 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Html ( )
		{ return this.Html ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含元素的 innerHTML 属性.
		/// </summary>
		/// <param name="expression">返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 或者返回 html 代码的函数, 比如: "function(i, h){ return '&lt;stong&gt;&lt;/stong&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Html ( string expression )
		{ return this.Execute ( "html", expression ); }

		#endregion

		#region " 方法 I "

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 不包含边框. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InnerHeight ( )
		{ return this.Execute ( "innerHeight" ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 不包含边框. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InnerWidth ( )
		{ return this.Execute ( "innerWidth" ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素添加到目标之后作为兄弟元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InsertAfter ( string expression )
		{ return this.Execute ( "insertAfter", expression ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素添加到目标之前作为兄弟元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InsertBefore ( string expression )
		{ return this.Execute ( "insertBefore", expression ); }

		/// <summary>
		///判断当前 jQuery 元素是否符合选择器, 如果至少一个符合时, 将在 javascript 中返回 true.
		/// </summary>
		/// <param name="expression">选择器, 比如: "'.box'", 也可以是一个 jQuery, 比如: "__myJQuery", 也可以是 DOM 元素, 比如: "document.getElementById('name')". (如果使用 jQuery 或者 DOM 元素需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Is ( string expression )
		{ return this.Execute ( "is", expression ); }

		#endregion

		#region " 方法 K "

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘按下事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( )
		{ return this.Keydown ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按下的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( string expressionI )
		{ return this.Keydown ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按下的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( string expressionI, string expressionII )
		{ return this.Execute ( "keydown", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘按住事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( )
		{ return this.Keypress ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按住的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( string expressionI )
		{ return this.Keypress ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按住的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( string expressionI, string expressionII )
		{ return this.Execute ( "keypress", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘松开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( )
		{ return this.Keyup ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘松开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( string expressionI )
		{ return this.Keyup ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘松开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( string expressionI, string expressionII )
		{ return this.Execute ( "keyup", expressionI, expressionII ); }

		#endregion

		#region " 方法 L "

		/// <summary>
		/// 选择当前 jQuery 中最后一个元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Last ( )
		{ return this.Execute ( "last" ); }

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Length ( )
		{
			this.AppendCode ( ".length" );
			return this;
		}

		/// <summary>
		/// 为 jQuery 中的元素添加事件, 可以用 die 方法取消. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI )
		{ return this.Live ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件, 可以用 die 方法取消. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI, string expressionII )
		{ return this.Live ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件, 可以用 die 方法取消. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "live", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加载入的事件, 或者使用 GET 请求 html 代码.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 或者返回地址的表达式, 比如: "'test.html'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI )
		{ return this.Load ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加载入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI, string expressionII )
		{ return this.Load ( expressionI, expressionII, null ); }
		/// <summary>
		/// 使用 GET 请求 html 代码.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "'test.html'".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回完成时回调函数的表达式, 比如: "function(r, t, x){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "load", expressionI, expressionII, expressionIII ); }

		#endregion

		#region " 方法 M "

		/// <summary>
		/// 对当前 jQuery 中的元素执行函数, 并将执行的结果返回为一个 javascript 数组. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expressionI">返回调用函数的表达式, 比如: "function(i, o){ return 'my_' + i.toString(); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Map ( string expressionI )
		{ return this.Map ( expressionI ); }
		/// <summary>
		/// 对一个数组或者对象执行函数.
		/// </summary>
		/// <param name="expressionI">返回对象或者数组的表达式, 比如: "['a', 'b', 'c']". (如果使用对象元素需要 1.6 版本以上)</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(elementOfArray, indexInArray){}" 或者 "function(value, indexOrKey){}". (如果使用后一个函数需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Map ( string expressionI, string expressionII )
		{ return this.Execute ( "map", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标按下事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( )
		{ return this.Mousedown ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标按下的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( string expressionI )
		{ return this.Mousedown ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标按下的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( string expressionI, string expressionII )
		{ return this.Execute ( "mousedown", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标进入事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( )
		{ return this.Mouseenter ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标进入的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( string expressionI )
		{ return this.Mouseenter ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标进入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseenter", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标离开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( )
		{ return this.Mouseleave ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标离开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( string expressionI )
		{ return this.Mouseleave ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标离开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseleave", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑动事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( )
		{ return this.Mousemove ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑动的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( string expressionI )
		{ return this.Mousemove ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑动的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( string expressionI, string expressionII )
		{ return this.Execute ( "mousemove", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑出事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( )
		{ return this.Mouseout ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑出的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( string expressionI )
		{ return this.Mouseout ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑出的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseout", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑入事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( )
		{ return this.Mouseover ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑入的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( string expressionI )
		{ return this.Mouseover ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseover", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标松开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( )
		{ return this.Mouseup ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标松开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( string expressionI )
		{ return this.Mouseup ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标松开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseup", expressionI, expressionII ); }

		#endregion

		#region " 方法 N "

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的第一个兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Next ( )
		{ return this.Next ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的符合选择器的第一个兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Next ( string expression )
		{ return this.Execute ( "next", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextAll ( )
		{ return this.NextAll ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的符合选择器的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextAll ( string expression )
		{ return this.Execute ( "nextAll", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素向后的所有兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextUntil ( )
		{ return this.NextUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素向后的所有兄弟元素, 出现符合选择器的兄弟元素为止, 不包含此符合选择器的兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextUntil ( string expression )
		{ return this.Execute ( "nextUntil", expression ); }

		/// <summary>
		/// 卸载 jQuery 在页面中 $ 的定义.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NoConflict ( )
		{ return this.NoConflict ( null ); }
		/// <summary>
		/// 卸载 jQuery 在页面中 $ 的定义.
		/// </summary>
		/// <param name="expression">一个返回布尔值的表达式, 比如: "true", "1 > 2" 或者 "isOK", 其中 isOK 是 javascript 脚本中的变量, 如果表达式为 true, 则卸载 $ 和 jQuery 的定义, 否则只卸载 $ 的定义.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NoConflict ( string expression )
		{ return this.Execute ( "noConflict", expression ); }

		/// <summary>
		/// 去除当前 jQuery 中符合条件的元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Not ( string expression )
		{ return this.Execute ( "not", expression ); }

		#endregion

		#region " 方法 O "

		/// <summary>
		/// 获取当前 jQuery 中第一个元素相对于 document 的位置, 返回值保存一个拥有 top 和 left 属性的对象中.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Offset ( )
		{ return this.Offset ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素相对于 document 的位置.
		/// </summary>
		/// <param name="expression">返回具有 top 和 left 属性的对象的表达式, 比如: "{ top: 10, left: 20 }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Offset ( string expression )
		{ return this.Execute ( "offset", expression ); }

		/// <summary>
		/// 获取 jQuery 中包含元素的第一个设置了 position 样式为 relative, absolute 或者 fixed 的父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OffsetParent ( )
		{ return this.Execute ( "offsetParent" ); }

		/// <summary>
		/// 为 jQuery 中的元素添加只执行一次的事件. (需要 1.1 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery One ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "one", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 包含边框, padding. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterHeight ( )
		{ return this.OuterHeight ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 包含边框, padding, 可选 margin. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个布尔表达式, 比如: "true", 指定是否包含 margin, 默认为 false.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterHeight ( string expression )
		{ return this.Execute ( "outerHeight", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 包含边框, padding. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterWidth ( )
		{ return this.OuterWidth ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 包含边框, padding, 可选 margin. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个布尔表达式, 比如: "true", 指定是否包含 margin, 默认为 false.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterWidth ( string expression )
		{ return this.Execute ( "outerWidth", expression ); }

		#endregion

		#region " 方法  P "

		/// <summary>
		/// 将对象或者数组转化为 url 参数.
		/// </summary>
		/// <param name="expressionI">对象或者数组, 比如: "{name: 'abc', age: 12}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Param ( string expressionI )
		{ return this.Param ( expressionI, null ); }
		/// <summary>
		/// 将对象或者数组转化为 url 参数.
		/// </summary>
		/// <param name="expressionI">对象或者数组, 比如: "{name: 'abc', age: 12}".</param>
		/// <param name="expressionII">返回布尔值的表达式, 比如: "true", 指示是否深度转化.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Param ( string expressionI, string expressionII )
		{ return this.Execute ( "param", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parent ( )
		{ return this.Parent ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级符合选择器的父元素.
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parent ( string expression )
		{ return this.Execute ( "parent", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parents ( )
		{ return this.Parents ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有符合选择器的父元素.
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parents ( string expression )
		{ return this.Execute ( "parents", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的所有父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ParentsUntil ( )
		{ return this.ParentsUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的所有父元素, 出现符合选择器的父元素为止, 不包含此符合选择器的父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ParentsUntil ( string expression )
		{ return this.Execute ( "parentsUntil", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中第一个元素相对于父元素的位置, 返回值保存一个拥有 top 和 left 属性的对象中.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Position ( )
		{ return this.Execute ( "position" ); }

		/// <summary>
		/// 使用 POST 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Post ( string expressionI )
		{ return this.Post ( expressionI, null, null, null ); }
		/// <summary>
		/// 使用 POST 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <param name="expressionIV">指定获取数据类型的字符串, "'xml'", "'json'", "'script'", "'html'" 中的一种.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Post ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "post", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i, h) { return 'old html is ' + h;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prepend ( string expressionI )
		{ return this.Prepend ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prepend ( string expressionI, string expressionII )
		{ return this.Execute ( "prepend", expressionI, expressionII ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素追加到指定目标之前.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'.red'", 可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrependTo ( string expression )
		{ return this.Execute ( "prependTo", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的第一个兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prev ( )
		{ return this.Prev ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的符合选择器的第一个兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prev ( string expression )
		{ return this.Execute ( "prev", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevAll ( )
		{ return this.PrevAll ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的符合选择器的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevAll ( string expression )
		{ return this.Execute ( "prevAll", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素向前的所有兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevUntil ( )
		{ return this.PrevUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素向前的所有兄弟元素, 出现符合选择器的兄弟元素为止, 不包含此符合选择器的兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevUntil ( string expression )
		{ return this.Execute ( "prevUntil", expression ); }

		/// <summary>
		/// 返回承若对象. (需要 1.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Promise ( )
		{ return this.Promise ( null, null ); }
		/// <summary>
		/// 返回承若对象. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">观察的类型.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Promise ( string expressionI )
		{ return this.Promise ( expressionI, null ); }
		/// <summary>
		/// 返回承若对象. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">观察的类型.</param>
		/// <param name="expressionII">承若附加的对象.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Promise ( string expressionI, string expressionII )
		{ return this.Execute ( "promise", expressionI, expressionII ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的属性, 与 Attr 不同的是返回的值不单单为字符串, 或者设置所有元素的多个属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'", 也可以是属性集合, 比如: "{type: 'text', title: 'test'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prop ( string expressionI )
		{ return this.Prop ( expressionI, null ); }
		/// <summary>
		/// 设置 jQuery 中元素的属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是属性名称, 比如: "'title'".</param>
		/// <param name="expressionII">返回属性名称的表达式, 比如: "'just test'", 或者返回属性值的函数, 比如: "function(i, a){ return 'my_' + i.toString(); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prop ( string expressionI, string expressionII )
		{ return this.Execute ( "prop", expressionI, expressionII ); }

		/// <summary>
		/// 产生新的函数, 并指定新的上下文. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">函数的原型, 比如: "function(){ return this.toString(); }", 如果 expressionII 是函数名称, 也可以是新的上下文的表达式, 比如: "someobj".</param>
		/// <param name="expressionII">新的上下文的表达式, 比如: "someobj", 如果 expressionI 是上下文的表达式, 也可以是函数名称, 比如: "'test'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Proxy ( string expressionI, string expressionII )
		{ return this.Execute ( "proxy", expressionI, expressionII ); }

		#endregion

		#region " 方法 R "

		/// <summary>
		/// 添加当整个页面载入后的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ready ( string expression )
		{ return this.Execute ( "", expression ); }

		/// <summary>
		/// 将当前 jQuery 中的元素从页面中删除.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Remove ( )
		{ return this.Remove ( null ); }
		/// <summary>
		/// 将当前 jQuery 中符合选择器的元素从页面中删除.
		/// </summary>
		/// <param name="expression">用于选择删除元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Remove ( string expression )
		{ return this.Execute ( "remove", expression ); }

		/// <summary>
		/// 删除 jQuery 中包含的元素的属性.
		/// </summary>
		/// <param name="expression">返回属性名称的表达式, 比如: "'title'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveAttr ( string expression )
		{ return this.Execute ( "removeAttr", expression ); }

		/// <summary>
		/// 删除 jQuery 中包含的元素的所有样式.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveClass ( )
		{ return this.RemoveClass ( null ); }
		/// <summary>
		/// 删除 jQuery 中包含的元素的指定样式.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveClass ( string expression )
		{ return this.Execute ( "removeClass", expression ); }

		/// <summary>
		/// 删除通过 Prop 添加的属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveProp ( string expressionI )
		{ return this.RemoveProp ( expressionI, null ); }
		/// <summary>
		/// 删除通过 Prop 添加的属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'".</param>
		/// <param name="expressionII">用于匹配属性的值, 比如: "'happy.gif'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveProp ( string expressionI, string expressionII )
		{ return this.Execute ( "removeProp", expressionI, expressionII ); }

		/// <summary>
		/// 使用当前 jQuery 中的元素替换符合选择器的元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">选择被替换到的元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ReplaceAll ( string expression )
		{ return this.Execute ( "replaceAll", expression ); }

		/// <summary>
		/// 使用新的元素替换当前 jQuery 中的元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(){ document.getElementById('abc') }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ReplaceWith ( string expression )
		{ return this.Execute ( "replaceWith", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加大小改变事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( )
		{ return this.Resize ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加大小改变的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( string expressionI )
		{ return this.Resize ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加大小改变的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( string expressionI, string expressionII )
		{ return this.Execute ( "resize", expressionI, expressionII ); }

		#endregion

		#region " 方法 S "

		/// <summary>
		/// 触发 jQuery 中的元素的添加滚动轴事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( )
		{ return this.Scroll ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加滚动轴的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( string expressionI )
		{ return this.Scroll ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加滚动轴的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( string expressionI, string expressionII )
		{ return this.Execute ( "scroll", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的水平滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollLeft ( )
		{ return this.ScrollLeft ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的水平滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollLeft ( string expression )
		{ return this.Execute ( "scrollLeft", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的垂直滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollTop ( )
		{ return this.ScrollTop ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的垂直滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollTop ( string expression )
		{ return this.Execute ( "scrollTop", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加选择事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( )
		{ return this.Select ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加选择的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( string expressionI )
		{ return this.Select ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加选择的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( string expressionI, string expressionII )
		{ return this.Execute ( "select", expressionI, expressionII ); }

		/// <summary>
		/// 将表单中包含的值转化为 url 参数字符串.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Serialize ( )
		{ return this.Execute ( "serialize" ); }

		/// <summary>
		/// 将表单中包含的值转化为数组.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery SerializeArray ( )
		{ return this.Execute ( "serializeArray" ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Siblings ( )
		{ return this.Siblings ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有符合选择器的兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Siblings ( string expression )
		{ return this.Execute ( "siblings", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中从某个位置开始到结束范围的元素, 0 是第 1 个元素, -1 是最后一个元素. (需要 1.1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Slice ( string expressionI )
		{ return this.Slice ( expressionI, null ); }
		/// <summary>
		/// 选择当前 jQuery 中某个范围的元素, 0 是第 1 个元素, -1 是最后一个元素. (需要 1.1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <param name="expressionII">结束索引, 比如: "2", 结束位置的元素不会被选择.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Slice ( string expressionI, string expressionII )
		{ return this.Execute ( "slice", expressionI, expressionII ); }

		/// <summary>
		/// 创建主 jQuery 对象的副本.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Sub ( )
		{ return this.Execute ( "sub" ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加提交事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( )
		{ return this.Submit ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加提交的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( string expressionI )
		{ return this.Submit ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加提交的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( string expressionI, string expressionII )
		{ return this.Execute ( "submit", expressionI, expressionII ); }

		#endregion

		#region " 方法 T "

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 innerText 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Text ( )
		{ return this.Text ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含元素的 innerText 属性.
		/// </summary>
		/// <param name="expression">一个字符串表达式, 比如: "'this is abc'", 或者返回字符串的函数, 比如: "function(i, t){ return 'old text is ' + t; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Text ( string expression )
		{ return this.Execute ( "text", expression ); }

		/// <summary>
		/// 为当前 jQuery 元素添加多个点击事件, 将根据点击次数在这些事件中切换.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <param name="expressionII">同 expressionI, 可以为 null.</param>
		/// <param name="expressionIII">同 expressionI, 可以为 null.</param>
		/// <param name="expressionIV">同 expressionI, 可以为 null.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Toggle ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "toggle", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 切换 jQuery 中包含的元素的样式, 样式存在则删除, 如果不存在则添加.
		/// </summary>
		/// <param name="expressionI">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ToggleClass ( string expressionI )
		{ return this.ToggleClass ( expressionI, null ); }
		/// <summary>
		/// 添加或者删除 jQuery 中包含的元素的样式. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <param name="expressionII">返回布尔值的表达式, 表示添加还是删除样式.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ToggleClass ( string expressionI, string expressionII )
		{ return this.Execute ( "toggleClass", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中元素的事件. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Trigger ( string expressionI )
		{ return this.Trigger ( expressionI, null ); }
		/// <summary>
		/// 触发 jQuery 中元素的事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">扩展的参数数组, 比如: "[age: 10, size: 100]".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Trigger ( string expressionI, string expressionII )
		{ return this.Execute ( "trigger", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中第一个元素的事件, 不引发元素的默认行文. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">扩展的参数数组, 比如: "[age: 10, size: 100]".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery TriggerHandler ( string expressionI, string expressionII )
		{ return this.Execute ( "triggerHandler", expressionI, expressionII ); }

		#endregion

		#region " 方法 U "

		/// <summary>
		/// 为 jQuery 中的元素取消所有事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( )
		{ return this.Unbind ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件.
		/// </summary>
		/// <param name="expressionI">可以是事件类型, 比如: "'click'", "'click mouseover'", 也可以是包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( string expressionI )
		{ return this.Unbind ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示取消停止冒泡的事件. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( string expressionI, string expressionII )
		{ return this.Execute ( "unbind", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的元素取消所有事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( )
		{ return this.Undelegate ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消命名空间下的事件. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">事件所在的命名空间, 比如: "'.whatever'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI )
		{ return this.Undelegate ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI, string expressionII )
		{ return this.Undelegate ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "undelegate", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加卸载的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unload ( string expressionI )
		{ return this.Unload ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加卸载的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unload ( string expressionI, string expressionII )
		{ return this.Execute ( "unload", expressionI, expressionII ); }

		/// <summary>
		/// 删除调用 wrap 方法产生的父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unwrap ( )
		{ return this.Execute ( "unwrap" ); }

		#endregion

		#region " 方法 V "

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 value 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Val ( )
		{ return this.Val ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含的元素 value 属性.
		/// </summary>
		/// <param name="expression">一个表达式, 比如: "'my name'", 或者是一个返回值的函数, 比如: "function(i, v){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Val ( string expression )
		{ return this.Execute ( "val", expression ); }

		#endregion

		#region " 方法 W "

		/// <summary>
		/// 调用 when 方法, 传递一个或者多个 javascript 对象, 之后可再通过 done, then 等方法编写这些对象载入后的处理方法. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expression">一个或者多个对象的表达式, 比如: "$.ajax('test.aspx')", 或者 "{ testing: 123 }, { name: 'jack' }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery When ( string expression )
		{ return this.Execute ( "when", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Width ( )
		{ return this.Width ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的宽度.
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110", 或者一个返回数值的函数, 比如: "function(i, w){ return i + w; }". (如果使用函数需要 1.4.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Width ( string expression )
		{ return this.Execute ( "width", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的每一个元素添加父元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(i){ return '&lt;div&gt;&lt;/div&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Wrap ( string expression )
		{ return this.Execute ( "wrap", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的元素添加一个共同的父元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery WrapAll ( string expression )
		{ return this.Execute ( "wrapAll", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的每一个元素添加一个子元素, 这个子元素包含原来所有的子元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(){ return '&lt;div&gt;&lt;/div&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery WrapInner ( string expression )
		{ return this.Execute ( "wrapInner", expression ); }

		#endregion

	}

}
// ../.class/web/ScriptHelper.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ScriptHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * 测试文件:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/testsite/TestScriptHelper.aspx
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/testsite/TestScriptHelper.aspx.cs
 * 合并下载:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/ScriptHelper.all.cs
 * 版本: 1.1, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
* */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

// HACK: 如果代码不能编译, 请尝试在项目中定义编译符号 V4, V3_5, V3, V2 以表示不同的 .NET 版本


// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 此类可以完成客户端脚本的编写, 修改标签属性, 包含脚本文件, 设置时钟等操作.
	/// </summary>
	public partial class ScriptHelper
	{

		private static readonly Random random = new Random ( );

#if PARAM
		/// <summary>
		/// 从一个字符串生成脚本的 id.
		/// </summary>
		/// <param name="key">字符串, 作为 id 的一部分, 默认为 "script_yyyyMMddhhmmss".</param>
		/// <returns>脚本 id.</returns>
		public static string MakeKey ( string key = null )
#else
		/// <summary>
		/// 从一个字符串生成脚本的 id.
		/// </summary>
		/// <param name="key">字符串, 作为 id 的一部分.</param>
		/// <returns>脚本 id.</returns>
		public static string MakeKey ( string key )
#endif
		{

			if ( string.IsNullOrEmpty ( key ) )
				key = DateTime.Now.ToString ( "yyyyMMddhhmmss" ) + random.Next ( 0, int.MaxValue );

			return string.Format ( "script_{0}", key );
		}

#if PARAM
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本, 默认为 None.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( NControl control, string key, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( NControl control, string key, ScriptBuildOption option )
#endif
		{

			if ( null == control )
				return false;

			return IsBuilt ( control.Page, key, option );
		}

#if PARAM
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="page">代码块所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本, 默认为 None.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( Page page, string key, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="page">代码块所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( Page page, string key, ScriptBuildOption option )
#endif
		{

			if ( null == page || null == page.ClientScript )
				return false;

			// HACK: 可能需要添加 V5
#if V4
			if ( option.HasFlag ( ScriptBuildOption.Startup ) )
#else
			if ( ( option & ScriptBuildOption.Startup ) == ScriptBuildOption.Startup )
#endif
				return page.ClientScript.IsStartupScriptRegistered ( page.GetType ( ), MakeKey ( key ) );
			else
				return page.ClientScript.IsClientScriptBlockRegistered ( page.GetType ( ), MakeKey ( key ) );

		}

		protected string code = string.Empty;

		protected readonly ScriptType scriptType;

		/// <summary>
		/// 获取或设置脚本代码.
		/// </summary>
		public string Code
		{
			get { return this.code; }
			set
			{

				if ( null != value )
					this.code = value;

			}
		}

		/// <summary>
		/// 获取脚本类型.
		/// </summary>
		public ScriptType ScriptType
		{
			get { return this.scriptType; }
		}

		/// <summary>
		/// 获取脚本类型对应的 Return 语句.
		/// </summary>
		public string Return
		{
			get
			{

				switch ( this.scriptType )
				{
					case ScriptType.VBScript:
						return string.Empty;

					case ScriptType.JavaScript:
					default:
						return "return";
				}

			}
		}

		/// <summary>
		/// 获取脚本类型对应的语句结束符号.
		/// </summary>
		public string EndOfLine
		{
			get
			{

				switch ( this.scriptType )
				{
					case ScriptType.VBScript:
						return string.Empty;

					case ScriptType.JavaScript:
					default:
						return ";";
				}

			}
		}

#if PARAM
		/// <summary>
		/// 创建脚本帮手.
		/// </summary>
		/// <param name="scriptType">脚本类型, 目前只有 JavaScript 类型可用, 默认为 JavaScript.</param>
		public ScriptHelper ( ScriptType scriptType = ScriptType.JavaScript )
#else
		/// <summary>
		/// 创建脚本帮手.
		/// </summary>
		/// <param name="scriptType">脚本类型, 目前只有 JavaScript 类型可用.</param>
		public ScriptHelper ( ScriptType scriptType )
#endif
		{
			this.scriptType = scriptType;

			switch ( scriptType )
			{
				case ScriptType.VBScript:
					throw new ArgumentException ( "目前不支持 VBScript, 请使用 JavaScript", "quotationType" );
			}

		}

#if PARAM
		/// <summary>
		/// 生成弹出消息的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>弹出消息框的代码.</returns>
		public string Alert ( string message, bool isAppend = true )
#else
		/// <summary>
		/// 生成弹出消息的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>弹出消息框的代码.</returns>
		public string Alert ( string message, bool isAppend )
#endif
		{

			string code = string.Empty;

			if ( string.IsNullOrEmpty ( message ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "alert({0});", message );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回结果到变量等的确认消息函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户确认结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 默认不返回值到变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回结果到变量等的确认消息函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户确认结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( message ) )
				return code;

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{1}confirm({0});", message, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回结果到变量的输入框函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'10'", 也可以是计算表达式, 比如: "defaultAge", 默认为 "''".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 默认不返回值到变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string defaultValue = null, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回结果到变量的输入框函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'10'", 也可以是计算表达式, 比如: "defaultAge".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性?</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string defaultValue, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( null == message )
				return code;

			if ( null == defaultValue )
				defaultValue = "''";

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}prompt({0}, {1});", message, defaultValue, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

		/// <summary>
		/// 清除所有的代码.
		/// </summary>
		public void Clear ( )
		{ this.code = string.Empty; }

		/// <summary>
		/// 添加代码到当前代码结尾处.
		/// </summary>
		/// <param name="code">被添加的代码.</param>
		public void AppendCode ( string code )
		{

			if ( string.IsNullOrEmpty ( code ) )
				return;

			this.code += code;
		}

#if PARAM
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称, 默认自动生成.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效, 默认 None.</param>
		public void Build ( NControl control, string key = null, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( NControl control, string key, ScriptBuildOption option )
#endif
		{

			if ( null == control )
				return;

			this.Build ( control.Page, key, option );
		}

#if PARAM
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="key">代码块的名称, 默认自动生成.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效, 默认 None.</param>
		public void Build ( Page page, string key = null, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( Page page, string key, ScriptBuildOption option )
#endif
		{

			if ( this.code == string.Empty || null == page || null == page.ClientScript || IsBuilt ( page, key, option ) )
				return;

			string type;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					type = "text/javascript";
					break;
			}

			string script;

			// HACK: 可能需要添加 V5
#if V4
			if ( option.HasFlag ( ScriptBuildOption.OnlyCode ) )
#else
			if ( ( option & ScriptBuildOption.OnlyCode ) == ScriptBuildOption.OnlyCode )
#endif
				script = this.code;
			else
				script = string.Format ( "<script language='{0}' type='{1}'>\n{2}\n</script>", this.scriptType.ToString ( ).ToLower ( ), type, this.code );

			key = MakeKey ( key );

			// HACK: 可能需要添加 V5
#if V4
			if ( option.HasFlag ( ScriptBuildOption.Startup ) )
#else
			if ( ( option & ScriptBuildOption.Startup ) == ScriptBuildOption.Startup )
#endif
				page.ClientScript.RegisterStartupScript ( page.GetType ( ), key, script );
			else
				page.ClientScript.RegisterClientScriptBlock ( page.GetType ( ), key, script );

			// if ( option.HasFlag ( ScriptBuildOption.EndResponse ) && null != page.Response )
			//     page.Response.End ();

		}

#if PARAM
		/// <summary>
		/// 生成导航的函数, 地址选项在实际代码中将使用单引号, 比如: '_blank', 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航窗口选项, 默认为 SelfWindow.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, NavigateOption option = NavigateOption.SelfWindow, bool isAppend = true )
#else
		/// <summary>
		/// 生成导航的函数, 地址选项在实际代码中将使用单引号, 比如: '_blank', 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航窗口选项.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, NavigateOption option, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( location ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:

					switch ( option )
					{
						case NavigateOption.NewWindow:
							code = string.Format (
								"window.open({0}, '{1}');",
								location,
								"_blank"
								);
							break;

						case NavigateOption.ParentWindow:
							code = string.Format (
								"window.open({0}, '{1}');",
								location,
								"_parent"
								);
							break;

						case NavigateOption.SelfWindow:
						default:
							code = string.Format ( "location.href = {0};", location );
							break;
					}

					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成清除时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>清除时钟的代码.</returns>
		public string ClearTimeout ( string handler, bool isAppend = true )
#else
		/// <summary>
		/// 生成清除时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>清除时钟的代码.</returns>
		public string ClearTimeout ( string handler, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( handler ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "clearTimeout({0});", handler );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回句柄到变量的时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 默认不保存到任何变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回句柄到变量的时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( runCode ) )
				return code;

			if ( delay <= 0 )
				delay = 1;

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}setTimeout({0}, {1});", runCode, delay, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成清除循环时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>清除循环时钟的代码.</returns>
		public string ClearInterval ( string handler, bool isAppend = true )
#else
		/// <summary>
		/// 生成清除循环时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>清除循环时钟的代码.</returns>
		public string ClearInterval ( string handler, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( handler ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "clearInterval({0});", handler );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回句柄到变量的循环时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 默认不保存到任何变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回句柄到变量的循环时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( runCode ) )
				return code;

			if ( delay <= 0 )
				delay = 1;

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}setInterval({0}, {1});", runCode, delay, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 添加一个数组到控件所在页面的脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 默认不包含值.</param>
		public static void RegisterArray ( NControl control, string arrayName, string arrayValue = null )
#else
		/// <summary>
		/// 添加一个数组到控件所在页面的脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 也可以设置为 null.</param>
		public static void RegisterArray ( NControl control, string arrayName, string arrayValue )
#endif
		{

			if ( null == control )
				return;

			RegisterArray ( control.Page, arrayName, arrayValue );
		}

#if PARAM
		/// <summary>
		/// 添加一个数组到页面脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 默认不包含值.</param>
		public static void RegisterArray ( Page page, string arrayName, string arrayValue = null )
#else
		/// <summary>
		/// 添加一个数组到页面脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 也可以设置为 null.</param>
		public static void RegisterArray ( Page page, string arrayName, string arrayValue )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( arrayName ) )
				return;

			if ( null == arrayValue )
				arrayValue = "";

			page.ClientScript.RegisterArrayDeclaration ( arrayName, arrayValue );
		}


#if PARAM
		/// <summary>
		/// 添加脚本包含到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称, 默认自动生成.</param>
		public static void RegisterInclude ( NControl control, string url, string key = null )
#else
		/// <summary>
		/// 添加脚本包含到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称.</param>
		public static void RegisterInclude ( NControl control, string url, string key )
#endif
		{

			if ( null == control )
				return;

			RegisterInclude ( control.Page, key, url );
		}

#if PARAM
		/// <summary>
		/// 添加脚本包含到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称, 默认自动生成.</param>
		public static void RegisterInclude ( Page page, string url, string key = null )
#else
		/// <summary>
		/// 添加脚本包含到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称.</param>
		public static void RegisterInclude ( Page page, string url, string key )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( url ) )
				return;

			key = MakeKey ( key );

			if ( page.ClientScript.IsClientScriptIncludeRegistered ( page.GetType ( ), key ) )
				return;

			page.ClientScript.RegisterClientScriptInclude ( page.GetType ( ), key, url );
		}

		/// <summary>
		/// 将资源中脚本注册到控件所在的页面中.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="resourceType">资源所在的类型.</param>
		/// <param name="resourceName">资源的名称.</param>
		public static void RegisterResource ( NControl control, Type resourceType, string resourceName )
		{

			if ( null == control )
				return;

			RegisterResource ( control.Page, resourceType, resourceName );
		}

		/// <summary>
		/// 将资源中脚本注册到页面中.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="resourceType">资源所在的类型.</param>
		/// <param name="resourceName">资源的名称.</param>
		public static void RegisterResource ( Page page, Type resourceType, string resourceName )
		{

			if ( null == page || null == page.ClientScript || null == resourceType || string.IsNullOrEmpty ( resourceName ) )
				return;

			page.ClientScript.RegisterClientScriptResource ( resourceType, resourceName );
		}

		/// <summary>
		/// 添加设置标签属性的脚本到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性, 但不能对同一标签的同一属性设置两次.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加设置标签属性的脚本.</param>
		/// <param name="id">标签的 id 属性, 比如: "spanTest", 标签应该是页面上存在的元素.</param>
		/// <param name="attributeName">标签的属性, 比如: "innerHTML" 或者 "style.color".</param>
		/// <param name="attributeValue">属性的值, 比如: "你好" 或者 "#ff0000", 可以为 null.</param>
		public static void RegisterAttribute ( NControl control, string id, string attributeName, string attributeValue )
		{

			if ( null == control )
				return;

			RegisterAttribute ( control.Page, id, attributeName, attributeValue );
		}
		/// <summary>
		/// 添加设置标签属性的脚本到页面, 不需要使用 Build 方法, 也不影响 Code 属性, 但不能对同一标签的同一属性设置两次.
		/// </summary>
		/// <param name="page">添加设置标签属性脚本的页面.</param>
		/// <param name="id">标签的 id 属性, 比如: "spanTest", 标签应该是页面上存在的元素.</param>
		/// <param name="attributeName">标签的属性, 比如: "innerHTML" 或者 "style.color".</param>
		/// <param name="attributeValue">属性的值, 比如: "你好" 或者 "#ff0000", 可以为 null.</param>
		public static void RegisterAttribute ( Page page, string id, string attributeName, string attributeValue )
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( id ) || string.IsNullOrEmpty ( attributeName ) )
				return;

			if ( null == attributeValue )
				attributeValue = string.Empty;

			try
			{ page.ClientScript.RegisterExpandoAttribute ( id, attributeName, attributeValue, true ); }
			catch { }

		}

		/// <summary>
		/// 添加隐藏值到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加隐藏值.</param>
		/// <param name="name">隐藏值的名称.</param>
		/// <param name="value">隐藏值, 可以为 null.</param>
		public static void RegisterHidden ( NControl control, string name, string value )
		{

			if ( null == control )
				return;

			RegisterHidden ( control.Page, name, value );
		}
		/// <summary>
		/// 添加隐藏值到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加隐藏值的页面.</param>
		/// <param name="name">隐藏值的名称.</param>
		/// <param name="value">隐藏值, 可以为 null.</param>
		public static void RegisterHidden ( Page page, string name, string value )
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( name ) )
				return;

			if ( null == value )
				value = string.Empty;

			page.ClientScript.RegisterHiddenField ( name, value );
		}

#if PARAM
		/// <summary>
		/// 添加 OnSubmit 脚本到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称, 默认自动生成.</param>
		public static void RegisterSubmit ( NControl control, string code, string key = null )
#else
		/// <summary>
		/// 添加 OnSubmit 脚本到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称.</param>
		public static void RegisterSubmit ( NControl control, string code, string key )
#endif
		{

			if ( null == control )
				return;

			RegisterSubmit ( control.Page, key, code );
		}

#if PARAM
		/// <summary>
		/// 添加 OnSubmit 脚本到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称, 默认自动生成.</param>
		public static void RegisterSubmit ( Page page, string code, string key = null )
#else
		/// <summary>
		/// 添加 OnSubmit 脚本到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称.</param>
		public static void RegisterSubmit ( Page page, string code, string key )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( code ) )
				return;

			key = MakeKey ( key );

			if ( page.ClientScript.IsOnSubmitStatementRegistered ( page.GetType ( ), key ) )
				return;

			page.ClientScript.RegisterOnSubmitStatement ( page.GetType ( ), key, code );
		}

	}

	partial class ScriptHelper
	{
#if !PARAM
		/// <summary>
		/// 添加脚本包含到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		public static void RegisterInclude ( Page page, string url )
		{ RegisterInclude ( page, url, null ); }

		/// <summary>
		/// 添加脚本包含到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		public static void RegisterInclude ( NControl control, string url )
		{ RegisterInclude ( control, url, null ); }

		/// <summary>
		/// 添加一个数组到页面脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		public static void RegisterArray ( Page page, string arrayName )
		{ RegisterArray ( page, arrayName, null ); }

		/// <summary>
		/// 添加一个数组到控件所在页面的脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		public static void RegisterArray ( NControl control, string arrayName )
		{ RegisterArray ( control, arrayName, null ); }

		/// <summary>
		/// 添加循环时钟的函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay )
		{ return this.SetInterval ( runCode, delay, null, true ); }
		/// <summary>
		/// 添加返回句柄到变量的循环时钟函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, string result )
		{ return this.SetInterval ( runCode, delay, result, true ); }
		/// <summary>
		/// 生成循环时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="isAppend">是否追加到 Code 属性?</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, bool isAppend )
		{ return this.SetInterval ( runCode, delay, null, isAppend ); }

		/// <summary>
		/// 添加清除循环时钟的函数到代码.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <returns>清除循环时钟的代码.</returns>
		public string ClearInterval ( string handler )
		{ return this.ClearInterval ( handler, true ); }

		/// <summary>
		/// 添加时钟的函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay )
		{ return this.SetTimeout ( runCode, delay, null, true ); }
		/// <summary>
		/// 添加返回句柄到变量的时钟函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result )
		{ return this.SetTimeout ( runCode, delay, result, true ); }
		/// <summary>
		/// 生成时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, bool isAppend )
		{ return this.SetTimeout ( runCode, delay, null, isAppend ); }

		/// <summary>
		/// 添加循环时钟的函数到代码.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <returns>清除时钟的代码.</returns>
		public string ClearTimeout ( string handler )
		{ return this.ClearTimeout ( handler, true ); }

		/// <summary>
		/// 添加导航的函数到代码, 在自身窗口打开.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location )
		{ return this.Navigate ( location, NavigateOption.SelfWindow, true ); }
		/// <summary>
		/// 添加导航的函数到代码, 地址选项在实际代码中将使用单引号, 比如: '_blank'.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航窗口选项.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, NavigateOption option )
		{ return this.Navigate ( location, option, true ); }
		/// <summary>
		/// 生成导航的函数, 在自身窗口打开, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, bool isAppend )
		{ return this.Navigate ( location, NavigateOption.SelfWindow, isAppend ); }

		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		public void Build ( Page page )
		{ this.Build ( page, null, ScriptBuildOption.None ); }
		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( Page page, ScriptBuildOption option )
		{ this.Build ( page, null, option ); }
		/// <summary>
		/// 生成代码块, 带有 script 标签, 但不结束页面处理.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="key">代码块的名称.</param>
		public void Build ( Page page, string key )
		{ this.Build ( page, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		public void Build ( NControl control )
		{ this.Build ( control, null, ScriptBuildOption.None ); }
		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( NControl control, ScriptBuildOption option )
		{ this.Build ( control, null, option ); }
		/// <summary>
		/// 生成代码块, 带有 script 标签, 但不结束页面处理.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		public void Build ( NControl control, string key )
		{ this.Build ( control, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 添加返回结果到变量的输入框函数到代码.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string result )
		{ return this.Prompt ( message, null, result, true ); }
		/// <summary>
		/// 添加返回结果到变量的输入框函数到代码.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'10'", 也可以是计算表达式, 比如: "defaultAge".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string defaultValue, string result )
		{ return this.Prompt ( message, defaultValue, result, true ); }
		/// <summary>
		/// 生成返回结果到变量的输入框函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string result, bool isAppend )
		{ return this.Prompt ( message, null, result, isAppend ); }

		/// <summary>
		/// 添加确认消息的函数到代码.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message )
		{ return this.Confirm ( message, null, true ); }
		/// <summary>
		/// 添加返回结果到变量等的确认消息函数到代码.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户确认结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, string result )
		{ return this.Confirm ( message, result, true ); }
		/// <summary>
		/// 生成确认消息的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, bool isAppend )
		{ return this.Confirm ( message, null, isAppend ); }

		/// <summary>
		/// 添加弹出消息的函数到代码.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <returns>弹出消息框的代码.</returns>
		public string Alert ( string message )
		{ return Alert ( message, true ); }

		/// <summary>
		/// 创建脚本帮手, 脚本类型为 JavaScript.
		/// </summary>
		public ScriptHelper ()
			: this ( ScriptType.JavaScript )
		{ }

		/// <summary>
		/// 指定名称的普通代码块是否已经存在?
		/// </summary>
		/// <param name="page">代码块所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( Page page, string key )
		{ return IsBuilt ( page, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 指定名称的普通代码块是否已经存在?
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <returns>是否存在代码块.</returns>
		public static bool IsBuilt ( NControl control, string key )
		{ return IsBuilt ( control, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 生成一个随机的脚本 id.
		/// </summary>
		/// <returns>脚本 id.</returns>
		public static string MakeKey ()
		{ return MakeKey ( null ); }
#endif
	}

}
// ../.class/io/StoreHelper.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/StoreHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/io/StoreHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.io
{

	/// <summary>
	/// 存储辅助类, 帮助 File, Directory 类完成存储工作.
	/// </summary>
	public sealed class StoreHelper
	{

		/// <summary>
		/// 读取文件中的内容.
		/// </summary>
		/// <param name="filePath">文件路径.</param>
		/// <returns>读取的文件中的内容.</returns>
		public static string Read ( string filePath )
		{ return Read ( filePath, Encoding.Default ); }
		/// <summary>
		/// 以指定的编码格式读取文件中的内容.
		/// </summary>
		/// <param name="filePath">文件路径.</param>
		/// <param name="encoding">文件编码.</param>
		/// <returns>读取的文件中的内容.</returns>
		public static string Read ( string filePath, Encoding encoding )
		{

			if ( string.IsNullOrEmpty ( filePath ) )
				return null;

			try
			{
				filePath = Path.GetFullPath ( filePath );

				if ( !File.Exists ( filePath ) )
					return null;

				return File.ReadAllText ( filePath, encoding );
			}
			catch
			{ return null; }

		}

		/// <summary>
		/// 将内容写入到文件, 如果目录不存在将创建目录.
		/// </summary>
		/// <param name="filePath">文件路径.</param>
		/// <param name="content">要写入文件的文本.</param>
		public static void Write ( string filePath, string content )
		{ Write ( filePath, content, Encoding.Default ); }
		/// <summary>
		/// 将内容以指定的编码格式写入到文件, 如果目录不存在将创建目录.
		/// </summary>
		/// <param name="filePath">文件路径.</param>
		/// <param name="content">要写入文件的文本.</param>
		/// <param name="encoding">文件编码.</param>
		public static void Write ( string filePath, string content, Encoding encoding )
		{

			if ( string.IsNullOrEmpty ( filePath ) || null == content )
				return;

			try
			{
				filePath = Path.GetFullPath ( filePath );

				Directory.CreateDirectory ( Path.GetDirectoryName ( filePath ) );

				File.WriteAllText ( filePath, content, encoding );
			}
			catch { }

		}

	}

}
// ../.enum/web/NavigateOption.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/NavigateOption
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 导航选项.
	/// </summary>
	public enum NavigateOption
	{
		/// <summary>
		/// 空设置.
		/// </summary>
		None = 0,
		/// <summary>
		/// 新窗口.
		/// </summary>
		NewWindow = 1,
		/// <summary>
		/// 在自身的窗口.
		/// </summary>
		SelfWindow = 2,
		/// <summary>
		/// 在父窗口中.
		/// </summary>
		ParentWindow = 3
	}

}
// ../.enum/web/ScriptBuildOption.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ScriptBuildOption
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 脚本编译选项.
	/// </summary>
	public enum ScriptBuildOption
	{
		/// <summary>
		/// 默认, 带有 script 标签, 普通脚本块, 不结束页面处理.
		/// </summary>
		None = 0,
		/// <summary>
		/// 结束页面处理.
		/// </summary>
		EndResponse = 1,
		/// <summary>
		/// 不带有 script 标签.
		/// </summary>
		OnlyCode = 2,
		/// <summary>
		/// 做为启动脚本.
		/// </summary>
		Startup = 4
	}

}
// ../.enum/web/ScriptType.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ScriptType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 脚本的类型.
	/// </summary>
	public enum ScriptType
	{
		/// <summary>
		/// Java 脚本.
		/// </summary>
		JavaScript = 1,
		/// <summary>
		/// VB 脚本.
		/// </summary>
		VBScript = 2
	}

}
// ../.enum/StringCompareMode.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/StringCompareMode
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/StringCompareMode.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer
{

	/// <summary>
	/// 字符串的对比模式.
	/// </summary>
	public enum StringCompareMode
	{
		/// <summary>
		/// 完全相等.
		/// </summary>
		Equal = 1,
		/// <summary>
		/// 开头匹配.
		/// </summary>
		StartWith = 2,
		/// <summary>
		/// 结尾匹配.
		/// </summary>
		EndWith = 3,
		/// <summary>
		/// 包含.
		/// </summary>
		Contain = 4
	}

}
// ../.class/web/HtmlEditHelper.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/HtmlEditHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/HtmlEditHelper.cs
 * 版本: 1.2, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// Html 编辑器.
	/// </summary>
	public sealed partial class HtmlEditHelper
	{
		private readonly WebBrowser browser;

		/// <summary>
		/// 获取或设置编辑器中的 html 代码.
		/// </summary>
		public string Html
		{
			get
			{

				if ( null == this.browser.Document || null == this.browser.Document.GetElementById ( "html" ) )
					return string.Empty;

				return this.browser.Document.GetElementById ( "html" ).InnerHtml;
			}
			set
			{

				if ( null != this.browser.Document && null != value && null == this.browser.Document.GetElementById ( "html" ) )
					this.browser.Document.GetElementById ( "html" ).InnerHtml = value;

			}
		}

#if PARAM
		/// <summary>
		/// 创建一个 Html 编辑器.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="editorUrl">编辑器页面地址, 默认使用本地编辑器.</param>
		public HtmlEditHelper ( WebBrowser browser, string editorUrl = null )
#else
		/// <summary>
		/// 创建一个 Html 编辑器.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="editorUrl">编辑器页面地址.</param>
		public HtmlEditHelper ( WebBrowser browser, string editorUrl )
#endif
		{

			if ( null == browser )
				throw new ArgumentNullException ( "browser", "浏览器控件不能为空" );

			if ( string.IsNullOrEmpty ( editorUrl ) )
				editorUrl = @"html.editor.htm";

			try
			{ browser.Navigate ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory, editorUrl ) ); }
			catch { }

			this.browser = browser;
		}

		/// <summary>
		/// 设置选中内容的背景色.
		/// </summary>
		/// <param name="color">背景色.</param>
		public void BackColor ( Color color )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "BackColor", true, color );
		}

		/// <summary>
		/// 设置选中内容的前景色.
		/// </summary>
		/// <param name="color">前景色.</param>
		public void ForeColor ( Color color )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "ForeColor", true, color );
		}

		/// <summary>
		/// 切换选中内容是否粗体.
		/// </summary>
		public void Bold ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Bold", true, null );
		}

		/// <summary>
		/// 切换选中内容是否斜体.
		/// </summary>
		public void Italic ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Italic", true, null );
		}

		/// <summary>
		/// 切换选中内容是否有下划线.
		/// </summary>
		public void Underline ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Underline", true, null );
		}

		/// <summary>
		/// 撤销.
		/// </summary>
		public void Undo ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Undo", true, null );
		}

		/// <summary>
		/// 增加缩进.
		/// </summary>
		public void Indent ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Indent", true, null );
		}

		/// <summary>
		/// 减少缩进.
		/// </summary>
		public void Outdent ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Outdent", true, null );
		}

		/// <summary>
		/// 清楚样式.
		/// </summary>
		public void RemoveFormat ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "RemoveFormat", true, null );
		}

		/// <summary>
		/// 复制选中内容.
		/// </summary>
		public void Copy ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Copy", true, null );
		}

		/// <summary>
		/// 剪切选中内容.
		/// </summary>
		public void Cut ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Cut", true, null );
		}

		/// <summary>
		/// 删除选中内容.
		/// </summary>
		public void Delete ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Delete", true, null );
		}

		/// <summary>
		/// 粘贴.
		/// </summary>
		public void Paste ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Paste", true, null );
		}

		/// <summary>
		/// 居中.
		/// </summary>
		public void JustifyCenter ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "JustifyCenter", true, null );
		}

		/// <summary>
		/// 居左.
		/// </summary>
		public void JustifyLeft ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "JustifyLeft", true, null );
		}

		/// <summary>
		/// 居右.
		/// </summary>
		public void JustifyRight ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "JustifyRight", true, null );
		}

		/// <summary>
		/// 插入段落.
		/// </summary>
		public void InsertParagraph ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "InsertParagraph", true, null );
		}

		/// <summary>
		/// 插入顺序列表.
		/// </summary>
		public void InsertOrderedList ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "InsertOrderedList", true, null );
		}

		/// <summary>
		/// 插入非顺序列表.
		/// </summary>
		public void InsertUnorderedList ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "InsertUnorderedList", true, null );
		}

		/// <summary>
		/// 插入图片.
		/// </summary>
		public void InsertImage ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "InsertImage", true, null );
		}

		/// <summary>
		/// 插入超链接.
		/// </summary>
		public void CreateLink ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "CreateLink", true, null );
		}

		/// <summary>
		/// 取消超链接.
		/// </summary>
		public void Unlink ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Unlink", true, null );
		}

		/// <summary>
		/// 设置选中内容的字体.
		/// </summary>
		/// <param name="name">设置的字体名称.</param>
		public void FontName ( string name )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "FontName", true, name );
		}

		/// <summary>
		/// 设置选中内容的字体.
		/// </summary>
		/// <param name="size">设置的字体大小.</param>
		public void FontSize ( int size )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "FontSize", true, size );
		}

	}

	partial class HtmlEditHelper
	{
#if !PARAM
		/// <summary>
		/// 创建一个 Html 编辑器, 编辑页面地址为 "html.editor.htm".
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		public HtmlEditHelper ( WebBrowser browser )
			: this ( browser, null )
		{ }
#endif
	}

}

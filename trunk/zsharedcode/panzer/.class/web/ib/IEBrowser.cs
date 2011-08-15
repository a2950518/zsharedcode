/*
 * 作者: M.S.cxc
 * wiki 分析&示例:
 * http://code.google.com/p/zsharedcode/wiki/IEBrowserDoc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/IEBrowser.cs
 * 版本: 2.5.0, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web;
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

		private int lastRecordTime;
		private string clickEventTagName = "INPUT;SELECT;TEXTAREA;A";

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
		/// 设置参与记录点击的元素的 tagName 属性, 可用 ; 号分隔, 默认为 "INPUT;SELECT;TEXTAREA;A".
		/// </summary>
		public string ClickEventTagName
		{
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.clickEventTagName = value;

			}
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

		private void elementChange ( object sender, EventArgs e )
		{
			HtmlElement element = sender as HtmlElement;

			string member = string.Empty;
			string value = string.Empty;

			switch ( element.TagName )
			{
				case "INPUT":

					if ( element.GetAttribute ( "type" ).ToLower ( ) == "radio" || element.GetAttribute ( "type" ).ToLower ( ) == "checkbox" )
					{
						member = "checked";
						value = HttpUtility.HtmlEncode ( element.GetAttribute ( "checked" ) );
					}
					else
					{
						member = "value";
						value = HttpUtility.HtmlEncode ( element.GetAttribute ( "value" ) );
					}

					break;

				case "SELECT":
					member = "selectedIndex";
					value = element.GetAttribute ( "selectedIndex" );
					break;

				case "TEXTAREA":
					member = "innerText";
					value = element.InnerText;
					break;
			}

			int wait = ( int ) ( ( Environment.TickCount - this.lastRecordTime ) / 1000 );

			this.lastRecordTime = Environment.TickCount;

			this.actions.Add ( new CustomRecordAction ( "property", member, value, wait, ElementMark.Create ( element ) ) );
		}

		private void elementClick ( object sender, EventArgs e )
		{
			HtmlElement element = sender as HtmlElement;

			int wait = ( int ) ( ( Environment.TickCount - this.lastRecordTime ) / 1000 );

			this.lastRecordTime = Environment.TickCount;

			this.actions.Add ( new CustomRecordAction ( "method", "click", string.Empty, wait, ElementMark.Create ( element ) ) );
		}

		private void installRecord ( HtmlDocument document )
		{

			if ( null == document )
				return;

			this.ieBrowser.AttachEventByTagName ( "INPUT", "onchange", this.elementChange, document );
			this.ieBrowser.AttachEventByTagName ( "SELECT", "onchange", this.elementChange, document );
			this.ieBrowser.AttachEventByTagName ( "TEXTAREA", "onchange", this.elementChange, document );

			foreach ( string tagName in this.clickEventTagName.Split ( ';' ) )
				this.ieBrowser.AttachEventByTagName ( tagName.Trim ( ), "onclick", this.elementClick, document );

			foreach ( HtmlWindow window in document.Window.Frames )
				try
				{ this.installRecord ( window.Document ); }
				catch { }

		}

		private void uninstallRecord ( HtmlDocument document )
		{

			if ( null == document )
				return;

			this.ieBrowser.DetachEventByTagName ( "INPUT", "onchange", this.elementChange, document );
			this.ieBrowser.DetachEventByTagName ( "SELECT", "onchange", this.elementChange, document );
			this.ieBrowser.DetachEventByTagName ( "TEXTAREA", "onchange", this.elementChange, document );

			foreach ( string tagName in this.clickEventTagName.Split ( ';' ) )
				this.ieBrowser.DetachEventByTagName ( tagName.Trim ( ), "onclick", this.elementClick, document );

			foreach ( HtmlWindow window in document.Window.Frames )
				try
				{ this.uninstallRecord ( window.Document ); }
				catch { }

		}

		/// <summary>
		/// 使当前页面具有记录操作的功能.
		/// </summary>
		public void InstallRecord ( )
		{

			if ( !this.isRecording )
				return;

			this.installRecord ( this.ieBrowser.Document );
		}

		/// <summary>
		/// 开始执行记录操作, 将记录用户在 WebBrowser 上的相关操作.
		/// </summary>
		public void BeginRecord ( )
		{

			if ( this.isRecording || this.isReplaying || this.ieBrowser.Url == string.Empty )
				return;

			this.isRecording = true;
			this.lastRecordTime = Environment.TickCount;
			this.actions.Clear ( );
			this.AppendAction ( new NavigateRecordAction ( this.ieBrowser.Url ) );
			this.InstallRecord ( );
		}

		/// <summary>
		/// 结束执行记录操作, 将结束记录用户在 WebBrowser 上的相关操作, 需要首先调用 BeginRecord 方法.
		/// </summary>
		public void EndRecord ( )
		{

			if ( !this.isRecording )
				return;

			this.uninstallRecord ( this.ieBrowser.Document );
			this.isRecording = false;
		}

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

				this.replayActions.RemoveAt ( 0 );

				HtmlElement element = this.ieBrowser.GetElement ( customAction.Mark );

				if ( null == element )
					continue;

				switch ( customAction.CustomType )
				{
					case "property":

						switch ( customAction.Member )
						{
							case "checked":
							case "value":
							case "selectedIndex":
								element.SetAttribute ( customAction.Member, HttpUtility.HtmlDecode ( customAction.Value ) );
								break;

							case "innerText":
								element.InnerText = HttpUtility.HtmlDecode ( customAction.Value );
								break;
						}

						break;

					case "method":
						this.ieBrowser.IEFlow.Wait ( customAction.Wait );

						element.InvokeMember ( customAction.Member );
						break;
				}

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
	public sealed partial class IEBrowser : IDisposable
	{
		private static readonly string comObjectFullName = "System.__ComObject";

		/// <summary>
		/// 得到 HtmlElement 对应的路径.
		/// </summary>
		/// <param name="element">用于获取路径的 HtmlElement 对象.</param>
		/// <returns>路径.</returns>
		public static string GetFramePath ( HtmlElement element )
		{

			if ( null == element )
				return string.Empty;

			string framePath = string.Empty;

			HtmlWindow window = element.Document.Window;

			while ( window != window.Parent )
			{

				for ( int index = 0; index < window.Parent.Frames.Count; index++ )
					if ( window == window.Parent.Frames[index] )
						framePath = index.ToString ( ) + framePath;

				window = window.Parent;
			}

			return framePath;
		}

		private readonly WebBrowser browser;

		private readonly IEFlow ieFlow;
		private readonly IERecord ieRecord;

		private bool isNewWindowEnabled;

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
		/// 获取当前页面是否安装了 jQuery 脚本, 需要首先调用 InstallTrace 方法.
		/// </summary>
		public bool IsJQueryInstalled
		{
			get
			{
				this.__Set ( "__isJQueryInstalled", "(typeof(jQuery) != 'undefined')" );
				return this.__Get<bool> ( "__isJQueryInstalled" );
			}
		}

		/// <summary>
		/// 获取或设置是否允许鼠标点击的页面在新窗口中打开, 如果为 false, 则在自身打开.
		/// </summary>
		public bool IsNewWindowEnabled
		{
			get { return this.isNewWindowEnabled; }
			set { this.isNewWindowEnabled = value; }
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
		/// 设置用于在 javascript 中调用的 .NET 对象.
		/// </summary>
		public object Scripting
		{
			set { this.browser.ObjectForScripting = value; }
		}

		/// <summary>
		/// 获取当前页面的 HtmlDocument 对象.
		/// </summary>
		public HtmlDocument Document
		{
			get { return this.browser.Document; }
		}

#if PARAM
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组, 默认为空.</param>
		/// <param name="scripting">用于在 javascript 中调用的 .NET 对象.</param>
		/// <param name="isNewWindowEnabled">是否允许鼠标点击的超链接在新窗口中打开, 如果为 false, 则新窗口在当前 WebBrowser 中打开, 默认为 true.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states = null, object scripting = null, bool isNewWindowEnabled = true )
#else
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组.</param>
		/// <param name="scripting">用于在 javascript 中调用的 .NET 对象.</param>
		/// <param name="isNewWindowEnabled">是否允许鼠标点击的超链接在新窗口中打开, 如果为 false, 则新窗口在当前 WebBrowser 中打开.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states, object scripting, bool isNewWindowEnabled )
#endif
		{

			if ( null == browser )
				throw new ArgumentNullException ( "browser", "浏览器控件不能为空" );

			this.browser = browser;
			this.isNewWindowEnabled = isNewWindowEnabled;
			this.ieFlow = new IEFlow ( this, states );
			this.ieRecord = new IERecord ( this );
			this.Scripting = scripting;

			browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler ( this.browserDocumentCompleted );
			browser.Navigated += new WebBrowserNavigatedEventHandler ( this.browserNavigated );
			browser.NewWindow += new CancelEventHandler ( this.browserNewWindow );
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
					this.ieRecord.InstallRecord ( );

			}
			else if ( this.ieRecord.IsReplaying )
			{
				this.ieRecord.NavigateUrl = this.ieRecord.NavigateUrl.Replace ( e.Url.AbsoluteUri.ToLower ( ), string.Empty ).Replace ( e.Url.Host.ToLower ( ) + e.Url.AbsolutePath.ToLower ( ), string.Empty );

				if ( this.ieRecord.NavigateUrl == string.Empty )
					this.ieRecord.ReplayCustomAction ( );

			}

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

		private void browserNewWindow ( object sender, CancelEventArgs e )
		{

			if ( !this.isNewWindowEnabled && Uri.IsWellFormedUriString ( this.browser.StatusText, UriKind.Absolute ) )
			{
				e.Cancel = true;
				this.Navigate ( this.browser.StatusText );
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
		/// 安装跟踪脚本到 WebBrowser, 可以使用 __set(name, value) 和 __get(name), __getJSON(name) javascript 函数.
		/// </summary>
		public void InstallTrace ( )
		{
			this.installScript (
				"__jsTrace",
				null,
				"function __set(name, value){if(null == name){return;}window[name] = eval(value);}function __get(name){if(null == name){return null;}else{return window[name];}}" +
				"function __getJSON(name) {\n" +

				"	if (null == name) { return null; }\n" +

				"	return __jsonToString(window[name]);\n" +
				"}\n" +
				"function __getType(value) {\n" +

				"	if (typeof (value) != 'object')\n" +
				"		return typeof (value);\n" +

				"	if (value instanceof Number)\n" +
				"		return 'number';\n" +
				"	else if (value instanceof String)\n" +
				"		return 'string';\n" +
				"	else if (value instanceof Boolean)\n" +
				"		return 'boolean';\n" +
				"	else if (value instanceof Date)\n" +
				"		return 'date';\n" +
				"	else\n" +
				"		return 'undefined';\n" +

				"}\n" +
				"function __jsonToString(json, name) {\n" +

				"	if (null == json) { return ''; }\n" +

				"	var expression = '';\n" +

				"	if (json instanceof Array) {\n" +

				"		if (null == name)\n" +
				"			expression += 'create-array`;`';\n" +
				"		else\n" +
				"			expression += 'create-array`:``:`' + name + '`;`';\n" +

				"		for (var index in json)\n" +
				"			if (json[index] instanceof Object && !(json[index] instanceof Number) && !(json[index] instanceof String) && !(json[index] instanceof Date) && !(json[index] instanceof RegExp) && !(json[index] instanceof Boolean))\n" +
				"				expression += __jsonToString(json[index]);\n" +
				"			else if (json[index] instanceof Date)\n" +
				"				expression += 'add-' + __getType(json[index]) + '`:`' + (null == json[index] ? '' : json[index].getFullYear().toString() + '-' + (json[index].getMonth() + 1).toString() + '-' + json[index].getDate().toString() + ' ' + json[index].getHours().toString() + ':' + json[index].getMinutes().toString() + ':' + json[index].getSeconds().toString()) + '`;`';\n" +
				"			else\n" +
				"				expression += 'add-' + __getType(json[index]) + '`:`' + (null == json[index] ? '' : json[index].toString()) + '`;`';\n" +

				"		expression += 'add-array`;`';\n" +
				"	}\n" +
				"	else if (json instanceof Object) {\n" +

				"		if (null == name)\n" +
				"			expression += 'create-object`;`';\n" +
				"		else\n" +
				"			expression += 'create-object`:``:`' + name + '`;`';\n" +

				"		for (var key in json)\n" +
				"			if (json[key] instanceof Object && !(json[key] instanceof Number) && !(json[key] instanceof String) && !(json[key] instanceof Date) && !(json[key] instanceof RegExp) && !(json[key] instanceof Boolean))\n" +
				"				expression += __jsonToString(json[key], key.toString());\n" +
				"			else if (json[index] instanceof Date)\n" +
				"				expression += 'add-' + __getType(json[key]) + '`:`' + (null == json[key] ? '' : json[key].getFullYear().toString() + '-' + (json[key].getMonth() + 1).toString() + '-' + json[key].getDate().toString() + ' ' + json[key].getHours().toString() + ':' + json[key].getMinutes().toString() + ':' + json[key].getSeconds().toString()) + '`:`' + key.toString() + '`;`';\n" +
				"			else\n" +
				"				expression += 'add-' + __getType(json[key]) + '`:`' + (null == json[key] ? '' : json[key].toString()) + '`:`' + key.toString() + '`;`';\n" +

				"		expression += 'add-object`;`';\n" +
				"	}\n" +

				"	return expression;\n" +
				"}",
				false
				);
		}

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

			HtmlDocument document = this.GetDocument ( framePath );

			try
			{ return document.InvokeScript ( methodName, parameters ); }
			catch
			{ return null; }

		}

		/// <summary>
		/// 根据条件获取 HtmlElement 对象.
		/// </summary>
		/// <param name="mark">用于标记 HtmlElement 的对象.</param>
		/// <returns>符合条件的 HtmlElement 对象.</returns>
		public HtmlElement GetElement ( ElementMark mark )
		{

			if ( null == mark )
				return null;

			HtmlDocument document = this.GetDocument ( mark.FramePath );

			if ( null == document )
				return null;

			foreach ( HtmlElement element in document.GetElementsByTagName ( mark.TagName ) )
				if ( ( string.IsNullOrEmpty ( mark.ID ) || element.Id == mark.ID ) && ( string.IsNullOrEmpty ( mark.Name ) || element.Name == mark.Name ) && ( string.IsNullOrEmpty ( mark.Class ) || element.GetAttribute ( "class" ) == mark.Class ) && ( string.IsNullOrEmpty ( mark.Type ) || element.GetAttribute ( "type" ) == mark.Type ) && ( string.IsNullOrEmpty ( mark.Value ) || element.GetAttribute ( "value" ) == mark.Value ) && ( string.IsNullOrEmpty ( mark.Href ) || element.GetAttribute ( "href" ) == mark.Href ) )
					return element;

			return null;
		}

		/// <summary>
		/// 根据路径得到 HtmlDocument 对象.
		/// </summary>
		/// <param name="framePath">HtmlDocument 的路径, 比如: "1.main.menu".</param>
		/// <returns>HtmlDocument 对象.</returns>
		public HtmlDocument GetDocument ( string framePath )
		{

			if ( null == this.browser.Document )
				return null;

			HtmlDocument document = this.browser.Document;

			if ( string.IsNullOrEmpty ( framePath ) )
				return document;

			foreach ( string path in framePath.Split ( '.' ) )
				if ( path != string.Empty )
				{
					int index;

					if ( int.TryParse ( path, out index ) )
						document = document.Window.Frames[index].Document;
					else
						document = document.Window.Frames[path].Document;

				}

			return document;
		}

#if PARAM
		/// <summary>
		/// 调用 __getJSON 函数, 获取页面中的 JSON 对象, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="framePath">__getJSON 函数所在框架的路径, 默认不使用路径.</param>
		/// <returns>JSON 对象.</returns>
		public JSON __GetJSON ( string name, string framePath = null )
#else
		/// <summary>
		/// 调用 __getJSON 函数, 获取页面中的 JSON 对象, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="framePath">__getJSON 函数所在框架的路径.</param>
		/// <returns>JSON 对象.</returns>
		public JSON __GetJSON ( string name, string framePath )
#endif
		{

			if ( string.IsNullOrEmpty ( name ) )
				return null;

			object value = this.InvokeScript ( "__getJSON", new object[] { name }, framePath );

			if ( null == value )
				return null;

			try
			{ return JSON.Create ( value.ToString ( ) ); }
			catch
			{ return null; }

		}

#if PARAM
		/// <summary>
		/// 调用 eval 函数, 设置 JSON 对象到页面, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="json">JSON 对象.</param>
		/// <param name="framePath">eval 函数所在框架的路径, 默认不使用路径.</param>
		public void __SetJSON ( string name, JSON json, string framePath = null )
#else
		/// <summary>
		/// 调用 __set 函数, 设置 JSON 对象到页面, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="json">JSON 对象.</param>
		/// <param name="framePath">eval 函数所在框架的路径.</param>
		public void __SetJSON ( string name, JSON json, string framePath )
#endif
		{

			if ( string.IsNullOrEmpty ( name ) || null == json )
				return;

			this.InvokeScript ( "eval", new object[] { string.Format ( "window['{0}'] = {1}", name, json.ToString ( ) ) }, framePath );
		}

#if PARAM
		/// <summary>
		/// 调用 __get 函数, 获得一个值, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="framePath">__get 函数所在框架的路径, 默认不使用路径.</param>
		/// <returns>值.</returns>
		public T __Get<T> ( string name, string framePath = null )
#else
		/// <summary>
		/// 调用 __get 函数, 获得一个值, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="framePath">__get 函数所在框架的路径.</param>
		/// <returns>值.</returns>
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

		/// <summary>
		/// 根据提供的 JQuery 对象选择元素并添加事件, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <param name="selector">用于选择元素的 JQuery 对象.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		public void AttachEventByJQuery ( JQuery selector, string eventName, EventHandler eventHandler )
		{
			// HACK: AttachEventByJQuery 与 DetachEventByJQuery 类似, 可以考虑合并.

			if ( null == selector )
				return;

			this.ExecuteJQuery ( selector, "__jqAttachEventByJQueryElements" );

			int count = this.ExecuteJQuery<int> ( JQuery.Create ( "__jqAttachEventByJQueryElements" ).Length ( ) );

			for ( int index = 0; index < count; index++ )
			{
				this.ExecuteJQuery ( JQuery.Create ( "__jqAttachEventByJQueryElements" ).Eq ( index.ToString ( ) ), "__jqAttachEventByJQueryElement" );

				string id = this.ExecuteJQuery<string> ( JQuery.Create ( "__jqAttachEventByJQueryElement" ).Attr ( "'id'" ) );

				if ( string.IsNullOrEmpty ( id ) )
				{
					id = ScriptHelper.MakeKey ( );

					this.ExecuteJQuery ( JQuery.Create ( "__jqAttachEventByJQueryElement" ).Attr ( "'id'", string.Format ( "'{0}'", id ) ) );
				}

				this.AttachEventByID ( id, eventName, eventHandler );
			}

		}

#if PARAM
		/// <summary>
		/// 为页面中指定 id 的元素添加事件.
		/// </summary>
		/// <param name="id">添加事件的元素的 id.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		/// <param name="document">元素所在的 HtmlDocument 对象, 默认为顶层的 HtmlDocument.</param>
		public void AttachEventByID ( string id, string eventName, EventHandler eventHandler, HtmlDocument document = null )
#else
		/// <summary>
		/// 为页面中指定 id 的元素添加事件.
		/// </summary>
		/// <param name="id">添加事件的元素的 id.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		/// <param name="document">元素所在的 HtmlDocument 对象.</param>
		public void AttachEventByID ( string id, string eventName, EventHandler eventHandler, HtmlDocument document )
#endif
		{

			if ( null == document )
				document = this.browser.Document;

			if ( null == document || string.IsNullOrEmpty ( id ) )
				return;

			this.AttachEvent ( document.GetElementById ( id ), eventName, eventHandler );
		}

#if PARAM
		/// <summary>
		/// 为页面中指定 tagName 的元素添加事件.
		/// </summary>
		/// <param name="tagName">添加事件的元素的 tagName.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		/// <param name="document">元素所在的 HtmlDocument 对象, 默认为顶层的 HtmlDocument.</param>
		public void AttachEventByTagName ( string tagName, string eventName, EventHandler eventHandler, HtmlDocument document = null )
#else
		/// <summary>
		/// 为页面中指定 tagName 的元素添加事件.
		/// </summary>
		/// <param name="tagName">添加事件的元素的 tagName.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		/// <param name="document">元素所在的 HtmlDocument 对象.</param>
		public void AttachEventByTagName ( string tagName, string eventName, EventHandler eventHandler, HtmlDocument document )
#endif
		{

			if ( null == document )
				document = this.browser.Document;

			if ( null == document || string.IsNullOrEmpty ( tagName ) )
				return;

			foreach ( HtmlElement element in document.GetElementsByTagName ( tagName ) )
				this.AttachEvent ( element, eventName, eventHandler );

		}

		/// <summary>
		/// 为 HtmlElement 添加事件.
		/// </summary>
		/// <param name="element">添加事件的 HtmlElement 对象.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		public void AttachEvent ( HtmlElement element, string eventName, EventHandler eventHandler )
		{

			if ( null == element || string.IsNullOrEmpty ( eventName ) || null == eventHandler )
				return;

			element.AttachEventHandler ( eventName, delegate { eventHandler ( element, EventArgs.Empty ); } );
		}

		/// <summary>
		/// 根据提供的 JQuery 对象选择元素并删除事件, 需要首先调用 InstallJQuery 方法.
		/// </summary>
		/// <param name="selector">用于选择元素的 JQuery 对象.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		public void DetachEventByJQuery ( JQuery selector, string eventName, EventHandler eventHandler )
		{
			// HACK: AttachEventByJQuery 与 DetachEventByJQuery 类似, 可以考虑合并.

			if ( null == selector )
				return;

			this.ExecuteJQuery ( selector, "__jqDetachEventByJQueryElements" );

			int count = this.ExecuteJQuery<int> ( JQuery.Create ( "__jqDetachEventByJQueryElements" ).Length ( ) );

			for ( int index = 0; index < count; index++ )
			{
				this.ExecuteJQuery ( JQuery.Create ( "__jqDetachEventByJQueryElements" ).Eq ( index.ToString ( ) ), "__jqDetachEventByJQueryElement" );

				string id = this.ExecuteJQuery<string> ( JQuery.Create ( "__jqDetachEventByJQueryElement" ).Attr ( "'id'" ) );

				if ( string.IsNullOrEmpty ( id ) )
				{
					id = ScriptHelper.MakeKey ( );

					this.ExecuteJQuery ( JQuery.Create ( "__jqDetachEventByJQueryElement" ).Attr ( "'id'", string.Format ( "'{0}'", id ) ) );
				}

				this.DetachEventByID ( id, eventName, eventHandler );
			}

		}

#if PARAM
		/// <summary>
		/// 为页面中指定 id 的元素删除事件.
		/// </summary>
		/// <param name="id">删除事件的元素的 id.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		/// <param name="document">元素所在的 HtmlDocument 对象, 默认为顶层的 HtmlDocument.</param>
		public void DetachEventByID ( string id, string eventName, EventHandler eventHandler, HtmlDocument document = null )
#else
		/// <summary>
		/// 为页面中指定 id 的元素删除事件.
		/// </summary>
		/// <param name="id">删除事件的元素的 id.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		/// <param name="document">元素所在的 HtmlDocument 对象.</param>
		public void DetachEventByID ( string id, string eventName, EventHandler eventHandler, HtmlDocument document )
#endif
		{

			if ( null == document )
				document = this.browser.Document;

			if ( null == document || string.IsNullOrEmpty ( id ) )
				return;

			this.DetachEvent ( document.GetElementById ( id ), eventName, eventHandler );
		}

#if PARAM
		/// <summary>
		/// 为页面中指定 tagName 的元素删除事件.
		/// </summary>
		/// <param name="tagName">删除事件的元素的 tagName.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		/// <param name="document">元素所在的 HtmlDocument 对象, 默认为顶层的 HtmlDocument.</param>
		public void DetachEventByTagName ( string tagName, string eventName, EventHandler eventHandler, HtmlDocument document = null )
#else
		/// <summary>
		/// 为页面中指定 tagName 的元素删除事件.
		/// </summary>
		/// <param name="tagName">删除事件的元素的 tagName.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		/// <param name="document">元素所在的 HtmlDocument 对象.</param>
		public void DetachEventByTagName ( string tagName, string eventName, EventHandler eventHandler, HtmlDocument document )
#endif
		{

			if ( null == document )
				document = this.browser.Document;

			if ( null == document || string.IsNullOrEmpty ( tagName ) )
				return;

			foreach ( HtmlElement element in document.GetElementsByTagName ( tagName ) )
				this.DetachEvent ( element, eventName, eventHandler );

		}

		/// <summary>
		/// 为 HtmlElement 删除事件.
		/// </summary>
		/// <param name="element">删除事件的 HtmlElement 对象.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		public void DetachEvent ( HtmlElement element, string eventName, EventHandler eventHandler )
		{

			if ( null == element || string.IsNullOrEmpty ( eventName ) || null == eventHandler )
				return;

			element.DetachEventHandler ( eventName, delegate { eventHandler ( element, EventArgs.Empty ); } );
		}

		/// <summary>
		/// 释放对为 WebBrowser 添加的事件.
		/// </summary>
		public void Dispose ( )
		{
			browser.DocumentCompleted -= new WebBrowserDocumentCompletedEventHandler ( this.browserDocumentCompleted );
			browser.Navigated -= new WebBrowserNavigatedEventHandler ( this.browserNavigated );
			browser.NewWindow -= new CancelEventHandler ( this.browserNewWindow );
		}

	}

	partial class IEBrowser
	{
#if !PARAM

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
			: this ( browser, null, null, true )
		{ }
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="isNewWindowEnabled">是否允许鼠标点击的超链接在新窗口中打开, 如果为 false, 则新窗口在当前 WebBrowser 中打开.</param>
		public IEBrowser ( WebBrowser browser, bool isNewWindowEnabled )
			: this ( browser, null, null, isNewWindowEnabled )
		{ }
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="scripting">用于在 javascript 中调用的 .NET 对象.</param>
		public IEBrowser ( WebBrowser browser, object scripting )
			: this ( browser, null, scripting, true )
		{ }
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="scripting">用于在 javascript 中调用的 .NET 对象.</param>
		/// <param name="isNewWindowEnabled">是否允许鼠标点击的超链接在新窗口中打开, 如果为 false, 则新窗口在当前 WebBrowser 中打开.</param>
		public IEBrowser ( WebBrowser browser, object scripting, bool isNewWindowEnabled )
			: this ( browser, null, scripting, isNewWindowEnabled )
		{ }
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states )
			: this ( browser, states, null, true )
		{ }
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组.</param>
		/// <param name="isNewWindowEnabled">是否允许鼠标点击的超链接在新窗口中打开, 如果为 false, 则新窗口在当前 WebBrowser 中打开.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states, bool isNewWindowEnabled )
			: this ( browser, states, null, isNewWindowEnabled )
		{ }
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组.</param>
		/// <param name="scripting">用于在 javascript 中调用的 .NET 对象.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states, object scripting )
			: this ( browser, states, scripting, true )
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
		/// 调用 eval 函数, 设置 JSON 对象到页面, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <param name="json">JSON 对象.</param>
		public void __SetJSON ( string name, JSON json )
		{ this.__SetJSON ( name, json, null ); }

		/// <summary>
		/// 调用 __getJSON 函数, 获取页面中的 JSON 对象, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="name">值的名称.</param>
		/// <returns>JSON 对象.</returns>
		public JSON __GetJSON ( string name )
		{ return this.__GetJSON ( name, null ); }

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
		/// <returns>值.</returns>
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

		/// <summary>
		/// 为页面中指定 id 的元素添加事件.
		/// </summary>
		/// <param name="id">添加事件的元素的 id.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		public void AttachEventByID ( string id, string eventName, EventHandler eventHandler )
		{ this.AttachEventByID ( id, eventName, eventHandler, null ); }

		/// <summary>
		/// 为页面中指定 tagName 的元素添加事件.
		/// </summary>
		/// <param name="tagName">添加事件的元素的 tagName.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		public void AttachEventByTagName ( string tagName, string eventName, EventHandler eventHandler )
		{ this.AttachEventByTagName ( tagName, eventName, eventHandler, null ); }

		/// <summary>
		/// 为页面中指定 id 的元素删除事件.
		/// </summary>
		/// <param name="id">删除事件的元素的 id.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		public void DetachEventByID ( string id, string eventName, EventHandler eventHandler )
		{ this.DetachEventByID ( id, eventName, eventHandler, null ); }

		/// <summary>
		/// 为页面中指定 tagName 的元素删除事件.
		/// </summary>
		/// <param name="tagName">删除事件的元素的 tagName.</param>
		/// <param name="eventName">事件的名称.</param>
		/// <param name="eventHandler">事件的句柄.</param>
		public void DetachEventByTagName ( string tagName, string eventName, EventHandler eventHandler )
		{ this.DetachEventByTagName ( tagName, eventName, eventHandler, null ); }
#endif
	}
	#endregion

}

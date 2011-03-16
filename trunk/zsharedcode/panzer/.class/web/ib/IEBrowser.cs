/*
 * wiki 成员参考:
 * http://code.google.com/p/zsharedcode/wiki/IEBrowser
 * http://code.google.com/p/zsharedcode/wiki/IEFlow
 * wiki 分析&示例:
 * http://code.google.com/p/zsharedcode/wiki/IEBrowserDoc
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/IEBrowser.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageAction.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageState.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageCondition.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/flow/Flow.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
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
using System.Windows.Forms;

using zoyobar.shared.panzer.flow;

namespace zoyobar.shared.panzer.web.ib
{

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

		protected override bool checkState ( WebPageCondition condition )
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

		private string url;
		private readonly WebBrowser browser;

		private readonly IEFlow ieFlow;

		/// <summary>
		/// 获取页面流程类.
		/// </summary>
		public IEFlow IEFlow
		{
			get { return this.ieFlow; }
		}

#if PARAM
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组, 默认为空.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states = null )
#else
		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="states">页面状态数组.</param>
		public IEBrowser ( WebBrowser browser, WebPageState[] states )
#endif
		{

			if ( null == browser )
				throw new ArgumentNullException ( "browser", "浏览器控件不能为空" );

			browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler ( this.browserDocumentCompleted );

			this.browser = browser;
			this.ieFlow = new IEFlow ( this, states );
		}

		private void browserDocumentCompleted ( object sender, WebBrowserDocumentCompletedEventArgs e )
		{
#if TRACE
			Console.WriteLine ( string.Format ( "\tcompleted url: {0}", e.Url.AbsoluteUri.ToLower ( ) ) );
#endif

			if ( this.ieFlow.CompletedUrls.Count < 100 )
				this.ieFlow.CompletedUrls.Add ( e.Url.AbsoluteUri.ToLower ( ) );

		}

		private void installScript ( string id, Uri scriptUrl, string code )
		{

			if ( null == this.browser.Document || ( null == scriptUrl && string.IsNullOrEmpty ( code ) ) )
				return;

			if ( string.IsNullOrEmpty ( id ) )
				id = ScriptHelper.MakeKey ( );

			HtmlElement scriptElement = null;

			foreach ( HtmlElement element in this.browser.Document.GetElementsByTagName ( "script" ) )
				if ( element.Id == id )
				{
					scriptElement = element;
					break;
				}

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
		public void InstallScript ( Uri scriptUrl, string id = null )
#else
		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并指定脚本的地址.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		public void InstallScript ( Uri scriptUrl, string id )
#endif
		{ this.installScript ( id, scriptUrl, null ); }

#if PARAM
		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并添加定义的 javascript  代码.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <param name="id">脚本 script 标签的 id 属性, 默认自动生成.</param>
		public void InstallScript ( string code, string id = null )
#else
		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并添加定义的 javascript  代码.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		/// <param name="id">脚本 script 标签的 id 属性.</param>
		public void InstallScript ( string code, string id )
#endif
		{ this.installScript ( id, null, code ); }

		/// <summary>
		/// 安装跟踪脚本到 WebBrowser, 可以使用 __set(name, value) 和 __get(name) 两个 javascript 函数.
		/// </summary>
		public void InstallTrace ( )
		{ this.installScript ( "jsTrace", null, "function __set(name, value){if(null == name){return;}window[name] = eval(value);}function __get(name){if(null == name){return null;}else{return window[name];}}" ); }

#if PARAM
		/// <summary>
		/// 安装指定地址的 jQuery 脚本到 WebBrowser 控件.
		/// </summary>
		/// <param name="jQueryUrl">jQuery 脚本地址, 默认安装网络地址.</param>
		public void InstallJQuery ( Uri jQueryUrl = null )
#else
		/// <summary>
		/// 安装指定地址的 jQuery 脚本到 WebBrowser 控件.
		/// </summary>
		/// <param name="jQueryUrl">jQuery 脚本地址.</param>
		public void InstallJQuery ( Uri jQueryUrl )
#endif
		{

			if ( null == jQueryUrl )
				jQueryUrl = new Uri ( JQuery.Script_1_4_1_Url );

			this.installScript ( "jsJQuery", jQueryUrl, null );
		}

		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并添加执行的 javascript  代码.
		/// </summary>
		/// <param name="code">需要添加的 javascript 代码.</param>
		public void ExecuteScript ( string code )
		{ this.installScript ( "executeScript", null, code ); }

#if PARAM
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架, 默认不指定路径.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object ExecuteJQuery ( JQuery jQuery, string resultName = null, string framePath = null )
		{ return this.ExecuteJQuery<object> ( jQuery, resultName, framePath ); }
#else
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
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
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称, 默认不返回值到变量.</param>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架, 默认不指定路径.</param>
		/// <returns>调用函数后的返回值.</returns>
		public T ExecuteJQuery<T> ( JQuery jQuery, string resultName = null, string framePath = null )
#else
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>调用函数后的返回值.</returns>
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

			this.url = url;

			try
			{ this.browser.Navigate ( url ); }
			catch { }

		}

		/// <summary>
		/// 刷新使用 Navigate 导航的地址.
		/// </summary>
		public void Refresh ( )
		{ this.Navigate ( this.url ); }

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
		/// 安装网络版本的 jQuery 脚本到 WebBrowser 控件.
		/// </summary>
		public void InstallJQuery ( )
		{ this.InstallJQuery ( null ); }

		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并指定脚本的地址.
		/// </summary>
		/// <param name="scriptUrl">脚本地址, 如: "http://www.google.com/xxx.js".</param>
		public void InstallScript ( Uri scriptUrl )
		{ this.installScript ( null, scriptUrl, null ); }

		/// <summary>
		/// 在 WebBrowser 中增加 script 标签, 并添加定义的 javascript  代码.
		/// </summary>
		/// <param name="code">javascript 代码.</param>
		public void InstallScript ( string code )
		{ this.installScript ( null, null, code ); }

		/// <summary>
		/// 创建一个 IEBrowser.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		public IEBrowser ( WebBrowser browser )
			: this ( browser, null )
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
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <returns>调用函数后的返回值.</returns>
		public T ExecuteJQuery<T> ( JQuery jQuery )
		{ return this.ExecuteJQuery<T> ( null, jQuery, null ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <returns>调用函数后的返回值.</returns>
		public T ExecuteJQuery<T> ( string framePath, JQuery jQuery )
		{ return this.ExecuteJQuery<T> ( framePath, jQuery, null ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <typeparam name="T">jQuery 执行结果的类型.</typeparam>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>调用函数后的返回值.</returns>
		public T ExecuteJQuery<T> ( JQuery jQuery, string resultName )
		{ return this.ExecuteJQuery<T> ( null, jQuery, resultName ); }

		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object ExecuteJQuery ( JQuery jQuery )
		{ return this.ExecuteJQuery<object> ( null, jQuery, null ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object ExecuteJQuery ( string framePath, JQuery jQuery )
		{ return this.ExecuteJQuery<object> ( framePath, jQuery, null ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object ExecuteJQuery ( JQuery jQuery, string resultName )
		{ return this.ExecuteJQuery<object> ( null, jQuery, resultName ); }
		/// <summary>
		/// 执行 JQuery 对象中包含的 jQuery 代码, 需要首先调用 InstallTrace 方法.
		/// </summary>
		/// <param name="framePath">执行 jQuery 的框架路径, 比如: "main.1.menu", 表示名称为 main 的框架中的第 2 个框架中的 menu 框架.</param>
		/// <param name="jQuery">包含 jQuery 代码的 JQuery 对象.</param>
		/// <param name="resultName">保存 jQuery 执行结果的 javascript 变量名称.</param>
		/// <returns>调用函数后的返回值.</returns>
		public object ExecuteJQuery ( string framePath, JQuery jQuery, string resultName )
		{ return this.ExecuteJQuery<object> ( framePath, jQuery, resultName ); }
#endif
	}
	#endregion

}

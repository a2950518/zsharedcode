/* allinone合并了多个文件,下载使用多个allinone代码,可能会遇到重复的类型定义,http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/IEBrowser.with.HtmlEditHelper.all.cs */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using zoyobar.shared.panzer.flow;
using System.Web.UI;
using NControl = System.Web.UI.Control;
using System.Drawing;
using System.Text;
using System.IO;
// ../.class/web/ib/IEBrowser.cs
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
		public FlowState (string name, A[] startActions, A[] completedActions, NextStateSetting<A, C> completedStateSetting, C[] conditions)
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
	public abstract class Flow<A, C>
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

		private Timer checkStateTimer = new Timer ( );
		private Timer checkTimeoutTimer = new Timer ( );
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

		/// <summary>
		/// 等待一段时间.
		/// </summary>
		/// <param name="second">等待的秒数.</param>
		public void Wait ( int second )
		{

			if ( second <= 0 )
				return;

			DateTime time = DateTime.Now;
			int oldRemainSecond = -1;

			while ( true )
			{
				int remainSecond = ( time.AddSeconds ( second ) - DateTime.Now ).Seconds;

				if ( oldRemainSecond == -1 || oldRemainSecond != remainSecond )
				{
					oldRemainSecond = remainSecond;

					if ( null != this.RemainWaitTimeChanged )
						this.RemainWaitTimeChanged ( remainSecond );

				}

				Application.DoEvents ( );

				if ( remainSecond <= 0 )
					break;

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

		protected abstract bool checkState ( C condition );

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

					this.currentState.Conditions[condition] = this.checkState ( condition );

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
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/flow/Flow.cs
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
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/flow/Flow.cs
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
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/flow/Flow.cs
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
		/// <param name="startActions">地址跳转行为.</param>
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
		/// <param name="startAction">地址跳转行为.</param>
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
		/// <param name="startActions">地址跳转行为.</param>
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
		/// <param name="startActions">地址跳转行为.</param>
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
		/// <param name="startActions">地址跳转行为.</param>
		public WebPageState ( string name, WebPageAction[] startActions )
			: this ( name, startActions, null, null, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
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
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageCondition condition, int timeout )
			: this ( name, new WebPageAction[] { startAction }, null, null, null, null, new WebPageCondition[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageNextStateSetting completedStateSetting, WebPageCondition condition )
			: this ( name, startActions, null, completedStateSetting, null, null, new WebPageCondition[] { condition }, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
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
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
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
		/// <param name="startAction">地址跳转行为.</param>
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
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting, WebPageCondition condition )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, null, new WebPageCondition[] { condition }, 0 )
		{ }

		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageNextStateSetting completedStateSetting )
			: this ( name, startActions, null, completedStateSetting, null, null, null, 0 )
		{ }

		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
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
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// JQuery 用于编写构造 jQuery 脚本, 包含了 jQuery 中的方法等. (尚未包含 Effects, Utilities 的部分方法)
	/// </summary>
	public class JQuery
		: ScriptHelper
	{

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
		/// <param name="expressionI">可以是一个选择器, 比如: "'strong'", 或者选择器的数组, 比如: "['body', 'ul']". (如果使用数组需要 1.4 版本以上)</param>
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
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
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
		/// <param name="expression">用于筛选子元素的选择器, 比如: "'strong'".</param>
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
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetScript ( string expressionI, string expressionII)
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
		/// <param name="expression">选择器, 比如: "'.box'".</param>
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
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
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
		/// <param name="expression">返回调用函数的表达式, 比如: "function(i, o){ return 'my_' + i.toString(); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Map ( string expression )
		{ return this.Execute ( "map", expression ); }

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
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
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
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
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

#if V4
			if ( option.HasFlag ( ScriptBuildOption.OnlyCode ) )
#else
			if ( ( option & ScriptBuildOption.OnlyCode ) == ScriptBuildOption.OnlyCode )
#endif
				script = this.code;
			else
				script = string.Format ( "<script language='{0}' type='{1}'>\n{2}\n</script>", this.scriptType.ToString ( ).ToLower ( ), type, this.code );

			key = MakeKey ( key );

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

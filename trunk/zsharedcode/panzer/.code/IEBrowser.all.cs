/* allinone合并了多个文件,下载使用多个allinone代码,可能会遇到重复的类型定义,http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/IEBrowser.cs */
// HACK: 如果代码不能编译, 请尝试设置为 V4, V3_5, V3, V2 以表示不同的 .NET 版本
#define V2
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using zoyobar.shared.panzer.flow;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NControl = System.Web.UI.Control;
// ../.class/web/ib/IEBrowser.cs
/*
 * 参考文档: http://blog.sina.com.cn/s/blog_604c436d0100o5ix.html (目前已经停止更新同步)
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://blog.sina.com.cn/s/blog_604c436d0100o04s.html
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/IEBrowser.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageAction.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageState.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageCondition.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/StringCompareMode.cs
 * 合并下载:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/IEBrowser.all.cs
 * 打包下载:
 * http://zsharedcode.googlecode.com/files/IEBrowser.zip (目前已经停止更新同步)
 * 版本: 2.1, .net 4.0, 其它版本可能有所不同
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
		/// 刷新当前地址.
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
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/flow/Flow.cs
 * 版本: .net 4.0, 其它版本可能有所不同
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
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageAction.cs
 * 版本: .net 4.0, 其它版本可能有所不同
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
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageCondition.cs
 * 版本: .net 4.0, 其它版本可能有所不同
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
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageCondition.cs
 * 版本: 1.2, .net 4.0, 其它版本可能有所不同
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
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// JQuery 用于编写构造 jQuery 脚本, 包含了 jQuery 中的方法等.
	/// </summary>
	public sealed class JQuery
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
		public static JQuery Create ()
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
		public JQuery ()
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

		#endregion

		#region " 基本 "

		/// <summary>
		/// 创建当前 JQuery 的副本, 拥有相同的 Code 属性.
		/// </summary>
		/// <returns>JQuery 的副本.</returns>
		public JQuery Copy ()
		{ return new JQuery(this); }

		/// <summary>
		/// 添加语句的结尾符号.
		/// </summary>
		/// <returns>添加结尾符号后的 JQuery.</returns>
		public JQuery EndLine ()
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
		/// 尚未编辑.
		/// </summary>
		/// <param name="expressionI">尚未编辑.</param>
		/// <param name="expressionII">尚未编辑.</param>
		/// <returns>尚未编辑.</returns>
		public JQuery Add ( string expressionI, string expressionII )
		{ return this.Execute ( "add", expressionI, expressionII ); }

		/// <summary>
		/// 添加执行添加样式的 addClass 方法的代码.
		/// </summary>
		/// <param name="expression">可以是多个样式的名称, 比如: "'box red'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery AddClass ( string expression )
		{ return this.Execute ( "addClass", expression ); }

		/// <summary>
		/// 添加执行获取设置属性的 attr 方法的代码.
		/// </summary>
		/// <param name="expressionI">可以是属性名称, 比如: "'title'", 也可以是属性集合, 比如: "{type: 'text', title: 'test'}".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Attr ( string expressionI )
		{ return this.Attr ( expressionI, null ); }
		/// <summary>
		/// 添加执行获取设置属性的 attr 方法的代码.
		/// </summary>
		/// <param name="expressionI">可以是属性名称, 比如: "'title'".</param>
		/// <param name="expressionII">可以是属性值, 比如: "'just test'", 或者返回属性值的函数, 比如: "function(i, a){ return 'my_' + i.toString(); }".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Attr ( string expressionI, string expressionII )
		{ return this.Execute ( "attr", expressionI, expressionII ); }

		#endregion

		#region " 方法 C "

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Children ( )
		{ return this.Children ( null ); }
		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <param name="expression">尚未编辑.</param>
		/// <returns>尚未编辑.</returns>
		public JQuery Children ( string expression )
		{ return this.Execute ( "children", expression ); }

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Contents ( )
		{ return this.Execute ( "contents" ); }

		#endregion

		#region " 方法 E "

		/// <summary>
		/// 添加执行按照索引选择元素的 eq 方法的代码.
		/// </summary>
		/// <param name="expression">元素的索引值, 比如: "0", 如果是 "-1", 则表示最后一个元素.</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Eq ( string expression )
		{ return this.Execute ( "eq", expression ); }
		
		#endregion

		#region " 方法 F "

		/// <summary>
		/// 添加执行通过选择器, 测试函数等选择元素的 filter 方法的代码.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')", 或者是另一个 jQuery 对象, 比如: "$('#li64')".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Filter ( string expression )
		{ return this.Execute ( "filter", expression ); }

		public JQuery Find ( string expression )
		{ return this.Execute ( "find", expression ); }

		/// <summary>
		/// 添加执行选择第一个元素的 first 方法的代码.
		/// </summary>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery First ()
		{ return this.Execute ( "first" ); }

		#endregion

		#region " 方法 H "

		/// <summary>
		/// 添加执行通过判断子元素是否符合选择器, DOM 元素从而选择元素的 has 方法的代码.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 或者是 DOM 元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Has ( string expression )
		{ return this.Execute ( "has", expression ); }

		/// <summary>
		/// 添加执行判断样式是否存在的 hasClass 方法的代码.
		/// </summary>
		/// <param name="expression">样式名称, 比如: "'box'", 将判断样式是否存在.</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery HasClass ( string expression )
		{ return this.Execute ( "hasClass", expression ); }

		/// <summary>
		/// 添加执行获取 innerHTML 的 html 方法的代码.
		/// </summary>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Html ()
		{ return this.Html ( null ); }
		/// <summary>
		/// 添加执行设置 innerHTML 的 html 方法的代码.
		/// </summary>
		/// <param name="expression">可以是 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 或者返回 html 代码的函数, 比如: "function(i, h){ return '&lt;stong&gt;&lt;/stong&gt;'; }".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Html ( string expression )
		{ return this.Execute ( "html", expression ); }

		#endregion

		#region " 方法 I "

		/// <summary>
		/// 添加执行判断元素是否符合选择器的 is 方法的代码.
		/// </summary>
		/// <param name="expression">选择器, 比如: "'.box'".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Is ( string expression )
		{ return this.Execute ( "is", expression ); }

		#endregion

		#region " 方法 L "

		/// <summary>
		/// 添加执行选择最后一个元素的 last 方法的代码.
		/// </summary>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Last ()
		{ return this.Execute ( "last" ); }

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Length ()
		{
			this.AppendCode ( ".length" );
			return this;
		}

		#endregion

		#region " 方法 M "

		/// <summary>
		/// 添加执行对元素使用函数的 map 方法的代码.
		/// </summary>
		/// <param name="expression">对元素调用的函数, 比如: "function(i, o){ return 'my_' + i.toString(); }".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Map ( string expression )
		{ return this.Execute ( "map", expression ); }

		#endregion

		#region " 方法 N "

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Next ( )
		{ return this.Execute ( "next" ); }

		/// <summary>
		/// 添加执行选择不符合条件的元素的 not 方法的代码.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'li'", 也可以是 DOM 元素, 比如: "document.getElementById('li51')", 或者是测试函数, 比如: "function(i){ return i == 3; }".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Not ( string expression )
		{ return this.Execute ( "not", expression ); }

		#endregion

		#region " 方法 R "

		/// <summary>
		/// 添加执行删除属性的 removeAttr 方法的代码.
		/// </summary>
		/// <param name="expression">属性的名称, 比如: "'title'".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery RemoveAttr ( string expression )
		{ return this.Execute ( "removeAttr", expression ); }

		/// <summary>
		/// 添加执行删除样式的 removeClass 方法的代码.
		/// </summary>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery RemoveClass ()
		{ return this.RemoveClass ( null ); }
		/// <summary>
		/// 添加执行删除样式的 removeClass 方法的代码.
		/// </summary>
		/// <param name="expression">样式的名称, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }."</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery RemoveClass ( string expression )
		{ return this.Execute ( "removeClass", expression ); }

		#endregion

		#region " 方法 S "

		/// <summary>
		/// 添加执行选择某个位置开始到结束范围的元素的 slice 方法的代码, 0 是第 1 个元素, -1 是最后一个元素.
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Slice ( string expressionI )
		{ return this.Slice ( expressionI, null ); }
		/// <summary>
		/// 添加执行选择某个范围的元素的 slice 方法的代码, 0 是第 1 个元素, -1 是最后一个元素.
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <param name="expressionII">结束索引, 比如: "2", 结束位置的元素不会被选择.</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Slice ( string expressionI, string expressionII )
		{ return this.Execute ( "slice", expressionI, expressionII ); }

		#endregion

		#region " 方法 T "

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Text ()
		{ return this.Text ( null ); }
		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <param name="expression">尚未编辑.</param>
		/// <returns>尚未编辑.</returns>
		public JQuery Text ( string expression )
		{ return this.Execute ( "text", expression ); }


		/// <summary>
		/// 添加执行切换样式的 toggleClass 方法的代码.
		/// </summary>
		/// <param name="expressionI">样式的名称, 比如: "'box'".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery ToggleClass ( string expressionI )
		{ return this.ToggleClass ( expressionI, null ); }
		/// <summary>
		/// 添加执行切换样式的 toggleClass 方法的代码.
		/// </summary>
		/// <param name="expressionI">样式的名称, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }."</param>
		/// <param name="expressionII">一个布尔值, 表示添加还是删除样式.</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery ToggleClass ( string expressionI, string expressionII )
		{ return this.Execute ( "toggleClass", expressionI, expressionII ); }

		public JQuery Trigger ( string expressionI )
		{ return this.Trigger ( expressionI, null ); }
		public JQuery Trigger ( string expressionI, string expressionII )
		{ return this.Execute ( "trigger", expressionI, expressionII ); }

		#endregion

		#region " 方法 V "

		/// <summary>
		/// 添加获取元素值的 val 方法的代码.
		/// </summary>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Val ()
		{ return this.Val ( null ); }
		/// <summary>
		/// 添加设置元素值的 val 方法的代码.
		/// </summary>
		/// <param name="expressionI">元素值的表达式, 比如: "'my name'", 或者返回元素值的函数, 比如: "function(i, v){ return 'my_' + i.toString(); }."</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Val ( string expressionI )
		{ return this.Execute ( "val", expressionI ); }
		
		#endregion

	}

}
// ../.class/web/ScriptHelper.cs
/*
 * 参考文档: http://blog.sina.com.cn/s/blog_604c436d0100o07u.html (目前已经停止更新同步)
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://blog.sina.com.cn/s/blog_604c436d0100o04s.html
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
 * 打包下载:
 * http://zsharedcode.googlecode.com/files/ScriptHelper.zip (目前已经停止更新同步)
 * http://zsharedcode.googlecode.com/files/ScriptHelper.with.test.zip (包含测试) (目前已经停止更新同步)
 * 版本: 1.1, .net 4.0, 其它版本可能有所不同
* */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.



// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 此类可以完成客户端脚本的编写, 修改标签属性, 包含脚本文件, 设置时钟等操作.
	/// </summary>
	public partial class ScriptHelper
	{

		private static readonly Random random = new Random ();

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
				return page.ClientScript.IsStartupScriptRegistered ( page.GetType (), MakeKey ( key ) );
			else
				return page.ClientScript.IsClientScriptBlockRegistered ( page.GetType (), MakeKey ( key ) );

		}

		protected string code = string.Empty;

		protected readonly ScriptType scriptType;

		/// <summary>
		/// 获取脚本代码.
		/// </summary>
		public string Code
		{
			get { return this.code; }
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
		public void Clear ()
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
				script = string.Format ( "<script language='{0}' type='{1}'>\n{2}\n</script>", this.scriptType, type, this.code );

			key = MakeKey ( key );

#if V4
			if ( option.HasFlag ( ScriptBuildOption.Startup ) )
#else
			if ( ( option & ScriptBuildOption.Startup ) == ScriptBuildOption.Startup )
#endif
				page.ClientScript.RegisterStartupScript ( page.GetType (), key, script );
			else
				page.ClientScript.RegisterClientScriptBlock ( page.GetType (), key, script );

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

			if ( page.ClientScript.IsClientScriptIncludeRegistered ( page.GetType (), key ) )
				return;

			page.ClientScript.RegisterClientScriptInclude ( page.GetType (), key, url );
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

			if ( page.ClientScript.IsOnSubmitStatementRegistered ( page.GetType (), key ) )
				return;

			page.ClientScript.RegisterOnSubmitStatement ( page.GetType (), key, code );
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
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
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
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
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
		/// 最为启动脚本.
		/// </summary>
		Startup = 4
	}

}
// ../.enum/web/ScriptType.cs
/*
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
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
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/StringCompareMode.cs
 * 版本: .net 4.0, 其它版本可能有所不同
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

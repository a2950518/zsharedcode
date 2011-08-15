/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageAction.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Collections.Generic;

using zoyobar.shared.panzer.flow;

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

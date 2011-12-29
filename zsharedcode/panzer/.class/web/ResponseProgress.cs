/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ResponseProgress.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.IO;
using System.Web;

namespace zoyobar.shared.panzer.web
{

#if EN
	/// <summary>
	/// Class that can display page loading progress.
	/// </summary>
#elif HANS
	/// <summary>
	/// 可以显示页面载入进度的类.
	/// </summary>
#endif
	public partial class ResponseProgress
	{
		private readonly string templateFilePath;
		private readonly string setMethodName;
		private readonly string hideMethodName;
		private readonly HttpResponse response;

		#region " ResponseProgress "
#if EN
		/// <summary>
		/// Create a class that displays page loading progress, using the default template.
		/// </summary>
		/// <param name="response">The response object.</param>
#elif HANS
		/// <summary>
		/// 创建显示页面载入进度的类, 使用默认的模板.
		/// </summary>
		/// <param name="response">响应对象.</param>
#endif
		#endregion
		public ResponseProgress ( HttpResponse response )
			: this ( response, null, null, null )
		{ }
		#region " ResponseProgress "
#if EN
		/// <summary>
		/// Create a class that displays page loading progress, specify a custom template.
		/// </summary>
		/// <param name="response">The response object.</param>
		/// <param name="templateFilePath">The path to the template file, include the elements whose ID are __process, __percent and __message.</param>
#elif HANS
		/// <summary>
		/// 创建显示页面载入进度的类, 指定自定义的模板.
		/// </summary>
		/// <param name="response">响应对象.</param>
		/// <param name="templateFilePath">模板文件的路径, 需要包含 id 为 __process, __percent, __message 的元素.</param>
#endif
		#endregion
		public ResponseProgress ( HttpResponse response, string templateFilePath )
			: this ( response, templateFilePath, null, null )
		{ }
		//! There's no use PARAM, If templateFilePath is not set, you cannot set the setMethodName and hideMethodName, cannot write (string templateFilePath = null, string setMethodName = null, string hideMethodName = null)
		#region " ResponseProgress "
#if EN
		/// <summary>
		/// Create a class that displays page loading progress, specify a custom template and method.
		/// </summary>
		/// <param name="response">The response object.</param>
		/// <param name="templateFilePath">The path to the template file, such as: @ "~/template.htm", include the javascript method specified by setMethodName, hideMethodName that is similar to: function setProgress(data) { /* Here you can call __setProgress (data); */ }, function hideProgress() { / * Here you can call __hideProgress (data); */ }.</param>
		/// <param name="setMethodName">The name of javascript method which sets the progress information.</param>
		/// <param name="hideMethodName">The name of javascript method which hides the progress information.</param>
#elif HANS
		/// <summary>
		/// 创建显示页面载入进度的类, 指定自定义的模板和函数.
		/// </summary>
		/// <param name="response">响应对象.</param>
		/// <param name="templateFilePath">模板文件的路径, 比如: @"~/template.htm", 需要包含 setMethodName, hideMethodName 指定的 javascript 函数, 函数格式类似于 function setProgress(data){ /* 这里可以调用 __setProgress(data); */ }, function hideProgress(){ /* 这里可以调用 __hideProgress(data); */ }.</param>
		/// <param name="setMethodName">设置进度的 javascript 函数名称.</param>
		/// <param name="hideMethodName">隐藏进度的 javascript 函数名称.</param>
#endif
		#endregion
		public ResponseProgress ( HttpResponse response, string templateFilePath, string setMethodName, string hideMethodName )
		{

			if ( null == response )
#if EN
				throw new ArgumentNullException ( "response", "The Response object is not available" );
#elif HANS
				throw new ArgumentNullException ( "response", "没有提供可用的 Response 对象" );
#endif

			this.setMethodName = string.IsNullOrEmpty ( setMethodName ) ? "__setProgress" : setMethodName;
			this.hideMethodName = string.IsNullOrEmpty ( hideMethodName ) ? "__hideProgress" : hideMethodName;
			this.templateFilePath = templateFilePath;
			this.response = response;
		}

		#region " Register "
#if EN
		/// <summary>
		/// Register the necessary html and javascript methods, will automatically set Response.BufferOutput to false.
		/// </summary>
#elif HANS
		/// <summary>
		/// 注册所需的 html 和 javascript 函数, 将自动设置 Response.BufferOutput 为 false.
		/// </summary>
#endif
		#endregion
		public void Register ( )
		{

			this.response.BufferOutput = false;
			this.response.Write (
				"<script type=\"text/javascript\">" +
				"function __set(id, value){var tag = document.getElementById(id); if(null == tag){return;} tag.innerText = null == value ? '' : value.toString();}" +
				"function __setProgress(data){__set('__message', data.message);__set('__percent', null == data.percent ? null : data.percent.toString() + '%');}" +
				"function __hideProgress(){document.getElementById('__progress').style.display = 'none';}" +
				"</script>"
				);

			if ( string.IsNullOrEmpty ( this.templateFilePath ) )
				this.response.Write (
					"<body><div id=\"__progress\" style=\"font-family: microsoft yahei, Segoe UI, Verdana, Tahoma, Arial, sans-serif\"><span id=\"__message\"></span>&nbsp;<span id=\"__percent\"></span></div></body>"
					);
			else
				this.response.WriteFile ( templateFilePath );

			this.response.Flush ( );
			this.response.ClearContent ( );
		}

#if PARAM
		#region " Set "
#if EN
		/// <summary>
		/// Sets the current progress information, the javacript method which specified by setMethodName in the constructor will be called, you need to call Register method first.
		/// </summary>
		/// <param name="percent">Percentage of progress, is the percent property of parameter, the default is -1, nothing is displayed.</param>
		/// <param name="message">Message of progress, is the message property of parameter, the default is null, nothing is displayed.</param>
#elif HANS
		/// <summary>
		/// 设置当前进度信息, 将调用构造函数中 setMethodName 指定的 javascript 函数, 需要首先调用 Register 方法.
		/// </summary>
		/// <param name="percent">进度的百分比, 对应参数的 percent 属性, 默认为 -1, 不显示.</param>
		/// <param name="message">消息, 对应参数的 message 属性, 默认为 null, 不显示.</param>
#endif
		#endregion
		public void Set ( int percent = -1, string message = null )
#else
		#region " Set "
#if EN
		/// <summary>
		/// Sets the current progress information, the javacript method which specified by setMethodName in the constructor will be called, you need to call Register method first.
		/// </summary>
		/// <param name="percent">Percentage of progress, is the percent property of parameter.</param>
		/// <param name="message">Message of progress, is the message property of parameter.</param>
#elif HANS
		/// <summary>
		/// 设置当前进度信息, 将调用构造函数中 setMethodName 指定的 javascript 函数, 需要首先调用 Register 方法.
		/// </summary>
		/// <param name="percent">进度的百分比, 对应参数的 percent 属性.</param>
		/// <param name="message">消息, 对应参数的 message 属性.</param>
#endif
		#endregion
		public void Set ( int percent, string message )
#endif
		{
			this.response.Write (
				"<script type=\"text/javascript\">" +
				this.setMethodName + "({" + ( percent < 0 ? string.Empty : string.Format ( "percent: {0},", percent ) ) + ( string.IsNullOrEmpty ( message ) ? string.Empty : string.Format ( "message: '{0}',", ScriptHelper.EscapeCharacter ( message, true ) ) ) + "nothing: null});" +
				"</script>"
				);

			this.response.Flush ( );
			this.response.ClearContent ( );
		}

		#region " Hide "
#if EN
		/// <summary>
		/// Hide progress information, the javacript method which specified by hideMethodName in the constructor will be called, you need to call Register method first.
		/// </summary>
#elif HANS
		/// <summary>
		/// 隐藏当前进度信息, 将调用构造函数中 hideMethodName 指定的 javascript 函数, 需要首先调用 Register 方法.
		/// </summary>
#endif
		#endregion
		public void Hide ( )
		{
			this.response.Write (
				"<script type=\"text/javascript\">" +
				this.hideMethodName + "();" +
				"</script>"
				);

			this.response.Flush ( );
			this.response.ClearContent ( );
		}

	}

	partial class ResponseProgress
	{
#if !PARAM

		#region " Set "
#if EN
		/// <summary>
		/// Sets the current progress information, the javacript method which specified by setMethodName in the constructor will be called, you need to call Register method first.
		/// </summary>
		/// <param name="percent">Percentage of progress, is the percent property of parameter.</param>
#elif HANS
		/// <summary>
		/// 设置当前进度信息, 将调用构造函数中 setMethodName 指定的 javascript 函数, 需要首先调用 Register 方法.
		/// </summary>
		/// <param name="percent">进度的百分比, 对应参数的 percent 属性.</param>
#endif
		#endregion
		public void Set ( int percent )
		{ this.Set ( percent, null ); }
		#region " Set "
#if EN
		/// <summary>
		/// Sets the current progress information, the javacript method which specified by setMethodName in the constructor will be called, you need to call Register method first.
		/// </summary>
		/// <param name="message">Message of progress, is the message property of parameter.</param>
#elif HANS
		/// <summary>
		/// 设置当前进度信息, 将调用构造函数中 setMethodName 指定的 javascript 函数, 需要首先调用 Register 方法.
		/// </summary>
		/// <param name="message">消息, 对应参数的 message 属性.</param>
#endif
		#endregion
		public void Set ( string message )
		{ this.Set ( -1, message ); }

#endif
	}

}

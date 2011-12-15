/*
 * Author: M.S.cxc
 * Code Url: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * Version: .net 4.0
 * 
 * License: This file is an open source shared for free, you need to comply with panzer license http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt, please download the license and include it in your project and product.
 * 
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * 版本: 1.2, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

// HACK: Define compilation symbol PARAM to provide the default parameters for method

// HACK: If the code does not compile, try to define compilation symbol V4, V3_5, V3, V2 that represent different .NET version

using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace zoyobar.shared.panzer.web
{

	#region " ScriptHelper "
#if EN
	/// <summary>
	/// You can use this class to write client-side scripts, modify the label attribute, contain a script file, set the clock, and so on.
	/// </summary>
#elif HANS
	/// <summary>
	/// 此类可以完成客户端脚本的编写, 修改标签属性, 包含脚本文件, 设置时钟等操作.
	/// </summary>
#endif
	#endregion
	public partial class ScriptHelper
	{

		#region " static "
		private static readonly Random random = new Random ( );

#if PARAM
		#region " EscapeCharacter "
#if EN
		/// <summary>
		/// Encode special characters in a string into script form, such as \ to \\.
		/// </summary>
		/// <param name="text">The string to encode.</param>
		/// <param name="isRemove">If true, remove return, linefeed and tab, the default is false.</param>
		/// <returns>Encoded string.</returns>
#elif HANS
		/// <summary>
		/// 将字符串中的特殊字符编码为脚本形式, 如: \ 编码为 \\.
		/// </summary>
		/// <param name="text">需要编码的字符串.</param>
		/// <param name="isRemove">如果为 true, 则删除回车, 换行和制表符, 默认为 false.</param>
		/// <returns>编码后的字符串.</returns>
#endif
		#endregion
		public static string EscapeCharacter ( string text, bool isRemove = false )
#else
		#region " EscapeCharacter "
#if EN
		/// <summary>
		/// Encode special characters in a string into script form, such as \ to \\.
		/// </summary>
		/// <param name="text">The string to encode.</param>
		/// <param name="isRemove">If true, remove return, linefeed and tab.</param>
		/// <returns>Encoded string.</returns>
#elif HANS
		/// <summary>
		/// 将字符串中的特殊字符编码为脚本形式, 如: \ 编码为 \\.
		/// </summary>
		/// <param name="text">需要编码的字符串.</param>
		/// <param name="isRemove">如果为 true, 则删除回车, 换行和制表符.</param>
		/// <returns>编码后的字符串.</returns>
#endif
		#endregion
		public static string EscapeCharacter ( string text, bool isRemove )
#endif
		{

			if ( string.IsNullOrEmpty ( text ) )
				return string.Empty;

			if ( isRemove )
			{
				text = text.Replace ( "\n", "!space!" ).Replace ( "\r", "!space!" ).Replace ( "\t", "!space!" );
				text = Regex.Replace ( text, "(!space!)+", " ", RegexOptions.Multiline );
			}
			else
				text = text.Replace ( "\n", "\\n" ).Replace ( "\r", "\\r" ).Replace ( "\t", "\\t" );

			return text.Replace ( "\\", "\\\\" ).Replace ( "\'", "\\'" );
		}

#if PARAM
		#region " IsBuilt "
#if EN
		/// <summary>
		/// Determine whether the code block with the specified name already exists?
		/// </summary>
		/// <param name="holder">Container page of the code block, which can be ASPXScriptHolder or RazorScriptHolder.</param>
		/// <param name="key">Keyword used to differentiate between code blocks in the build process.</param>
		/// <param name="option">Script generation options, which can be None, Startup, defaults to None. (Not valid for Razor)</param>
		/// <returns>The code block exist?</returns>
#elif HANS
		/// <summary>
		/// 判断指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="holder">代码块所在的容器页面, 可以是 ASPXScriptHolder 或者 RazorScriptHolder.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字.</param>
		/// <param name="option">脚本的生成选项, 可以是 None, Startup, 默认为 None. (对 Razor 无效)</param>
		/// <returns>是否存在代码块?</returns>
#endif
		#endregion
		public static bool IsBuilt ( ScriptHolder holder, string key, ScriptBuildOption option = ScriptBuildOption.None )
#else
		#region " IsBuilt "
#if EN
		/// <summary>
		/// Determine whether the code block with the specified name already exists?
		/// </summary>
		/// <param name="holder">Container page of the code block, which can be ASPXScriptHolder or RazorScriptHolder.</param>
		/// <param name="key">Keyword used to differentiate between code blocks in the build process.</param>
		/// <param name="option">Script generation options, which can be None, Startup. (Not valid for Razor)</param>
		/// <returns>The code block exist?</returns>
#elif HANS
		/// <summary>
		/// 判断指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="holder">代码块所在的容器页面, 可以是 ASPXScriptHolder 或者 RazorScriptHolder.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字.</param>
		/// <param name="option">脚本的生成选项, 可以是 None, Startup. (对 Razor 无效)</param>
		/// <returns>是否存在代码块?</returns>
#endif
		#endregion
		public static bool IsBuilt ( ScriptHolder holder, string key, ScriptBuildOption option )
#endif
		{

			if ( null == holder )
				return false;

			// HACK: You may need to add the V5
#if V4
			if ( option.HasFlag ( ScriptBuildOption.Startup ) )
#else
			if ( ( option & ScriptBuildOption.Startup ) == ScriptBuildOption.Startup )
#endif
				return holder.IsStartupScriptRegistered ( MakeKey ( key ) );
			else
				return holder.IsClientScriptBlockRegistered ( MakeKey ( key ) );

		}

#if PARAM
		#region " MakeKey "
#if EN
		/// <summary>
		/// Generate script id from a string.
		/// </summary>
		/// <param name="key">Strings, as part of the ID, the default is a random string.</param>
		/// <returns>Script id.</returns>
#elif HANS
		/// <summary>
		/// 从一个字符串生成脚本的 id.
		/// </summary>
		/// <param name="key">字符串, 作为 id 的一部分, 默认为一个随机字符串.</param>
		/// <returns>脚本 id.</returns>
#endif
		#endregion
		public static string MakeKey ( string key = null )
#else
		#region " MakeKey "
#if EN
		/// <summary>
		/// Generate script id from a string.
		/// </summary>
		/// <param name="key">Strings, as part of the id.</param>
		/// <returns>Script id.</returns>
#elif HANS
		/// <summary>
		/// 从一个字符串生成脚本的 id.
		/// </summary>
		/// <param name="key">字符串, 作为 id 的一部分.</param>
		/// <returns>脚本 id.</returns>
#endif
		#endregion
		public static string MakeKey ( string key )
#endif
		{

			if ( string.IsNullOrEmpty ( key ) )
				key = DateTime.Now.ToString ( "yyyyMMddhhmmss" ) + random.Next ( 0, int.MaxValue );

			return string.Format ( "script_{0}", key );
		}
		#endregion

		#region " property "
		protected string code = string.Empty;
		protected readonly ScriptType scriptType;

		#region " Code "
#if EN
		/// <summary>
		/// Get or set the current scripting code, null is equivalent to an empty string.
		/// </summary>
#elif HANS
		/// <summary>
		/// 获取或设置当前的脚本代码, 设置 null 相当于空字符串.
		/// </summary>
#endif
		#endregion
		public string Code
		{
			get { return this.code; }
			set { this.code = ( null == value ? string.Empty : value ); }
		}

		#region " EndOfLine "
#if EN
		/// <summary>
		/// Get statement completion symbols, such as ";" for JavaScript.
		/// </summary>
#elif HANS
		/// <summary>
		/// 获取当前脚本类型对应的语句结束符号, 比如 JavaScript 对应了 ";".
		/// </summary>
#endif
		#endregion
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

		#region " Return "
#if EN
		/// <summary>
		/// Get the Return statement, such as JavaScript corresponds to "return".
		/// </summary>
#elif HANS
		/// <summary>
		/// 获取当前脚本类型对应的 Return 语句, 比如 JavaScript 对应了 "return".
		/// </summary>
#endif
		#endregion
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

		#region " ScriptType "
#if EN
		/// <summary>
		/// Get the script type.
		/// </summary>
#elif HANS
		/// <summary>
		/// 获取代码所使用的脚本类型.
		/// </summary>
#endif
		#endregion
		public ScriptType ScriptType
		{
			get { return this.scriptType; }
		}
		#endregion

#if PARAM
		#region " ScriptHelper "
#if EN
		/// <summary>
		/// Create a new script helper.
		/// </summary>
		/// <param name="scriptType">The script type, currently only available for JavaScript, defaults to JavaScript.</param>
#elif HANS
		/// <summary>
		/// 创建脚本助手.
		/// </summary>
		/// <param name="scriptType">脚本类型, 目前只有 JavaScript 类型可用, 默认为 JavaScript.</param>
#endif
		#endregion
		public ScriptHelper ( ScriptType scriptType = ScriptType.JavaScript )
#else
		#region " ScriptHelper "
#if EN
		/// <summary>
		/// Create a new script helper.
		/// </summary>
		/// <param name="scriptType">The script type, currently only available for JavaScript.</param>
#elif HANS
		/// <summary>
		/// 创建脚本助手.
		/// </summary>
		/// <param name="scriptType">脚本类型, 目前只有 JavaScript 类型可用.</param>
#endif
		#endregion
		public ScriptHelper ( ScriptType scriptType )
#endif
		{

			switch ( scriptType )
			{
				case ScriptType.VBScript:
#if EN
					throw new ArgumentException ( "Does not currently support VBScript, please use the JavaScript", "scriptType" );
#elif HANS
					throw new ArgumentException ( "目前不支持 VBScript, 请使用 JavaScript", "scriptType" );
#endif

			}

			this.scriptType = scriptType;
		}

		#region " javascript "

#if PARAM
		#region " Alert "
#if EN
		/// <summary>
		/// Generate alert method, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="message">Popup content, for example: "'hello'", can also be expressions, for example: "'my name is' + myname".</param>
		/// <param name="isAppend">Defaults to true, the script appends to the Code property.</param>
		/// <returns>The script which contains alert method.</returns>
#elif HANS
		/// <summary>
		/// 生成弹出消息的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'hello'", 也可以是计算表达式, 比如: "'my name is ' + myname".</param>
		/// <param name="isAppend">默认为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>弹出消息的脚本代码.</returns>
#endif
		#endregion
		public string Alert ( string message, bool isAppend = true )
#else
		#region " Alert "
#if EN
		/// <summary>
		/// Generate alert method, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="message">Popup content, for example: "'hello'", can also be expressions, for example: "'my name is' + myname".</param>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains alert method.</returns>
#elif HANS
		/// <summary>
		/// 生成弹出消息的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'hello'", 也可以是计算表达式, 比如: "'my name is ' + myname".</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>弹出消息的脚本代码.</returns>
#endif
		#endregion
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
				this.AppendCode ( code );

			return code;
		}

#if PARAM
		#region " ClearInterval "
#if EN
		/// <summary>
		/// Generate clearInterval method, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="handler">The handle of the clock, for example: "100,000" or exit script variables, such as: "timer1".</param>
		/// <param name="isAppend">Defaults to true, the script appends to the Code property.</param>
		/// <returns>The script which contains clearInterval method.</returns>
#elif HANS
		/// <summary>
		/// 生成清除循环时钟的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的脚本变量, 比如: "timer1".</param>
		/// <param name="isAppend">默认为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>清除循环时钟的脚本代码.</returns>
#endif
		#endregion
		public string ClearInterval ( string handler, bool isAppend = true )
#else
		#region " ClearInterval "
#if EN
		/// <summary>
		/// Generate clearInterval method, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="handler">The handle of the clock, for example: "100,000" or exit script variables, such as: "timer1".</param>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains clearInterval method.</returns>
#elif HANS
		/// <summary>
		/// 生成清除循环时钟的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的脚本变量, 比如: "timer1".</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>清除循环时钟的脚本代码.</returns>
#endif
		#endregion
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
				this.AppendCode ( code );

			return code;
		}

#if PARAM
		#region " ClearTimeout "
#if EN
		/// <summary>
		/// Generate clearTimeout method, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="handler">The handle of the clock, for example: "100,000" or exit script variables, such as: "timer1".</param>
		/// <param name="isAppend">Defaults to true, the script appends to the Code property.</param>
		/// <returns>The script which contains clearTimeout method.</returns>
#elif HANS
		/// <summary>
		/// 生成清除时钟的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的脚本变量, 比如: "timer1".</param>
		/// <param name="isAppend">默认为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>清除时钟的脚本代码.</returns>
#endif
		#endregion
		public string ClearTimeout ( string handler, bool isAppend = true )
#else
		#region " ClearTimeout "
#if EN
		/// <summary>
		/// Generate clearTimeout method, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="handler">The handle of the clock, for example: "100,000" or exit script variables, such as: "timer1".</param>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains clearTimeout method.</returns>
#elif HANS
		/// <summary>
		/// 生成清除时钟的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的脚本变量, 比如: "timer1".</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>清除时钟的脚本代码.</returns>
#endif
		#endregion
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
		#region " Confirm "
#if EN
		/// <summary>
		/// Generate confirm method, save the result user selected into a script variable, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="message">What needs to be confirmed, such as: "'Delete?'", can also be a expression, such as: "'Delete student ' + name".</param>
		/// <param name="result">The name of the variable which save the result, for example: "deleteIt", defaults to null, the result will not be saved.</param>
		/// <param name="isAppend">Defaults to true, the script appends to the Code property.</param>
		/// <returns>The script which contains confirm method.</returns>
#elif HANS
		/// <summary>
		/// 生成弹出确认框并将用户选择的结果保存在脚本变量中的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="message">需要确认的内容, 比如: "'确认删除吗?'", 也可以是计算表达式, 比如: "'删除姓名为' + name + '的学生吗?'".</param>
		/// <param name="result">保存用户所选结果的变量的名称, 比如: "deleteIt", 默认为 null, 不保存用户选择的结果.</param>
		/// <param name="isAppend">默认为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>弹出确认框的脚本代码.</returns>
#endif
		#endregion
		public string Confirm ( string message, string result = null, bool isAppend = true )
#else
		#region " Confirm "
#if EN
		/// <summary>
		/// Generate confirm method, save the result user selected into a script variable, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="message">What needs to be confirmed, such as: "'Delete?'", can also be a expression, such as: "'Delete student ' + name".</param>
		/// <param name="result">The name of the variable which save the result, for example: "deleteIt", if set to null, then the result will not be saved.</param>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains confirm method.</returns>
#elif HANS
		/// <summary>
		/// 生成弹出确认框并将用户选择的结果保存在脚本变量中的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="message">需要确认的内容, 比如: "'确认删除吗?'", 也可以是计算表达式, 比如: "'删除姓名为' + name + '的学生吗?'".</param>
		/// <param name="result">保存用户所选结果的变量的名称, 比如: "deleteIt", 如果设置为 null, 则不会保存用户选择的结果.</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>弹出确认框的脚本代码.</returns>
#endif
		#endregion
		public string Confirm ( string message, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( message ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{1}confirm({0});", message, string.IsNullOrEmpty ( result ) ? string.Empty : result + " = " );
					break;
			}

			if ( isAppend )
				this.AppendCode ( code );

			return code;
		}

#if PARAM
		#region " Navigate "
#if EN
		/// <summary>
		/// Generate navigation scripts, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="location">Url for navigation, for example: "'www.google.com.hk'", can also be a expressions, for example: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">Navigation option, indicating where to display the page, defaults to SelfWindow, in its own window.</param>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains navigation scripts.</returns>
#elif HANS
		/// <summary>
		/// 生成导航页面的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com.hk'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航的选项, 指示在自身还是新窗口中显示页面, 最终的代码中选项会使用单引号, 比如: '_blank', 默认为 SelfWindow, 在自身窗口显示.</param>
		/// <param name="isAppend">默认为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>导航的脚本代码.</returns>
#endif
		#endregion
		public string Navigate ( string location, NavigateOption option = NavigateOption.SelfWindow, bool isAppend = true )
#else
		#region " Navigate "
#if EN
		/// <summary>
		/// Generate navigation scripts, and choose whether to append the script to the Code property.
		/// </summary>
		/// <param name="location">Url for navigation, for example: "'www.google.com.hk'", can also be a expressions, for example: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">Navigation option, indicating where to display the page.</param>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains navigation scripts.</returns>
#elif HANS
		/// <summary>
		/// 生成导航页面的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com.hk'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航的选项, 指示在自身还是新窗口中显示页面, 最终的代码中选项会使用单引号, 比如: '_blank'.</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>导航的脚本代码.</returns>
#endif
		#endregion
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
		/// 生成弹出输入框并将用户选择的结果保存在脚本变量中的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'请输入姓名:'", 也可以是计算表达式, 比如: "'请输入' + something".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'小明'", 也可以是计算表达式, 比如: "defaultName", 默认为 "''".</param>
		/// <param name="result">保存用户输入内容的变量的名称, 比如: "userName", 默认为 null, 不保存用户选择的结果.</param>
		/// <param name="isAppend">默认为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>弹出输入框的脚本代码.</returns>
		public string Prompt ( string message, string defaultValue = null, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成弹出输入框并将用户选择的结果保存在脚本变量中的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'请输入姓名:'", 也可以是计算表达式, 比如: "'请输入' + something".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'小明'", 也可以是计算表达式, 比如: "defaultName".</param>
		/// <param name="result">保存用户输入内容的变量的名称, 比如: "userName", 如果设置为 null, 则不会保存用户选择的结果.</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>弹出输入框的脚本代码.</returns>
		public string Prompt ( string message, string defaultValue, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( null == message )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}prompt({0}, {1});", message, null == defaultValue ? "''" : defaultValue, string.IsNullOrEmpty ( result ) ? string.Empty : result + " = " );
					break;
			}

			if ( isAppend )
				this.AppendCode ( code );

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成循环时钟返回句柄到变量的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <param name="result">保存时钟句柄的变量的名称, 比如: "timer1", "window.MyTimer", 默认为 null, 不保存句柄.</param>
		/// <param name="isAppend">默认为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>循环时钟的脚本代码.</returns>
		public string SetInterval ( string runCode, int delay, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成循环时钟返回句柄到变量的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <param name="result">保存时钟句柄的变量的名称, 比如: "timer1", "window.MyTimer", 如果设置为 null, 则不会保存句柄.</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>循环时钟的脚本代码.</returns>
		public string SetInterval ( string runCode, int delay, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( runCode ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}setInterval({0}, {1});", runCode, delay <= 0 ? 1 : delay, string.IsNullOrEmpty ( result ) ? string.Empty : result + " = " );
					break;
			}

			if ( isAppend )
				this.AppendCode ( code );

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成时钟返回句柄到变量的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <param name="result">保存时钟句柄的变量的名称, 比如: "timer1", "window.MyTimer", 默认为 null, 不保存句柄.</param>
		/// <param name="isAppend">默认为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>时钟的脚本代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成时钟返回句柄到变量的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <param name="result">保存时钟句柄的变量的名称, 比如: "timer1", "window.MyTimer", 如果设置为 null, 则不会保存句柄.</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>时钟的脚本代码.</returns>
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
		#endregion

		#region " helper "
		/// <summary>
		/// 追加脚本代码 Code 属性的结尾处.
		/// </summary>
		/// <param name="code">被追加的脚本代码.</param>
		public void AppendCode ( string code )
		{

			if ( string.IsNullOrEmpty ( code ) )
				return;

			this.code += code;
		}

#if PARAM
		/// <summary>
		/// 将 Code 属性中的脚本作为一个代码块写入指定的目标中, 如果指定关键字的代码块已经在目标中存在, 则不写入.
		/// </summary>
		/// <param name="holder">表示脚本写入目标的对象, 可以是 ASPXScriptHolder 或者 RazorScriptHolder, 分别表示 aspx 和 cshtml 页面.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字, 默认为一个随机字符串.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效, Startup 表示在页面尾部写入代码块, 默认为 None 表示在页面头部写入. (此选项对 Razor 无效)</param>
		public void Build ( ScriptHolder holder, string key = null, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 将 Code 属性中的脚本作为一个代码块写入指定的目标中, 如果指定关键字的代码块已经在目标中存在, 则不写入.
		/// </summary>
		/// <param name="holder">表示脚本写入目标的对象, 可以是 ASPXScriptHolder 或者 RazorScriptHolder, 分别表示 aspx 和 cshtml 页面.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效, Startup 表示在页面尾部写入代码块, 而 None 表示在页面头部写入. (此选项对 Razor 无效)</param>
		public void Build ( ScriptHolder holder, string key, ScriptBuildOption option )
#endif
		{

			if ( null == holder || this.code == string.Empty || IsBuilt ( holder, key, option ) )
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
				holder.RegisterStartupScript ( key, script );
			else
				holder.RegisterClientScriptBlock ( key, script );

			// if ( option.HasFlag ( ScriptBuildOption.EndResponse ) && null != page.Response )
			//     page.Response.End ();

		}

		/// <summary>
		/// 清除所有的代码.
		/// </summary>
		public void Clear ( )
		{ this.code = string.Empty; }
		#endregion

		#region " aspx "
#if PARAM
		/// <summary>
		/// 为控件所在的 aspx 页面写入定义数组的脚本, 如果数组已经存在, 则新的数组元素将追加到原数组中. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="control">控件, 其所在页面将写入定义数组的脚本.</param>
		/// <param name="arrayName">数组名称, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 默认不包含任何元素.</param>
		public static void RegisterArray ( Control control, string arrayName, string arrayValue = null )
#else
		/// <summary>
		/// 为控件所在的 aspx 页面写入定义数组的脚本, 如果数组已经存在, 则新的数组元素将追加到原数组中. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="control">控件, 其所在页面将写入定义数组的脚本.</param>
		/// <param name="arrayName">数组名称, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'".</param>
		public static void RegisterArray ( Control control, string arrayName, string arrayValue )
#endif
		{

			if ( null == control )
				return;

			RegisterArray ( control.Page, arrayName, arrayValue );
		}

#if PARAM
		/// <summary>
		/// 为 aspx 页面写入定义数组的脚本, 如果数组已经存在, 则新的数组元素将追加到原数组中. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">将被写入定义数组脚本的页面.</param>
		/// <param name="arrayName">数组名称, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 默认不包含任何元素.</param>
		public static void RegisterArray ( Page page, string arrayName, string arrayValue = null )
#else
		/// <summary>
		/// 为 aspx 页面写入定义数组的脚本, 如果数组已经存在, 则新的数组元素将追加到原数组中. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">将被写入定义数组脚本的页面.</param>
		/// <param name="arrayName">数组名称, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'".</param>
		public static void RegisterArray ( Page page, string arrayName, string arrayValue )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( arrayName ) )
				return;

			page.ClientScript.RegisterArrayDeclaration ( arrayName, null == arrayValue ? string.Empty : arrayValue );
		}

		/// <summary>
		/// 为控件所在的 aspx 页面写入设置元素属性的脚本, 不能为同一元素的同一属性设置两次. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="control">控件, 其所在页面将写入设置元素属性的脚本.</param>
		/// <param name="id">元素的 id 属性, 比如: "spanTest".</param>
		/// <param name="attributeName">要设置的元素的属性, 比如: "innerHTML", "style.color".</param>
		/// <param name="attributeValue">属性的值, 比如: "你好", "#ff0000", 可以为 null.</param>
		public static void RegisterAttribute ( Control control, string id, string attributeName, string attributeValue )
		{

			if ( null == control )
				return;

			RegisterAttribute ( control.Page, id, attributeName, attributeValue );
		}
		/// <summary>
		/// 为 aspx 页面写入设置元素属性的脚本, 不能为同一元素的同一属性设置两次. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">将被写入设置元素属性脚本的页面.</param>
		/// <param name="id">元素的 id 属性, 比如: "spanTest".</param>
		/// <param name="attributeName">要设置的元素的属性, 比如: "innerHTML", "style.color".</param>
		/// <param name="attributeValue">属性的值, 比如: "你好", "#ff0000", 可以为 null.</param>
		public static void RegisterAttribute ( Page page, string id, string attributeName, string attributeValue )
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( id ) || string.IsNullOrEmpty ( attributeName ) )
				return;

			try
			{ page.ClientScript.RegisterExpandoAttribute ( id, attributeName, null == attributeValue ? string.Empty : attributeValue, true ); }
			catch { }

		}

		/// <summary>
		/// 为控件所在的 aspx 页面添加隐藏值, 也就是 type 属性为 hidden 的 input 元素. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加隐藏值.</param>
		/// <param name="name">隐藏值的名称.</param>
		/// <param name="value">隐藏值, 可以为 null.</param>
		public static void RegisterHidden ( Control control, string name, string value )
		{

			if ( null == control )
				return;

			RegisterHidden ( control.Page, name, value );
		}
		/// <summary>
		/// 为 aspx 页面添加隐藏值, 也就是 type 属性为 hidden 的 input 元素. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加隐藏值.</param>
		/// <param name="name">隐藏值的名称.</param>
		/// <param name="value">隐藏值, 可以为 null.</param>
		public static void RegisterHidden ( Page page, string name, string value )
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( name ) )
				return;

			page.ClientScript.RegisterHiddenField ( name, null == value ? string.Empty : value );
		}

#if PARAM
		/// <summary>
		/// 为控件所在的 aspx 页面添加脚本引用, 如果指定关键字的脚本引用已经存在, 则不再次引用. (此方法对 Razor 无效)
		/// <param name="control">控件, 其所在页面将添加脚本引用.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字, 默认为一个随机字符串.</param>
		public static void RegisterInclude ( Control control, string url, string key = null )
#else
		/// <summary>
		/// 为控件所在的 aspx 页面添加脚本引用, 如果指定关键字的脚本引用已经存在, 则不再次引用. (此方法对 Razor 无效)
		/// <param name="control">控件, 其所在页面将添加脚本引用.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字.</param>
		public static void RegisterInclude ( Control control, string url, string key )
#endif
		{

			if ( null == control )
				return;

			RegisterInclude ( control.Page, key, url );
		}

#if PARAM
		/// <summary>
		/// 为 aspx 页面添加脚本引用, 如果指定关键字的脚本引用已经存在, 则不再次引用. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">添加脚本引用的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字, 默认为一个随机字符串.</param>
		public static void RegisterInclude ( Page page, string url, string key = null )
#else
		/// <summary>
		/// 为 aspx 页面添加脚本引用, 如果指定关键字的脚本引用已经存在, 则不再次引用. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">添加脚本引用的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字.</param>
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
		/// 为控件所在的 aspx 页面添加资源脚本的引用. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加资源脚本引用.</param>
		/// <param name="resourceType">包含脚本资源的类型.</param>
		/// <param name="resourceName">脚本资源的名称.</param>
		public static void RegisterResource ( Control control, Type resourceType, string resourceName )
		{

			if ( null == control )
				return;

			RegisterResource ( control.Page, resourceType, resourceName );
		}

		/// <summary>
		/// 为 aspx 页面添加资源脚本的引用. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">添加资源脚本引用的页面.</param>
		/// <param name="resourceType">包含脚本资源的类型.</param>
		/// <param name="resourceName">脚本资源的名称.</param>
		public static void RegisterResource ( Page page, Type resourceType, string resourceName )
		{

			if ( null == page || null == page.ClientScript || null == resourceType || string.IsNullOrEmpty ( resourceName ) )
				return;

			page.ClientScript.RegisterClientScriptResource ( resourceType, resourceName );
		}

#if PARAM
		/// <summary>
		/// 为控件所在的 aspx 页面写入提交表单的脚本, 如果指定关键字的脚本已经存在, 则不再次写入. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="control">控件, 其所在页面将写入提交表单脚本.</param>
		/// <param name="code">脚本的内容, 比如: "if(age != 10){return false;}".</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字, 默认为一个随机字符串.</param>
		public static void RegisterSubmit ( Control control, string code, string key = null )
#else
		/// <summary>
		/// 为控件所在的 aspx 页面写入提交表单的脚本, 如果指定关键字的脚本已经存在, 则不再次写入. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="control">控件, 其所在页面将写入提交表单脚本.</param>
		/// <param name="code">脚本的内容, 比如: "if(age != 10){return false;}".</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字.</param>
		public static void RegisterSubmit ( Control control, string code, string key )
#endif
		{

			if ( null == control )
				return;

			RegisterSubmit ( control.Page, key, code );
		}

#if PARAM
		/// <summary>
		/// 为 aspx 页面写入提交表单的脚本, 如果指定关键字的脚本已经存在, 则不再次写入. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">写入提交表单脚本的页面.</param>
		/// <param name="code">脚本的内容, 比如: "if(age != 10){return false;}".</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字, 默认为一个随机字符串.</param>
		public static void RegisterSubmit ( Page page, string code, string key = null )
#else
		/// <summary>
		/// 为 aspx 页面写入提交表单的脚本, 如果指定关键字的脚本已经存在, 则不再次写入. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">写入提交表单脚本的页面.</param>
		/// <param name="code">脚本的内容, 比如: "if(age != 10){return false;}".</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字.</param>
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
		#endregion

	}

	partial class ScriptHelper
	{
#if !PARAM

		#region " static "
		#region " EscapeCharacter "
#if EN
		/// <summary>
		/// Encode special characters in a string into script form, such as \ to \\, do not delete return, linefeed and tab.
		/// </summary>
		/// <param name="text">The string to encode.</param>
		/// <returns>Encoded string.</returns>
#elif HANS
		/// <summary>
		/// 将字符串中的特殊字符编码为脚本形式, 如: \ 编码为 \\, 不删除回车, 换行和制表符.
		/// </summary>
		/// <param name="text">需要编码的字符串.</param>
		/// <returns>编码后的字符串.</returns>
#endif
		#endregion
		public static string EscapeCharacter ( string text )
		{ return EscapeCharacter ( text, false ); }

		#region " IsBuilt "
#if EN
		/// <summary>
		/// Determine whether the normal code block with the specified name already exists? 
		/// </summary>
		/// <param name="holder">Container page of the code block, which can be ASPXScriptHolder or RazorScriptHolder.</param>
		/// <param name="key">Keyword used to differentiate between code blocks in the build process.</param>
		/// <returns>The code block exist?</returns>
#elif HANS
		/// <summary>
		/// 判断指定名称的普通代码块是否已经存在?
		/// </summary>
		/// <param name="holder">代码块所在的容器页面, 可以是 ASPXScriptHolder 或者 RazorScriptHolder.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字.</param>
		/// <returns>是否存在代码块?</returns>
#endif
		#endregion
		public static bool IsBuilt ( ScriptHolder holder, string key )
		{ return IsBuilt ( holder, key, ScriptBuildOption.None ); }

		#region " MakeKey "
#if EN
		/// <summary>
		/// Generate a random script id.
		/// </summary>
		/// <returns>Script id.</returns>
#elif HANS
		/// <summary>
		/// 生成一个随机的脚本 id.
		/// </summary>
		/// <returns>脚本 id.</returns>
#endif
		#endregion
		public static string MakeKey ( )
		{ return MakeKey ( null ); }
		#endregion

		#region " ScriptHelper "
#if EN
		/// <summary>
		/// Create a new script helper, the script type is JavaScript.
		/// </summary>
#elif HANS
		/// <summary>
		/// 创建脚本助手, 脚本类型为 JavaScript.
		/// </summary>
#endif
		#endregion
		public ScriptHelper ( )
			: this ( ScriptType.JavaScript )
		{ }

		#region " javascript "

		#region " Alert "
#if EN
		/// <summary>
		/// Generate alert method, and appends to the Code property.
		/// </summary>
		/// <param name="message">Popup content, for example: "'hello'", can also be expressions, for example: "'my name is' + myname".</param>
		/// <returns>The script which contains alert method.</returns>
#elif HANS
		/// <summary>
		/// 生成弹出消息的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'hello'", 也可以是计算表达式, 比如: "'my name is ' + myname".</param>
		/// <returns>弹出消息的脚本代码.</returns>
#endif
		#endregion
		public string Alert ( string message )
		{ return Alert ( message, true ); }

		#region " ClearInterval "
#if EN
		/// <summary>
		/// Generate clearInterval method, and appends to the Code property.
		/// </summary>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains clearInterval method.</returns>
#elif HANS
		/// <summary>
		/// 生成清除循环时钟的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的脚本变量, 比如: "timer1".</param>
		/// <returns>清除循环时钟的脚本代码.</returns>
#endif
		#endregion
		public string ClearInterval ( string handler )
		{ return this.ClearInterval ( handler, true ); }

		#region " ClearTimeout "
#if EN
		/// <summary>
		/// Generate clearTimeout method, and appends to the Code property.
		/// </summary>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains clearTimeout method.</returns>
#elif HANS
		/// <summary>
		/// 生成清除时钟的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的脚本变量, 比如: "timer1".</param>
		/// <returns>清除时钟的脚本代码.</returns>
#endif
		#endregion
		public string ClearTimeout ( string handler )
		{ return this.ClearTimeout ( handler, true ); }

		#region " Confirm "
#if EN
		/// <summary>
		/// Generate confirm method, and appends to the Code property.
		/// </summary>
		/// <param name="message">What needs to be confirmed, such as: "'Delete?'", can also be a expression, such as: "'Delete student ' + name".</param>
		/// <returns>The script which contains confirm method.</returns>
#elif HANS
		/// <summary>
		/// 生成弹出确认框的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="message">需要确认的内容, 比如: "'确认删除吗?'", 也可以是计算表达式, 比如: "'删除姓名为' + name + '的学生吗?'".</param>
		/// <returns>弹出确认框的脚本代码.</returns>
#endif
		#endregion
		public string Confirm ( string message )
		{ return this.Confirm ( message, null, true ); }
		#region " Confirm "
#if EN
		/// <summary>
		/// Generate confirm method, save the result user selected into a script variable, and appends to the Code property.
		/// </summary>
		/// <param name="message">What needs to be confirmed, such as: "'Delete?'", can also be a expression, such as: "'Delete student ' + name".</param>
		/// <param name="result">The name of the variable which save the result, for example: "deleteIt", if set to null, then the result will not be saved.</param>
		/// <returns>The script which contains confirm method.</returns>
#elif HANS
		/// <summary>
		/// 生成弹出确认框并将用户选择的结果保存在脚本变量中的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="message">需要确认的内容, 比如: "'确认删除吗?'", 也可以是计算表达式, 比如: "'删除姓名为' + name + '的学生吗?'".</param>
		/// <param name="result">保存用户所选结果的变量的名称, 比如: "deleteIt", 如果设置为 null, 则不会保存用户选择的结果.</param>
		/// <returns>弹出确认框的脚本代码.</returns>
#endif
		#endregion
		public string Confirm ( string message, string result )
		{ return this.Confirm ( message, result, true ); }
		#region " Confirm "
#if EN
		/// <summary>
		/// Generate confirm method, and appends to the Code property.
		/// </summary>
		/// <param name="message">What needs to be confirmed, such as: "'Delete?'", can also be a expression, such as: "'Delete student ' + name".</param>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains confirm method.</returns>
#elif HANS
		/// <summary>
		/// 生成弹出确认框的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="message">需要确认的内容, 比如: "'确认删除吗?'", 也可以是计算表达式, 比如: "'删除姓名为' + name + '的学生吗?'".</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>弹出确认框的脚本代码.</returns>
#endif
		#endregion
		public string Confirm ( string message, bool isAppend )
		{ return this.Confirm ( message, null, isAppend ); }

		#region " Navigate "
#if EN
		/// <summary>
		/// Generate navigation scripts, and appends to the Code property.
		/// </summary>
		/// <param name="location">Url for navigation, for example: "'www.google.com.hk'", can also be a expressions, for example: "'www.' + mydomain + '.com'".</param>
		/// <returns>The script which contains navigation scripts.</returns>
#elif HANS
		/// <summary>
		/// 生成在自身窗口打开页面的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com.hk'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <returns>导航的脚本代码.</returns>
#endif
		#endregion
		public string Navigate ( string location )
		{ return this.Navigate ( location, NavigateOption.SelfWindow, true ); }
		#region " Navigate "
#if EN
		/// <summary>
		/// Generate navigation scripts, and appends to the Code property.
		/// </summary>
		/// <param name="location">Url for navigation, for example: "'www.google.com.hk'", can also be a expressions, for example: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">Navigation option, indicating where to display the page.</param>
		/// <returns>The script which contains navigation scripts.</returns>
#elif HANS
		/// <summary>
		/// 生成导航页面的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com.hk'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航的选项, 指示在自身还是新窗口中显示页面, 最终的代码中选项会使用单引号, 比如: '_blank'.</param>
		/// <returns>导航的脚本代码.</returns>
#endif
		#endregion
		public string Navigate ( string location, NavigateOption option )
		{ return this.Navigate ( location, option, true ); }
		#region " Navigate "
#if EN
		/// <summary>
		/// Generate navigation scripts, and appends to the Code property.
		/// </summary>
		/// <param name="location">Url for navigation, for example: "'www.google.com.hk'", can also be a expressions, for example: "'www.' + mydomain + '.com'".</param>
		/// <param name="isAppend">If true, the script appends to the Code property.</param>
		/// <returns>The script which contains navigation scripts.</returns>
#elif HANS
		/// <summary>
		/// 生成导航页面的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com.hk'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>导航的脚本代码.</returns>
#endif
		#endregion
		public string Navigate ( string location, bool isAppend )
		{ return this.Navigate ( location, NavigateOption.SelfWindow, isAppend ); }

		/// <summary>
		/// 生成弹出输入框并将用户选择的结果保存在脚本变量中的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'请输入姓名:'", 也可以是计算表达式, 比如: "'请输入' + something".</param>
		/// <param name="result">保存用户输入内容的变量的名称, 比如: "userName", 如果设置为 null, 则不会保存用户选择的结果.</param>
		/// <returns>弹出输入框的脚本代码.</returns>
		public string Prompt ( string message, string result )
		{ return this.Prompt ( message, null, result, true ); }
		/// <summary>
		/// 生成弹出输入框并将用户选择的结果保存在脚本变量中的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'请输入姓名:'", 也可以是计算表达式, 比如: "'请输入' + something".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'小明'", 也可以是计算表达式, 比如: "defaultName".</param>
		/// <param name="result">保存用户输入内容的变量的名称, 比如: "userName", 如果设置为 null, 则不会保存用户选择的结果.</param>
		/// <returns>弹出输入框的脚本代码.</returns>
		public string Prompt ( string message, string defaultValue, string result )
		{ return this.Prompt ( message, defaultValue, result, true ); }
		/// <summary>
		/// 生成弹出输入框并将用户选择的结果保存在脚本变量中的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'请输入姓名:'", 也可以是计算表达式, 比如: "'请输入' + something".</param>
		/// <param name="result">保存用户输入内容的变量的名称, 比如: "userName", 如果设置为 null, 则不会保存用户选择的结果.</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>弹出输入框的脚本代码.</returns>
		public string Prompt ( string message, string result, bool isAppend )
		{ return this.Prompt ( message, null, result, isAppend ); }

		/// <summary>
		/// 生成循环时钟返回句柄到变量的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <returns>循环时钟的脚本代码.</returns>
		public string SetInterval ( string runCode, int delay )
		{ return this.SetInterval ( runCode, delay, null, true ); }
		/// <summary>
		/// 生成循环时钟返回句柄到变量的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <param name="result">保存时钟句柄的变量的名称, 比如: "timer1", "window.MyTimer", 如果设置为 null, 则不会保存句柄.</param>
		/// <returns>循环时钟的脚本代码.</returns>
		public string SetInterval ( string runCode, int delay, string result )
		{ return this.SetInterval ( runCode, delay, result, true ); }
		/// <summary>
		/// 生成循环时钟返回句柄到变量的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>循环时钟的脚本代码.</returns>
		public string SetInterval ( string runCode, int delay, bool isAppend )
		{ return this.SetInterval ( runCode, delay, null, isAppend ); }

		/// <summary>
		/// 生成时钟返回句柄到变量的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <returns>时钟的脚本代码.</returns>
		public string SetTimeout ( string runCode, int delay )
		{ return this.SetTimeout ( runCode, delay, null, true ); }
		/// <summary>
		/// 生成时钟返回句柄到变量的脚本, 并追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <param name="result">保存时钟句柄的变量的名称, 比如: "timer1", "window.MyTimer", 如果设置为 null, 则不会保存句柄.</param>
		/// <returns>时钟的脚本代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result )
		{ return this.SetTimeout ( runCode, delay, result, true ); }
		/// <summary>
		/// 生成时钟返回句柄到变量的脚本, 并选择是否将脚本追加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发时运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位, 大于 0.</param>
		/// <param name="isAppend">如果为 true, 则将脚本追加到 Code 属性.</param>
		/// <returns>时钟的脚本代码.</returns>
		public string SetTimeout ( string runCode, int delay, bool isAppend )
		{ return this.SetTimeout ( runCode, delay, null, isAppend ); }
		#endregion

		#region " helper "
		/// <summary>
		/// 将 Code 属性中的脚本作为一个代码块写入指定的目标中, 代码块位于目标的头部. (Razor 中代码块的写入位置由此方法调用位置决定)
		/// </summary>
		/// <param name="holder">表示脚本写入目标的对象, 可以是 ASPXScriptHolder 或者 RazorScriptHolder, 分别表示 aspx 和 cshtml 页面.</param>
		public void Build ( ScriptHolder holder )
		{ this.Build ( holder, null, ScriptBuildOption.None ); }
		/// <summary>
		/// 将 Code 属性中的脚本作为一个代码块写入指定的目标中.
		/// </summary>
		/// <param name="holder">表示脚本写入目标的对象, 可以是 ASPXScriptHolder 或者 RazorScriptHolder, 分别表示 aspx 和 cshtml 页面.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效, Startup 表示在页面尾部写入代码块, 而 None 表示在页面头部写入. (此选项对 Razor 无效)</param>
		public void Build ( ScriptHolder holder, ScriptBuildOption option )
		{ this.Build ( holder, null, option ); }
		/// <summary>
		/// 将 Code 属性中的脚本作为一个代码块写入指定的目标中, 如果指定关键字的代码块已经在目标中存在, 则不写入.
		/// </summary>
		/// <param name="holder">表示脚本写入目标的对象, 可以是 ASPXScriptHolder 或者 RazorScriptHolder, 分别表示 aspx 和 cshtml 页面.</param>
		/// <param name="key">用于在生成过程中区分代码块的关键字.</param>
		public void Build ( ScriptHolder holder, string key )
		{ this.Build ( holder, key, ScriptBuildOption.None ); }
		#endregion

		#region " aspx "
		/// <summary>
		/// 为控件所在的 aspx 页面写入定义数组的脚本. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="control">控件, 其所在页面将写入定义数组的脚本.</param>
		/// <param name="arrayName">数组名称, 比如: "names".</param>
		public static void RegisterArray ( Control control, string arrayName )
		{ RegisterArray ( control, arrayName, null ); }

		/// <summary>
		/// 为 aspx 页面写入定义数组的脚本. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">将被写入定义数组脚本的页面.</param>
		/// <param name="arrayName">数组名称, 比如: "names".</param>
		public static void RegisterArray ( Page page, string arrayName )
		{ RegisterArray ( page, arrayName, null ); }

		/// <summary>
		/// 为控件所在的 aspx 页面添加脚本引用. (此方法对 Razor 无效)
		/// <param name="control">控件, 其所在页面将添加脚本引用.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		public static void RegisterInclude ( Control control, string url )
		{ RegisterInclude ( control, url, null ); }

		/// <summary>
		/// 为 aspx 页面添加脚本引用. (此方法对 Razor 无效)
		/// </summary>
		/// <param name="page">添加脚本引用的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		public static void RegisterInclude ( Page page, string url )
		{ RegisterInclude ( page, url, null ); }
		#endregion

#endif
	}

}

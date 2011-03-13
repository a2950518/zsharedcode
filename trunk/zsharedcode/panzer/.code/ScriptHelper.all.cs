/* allinone合并了多个文件,下载使用多个allinone代码,可能会遇到重复的类型定义,http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/ScriptHelper.all.cs */
using System;
using System.Web.UI;
using NControl = System.Web.UI.Control;
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
		/// 最为启动脚本.
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

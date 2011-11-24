/*
 * Author: M.S.cxc
 * Code Url: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * Version: .net 4.0
 * 
 * License: This file is an open source shared for free, you need to comply with panzer license http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt, please download the license and include it in your project and product.
 * 
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	#region " ScriptBuildOption "
#if EN
	/// <summary>
	/// Script compile options.
	/// </summary>
#elif HANS
	/// <summary>
	/// 脚本编译选项.
	/// </summary>
#endif
	#endregion
	public enum ScriptBuildOption
	{
		#region " None "
#if EN
		/// <summary>
		/// By default, with a script tag, normal script blocks, not end page processing.
		/// </summary>
#elif HANS
		/// <summary>
		/// 默认, 带有 script 标签, 普通脚本块, 不结束页面处理.
		/// </summary>
#endif
		#endregion
		None = 0,
		#region " EndResponse "
#if EN
		/// <summary>
		/// End page processing.
		/// </summary>
#elif HANS
		/// <summary>
		/// 结束页面处理.
		/// </summary>
#endif
		#endregion
		EndResponse = 1,
		#region " OnlyCode "
#if EN
		/// <summary>
		/// With no script tag.
		/// </summary>
#elif HANS
		/// <summary>
		/// 不带有 script 标签.
		/// </summary>
#endif
		#endregion
		OnlyCode = 2,
		#region " Startup "
#if EN
		/// <summary>
		/// As a startup script.
		/// </summary>
#elif HANS
		/// <summary>
		/// 做为启动脚本.
		/// </summary>
#endif
		#endregion
		Startup = 4
	}

}
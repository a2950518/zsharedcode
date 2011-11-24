/*
 * Author: M.S.cxc
 * Code Url: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * Version: .net 4.0
 * 
 * License: This file is an open source shared for free, you need to comply with panzer license http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt, please download the license and include it in your project and product.
 * 
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	#region " ScriptType "
#if EN
	/// <summary>
	/// Script type.
	/// </summary>
#elif HANS
	/// <summary>
	/// 脚本的类型.
	/// </summary>
#endif
	#endregion
	public enum ScriptType
	{

		#region " JavaScript "
#if EN
		/// <summary>
		/// JavaScript.
		/// </summary>
#elif HANS
		/// <summary>
		/// Java 脚本.
		/// </summary>
#endif
		#endregion
		JavaScript = 1,

		#region " VBScript "
#if EN
		/// <summary>
		/// VBScript.
		/// </summary>
#elif HANS
		/// <summary>
		/// VB 脚本.
		/// </summary>
#endif
		#endregion
		VBScript = 2
	}

}
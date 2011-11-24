/*
 * Author: M.S.cxc
 * Code Url: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * Version: .net 4.0
 * 
 * License: This file is an open source shared for free, you need to comply with panzer license http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt, please download the license and include it in your project and product.
 * 
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	#region " NavigateOption "
#if EN
	/// <summary>
	/// Navigation options.
	/// </summary>
#elif HANS
	/// <summary>
	/// 导航选项.
	/// </summary>
#endif
	#endregion
	public enum NavigateOption
	{
		#region " None "
#if EN
		/// <summary>
		/// None.
		/// </summary>
#elif HANS
		/// <summary>
		/// 空设置.
		/// </summary>
#endif
		#endregion
		None = 0,
		#region " NewWindow "
#if EN
		/// <summary>
		/// New window.
		/// </summary>
#elif HANS
		/// <summary>
		/// 新窗口.
		/// </summary>
#endif
		#endregion
		NewWindow = 1,
		#region " SelfWindow "
#if EN
		/// <summary>
		/// In its own window.
		/// </summary>
#elif HANS
		/// <summary>
		/// 在自身的窗口.
		/// </summary>
#endif
		#endregion
		SelfWindow = 2,
		#region " ParentWindow "
#if EN
		/// <summary>
		/// In the parent window.
		/// </summary>
#elif HANS
		/// <summary>
		/// 在父窗口中.
		/// </summary>
#endif
		#endregion
		ParentWindow = 3,
	}

}
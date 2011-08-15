/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.interface/ui/IWindow.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.ui
{

	/// <summary>
	/// 实现 WindowCore 类工作平台的功能.
	/// </summary>
	public interface IWindow
	{

		/// <summary>
		/// 获取实现 IWindow 的对象.
		/// </summary>
		object Platform 
		{ get; }

	}

}

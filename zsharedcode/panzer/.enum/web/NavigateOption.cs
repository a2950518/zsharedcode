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
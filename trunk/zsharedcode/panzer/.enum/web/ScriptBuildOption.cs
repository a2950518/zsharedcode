/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
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
		/// 做为启动脚本.
		/// </summary>
		Startup = 4
	}

}
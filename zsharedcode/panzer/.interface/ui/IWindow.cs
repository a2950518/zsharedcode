/*
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.interface/ui/IWindow.cs
 * 版本: 2.0, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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

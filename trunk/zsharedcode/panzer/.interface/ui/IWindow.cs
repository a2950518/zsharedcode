/*
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.interface/ui/IWindow.cs
 * 版本: 2.0, .net 4.0, 其它版本可能有所不同
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

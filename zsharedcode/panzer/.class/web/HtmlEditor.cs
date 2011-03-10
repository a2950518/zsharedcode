/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/HtmlEditor
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/HtmlEditor.cs
 * 版本: 1.2, .net 4.0, 其它版本可能有所不同
 * */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// Html 编辑器.
	/// </summary>
	public sealed class HtmlEditor
	{
		private readonly WebBrowser browser;

		/// <summary>
		/// 创建一个 Html 编辑器.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		public HtmlEditor ( WebBrowser browser )
		{

			if ( null == browser )
				throw new ArgumentNullException ( "browser", "浏览器控件不能为空" );

			this.browser = browser;
		}

		public void BackColor ( Color color )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "BackColor", true, color );
		}

	}

}

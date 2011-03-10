/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/HtmlEditHelper
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/HtmlEditHelper.cs
 * 版本: 1.2, .net 4.0, 其它版本可能有所不同
 * */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// Html 编辑器.
	/// </summary>
	public sealed partial class HtmlEditHelper
	{
		private readonly WebBrowser browser;

		/// <summary>
		/// 创建一个 Html 编辑器, 编辑页面地址为 "html.editor.htm".
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		public HtmlEditHelper ( WebBrowser browser )
			: this(browser, null)
		{ }
		/// <summary>
		/// 创建一个 Html 编辑器.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="editorUrl">编辑器页面地址.</param>
		public HtmlEditHelper ( WebBrowser browser, string editorUrl )
		{

			if ( null == browser )
				throw new ArgumentNullException ( "browser", "浏览器控件不能为空" );

			if ( string.IsNullOrEmpty ( editorUrl ) )
				editorUrl = @"html.editor.htm";

			try
			{ browser.Navigate ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory, editorUrl ) ); }
			catch { }

			this.browser = browser;
		}

		/// <summary>
		/// 设置选中内容的背景色.
		/// </summary>
		/// <param name="color">背景色.</param>
		public void BackColor ( Color color )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "BackColor", true, color );
		}

		/// <summary>
		/// 切换选中内容是否粗体.
		/// </summary>
		public void Bold ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Bold", true, null );
		}

		/// <summary>
		/// 复制选中内容.
		/// </summary>
		public void Copy ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Copy", true, null );
		}

		/// <summary>
		/// 剪切选中内容.
		/// </summary>
		public void Cut ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Cut", true, null );
		}

		/// <summary>
		/// 删除选中内容.
		/// </summary>
		public void Delete ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Delete", true, null );
		}

		/// <summary>
		/// 设置选中内容的字体.
		/// </summary>
		public void FontName ( Font font )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "FontName", true, font );
		}

		/// <summary>
		/// 设置选中内容的字体.
		/// </summary>
		public void FontSize ( Font font )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "FontSize", true, font );
		}

	}
	
	partial class HtmlEditor
	{
#if !PARAM
#endif
	}

}

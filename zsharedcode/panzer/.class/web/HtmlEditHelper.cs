/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/HtmlEditHelper.cs
 * 版本: 1.2, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */
using System;
using System.Drawing;
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
		/// 获取或设置编辑器中的 html 代码.
		/// </summary>
		public string Html
		{
			get
			{

				if ( null == this.browser.Document || null == this.browser.Document.GetElementById ( "html" ) )
					return string.Empty;

				return this.browser.Document.GetElementById ( "html" ).InnerHtml;
			}
			set
			{

				if ( null != this.browser.Document && null != value && null == this.browser.Document.GetElementById ( "html" ) )
					this.browser.Document.GetElementById ( "html" ).InnerHtml = value;

			}
		}

#if PARAM
		/// <summary>
		/// 创建一个 Html 编辑器.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="editorUrl">编辑器页面地址, 默认使用本地编辑器.</param>
		public HtmlEditHelper ( WebBrowser browser, string editorUrl = null )
#else
		/// <summary>
		/// 创建一个 Html 编辑器.
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		/// <param name="editorUrl">编辑器页面地址.</param>
		public HtmlEditHelper ( WebBrowser browser, string editorUrl )
#endif
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
		/// 设置选中内容的前景色.
		/// </summary>
		/// <param name="color">前景色.</param>
		public void ForeColor ( Color color )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "ForeColor", true, color );
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
		/// 切换选中内容是否斜体.
		/// </summary>
		public void Italic ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Italic", true, null );
		}

		/// <summary>
		/// 切换选中内容是否有下划线.
		/// </summary>
		public void Underline ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Underline", true, null );
		}

		/// <summary>
		/// 撤销.
		/// </summary>
		public void Undo ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Undo", true, null );
		}

		/// <summary>
		/// 增加缩进.
		/// </summary>
		public void Indent ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Indent", true, null );
		}

		/// <summary>
		/// 减少缩进.
		/// </summary>
		public void Outdent ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Outdent", true, null );
		}

		/// <summary>
		/// 清楚样式.
		/// </summary>
		public void RemoveFormat ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "RemoveFormat", true, null );
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
		/// 粘贴.
		/// </summary>
		public void Paste ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Paste", true, null );
		}

		/// <summary>
		/// 居中.
		/// </summary>
		public void JustifyCenter ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "JustifyCenter", true, null );
		}

		/// <summary>
		/// 居左.
		/// </summary>
		public void JustifyLeft ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "JustifyLeft", true, null );
		}

		/// <summary>
		/// 居右.
		/// </summary>
		public void JustifyRight ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "JustifyRight", true, null );
		}

		/// <summary>
		/// 插入段落.
		/// </summary>
		public void InsertParagraph ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "InsertParagraph", true, null );
		}

		/// <summary>
		/// 插入顺序列表.
		/// </summary>
		public void InsertOrderedList ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "InsertOrderedList", true, null );
		}

		/// <summary>
		/// 插入非顺序列表.
		/// </summary>
		public void InsertUnorderedList ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "InsertUnorderedList", true, null );
		}

		/// <summary>
		/// 插入图片.
		/// </summary>
		public void InsertImage ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "InsertImage", true, null );
		}

		/// <summary>
		/// 插入超链接.
		/// </summary>
		public void CreateLink ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "CreateLink", true, null );
		}

		/// <summary>
		/// 取消超链接.
		/// </summary>
		public void Unlink ( )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "Unlink", true, null );
		}

		/// <summary>
		/// 设置选中内容的字体.
		/// </summary>
		/// <param name="name">设置的字体名称.</param>
		public void FontName ( string name )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "FontName", true, name );
		}

		/// <summary>
		/// 设置选中内容的字体.
		/// </summary>
		/// <param name="size">设置的字体大小.</param>
		public void FontSize ( int size )
		{

			if ( null == this.browser.Document )
				return;

			this.browser.Document.ExecCommand ( "FontSize", true, size );
		}

	}

	partial class HtmlEditHelper
	{
#if !PARAM
		/// <summary>
		/// 创建一个 Html 编辑器, 编辑页面地址为 "html.editor.htm".
		/// </summary>
		/// <param name="browser">WebBrowser 控件.</param>
		public HtmlEditHelper ( WebBrowser browser )
			: this ( browser, null )
		{ }
#endif
	}

}

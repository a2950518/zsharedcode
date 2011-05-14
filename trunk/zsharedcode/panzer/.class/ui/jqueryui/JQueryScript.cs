/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryScript
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryScript.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;

// HACK: 避免在 allinone 文件中的名称冲突
using NBorderStyle = System.Web.UI.WebControls.BorderStyle;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " JQueryScript "
	/// <summary>
	/// 实现 jQuery UI 的服务器控件.
	/// </summary>
	// [DefaultProperty ( "Html" )]
	[ToolboxData ( "<{0}:JQueryScript runat=server></{0}:JQueryScript>" )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public class JQueryScript
		: WebControl, INamingContainer
	{

		private readonly PlaceHolder html = new PlaceHolder ( );

		/// <summary>
		/// 获取 PlaceHolder 控件, 其中包含了元素中包含的 script 标签的代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置元素中包含的 script 标签的代码" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Html
		{
			get { return this.html; }
		}

		#region " hide "

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override string AccessKey
		{
			get { return string.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Color BackColor
		{
			get { return Color.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Color BorderColor
		{
			get { return Color.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override NBorderStyle BorderStyle
		{
			get { return NBorderStyle.None; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Unit BorderWidth
		{
			get { return Unit.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override bool Enabled
		{
			get { return true; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override bool EnableTheming
		{
			get { return false; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override FontInfo Font
		{
			get { return base.Font; }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Color ForeColor
		{
			get { return Color.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override string SkinID
		{
			get { return string.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override short TabIndex
		{
			get { return -1; }
			set { }
		}

		#endregion

		/// <summary>
		/// 创建一个 JQueryScript.
		/// </summary>
		public JQueryScript ( )
			: base ( )
		{ this.EnableViewState = false; }

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.Visible || this.html.Controls.Count != 1)
				return;

			LiteralControl literal = this.html.Controls[0] as LiteralControl;

			if ( null == literal )
				return;

			literal.Text = JQueryCoder.Encode ( this, literal.Text );

			this.html.RenderControl ( writer );
		}

	}
	#endregion

}

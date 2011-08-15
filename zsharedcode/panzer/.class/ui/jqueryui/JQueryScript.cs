/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryScript.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " JQueryScript "
	/// <summary>
	/// 可在其中编写内嵌语法的客户端脚本的服务器控件.
	/// </summary>
	[ToolboxData ( "<{0}:JQueryScript runat=server></{0}:JQueryScript>" )]
	[ParseChildren ( true, "Template" )]
	[DefaultProperty ( "Template" )]
	public class JQueryScript
		: Control, INamingContainer
	{
		private readonly PlaceHolder template = new PlaceHolder ( );

		/// <summary>
		/// 获取 PlaceHolder 控件, 其中包含了元素中包含的 script 标签的代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "脚本" )]
		[Description ( "设置元素中包含的 script 标签的代码" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerDefaultProperty )]
		public PlaceHolder Template
		{
			get { return this.template; }
		}

		#region " hide "
#if V4
		[Browsable ( false )]
		public override ClientIDMode ClientIDMode
		{
			get { return base.ClientIDMode; }
			set { base.ClientIDMode = value; }
		}
		[Browsable ( false )]
		public override ViewStateMode ViewStateMode
		{
			get { return base.ViewStateMode; }
			set { base.ViewStateMode = value; }
		}
#endif
		[Browsable ( false )]
		public override bool EnableViewState
		{
			get { return base.EnableViewState; }
			set { base.EnableViewState = value; }
		}
		[Browsable ( false )]
		public override bool Visible
		{
			get { return base.Visible; }
			set { base.Visible = value; }
		}
		#endregion

		private bool isFaceless ( )
		{ return this.DesignMode; }

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.Visible || this.template.Controls.Count != 1 )
				return;

			if ( this.isFaceless ( ) )
				writer.Write ( "<span style=\"font-family: Verdana; background-color: #FFFFFF; font-size: 10pt;\"><strong>{0}:</strong> {1}</span>", "JQueryScript", this.ID );

			LiteralControl literal = this.template.Controls[0] as LiteralControl;

			if ( null == literal )
				return;

			literal.Text = JQueryCoder.Encode ( this, literal.Text );

			if ( this.isFaceless ( ) )
				writer.Write ( " <span style=\"font-family: Verdana; background-color: #FFFFFF; color: #660066; font-size: 10pt;\">{0}</span>", literal.Text.Length );
			else
				this.template.RenderControl ( writer );

		}

	}
	#endregion

}

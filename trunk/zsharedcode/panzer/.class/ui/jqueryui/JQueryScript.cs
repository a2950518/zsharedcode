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
	[ParseChildren ( true )]
	public class JQueryScript
		: Control, INamingContainer
	{
		private ITemplate contentTemplate;

		/// <summary>
		/// 获取或设置内部 html 代码的模板. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate ContentTemplate
		{
			get { return this.contentTemplate; }
			set { this.contentTemplate = value; }
		}

		private bool isFaceless ( )
		{ return this.DesignMode; }

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.Visible )
				return;

			if ( this.isFaceless ( ) )
				writer.Write ( "<span style=\"font-family: Verdana; background-color: #FFFFFF; font-size: 10pt;\"><strong>{0}:</strong> {1}</span>", "JQueryScript", this.ID );

			if ( null != this.contentTemplate )
			{
				this.Controls.Clear ( );
				Literal content = new Literal ( );
				this.contentTemplate.InstantiateIn ( content );

				content.Text = JQueryCoder.Encode ( this, content.Text );
				writer.Write ( content.Text );
			}

		}

		/*
		protected override void CreateChildControls ( )
		{

			if ( null == this.contentTemplate )
			{
				base.CreateChildControls ( );
				return;
			}

			this.Controls.Clear ( );
			Literal content = new Literal ( );
			this.contentTemplate.InstantiateIn ( content );

			content.Text = JQueryCoder.Encode ( this, content.Text );

			this.Controls.Add ( content );
		}
		*/

	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ScriptPackage.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 将输出多个控件产生的客户端脚本的控件.
	/// </summary>
	[ToolboxData ( "<{0}:ScriptPackage runat=server></{0}:ScriptPackage>" )]
	public sealed class ScriptPackage
		: WebControl, INamingContainer
	{
		private string code = string.Empty;
		private List<string> elements = new List<string> ( );

		/// <summary>
		/// 获取或设置脚本内容. 
		/// </summary>
		[Category ( "脚本" )]
		[Description ( "脚本内容" )]
		[DefaultValue ( "" )]
		public string Code
		{
			get { return this.code; }
			set
			{

				if ( null != value )
					this.code = value;

			}
		}

		protected override HtmlTextWriterTag TagKey
		{
			get
			{

				if ( this.isFaceless ( ) )
					return HtmlTextWriterTag.Code;
				else
					return HtmlTextWriterTag.Script;

			}
		}

		private bool isFaceless ( )
		{ return this.DesignMode; }

		protected override void AddAttributesToRender ( HtmlTextWriter writer )
		{
			base.AddAttributesToRender ( writer );

			writer.AddAttribute ( HtmlTextWriterAttribute.Type, "text/javascript" );
		}

		protected override void RenderContents ( HtmlTextWriter writer )
		{
			base.RenderContents ( writer );

			if ( this.isFaceless ( ) )
				writer.Write ( "<span style=\"font-family: Verdana; background-color: #FFFFFF\"><strong>{0}:</strong> {1}</span>", "ScriptPackage", this.ID );
			else
				writer.Write ( this.code );

		}

	}

}

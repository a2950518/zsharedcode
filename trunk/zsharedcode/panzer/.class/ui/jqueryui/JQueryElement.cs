using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 页面元素的类型.
	/// </summary>
	public enum ElementType
	{
		/// <summary>
		/// 没有任何页面元素.
		/// </summary>
		None = 0,
		/// <summary>
		/// div 元素.
		/// </summary>
		Div = 1,
		/// <summary>
		/// span 元素.
		/// </summary>
		Span = 2
	}

	/// <summary>
	/// 实现 jQuery UI 的服务器控件.
	/// </summary>
	[DefaultProperty("Text")]
	[ToolboxData ( "<{0}:JQueryUI runat=server></{0}:JQueryUI>" )]
	[ParseChildren ( false )]
	public class JQueryElement
		: Control, INamingContainer
	{
		private ElementType elementType;

		private bool isDraggable;

		/// <summary>
		/// 获取或设置元素是否可以拖动.
		/// </summary>
		[Category("行为")]
		[DefaultValue(typeof(bool), "false")]
		private bool IsDraggable
		{
			get { return this.isDraggable; }
			set { this.isDraggable = value; }
		}

		/// <summary>
		/// 获取或设置元素的类型.
		/// </summary>
		[Category("基本")]
		[DefaultValue(typeof(ElementType), "None")]
		public ElementType ElementType
		{
			get { return this.elementType; }
			set { this.elementType = value; }
		}

		protected override void Render ( HtmlTextWriter writer )
		{
			JQuery jquery = new JQuery ( string.Format ( "'#{0}'", this.ClientID ) );

			if(this.elementType != ElementType.None)
				writer.Write ( "<{0} id={1}>", this.elementType.ToString().ToLower(), this.ClientID );

			base.Render ( writer );

			if ( this.elementType != ElementType.None )
				writer.Write ( "</{0}>", this.elementType.ToString ( ).ToLower ( ) );

			if ( this.isDraggable )
				;

			jquery.Code = "$(function(){" + jquery.Code + "});";
			jquery.Build ( this, this.ClientID, ScriptBuildOption.Startup );
		}

	}

}

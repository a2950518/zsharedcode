/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Accordion.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 折叠列表插件.
	/// </summary>
	[ToolboxData ( "<{0}:Accordion runat=server></{0}:Accordion>" )]
	public class Accordion
		: JQueryWidget<AccordionSetting>, IPostBackEventHandler
	{

		/// <summary>
		/// 创建一个 jQuery UI 日期框.
		/// </summary>
		public Accordion ( )
			: base ( new AccordionSetting ( ), HtmlTextWriterTag.Div )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置折叠列表是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示折叠列表是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置被激活的列表, 对应数值, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示被激活的列表, 对应数值, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public int Active
		{
			get { return this.uiSetting.Active; }
			set { this.uiSetting.Active = value; }
		}

		/// <summary>
		/// 获取或设置列表切换的动画, 比如: "bounceslide", 默认为 "slide".
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "slide" )]
		[Description ( "指示列表切换的动画, 比如: bounceslide, 默认为 slide" )]
		[NotifyParentProperty ( true )]
		public string Animated
		{
			get { return this.uiSetting.Animated; }
			set { this.uiSetting.Animated = value; }
		}

		/// <summary>
		/// 获取或设置是否自动调整与最高的列表同高, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( true )]
		[Description ( "指示是否自动调整与最高的列表同高, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool AutoHeight
		{
			get { return this.uiSetting.AutoHeight; }
			set { this.uiSetting.AutoHeight = value; }
		}

		/// <summary>
		/// 获取或设置是否在动画结束后清除 height, overflow 样式, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否在动画结束后清除 height, overflow 样式, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ClearStyle
		{
			get { return this.uiSetting.ClearStyle; }
			set { this.uiSetting.ClearStyle = value; }
		}

		/// <summary>
		/// 获取或设置是否关闭所有的列表, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否关闭所有的列表, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Collapsible
		{
			get { return this.uiSetting.Collapsible; }
			set { this.uiSetting.Collapsible = value; }
		}

		/// <summary>
		/// 获取或设置触发列表的事件, 默认为 click.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( EventType.click )]
		[Description ( "指示触发列表的事件, 默认为 click" )]
		[NotifyParentProperty ( true )]
		public EventType Event
		{
			get { return this.uiSetting.Event; }
			set { this.uiSetting.Event = value; }
		}

		/// <summary>
		/// 获取或设置是否以父容器填充高度, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否以父容器填充高度, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool FillSpace
		{
			get { return this.uiSetting.FillSpace; }
			set { this.uiSetting.FillSpace = value; }
		}

		/// <summary>
		/// 获取或设置作为标题的元素, 可以是选择器, 默认为 "> li > :first-child, > :not(li):even".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "> li > :first-child, > :not(li):even" )]
		[Description ( "指示作为标题的元素, 可以是选择器, 默认为 > li > :first-child, > :not(li):even" )]
		[NotifyParentProperty ( true )]
		public string Header
		{
			get { return this.uiSetting.Header; }
			set { this.uiSetting.Header = value; }
		}

		/// <summary>
		/// 获取或设置列表显示的图标, 默认为: "{ 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "{ 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }" )]
		[Description ( "指示列表显示的图标, 默认为: { 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }" )]
		[NotifyParentProperty ( true )]
		public string Icons
		{
			get { return this.uiSetting.Icons; }
			set { this.uiSetting.Icons = value; }
		}

		/// <summary>
		/// 获取或设置是否可以导航, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否可以导航, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Navigation
		{
			get { return this.uiSetting.Navigation; }
			set { this.uiSetting.Navigation = value; }
		}

		/// <summary>
		/// 获取或设置选择导航的函数, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择导航的函数, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string NavigationFilter
		{
			get { return this.uiSetting.NavigationFilter; }
			set { this.uiSetting.NavigationFilter = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置列表被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置列表改变时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.uiSetting.Change; }
			set { this.uiSetting.Change = value; }
		}

		/// <summary>
		/// 获取或设置列表开始改变时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表开始改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Changestart
		{
			get { return this.uiSetting.Changestart; }
			set { this.uiSetting.Changestart = value; }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取 Change 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Change 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting ChangeAsync
		{
			get { return this.uiSetting.ChangeAsync; }
		}
		#endregion

		#region " server "
		/// <summary>
		/// 在服务器端执行的选中列表改变事件.
		/// </summary>
		[Description ( "指示选中列表改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event AccordionChangeEventHandler ChangeSync;
		#endregion

		protected override bool isFaceless ( )
		{ return this.DesignMode && ( this.selector != string.Empty || this.html == string.Empty ); }

		protected override bool isFace ( )
		{ return this.DesignMode && this.selector == string.Empty && this.html != string.Empty; }

		protected override string facelessPrefix ( )
		{ return "Accordion"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.Active != 0 )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Active );

			if ( this.Collapsible )
				postfix += " <span style=\"color: #660066\">collapsible</span>";

			if ( this.FillSpace )
				postfix += " <span style=\"color: #660066\">fillSpace</span>";

			return base.facelessPostfix ( ) + postfix;
		}

		protected override void AddAttributesToRender ( HtmlTextWriter writer )
		{
			base.AddAttributesToRender ( writer );

			if ( this.isFace ( ) )
				writer.AddAttribute ( HtmlTextWriterAttribute.Class,
					string.Format (
					"ui-accordion ui-widget ui-helper-reset ui-accordion-icons{0}",
					this.Disabled ? " ui-accordion-disabled ui-state-disabled" : string.Empty
					)
					);

		}

		protected override void RenderContents ( HtmlTextWriter writer )
		{

			if ( null != this.ChangeSync )
				this.Change = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "change;[%':ui.options.active%]" ) + "}";

			base.RenderContents ( writer );
		}

		private void onChange ( AccordionEventArgs e )
		{ this.Active = e.Active; }

		public void RaisePostBackEvent ( string eventArgument )
		{

			if ( string.IsNullOrEmpty ( eventArgument ) )
				return;

			string[] parts = eventArgument.Split ( ';' );

			switch ( parts[0] )
			{
				case "change":

					if ( null != this.ChangeSync )
					{
						AccordionEventArgs e = new AccordionEventArgs ( StringConvert.ToObject<int> ( parts[1] ) );

						this.onChange ( e );
						this.ChangeSync ( this, e );
					}

					break;
			}

		}

		/*
		protected override void Render ( HtmlTextWriter writer )
		{

			if ( this.selector == string.Empty )
				switch ( this.uiSetting.Type )
				{
					case WidgetType.accordion:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );

						string html = string.Empty;

						if ( this.html.Controls.Count != 0 )
							try
							{
								// HACK: 这里也可以使用 panzer 的 Xml 类.
								html = ( this.html.Controls[0] as System.Web.UI.LiteralControl ).Text.Replace ( "__designer:", string.Empty );

								XmlDocument xml = new XmlDocument ( );
								xml.LoadXml ( string.Format ( "<html>{0}</html>", html ) );


								//foreach(XmlNode node in xml.FirstChild.ChildNodes)

								for ( int index = 0; index < xml.FirstChild.ChildNodes.Count; index++ )
									if ( index % 2 == 0 )
									{
										xml.FirstChild.ChildNodes[index].Attributes.Append ( xml.CreateAttribute ( "class" ) ).Value = string.Format ( "ui-accordion-header ui-helper-reset ui-state-{0} ui-corner-top", this.Active == index / 2 ? "active" : "default" );
										xml.FirstChild.ChildNodes[index].InnerXml = string.Format ( "<span class=\"ui-icon ui-icon-triangle-1-{0}\"></span>", this.Active == index / 2 ? "s" : "e" ) + xml.FirstChild.ChildNodes[index].InnerXml;
									}
									else
									{
										xml.FirstChild.ChildNodes[index].Attributes.Append ( xml.CreateAttribute ( "class" ) ).Value = string.Format ( "ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content-{0}", this.Active == ( index - 1 ) / 2 ? "active" : "default" );
										xml.FirstChild.ChildNodes[index].Attributes.Append ( xml.CreateAttribute ( "style" ) ).Value = string.Format ( "height: auto; overflow: auto; padding-top: 17.6px; padding-bottom: 17.6px; display: {0};", this.Active == ( index - 1 ) / 2 ? "block" : "none" );
									}

								html = xml.FirstChild.InnerXml;
							}
							catch ( Exception err ) { html = err.Message; }

						writer.Write (
							"<{6} id=\"{0}\" class=\"{3}ui-accordion ui-widget ui-helper-reset ui-accordion-icons{2}\" style=\"{4}\" title=\"{5}\">{1}</{6}>",
							this.ClientID,
							html,
							this.Disabled ? " ui-accordion-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( )
							);
						return;
				}

			base.Render ( writer );
		}
		*/

	}

	/// <summary>
	/// 折叠列表选中索引改变事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void AccordionChangeEventHandler ( object sender, AccordionEventArgs e );

	/// <summary>
	/// 折叠列表事件参数.
	/// </summary>
	public sealed class AccordionEventArgs
	{
		/// <summary>
		/// 索引.
		/// </summary>
		public readonly int Active;

		/// <summary>
		/// 创建一个折叠列表事件参数.
		/// </summary>
		/// <param name="active">索引.</param>
		public AccordionEventArgs ( int active )
		{

			if ( active < 0 )
				active = 0;

			this.Active = active;
		}

	}

}

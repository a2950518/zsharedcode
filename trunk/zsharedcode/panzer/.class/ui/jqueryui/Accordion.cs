/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAccordion
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Accordion.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 折叠列表插件.
	/// </summary>
	[ToolboxData ( "<{0}:Accordion runat=server></{0}:Accordion>" )]
	[DesignerAttribute ( typeof ( AccordionDesigner ) )]
	public class Accordion
		: BaseWidget, IPostBackEventHandler
	{
		private readonly AjaxSettingEdit changeAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 折叠列表.
		/// </summary>
		public Accordion ( )
			: base ( WidgetType.accordion )
		{ this.elementType = ElementType.Div; }

		#region " Option "
		/// <summary>
		/// 获取或设置折叠列表是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示折叠列表是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.AccordionSetting.Disabled, false ); }
			set { this.widgetSetting.AccordionSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置被激活的列表, 对应一个选择器, 元素, 数值或者布尔值.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示被激活的列表, 对应一个选择器, 元素, 数值或者布尔值" )]
		[NotifyParentProperty ( true )]
		public int Active
		{
			get { return this.getInteger ( this.widgetSetting.AccordionSetting.Active, 0 ); }
			set { this.widgetSetting.AccordionSetting.Active = value <= 0 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置列表切换的动画, 比如: bounceslide, slide.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表切换的动画, 比如: bounceslide, slide" )]
		[NotifyParentProperty ( true )]
		public string Animated
		{
			get { return this.widgetSetting.AccordionSetting.Animated.Trim ( '\'' ); }
			set { this.widgetSetting.AccordionSetting.Animated = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否自动调整与最高的列表同高, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( true )]
		[Description ( "指示是否自动调整与最高的列表同高, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool AutoHeight
		{
			get { return this.getBoolean ( this.widgetSetting.AccordionSetting.AutoHeight, true ); }
			set { this.widgetSetting.AccordionSetting.AutoHeight = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否在动画结束后清除 height, overflow 样式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否在动画结束后清除 height, overflow 样式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ClearStyle
		{
			get { return this.getBoolean ( this.widgetSetting.AccordionSetting.ClearStyle, false ); }
			set { this.widgetSetting.AccordionSetting.ClearStyle = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否关闭所有的列表, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否关闭所有的列表, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Collapsible
		{
			get { return this.getBoolean ( this.widgetSetting.AccordionSetting.Collapsible, false ); }
			set { this.widgetSetting.AccordionSetting.Collapsible = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置触发列表的事件, 比如: mouseover.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( EventType.click )]
		[Description ( "指示触发列表的事件, 比如: mouseover" )]
		[NotifyParentProperty ( true )]
		public EventType Event
		{
			get { return this.getEnum<EventType> ( this.widgetSetting.AccordionSetting.Event, EventType.click ); }
			set { this.widgetSetting.AccordionSetting.Event = "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否以父容器填充高度, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否以父容器填充高度, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool FillSpace
		{
			get { return this.getBoolean ( this.widgetSetting.AccordionSetting.FillSpace, false ); }
			set { this.widgetSetting.AccordionSetting.FillSpace = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置作为标题的元素, 可以是选择器, 默认为 > li > :first-child, > :not(li):even.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示作为标题的元素, 可以是选择器, 默认为 > li > :first-child, > :not(li):even" )]
		[NotifyParentProperty ( true )]
		public string Header
		{
			get { return this.widgetSetting.AccordionSetting.Header.Trim ( '\'' ); }
			set { this.widgetSetting.AccordionSetting.Header = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置列表显示的图标, 默认为: { 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表显示的图标, 默认为: { 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }" )]
		[NotifyParentProperty ( true )]
		public string Icons
		{
			get { return this.widgetSetting.AccordionSetting.Icons; }
			set { this.widgetSetting.AccordionSetting.Icons = value; }
		}

		/// <summary>
		/// 获取或设置是否可以导航, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否可以导航, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Navigation
		{
			get { return this.getBoolean ( this.widgetSetting.AccordionSetting.Navigation, false ); }
			set { this.widgetSetting.AccordionSetting.Navigation = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置选择导航的函数.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择导航的函数" )]
		[NotifyParentProperty ( true )]
		public string NavigationFilter
		{
			get { return this.widgetSetting.AccordionSetting.NavigationFilter.Trim ( '\'' ); }
			set { this.widgetSetting.AccordionSetting.NavigationFilter = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置列表被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.AccordionSetting.Create; }
			set { this.widgetSetting.AccordionSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置列表改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.widgetSetting.AccordionSetting.Change; }
			set { this.widgetSetting.AccordionSetting.Change = value; }
		}

		/// <summary>
		/// 获取或设置列表开始改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表开始改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Changestart
		{
			get { return this.widgetSetting.AccordionSetting.Changestart; }
			set { this.widgetSetting.AccordionSetting.Changestart = value; }
		}
		#endregion

		#region " Ajax "
		/// <summary>
		/// 获取 Change 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Change 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSettingEdit ChangeAsync
		{
			get { return this.changeAjax; }
		}
		#endregion

		#region " Server "
		/// <summary>
		/// 在服务器端执行的选中列表改变事件.
		/// </summary>
		[Description ( "指示选中列表改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event AccordionChangeEventHandler ChangeSync;
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.AccordionSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.changeAjax.Url != string.Empty )
				{
					this.changeAjax.WidgetEventType = EventType.accordionchange;
					this.widgetSetting.AjaxSettings.Add ( this.changeAjax );
				}

				if ( null != this.ChangeSync )
					this.Change = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "change;[%':ui.options.active%]" ) + "}";

			}
			else if ( this.selector == string.Empty )
				switch ( this.widgetSetting.Type )
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

	}

	#region " AccordionDesigner "
	/// <summary>
	/// 折叠列表设计器.
	/// </summary>
	public class AccordionDesigner : JQueryElementDesigner
	{

		/// <summary>
		/// 获取行为列表.
		/// </summary>
		public override DesignerActionListCollection ActionLists
		{
			get { return new DesignerActionListCollection ( ); }
		}

	}
	#endregion

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

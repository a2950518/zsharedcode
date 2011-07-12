/* allinone合并了多个文件,下载使用多个allinone代码,可能会遇到重复的类型定义,http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/JQueryElement.all.cs */
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Globalization;
using NParameter = zoyobar.shared.panzer.web.jqueryui.Parameter;
using System.Net;
using zoyobar.shared.panzer.web;
using NBorderStyle = System.Web.UI.WebControls.BorderStyle;
using System.Reflection;
using System.Web;
using NControl = System.Web.UI.Control;
// ../.class/ui/jqueryui/Accordion.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAccordion
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Accordion.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 折叠列表插件.
	/// </summary>
	[ToolboxData ( "<{0}:Accordion runat=server></{0}:Accordion>" )]
	[Designer ( typeof ( AccordionDesigner ) )]
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
// ../.class/ui/jqueryui/Autocomplete.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAutocomplete
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Autocomplete.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 自动填充插件.
	/// </summary>
	[ToolboxData ( "<{0}:Autocomplete runat=server></{0}:Autocomplete>" )]
	[Designer ( typeof ( AutocompleteDesigner ) )]
	public class Autocomplete
		: BaseWidget
	{
		private readonly AjaxSettingEdit changeAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 自动填充.
		/// </summary>
		public Autocomplete ( )
			: base ( WidgetType.autocomplete )
		{ this.elementType = ElementType.Input; }

		#region " Option "
		/// <summary>
		/// 获取或设置自动填充是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示自动填充是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.AutocompleteSetting.Disabled, false ); }
			set { this.widgetSetting.AutocompleteSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置填充对应的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充对应的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.widgetSetting.AutocompleteSetting.AppendTo.Trim ( '\'' ); }
			set { this.widgetSetting.AutocompleteSetting.AppendTo = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否自动对焦到第一个条目, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否自动对焦到第一个条目, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool AutoFocus
		{
			get { return this.getBoolean ( this.widgetSetting.AutocompleteSetting.AutoFocus, false ); }
			set { this.widgetSetting.AutocompleteSetting.AutoFocus = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的激活自动填充的延迟, 比如: 300.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 300 )]
		[Description ( "指示以毫秒为单位的激活自动填充的延迟, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public int Delay
		{
			get { return this.getInteger ( this.widgetSetting.AutocompleteSetting.Delay, 300 ); }
			set { this.widgetSetting.AutocompleteSetting.Delay = value <= 0 || value == 300 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置激活填充需要最小的输入字符数, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示激活填充需要最小的输入字符数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public int MinLength
		{
			get { return this.getInteger ( this.widgetSetting.AutocompleteSetting.MinLength, 1 ); }
			set { this.widgetSetting.AutocompleteSetting.MinLength = value <= 1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.widgetSetting.AutocompleteSetting.Position; }
			set { this.widgetSetting.AutocompleteSetting.Position = value; }
		}

		/// <summary>
		/// 获取或设置用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数" )]
		[NotifyParentProperty ( true )]
		public string Source
		{
			get { return this.widgetSetting.AutocompleteSetting.Source; }
			set { this.widgetSetting.AutocompleteSetting.Source = value; }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置填充被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.AutocompleteSetting.Create; }
			set { this.widgetSetting.AutocompleteSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置搜索匹配项时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示搜索匹配项时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Search
		{
			get { return this.widgetSetting.AutocompleteSetting.Search; }
			set { this.widgetSetting.AutocompleteSetting.Search = value; }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.widgetSetting.AutocompleteSetting.Open; }
			set { this.widgetSetting.AutocompleteSetting.Open = value; }
		}

		/// <summary>
		/// 获取或设置获得焦点时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public new string Focus
		{
			get { return this.widgetSetting.AutocompleteSetting.Focus; }
			set { this.widgetSetting.AutocompleteSetting.Focus = value; }
		}

		/// <summary>
		/// 获取或设置选择某个条目的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择某个条目的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.widgetSetting.AutocompleteSetting.Select; }
			set { this.widgetSetting.AutocompleteSetting.Select = value; }
		}

		/// <summary>
		/// 获取或设置列表关闭时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.widgetSetting.AutocompleteSetting.Close; }
			set { this.widgetSetting.AutocompleteSetting.Close = value; }
		}

		/// <summary>
		/// 获取或设置选择的条目改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择的条目改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.widgetSetting.AutocompleteSetting.Change; }
			set { this.widgetSetting.AutocompleteSetting.Change = value; }
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

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.AutocompleteSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.changeAjax.Url != string.Empty )
				{
					this.changeAjax.WidgetEventType = EventType.click;
					this.widgetSetting.AjaxSettings.Add ( this.changeAjax );
				}

			}
			else if ( string.IsNullOrEmpty ( this.selector ) )
				switch ( this.widgetSetting.Type )
				{
					case WidgetType.autocomplete:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );

						writer.Write (
							"<{5} id=\"{0}\" type=\"textbox\" class=\"{2}ui-autocomplete-input{1}\" style=\"{3}\" title=\"{4}\"/>",
							this.ClientID,
							this.Disabled ? " ui-autocomplete-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( )
							);
						return;
				}

			base.Render ( writer );
		}

	}

	#region " AutocompleteDesigner "
	/// <summary>
	/// 自动填充设计器.
	/// </summary>
	public class AutocompleteDesigner : JQueryElementDesigner
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

}
// ../.class/ui/jqueryui/Button.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIButton
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Button.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 按钮插件.
	/// </summary>
	[ToolboxData ( "<{0}:Button runat=server></{0}:Button>" )]
	[Designer ( typeof ( ButtonDesigner ) )]
	public class Button
		: BaseWidget, IPostBackEventHandler
	{
		private readonly AjaxSettingEdit clickAjax = new AjaxSettingEdit ( );
		private string primaryIcon = string.Empty;
		private string secondaryIcon = string.Empty;

		/// <summary>
		/// 获取或设置按钮显示的主图标, 比如: ui-icon-gear, 也可以通过 Icons 属性设置.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的主图标, 比如: ui-icon-gear, 也可以通过 Icons 属性设置" )]
		[NotifyParentProperty ( true )]
		[CssClassProperty ( )]
		public string PrimaryIcon
		{
			get { return this.primaryIcon; }
			set
			{

				if ( null == value )
					return;

				this.primaryIcon = value;
			}
		}

		/// <summary>
		/// 获取或设置按钮显示的第二图标, 比如: ui-icon-triangle-1-s, 也可以通过 Icons 属性设置.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的第二图标, 比如: ui-icon-triangle-1-s, 也可以通过 Icons 属性设置" )]
		[NotifyParentProperty ( true )]
		[CssClassProperty ( )]
		public string SecondaryIcon
		{
			get { return this.secondaryIcon; }
			set
			{

				if ( null == value )
					return;

				this.secondaryIcon = value;
			}
		}

		/// <summary>
		/// 创建一个 jQuery UI 按钮.
		/// </summary>
		public Button ( )
			: base ( WidgetType.button )
		{ this.elementType = ElementType.Span; }

		#region " Option "
		/// <summary>
		/// 获取或设置按钮是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示按钮是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.ButtonSetting.Disabled, false ); }
			set { this.widgetSetting.ButtonSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置按钮是否显示文本, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( true )]
		[Description ( "指示按钮是否显示文本, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Text
		{
			get { return this.getBoolean ( this.widgetSetting.ButtonSetting.Text, true ); }
			set { this.widgetSetting.ButtonSetting.Text = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }" )]
		[NotifyParentProperty ( true )]
		public string Icons
		{
			get { return this.widgetSetting.ButtonSetting.Icons; }
			set { this.widgetSetting.ButtonSetting.Icons = value; }
		}

		/// <summary>
		/// 获取或设置按钮显示的文本, 比如: ok.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的文本, 比如: ok" )]
		[NotifyParentProperty ( true )]
		public string Label
		{
			get { return this.widgetSetting.ButtonSetting.Label.Trim ( '\'' ); }
			set { this.widgetSetting.ButtonSetting.Label = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置按钮被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.ButtonSetting.Create; }
			set { this.widgetSetting.ButtonSetting.Create = value; }
		}
		#endregion

		#region " Ajax "
		/// <summary>
		/// 获取 Click 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Click 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSettingEdit ClickAsync
		{
			get { return this.clickAjax; }
		}
		#endregion

		#region " Client "
		/// <summary>
		/// 获取或设置按钮被点击时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮被点击时的客户端事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Click
		{
			get { return this.widgetSetting.ButtonSetting.EditHelper.GetOuterEventEditValue ( EventType.click ); }
			set { this.widgetSetting.ButtonSetting.EditHelper.SetOuterEventEditValue ( EventType.click, value ); }
		}
		#endregion

		#region " Server "
		/// <summary>
		/// 在服务器端执行的点击事件.
		/// </summary>
		[Description ( "指示按钮被点击时的服务器端事件, 如果设置客户端事件将无效" )]
		public event EventHandler ClickSync;
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.ButtonSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.clickAjax.Url != string.Empty )
				{
					this.clickAjax.WidgetEventType = EventType.click;
					this.widgetSetting.AjaxSettings.Add ( this.clickAjax );
				}

				if ( null != this.ClickSync )
					this.Click = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "click" ) + "}";

				if ( !string.IsNullOrEmpty ( this.primaryIcon ) || !string.IsNullOrEmpty ( this.secondaryIcon ) )
					this.Icons = "{" + string.Format ( " primary: '{0}', secondary: '{1}' ", this.primaryIcon, this.secondaryIcon ) + "}";

			}
			else if ( this.selector == string.Empty )
			{
				string style = string.Empty;

				if ( this.Width != Unit.Empty )
					style += string.Format ( "width:{0};", this.Width );

				if ( this.Height != Unit.Empty )
					style += string.Format ( "height:{0};", this.Height );

				string css = string.Empty;

				if ( !this.Text )
					css = " ui-button-icon-only";
				else if ( this.primaryIcon != string.Empty && this.secondaryIcon == string.Empty )
					css = " ui-button-text-icon-primary";
				else if ( this.secondaryIcon != string.Empty && this.primaryIcon == string.Empty )
					css = " ui-button-text-icon-secondary";
				else if ( this.primaryIcon != string.Empty && this.secondaryIcon != string.Empty )
					css = " ui-button-text-icons";
				else
					css = " ui-button-text-only";

				writer.Write (
					"<{6} id=\"{0}\" class=\"{3}ui-button ui-widget ui-state-default ui-corner-all{2}{9}\" style=\"{4}\" title=\"{5}\">{7}<span class=\"ui-button-text\">{1}</span>{8}</{6}>",
					this.ClientID,
					this.Label,
					this.Disabled ? " ui-button-disabled ui-state-disabled" : string.Empty,
					string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
					style,
					this.ToolTip,
					this.elementType.ToString ( ).ToLower ( ),
					this.primaryIcon == string.Empty ? string.Empty : string.Format ( "<span class=\"ui-button-icon-primary ui-icon {0}\" style=\"top: 15px;position: absolute;\"></span>", this.primaryIcon ),
					this.secondaryIcon == string.Empty ? string.Empty : string.Format ( "<span class=\"ui-button-icon-secondary ui-icon {0}\" style=\"top: 15px;position: absolute;\"></span>", this.secondaryIcon ),
					css
					);
				return;
			}

			base.Render ( writer );
		}

		public void RaisePostBackEvent ( string eventArgument )
		{

			switch ( eventArgument )
			{
				case "click":

					if ( null != this.ClickSync )
						this.ClickSync ( this, new EventArgs ( ) );

					break;
			}

		}

		protected override void LoadViewState ( object savedState )
		{
			base.LoadViewState ( savedState );

			List<object> states = this.ViewState["Button"] as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.primaryIcon = states[0] as string;

			if ( states.Count >= 2 )
				this.secondaryIcon = states[1] as string;

		}

		protected override object SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.primaryIcon );
			states.Add ( this.secondaryIcon );

			this.ViewState["Button"] = states;

			return base.SaveViewState ( );
		}


	}

	#region " ButtonDesigner "
	/// <summary>
	/// 按钮设计器.
	/// </summary>
	public class ButtonDesigner : JQueryElementDesigner
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

}
// ../.class/ui/jqueryui/Datepicker.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepicker
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerDurationType
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerShowOnType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Datepicker.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 折叠列表插件.
	/// </summary>
	[ToolboxData ( "<{0}:Datepicker runat=server></{0}:Datepicker>" )]
	[Designer ( typeof ( DatepickerDesigner ) )]
	public class Datepicker
		: BaseWidget
	{

		#region " Enum "
		/// <summary>
		/// ShowOn 类型.
		/// </summary>
		public enum ShowOnType
		{
			/// <summary>
			/// 获取焦点.
			/// </summary>
			focus = 0,
			/// <summary>
			/// 点击按钮.
			/// </summary>
			button = 1,
			/// <summary>
			/// 获取焦点或者点击按钮.
			/// </summary>
			both = 2,
		}

		/// <summary>
		/// Duration 类型.
		/// </summary>
		public enum DurationType
		{
			/// <summary>
			/// 正常的.
			/// </summary>
			normal = 0,
			/// <summary>
			/// 缓慢的.
			/// </summary>
			slow = 1,
			/// <summary>
			/// 迅速的.
			/// </summary>
			fast = 2,
		}
		#endregion

		private readonly AjaxSettingEdit changeAjax = new AjaxSettingEdit ( );
		private DateTime defaultDate = DateTime.Today;
		private DateTime maxDate = DateTime.MaxValue;
		private DateTime minDate = DateTime.MinValue;

		/// <summary>
		/// 创建一个 jQuery UI 折叠列表.
		/// </summary>
		public Datepicker ( )
			: base ( WidgetType.datepicker )
		{ this.elementType = ElementType.Span; }

		#region " Option "
		/// <summary>
		/// 获取或设置日期框是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示日期框是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.Disabled, false ); }
			set { this.widgetSetting.DatepickerSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置备用字段, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示备用字段, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AltField
		{
			get { return this.widgetSetting.DatepickerSetting.AltField.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.AltField = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置在备用字段显示的日期格式, 比如: yy-mm-dd.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示在备用字段显示的日期格式, 比如: yy-mm-dd" )]
		[NotifyParentProperty ( true )]
		public string AltFormat
		{
			get { return this.widgetSetting.DatepickerSetting.AltFormat.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.AltFormat = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置显示在日期字段后的文本, 比如: ....
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示在日期字段后的文本, 比如: ..." )]
		[NotifyParentProperty ( true )]
		public string AppendText
		{
			get { return this.widgetSetting.DatepickerSetting.AppendText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.AppendText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否自动调整输入框的大小, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否自动调整输入框的大小, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool AutoSize
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.AutoSize, false ); }
			set { this.widgetSetting.DatepickerSetting.AutoSize = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置按钮的图片, 比如: /images/datepicker.gif.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的图片, 比如: /images/datepicker.gif" )]
		[NotifyParentProperty ( true )]
		public string ButtonImage
		{
			get { return this.widgetSetting.DatepickerSetting.ButtonImage.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.ButtonImage = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否按钮只显示图片, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否按钮只显示图片, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ButtonImageOnly
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ButtonImageOnly, false ); }
			set { this.widgetSetting.DatepickerSetting.ButtonImageOnly = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置按钮的文本, 比如: ....
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的文本, 比如: ..." )]
		[NotifyParentProperty ( true )]
		public string ButtonText
		{
			get { return this.widgetSetting.DatepickerSetting.ButtonText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.ButtonText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置区域设置, 默认 $.datepicker.iso8601Week.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示区域设置, 默认 $.datepicker.iso8601Week" )]
		[NotifyParentProperty ( true )]
		public string CalculateWeek
		{
			get { return this.widgetSetting.DatepickerSetting.CalculateWeek; }
			set { this.widgetSetting.DatepickerSetting.CalculateWeek = value; }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否允许使用下拉框改变月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ChangeMonth
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ChangeMonth, false ); }
			set { this.widgetSetting.DatepickerSetting.ChangeMonth = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变年份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否允许使用下拉框改变年份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ChangeYear
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ChangeYear, false ); }
			set { this.widgetSetting.DatepickerSetting.ChangeYear = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 比如: 'X'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭链接的文本, 比如: 'X'" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.widgetSetting.DatepickerSetting.CloseText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.CloseText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否限制输入的格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否限制输入的格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ConstrainInput
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ConstrainInput, true ); }
			set { this.widgetSetting.DatepickerSetting.ConstrainInput = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置当天链接的文本, 比如: '今天'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示当天链接的文本, 比如: '今天'" )]
		[NotifyParentProperty ( true )]
		public string CurrentText
		{
			get { return this.widgetSetting.DatepickerSetting.CurrentText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.CurrentText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置日期的格式, 比如: mm/dd/yy.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期的格式, 比如: mm/dd/yy" )]
		[NotifyParentProperty ( true )]
		public string DateFormat
		{
			get { return this.widgetSetting.DatepickerSetting.DateFormat.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.DateFormat = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" )]
		[NotifyParentProperty ( true )]
		public string DayNames
		{
			get { return this.widgetSetting.DatepickerSetting.DayNames; }
			set { this.widgetSetting.DatepickerSetting.DayNames = value; }
		}

		/// <summary>
		/// 获取或设置天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesMin
		{
			get { return this.widgetSetting.DatepickerSetting.DayNamesMin; }
			set { this.widgetSetting.DatepickerSetting.DayNamesMin = value; }
		}

		/// <summary>
		/// 获取或设置天的短名称, 比如: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesShort
		{
			get { return this.widgetSetting.DatepickerSetting.DayNamesShort; }
			set { this.widgetSetting.DatepickerSetting.DayNamesShort = value; }
		}

		/// <summary>
		/// 获取或设置默认日期.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "指示默认日期" )]
		[NotifyParentProperty ( true )]
		public DateTime DefaultDate
		{
			get { return this.defaultDate; }
			set { this.defaultDate = value; }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的日期显示速度, 或者使用 slow, normal, fast 中的一种.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( DurationType.normal )]
		[Description ( "指示以毫秒为单位的日期显示速度, 或者使用 slow, normal, fast 中的一种" )]
		[NotifyParentProperty ( true )]
		public DurationType Duration
		{
			get { return this.getEnum<DurationType> ( this.widgetSetting.DatepickerSetting.Duration, DurationType.normal ); }
			set { this.widgetSetting.DatepickerSetting.Duration = value == DurationType.normal ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置哪一天作为一周的开始, 0 表示周日以此类推.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示哪一天作为一周的开始, 0 表示周日以此类推" )]
		[NotifyParentProperty ( true )]
		public int FirstDay
		{
			get { return this.getInteger ( this.widgetSetting.DatepickerSetting.FirstDay, 0 ); }
			set { this.widgetSetting.DatepickerSetting.FirstDay = value <= 0 || value > 6 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool GotoCurrent
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.GotoCurrent, false ); }
			set { this.widgetSetting.DatepickerSetting.GotoCurrent = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否隐藏上一和下一链接, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否隐藏上一和下一链接, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool HideIfNoPrevNext
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.HideIfNoPrevNext, false ); }
			set { this.widgetSetting.DatepickerSetting.HideIfNoPrevNext = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否使用从右向左, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否使用从右向左, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool IsRTL
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.IsRTL, false ); }
			set { this.widgetSetting.DatepickerSetting.IsRTL = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置最大日期.
		/// </summary>
		[Category ( "行为" )]
		[Description ( "指示最大日期" )]
		[NotifyParentProperty ( true )]
		public DateTime MaxDate
		{
			get { return this.maxDate; }
			set { this.maxDate = value; }
		}

		/// <summary>
		/// 获取或设置最大日期.
		/// </summary>
		[Category ( "行为" )]
		[Description ( "指示最小日期" )]
		[NotifyParentProperty ( true )]
		public DateTime MinDate
		{
			get { return this.minDate; }
			set { this.minDate = value; }
		}

		/// <summary>
		/// 获取或设置月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" )]
		[NotifyParentProperty ( true )]
		public string MonthNames
		{
			get { return this.widgetSetting.DatepickerSetting.MonthNames; }
			set { this.widgetSetting.DatepickerSetting.MonthNames = value; }
		}

		/// <summary>
		/// 获取或设置月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" )]
		[NotifyParentProperty ( true )]
		public string MonthNamesShort
		{
			get { return this.widgetSetting.DatepickerSetting.MonthNamesShort; }
			set { this.widgetSetting.DatepickerSetting.MonthNamesShort = value; }
		}

		/// <summary>
		/// 获取或设置链接是否使用日期格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示链接是否使用日期格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool NavigationAsDateFormat
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.NavigationAsDateFormat, false ); }
			set { this.widgetSetting.DatepickerSetting.NavigationAsDateFormat = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置下一链接的文本, 比如: ....
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示下一链接的文本, 比如: ..." )]
		[NotifyParentProperty ( true )]
		public string NextText
		{
			get { return this.widgetSetting.DatepickerSetting.NextText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.NextText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置显示的月数, 默认为 1.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 1 )]
		[Description ( "指示显示的月数, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public int NumberOfMonths
		{
			get { return this.getInteger ( this.widgetSetting.DatepickerSetting.NumberOfMonths, 1 ); }
			set { this.widgetSetting.DatepickerSetting.NumberOfMonths = value <= 1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置上一链接的文本, 比如: ....
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示上一链接的文本, 比如: ..." )]
		[NotifyParentProperty ( true )]
		public string PrevText
		{
			get { return this.widgetSetting.DatepickerSetting.PrevText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.PrevText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否可以选择其它的月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否可以选择其它的月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool SelectOtherMonths
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.SelectOtherMonths, false ); }
			set { this.widgetSetting.DatepickerSetting.SelectOtherMonths = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置短年份的设置, 可以是数字或者字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示短年份的设置, 可以是数字或者字符串" )]
		[NotifyParentProperty ( true )]
		public string ShortYearCutoff
		{
			get { return this.widgetSetting.DatepickerSetting.ShortYearCutoff.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.ShortYearCutoff = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置显示日期时的动画, 比如: show.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示日期时的动画, 比如: show" )]
		[NotifyParentProperty ( true )]
		public string ShowAnim
		{
			get { return this.widgetSetting.DatepickerSetting.ShowAnim.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.ShowAnim = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否显示按钮面板, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否显示按钮面板, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowButtonPanel
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ShowButtonPanel, false ); }
			set { this.widgetSetting.DatepickerSetting.ShowButtonPanel = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置当前月份的显示位置.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 0 )]
		[Description ( "指示当前月份的显示位置" )]
		[NotifyParentProperty ( true )]
		public int ShowCurrentAtPos
		{
			get { return this.getInteger ( this.widgetSetting.DatepickerSetting.ShowCurrentAtPos, 0 ); }
			set { this.widgetSetting.DatepickerSetting.ShowCurrentAtPos = value <= 0 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置是否在年后显示月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否在年后显示月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowMonthAfterYear
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ShowMonthAfterYear, false ); }
			set { this.widgetSetting.DatepickerSetting.ShowMonthAfterYear = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置日期框显示方式, 可以是 focus, button, both 中的一种.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( ShowOnType.focus )]
		[Description ( "指示日期框显示方式, 可以是 focus, button, both 中的一种" )]
		[NotifyParentProperty ( true )]
		public ShowOnType ShowOn
		{
			get { return this.getEnum<ShowOnType> ( this.widgetSetting.DatepickerSetting.ShowOn, ShowOnType.focus ); }
			set { this.widgetSetting.DatepickerSetting.ShowOn = value == ShowOnType.focus ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置显示选项, 比如: {direction: 'up' }.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示选项, 比如: {direction: 'up' }" )]
		[NotifyParentProperty ( true )]
		public string ShowOptions
		{
			get { return this.widgetSetting.DatepickerSetting.ShowOptions; }
			set { this.widgetSetting.DatepickerSetting.ShowOptions = value; }
		}

		/// <summary>
		/// 获取或设置是否显示其它月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否显示其它月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowOtherMonths
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ShowOtherMonths, false ); }
			set { this.widgetSetting.DatepickerSetting.ShowOtherMonths = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否显示当前为一年中的第几周, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否显示当前为一年中的第几周, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowWeek
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ShowWeek, false ); }
			set { this.widgetSetting.DatepickerSetting.ShowWeek = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置每一次跳转的月份数, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示每一次跳转的月份数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public int StepMonths
		{
			get { return this.getInteger ( this.widgetSetting.DatepickerSetting.StepMonths, 1 ); }
			set { this.widgetSetting.DatepickerSetting.StepMonths = value <= 1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置周的标题设置, 默认: Wk.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示周的标题设置, 默认: Wk" )]
		[NotifyParentProperty ( true )]
		public string WeekHeader
		{
			get { return this.widgetSetting.DatepickerSetting.WeekHeader.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.WeekHeader = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置可选择的年份范围, 默认: c-10:c+10.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示可选择的年份范围, 默认: c-10:c+10" )]
		[NotifyParentProperty ( true )]
		public string YearRange
		{
			get { return this.widgetSetting.DatepickerSetting.YearRange.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.YearRange = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置跟随在年后的文本, 比如: Y.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示跟随在年后的文本, 比如: Y" )]
		[NotifyParentProperty ( true )]
		public string YearSuffix
		{
			get { return this.widgetSetting.DatepickerSetting.YearSuffix.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.YearSuffix = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置日期框被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.DatepickerSetting.Create; }
			set { this.widgetSetting.DatepickerSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置日期框显示时的事件, 类似于: function(input, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示时的事件, 类似于: function(input, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShow
		{
			get { return this.widgetSetting.DatepickerSetting.BeforeShow; }
			set { this.widgetSetting.DatepickerSetting.BeforeShow = value; }
		}

		/// <summary>
		/// 获取或设置日期框显示天时的事件, 类似于: function(date) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示天时的事件, 类似于: function(date) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShowDay
		{
			get { return this.widgetSetting.DatepickerSetting.BeforeShowDay; }
			set { this.widgetSetting.DatepickerSetting.BeforeShowDay = value; }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(year, month, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示年和月改变时的事件, 类似于: function(year, month, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnChangeMonthYear
		{
			get { return this.widgetSetting.DatepickerSetting.OnChangeMonthYear; }
			set { this.widgetSetting.DatepickerSetting.OnChangeMonthYear = value; }
		}

		/// <summary>
		/// 获取或设置日期款关闭时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期款关闭时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnClose
		{
			get { return this.widgetSetting.DatepickerSetting.OnClose; }
			set { this.widgetSetting.DatepickerSetting.OnClose = value; }
		}

		/// <summary>
		/// 获取或设置日期选择时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期选择时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnSelect
		{
			get { return this.widgetSetting.DatepickerSetting.OnSelect; }
			set { this.widgetSetting.DatepickerSetting.OnSelect = value; }
		}
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.DatepickerSetting.SetEditHelper ( this.editHelper );

				if ( this.defaultDate.ToString ( "yyyy-MM-dd" ) != DateTime.Today.ToString ( "yyyy-MM-dd" ) )
					this.widgetSetting.DatepickerSetting.DefaultDate = string.Format ( "new Date({0}, {1}, {2})", this.defaultDate.Year, this.defaultDate.Month - 1, this.defaultDate.Day );

				if ( this.maxDate.ToString ( "yyyy-MM-dd" ) != DateTime.MaxValue.ToString ( "yyyy-MM-dd" ) )
					this.widgetSetting.DatepickerSetting.MaxDate = string.Format ( "new Date({0}, {1}, {2})", this.maxDate.Year, this.maxDate.Month - 1, this.maxDate.Day );

				if ( this.minDate.ToString ( "yyyy-MM-dd" ) != DateTime.MinValue.ToString ( "yyyy-MM-dd" ) )
					this.widgetSetting.DatepickerSetting.MinDate = string.Format ( "new Date({0}, {1}, {2})", this.minDate.Year, this.minDate.Month - 1, this.minDate.Day );

			}
			else if ( this.selector == string.Empty )
				switch ( this.widgetSetting.Type )
				{
					case WidgetType.datepicker:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );

						string title;

						if ( this.ShowMonthAfterYear )
							title = "{1}&nbsp;{0}";
						else
							title = "{0}&nbsp;{1}";

						string[] dayNames;

						switch ( this.FirstDay )
						{
							case 1:
								dayNames = new string[] { "[Mo]", "[Tu]", "[We]", "[Th]", "[Fr]", "[Sa]", "[Su]" };
								break;

							case 2:
								dayNames = new string[] { "[Tu]", "[We]", "[Th]", "[Fr]", "[Sa]", "[Su]", "[Mo]" };
								break;

							case 3:
								dayNames = new string[] { "[We]", "[Th]", "[Fr]", "[Sa]", "[Su]", "[Mo]", "[Tu]" };
								break;

							case 4:
								dayNames = new string[] { "[Th]", "[Fr]", "[Sa]", "[Su]", "[Mo]", "[Tu]", "[We]" };
								break;

							case 5:
								dayNames = new string[] { "[Fr]", "[Sa]", "[Su]", "[Mo]", "[Tu]", "[We]", "[Th]" };
								break;

							case 6:
								dayNames = new string[] { "[Sa]", "[Su]", "[Mo]", "[Tu]", "[We]", "[Th]", "[Fr]" };
								break;

							case 0:
							default:
								dayNames = new string[] { "[Su]", "[Mo]", "[Tu]", "[We]", "[Th]", "[Fr]", "[Sa]" };
								break;
						}

						string head = string.Format ( "<tr>{7}<th class=\"ui-datepicker-week-end\"><span>{0}</span></th><th><span>{1}</span></th><th><span>{2}</span></th><th><span>{3}</span></th><th><span>{4}</span></th><th><span>{5}</span></th><th class=\"ui-datepicker-week-end\"><span>{6}</span></th></tr>", dayNames[0], dayNames[1], dayNames[2], dayNames[3], dayNames[4], dayNames[5], dayNames[6], this.ShowWeek ? "<th class=\"ui-datepicker-week-col\">" + ( this.WeekHeader == string.Empty ? "[Wk]" : this.WeekHeader ) + "</th>" : string.Empty );

						string table = string.Format (
							"<div style=\"display: block;{4}\" class=\"ui-datepicker-inline ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all\"><div class=\"ui-datepicker-header ui-widget-header ui-helper-clearfix ui-corner-all\"><a class=\"ui-datepicker-prev ui-corner-all\" title=\"Prev\"><span class=\"ui-icon ui-icon-circle-triangle-w\">Prev</span></a><a class=\"ui-datepicker-next ui-corner-all\" title=\"Next\"><span class=\"ui-icon ui-icon-circle-triangle-e\">Next</span></a><div class=\"ui-datepicker-title\">" + title + "</div></div><table class=\"ui-datepicker-calendar\"><thead>" + head + "</thead><tbody><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default ui-state-highlight ui-state-active\">1</a></td><td><a class=\"ui-state-default\">2</a></td><td><a class=\"ui-state-default\">3</a></td><td><a class=\"ui-state-default\">4</a></td><td><a class=\"ui-state-default\">5</a></td><td><a class=\"ui-state-default\">6</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">7</a></td></tr><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">8</a></td><td><a class=\"ui-state-default\">9</a></td><td><a class=\"ui-state-default\">10</a></td><td><a class=\"ui-state-default\">11</a></td><td><a class=\"ui-state-default\">12</a></td><td><a class=\"ui-state-default\">13</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">14</a></td></tr><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">15</a></td><td><a class=\"ui-state-default\">16</a></td><td><a class=\"ui-state-default\">17</a></td><td><a class=\"ui-state-default\">18</a></td><td><a class=\"ui-state-default\">19</a></td><td><a class=\"ui-state-default\">20</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">21</a></td></tr><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">22</a></td><td><a class=\"ui-state-default\">23</a></td><td><a class=\"ui-state-default\">24</a></td><td><a class=\"ui-state-default\">25</a></td><td><a class=\"ui-state-default\">26</a></td><td class=\"ui-datepicker-days-cell-over ui-datepicker-current-day ui-datepicker-today\"><a class=\"ui-state-default\">27</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">28</a></td></tr><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">29</a></td><td><a class=\"ui-state-default\">30</a></td><td><a class=\"ui-state-default\">31</a></td><td class=\"ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">{5}</td><td class=\"ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">{6}</td><td class=\"ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">{7}</td><td class=\"ui-datepicker-week-end ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">{8}</td></tr></tbody></table>{2}</div>",
							this.ChangeMonth ? "<select class=\"ui-datepicker-month\" style=\"position: relative; top: 3px; width: 100px;height: 22px;\"><option value=\"xxx\">{xxx}</option></select>" : "<span class=\"ui-datepicker-month\">{xxx}</span>",
							this.ChangeYear ? "<select class=\"ui-datepicker-year\" style=\"position: relative; top: 3px; width: 100px;height: 22px;\"><option value=\"20xx\">{20xx}</option></select>" : "<span class=\"ui-datepicker-year\">{20xx}</span>",
							this.ShowButtonPanel ? "<div class=\"ui-datepicker-buttonpane ui-widget-content\"><button class=\"ui-datepicker-current ui-state-default ui-priority-secondary ui-corner-all\">" + ( this.CurrentText == string.Empty ? "{Txx}" : this.CurrentText ) + "</button></div>" : string.Empty,
							this.ShowWeek ? "<td class=\"ui-datepicker-week-col\">xx</td>" : string.Empty,
							this.ShowWeek ? "width: 330px;" : string.Empty,
							this.ShowOtherMonths ? "<span class=\"ui-state-default\">1</span>" : "&nbsp;",
							this.ShowOtherMonths ? "<span class=\"ui-state-default\">2</span>" : "&nbsp;",
							this.ShowOtherMonths ? "<span class=\"ui-state-default\">3</span>" : "&nbsp;",
							this.ShowOtherMonths ? "<span class=\"ui-state-default\">4</span>" : "&nbsp;"
							);

						//<div id=\"Dp\" class=\"hasDatepicker\"></div>
						writer.Write (
							"<{6} id=\"{0}\" class=\"{3}hasDatepicker{2}\" style=\"{4}\" title=\"{5}\">{1}</{6}>",
							this.ClientID,
							table,
							this.Disabled ? " ui-datepicker-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( )
							);
						return;
				}

			base.Render ( writer );
		}

		protected override void LoadViewState ( object savedState )
		{
			base.LoadViewState ( savedState );

			List<object> states = this.ViewState["Datepicker"] as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.defaultDate = ( DateTime ) states[0];

			if ( states.Count >= 2 )
				this.maxDate = ( DateTime ) states[1];

			if ( states.Count >= 3 )
				this.minDate = ( DateTime ) states[2];

		}

		protected override object SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.defaultDate );
			states.Add ( this.maxDate );
			states.Add ( this.minDate );

			this.ViewState["Datepicker"] = states;

			return base.SaveViewState ( );
		}

	}

	#region " DatepickerDesigner "
	/// <summary>
	/// 折叠列表设计器.
	/// </summary>
	public class DatepickerDesigner : JQueryElementDesigner
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

}
// ../.class/ui/jqueryui/Dialog.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDialog
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Dialog.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 对话框插件.
	/// </summary>
	[ToolboxData ( "<{0}:Dialog runat=server></{0}:Dialog>" )]
	[Designer ( typeof ( DialogDesigner ) )]
	public class Dialog
		: BaseWidget
	{
		private readonly AjaxSettingEdit openAjax = new AjaxSettingEdit ( );
		private readonly AjaxSettingEdit closeAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 对话框.
		/// </summary>
		public Dialog ( )
			: base ( WidgetType.dialog )
		{ this.elementType = ElementType.Div; }

		#region " Option "
		/// <summary>
		/// 获取或设置对话框是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示对话框是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.DialogSetting.Disabled, false ); }
			set { this.widgetSetting.DialogSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置对话框是否自动打开, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示对话框是否自动打开, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool AutoOpen
		{
			get { return this.getBoolean ( this.widgetSetting.DialogSetting.AutoOpen, true ); }
			set { this.widgetSetting.DialogSetting.AutoOpen = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }" )]
		[NotifyParentProperty ( true )]
		public string Buttons
		{
			get { return this.widgetSetting.DialogSetting.Buttons; }
			set { this.widgetSetting.DialogSetting.Buttons = value; }
		}

		/// <summary>
		/// 获取或设置是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool CloseOnEscape
		{
			get { return this.getBoolean ( this.widgetSetting.DialogSetting.CloseOnEscape, true ); }
			set { this.widgetSetting.DialogSetting.CloseOnEscape = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 默认 close.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭链接的文本, 默认 close" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.widgetSetting.DialogSetting.CloseText.Trim ( '\'' ); }
			set { this.widgetSetting.DialogSetting.CloseText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置对话框的样式, 比如: alert.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框的样式, 比如: alert" )]
		[NotifyParentProperty ( true )]
		public string DialogClass
		{
			get { return this.widgetSetting.DialogSetting.DialogClass.Trim ( '\'' ); }
			set { this.widgetSetting.DialogSetting.DialogClass = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否允许拖动, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否允许拖动, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Draggable
		{
			get { return this.getBoolean ( this.widgetSetting.DialogSetting.Draggable, true ); }
			set { this.widgetSetting.DialogSetting.Draggable = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置对话框高度, 比如: 300.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( -1 )]
		[Description ( "指示对话框高度, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public new int Height
		{
			get { return this.getInteger ( this.widgetSetting.DialogSetting.Height, -1 ); }
			set { this.widgetSetting.DialogSetting.Height = value <= -1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置关闭对话框时的动画, 比如: slide.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭对话框时的动画, 比如: slide" )]
		[NotifyParentProperty ( true )]
		public string Hide
		{
			get { return this.widgetSetting.DialogSetting.Hide.Trim ( '\'' ); }
			set { this.widgetSetting.DialogSetting.Hide = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置最大高度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( -1 )]
		[Description ( "指示最大高度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public int MaxHeight
		{
			get { return this.getInteger ( this.widgetSetting.DialogSetting.MaxHeight, -1 ); }
			set { this.widgetSetting.DialogSetting.MaxHeight = value <= -1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置最大宽度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( -1 )]
		[Description ( "指示最大宽度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public int MaxWidth
		{
			get { return this.getInteger ( this.widgetSetting.DialogSetting.MaxWidth, -1 ); }
			set { this.widgetSetting.DialogSetting.MaxWidth = value <= -1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置最小高度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 150 )]
		[Description ( "指示最小高度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public int MinHeight
		{
			get { return this.getInteger ( this.widgetSetting.DialogSetting.MinHeight, 150 ); }
			set { this.widgetSetting.DialogSetting.MinHeight = value <= 0 || value == 150 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置最小宽度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 150 )]
		[Description ( "指示最小宽度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public int MinWidth
		{
			get { return this.getInteger ( this.widgetSetting.DialogSetting.MinWidth, 150 ); }
			set { this.widgetSetting.DialogSetting.MinWidth = value <= 0 || value == 150 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置是否使用 modal 模式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否使用 modal 模式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Modal
		{
			get { return this.getBoolean ( this.widgetSetting.DialogSetting.Modal, true ); }
			set { this.widgetSetting.DialogSetting.Modal = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置对话框的位置, 比如: ['right','top'], [100, 200].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框的位置, 比如: ['right','top'], [100, 200]" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.widgetSetting.DialogSetting.Position; }
			set { this.widgetSetting.DialogSetting.Position = value; }
		}

		/// <summary>
		/// 获取或设置是否允许缩放, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否允许缩放, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Resizable
		{
			get { return this.getBoolean ( this.widgetSetting.DialogSetting.Resizable, true ); }
			set { this.widgetSetting.DialogSetting.Resizable = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置显示时的动画, 比如: slide.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示时的动画, 比如: slide" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.widgetSetting.DialogSetting.Show.Trim ( '\'' ); }
			set { this.widgetSetting.DialogSetting.Show = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否自动置顶, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否自动置顶, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Stack
		{
			get { return this.getBoolean ( this.widgetSetting.DialogSetting.Stack, true ); }
			set { this.widgetSetting.DialogSetting.Stack = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置对话框标题, 比如: my title.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框标题, 比如: my title" )]
		[NotifyParentProperty ( true )]
		public string Title
		{
			get { return this.widgetSetting.DialogSetting.Title.Trim ( '\'' ); }
			set { this.widgetSetting.DialogSetting.Title = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置对话框宽度, 比如: 300.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 300 )]
		[Description ( "指示对话框宽度, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public new int Width
		{
			get { return this.getInteger ( this.widgetSetting.DialogSetting.Width, 300 ); }
			set { this.widgetSetting.DialogSetting.Width = value <= 0 || value == 300 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置对话框 Z 轴顺序, 比如: 2.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 1000 )]
		[Description ( "指示对话框 Z 轴顺序, 比如: 2" )]
		[NotifyParentProperty ( true )]
		public int ZIndex
		{
			get { return this.getInteger ( this.widgetSetting.DialogSetting.ZIndex, 1000 ); }
			set { this.widgetSetting.DialogSetting.ZIndex = value <= 0 || value == 1000 ? string.Empty : value.ToString ( ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置对话框被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.DialogSetting.Create; }
			set { this.widgetSetting.DialogSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置对话框关闭之前的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭之前的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeClose
		{
			get { return this.widgetSetting.DialogSetting.BeforeClose; }
			set { this.widgetSetting.DialogSetting.BeforeClose = value; }
		}

		/// <summary>
		/// 获取或设置对话框打开时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.widgetSetting.DialogSetting.Open; }
			set { this.widgetSetting.DialogSetting.Open = value; }
		}

		/// <summary>
		/// 获取或设置对话框获得焦点时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public new string Focus
		{
			get { return this.widgetSetting.DialogSetting.Focus; }
			set { this.widgetSetting.DialogSetting.Focus = value; }
		}

		/// <summary>
		/// 获取或设置对话框拖动开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStart
		{
			get { return this.widgetSetting.DialogSetting.DragStart; }
			set { this.widgetSetting.DialogSetting.DragStart = value; }
		}

		/// <summary>
		/// 获取或设置对话框拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drag
		{
			get { return this.widgetSetting.DialogSetting.Drag; }
			set { this.widgetSetting.DialogSetting.Drag = value; }
		}

		/// <summary>
		/// 获取或设置对话框拖动结束时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStop
		{
			get { return this.widgetSetting.DialogSetting.DragStop; }
			set { this.widgetSetting.DialogSetting.DragStop = value; }
		}

		/// <summary>
		/// 获取或设置对话框缩放开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStart
		{
			get { return this.widgetSetting.DialogSetting.ResizeStart; }
			set { this.widgetSetting.DialogSetting.ResizeStart = value; }
		}

		/// <summary>
		/// 获取或设置对话框缩放时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Resize
		{
			get { return this.widgetSetting.DialogSetting.Resize; }
			set { this.widgetSetting.DialogSetting.Resize = value; }
		}

		/// <summary>
		/// 获取或设置对话框缩放结束时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStop
		{
			get { return this.widgetSetting.DialogSetting.ResizeStop; }
			set { this.widgetSetting.DialogSetting.ResizeStop = value; }
		}

		/// <summary>
		/// 获取或设置对话框关闭时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.widgetSetting.DialogSetting.Close; }
			set { this.widgetSetting.DialogSetting.Close = value; }
		}
		#endregion

		#region " Ajax "
		/// <summary>
		/// 获取 Open 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Open 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSettingEdit OpenAsync
		{
			get { return this.openAjax; }
		}

		/// <summary>
		/// 获取 Close 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Close 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSettingEdit CloseAsync
		{
			get { return this.closeAjax; }
		}
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.DialogSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.closeAjax.Url != string.Empty )
				{
					this.closeAjax.WidgetEventType = EventType.dialogclose;
					this.widgetSetting.AjaxSettings.Add ( this.closeAjax );
				}

				if ( this.openAjax.Url != string.Empty )
				{
					this.openAjax.WidgetEventType = EventType.dialogopen;
					this.widgetSetting.AjaxSettings.Add ( this.openAjax );
				}

			}
			else if ( this.selector == string.Empty )
				switch ( this.widgetSetting.Type )
				{
					case WidgetType.dialog:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );

						writer.Write (
							"<{5} id=\"{0}\" class=\"{2}ui-dialog ui-widget ui-widget-content ui-corner-all{1}{6}{7}\" style=\"{3}\" title=\"{4}\" style=\"width: {8}px; height: {9}; display: block; z-index: 1000; outline-width: 0px; outline-style: none; outline-color: invert;\"><div class=\"ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix\"><span id=\"ui-dialog-title-sss\" class=\"ui-dialog-title\">{10}</span><a class=\"ui-dialog-titlebar-close ui-corner-all\"><span class=\"ui-icon ui-icon-closethick\">{11}</span></a><br /></div><div style=\"width: auto; height: auto;\" class=\"ui-dialog-content ui-widget-content\">",
							this.ClientID,
							this.Disabled ? " ui-dialog-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( ),
							this.Draggable ? " ui-draggable" : string.Empty,
							this.Resizable ? " ui-resizable" : string.Empty,
							this.Width,
							this.Height == -1 ? "auto" :  this.Height.ToString() + "px",
							this.Title,
							this.CloseText == string.Empty ? "close" : this.CloseText
							);

						if ( this.html.Controls.Count != 0 )
							this.html.RenderControl ( writer );

						writer.Write (
							"</div>{1}{2}</{0}>",
							this.elementType.ToString ( ).ToLower ( ),
							this.Resizable ? "<div class=\"ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se ui-icon-grip-diagonal-se\" style=\"z-index: 1001;\"/>" : string.Empty,
							this.Buttons == string.Empty ? string.Empty : "<div class=\"ui-dialog-buttonpane ui-widget-content ui-helper-clearfix\"><div class=\"ui-dialog-buttonset\"><button class=\"ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only\"><span class=\"ui-button-text\" type=\"button\">button</span></button></div></div>"
							);
						return;
				}

			base.Render ( writer );
		}

	}

	#region " DialogDesigner "
	/// <summary>
	/// 对话框设计器.
	/// </summary>
	public class DialogDesigner : JQueryElementDesigner
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

}
// ../.class/ui/jqueryui/Progressbar.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIProgressbar
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Progressbar.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 进度条插件.
	/// </summary>
	[ToolboxData ( "<{0}:Progressbar runat=server></{0}:Progressbar>" )]
	[Designer ( typeof ( ProgressbarDesigner ) )]
	public class Progressbar
		: BaseWidget, IPostBackEventHandler
	{
		private readonly AjaxSettingEdit changeAjax = new AjaxSettingEdit ( );
		private readonly AjaxSettingEdit completeAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 进度条.
		/// </summary>
		public Progressbar ( )
			: base ( WidgetType.progressbar )
		{ this.elementType = ElementType.Div; }

		#region " Option "
		/// <summary>
		/// 获取或设置进度条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示进度条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.ProgressbarSetting.Disabled, false ); }
			set { this.widgetSetting.ProgressbarSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置进度条当前的值, 比如: 37.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示进度条当前的值, 比如: 37" )]
		[NotifyParentProperty ( true )]
		public int Value
		{
			get { return this.getInteger ( this.widgetSetting.ProgressbarSetting.Value, 0 ); }
			set { this.widgetSetting.ProgressbarSetting.Value = value <= 0 ? string.Empty : value.ToString ( ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置进度条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.ProgressbarSetting.Create; }
			set { this.widgetSetting.ProgressbarSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置进度条当前值改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条当前值改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.widgetSetting.ProgressbarSetting.Change; }
			set { this.widgetSetting.ProgressbarSetting.Change = value; }
		}

		/// <summary>
		/// 获取或设置进度条完成时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Complete
		{
			get { return this.widgetSetting.ProgressbarSetting.Complete; }
			set { this.widgetSetting.ProgressbarSetting.Complete = value; }
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
		[NotifyParentProperty ( true )]
		public AjaxSettingEdit ChangeAsync
		{
			get { return this.changeAjax; }
		}
		/// <summary>
		/// 获取 Complete 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Complete 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AjaxSettingEdit CompleteAsync
		{
			get { return this.completeAjax; }
		}
		#endregion

		#region " Server "
		/// <summary>
		/// 在服务器端执行的值改变事件.
		/// </summary>
		[Description ( "指示值改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event ProgressbarChangeEventHandler ChangeSync;
		/// <summary>
		/// 在服务器端执行的完成事件.
		/// </summary>
		[Description ( "指示完成的服务器端事件, 如果设置客户端事件将无效" )]
		public event ProgressbarCompleteEventHandler CompleteSync;
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.ProgressbarSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.changeAjax.Url != string.Empty )
				{
					this.changeAjax.WidgetEventType = EventType.progressbarchange;
					this.widgetSetting.AjaxSettings.Add ( this.changeAjax );
				}

				if ( this.completeAjax.Url != string.Empty )
				{
					this.completeAjax.WidgetEventType = EventType.progressbarcomplete;
					this.widgetSetting.AjaxSettings.Add ( this.completeAjax );
				}

				if ( null != this.ChangeSync )
					this.Change = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "change;[%':$(this).progressbar(!sq!option!sq!, !sq!value!sq!)%]" ) + "}";

				if ( null != this.CompleteSync )
					this.Complete = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "complete;[%':$(this).progressbar(!sq!option!sq!, !sq!value!sq!)%]" ) + "}";

			}
			else if ( this.selector == string.Empty )
				switch ( this.widgetSetting.Type )
				{
					case WidgetType.progressbar:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );

						writer.Write (
							"<{6} id=\"{0}\" class=\"{3}ui-progressbar ui-widget ui-widget-content ui-corner-all{2}\" style=\"{4}\" title=\"{5}\"><div style=\"width: {1}%;\" class=\"ui-progressbar-value ui-widget-header ui-corner-left\"></div></{6}>",
							this.ClientID,
							this.Value,
							this.Disabled ? " ui-progressbase-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( )
							);
						return;
				}

			base.Render ( writer );
		}

		private void onChange ( ProgressbarEventArgs e )
		{ this.Value = e.Value; }

		private void onComplete ( ProgressbarEventArgs e )
		{ this.Value = e.Value; }

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
						ProgressbarEventArgs e = new ProgressbarEventArgs ( StringConvert.ToObject<int> ( parts[1] ) );

						this.onChange ( e );
						this.ChangeSync ( this, e );
					}


					break;

				case "complete":

					if ( null != this.CompleteSync )
					{
						ProgressbarEventArgs e = new ProgressbarEventArgs ( StringConvert.ToObject<int> ( parts[1] ) );

						this.onComplete ( e );
						this.CompleteSync ( this, e );
					}

					break;
			}

		}

	}

	#region " ProgressbarDesigner "
	/// <summary>
	/// 进度条设计器.
	/// </summary>
	public class ProgressbarDesigner : JQueryElementDesigner
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
	/// 进度条值改变事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void ProgressbarChangeEventHandler ( object sender, ProgressbarEventArgs e );

	/// <summary>
	/// 进度条完成事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void ProgressbarCompleteEventHandler ( object sender, ProgressbarEventArgs e );

	/// <summary>
	/// 进度条事件参数.
	/// </summary>
	public sealed class ProgressbarEventArgs
	{
		/// <summary>
		/// 值.
		/// </summary>
		public readonly int Value;

		/// <summary>
		/// 创建一个进度条事件参数.
		/// </summary>
		/// <param name="value">值.</param>
		public ProgressbarEventArgs ( int value )
		{

			if ( value < 0 )
				value = 0;

			this.Value = value;
		}

	}

}
// ../.class/ui/jqueryui/Slider.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISlider
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISliderOrientationType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Slider.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 分割条插件.
	/// </summary>
	[ToolboxData ( "<{0}:Slider runat=server></{0}:Slider>" )]
	[Designer ( typeof ( SliderDesigner ) )]
	public class Slider
		: BaseWidget, IPostBackEventHandler
	{

		#region " Enum "
		/// <summary>
		/// Orientation 类型.
		/// </summary>
		public enum OrientationType
		{
			/// <summary>
			/// 水平.
			/// </summary>
			horizontal = 0,
			/// <summary>
			/// 垂直.
			/// </summary>
			vertical = 1,
		}
		#endregion


		private readonly AjaxSettingEdit changeAjax = new AjaxSettingEdit ( );
		private readonly AjaxSettingEdit completeAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 分割条.
		/// </summary>
		public Slider ( )
			: base ( WidgetType.slider )
		{ this.elementType = ElementType.Div; }

		#region " Option "
		/// <summary>
		/// 获取或设置分割条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示分割条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.SliderSetting.Disabled, false ); }
			set { this.widgetSetting.SliderSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( false )]
		[Description ( "指示是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'" )]
		[NotifyParentProperty ( true )]
		public bool Animate
		{
			get { return this.getBoolean ( this.widgetSetting.SliderSetting.Animate, false ); }
			set { this.widgetSetting.SliderSetting.Animate = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置分割条最大值, 比如: 100.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 100 )]
		[Description ( "指示分割条最大值, 比如: 100" )]
		[NotifyParentProperty ( true )]
		public int Max
		{
			get { return this.getInteger ( this.widgetSetting.SliderSetting.Max, 100 ); }
			set { this.widgetSetting.SliderSetting.Max = value <= 0 || value == 100 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置分割条最小值, 比如: 0.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 0 )]
		[Description ( "指示分割条最小值, 比如: 0" )]
		[NotifyParentProperty ( true )]
		public int Min
		{
			get { return this.getInteger ( this.widgetSetting.SliderSetting.Min, 0 ); }
			set { this.widgetSetting.SliderSetting.Min = value <= 0 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置分割条的方向.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( OrientationType.horizontal )]
		[Description ( "指示分割条的方向" )]
		[NotifyParentProperty ( true )]
		public OrientationType Orientation
		{
			get { return this.getEnum<OrientationType> ( this.widgetSetting.SliderSetting.Orientation, OrientationType.horizontal ); }
			set { this.widgetSetting.SliderSetting.Orientation = value == OrientationType.horizontal ? string.Empty : "'" + value.ToString ( ) + "'"; }
		}

		/// <summary>
		/// 获取或设置分割条是否使用范围, 或者为 'min', 'max' 中的一种.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示分割条是否使用范围, 或者为 'min', 'max' 中的一种" )]
		[NotifyParentProperty ( true )]
		public bool Range
		{
			get { return this.getBoolean ( this.widgetSetting.SliderSetting.Range, false ); }
			set { this.widgetSetting.SliderSetting.Range = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置分割条的步长, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示分割条的步长, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public int Step
		{
			get { return this.getInteger ( this.widgetSetting.SliderSetting.Step, 1 ); }
			set { this.widgetSetting.SliderSetting.Step = value <= 1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置分割条的值, 比如: 30.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示分割条的值, 比如: 30" )]
		[NotifyParentProperty ( true )]
		public int Value
		{
			get { return this.getInteger ( this.widgetSetting.SliderSetting.Value, 0 ); }
			set { this.widgetSetting.SliderSetting.Value = value <= 0 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置分割条的范围值, 比如: [1, 4, 10].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的范围值, 比如: [1, 4, 10]" )]
		[NotifyParentProperty ( true )]
		public string Values
		{
			get { return this.widgetSetting.SliderSetting.Values; }
			set { this.widgetSetting.SliderSetting.Values = value; }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置分割条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.SliderSetting.Create; }
			set { this.widgetSetting.SliderSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置分割条开始拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条开始拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.widgetSetting.SliderSetting.Start; }
			set { this.widgetSetting.SliderSetting.Start = value; }
		}

		/// <summary>
		/// 获取或设置分割条拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Slide
		{
			get { return this.widgetSetting.SliderSetting.Slide; }
			set { this.widgetSetting.SliderSetting.Slide = value; }
		}

		/// <summary>
		/// 获取或设置分割条改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.widgetSetting.SliderSetting.Change; }
			set { this.widgetSetting.SliderSetting.Change = value; }
		}

		/// <summary>
		/// 获取或设置分割条结束拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条结束拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.widgetSetting.SliderSetting.Stop; }
			set { this.widgetSetting.SliderSetting.Stop = value; }
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
		[NotifyParentProperty ( true )]
		public AjaxSettingEdit ChangeAsync
		{
			get { return this.changeAjax; }
		}
		#endregion

		#region " Server "
		/// <summary>
		/// 在服务器端执行的值改变事件.
		/// </summary>
		[Description ( "指示值改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event SliderChangeEventHandler ChangeSync;
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.SliderSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.changeAjax.Url != string.Empty )
				{
					this.changeAjax.WidgetEventType = EventType.slidechange;
					this.widgetSetting.AjaxSettings.Add ( this.changeAjax );
				}

				if ( null != this.ChangeSync )
					this.Change = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "change;[%':ui.value%]" ) + "}";

			}
			else if ( this.selector == string.Empty )
				switch ( this.widgetSetting.Type )
				{
					case WidgetType.slider:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );
						//<DIV id=Sd class="ui-slider ui-slider-horizontal ui-widget ui-widget-content ui-corner-all" jQuery151036562766734722585="10"><A style="LEFT: 15%" class="ui-slider-handle ui-state-default ui-corner-all" href="http://localhost:55735/TestJQueryUI.aspx#" jQuery151036562766734722585="11"></A></DIV>
						writer.Write (
							"<{6} id=\"{0}\" class=\"{3}ui-slider ui-slider-{7} ui-widget ui-widget-content ui-corner-all{2}\" style=\"{4}\" title=\"{5}\"><a style=\"left: {1}%;\" class=\"ui-slider-handle ui-state-default ui-corner-all\"></div></{6}>",
							this.ClientID,
							this.Value / this.Max,
							this.Disabled ? " ui-slider-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( ),
							this.Orientation
							);
						return;
				}

			base.Render ( writer );
		}

		private void onChange ( SliderEventArgs e )
		{ this.Value = e.Value; }

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
						SliderEventArgs e = new SliderEventArgs ( StringConvert.ToObject<int> ( parts[1] ) );

						this.onChange ( e );
						this.ChangeSync ( this, e );
					}

					break;

			}

		}

	}

	#region " SliderDesigner "
	/// <summary>
	/// 分割条设计器.
	/// </summary>
	public class SliderDesigner : JQueryElementDesigner
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
	/// 分割条值改变事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void SliderChangeEventHandler ( object sender, SliderEventArgs e );

	/// <summary>
	/// 分割条事件参数.
	/// </summary>
	public sealed class SliderEventArgs
	{
		/// <summary>
		/// 值.
		/// </summary>
		public readonly int Value;

		/// <summary>
		/// 创建一个分割条事件参数.
		/// </summary>
		/// <param name="value">值.</param>
		public SliderEventArgs ( int value )
		{

			if ( value < 0 )
				value = 0;

			this.Value = value;
		}

	}

}
// ../.class/ui/jqueryui/Tabs.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITabs
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Tabs.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 分组标签插件.
	/// </summary>
	[ToolboxData ( "<{0}:Tabs runat=server></{0}:Tabs>" )]
	[Designer ( typeof ( TabsDesigner ) )]
	public class Tabs
		: BaseWidget, IPostBackEventHandler
	{
		private readonly AjaxSettingEdit selectAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 分组标签.
		/// </summary>
		public Tabs ( )
			: base ( WidgetType.tabs )
		{ this.elementType = ElementType.Div; }

		#region " Option "
		/// <summary>
		/// 获取或设置分组标签是否可用, 或者禁用的标签的索引, 可以设置为 true, false, 或者 [0, 1].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示分组标签是否可用, 或者禁用的标签的索引, 可以设置为 true, false, 或者 [0, 1]" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.TabsSetting.Disabled, false ); }
			set { this.widgetSetting.TabsSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置标签内容的 Ajax 选项, 比如: { async: false }.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签内容的 Ajax 选项, 比如: { async: false }" )]
		[NotifyParentProperty ( true )]
		public string AjaxOptions
		{
			get { return this.widgetSetting.TabsSetting.AjaxOptions; }
			set { this.widgetSetting.TabsSetting.AjaxOptions = value; }
		}

		/// <summary>
		/// 获取或设置是否使用缓存, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否使用缓存, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Cache
		{
			get { return this.getBoolean ( this.widgetSetting.TabsSetting.Cache, false ); }
			set { this.widgetSetting.TabsSetting.Cache = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置当再次选择已选中的标签时, 是否取消选中状态, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示当再次选择已选中的标签时, 是否取消选中状态, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Collapsible
		{
			get { return this.getBoolean ( this.widgetSetting.TabsSetting.Collapsible, false ); }
			set { this.widgetSetting.TabsSetting.Collapsible = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置 cookie 的设置, 比如: { expires: 7, path: '/', domain: 'jquery.com', secure: true }.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 cookie 的设置, 比如: { expires: 7, path: '/', domain: 'jquery.com', secure: true }" )]
		[NotifyParentProperty ( true )]
		public string Cookie
		{
			get { return this.widgetSetting.TabsSetting.Cookie; }
			set { this.widgetSetting.TabsSetting.Cookie = value; }
		}

		/// <summary>
		/// 请使用 Collapsible.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "请使用 Collapsible" )]
		[NotifyParentProperty ( true )]
		public bool Deselectable
		{
			get { return this.getBoolean ( this.widgetSetting.TabsSetting.Deselectable, false ); }
			set { this.widgetSetting.TabsSetting.Deselectable = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置触发切换的事件名称, 默认: click.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( EventType.click )]
		[Description ( "指示触发切换的事件名称, 默认: click" )]
		[NotifyParentProperty ( true )]
		public EventType Event
		{
			get { return this.getEnum<EventType> ( this.widgetSetting.TabsSetting.Event, EventType.click ); }
			set { this.widgetSetting.TabsSetting.Event = "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置显示或者隐藏的动画效果, 比如: { opacity: 'toggle' }, 'slow', 'normal', 'fast'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示或者隐藏的动画效果, 比如: { opacity: 'toggle' }, 'slow', 'normal', 'fast'" )]
		[NotifyParentProperty ( true )]
		public string Fx
		{
			get { return this.widgetSetting.TabsSetting.Fx; }
			set { this.widgetSetting.TabsSetting.Fx = value; }
		}

		/// <summary>
		/// 获取或设置 id 的前缀, 默认为 ui-tabs-.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 id 的前缀, 默认为 ui-tabs-" )]
		[NotifyParentProperty ( true )]
		public string IdPrefix
		{
			get { return this.widgetSetting.TabsSetting.IdPrefix.Trim ( '\'' ); }
			set { this.widgetSetting.TabsSetting.IdPrefix = string.IsNullOrEmpty ( value ) || value == "ui-tabs-" ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置面板的模板内容.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示面板的模板内容, 默认为 <div></div>" )]
		[NotifyParentProperty ( true )]
		public string PanelTemplate
		{
			get { return this.widgetSetting.TabsSetting.PanelTemplate.Trim ( '\'' ); }
			set { this.widgetSetting.TabsSetting.PanelTemplate = string.IsNullOrEmpty ( value ) || value == "<div></div>" ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置选中的标签, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示选中的标签, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public int Selected
		{
			get { return this.getInteger ( this.widgetSetting.TabsSetting.Selected, 0 ); }
			set { this.widgetSetting.TabsSetting.Selected = value <= 0 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置载入条的内容.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示载入条的内容" )]
		[NotifyParentProperty ( true )]
		public string Spinner
		{
			get { return this.widgetSetting.TabsSetting.Spinner.Trim ( '\'' ); }
			set { this.widgetSetting.TabsSetting.Spinner = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置表头的模板内容.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示表头的模板内容, 默认为 '<li><a href=#{href}><span>#{label}</span></a></li>'" )]
		[NotifyParentProperty ( true )]
		public string TabTemplate
		{
			get { return this.widgetSetting.TabsSetting.TabTemplate.Trim ( '\'' ); }
			set { this.widgetSetting.TabsSetting.TabTemplate = string.IsNullOrEmpty ( value ) || value == "<li><a href=#{href}><span>#{label}</span></a></li>" ? string.Empty : "'" + value + "'"; }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置分组标签被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.TabsSetting.Create; }
			set { this.widgetSetting.TabsSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置分组标签被选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.widgetSetting.TabsSetting.Select; }
			set { this.widgetSetting.TabsSetting.Select = value; }
		}

		/// <summary>
		/// 获取或设置内容载入时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示内容载入时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public new string Load
		{
			get { return this.widgetSetting.TabsSetting.Load; }
			set { this.widgetSetting.TabsSetting.Load = value; }
		}

		/// <summary>
		/// 获取或设置标签显示时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签显示时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.widgetSetting.TabsSetting.Show; }
			set { this.widgetSetting.TabsSetting.Show = value; }
		}

		/// <summary>
		/// 获取或设置标签被添加时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被添加时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Add
		{
			get { return this.widgetSetting.TabsSetting.Add; }
			set { this.widgetSetting.TabsSetting.Add = value; }
		}

		/// <summary>
		/// 获取或设置标签被删除时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被删除时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.widgetSetting.TabsSetting.Remove; }
			set { this.widgetSetting.TabsSetting.Remove = value; }
		}

		/// <summary>
		/// 获取或设置标签被启用时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被启用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Enable
		{
			get { return this.widgetSetting.TabsSetting.Enable; }
			set { this.widgetSetting.TabsSetting.Enable = value; }
		}

		/// <summary>
		/// 获取或设置标签被禁用时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被禁用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Disable
		{
			get { return this.widgetSetting.TabsSetting.Disable; }
			set { this.widgetSetting.TabsSetting.Disable = value; }
		}
		#endregion

		#region " Ajax "
		/// <summary>
		/// 获取 Select 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Select 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSettingEdit SelectAsync
		{
			get { return this.selectAjax; }
		}
		#endregion

		#region " Server "
		/// <summary>
		/// 在服务器端执行的选中索引改变事件.
		/// </summary>
		[Description ( "指示选中索引改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event TabsSelectEventHandler SelectSync;
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.TabsSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.selectAjax.Url != string.Empty )
				{
					this.selectAjax.WidgetEventType = EventType.tabsselect;
					this.widgetSetting.AjaxSettings.Add ( this.selectAjax );
				}


				if ( null != this.SelectSync )
					this.Select = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "select;[%':ui.index%]" ) + "}";

			}
			else if ( this.selector == string.Empty )
				switch ( this.widgetSetting.Type )
				{
					case WidgetType.tabs:
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

								XmlNode titleNode = xml.FirstChild.FirstChild;

								titleNode.Attributes.Append ( xml.CreateAttribute ( "class" ) ).Value = "ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all";

								for ( int index = 0; index < titleNode.ChildNodes.Count; index++ )
									titleNode.ChildNodes[index].Attributes.Append ( xml.CreateAttribute ( "class" ) ).Value = "ui-state-default ui-corner-top" + ( index == this.Selected ? " ui-tabs-selected ui-state-active" : string.Empty );

								for ( int index = 1; index < xml.FirstChild.ChildNodes.Count; index++ )
									xml.FirstChild.ChildNodes[index].Attributes.Append ( xml.CreateAttribute ( "class" ) ).Value = "ui-tabs-panel ui-widget-content ui-corner-bottom" + ( index - 1 == this.Selected ? string.Empty : " ui-tabs-hide" );

								html = xml.FirstChild.InnerXml;
							}
							catch ( Exception err ) { html = err.Message; }

						writer.Write (
							"<{6} id=\"{0}\" class=\"{3}ui-tabs ui-widget ui-widget-content ui-corner-all{2}\" style=\"{4}\" title=\"{5}\">{1}</{6}>",
							this.ClientID,
							html,
							this.Disabled ? " ui-tabs-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( )
							);
						return;
				}

			base.Render ( writer );
		}

		private void onSelect ( TabsEventArgs e )
		{ this.Selected = e.Index; }

		public void RaisePostBackEvent ( string eventArgument )
		{

			if ( string.IsNullOrEmpty ( eventArgument ) )
				return;

			string[] parts = eventArgument.Split ( ';' );

			switch ( parts[0] )
			{
				case "select":

					if ( null != this.SelectSync )
					{
						TabsEventArgs e = new TabsEventArgs ( StringConvert.ToObject<int> ( parts[1] ) );

						this.onSelect ( e );
						this.SelectSync ( this, e );
					}

					break;
			}

		}

	}

	#region " TabsDesigner "
	/// <summary>
	/// 分组标签设计器.
	/// </summary>
	public class TabsDesigner : JQueryElementDesigner
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
	/// 分组标签选中索引改变事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void TabsSelectEventHandler ( object sender, TabsEventArgs e );

	/// <summary>
	/// 分组标签事件参数.
	/// </summary>
	public sealed class TabsEventArgs
	{
		/// <summary>
		/// 索引.
		/// </summary>
		public readonly int Index;

		/// <summary>
		/// 创建一个分组标签事件参数.
		/// </summary>
		/// <param name="index">索引.</param>
		public TabsEventArgs ( int index )
		{

			if ( index < 0 )
				index = 0;

			this.Index = index;
		}

	}

}
// ../.class/ui/jqueryui/JQueryElement.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryElement
 * http://code.google.com/p/zsharedcode/wiki/JQueryElementConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryElementType
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIBaseWidget
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryElement.cs
 * 版本: 2.6.1, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " JQueryElement "
	/// <summary>
	/// 实现 jQuery UI 的服务器控件.
	/// </summary>
	// [DefaultProperty ( "Html" )]
	[ToolboxData ( "<{0}:JQueryElement runat=server></{0}:JQueryElement>" )]
	[DesignerAttribute ( typeof ( JQueryElementDesigner ) )]
	public class JQueryElement
		: BaseJQueryElement
	{

		/// <summary>
		/// 获取或设置元素的拖动设置.
		/// </summary>
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override DraggableSettingEdit DraggableSetting
		{
			get { return base.DraggableSetting; }
			set { base.DraggableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的拖放设置.
		/// </summary>
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override DroppableSettingEdit DroppableSetting
		{
			get { return base.DroppableSetting; }
			set { base.DroppableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的排列设置.
		/// </summary>
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override SortableSettingEdit SortableSetting
		{
			get { return base.SortableSetting; }
			set { base.SortableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的选中设置.
		/// </summary>
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override SelectableSettingEdit SelectableSetting
		{
			get { return base.SelectableSetting; }
			set { base.SelectableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的缩放设置.
		/// </summary>
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override ResizableSettingEdit ResizableSetting
		{
			get { return base.ResizableSetting; }
			set { base.ResizableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的 Widget 设置.
		/// </summary>
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override WidgetSettingEdit WidgetSetting
		{
			get { return base.WidgetSetting; }
			set { base.WidgetSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的 Repeater 设置.
		/// </summary>
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override RepeaterSettingEdit RepeaterSetting
		{
			get { return base.RepeaterSetting; }
			set { base.RepeaterSetting = value; }
		}

		/// <summary>
		/// 获取 PlaceHolder 控件, 其中包含了元素中包含的 html 代码. 
		/// </summary>
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override PlaceHolder Html
		{
			get { return base.Html; }
		}

		/// <summary>
		/// 创建一个 JQueryElement.
		/// </summary>
		public JQueryElement ( )
			: base ( )
		{ }

	}
	#endregion

	#region " JQueryElementDesigner "
	/// <summary>
	/// JQueryElement 设计器.
	/// </summary>
	public class JQueryElementDesigner : ControlDesigner
	{

		/// <summary>
		/// 获取行为列表.
		/// </summary>
		public override DesignerActionListCollection ActionLists
		{
			get
			{

				DesignerActionListCollection actions = new DesignerActionListCollection ( );
				actions.Add ( new BaseDesignerAction ( this ) );

				switch ( this.JQueryElement.WidgetSetting.Type )
				{
					case WidgetType.accordion:
						actions.Add ( new AccordionDesignerAction ( this ) );
						break;

					case WidgetType.autocomplete:
						actions.Add ( new AutocompleteDesignerAction ( this ) );
						break;

					case WidgetType.button:
						actions.Add ( new ButtonDesignerAction ( this ) );
						break;

					case WidgetType.datepicker:
						actions.Add ( new DatepickerDesignerAction ( this ) );
						break;

					case WidgetType.dialog:
						actions.Add ( new DialogDesignerAction ( this ) );
						break;

					case WidgetType.progressbar:
						actions.Add ( new ProgressbarDesignerAction ( this ) );
						break;

					case WidgetType.slider:
						actions.Add ( new SliderDesignerAction ( this ) );
						break;

					case WidgetType.tabs:
						actions.Add ( new TabsDesignerAction ( this ) );
						break;
				}

				if ( this.JQueryElement.WidgetSetting.Type != WidgetType.none )
					actions.Add ( new AjaxDesignerAction ( this ) );

				if ( this.JQueryElement.DraggableSetting.IsDraggable )
					actions.Add ( new DraggableDesignerAction ( this ) );

				if ( this.JQueryElement.DroppableSetting.IsDroppable )
					actions.Add ( new DroppableDesignerAction ( this ) );

				if ( this.JQueryElement.ResizableSetting.IsResizable )
					actions.Add ( new ResizableDesignerAction ( this ) );

				if ( this.JQueryElement.SelectableSetting.IsSelectable )
					actions.Add ( new SelectableDesignerAction ( this ) );

				if ( this.JQueryElement.SortableSetting.IsSortable )
					actions.Add ( new SortableDesignerAction ( this ) );

				return actions;
			}
		}

		/// <summary>
		/// 获取 JQueryElement 对象.
		/// </summary>
		public JQueryElement JQueryElement
		{
			get { return this.Component as JQueryElement; }
		}

		#region " JQueryElementDesignerAction "
		/// <summary>
		/// JQueryElement 的设计行为.
		/// </summary>
		public class JQueryElementDesignerAction : DesignerActionList
		{
			protected readonly JQueryElementDesigner designer;

			/// <summary>
			/// 获取 JQueryElement 对象.
			/// </summary>
			public JQueryElement JQueryElement
			{
				get { return this.Component as JQueryElement; }
			}

			/// <summary>
			/// 创建 JQueryElement 的设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public JQueryElementDesignerAction ( JQueryElementDesigner designer )
				: base ( designer.Component )
			{ this.designer = designer; }

			protected bool fetchEnum<T> ( string text, T defalutValue, out T value )
				where T : struct
			{
				value = defalutValue;

				bool isSuccess = true;
				int test;

				if ( !string.IsNullOrEmpty ( text ) )
					if ( this.fetchInteger ( text, 0, out test ) )
						isSuccess = false;
					else
						// HACK: 可能需要添加 V5
#if V4
						isSuccess = Enum.TryParse<T> ( text.Trim ( '\'' ).Trim ( '"' ), out value );
#else
						try
						{ value = ( T ) Enum.Parse ( typeof ( T ), text.Trim ( '\'' ).Trim ( '"' ), true ); }
						catch
						{ isSuccess = false; }
#endif

				return isSuccess;
			}

			protected bool fetchBoolean ( string text, bool defaultValue, out bool value )
			{
				value = defaultValue;

				bool isSuccess;

				if ( string.IsNullOrEmpty ( text ) )
					isSuccess = false;
				else
					isSuccess = bool.TryParse ( text, out value );

				return isSuccess;
			}

			protected bool fetchDecimal ( string text, decimal defaultValue, out decimal value )
			{
				value = defaultValue;

				bool isSuccess;

				if ( string.IsNullOrEmpty ( text ) )
					isSuccess = false;
				else
					isSuccess = decimal.TryParse ( text, out value );

				return isSuccess;
			}

			protected bool fetchInteger ( string text, int defaultValue, out int value )
			{
				value = defaultValue;

				bool isSuccess;

				if ( string.IsNullOrEmpty ( text ) )
					isSuccess = false;
				else
					isSuccess = int.TryParse ( text, out value );

				return isSuccess;
			}

			protected void refreshWidgetSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["WidgetSetting"].SetValue ( this.JQueryElement, this.JQueryElement.WidgetSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshDraggableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["DraggableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.DraggableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshDroppableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["DroppableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.DroppableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshResizableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["ResizableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.ResizableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshSelectableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["SelectableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.SelectableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshSortableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["SortableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.SortableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

		}
		#endregion

		#region " BaseDesignerAction "
		/// <summary>
		/// JQueryElement 的基本设计行为.
		/// </summary>
		public class BaseDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建 JQueryElement 的基本设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public BaseDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );
				items.Add ( new DesignerActionHeaderItem ( "基本设置", "base" ) );
				items.Add ( new DesignerActionPropertyItem ( "ElementType", "元素类型", "base" ) );
				items.Add ( new DesignerActionPropertyItem ( "WidgetSettingType", "Widget 类型", "base" ) );
				items.Add ( new DesignerActionPropertyItem ( "Selector", "选择器", "base", "选择器, 将针对此选择器对应的元素执行操作, 比如: \"'#age'\", 默认为自身" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsVariable", "生成 javascript 变量", "base" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsDraggable", "启用拖动", "base-e" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsDroppable", "启用拖放", "base-e" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsResizable", "启用缩放", "base-e" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsSelectable", "启用选中", "base-e" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsSortable", "启用排列", "base-e" ) );

				return items;
			}

			/// <summary>
			/// 获取或设置页面元素类型.
			/// </summary>
			public ElementType ElementType
			{
				get
				{ return this.JQueryElement.ElementType; }
				set
				{
					TypeDescriptor.GetProperties ( this.JQueryElement )["ElementType"].SetValue ( this.JQueryElement, value );
					this.designer.UpdateDesignTimeHtml ( );
				}
			}

			/// <summary>
			/// 获取或设置 Widget 类型.
			/// </summary>
			public WidgetType WidgetSettingType
			{
				get
				{ return this.JQueryElement.WidgetSetting.Type; }
				set
				{
					this.JQueryElement.WidgetSetting.Type = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置选择器.
			/// </summary>
			public string Selector
			{
				get
				{ return this.JQueryElement.Selector; }
				set
				{
					TypeDescriptor.GetProperties ( this.JQueryElement )["Selector"].SetValue ( this.JQueryElement, value );
					this.designer.UpdateDesignTimeHtml ( );
				}
			}

			/// <summary>
			/// 获取或设置是否生成 javascript 变量.
			/// </summary>
			public bool IsVariable
			{
				get { return this.JQueryElement.IsVariable; }
				set { TypeDescriptor.GetProperties ( this.JQueryElement )["IsVariable"].SetValue ( this.JQueryElement, value ); }
			}

			/// <summary>
			/// 获取或设置是否可以拖动.
			/// </summary>
			public bool IsDraggable
			{
				get { return this.JQueryElement.DraggableSetting.IsDraggable; }
				set
				{
					this.JQueryElement.DraggableSetting.IsDraggable = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以拖放.
			/// </summary>
			public bool IsDroppable
			{
				get { return this.JQueryElement.DroppableSetting.IsDroppable; }
				set
				{
					this.JQueryElement.DroppableSetting.IsDroppable = value;
					this.refreshDroppableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以缩放.
			/// </summary>
			public bool IsResizable
			{
				get { return this.JQueryElement.ResizableSetting.IsResizable; }
				set
				{
					this.JQueryElement.ResizableSetting.IsResizable = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以选中.
			/// </summary>
			public bool IsSelectable
			{
				get { return this.JQueryElement.SelectableSetting.IsSelectable; }
				set
				{
					this.JQueryElement.SelectableSetting.IsSelectable = value;
					this.refreshSelectableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以排列.
			/// </summary>
			public bool IsSortable
			{
				get { return this.JQueryElement.SortableSetting.IsSortable; }
				set
				{
					this.JQueryElement.SortableSetting.IsSortable = value;
					this.refreshSortableSetting ( );
				}
			}

		}
		#endregion

		#region " DraggableDesignerAction "
		/// <summary>
		/// 拖动的设计行为.
		/// </summary>
		public class DraggableDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// Axis 类型.
			/// </summary>
			public enum AxisType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// x 轴拖动.
				/// </summary>
				x = 1,
				/// <summary>
				/// y 轴拖动.
				/// </summary>
				y = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Containment 类型.
			/// </summary>
			public enum ContainmentType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 容器为 parent.
				/// </summary>
				parent = 1,
				/// <summary>
				/// 容器为 document.
				/// </summary>
				document = 2,
				/// <summary>
				/// 容器为 window.
				/// </summary>
				window = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Helper 类型.
			/// </summary>
			public enum HelperType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 使用自身.
				/// </summary>
				original = 1,
				/// <summary>
				/// 使用副本.
				/// </summary>
				clone = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// SnapMode 类型.
			/// </summary>
			public enum SnapModeType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 内部附着.
				/// </summary>
				inner = 1,
				/// <summary>
				/// 外部附着.
				/// </summary>
				outer = 2,
				/// <summary>
				/// 内部和外部附着.
				/// </summary>
				both = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个拖动设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public DraggableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "拖动设置", "draggable" ) );

				AxisType axisType;

				if ( this.fetchEnum<AxisType> ( this.JQueryElement.DraggableSetting.Axis, AxisType.@null, out axisType ) )
					items.Add ( new DesignerActionPropertyItem ( "Axis", "方向", "draggable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AxisText", "方向", "draggable", "指示拖动的方向, 可以是 'x', 'y'" ) );

				ContainmentType containmentType;

				if ( this.fetchEnum<ContainmentType> ( this.JQueryElement.DraggableSetting.Containment, ContainmentType.@null, out containmentType ) )
					items.Add ( new DesignerActionPropertyItem ( "Containment", "容器", "draggable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ContainmentText", "容器", "draggable", "指示拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" ) );

				HelperType helperType;

				if ( this.fetchEnum<HelperType> ( this.JQueryElement.DraggableSetting.Helper, HelperType.@null, out helperType ) )
					items.Add ( new DesignerActionPropertyItem ( "Helper", "helper", "draggable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "HelperText", "helper", "draggable", "指示是否使用副本 'original' 针对元素本身, 'clone' 针对元素的副本" ) );

				decimal opacity;

				if ( this.fetchDecimal ( this.JQueryElement.DraggableSetting.Opacity, 1, out opacity ) )
					items.Add ( new DesignerActionPropertyItem ( "Opacity", "透明度", "draggable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "OpacityText", "透明度", "draggable" ) );

				bool isRevert;

				if ( this.JQueryElement.DraggableSetting.Revert == string.Empty || this.fetchBoolean ( this.JQueryElement.DraggableSetting.Revert, false, out isRevert ) )
				{
					items.Add ( new DesignerActionPropertyItem ( "Revert", "播放恢复动画", "draggable" ) );

					if ( this.Revert )
						items.Add ( new DesignerActionPropertyItem ( "RevertDuration", "恢复动画时长", "draggable" ) );

				}
				else
				{
					items.Add ( new DesignerActionPropertyItem ( "RevertText", "播放恢复动画", "draggable", "指示是否在拖动后播放恢复原位的动画, 比如: true, 或者是 'valid', 'invalid'" ) );
					items.Add ( new DesignerActionPropertyItem ( "RevertDuration", "恢复动画时长", "draggable" ) );
				}

				items.Add ( new DesignerActionPropertyItem ( "Snap", "附着", "draggable" ) );

				if ( this.Snap )
				{
					items.Add ( new DesignerActionPropertyItem ( "SnapText", "附着目标", "draggable" ) );
					items.Add ( new DesignerActionPropertyItem ( "SnapMode", "附着模式", "draggable" ) );
					items.Add ( new DesignerActionPropertyItem ( "SnapTolerance", "附着距离", "draggable" ) );
				}

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多拖动设置...", "draggable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多拖动设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.DraggableSetting, this.JQueryElement.ID + " 拖动设置" ).ShowDialog ( );
				this.refreshDraggableSetting ( );
			}

			/// <summary>
			/// 获取或设置拖动的方向.
			/// </summary>
			public AxisType Axis
			{
				get
				{
					AxisType type;
					this.fetchEnum<AxisType> ( this.JQueryElement.DraggableSetting.Axis, AxisType.@null, out type );

					return type;
				}
				set
				{

					if ( value == AxisType.other )
						this.JQueryElement.DraggableSetting.Axis = "null /*javascript 代码*/";
					else
						this.JQueryElement.DraggableSetting.Axis = ( value == AxisType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动的方向.
			/// </summary>
			public string AxisText
			{
				get { return this.JQueryElement.DraggableSetting.Axis; }
				set
				{
					this.JQueryElement.DraggableSetting.Axis = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public ContainmentType Containment
			{
				get
				{
					ContainmentType type;
					this.fetchEnum<ContainmentType> ( this.JQueryElement.DraggableSetting.Containment, ContainmentType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ContainmentType.other )
						this.JQueryElement.DraggableSetting.Containment = "null /*javascript 代码*/";
					else
						this.JQueryElement.DraggableSetting.Containment = ( value == ContainmentType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public string ContainmentText
			{
				get { return this.JQueryElement.DraggableSetting.Containment; }
				set
				{
					this.JQueryElement.DraggableSetting.Containment = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否使用副本.
			/// </summary>
			public HelperType Helper
			{
				get
				{
					HelperType type;
					this.fetchEnum<HelperType> ( this.JQueryElement.DraggableSetting.Helper, HelperType.@null, out type );

					return type;
				}
				set
				{

					if ( value == HelperType.other )
						this.JQueryElement.DraggableSetting.Helper = "null /*javascript 代码*/";
					else
						this.JQueryElement.DraggableSetting.Helper = ( value == HelperType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置使用副本.
			/// </summary>
			public string HelperText
			{
				get { return this.JQueryElement.DraggableSetting.Helper; }
				set
				{
					this.JQueryElement.DraggableSetting.Helper = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动时的透明度.
			/// </summary>
			public decimal Opacity
			{
				get
				{
					decimal opacity;
					this.fetchDecimal ( this.JQueryElement.DraggableSetting.Opacity, 1, out opacity );

					return opacity;
				}
				set
				{

					this.JQueryElement.DraggableSetting.Opacity = ( value < 0 || value >= 1 ) ? string.Empty : value.ToString ( );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动时的透明度.
			/// </summary>
			public string OpacityText
			{
				get { return this.JQueryElement.DraggableSetting.Opacity; }
				set
				{
					this.JQueryElement.DraggableSetting.Opacity = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复原位的动画.
			/// </summary>
			public bool Revert
			{
				get
				{
					bool isRevert;
					this.fetchBoolean ( this.JQueryElement.DraggableSetting.Revert, false, out isRevert );

					return isRevert;
				}
				set
				{
					this.JQueryElement.DraggableSetting.Revert = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复原位的动画.
			/// </summary>
			public string RevertText
			{
				get { return this.JQueryElement.DraggableSetting.Revert; }
				set
				{
					this.JQueryElement.DraggableSetting.Revert = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复原位的动画时长.
			/// </summary>
			public int RevertDuration
			{
				get
				{
					int duration;
					this.fetchInteger ( this.JQueryElement.DraggableSetting.RevertDuration, 500, out duration );

					return duration;
				}
				set
				{
					this.JQueryElement.DraggableSetting.RevertDuration = ( value < 0 || value == 500 ? string.Empty : value.ToString ( ) );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否附着.
			/// </summary>
			public bool Snap
			{
				get { return this.JQueryElement.DraggableSetting.Snap != string.Empty; }
				set
				{
					this.JQueryElement.DraggableSetting.Snap = ( value ? "null /*选择器*/" : string.Empty );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置附着的目标.
			/// </summary>
			public string SnapText
			{
				get { return this.JQueryElement.DraggableSetting.Snap; }
				set
				{
					this.JQueryElement.DraggableSetting.Snap = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置附着模式.
			/// </summary>
			public SnapModeType SnapMode
			{
				get
				{
					SnapModeType type;
					this.fetchEnum<SnapModeType> ( this.JQueryElement.DraggableSetting.SnapMode, SnapModeType.@null, out type );

					return type;
				}
				set
				{

					if ( value == SnapModeType.other )
						this.JQueryElement.DraggableSetting.SnapMode = "null /*javascript 代码*/";
					else
						this.JQueryElement.DraggableSetting.SnapMode = ( value == SnapModeType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置附着模式.
			/// </summary>
			public string SnapModeText
			{
				get { return this.JQueryElement.DraggableSetting.SnapMode; }
				set
				{
					this.JQueryElement.DraggableSetting.SnapMode = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置附着模式的有效距离.
			/// </summary>
			public int SnapTolerance
			{
				get
				{
					int tolerance;
					this.fetchInteger ( this.JQueryElement.DraggableSetting.SnapTolerance, 20, out tolerance );

					return tolerance;
				}
				set
				{
					this.JQueryElement.DraggableSetting.SnapTolerance = ( value < 0 || value == 20 ? string.Empty : value.ToString ( ) );

					this.refreshDraggableSetting ( );
				}
			}

		}
		#endregion

		#region " DroppableDesignerAction "
		/// <summary>
		/// 拖放的设计行为.
		/// </summary>
		public class DroppableDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// Tolerance 类型.
			/// </summary>
			public enum ToleranceType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 完全进入可以拖放.
				/// </summary>
				fit = 1,
				/// <summary>
				/// 一半进入可以拖放.
				/// </summary>
				intersect = 2,
				/// <summary>
				/// 鼠标进入即可拖放.
				/// </summary>
				pointer = 3,
				/// <summary>
				/// 接触即可拖放.
				/// </summary>
				touch = 4,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// 创建一个拖放设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public DroppableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "拖放设置", "droppable" ) );

				items.Add ( new DesignerActionPropertyItem ( "Accept", "接受目标", "droppable", "指示拖放接受的目标, 对应一个函数或者选择器" ) );

				ToleranceType toleranceType;

				if ( this.fetchEnum<ToleranceType> ( this.JQueryElement.DroppableSetting.Tolerance, ToleranceType.@null, out toleranceType ) )
					items.Add ( new DesignerActionPropertyItem ( "Tolerance", "触发方式", "droppable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ToleranceText", "触发方式", "droppable", "拖放的触发方式, 可以是 'fit', 'intersect', 'pointer', 'touch'" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多拖放设置...", "droppable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多拖放设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.DroppableSetting, this.JQueryElement.ID + " 拖放设置" ).ShowDialog ( );
				this.refreshDroppableSetting ( );
			}

			/// <summary>
			/// 获取或设置拖动接受的目标.
			/// </summary>
			public string Accept
			{
				get { return this.JQueryElement.DroppableSetting.Accept; }
				set
				{
					this.JQueryElement.DroppableSetting.Accept = value;
					this.refreshDroppableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动触发方式.
			/// </summary>
			public ToleranceType Tolerance
			{
				get
				{
					ToleranceType type;
					this.fetchEnum<ToleranceType> ( this.JQueryElement.DroppableSetting.Tolerance, ToleranceType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ToleranceType.other )
						this.JQueryElement.DroppableSetting.Tolerance = "null /*javascript 代码*/";
					else
						this.JQueryElement.DroppableSetting.Tolerance = ( value == ToleranceType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDroppableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动触发方式.
			/// </summary>
			public string ToleranceText
			{
				get { return this.JQueryElement.DroppableSetting.Tolerance; }
				set
				{
					this.JQueryElement.DroppableSetting.Tolerance = value;
					this.refreshDroppableSetting ( );
				}
			}

		}
		#endregion

		#region " ResizableDesignerAction "
		/// <summary>
		/// 缩放的设计行为.
		/// </summary>
		public class ResizableDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// AnimateDuration 类型.
			/// </summary>
			public enum AnimateDurationType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 缓慢的播放.
				/// </summary>
				slow = 1,
				/// <summary>
				/// 正常的播放.
				/// </summary>
				normal = 2,
				/// <summary>
				/// 快速的播放.
				/// </summary>
				fast = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Containment 类型.
			/// </summary>
			public enum ContainmentType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 容器为 parent.
				/// </summary>
				parent = 1,
				/// <summary>
				/// 容器为 document.
				/// </summary>
				document = 2,
				/// <summary>
				/// 容器为 window.
				/// </summary>
				window = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个缩放设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public ResizableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "缩放设置", "resizable" ) );

				ContainmentType containmentType;

				if ( this.fetchEnum<ContainmentType> ( this.JQueryElement.ResizableSetting.Containment, ContainmentType.@null, out containmentType ) )
					items.Add ( new DesignerActionPropertyItem ( "Containment", "容器", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ContainmentText", "容器", "resizable", "指示缩放所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" ) );

				items.Add ( new DesignerActionPropertyItem ( "Handles", "方向", "resizable", "指示缩放的方向, 为一个字符串, 比如: 'n, e, s, w', 可以从 'n, e, s, w, ne, se, sw, nw, all' 中取值" ) );

				int maxHeight;

				if ( this.fetchInteger ( this.JQueryElement.ResizableSetting.MaxHeight, 0, out maxHeight ) )
					items.Add ( new DesignerActionPropertyItem ( "MaxHeight", "最大高度", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MaxHeightText", "最大高度", "resizable" ) );

				int maxWidth;

				if ( this.fetchInteger ( this.JQueryElement.ResizableSetting.MaxWidth, 0, out maxWidth ) )
					items.Add ( new DesignerActionPropertyItem ( "MaxWidth", "最大宽度", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MaxWidthText", "最大宽度", "resizable" ) );

				int minHeight;

				if ( this.fetchInteger ( this.JQueryElement.ResizableSetting.MinHeight, 0, out minHeight ) )
					items.Add ( new DesignerActionPropertyItem ( "MinHeight", "最小高度", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MinHeightText", "最小高度", "resizable" ) );

				int minWidth;

				if ( this.fetchInteger ( this.JQueryElement.ResizableSetting.MinWidth, 0, out minWidth ) )
					items.Add ( new DesignerActionPropertyItem ( "MinWidth", "最小宽度", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MinWidthText", "最小宽度", "resizable" ) );

				bool isGhost;

				if ( this.JQueryElement.ResizableSetting.Ghost == string.Empty || this.fetchBoolean ( this.JQueryElement.ResizableSetting.Ghost, false, out isGhost ) )
					items.Add ( new DesignerActionPropertyItem ( "Ghost", "使用背影", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "GhostText", "使用背影", "resizable", "指示是否在缩放时使用阴影, 可以设置为 true 或者 false" ) );

				bool isAutoHide;

				if ( this.JQueryElement.ResizableSetting.AutoHide == string.Empty || this.fetchBoolean ( this.JQueryElement.ResizableSetting.AutoHide, false, out isAutoHide ) )
					items.Add ( new DesignerActionPropertyItem ( "AutoHide", "自动隐藏", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AutoHideText", "自动隐藏", "resizable", "指示是否自动隐藏, 可以设置为 true 或者 false" ) );

				bool isAnimate;

				if ( this.JQueryElement.ResizableSetting.Animate == string.Empty || this.fetchBoolean ( this.JQueryElement.ResizableSetting.Animate, false, out isAnimate ) )
				{
					items.Add ( new DesignerActionPropertyItem ( "Animate", "播放缩放动画", "resizable" ) );

					if ( this.Animate )
					{
						AnimateDurationType animateDurationType;

						if ( this.fetchEnum<AnimateDurationType> ( this.JQueryElement.ResizableSetting.AnimateDuration, AnimateDurationType.@null, out animateDurationType ) )
							items.Add ( new DesignerActionPropertyItem ( "AnimateDuration", "缩放动画时长", "resizable" ) );
						else
							items.Add ( new DesignerActionPropertyItem ( "AnimateDurationText", "缩放动画时长", "resizable" ) );

						items.Add ( new DesignerActionPropertyItem ( "AnimateEasing", "缩放动画效果", "resizable" ) );
					}

				}
				else
				{
					items.Add ( new DesignerActionPropertyItem ( "AnimateText", "播放缩放动画", "resizable", "指示是否播放缩放的动画, 可以设置为 true 或者 false" ) );

					AnimateDurationType animateDurationType;

					if ( this.fetchEnum<AnimateDurationType> ( this.JQueryElement.ResizableSetting.AnimateDuration, AnimateDurationType.@null, out animateDurationType ) )
						items.Add ( new DesignerActionPropertyItem ( "AnimateDuration", "缩放动画时长", "resizable" ) );
					else
						items.Add ( new DesignerActionPropertyItem ( "AnimateDurationText", "缩放动画时长", "resizable" ) );

					items.Add ( new DesignerActionPropertyItem ( "AnimateEasing", "缩放动画效果", "resizable" ) );
				}


				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多缩放设置...", "resizable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多缩放设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.ResizableSetting, this.JQueryElement.ID + " 缩放设置" ).ShowDialog ( );
				this.refreshResizableSetting ( );
			}

			/// <summary>
			/// 获取或设置是否播放恢复动画.
			/// </summary>
			public bool Animate
			{
				get
				{
					bool isAnimate;
					this.fetchBoolean ( this.JQueryElement.ResizableSetting.Animate, false, out isAnimate );

					return isAnimate;
				}
				set
				{
					this.JQueryElement.ResizableSetting.Animate = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复动画.
			/// </summary>
			public string AnimateText
			{
				get { return this.JQueryElement.ResizableSetting.Animate; }
				set
				{
					this.JQueryElement.ResizableSetting.Animate = value;

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置播放动画的时长.
			/// </summary>
			public AnimateDurationType AnimateDuration
			{
				get
				{
					AnimateDurationType type;
					this.fetchEnum<AnimateDurationType> ( this.JQueryElement.ResizableSetting.AnimateDuration, AnimateDurationType.@null, out type );

					return type;
				}
				set
				{

					if ( value == AnimateDurationType.other )
						this.JQueryElement.ResizableSetting.AnimateDuration = "null /*javascript 代码*/";
					else
						this.JQueryElement.ResizableSetting.AnimateDuration = ( value == AnimateDurationType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置播放动画的时长.
			/// </summary>
			public string AnimateDurationText
			{
				get { return this.JQueryElement.ResizableSetting.AnimateDuration; }
				set
				{
					this.JQueryElement.ResizableSetting.AnimateDuration = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置动画效果.
			/// </summary>
			public string AnimateEasing
			{
				get { return this.JQueryElement.ResizableSetting.AnimateEasing; }
				set
				{
					this.JQueryElement.ResizableSetting.AnimateEasing = value;

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置宽高比.
			/// </summary>
			public decimal AspectRatio
			{
				get
				{
					decimal aspectRatio;
					this.fetchDecimal ( this.JQueryElement.ResizableSetting.AspectRatio, 1, out aspectRatio );

					return aspectRatio;
				}
				set
				{

					this.JQueryElement.ResizableSetting.AspectRatio = ( value < 0 ) ? string.Empty : value.ToString ( );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动隐藏.
			/// </summary>
			public bool AutoHide
			{
				get
				{
					bool isAutoHide;
					this.fetchBoolean ( this.JQueryElement.ResizableSetting.AutoHide, false, out isAutoHide );

					return isAutoHide;
				}
				set
				{
					this.JQueryElement.ResizableSetting.AutoHide = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动隐藏.
			/// </summary>
			public string AutoHideText
			{
				get { return this.JQueryElement.ResizableSetting.AutoHide; }
				set
				{
					this.JQueryElement.ResizableSetting.AutoHide = value;

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public ContainmentType Containment
			{
				get
				{
					ContainmentType type;
					this.fetchEnum<ContainmentType> ( this.JQueryElement.ResizableSetting.Containment, ContainmentType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ContainmentType.other )
						this.JQueryElement.ResizableSetting.Containment = "null /*javascript 代码*/";
					else
						this.JQueryElement.ResizableSetting.Containment = ( value == ContainmentType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public string ContainmentText
			{
				get { return this.JQueryElement.ResizableSetting.Containment; }
				set
				{
					this.JQueryElement.ResizableSetting.Containment = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复动画.
			/// </summary>
			public bool Ghost
			{
				get
				{
					bool isGhost;
					this.fetchBoolean ( this.JQueryElement.ResizableSetting.Ghost, false, out isGhost );

					return isGhost;
				}
				set
				{
					this.JQueryElement.ResizableSetting.Ghost = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复动画.
			/// </summary>
			public string GhostText
			{
				get { return this.JQueryElement.ResizableSetting.Ghost; }
				set
				{
					this.JQueryElement.ResizableSetting.Ghost = value;

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置缩放的方向.
			/// </summary>
			public string Handles
			{
				get { return this.JQueryElement.ResizableSetting.Handles; }
				set
				{
					this.JQueryElement.ResizableSetting.Handles = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大高度.
			/// </summary>
			public int MaxHeight
			{
				get
				{
					int length;
					this.fetchInteger ( this.JQueryElement.ResizableSetting.MaxHeight, 0, out length );

					return length;
				}
				set
				{
					this.JQueryElement.ResizableSetting.MaxHeight = ( value <= 0 ? string.Empty : value.ToString ( ) );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大高度.
			/// </summary>
			public string MaxHeightText
			{
				get { return this.JQueryElement.ResizableSetting.MaxHeight; }
				set
				{
					this.JQueryElement.ResizableSetting.MaxHeight = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大宽度.
			/// </summary>
			public int MaxWidth
			{
				get
				{
					int length;
					this.fetchInteger ( this.JQueryElement.ResizableSetting.MaxWidth, 0, out length );

					return length;
				}
				set
				{
					this.JQueryElement.ResizableSetting.MaxWidth = ( value <= 0 ? string.Empty : value.ToString ( ) );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大宽度.
			/// </summary>
			public string MaxWidthText
			{
				get { return this.JQueryElement.ResizableSetting.MaxWidth; }
				set
				{
					this.JQueryElement.ResizableSetting.MaxWidth = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小高度.
			/// </summary>
			public int MinHeight
			{
				get
				{
					int length;
					this.fetchInteger ( this.JQueryElement.ResizableSetting.MinHeight, 10, out length );

					return length;
				}
				set
				{
					this.JQueryElement.ResizableSetting.MinHeight = ( value <= 0 || value == 10 ? string.Empty : value.ToString ( ) );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小高度.
			/// </summary>
			public string MinHeightText
			{
				get { return this.JQueryElement.ResizableSetting.MinHeight; }
				set
				{
					this.JQueryElement.ResizableSetting.MinHeight = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小宽度.
			/// </summary>
			public int MinWidth
			{
				get
				{
					int length;
					this.fetchInteger ( this.JQueryElement.ResizableSetting.MinWidth, 10, out length );

					return length;
				}
				set
				{
					this.JQueryElement.ResizableSetting.MinWidth = ( value < 0 || value == 10 ? string.Empty : value.ToString ( ) );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小宽度.
			/// </summary>
			public string MinWidthText
			{
				get { return this.JQueryElement.ResizableSetting.MinWidth; }
				set
				{
					this.JQueryElement.ResizableSetting.MinWidth = value;
					this.refreshResizableSetting ( );
				}
			}

		}
		#endregion

		#region " SelectableDesignerAction "
		/// <summary>
		/// 选中的设计行为.
		/// </summary>
		public class SelectableDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// Tolerance 类型.
			/// </summary>
			public enum ToleranceType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 全部进入后选中.
				/// </summary>
				fit = 1,
				/// <summary>
				/// 接触后即可选中.
				/// </summary>
				touch = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个选中设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public SelectableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "选中设置", "selectable" ) );

				ToleranceType toleranceType;

				if ( this.fetchEnum<ToleranceType> ( this.JQueryElement.SelectableSetting.Tolerance, ToleranceType.@null, out toleranceType ) )
					items.Add ( new DesignerActionPropertyItem ( "Tolerance", "触发方式", "selectable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ToleranceText", "触发方式", "selectable", "指示排列中选中的触发方式, 可以是 'touch' 或者 'fit'" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多选中设置...", "selectable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多选中设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.SelectableSetting, this.JQueryElement.ID + " 选中设置" ).ShowDialog ( );
				this.refreshSelectableSetting ( );
			}

			/// <summary>
			/// 获取或设置触发方式.
			/// </summary>
			public ToleranceType Tolerance
			{
				get
				{
					ToleranceType type;
					this.fetchEnum<ToleranceType> ( this.JQueryElement.SelectableSetting.Tolerance, ToleranceType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ToleranceType.other )
						this.JQueryElement.SelectableSetting.Tolerance = "null /*javascript 代码*/";
					else
						this.JQueryElement.SelectableSetting.Tolerance = ( value == ToleranceType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSelectableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置触发方式.
			/// </summary>
			public string ToleranceText
			{
				get { return this.JQueryElement.SelectableSetting.Tolerance; }
				set
				{
					this.JQueryElement.SelectableSetting.Tolerance = value;
					this.refreshSelectableSetting ( );
				}
			}

		}
		#endregion

		#region " SortableDesignerAction "
		/// <summary>
		/// 排列的设计行为.
		/// </summary>
		public class SortableDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// Axis 类型.
			/// </summary>
			public enum AxisType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// x 轴拖动.
				/// </summary>
				x = 1,
				/// <summary>
				/// y 轴拖动.
				/// </summary>
				y = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Containment 类型.
			/// </summary>
			public enum ContainmentType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 容器为 parent.
				/// </summary>
				parent = 1,
				/// <summary>
				/// 容器为 document.
				/// </summary>
				document = 2,
				/// <summary>
				/// 容器为 window.
				/// </summary>
				window = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Helper 类型.
			/// </summary>
			public enum HelperType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 使用自身.
				/// </summary>
				original = 1,
				/// <summary>
				/// 使用副本.
				/// </summary>
				clone = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Tolerance 类型.
			/// </summary>
			public enum ToleranceType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 一半进入可以排列.
				/// </summary>
				intersect = 1,
				/// <summary>
				/// 鼠标进入即可排列.
				/// </summary>
				pointer = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个排列设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public SortableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "排列设置", "sortable" ) );

				AxisType axisType;

				if ( this.fetchEnum<AxisType> ( this.JQueryElement.SortableSetting.Axis, AxisType.@null, out axisType ) )
					items.Add ( new DesignerActionPropertyItem ( "Axis", "方向", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AxisText", "方向", "sortable", "指示拖动的方向, 可以是 'x', 'y'" ) );

				items.Add ( new DesignerActionPropertyItem ( "ConnectWith", "关联", "sortable", "指示关联的排列, 可以将元素拖放在关联列表中, 是一个选择器" ) );

				ContainmentType containmentType;

				if ( this.fetchEnum<ContainmentType> ( this.JQueryElement.SortableSetting.Containment, ContainmentType.@null, out containmentType ) )
					items.Add ( new DesignerActionPropertyItem ( "Containment", "容器", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ContainmentText", "容器", "sortable", "指示拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" ) );

				HelperType helperType;

				if ( this.fetchEnum<HelperType> ( this.JQueryElement.SortableSetting.Helper, HelperType.@null, out helperType ) )
					items.Add ( new DesignerActionPropertyItem ( "Helper", "helper", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "HelperText", "helper", "sortable", "指示是否使用副本 'original' 针对元素本身, 'clone' 针对元素的副本" ) );

				ToleranceType toleranceType;

				if ( this.fetchEnum<ToleranceType> ( this.JQueryElement.SortableSetting.Tolerance, ToleranceType.@null, out toleranceType ) )
					items.Add ( new DesignerActionPropertyItem ( "Tolerance", "触发方式", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ToleranceText", "触发方式", "sortable", "指示排列中拖放的触发方式, 可以是 'intersect' 或者 'pointer'" ) );

				decimal opacity;

				if ( this.fetchDecimal ( this.JQueryElement.DraggableSetting.Opacity, 1, out opacity ) )
					items.Add ( new DesignerActionPropertyItem ( "Opacity", "透明度", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "OpacityText", "透明度", "sortable" ) );

				bool isDropOnEmpty;

				if ( this.JQueryElement.SortableSetting.DropOnEmpty == string.Empty || this.fetchBoolean ( this.JQueryElement.SortableSetting.DropOnEmpty, true, out isDropOnEmpty ) )
					items.Add ( new DesignerActionPropertyItem ( "DropOnEmpty", "拖放空表", "sortable", "指示是否可以将条目拖放到空的关联列表中" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "DropOnEmptyText", "拖放空表", "sortable", "指示是否可以将条目拖放到空的关联列表中, 可以设置为 true 或者 false" ) );

				bool isRevert;

				if ( this.JQueryElement.SortableSetting.Revert == string.Empty || this.fetchBoolean ( this.JQueryElement.SortableSetting.Revert, false, out isRevert ) )
					items.Add ( new DesignerActionPropertyItem ( "Revert", "播放排列动画", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "RevertText", "播放排列动画", "sortable", "指示是否在排列后播放恢复原位的动画, 比如: true, 或者是以毫秒为单位的动画播放时间, 比如: 500" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多排列设置...", "sortable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多排列设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.SortableSetting, this.JQueryElement.ID + " 排列设置" ).ShowDialog ( );
				this.refreshSortableSetting ( );
			}

			/// <summary>
			/// 获取或设置排列拖动时的方向.
			/// </summary>
			public AxisType Axis
			{
				get
				{
					AxisType type;
					this.fetchEnum<AxisType> ( this.JQueryElement.SortableSetting.Axis, AxisType.@null, out type );

					return type;
				}
				set
				{

					if ( value == AxisType.other )
						this.JQueryElement.SortableSetting.Axis = "null /*javascript 代码*/";
					else
						this.JQueryElement.SortableSetting.Axis = ( value == AxisType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置排列拖动时的方向.
			/// </summary>
			public string AxisText
			{
				get { return this.JQueryElement.SortableSetting.Axis; }
				set
				{
					this.JQueryElement.SortableSetting.Axis = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置另一个关联的列表, 对应一个选择器.
			/// </summary>
			public string ConnectWith
			{
				get { return this.JQueryElement.SortableSetting.ConnectWith; }
				set
				{
					this.JQueryElement.SortableSetting.ConnectWith = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public ContainmentType Containment
			{
				get
				{
					ContainmentType type;
					this.fetchEnum<ContainmentType> ( this.JQueryElement.SortableSetting.Containment, ContainmentType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ContainmentType.other )
						this.JQueryElement.SortableSetting.Containment = "null /*javascript 代码*/";
					else
						this.JQueryElement.SortableSetting.Containment = ( value == ContainmentType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public string ContainmentText
			{
				get { return this.JQueryElement.SortableSetting.Containment; }
				set
				{
					this.JQueryElement.SortableSetting.Containment = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以拖放到空列表中.
			/// </summary>
			public bool DropOnEmpty
			{
				get
				{
					bool isDropOnEmpty;
					this.fetchBoolean ( this.JQueryElement.SortableSetting.DropOnEmpty, true, out isDropOnEmpty );

					return isDropOnEmpty;
				}
				set
				{
					this.JQueryElement.SortableSetting.DropOnEmpty = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以拖放到空列表中.
			/// </summary>
			public string DropOnEmptyText
			{
				get { return this.JQueryElement.SortableSetting.DropOnEmpty; }
				set
				{
					this.JQueryElement.SortableSetting.DropOnEmpty = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否使用副本.
			/// </summary>
			public HelperType Helper
			{
				get
				{
					HelperType type;
					this.fetchEnum<HelperType> ( this.JQueryElement.SortableSetting.Helper, HelperType.@null, out type );

					return type;
				}
				set
				{

					if ( value == HelperType.other )
						this.JQueryElement.SortableSetting.Helper = "null /*javascript 代码*/";
					else
						this.JQueryElement.SortableSetting.Helper = ( value == HelperType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置使用副本.
			/// </summary>
			public string HelperText
			{
				get { return this.JQueryElement.SortableSetting.Helper; }
				set
				{
					this.JQueryElement.SortableSetting.Helper = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置排列拖动时的透明度.
			/// </summary>
			public decimal Opacity
			{
				get
				{
					decimal opacity;
					this.fetchDecimal ( this.JQueryElement.SortableSetting.Opacity, 1, out opacity );

					return opacity;
				}
				set
				{

					this.JQueryElement.SortableSetting.Opacity = ( value < 0 || value >= 1 ) ? string.Empty : value.ToString ( );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置排列拖动时的透明度.
			/// </summary>
			public string OpacityText
			{
				get { return this.JQueryElement.SortableSetting.Opacity; }
				set
				{
					this.JQueryElement.SortableSetting.Opacity = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放排列动画.
			/// </summary>
			public bool Revert
			{
				get
				{
					bool isRevert;
					this.fetchBoolean ( this.JQueryElement.SortableSetting.Revert, false, out isRevert );

					return isRevert;
				}
				set
				{
					this.JQueryElement.SortableSetting.Revert = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放排列动画.
			/// </summary>
			public string RevertText
			{
				get { return this.JQueryElement.SortableSetting.Revert; }
				set
				{
					this.JQueryElement.SortableSetting.Revert = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动触发方式.
			/// </summary>
			public ToleranceType Tolerance
			{
				get
				{
					ToleranceType type;
					this.fetchEnum<ToleranceType> ( this.JQueryElement.SortableSetting.Tolerance, ToleranceType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ToleranceType.other )
						this.JQueryElement.SortableSetting.Tolerance = "null /*javascript 代码*/";
					else
						this.JQueryElement.SortableSetting.Tolerance = ( value == ToleranceType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动触发方式.
			/// </summary>
			public string ToleranceText
			{
				get { return this.JQueryElement.SortableSetting.Tolerance; }
				set
				{
					this.JQueryElement.SortableSetting.Tolerance = value;
					this.refreshSortableSetting ( );
				}
			}

		}
		#endregion

		#region " AccordionDesignerAction "
		/// <summary>
		/// 折叠列表的设计行为.
		/// </summary>
		public class AccordionDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个折叠列表设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public AccordionDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "折叠列表设置", "accordion" ) );

				bool isAutoHeight;

				if ( this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight, true, out isAutoHeight ) )
					items.Add ( new DesignerActionPropertyItem ( "AutoHeight", "相同最大高度", "accordion", "指示是否自动调整与最高的列表同高" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AutoHeightText", "相同最大高度", "accordion", "指示是否自动调整与最高的列表同高, 可以设置为 true 或者 false" ) );

				bool isCollapsible;

				if ( this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible, false, out isCollapsible ) )
					items.Add ( new DesignerActionPropertyItem ( "Collapsible", "可关闭所有", "accordion", "指示是否关闭所有的列表" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "CollapsibleText", "可关闭所有", "accordion", "指示是否关闭所有的列表, 可以设置为 true 或者 false" ) );

				bool isFillSpace;

				if ( this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace, false, out isFillSpace ) )
					items.Add ( new DesignerActionPropertyItem ( "FillSpace", "使用父容器高度", "accordion", "指示是否以父容器填充高度" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "FillSpaceText", "使用父容器高度", "accordion", "指示是否以父容器填充高度, 可以设置为 true 或者 false" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多折叠列表设置...", "accordion" ) );
				return items;
			}

			/// <summary>
			/// 设置更多折叠列表设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AccordionSetting, this.JQueryElement.ID + " 折叠列表设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置是否自动调整与最高的列表同高.
			/// </summary>
			public bool AutoHeight
			{
				get
				{
					bool isAutoHeight;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight, true, out isAutoHeight );

					return isAutoHeight;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动调整与最高的列表同高.
			/// </summary>
			public string AutoHeightText
			{
				get { return this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight; }
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否关闭所有的列表.
			/// </summary>
			public bool Collapsible
			{
				get
				{
					bool isCollapsible;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible, false, out isCollapsible );

					return isCollapsible;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否关闭所有的列表.
			/// </summary>
			public string CollapsibleText
			{
				get { return this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible; }
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否以父容器填充高度.
			/// </summary>
			public bool FillSpace
			{
				get
				{
					bool isFillSpace;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace, false, out isFillSpace );

					return isFillSpace;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否以父容器填充高度.
			/// </summary>
			public string FillSpaceText
			{
				get { return this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace; }
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " AutocompleteDesignerAction "
		/// <summary>
		/// 自动填充的设计行为.
		/// </summary>
		public class AutocompleteDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个自动填充设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public AutocompleteDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "自动填充设置", "autocomplete" ) );

				int minLength;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength, 1, out minLength ) )
					items.Add ( new DesignerActionPropertyItem ( "MinLength", "最小字符数", "autocomplete", "指示激活填充需要最小的输入字符数, 比如: 3, 默认为 1" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MinLengthText", "最小字符数", "autocomplete", "指示激活填充需要最小的输入字符数, 比如: 3, 默认为 1" ) );

				items.Add ( new DesignerActionPropertyItem ( "Source", "源", "autocomplete", "指示用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数" ) );

				bool isAutoFocus;

				if ( this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus, true, out isAutoFocus ) )
					items.Add ( new DesignerActionPropertyItem ( "AutoFocus", "自动获得焦点", "autocomplete", "指示是否自动对焦到第一个条目" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AutoFocusText", "自动获得焦点", "autocomplete", "指示是否自动对焦到第一个条目, 可以设置为 true 或者 false" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多自动填充设置...", "autocomplete" ) );
				return items;
			}

			/// <summary>
			/// 设置更多自动填充设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AutocompleteSetting, this.JQueryElement.ID + " 自动填充设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置是否自动获得焦点.
			/// </summary>
			public bool AutoFocus
			{
				get
				{
					bool isAutoFocus;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus, false, out isAutoFocus );

					return isAutoFocus;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动获得焦点.
			/// </summary>
			public string AutoFocusText
			{
				get { return this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus; }
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置激活填充需要最小的输入字符数.
			/// </summary>
			public int MinLength
			{
				get
				{
					int minLength;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength, 1, out minLength );

					return minLength;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength = ( value < 0 || value == 1 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置激活填充需要最小的输入字符数.
			/// </summary>
			public string MinLengthText
			{
				get { return this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength; }
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置源.
			/// </summary>
			public string Source
			{
				get { return this.JQueryElement.WidgetSetting.AutocompleteSetting.Source; }
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.Source = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " ButtonDesignerAction "
		/// <summary>
		/// 按钮的设计行为.
		/// </summary>
		public class ButtonDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个按钮设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public ButtonDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "按钮设置", "button" ) );

				bool isText;

				if ( this.JQueryElement.WidgetSetting.ButtonSetting.Text == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.ButtonSetting.Text, true, out isText ) )
				{

					if ( this.Text )
						items.Add ( new DesignerActionPropertyItem ( "Label", "文本", "button", "指示按钮显示的文本, 比如: 'ok'" ) );
					else
						items.Add ( new DesignerActionPropertyItem ( "Icons", "图标", "button", "指示按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }" ) );

					items.Add ( new DesignerActionPropertyItem ( "Text", "显示文本", "button" ) );
				}
				else
				{
					items.Add ( new DesignerActionPropertyItem ( "Label", "文本", "button", "指示按钮显示的文本, 比如: 'ok'" ) );
					items.Add ( new DesignerActionPropertyItem ( "Icons", "图标", "button", "指示按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }" ) );

					items.Add ( new DesignerActionPropertyItem ( "TextText", "显示文本", "button", "指示按钮是否显示文本, 可以设置为 true 或者 false" ) );
				}

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多按钮设置...", "button" ) );
				return items;
			}

			/// <summary>
			/// 设置更多按钮设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.ButtonSetting, this.JQueryElement.ID + " 按钮设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置按钮文本.
			/// </summary>
			public string Label
			{
				get
				{ return this.JQueryElement.WidgetSetting.ButtonSetting.Label; }
				set
				{
					this.JQueryElement.WidgetSetting.ButtonSetting.Label = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置按钮图标.
			/// </summary>
			public string Icons
			{
				get
				{ return this.JQueryElement.WidgetSetting.ButtonSetting.Icons; }
				set
				{
					this.JQueryElement.WidgetSetting.ButtonSetting.Icons = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置按钮是否显示图标.
			/// </summary>
			public bool Text
			{
				get
				{
					bool isText;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.ButtonSetting.Text, true, out isText );

					return isText;
				}
				set
				{
					this.JQueryElement.WidgetSetting.ButtonSetting.Text = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置按钮是否显示图标.
			/// </summary>
			public string TextText
			{
				get { return this.JQueryElement.WidgetSetting.ButtonSetting.Text; }
				set
				{
					this.JQueryElement.WidgetSetting.ButtonSetting.Text = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " DatepickerDesignerAction "
		/// <summary>
		/// 日期框的设计行为.
		/// </summary>
		public class DatepickerDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个日期框设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public DatepickerDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "日期框设置", "datepicker" ) );

				items.Add ( new DesignerActionPropertyItem ( "CurrentText", "当天文本", "datepicker", "指示当天链接的文本, 比如: '今天'" ) );
				items.Add ( new DesignerActionPropertyItem ( "DayNames", "天的名称", "datepicker", "指示天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" ) );
				items.Add ( new DesignerActionPropertyItem ( "DayNamesMin", "天的最短名称", "datepicker", "指示天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" ) );
				items.Add ( new DesignerActionPropertyItem ( "DayNamesShort", "天的短名称", "datepicker", "指示天的短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" ) );
				items.Add ( new DesignerActionPropertyItem ( "MonthNames", "月的名称", "datepicker", "指示月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" ) );
				items.Add ( new DesignerActionPropertyItem ( "MonthNamesShort", "月的短名称", "datepicker", "指示月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" ) );

				int numberOfMonths;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths, 1, out numberOfMonths ) )
					items.Add ( new DesignerActionPropertyItem ( "NumberOfMonths", "显示月份数", "datepicker", "指示显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3]" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "NumberOfMonthsText", "显示月份数", "datepicker", "指示显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3]" ) );

				items.Add ( new DesignerActionPropertyItem ( "MaxDate", "最大日期", "datepicker", "指示最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周" ) );
				items.Add ( new DesignerActionPropertyItem ( "MinDate", "最小日期", "datepicker", "指示最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周" ) );

				bool isChangeMonth;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth, false, out isChangeMonth ) )
					items.Add ( new DesignerActionPropertyItem ( "ChangeMonth", "可选择月份", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ChangeMonthText", "可选择月份", "datepicker", "指示是否允许使用下拉框改变月份, 可以设置为 true 或者 false" ) );

				bool isChangeYear;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear, false, out isChangeYear ) )
					items.Add ( new DesignerActionPropertyItem ( "ChangeYear", "可选择年份", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ChangeYearText", "可选择年份", "datepicker", "指示是否允许使用下拉框改变年份, 可以设置为 true 或者 false" ) );

				bool isSelectOtherMonths;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths, false, out isSelectOtherMonths ) )
					items.Add ( new DesignerActionPropertyItem ( "SelectOtherMonths", "可选择其它月份", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "SelectOtherMonthsText", "可选择其它月份", "datepicker", "指示是否可以选择其它的月份, 可以设置为 true 或者 false" ) );

				bool isShowOtherMonths;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths, false, out isShowOtherMonths ) )
					items.Add ( new DesignerActionPropertyItem ( "ShowOtherMonths", "显示其它月份", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ShowOtherMonthsText", "显示其它月份", "datepicker", "指示是否显示其它月份, 可以设置为 true 或者 false" ) );

				bool isShowButtonPanel;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel, false, out isShowButtonPanel ) )
					items.Add ( new DesignerActionPropertyItem ( "ShowButtonPanel", "显示按钮面板", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ShowButtonPanelText", "显示按钮面板", "datepicker", "是否显示按钮面板, 可以设置为 true 或者 false" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多日期框设置...", "datepicker" ) );
				return items;
			}

			/// <summary>
			/// 设置更多日期框设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.DatepickerSetting, this.JQueryElement.ID + " 日期框设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置当天文本.
			/// </summary>
			public string CurrentText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.CurrentText; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.CurrentText = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置天的名称.
			/// </summary>
			public string DayNames
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.DayNames; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.DayNames = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置天的最短名称.
			/// </summary>
			public string DayNamesMin
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.DayNamesMin; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.DayNamesMin = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置天的短名称.
			/// </summary>
			public string DayNamesShort
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.DayNamesShort; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.DayNamesShort = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置月的名称.
			/// </summary>
			public string MonthNames
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.MonthNames; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.MonthNames = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置月的短名称.
			/// </summary>
			public string MonthNamesShort
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.MonthNamesShort; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.MonthNamesShort = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置显示月份数.
			/// </summary>
			public int NumberOfMonths
			{
				get
				{
					int numberOfMonths;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths, 1, out numberOfMonths );

					return numberOfMonths;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths = ( value < 0 || value == 1 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置显示月份数.
			/// </summary>
			public string NumberOfMonthsText
			{
				get { return this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大日期.
			/// </summary>
			public string MaxDate
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.MaxDate; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.MaxDate = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小日期.
			/// </summary>
			public string MinDate
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.MinDate; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.MinDate = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以更改月份.
			/// </summary>
			public bool ChangeMonth
			{
				get
				{
					bool isChangeMonth;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth, false, out isChangeMonth );

					return isChangeMonth;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以更改月份.
			/// </summary>
			public string ChangeMonthText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以更改年份.
			/// </summary>
			public bool ChangeYear
			{
				get
				{
					bool isChangeYear;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear, false, out isChangeYear );

					return isChangeYear;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以更改年份.
			/// </summary>
			public string ChangeYearText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以选择其它月份.
			/// </summary>
			public bool SelectOtherMonths
			{
				get
				{
					bool isSelectOtherMonths;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths, false, out isSelectOtherMonths );

					return isSelectOtherMonths;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以选择其它月份.
			/// </summary>
			public string SelectOtherMonthsText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否显示其它月份.
			/// </summary>
			public bool ShowOtherMonths
			{
				get
				{
					bool isShowOtherMonths;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths, false, out isShowOtherMonths );

					return isShowOtherMonths;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否显示其它月份.
			/// </summary>
			public string ShowOtherMonthsText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否显示按钮面板.
			/// </summary>
			public bool ShowButtonPanel
			{
				get
				{
					bool isShowButtonPanel;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel, false, out isShowButtonPanel );

					return isShowButtonPanel;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否显示按钮面板.
			/// </summary>
			public string ShowButtonPanelText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " DialogDesignerAction "
		/// <summary>
		/// 对话框的设计行为.
		/// </summary>
		public class DialogDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个对话框设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public DialogDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "对话框设置", "dialog" ) );

				items.Add ( new DesignerActionPropertyItem ( "Buttons", "按钮", "dialog", "指示对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }" ) );
				items.Add ( new DesignerActionPropertyItem ( "Title", "标题", "dialog", "指示对话框标题, 比如: 'my title'" ) );
				items.Add ( new DesignerActionPropertyItem ( "Position", "位置", "dialog", "指示对话框的位置, 比如: ['right','top'], [100, 200]" ) );

				int height;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.DialogSetting.Height, 0, out height ) )
					items.Add ( new DesignerActionPropertyItem ( "Height", "高度", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "HeightText", "高度", "dialog" ) );

				int width;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.DialogSetting.Width, 0, out width ) )
					items.Add ( new DesignerActionPropertyItem ( "Width", "宽度", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "WidthText", "宽度", "dialog" ) );

				bool isAutoOpen;

				if ( this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen, true, out isAutoOpen ) )
					items.Add ( new DesignerActionPropertyItem ( "AutoOpen", "自动打开", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AutoOpenText", "自动打开", "dialog", "指示对话框是否自动打开, 可以设置为 true 或者 false" ) );

				bool isCloseOnEscape;

				if ( this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape, true, out isCloseOnEscape ) )
					items.Add ( new DesignerActionPropertyItem ( "CloseOnEscape", "Esc 关闭", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "CloseOnEscapeText", "Esc 关闭", "dialog", "指示是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false" ) );

				bool isDraggable;

				if ( this.JQueryElement.WidgetSetting.DialogSetting.Draggable == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.Draggable, true, out isDraggable ) )
					items.Add ( new DesignerActionPropertyItem ( "Draggable", "可拖动", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "DraggableText", "可拖动", "dialog", "指示是否允许拖动, 可以设置为 true 或者 false" ) );

				bool isResizable;

				if ( this.JQueryElement.WidgetSetting.DialogSetting.Resizable == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.Resizable, true, out isResizable ) )
					items.Add ( new DesignerActionPropertyItem ( "Resizable", "可缩放", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ResizableText", "可缩放", "dialog", "指示是否允许缩放, 可以设置为 true 或者 false" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多对话框设置...", "dialog" ) );
				return items;
			}

			/// <summary>
			/// 设置更多对话框设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.DialogSetting, this.JQueryElement.ID + " 对话框设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置对话框按钮.
			/// </summary>
			public string Buttons
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Buttons; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Buttons = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置对话框标题.
			/// </summary>
			public string Title
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Title; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Title = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置位置.
			/// </summary>
			public string Position
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Position; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Position = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置高度.
			/// </summary>
			public int Height
			{
				get
				{
					int height;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.DialogSetting.Height, 0, out height );

					return height;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Height = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置高度.
			/// </summary>
			public string HeightText
			{
				get { return this.JQueryElement.WidgetSetting.DialogSetting.Height; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Height = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置宽度.
			/// </summary>
			public int Width
			{
				get
				{
					int width;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.DialogSetting.Width, 0, out width );

					return width;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Width = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置宽度.
			/// </summary>
			public string WidthText
			{
				get { return this.JQueryElement.WidgetSetting.DialogSetting.Width; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Width = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动打开.
			/// </summary>
			public bool AutoOpen
			{
				get
				{
					bool isAutoOpen;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen, true, out isAutoOpen );

					return isAutoOpen;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动打开.
			/// </summary>
			public string AutoOpenText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否按下 Esc 关闭.
			/// </summary>
			public bool CloseOnEscape
			{
				get
				{
					bool isCloseOnEscape;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape, true, out isCloseOnEscape );

					return isCloseOnEscape;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否按下 Esc 关闭.
			/// </summary>
			public string CloseOnEscapeText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可拖动.
			/// </summary>
			public bool Draggable
			{
				get
				{
					bool isDraggable;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.Draggable, true, out isDraggable );

					return isDraggable;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Draggable = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可拖动.
			/// </summary>
			public string DraggableText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Draggable; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Draggable = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可缩放.
			/// </summary>
			public bool Resizable
			{
				get
				{
					bool isResizable;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.Resizable, true, out isResizable );

					return isResizable;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Resizable = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可缩放.
			/// </summary>
			public string ResizableText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Resizable; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Resizable = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " ProgressbarDesignerAction "
		/// <summary>
		/// 进度条的设计行为.
		/// </summary>
		public class ProgressbarDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个进度条设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public ProgressbarDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "进度条设置", "progressbar" ) );

				int value;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.ProgressbarSetting.Value, 0, out value ) )
					items.Add ( new DesignerActionPropertyItem ( "Value", "进度", "progressbar" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ValueText", "进度", "progressbar" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多进度条设置...", "progressbar" ) );
				return items;
			}

			/// <summary>
			/// 设置更多进度条设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.ProgressbarSetting, this.JQueryElement.ID + " 进度条设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置进度.
			/// </summary>
			public int Value
			{
				get
				{
					int value;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.ProgressbarSetting.Value, 0, out value );

					return value;
				}
				set
				{
					this.JQueryElement.WidgetSetting.ProgressbarSetting.Value = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置进度.
			/// </summary>
			public string ValueText
			{
				get { return this.JQueryElement.WidgetSetting.ProgressbarSetting.Value; }
				set
				{
					this.JQueryElement.WidgetSetting.ProgressbarSetting.Value = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " SliderDesignerAction "
		/// <summary>
		/// 分割条的设计行为.
		/// </summary>
		public class SliderDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// Orientation 类型.
			/// </summary>
			public enum OrientationType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 水平.
				/// </summary>
				horizontal = 1,
				/// <summary>
				/// 垂直.
				/// </summary>
				vertical = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个分割条设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public SliderDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "分割条设置", "slider" ) );

				int max;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Max, 100, out max ) )
					items.Add ( new DesignerActionPropertyItem ( "Max", "最大值", "slider" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MaxText", "最大值", "slider" ) );

				int min;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Min, 0, out min ) )
					items.Add ( new DesignerActionPropertyItem ( "Min", "最小值", "slider" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MinText", "最小值", "slider" ) );

				int step;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Step, 1, out step ) )
					items.Add ( new DesignerActionPropertyItem ( "Step", "步长", "slider" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "StepText", "步长", "slider" ) );

				OrientationType orientationType;

				if ( this.fetchEnum<OrientationType> ( this.JQueryElement.WidgetSetting.SliderSetting.Orientation, OrientationType.@null, out orientationType ) )
					items.Add ( new DesignerActionPropertyItem ( "Orientation", "方向", "slider" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "OrientationText", "方向", "slider", "指示分割条的方向, 比如: 'horizontal', 'vertical'" ) );

				bool isRange;

				if ( this.JQueryElement.WidgetSetting.SliderSetting.Range == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.SliderSetting.Range, false, out isRange ) )
				{

					if ( this.Range )
						items.Add ( new DesignerActionPropertyItem ( "Values", "范围值", "slider", "指示分割条的范围值, 比如: [1, 4, 10]" ) );
					else
					{
						int value;

						if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Value, 0, out value ) )
							items.Add ( new DesignerActionPropertyItem ( "Value", "值", "slider" ) );
						else
							items.Add ( new DesignerActionPropertyItem ( "ValueText", "值", "slider" ) );

					}

					items.Add ( new DesignerActionPropertyItem ( "Range", "使用范围", "slider" ) );
				}
				else
				{
					int value;

					if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Value, 0, out value ) )
						items.Add ( new DesignerActionPropertyItem ( "Value", "值", "slider" ) );
					else
						items.Add ( new DesignerActionPropertyItem ( "ValueText", "值", "slider" ) );

					items.Add ( new DesignerActionPropertyItem ( "Values", "范围值", "slider", "指示分割条的范围值, 比如: [1, 4, 10]" ) );

					items.Add ( new DesignerActionPropertyItem ( "RangeText", "使用范围", "slider", "指示分割条是否使用范围, 或者为 'min', 'max' 中的一种" ) );
				}

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多分割条设置...", "slider" ) );
				return items;
			}

			/// <summary>
			/// 设置更多分割条设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.SliderSetting, this.JQueryElement.ID + " 分割条设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置范围值.
			/// </summary>
			public string Values
			{
				get
				{ return this.JQueryElement.WidgetSetting.SliderSetting.Values; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Values = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置值.
			/// </summary>
			public int Value
			{
				get
				{
					int value;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Value, 0, out value );

					return value;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Value = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置值.
			/// </summary>
			public string ValueText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Value; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Value = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大值.
			/// </summary>
			public int Max
			{
				get
				{
					int max;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Max, 100, out max );

					return max;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Max = ( value < 0 || value == 100 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大值.
			/// </summary>
			public string MaxText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Max; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Max = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小值.
			/// </summary>
			public int Min
			{
				get
				{
					int min;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Min, 0, out min );

					return min;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Min = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小值.
			/// </summary>
			public string MinText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Min; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Min = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置步长.
			/// </summary>
			public int Step
			{
				get
				{
					int min;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Step, 1, out min );

					return min;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Step = ( value < 0 || value == 1 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置步长.
			/// </summary>
			public string StepText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Step; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Step = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置方向.
			/// </summary>
			public OrientationType Orientation
			{
				get
				{
					OrientationType type;
					this.fetchEnum<OrientationType> ( this.JQueryElement.WidgetSetting.SliderSetting.Orientation, OrientationType.@null, out type );

					return type;
				}
				set
				{

					if ( value == OrientationType.other )
						this.JQueryElement.WidgetSetting.SliderSetting.Orientation = "null /*javascript 代码*/";
					else
						this.JQueryElement.WidgetSetting.SliderSetting.Orientation = ( value == OrientationType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置方向.
			/// </summary>
			public string OrientationText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Orientation; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Orientation = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否使用范围.
			/// </summary>
			public bool Range
			{
				get
				{
					bool isRange;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.SliderSetting.Range, false, out isRange );

					return isRange;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Range = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否使用范围.
			/// </summary>
			public string RangeText
			{
				get
				{ return this.JQueryElement.WidgetSetting.SliderSetting.Range; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Range = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " TabsDesignerAction "
		/// <summary>
		/// 分组标签的设计行为.
		/// </summary>
		public class TabsDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个分组标签设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public TabsDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "分组标签设置", "tabs" ) );

				int selected;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.TabsSetting.Selected, 0, out selected ) )
					items.Add ( new DesignerActionPropertyItem ( "Selected", "选中标签索引", "tabs" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "SelectedText", "选中标签索引", "tabs" ) );

				items.Add ( new DesignerActionPropertyItem ( "Event", "触发事件", "tabs", "指示触发切换的事件名称, 默认: 'click'" ) );
				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多分组标签设置...", "tabs" ) );
				return items;
			}

			/// <summary>
			/// 设置更多分组标签设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.TabsSetting, this.JQueryElement.ID + " 分组标签设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置选中标签索引.
			/// </summary>
			public int Selected
			{
				get
				{
					int value;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.TabsSetting.Selected, 0, out value );

					return value;
				}
				set
				{
					this.JQueryElement.WidgetSetting.TabsSetting.Selected = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置选中标签索引.
			/// </summary>
			public string SelectedText
			{
				get { return this.JQueryElement.WidgetSetting.TabsSetting.Selected; }
				set
				{
					this.JQueryElement.WidgetSetting.TabsSetting.Selected = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置触发事件.
			/// </summary>
			public string Event
			{
				get { return this.JQueryElement.WidgetSetting.TabsSetting.Event; }
				set
				{
					this.JQueryElement.WidgetSetting.TabsSetting.Event = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " AjaxDesignerAction "
		/// <summary>
		/// Ajax 设计行为.
		/// </summary>
		public class AjaxDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个 Ajax 设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public AjaxDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "Ajax 设置", "ajax" ) );

				for ( int index = 0; index < 4 && index < this.JQueryElement.WidgetSetting.AjaxSettings.Count; index++ )
					items.Add ( new DesignerActionMethodItem ( this, string.Format ( "DesignerWindow{0}", index + 1 ), string.Format ( "Ajax[{0}] 设置...", index + 1 ), "ajax" ) );

				items.Add ( new DesignerActionTextItem ( "请在源视图中添加 Ajax 操作", "ajax" ) );
				return items;
			}

			/// <summary>
			/// 设置更多 Ajax 设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings, this.JQueryElement.ID + " Ajax 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// Ajax 1 设置.
			/// </summary>
			public void DesignerWindow1 ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings[0], this.JQueryElement.ID + " Ajax 1 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// Ajax 1 设置.
			/// </summary>
			public void DesignerWindow2 ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings[1], this.JQueryElement.ID + " Ajax 2 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// Ajax 1 设置.
			/// </summary>
			public void DesignerWindow3 ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings[2], this.JQueryElement.ID + " Ajax 3 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// Ajax 4 设置.
			/// </summary>
			public void DesignerWindow4 ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings[3], this.JQueryElement.ID + " Ajax 4 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

		}
		#endregion

		#region " FormDesigner "
		/// <summary>
		/// 设计器窗体.
		/// </summary>
		public sealed class FormDesigner : Form
		{
			private readonly PropertyGrid propertyGrid;

			/// <summary>
			/// 创建一个设计器窗体.
			/// </summary>
			public FormDesigner ( object setting, string text )
			{
				this.propertyGrid = new PropertyGrid ( );

				this.propertyGrid.Dock = DockStyle.Fill;
				this.propertyGrid.Name = "propertyGrid";
				this.propertyGrid.SelectedObject = setting;

				try
				{ this.propertyGrid.Font = new Font ( "Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ( ( byte ) ( 0 ) ) ); }
				catch { }


				this.Controls.Add ( this.propertyGrid );
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "FormDesigner";
				this.ShowIcon = false;
				this.ShowInTaskbar = false;
				this.Text = text;
				this.TopMost = true;

				this.StartPosition = FormStartPosition.CenterScreen;
			}

		}
		#endregion

	}
	#endregion

	#region " BaseWidget "
	/// <summary>
	/// 插件的基础类.
	/// </summary>
	public class BaseWidget
		: BaseJQueryElement
	{

		#region " hide "

		/// <summary>
		/// 获取或设置元素的拖动设置.
		/// </summary>
		[Browsable ( false )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override DraggableSettingEdit DraggableSetting
		{
			get { return base.DraggableSetting; }
			set { base.DraggableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的拖放设置.
		/// </summary>
		[Browsable ( false )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override DroppableSettingEdit DroppableSetting
		{
			get { return base.DroppableSetting; }
			set { base.DroppableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的排列设置.
		/// </summary>
		[Browsable ( false )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override SortableSettingEdit SortableSetting
		{
			get { return base.SortableSetting; }
			set { base.SortableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的选中设置.
		/// </summary>
		[Browsable ( false )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override SelectableSettingEdit SelectableSetting
		{
			get { return base.SelectableSetting; }
			set { base.SelectableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的缩放设置.
		/// </summary>
		[Browsable ( false )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public override ResizableSettingEdit ResizableSetting
		{
			get { return base.ResizableSetting; }
			set { base.ResizableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的 Widget 设置.
		/// </summary>
		[Browsable ( false )]
		public override WidgetSettingEdit WidgetSetting
		{
			get { return base.WidgetSetting; }
			set { base.WidgetSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的 Repeater 设置.
		/// </summary>
		[Browsable ( false )]
		public override RepeaterSettingEdit RepeaterSetting
		{
			get { return base.RepeaterSetting; }
			set { base.RepeaterSetting = value; }
		}
		#endregion

		/// <summary>
		/// 创建一个插件的基础类.
		/// </summary>
		/// <param name="type">插件的类型.</param>
		protected BaseWidget ( WidgetType type )
			: base ( )
		{ this.widgetSetting.Type = type; }

		protected T getEnum<T> ( string text, T defalutValue )
			where T : struct
		{
			T value;

			if ( string.IsNullOrEmpty ( text ) )
				value = defalutValue;
			// HACK: 可能需要添加 V5
#if V4
			else if ( !Enum.TryParse ( text.Trim ( '\'' ).Trim ( '"' ), out value ) )
				value = defalutValue;
#else
			else
				try
				{ value = ( T ) Enum.Parse ( typeof ( T ), text.Trim ( '\'' ).Trim ( '"' ), true ); }
				catch
				{ value = defalutValue; }
#endif

			return value;
		}

		protected decimal getDecimal ( string text, decimal defaultValue )
		{
			decimal value;

			if ( string.IsNullOrEmpty ( text ) || !decimal.TryParse ( text, out value ) )
				value = defaultValue;

			return value;
		}

		protected bool getBoolean ( string text, bool defaultValue )
		{
			bool value;

			if ( string.IsNullOrEmpty ( text ) || !bool.TryParse ( text, out value ) )
				value = defaultValue;

			return value;
		}

		protected int getInteger ( string text, int defaultValue )
		{
			int value;

			if ( string.IsNullOrEmpty ( text ) || !int.TryParse ( text, out value ) )
				value = defaultValue;

			return value;
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/DraggableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDraggableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDraggableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DraggableSettingEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " DraggableSettingEdit "
	/// <summary>
	/// jQuery UI 拖动的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DraggableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DraggableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isDraggable = false;

		/// <summary>
		/// 获取元素的拖动设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的拖动设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以拖动.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以拖动" )]
		[NotifyParentProperty ( true )]
		public bool IsDraggable
		{
			get { return this.isDraggable; }
			set { this.isDraggable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置拖动是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置是否添加样式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否添加样式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AddClasses
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.addClasses ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.addClasses, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标点击在何处拖动有效, 可以是 'parent', 'body' 等.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标点击在何处拖动有效, 可以是 'parent', 'body' 等" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendTo ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendTo, value ); }
		}

		/// <summary>
		/// 获取或设置拖动的方向, 可以是 'x', 'y'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动的方向, 可以是 'x', 'y'" )]
		[NotifyParentProperty ( true )]
		public string Axis
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.axis ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.axis, value ); }
		}

		/// <summary>
		/// 获取或设置不参加拖动的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加拖动的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置关联的排列, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示关联的排列, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string ConnectToSortable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.connectToSortable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.connectToSortable, value ); }
		}

		/// <summary>
		/// 获取或设置拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" )]
		[NotifyParentProperty ( true )]
		public string Containment
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.containment ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.containment, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标样式, 比如: 'auto'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标样式, 比如: 'auto'" )]
		[NotifyParentProperty ( true )]
		public string Cursor
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursor ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursor, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性" )]
		[NotifyParentProperty ( true )]
		public string CursorAt
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursorAt ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursorAt, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的延迟, 以毫秒计算" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发拖动, 比如: 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发排列, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来移动元素, 为一个数组, 比如: [10, 30].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来移动元素, 为一个数组, 比如: [10, 30]" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.grid ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.grid, value ); }
		}

		/// <summary>
		/// 获取或设置用于点击的元素, 点击后拖动才有效, 对应一个 dom 元素或者选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于点击的元素, 点击后拖动才有效, 对应一个 dom 元素或者选择器" )]
		[NotifyParentProperty ( true )]
		public string Handle
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.handle ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.handle, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用副本 'original' 针对元素本身, 'clone' 针对元素的副本.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用副本 'original' 针对元素本身, 'clone' 针对元素的副本" )]
		[NotifyParentProperty ( true )]
		public string Helper
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.helper ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.helper, value ); }
		}

		/// <summary>
		/// 获取或设置是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器..
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器" )]
		[NotifyParentProperty ( true )]
		public string IFrameFix
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.iframeFix ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.iframeFix, value ); }
		}

		/// <summary>
		/// 获取或设置元素拖动时的透明度, 0 到 1 之间.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素拖动时的透明度, 0 到 1 之间" )]
		[NotifyParentProperty ( true )]
		public string Opacity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.opacity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.opacity, value ); }
		}

		/// <summary>
		/// 获取或设置是否刷新位置, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否刷新位置, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string RefreshPositions
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.refreshPositions ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.refreshPositions, value ); }
		}

		/// <summary>
		/// 获取或设置是否在拖动后播放恢复原位的动画, 比如: true, 或者是 'valid', 'invalid'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在拖动后播放恢复原位的动画, 比如: true, 或者是 'valid', 'invalid'" )]
		[NotifyParentProperty ( true )]
		public string Revert
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.revert ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.revert, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画播放时间, 比如: 500.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的动画播放时间, 比如: 500" )]
		[NotifyParentProperty ( true )]
		public string RevertDuration
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.revertDuration ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.revertDuration, value ); }
		}

		/// <summary>
		/// 获取或设置范围, 比如: 'default'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示范围, 比如: 'default'" )]
		[NotifyParentProperty ( true )]
		public string Scope
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scope ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scope, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以显示滚动轴.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以显示滚动轴, 比如: true" )]
		[NotifyParentProperty ( true )]
		public string Scroll
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scroll ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scroll, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的灵敏度, 比如: 40.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的灵敏度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSensitivity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSensitivity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSensitivity, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的速度, 比如: 40.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的速度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSpeed
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSpeed ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSpeed, value ); }
		}

		/// <summary>
		/// 获取或设置是否附着, 比如: true, 或者附着的目标元素的选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否附着, 比如: true, 或者附着的目标元素的选择器" )]
		[NotifyParentProperty ( true )]
		public string Snap
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.snap ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.snap, value ); }
		}

		/// <summary>
		/// 获取或设置附着模式, 可以是 'inner', 'outer', 'both'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示附着模式, 可以是 'inner', 'outer', 'both'" )]
		[NotifyParentProperty ( true )]
		public string SnapMode
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.snapMode ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.snapMode, value ); }
		}

		/// <summary>
		/// 获取或设置附着发生的距离, 比如: 100.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示附着发生的距离, 比如: 100" )]
		[NotifyParentProperty ( true )]
		public string SnapTolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.snapTolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.snapTolerance, value ); }
		}

		/// <summary>
		/// 获取或设置控制 z 轴顺序, 对应一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示控制 z 轴顺序, 对应一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Stack
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stack ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stack, value ); }
		}

		/// <summary>
		/// 获取或设置 Z 轴顺序, 比如: 5.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示 Z 轴顺序, 比如: 5" )]
		[NotifyParentProperty ( true )]
		public string ZIndex
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.zIndex ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.zIndex, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置拖动被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置拖动开始的时候的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置拖动完成时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drag
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.drag ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.drag, value ); }
		}

		/// <summary>
		/// 获取或设置拖动停止的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 拖动的相关设置.
		/// </summary>
		/// <returns>jQuery UI 拖动的相关设置.</returns>
		public DraggableSetting CreateDraggableSetting ( )
		{ return new DraggableSetting ( this.isDraggable, this.editHelper.CreateOptions ( ) ); }

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.isDraggable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isDraggable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DraggableSettingEditConverter "
	/// <summary>
	/// jQuery UI 拖动设置编辑器的转换器.
	/// </summary>
	public sealed class DraggableSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			DraggableSettingEdit edit = new DraggableSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsDraggable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DraggableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DraggableSettingEdit setting = value as DraggableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsDraggable, setting.EditHelper );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/DroppableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDroppableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDroppableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DroppableSettingEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " DroppableSettingEdit "
	/// <summary>
	/// jQuery UI 拖放的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DroppableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DroppableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isDroppable = false;

		/// <summary>
		/// 获取元素的拖放设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的拖放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以拖放.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以拖放" )]
		[NotifyParentProperty ( true )]
		public bool IsDroppable
		{
			get { return this.isDroppable; }
			set { this.isDroppable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置拖放是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置拖放接受的目标, 对应一个函数或者选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放接受的目标, 对应一个函数或者选择器" )]
		[NotifyParentProperty ( true )]
		public string Accept
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.accept ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.accept, value ); }
		}

		/// <summary>
		/// 获取或设置拖放被激活时的样式, 对应一个函数或者选择器.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放被激活时的样式, 对应一个函数或者选择器" )]
		[NotifyParentProperty ( true )]
		public string ActiveClass 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.activeClass ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.activeClass, value ); }
		}

		/// <summary>
		/// 获取或设置是否添加样式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否添加样式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AddClasses
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.addClasses ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.addClasses, value ); }
		}

		/// <summary>
		/// 获取或设置是否阻止事件传播, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否阻止事件传播, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Greedy
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.greedy ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.greedy, value ); }
		}

		/// <summary>
		/// 获取或设置悬停样式, 比如: 'drophover'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示悬停样式, 比如: 'drophover'" )]
		[NotifyParentProperty ( true )]
		public string HoverClass
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.hoverClass ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.hoverClass, value ); }
		}

		/// <summary>
		/// 获取或设置范围, 比如: 'default'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示范围, 比如: 'default'" )]
		[NotifyParentProperty ( true )]
		public string Scope
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scope ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scope, value ); }
		}

		/// <summary>
		/// 获取或设置拖放的触发方式, 可以是 'fit', 'intersect', 'pointer', 'touch'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放的触发方式, 可以是 'fit', 'intersect', 'pointer', 'touch'" )]
		[NotifyParentProperty ( true )]
		public string Tolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tolerance, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置拖放被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置拖放被激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放被激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Activate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.activate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.activate, value ); }
		}

		/// <summary>
		/// 获取或设置拖放取消激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放取消激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Deactivate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.deactivate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.deactivate, value ); }
		}

		/// <summary>
		/// 获取或设置元素滑过时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑过时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Over
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.over ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.over, value ); }
		}

		/// <summary>
		/// 获取或设置元素滑出时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑出时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Out
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@out ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@out, value ); }
		}

		/// <summary>
		/// 获取或设置拖放时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.drop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.drop, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 拖放的相关设置.
		/// </summary>
		/// <returns>jQuery UI 拖放的相关设置.</returns>
		public DroppableSetting CreateDroppableSetting ( )
		{ return new DroppableSetting ( this.isDroppable, this.editHelper.CreateOptions ( ) ); }

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.isDroppable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isDroppable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DroppableSettingEditConverter "
	/// <summary>
	/// jQuery UI 拖放设置编辑器的转换器.
	/// </summary>
	public sealed class DroppableSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			DroppableSettingEdit edit = new DroppableSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsDroppable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DroppableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DroppableSettingEdit setting = value as DroppableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsDroppable, setting.EditHelper );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/ResizableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ResizableSettingEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " ResizableSettingEdit "
	/// <summary>
	/// jQuery UI 缩放的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( ResizableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ResizableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isResizable = false;

		/// <summary>
		/// 获取元素的缩放设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的缩放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以缩放.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以缩放" )]
		[NotifyParentProperty ( true )]
		public bool IsResizable
		{
			get { return this.isResizable; }
			set { this.isResizable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置缩放是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置同时缩放的内容, 对应一个 dom 元素, 选择器或者 jQuery.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示同时缩放的内容, 对应一个 dom 元素, 选择器或者 jQuery" )]
		[NotifyParentProperty ( true )]
		public string AlsoResize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.alsoResize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.alsoResize, value ); }
		}

		/// <summary>
		/// 获取或设置是否播放缩放的动画, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否播放缩放的动画, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Animate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animate, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画时长, 比如: 1000.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的动画时长, 比如: 1000" )]
		[NotifyParentProperty ( true )]
		public string AnimateDuration
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animateDuration ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animateDuration, value ); }
		}

		/// <summary>
		/// 获取或设置动画效果, 比如: 'swing'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示动画效果, 比如: 'swing'" )]
		[NotifyParentProperty ( true )]
		public string AnimateEasing
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animateEasing ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animateEasing, value ); }
		}

		/// <summary>
		/// 获取或设置宽高比例, 比如: 9 / 16, 或者 true, false.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示宽高比例, 比如: 9 / 16, 或者 true, false" )]
		[NotifyParentProperty ( true )]
		public string AspectRatio
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.aspectRatio ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.aspectRatio, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动隐藏, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动隐藏, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoHide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoHide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoHide, value ); }
		}

		/// <summary>
		/// 获取或设置不参加缩放的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加缩放的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置缩放所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string Containment
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.containment ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.containment, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的延迟, 以毫秒计算" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发缩放, 比如: 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发缩放, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置是否在缩放时使用阴影, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在缩放时使用阴影, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Ghost
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.ghost ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.ghost, value ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来缩放, 为一个数组, 比如: [10, 30].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来缩放, 为一个数组, 比如: [10, 30]" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.grid ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.grid, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的方向, 为一个字符串, 比如: 'n, e, s, w', 可以从 'n, e, s, w, ne, se, sw, nw, all' 中取值.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的方向, 为一个字符串, 比如: 'n, e, s, w', 可以从 'n, e, s, w, ne, se, sw, nw, all' 中取值" )]
		[NotifyParentProperty ( true )]
		public string Handles
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.handles ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.handles, value ); }
		}

		/// <summary>
		/// 获取或设置 helper 的样式, 比如: 'ui-state-highlight'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示 helper 的样式, 比如: 'ui-state-highlight'" )]
		[NotifyParentProperty ( true )]
		public string Helper
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.helper ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.helper, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最大高度, 比如: 200.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最大高度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MaxHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxHeight, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最大宽度, 比如: 200.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最大宽度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MaxWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxWidth, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最小高度, 比如: 200.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最小高度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MinHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minHeight, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最小宽度, 比如: 200.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最小宽度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MinWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minWidth, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置缩放被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置缩放开始的时候的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置缩放时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Resize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resize, value ); }
		}

		/// <summary>
		/// 获取或设置缩放停止的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 缩放的相关设置.
		/// </summary>
		/// <returns>jQuery UI 缩放的相关设置.</returns>
		public ResizableSetting CreateResizableSetting ( )
		{ return new ResizableSetting ( this.isResizable, this.editHelper.CreateOptions ( ) ); }

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.isResizable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isResizable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ResizableSettingEditConverter "
	/// <summary>
	/// jQuery UI 缩放设置编辑器的转换器.
	/// </summary>
	public sealed class ResizableSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			ResizableSettingEdit edit = new ResizableSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsResizable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ResizableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ResizableSettingEdit setting = value as ResizableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsResizable, setting.EditHelper );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/SelectableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISelectableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISelectableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SelectableSettingEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " SelectableSettingEdit "
	/// <summary>
	/// jQuery UI 选中的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( SelectableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class SelectableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isSelectable = false;

		/// <summary>
		/// 获取元素的选中设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的选中设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以选中.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以选中" )]
		[NotifyParentProperty ( true )]
		public bool IsSelectable
		{
			get { return this.isSelectable; }
			set { this.isSelectable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置选中是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置选中是否自动刷新, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中是否自动刷新, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoRefresh
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoRefresh ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoRefresh, value ); }
		}

		/// <summary>
		/// 获取或设置不参加选中的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加选中的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的延迟, 以毫秒计算" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发选中, 比如: 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发选中, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置参加选中的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示参加选中的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Filter
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.filter ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.filter, value ); }
		}

		/// <summary>
		/// 获取或设置排列中选中的触发方式, 可以是 'touch' 或者 'fit'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列中选中的触发方式, 可以是 'touch' 或者 'fit'" )]
		[NotifyParentProperty ( true )]
		public string Tolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tolerance, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置选中被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置选中后的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中后的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Selected 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selected ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selected, value ); }
		}

		/// <summary>
		/// 获取或设置选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Selecting 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selecting ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selecting, value ); }
		}

		/// <summary>
		/// 获取或设置选中开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置选中停止时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}

		/// <summary>
		/// 获取或设置取消选中的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示取消选中的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Unselected 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.unselected ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.unselected, value ); }
		}

		/// <summary>
		/// 获取或设置取消选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示取消选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Unselecting 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.unselecting ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.unselecting, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 选中的相关设置.
		/// </summary>
		/// <returns>jQuery UI 选中的相关设置.</returns>
		public SelectableSetting CreateSelectableSetting ( )
		{ return new SelectableSetting ( this.isSelectable, this.editHelper.CreateOptions ( ) ); }

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.isSelectable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isSelectable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " SelectableSettingEditConverter "
	/// <summary>
	/// jQuery UI 选中设置编辑器的转换器.
	/// </summary>
	public sealed class SelectableSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			SelectableSettingEdit edit = new SelectableSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsSelectable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SelectableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SelectableSettingEdit setting = value as SelectableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsSelectable, setting.EditHelper );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/SortableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISortableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISortableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SortableSettingEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " SortableSettingEdit "
	/// <summary>
	/// jQuery UI 排列的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( SortableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class SortableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isSortable = false;

		/// <summary>
		/// 获取元素的排列设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的排列设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以排列.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以排列" )]
		[NotifyParentProperty ( true )]
		public bool IsSortable
		{
			get { return this.isSortable; }
			set { this.isSortable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置排列是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标点击在何处排序有效, 可以是 'parent', 'body' 等.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标点击在何处排序有效, 可以是 'parent', 'body' 等" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendTo ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendTo, value ); }
		}

		/// <summary>
		/// 获取或设置排列时拖动的方向, 可以是 'x', 'y'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列时拖动的方向, 可以是 'x', 'y'" )]
		[NotifyParentProperty ( true )]
		public string Axis
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.axis ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.axis, value ); }
		}

		/// <summary>
		/// 获取或设置不参加排列的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加排列的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置关联的排列, 可以将元素拖放在关联列表中, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示关联的排列, 可以将元素拖放在关联列表中, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string ConnectWith
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.connectWith ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.connectWith, value ); }
		}

		/// <summary>
		/// 获取或设置排列所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" )]
		[NotifyParentProperty ( true )]
		public string Containment
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.containment ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.containment, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标样式, 比如: 'auto'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标样式, 比如: 'auto'" )]
		[NotifyParentProperty ( true )]
		public string Cursor
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursor ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursor, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性" )]
		[NotifyParentProperty ( true )]
		public string CursorAt
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursorAt ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursorAt, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的延迟, 以毫秒计算" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发排列, 比如: 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发排列, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以将条目拖放到空的关联列表中, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以将条目拖放到空的关联列表中, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string DropOnEmpty
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dropOnEmpty ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dropOnEmpty, value ); }
		}

		/// <summary>
		/// 获取或设置是否强制 helper 拥有尺寸, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否强制 helper 拥有尺寸, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ForceHelperSize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.forceHelperSize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.forceHelperSize, value ); }
		}

		/// <summary>
		/// 获取或设置是否强制 placeholder 拥有尺寸, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否强制 placeholder 拥有尺寸, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ForcePlaceholderSize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.forcePlaceholderSize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.forcePlaceholderSize, value ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来移动元素, 为一个数组, 比如: [10, 30].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来移动元素, 为一个数组, 比如: [10, 30]" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.grid ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.grid, value ); }
		}

		/// <summary>
		/// 获取或设置用于点击的元素, 点击后排列才有效, 对应一个 dom 元素或者选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于点击的元素, 点击后排列才有效, 对应一个 dom 元素或者选择器" )]
		[NotifyParentProperty ( true )]
		public string Handle
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.handle ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.handle, value ); }
		}

		/// <summary>
		/// 获取或设置 helper 的行为, 可以是 'original', 'clone'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 helper 的行为, 可以是 'original', 'clone'" )]
		[NotifyParentProperty ( true )]
		public string Helper
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.helper ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.helper, value ); }
		}

		/// <summary>
		/// 获取或设置参与排列的元素, 对应选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示参与排列的元素, 对应选择器" )]
		[NotifyParentProperty ( true )]
		public string Items
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.items ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.items, value ); }
		}

		/// <summary>
		/// 获取或设置元素排列时的透明度, 0 到 1 之间.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素排列时的透明度, 0 到 1 之间" )]
		[NotifyParentProperty ( true )]
		public string Opacity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.opacity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.opacity, value ); }
		}

		/// <summary>
		/// 获取或设置 placeholder 的样式, 比如: 'ui-state-highlight'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示 placeholder 的样式, 比如: 'ui-state-highlight'" )]
		[NotifyParentProperty ( true )]
		public string Placeholder
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.placeholder ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.placeholder, value ); }
		}

		/// <summary>
		/// 获取或设置是否在排列后播放恢复原位的动画, 比如: true, 或者是以毫秒为单位的动画播放时间, 比如: 500.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在排列后播放恢复原位的动画, 比如: true, 或者是以毫秒为单位的动画播放时间, 比如: 500" )]
		[NotifyParentProperty ( true )]
		public string Revert
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.revert ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.revert, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以显示滚动轴.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以显示滚动轴, 比如: true" )]
		[NotifyParentProperty ( true )]
		public string Scroll
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scroll ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scroll, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的灵敏度, 比如: 40.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的灵敏度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSensitivity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSensitivity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSensitivity, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的速度, 比如: 40.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的速度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSpeed
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSpeed ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSpeed, value ); }
		}

		/// <summary>
		/// 获取或设置排列中拖放的触发方式, 可以是 'intersect' 或者 'pointer'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列中拖放的触发方式, 可以是 'intersect' 或者 'pointer'" )]
		[NotifyParentProperty ( true )]
		public string Tolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tolerance, value ); }
		}

		/// <summary>
		/// 获取或设置 Z 轴顺序, 比如: 5.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示 Z 轴顺序, 比如: 5" )]
		[NotifyParentProperty ( true )]
		public string ZIndex
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.zIndex ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.zIndex, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置排列被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置排列开始的时候的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置排列时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Sort
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.sort ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.sort, value ); }
		}

		/// <summary>
		/// 获取或设置排列改变的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列改变的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置排列停止之前的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列停止之前的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeStop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeStop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeStop, value ); }
		}

		/// <summary>
		/// 获取或设置排列停止的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}

		/// <summary>
		/// 获取或设置 dom 元素改变的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 dom 元素改变的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Update
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.update ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.update, value ); }
		}

		/// <summary>
		/// 获取或设置接收到元素的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示接收到元素的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Receive
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.receive ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.receive, value ); }
		}

		/// <summary>
		/// 获取或设置元素被移除的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素被移除的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.remove ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.remove, value ); }
		}

		/// <summary>
		/// 获取或设置元素滑过时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑过时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Over
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.over ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.over, value ); }
		}

		/// <summary>
		/// 获取或设置元素滑出时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑出时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Out
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@out ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@out, value ); }
		}

		/// <summary>
		/// 获取或设置排列被激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列被激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Activate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.activate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.activate, value ); }
		}

		/// <summary>
		/// 获取或设置排列取消激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列取消激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Deactivate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.deactivate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.deactivate, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 排列的相关设置.
		/// </summary>
		/// <returns>jQuery UI 排列的相关设置.</returns>
		public SortableSetting CreateSortableSetting ( )
		{ return new SortableSetting ( this.isSortable, this.editHelper.CreateOptions ( ) ); }

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.isSortable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isSortable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " SortableSettingEditConverter "
	/// <summary>
	/// jQuery UI 排列设置编辑器的转换器.
	/// </summary>
	public sealed class SortableSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			SortableSettingEdit edit = new SortableSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsSortable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SortableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SortableSettingEdit setting = value as SortableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsSortable, setting.EditHelper );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/OptionEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOptionEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOptionEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOptionEditCollectionEditor
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " OptionEdit "
	/// <summary>
	/// jQuery UI 的选项编辑器.
	/// </summary>
	// [DefaultProperty ( "Value" )]
	// [ToolboxData ( "<{0}:OptionEdit />" )]
	// [ControlBuilder ( typeof ( ListItemControlBuilder ) )]
	[DefaultProperty ( "Value" )]
	[TypeConverter ( typeof ( OptionEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class OptionEdit
		: IStateManager
	{
		private OptionType type = OptionType.none;
		private string value = string.Empty;

		/// <summary>
		/// 获取或设置选项的类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( OptionType.none )]
		[Description ( "选项的类型" )]
		[NotifyParentProperty ( true )]
		public OptionType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置选项的数据.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "选项的数据" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.value; }
			set
			{

				if ( null != value )
					this.value = value;

			}
		}

		/// <summary>
		/// 创建一个 jQuery UI 选项.
		/// </summary>
		/// <returns>jQuery UI 选项.</returns>
		public Option CreateOption ( )
		{ return new Option ( this.type, this.value ); }

		/// <summary>
		/// 转换为等效字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.type = ( OptionType ) states[0];

			if ( states.Count >= 2 )
				this.Value = states[1] as string;

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.type );
			states.Add ( this.value );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " OptionEditConverter "
	/// <summary>
	/// jQuery UI 选项编辑器的转换器.
	/// </summary>
	public sealed class OptionEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			OptionEdit edit = new OptionEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 2 )
				try
				{

					if ( expressionHelper[0].Value != string.Empty )
						edit.Type = ( OptionType ) Enum.Parse ( typeof ( OptionType ), expressionHelper[0].Value, true );

					if ( expressionHelper[1].Value != string.Empty )
						edit.Value = expressionHelper[1].Value;

				}
				catch
				{ }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is OptionEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType );

			OptionEdit edit = value as OptionEdit;

			return string.Format ( "{0}`;{1}`;", edit.Type, edit.Value );
		}

	}
	#endregion

	#region " OptionEditCollectionEditor "
	/// <summary>
	/// jQuery UI 选项的集合编辑器.
	/// </summary>
	public class OptionEditCollectionEditor : CollectionEditor
	{

		public OptionEditCollectionEditor ( Type type )
			: base ( type )
		{ }

		protected override bool CanSelectMultipleInstances ( )
		{ return false; }

		protected override Type CreateCollectionItemType ( )
		{ return typeof ( OptionEdit ); }

	}
	#endregion

}
// ../.class/ui/jqueryui/EventEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEventEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEventEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEventEditCollectionEditor
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " EventEdit "
	/// <summary>
	/// jQuery UI 的事件编辑器.
	/// </summary>
	// [DefaultProperty ( "Value" )]
	// [ToolboxData ( "<{0}:EventEdit />" )]
	// [ControlBuilder ( typeof ( ListItemControlBuilder ) )]
	[DefaultProperty ( "Value" )]
	[TypeConverter ( typeof ( EventEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class EventEdit
		: IStateManager
	{
		private EventType type = EventType.none;
		private string value = string.Empty;

		/// <summary>
		/// 获取或设置事件的类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( EventType.none )]
		[Description ( "事件的类型" )]
		[NotifyParentProperty ( true )]
		public EventType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置事件的内容.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "事件的内容" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.value; }
			set
			{

				if ( null != value )
					this.value = value;

			}
		}

		/// <summary>
		/// 创建一个 jQuery UI 事件.
		/// </summary>
		/// <returns>jQuery UI 事件.</returns>
		public Event CreateEvent ( )
		{ return new Event ( this.type, this.value ); }

		/// <summary>
		/// 转换为等效字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.type = ( EventType ) states[0];

			if ( states.Count >= 2 )
				this.Value = states[1] as string;

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.type );
			states.Add ( this.value );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " EventEditConverter "
	/// <summary>
	/// jQuery UI 选项编辑器的转换器.
	/// </summary>
	public sealed class EventEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			EventEdit edit = new EventEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 2 )
				try
				{

					if ( expressionHelper[0].Value != string.Empty )
						edit.Type = ( EventType ) Enum.Parse ( typeof ( EventType ), expressionHelper[0].Value, true );

					if ( expressionHelper[1].Value != string.Empty )
						edit.Value = expressionHelper[1].Value;

				}
				catch
				{ }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is EventEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType );

			EventEdit edit = value as EventEdit;

			return string.Format ( "{0}`;{1}`;", edit.Type.ToString ( ), edit.Value );
		}

	}
	#endregion

	#region " EventEditCollectionEditor "
	/// <summary>
	/// jQuery UI 选项的集合编辑器.
	/// </summary>
	public class EventEditCollectionEditor : CollectionEditor
	{

		public EventEditCollectionEditor ( Type type )
			: base ( type )
		{ }

		protected override bool CanSelectMultipleInstances ( )
		{ return false; }

		protected override Type CreateCollectionItemType ( )
		{ return typeof ( EventEdit ); }

	}
	#endregion

}
// ../.class/ui/jqueryui/ParameterEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameterEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameterEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameterEditCollectionEditor
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ParameterEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " ParameterEdit "
	/// <summary>
	/// jQuery UI 的参数编辑器.
	/// </summary>
	// [DefaultProperty ( "Value" )]
	// [ToolboxData ( "<{0}:ParameterEdit />" )]
	// [ControlBuilder ( typeof ( ListItemControlBuilder ) )]
	[DefaultProperty ( "Value" )]
	[TypeConverter ( typeof ( ParameterEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ParameterEdit
		: IStateManager
	{
		private ParameterType type = ParameterType.Selector;
		private string value = string.Empty;
		private string name = string.Empty;

		/// <summary>
		/// 获取或设置参数的名称.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "参数的名称" )]
		[NotifyParentProperty ( true )]
		public string Name
		{
			get { return this.name; }
			set
			{

				if ( null != value )
					this.name = value;

			}
		}

		/// <summary>
		/// 获取或设置参数的类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( ParameterType.Selector )]
		[Description ( "参数的类型" )]
		[NotifyParentProperty ( true )]
		public ParameterType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置参数的数据.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "参数的数据" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.value; }
			set
			{

				if ( null != value )
					this.value = value;

			}
		}

		/// <summary>
		/// 创建一个 jQuery UI 参数.
		/// </summary>
		/// <returns>jQuery UI 参数</returns>
		public NParameter CreateParameter ( )
		{ return new NParameter ( this.name, this.type, this.value ); }

		/// <summary>
		/// 转换为等效字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.Name = states[0] as string;

			if ( states.Count >= 2 )
				this.type = ( ParameterType ) states[1];

			if ( states.Count >= 3 )
				this.Value = states[2] as string;

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.name );
			states.Add ( this.type );
			states.Add ( this.value );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ParameterEditConverter "
	/// <summary>
	/// jQuery UI 参数编辑器的转换器.
	/// </summary>
	public sealed class ParameterEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			ParameterEdit edit = new ParameterEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 3 )
				try
				{

					if ( expressionHelper[0].Value != string.Empty )
						edit.Name = expressionHelper[0].Value;

					if ( expressionHelper[1].Value != string.Empty )
						edit.Type = ( ParameterType ) Enum.Parse ( typeof ( ParameterType ), expressionHelper[1].Value, true );

					if ( expressionHelper[2].Value != string.Empty )
						edit.Value = expressionHelper[2].Value;

				}
				catch
				{ }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ParameterEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType );

			ParameterEdit edit = value as ParameterEdit;

			return string.Format ( "{0}`;{1}`;{2}`;", edit.Name, edit.Type, edit.Value );
		}

	}
	#endregion

	#region " ParameterEditCollectionEditor "
	/// <summary>
	/// jQuery UI 参数的集合编辑器.
	/// </summary>
	public class ParameterEditCollectionEditor : CollectionEditor
	{

		public ParameterEditCollectionEditor ( Type type )
			: base ( type )
		{ }

		protected override bool CanSelectMultipleInstances ( )
		{ return false; }

		protected override Type CreateCollectionItemType ( )
		{ return typeof ( ParameterEdit ); }

	}
	#endregion

}
// ../.class/ui/jqueryui/AjaxSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSettingEditCollectionEditor
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxSettingEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " AjaxSettingEdit "
	/// <summary>
	/// jQuery UI Ajax 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( AjaxSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class AjaxSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private EventType widgetEventType = EventType.none;
		private string url = string.Empty;
		private DataType dataType = DataType.json;
		private string form = string.Empty;
		private readonly List<ParameterEdit> parameters = new List<ParameterEdit> ( );
		private bool isSingleQuote = true;

		/// <summary>
		/// 获取元素的 Ajax 事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的 Ajax 事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Event "
		/// <summary>
		/// 获取或设置 ajax 完成时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 完成时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Complete
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.complete ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.complete, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 错误时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 错误时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Error
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.error ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.error, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 成功时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 成功时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Success
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.success ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.success, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 发送时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 发送时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Send
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.send ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.send, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 开始时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 开始时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.start ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.start, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 停止时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 停止时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.stop ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.stop, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 获取或设置和 Widget 相关的触发事件.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( EventType.none )]
		[Description ( "指示和 Widget 相关的触发事件" )]
		[NotifyParentProperty ( true )]
		public EventType WidgetEventType
		{
			get { return this.widgetEventType; }
			set { this.widgetEventType = value; }
		}

		/// <summary>
		/// 获取或设置请求的地址.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示请求的地址" )]
		[NotifyParentProperty ( true )]
		[UrlProperty ( )]
		public string Url
		{
			get { return this.url; }
			set { this.url = value; }
		}

		/// <summary>
		/// 获取或设置获取的数据类型.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( DataType.json )]
		[Description ( "指示获取的数据类型" )]
		[NotifyParentProperty ( true )]
		public DataType DataType
		{
			get { return this.dataType; }
			set { this.dataType = value; }
		}

		/// <summary>
		/// 获取或设置用作传递参数的表单.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用作传递参数的表单, 可以是一个选择器或元素" )]
		[NotifyParentProperty ( true )]
		public string Form
		{
			get { return this.form; }
			set { this.form = value; }
		}

		/// <summary>
		/// 获取用作传递的参数.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "用作传递的参数" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( ParameterEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<ParameterEdit> Parameters
		{
			get { return this.parameters; }
		}

		/// <summary>
		/// 获取或设置是否为字符串使用单引号.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否为字符串使用单引号" )]
		[NotifyParentProperty ( true )]
		public bool IsSingleQuote
		{
			get { return this.isSingleQuote; }
			set { this.isSingleQuote = value; }
		}

		/// <summary>
		/// 创建一个 jQuery UI Ajax 的相关设置.
		/// </summary>
		/// <returns>jQuery UI Ajax 的相关设置.</returns>
		public AjaxSetting CreateAjaxSetting ( )
		{
			List<NParameter> parameters = new List<NParameter> ( );

			foreach ( ParameterEdit edit in this.parameters )
				parameters.Add ( edit.CreateParameter ( ) );

			return new AjaxSetting ( this.widgetEventType, this.url, this.dataType, this.form, parameters.ToArray ( ), this.editHelper.CreateEvents ( ), this.isSingleQuote );
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.widgetEventType = ( EventType ) states[0];

			if ( states.Count >= 2 )
				this.Url = states[1] as string;

			if ( states.Count >= 3 )
				this.dataType = ( DataType ) states[2];

			if ( states.Count >= 4 )
				this.Form = states[3] as string;

			if ( states.Count >= 5 )
				this.isSingleQuote = ( bool ) states[4];

			if ( states.Count >= 6 )
				( this.editHelper as IStateManager ).LoadViewState ( states[5] );

			if ( states.Count >= 7 )
			{
				List<object> parameterStates = states[6] as List<object>;

				for ( int index = 0; index < parameterStates.Count; index++ )
					( this.parameters[index] as IStateManager ).LoadViewState ( parameterStates[index] );

			}

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.widgetEventType );
			states.Add ( this.url );
			states.Add ( this.dataType );
			states.Add ( this.form );
			states.Add ( this.isSingleQuote );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			List<object> parameterStates = new List<object> ( );

			foreach ( ParameterEdit edit in this.parameters )
				parameterStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( parameterStates );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " AjaxSettingEditConverter "
	/// <summary>
	/// jQuery UI Ajax 设置编辑器的转换器.
	/// </summary>
	public sealed class AjaxSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			AjaxSettingEdit edit = new AjaxSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 6 )
				try
				{

					if ( expressionHelper[0].Value != string.Empty )
						edit.WidgetEventType = ( EventType ) Enum.Parse ( typeof ( EventType ), expressionHelper[0].Value );

					if ( expressionHelper[1].Value != string.Empty )
						edit.Url = expressionHelper[1].Value;

					if ( expressionHelper[2].Value != string.Empty )
						edit.DataType = ( DataType ) Enum.Parse ( typeof ( DataType ), expressionHelper[2].Value );

					if ( expressionHelper[3].Value != string.Empty )
						edit.Form = expressionHelper[3].Value;

					if ( expressionHelper[4].Value != string.Empty )
						edit.IsSingleQuote = StringConvert.ToObject<bool> ( expressionHelper[4].Value );

					if ( expressionHelper[5].Value != string.Empty )
						edit.EditHelper.FromString ( expressionHelper[5].Value );

				}
				catch { }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AjaxSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AjaxSettingEdit setting = value as AjaxSettingEdit;

			return string.Format ( "{0}`;{1}`;{2}`;{3}`;{4}`;{5}", setting.WidgetEventType, setting.Url, setting.DataType, setting.Form, setting.IsSingleQuote, setting.EditHelper );
		}

	}
	#endregion

	#region " AjaxSettingEditCollectionEditor "
	/// <summary>
	/// jQuery UI 选项的集合编辑器.
	/// </summary>
	public class AjaxSettingEditCollectionEditor : CollectionEditor
	{

		public AjaxSettingEditCollectionEditor ( Type type )
			: base ( type )
		{ }

		protected override bool CanSelectMultipleInstances ( )
		{ return false; }

		protected override Type CreateCollectionItemType ( )
		{ return typeof ( AjaxSettingEdit ); }

	}
	#endregion

}
// ../.class/ui/jqueryui/WidgetSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIWidgetSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIWidgetSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAccordionSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAccordionSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAutocompleteSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAutocompleteSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIButtonSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIButtonSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDialogSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDialogSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIProgressbarSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIProgressbarSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISliderSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISliderSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITabsSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITabsSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEmptySettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEmptySettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/WidgetSettingEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " WidgetSettingEdit "
	/// <summary>
	/// jQuery UI Widget 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( WidgetSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class WidgetSettingEdit
		: IStateManager
	{
		private readonly List<AjaxSettingEdit> ajaxSettings = new List<AjaxSettingEdit> ( );
		private WidgetType type = WidgetType.empty;

		private readonly AccordionSettingEdit accordionSetting = new AccordionSettingEdit ( );
		private readonly AutocompleteSettingEdit autocompleteSetting = new AutocompleteSettingEdit ( );
		private readonly ButtonSettingEdit buttonSetting = new ButtonSettingEdit ( );
		private readonly DatepickerSettingEdit datepickerSetting = new DatepickerSettingEdit ( );
		private readonly DialogSettingEdit dialogSetting = new DialogSettingEdit ( );
		private readonly ProgressbarSettingEdit progressbarSetting = new ProgressbarSettingEdit ( );
		private readonly SliderSettingEdit sliderSetting = new SliderSettingEdit ( );
		private readonly TabsSettingEdit tabsSetting = new TabsSettingEdit ( );
		private readonly EmptySettingEdit emptySetting = new EmptySettingEdit ( );

		/// <summary>
		/// 获取元素的 Widget 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( AjaxSettingEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<AjaxSettingEdit> AjaxSettings
		{
			get { return this.ajaxSettings; }
		}

		/// <summary>
		/// 获取或设置 Widget 类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( WidgetType.empty )]
		[Description ( "指示 Widget 类型" )]
		[NotifyParentProperty ( true )]
		public WidgetType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取元素的折叠列表设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的折叠列表设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AccordionSettingEdit AccordionSetting
		{
			get { return this.accordionSetting; }
		}

		/// <summary>
		/// 获取元素的自动填充设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的自动填充设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AutocompleteSettingEdit AutocompleteSetting
		{
			get { return this.autocompleteSetting; }
		}

		/// <summary>
		/// 获取元素的 Button 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的 Button 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public ButtonSettingEdit ButtonSetting
		{
			get { return this.buttonSetting; }
		}

		/// <summary>
		/// 获取元素的日期框设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的日期框设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public DatepickerSettingEdit DatepickerSetting
		{
			get { return this.datepickerSetting; }
		}

		/// <summary>
		/// 获取元素的对话框设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的对话框设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public DialogSettingEdit DialogSetting
		{
			get { return this.dialogSetting; }
		}

		/// <summary>
		/// 获取元素的进度条设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的进度条设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public ProgressbarSettingEdit ProgressbarSetting
		{
			get { return this.progressbarSetting; }
		}

		/// <summary>
		/// 获取元素的分割条设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的分割条设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public SliderSettingEdit SliderSetting
		{
			get { return this.sliderSetting; }
		}

		/// <summary>
		/// 获取元素的分组标签设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的分组标签设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public TabsSettingEdit TabsSetting
		{
			get { return this.tabsSetting; }
		}

		/// <summary>
		/// 获取元素的空设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的空设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public EmptySettingEdit EmptySetting
		{
			get { return this.emptySetting; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 排列的相关设置.
		/// </summary>
		/// <returns>jQuery UI 排列的相关设置.</returns>
		public WidgetSetting CreateWidgetSetting ( )
		{
			List<AjaxSetting> ajaxSettings = new List<AjaxSetting> ( );

			foreach ( AjaxSettingEdit edit in this.ajaxSettings )
				ajaxSettings.Add ( edit.CreateAjaxSetting ( ) );

			SettingEditHelper editHelper;

			switch ( this.type )
			{
				case WidgetType.accordion:
					editHelper = this.accordionSetting.EditHelper;
					break;

				case WidgetType.autocomplete:
					editHelper = this.autocompleteSetting.EditHelper;
					break;

				case WidgetType.button:
					editHelper = this.buttonSetting.EditHelper;
					break;

				case WidgetType.datepicker:
					editHelper = this.datepickerSetting.EditHelper;
					break;

				case WidgetType.dialog:
					editHelper = this.dialogSetting.EditHelper;
					break;

				case WidgetType.progressbar:
					editHelper = this.progressbarSetting.EditHelper;
					break;

				case WidgetType.slider:
					editHelper = this.sliderSetting.EditHelper;
					break;

				case WidgetType.tabs:
					editHelper = this.tabsSetting.EditHelper;
					break;

				case WidgetType.empty:
				default:
					editHelper = this.emptySetting.EditHelper;
					break;
			}

			return new WidgetSetting ( this.type, editHelper.CreateOptions ( ), editHelper.CreateEvents ( ), ajaxSettings.ToArray ( ) );
		}

		/// <summary>
		/// 转化为等效的字符串. (用于在程序集内容使用)
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.type = ( WidgetType ) states[0];

			if ( states.Count >= 2 )
			{
				/*
				List<object> ajaxSettingStates = states[1] as List<object>;

				for ( int index = 0; index < ajaxSettingStates.Count; index++ )
					( this.ajaxSettings[index] as IStateManager ).LoadViewState ( ajaxSettingStates[index] );
				*/
			}

			if ( states.Count >= 3 )
				( this.buttonSetting as IStateManager ).LoadViewState ( states[2] );

			if ( states.Count >= 4 )
				( this.accordionSetting as IStateManager ).LoadViewState ( states[3] );

			if ( states.Count >= 5 )
				( this.autocompleteSetting as IStateManager ).LoadViewState ( states[4] );

			if ( states.Count >= 6 )
				( this.datepickerSetting as IStateManager ).LoadViewState ( states[5] );

			if ( states.Count >= 7 )
				( this.dialogSetting as IStateManager ).LoadViewState ( states[6] );

			if ( states.Count >= 8 )
				( this.progressbarSetting as IStateManager ).LoadViewState ( states[7] );

			if ( states.Count >= 9 )
				( this.sliderSetting as IStateManager ).LoadViewState ( states[8] );

			if ( states.Count >= 10 )
				( this.tabsSetting as IStateManager ).LoadViewState ( states[9] );

			if ( states.Count >= 11 )
				( this.emptySetting as IStateManager ).LoadViewState ( states[10] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.type );

			List<object> ajaxSettingStates = new List<object> ( );

			foreach ( AjaxSettingEdit edit in this.ajaxSettings )
				ajaxSettingStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( /*ajaxSettingStates*/ null );

			states.Add ( ( this.buttonSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.accordionSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.autocompleteSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.datepickerSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.dialogSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.progressbarSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.sliderSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.tabsSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.emptySetting as IStateManager ).SaveViewState ( ) );
			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " WidgetSettingEditConverter "
	/// <summary>
	/// jQuery UI Widget 设置编辑器的转换器.
	/// </summary>
	public sealed class WidgetSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			WidgetSettingEdit edit = new WidgetSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				try
				{ edit.Type = ( WidgetType ) Enum.Parse ( typeof ( WidgetType ), expressionHelper[0].Value, true ); }
				catch
				{ }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is WidgetSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			WidgetSettingEdit setting = value as WidgetSettingEdit;

			return string.Format ( "{0}`;", setting.Type );
		}

	}
	#endregion

	#region " ButtonSettingEdit "
	/// <summary>
	/// jQuery UI Button 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( ButtonSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ButtonSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的 Button 设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "Button 相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的 Button 事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "Button 相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置按钮是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置按钮是否显示文本, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮是否显示文本, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Text
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.text ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.text, value ); }
		}

		/// <summary>
		/// 获取或设置按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }" )]
		[NotifyParentProperty ( true )]
		public string Icons
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.icons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.icons, value ); }
		}

		/// <summary>
		/// 获取或设置按钮显示的文本, 比如: 'ok'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的文本, 比如: 'ok'" )]
		[NotifyParentProperty ( true )]
		public string Label
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.label ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.label, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置按钮被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ButtonSettingEditConverter "
	/// <summary>
	/// jQuery UI Button 设置编辑器的转换器.
	/// </summary>
	public sealed class ButtonSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			ButtonSettingEdit edit = new ButtonSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ButtonSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ButtonSettingEdit setting = value as ButtonSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " AccordionSettingEdit "
	/// <summary>
	/// jQuery UI 折叠列表的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( AccordionSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class AccordionSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的折叠列表设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "Button 相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的折叠列表事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "Button 相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置折叠列表是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示折叠列表是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置被激活的列表, 对应一个选择器, 元素, 数值或者布尔值.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示被激活的列表, 对应一个选择器, 元素, 数值或者布尔值" )]
		[NotifyParentProperty ( true )]
		public string Active
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.active ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.active, value ); }
		}

		/// <summary>
		/// 获取或设置列表切换的动画, 比如: 'bounceslide', 'slide', 也可以设置为 false, 来禁止动画.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表切换的动画, 比如: 'bounceslide', 'slide', 也可以设置为 false, 来禁止动画" )]
		[NotifyParentProperty ( true )]
		public string Animated
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animated ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animated, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动调整与最高的列表同高, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动调整与最高的列表同高, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoHeight, value ); }
		}

		/// <summary>
		/// 获取或设置是否在动画结束后清除 height, overflow 样式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在动画结束后清除 height, overflow 样式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ClearStyle
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.clearStyle ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.clearStyle, value ); }
		}

		/// <summary>
		/// 获取或设置是否关闭所有的列表, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否关闭所有的列表, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Collapsible
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.collapsible ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.collapsible, value ); }
		}

		/// <summary>
		/// 获取或设置触发列表的事件, 比如: 'mouseover'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示触发列表的事件, 比如: 'mouseover'" )]
		[NotifyParentProperty ( true )]
		public string Event
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@event ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@event, value ); }
		}

		/// <summary>
		/// 获取或设置是否以父容器填充高度, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否以父容器填充高度, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string FillSpace
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.fillSpace ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.fillSpace, value ); }
		}

		/// <summary>
		/// 获取或设置作为标题的元素, 可以是选择器或者 jQuery 对象, 默认为 '> li > :first-child, > :not(li):even'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示作为标题的元素, 可以是选择器或者 jQuery 对象, 默认为 '> li > :first-child, > :not(li):even'" )]
		[NotifyParentProperty ( true )]
		public string Header
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.header ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.header, value ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.icons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.icons, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以导航, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以导航, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Navigation
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.navigation ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.navigation, value ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.navigationFilter ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.navigationFilter, value ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.changestart ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.changestart, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " AccordionSettingEditConverter "
	/// <summary>
	/// jQuery UI 折叠列表设置编辑器的转换器.
	/// </summary>
	public sealed class AccordionSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			AccordionSettingEdit edit = new AccordionSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AccordionSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AccordionSettingEdit setting = value as AccordionSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " AutocompleteSettingEdit "
	/// <summary>
	/// jQuery UI 自动填充的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( AutocompleteSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class AutocompleteSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的自动填充设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "自动填充相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的自动填充事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "自动填充相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置自动填充是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示自动填充是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置填充对应的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充对应的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendTo ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendTo, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动对焦到第一个条目, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动对焦到第一个条目, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoFocus
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoFocus ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoFocus, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的激活自动填充的延迟, 比如: 300.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的激活自动填充的延迟, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置激活填充需要最小的输入字符数, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示激活填充需要最小的输入字符数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public string MinLength
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minLength ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minLength, value ); }
		}

		/// <summary>
		/// 获取或设置填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.position ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.position, value ); }
		}

		/// <summary>
		/// 获取或设置用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数" )]
		[NotifyParentProperty ( true )]
		public string Source
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.source ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.source, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置填充被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置搜索匹配项时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示搜索匹配项时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Search
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.search ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.search, value ); }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.open ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.open, value ); }
		}

		/// <summary>
		/// 获取或设置获得焦点时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Focus
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.focus ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.focus, value ); }
		}

		/// <summary>
		/// 获取或设置选择某个条目的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择某个条目的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.select ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.select, value ); }
		}

		/// <summary>
		/// 获取或设置列表关闭时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.close ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.close, value ); }
		}

		/// <summary>
		/// 获取或设置选择的条目改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择的条目改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " AutocompleteSettingEditConverter "
	/// <summary>
	/// jQuery UI 自动填充设置编辑器的转换器.
	/// </summary>
	public sealed class AutocompleteSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			AutocompleteSettingEdit edit = new AutocompleteSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AutocompleteSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AutocompleteSettingEdit setting = value as AutocompleteSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " DatepickerSettingEdit "
	/// <summary>
	/// jQuery UI 日期框的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DatepickerSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DatepickerSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的日期框设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "日期框相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的日期框事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "日期框相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置日期框是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置备用字段, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示备用字段, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AltField
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.altField ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.altField, value ); }
		}

		/// <summary>
		/// 获取或设置在备用字段显示的日期格式, 比如: 'yy-mm-dd'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示在备用字段显示的日期格式, 比如: 'yy-mm-dd'" )]
		[NotifyParentProperty ( true )]
		public string AltFormat
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.altFormat ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.altFormat, value ); }
		}

		/// <summary>
		/// 获取或设置显示在日期字段后的文本, 比如: '...'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示在日期字段后的文本, 比如: '...'" )]
		[NotifyParentProperty ( true )]
		public string AppendText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendText, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动调整输入框的大小, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动调整输入框的大小, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoSize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoSize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoSize, value ); }
		}

		/// <summary>
		/// 获取或设置按钮的图片, 比如: '/images/datepicker.gif'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的图片, 比如: '/images/datepicker.gif'" )]
		[NotifyParentProperty ( true )]
		public string ButtonImage
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttonImage ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttonImage, value ); }
		}

		/// <summary>
		/// 获取或设置是否按钮只显示图片, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否按钮只显示图片, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ButtonImageOnly
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttonImageOnly ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttonImageOnly, value ); }
		}

		/// <summary>
		/// 获取或设置按钮的文本, 默认 '...'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的文本, 默认 '...'" )]
		[NotifyParentProperty ( true )]
		public string ButtonText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttonText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttonText, value ); }
		}

		/// <summary>
		/// 获取或设置区域设置, 默认 $.datepicker.iso8601Week.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示区域设置, 默认 $.datepicker.iso8601Week" )]
		[NotifyParentProperty ( true )]
		public string CalculateWeek
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.calculateWeek ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.calculateWeek, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许使用下拉框改变月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ChangeMonth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.changeMonth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.changeMonth, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变年份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许使用下拉框改变年份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ChangeYear
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.changeYear ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.changeYear, value ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 比如: 'X'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭链接的文本, 比如: 'X'" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeText, value ); }
		}

		/// <summary>
		/// 获取或设置是否限制输入的格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否限制输入的格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ConstrainInput
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.constrainInput ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.constrainInput, value ); }
		}

		/// <summary>
		/// 获取或设置当天链接的文本, 比如: '今天'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示当天链接的文本, 比如: '今天'" )]
		[NotifyParentProperty ( true )]
		public string CurrentText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.currentText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.currentText, value ); }
		}

		/// <summary>
		/// 获取或设置日期的格式, 比如: 'mm/dd/yy'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期的格式, 比如: 'mm/dd/yy'" )]
		[NotifyParentProperty ( true )]
		public string DateFormat
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dateFormat ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dateFormat, value ); }
		}

		/// <summary>
		/// 获取或设置天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" )]
		[NotifyParentProperty ( true )]
		public string DayNames
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dayNames ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dayNames, value ); }
		}

		/// <summary>
		/// 获取或设置天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesMin
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dayNamesMin ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dayNamesMin, value ); }
		}

		/// <summary>
		/// 获取或设置天的短名称, 比如: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesShort
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dayNamesShort ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dayNamesShort, value ); }
		}

		/// <summary>
		/// 获取或设置默认日期, 可以是日期, 数字或者字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示默认日期, 可以是日期, 数字或者字符串" )]
		[NotifyParentProperty ( true )]
		public string DefaultDate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.defaultDate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.defaultDate, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的日期显示速度, 或者使用 'slow', 'normal', 'fast' 中的一种.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的日期显示速度, 或者使用 'slow', 'normal', 'fast' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string Duration
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.duration ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.duration, value ); }
		}

		/// <summary>
		/// 获取或设置哪一天作为一周的开始, 0 表示周日以此类推.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示哪一天作为一周的开始, 0 表示周日以此类推" )]
		[NotifyParentProperty ( true )]
		public string FirstDay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.firstDay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.firstDay, value ); }
		}

		/// <summary>
		/// 获取或设置是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string GotoCurrent
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.gotoCurrent ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.gotoCurrent, value ); }
		}

		/// <summary>
		/// 获取或设置是否隐藏上一和下一链接, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否隐藏上一和下一链接, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string HideIfNoPrevNext
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.hideIfNoPrevNext ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.hideIfNoPrevNext, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用从右向左, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用从右向左, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string IsRTL
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.isRTL ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.isRTL, value ); }
		}

		/// <summary>
		/// 获取或设置最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周" )]
		[NotifyParentProperty ( true )]
		public string MaxDate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxDate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxDate, value ); }
		}

		/// <summary>
		/// 获取或设置最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小日期, 可以是日期, 数字或者字符串, 比如: '-1m -1w', 表示推前一月零一周" )]
		[NotifyParentProperty ( true )]
		public string MinDate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minDate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minDate, value ); }
		}

		/// <summary>
		/// 获取或设置月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" )]
		[NotifyParentProperty ( true )]
		public string MonthNames
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.monthNames ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.monthNames, value ); }
		}

		/// <summary>
		/// 获取或设置月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" )]
		[NotifyParentProperty ( true )]
		public string MonthNamesShort
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.monthNamesShort ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.monthNamesShort, value ); }
		}

		/// <summary>
		/// 获取或设置链接是否使用日期格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示链接是否使用日期格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string NavigationAsDateFormat
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.navigationAsDateFormat ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.navigationAsDateFormat, value ); }
		}

		/// <summary>
		/// 获取或设置下一链接的文本, 比如: '...'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示下一链接的文本, 比如: '...'" )]
		[NotifyParentProperty ( true )]
		public string NextText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.nextText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.nextText, value ); }
		}

		/// <summary>
		/// 获取或设置显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3]" )]
		[NotifyParentProperty ( true )]
		public string NumberOfMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.numberOfMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.numberOfMonths, value ); }
		}

		/// <summary>
		/// 获取或设置上一链接的文本, 比如: '...'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示上一链接的文本, 比如: '...'" )]
		[NotifyParentProperty ( true )]
		public string PrevText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.prevText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.prevText, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以选择其它的月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以选择其它的月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string SelectOtherMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selectOtherMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selectOtherMonths, value ); }
		}

		/// <summary>
		/// 获取或设置短年份的设置, 可以是数字或者字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示短年份的设置, 可以是数字或者字符串" )]
		[NotifyParentProperty ( true )]
		public string ShortYearCutoff
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.shortYearCutoff ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.shortYearCutoff, value ); }
		}

		/// <summary>
		/// 获取或设置显示日期时的动画, 比如: 'show'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示日期时的动画, 比如: 'show'" )]
		[NotifyParentProperty ( true )]
		public string ShowAnim
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showAnim ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showAnim, value ); }
		}

		/// <summary>
		/// 获取或设置是否显示按钮面板, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否显示按钮面板, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowButtonPanel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showButtonPanel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showButtonPanel, value ); }
		}

		/// <summary>
		/// 获取或设置当前月份的显示位置.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示当前月份的显示位置" )]
		[NotifyParentProperty ( true )]
		public string ShowCurrentAtPos
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showCurrentAtPos ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showCurrentAtPos, value ); }
		}

		/// <summary>
		/// 获取或设置是否在年后显示月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在年后显示月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowMonthAfterYear
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showMonthAfterYear ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showMonthAfterYear, value ); }
		}

		/// <summary>
		/// 获取或设置日期框显示方式, 可以是 'focus', 'button' , 'both' 中的一种.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示方式, 可以是 'focus', 'button' , 'both' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string ShowOn
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showOn ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showOn, value ); }
		}

		/// <summary>
		/// 获取或设置显示选项, 比如: {direction: 'up' }.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示选项, 比如: {direction: 'up' }" )]
		[NotifyParentProperty ( true )]
		public string ShowOptions
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showOptions ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showOptions, value ); }
		}

		/// <summary>
		/// 获取或设置是否显示其它月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否显示其它月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowOtherMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showOtherMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showOtherMonths, value ); }
		}

		/// <summary>
		/// 获取或设置是否显示当前为一年中的第几周, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否显示当前为一年中的第几周, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowWeek
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showWeek ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showWeek, value ); }
		}

		/// <summary>
		/// 获取或设置每一次跳转的月份数, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示每一次跳转的月份数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public string StepMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stepMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stepMonths, value ); }
		}

		/// <summary>
		/// 获取或设置周的标题设置, 默认: 'Wk'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示周的标题设置, 默认: 'Wk'" )]
		[NotifyParentProperty ( true )]
		public string WeekHeader
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.weekHeader ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.weekHeader, value ); }
		}

		/// <summary>
		/// 获取或设置可选择的年份范围, 默认: 'c-10:c+10'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示可选择的年份范围, 默认: 'c-10:c+10'" )]
		[NotifyParentProperty ( true )]
		public string YearRange
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.yearRange ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.yearRange, value ); }
		}

		/// <summary>
		/// 获取或设置跟随在年后的文本, 比如: 'Y'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示跟随在年后的文本, 比如: 'Y'" )]
		[NotifyParentProperty ( true )]
		public string YearSuffix
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.yearSuffix ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.yearSuffix, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置日期框被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置日期框显示时的事件, 类似于: function(input, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示时的事件, 类似于: function(input, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShow
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeShow ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeShow, value ); }
		}

		/// <summary>
		/// 获取或设置日期框显示天时的事件, 类似于: function(date) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示天时的事件, 类似于: function(date) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShowDay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeShowDay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeShowDay, value ); }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(year, month, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示年和月改变时的事件, 类似于: function(year, month, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnChangeMonthYear
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.onChangeMonthYear ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.onChangeMonthYear, value ); }
		}

		/// <summary>
		/// 获取或设置日期款关闭时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期款关闭时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnClose
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.onClose ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.onClose, value ); }
		}

		/// <summary>
		/// 获取或设置日期选择时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期选择时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnSelect
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.onSelect ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.onSelect, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DatepickerSettingEditConverter "
	/// <summary>
	/// jQuery UI 日期框设置编辑器的转换器.
	/// </summary>
	public sealed class DatepickerSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			DatepickerSettingEdit edit = new DatepickerSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DatepickerSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DatepickerSettingEdit setting = value as DatepickerSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " DialogSettingEdit "
	/// <summary>
	/// jQuery UI 对话框的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DialogSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DialogSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的对话框设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "对话框相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的对话框事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "对话框相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置对话框是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置对话框是否自动打开, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框是否自动打开, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoOpen
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoOpen ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoOpen, value ); }
		}

		/// <summary>
		/// 获取或设置对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }" )]
		[NotifyParentProperty ( true )]
		public string Buttons
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttons, value ); }
		}

		/// <summary>
		/// 获取或设置是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string CloseOnEscape
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeOnEscape ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeOnEscape, value ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 默认 'close'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭链接的文本, 默认 'close'" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeText, value ); }
		}

		/// <summary>
		/// 获取或设置对话框的样式, 比如: 'alert'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框的样式, 比如: 'alert'" )]
		[NotifyParentProperty ( true )]
		public string DialogClass
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dialogClass ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dialogClass, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许拖动, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许拖动, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Draggable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.draggable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.draggable, value ); }
		}

		/// <summary>
		/// 获取或设置对话框高度, 比如: 300.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框高度, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public string Height
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.height ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.height, value ); }
		}

		/// <summary>
		/// 获取或设置关闭对话框时的动画, 比如: 'slide'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭对话框时的动画, 比如: 'slide'" )]
		[NotifyParentProperty ( true )]
		public string Hide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.hide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.hide, value ); }
		}

		/// <summary>
		/// 获取或设置最大高度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大高度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MaxHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxHeight, value ); }
		}

		/// <summary>
		/// 获取或设置最大宽度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大宽度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MaxWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxWidth, value ); }
		}

		/// <summary>
		/// 获取或设置最小高度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小高度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MinHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minHeight, value ); }
		}

		/// <summary>
		/// 获取或设置最小宽度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小宽度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MinWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minWidth, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用 modal 模式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用 modal 模式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Modal
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.modal ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.modal, value ); }
		}

		/// <summary>
		/// 获取或设置对话框的位置, 比如: ['right','top'], [100, 200].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框的位置, 比如: ['right','top'], [100, 200]" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.position ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.position, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许缩放, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许缩放, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Resizable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resizable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizable, value ); }
		}

		/// <summary>
		/// 获取或设置显示时的动画, 比如: 'slide'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示时的动画, 比如: 'slide'" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.show ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.show, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动置顶, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动置顶, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Stack
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stack ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stack, value ); }
		}

		/// <summary>
		/// 获取或设置对话框标题, 比如: 'my title'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框标题, 比如: 'my title'" )]
		[NotifyParentProperty ( true )]
		public string Title
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.title ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.title, value ); }
		}

		/// <summary>
		/// 获取或设置对话框宽度, 比如: 300.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框宽度, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public string Width
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.width ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.width, value ); }
		}

		/// <summary>
		/// 获取或设置对话框 Z 轴顺序, 比如: 2.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框 Z 轴顺序, 比如: 2" )]
		[NotifyParentProperty ( true )]
		public string ZIndex
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.zIndex ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.zIndex, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置对话框被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置对话框关闭之前的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭之前的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeClose
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeClose ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeClose, value ); }
		}

		/// <summary>
		/// 获取或设置对话框打开时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.open ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.open, value ); }
		}

		/// <summary>
		/// 获取或设置对话框获得焦点时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Focus
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.focus ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.focus, value ); }
		}

		/// <summary>
		/// 获取或设置对话框拖动开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStart
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dragStart ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dragStart, value ); }
		}

		/// <summary>
		/// 获取或设置对话框拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drag
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.drag ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.drag, value ); }
		}

		/// <summary>
		/// 获取或设置对话框拖动结束时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dragStop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dragStop, value ); }
		}

		/// <summary>
		/// 获取或设置对话框缩放开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStart
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resizeStart ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizeStart, value ); }
		}

		/// <summary>
		/// 获取或设置对话框缩放时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Resize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resize, value ); }
		}

		/// <summary>
		/// 获取或设置对话框缩放结束时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resizeStop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizeStop, value ); }
		}

		/// <summary>
		/// 获取或设置对话框关闭时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.close ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.close, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DialogSettingEditConverter "
	/// <summary>
	/// jQuery UI 对话框设置编辑器的转换器.
	/// </summary>
	public sealed class DialogSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			DialogSettingEdit edit = new DialogSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DialogSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DialogSettingEdit setting = value as DialogSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " ProgressbarSettingEdit "
	/// <summary>
	/// jQuery UI 进度条的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( ProgressbarSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ProgressbarSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的进度条设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "进度条相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的进度条事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "进度条相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置进度条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置进度条当前的值, 比如: 37.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条当前的值, 比如: 37" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.value ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.value, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置进度条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置进度条当前值改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条当前值改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置进度条完成时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Complete
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.complete ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.complete, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ProgressbarSettingEditConverter "
	/// <summary>
	/// jQuery UI 进度条设置编辑器的转换器.
	/// </summary>
	public sealed class ProgressbarSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			ProgressbarSettingEdit edit = new ProgressbarSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ProgressbarSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ProgressbarSettingEdit setting = value as ProgressbarSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " SliderSettingEdit "
	/// <summary>
	/// jQuery UI 分割条的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( SliderSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class SliderSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的分割条设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "分割条相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的分割条事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "分割条相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置分割条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'" )]
		[NotifyParentProperty ( true )]
		public string Animate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animate, value ); }
		}

		/// <summary>
		/// 获取或设置分割条最大值, 比如: 100.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条最大值, 比如: 100" )]
		[NotifyParentProperty ( true )]
		public string Max
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.max ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.max, value ); }
		}

		/// <summary>
		/// 获取或设置分割条最小值, 比如: 0.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条最小值, 比如: 0" )]
		[NotifyParentProperty ( true )]
		public string Min
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.min ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.min, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的方向, 比如: 'horizontal', 'vertical'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的方向, 比如: 'horizontal', 'vertical'" )]
		[NotifyParentProperty ( true )]
		public string Orientation
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.orientation ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.orientation, value ); }
		}

		/// <summary>
		/// 获取或设置分割条是否使用范围, 或者为 'min', 'max' 中的一种.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条是否使用范围, 或者为 'min', 'max' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string Range
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.range ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.range, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的步长, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的步长, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public string Step
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.step ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.step, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的值, 比如: 30.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的值, 比如: 30" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.value ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.value, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的范围值, 比如: [1, 4, 10].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的范围值, 比如: [1, 4, 10]" )]
		[NotifyParentProperty ( true )]
		public string Values
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.values ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.values, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置分割条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置分割条开始拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条开始拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置分割条拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Slide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.slide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.slide, value ); }
		}

		/// <summary>
		/// 获取或设置分割条改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置分割条结束拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条结束拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " SliderSettingEditConverter "
	/// <summary>
	/// jQuery UI 分割条设置编辑器的转换器.
	/// </summary>
	public sealed class SliderSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			SliderSettingEdit edit = new SliderSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SliderSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SliderSettingEdit setting = value as SliderSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " TabsSettingEdit "
	/// <summary>
	/// jQuery UI 分组标签的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( TabsSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class TabsSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的分组标签设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "分组标签相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的分组标签事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "分组标签相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置分组标签是否可用, 或者禁用的标签的索引, 可以设置为 true, false, 或者 [0, 1].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签是否可用, 或者禁用的标签的索引, 可以设置为 true, false, 或者 [0, 1]" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置标签内容的 Ajax 选项, 比如: { async: false }.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签内容的 Ajax 选项, 比如: { async: false }" )]
		[NotifyParentProperty ( true )]
		public string AjaxOptions
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.ajaxOptions ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.ajaxOptions, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用缓存, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用缓存, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Cache
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cache ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cache, value ); }
		}

		/// <summary>
		/// 获取或设置当再次选择已选中的标签时, 是否取消选中状态, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示当再次选择已选中的标签时, 是否取消选中状态, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Collapsible
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.collapsible ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.collapsible, value ); }
		}

		/// <summary>
		/// 获取或设置 cookie 的设置, 比如: { expires: 7, path: '/', domain: 'jquery.com', secure: true }.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 cookie 的设置, 比如: { expires: 7, path: '/', domain: 'jquery.com', secure: true }" )]
		[NotifyParentProperty ( true )]
		public string Cookie
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cookie ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cookie, value ); }
		}

		/// <summary>
		/// 请使用 Collapsible.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "请使用 Collapsible" )]
		[NotifyParentProperty ( true )]
		public string Deselectable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.deselectable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.deselectable, value ); }
		}

		/// <summary>
		/// 获取或设置触发切换的事件名称, 默认: 'click'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示触发切换的事件名称, 默认: 'click'" )]
		[NotifyParentProperty ( true )]
		public string Event
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@event ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@event, value ); }
		}

		/// <summary>
		/// 获取或设置显示或者隐藏的动画效果, 比如: { opacity: 'toggle' }, 'slow', 'normal', 'fast'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示或者隐藏的动画效果, 比如: { opacity: 'toggle' }, 'slow', 'normal', 'fast'" )]
		[NotifyParentProperty ( true )]
		public string Fx
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.fx ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.fx, value ); }
		}

		/// <summary>
		/// 获取或设置 id 的前缀, 默认为 'ui-tabs-'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 id 的前缀, 默认为 'ui-tabs-'" )]
		[NotifyParentProperty ( true )]
		public string IdPrefix
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.idPrefix ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.idPrefix, value ); }
		}

		/// <summary>
		/// 获取或设置面板的模板内容.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示面板的模板内容, 默认为 '<div></div>'" )]
		[NotifyParentProperty ( true )]
		public string PanelTemplate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.panelTemplate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.panelTemplate, value ); }
		}

		/// <summary>
		/// 获取或设置选中的标签, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中的标签, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public string Selected
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selected ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selected, value ); }
		}

		/// <summary>
		/// 获取或设置载入条的内容.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示载入条的内容" )]
		[NotifyParentProperty ( true )]
		public string Spinner
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.spinner ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.spinner, value ); }
		}

		/// <summary>
		/// 获取或设置表头的模板内容.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示表头的模板内容, 默认为 '<li><a href=#{href}><span>#{label}</span></a></li>'" )]
		[NotifyParentProperty ( true )]
		public string TabTemplate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tabTemplate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tabTemplate, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置分组标签被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置分组标签被选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.select ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.select, value ); }
		}

		/// <summary>
		/// 获取或设置内容载入时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示内容载入时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Load
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.load ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.load, value ); }
		}

		/// <summary>
		/// 获取或设置标签显示时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签显示时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.show ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.show, value ); }
		}

		/// <summary>
		/// 获取或设置标签被添加时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被添加时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Add
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.add ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.add, value ); }
		}

		/// <summary>
		/// 获取或设置标签被删除时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被删除时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.remove ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.remove, value ); }
		}

		/// <summary>
		/// 获取或设置标签被启用时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被启用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Enable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.enable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.enable, value ); }
		}

		/// <summary>
		/// 获取或设置标签被禁用时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被禁用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Disable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disable, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " TabsSettingEditConverter "
	/// <summary>
	/// jQuery UI 分组标签设置编辑器的转换器.
	/// </summary>
	public sealed class TabsSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			TabsSettingEdit edit = new TabsSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is TabsSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			TabsSettingEdit setting = value as TabsSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " EmptySettingEdit "
	/// <summary>
	/// jQuery UI 空的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( EmptySettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class EmptySettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的空设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "空相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的空事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "空相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " EmptySettingEditConverter "
	/// <summary>
	/// jQuery UI 空设置编辑器的转换器.
	/// </summary>
	public sealed class EmptySettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			EmptySettingEdit edit = new EmptySettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is EmptySettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			EmptySettingEdit setting = value as EmptySettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/RepeaterSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIRepeaterSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIRepeaterSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/RepeaterSettingEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " RepeaterSettingEdit "
	/// <summary>
	/// jQuery UI Repeater 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( RepeaterSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class RepeaterSettingEdit
		: IStateManager
	{
		private string field = string.Empty;
		private string attribute = string.Empty;

		private readonly PlaceHolder header = new PlaceHolder ( );
		private readonly PlaceHolder footer = new PlaceHolder ( );
		private readonly PlaceHolder item = new PlaceHolder ( );
		private readonly PlaceHolder editItem = new PlaceHolder ( );
		private readonly PlaceHolder empty = new PlaceHolder ( );

		private string rowsName = "rows";

		private bool isRepeatable = false;

		/// <summary>
		/// 获取或设置字段的名称, 使用 ; 号分隔, 区分大小写.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "参加绑定的字段的名称, 使用 ; 号分隔, 区分大小写" )]
		[NotifyParentProperty ( true )]
		public string Field
		{
			get { return this.field; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.field = value;

			}
		}

		/// <summary>
		/// 获取或设置属性的名称, 使用 ; 号分隔, 区分大小写.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "参加绑定的属性的名称, 使用 ; 号分隔, 区分大小写" )]
		[NotifyParentProperty ( true )]
		public string Attribute
		{
			get { return this.attribute; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.attribute = value;

			}
		}

		/// <summary>
		/// 获取或设置 json 中行的属性名.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "rows" )]
		[Description ( "指示 json 中行的属性名" )]
		[NotifyParentProperty ( true )]
		public string RowsName
		{
			get { return this.rowsName; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.rowsName = value;

			}
		}

		/// <summary>
		/// 获取或设置是否可以使用 Repeater.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( false )]
		[Description ( "指示 Repeater 是否可用" )]
		[NotifyParentProperty ( true )]
		public bool IsRepeatable
		{
			get { return this.isRepeatable; }
			set { this.isRepeatable = value; }
		}

		/// <summary>
		/// 获取标题模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置标题模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Header
		{
			get { return this.header; }
		}

		/// <summary>
		/// 获取结尾模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置结尾模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Footer
		{
			get { return this.footer; }
		}

		/// <summary>
		/// 获取行模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置行模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Item
		{
			get { return this.item; }
		}

		/// <summary>
		/// 获取行编辑模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置行编辑模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder EditItem
		{
			get { return this.editItem; }
		}

		/// <summary>
		/// 获取空数据模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置空数据模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Empty
		{
			get { return this.empty; }
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.Field = states[0] as string;

			if ( states.Count >= 2 )
				this.isRepeatable = (bool) states[1];

			if ( states.Count >= 3 )
				this.RowsName = states[2] as string;

			if ( states.Count >= 4 )
				this.attribute = states[3] as string;

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.field );
			states.Add ( this.isRepeatable );
			states.Add ( this.rowsName );
			states.Add ( this.attribute );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " RepeaterSettingEditConverter "
	/// <summary>
	/// jQuery UI Repeater 设置编辑器的转换器.
	/// </summary>
	public sealed class RepeaterSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			RepeaterSettingEdit edit = new RepeaterSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 4 )
				try
				{

					if ( expressionHelper[0].Value != string.Empty )
						edit.IsRepeatable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

					if ( expressionHelper[1].Value != string.Empty )
						edit.RowsName = expressionHelper[1].Value;

					if ( expressionHelper[2].Value != string.Empty )
						edit.Field = expressionHelper[2].Value;

					if ( expressionHelper[3].Value != string.Empty )
						edit.Attribute = expressionHelper[3].Value;

				}
				catch { }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is RepeaterSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			RepeaterSettingEdit setting = value as RepeaterSettingEdit;

			return string.Format ( "{0}`;{1}`;{2}`;{3}`;", setting.IsRepeatable, setting.RowsName, setting.Field, setting.Attribute );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/SettingEditHelper.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISettingEditHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 编辑 OptionEdit, EventEdit 的辅助类.
	/// </summary>
	public sealed class SettingEditHelper
		: IStateManager
	{
		/// <summary>
		/// 内部的 OptionEdit 集合.
		/// </summary>
		public readonly List<OptionEdit> InnerOptionEdits = new List<OptionEdit> ( );
		/// <summary>
		/// 内部的 EventEdit 集合.
		/// </summary>
		public readonly List<EventEdit> InnerEventEdits = new List<EventEdit> ( );
		/// <summary>
		/// 外部的 OptionEdit 集合.
		/// </summary>
		public readonly List<OptionEdit> OuterOptionEdits = new List<OptionEdit> ( );
		/// <summary>
		/// 外部的 EventEdit 集合.
		/// </summary>
		public readonly List<EventEdit> OuterEventEdits = new List<EventEdit> ( );

		/// <summary>
		/// 创建对应的 Option 数组.
		/// </summary>
		/// <returns>Option 数组</returns>
		public Option[] CreateOptions ( )
		{
			List<Option> options = new List<Option> ( );

			foreach ( OptionEdit edit in this.InnerOptionEdits )
				options.Add ( edit.CreateOption ( ) );

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				options.Add ( edit.CreateOption ( ) );

			return options.ToArray ( );
		}

		/// <summary>
		/// 创建对应的 Event 数组.
		/// </summary>
		/// <returns>Event 数组</returns>
		public Event[] CreateEvents ( )
		{
			List<Event> events = new List<Event> ( );

			foreach ( EventEdit edit in this.OuterEventEdits )
				events.Add ( edit.CreateEvent ( ) );

			foreach ( EventEdit edit in this.InnerEventEdits )
				events.Add ( edit.CreateEvent ( ) );

			return events.ToArray ( );
		}

		/// <summary>
		/// 得到外部 OptionEdit 的值.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <returns>选项值.</returns>
		public string GetOuterOptionEditValue ( OptionType type )
		{

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				if ( edit.Type == type )
					return edit.Value;

			return string.Empty;
		}

		/// <summary>
		/// 设置外部 OptionEdit 的值.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">选项值.</param>
		public void SetOuterOptionEditValue ( OptionType type, string value )
		{

			if ( null == value )
				return;

			bool isExist = false;

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				if ( edit.Type == type )
				{
					edit.Value = value;
					isExist = true;
				}

			if ( !isExist )
			{
				OptionEdit edit = new OptionEdit ( );
				edit.Type = type;
				edit.Value = value;

				this.OuterOptionEdits.Add ( edit );
			}

		}

		/// <summary>
		/// 得到外部 EventEdit 的值.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <returns>事件值.</returns>
		public string GetOuterEventEditValue ( EventType type )
		{

			foreach ( EventEdit edit in this.OuterEventEdits )
				if ( edit.Type == type )
					return edit.Value;

			return string.Empty;
		}

		/// <summary>
		/// 设置外部 EventEdit 的值.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <param name="value">事件值.</param>
		public void SetOuterEventEditValue ( EventType type, string value )
		{

			if ( null == value )
				return;

			bool isExist = false;

			foreach ( EventEdit edit in this.OuterEventEdits )
				if ( edit.Type == type )
				{
					edit.Value = value;
					break;
				}

			if ( !isExist )
			{
				EventEdit edit = new EventEdit ( );
				edit.Type = type;
				edit.Value = value;

				this.OuterEventEdits.Add ( edit );
			}

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>字符串</returns>
		public override string ToString ( )
		{
			string optionExpression = string.Empty;

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				if ( edit.Value != string.Empty )
					optionExpression += string.Format ( "{0}={1}`;", edit.Type, edit.Value );

			optionExpression = "{" + optionExpression + "}`;";

			string eventExpression = string.Empty;

			foreach ( EventEdit edit in this.OuterEventEdits )
				if ( edit.Value != string.Empty )
					eventExpression += string.Format ( "{0}={1}`;", edit.Type, edit.Value );

			eventExpression = "{" + eventExpression + "}`;";

			return optionExpression + eventExpression;
		}

		/// <summary>
		/// 从字符串转化.
		/// </summary>
		/// <param name="expression">字符串.</param>
		public void FromString ( string expression )
		{

			if ( string.IsNullOrEmpty ( expression ) )
				return;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );


			if ( expressionHelper.ChildCount == 2 )
			{
				this.OuterOptionEdits.Clear ( );

				for ( int index = 0; index < expressionHelper[0].ChildCount; index++ )
				{
					string[] parts = expressionHelper[0][index].Value.Split ( '=' );

					if ( parts.Length != 2 || parts[1] == string.Empty )
						continue;

					try
					{ this.SetOuterOptionEditValue ( ( OptionType ) Enum.Parse ( typeof ( OptionType ), parts[0] ), parts[1] ); }
					catch { }

				}

				this.OuterEventEdits.Clear ( );

				for ( int index = 0; index < expressionHelper[1].ChildCount; index++ )
				{
					string[] parts = expressionHelper[1][index].Value.Split ( '=' );

					if ( parts.Length != 2 || parts[1] == string.Empty )
						continue;

					try
					{ this.SetOuterEventEditValue ( ( EventType ) Enum.Parse ( typeof ( EventType ), parts[0] ), parts[1] ); }
					catch { }

				}

			}

		}

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
			{
				List<object> optionStates = states[0] as List<object>;

				if ( null != optionStates )
					for ( int index = 0; index < this.InnerOptionEdits.Count; index++ )
						if ( index < optionStates.Count )
							( this.InnerOptionEdits[index] as IStateManager ).LoadViewState ( optionStates[index] );
						else
							break;

			}

			if ( states.Count >= 2 )
			{
				List<object> eventStates = states[1] as List<object>;

				if ( null != eventStates )
					for ( int index = 0; index < this.InnerEventEdits.Count; index++ )
						if ( index < eventStates.Count )
							( this.InnerEventEdits[index] as IStateManager ).LoadViewState ( eventStates[index] );
						else
							break;

			}

			if ( states.Count >= 3 )
			{
				List<object> optionStates = states[2] as List<object>;

				if ( null != optionStates )
					for ( int index = 0; index < this.OuterOptionEdits.Count; index++ )
						if ( index < optionStates.Count )
							( this.OuterOptionEdits[index] as IStateManager ).LoadViewState ( optionStates[index] );
						else
							break;

			}

			if ( states.Count >= 4 )
			{
				List<object> eventStates = states[3] as List<object>;

				if ( null != eventStates )
					for ( int index = 0; index < this.OuterEventEdits.Count; index++ )
						if ( index < eventStates.Count )
							( this.OuterEventEdits[index] as IStateManager ).LoadViewState ( eventStates[index] );
						else
							break;

			}

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			List<object> optionStates = new List<object> ( );

			foreach ( OptionEdit edit in this.InnerOptionEdits )
				optionStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( optionStates );

			List<object> eventStates = new List<object> ( );

			foreach ( EventEdit edit in this.InnerEventEdits )
				eventStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( eventStates );

			optionStates = new List<object> ( );

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				optionStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( optionStates );

			eventStates = new List<object> ( );

			foreach ( EventEdit edit in this.OuterEventEdits )
				eventStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( eventStates );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}

}
// ../.class/ui/jqueryui/JQueryScript.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryScript
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryScript.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



// HACK: 避免在 allinone 文件中的名称冲突

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

			if ( !this.Visible || this.html.Controls.Count != 1 )
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
// ../.class/ui/jqueryui/JQueryCoder.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryCoder
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryCoder.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 为 JQueryElement 以及相关控件中的内嵌语法执行操作.
	/// </summary>
	public sealed class JQueryCoder
	{

		/// <summary>
		/// 编码内嵌语法.
		/// </summary>
		/// <param name="control">控件.</param>
		/// <param name="code">包含内嵌语法的代码.</param>
		/// <returns>编码后的代码.</returns>
		public static string Encode ( NControl control, string code )
		{

			if ( string.IsNullOrEmpty ( code ) || null == control || null == control.Page )
				return string.Empty;

			int beginIndex;
			int endIndex;

			while ( true )
			{
				endIndex = code.IndexOf ( "%]" );

				if ( endIndex == -1 )
					break;

				beginIndex = code.LastIndexOf ( "[%", endIndex );

				if ( beginIndex == -1 )
					break;

				string expression = code.Substring ( beginIndex, endIndex - beginIndex + 2 );

				string command = expression.Replace ( "[%", string.Empty ).Replace ( "%]", string.Empty ).Trim ( );

				beginIndex = command.IndexOf ( ':' );

				if ( beginIndex <= 0 || beginIndex == command.Length - 1 )
					break;

				string commandName = command.Substring ( 0, beginIndex ).Trim ( ).ToLower ( );
				string commandParameter = command.Substring ( beginIndex + 1 ).Trim ( );

				if ( commandName == string.Empty || commandParameter == string.Empty )
					break;

				string result = null;

				switch ( commandName )
				{
					case "id":
						NControl aimControl = control.Page.FindControl ( commandParameter );

						if ( null != aimControl )
							result = aimControl.ClientID;

						break;

					case "param":

						try
						{ result = HttpContext.Current.Request[commandParameter]; }
						catch { }

						break;

					case "fun":
						MethodInfo methodInfo;
						NControl currentControl = control;

						while ( true )
						{
							methodInfo = currentControl.GetType ( ).GetMethod ( commandParameter, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic );

							if ( null != methodInfo || null == currentControl.Parent )
								break;

							currentControl = currentControl.Parent;
						}

						if ( null != methodInfo )
							if ( methodInfo.IsStatic )
								result = methodInfo.Invoke ( null, null ) as string;
							else
								result = methodInfo.Invoke ( currentControl, null ) as string;

						break;

					case "\\'":
						result = "' + " + commandParameter + " + '";
						break;

					case "\\\"":
						result = "\" + " + commandParameter + " + \"";
						break;
				}

				code = code.Replace ( expression, string.IsNullOrEmpty ( result ) ? "null" : result );
			}

			return code.Replace ( "!sq!", "'" ).Replace ( "!dq!", "'" );
		}

	}

}
// ../.class/web/jqueryui/DraggableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIDraggableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DraggableSetting "
	/// <summary>
	/// jQuery UI 拖动的相关设置.
	/// </summary>
	public sealed class DraggableSetting
	{
		/// <summary>
		/// 拖动相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以拖动.
		/// </summary>
		public readonly bool IsDraggable;

		/// <summary>
		/// 创建 jQuery UI 拖动的相关设置.
		/// </summary>
		/// <param name="isDraggable">是否可以拖动.</param>
		/// <param name="options">拖动相关选项.</param>
		public DraggableSetting ( bool isDraggable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsDraggable = isDraggable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/DroppableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIDroppableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DroppableSetting "
	/// <summary>
	/// jQuery UI 拖放的相关设置.
	/// </summary>
	public sealed class DroppableSetting
	{
		/// <summary>
		/// 拖放相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以拖放.
		/// </summary>
		public readonly bool IsDroppable;

		/// <summary>
		/// 创建 jQuery UI 拖放的相关设置.
		/// </summary>
		/// <param name="isDroppable">是否可以拖放.</param>
		/// <param name="options">拖放相关选项.</param>
		public DroppableSetting ( bool isDroppable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsDroppable = isDroppable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/ResizableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ResizableSetting "
	/// <summary>
	/// jQuery UI 缩放的相关设置.
	/// </summary>
	public sealed class ResizableSetting
	{
		/// <summary>
		/// 缩放相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以缩放.
		/// </summary>
		public readonly bool IsResizable;

		/// <summary>
		/// 创建 jQuery UI 缩放的相关设置.
		/// </summary>
		/// <param name="isResizable">是否可以缩放.</param>
		/// <param name="options">缩放相关选项.</param>
		public ResizableSetting ( bool isResizable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsResizable = isResizable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/SelectableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUISelectableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " SelectableSetting "
	/// <summary>
	/// jQuery UI 选中的相关设置.
	/// </summary>
	public sealed class SelectableSetting
	{
		/// <summary>
		/// 选中相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以选中.
		/// </summary>
		public readonly bool IsSelectable;

		/// <summary>
		/// 创建 jQuery UI 选中的相关设置.
		/// </summary>
		/// <param name="isSelectable">是否可以选中.</param>
		/// <param name="options">选中相关选项.</param>
		public SelectableSetting ( bool isSelectable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsSelectable = isSelectable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/SortableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUISortableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " SortableSetting "
	/// <summary>
	/// jQuery UI 排列的相关设置.
	/// </summary>
	public sealed class SortableSetting
	{
		/// <summary>
		/// 排列相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以排列.
		/// </summary>
		public readonly bool IsSortable;

		/// <summary>
		/// 创建 jQuery UI 排列的相关设置.
		/// </summary>
		/// <param name="isSortable">是否可以排列.</param>
		/// <param name="options">排列相关选项.</param>
		public SortableSetting ( bool isSortable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsSortable = isSortable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/ExpressionHelper.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/ExpressionHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ExpressionHelper "
	/// <summary>
	/// jQuery UI 的 ViewState 数据转换辅助类.
	/// </summary>
	public sealed class ExpressionHelper
	{
		private readonly List<ExpressionHelper> childExpressionHelpers = new List<ExpressionHelper> ( );

		private readonly string value = string.Empty;
		private readonly string name = string.Empty;

		/// <summary>
		/// 子数据转换辅助类.
		/// </summary>
		public List<ExpressionHelper> ChildExpressionHelpers
		{
			get { return this.childExpressionHelpers; }
		}

		/// <summary>
		/// 获取数据项名称.
		/// </summary>
		public string Name
		{
			get { return this.name; }
		}

		/// <summary>
		/// 获取数据项值.
		/// </summary>
		public string Value
		{
			get { return this.value; }
		}

		/// <summary>
		/// 获取是否有子数据.
		/// </summary>
		public bool IsHasChild
		{
			get { return this.ChildCount != 0; }
		}

		/// <summary>
		/// 获取子数据数量.
		/// </summary>
		public int ChildCount
		{
			get { return this.childExpressionHelpers.Count; }
		}

		/// <summary>
		/// 获取子数据的辅助类.
		/// </summary>
		/// <param name="index">子数据的索引.</param>
		/// <returns>子数据的辅助类.</returns>
		public ExpressionHelper this[int index]
		{
			get
			{

				if ( index < 0 || index >= this.ChildCount )
					return null;

				return this.childExpressionHelpers[index];
			}
		}

		/// <summary>
		/// 创建一个 jQuery UI 的 ViewState 数据转换辅助类.
		/// </summary>
		/// <param name="expression">数据字符串.</param>
		public ExpressionHelper ( string expression )
		{

			if ( null == expression )
				throw new ArgumentNullException ( "expression", "表达式不能为空" );

			expression = expression.Trim ( );

			if ( expression.Contains ( "`;" ) )
				foreach ( string part in expression.Split ( new string[] { "`;" }, StringSplitOptions.RemoveEmptyEntries ) )
					this.childExpressionHelpers.Add ( new ExpressionHelper ( part ) );
			else if ( expression.StartsWith ( "`|" ) && expression.EndsWith ( "|`" ) )
			{
				expression = expression.Trim ( '`' ).Trim ( '|' );

				foreach ( string part in expression.Split ( new string[] { "`," }, StringSplitOptions.RemoveEmptyEntries ) )
					this.childExpressionHelpers.Add ( new ExpressionHelper ( part ) );

			}
			else if ( expression.Contains ( "`:" ) )
			{
				string[] parts = expression.Split ( new string[] { "`:" }, StringSplitOptions.RemoveEmptyEntries );

				this.name = parts[0].Trim ( );
				this.value = parts[1].Trim ( );
			}
			else
				this.value = expression;


		}

	}
	#endregion

}
// ../.class/web/jqueryui/JQueryUI.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUI
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/JQueryUI.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " JQueryUI "
	/// <summary>
	/// jQuery UI 辅助类.
	/// </summary>
	public sealed class JQueryUI
		: JQuery
	{

		private static string makeOptionExpression ( List<Option> options )
		{

			if ( null == options || options.Count == 0 )
				return string.Empty;

			string optionExpression = "{";

			foreach ( Option option in options )
				if ( null != option && option.Type != OptionType.none && option.Value != string.Empty )
					optionExpression += string.Format ( " {0}: {1},", option.Type, option.Value );

			return optionExpression.TrimEnd ( ',' ) + " }";
		}

		private static string makeParameterExpression ( List<Parameter> parameters )
		{

			if ( null == parameters || parameters.Count == 0 )
				return string.Empty;

			string parameterExpression = "{";

			foreach ( Parameter parameter in parameters )
				if ( null != parameter && parameter.Value != string.Empty )
					switch ( parameter.Type )
					{
						case ParameterType.Selector:
							parameterExpression += string.Format ( " {0}: {1},", parameter.Name, JQuery.Create ( parameter.Value ).Val ( ).Code );
							break;

						case ParameterType.Expression:
							parameterExpression += string.Format ( " {0}: {1},", parameter.Name, parameter.Value );
							break;
					}

			return parameterExpression.TrimEnd ( ',' ) + " }";
		}

		#region " 构造 "

		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery UI 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( JQueryUI jQuery )
		{ return new JQueryUI ( jQuery ); }

		/// <summary>
		/// 创建使用别名的空的 JQuery UI.
		/// </summary>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( )
		{ return Create ( null, null, true ); }
		/// <summary>
		/// 创建空的 JQuery UI.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( bool isAlias )
		{ return Create ( null, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( string expressionI )
		{ return Create ( expressionI, null, true ); }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( string expressionI, bool isAlias )
		{ return Create ( expressionI, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( string expressionI, string expressionII )
		{ return Create ( expressionI, expressionII, true ); }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( string expressionI, string expressionII, bool isAlias )
		{ return new JQueryUI ( expressionI, expressionII, isAlias ); }

		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( bool isInstance, bool isAlias )
		{ return new JQueryUI ( isInstance, isAlias ); }


		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery UI 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		public JQueryUI ( JQueryUI jQuery )
			: base ( jQuery )
		{ }

		/// <summary>
		/// 创建使用别名的空的 JQuery UI.
		/// </summary>
		public JQueryUI ( )
			: this ( null, null, true )
		{ }
		/// <summary>
		/// 创建空的 JQuery UI.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( bool isAlias )
			: this ( null, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		public JQueryUI ( string expressionI )
			: this ( expressionI, null, true )
		{ }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( string expressionI, bool isAlias )
			: this ( expressionI, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		public JQueryUI ( string expressionI, string expressionII )
			: this ( expressionI, expressionII, true )
		{ }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( string expressionI, string expressionII, bool isAlias )
			: base ( expressionI, expressionII, isAlias )
		{ }

		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( bool isInstance, bool isAlias )
			: base ( isInstance, isAlias )
		{ }

		#endregion

		/// <summary>
		/// 拖动操作.
		/// </summary>
		/// <param name="setting">拖动的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Draggable ( DraggableSetting setting )
		{

			if ( null == setting || !setting.IsDraggable )
				return this;

			return this.Execute ( "draggable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// 拖放操作.
		/// </summary>
		/// <param name="setting">拖放的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Droppable ( DroppableSetting setting )
		{

			if ( null == setting || !setting.IsDroppable )
				return this;

			return this.Execute ( "droppable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// 排列操作.
		/// </summary>
		/// <param name="setting">排列的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Sortable ( SortableSetting setting )
		{

			if ( null == setting || !setting.IsSortable )
				return this;

			return this.Execute ( "sortable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// 选中操作.
		/// </summary>
		/// <param name="setting">选中的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Selectable ( SelectableSetting setting )
		{

			if ( null == setting || !setting.IsSelectable )
				return this;

			return this.Execute ( "selectable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// 缩放操作.
		/// </summary>
		/// <param name="setting">缩放的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Resizable ( ResizableSetting setting )
		{

			if ( null == setting || !setting.IsResizable )
				return this;

			return this.Execute ( "resizable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// Widget 操作.
		/// </summary>
		/// <param name="setting">Widget 相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Widget ( WidgetSetting setting )
		{

			if ( null == setting || setting.WidgetType == WidgetType.none )
				return this;

			if ( setting.WidgetType != WidgetType.empty )
				this.Execute ( setting.WidgetType.ToString ( ), makeOptionExpression ( setting.Options ) );

			foreach ( Event @event in setting.Events )
				if ( @event.Type != EventType.none && @event.Type != EventType.__init )
					this.Execute ( @event.Type.ToString ( ), @event.Value );

			foreach ( AjaxSetting ajaxSetting in setting.AjaxSettings )
			{

				if ( ajaxSetting.WidgetEventType == EventType.none )
					continue;

				string quote;

				if ( ajaxSetting.IsSingleQuote )
					quote = "'";
				else
					quote = "\"";

				string data;

				if ( string.IsNullOrEmpty ( ajaxSetting.Form ) )
					data = makeParameterExpression ( ajaxSetting.Parameters );
				else
					data = JQuery.Create ( ajaxSetting.Form ).Serialize ( ).Code;

				JQuery jQuery = JQuery.Create ( false, true );
				string map = string.Format ( "url: {0}{1}{0}, dataType: {0}{2}{0}, data: {3}", quote, ajaxSetting.Url, ajaxSetting.DataType, string.IsNullOrEmpty ( data ) ? "{ }" : data );

				foreach ( Event @event in ajaxSetting.Events )
					if ( @event.Type != EventType.none && @event.Type != EventType.__init )
						map += ", " + @event.Type + ": " + @event.Value;

				jQuery.Ajax ( "{" + map + "}" );

				if ( ajaxSetting.WidgetEventType == EventType.__init )
					this.EndLine ( ).AppendCode ( jQuery.Code );
				else
					this.Bind ( string.Format ( "'{0}'", ajaxSetting.WidgetEventType ), "function(e){" + jQuery.Code + "}" );
				// this.Execute ( ajaxSetting.WidgetEventType.ToString ( ), "function(e){" + jQuery.Code + "}" );

			}

			return this;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/Option.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOption
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOptionType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " OptionType "
	/// <summary>
	/// jQuery UI 的选项类型.
	/// </summary>
	public enum OptionType
	{
		/// <summary>
		/// 空的选项.
		/// </summary>
		none = 0,

		/// <summary>
		/// 禁用, 对应一个 javascript 布尔值或者数组.
		/// </summary>
		disabled = 1,

		/// <summary>
		/// 是否添加默认样式, 对应一个 javascript 布尔值.
		/// </summary>
		addClasses = 2,

		/// <summary>
		/// 追加位置, 对应一个 javascript 元素或者选择器.
		/// </summary>
		appendTo = 3,

		/// <summary>
		/// 指定 x/y 轴, 对应一个 javascript 字符串, 'x' 或者 'y'.
		/// </summary>
		axis = 4,

		/// <summary>
		/// 在符合选择器的元素上取消操作, 对应选择器.
		/// </summary>
		cancel = 5,

		/// <summary>
		/// 关联符合选择器的排序, 对应选择器.
		/// </summary>
		connectToSortable = 6,

		/// <summary>
		/// 操作所在的容器, 对应选择器, javascript 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		containment = 7,

		/// <summary>
		/// 鼠标样式, 对应一个 javascript 字符串.
		/// </summary>
		cursor = 8,

		/// <summary>
		/// 鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性.
		/// </summary>
		cursorAt = 9,

		/// <summary>
		/// 以毫秒计算的延迟, 对应一个 javascript 数值.
		/// </summary>
		delay = 10,

		/// <summary>
		/// 距离, 对应一个 javascript 数值.
		/// </summary>
		distance = 11,

		/// <summary>
		/// 表格, 对应一个 javascript 数组, [10, 20].
		/// </summary>
		grid = 12,

		/// <summary>
		/// 限制或者相关的句柄, 对应一个 javascript 元素或者选择器.
		/// </summary>
		handle = 13,

		/// <summary>
		/// 行为方式, 对应一个 javascript 字符串或者返回字符串的函数, 'original' 针对元素本身, 'clone' 针对元素的副本.
		/// </summary>
		helper = 14,

		/// <summary>
		/// 是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器.
		/// </summary>
		iframeFix = 15,

		/// <summary>
		/// 透明度, 对应一个 javascript 数值, 0 到 1 之间.
		/// </summary>
		opacity = 16,

		/// <summary>
		/// 刷新位置, 对应一个 javascript 布尔值.
		/// </summary>
		refreshPositions = 17,

		/// <summary>
		/// 恢复原始状态, 对应一个 javascript 布尔值, 或者恢复的毫秒数.
		/// </summary>
		revert = 18,

		/// <summary>
		/// 恢复原始状态的延迟, 以毫秒计算, 对应一个 javascript 数值.
		/// </summary>
		revertDuration = 19,

		/// <summary>
		/// 使用范围, 将各种操作功能关联, 对应一个 javascript 字符串.
		/// </summary>
		scope = 20,

		/// <summary>
		/// 使用滚动轴, 对应一个 javascript 布尔值.
		/// </summary>
		scroll = 21,

		/// <summary>
		/// 滚动轴灵敏度, 对应一个 javascript 数值.
		/// </summary>
		scrollSensitivity = 22,

		/// <summary>
		/// 滚动轴速度, 对应一个 javascript 数值.
		/// </summary>
		scrollSpeed = 23,

		/// <summary>
		/// 附着, 对应一个 javascript 布尔值或选择器.
		/// </summary>
		snap = 24,

		/// <summary>
		/// 附着模式, 对应一个 javascript 字符串, 可以是 'inner', 'outer', 'both'.
		/// </summary>
		snapMode = 25,

		/// <summary>
		/// 附着距离, 对应一个 javascript 数值.
		/// </summary>
		snapTolerance = 26,

		/// <summary>
		/// 控制 z 轴顺序, 对应一个选择器.
		/// </summary>
		stack = 27,

		/// <summary>
		/// z 轴顺序, 对应一个 javascript 数值.
		/// </summary>
		zIndex = 28,

		/// <summary>
		/// 被创建时, 对应一个 javascript 函数.
		/// </summary>
		create = 29,

		/// <summary>
		/// 动作开始时, 对应一个 javascript 函数.
		/// </summary>
		start = 30,

		/// <summary>
		/// 拖动时, 对应一个 javascript 函数.
		/// </summary>
		drag = 31,

		/// <summary>
		/// 动作停止时, 对应一个 javascript 函数.
		/// </summary>
		stop = 32,

		/// <summary>
		/// 动作接受的目标, 对应一个 javascript 函数或者选择器.
		/// </summary>
		accept = 33,

		/// <summary>
		/// 提供可用时的样式, 对应一个 javascript 字符串.
		/// </summary>
		activeClass = 34,

		/// <summary>
		/// 阻止事件的传播, 对应一个 javascript 布尔值.
		/// </summary>
		greedy = 35,

		/// <summary>
		/// 提供悬浮样式, 对应一个 javascript 字符串.
		/// </summary>
		hoverClass = 36,

		/// <summary>
		/// 接触的模式, 对应一个 javascript 字符串, 为 'fit', 'intersect', 'pointer', 'touch' 中的一种.
		/// </summary>
		tolerance = 37,

		/// <summary>
		/// 被激活时, 对应一个 javascript 函数.
		/// </summary>
		activate = 38,

		/// <summary>
		/// 取消激活时, 对应一个 javascript 函数.
		/// </summary>
		deactivate = 39,

		/// <summary>
		/// 在元素上时, 对应一个 javascript 函数.
		/// </summary>
		over = 40,

		/// <summary>
		/// 在元素之外时, 对应一个 javascript 函数.
		/// </summary>
		@out = 41,

		/// <summary>
		/// 元素放下时, 对应一个 javascript 函数.
		/// </summary>
		drop = 42,

		/// <summary>
		/// 关联的元素, 对应一个选择器.
		/// </summary>
		connectWith = 43,

		/// <summary>
		/// 是否允许拖放目标为空, 对应一个 javascript 布尔值.
		/// </summary>
		dropOnEmpty = 44,

		/// <summary>
		/// 强制 helper 拥有尺寸, 对应一个 javascript 布尔值.
		/// </summary>
		forceHelperSize = 45,

		/// <summary>
		/// 强制 placeholder 拥有尺寸, 对应一个 javascript 布尔值.
		/// </summary>
		forcePlaceholderSize = 46,

		/// <summary>
		/// 针对的条目, 对应一个选择器.
		/// </summary>
		items = 47,

		/// <summary>
		/// 应用于空白的样式, 对应一个 javascript 字符串.
		/// </summary>
		placeholder = 48,

		/// <summary>
		/// 排序时, 对应一个 javascript 函数.
		/// </summary>
		sort = 49,

		/// <summary>
		/// 改变时, 对应一个 javascript 函数.
		/// </summary>
		change = 50,

		/// <summary>
		/// 动作停止之前, 对应一个 javascript 函数.
		/// </summary>
		beforeStop = 51,

		/// <summary>
		/// 更新后, 对应一个 javascript 函数.
		/// </summary>
		update = 52,

		/// <summary>
		/// 接收时, 对应一个 javascript 函数.
		/// </summary>
		receive = 53,

		/// <summary>
		/// 移除后, 对应一个 javascript 函数.
		/// </summary>
		remove = 54,

		/// <summary>
		/// 自动刷新, 对应一个 javascript 布尔值.
		/// </summary>
		autoRefresh = 55,

		/// <summary>
		/// 对目标的过滤, 对应选择器.
		/// </summary>
		filter = 56,

		/// <summary>
		/// 选择后, 对应一个 javascript 函数.
		/// </summary>
		selected = 57,

		/// <summary>
		/// 选择时, 对应一个 javascript 函数.
		/// </summary>
		selecting = 58,

		/// <summary>
		/// 取消选择后, 对应一个 javascript 函数.
		/// </summary>
		unselected = 59,

		/// <summary>
		/// 取消选择时, 对应一个 javascript 函数.
		/// </summary>
		unselecting = 60,

		/// <summary>
		/// 同时缩放, 对应一个 javascript 元素, 选择器或者 jQuery.
		/// </summary>
		alsoResize = 61,

		/// <summary>
		/// 播放动画, 对应一个 javascript 布尔值.
		/// </summary>
		animate = 62,

		/// <summary>
		/// 播放动画延迟, 对应一个 javascript 数值.
		/// </summary>
		animateDuration = 63,

		/// <summary>
		/// 动画效果, 对应一个 javascript 字符串.
		/// </summary>
		animateEasing = 64,

		/// <summary>
		/// 宽高比例, 对应一个 javascript 布尔值或者数值.
		/// </summary>
		aspectRatio = 65,

		/// <summary>
		/// 自动隐藏, 对应一个 javascript 布尔值.
		/// </summary>
		autoHide = 66,

		/// <summary>
		/// 复制, 对应一个 javascript 布尔值.
		/// </summary>
		ghost = 67,

		/// <summary>
		/// 缩放的方式, 对应一个 javascript 字符串或者对象.
		/// </summary>
		handles = 68,

		/// <summary>
		/// 最大高度, 对应一个 javascript 数值.
		/// </summary>
		maxHeight = 69,

		/// <summary>
		/// 最大宽度, 对应一个 javascript 数值.
		/// </summary>
		maxWidth = 70,

		/// <summary>
		/// 最小高度, 对应一个 javascript 数值.
		/// </summary>
		minHeight = 71,

		/// <summary>
		/// 最小宽度, 对应一个 javascript 数值.
		/// </summary>
		minWidth = 72,

		/// <summary>
		/// 大小缩放时, 对应一个 javascript 函数.
		/// </summary>
		resize = 73,

		/// <summary>
		/// 是否使用文本, 对应一个 javascript 布尔值.
		/// </summary>
		text = 74,

		/// <summary>
		/// 图标, 对应一个 javascript 对象.
		/// </summary>
		icons = 75,

		/// <summary>
		/// 标签, 对应一个 javascript 字符串.
		/// </summary>
		label = 76,

		/// <summary>
		/// 激活的内容, 对应一个选择器, 元素, 数值或者布尔值.
		/// </summary>
		active = 77,

		/// <summary>
		/// 动画, 对应一个 javascript 字符串或者布尔值.
		/// </summary>
		animated = 78,

		/// <summary>
		/// 自动调整高度, 对应一个 javascript 布尔值.
		/// </summary>
		autoHeight = 79,

		/// <summary>
		/// 清除样式, 对应一个 javascript 布尔值.
		/// </summary>
		clearStyle = 80,

		/// <summary>
		/// 是否合并, 对应一个 javascript 布尔值.
		/// </summary>
		collapsible = 81,

		/// <summary>
		/// 触发的事件, 对应一个 javascript 字符串.
		/// </summary>
		@event = 82,

		/// <summary>
		/// 是否填充空白, 对应一个 javascript 布尔值.
		/// </summary>
		fillSpace = 83,

		/// <summary>
		/// 标题内容, 对应一个选择器或者 jQuery.
		/// </summary>
		header = 84,

		/// <summary>
		/// 是否导航, 对应一个 javascript 布尔值.
		/// </summary>
		navigation = 85,

		/// <summary>
		/// 导航过滤, 对应一个 javascript 函数.
		/// </summary>
		navigationFilter = 86,

		/// <summary>
		/// 改变开始时, 对应一个 javascript 函数.
		/// </summary>
		changestart = 87,

		/// <summary>
		/// 自动获得焦点, 对应一个 javascript 布尔值.
		/// </summary>
		autoFocus = 88,

		/// <summary>
		/// 最小长度, 对应一个 javascript 数值.
		/// </summary>
		minLength = 89,

		/// <summary>
		/// 位置, 对应一个 javascript 对象.
		/// </summary>
		position = 90,

		/// <summary>
		/// 源, 对应一个 javascript 字符串或者数组.
		/// </summary>
		source = 91,

		/// <summary>
		/// 搜索时, 对应一个 javascript 函数.
		/// </summary>
		search = 92,

		/// <summary>
		/// 打开时, 对应一个 javascript 函数.
		/// </summary>
		open = 93,

		/// <summary>
		/// 获得焦点时, 对应一个 javascript 函数.
		/// </summary>
		focus = 94,

		/// <summary>
		/// 选择时或者选中的, 对应一个 javascript 函数或者数组.
		/// </summary>
		select = 95,

		/// <summary>
		/// 关闭时, 对应一个 javascript 函数.
		/// </summary>
		close = 96,

		/// <summary>
		/// 进度值, 对应一个 javascript 数值.
		/// </summary>
		value = 97,

		/// <summary>
		/// 完成时, 对应一个 javascript 函数.
		/// </summary>
		complete = 98,

		/// <summary>
		/// 提示元素, 对应一个选择器或者元素.
		/// </summary>
		altField = 99,

		/// <summary>
		/// 提示的格式, 对应一个 javascript 字符串.
		/// </summary>
		altFormat = 100,

		/// <summary>
		/// 追加的文本, 对应一个 javascript 字符串.
		/// </summary>
		appendText = 101,

		/// <summary>
		/// 自动改变大小, 对应一个 javascript 布尔值.
		/// </summary>
		autoSize = 102,

		/// <summary>
		/// 按钮图片, 对应一个 javascript 字符串.
		/// </summary>
		buttonImage = 103,

		/// <summary>
		/// 只显示按钮图片, 对应一个 javascript 布尔值.
		/// </summary>
		buttonImageOnly = 104,

		/// <summary>
		/// 按钮文本, 对应一个 javascript 字符串.
		/// </summary>
		buttonText = 105,

		/// <summary>
		/// 如何计算周.
		/// </summary>
		calculateWeek = 106,

		/// <summary>
		/// 是否可以改变月份, 对应一个 javascript 布尔值.
		/// </summary>
		changeMonth = 107,

		/// <summary>
		/// 是否可以改变年份, 对应一个 javascript 布尔值.
		/// </summary>
		changeYear = 108,

		/// <summary>
		/// 关闭的文本, 对应一个 javascript 字符串.
		/// </summary>
		closeText = 109,

		/// <summary>
		/// 是否限制输入, 对应一个 javascript 布尔值.
		/// </summary>
		constrainInput = 110,

		/// <summary>
		/// 当前日期的显示文本, 对应一个 javascript 字符串.
		/// </summary>
		currentText = 111,

		/// <summary>
		/// 日期格式, 对应一个 javascript 字符串.
		/// </summary>
		dateFormat = 112,

		/// <summary>
		/// 星期的名称, 对应一个 javascript 数组.
		/// </summary>
		dayNames = 113,

		/// <summary>
		/// 星期的最短名称, 对应一个 javascript 数组.
		/// </summary>
		dayNamesMin = 114,

		/// <summary>
		/// 星期的短名称, 对应一个 javascript 数组.
		/// </summary>
		dayNamesShort = 115,

		/// <summary>
		/// 默认的日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		defaultDate = 116,

		/// <summary>
		/// 间隔, 对应一个 javascript 字符串.
		/// </summary>
		duration = 117,

		/// <summary>
		/// 一周开始的一天, 对应一个 javascript 数值.
		/// </summary>
		firstDay = 118,

		/// <summary>
		/// 是否当前时间为选中时间, 对应一个 javascript 布尔值.
		/// </summary>
		gotoCurrent = 119,

		/// <summary>
		/// 是否隐藏上一和下一按钮, 对应一个 javascript 布尔值.
		/// </summary>
		hideIfNoPrevNext = 120,

		/// <summary>
		/// 是否从右到左, 对应一个 javascript 布尔值.
		/// </summary>
		isRTL = 121,

		/// <summary>
		/// 最大日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		maxDate = 122,

		/// <summary>
		/// 最小日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		minDate = 123,

		/// <summary>
		/// 月的名称, 对应一个 javascript 数组.
		/// </summary>
		monthNames = 124,

		/// <summary>
		/// 月的短名称, 对应一个 javascript 数组.
		/// </summary>
		monthNamesShort = 125,

		/// <summary>
		/// 导航应用日期格式, 对应一个 javascript 布尔值.
		/// </summary>
		navigationAsDateFormat = 126,

		/// <summary>
		/// 下一个的文本, 对应一个 javascript 字符串.
		/// </summary>
		nextText = 127,

		/// <summary>
		/// 显示的月数, 对应一个 javascript 数值.
		/// </summary>
		numberOfMonths = 128,

		/// <summary>
		/// 上一个的文本, 对应一个 javascript 字符串.
		/// </summary>
		prevText = 129,

		/// <summary>
		/// 是否可以选择其它月, 对应一个 javascript 布尔值.
		/// </summary>
		selectOtherMonths = 130,

		/// <summary>
		/// 尚不明确, 对应一个 javascript 字符串或者数值.
		/// </summary>
		shortYearCutoff = 131,

		/// <summary>
		/// 显示动画, 对应一个 javascript 字符串.
		/// </summary>
		showAnim = 132,

		/// <summary>
		/// 是否显示按钮栏, 对应一个 javascript 布尔值.
		/// </summary>
		showButtonPanel = 133,

		/// <summary>
		/// 当前月份显示的位置, 对应一个 javascript 数值.
		/// </summary>
		showCurrentAtPos = 134,

		/// <summary>
		/// 是否在年后显示月份, 对应一个 javascript 布尔值.
		/// </summary>
		showMonthAfterYear = 135,

		/// <summary>
		/// 是否显示按钮效果, 对应一个 javascript 字符串.
		/// </summary>
		showOn = 136,

		/// <summary>
		/// 显示的样式, 对应一个 javascript 对象.
		/// </summary>
		showOptions = 137,

		/// <summary>
		/// 是否显示其它月, 对应一个 javascript 布尔值.
		/// </summary>
		showOtherMonths = 138,

		/// <summary>
		/// 是否显示周, 对应一个 javascript 布尔值.
		/// </summary>
		showWeek = 139,

		/// <summary>
		/// 一次跳转的月份数, 对应一个 javascript 数值.
		/// </summary>
		stepMonths = 140,

		/// <summary>
		/// 周的标题, 对应一个 javascript 字符串.
		/// </summary>
		weekHeader = 141,

		/// <summary>
		/// 年的跨度, 对应一个 javascript 数值.
		/// </summary>
		yearRange = 142,

		/// <summary>
		/// 年份的附加标题, 对应一个 javascript 字符串.
		/// </summary>
		yearSuffix = 143,

		/// <summary>
		/// 显示之前, 对应一个 javascript 函数.
		/// </summary>
		beforeShow = 144,

		/// <summary>
		/// 显示日期之前, 对应一个 javascript 函数.
		/// </summary>
		beforeShowDay = 145,

		/// <summary>
		/// 改变月年时, 对应一个 javascript 函数.
		/// </summary>
		onChangeMonthYear = 146,

		/// <summary>
		/// 关闭时, 对应一个 javascript 函数.
		/// </summary>
		onClose = 147,

		/// <summary>
		/// 选择时, 对应一个 javascript 函数.
		/// </summary>
		onSelect = 148,

		/// <summary>
		/// 是否自动打开, 对应一个 javascript 布尔值.
		/// </summary>
		autoOpen = 149,

		/// <summary>
		/// 按钮, 对应一个 javascript 对象或者数组.
		/// </summary>
		buttons = 150,

		/// <summary>
		/// 是否按下 Esc 建关闭, 对应一个 javascript 布尔值.
		/// </summary>
		closeOnEscape = 151,

		/// <summary>
		/// 对话框的样式, 对应一个 javascript 字符串.
		/// </summary>
		dialogClass = 152,

		/// <summary>
		/// 是否允许拖动, 对应一个 javascript 布尔值.
		/// </summary>
		draggable = 153,

		/// <summary>
		/// 高度, 对应一个 javascript 数值.
		/// </summary>
		height = 154,

		/// <summary>
		/// 关闭时的效果, 对应一个 javascript 字符串.
		/// </summary>
		hide = 155,

		/// <summary>
		/// 是否使用 modal, 对应一个 javascript 布尔值.
		/// </summary>
		modal = 156,

		/// <summary>
		/// 是否可以缩放, 对应一个 javascript 布尔值.
		/// </summary>
		resizable = 157,

		/// <summary>
		/// 显示时的效果, 对应一个 javascript 字符串.
		/// </summary>
		show = 158,

		/// <summary>
		/// 标题, 对应一个 javascript 字符串.
		/// </summary>
		title = 161,

		/// <summary>
		/// 宽度, 对应一个 javascript 数值.
		/// </summary>
		width = 162,

		/// <summary>
		/// 关闭之前, 对应一个 javascript 函数.
		/// </summary>
		beforeClose = 163,

		/// <summary>
		/// 拖动开始, 对应一个 javascript 函数.
		/// </summary>
		dragStart = 164,

		/// <summary>
		/// 拖动停止, 对应一个 javascript 函数.
		/// </summary>
		dragStop = 165,

		/// <summary>
		/// 缩放开始, 对应一个 javascript 函数.
		/// </summary>
		resizeStart = 166,

		/// <summary>
		/// 缩放停止, 对应一个 javascript 函数.
		/// </summary>
		resizeStop = 166,

		/// <summary>
		/// 最大值, 对应一个 javascript 数值.
		/// </summary>
		max = 167,

		/// <summary>
		/// 最小值, 对应一个 javascript 数值.
		/// </summary>
		min = 168,

		/// <summary>
		/// 方向, 对应一个 javascript 字符串.
		/// </summary>
		orientation = 169,

		/// <summary>
		/// 使用范围, 对应一个 javascript 字符串或者布尔值.
		/// </summary>
		range = 170,

		/// <summary>
		/// 步长, 对应一个 javascript 数值.
		/// </summary>
		step = 171,

		/// <summary>
		/// 值, 对应一个 javascript 数组.
		/// </summary>
		values = 172,

		/// <summary>
		/// 滑动时, 对应一个 javascript 函数.
		/// </summary>
		slide = 173,

		/// <summary>
		/// Ajax 选项, 对应一个 javascript 对象.
		/// </summary>
		ajaxOptions = 174,

		/// <summary>
		/// 是否缓存, 对应一个 javascript 布尔值.
		/// </summary>
		cache = 175,

		/// <summary>
		/// Cookie, 对应一个 javascript 对象.
		/// </summary>
		cookie = 176,

		/// <summary>
		/// 应使用 collapsible.
		/// </summary>
		deselectable = 177,

		/// <summary>
		/// 效果, 对应一个 javascript 对象或者数组.
		/// </summary>
		fx = 179,

		/// <summary>
		/// id 前缀, 对应一个 javascript 字符串.
		/// </summary>
		idPrefix = 180,

		/// <summary>
		/// 面板模板, 对应一个 javascript 字符串.
		/// </summary>
		panelTemplate = 181,

		/// <summary>
		/// 载入条, 对应一个 javascript 字符串.
		/// </summary>
		spinner = 183,

		/// <summary>
		/// 标签模板, 对应一个 javascript 字符串.
		/// </summary>
		tabTemplate = 184,

		/// <summary>
		/// 载入时, 对应一个 javascript 函数.
		/// </summary>
		load = 185,
		
		/// <summary>
		/// 添加时, 对应一个 javascript 函数.
		/// </summary>
		add = 186,

		/// <summary>
		/// 可用时, 对应一个 javascript 函数.
		/// </summary>
		enable = 187,

		/// <summary>
		/// 禁用时, 对应一个 javascript 函数.
		/// </summary>
		disable = 188,
	}
	#endregion

	#region " Option "
	/// <summary>
	/// jQuery UI 的选项.
	/// </summary>
	public sealed class Option
	{
		/// <summary>
		/// 选项类型.
		/// </summary>
		public readonly OptionType Type;
		/// <summary>
		/// 选项值.
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// 创建一个 jQuery UI 选项.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">选项值.</param>
		public Option ( OptionType type, string value )
		{

			if ( null == value )
				value = string.Empty;

			this.Type = type;
			this.Value = value;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/Event.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEvent
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEventType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " EventType "
	/// <summary>
	/// jQuery UI 的事件类型.
	/// </summary>
	public enum EventType
	{
		/// <summary>
		/// 没有任何事件.
		/// </summary>
		none = 0,
		/// <summary>
		/// 完成时.
		/// </summary>
		complete,
		/// <summary>
		/// 出错时.
		/// </summary>
		error,
		/// <summary>
		/// 成功时.
		/// </summary>
		success,
		/// <summary>
		/// 点击时.
		/// </summary>
		click,
		/// <summary>
		/// 提交时.
		/// </summary>
		submit,
		/// <summary>
		/// 选中时.
		/// </summary>
		select,
		/// <summary>
		/// 滚动轴事件.
		/// </summary>
		scroll,
		/// <summary>
		/// document 准备好时.
		/// </summary>
		ready,
		/// <summary>
		/// 尺寸改变时.
		/// </summary>
		resize,
		/// <summary>
		/// 鼠标按下时.
		/// </summary>
		mousedown,
		/// <summary>
		/// 鼠标进入时.
		/// </summary>
		mouseenter,
		/// <summary>
		/// 鼠标离开时.
		/// </summary>
		mouseleave,
		/// <summary>
		/// 鼠标移动时.
		/// </summary>
		mousemove,
		/// <summary>
		/// 鼠标移出时.
		/// </summary>
		mouseout,
		/// <summary>
		/// 鼠标在其上时.
		/// </summary>
		mouseover,
		/// <summary>
		/// 鼠标松开时.
		/// </summary>
		mouseup,
		/// <summary>
		/// 载入时.
		/// </summary>
		load,
		/// <summary>
		/// 按键按下.
		/// </summary>
		keydown,
		/// <summary>
		/// 按键按住.
		/// </summary>
		keypress,
		/// <summary>
		/// 按键松开.
		/// </summary>
		keyup,
		/// <summary>
		/// 悬停.
		/// </summary>
		hover,
		/// <summary>
		/// 获得焦点.
		/// </summary>
		focus,
		/// <summary>
		/// 双击时.
		/// </summary>
		dblclick,
		/// <summary>
		/// 改变时.
		/// </summary>
		change,
		/// <summary>
		/// 失去焦点时.
		/// </summary>
		blur,
		/// <summary>
		/// 在定义后执行.
		/// </summary>
		__init,
		/// <summary>
		/// 开始时.
		/// </summary>
		start,
		/// <summary>
		/// 停止时.
		/// </summary>
		stop,
		/// <summary>
		/// 发送时.
		/// </summary>
		send,
		/// <summary>
		/// 按钮创建时.
		/// </summary>
		buttoncreate,
		/// <summary>
		/// 进度条创建时.
		/// </summary>
		progressbarcreate,
		/// <summary>
		/// 进度条改变时.
		/// </summary>
		progressbarchange,
		/// <summary>
		/// 进度条完成时.
		/// </summary>
		progressbarcomplete,
		/// <summary>
		/// 分组标签创建时.
		/// </summary>
		tabscreate,
		/// <summary>
		/// 分组标签选择时.
		/// </summary>
		tabsselect,
		/// <summary>
		/// 分组标签载入时.
		/// </summary>
		tabsload,
		/// <summary>
		/// 分组标签显示时.
		/// </summary>
		tabsshow,
		/// <summary>
		/// 分组标签添加时.
		/// </summary>
		tabsadd,
		/// <summary>
		/// 分组标签删除时.
		/// </summary>
		tabsremove,
		/// <summary>
		/// 分组标签可用时.
		/// </summary>
		tabsenable,
		/// <summary>
		/// 分组标签禁用时.
		/// </summary>
		tabsdisable,
		/// <summary>
		/// 对话框创建时.
		/// </summary>
		dialogcreate,
		/// <summary>
		/// 对话框关闭之前时.
		/// </summary>
		dialogbeforeclose,
		/// <summary>
		/// 对话框开始时.
		/// </summary>
		dialogopen,
		/// <summary>
		/// 对话框获得焦点时.
		/// </summary>
		dialogfocus,
		/// <summary>
		/// 对话框拖动开始时.
		/// </summary>
		dialogdragstart,
		/// <summary>
		/// 对话框拖动时.
		/// </summary>
		dialogdrag,
		/// <summary>
		/// 对话框拖动结束时.
		/// </summary>
		dialogdragstop,
		/// <summary>
		/// 对话框缩放开始时.
		/// </summary>
		dialogresizestart,
		/// <summary>
		/// 对话框缩放时.
		/// </summary>
		dialogresize,
		/// <summary>
		/// 对话框缩放结束时.
		/// </summary>
		dialogresizestop,
		/// <summary>
		/// 对话框关闭时.
		/// </summary>
		dialogclose,
		/// <summary>
		/// 分割条创建时.
		/// </summary>
		slidecreate,
		/// <summary>
		/// 分割条开始滑动时.
		/// </summary>
		slidestart,
		/// <summary>
		/// 分割条滑动时.
		/// </summary>
		slide,
		/// <summary>
		/// 分割条改变时.
		/// </summary>
		slidechange,
		/// <summary>
		/// 分割条停止滑动时.
		/// </summary>
		slidestop,
		/// <summary>
		/// 折叠列表创建时.
		/// </summary>
		accordioncreate,
		/// <summary>
		/// 折叠列表改变时.
		/// </summary>
		accordionchange,
		/// <summary>
		/// 折叠列表开始改变时.
		/// </summary>
		accordionchangestart,
		/// <summary>
		/// 日期框创建时.
		/// </summary>
		datepickercreate,
		/// <summary>
		/// 自动填充创建时.
		/// </summary>
		autocompletecreate,
		/// <summary>
		/// 自动填充搜索时.
		/// </summary>
		autocompletesearch,
		/// <summary>
		/// 自动填充打开时.
		/// </summary>
		autocompleteopen,
		/// <summary>
		/// 自动填充获得焦点时.
		/// </summary>
		autocompletefocus,
		/// <summary>
		/// 自动填充选择时时.
		/// </summary>
		autocompleteselect,
		/// <summary>
		/// 自动填充关闭时.
		/// </summary>
		autocompleteclose,
		/// <summary>
		/// 自动填充改变时.
		/// </summary>
		autocompletechange,
	}
	#endregion

	#region " Event "
	/// <summary>
	/// jQuery UI 的事件.
	/// </summary>
	public sealed class Event
	{
		/// <summary>
		/// 事件类型.
		/// </summary>
		public readonly EventType Type;
		/// <summary>
		/// 事件内容.
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// 创建一个 jQuery UI 事件.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <param name="value">事件内容.</param>
		public Event ( EventType type, string value )
		{

			if ( null == value )
				value = string.Empty;

			this.Type = type;
			this.Value = value;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/Parameter.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameterType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ParameterType "
	/// <summary>
	/// jQuery UI 的参数类型.
	/// </summary>
	public enum ParameterType
	{
		/// <summary>
		/// 表达式.
		/// </summary>
		Expression = 1,
		/// <summary>
		/// 选择器.
		/// </summary>
		Selector = 2,
	}
	#endregion

	#region " Parameter "
	/// <summary>
	/// jQuery UI 的参数.
	/// </summary>
	public sealed class Parameter
	{
		/// <summary>
		/// 参数名称.
		/// </summary>
		public readonly string Name;
		/// <summary>
		/// 参数类型.
		/// </summary>
		public readonly ParameterType Type;
		/// <summary>
		/// 参数值.
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// 创建一个 jQuery UI 参数.
		/// </summary>
		/// <param name="name">参数名称.</param>
		/// <param name="type">参数类型.</param>
		/// <param name="value">参数值.</param>
		public Parameter ( string name, ParameterType type, string value )
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", "参数名称不能为空" );

			if ( null == value )
				value = string.Empty;

			this.Name = name;
			this.Type = type;
			this.Value = value;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/AjaxSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DataType "
	/// <summary>
	/// Ajax 获取的数据类型.
	/// </summary>
	public enum DataType
	{
		/// <summary>
		/// json 数据.
		/// </summary>
		json = 1,
		/// <summary>
		/// 脚本代码.
		/// </summary>
		script = 2,
		/// <summary>
		/// xml 数据.
		/// </summary>
		xml = 3,
		/// <summary>
		/// html 代码.
		/// </summary>
		html = 4,
	}
	#endregion

	#region " AjaxSetting "
	/// <summary>
	/// jQuery UI Ajax 设置.
	/// </summary>
	public sealed class AjaxSetting
	{
		/// <summary>
		/// Ajax 相关事件.
		/// </summary>
		public readonly List<Event> Events = new List<Event> ( );
		/// <summary>
		/// 和 Widget 相关的触发事件.
		/// </summary>
		public readonly EventType WidgetEventType;
		/// <summary>
		/// 请求的地址.
		/// </summary>
		public readonly string Url;
		/// <summary>
		/// 获取的数据类型.
		/// </summary>
		public readonly DataType DataType;
		/// <summary>
		/// 用作传递参数的表单.
		/// </summary>
		public readonly string Form;
		/// <summary>
		/// 用作传递的参数.
		/// </summary>
		public readonly List<Parameter> Parameters = new List<Parameter> ( );
		/// <summary>
		/// 是否为字符串使用单引号.
		/// </summary>
		public readonly bool IsSingleQuote;

		/// <summary>
		/// 创建 jQuery UI Ajax 设置.
		/// </summary>
		/// <param name="widgetEventType">和 Widget 相关的触发事件.</param>
		/// <param name="url">请求的地址, 比如: "''".</param>
		/// <param name="dataType">获取的数据类型.</param>
		/// <param name="form">用作传递参数的表单.</param>
		/// <param name="parameters">用作传递的参数, 如果指定了 form 参数, 则忽略 parameters.</param>
		/// <param name="events">Ajax 相关事件.</param>
		/// <param name="isSingleQuote">是否为字符串使用单引号.</param>
		public AjaxSetting ( EventType widgetEventType, string url, DataType dataType, string form, Parameter[] parameters, Event[] events, bool isSingleQuote )
		{

			if ( string.IsNullOrEmpty ( url ) )
				url = "/";

			if ( string.IsNullOrEmpty ( form ) )
				if ( null != parameters )
					foreach ( Parameter parameter in parameters )
						if ( null != parameter )
							this.Parameters.Add ( parameter );

			if ( null != events )
				foreach ( Event @event in events )
					if ( null != @event )
						this.Events.Add ( @event );

			this.Url = url;
			this.DataType = dataType;
			this.WidgetEventType = widgetEventType;
			this.Form = form;

			this.IsSingleQuote = isSingleQuote;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/WidgetSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIWidgetSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " WidgetType "
	/// <summary>
	/// Widget 类型.
	/// </summary>
	public enum WidgetType
	{
		/// <summary>
		/// 没有任何类型.
		/// </summary>
		none = 0,
		/// <summary>
		/// 折叠列表.
		/// </summary>
		accordion = 1,
		/// <summary>
		/// 自动填充.
		/// </summary>
		autocomplete = 2,
		/// <summary>
		/// 按钮.
		/// </summary>
		button = 3,
		/// <summary>
		/// 日期框.
		/// </summary>
		datepicker = 4,
		/// <summary>
		/// 对话框.
		/// </summary>
		dialog = 5,
		/// <summary>
		/// 进度条.
		/// </summary>
		progressbar = 6,
		/// <summary>
		/// 分割条.
		/// </summary>
		slider = 7,
		/// <summary>
		/// 分组标签.
		/// </summary>
		tabs = 8,
		/// <summary>
		/// 空的 Widget.
		/// </summary>
		empty = 9,
	}
	#endregion

	#region " WidgetSetting "
	/// <summary>
	/// jQuery UI Widget 设置.
	/// </summary>
	public sealed class WidgetSetting
	{
		/// <summary>
		/// Widget 相关事件.
		/// </summary>
		public readonly List<Event> Events = new List<Event> ( );
		/// <summary>
		/// Widget 相关设置.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// Widget 类型.
		/// </summary>
		public readonly WidgetType WidgetType;
		/// <summary>
		/// Ajax 相关设置.
		/// </summary>
		public readonly List<AjaxSetting> AjaxSettings = new List<AjaxSetting> ( );

		/// <summary>
		/// 创建 jQuery UI Widget 设置.
		/// </summary>
		/// <param name="widgetEventType">和 Widget 相关的触发事件.</param>
		/// <param name="options">Widget 相关设置.</param>
		/// <param name="events">Widget 相关事件.</param>
		/// <param name="ajaxSettings">Ajax 相关设置.</param>
		public WidgetSetting ( WidgetType widgetEventType, Option[] options, Event[] events, AjaxSetting[] ajaxSettings )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			if ( null != events )
				foreach ( Event @event in events )
					if ( null != @event )
						this.Events.Add ( @event );

			if ( null != ajaxSettings )
				foreach ( AjaxSetting ajaxSetting in ajaxSettings )
					if ( null != ajaxSetting )
						this.AjaxSettings.Add ( ajaxSetting );

			this.WidgetType = widgetEventType;
		}

	}
	#endregion

}
// ../.class/web/JQuery.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQuery
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// JQuery 用于编写构造 jQuery 脚本, 包含了 jQuery 中的方法等, 支持 1.6 版本. (尚未包含 Effects, Utilities 的部分方法)
	/// </summary>
	public class JQuery
		: ScriptHelper
	{

		/// <summary>
		/// 获取 jQuery 脚本的压缩版本.
		/// </summary>
		public static string CodeMin
		{
			get
			{
				#region " Code "
				return "(function(a,b){function cy(a){return f.isWindow(a)?a:a.nodeType===9?a.defaultView||a.parentWindow:!1}function cv(a){if(!cj[a]){var b=f(\"<\"+a+\">\").appendTo(\"body\"),d=b.css(\"display\");b.remove();if(d===\"none\"||d===\"\"){ck||(ck=c.createElement(\"iframe\"),ck.frameBorder=ck.width=ck.height=0),c.body.appendChild(ck);if(!cl||!ck.createElement)cl=(ck.contentWindow||ck.contentDocument).document,cl.write(\"<!doctype><html><body></body></html>\");b=cl.createElement(a),cl.body.appendChild(b),d=f.css(b,\"display\"),c.body.removeChild(ck)}cj[a]=d}return cj[a]}function cu(a,b){var c={};f.each(cp.concat.apply([],cp.slice(0,b)),function(){c[this]=a});return c}function ct(){cq=b}function cs(){setTimeout(ct,0);return cq=f.now()}function ci(){try{return new a.ActiveXObject(\"Microsoft.XMLHTTP\")}catch(b){}}function ch(){try{return new a.XMLHttpRequest}catch(b){}}function cb(a,c){a.dataFilter&&(c=a.dataFilter(c,a.dataType));var d=a.dataTypes,e={},g,h,i=d.length,j,k=d[0],l,m,n,o,p;for(g=1;g<i;g++){if(g===1)for(h in a.converters)typeof h==\"string\"&&(e[h.toLowerCase()]=a.converters[h]);l=k,k=d[g];if(k===\"*\")k=l;else if(l!==\"*\"&&l!==k){m=l+\" \"+k,n=e[m]||e[\"* \"+k];if(!n){p=b;for(o in e){j=o.split(\" \");if(j[0]===l||j[0]===\"*\"){p=e[j[1]+\" \"+k];if(p){o=e[o],o===!0?n=p:p===!0&&(n=o);break}}}}!n&&!p&&f.error(\"No conversion from \"+m.replace(\" \",\" to \")),n!==!0&&(c=n?n(c):p(o(c)))}}return c}function ca(a,c,d){var e=a.contents,f=a.dataTypes,g=a.responseFields,h,i,j,k;for(i in g)i in d&&(c[g[i]]=d[i]);while(f[0]===\"*\")f.shift(),h===b&&(h=a.mimeType||c.getResponseHeader(\"content-type\"));if(h)for(i in e)if(e[i]&&e[i].test(h)){f.unshift(i);break}if(f[0]in d)j=f[0];else{for(i in d){if(!f[0]||a.converters[i+\" \"+f[0]]){j=i;break}k||(k=i)}j=j||k}if(j){j!==f[0]&&f.unshift(j);return d[j]}}function b_(a,b,c,d){if(f.isArray(b))f.each(b,function(b,e){c||bF.test(a)?d(a,e):b_(a+\"[\"+(typeof e==\"object\"||f.isArray(e)?b:\"\")+\"]\",e,c,d)});else if(!c&&b!=null&&typeof b==\"object\")for(var e in b)b_(a+\"[\"+e+\"]\",b[e],c,d);else d(a,b)}function b$(a,c,d,e,f,g){f=f||c.dataTypes[0],g=g||{},g[f]=!0;var h=a[f],i=0,j=h?h.length:0,k=a===bU,l;for(;i<j&&(k||!l);i++)l=h[i](c,d,e),typeof l==\"string\"&&(!k||g[l]?l=b:(c.dataTypes.unshift(l),l=b$(a,c,d,e,l,g)));(k||!l)&&!g[\"*\"]&&(l=b$(a,c,d,e,\"*\",g));return l}function bZ(a){return function(b,c){typeof b!=\"string\"&&(c=b,b=\"*\");if(f.isFunction(c)){var d=b.toLowerCase().split(bQ),e=0,g=d.length,h,i,j;for(;e<g;e++)h=d[e],j=/^\\+/.test(h),j&&(h=h.substr(1)||\"*\"),i=a[h]=a[h]||[],i[j?\"unshift\":\"push\"](c)}}}function bD(a,b,c){var d=b===\"width\"?bx:by,e=b===\"width\"?a.offsetWidth:a.offsetHeight;if(c===\"border\")return e;f.each(d,function(){c||(e-=parseFloat(f.css(a,\"padding\"+this))||0),c===\"margin\"?e+=parseFloat(f.css(a,\"margin\"+this))||0:e-=parseFloat(f.css(a,\"border\"+this+\"Width\"))||0});return e}function bn(a,b){b.src?f.ajax({url:b.src,async:!1,dataType:\"script\"}):f.globalEval((b.text||b.textContent||b.innerHTML||\"\").replace(bf,\"/*$0*/\")),b.parentNode&&b.parentNode.removeChild(b)}function bm(a){f.nodeName(a,\"input\")?bl(a):a.getElementsByTagName&&f.grep(a.getElementsByTagName(\"input\"),bl)}function bl(a){if(a.type===\"checkbox\"||a.type===\"radio\")a.defaultChecked=a.checked}function bk(a){return\"getElementsByTagName\"in a?a.getElementsByTagName(\"*\"):\"querySelectorAll\"in a?a.querySelectorAll(\"*\"):[]}function bj(a,b){var c;if(b.nodeType===1){b.clearAttributes&&b.clearAttributes(),b.mergeAttributes&&b.mergeAttributes(a),c=b.nodeName.toLowerCase();if(c===\"object\")b.outerHTML=a.outerHTML;else if(c!==\"input\"||a.type!==\"checkbox\"&&a.type!==\"radio\"){if(c===\"option\")b.selected=a.defaultSelected;else if(c===\"input\"||c===\"textarea\")b.defaultValue=a.defaultValue}else a.checked&&(b.defaultChecked=b.checked=a.checked),b.value!==a.value&&(b.value=a.value);b.removeAttribute(f.expando)}}function bi(a,b){if(b.nodeType===1&&!!f.hasData(a)){var c=f.expando,d=f.data(a),e=f.data(b,d);if(d=d[c]){var g=d.events;e=e[c]=f.extend({},d);if(g){delete e.handle,e.events={};for(var h in g)for(var i=0,j=g[h].length;i<j;i++)f.event.add(b,h+(g[h][i].namespace?\".\":\"\")+g[h][i].namespace,g[h][i],g[h][i].data)}}}}function bh(a,b){return f.nodeName(a,\"table\")?a.getElementsByTagName(\"tbody\")[0]||a.appendChild(a.ownerDocument.createElement(\"tbody\")):a}function X(a,b,c){b=b||0;if(f.isFunction(b))return f.grep(a,function(a,d){var e=!!b.call(a,d,a);return e===c});if(b.nodeType)return f.grep(a,function(a,d){return a===b===c});if(typeof b==\"string\"){var d=f.grep(a,function(a){return a.nodeType===1});if(S.test(b))return f.filter(b,d,!c);b=f.filter(b,d)}return f.grep(a,function(a,d){return f.inArray(a,b)>=0===c})}function W(a){return!a||!a.parentNode||a.parentNode.nodeType===11}function O(a,b){return(a&&a!==\"*\"?a+\".\":\"\")+b.replace(A,\"`\").replace(B,\"&\")}function N(a){var b,c,d,e,g,h,i,j,k,l,m,n,o,p=[],q=[],r=f._data(this,\"events\");if(!(a.liveFired===this||!r||!r.live||a.target.disabled||a.button&&a.type===\"click\")){a.namespace&&(n=new RegExp(\"(^|\\\\.)\"+a.namespace.split(\".\").join(\"\\\\.(?:.*\\\\.)?\")+\"(\\\\.|$)\")),a.liveFired=this;var s=r.live.slice(0);for(i=0;i<s.length;i++)g=s[i],g.origType.replace(y,\"\")===a.type?q.push(g.selector):s.splice(i--,1);e=f(a.target).closest(q,a.currentTarget);for(j=0,k=e.length;j<k;j++){m=e[j];for(i=0;i<s.length;i++){g=s[i];if(m.selector===g.selector&&(!n||n.test(g.namespace))&&!m.elem.disabled){h=m.elem,d=null;if(g.preType===\"mouseenter\"||g.preType===\"mouseleave\")a.type=g.preType,d=f(a.relatedTarget).closest(g.selector)[0],d&&f.contains(h,d)&&(d=h);(!d||d!==h)&&p.push({elem:h,handleObj:g,level:m.level})}}}for(j=0,k=p.length;j<k;j++){e=p[j];if(c&&e.level>c)break;a.currentTarget=e.elem,a.data=e.handleObj.data,a.handleObj=e.handleObj,o=e.handleObj.origHandler.apply(e.elem,arguments);if(o===!1||a.isPropagationStopped()){c=e.level,o===!1&&(b=!1);if(a.isImmediatePropagationStopped())break}}return b}}function L(a,c,d){var e=f.extend({},d[0]);e.type=a,e.originalEvent={},e.liveFired=b,f.event.handle.call(c,e),e.isDefaultPrevented()&&d[0].preventDefault()}function F(){return!0}function E(){return!1}function m(a,c,d){var e=c+\"defer\",g=c+\"queue\",h=c+\"mark\",i=f.data(a,e,b,!0);i&&(d===\"queue\"||!f.data(a,g,b,!0))&&(d===\"mark\"||!f.data(a,h,b,!0))&&setTimeout(function(){!f.data(a,g,b,!0)&&!f.data(a,h,b,!0)&&(f.removeData(a,e,!0),i.resolve())},0)}function l(a){for(var b in a)if(b!==\"toJSON\")return!1;return!0}function k(a,c,d){if(d===b&&a.nodeType===1){var e=\"data-\"+c.replace(j,\"$1-$2\").toLowerCase();d=a.getAttribute(e);if(typeof d==\"string\"){try{d=d===\"true\"?!0:d===\"false\"?!1:d===\"null\"?null:f.isNaN(d)?i.test(d)?f.parseJSON(d):d:parseFloat(d)}catch(g){}f.data(a,c,d)}else d=b}return d}var c=a.document,d=a.navigator,e=a.location,f=function(){function H(){if(!e.isReady){try{c.documentElement.doScroll(\"left\")}catch(a){setTimeout(H,1);return}e.ready()}}var e=function(a,b){return new e.fn.init(a,b,h)},f=a.jQuery,g=a.$,h,i=/^(?:[^<]*(<[\\w\\W]+>)[^>]*$|#([\\w\\-]*)$)/,j=/\\S/,k=/^\\s+/,l=/\\s+$/,m=/\\d/,n=/^<(\\w+)\\s*\\/?>(?:<\\/\\1>)?$/,o=/^[\\],:{}\\s]*$/,p=/\\\\(?:[\"\\\\\\/bfnrt]|u[0-9a-fA-F]{4})/g,q=/\"[^\"\\\\\\n\\r]*\"|true|false|null|-?\\d+(?:\\.\\d*)?(?:[eE][+\\-]?\\d+)?/g,r=/(?:^|:|,)(?:\\s*\\[)+/g,s=/(webkit)[ \\/]([\\w.]+)/,t=/(opera)(?:.*version)?[ \\/]([\\w.]+)/,u=/(msie) ([\\w.]+)/,v=/(mozilla)(?:.*? rv:([\\w.]+))?/,w=d.userAgent,x,y,z,A=Object.prototype.toString,B=Object.prototype.hasOwnProperty,C=Array.prototype.push,D=Array.prototype.slice,E=String.prototype.trim,F=Array.prototype.indexOf,G={};e.fn=e.prototype={constructor:e,init:function(a,d,f){var g,h,j,k;if(!a)return this;if(a.nodeType){this.context=this[0]=a,this.length=1;return this}if(a===\"body\"&&!d&&c.body){this.context=c,this[0]=c.body,this.selector=a,this.length=1;return this}if(typeof a==\"string\"){a.charAt(0)!==\"<\"||a.charAt(a.length-1)!==\">\"||a.length<3?g=i.exec(a):g=[null,a,null];if(g&&(g[1]||!d)){if(g[1]){d=d instanceof e?d[0]:d,k=d?d.ownerDocument||d:c,j=n.exec(a),j?e.isPlainObject(d)?(a=[c.createElement(j[1])],e.fn.attr.call(a,d,!0)):a=[k.createElement(j[1])]:(j=e.buildFragment([g[1]],[k]),a=(j.cacheable?e.clone(j.fragment):j.fragment).childNodes);return e.merge(this,a)}h=c.getElementById(g[2]);if(h&&h.parentNode){if(h.id!==g[2])return f.find(a);this.length=1,this[0]=h}this.context=c,this.selector=a;return this}return!d||d.jquery?(d||f).find(a):this.constructor(d).find(a)}if(e.isFunction(a))return f.ready(a);a.selector!==b&&(this.selector=a.selector,this.context=a.context);return e.makeArray(a,this)},selector:\"\",jquery:\"1.6.1\",length:0,size:function(){return this.length},toArray:function(){return D.call(this,0)},get:function(a){return a==null?this.toArray():a<0?this[this.length+a]:this[a]},pushStack:function(a,b,c){var d=this.constructor();e.isArray(a)?C.apply(d,a):e.merge(d,a),d.prevObject=this,d.context=this.context,b===\"find\"?d.selector=this.selector+(this.selector?\" \":\"\")+c:b&&(d.selector=this.selector+\".\"+b+\"(\"+c+\")\");return d},each:function(a,b){return e.each(this,a,b)},ready:function(a){e.bindReady(),y.done(a);return this},eq:function(a){return a===-1?this.slice(a):this.slice(a,+a+1)},first:function(){return this.eq(0)},last:function(){return this.eq(-1)},slice:function(){return this.pushStack(D.apply(this,arguments),\"slice\",D.call(arguments).join(\",\"))},map:function(a){return this.pushStack(e.map(this,function(b,c){return a.call(b,c,b)}))},end:function(){return this.prevObject||this.constructor(null)},push:C,sort:[].sort,splice:[].splice},e.fn.init.prototype=e.fn,e.extend=e.fn.extend=function(){var a,c,d,f,g,h,i=arguments[0]||{},j=1,k=arguments.length,l=!1;typeof i==\"boolean\"&&(l=i,i=arguments[1]||{},j=2),typeof i!=\"object\"&&!e.isFunction(i)&&(i={}),k===j&&(i=this,--j);for(;j<k;j++)if((a=arguments[j])!=null)for(c in a){d=i[c],f=a[c];if(i===f)continue;l&&f&&(e.isPlainObject(f)||(g=e.isArray(f)))?(g?(g=!1,h=d&&e.isArray(d)?d:[]):h=d&&e.isPlainObject(d)?d:{},i[c]=e.extend(l,h,f)):f!==b&&(i[c]=f)}return i},e.extend({noConflict:function(b){a.$===e&&(a.$=g),b&&a.jQuery===e&&(a.jQuery=f);return e},isReady:!1,readyWait:1,holdReady:function(a){a?e.readyWait++:e.ready(!0)},ready:function(a){if(a===!0&&!--e.readyWait||a!==!0&&!e.isReady){if(!c.body)return setTimeout(e.ready,1);e.isReady=!0;if(a!==!0&&--e.readyWait>0)return;y.resolveWith(c,[e]),e.fn.trigger&&e(c).trigger(\"ready\").unbind(\"ready\")}},bindReady:function(){if(!y){y=e._Deferred();if(c.readyState===\"complete\")return setTimeout(e.ready,1);if(c.addEventListener)c.addEventListener(\"DOMContentLoaded\",z,!1),a.addEventListener(\"load\",e.ready,!1);else if(c.attachEvent){c.attachEvent(\"onreadystatechange\",z),a.attachEvent(\"onload\",e.ready);var b=!1;try{b=a.frameElement==null}catch(d){}c.documentElement.doScroll&&b&&H()}}},isFunction:function(a){return e.type(a)===\"function\"},isArray:Array.isArray||function(a){return e.type(a)===\"array\"},isWindow:function(a){return a&&typeof a==\"object\"&&\"setInterval\"in a},isNaN:function(a){return a==null||!m.test(a)||isNaN(a)},type:function(a){return a==null?String(a):G[A.call(a)]||\"object\"},isPlainObject:function(a){if(!a||e.type(a)!==\"object\"||a.nodeType||e.isWindow(a))return!1;if(a.constructor&&!B.call(a,\"constructor\")&&!B.call(a.constructor.prototype,\"isPrototypeOf\"))return!1;var c;for(c in a);return c===b||B.call(a,c)},isEmptyObject:function(a){for(var b in a)return!1;return!0},error:function(a){throw a},parseJSON:function(b){if(typeof b!=\"string\"||!b)return null;b=e.trim(b);if(a.JSON&&a.JSON.parse)return a.JSON.parse(b);if(o.test(b.replace(p,\"@\").replace(q,\"]\").replace(r,\"\")))return(new Function(\"return \"+b))();e.error(\"Invalid JSON: \"+b)},parseXML:function(b,c,d){a.DOMParser?(d=new DOMParser,c=d.parseFromString(b,\"text/xml\")):(c=new ActiveXObject(\"Microsoft.XMLDOM\"),c.async=\"false\",c.loadXML(b)),d=c.documentElement,(!d||!d.nodeName||d.nodeName===\"parsererror\")&&e.error(\"Invalid XML: \"+b);return c},noop:function(){},globalEval:function(b){b&&j.test(b)&&(a.execScript||function(b){a.eval.call(a,b)})(b)},nodeName:function(a,b){return a.nodeName&&a.nodeName.toUpperCase()===b.toUpperCase()},each:function(a,c,d){var f,g=0,h=a.length,i=h===b||e.isFunction(a);if(d){if(i){for(f in a)if(c.apply(a[f],d)===!1)break}else for(;g<h;)if(c.apply(a[g++],d)===!1)break}else if(i){for(f in a)if(c.call(a[f],f,a[f])===!1)break}else for(;g<h;)if(c.call(a[g],g,a[g++])===!1)break;return a},trim:E?function(a){return a==null?\"\":E.call(a)}:function(a){return a==null?\"\":(a+\"\").replace(k,\"\").replace(l,\"\")},makeArray:function(a,b){var c=b||[];if(a!=null){var d=e.type(a);a.length==null||d===\"string\"||d===\"function\"||d===\"regexp\"||e.isWindow(a)?C.call(c,a):e.merge(c,a)}return c},inArray:function(a,b){if(F)return F.call(b,a);for(var c=0,d=b.length;c<d;c++)if(b[c]===a)return c;return-1},merge:function(a,c){var d=a.length,e=0;if(typeof c.length==\"number\")for(var f=c.length;e<f;e++)a[d++]=c[e];else while(c[e]!==b)a[d++]=c[e++];a.length=d;return a},grep:function(a,b,c){var d=[],e;c=!!c;for(var f=0,g=a.length;f<g;f++)e=!!b(a[f],f),c!==e&&d.push(a[f]);return d},map:function(a,c,d){var f,g,h=[],i=0,j=a.length,k=a instanceof e||j!==b&&typeof j==\"number\"&&(j>0&&a[0]&&a[j-1]||j===0||e.isArray(a));if(k)for(;i<j;i++)f=c(a[i],i,d),f!=null&&(h[h.length]=f);else for(g in a)f=c(a[g],g,d),f!=null&&(h[h.length]=f);return h.concat.apply([],h)},guid:1,proxy:function(a,c){if(typeof c==\"string\"){var d=a[c];c=a,a=d}if(!e.isFunction(a))return b;var f=D.call(arguments,2),g=function(){return a.apply(c,f.concat(D.call(arguments)))};g.guid=a.guid=a.guid||g.guid||e.guid++;return g},access:function(a,c,d,f,g,h){var i=a.length;if(typeof c==\"object\"){for(var j in c)e.access(a,j,c[j],f,g,d);return a}if(d!==b){f=!h&&f&&e.isFunction(d);for(var k=0;k<i;k++)g(a[k],c,f?d.call(a[k],k,g(a[k],c)):d,h);return a}return i?g(a[0],c):b},now:function(){return(new Date).getTime()},uaMatch:function(a){a=a.toLowerCase();var b=s.exec(a)||t.exec(a)||u.exec(a)||a.indexOf(\"compatible\")<0&&v.exec(a)||[];return{browser:b[1]||\"\",version:b[2]||\"0\"}},sub:function(){function a(b,c){return new a.fn.init(b,c)}e.extend(!0,a,this),a.superclass=this,a.fn=a.prototype=this(),a.fn.constructor=a,a.sub=this.sub,a.fn.init=function(d,f){f&&f instanceof e&&!(f instanceof a)&&(f=a(f));return e.fn.init.call(this,d,f,b)},a.fn.init.prototype=a.fn;var b=a(c);return a},browser:{}}),e.each(\"Boolean Number String Function Array Date RegExp Object\".split(\" \"),function(a,b){G[\"[object \"+b+\"]\"]=b.toLowerCase()}),x=e.uaMatch(w),x.browser&&(e.browser[x.browser]=!0,e.browser.version=x.version),e.browser.webkit&&(e.browser.safari=!0),j.test(\" \")&&(k=/^[\\s\\xA0]+/,l=/[\\s\\xA0]+$/),h=e(c),c.addEventListener?z=function(){c.removeEventListener(\"DOMContentLoaded\",z,!1),e.ready()}:c.attachEvent&&(z=function(){c.readyState===\"complete\"&&(c.detachEvent(\"onreadystatechange\",z),e.ready())});return e}(),g=\"done fail isResolved isRejected promise then always pipe\".split(\" \"),h=[].slice;f.extend({_Deferred:function(){var a=[],b,c,d,e={done:function(){if(!d){var c=arguments,g,h,i,j,k;b&&(k=b,b=0);for(g=0,h=c.length;g<h;g++)i=c[g],j=f.type(i),j===\"array\"?e.done.apply(e,i):j===\"function\"&&a.push(i);k&&e.resolveWith(k[0],k[1])}return this},resolveWith:function(e,f){if(!d&&!b&&!c){f=f||[],c=1;try{while(a[0])a.shift().apply(e,f)}finally{b=[e,f],c=0}}return this},resolve:function(){e.resolveWith(this,arguments);return this},isResolved:function(){return!!c||!!b},cancel:function(){d=1,a=[];return this}};return e},Deferred:function(a){var b=f._Deferred(),c=f._Deferred(),d;f.extend(b,{then:function(a,c){b.done(a).fail(c);return this},always:function(){return b.done.apply(b,arguments).fail.apply(this,arguments)},fail:c.done,rejectWith:c.resolveWith,reject:c.resolve,isRejected:c.isResolved,pipe:function(a,c){return f.Deferred(function(d){f.each({done:[a,\"resolve\"],fail:[c,\"reject\"]},function(a,c){var e=c[0],g=c[1],h;f.isFunction(e)?b[a](function(){h=e.apply(this,arguments),h&&f.isFunction(h.promise)?h.promise().then(d.resolve,d.reject):d[g](h)}):b[a](d[g])})}).promise()},promise:function(a){if(a==null){if(d)return d;d=a={}}var c=g.length;while(c--)a[g[c]]=b[g[c]];return a}}),b.done(c.cancel).fail(b.cancel),delete b.cancel,a&&a.call(b,b);return b},when:function(a){function i(a){return function(c){b[a]=arguments.length>1?h.call(arguments,0):c,--e||g.resolveWith(g,h.call(b,0))}}var b=arguments,c=0,d=b.length,e=d,g=d<=1&&a&&f.isFunction(a.promise)?a:f.Deferred();if(d>1){for(;c<d;c++)b[c]&&f.isFunction(b[c].promise)?b[c].promise().then(i(c),g.reject):--e;e||g.resolveWith(g,b)}else g!==a&&g.resolveWith(g,d?[a]:[]);return g.promise()}}),f.support=function(){var a=c.createElement(\"div\"),b=c.documentElement,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r;a.setAttribute(\"className\",\"t\"),a.innerHTML=\"   <link/><table></table><a href='/a' style='top:1px;float:left;opacity:.55;'>a</a><input type='checkbox'/>\",d=a.getElementsByTagName(\"*\"),e=a.getElementsByTagName(\"a\")[0];if(!d||!d.length||!e)return{};f=c.createElement(\"select\"),g=f.appendChild(c.createElement(\"option\")),h=a.getElementsByTagName(\"input\")[0],j={leadingWhitespace:a.firstChild.nodeType===3,tbody:!a.getElementsByTagName(\"tbody\").length,htmlSerialize:!!a.getElementsByTagName(\"link\").length,style:/top/.test(e.getAttribute(\"style\")),hrefNormalized:e.getAttribute(\"href\")===\"/a\",opacity:/^0.55$/.test(e.style.opacity),cssFloat:!!e.style.cssFloat,checkOn:h.value===\"on\",optSelected:g.selected,getSetAttribute:a.className!==\"t\",submitBubbles:!0,changeBubbles:!0,focusinBubbles:!1,deleteExpando:!0,noCloneEvent:!0,inlineBlockNeedsLayout:!1,shrinkWrapBlocks:!1,reliableMarginRight:!0},h.checked=!0,j.noCloneChecked=h.cloneNode(!0).checked,f.disabled=!0,j.optDisabled=!g.disabled;try{delete a.test}catch(s){j.deleteExpando=!1}!a.addEventListener&&a.attachEvent&&a.fireEvent&&(a.attachEvent(\"onclick\",function b(){j.noCloneEvent=!1,a.detachEvent(\"onclick\",b)}),a.cloneNode(!0).fireEvent(\"onclick\")),h=c.createElement(\"input\"),h.value=\"t\",h.setAttribute(\"type\",\"radio\"),j.radioValue=h.value===\"t\",h.setAttribute(\"checked\",\"checked\"),a.appendChild(h),k=c.createDocumentFragment(),k.appendChild(a.firstChild),j.checkClone=k.cloneNode(!0).cloneNode(!0).lastChild.checked,a.innerHTML=\"\",a.style.width=a.style.paddingLeft=\"1px\",l=c.createElement(\"body\"),m={visibility:\"hidden\",width:0,height:0,border:0,margin:0,background:\"none\"};for(q in m)l.style[q]=m[q];l.appendChild(a),b.insertBefore(l,b.firstChild),j.appendChecked=h.checked,j.boxModel=a.offsetWidth===2,\"zoom\"in a.style&&(a.style.display=\"inline\",a.style.zoom=1,j.inlineBlockNeedsLayout=a.offsetWidth===2,a.style.display=\"\",a.innerHTML=\"<div style='width:4px;'></div>\",j.shrinkWrapBlocks=a.offsetWidth!==2),a.innerHTML=\"<table><tr><td style='padding:0;border:0;display:none'></td><td>t</td></tr></table>\",n=a.getElementsByTagName(\"td\"),r=n[0].offsetHeight===0,n[0].style.display=\"\",n[1].style.display=\"none\",j.reliableHiddenOffsets=r&&n[0].offsetHeight===0,a.innerHTML=\"\",c.defaultView&&c.defaultView.getComputedStyle&&(i=c.createElement(\"div\"),i.style.width=\"0\",i.style.marginRight=\"0\",a.appendChild(i),j.reliableMarginRight=(parseInt((c.defaultView.getComputedStyle(i,null)||{marginRight:0}).marginRight,10)||0)===0),l.innerHTML=\"\",b.removeChild(l);if(a.attachEvent)for(q in{submit:1,change:1,focusin:1})p=\"on\"+q,r=p in a,r||(a.setAttribute(p,\"return;\"),r=typeof a[p]==\"function\"),j[q+\"Bubbles\"]=r;return j}(),f.boxModel=f.support.boxModel;var i=/^(?:\\{.*\\}|\\[.*\\])$/,j=/([a-z])([A-Z])/g;f.extend({cache:{},uuid:0,expando:\"jQuery\"+(f.fn.jquery+Math.random()).replace(/\\D/g,\"\"),noData:{embed:!0,object:\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\",applet:!0},hasData:function(a){a=a.nodeType?f.cache[a[f.expando]]:a[f.expando];return!!a&&!l(a)},data:function(a,c,d,e){if(!!f.acceptData(a)){var g=f.expando,h=typeof c==\"string\",i,j=a.nodeType,k=j?f.cache:a,l=j?a[f.expando]:a[f.expando]&&f.expando;if((!l||e&&l&&!k[l][g])&&h&&d===b)return;l||(j?a[f.expando]=l=++f.uuid:l=f.expando),k[l]||(k[l]={},j||(k[l].toJSON=f.noop));if(typeof c==\"object\"||typeof c==\"function\")e?k[l][g]=f.extend(k[l][g],c):k[l]=f.extend(k[l],c);i=k[l],e&&(i[g]||(i[g]={}),i=i[g]),d!==b&&(i[f.camelCase(c)]=d);if(c===\"events\"&&!i[c])return i[g]&&i[g].events;return h?i[f.camelCase(c)]:i}},removeData:function(b,c,d){if(!!f.acceptData(b)){var e=f.expando,g=b.nodeType,h=g?f.cache:b,i=g?b[f.expando]:f.expando;if(!h[i])return;if(c){var j=d?h[i][e]:h[i];if(j){delete j[c];if(!l(j))return}}if(d){delete h[i][e];if(!l(h[i]))return}var k=h[i][e];f.support.deleteExpando||h!=a?delete h[i]:h[i]=null,k?(h[i]={},g||(h[i].toJSON=f.noop),h[i][e]=k):g&&(f.support.deleteExpando?delete b[f.expando]:b.removeAttribute?b.removeAttribute(f.expando):b[f.expando]=null)}},_data:function(a,b,c){return f.data(a,b,c,!0)},acceptData:function(a){if(a.nodeName){var b=f.noData[a.nodeName.toLowerCase()];if(b)return b!==!0&&a.getAttribute(\"classid\")===b}return!0}}),f.fn.extend({data:function(a,c){var d=null;if(typeof a==\"undefined\"){if(this.length){d=f.data(this[0]);if(this[0].nodeType===1){var e=this[0].attributes,g;for(var h=0,i=e.length;h<i;h++)g=e[h].name,g.indexOf(\"data-\")===0&&(g=f.camelCase(g.substring(5)),k(this[0],g,d[g]))}}return d}if(typeof a==\"object\")return this.each(function(){f.data(this,a)});var j=a.split(\".\");j[1]=j[1]?\".\"+j[1]:\"\";if(c===b){d=this.triggerHandler(\"getData\"+j[1]+\"!\",[j[0]]),d===b&&this.length&&(d=f.data(this[0],a),d=k(this[0],a,d));return d===b&&j[1]?this.data(j[0]):d}return this.each(function(){var b=f(this),d=[j[0],c];b.triggerHandler(\"setData\"+j[1]+\"!\",d),f.data(this,a,c),b.triggerHandler(\"changeData\"+j[1]+\"!\",d)})},removeData:function(a){return this.each(function(){f.removeData(this,a)})}}),f.extend({_mark:function(a,c){a&&(c=(c||\"fx\")+\"mark\",f.data(a,c,(f.data(a,c,b,!0)||0)+1,!0))},_unmark:function(a,c,d){a!==!0&&(d=c,c=a,a=!1);if(c){d=d||\"fx\";var e=d+\"mark\",g=a?0:(f.data(c,e,b,!0)||1)-1;g?f.data(c,e,g,!0):(f.removeData(c,e,!0),m(c,d,\"mark\"))}},queue:function(a,c,d){if(a){c=(c||\"fx\")+\"queue\";var e=f.data(a,c,b,!0);d&&(!e||f.isArray(d)?e=f.data(a,c,f.makeArray(d),!0):e.push(d));return e||[]}},dequeue:function(a,b){b=b||\"fx\";var c=f.queue(a,b),d=c.shift(),e;d===\"inprogress\"&&(d=c.shift()),d&&(b===\"fx\"&&c.unshift(\"inprogress\"),d.call(a,function(){f.dequeue(a,b)})),c.length||(f.removeData(a,b+\"queue\",!0),m(a,b,\"queue\"))}}),f.fn.extend({queue:function(a,c){typeof a!=\"string\"&&(c=a,a=\"fx\");if(c===b)return f.queue(this[0],a);return this.each(function(){var b=f.queue(this,a,c);a===\"fx\"&&b[0]!==\"inprogress\"&&f.dequeue(this,a)})},dequeue:function(a){return this.each(function(){f.dequeue(this,a)})},delay:function(a,b){a=f.fx?f.fx.speeds[a]||a:a,b=b||\"fx\";return this.queue(b,function(){var c=this;setTimeout(function(){f.dequeue(c,b)},a)})},clearQueue:function(a){return this.queue(a||\"fx\",[])},promise:function(a,c){function m(){--h||d.resolveWith(e,[e])}typeof a!=\"string\"&&(c=a,a=b),a=a||\"fx\";var d=f.Deferred(),e=this,g=e.length,h=1,i=a+\"defer\",j=a+\"queue\",k=a+\"mark\",l;while(g--)if(l=f.data(e[g],i,b,!0)||(f.data(e[g],j,b,!0)||f.data(e[g],k,b,!0))&&f.data(e[g],i,f._Deferred(),!0))h++,l.done(m);m();return d.promise()}});var n=/[\\n\\t\\r]/g,o=/\\s+/,p=/\\r/g,q=/^(?:button|input)$/i,r=/^(?:button|input|object|select|textarea)$/i,s=/^a(?:rea)?$/i,t=/^(?:autofocus|autoplay|async|checked|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped|selected)$/i,u=/\\:/,v,w;f.fn.extend({attr:function(a,b){return f.access(this,a,b,!0,f.attr)},removeAttr:function(a){return this.each(function(){f.removeAttr(this,a)})},prop:function(a,b){return f.access(this,a,b,!0,f.prop)},removeProp:function(a){a=f.propFix[a]||a;return this.each(function(){try{this[a]=b,delete this[a]}catch(c){}})},addClass:function(a){if(f.isFunction(a))return this.each(function(b){var c=f(this);c.addClass(a.call(this,b,c.attr(\"class\")||\"\"))});if(a&&typeof a==\"string\"){var b=(a||\"\").split(o);for(var c=0,d=this.length;c<d;c++){var e=this[c];if(e.nodeType===1)if(!e.className)e.className=a;else{var g=\" \"+e.className+\" \",h=e.className;for(var i=0,j=b.length;i<j;i++)g.indexOf(\" \"+b[i]+\" \")<0&&(h+=\" \"+b[i]);e.className=f.trim(h)}}}return this},removeClass:function(a){if(f.isFunction(a))return this.each(function(b){var c=f(this);c.removeClass(a.call(this,b,c.attr(\"class\")))});if(a&&typeof a==\"string\"||a===b){var c=(a||\"\").split(o);for(var d=0,e=this.length;d<e;d++){var g=this[d];if(g.nodeType===1&&g.className)if(a){var h=(\" \"+g.className+\" \").replace(n,\" \");for(var i=0,j=c.length;i<j;i++)h=h.replace(\" \"+c[i]+\" \",\" \");g.className=f.trim(h)}else g.className=\"\"}}return this},toggleClass:function(a,b){var c=typeof a,d=typeof b==\"boolean\";if(f.isFunction(a))return this.each(function(c){var d=f(this);d.toggleClass(a.call(this,c,d.attr(\"class\"),b),b)});return this.each(function(){if(c===\"string\"){var e,g=0,h=f(this),i=b,j=a.split(o);while(e=j[g++])i=d?i:!h.hasClass(e),h[i?\"addClass\":\"removeClass\"](e)}else if(c===\"undefined\"||c===\"boolean\")this.className&&f._data(this,\"__className__\",this.className),this.className=this.className||a===!1?\"\":f._data(this,\"__className__\")||\"\"})},hasClass:function(a){var b=\" \"+a+\" \";for(var c=0,d=this.length;c<d;c++)if((\" \"+this[c].className+\" \").replace(n,\" \").indexOf(b)>-1)return!0;return!1},val:function(a){var c,d,e=this[0];if(!arguments.length){if(e){c=f.valHooks[e.nodeName.toLowerCase()]||f.valHooks[e.type];if(c&&\"get\"in c&&(d=c.get(e,\"value\"))!==b)return d;return(e.value||\"\").replace(p,\"\")}return b}var g=f.isFunction(a);return this.each(function(d){var e=f(this),h;if(this.nodeType===1){g?h=a.call(this,d,e.val()):h=a,h==null?h=\"\":typeof h==\"number\"?h+=\"\":f.isArray(h)&&(h=f.map(h,function(a){return a==null?\"\":a+\"\"})),c=f.valHooks[this.nodeName.toLowerCase()]||f.valHooks[this.type];if(!c||!(\"set\"in c)||c.set(this,h,\"value\")===b)this.value=h}})}}),f.extend({valHooks:{option:{get:function(a){var b=a.attributes.value;return!b||b.specified?a.value:a.text}},select:{get:function(a){var b,c=a.selectedIndex,d=[],e=a.options,g=a.type===\"select-one\";if(c<0)return null;for(var h=g?c:0,i=g?c+1:e.length;h<i;h++){var j=e[h];if(j.selected&&(f.support.optDisabled?!j.disabled:j.getAttribute(\"disabled\")===null)&&(!j.parentNode.disabled||!f.nodeName(j.parentNode,\"optgroup\"))){b=f(j).val();if(g)return b;d.push(b)}}if(g&&!d.length&&e.length)return f(e[c]).val();return d},set:function(a,b){var c=f.makeArray(b);f(a).find(\"option\").each(function(){this.selected=f.inArray(f(this).val(),c)>=0}),c.length||(a.selectedIndex=-1);return c}}},attrFn:{val:!0,css:!0,html:!0,text:!0,data:!0,width:!0,height:!0,offset:!0},attrFix:{tabindex:\"tabIndex\"},attr:function(a,c,d,e){var g=a.nodeType;if(!a||g===3||g===8||g===2)return b;if(e&&c in f.attrFn)return f(a)[c](d);if(!(\"getAttribute\"in a))return f.prop(a,c,d);var h,i,j=g!==1||!f.isXMLDoc(a);c=j&&f.attrFix[c]||c,i=f.attrHooks[c],i||(!t.test(c)||typeof d!=\"boolean\"&&d!==b&&d.toLowerCase()!==c.toLowerCase()?v&&(f.nodeName(a,\"form\")||u.test(c))&&(i=v):i=w);if(d!==b){if(d===null){f.removeAttr(a,c);return b}if(i&&\"set\"in i&&j&&(h=i.set(a,d,c))!==b)return h;a.setAttribute(c,\"\"+d);return d}if(i&&\"get\"in i&&j)return i.get(a,c);h=a.getAttribute(c);return h===null?b:h},removeAttr:function(a,b){var c;a.nodeType===1&&(b=f.attrFix[b]||b,f.support.getSetAttribute?a.removeAttribute(b):(f.attr(a,b,\"\"),a.removeAttributeNode(a.getAttributeNode(b))),t.test(b)&&(c=f.propFix[b]||b)in a&&(a[c]=!1))},attrHooks:{type:{set:function(a,b){if(q.test(a.nodeName)&&a.parentNode)f.error(\"type property can't be changed\");else if(!f.support.radioValue&&b===\"radio\"&&f.nodeName(a,\"input\")){var c=a.value;a.setAttribute(\"type\",b),c&&(a.value=c);return b}}},tabIndex:{get:function(a){var c=a.getAttributeNode(\"tabIndex\");return c&&c.specified?parseInt(c.value,10):r.test(a.nodeName)||s.test(a.nodeName)&&a.href?0:b}}},propFix:{tabindex:\"tabIndex\",readonly:\"readOnly\",\"for\":\"htmlFor\",\"class\":\"className\",maxlength:\"maxLength\",cellspacing:\"cellSpacing\",cellpadding:\"cellPadding\",rowspan:\"rowSpan\",colspan:\"colSpan\",usemap:\"useMap\",frameborder:\"frameBorder\",contenteditable:\"contentEditable\"},prop:function(a,c,d){var e=a.nodeType;if(!a||e===3||e===8||e===2)return b;var g,h,i=e!==1||!f.isXMLDoc(a);c=i&&f.propFix[c]||c,h=f.propHooks[c];return d!==b?h&&\"set\"in h&&(g=h.set(a,d,c))!==b?g:a[c]=d:h&&\"get\"in h&&(g=h.get(a,c))!==b?g:a[c]},propHooks:{}}),w={get:function(a,c){return a[f.propFix[c]||c]?c.toLowerCase():b},set:function(a,b,c){var d;b===!1?f.removeAttr(a,c):(d=f.propFix[c]||c,d in a&&(a[d]=b),a.setAttribute(c,c.toLowerCase()));return c}},f.attrHooks.value={get:function(a,b){if(v&&f.nodeName(a,\"button\"))return v.get(a,b);return a.value},set:function(a,b,c){if(v&&f.nodeName(a,\"button\"))return v.set(a,b,c);a.value=b}},f.support.getSetAttribute||(f.attrFix=f.propFix,v=f.attrHooks.name=f.valHooks.button={get:function(a,c){var d;d=a.getAttributeNode(c);return d&&d.nodeValue!==\"\"?d.nodeValue:b},set:function(a,b,c){var d=a.getAttributeNode(c);if(d){d.nodeValue=b;return b}}},f.each([\"width\",\"height\"],function(a,b){f.attrHooks[b]=f.extend(f.attrHooks[b],{set:function(a,c){if(c===\"\"){a.setAttribute(b,\"auto\");return c}}})})),f.support.hrefNormalized||f.each([\"href\",\"src\",\"width\",\"height\"],function(a,c){f.attrHooks[c]=f.extend(f.attrHooks[c],{get:function(a){var d=a.getAttribute(c,2);return d===null?b:d}})}),f.support.style||(f.attrHooks.style={get:function(a){return a.style.cssText.toLowerCase()||b},set:function(a,b){return a.style.cssText=\"\"+b}}),f.support.optSelected||(f.propHooks.selected=f.extend(f.propHooks.selected,{get:function(a){var b=a.parentNode;b&&(b.selectedIndex,b.parentNode&&b.parentNode.selectedIndex)}})),f.support.checkOn||f.each([\"radio\",\"checkbox\"],function(){f.valHooks[this]={get:function(a){return a.getAttribute(\"value\")===null?\"on\":a.value}}}),f.each([\"radio\",\"checkbox\"],function(){f.valHooks[this]=f.extend(f.valHooks[this],{set:function(a,b){if(f.isArray(b))return a.checked=f.inArray(f(a).val(),b)>=0}})});var x=Object.prototype.hasOwnProperty,y=/\\.(.*)$/,z=/^(?:textarea|input|select)$/i,A=/\\./g,B=/ /g,C=/[^\\w\\s.|`]/g,D=function(a){return a.replace(C,\"\\\\$&\")};f.event={add:function(a,c,d,e){if(a.nodeType!==3&&a.nodeType!==8){if(d===!1)d=E;else if(!d)return;var g,h;d.handler&&(g=d,d=g.handler),d.guid||(d.guid=f.guid++);var i=f._data(a);if(!i)return;var j=i.events,k=i.handle;j||(i.events=j={}),k||(i.handle=k=function(a){return typeof f!=\"undefined\"&&(!a||f.event.triggered!==a.type)?f.event.handle.apply(k.elem,arguments):b}),k.elem=a,c=c.split(\" \");var l,m=0,n;while(l=c[m++]){h=g?f.extend({},g):{handler:d,data:e},l.indexOf(\".\")>-1?(n=l.split(\".\"),l=n.shift(),h.namespace=n.slice(0).sort().join(\".\")):(n=[],h.namespace=\"\"),h.type=l,h.guid||(h.guid=d.guid);var o=j[l],p=f.event.special[l]||{};if(!o){o=j[l]=[];if(!p.setup||p.setup.call(a,e,n,k)===!1)a.addEventListener?a.addEventListener(l,k,!1):a.attachEvent&&a.attachEvent(\"on\"+l,k)}p.add&&(p.add.call(a,h),h.handler.guid||(h.handler.guid=d.guid)),o.push(h),f.event.global[l]=!0}a=null}},global:{},remove:function(a,c,d,e){if(a.nodeType!==3&&a.nodeType!==8){d===!1&&(d=E);var g,h,i,j,k=0,l,m,n,o,p,q,r,s=f.hasData(a)&&f._data(a),t=s&&s.events;if(!s||!t)return;c&&c.type&&(d=c.handler,c=c.type);if(!c||typeof c==\"string\"&&c.charAt(0)===\".\"){c=c||\"\";for(h in t)f.event.remove(a,h+c);return}c=c.split(\" \");while(h=c[k++]){r=h,q=null,l=h.indexOf(\".\")<0,m=[],l||(m=h.split(\".\"),h=m.shift(),n=new RegExp(\"(^|\\\\.)\"+f.map(m.slice(0).sort(),D).join(\"\\\\.(?:.*\\\\.)?\")+\"(\\\\.|$)\")),p=t[h];if(!p)continue;if(!d){for(j=0;j<p.length;j++){q=p[j];if(l||n.test(q.namespace))f.event.remove(a,r,q.handler,j),p.splice(j--,1)}continue}o=f.event.special[h]||{};for(j=e||0;j<p.length;j++){q=p[j];if(d.guid===q.guid){if(l||n.test(q.namespace))e==null&&p.splice(j--,1),o.remove&&o.remove.call(a,q);if(e!=null)break}}if(p.length===0||e!=null&&p.length===1)(!o.teardown||o.teardown.call(a,m)===!1)&&f.removeEvent(a,h,s.handle),g=null,delete t[h]}if(f.isEmptyObject(t)){var u=s.handle;u&&(u.elem=null),delete s.events,delete s.handle,f.isEmptyObject(s)&&f.removeData(a,b,!0)}}},customEvent:{getData:!0,setData:!0,changeData:!0},trigger:function(c,d,e,g){var h=c.type||c,i=[],j;h.indexOf(\"!\")>=0&&(h=h.slice(0,-1),j=!0),h.indexOf(\".\")>=0&&(i=h.split(\".\"),h=i.shift(),i.sort());if(!!e&&!f.event.customEvent[h]||!!f.event.global[h]){c=typeof c==\"object\"?c[f.expando]?c:new f.Event(h,c):new f.Event(h),c.type=h,c.exclusive=j,c.namespace=i.join(\".\"),c.namespace_re=new RegExp(\"(^|\\\\.)\"+i.join(\"\\\\.(?:.*\\\\.)?\")+\"(\\\\.|$)\");if(g||!e)c.preventDefault(),c.stopPropagation();if(!e){f.each(f.cache,function(){var a=f.expando,b=this[a];b&&b.events&&b.events[h]&&f.event.trigger(c,d,b.handle.elem" +
					")});return}if(e.nodeType===3||e.nodeType===8)return;c.result=b,c.target=e,d=d?f.makeArray(d):[],d.unshift(c);var k=e,l=h.indexOf(\":\")<0?\"on\"+h:\"\";do{var m=f._data(k,\"handle\");c.currentTarget=k,m&&m.apply(k,d),l&&f.acceptData(k)&&k[l]&&k[l].apply(k,d)===!1&&(c.result=!1,c.preventDefault()),k=k.parentNode||k.ownerDocument||k===c.target.ownerDocument&&a}while(k&&!c.isPropagationStopped());if(!c.isDefaultPrevented()){var n,o=f.event.special[h]||{};if((!o._default||o._default.call(e.ownerDocument,c)===!1)&&(h!==\"click\"||!f.nodeName(e,\"a\"))&&f.acceptData(e)){try{l&&e[h]&&(n=e[l],n&&(e[l]=null),f.event.triggered=h,e[h]())}catch(p){}n&&(e[l]=n),f.event.triggered=b}}return c.result}},handle:function(c){c=f.event.fix(c||a.event);var d=((f._data(this,\"events\")||{})[c.type]||[]).slice(0),e=!c.exclusive&&!c.namespace,g=Array.prototype.slice.call(arguments,0);g[0]=c,c.currentTarget=this;for(var h=0,i=d.length;h<i;h++){var j=d[h];if(e||c.namespace_re.test(j.namespace)){c.handler=j.handler,c.data=j.data,c.handleObj=j;var k=j.handler.apply(this,g);k!==b&&(c.result=k,k===!1&&(c.preventDefault(),c.stopPropagation()));if(c.isImmediatePropagationStopped())break}}return c.result},props:\"altKey attrChange attrName bubbles button cancelable charCode clientX clientY ctrlKey currentTarget data detail eventPhase fromElement handler keyCode layerX layerY metaKey newValue offsetX offsetY pageX pageY prevValue relatedNode relatedTarget screenX screenY shiftKey srcElement target toElement view wheelDelta which\".split(\" \"),fix:function(a){if(a[f.expando])return a;var d=a;a=f.Event(d);for(var e=this.props.length,g;e;)g=this.props[--e],a[g]=d[g];a.target||(a.target=a.srcElement||c),a.target.nodeType===3&&(a.target=a.target.parentNode),!a.relatedTarget&&a.fromElement&&(a.relatedTarget=a.fromElement===a.target?a.toElement:a.fromElement);if(a.pageX==null&&a.clientX!=null){var h=a.target.ownerDocument||c,i=h.documentElement,j=h.body;a.pageX=a.clientX+(i&&i.scrollLeft||j&&j.scrollLeft||0)-(i&&i.clientLeft||j&&j.clientLeft||0),a.pageY=a.clientY+(i&&i.scrollTop||j&&j.scrollTop||0)-(i&&i.clientTop||j&&j.clientTop||0)}a.which==null&&(a.charCode!=null||a.keyCode!=null)&&(a.which=a.charCode!=null?a.charCode:a.keyCode),!a.metaKey&&a.ctrlKey&&(a.metaKey=a.ctrlKey),!a.which&&a.button!==b&&(a.which=a.button&1?1:a.button&2?3:a.button&4?2:0);return a},guid:1e8,proxy:f.proxy,special:{ready:{setup:f.bindReady,teardown:f.noop},live:{add:function(a){f.event.add(this,O(a.origType,a.selector),f.extend({},a,{handler:N,guid:a.handler.guid}))},remove:function(a){f.event.remove(this,O(a.origType,a.selector),a)}},beforeunload:{setup:function(a,b,c){f.isWindow(this)&&(this.onbeforeunload=c)},teardown:function(a,b){this.onbeforeunload===b&&(this.onbeforeunload=null)}}}},f.removeEvent=c.removeEventListener?function(a,b,c){a.removeEventListener&&a.removeEventListener(b,c,!1)}:function(a,b,c){a.detachEvent&&a.detachEvent(\"on\"+b,c)},f.Event=function(a,b){if(!this.preventDefault)return new f.Event(a,b);a&&a.type?(this.originalEvent=a,this.type=a.type,this.isDefaultPrevented=a.defaultPrevented||a.returnValue===!1||a.getPreventDefault&&a.getPreventDefault()?F:E):this.type=a,b&&f.extend(this,b),this.timeStamp=f.now(),this[f.expando]=!0},f.Event.prototype={preventDefault:function(){this.isDefaultPrevented=F;var a=this.originalEvent;!a||(a.preventDefault?a.preventDefault():a.returnValue=!1)},stopPropagation:function(){this.isPropagationStopped=F;var a=this.originalEvent;!a||(a.stopPropagation&&a.stopPropagation(),a.cancelBubble=!0)},stopImmediatePropagation:function(){this.isImmediatePropagationStopped=F,this.stopPropagation()},isDefaultPrevented:E,isPropagationStopped:E,isImmediatePropagationStopped:E};var G=function(a){var b=a.relatedTarget;a.type=a.data;try{if(b&&b!==c&&!b.parentNode)return;while(b&&b!==this)b=b.parentNode;b!==this&&f.event.handle.apply(this,arguments)}catch(d){}},H=function(a){a.type=a.data,f.event.handle.apply(this,arguments)};f.each({mouseenter:\"mouseover\",mouseleave:\"mouseout\"},function(a,b){f.event.special[a]={setup:function(c){f.event.add(this,b,c&&c.selector?H:G,a)},teardown:function(a){f.event.remove(this,b,a&&a.selector?H:G)}}}),f.support.submitBubbles||(f.event.special.submit={setup:function(a,b){if(!f.nodeName(this,\"form\"))f.event.add(this,\"click.specialSubmit\",function(a){var b=a.target,c=b.type;(c===\"submit\"||c===\"image\")&&f(b).closest(\"form\").length&&L(\"submit\",this,arguments)}),f.event.add(this,\"keypress.specialSubmit\",function(a){var b=a.target,c=b.type;(c===\"text\"||c===\"password\")&&f(b).closest(\"form\").length&&a.keyCode===13&&L(\"submit\",this,arguments)});else return!1},teardown:function(a){f.event.remove(this,\".specialSubmit\")}});if(!f.support.changeBubbles){var I,J=function(a){var b=a.type,c=a.value;b===\"radio\"||b===\"checkbox\"?c=a.checked:b===\"select-multiple\"?c=a.selectedIndex>-1?f.map(a.options,function(a){return a.selected}).join(\"-\"):\"\":f.nodeName(a,\"select\")&&(c=a.selectedIndex);return c},K=function(c){var d=c.target,e,g;if(!!z.test(d.nodeName)&&!d.readOnly){e=f._data(d,\"_change_data\"),g=J(d),(c.type!==\"focusout\"||d.type!==\"radio\")&&f._data(d,\"_change_data\",g);if(e===b||g===e)return;if(e!=null||g)c.type=\"change\",c.liveFired=b,f.event.trigger(c,arguments[1],d)}};f.event.special.change={filters:{focusout:K,beforedeactivate:K,click:function(a){var b=a.target,c=f.nodeName(b,\"input\")?b.type:\"\";(c===\"radio\"||c===\"checkbox\"||f.nodeName(b,\"select\"))&&K.call(this,a)},keydown:function(a){var b=a.target,c=f.nodeName(b,\"input\")?b.type:\"\";(a.keyCode===13&&!f.nodeName(b,\"textarea\")||a.keyCode===32&&(c===\"checkbox\"||c===\"radio\")||c===\"select-multiple\")&&K.call(this,a)},beforeactivate:function(a){var b=a.target;f._data(b,\"_change_data\",J(b))}},setup:function(a,b){if(this.type===\"file\")return!1;for(var c in I)f.event.add(this,c+\".specialChange\",I[c]);return z.test(this.nodeName)},teardown:function(a){f.event.remove(this,\".specialChange\");return z.test(this.nodeName)}},I=f.event.special.change.filters,I.focus=I.beforeactivate}f.support.focusinBubbles||f.each({focus:\"focusin\",blur:\"focusout\"},function(a,b){function e(a){var c=f.event.fix(a);c.type=b,c.originalEvent={},f.event.trigger(c,null,c.target),c.isDefaultPrevented()&&a.preventDefault()}var d=0;f.event.special[b]={setup:function(){d++===0&&c.addEventListener(a,e,!0)},teardown:function(){--d===0&&c.removeEventListener(a,e,!0)}}}),f.each([\"bind\",\"one\"],function(a,c){f.fn[c]=function(a,d,e){var g;if(typeof a==\"object\"){for(var h in a)this[c](h,d,a[h],e);return this}if(arguments.length===2||d===!1)e=d,d=b;c===\"one\"?(g=function(a){f(this).unbind(a,g);return e.apply(this,arguments)},g.guid=e.guid||f.guid++):g=e;if(a===\"unload\"&&c!==\"one\")this.one(a,d,e);else for(var i=0,j=this.length;i<j;i++)f.event.add(this[i],a,g,d);return this}}),f.fn.extend({unbind:function(a,b){if(typeof a==\"object\"&&!a.preventDefault)for(var c in a)this.unbind(c,a[c]);else for(var d=0,e=this.length;d<e;d++)f.event.remove(this[d],a,b);return this},delegate:function(a,b,c,d){return this.live(b,c,d,a)},undelegate:function(a,b,c){return arguments.length===0?this.unbind(\"live\"):this.die(b,null,c,a)},trigger:function(a,b){return this.each(function(){f.event.trigger(a,b,this)})},triggerHandler:function(a,b){if(this[0])return f.event.trigger(a,b,this[0],!0)},toggle:function(a){var b=arguments,c=a.guid||f.guid++,d=0,e=function(c){var e=(f.data(this,\"lastToggle\"+a.guid)||0)%d;f.data(this,\"lastToggle\"+a.guid,e+1),c.preventDefault();return b[e].apply(this,arguments)||!1};e.guid=c;while(d<b.length)b[d++].guid=c;return this.click(e)},hover:function(a,b){return this.mouseenter(a).mouseleave(b||a)}});var M={focus:\"focusin\",blur:\"focusout\",mouseenter:\"mouseover\",mouseleave:\"mouseout\"};f.each([\"live\",\"die\"],function(a,c){f.fn[c]=function(a,d,e,g){var h,i=0,j,k,l,m=g||this.selector,n=g?this:f(this.context);if(typeof a==\"object\"&&!a.preventDefault){for(var o in a)n[c](o,d,a[o],m);return this}if(c===\"die\"&&!a&&g&&g.charAt(0)===\".\"){n.unbind(g);return this}if(d===!1||f.isFunction(d))e=d||E,d=b;a=(a||\"\").split(\" \");while((h=a[i++])!=null){j=y.exec(h),k=\"\",j&&(k=j[0],h=h.replace(y,\"\"));if(h===\"hover\"){a.push(\"mouseenter\"+k,\"mouseleave\"+k);continue}l=h,M[h]?(a.push(M[h]+k),h=h+k):h=(M[h]||h)+k;if(c===\"live\")for(var p=0,q=n.length;p<q;p++)f.event.add(n[p],\"live.\"+O(h,m),{data:d,selector:m,handler:e,origType:h,origHandler:e,preType:l});else n.unbind(\"live.\"+O(h,m),e)}return this}}),f.each(\"blur focus focusin focusout load resize scroll unload click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup error\".split(\" \"),function(a,b){f.fn[b]=function(a,c){c==null&&(c=a,a=null);return arguments.length>0?this.bind(b,a,c):this.trigger(b)},f.attrFn&&(f.attrFn[b]=!0)}),function(){function u(a,b,c,d,e,f){for(var g=0,h=d.length;g<h;g++){var i=d[g];if(i){var j=!1;i=i[a];while(i){if(i.sizcache===c){j=d[i.sizset];break}if(i.nodeType===1){f||(i.sizcache=c,i.sizset=g);if(typeof b!=\"string\"){if(i===b){j=!0;break}}else if(k.filter(b,[i]).length>0){j=i;break}}i=i[a]}d[g]=j}}}function t(a,b,c,d,e,f){for(var g=0,h=d.length;g<h;g++){var i=d[g];if(i){var j=!1;i=i[a];while(i){if(i.sizcache===c){j=d[i.sizset];break}i.nodeType===1&&!f&&(i.sizcache=c,i.sizset=g);if(i.nodeName.toLowerCase()===b){j=i;break}i=i[a]}d[g]=j}}}var a=/((?:\\((?:\\([^()]+\\)|[^()]+)+\\)|\\[(?:\\[[^\\[\\]]*\\]|['\"][^'\"]*['\"]|[^\\[\\]'\"]+)+\\]|\\\\.|[^ >+~,(\\[\\\\]+)+|[>+~])(\\s*,\\s*)?((?:.|\\r|\\n)*)/g,d=0,e=Object.prototype.toString,g=!1,h=!0,i=/\\\\/g,j=/\\W/;[0,0].sort(function(){h=!1;return 0});var k=function(b,d,f,g){f=f||[],d=d||c;var h=d;if(d.nodeType!==1&&d.nodeType!==9)return[];if(!b||typeof b!=\"string\")return f;var i,j,n,o,q,r,s,t,u=!0,w=k.isXML(d),x=[],y=b;do{a.exec(\"\"),i=a.exec(y);if(i){y=i[3],x.push(i[1]);if(i[2]){o=i[3];break}}}while(i);if(x.length>1&&m.exec(b))if(x.length===2&&l.relative[x[0]])j=v(x[0]+x[1],d);else{j=l.relative[x[0]]?[d]:k(x.shift(),d);while(x.length)b=x.shift(),l.relative[b]&&(b+=x.shift()),j=v(b,j)}else{!g&&x.length>1&&d.nodeType===9&&!w&&l.match.ID.test(x[0])&&!l.match.ID.test(x[x.length-1])&&(q=k.find(x.shift(),d,w),d=q.expr?k.filter(q.expr,q.set)[0]:q.set[0]);if(d){q=g?{expr:x.pop(),set:p(g)}:k.find(x.pop(),x.length===1&&(x[0]===\"~\"||x[0]===\"+\")&&d.parentNode?d.parentNode:d,w),j=q.expr?k.filter(q.expr,q.set):q.set,x.length>0?n=p(j):u=!1;while(x.length)r=x.pop(),s=r,l.relative[r]?s=x.pop():r=\"\",s==null&&(s=d),l.relative[r](n,s,w)}else n=x=[]}n||(n=j),n||k.error(r||b);if(e.call(n)===\"[object Array]\")if(!u)f.push.apply(f,n);else if(d&&d.nodeType===1)for(t=0;n[t]!=null;t++)n[t]&&(n[t]===!0||n[t].nodeType===1&&k.contains(d,n[t]))&&f.push(j[t]);else for(t=0;n[t]!=null;t++)n[t]&&n[t].nodeType===1&&f.push(j[t]);else p(n,f);o&&(k(o,h,f,g),k.uniqueSort(f));return f};k.uniqueSort=function(a){if(r){g=h,a.sort(r);if(g)for(var b=1;b<a.length;b++)a[b]===a[b-1]&&a.splice(b--,1)}return a},k.matches=function(a,b){return k(a,null,null,b)},k.matchesSelector=function(a,b){return k(b,null,null,[a]).length>0},k.find=function(a,b,c){var d;if(!a)return[];for(var e=0,f=l.order.length;e<f;e++){var g,h=l.order[e];if(g=l.leftMatch[h].exec(a)){var j=g[1];g.splice(1,1);if(j.substr(j.length-1)!==\"\\\\\"){g[1]=(g[1]||\"\").replace(i,\"\"),d=l.find[h](g,b,c);if(d!=null){a=a.replace(l.match[h],\"\");break}}}}d||(d=typeof b.getElementsByTagName!=\"undefined\"?b.getElementsByTagName(\"*\"):[]);return{set:d,expr:a}},k.filter=function(a,c,d,e){var f,g,h=a,i=[],j=c,m=c&&c[0]&&k.isXML(c[0]);while(a&&c.length){for(var n in l.filter)if((f=l.leftMatch[n].exec(a))!=null&&f[2]){var o,p,q=l.filter[n],r=f[1];g=!1,f.splice(1,1);if(r.substr(r.length-1)===\"\\\\\")continue;j===i&&(i=[]);if(l.preFilter[n]){f=l.preFilter[n](f,j,d,i,e,m);if(!f)g=o=!0;else if(f===!0)continue}if(f)for(var s=0;(p=j[s])!=null;s++)if(p){o=q(p,f,s,j);var t=e^!!o;d&&o!=null?t?g=!0:j[s]=!1:t&&(i.push(p),g=!0)}if(o!==b){d||(j=i),a=a.replace(l.match[n],\"\");if(!g)return[];break}}if(a===h)if(g==null)k.error(a);else break;h=a}return j},k.error=function(a){throw\"Syntax error, unrecognized expression: \"+a};var l=k.selectors={order:[\"ID\",\"NAME\",\"TAG\"],match:{ID:/#((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)/,CLASS:/\\.((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)/,NAME:/\\[name=['\"]*((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)['\"]*\\]/,ATTR:/\\[\\s*((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)\\s*(?:(\\S?=)\\s*(?:(['\"])(.*?)\\3|(#?(?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)*)|)|)\\s*\\]/,TAG:/^((?:[\\w\\u00c0-\\uFFFF\\*\\-]|\\\\.)+)/,CHILD:/:(only|nth|last|first)-child(?:\\(\\s*(even|odd|(?:[+\\-]?\\d+|(?:[+\\-]?\\d*)?n\\s*(?:[+\\-]\\s*\\d+)?))\\s*\\))?/,POS:/:(nth|eq|gt|lt|first|last|even|odd)(?:\\((\\d*)\\))?(?=[^\\-]|$)/,PSEUDO:/:((?:[\\w\\u00c0-\\uFFFF\\-]|\\\\.)+)(?:\\((['\"]?)((?:\\([^\\)]+\\)|[^\\(\\)]*)+)\\2\\))?/},leftMatch:{},attrMap:{\"class\":\"className\",\"for\":\"htmlFor\"},attrHandle:{href:function(a){return a.getAttribute(\"href\")},type:function(a){return a.getAttribute(\"type\")}},relative:{\"+\":function(a,b){var c=typeof b==\"string\",d=c&&!j.test(b),e=c&&!d;d&&(b=b.toLowerCase());for(var f=0,g=a.length,h;f<g;f++)if(h=a[f]){while((h=h.previousSibling)&&h.nodeType!==1);a[f]=e||h&&h.nodeName.toLowerCase()===b?h||!1:h===b}e&&k.filter(b,a,!0)},\">\":function(a,b){var c,d=typeof b==\"string\",e=0,f=a.length;if(d&&!j.test(b)){b=b.toLowerCase();for(;e<f;e++){c=a[e];if(c){var g=c.parentNode;a[e]=g.nodeName.toLowerCase()===b?g:!1}}}else{for(;e<f;e++)c=a[e],c&&(a[e]=d?c.parentNode:c.parentNode===b);d&&k.filter(b,a,!0)}},\"\":function(a,b,c){var e,f=d++,g=u;typeof b==\"string\"&&!j.test(b)&&(b=b.toLowerCase(),e=b,g=t),g(\"parentNode\",b,f,a,e,c)},\"~\":function(a,b,c){var e,f=d++,g=u;typeof b==\"string\"&&!j.test(b)&&(b=b.toLowerCase(),e=b,g=t),g(\"previousSibling\",b,f,a,e,c)}},find:{ID:function(a,b,c){if(typeof b.getElementById!=\"undefined\"&&!c){var d=b.getElementById(a[1]);return d&&d.parentNode?[d]:[]}},NAME:function(a,b){if(typeof b.getElementsByName!=\"undefined\"){var c=[],d=b.getElementsByName(a[1]);for(var e=0,f=d.length;e<f;e++)d[e].getAttribute(\"name\")===a[1]&&c.push(d[e]);return c.length===0?null:c}},TAG:function(a,b){if(typeof b.getElementsByTagName!=\"undefined\")return b.getElementsByTagName(a[1])}},preFilter:{CLASS:function(a,b,c,d,e,f){a=\" \"+a[1].replace(i,\"\")+\" \";if(f)return a;for(var g=0,h;(h=b[g])!=null;g++)h&&(e^(h.className&&(\" \"+h.className+\" \").replace(/[\\t\\n\\r]/g,\" \").indexOf(a)>=0)?c||d.push(h):c&&(b[g]=!1));return!1},ID:function(a){return a[1].replace(i,\"\")},TAG:function(a,b){return a[1].replace(i,\"\").toLowerCase()},CHILD:function(a){if(a[1]===\"nth\"){a[2]||k.error(a[0]),a[2]=a[2].replace(/^\\+|\\s*/g,\"\");var b=/(-?)(\\d*)(?:n([+\\-]?\\d*))?/.exec(a[2]===\"even\"&&\"2n\"||a[2]===\"odd\"&&\"2n+1\"||!/\\D/.test(a[2])&&\"0n+\"+a[2]||a[2]);a[2]=b[1]+(b[2]||1)-0,a[3]=b[3]-0}else a[2]&&k.error(a[0]);a[0]=d++;return a},ATTR:function(a,b,c,d,e,f){var g=a[1]=a[1].replace(i,\"\");!f&&l.attrMap[g]&&(a[1]=l.attrMap[g]),a[4]=(a[4]||a[5]||\"\").replace(i,\"\"),a[2]===\"~=\"&&(a[4]=\" \"+a[4]+\" \");return a},PSEUDO:function(b,c,d,e,f){if(b[1]===\"not\")if((a.exec(b[3])||\"\").length>1||/^\\w/.test(b[3]))b[3]=k(b[3],null,null,c);else{var g=k.filter(b[3],c,d,!0^f);d||e.push.apply(e,g);return!1}else if(l.match.POS.test(b[0])||l.match.CHILD.test(b[0]))return!0;return b},POS:function(a){a.unshift(!0);return a}},filters:{enabled:function(a){return a.disabled===!1&&a.type!==\"hidden\"},disabled:function(a){return a.disabled===!0},checked:function(a){return a.checked===!0},selected:function(a){a.parentNode&&a.parentNode.selectedIndex;return a.selected===!0},parent:function(a){return!!a.firstChild},empty:function(a){return!a.firstChild},has:function(a,b,c){return!!k(c[3],a).length},header:function(a){return/h\\d/i.test(a.nodeName)},text:function(a){var b=a.getAttribute(\"type\"),c=a.type;return a.nodeName.toLowerCase()===\"input\"&&\"text\"===c&&(b===c||b===null)},radio:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"radio\"===a.type},checkbox:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"checkbox\"===a.type},file:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"file\"===a.type},password:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"password\"===a.type},submit:function(a){var b=a.nodeName.toLowerCase();return(b===\"input\"||b===\"button\")&&\"submit\"===a.type},image:function(a){return a.nodeName.toLowerCase()===\"input\"&&\"image\"===a.type},reset:function(a){var b=a.nodeName.toLowerCase();return(b===\"input\"||b===\"button\")&&\"reset\"===a.type},button:function(a){var b=a.nodeName.toLowerCase();return b===\"input\"&&\"button\"===a.type||b===\"button\"},input:function(a){return/input|select|textarea|button/i.test(a.nodeName)},focus:function(a){return a===a.ownerDocument.activeElement}},setFilters:{first:function(a,b){return b===0},last:function(a,b,c,d){return b===d.length-1},even:function(a,b){return b%2===0},odd:function(a,b){return b%2===1},lt:function(a,b,c){return b<c[3]-0},gt:function(a,b,c){return b>c[3]-0},nth:function(a,b,c){return c[3]-0===b},eq:function(a,b,c){return c[3]-0===b}},filter:{PSEUDO:function(a,b,c,d){var e=b[1],f=l.filters[e];if(f)return f(a,c,b,d);if(e===\"contains\")return(a.textContent||a.innerText||k.getText([a])||\"\").indexOf(b[3])>=0;if(e===\"not\"){var g=b[3];for(var h=0,i=g.length;h<i;h++)if(g[h]===a)return!1;return!0}k.error(e)},CHILD:function(a,b){var c=b[1],d=a;switch(c){case\"only\":case\"first\":while(d=d.previousSibling)if(d.nodeType===1)return!1;if(c===\"first\")return!0;d=a;case\"last\":while(d=d.nextSibling)if(d.nodeType===1)return!1;return!0;case\"nth\":var e=b[2],f=b[3];if(e===1&&f===0)return!0;var g=b[0],h=a.parentNode;if(h&&(h.sizcache!==g||!a.nodeIndex)){var i=0;for(d=h.firstChild;d;d=d.nextSibling)d.nodeType===1&&(d.nodeIndex=++i);h.sizcache=g}var j=a.nodeIndex-f;return e===0?j===0:j%e===0&&j/e>=0}},ID:function(a,b){return a.nodeType===1&&a.getAttribute(\"id\")===b},TAG:function(a,b){return b===\"*\"&&a.nodeType===1||a.nodeName.toLowerCase()===b},CLASS:function(a,b){return(\" \"+(a.className||a.getAttribute(\"class\"))+\" \").indexOf(b)>-1},ATTR:function(a,b){var c=b[1],d=l.attrHandle[c]?l.attrHandle[c](a):a[c]!=null?a[c]:a.getAttribute(c),e=d+\"\",f=b[2],g=b[4];return d==null?f===\"!=\":f===\"=\"?e===g:f===\"*=\"?e.indexOf(g)>=0:f===\"~=\"?(\" \"+e+\" \").indexOf(g)>=0:g?f===\"!=\"?e!==g:f===\"^=\"?e.indexOf(g)===0:f===\"$=\"?e.substr(e.length-g.length)===g:f===\"|=\"?e===g||e.substr(0,g.length+1)===g+\"-\":!1:e&&d!==!1},POS:function(a,b,c,d){var e=b[2],f=l.setFilters[e];if(f)return f(a,c,b,d)}}},m=l.match.POS,n=function(a,b){return\"\\\\\"+(b-0+1)};for(var o in l.match)l.match[o]=new RegExp(l.match[o].source+/(?![^\\[]*\\])(?![^\\(]*\\))/.source),l.leftMatch[o]=new RegExp(/(^(?:.|\\r|\\n)*?)/.source+l.match[o].source.replace(/\\\\(\\d+)/g,n));var p=function(a,b){a=Array.prototype.slice.call(a,0);if(b){b.push.apply(b,a);return b}return a};try{Array.prototype.slice.call(c.documentElement.childNodes,0)[0].nodeType}catch(q){p=function(a,b){var c=0,d=b||[];if(e.call(a)===\"[object Array]\")Array.prototype.push.apply(d,a);else if(typeof a.length==\"number\")for(var f=a.length;c<f;c++)d.push(a[c]);else for(;a[c];c++)d.push(a[c]);return d}}var r,s;c.documentElement.compareDocumentPosition?r=function(a,b){if(a===b){g=!0;return 0}if(!a.compareDocumentPosition||!b.compareDocumentPosition)return a.compareDocumentPosition?-1:1;return a.compareDocumentPosition(b)&4?-1:1}:(r=function(a,b){if(a===b){g=!0;return 0}if(a.sourceIndex&&b.sourceIndex)return a.sourceIndex-b.sourceIndex;var c,d,e=[],f=[],h=a.parentNode,i=b.parentNode,j=h;if(h===i)return s(a,b);if(!h)return-1;if(!i)return 1;while(j)e.unshift(j),j=j.parentNode;j=i;while(j)f.unshift(j),j=j.parentNode;c=e.length,d=f.length;for(var k=0;k<c&&k<d;k++)if(e[k]!==f[k])return s(e[k],f[k]);return k===c?s(a,f[k],-1):s(e[k],b,1)},s=function(a,b,c){if(a===b)return c;var d=a.nextSibling;while(d){if(d===b)return-1;d=d.nextSibling}return 1}),k.getText=function(a){var b=\"\",c;for(var d=0;a[d];d++)c=a[d],c.nodeType===3||c.nodeType===4?b+=c.nodeValue:c.nodeType!==8&&(b+=k.getText(c.childNodes));return b},function(){var a=c.createElement(\"div\"),d=\"script\"+(new Date).getTime(),e=c.documentElement;a.innerHTML=\"<a name='\"+d+\"'/>\",e.insertBefore(a,e.firstChild),c.getElementById(d)&&(l.find.ID=function(a,c,d){if(typeof c.getElementById!=\"undefined\"&&!d){var e=c.getElementById(a[1]);return e?e.id===a[1]||typeof e.getAttributeNode!=\"undefined\"&&e.getAttributeNode(\"id\").nodeValue===a[1]?[e]:b:[]}},l.filter.ID=function(a,b){var c=typeof a.getAttributeNode!=\"undefined\"&&a.getAttributeNode(\"id\");return a.nodeType===1&&c&&c.nodeValue===b}),e.removeChild(a),e=a=null}(),function(){var a=c.createElement(\"div\");a.appendChild(c.createComment(\"\")),a.getElementsByTagName(\"*\").length>0&&(l.find.TAG=function(a,b){var c=b.getElementsByTagName(a[1]);if(a[1]===\"*\"){var d=[];for(var e=0;c[e];e++)c[e].nodeType===1&&d.push(c[e]);c=d}return c}),a.innerHTML=\"<a href='#'></a>\",a.firstChild&&typeof a.firstChild.getAttribute!=\"undefined\"&&a.firstChild.getAttribute(\"href\")!==\"#\"&&(l.attrHandle.href=function(a){return a.getAttribute(\"href\",2)}),a=null}(),c.querySelectorAll&&function(){var a=k,b=c.createElement(\"div\"),d=\"__sizzle__\";b.innerHTML=\"<p class='TEST'></p>\";if(!b.querySelectorAll||b.querySelectorAll(\".TEST\").length!==0){k=function(b,e,f,g){e=e||c;if(!g&&!k.isXML(e)){var h=/^(\\w+$)|^\\.([\\w\\-]+$)|^#([\\w\\-]+$)/.exec(b);if(h&&(e.nodeType===1||e.nodeType===9)){if(h[1])return p(e.getElementsByTagName(b),f);if(h[2]&&l.find.CLASS&&e.getElementsByClassName)return p(e.getElementsByClassName(h[2]),f)}if(e.nodeType===9){if(b===\"body\"&&e.body)return p([e.body],f);if(h&&h[3]){var i=e.getElementById(h[3]);if(!i||!i.parentNode)return p([],f);if(i.id===h[3])return p([i],f)}try{return p(e.querySelectorAll(b),f)}catch(j){}}else if(e.nodeType===1&&e.nodeName.toLowerCase()!==\"object\"){var m=e,n=e.getAttribute(\"id\"),o=n||d,q=e.parentNode,r=/^\\s*[+~]/.test(b);n?o=o.replace(/'/g,\"\\\\$&\"):e.setAttribute(\"id\",o),r&&q&&(e=e.parentNode);try{if(!r||q)return p(e.querySelectorAll(\"[id='\"+o+\"'] \"+b),f)}catch(s){}finally{n||m.removeAttribute(\"id\")}}}return a(b,e,f,g)};for(var e in a)k[e]=a[e];b=null}}(),function(){var a=c.documentElement,b=a.matchesSelector||a.mozMatchesSelector||a.webkitMatchesSelector||a.msMatchesSelector;if(b){var d=!b.call(c.createElement(\"div\"),\"div\"),e=!1;try{b.call(c.documentElement,\"[test!='']:sizzle\")}catch(f){e=!0}k.matchesSelector=function(a,c){c=c.replace(/\\=\\s*([^'\"\\]]*)\\s*\\]/g,\"='$1']\");if(!k.isXML(a))try{if(e||!l.match.PSEUDO.test(c)&&!/!=/.test(c)){var f=b.call(a,c);if(f||!d||a.document&&a.document.nodeType!==11)return f}}catch(g){}return k(c,null,null,[a]).length>0}}}(),function(){var a=c.createElement(\"div\");a.innerHTML=\"<div class='test e'></div><div class='test'></div>\";if(!!a.getElementsByClassName&&a.getElementsByClassName(\"e\").length!==0){a.lastChild.className=\"e\";if(a.getElementsByClassName(\"e\").length===1)return;l.order.splice(1,0,\"CLASS\"),l.find.CLASS=function(a,b,c){if(typeof b.getElementsByClassName!=\"undefined\"&&!c)return b.getElementsByClassName(a[1])},a=null}}(),c.documentElement.contains?k.contains=function(a,b){return a!==b&&(a.contains?a.contains(b):!0)}:c.documentElement.compareDocumentPosition?k.contains=function(a,b){return!!(a.compareDocumentPosition(b)&16)}:k.contains=function(){return!1},k.isXML=function(a){var b=(a?a.ownerDocument||a:0).documentElement;return b?b.nodeName!==\"HTML\":!1};var v=function(a,b){var c,d=[],e=\"\",f=b.nodeType?[b]:b;while(c=l.match.PSEUDO.exec(a))e+=c[0],a=a.replace(l.match.PSEUDO,\"\");a=l.relative[a]?a+\"*\":a;for(var g=0,h=f.length;g<h;g++)k(a,f[g],d);return k.filter(e,d)};f.find=k,f.expr=k.selectors,f.expr[\":\"]=f.expr.filters,f.unique=k.uniqueSort,f.text=k.getText,f.isXMLDoc=k.isXML,f.contains=k.contains}();var P=/Until$/,Q=/^(?:parents|prevUntil|prevAll)/,R=/,/,S=/^.[^:#\\[\\.,]*$/,T=Array.prototype.slice,U=f.expr.match.POS,V={children:!0,contents:!0,next:!0,prev:!0};f.fn.extend({find:function(a){var b=this,c,d;if(typeof a!=\"string\")return f(a).filter(function(){for(c=0,d=b.length;c<d;c++)if(f.contains(b[c],this))return!0});var e=this.pushStack(\"\",\"find\",a),g,h,i;for(c=0,d=this.length;c<d;c++){g=e.length,f.find(a,this[c],e);if(c>0)for(h=g;h<e.length;h++)for(i=0;i<g;i++)if(e[i]===e[h]){e.splice(h--,1);break}}return e},has:function(a){var b=f(a);return this.filter(function(){for(var a=0,c=b.length;a<c;a++)if(f.contains(this,b[a]))return!0})},not:function(a){return this.pushStack(X(this,a,!1),\"not\",a)},filter:function(a){return this.pushStack(X(this,a,!0),\"filter\",a)},is:function(a){return!!a&&(typeof a==\"string\"?f.filter(a,this).length>0:this.filter(a).length>0)},closest:function(a,b){var c=[],d,e,g=this[0];if(f.isArray(a)){var h,i,j={},k=1;if(g&&a.length){for(d=0,e=a.length;d<e;d++)i=a[d],j[i]||(j[i]=U.test(i)?f(i,b||this.context):i);while(g&&g.ownerDocument&&g!==b){for(i in j)h=j[i],(h.jquery?h.index(g)>-1:f(g).is(h))&&c.push({selector:i,elem:g,level:k});g=g.parentNode,k++}}return c}var l=U.test(a)||typeof a!=\"string\"?f(a,b||this.context):0;for(d=0,e=this.length;d<e;d++){g=this[d];while(g){if(l?l.index(g)>-1:f.find.matchesSelector(g,a)){c.push(g);break}g=g.parentNode;if(!g||!g.ownerDocument||g===b||g.nodeType===11)break}}c=c.length>1?f.unique(c):c;return this.pushStack(c,\"closest\",a)},index:function(a){if(!a||typeof a==\"string\")return f.inArray(this[0],a?f(a):this.parent().children());return f.inArray(a.jquery?a[0]:a,this)},add:function(a,b){var c=typeof a==\"string\"?f(a,b):f.makeArray(a&&a.nodeType?[a]:a),d=f.merge(this.get(),c);return this.pushStack(W(c[0])||W(d[0])?d:f.unique(d))},andSelf:function(){return this.add(this.prevObject)}}),f.each({parent:function(a){var b=a.parentNode;return b&&b.nodeType!==11?b:null},parents:function(a){return f.dir(a,\"parentNode\")},parentsUntil:function(a,b,c){return f.dir(a,\"parentNode\",c)},next:function(a){return f.nth(a,2,\"nextSibling\")},prev:function(a){return f.nth(a,2,\"previousSibling\")},nextAll:function(a){return f.dir(a,\"nextSibling\")},prevAll:function(a){return f.dir(a,\"previousSibling\")},nextUntil:function(a,b,c){return f.dir(a,\"nextSibling\",c)},prevUntil:function(a,b,c){return f.dir(a,\"previousSibling\",c)},siblings:function(a){return f.sibling(a.parentNode.firstChild,a)},children:function(a){return f.sibling(a.firstChild)},contents:function(a){return f.nodeName(a,\"iframe\")?a.contentDocument||a.contentWindow.document:f.makeArray(a.childNodes)}},function(a,b){f.fn[a]=function(c,d){var e=f.map(this,b,c),g=T.call(arguments);P.test(a)||(d=c),d&&typeof d==\"string\"&&(e=f.filter(d,e)),e=this.length>1&&!V[a]?f.unique(e):e,(this.length>1||R.test(d))&&Q.test(a)&&(e=e.reverse());return this.pushStack(e,a,g.join(\",\"))}}),f.extend({filter:function(a,b,c){c&&(a=\":not(\"+a+\")\");return b.length===1?f.find.matchesSelector(b[0],a)?[b[0]]:[]:f.find.matches(a,b)},dir:function(a,c,d){var e=[],g=a[c];while(g&&g.nodeType!==9&&(d===b||g.nodeType!==1||!f(g).is(d)))g.nodeType===1&&e.push(g),g=g[c];return e},nth:function(a,b,c,d){b=b||1;var e=0;for(;a;a=a[c])if(a.nodeType===1&&++e===b)break;return a},sibling:function(a,b){var c=[];for(;a;a=a.nextSibling)a.nodeType===1&&a!==b&&c.push(a);return c}});var Y=/ jQuery\\d+=\"(?:\\d+|null)\"/g,Z=/^\\s+/,$=/<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\\w:]+)[^>]*)\\/>/ig,_=/<([\\w:]+)/,ba=/<tbody/i,bb=/<|&#?\\w+;/,bc=/<(?:script|object|embed|option|style)/i,bd=/checked\\s*(?:[^=]|=\\s*.checked.)/i,be=/\\/(java|ecma)script/i,bf=/^\\s*<!(?:\\[CDATA\\[|\\-\\-)/,bg={option:[1,\"<select multiple='multiple'>\",\"</select>\"],legend:[1,\"<fieldset>\",\"</fieldset>\"],thead:[1,\"<table>\",\"</table>\"],tr:[2,\"<table><tbody>\",\"</tbody></table>\"],td:[3,\"<table><tbody><tr>\",\"</tr></tbody></table>\"],col:[2,\"<table><tbody></tbody><colgroup>\",\"</colgroup></table>\"],area:[1,\"<map>\",\"</map>\"],_default:[0,\"\",\"\"]};bg.optgroup=bg.option,bg.tbody=bg.tfoot=bg.colgroup=bg.caption=bg.thead,bg.th=bg.td,f.support.htmlSerialize||(bg._default=[1,\"div<div>\",\"</div>\"]),f.fn.extend({text:function(a){if(f.isFunction(a))return this.each(function(b){var c=f(this);c.text(a.call(this,b,c.text()))});if(typeof a!=\"object\"&&a!==b)return this.empty().append((this[0]&&this[0].ownerDocument||c).createTextNode(a));return f.text(this)},wrapAll:function(a){if(f.isFunction(a))return this.each(function(b){f(this).wrapAll(a.call(this,b))});if(this[0]){var b=f(a,this[0].ownerDocument).eq(0).clone(!0);this[0].parentNode&&b.insertBefore(this[0]),b.map(function(){var a=this;while(a.firstChild&&a.firstChild.nodeType===1)a=a.firstChild;return a}).append(this)}return this},wrapInner:function(a){if(f.isFunction(a))return this.each(function(b){f(this).wrapInner(a.call(this,b))});return this.each(function(){var b=f(this),c=b.contents();c.length?c.wrapAll(a):b.append(a)})},wrap:function(a){return this.each(function(){f(this).wrapAll(a)})},unwrap:function(){return this.parent().each(function(){f.nodeName(this,\"body\")||f(this).replaceWith(this.childNodes)}).end()},append:function(){return this.domManip(arguments,!0,function(a){this.nodeType===1&&this.appendChild(a)})},prepend:function(){return this.domManip(arguments,!0,function(a){this.nodeType===1&&this.insertBefore(a,this.firstChild)})},before:function(){if(this[0]&&this[0].parentNode)return this.domManip(arguments,!1,function(a){this.parentNode.insertBefore(a,this)});if(arguments.length){var a=f(arguments[0]);a.push.apply(a,this.toArray());return this.pushStack(a,\"before\",arguments)}},after:function(){if(this[0]&&this[0].parentNode)return this.domManip(arguments,!1,function(a){this.parentNode.insertBefore(a,this.nextSibling)});if(arguments.length){var a=this.pushStack(this,\"after\",arguments);a.push.apply(a,f(arguments[0]).toArray());return a}},remove:function(a,b){for(var c=0,d;(d=this[c])!=null;c++)if(!a||f.filter(a,[d]).length)!b&&d.nodeType===1&&(f.cleanData(d.getElementsByTagName(\"*\")),f.cleanData([d])),d.parentNode&&d.parentNode.removeChild(d);return this},empty:function(){for(var a=0,b;(b=this[a])!=null;a++){b.nodeType===1&&f.cleanData(b.getElementsByTagName(\"*\"));while(b.firstChild)b.removeChild(b.firstChild)}return this},clone:function(a,b){a=a==null?!1:a,b=b==null?a:b;return this.map(function(){return f.clone(this,a,b)})},html:function(a){if(a===b)return this[0]&&this[0].nodeType===1?this[0].innerHTML.replace(Y,\"\"):null;if(typeof a==\"string\"&&!bc.test(a)&&(f.support.leadingWhitespace||!Z.test(a))&&!bg[(_.exec(a)||[\"\",\"\"])[1].toLowerCase()]){a=a.replace($,\"<$1></$2>\");try{for(var c=0,d=this.length;c<d;c++)this[c].nodeType===1&&(f.cleanData(this[c].getElementsByTagName(\"*\")),this[c].innerHTML=a)}catch(e){this.empty().append(a)}}else f.isFunction(a)?this.each(function(b){var c=f(this);c.html(a.call(this,b,c.html()))}):this.empty().append(a);return this},replaceWith:function(a){if(this[0]&&this[0].parentNode){if(f.isFunction(a))return this.each(function(b){var c=f(this),d=c.html();c.replaceWith(a.call(this,b,d))});typeof a!=\"string\"&&(a=f(a).detach());return this.each(function(){var b=this.nextSibling,c=this.parentNode;f(this).remove(),b?f(b).before(a):f(c).append(a)})}return this.length?this.pushStack(f(f.isFunction(a)?a():a),\"replaceWith\",a):this},detach:function(a){return this.remove(a,!0)},domManip:function(a,c,d){var e,g,h,i,j=a[0],k=[];if(!f.support.checkClone&&arguments.length===3&&typeof j==\"string\"&&bd.test(j))return this.each(function(){f(this).domManip(a,c,d,!0)});if(f.isFunction(j))return this.each(function(e){var g=f(this);a[0]=j.call(this,e,c?g.html():b),g.domManip(a,c,d)});if(this[0]){i=j&&j.parentNode,f.support.parentNode&&i&&i.nodeType===11&&i.childNodes.length===this.length?e={fragment:i}:e=f.buildFragment(a,this,k),h=e.fragment,h.childNodes.length===1?g=h=h.firstChild:g=h.firstChild;if(g){c=c&&f.nodeName(g,\"tr\");for(var l=0,m=this.length,n=m-1;l<m;l++)d.call(c?bh(this[l],g):this[l],e.cacheable||m>1&&l<n?f.clone(h,!0,!0):h)}k.length&&f.each(k,bn)}return this}}),f.buildFragment=function(a,b,d){var e,g,h,i=b&&b[0]?b[0].ownerDocument||b[0]:c;a.length===1&&typeof a[0]==\"string\"&&a[0].length<512&&i===c&&a[0].charAt(0)===\"<\"&&!bc.test(a[0])&&(f.support.checkClone||!bd.test(a[0]))&&(g=!0,h=f.fragments[a[0]],h&&h!==1&&(e=h)),e||(e=i.createDocumentFragment(),f.clean(a,i,e,d)),g&&(f.fragments[a[0]]=h?e:1);return{fragment:e,cacheable:g}},f.fragments={},f.each({appendTo:\"append\",prependTo:\"prepend\",insertBefore:\"before\",insertAfter:\"after\",replaceAll:\"replaceWith\"},function(a,b){f.fn[a]=function(c){var d=[],e=f(c),g=this.length===1&&this[0].parentNode;if(g&&g.nodeType===11&&g.childNodes.length===1&&e.length===1){e[b](this[0]);return this}for(var h=0,i=e.length;h<i;h++){var j=(h>0?this.clone(!0):this).get();f(e[h])[b](j),d=d.concat(j)}return this.pushStack(d,a,e.selector)}}),f.extend({clone:function(a,b,c){var d=a.cloneNode(!0),e,g,h;if((!f.support.noCloneEvent||!f.support.noCloneChecked)&&(a.nodeType===1||a.nodeType===11)&&!f.isXMLDoc(a)){bj(a,d),e=bk(a),g=bk(d);for(h=0;e[h];++h)bj(e[h],g[h])}if(b){bi(a,d);if(c){e=bk(a),g=bk(d);for(h=0;e[h];++h)bi(e[h],g[h])}}return d},clean:function(a,b,d,e){var g;b=b||c,typeof b.createElement==\"undefined\"&&(b=b.ownerDocument||" +
					"b[0]&&b[0].ownerDocument||c);var h=[],i;for(var j=0,k;(k=a[j])!=null;j++){typeof k==\"number\"&&(k+=\"\");if(!k)continue;if(typeof k==\"string\")if(!bb.test(k))k=b.createTextNode(k);else{k=k.replace($,\"<$1></$2>\");var l=(_.exec(k)||[\"\",\"\"])[1].toLowerCase(),m=bg[l]||bg._default,n=m[0],o=b.createElement(\"div\");o.innerHTML=m[1]+k+m[2];while(n--)o=o.lastChild;if(!f.support.tbody){var p=ba.test(k),q=l===\"table\"&&!p?o.firstChild&&o.firstChild.childNodes:m[1]===\"<table>\"&&!p?o.childNodes:[];for(i=q.length-1;i>=0;--i)f.nodeName(q[i],\"tbody\")&&!q[i].childNodes.length&&q[i].parentNode.removeChild(q[i])}!f.support.leadingWhitespace&&Z.test(k)&&o.insertBefore(b.createTextNode(Z.exec(k)[0]),o.firstChild),k=o.childNodes}var r;if(!f.support.appendChecked)if(k[0]&&typeof (r=k.length)==\"number\")for(i=0;i<r;i++)bm(k[i]);else bm(k);k.nodeType?h.push(k):h=f.merge(h,k)}if(d){g=function(a){return!a.type||be.test(a.type)};for(j=0;h[j];j++)if(e&&f.nodeName(h[j],\"script\")&&(!h[j].type||h[j].type.toLowerCase()===\"text/javascript\"))e.push(h[j].parentNode?h[j].parentNode.removeChild(h[j]):h[j]);else{if(h[j].nodeType===1){var s=f.grep(h[j].getElementsByTagName(\"script\"),g);h.splice.apply(h,[j+1,0].concat(s))}d.appendChild(h[j])}}return h},cleanData:function(a){var b,c,d=f.cache,e=f.expando,g=f.event.special,h=f.support.deleteExpando;for(var i=0,j;(j=a[i])!=null;i++){if(j.nodeName&&f.noData[j.nodeName.toLowerCase()])continue;c=j[f.expando];if(c){b=d[c]&&d[c][e];if(b&&b.events){for(var k in b.events)g[k]?f.event.remove(j,k):f.removeEvent(j,k,b.handle);b.handle&&(b.handle.elem=null)}h?delete j[f.expando]:j.removeAttribute&&j.removeAttribute(f.expando),delete d[c]}}}});var bo=/alpha\\([^)]*\\)/i,bp=/opacity=([^)]*)/,bq=/-([a-z])/ig,br=/([A-Z]|^ms)/g,bs=/^-?\\d+(?:px)?$/i,bt=/^-?\\d/,bu=/^[+\\-]=/,bv=/[^+\\-\\.\\de]+/g,bw={position:\"absolute\",visibility:\"hidden\",display:\"block\"},bx=[\"Left\",\"Right\"],by=[\"Top\",\"Bottom\"],bz,bA,bB,bC=function(a,b){return b.toUpperCase()};f.fn.css=function(a,c){if(arguments.length===2&&c===b)return this;return f.access(this,a,c,!0,function(a,c,d){return d!==b?f.style(a,c,d):f.css(a,c)})},f.extend({cssHooks:{opacity:{get:function(a,b){if(b){var c=bz(a,\"opacity\",\"opacity\");return c===\"\"?\"1\":c}return a.style.opacity}}},cssNumber:{zIndex:!0,fontWeight:!0,opacity:!0,zoom:!0,lineHeight:!0,widows:!0,orphans:!0},cssProps:{\"float\":f.support.cssFloat?\"cssFloat\":\"styleFloat\"},style:function(a,c,d,e){if(!!a&&a.nodeType!==3&&a.nodeType!==8&&!!a.style){var g,h,i=f.camelCase(c),j=a.style,k=f.cssHooks[i];c=f.cssProps[i]||i;if(d===b){if(k&&\"get\"in k&&(g=k.get(a,!1,e))!==b)return g;return j[c]}h=typeof d;if(h===\"number\"&&isNaN(d)||d==null)return;h===\"string\"&&bu.test(d)&&(d=+d.replace(bv,\"\")+parseFloat(f.css(a,c))),h===\"number\"&&!f.cssNumber[i]&&(d+=\"px\");if(!k||!(\"set\"in k)||(d=k.set(a,d))!==b)try{j[c]=d}catch(l){}}},css:function(a,c,d){var e,g;c=f.camelCase(c),g=f.cssHooks[c],c=f.cssProps[c]||c,c===\"cssFloat\"&&(c=\"float\");if(g&&\"get\"in g&&(e=g.get(a,!0,d))!==b)return e;if(bz)return bz(a,c)},swap:function(a,b,c){var d={};for(var e in b)d[e]=a.style[e],a.style[e]=b[e];c.call(a);for(e in b)a.style[e]=d[e]},camelCase:function(a){return a.replace(bq,bC)}}),f.curCSS=f.css,f.each([\"height\",\"width\"],function(a,b){f.cssHooks[b]={get:function(a,c,d){var e;if(c){a.offsetWidth!==0?e=bD(a,b,d):f.swap(a,bw,function(){e=bD(a,b,d)});if(e<=0){e=bz(a,b,b),e===\"0px\"&&bB&&(e=bB(a,b,b));if(e!=null)return e===\"\"||e===\"auto\"?\"0px\":e}if(e<0||e==null){e=a.style[b];return e===\"\"||e===\"auto\"?\"0px\":e}return typeof e==\"string\"?e:e+\"px\"}},set:function(a,b){if(!bs.test(b))return b;b=parseFloat(b);if(b>=0)return b+\"px\"}}}),f.support.opacity||(f.cssHooks.opacity={get:function(a,b){return bp.test((b&&a.currentStyle?a.currentStyle.filter:a.style.filter)||\"\")?parseFloat(RegExp.$1)/100+\"\":b?\"1\":\"\"},set:function(a,b){var c=a.style,d=a.currentStyle;c.zoom=1;var e=f.isNaN(b)?\"\":\"alpha(opacity=\"+b*100+\")\",g=d&&d.filter||c.filter||\"\";c.filter=bo.test(g)?g.replace(bo,e):g+\" \"+e}}),f(function(){f.support.reliableMarginRight||(f.cssHooks.marginRight={get:function(a,b){var c;f.swap(a,{display:\"inline-block\"},function(){b?c=bz(a,\"margin-right\",\"marginRight\"):c=a.style.marginRight});return c}})}),c.defaultView&&c.defaultView.getComputedStyle&&(bA=function(a,c){var d,e,g;c=c.replace(br,\"-$1\").toLowerCase();if(!(e=a.ownerDocument.defaultView))return b;if(g=e.getComputedStyle(a,null))d=g.getPropertyValue(c),d===\"\"&&!f.contains(a.ownerDocument.documentElement,a)&&(d=f.style(a,c));return d}),c.documentElement.currentStyle&&(bB=function(a,b){var c,d=a.currentStyle&&a.currentStyle[b],e=a.runtimeStyle&&a.runtimeStyle[b],f=a.style;!bs.test(d)&&bt.test(d)&&(c=f.left,e&&(a.runtimeStyle.left=a.currentStyle.left),f.left=b===\"fontSize\"?\"1em\":d||0,d=f.pixelLeft+\"px\",f.left=c,e&&(a.runtimeStyle.left=e));return d===\"\"?\"auto\":d}),bz=bA||bB,f.expr&&f.expr.filters&&(f.expr.filters.hidden=function(a){var b=a.offsetWidth,c=a.offsetHeight;return b===0&&c===0||!f.support.reliableHiddenOffsets&&(a.style.display||f.css(a,\"display\"))===\"none\"},f.expr.filters.visible=function(a){return!f.expr.filters.hidden(a)});var bE=/%20/g,bF=/\\[\\]$/,bG=/\\r?\\n/g,bH=/#.*$/,bI=/^(.*?):[ \\t]*([^\\r\\n]*)\\r?$/mg,bJ=/^(?:color|date|datetime|email|hidden|month|number|password|range|search|tel|text|time|url|week)$/i,bK=/^(?:about|app|app\\-storage|.+\\-extension|file|widget):$/,bL=/^(?:GET|HEAD)$/,bM=/^\\/\\//,bN=/\\?/,bO=/<script\\b[^<]*(?:(?!<\\/script>)<[^<]*)*<\\/script>/gi,bP=/^(?:select|textarea)/i,bQ=/\\s+/,bR=/([?&])_=[^&]*/,bS=/^([\\w\\+\\.\\-]+:)(?:\\/\\/([^\\/?#:]*)(?::(\\d+))?)?/,bT=f.fn.load,bU={},bV={},bW,bX;try{bW=e.href}catch(bY){bW=c.createElement(\"a\"),bW.href=\"\",bW=bW.href}bX=bS.exec(bW.toLowerCase())||[],f.fn.extend({load:function(a,c,d){if(typeof a!=\"string\"&&bT)return bT.apply(this,arguments);if(!this.length)return this;var e=a.indexOf(\" \");if(e>=0){var g=a.slice(e,a.length);a=a.slice(0,e)}var h=\"GET\";c&&(f.isFunction(c)?(d=c,c=b):typeof c==\"object\"&&(c=f.param(c,f.ajaxSettings.traditional),h=\"POST\"));var i=this;f.ajax({url:a,type:h,dataType:\"html\",data:c,complete:function(a,b,c){c=a.responseText,a.isResolved()&&(a.done(function(a){c=a}),i.html(g?f(\"<div>\").append(c.replace(bO,\"\")).find(g):c)),d&&i.each(d,[c,b,a])}});return this},serialize:function(){return f.param(this.serializeArray())},serializeArray:function(){return this.map(function(){return this.elements?f.makeArray(this.elements):this}).filter(function(){return this.name&&!this.disabled&&(this.checked||bP.test(this.nodeName)||bJ.test(this.type))}).map(function(a,b){var c=f(this).val();return c==null?null:f.isArray(c)?f.map(c,function(a,c){return{name:b.name,value:a.replace(bG,\"\\r\\n\")}}):{name:b.name,value:c.replace(bG,\"\\r\\n\")}}).get()}}),f.each(\"ajaxStart ajaxStop ajaxComplete ajaxError ajaxSuccess ajaxSend\".split(\" \"),function(a,b){f.fn[b]=function(a){return this.bind(b,a)}}),f.each([\"get\",\"post\"],function(a,c){f[c]=function(a,d,e,g){f.isFunction(d)&&(g=g||e,e=d,d=b);return f.ajax({type:c,url:a,data:d,success:e,dataType:g})}}),f.extend({getScript:function(a,c){return f.get(a,b,c,\"script\")},getJSON:function(a,b,c){return f.get(a,b,c,\"json\")},ajaxSetup:function(a,b){b?f.extend(!0,a,f.ajaxSettings,b):(b=a,a=f.extend(!0,f.ajaxSettings,b));for(var c in{context:1,url:1})c in b?a[c]=b[c]:c in f.ajaxSettings&&(a[c]=f.ajaxSettings[c]);return a},ajaxSettings:{url:bW,isLocal:bK.test(bX[1]),global:!0,type:\"GET\",contentType:\"application/x-www-form-urlencoded\",processData:!0,async:!0,accepts:{xml:\"application/xml, text/xml\",html:\"text/html\",text:\"text/plain\",json:\"application/json, text/javascript\",\"*\":\"*/*\"},contents:{xml:/xml/,html:/html/,json:/json/},responseFields:{xml:\"responseXML\",text:\"responseText\"},converters:{\"* text\":a.String,\"text html\":!0,\"text json\":f.parseJSON,\"text xml\":f.parseXML}},ajaxPrefilter:bZ(bU),ajaxTransport:bZ(bV),ajax:function(a,c){function w(a,c,l,m){if(s!==2){s=2,q&&clearTimeout(q),p=b,n=m||\"\",v.readyState=a?4:0;var o,r,u,w=l?ca(d,v,l):b,x,y;if(a>=200&&a<300||a===304){if(d.ifModified){if(x=v.getResponseHeader(\"Last-Modified\"))f.lastModified[k]=x;if(y=v.getResponseHeader(\"Etag\"))f.etag[k]=y}if(a===304)c=\"notmodified\",o=!0;else try{r=cb(d,w),c=\"success\",o=!0}catch(z){c=\"parsererror\",u=z}}else{u=c;if(!c||a)c=\"error\",a<0&&(a=0)}v.status=a,v.statusText=c,o?h.resolveWith(e,[r,c,v]):h.rejectWith(e,[v,c,u]),v.statusCode(j),j=b,t&&g.trigger(\"ajax\"+(o?\"Success\":\"Error\"),[v,d,o?r:u]),i.resolveWith(e,[v,c]),t&&(g.trigger(\"ajaxComplete\",[v,d]),--f.active||f.event.trigger(\"ajaxStop\"))}}typeof a==\"object\"&&(c=a,a=b),c=c||{};var d=f.ajaxSetup({},c),e=d.context||d,g=e!==d&&(e.nodeType||e instanceof f)?f(e):f.event,h=f.Deferred(),i=f._Deferred(),j=d.statusCode||{},k,l={},m={},n,o,p,q,r,s=0,t,u,v={readyState:0,setRequestHeader:function(a,b){if(!s){var c=a.toLowerCase();a=m[c]=m[c]||a,l[a]=b}return this},getAllResponseHeaders:function(){return s===2?n:null},getResponseHeader:function(a){var c;if(s===2){if(!o){o={};while(c=bI.exec(n))o[c[1].toLowerCase()]=c[2]}c=o[a.toLowerCase()]}return c===b?null:c},overrideMimeType:function(a){s||(d.mimeType=a);return this},abort:function(a){a=a||\"abort\",p&&p.abort(a),w(0,a);return this}};h.promise(v),v.success=v.done,v.error=v.fail,v.complete=i.done,v.statusCode=function(a){if(a){var b;if(s<2)for(b in a)j[b]=[j[b],a[b]];else b=a[v.status],v.then(b,b)}return this},d.url=((a||d.url)+\"\").replace(bH,\"\").replace(bM,bX[1]+\"//\"),d.dataTypes=f.trim(d.dataType||\"*\").toLowerCase().split(bQ),d.crossDomain==null&&(r=bS.exec(d.url.toLowerCase()),d.crossDomain=!(!r||r[1]==bX[1]&&r[2]==bX[2]&&(r[3]||(r[1]===\"http:\"?80:443))==(bX[3]||(bX[1]===\"http:\"?80:443)))),d.data&&d.processData&&typeof d.data!=\"string\"&&(d.data=f.param(d.data,d.traditional)),b$(bU,d,c,v);if(s===2)return!1;t=d.global,d.type=d.type.toUpperCase(),d.hasContent=!bL.test(d.type),t&&f.active++===0&&f.event.trigger(\"ajaxStart\");if(!d.hasContent){d.data&&(d.url+=(bN.test(d.url)?\"&\":\"?\")+d.data),k=d.url;if(d.cache===!1){var x=f.now(),y=d.url.replace(bR,\"$1_=\"+x);d.url=y+(y===d.url?(bN.test(d.url)?\"&\":\"?\")+\"_=\"+x:\"\")}}(d.data&&d.hasContent&&d.contentType!==!1||c.contentType)&&v.setRequestHeader(\"Content-Type\",d.contentType),d.ifModified&&(k=k||d.url,f.lastModified[k]&&v.setRequestHeader(\"If-Modified-Since\",f.lastModified[k]),f.etag[k]&&v.setRequestHeader(\"If-None-Match\",f.etag[k])),v.setRequestHeader(\"Accept\",d.dataTypes[0]&&d.accepts[d.dataTypes[0]]?d.accepts[d.dataTypes[0]]+(d.dataTypes[0]!==\"*\"?\", */*; q=0.01\":\"\"):d.accepts[\"*\"]);for(u in d.headers)v.setRequestHeader(u,d.headers[u]);if(d.beforeSend&&(d.beforeSend.call(e,v,d)===!1||s===2)){v.abort();return!1}for(u in{success:1,error:1,complete:1})v[u](d[u]);p=b$(bV,d,c,v);if(!p)w(-1,\"No Transport\");else{v.readyState=1,t&&g.trigger(\"ajaxSend\",[v,d]),d.async&&d.timeout>0&&(q=setTimeout(function(){v.abort(\"timeout\")},d.timeout));try{s=1,p.send(l,w)}catch(z){status<2?w(-1,z):f.error(z)}}return v},param:function(a,c){var d=[],e=function(a,b){b=f.isFunction(b)?b():b,d[d.length]=encodeURIComponent(a)+\"=\"+encodeURIComponent(b)};c===b&&(c=f.ajaxSettings.traditional);if(f.isArray(a)||a.jquery&&!f.isPlainObject(a))f.each(a,function(){e(this.name,this.value)});else for(var g in a)b_(g,a[g],c,e);return d.join(\"&\").replace(bE,\"+\")}}),f.extend({active:0,lastModified:{},etag:{}});var cc=f.now(),cd=/(\\=)\\?(&|$)|\\?\\?/i;f.ajaxSetup({jsonp:\"callback\",jsonpCallback:function(){return f.expando+\"_\"+cc++}}),f.ajaxPrefilter(\"json jsonp\",function(b,c,d){var e=b.contentType===\"application/x-www-form-urlencoded\"&&typeof b.data==\"string\";if(b.dataTypes[0]===\"jsonp\"||b.jsonp!==!1&&(cd.test(b.url)||e&&cd.test(b.data))){var g,h=b.jsonpCallback=f.isFunction(b.jsonpCallback)?b.jsonpCallback():b.jsonpCallback,i=a[h],j=b.url,k=b.data,l=\"$1\"+h+\"$2\";b.jsonp!==!1&&(j=j.replace(cd,l),b.url===j&&(e&&(k=k.replace(cd,l)),b.data===k&&(j+=(/\\?/.test(j)?\"&\":\"?\")+b.jsonp+\"=\"+h))),b.url=j,b.data=k,a[h]=function(a){g=[a]},d.always(function(){a[h]=i,g&&f.isFunction(i)&&a[h](g[0])}),b.converters[\"script json\"]=function(){g||f.error(h+\" was not called\");return g[0]},b.dataTypes[0]=\"json\";return\"script\"}}),f.ajaxSetup({accepts:{script:\"text/javascript, application/javascript, application/ecmascript, application/x-ecmascript\"},contents:{script:/javascript|ecmascript/},converters:{\"text script\":function(a){f.globalEval(a);return a}}}),f.ajaxPrefilter(\"script\",function(a){a.cache===b&&(a.cache=!1),a.crossDomain&&(a.type=\"GET\",a.global=!1)}),f.ajaxTransport(\"script\",function(a){if(a.crossDomain){var d,e=c.head||c.getElementsByTagName(\"head\")[0]||c.documentElement;return{send:function(f,g){d=c.createElement(\"script\"),d.async=\"async\",a.scriptCharset&&(d.charset=a.scriptCharset),d.src=a.url,d.onload=d.onreadystatechange=function(a,c){if(c||!d.readyState||/loaded|complete/.test(d.readyState))d.onload=d.onreadystatechange=null,e&&d.parentNode&&e.removeChild(d),d=b,c||g(200,\"success\")},e.insertBefore(d,e.firstChild)},abort:function(){d&&d.onload(0,1)}}}});var ce=a.ActiveXObject?function(){for(var a in cg)cg[a](0,1)}:!1,cf=0,cg;f.ajaxSettings.xhr=a.ActiveXObject?function(){return!this.isLocal&&ch()||ci()}:ch,function(a){f.extend(f.support,{ajax:!!a,cors:!!a&&\"withCredentials\"in a})}(f.ajaxSettings.xhr()),f.support.ajax&&f.ajaxTransport(function(c){if(!c.crossDomain||f.support.cors){var d;return{send:function(e,g){var h=c.xhr(),i,j;c.username?h.open(c.type,c.url,c.async,c.username,c.password):h.open(c.type,c.url,c.async);if(c.xhrFields)for(j in c.xhrFields)h[j]=c.xhrFields[j];c.mimeType&&h.overrideMimeType&&h.overrideMimeType(c.mimeType),!c.crossDomain&&!e[\"X-Requested-With\"]&&(e[\"X-Requested-With\"]=\"XMLHttpRequest\");try{for(j in e)h.setRequestHeader(j,e[j])}catch(k){}h.send(c.hasContent&&c.data||null),d=function(a,e){var j,k,l,m,n;try{if(d&&(e||h.readyState===4)){d=b,i&&(h.onreadystatechange=f.noop,ce&&delete cg[i]);if(e)h.readyState!==4&&h.abort();else{j=h.status,l=h.getAllResponseHeaders(),m={},n=h.responseXML,n&&n.documentElement&&(m.xml=n),m.text=h.responseText;try{k=h.statusText}catch(o){k=\"\"}!j&&c.isLocal&&!c.crossDomain?j=m.text?200:404:j===1223&&(j=204)}}}catch(p){e||g(-1,p)}m&&g(j,k,m,l)},!c.async||h.readyState===4?d():(i=++cf,ce&&(cg||(cg={},f(a).unload(ce)),cg[i]=d),h.onreadystatechange=d)},abort:function(){d&&d(0,1)}}}});var cj={},ck,cl,cm=/^(?:toggle|show|hide)$/,cn=/^([+\\-]=)?([\\d+.\\-]+)([a-z%]*)$/i,co,cp=[[\"height\",\"marginTop\",\"marginBottom\",\"paddingTop\",\"paddingBottom\"],[\"width\",\"marginLeft\",\"marginRight\",\"paddingLeft\",\"paddingRight\"],[\"opacity\"]],cq,cr=a.webkitRequestAnimationFrame||a.mozRequestAnimationFrame||a.oRequestAnimationFrame;f.fn.extend({show:function(a,b,c){var d,e;if(a||a===0)return this.animate(cu(\"show\",3),a,b,c);for(var g=0,h=this.length;g<h;g++)d=this[g],d.style&&(e=d.style.display,!f._data(d,\"olddisplay\")&&e===\"none\"&&(e=d.style.display=\"\"),e===\"\"&&f.css(d,\"display\")===\"none\"&&f._data(d,\"olddisplay\",cv(d.nodeName)));for(g=0;g<h;g++){d=this[g];if(d.style){e=d.style.display;if(e===\"\"||e===\"none\")d.style.display=f._data(d,\"olddisplay\")||\"\"}}return this},hide:function(a,b,c){if(a||a===0)return this.animate(cu(\"hide\",3),a,b,c);for(var d=0,e=this.length;d<e;d++)if(this[d].style){var g=f.css(this[d],\"display\");g!==\"none\"&&!f._data(this[d],\"olddisplay\")&&f._data(this[d],\"olddisplay\",g)}for(d=0;d<e;d++)this[d].style&&(this[d].style.display=\"none\");return this},_toggle:f.fn.toggle,toggle:function(a,b,c){var d=typeof a==\"boolean\";f.isFunction(a)&&f.isFunction(b)?this._toggle.apply(this,arguments):a==null||d?this.each(function(){var b=d?a:f(this).is(\":hidden\");f(this)[b?\"show\":\"hide\"]()}):this.animate(cu(\"toggle\",3),a,b,c);return this},fadeTo:function(a,b,c,d){return this.filter(\":hidden\").css(\"opacity\",0).show().end().animate({opacity:b},a,c,d)},animate:function(a,b,c,d){var e=f.speed(b,c,d);if(f.isEmptyObject(a))return this.each(e.complete,[!1]);a=f.extend({},a);return this[e.queue===!1?\"each\":\"queue\"](function(){e.queue===!1&&f._mark(this);var b=f.extend({},e),c=this.nodeType===1,d=c&&f(this).is(\":hidden\"),g,h,i,j,k,l,m,n,o;b.animatedProperties={};for(i in a){g=f.camelCase(i),i!==g&&(a[g]=a[i],delete a[i]),h=a[g],f.isArray(h)?(b.animatedProperties[g]=h[1],h=a[g]=h[0]):b.animatedProperties[g]=b.specialEasing&&b.specialEasing[g]||b.easing||\"swing\";if(h===\"hide\"&&d||h===\"show\"&&!d)return b.complete.call(this);c&&(g===\"height\"||g===\"width\")&&(b.overflow=[this.style.overflow,this.style.overflowX,this.style.overflowY],f.css(this,\"display\")===\"inline\"&&f.css(this,\"float\")===\"none\"&&(f.support.inlineBlockNeedsLayout?(j=cv(this.nodeName),j===\"inline\"?this.style.display=\"inline-block\":(this.style.display=\"inline\",this.style.zoom=1)):this.style.display=\"inline-block\"))}b.overflow!=null&&(this.style.overflow=\"hidden\");for(i in a)k=new f.fx(this,b,i),h=a[i],cm.test(h)?k[h===\"toggle\"?d?\"show\":\"hide\":h]():(l=cn.exec(h),m=k.cur(),l?(n=parseFloat(l[2]),o=l[3]||(f.cssNumber[i]?\"\":\"px\"),o!==\"px\"&&(f.style(this,i,(n||1)+o),m=(n||1)/k.cur()*m,f.style(this,i,m+o)),l[1]&&(n=(l[1]===\"-=\"?-1:1)*n+m),k.custom(m,n,o)):k.custom(m,h,\"\"));return!0})},stop:function(a,b){a&&this.queue([]),this.each(function(){var a=f.timers,c=a.length;b||f._unmark(!0,this);while(c--)a[c].elem===this&&(b&&a[c](!0),a.splice(c,1))}),b||this.dequeue();return this}}),f.each({slideDown:cu(\"show\",1),slideUp:cu(\"hide\",1),slideToggle:cu(\"toggle\",1),fadeIn:{opacity:\"show\"},fadeOut:{opacity:\"hide\"},fadeToggle:{opacity:\"toggle\"}},function(a,b){f.fn[a]=function(a,c,d){return this.animate(b,a,c,d)}}),f.extend({speed:function(a,b,c){var d=a&&typeof a==\"object\"?f.extend({},a):{complete:c||!c&&b||f.isFunction(a)&&a,duration:a,easing:c&&b||b&&!f.isFunction(b)&&b};d.duration=f.fx.off?0:typeof d.duration==\"number\"?d.duration:d.duration in f.fx.speeds?f.fx.speeds[d.duration]:f.fx.speeds._default,d.old=d.complete,d.complete=function(a){d.queue!==!1?f.dequeue(this):a!==!1&&f._unmark(this),f.isFunction(d.old)&&d.old.call(this)};return d},easing:{linear:function(a,b,c,d){return c+d*a},swing:function(a,b,c,d){return(-Math.cos(a*Math.PI)/2+.5)*d+c}},timers:[],fx:function(a,b,c){this.options=b,this.elem=a,this.prop=c,b.orig=b.orig||{}}}),f.fx.prototype={update:function(){this.options.step&&this.options.step.call(this.elem,this.now,this),(f.fx.step[this.prop]||f.fx.step._default)(this)},cur:function(){if(this.elem[this.prop]!=null&&(!this.elem.style||this.elem.style[this.prop]==null))return this.elem[this.prop];var a,b=f.css(this.elem,this.prop);return isNaN(a=parseFloat(b))?!b||b===\"auto\"?0:b:a},custom:function(a,b,c){function h(a){return d.step(a)}var d=this,e=f.fx,g;this.startTime=cq||cs(),this.start=a,this.end=b,this.unit=c||this.unit||(f.cssNumber[this.prop]?\"\":\"px\"),this.now=this.start,this.pos=this.state=0,h.elem=this.elem,h()&&f.timers.push(h)&&!co&&(cr?(co=1,g=function(){co&&(cr(g),e.tick())},cr(g)):co=setInterval(e.tick,e.interval))},show:function(){this.options.orig[this.prop]=f.style(this.elem,this.prop),this.options.show=!0,this.custom(this.prop===\"width\"||this.prop===\"height\"?1:0,this.cur()),f(this.elem).show()},hide:function(){this.options.orig[this.prop]=f.style(this.elem,this.prop),this.options.hide=!0,this.custom(this.cur(),0)},step:function(a){var b=cq||cs(),c=!0,d=this.elem,e=this.options,g,h;if(a||b>=e.duration+this.startTime){this.now=this.end,this.pos=this.state=1,this.update(),e.animatedProperties[this.prop]=!0;for(g in e.animatedProperties)e.animatedProperties[g]!==!0&&(c=!1);if(c){e.overflow!=null&&!f.support.shrinkWrapBlocks&&f.each([\"\",\"X\",\"Y\"],function(a,b){d.style[\"overflow\"+b]=e.overflow[a]}),e.hide&&f(d).hide();if(e.hide||e.show)for(var i in e.animatedProperties)f.style(d,i,e.orig[i]);e.complete.call(d)}return!1}e.duration==Infinity?this.now=b:(h=b-this.startTime,this.state=h/e.duration,this.pos=f.easing[e.animatedProperties[this.prop]](this.state,h,0,1,e.duration),this.now=this.start+(this.end-this.start)*this.pos),this.update();return!0}},f.extend(f.fx,{tick:function(){for(var a=f.timers,b=0;b<a.length;++b)a[b]()||a.splice(b--,1);a.length||f.fx.stop()},interval:13,stop:function(){clearInterval(co),co=null},speeds:{slow:600,fast:200,_default:400},step:{opacity:function(a){f.style(a.elem,\"opacity\",a.now)},_default:function(a){a.elem.style&&a.elem.style[a.prop]!=null?a.elem.style[a.prop]=(a.prop===\"width\"||a.prop===\"height\"?Math.max(0,a.now):a.now)+a.unit:a.elem[a.prop]=a.now}}}),f.expr&&f.expr.filters&&(f.expr.filters.animated=function(a){return f.grep(f.timers,function(b){return a===b.elem}).length});var cw=/^t(?:able|d|h)$/i,cx=/^(?:body|html)$/i;\"getBoundingClientRect\"in c.documentElement?f.fn.offset=function(a){var b=this[0],c;if(a)return this.each(function(b){f.offset.setOffset(this,a,b)});if(!b||!b.ownerDocument)return null;if(b===b.ownerDocument.body)return f.offset.bodyOffset(b);try{c=b.getBoundingClientRect()}catch(d){}var e=b.ownerDocument,g=e.documentElement;if(!c||!f.contains(g,b))return c?{top:c.top,left:c.left}:{top:0,left:0};var h=e.body,i=cy(e),j=g.clientTop||h.clientTop||0,k=g.clientLeft||h.clientLeft||0,l=i.pageYOffset||f.support.boxModel&&g.scrollTop||h.scrollTop,m=i.pageXOffset||f.support.boxModel&&g.scrollLeft||h.scrollLeft,n=c.top+l-j,o=c.left+m-k;return{top:n,left:o}}:f.fn.offset=function(a){var b=this[0];if(a)return this.each(function(b){f.offset.setOffset(this,a,b)});if(!b||!b.ownerDocument)return null;if(b===b.ownerDocument.body)return f.offset.bodyOffset(b);f.offset.initialize();var c,d=b.offsetParent,e=b,g=b.ownerDocument,h=g.documentElement,i=g.body,j=g.defaultView,k=j?j.getComputedStyle(b,null):b.currentStyle,l=b.offsetTop,m=b.offsetLeft;while((b=b.parentNode)&&b!==i&&b!==h){if(f.offset.supportsFixedPosition&&k.position===\"fixed\")break;c=j?j.getComputedStyle(b,null):b.currentStyle,l-=b.scrollTop,m-=b.scrollLeft,b===d&&(l+=b.offsetTop,m+=b.offsetLeft,f.offset.doesNotAddBorder&&(!f.offset.doesAddBorderForTableAndCells||!cw.test(b.nodeName))&&(l+=parseFloat(c.borderTopWidth)||0,m+=parseFloat(c.borderLeftWidth)||0),e=d,d=b.offsetParent),f.offset.subtractsBorderForOverflowNotVisible&&c.overflow!==\"visible\"&&(l+=parseFloat(c.borderTopWidth)||0,m+=parseFloat(c.borderLeftWidth)||0),k=c}if(k.position===\"relative\"||k.position===\"static\")l+=i.offsetTop,m+=i.offsetLeft;f.offset.supportsFixedPosition&&k.position===\"fixed\"&&(l+=Math.max(h.scrollTop,i.scrollTop),m+=Math.max(h.scrollLeft,i.scrollLeft));return{top:l,left:m}},f.offset={initialize:function(){var a=c.body,b=c.createElement(\"div\"),d,e,g,h,i=parseFloat(f.css(a,\"marginTop\"))||0,j=\"<div style='position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;'><div></div></div><table style='position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;' cellpadding='0' cellspacing='0'><tr><td></td></tr></table>\";f.extend(b.style,{position:\"absolute\",top:0,left:0,margin:0,border:0,width:\"1px\",height:\"1px\",visibility:\"hidden\"}),b.innerHTML=j,a.insertBefore(b,a.firstChild),d=b.firstChild,e=d.firstChild,h=d.nextSibling.firstChild.firstChild,this.doesNotAddBorder=e.offsetTop!==5,this.doesAddBorderForTableAndCells=h.offsetTop===5,e.style.position=\"fixed\",e.style.top=\"20px\",this.supportsFixedPosition=e.offsetTop===20||e.offsetTop===15,e.style.position=e.style.top=\"\",d.style.overflow=\"hidden\",d.style.position=\"relative\",this.subtractsBorderForOverflowNotVisible=e.offsetTop===-5,this.doesNotIncludeMarginInBodyOffset=a.offsetTop!==i,a.removeChild(b),f.offset.initialize=f.noop},bodyOffset:function(a){var b=a.offsetTop,c=a.offsetLeft;f.offset.initialize(),f.offset.doesNotIncludeMarginInBodyOffset&&(b+=parseFloat(f.css(a,\"marginTop\"))||0,c+=parseFloat(f.css(a,\"marginLeft\"))||0);return{top:b,left:c}},setOffset:function(a,b,c){var d=f.css(a,\"position\");d===\"static\"&&(a.style.position=\"relative\");var e=f(a),g=e.offset(),h=f.css(a,\"top\"),i=f.css(a,\"left\"),j=(d===\"absolute\"||d===\"fixed\")&&f.inArray(\"auto\",[h,i])>-1,k={},l={},m,n;j?(l=e.position(),m=l.top,n=l.left):(m=parseFloat(h)||0,n=parseFloat(i)||0),f.isFunction(b)&&(b=b.call(a,c,g)),b.top!=null&&(k.top=b.top-g.top+m),b.left!=null&&(k.left=b.left-g.left+n),\"using\"in b?b.using.call(a,k):e.css(k)}},f.fn.extend({position:function(){if(!this[0])return null;var a=this[0],b=this.offsetParent(),c=this.offset(),d=cx.test(b[0].nodeName)?{top:0,left:0}:b.offset();c.top-=parseFloat(f.css(a,\"marginTop\"))||0,c.left-=parseFloat(f.css(a,\"marginLeft\"))||0,d.top+=parseFloat(f.css(b[0],\"borderTopWidth\"))||0,d.left+=parseFloat(f.css(b[0],\"borderLeftWidth\"))||0;return{top:c.top-d.top,left:c.left-d.left}},offsetParent:function(){return this.map(function(){var a=this.offsetParent||c.body;while(a&&!cx.test(a.nodeName)&&f.css(a,\"position\")===\"static\")a=a.offsetParent;return a})}}),f.each([\"Left\",\"Top\"],function(a,c){var d=\"scroll\"+c;f.fn[d]=function(c){var e,g;if(c===b){e=this[0];if(!e)return null;g=cy(e);return g?\"pageXOffset\"in g?g[a?\"pageYOffset\":\"pageXOffset\"]:f.support.boxModel&&g.document.documentElement[d]||g.document.body[d]:e[d]}return this.each(function(){g=cy(this),g?g.scrollTo(a?f(g).scrollLeft():c,a?c:f(g).scrollTop()):this[d]=c})}}),f.each([\"Height\",\"Width\"],function(a,c){var d=c.toLowerCase();f.fn[\"inner\"+c]=function(){return this[0]?parseFloat(f.css(this[0],d,\"padding\")):null},f.fn[\"outer\"+c]=function(a){return this[0]?parseFloat(f.css(this[0],d,a?\"margin\":\"border\")):null},f.fn[d]=function(a){var e=this[0];if(!e)return a==null?null:this;if(f.isFunction(a))return this.each(function(b){var c=f(this);c[d](a.call(this,b,c[d]()))});if(f.isWindow(e)){var g=e.document.documentElement[\"client\"+c];return e.document.compatMode===\"CSS1Compat\"&&g||e.document.body[\"client\"+c]||g}if(e.nodeType===9)return Math.max(e.documentElement[\"client\"+c],e.body[\"scroll\"+c],e.documentElement[\"scroll\"+c],e.body[\"offset\"+c],e.documentElement[\"offset\"+c]);if(a===b){var h=f.css(e,d),i=parseFloat(h);return f.isNaN(i)?h:i}return this.css(d,typeof a==\"string\"?a:a+\"px\")}}),a.jQuery=a.$=f})(window);";
				#endregion
			}
		}

		/// <summary>
		/// 获取 1.4.2 版本的 jQuery 脚本官方地址.
		/// </summary>
		public static string Script_1_4_2_Url
		{
			get { return "http://code.jquery.com/jquery-1.4.2.min.js"; }
		}

		/// <summary>
		/// 获取 1.4.1 版本的 jQuery 脚本 zoyobar.googlecode.com 地址.
		/// </summary>
		public static string Script_1_4_1_Url
		{
			get { return "http://zoyobar.googlecode.com/files/jquery-1.4.1.min.js"; }
		}

		#region " 构造 "

		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( JQuery jQuery )
		{ return new JQuery ( jQuery ); }

		/// <summary>
		/// 创建使用别名的空的 JQuery.
		/// </summary>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( )
		{ return Create ( null, null, true ); }
		/// <summary>
		/// 创建空的 JQuery.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( bool isAlias )
		{ return Create ( null, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI )
		{ return Create ( expressionI, null, true ); }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, bool isAlias )
		{ return Create ( expressionI, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, string expressionII )
		{ return Create ( expressionI, expressionII, true ); }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, string expressionII, bool isAlias )
		{ return new JQuery ( expressionI, expressionII, isAlias ); }

		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( bool isInstance, bool isAlias )
		{ return new JQuery ( isInstance, isAlias ); }


		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		public JQuery ( JQuery jQuery )
			: base ( ScriptType.JavaScript )
		{

			if ( null == jQuery )
				return;

			this.code = jQuery.code;
		}

		/// <summary>
		/// 创建使用别名的空的 JQuery.
		/// </summary>
		public JQuery ( )
			: this ( null, null, true )
		{ }
		/// <summary>
		/// 创建空的 JQuery.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( bool isAlias )
			: this ( null, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		public JQuery ( string expressionI )
			: this ( expressionI, null, true )
		{ }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( string expressionI, bool isAlias )
			: this ( expressionI, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		public JQuery ( string expressionI, string expressionII )
			: this ( expressionI, expressionII, true )
		{ }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( string expressionI, string expressionII, bool isAlias )
			: base ( ScriptType.JavaScript )
		{

			string constructor;

			if ( isAlias )
				constructor = "$";
			else
				constructor = "jQuery";

			if ( string.IsNullOrEmpty ( expressionI ) )
				this.AppendCode ( string.Format ( "{0}()", constructor ) );
			else
				if ( string.IsNullOrEmpty ( expressionII ) )
					this.AppendCode ( string.Format ( "{0}({1})", constructor, expressionI ) );
				else
					this.AppendCode ( string.Format ( "{0}({1}, {2})", constructor, expressionI, expressionII ) );

		}

		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( bool isInstance, bool isAlias )
			: base ( ScriptType.JavaScript )
		{

			if ( isAlias )
				this.AppendCode ( "$" );
			else
				this.AppendCode ( "jQuery" );

			if ( isInstance )
				this.AppendCode ( "()" );

		}

		#endregion

		#region " 基本 "

		/// <summary>
		/// 创建当前 JQuery 的副本, 拥有相同的 Code 属性.
		/// </summary>
		/// <returns>JQuery 的副本.</returns>
		public JQuery Copy ( )
		{ return new JQuery ( this ); }

		/// <summary>
		/// 添加语句的结尾符号.
		/// </summary>
		/// <returns>添加结尾符号后的 JQuery.</returns>
		public JQuery EndLine ( )
		{
			this.AppendCode ( this.EndOfLine );
			return this;
		}

		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName )
		{ return this.Execute ( methodName, null, null, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI )
		{ return this.Execute ( methodName, expressionI, null, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII )
		{ return this.Execute ( methodName, expressionI, expressionII, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <param name="expressionIII">方法的第 3 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( methodName, expressionI, expressionII, expressionIII, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <param name="expressionIII">方法的第 3 个参数的表达式.</param>
		/// <param name="expressionIV">方法的第 4 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII, string expressionIII, string expressionIV )
		{

			if ( string.IsNullOrEmpty ( methodName ) )
				return this;

			if ( string.IsNullOrEmpty ( expressionI ) )
				this.AppendCode ( string.Format ( ".{0}()", methodName ) );
			else
				if ( string.IsNullOrEmpty ( expressionII ) )
					this.AppendCode ( string.Format ( ".{0}({1})", methodName, expressionI ) );
				else
					if ( string.IsNullOrEmpty ( expressionIII ) )
						this.AppendCode ( string.Format ( ".{0}({1}, {2})", methodName, expressionI, expressionII ) );
					else
						if ( string.IsNullOrEmpty ( expressionIV ) )
							this.AppendCode ( string.Format ( ".{0}({1}, {2}, {3})", methodName, expressionI, expressionII, expressionIII ) );
						else
							this.AppendCode ( string.Format ( ".{0}({1}, {2}, {3}, {4})", methodName, expressionI, expressionII, expressionIII, expressionIV ) );

			return this;
		}

		#endregion

		#region " 方法 A "

		/// <summary>
		/// 合并新的元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 或者是一段 html 代码, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Add ( string expressionI )
		{ return this.Add ( expressionI, null ); }
		/// <summary>
		/// 合并新的元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">选择器, 比如: "'body table .red'".</param>
		/// <param name="expressionII">document 元素, 指定选择器搜索的文档.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Add ( string expressionI, string expressionII )
		{ return this.Execute ( "add", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的包含的页面元素添加新的样式.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 可以是多个样式的名称, 比如: "'box red'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AddClass ( string expression )
		{ return this.Execute ( "addClass", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i) { return this.className + i.toString;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery After ( string expressionI )
		{ return this.After ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery After ( string expressionI, string expressionII )
		{ return this.Execute ( "after", expressionI, expressionII ); }

		/// <summary>
		/// 执行 ajax 操作, 并返回 jqXHR javascript 对象.
		/// </summary>
		/// <param name="expressionI">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ajax ( string expressionI )
		{ return this.Ajax ( expressionI, null ); }
		/// <summary>
		/// 执行 ajax 操作, 并返回 jqXHR javascript 对象. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "'js/test.js'".</param>
		/// <param name="expressionII">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ajax ( string expressionI, string expressionII )
		{ return this.Execute ( "ajax", expressionI, expressionII ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求完成的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxComplete ( string expression )
		{ return this.Execute ( "ajaxComplete", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求失败的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, g, a, t){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxError ( string expression )
		{ return this.Execute ( "ajaxError", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求发出的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSend ( string expression )
		{ return this.Execute ( "ajaxSend", expression ); }

		/// <summary>
		/// 设置之后 ajax 操作的默认设置. (需要 1.1 版本以上)
		/// </summary>
		/// <param name="expression">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSetup ( string expression )
		{ return this.Execute ( "ajaxSetup", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加第一个 ajax 请求的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxStart ( string expression )
		{ return this.Execute ( "ajaxStart", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加所有 ajax 请求结束的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxStop ( string expression )
		{ return this.Execute ( "ajaxStop", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加所有 ajax 请求成功的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSuccess ( string expression )
		{ return this.Execute ( "ajaxSuccess", expression ); }

		/// <summary>
		/// 合并 jQuery 匹配到的上一批元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AndSelf ( )
		{ return this.Execute ( "andSelf" ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i, h) { return 'old html is ' + h;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Append ( string expressionI )
		{ return this.Append ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Append ( string expressionI, string expressionII )
		{ return this.Execute ( "append", expressionI, expressionII ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素追加到指定目标之后.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'.red'", 可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AppendTo ( string expression )
		{ return this.Execute ( "appendTo", expression ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的属性, 或者设置所有元素的多个属性.
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'", 也可以是属性集合, 比如: "{type: 'text', title: 'test'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Attr ( string expressionI )
		{ return this.Attr ( expressionI, null ); }
		/// <summary>
		/// 设置 jQuery 中元素的属性.
		/// </summary>
		/// <param name="expressionI">可以是属性名称, 比如: "'title'".</param>
		/// <param name="expressionII">返回属性名称的表达式, 比如: "'just test'", 或者返回属性值的函数, 比如: "function(i, a){ return 'my_' + i.toString(); }". (如果使用函数需要 1.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Attr ( string expressionI, string expressionII )
		{ return this.Execute ( "attr", expressionI, expressionII ); }

		#endregion

		#region " 方法 B "

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i) { return this.className + i.toString;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Before ( string expressionI )
		{ return this.Before ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Before ( string expressionI, string expressionII )
		{ return this.Execute ( "before", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加事件. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI )
		{ return this.Bind ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示停止事件的冒泡. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI, string expressionII )
		{ return this.Bind ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示停止事件的冒泡. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "bind", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加失去焦点事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( )
		{ return this.Blur ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加失去焦点的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( string expressionI )
		{ return this.Blur ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加失去焦点的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( string expressionI, string expressionII )
		{ return this.Execute ( "blur", expressionI, expressionII ); }

		#endregion

		#region " 方法 C "

		/// <summary>
		/// 触发 jQuery 中的元素的添加数据改变事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( )
		{ return this.Change ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加数据改变的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( string expressionI )
		{ return this.Change ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加数据改变的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( string expressionI, string expressionII )
		{ return this.Execute ( "change", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级子元素, 不包含文本元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Children ( )
		{ return this.Children ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素中符合选择器的第一级子元素, 不包含文本元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Children ( string expression )
		{ return this.Execute ( "children", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加单击事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( )
		{ return this.Click ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加单击的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( string expressionI )
		{ return this.Click ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加单击的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( string expressionI, string expressionII )
		{ return this.Execute ( "click", expressionI, expressionII ); }

		/// <summary>
		/// 复制当前 jQuery 中包含的元素, 对于是否复制元素的事件和数据, 1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false, 不复制元素的子元素的事件和数据.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( )
		{ return this.Clone ( null, null ); }
		/// <summary>
		/// 复制当前 jQuery 中包含的元素, 不复制元素的子元素的事件和数据.
		/// </summary>
		/// <param name="expressionI">一个布尔表达式, 比如: "true", 表示是否复制元素的事件和数据. (1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( string expressionI )
		{ return this.Clone ( expressionI, null ); }
		/// <summary>
		/// 复制当前 jQuery 中包含的元素. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expressionI">一个布尔表达式, 比如: "true", 表示是否复制元素的事件和数据. (1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false)</param>
		/// <param name="expressionII">一个布尔表达式, 比如: "true", 表示是否复制元素的子元素的事件和数据.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( string expressionI, string expressionII )
		{ return this.Execute ( "clone", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中元素的第一个符合选择器的父元素, 从当前 jQuery 元素开始搜索. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是一个选择器, 比如: "'strong'", 或者选择器的数组, 比如: "['body', 'ul']", 也可以是一个 jQuery, 比如: "__myJQuery", 也可以是 DOM 元素, 比如: "document.getElementById('name')". (如果使用数组需要 1.4 版本以上, 如果使用 jQuery 或者 DOM 元素需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Closest ( string expressionI )
		{ return this.Closest ( expressionI, null ); }
		/// <summary>
		/// 获取当前 jQuery 中元素的第一个符合选择器的父元素, 从当前 jQuery 元素开始搜索. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是一个选择器, 比如: "'strong'", 或者选择器的数组, 比如: "['body', 'ul']".</param>
		/// <param name="expressionII">返回页面元素的表达式, 指定搜索的位置.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Closest ( string expressionI, string expressionII )
		{ return this.Execute ( "closest", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有子元素, 包含文本和注释. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Contents ( )
		{ return this.Execute ( "contents" ); }

		/// <summary>
		/// 获取当前 jQuery 中第一个元素的样式或者设置所有元素的多个样式.
		/// </summary>
		/// <param name="expressionI">返回要获取的样式名称的表达式, 比如: "'color'", 或者要设置的多个样式, 比如: "{'background-color' : '#ddd', 'font-weight' : '', 'color' : 'rgb(0,40,244)'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Css ( string expressionI )
		{ return this.Css ( expressionI, null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的样式.
		/// </summary>
		/// <param name="expressionI">返回要设置的样式名称的表达式, 比如: "'color'".</param>
		/// <param name="expressionII">返回样式值的表达式, 比如: "'red'", 或者返回值的函数, 比如: "function(i, v){return i.toString() + 'px';}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Css ( string expressionI, string expressionII )
		{ return this.Execute ( "css", expressionI, expressionII ); }

		/// <summary>
		/// 获得 jQuery 的 cssHooks 属性, 用于设置新的样式规则. (需要 1.4.3 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery CssHooks ( )
		{
			this.AppendCode ( ".cssHooks" );
			return this;
		}

		#endregion

		#region " 方法 D "

		/// <summary>
		/// 触发 jQuery 中的元素的添加双击事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( )
		{ return this.Dblclick ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加双击的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( string expressionI )
		{ return this.Dblclick ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加双击的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( string expressionI, string expressionII )
		{ return this.Execute ( "dblclick", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Delegate ( string expressionI, string expressionII, string expressionIII )
		{ return this.Delegate ( expressionI, expressionII, expressionIII, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIV">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Delegate ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "delegate", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 将当前 jQuery 中的元素从页面中删除, 但仍保存在 jQuery 中. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Detach ( )
		{ return this.Detach ( null ); }
		/// <summary>
		/// 将当前 jQuery 中符合选择器的元素从页面中删除, 但仍保存在 jQuery 中. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择删除元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Detach ( string expression )
		{ return this.Execute ( "detach", expression ); }

		/// <summary>
		/// 取消所有使用 live 方法绑定的事件. (需要 1.4.1 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( )
		{ return this.Die ( null, null ); }
		/// <summary>
		/// 取消使用 live 方法绑定的指定事件. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( string expressionI )
		{ return this.Die ( expressionI, null ); }
		/// <summary>
		/// 取消使用 live 方法绑定的指定事件的某个函数. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "clickfunction", 将取消函数作为事件的处理.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( string expressionI, string expressionII )
		{ return this.Execute ( "die", expressionI, expressionII ); }

		#endregion

		#region " 方法 E "

		/// <summary>
		/// 对当前 jQuery 中包含的元素执行对应的 javascript 函数.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(i, e){ $(e).html(i.toString()); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Each ( string expression )
		{ return this.Execute ( "each", expression ); }

		/// <summary>
		/// 将当前 jQuery 中元素的子元素从页面中删除, 包含文本.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Empty ( )
		{ return this.Execute ( "empty" ); }

		/// <summary>
		/// 将最初搜索的一批元素恢复到 jQuery 中. 
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery End ( )
		{ return this.Execute ( "end" ); }

		/// <summary>
		/// 获取当前 jQuery 中指定索引的元素. (需要 1.1.2 版本以上)
		/// </summary>
		/// <param name="expression">返回元素的索引值的表达式, 比如: "0", 如果是 "-1", 则表示最后一个元素. (如果使用负数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Eq ( string expression )
		{ return this.Execute ( "eq", expression ); }

		/// <summary>
		/// 为 jQuery 中的元素添加处理错误的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Error ( string expressionI )
		{ return this.Error ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加处理错误的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Error ( string expressionI, string expressionII )
		{ return this.Execute ( "error", expressionI, expressionII ); }

		#endregion

		#region " 方法 F "

		/// <summary>
		/// 选择当前 jQuery 中符合选择器, 筛选函数, 元素或者 jQuery 中元素的元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')", 或者是另一个 jQuery 对象, 比如: "$('#li64')". (如果元素或者 jQuery 需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Filter ( string expression )
		{ return this.Execute ( "filter", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中包含元素的符合选择器的子元素.
		/// </summary>
		/// <param name="expression">用于筛选子元素的选择器, 比如: "'strong'", 也可以是一个 jQuery, 比如: "__myJQuery", 也可以是 DOM 元素, 比如: "document.getElementById('name')". (如果使用 jQuery 或者 DOM 元素需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Find ( string expression )
		{ return this.Execute ( "find", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中第一个元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery First ( )
		{ return this.Execute ( "first" ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加获取焦点事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( )
		{ return this.Focus ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取焦点的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( string expressionI )
		{ return this.Focus ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取焦点的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( string expressionI, string expressionII )
		{ return this.Execute ( "focus", expressionI, expressionII ); }

		#endregion

		#region " 方法 G "

		/// <summary>
		/// 使用 GET 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Get ( string expressionI )
		{ return this.Get ( expressionI, null, null, null ); }
		/// <summary>
		/// 使用 GET 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <param name="expressionIV">指定获取数据类型的字符串, "'xml'", "'json'", "'script'", "'html'" 中的一种.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Get ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "get", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 使用 GET 获取请求 json 数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "test.aspx".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetJSON ( string expressionI )
		{ return this.GetJSON ( expressionI, null, null ); }
		/// <summary>
		/// 使用 GET 获取请求 json 数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "test.aspx".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetJSON ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "getJSON", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 使用 GET 获取请求 javascript 脚本并执行.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetScript ( string expressionI )
		{ return this.GetScript ( expressionI, null ); }
		/// <summary>
		/// 使用 GET 获取请求 javascript 脚本并执行.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回成功时回调函数的表达式, 比如: "function(d, t){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetScript ( string expressionI, string expressionII )
		{ return this.Execute ( "getScript", expressionI, expressionII ); }

		#endregion

		#region " 方法 H "

		/// <summary>
		/// 选择 jQuery 中元素, 其子元素符合选择器或者元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 或者是元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Has ( string expression )
		{ return this.Execute ( "has", expression ); }

		/// <summary>
		/// 判断样式是否存在.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 比如: "'box'", 将判断样式是否存在.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery HasClass ( string expression )
		{ return this.Execute ( "hasClass", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Height ( )
		{ return this.Height ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的高度.
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110", 或者一个返回数值的函数, 比如: "function(i, h){ return i + h; }". (如果使用函数需要 1.4.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Height ( string expression )
		{ return this.Execute ( "height", expression ); }

		/// <summary>
		/// 是否让 ready 等待执行. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expression">返回布尔值的表达式, 比如: "true", 表示阻止 ready 执行.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery HoldReady ( string expression )
		{ return this.Execute ( "holdReady", expression ); }

		/// <summary>
		/// 设置当前 jQuery 元素的鼠标进入和离开的事件. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标进入和离开的共同事件.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Hover ( string expressionI )
		{ return this.Hover ( expressionI, null ); }
		/// <summary>
		/// 设置当前 jQuery 元素的鼠标进入和离开的事件. (需要 1.4.1 版本以上)
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标进入事件.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标离开事件.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Hover ( string expressionI, string expressionII )
		{ return this.Execute ( "hover", expressionI, expressionII ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 innerHTML 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Html ( )
		{ return this.Html ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含元素的 innerHTML 属性.
		/// </summary>
		/// <param name="expression">返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 或者返回 html 代码的函数, 比如: "function(i, h){ return '&lt;stong&gt;&lt;/stong&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Html ( string expression )
		{ return this.Execute ( "html", expression ); }

		#endregion

		#region " 方法 I "

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 不包含边框. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InnerHeight ( )
		{ return this.Execute ( "innerHeight" ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 不包含边框. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InnerWidth ( )
		{ return this.Execute ( "innerWidth" ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素添加到目标之后作为兄弟元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InsertAfter ( string expression )
		{ return this.Execute ( "insertAfter", expression ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素添加到目标之前作为兄弟元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InsertBefore ( string expression )
		{ return this.Execute ( "insertBefore", expression ); }

		/// <summary>
		///判断当前 jQuery 元素是否符合选择器, 如果至少一个符合时, 将在 javascript 中返回 true.
		/// </summary>
		/// <param name="expression">选择器, 比如: "'.box'", 也可以是一个 jQuery, 比如: "__myJQuery", 也可以是 DOM 元素, 比如: "document.getElementById('name')". (如果使用 jQuery 或者 DOM 元素需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Is ( string expression )
		{ return this.Execute ( "is", expression ); }

		#endregion

		#region " 方法 K "

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘按下事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( )
		{ return this.Keydown ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按下的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( string expressionI )
		{ return this.Keydown ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按下的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( string expressionI, string expressionII )
		{ return this.Execute ( "keydown", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘按住事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( )
		{ return this.Keypress ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按住的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( string expressionI )
		{ return this.Keypress ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按住的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( string expressionI, string expressionII )
		{ return this.Execute ( "keypress", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘松开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( )
		{ return this.Keyup ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘松开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( string expressionI )
		{ return this.Keyup ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘松开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( string expressionI, string expressionII )
		{ return this.Execute ( "keyup", expressionI, expressionII ); }

		#endregion

		#region " 方法 L "

		/// <summary>
		/// 选择当前 jQuery 中最后一个元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Last ( )
		{ return this.Execute ( "last" ); }

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Length ( )
		{
			this.AppendCode ( ".length" );
			return this;
		}

		/// <summary>
		/// 为 jQuery 中的元素添加事件, 可以用 die 方法取消. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI )
		{ return this.Live ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件, 可以用 die 方法取消. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI, string expressionII )
		{ return this.Live ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件, 可以用 die 方法取消. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "live", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加载入的事件, 或者使用 GET 请求 html 代码.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 或者返回地址的表达式, 比如: "'test.html'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI )
		{ return this.Load ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加载入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI, string expressionII )
		{ return this.Load ( expressionI, expressionII, null ); }
		/// <summary>
		/// 使用 GET 请求 html 代码.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "'test.html'".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回完成时回调函数的表达式, 比如: "function(r, t, x){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "load", expressionI, expressionII, expressionIII ); }

		#endregion

		#region " 方法 M "

		/// <summary>
		/// 对当前 jQuery 中的元素执行函数, 并将执行的结果返回为一个 javascript 数组. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expressionI">返回调用函数的表达式, 比如: "function(i, o){ return 'my_' + i.toString(); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Map ( string expressionI )
		{ return this.Map ( expressionI ); }
		/// <summary>
		/// 对一个数组或者对象执行函数.
		/// </summary>
		/// <param name="expressionI">返回对象或者数组的表达式, 比如: "['a', 'b', 'c']". (如果使用对象元素需要 1.6 版本以上)</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(elementOfArray, indexInArray){}" 或者 "function(value, indexOrKey){}". (如果使用后一个函数需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Map ( string expressionI, string expressionII )
		{ return this.Execute ( "map", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标按下事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( )
		{ return this.Mousedown ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标按下的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( string expressionI )
		{ return this.Mousedown ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标按下的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( string expressionI, string expressionII )
		{ return this.Execute ( "mousedown", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标进入事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( )
		{ return this.Mouseenter ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标进入的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( string expressionI )
		{ return this.Mouseenter ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标进入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseenter", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标离开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( )
		{ return this.Mouseleave ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标离开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( string expressionI )
		{ return this.Mouseleave ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标离开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseleave", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑动事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( )
		{ return this.Mousemove ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑动的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( string expressionI )
		{ return this.Mousemove ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑动的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( string expressionI, string expressionII )
		{ return this.Execute ( "mousemove", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑出事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( )
		{ return this.Mouseout ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑出的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( string expressionI )
		{ return this.Mouseout ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑出的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseout", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑入事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( )
		{ return this.Mouseover ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑入的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( string expressionI )
		{ return this.Mouseover ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseover", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标松开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( )
		{ return this.Mouseup ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标松开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( string expressionI )
		{ return this.Mouseup ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标松开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseup", expressionI, expressionII ); }

		#endregion

		#region " 方法 N "

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的第一个兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Next ( )
		{ return this.Next ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的符合选择器的第一个兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Next ( string expression )
		{ return this.Execute ( "next", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextAll ( )
		{ return this.NextAll ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的符合选择器的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextAll ( string expression )
		{ return this.Execute ( "nextAll", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素向后的所有兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextUntil ( )
		{ return this.NextUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素向后的所有兄弟元素, 出现符合选择器的兄弟元素为止, 不包含此符合选择器的兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextUntil ( string expression )
		{ return this.Execute ( "nextUntil", expression ); }

		/// <summary>
		/// 卸载 jQuery 在页面中 $ 的定义.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NoConflict ( )
		{ return this.NoConflict ( null ); }
		/// <summary>
		/// 卸载 jQuery 在页面中 $ 的定义.
		/// </summary>
		/// <param name="expression">一个返回布尔值的表达式, 比如: "true", "1 > 2" 或者 "isOK", 其中 isOK 是 javascript 脚本中的变量, 如果表达式为 true, 则卸载 $ 和 jQuery 的定义, 否则只卸载 $ 的定义.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NoConflict ( string expression )
		{ return this.Execute ( "noConflict", expression ); }

		/// <summary>
		/// 去除当前 jQuery 中符合条件的元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Not ( string expression )
		{ return this.Execute ( "not", expression ); }

		#endregion

		#region " 方法 O "

		/// <summary>
		/// 获取当前 jQuery 中第一个元素相对于 document 的位置, 返回值保存一个拥有 top 和 left 属性的对象中.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Offset ( )
		{ return this.Offset ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素相对于 document 的位置.
		/// </summary>
		/// <param name="expression">返回具有 top 和 left 属性的对象的表达式, 比如: "{ top: 10, left: 20 }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Offset ( string expression )
		{ return this.Execute ( "offset", expression ); }

		/// <summary>
		/// 获取 jQuery 中包含元素的第一个设置了 position 样式为 relative, absolute 或者 fixed 的父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OffsetParent ( )
		{ return this.Execute ( "offsetParent" ); }

		/// <summary>
		/// 为 jQuery 中的元素添加只执行一次的事件. (需要 1.1 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery One ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "one", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 包含边框, padding. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterHeight ( )
		{ return this.OuterHeight ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 包含边框, padding, 可选 margin. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个布尔表达式, 比如: "true", 指定是否包含 margin, 默认为 false.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterHeight ( string expression )
		{ return this.Execute ( "outerHeight", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 包含边框, padding. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterWidth ( )
		{ return this.OuterWidth ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 包含边框, padding, 可选 margin. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个布尔表达式, 比如: "true", 指定是否包含 margin, 默认为 false.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterWidth ( string expression )
		{ return this.Execute ( "outerWidth", expression ); }

		#endregion

		#region " 方法  P "

		/// <summary>
		/// 将对象或者数组转化为 url 参数.
		/// </summary>
		/// <param name="expressionI">对象或者数组, 比如: "{name: 'abc', age: 12}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Param ( string expressionI )
		{ return this.Param ( expressionI, null ); }
		/// <summary>
		/// 将对象或者数组转化为 url 参数.
		/// </summary>
		/// <param name="expressionI">对象或者数组, 比如: "{name: 'abc', age: 12}".</param>
		/// <param name="expressionII">返回布尔值的表达式, 比如: "true", 指示是否深度转化.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Param ( string expressionI, string expressionII )
		{ return this.Execute ( "param", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parent ( )
		{ return this.Parent ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级符合选择器的父元素.
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parent ( string expression )
		{ return this.Execute ( "parent", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parents ( )
		{ return this.Parents ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有符合选择器的父元素.
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parents ( string expression )
		{ return this.Execute ( "parents", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的所有父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ParentsUntil ( )
		{ return this.ParentsUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的所有父元素, 出现符合选择器的父元素为止, 不包含此符合选择器的父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ParentsUntil ( string expression )
		{ return this.Execute ( "parentsUntil", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中第一个元素相对于父元素的位置, 返回值保存一个拥有 top 和 left 属性的对象中.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Position ( )
		{ return this.Execute ( "position" ); }

		/// <summary>
		/// 使用 POST 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Post ( string expressionI )
		{ return this.Post ( expressionI, null, null, null ); }
		/// <summary>
		/// 使用 POST 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <param name="expressionIV">指定获取数据类型的字符串, "'xml'", "'json'", "'script'", "'html'" 中的一种.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Post ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "post", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i, h) { return 'old html is ' + h;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prepend ( string expressionI )
		{ return this.Prepend ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prepend ( string expressionI, string expressionII )
		{ return this.Execute ( "prepend", expressionI, expressionII ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素追加到指定目标之前.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'.red'", 可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrependTo ( string expression )
		{ return this.Execute ( "prependTo", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的第一个兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prev ( )
		{ return this.Prev ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的符合选择器的第一个兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prev ( string expression )
		{ return this.Execute ( "prev", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevAll ( )
		{ return this.PrevAll ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的符合选择器的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevAll ( string expression )
		{ return this.Execute ( "prevAll", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素向前的所有兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevUntil ( )
		{ return this.PrevUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素向前的所有兄弟元素, 出现符合选择器的兄弟元素为止, 不包含此符合选择器的兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevUntil ( string expression )
		{ return this.Execute ( "prevUntil", expression ); }

		/// <summary>
		/// 返回承若对象. (需要 1.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Promise ( )
		{ return this.Promise ( null, null ); }
		/// <summary>
		/// 返回承若对象. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">观察的类型.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Promise ( string expressionI )
		{ return this.Promise ( expressionI, null ); }
		/// <summary>
		/// 返回承若对象. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">观察的类型.</param>
		/// <param name="expressionII">承若附加的对象.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Promise ( string expressionI, string expressionII )
		{ return this.Execute ( "promise", expressionI, expressionII ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的属性, 与 Attr 不同的是返回的值不单单为字符串, 或者设置所有元素的多个属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'", 也可以是属性集合, 比如: "{type: 'text', title: 'test'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prop ( string expressionI )
		{ return this.Prop ( expressionI, null ); }
		/// <summary>
		/// 设置 jQuery 中元素的属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是属性名称, 比如: "'title'".</param>
		/// <param name="expressionII">返回属性名称的表达式, 比如: "'just test'", 或者返回属性值的函数, 比如: "function(i, a){ return 'my_' + i.toString(); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prop ( string expressionI, string expressionII )
		{ return this.Execute ( "prop", expressionI, expressionII ); }

		/// <summary>
		/// 产生新的函数, 并指定新的上下文. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">函数的原型, 比如: "function(){ return this.toString(); }", 如果 expressionII 是函数名称, 也可以是新的上下文的表达式, 比如: "someobj".</param>
		/// <param name="expressionII">新的上下文的表达式, 比如: "someobj", 如果 expressionI 是上下文的表达式, 也可以是函数名称, 比如: "'test'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Proxy ( string expressionI, string expressionII )
		{ return this.Execute ( "proxy", expressionI, expressionII ); }

		#endregion

		#region " 方法 R "

		/// <summary>
		/// 添加当整个页面载入后的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ready ( string expression )
		{ return this.Execute ( "", expression ); }

		/// <summary>
		/// 将当前 jQuery 中的元素从页面中删除.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Remove ( )
		{ return this.Remove ( null ); }
		/// <summary>
		/// 将当前 jQuery 中符合选择器的元素从页面中删除.
		/// </summary>
		/// <param name="expression">用于选择删除元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Remove ( string expression )
		{ return this.Execute ( "remove", expression ); }

		/// <summary>
		/// 删除 jQuery 中包含的元素的属性.
		/// </summary>
		/// <param name="expression">返回属性名称的表达式, 比如: "'title'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveAttr ( string expression )
		{ return this.Execute ( "removeAttr", expression ); }

		/// <summary>
		/// 删除 jQuery 中包含的元素的所有样式.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveClass ( )
		{ return this.RemoveClass ( null ); }
		/// <summary>
		/// 删除 jQuery 中包含的元素的指定样式.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveClass ( string expression )
		{ return this.Execute ( "removeClass", expression ); }

		/// <summary>
		/// 删除通过 Prop 添加的属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveProp ( string expressionI )
		{ return this.RemoveProp ( expressionI, null ); }
		/// <summary>
		/// 删除通过 Prop 添加的属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'".</param>
		/// <param name="expressionII">用于匹配属性的值, 比如: "'happy.gif'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveProp ( string expressionI, string expressionII )
		{ return this.Execute ( "removeProp", expressionI, expressionII ); }

		/// <summary>
		/// 使用当前 jQuery 中的元素替换符合选择器的元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">选择被替换到的元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ReplaceAll ( string expression )
		{ return this.Execute ( "replaceAll", expression ); }

		/// <summary>
		/// 使用新的元素替换当前 jQuery 中的元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(){ document.getElementById('abc') }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ReplaceWith ( string expression )
		{ return this.Execute ( "replaceWith", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加大小改变事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( )
		{ return this.Resize ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加大小改变的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( string expressionI )
		{ return this.Resize ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加大小改变的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( string expressionI, string expressionII )
		{ return this.Execute ( "resize", expressionI, expressionII ); }

		#endregion

		#region " 方法 S "

		/// <summary>
		/// 触发 jQuery 中的元素的添加滚动轴事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( )
		{ return this.Scroll ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加滚动轴的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( string expressionI )
		{ return this.Scroll ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加滚动轴的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( string expressionI, string expressionII )
		{ return this.Execute ( "scroll", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的水平滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollLeft ( )
		{ return this.ScrollLeft ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的水平滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollLeft ( string expression )
		{ return this.Execute ( "scrollLeft", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的垂直滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollTop ( )
		{ return this.ScrollTop ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的垂直滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollTop ( string expression )
		{ return this.Execute ( "scrollTop", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加选择事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( )
		{ return this.Select ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加选择的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( string expressionI )
		{ return this.Select ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加选择的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( string expressionI, string expressionII )
		{ return this.Execute ( "select", expressionI, expressionII ); }

		/// <summary>
		/// 将表单中包含的值转化为 url 参数字符串.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Serialize ( )
		{ return this.Execute ( "serialize" ); }

		/// <summary>
		/// 将表单中包含的值转化为数组.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery SerializeArray ( )
		{ return this.Execute ( "serializeArray" ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Siblings ( )
		{ return this.Siblings ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有符合选择器的兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Siblings ( string expression )
		{ return this.Execute ( "siblings", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中从某个位置开始到结束范围的元素, 0 是第 1 个元素, -1 是最后一个元素. (需要 1.1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Slice ( string expressionI )
		{ return this.Slice ( expressionI, null ); }
		/// <summary>
		/// 选择当前 jQuery 中某个范围的元素, 0 是第 1 个元素, -1 是最后一个元素. (需要 1.1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <param name="expressionII">结束索引, 比如: "2", 结束位置的元素不会被选择.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Slice ( string expressionI, string expressionII )
		{ return this.Execute ( "slice", expressionI, expressionII ); }

		/// <summary>
		/// 创建主 jQuery 对象的副本.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Sub ( )
		{ return this.Execute ( "sub" ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加提交事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( )
		{ return this.Submit ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加提交的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( string expressionI )
		{ return this.Submit ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加提交的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( string expressionI, string expressionII )
		{ return this.Execute ( "submit", expressionI, expressionII ); }

		#endregion

		#region " 方法 T "

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 innerText 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Text ( )
		{ return this.Text ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含元素的 innerText 属性.
		/// </summary>
		/// <param name="expression">一个字符串表达式, 比如: "'this is abc'", 或者返回字符串的函数, 比如: "function(i, t){ return 'old text is ' + t; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Text ( string expression )
		{ return this.Execute ( "text", expression ); }

		/// <summary>
		/// 为当前 jQuery 元素添加多个点击事件, 将根据点击次数在这些事件中切换.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <param name="expressionII">同 expressionI, 可以为 null.</param>
		/// <param name="expressionIII">同 expressionI, 可以为 null.</param>
		/// <param name="expressionIV">同 expressionI, 可以为 null.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Toggle ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "toggle", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 切换 jQuery 中包含的元素的样式, 样式存在则删除, 如果不存在则添加.
		/// </summary>
		/// <param name="expressionI">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ToggleClass ( string expressionI )
		{ return this.ToggleClass ( expressionI, null ); }
		/// <summary>
		/// 添加或者删除 jQuery 中包含的元素的样式. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <param name="expressionII">返回布尔值的表达式, 表示添加还是删除样式.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ToggleClass ( string expressionI, string expressionII )
		{ return this.Execute ( "toggleClass", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中元素的事件. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Trigger ( string expressionI )
		{ return this.Trigger ( expressionI, null ); }
		/// <summary>
		/// 触发 jQuery 中元素的事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">扩展的参数数组, 比如: "[age: 10, size: 100]".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Trigger ( string expressionI, string expressionII )
		{ return this.Execute ( "trigger", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中第一个元素的事件, 不引发元素的默认行文. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">扩展的参数数组, 比如: "[age: 10, size: 100]".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery TriggerHandler ( string expressionI, string expressionII )
		{ return this.Execute ( "triggerHandler", expressionI, expressionII ); }

		#endregion

		#region " 方法 U "

		/// <summary>
		/// 为 jQuery 中的元素取消所有事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( )
		{ return this.Unbind ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件.
		/// </summary>
		/// <param name="expressionI">可以是事件类型, 比如: "'click'", "'click mouseover'", 也可以是包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( string expressionI )
		{ return this.Unbind ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示取消停止冒泡的事件. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( string expressionI, string expressionII )
		{ return this.Execute ( "unbind", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的元素取消所有事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( )
		{ return this.Undelegate ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消命名空间下的事件. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">事件所在的命名空间, 比如: "'.whatever'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI )
		{ return this.Undelegate ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI, string expressionII )
		{ return this.Undelegate ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "undelegate", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加卸载的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unload ( string expressionI )
		{ return this.Unload ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加卸载的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unload ( string expressionI, string expressionII )
		{ return this.Execute ( "unload", expressionI, expressionII ); }

		/// <summary>
		/// 删除调用 wrap 方法产生的父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unwrap ( )
		{ return this.Execute ( "unwrap" ); }

		#endregion

		#region " 方法 V "

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 value 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Val ( )
		{ return this.Val ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含的元素 value 属性.
		/// </summary>
		/// <param name="expression">一个表达式, 比如: "'my name'", 或者是一个返回值的函数, 比如: "function(i, v){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Val ( string expression )
		{ return this.Execute ( "val", expression ); }

		#endregion

		#region " 方法 W "

		/// <summary>
		/// 调用 when 方法, 传递一个或者多个 javascript 对象, 之后可再通过 done, then 等方法编写这些对象载入后的处理方法. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expression">一个或者多个对象的表达式, 比如: "$.ajax('test.aspx')", 或者 "{ testing: 123 }, { name: 'jack' }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery When ( string expression )
		{ return this.Execute ( "when", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Width ( )
		{ return this.Width ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的宽度.
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110", 或者一个返回数值的函数, 比如: "function(i, w){ return i + w; }". (如果使用函数需要 1.4.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Width ( string expression )
		{ return this.Execute ( "width", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的每一个元素添加父元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(i){ return '&lt;div&gt;&lt;/div&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Wrap ( string expression )
		{ return this.Execute ( "wrap", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的元素添加一个共同的父元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery WrapAll ( string expression )
		{ return this.Execute ( "wrapAll", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的每一个元素添加一个子元素, 这个子元素包含原来所有的子元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(){ return '&lt;div&gt;&lt;/div&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery WrapInner ( string expression )
		{ return this.Execute ( "wrapInner", expression ); }

		#endregion

	}

}
// ../.class/web/ScriptHelper.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ScriptHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * 测试文件:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/testsite/TestScriptHelper.aspx
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/testsite/TestScriptHelper.aspx.cs
 * 合并下载:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/ScriptHelper.all.cs
 * 版本: 1.1, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
* */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

// HACK: 如果代码不能编译, 请尝试在项目中定义编译符号 V4, V3_5, V3, V2 以表示不同的 .NET 版本


// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 此类可以完成客户端脚本的编写, 修改标签属性, 包含脚本文件, 设置时钟等操作.
	/// </summary>
	public partial class ScriptHelper
	{

		private static readonly Random random = new Random ( );

#if PARAM
		/// <summary>
		/// 从一个字符串生成脚本的 id.
		/// </summary>
		/// <param name="key">字符串, 作为 id 的一部分, 默认为 "script_yyyyMMddhhmmss".</param>
		/// <returns>脚本 id.</returns>
		public static string MakeKey ( string key = null )
#else
		/// <summary>
		/// 从一个字符串生成脚本的 id.
		/// </summary>
		/// <param name="key">字符串, 作为 id 的一部分.</param>
		/// <returns>脚本 id.</returns>
		public static string MakeKey ( string key )
#endif
		{

			if ( string.IsNullOrEmpty ( key ) )
				key = DateTime.Now.ToString ( "yyyyMMddhhmmss" ) + random.Next ( 0, int.MaxValue );

			return string.Format ( "script_{0}", key );
		}

#if PARAM
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本, 默认为 None.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( NControl control, string key, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( NControl control, string key, ScriptBuildOption option )
#endif
		{

			if ( null == control )
				return false;

			return IsBuilt ( control.Page, key, option );
		}

#if PARAM
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="page">代码块所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本, 默认为 None.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( Page page, string key, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="page">代码块所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( Page page, string key, ScriptBuildOption option )
#endif
		{

			if ( null == page || null == page.ClientScript )
				return false;

			// HACK: 可能需要添加 V5
#if V4
			if ( option.HasFlag ( ScriptBuildOption.Startup ) )
#else
			if ( ( option & ScriptBuildOption.Startup ) == ScriptBuildOption.Startup )
#endif
				return page.ClientScript.IsStartupScriptRegistered ( page.GetType ( ), MakeKey ( key ) );
			else
				return page.ClientScript.IsClientScriptBlockRegistered ( page.GetType ( ), MakeKey ( key ) );

		}

#if PARAM
		/// <summary>
		/// 对字符串编码, 以进行接下来的操作.
		/// </summary>
		/// <param name="text">需要编码的字符串.</param>
		/// <param name="isRemove">是否删除某些特殊字符, 如: 换行, 默认为 false.</param>
		/// <returns>编码后的字符串.</returns>
		public static string EscapeCharacter ( string text, bool isRemove = false )
#else
		/// <summary>
		/// 对字符串编码, 以进行接下来的操作.
		/// </summary>
		/// <param name="text">需要编码的字符串.</param>
		/// <param name="isRemove">是否删除某些特殊字符, 如: 换行.</param>
		/// <returns>编码后的字符串.</returns>
		public static string EscapeCharacter ( string text, bool isRemove )
#endif
		{

			if ( string.IsNullOrEmpty ( text ) )
				return string.Empty;

			if ( isRemove )
				text = text.Replace ( "\n", string.Empty ).Replace ( "\r", string.Empty ).Replace ( "\t", string.Empty );
			else
				text = text.Replace ( "\n", "\\n" ).Replace ( "\r", "\\r" ).Replace ( "\t", "\\t" );

			return text.Replace ( "\\", "\\\\" ).Replace ( "\'", "\\'" );
		}

		protected string code = string.Empty;

		protected readonly ScriptType scriptType;

		/// <summary>
		/// 获取或设置脚本代码.
		/// </summary>
		public string Code
		{
			get { return this.code; }
			set
			{

				if ( null != value )
					this.code = value;

			}
		}

		/// <summary>
		/// 获取脚本类型.
		/// </summary>
		public ScriptType ScriptType
		{
			get { return this.scriptType; }
		}

		/// <summary>
		/// 获取脚本类型对应的 Return 语句.
		/// </summary>
		public string Return
		{
			get
			{

				switch ( this.scriptType )
				{
					case ScriptType.VBScript:
						return string.Empty;

					case ScriptType.JavaScript:
					default:
						return "return";
				}

			}
		}

		/// <summary>
		/// 获取脚本类型对应的语句结束符号.
		/// </summary>
		public string EndOfLine
		{
			get
			{

				switch ( this.scriptType )
				{
					case ScriptType.VBScript:
						return string.Empty;

					case ScriptType.JavaScript:
					default:
						return ";";
				}

			}
		}

#if PARAM
		/// <summary>
		/// 创建脚本帮手.
		/// </summary>
		/// <param name="scriptType">脚本类型, 目前只有 JavaScript 类型可用, 默认为 JavaScript.</param>
		public ScriptHelper ( ScriptType scriptType = ScriptType.JavaScript )
#else
		/// <summary>
		/// 创建脚本帮手.
		/// </summary>
		/// <param name="scriptType">脚本类型, 目前只有 JavaScript 类型可用.</param>
		public ScriptHelper ( ScriptType scriptType )
#endif
		{
			this.scriptType = scriptType;

			switch ( scriptType )
			{
				case ScriptType.VBScript:
					throw new ArgumentException ( "目前不支持 VBScript, 请使用 JavaScript", "quotationType" );
			}

		}

#if PARAM
		/// <summary>
		/// 生成弹出消息的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>弹出消息框的代码.</returns>
		public string Alert ( string message, bool isAppend = true )
#else
		/// <summary>
		/// 生成弹出消息的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>弹出消息框的代码.</returns>
		public string Alert ( string message, bool isAppend )
#endif
		{

			string code = string.Empty;

			if ( string.IsNullOrEmpty ( message ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "alert({0});", message );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回结果到变量等的确认消息函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户确认结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 默认不返回值到变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回结果到变量等的确认消息函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户确认结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( message ) )
				return code;

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{1}confirm({0});", message, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回结果到变量的输入框函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'10'", 也可以是计算表达式, 比如: "defaultAge", 默认为 "''".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 默认不返回值到变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string defaultValue = null, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回结果到变量的输入框函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'10'", 也可以是计算表达式, 比如: "defaultAge".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性?</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string defaultValue, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( null == message )
				return code;

			if ( null == defaultValue )
				defaultValue = "''";

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}prompt({0}, {1});", message, defaultValue, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

		/// <summary>
		/// 清除所有的代码.
		/// </summary>
		public void Clear ( )
		{ this.code = string.Empty; }

		/// <summary>
		/// 添加代码到当前代码结尾处.
		/// </summary>
		/// <param name="code">被添加的代码.</param>
		public void AppendCode ( string code )
		{

			if ( string.IsNullOrEmpty ( code ) )
				return;

			this.code += code;
		}

#if PARAM
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称, 默认自动生成.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效, 默认 None.</param>
		public void Build ( NControl control, string key = null, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( NControl control, string key, ScriptBuildOption option )
#endif
		{

			if ( null == control )
				return;

			this.Build ( control.Page, key, option );
		}

#if PARAM
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="key">代码块的名称, 默认自动生成.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效, 默认 None.</param>
		public void Build ( Page page, string key = null, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( Page page, string key, ScriptBuildOption option )
#endif
		{

			if ( this.code == string.Empty || null == page || null == page.ClientScript || IsBuilt ( page, key, option ) )
				return;

			string type;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					type = "text/javascript";
					break;
			}

			string script;

			// HACK: 可能需要添加 V5
#if V4
			if ( option.HasFlag ( ScriptBuildOption.OnlyCode ) )
#else
			if ( ( option & ScriptBuildOption.OnlyCode ) == ScriptBuildOption.OnlyCode )
#endif
				script = this.code;
			else
				script = string.Format ( "<script language='{0}' type='{1}'>\n{2}\n</script>", this.scriptType.ToString ( ).ToLower ( ), type, this.code );

			key = MakeKey ( key );

			// HACK: 可能需要添加 V5
#if V4
			if ( option.HasFlag ( ScriptBuildOption.Startup ) )
#else
			if ( ( option & ScriptBuildOption.Startup ) == ScriptBuildOption.Startup )
#endif
				page.ClientScript.RegisterStartupScript ( page.GetType ( ), key, script );
			else
				page.ClientScript.RegisterClientScriptBlock ( page.GetType ( ), key, script );

			// if ( option.HasFlag ( ScriptBuildOption.EndResponse ) && null != page.Response )
			//     page.Response.End ();

		}

#if PARAM
		/// <summary>
		/// 生成导航的函数, 地址选项在实际代码中将使用单引号, 比如: '_blank', 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航窗口选项, 默认为 SelfWindow.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, NavigateOption option = NavigateOption.SelfWindow, bool isAppend = true )
#else
		/// <summary>
		/// 生成导航的函数, 地址选项在实际代码中将使用单引号, 比如: '_blank', 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航窗口选项.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, NavigateOption option, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( location ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:

					switch ( option )
					{
						case NavigateOption.NewWindow:
							code = string.Format (
								"window.open({0}, '{1}');",
								location,
								"_blank"
								);
							break;

						case NavigateOption.ParentWindow:
							code = string.Format (
								"window.open({0}, '{1}');",
								location,
								"_parent"
								);
							break;

						case NavigateOption.SelfWindow:
						default:
							code = string.Format ( "location.href = {0};", location );
							break;
					}

					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成清除时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>清除时钟的代码.</returns>
		public string ClearTimeout ( string handler, bool isAppend = true )
#else
		/// <summary>
		/// 生成清除时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>清除时钟的代码.</returns>
		public string ClearTimeout ( string handler, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( handler ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "clearTimeout({0});", handler );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回句柄到变量的时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 默认不保存到任何变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回句柄到变量的时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( runCode ) )
				return code;

			if ( delay <= 0 )
				delay = 1;

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}setTimeout({0}, {1});", runCode, delay, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成清除循环时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>清除循环时钟的代码.</returns>
		public string ClearInterval ( string handler, bool isAppend = true )
#else
		/// <summary>
		/// 生成清除循环时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>清除循环时钟的代码.</returns>
		public string ClearInterval ( string handler, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( handler ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "clearInterval({0});", handler );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回句柄到变量的循环时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 默认不保存到任何变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回句柄到变量的循环时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( runCode ) )
				return code;

			if ( delay <= 0 )
				delay = 1;

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}setInterval({0}, {1});", runCode, delay, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 添加一个数组到控件所在页面的脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 默认不包含值.</param>
		public static void RegisterArray ( NControl control, string arrayName, string arrayValue = null )
#else
		/// <summary>
		/// 添加一个数组到控件所在页面的脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 也可以设置为 null.</param>
		public static void RegisterArray ( NControl control, string arrayName, string arrayValue )
#endif
		{

			if ( null == control )
				return;

			RegisterArray ( control.Page, arrayName, arrayValue );
		}

#if PARAM
		/// <summary>
		/// 添加一个数组到页面脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 默认不包含值.</param>
		public static void RegisterArray ( Page page, string arrayName, string arrayValue = null )
#else
		/// <summary>
		/// 添加一个数组到页面脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 也可以设置为 null.</param>
		public static void RegisterArray ( Page page, string arrayName, string arrayValue )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( arrayName ) )
				return;

			if ( null == arrayValue )
				arrayValue = "";

			page.ClientScript.RegisterArrayDeclaration ( arrayName, arrayValue );
		}


#if PARAM
		/// <summary>
		/// 添加脚本包含到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称, 默认自动生成.</param>
		public static void RegisterInclude ( NControl control, string url, string key = null )
#else
		/// <summary>
		/// 添加脚本包含到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称.</param>
		public static void RegisterInclude ( NControl control, string url, string key )
#endif
		{

			if ( null == control )
				return;

			RegisterInclude ( control.Page, key, url );
		}

#if PARAM
		/// <summary>
		/// 添加脚本包含到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称, 默认自动生成.</param>
		public static void RegisterInclude ( Page page, string url, string key = null )
#else
		/// <summary>
		/// 添加脚本包含到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称.</param>
		public static void RegisterInclude ( Page page, string url, string key )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( url ) )
				return;

			key = MakeKey ( key );

			if ( page.ClientScript.IsClientScriptIncludeRegistered ( page.GetType ( ), key ) )
				return;

			page.ClientScript.RegisterClientScriptInclude ( page.GetType ( ), key, url );
		}

		/// <summary>
		/// 将资源中脚本注册到控件所在的页面中.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="resourceType">资源所在的类型.</param>
		/// <param name="resourceName">资源的名称.</param>
		public static void RegisterResource ( NControl control, Type resourceType, string resourceName )
		{

			if ( null == control )
				return;

			RegisterResource ( control.Page, resourceType, resourceName );
		}

		/// <summary>
		/// 将资源中脚本注册到页面中.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="resourceType">资源所在的类型.</param>
		/// <param name="resourceName">资源的名称.</param>
		public static void RegisterResource ( Page page, Type resourceType, string resourceName )
		{

			if ( null == page || null == page.ClientScript || null == resourceType || string.IsNullOrEmpty ( resourceName ) )
				return;

			page.ClientScript.RegisterClientScriptResource ( resourceType, resourceName );
		}

		/// <summary>
		/// 添加设置标签属性的脚本到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性, 但不能对同一标签的同一属性设置两次.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加设置标签属性的脚本.</param>
		/// <param name="id">标签的 id 属性, 比如: "spanTest", 标签应该是页面上存在的元素.</param>
		/// <param name="attributeName">标签的属性, 比如: "innerHTML" 或者 "style.color".</param>
		/// <param name="attributeValue">属性的值, 比如: "你好" 或者 "#ff0000", 可以为 null.</param>
		public static void RegisterAttribute ( NControl control, string id, string attributeName, string attributeValue )
		{

			if ( null == control )
				return;

			RegisterAttribute ( control.Page, id, attributeName, attributeValue );
		}
		/// <summary>
		/// 添加设置标签属性的脚本到页面, 不需要使用 Build 方法, 也不影响 Code 属性, 但不能对同一标签的同一属性设置两次.
		/// </summary>
		/// <param name="page">添加设置标签属性脚本的页面.</param>
		/// <param name="id">标签的 id 属性, 比如: "spanTest", 标签应该是页面上存在的元素.</param>
		/// <param name="attributeName">标签的属性, 比如: "innerHTML" 或者 "style.color".</param>
		/// <param name="attributeValue">属性的值, 比如: "你好" 或者 "#ff0000", 可以为 null.</param>
		public static void RegisterAttribute ( Page page, string id, string attributeName, string attributeValue )
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( id ) || string.IsNullOrEmpty ( attributeName ) )
				return;

			if ( null == attributeValue )
				attributeValue = string.Empty;

			try
			{ page.ClientScript.RegisterExpandoAttribute ( id, attributeName, attributeValue, true ); }
			catch { }

		}

		/// <summary>
		/// 添加隐藏值到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加隐藏值.</param>
		/// <param name="name">隐藏值的名称.</param>
		/// <param name="value">隐藏值, 可以为 null.</param>
		public static void RegisterHidden ( NControl control, string name, string value )
		{

			if ( null == control )
				return;

			RegisterHidden ( control.Page, name, value );
		}
		/// <summary>
		/// 添加隐藏值到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加隐藏值的页面.</param>
		/// <param name="name">隐藏值的名称.</param>
		/// <param name="value">隐藏值, 可以为 null.</param>
		public static void RegisterHidden ( Page page, string name, string value )
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( name ) )
				return;

			if ( null == value )
				value = string.Empty;

			page.ClientScript.RegisterHiddenField ( name, value );
		}

#if PARAM
		/// <summary>
		/// 添加 OnSubmit 脚本到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称, 默认自动生成.</param>
		public static void RegisterSubmit ( NControl control, string code, string key = null )
#else
		/// <summary>
		/// 添加 OnSubmit 脚本到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称.</param>
		public static void RegisterSubmit ( NControl control, string code, string key )
#endif
		{

			if ( null == control )
				return;

			RegisterSubmit ( control.Page, key, code );
		}

#if PARAM
		/// <summary>
		/// 添加 OnSubmit 脚本到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称, 默认自动生成.</param>
		public static void RegisterSubmit ( Page page, string code, string key = null )
#else
		/// <summary>
		/// 添加 OnSubmit 脚本到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称.</param>
		public static void RegisterSubmit ( Page page, string code, string key )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( code ) )
				return;

			key = MakeKey ( key );

			if ( page.ClientScript.IsOnSubmitStatementRegistered ( page.GetType ( ), key ) )
				return;

			page.ClientScript.RegisterOnSubmitStatement ( page.GetType ( ), key, code );
		}

	}

	partial class ScriptHelper
	{
#if !PARAM
		/// <summary>
		/// 对字符串编码, 不删除特殊字符, 如: 换行, 以进行接下来的操作.
		/// </summary>
		/// <param name="text">需要编码的字符串.</param>
		/// <returns>编码后的字符串.</returns>
		public static string EscapeCharacter ( string text )
		{ return EscapeCharacter ( text, false ); }

		/// <summary>
		/// 添加脚本包含到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		public static void RegisterInclude ( Page page, string url )
		{ RegisterInclude ( page, url, null ); }

		/// <summary>
		/// 添加脚本包含到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		public static void RegisterInclude ( NControl control, string url )
		{ RegisterInclude ( control, url, null ); }

		/// <summary>
		/// 添加一个数组到页面脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		public static void RegisterArray ( Page page, string arrayName )
		{ RegisterArray ( page, arrayName, null ); }

		/// <summary>
		/// 添加一个数组到控件所在页面的脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		public static void RegisterArray ( NControl control, string arrayName )
		{ RegisterArray ( control, arrayName, null ); }

		/// <summary>
		/// 添加循环时钟的函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay )
		{ return this.SetInterval ( runCode, delay, null, true ); }
		/// <summary>
		/// 添加返回句柄到变量的循环时钟函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, string result )
		{ return this.SetInterval ( runCode, delay, result, true ); }
		/// <summary>
		/// 生成循环时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="isAppend">是否追加到 Code 属性?</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, bool isAppend )
		{ return this.SetInterval ( runCode, delay, null, isAppend ); }

		/// <summary>
		/// 添加清除循环时钟的函数到代码.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <returns>清除循环时钟的代码.</returns>
		public string ClearInterval ( string handler )
		{ return this.ClearInterval ( handler, true ); }

		/// <summary>
		/// 添加时钟的函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay )
		{ return this.SetTimeout ( runCode, delay, null, true ); }
		/// <summary>
		/// 添加返回句柄到变量的时钟函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result )
		{ return this.SetTimeout ( runCode, delay, result, true ); }
		/// <summary>
		/// 生成时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, bool isAppend )
		{ return this.SetTimeout ( runCode, delay, null, isAppend ); }

		/// <summary>
		/// 添加循环时钟的函数到代码.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <returns>清除时钟的代码.</returns>
		public string ClearTimeout ( string handler )
		{ return this.ClearTimeout ( handler, true ); }

		/// <summary>
		/// 添加导航的函数到代码, 在自身窗口打开.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location )
		{ return this.Navigate ( location, NavigateOption.SelfWindow, true ); }
		/// <summary>
		/// 添加导航的函数到代码, 地址选项在实际代码中将使用单引号, 比如: '_blank'.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航窗口选项.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, NavigateOption option )
		{ return this.Navigate ( location, option, true ); }
		/// <summary>
		/// 生成导航的函数, 在自身窗口打开, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, bool isAppend )
		{ return this.Navigate ( location, NavigateOption.SelfWindow, isAppend ); }

		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		public void Build ( Page page )
		{ this.Build ( page, null, ScriptBuildOption.None ); }
		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( Page page, ScriptBuildOption option )
		{ this.Build ( page, null, option ); }
		/// <summary>
		/// 生成代码块, 带有 script 标签, 但不结束页面处理.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="key">代码块的名称.</param>
		public void Build ( Page page, string key )
		{ this.Build ( page, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		public void Build ( NControl control )
		{ this.Build ( control, null, ScriptBuildOption.None ); }
		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( NControl control, ScriptBuildOption option )
		{ this.Build ( control, null, option ); }
		/// <summary>
		/// 生成代码块, 带有 script 标签, 但不结束页面处理.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		public void Build ( NControl control, string key )
		{ this.Build ( control, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 添加返回结果到变量的输入框函数到代码.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string result )
		{ return this.Prompt ( message, null, result, true ); }
		/// <summary>
		/// 添加返回结果到变量的输入框函数到代码.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'10'", 也可以是计算表达式, 比如: "defaultAge".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string defaultValue, string result )
		{ return this.Prompt ( message, defaultValue, result, true ); }
		/// <summary>
		/// 生成返回结果到变量的输入框函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string result, bool isAppend )
		{ return this.Prompt ( message, null, result, isAppend ); }

		/// <summary>
		/// 添加确认消息的函数到代码.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message )
		{ return this.Confirm ( message, null, true ); }
		/// <summary>
		/// 添加返回结果到变量等的确认消息函数到代码.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户确认结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, string result )
		{ return this.Confirm ( message, result, true ); }
		/// <summary>
		/// 生成确认消息的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, bool isAppend )
		{ return this.Confirm ( message, null, isAppend ); }

		/// <summary>
		/// 添加弹出消息的函数到代码.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <returns>弹出消息框的代码.</returns>
		public string Alert ( string message )
		{ return Alert ( message, true ); }

		/// <summary>
		/// 创建脚本帮手, 脚本类型为 JavaScript.
		/// </summary>
		public ScriptHelper ()
			: this ( ScriptType.JavaScript )
		{ }

		/// <summary>
		/// 指定名称的普通代码块是否已经存在?
		/// </summary>
		/// <param name="page">代码块所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( Page page, string key )
		{ return IsBuilt ( page, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 指定名称的普通代码块是否已经存在?
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <returns>是否存在代码块.</returns>
		public static bool IsBuilt ( NControl control, string key )
		{ return IsBuilt ( control, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 生成一个随机的脚本 id.
		/// </summary>
		/// <returns>脚本 id.</returns>
		public static string MakeKey ()
		{ return MakeKey ( null ); }
#endif
	}

}
// ../.enum/web/NavigateOption.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/NavigateOption
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 导航选项.
	/// </summary>
	public enum NavigateOption
	{
		/// <summary>
		/// 空设置.
		/// </summary>
		None = 0,
		/// <summary>
		/// 新窗口.
		/// </summary>
		NewWindow = 1,
		/// <summary>
		/// 在自身的窗口.
		/// </summary>
		SelfWindow = 2,
		/// <summary>
		/// 在父窗口中.
		/// </summary>
		ParentWindow = 3
	}

}
// ../.enum/web/ScriptBuildOption.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ScriptBuildOption
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 脚本编译选项.
	/// </summary>
	public enum ScriptBuildOption
	{
		/// <summary>
		/// 默认, 带有 script 标签, 普通脚本块, 不结束页面处理.
		/// </summary>
		None = 0,
		/// <summary>
		/// 结束页面处理.
		/// </summary>
		EndResponse = 1,
		/// <summary>
		/// 不带有 script 标签.
		/// </summary>
		OnlyCode = 2,
		/// <summary>
		/// 做为启动脚本.
		/// </summary>
		Startup = 4
	}

}
// ../.enum/web/ScriptType.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ScriptType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 脚本的类型.
	/// </summary>
	public enum ScriptType
	{
		/// <summary>
		/// Java 脚本.
		/// </summary>
		JavaScript = 1,
		/// <summary>
		/// VB 脚本.
		/// </summary>
		VBScript = 2
	}

}
// ../.class/code/StringConvert.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/StringConvert
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

// HACK: 如果代码不能编译, 请尝试在项目中定义编译符号 V4, V3_5, V3, V2 以表示不同的 .NET 版本


namespace zoyobar.shared.panzer.code
{

	/// <summary>
	/// 字符串转换器.
	/// </summary>
	public sealed class StringConvert
	{

		/// <summary>
		/// 将对象转化为字符串.
		/// </summary>
		/// <param name="value">需要转化的对象.</param>
		/// <returns>转化后的字符串.</returns>
		public static string ToString ( object value )
		{

			if ( null == value )
				return string.Empty;

			if ( value.GetType ( ) == typeof ( Color ) )
				return ( ( Color ) value ).ToArgb ( ).ToString ( );
			else
				return value.ToString ( );

		}

		/// <summary>
		/// 将字符串转化为指定类型的对象.
		/// </summary>
		/// <param name="value">需要转化的字符串.</param>
		/// <returns>转化后的对象.</returns>
		public static T ToObject<T> ( string value )
		{

			if ( null == value )
				return default ( T );

			Type type = typeof ( T );

			try
			{

				// HACK: 可能需要添加 V5
#if V4
				if ( type == typeof ( Guid ) )
					return ( T ) ( object ) new Guid ( value );
				else if ( type == typeof ( Color ) )
					return ( T ) ( object ) Color.FromArgb ( Convert.ToInt32 ( value ) );
				else if ( type == typeof ( string ) )
					return ( T ) ( object ) value.ToString ( );
				else if ( type == typeof ( int ) )
					return ( T ) ( object ) int.Parse ( value );
				else if ( type == typeof ( short ) )
					return ( T ) ( object ) short.Parse ( value );
				else if ( type == typeof ( long ) )
					return ( T ) ( object ) long.Parse ( value );
				else if ( type == typeof ( decimal ) )
					return ( T ) ( object ) decimal.Parse ( value );
				else if ( type == typeof ( bool ) )
					return ( T ) ( object ) bool.Parse ( value );
				else if ( type == typeof ( DateTime ) )
					return ( T ) ( object ) DateTime.Parse ( value );
				else if ( type == typeof ( float ) )
					return ( T ) ( object ) float.Parse ( value );
				else if ( type == typeof ( double ) )
					return ( T ) ( object ) double.Parse ( value );
				else
					return ( T ) ( object ) value;
#else
				if ( object.ReferenceEquals ( type, typeof ( Guid ) ) )
					return ( T ) ( object ) new Guid ( value );
				else if ( object.ReferenceEquals ( type, typeof ( Color ) ) )
					return ( T ) ( object ) Color.FromArgb ( Convert.ToInt32 ( value ) );
				else if ( object.ReferenceEquals ( type, typeof ( string ) ) )
					return ( T ) ( object ) value.ToString ( );
				else if ( object.ReferenceEquals ( type, typeof ( int ) ) )
					return ( T ) ( object ) int.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( short ) ) )
					return ( T ) ( object ) short.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( long ) ) )
					return ( T ) ( object ) long.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( decimal ) ) )
					return ( T ) ( object ) decimal.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( bool ) ) )
					return ( T ) ( object ) bool.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( DateTime ) ) )
					return ( T ) ( object ) DateTime.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( float ) ) )
					return ( T ) ( object ) float.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( double ) ) )
					return ( T ) ( object ) double.Parse ( value );
				else
					return ( T ) ( object ) value;
#endif

			}
			catch
			{ return default ( T ); }

		}

	}

}

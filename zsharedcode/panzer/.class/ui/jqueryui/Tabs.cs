﻿/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITabs
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Tabs.cs
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
	/// jQuery UI 分组标签插件.
	/// </summary>
	[ToolboxData ( "<{0}:Tabs runat=server></{0}:Tabs>" )]
	[DesignerAttribute ( typeof ( TabsDesigner ) )]
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
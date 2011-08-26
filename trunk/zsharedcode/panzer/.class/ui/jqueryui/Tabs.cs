/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Tabs.cs
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
	/// jQuery UI 分组标签插件.
	/// </summary>
	[ToolboxData ( "<{0}:Tabs runat=server></{0}:Tabs>" )]
	public class Tabs
		: JQueryWidget<TabsSetting>, IPostBackEventHandler
	{

		/// <summary>
		/// 创建一个 jQuery UI 分组标签.
		/// </summary>
		public Tabs ( )
			: base ( new TabsSetting ( ), HtmlTextWriterTag.Div )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置分组标签是否可用, 或者禁用的标签的索引, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示分组标签是否可用, 或者禁用的标签的索引, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置标签内容的 Ajax 选项, 比如: "{ async: false }", 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签内容的 Ajax 选项, 比如: { async: false }, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string AjaxOptions
		{
			get { return this.uiSetting.AjaxOptions; }
			set { this.uiSetting.AjaxOptions = value; }
		}

		/// <summary>
		/// 获取或设置是否使用缓存, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否使用缓存, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Cache
		{
			get { return this.uiSetting.Cache; }
			set { this.uiSetting.Cache = value; }
		}

		/// <summary>
		/// 获取或设置当再次选择已选中的标签时, 是否取消选中状态, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示当再次选择已选中的标签时, 是否取消选中状态, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Collapsible
		{
			get { return this.uiSetting.Collapsible; }
			set { this.uiSetting.Collapsible = value; }
		}

		/// <summary>
		/// 获取或设置 cookie 的设置, 比如: "{ expires: 7, path: '/', domain: 'jquery.com', secure: true }", 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 cookie 的设置, 比如: { expires: 7, path: '/', domain: 'jquery.com', secure: true }, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Cookie
		{
			get { return this.uiSetting.Cookie; }
			set { this.uiSetting.Cookie = value; }
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
			get { return this.uiSetting.Deselectable; }
			set { this.uiSetting.Deselectable = value; }
		}

		/// <summary>
		/// 获取或设置触发切换的事件名称, 默认为 click.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( EventType.click )]
		[Description ( "指示触发切换的事件名称, 默认为 click" )]
		[NotifyParentProperty ( true )]
		public EventType Event
		{
			get { return this.uiSetting.Event; }
			set { this.uiSetting.Event = value; }
		}

		/// <summary>
		/// 获取或设置显示或者隐藏的动画效果, 比如: "{ opacity: 'toggle' }", 默认为空字符串.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示或者隐藏的动画效果, 比如: { opacity: 'toggle' }, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Fx
		{
			get { return this.uiSetting.Fx; }
			set { this.uiSetting.Fx = value; }
		}

		/// <summary>
		/// 获取或设置 id 的前缀, 默认为 "ui-tabs-".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "ui-tabs-" )]
		[Description ( "指示 id 的前缀, 默认为 ui-tabs-" )]
		[NotifyParentProperty ( true )]
		public string IdPrefix
		{
			get { return this.uiSetting.IdPrefix; }
			set { this.uiSetting.IdPrefix = value; }
		}

		/// <summary>
		/// 获取或设置面板的模板内容.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "<div></div>" )]
		[Description ( "指示面板的模板内容, 默认为 <div></div>" )]
		[NotifyParentProperty ( true )]
		public string PanelTemplate
		{
			get { return this.uiSetting.PanelTemplate; }
			set { this.uiSetting.PanelTemplate = value; }
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
			get { return this.uiSetting.Selected; }
			set { this.uiSetting.Selected = value; }
		}

		/// <summary>
		/// 获取或设置载入条的内容.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "<em>Loading&#8230;</em>" )]
		[Description ( "指示载入条的内容, 默认为 <em>Loading&#8230;</em>" )]
		[NotifyParentProperty ( true )]
		public string Spinner
		{
			get { return this.uiSetting.Spinner; }
			set { this.uiSetting.Spinner = value; }
		}

		/// <summary>
		/// 获取或设置表头的模板内容.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "<li><a href=#{href}><span>#{label}</span></a></li>" )]
		[Description ( "指示表头的模板内容, 默认为 <li><a href=#{href}><span>#{label}</span></a></li>" )]
		[NotifyParentProperty ( true )]
		public string TabTemplate
		{
			get { return this.uiSetting.TabTemplate; }
			set { this.uiSetting.TabTemplate = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置分组标签被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置分组标签被选中时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.uiSetting.Select; }
			set { this.uiSetting.Select = value; }
		}

		/// <summary>
		/// 获取或设置内容载入时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示内容载入时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public new string Load
		{
			get { return this.uiSetting.Load; }
			set { this.uiSetting.Load = value; }
		}

		/// <summary>
		/// 获取或设置标签显示时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签显示时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.uiSetting.Show; }
			set { this.uiSetting.Show = value; }
		}

		/// <summary>
		/// 获取或设置标签被添加时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被添加时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Add
		{
			get { return this.uiSetting.Add; }
			set { this.uiSetting.Add = value; }
		}

		/// <summary>
		/// 获取或设置标签被删除时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被删除时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.uiSetting.Remove; }
			set { this.uiSetting.Remove = value; }
		}

		/// <summary>
		/// 获取或设置标签被启用时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被启用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Enable
		{
			get { return this.uiSetting.Enable; }
			set { this.uiSetting.Enable = value; }
		}

		/// <summary>
		/// 获取或设置标签被禁用时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被禁用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Disable
		{
			get { return this.uiSetting.Disable; }
			set { this.uiSetting.Disable = value; }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取 Select 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Select 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting SelectAsync
		{
			get { return this.uiSetting.SelectAsync; }
		}
		#endregion

		#region " server "
		/// <summary>
		/// 在服务器端执行的选中索引改变事件.
		/// </summary>
		[Description ( "指示选中索引改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event TabsSelectEventHandler SelectSync;
		#endregion

		protected override bool isFaceless ( )
		{ return this.DesignMode && ( this.selector != string.Empty || this.html == string.Empty ); }

		protected override bool isFace ( )
		{ return this.DesignMode && this.selector == string.Empty && this.html != string.Empty; }

		protected override string facelessPrefix ( )
		{ return "Tabs"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.Cache )
				postfix += " <span style=\"color: #660066\">cache</span>";

			if ( this.Collapsible )
				postfix += " <span style=\"color: #660066\">collapsible</span>";

			return base.facelessPostfix ( ) + postfix;
		}

		protected override void AddAttributesToRender ( HtmlTextWriter writer )
		{
			base.AddAttributesToRender ( writer );

			if ( this.isFace ( ) )
				writer.AddAttribute ( HtmlTextWriterAttribute.Class,
					string.Format (
					"ui-tabs ui-widget ui-widget-content ui-corner-all{0}",
					this.Disabled ? " ui-tabs-disabled ui-state-disabled" : string.Empty
					)
					);

		}

		protected override void RenderContents ( HtmlTextWriter writer )
		{

			if ( null != this.SelectSync )
				this.Select = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "select;[%':ui.index%]" ) + "}";

			base.RenderContents ( writer );

		}

		/*
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
		*/

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

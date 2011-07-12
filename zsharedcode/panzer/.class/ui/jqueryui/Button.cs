/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIButton
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Button.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web.jqueryui;

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

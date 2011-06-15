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
		[Description ( "指示按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }, 暂不支持设计时显示" )]
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

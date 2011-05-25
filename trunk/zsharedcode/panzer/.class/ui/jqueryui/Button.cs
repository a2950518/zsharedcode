/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIButton
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Button.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/JQueryElement.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DraggableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DroppableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SortableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SelectableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ResizableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ParameterEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/WidgetSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/RepeaterSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryCoder.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/JQueryUI.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
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
	[DesignerAttribute ( typeof ( ButtonDesigner ) )]
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
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ), false ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value.ToString ( ).ToLower ( ) ); }
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
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.text ), true ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.text, value.ToString ( ).ToLower ( ) ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.icons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.icons, value ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.label ).Trim ( '\'' ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.label, string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'" ); }
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
			get { return this.editHelper.GetOuterEventEditValue ( EventType.click ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.click, value ); }
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
				this.widgetSetting.Type = this.type;

				this.widgetSetting.ButtonSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.clickAjax.Url != string.Empty )
				{
					this.clickAjax.WidgetEventType = EventType.click;
					this.widgetSetting.AjaxSettings.Add ( this.clickAjax );
				}

				if ( null != this.ClickSync )
					this.Click = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "click" ) + "}";

			}
			else if ( string.IsNullOrEmpty ( this.selector ) )
				switch ( this.type )
				{
					case WidgetType.button:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );

						writer.Write (
							"<{6} id=\"{0}\" class=\"{3}ui-button ui-widget ui-state-default ui-corner-all{2} ui-button-text-only\" style=\"{4}\" title=\"{5}\"><span class=\"ui-button-text\">{1}</span></{6}>",
							this.ClientID,
							this.Label,
							this.Disabled ? " ui-button-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( )
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

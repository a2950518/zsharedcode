/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDialog
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Dialog.cs
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
	/// jQuery UI 对话框插件.
	/// </summary>
	[ToolboxData ( "<{0}:Dialog runat=server></{0}:Dialog>" )]
	[DesignerAttribute ( typeof ( DialogDesigner ) )]
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
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ), false ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value.ToString ( ).ToLower ( ) ); }
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
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.autoOpen ), true ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoOpen, value.ToString ( ).ToLower ( ) ); }
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
		[DefaultValue ( true )]
		[Description ( "指示是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool CloseOnEscape
		{
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.closeOnEscape ), true ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeOnEscape, value.ToString ( ).ToLower ( ) ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeText ).Trim ( '\'' ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeText, string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'" ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dialogClass ).Trim ( '\'' ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dialogClass, string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'" ); }
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
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.draggable ), true ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.draggable, value.ToString ( ).ToLower ( ) ); }
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
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.height ), -1 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.height, value <= -1 ? string.Empty : value.ToString ( ) ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.hide ).Trim ( '\'' ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.hide, string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'" ); }
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
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.maxHeight ), -1 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxHeight, value <= -1 ? string.Empty : value.ToString ( ) ); }
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
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.maxWidth ), -1 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxWidth, value <= -1 ? string.Empty : value.ToString ( ) ); }
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
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.minHeight ), 150 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minHeight, value <= 0 || value == 150 ? string.Empty : value.ToString ( ) ); }
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
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.minWidth ), 150 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minWidth, value <= 0 || value == 150 ? string.Empty : value.ToString ( ) ); }
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
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.modal ), true ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.modal, value.ToString ( ).ToLower ( ) ); }
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
		[DefaultValue ( true )]
		[Description ( "指示是否允许缩放, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Resizable
		{
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.resizable ), true ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizable, value.ToString ( ).ToLower ( ) ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.show ).Trim ( '\'' ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.show, string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'" ); }
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
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.stack ), true ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stack, value.ToString ( ).ToLower ( ) ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.title ).Trim ( '\'' ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.title, string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'" ); }
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
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.width ), 300 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.width, value <= 0 || value == 300 ? string.Empty : value.ToString ( ) ); }
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
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.zIndex ), 1000 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.zIndex, value <= 0 || value == 1000 ? string.Empty : value.ToString ( ) ); }
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
		public new string Focus
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
				this.widgetSetting.Type = this.type;

				this.widgetSetting.DialogSetting.SetEditHelper ( this.editHelper );

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
				switch ( this.type )
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

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Dialog.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 对话框插件.
	/// </summary>
	[ToolboxData ( "<{0}:Dialog runat=server></{0}:Dialog>" )]
	public class Dialog
		: JQueryWidget<DialogSetting>
	{

		/// <summary>
		/// 创建一个 jQuery UI 对话框.
		/// </summary>
		public Dialog ( )
			: base ( new DialogSetting ( ), HtmlTextWriterTag.Div )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置对话框是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示对话框是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置对话框是否自动打开, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示对话框是否自动打开, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool AutoOpen
		{
			get { return this.uiSetting.AutoOpen; }
			set { this.uiSetting.AutoOpen = value; }
		}

		/// <summary>
		/// 获取或设置对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }, 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Buttons
		{
			get { return this.uiSetting.Buttons; }
			set { this.uiSetting.Buttons = value; }
		}

		/// <summary>
		/// 获取或设置是否在按下 Esc 时关闭对话框, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否在按下 Esc 时关闭对话框, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool CloseOnEscape
		{
			get { return this.uiSetting.CloseOnEscape; }
			set { this.uiSetting.CloseOnEscape = value; }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 默认为 "close".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "close" )]
		[Description ( "指示关闭链接的文本, 默认为 close" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.uiSetting.CloseText; }
			set { this.uiSetting.CloseText = value; }
		}

		/// <summary>
		/// 获取或设置对话框的样式, 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框的样式, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string DialogClass
		{
			get { return this.uiSetting.DialogClass; }
			set { this.uiSetting.DialogClass = value; }
		}

		/// <summary>
		/// 获取或设置是否允许拖动, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否允许拖动, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool Draggable
		{
			get { return this.uiSetting.Draggable; }
			set { this.uiSetting.Draggable = value; }
		}

		/// <summary>
		/// 获取或设置对话框高度, 默认 -1 不设置高度.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( -1 )]
		[Description ( "指示对话框高度, 默认 -1 不设置高度" )]
		[NotifyParentProperty ( true )]
		public new int Height
		{
			get { return this.uiSetting.Height; }
			set { this.uiSetting.Height = value; }
		}

		/// <summary>
		/// 获取或设置关闭对话框时的动画, 默认空字符串.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭对话框时的动画, 默认空字符串" )]
		[NotifyParentProperty ( true )]
		public string Hide
		{
			get { return this.uiSetting.Hide; }
			set { this.uiSetting.Hide = value; }
		}

		/// <summary>
		/// 获取或设置最大高度, 默认 -1 不设置最大高度.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( -1 )]
		[Description ( "指示最大高度, 默认 -1 不设置最大高度" )]
		[NotifyParentProperty ( true )]
		public int MaxHeight
		{
			get { return this.uiSetting.MaxHeight; }
			set { this.uiSetting.MaxHeight = value; }
		}

		/// <summary>
		/// 获取或设置最大宽度, 默认 -1 不设置最大宽度.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( -1 )]
		[Description ( "指示最大宽度, 默认 -1 不设置最大宽度" )]
		[NotifyParentProperty ( true )]
		public int MaxWidth
		{
			get { return this.uiSetting.MaxWidth; }
			set { this.uiSetting.MaxWidth = value; }
		}

		/// <summary>
		/// 获取或设置最小高度, 默认为 150.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 150 )]
		[Description ( "指示最小高度, 默认为 150" )]
		[NotifyParentProperty ( true )]
		public int MinHeight
		{
			get { return this.uiSetting.MinHeight; }
			set { this.uiSetting.MinHeight = value; }
		}

		/// <summary>
		/// 获取或设置最小宽度, 默认为 150.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 150 )]
		[Description ( "指示最小宽度, 默认为 150" )]
		[NotifyParentProperty ( true )]
		public int MinWidth
		{
			get { return this.uiSetting.MinWidth; }
			set { this.uiSetting.MinWidth = value; }
		}

		/// <summary>
		/// 获取或设置是否使用 modal 模式, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否使用 modal 模式, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Modal
		{
			get { return this.uiSetting.Modal; }
			set { this.uiSetting.Modal = value; }
		}

		/// <summary>
		/// 获取或设置对话框的位置, 比如: "['right','top']", 默认为 "'center'".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "'center'" )]
		[Description ( "指示对话框的位置, 比如: ['right','top'], 默认为 'center'" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.uiSetting.Position; }
			set { this.uiSetting.Position = value; }
		}

		/// <summary>
		/// 获取或设置是否允许缩放, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否允许缩放, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool Resizable
		{
			get { return this.uiSetting.Resizable; }
			set { this.uiSetting.Resizable = value; }
		}

		/// <summary>
		/// 获取或设置显示动画的选项, 默认为空字符串.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示动画的选项, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.uiSetting.Show; }
			set { this.uiSetting.Show = value; }
		}

		/// <summary>
		/// 获取或设置是否自动置顶, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否自动置顶, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool Stack
		{
			get { return this.uiSetting.Stack; }
			set { this.uiSetting.Stack = value; }
		}

		/// <summary>
		/// 获取或设置对话框标题, 默认空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框标题, 默认空字符串" )]
		[NotifyParentProperty ( true )]
		public string Title
		{
			get { return this.uiSetting.Title; }
			set { this.uiSetting.Title = value; }
		}

		/// <summary>
		/// 获取或设置对话框宽度, 默认为 300.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 300 )]
		[Description ( "指示对话框宽度, 默认为 300" )]
		[NotifyParentProperty ( true )]
		public new int Width
		{
			get { return this.uiSetting.Width; }
			set { this.uiSetting.Width = value; }
		}

		/// <summary>
		/// 获取或设置对话框 Z 轴顺序, 默认为 1000.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 1000 )]
		[Description ( "指示对话框 Z 轴顺序, 默认为 1000" )]
		[NotifyParentProperty ( true )]
		public int ZIndex
		{
			get { return this.uiSetting.ZIndex; }
			set { this.uiSetting.ZIndex = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置对话框被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置对话框关闭之前的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭之前的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeClose
		{
			get { return this.uiSetting.BeforeClose; }
			set { this.uiSetting.BeforeClose = value; }
		}

		/// <summary>
		/// 获取或设置对话框打开时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.uiSetting.Open; }
			set { this.uiSetting.Open = value; }
		}

		/// <summary>
		/// 获取或设置对话框获得焦点时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public new string Focus
		{
			get { return this.uiSetting.Focus; }
			set { this.uiSetting.Focus = value; }
		}

		/// <summary>
		/// 获取或设置对话框拖动开始时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStart
		{
			get { return this.uiSetting.DragStart; }
			set { this.uiSetting.DragStart = value; }
		}

		/// <summary>
		/// 获取或设置对话框拖动时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drag
		{
			get { return this.uiSetting.Drag; }
			set { this.uiSetting.Drag = value; }
		}

		/// <summary>
		/// 获取或设置对话框拖动结束时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStop
		{
			get { return this.uiSetting.DragStop; }
			set { this.uiSetting.DragStop = value; }
		}

		/// <summary>
		/// 获取或设置对话框缩放开始时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStart
		{
			get { return this.uiSetting.ResizeStart; }
			set { this.uiSetting.ResizeStart = value; }
		}

		/// <summary>
		/// 获取或设置对话框缩放时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Resize
		{
			get { return this.uiSetting.Resize; }
			set { this.uiSetting.Resize = value; }
		}

		/// <summary>
		/// 获取或设置对话框缩放结束时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStop
		{
			get { return this.uiSetting.ResizeStop; }
			set { this.uiSetting.ResizeStop = value; }
		}

		/// <summary>
		/// 获取或设置对话框关闭时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.uiSetting.Close; }
			set { this.uiSetting.Close = value; }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取 Open 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Open 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting OpenAsync
		{
			get { return this.uiSetting.OpenAsync; }
		}

		/// <summary>
		/// 获取 Close 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Close 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting CloseAsync
		{
			get { return this.uiSetting.CloseAsync; }
		}
		#endregion

		protected override bool isFaceless ( )
		{ return this.DesignMode && ( this.selector != string.Empty || this.html == string.Empty ); }

		protected override bool isFace ( )
		{ return this.DesignMode && this.selector == string.Empty && this.html != string.Empty; }

		protected override string facelessPrefix ( )
		{ return "Dialog"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.Draggable )
				postfix += " <span style=\"color: #660066\">draggable</span>";

			if ( this.Modal )
				postfix += " <span style=\"color: #660066\">model</span>";

			postfix += string.Format(" <span style=\"color: #660066\">{0}</span>", this.Position);

			if ( this.Resizable )
				postfix += " <span style=\"color: #660066\">resizable</span>";

			if ( this.Title != string.Empty )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Title );

			return base.facelessPostfix ( ) + postfix;
		}

		protected override void AddAttributesToRender ( HtmlTextWriter writer )
		{
			base.AddAttributesToRender ( writer );

			if ( this.isFace ( ) )
				writer.AddAttribute ( HtmlTextWriterAttribute.Class,
					string.Format (
					"ui-dialog ui-widget ui-widget-content ui-corner-all{0}{1}{2}",
					this.Disabled ? " ui-dialog-disabled ui-state-disabled" : string.Empty,
					this.Draggable ? " ui-draggable" : string.Empty,
					this.Resizable ? " ui-resizable" : string.Empty
					)
					);

		}

		/*
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
							this.Height == -1 ? "auto" : this.Height.ToString ( ) + "px",
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
		*/

	}

}

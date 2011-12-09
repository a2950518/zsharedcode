/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DialogSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DialogSetting "
	/// <summary>
	/// 对话框设置.
	/// </summary>
	public sealed class DialogSetting
		: WidgetSetting
	{

		#region " option "
		/// <summary>
		/// 获取或设置对话框是否可用, 默认为 false.
		/// </summary>
		[Category("行为")]
		[DefaultValue(false)]
		[Description("指示对话框是否可用, 默认为 false")]
		[NotifyParentProperty(true)]
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.disabled, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.disabled, value, false); }
		}

		/// <summary>
		/// 获取或设置对话框是否自动打开, 默认为 true.
		/// </summary>
		[Category("行为")]
		[DefaultValue(true)]
		[Description("指示对话框是否自动打开, 默认为 true")]
		[NotifyParentProperty(true)]
		public bool AutoOpen
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.autoOpen, true); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.autoOpen, value, true); }
		}

		/// <summary>
		/// 获取或设置对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }, 默认为空字符串.
		/// </summary>
		[Category("外观")]
		[DefaultValue("")]
		[Description("指示对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }, 默认为空字符串")]
		[NotifyParentProperty(true)]
		public string Buttons
		{
			get { return this.settingHelper.GetOptionValue(OptionType.buttons); }
			set { this.settingHelper.SetOptionValue(OptionType.buttons, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置是否在按下 Esc 时关闭对话框, 默认为 true.
		/// </summary>
		[Category("行为")]
		[DefaultValue(true)]
		[Description("指示是否在按下 Esc 时关闭对话框, 默认为 true")]
		[NotifyParentProperty(true)]
		public bool CloseOnEscape
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.closeOnEscape, true); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.closeOnEscape, value, true); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 默认为 "close".
		/// </summary>
		[Category("外观")]
		[DefaultValue("close")]
		[Description("指示关闭链接的文本, 默认为 close")]
		[NotifyParentProperty(true)]
		public string CloseText
		{
			get { return this.settingHelper.GetOptionValueToString(OptionType.closeText, "close"); }
			set { this.settingHelper.SetOptionValueToString(OptionType.closeText, value, "close"); }
		}

		/// <summary>
		/// 获取或设置对话框的样式, 默认为空字符串.
		/// </summary>
		[Category("外观")]
		[DefaultValue("")]
		[Description("指示对话框的样式, 默认为空字符串")]
		[NotifyParentProperty(true)]
		public string DialogClass
		{
			get { return this.settingHelper.GetOptionValueToString(OptionType.dialogClass, string.Empty); }
			set { this.settingHelper.SetOptionValueToString(OptionType.dialogClass, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置是否允许拖动, 默认为 true.
		/// </summary>
		[Category("行为")]
		[DefaultValue(true)]
		[Description("指示是否允许拖动, 默认为 true")]
		[NotifyParentProperty(true)]
		public bool Draggable
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.draggable, true); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.draggable, value, true); }
		}

		/// <summary>
		/// 获取或设置对话框高度, 默认 -1 不设置高度.
		/// </summary>
		[Category("外观")]
		[DefaultValue(-1)]
		[Description("指示对话框高度, 默认 -1 不设置高度")]
		[NotifyParentProperty(true)]
		public int Height
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.height, -1); }
			set { this.settingHelper.SetOptionValue(OptionType.height, (value <= 0) ? "-1" : value.ToString(), "-1"); }
		}

		/// <summary>
		/// 获取或设置关闭对话框时的动画, 默认空字符串.
		/// </summary>
		[Category("动画")]
		[DefaultValue("")]
		[Description("指示关闭对话框时的动画, 默认空字符串")]
		[NotifyParentProperty(true)]
		public string Hide
		{
			get { return this.settingHelper.GetOptionValueToString(OptionType.hide, string.Empty); }
			set { this.settingHelper.SetOptionValueToString(OptionType.hide, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置最大高度, 默认 -1 不设置最大高度.
		/// </summary>
		[Category("外观")]
		[DefaultValue(-1)]
		[Description("指示最大高度, 默认 -1 不设置最大高度")]
		[NotifyParentProperty(true)]
		public int MaxHeight
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.maxHeight, -1); }
			set { this.settingHelper.SetOptionValue(OptionType.maxHeight, (value <= 0) ? "-1" : value.ToString(), "-1"); }
		}

		/// <summary>
		/// 获取或设置最大宽度, 默认 -1 不设置最大宽度.
		/// </summary>
		[Category("外观")]
		[DefaultValue(-1)]
		[Description("指示最大宽度, 默认 -1 不设置最大宽度")]
		[NotifyParentProperty(true)]
		public int MaxWidth
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.maxWidth, -1); }
			set { this.settingHelper.SetOptionValue(OptionType.maxWidth, (value <= 0) ? "-1" : value.ToString(), "-1"); }
		}

		/// <summary>
		/// 获取或设置最小高度, 默认为 150.
		/// </summary>
		[Category("外观")]
		[DefaultValue(150)]
		[Description("指示最小高度, 默认为 150")]
		[NotifyParentProperty(true)]
		public int MinHeight
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.minHeight, 150); }
			set { this.settingHelper.SetOptionValue(OptionType.minHeight, (value <= 0) ? "150" : value.ToString(), "150"); }
		}

		/// <summary>
		/// 获取或设置最小宽度, 默认为 150.
		/// </summary>
		[Category("外观")]
		[DefaultValue(150)]
		[Description("指示最小宽度, 默认为 150")]
		[NotifyParentProperty(true)]
		public int MinWidth
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.minWidth, 150); }
			set { this.settingHelper.SetOptionValue(OptionType.minWidth, (value <= 0) ? "150" : value.ToString(), "150"); }
		}

		/// <summary>
		/// 获取或设置是否使用 modal 模式, 默认为 false.
		/// </summary>
		[Category("行为")]
		[DefaultValue(false)]
		[Description("指示是否使用 modal 模式, 默认为 false")]
		[NotifyParentProperty(true)]
		public bool Modal
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.modal, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.modal, value, false); }
		}

		/// <summary>
		/// 获取或设置对话框的位置, 比如: "['right','top']", 默认为 "'center'".
		/// </summary>
		[Category("外观")]
		[DefaultValue("'center'")]
		[Description("指示对话框的位置, 比如: ['right','top'], 默认为 'center'")]
		[NotifyParentProperty(true)]
		public string Position
		{
			get { return this.settingHelper.GetOptionValue(OptionType.position, "'center'"); }
			set { this.settingHelper.SetOptionValue(OptionType.position, value, "'center'"); }
		}

		/// <summary>
		/// 获取或设置是否允许缩放, 默认为 true.
		/// </summary>
		[Category("行为")]
		[DefaultValue(true)]
		[Description("指示是否允许缩放, 默认为 true")]
		[NotifyParentProperty(true)]
		public bool Resizable
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.resizable, true); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.resizable, value, true); }
		}

		/// <summary>
		/// 获取或设置显示动画的选项, 默认为空字符串.
		/// </summary>
		[Category("动画")]
		[DefaultValue("")]
		[Description("指示显示动画的选项, 默认为空字符串")]
		[NotifyParentProperty(true)]
		public string Show
		{
			get { return this.settingHelper.GetOptionValue(OptionType.show); }
			set { this.settingHelper.SetOptionValue(OptionType.show, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置是否自动置顶, 默认为 true.
		/// </summary>
		[Category("行为")]
		[DefaultValue(true)]
		[Description("指示是否自动置顶, 默认为 true")]
		[NotifyParentProperty(true)]
		public bool Stack
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.stack, true); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.stack, value, true); }
		}

		/// <summary>
		/// 获取或设置对话框标题, 默认空字符串.
		/// </summary>
		[Category("外观")]
		[DefaultValue("")]
		[Description("指示对话框标题, 默认空字符串")]
		[NotifyParentProperty(true)]
		public string Title
		{
			get { return this.settingHelper.GetOptionValueToString(OptionType.title, string.Empty); }
			set { this.settingHelper.SetOptionValueToString(OptionType.title, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框宽度, 默认为 300.
		/// </summary>
		[Category("外观")]
		[DefaultValue(300)]
		[Description("指示对话框宽度, 默认为 300")]
		[NotifyParentProperty(true)]
		public int Width
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.width, 300); }
			set { this.settingHelper.SetOptionValue(OptionType.width, (value <= 0) ? "300" : value.ToString(), "300"); }
		}

		/// <summary>
		/// 获取或设置对话框 Z 轴顺序, 默认为 1000.
		/// </summary>
		[Category("外观")]
		[DefaultValue(1000)]
		[Description("指示对话框 Z 轴顺序, 默认为 1000")]
		[NotifyParentProperty(true)]
		public int ZIndex
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.zIndex, 1000); }
			set { this.settingHelper.SetOptionValue(OptionType.zIndex, (value <= 0) ? "1000" : value.ToString(), "1000"); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置对话框被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框被创建时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Create
		{
			get { return this.settingHelper.GetOptionValue(OptionType.create); }
			set { this.settingHelper.SetOptionValue(OptionType.create, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框关闭之前的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框关闭之前的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string BeforeClose
		{
			get { return this.settingHelper.GetOptionValue(OptionType.beforeClose); }
			set { this.settingHelper.SetOptionValue(OptionType.beforeClose, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框打开时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框打开时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Open
		{
			get { return this.settingHelper.GetOptionValue(OptionType.open); }
			set { this.settingHelper.SetOptionValue(OptionType.open, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框获得焦点时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框获得焦点时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Focus
		{
			get { return this.settingHelper.GetOptionValue(OptionType.focus); }
			set { this.settingHelper.SetOptionValue(OptionType.focus, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框拖动开始时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框拖动开始时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string DragStart
		{
			get { return this.settingHelper.GetOptionValue(OptionType.dragStart); }
			set { this.settingHelper.SetOptionValue(OptionType.dragStart, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框拖动时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框拖动时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Drag
		{
			get { return this.settingHelper.GetOptionValue(OptionType.drag); }
			set { this.settingHelper.SetOptionValue(OptionType.drag, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框拖动结束时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框拖动结束时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string DragStop
		{
			get { return this.settingHelper.GetOptionValue(OptionType.dragStop); }
			set { this.settingHelper.SetOptionValue(OptionType.dragStop, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框缩放开始时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框缩放开始时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string ResizeStart
		{
			get { return this.settingHelper.GetOptionValue(OptionType.resizeStart); }
			set { this.settingHelper.SetOptionValue(OptionType.resizeStart, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框缩放时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框缩放时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Resize
		{
			get { return this.settingHelper.GetOptionValue(OptionType.resize); }
			set { this.settingHelper.SetOptionValue(OptionType.resize, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框缩放结束时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框缩放结束时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string ResizeStop
		{
			get { return this.settingHelper.GetOptionValue(OptionType.resizeStop); }
			set { this.settingHelper.SetOptionValue(OptionType.resizeStop, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置对话框关闭时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示对话框关闭时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Close
		{
			get { return this.settingHelper.GetOptionValue(OptionType.close); }
			set { this.settingHelper.SetOptionValue(OptionType.close, value, string.Empty); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置对话框打开时触发的 Ajax 操作的相关设置.
		/// </summary>
		public AjaxSetting OpenAsync
		{
			get { return this.ajaxs[0]; }
			set
			{

				if (null != value)
					this.ajaxs[0] = value;

			}
		}

		/// <summary>
		/// 获取或设置对话框关闭时触发的 Ajax 操作的相关设置.
		/// </summary>
		public AjaxSetting CloseAsync
		{
			get { return this.ajaxs[1]; }
			set
			{

				if (null != value)
					this.ajaxs[1] = value;

			}
		}
		#endregion

		/// <summary>
		/// 创建一个对话框设置.
		/// </summary>
		public DialogSetting()
			: base(WidgetType.dialog, 2)
		{ }

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine()
		{
			this.OpenAsync.EventType = EventType.dialogopen;
			this.CloseAsync.EventType = EventType.dialogclose;

			base.Recombine ( );
		}

	}
	#endregion

}

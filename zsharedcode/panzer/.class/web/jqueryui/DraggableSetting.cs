/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DraggableSetting "
	/// <summary>
	/// jQuery UI 拖动的相关设置.
	/// </summary>
	public sealed class DraggableSetting
		: InteractionSetting
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
		}

		/// <summary>
		/// Helper 类型.
		/// </summary>
		public enum HelperType
		{
			/// <summary>
			/// 使用自身.
			/// </summary>
			original = 0,
			/// <summary>
			/// 使用副本.
			/// </summary>
			clone = 1,
		}

		/// <summary>
		/// SnapMode 类型.
		/// </summary>
		public enum SnapModeType
		{
			/// <summary>
			/// 内部和外部附着.
			/// </summary>
			both = 0,
			/// <summary>
			/// 内部附着.
			/// </summary>
			inner = 1,
			/// <summary>
			/// 外部附着.
			/// </summary>
			outer = 2,
		}
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置拖动是否可用, 默认为 false.
		/// </summary>
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.disabled, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.disabled, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否添加样式, 默认为 true.
		/// </summary>
		public bool AddClasses
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.addClasses, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.addClasses, value, true ); }
		}
		/// <summary>
		/// 获取或设置鼠标点击在何处拖动有效, 可以是 "parent", "body" 等, 默认为 "parent".
		/// </summary>
		public string AppendTo
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.appendTo, "parent" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.appendTo, value, "parent" ); }
		}

		/// <summary>
		/// 获取或设置拖动的方向, 可以是 x, y, 默认为 null.
		/// </summary>
		public AxisType Axis
		{
			get { return this.settingHelper.GetOptionValueToEnum<AxisType> ( OptionType.axis, AxisType.@null ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.axis, value.ToString ( ), AxisType.@null.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置不参加拖动的元素, 是一个选择器, 默认为 ":input,option".
		/// </summary>
		public string Cancel
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.cancel, ":input,option" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.cancel, value, ":input,option" ); }
		}

		/// <summary>
		/// 获取或设置关联的排列, 是一个选择器, 默认为空字符串.
		/// </summary>
		public string ConnectToSortable
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.connectToSortable, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.connectToSortable, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置拖动所在的容器, 默认为 null.
		/// </summary>
		public ContainmentType Containment
		{
			get { return this.settingHelper.GetOptionValueToEnum<ContainmentType> ( OptionType.containment, ContainmentType.@null ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.containment, value.ToString ( ), ContainmentType.@null.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置鼠标样式, 默认为 "auto".
		/// </summary>
		public string Cursor
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.cursor, "auto" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.cursor, value, "auto" ); }
		}

		/// <summary>
		/// 获取或设置鼠标的相对位置, 对应一个 javascript 对象, "{ top: 1, left: 2, right: 3, bottom: 4 }", 需要具有选择其中的一个或者两个属性, 默认为空字符串.
		/// </summary>
		public string CursorAt
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.cursorAt ); }
			set { this.settingHelper.SetOptionValue ( OptionType.cursorAt, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算, 默认为 0.
		/// </summary>
		public int Delay
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.delay, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.delay, ( value < 0 ) ? "0" : value.ToString ( ), "0" ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发拖动, 默认为 1.
		/// </summary>
		public int Distance
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.distance, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.distance, ( value <= 0 ) ? "1" : value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来移动元素, 为一个数组, 比如: "[10, 30]", 默认为空字符串.
		/// </summary>
		public string Grid
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.grid ); }
			set { this.settingHelper.SetOptionValue ( OptionType.grid, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置用于点击的元素, 点击后拖动才有效, 对应一个 dom 元素或者选择器.
		/// </summary>
		public string Handle
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.handle, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.handle, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否使用副本 original 针对元素本身, clone 针对元素的副本, 默认为 original.
		/// </summary>
		public HelperType Helper
		{
			get { return this.settingHelper.GetOptionValueToEnum<HelperType> ( OptionType.helper, HelperType.original ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.helper, value.ToString ( ), HelperType.original.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置是否引发 iframe 中的事件, 默认为 false.
		/// </summary>
		public bool IFrameFix
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.iframeFix, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.iframeFix, value, false ); }
		}

		/// <summary>
		/// 获取或设置元素拖动时的透明度, 0 到 1 之间, 默认为 1.
		/// </summary>
		public double Opacity
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.opacity, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.opacity, ( value < 0 || value > 1 ) ? "1" : value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置是否刷新位置, 默认为 false.
		/// </summary>
		public bool RefreshPositions
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.refreshPositions, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.refreshPositions, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否在拖动后播放恢复原位的动画, 默认为 false.
		/// </summary>
		public bool Revert
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.revert, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.revert, value, false ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画播放时间, 默认为 500.
		/// </summary>
		public int RevertDuration
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.revertDuration, 500 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.revertDuration, ( value <= 0 ) ? "500" : value.ToString ( ), "500" ); }
		}

		/// <summary>
		/// 获取或设置范围, 默认为 "default".
		/// </summary>
		public string Scope
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.scope, "default" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.scope, value, "default" ); }
		}

		/// <summary>
		/// 获取或设置是否可以显示滚动轴, 默认为 true.
		/// </summary>
		public bool Scroll
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.scroll, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.scroll, value, true ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的灵敏度, 默认为 20.
		/// </summary>
		public int ScrollSensitivity
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.scrollSensitivity, 20 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.scrollSensitivity, ( value <= 0 ) ? "20" : value.ToString ( ), "20" ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的速度, 默认为 20.
		/// </summary>
		public int ScrollSpeed
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.scrollSpeed, 20 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.scrollSpeed, ( value <= 0 ) ? "20" : value.ToString ( ), "20" ); }
		}

		/// <summary>
		/// 获取或设置是否附着, 默认为 false.
		/// </summary>
		public bool Snap
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.snap, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.snap, value, false ); }
		}

		/// <summary>
		/// 获取或设置附着模式, 可以是 inner, outer, 默认为 both.
		/// </summary>
		public SnapModeType SnapMode
		{
			get { return this.settingHelper.GetOptionValueToEnum<SnapModeType> ( OptionType.snapMode, SnapModeType.both ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.snapMode, value.ToString ( ), SnapModeType.both.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置附着发生的距离, 默认为 20.
		/// </summary>
		public int SnapTolerance
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.snapTolerance, 20 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.snapTolerance, ( value < 0 ) ? "20" : value.ToString ( ), "20" ); }
		}

		/// <summary>
		/// 获取或设置控制 z 轴顺序, 对应一个选择器, 默认为空字符串.
		/// </summary>
		public string Stack
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.stack, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.stack, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置 Z 轴顺序, 默认 -1 不设置顺序.
		/// </summary>
		public int ZIndex
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.zIndex, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.zIndex, value.ToString ( ), "-1" ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置拖动被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Create
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.create ); }
			set { this.settingHelper.SetOptionValue ( OptionType.create, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置拖动开始的时候的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Start
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.start ); }
			set { this.settingHelper.SetOptionValue ( OptionType.start, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置拖动完成时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Drag
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.drag ); }
			set { this.settingHelper.SetOptionValue ( OptionType.drag, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置拖动停止的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Stop
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.stop ); }
			set { this.settingHelper.SetOptionValue ( OptionType.stop, value, string.Empty ); }
		}
		#endregion

		/// <summary>
		/// 创建 jQuery UI 拖动的相关设置.
		/// </summary>
		public DraggableSetting ( )
			: this ( null )
		{ }
		/// <summary>
		/// 创建 jQuery UI 拖动的相关设置.
		/// </summary>
		/// <param name="options">拖动相关选项.</param>
		public DraggableSetting ( Option[] options )
			: base ( InteractionType.draggable, options )
		{ }

	}
	#endregion

}

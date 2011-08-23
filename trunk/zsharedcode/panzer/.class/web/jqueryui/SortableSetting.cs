/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " SortableSetting "
	/// <summary>
	/// jQuery UI 排列的相关设置.
	/// </summary>
	public sealed class SortableSetting
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
		/// Tolerance 类型.
		/// </summary>
		public enum ToleranceType
		{
			/// <summary>
			/// 一半进入可以拖放.
			/// </summary>
			intersect = 0,
			/// <summary>
			/// 鼠标进入即可拖放.
			/// </summary>
			pointer = 1,
		}
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置排列是否可用, 默认为 false.
		/// </summary>
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.disabled, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.disabled, value, false ); }
		}

		/// <summary>
		/// 获取或设置鼠标点击在何处排序有效, 可以是 "parent", "body" 等, 默认为 "parent".
		/// </summary>
		public string AppendTo
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.appendTo, "parent" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.appendTo, value, "parent" ); }
		}

		/// <summary>
		/// 获取或设置排列时拖动的方向, 可以是 x, y, 默认为 null.
		/// </summary>
		public AxisType Axis
		{
			get { return this.settingHelper.GetOptionValueToEnum<AxisType> ( OptionType.axis, AxisType.@null ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.axis, value.ToString ( ), AxisType.@null.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置不参加排列的元素, 是一个选择器, 默认为 ":input,option".
		/// </summary>
		public string Cancel
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.cancel, ":input,option" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.cancel, value, ":input,option" ); }
		}

		/// <summary>
		/// 获取或设置关联的排列, 可以将元素拖放在关联列表中, 是一个选择器, 默认为空字符串.
		/// </summary>
		public string ConnectWith
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.connectWith, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.connectWith, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置排列所在的容器, 默认为 null.
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
		/// 获取或设置鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性, 默认为空字符串.
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
		/// 获取或设置鼠标移动多少像素触发排列, 默认为 1.
		/// </summary>
		public int Distance
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.distance, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.distance, ( value <= 0 ) ? "1" : value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置是否可以将条目拖放到空的关联列表中, 默认为 true.
		/// </summary>
		public bool DropOnEmpty
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.dropOnEmpty, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.dropOnEmpty, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否强制 helper 拥有尺寸, 默认为 false.
		/// </summary>
		public bool ForceHelperSize
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.forceHelperSize, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.forceHelperSize, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否强制 placeholder 拥有尺寸, 默认为 false.
		/// </summary>
		public bool ForcePlaceholderSize
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.forcePlaceholderSize, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.forcePlaceholderSize, value, false ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来移动元素, 为一个数组, 比如: [10, 30], 默认为空字符串.
		/// </summary>
		public string Grid
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.grid ); }
			set { this.settingHelper.SetOptionValue ( OptionType.grid, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置用于点击的元素, 点击后排列才有效, 对应一个 dom 元素或者选择器.
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
		/// 获取或设置参与排列的元素, 对应选择器, 默认为 "> *".
		/// </summary>
		public string Items
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.items, "> *" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.items, value, "> *" ); }
		}

		/// <summary>
		/// 获取或设置元素排列时的透明度, 0 到 1 之间, 默认为 1.
		/// </summary>
		public double Opacity
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.opacity, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.opacity, ( value < 0 || value > 1 ) ? "1" : value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置 placeholder 的样式, 默认空字符串.
		/// </summary>
		public string Placeholder
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.placeholder, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.placeholder, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否在排列后播放恢复原位的动画, 默认为 false.
		/// </summary>
		public bool Revert
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.revert, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.revert, value, false ); }
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
		/// 获取或设置排列中拖放的触发方式, 默认 intersect.
		/// </summary>
		public ToleranceType Tolerance
		{
			get { return this.settingHelper.GetOptionValueToEnum<ToleranceType> ( OptionType.tolerance, ToleranceType.intersect ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.tolerance, value.ToString ( ), ToleranceType.intersect.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置 Z 轴顺序, 默认 1000.
		/// </summary>
		public int ZIndex
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.zIndex, 1000 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.zIndex, value.ToString ( ), "1000" ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置排列被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Create
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.create ); }
			set { this.settingHelper.SetOptionValue ( OptionType.create, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置排列开始的时候的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Start
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.start ); }
			set { this.settingHelper.SetOptionValue ( OptionType.start, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置排列时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Sort
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.sort ); }
			set { this.settingHelper.SetOptionValue ( OptionType.sort, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置排列改变的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Change
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.change ); }
			set { this.settingHelper.SetOptionValue ( OptionType.change, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置排列停止之前的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string BeforeStop
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.beforeStop ); }
			set { this.settingHelper.SetOptionValue ( OptionType.beforeStop, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置排列停止的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Stop
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.stop ); }
			set { this.settingHelper.SetOptionValue ( OptionType.stop, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置 dom 元素改变的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Update
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.update ); }
			set { this.settingHelper.SetOptionValue ( OptionType.update, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置接收到元素的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Receive
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.receive ); }
			set { this.settingHelper.SetOptionValue ( OptionType.receive, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置元素被移除的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Remove
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.remove ); }
			set { this.settingHelper.SetOptionValue ( OptionType.remove, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置元素滑过时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Over
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.over ); }
			set { this.settingHelper.SetOptionValue ( OptionType.over, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置元素滑出时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Out
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.@out ); }
			set { this.settingHelper.SetOptionValue ( OptionType.@out, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置排列被激活时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Activate
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.activate ); }
			set { this.settingHelper.SetOptionValue ( OptionType.activate, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置排列取消激活时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Deactivate
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.deactivate ); }
			set { this.settingHelper.SetOptionValue ( OptionType.deactivate, value, string.Empty ); }
		}
		#endregion

		/// <summary>
		/// 创建 jQuery UI 排列的相关设置.
		/// </summary>
		public SortableSetting ( )
			: this ( null )
		{ }
		/// <summary>
		/// 创建 jQuery UI 排列的相关设置.
		/// </summary>
		/// <param name="options">排列相关选项.</param>
		public SortableSetting ( Option[] options )
			: base ( InteractionType.sortable, options )
		{ }

	}
	#endregion

}

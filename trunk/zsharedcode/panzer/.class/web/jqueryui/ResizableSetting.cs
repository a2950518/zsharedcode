/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ResizableSetting "
	/// <summary>
	/// jQuery UI 缩放的相关设置.
	/// </summary>
	public sealed class ResizableSetting
		: InteractionSetting
	{

		#region " Enum "
		/// <summary>
		/// AnimateDuration 类型.
		/// </summary>
		public enum AnimateDurationType
		{
			/// <summary>
			/// 缓慢的播放.
			/// </summary>
			slow = 0,
			/// <summary>
			/// 正常的播放.
			/// </summary>
			normal = 1,
			/// <summary>
			/// 快速的播放.
			/// </summary>
			fast = 2,
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
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置缩放是否可用, 默认为 false.
		/// </summary>
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.disabled, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.disabled, value, false ); }
		}

		/// <summary>
		/// 获取或设置同时缩放的内容, 对应一个选择器, 默认空字符串.
		/// </summary>
		public string AlsoResize
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.alsoResize, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.alsoResize, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否播放缩放的动画, 默认为 false.
		/// </summary>
		public bool Animate
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.animate, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.animate, value, false ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画时长, 默认为 slow.
		/// </summary>
		public AnimateDurationType AnimateDuration
		{
			get { return this.settingHelper.GetOptionValueToEnum<AnimateDurationType> ( OptionType.animateDuration, AnimateDurationType.slow ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.animateDuration, value.ToString ( ), AnimateDurationType.slow.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置动画效果, 默认为 swing.
		/// </summary>
		public string AnimateEasing
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.animateEasing, "swing" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.animateEasing, value, "swing" ); }
		}

		/// <summary>
		/// 获取或设置宽高比例, 比如: 9 / 16, 默认 -1 不设置.
		/// </summary>
		public double AspectRatio
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.aspectRatio, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.aspectRatio, ( value <= 0 ) ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置是否自动隐藏, 默认为 false.
		/// </summary>
		public bool AutoHide
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.autoHide, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.autoHide, value, false ); }
		}

		/// <summary>
		/// 获取或设置不参加缩放的元素, 是一个选择器, 默认为 ":input,option".
		/// </summary>
		public string Cancel
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.cancel, ":input,option" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.cancel, value, ":input,option" ); }
		}

		/// <summary>
		/// 获取或设置缩放所在的容器, 默认为 null.
		/// </summary>
		public ContainmentType Containment
		{
			get { return this.settingHelper.GetOptionValueToEnum<ContainmentType> ( OptionType.containment, ContainmentType.@null ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.containment, value.ToString ( ), ContainmentType.@null.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算, 默认为 0.
		/// </summary>
		public int Delay
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.delay, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.delay, ( value <= 0 ) ? "0" : value.ToString ( ), "0" ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发缩放, 默认为 1.
		/// </summary>
		public int Distance
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.distance, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.distance, ( value <= 0 ) ? "1" : value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置是否在缩放时使用阴影, 默认为 false.
		/// </summary>
		public bool Ghost
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.ghost, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.ghost, value, false ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来缩放, 为一个数组, 比如: "[10, 30]", 默认为空字符串.
		/// </summary>
		public string Grid
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.grid ); }
			set { this.settingHelper.SetOptionValue ( OptionType.grid, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置缩放的方向, 为一个字符串, 默认为 "e, s, se".
		/// </summary>
		public string Handles
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.handles, "e, s, se" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.handles, value, "e, s, se" ); }
		}

		/// <summary>
		/// 获取或设置 helper 的样式, 默认空字符串.
		/// </summary>
		public string Helper
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.helper, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.helper, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置缩放的最大高度, 默认 -1 不设置.
		/// </summary>
		public int MaxHeight
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.maxHeight, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.maxHeight, ( value <= 0 ) ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置缩放的最大宽度, 默认 -1 不设置.
		/// </summary>
		public int MaxWidth
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.maxWidth, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.maxWidth, ( value <= 0 ) ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置缩放的最小高度, 默认为 10.
		/// </summary>
		public int MinHeight
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.minHeight, 10 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.minHeight, ( value <= 0 ) ? "10" : value.ToString ( ), "10" ); }
		}

		/// <summary>
		/// 获取或设置缩放的最小宽度, 默认为 10.
		/// </summary>
		public int MinWidth
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.minWidth, 10 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.minWidth, ( value <= 0 ) ? "10" : value.ToString ( ), "10" ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置缩放被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Create
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.create ); }
			set { this.settingHelper.SetOptionValue ( OptionType.create, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置缩放开始的时候的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Start
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.start ); }
			set { this.settingHelper.SetOptionValue ( OptionType.start, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置缩放时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Resize
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.resize ); }
			set { this.settingHelper.SetOptionValue ( OptionType.resize, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置缩放停止的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Stop
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.stop ); }
			set { this.settingHelper.SetOptionValue ( OptionType.stop, value, string.Empty ); }
		}
		#endregion

		/// <summary>
		/// 创建 jQuery UI 缩放的相关设置.
		/// </summary>
		public ResizableSetting ( )
			: this ( null )
		{ }
		/// <summary>
		/// 创建 jQuery UI 缩放的相关设置.
		/// </summary>
		/// <param name="options">缩放相关选项.</param>
		public ResizableSetting ( Option[] options )
			: base ( InteractionType.resizable, options )
		{ }

	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " SelectableSetting "
	/// <summary>
	/// jQuery UI 选中的相关设置.
	/// </summary>
	public sealed class SelectableSetting
		: InteractionSetting
	{

		#region " Enum "
		/// <summary>
		/// Tolerance 类型.
		/// </summary>
		public enum ToleranceType
		{
			/// <summary>
			/// 接触即可拖放.
			/// </summary>
			touch = 0,
			/// <summary>
			/// 完全进入可以拖放.
			/// </summary>
			fit = 1,
		}
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置选中是否可用, 默认为 false.
		/// </summary>
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.disabled, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.disabled, value, false ); }
		}

		/// <summary>
		/// 获取或设置选中是否自动刷新, 默认为 true.
		/// </summary>
		public bool AutoRefresh
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.autoRefresh, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.autoRefresh, value, true ); }
		}

		/// <summary>
		/// 获取或设置不参加选中的元素, 是一个选择器, 默认为 ":input,option".
		/// </summary>
		public string Cancel
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.cancel, ":input,option" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.cancel, value, ":input,option" ); }
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
		/// 获取或设置鼠标移动多少像素触发选中, 默认为 0.
		/// </summary>
		public int Distance
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.distance, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.distance, ( value <= 0 ) ? "0" : value.ToString ( ), "0" ); }
		}

		/// <summary>
		/// 获取或设置参加选中的元素, 是一个选择器, 默认 "*".
		/// </summary>
		public string Filter
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.filter, "*" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.filter, value, "*" ); }
		}

		/// <summary>
		/// 获取或设置排列中选中的触发方式, 默认为 touch.
		/// </summary>
		public ToleranceType Tolerance
		{
			get { return this.settingHelper.GetOptionValueToEnum<ToleranceType> ( OptionType.tolerance, ToleranceType.touch ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.tolerance, value.ToString ( ), ToleranceType.touch.ToString ( ) ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置选中被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Create
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.create ); }
			set { this.settingHelper.SetOptionValue ( OptionType.create, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置选中后的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Selected
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.selected ); }
			set { this.settingHelper.SetOptionValue ( OptionType.selected, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置选中时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Selecting
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.selecting ); }
			set { this.settingHelper.SetOptionValue ( OptionType.selecting, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置选中开始时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Start
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.start ); }
			set { this.settingHelper.SetOptionValue ( OptionType.start, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置选中停止时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Stop
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.stop ); }
			set { this.settingHelper.SetOptionValue ( OptionType.stop, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置取消选中的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Unselected
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.unselected ); }
			set { this.settingHelper.SetOptionValue ( OptionType.unselected, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置取消选中时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Unselecting
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.unselecting ); }
			set { this.settingHelper.SetOptionValue ( OptionType.unselecting, value, string.Empty ); }
		}
		#endregion

		/// <summary>
		/// 创建 jQuery UI 选中的相关设置.
		/// </summary>
		public SelectableSetting ( )
			: this ( null )
		{ }
		/// <summary>
		/// 创建 jQuery UI 选中的相关设置.
		/// </summary>
		/// <param name="options">选中相关选项.</param>
		public SelectableSetting ( Option[] options )
			: base ( InteractionType.selectable, options )
		{ }

	}
	#endregion

}

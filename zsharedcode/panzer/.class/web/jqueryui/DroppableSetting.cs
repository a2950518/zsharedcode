/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DroppableSetting "
	/// <summary>
	/// jQuery UI 拖放的相关设置.
	/// </summary>
	public sealed class DroppableSetting
		: InteractionSetting
	{

		#region " Enum "
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
			/// 完全进入可以拖放.
			/// </summary>
			fit = 1,
			/// <summary>
			/// 鼠标进入即可拖放.
			/// </summary>
			pointer = 2,
			/// <summary>
			/// 接触即可拖放.
			/// </summary>
			touch = 3,
		}
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置拖放是否可用, 默认为 false.
		/// </summary>
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.disabled, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.disabled, value, false ); }
		}

		/// <summary>
		/// 获取或设置拖放接受的目标, 对应一个选择器, 默认 "*".
		/// </summary>
		public string Accept
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.accept, "*" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.accept, value, "*" ); }
		}

		/// <summary>
		/// 获取或设置拖放被激活时的样式, 默认空字符串.
		/// </summary>
		public string ActiveClass
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.activeClass, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.activeClass, value, string.Empty ); }
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
		/// 获取或设置是否阻止事件传播, 默认为 false.
		/// </summary>
		public bool Greedy
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.greedy, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.greedy, value, false ); }
		}

		/// <summary>
		/// 获取或设置悬停样式, 默认空字符串.
		/// </summary>
		public string HoverClass
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.hoverClass, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.hoverClass, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置范围, 默认为 default.
		/// </summary>
		public string Scope
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.scope, "default" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.scope, value, "default" ); }
		}

		/// <summary>
		/// 获取或设置拖放的触发方式, 默认为 intersect.
		/// </summary>
		public ToleranceType Tolerance
		{
			get { return this.settingHelper.GetOptionValueToEnum<ToleranceType> ( OptionType.tolerance, ToleranceType.intersect ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.tolerance, value.ToString ( ), ToleranceType.intersect.ToString ( ) ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置拖放被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Create
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.create ); }
			set { this.settingHelper.SetOptionValue ( OptionType.create, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置拖放被激活时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Activate
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.activate ); }
			set { this.settingHelper.SetOptionValue ( OptionType.activate, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置拖放取消激活时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Deactivate
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.deactivate ); }
			set { this.settingHelper.SetOptionValue ( OptionType.deactivate, value, string.Empty ); }
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
		/// 获取或设置拖放时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Drop
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.drop ); }
			set { this.settingHelper.SetOptionValue ( OptionType.drop, value, string.Empty ); }
		}
		#endregion

		/// <summary>
		/// 创建 jQuery UI 拖放的相关设置.
		/// </summary>
		public DroppableSetting ( )
			: this ( null )
		{ }
		/// <summary>
		/// 创建 jQuery UI 拖放的相关设置.
		/// </summary>
		/// <param name="options">拖放相关选项.</param>
		public DroppableSetting ( Option[] options )
			: base ( InteractionType.droppable, options )
		{ }

	}
	#endregion

}

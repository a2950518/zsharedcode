/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AccordionSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " AccordionSetting "
	/// <summary>
	/// 折叠列表设置.
	/// </summary>
	public sealed class AccordionSetting
		: WidgetSetting
	{

		#region " option "
		/// <summary>
		/// 获取或设置折叠列表是否可用, 默认为 false.
		/// </summary>
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.disabled, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.disabled, value, false ); }
		}

		/// <summary>
		/// 获取或设置被激活的列表, 对应数值, 默认为 0.
		/// </summary>
		public int Active
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.active, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.active, ( value <= 0 ) ? "0" : value.ToString ( ), "0" ); }
		}

		/// <summary>
		/// 获取或设置列表切换的动画, 比如: "bounceslide", 默认为 "slide".
		/// </summary>
		public string Animated
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.animated, "slide" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.animated, value, "slide" ); }
		}

		/// <summary>
		/// 获取或设置是否自动调整与最高的列表同高, 默认为 true.
		/// </summary>
		public bool AutoHeight
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.autoHeight, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.autoHeight, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否在动画结束后清除 height, overflow 样式, 默认为 false.
		/// </summary>
		public bool ClearStyle
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.clearStyle, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.clearStyle, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否关闭所有的列表, 默认为 false.
		/// </summary>
		public bool Collapsible
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.collapsible, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.collapsible, value, false ); }
		}

		/// <summary>
		/// 获取或设置触发列表的事件, 默认为 click.
		/// </summary>
		public EventType Event
		{
			get { return this.settingHelper.GetOptionValueToEnum<EventType> ( OptionType.@event, EventType.click ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.@event, value.ToString ( ), EventType.click.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置是否以父容器填充高度, 默认为 false.
		/// </summary>
		public bool FillSpace
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.fillSpace, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.fillSpace, value, false ); }
		}

		/// <summary>
		/// 获取或设置作为标题的元素, 可以是选择器, 默认为 "> li > :first-child, > :not(li):even".
		/// </summary>
		public string Header
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.header, "> li > :first-child, > :not(li):even" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.header, value, "> li > :first-child, > :not(li):even" ); }
		}

		/// <summary>
		/// 获取或设置列表显示的图标, 默认为: "{ 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }".
		/// </summary>
		public string Icons
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.icons, "{ 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.icons, value, "{ 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }" ); }
		}

		/// <summary>
		/// 获取或设置是否可以导航, 默认为 false.
		/// </summary>
		public bool Navigation
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.navigation, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.navigation, value, false ); }
		}

		/// <summary>
		/// 获取或设置选择导航的函数, 默认为空字符串.
		/// </summary>
		public string NavigationFilter
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.navigationFilter ); }
			set { this.settingHelper.SetOptionValue ( OptionType.navigationFilter, value, string.Empty ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置列表被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Create
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.create ); }
			set { this.settingHelper.SetOptionValue ( OptionType.create, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置列表改变时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.change ); }
			set { this.settingHelper.SetOptionValue ( OptionType.change, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置列表开始改变时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表开始改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Changestart
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.changestart ); }
			set { this.settingHelper.SetOptionValue ( OptionType.changestart, value, string.Empty ); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置折叠列表改变时触发的 Ajax 操作的相关设置.
		/// </summary>
		public AjaxSetting ChangeAsync
		{
			get { return this.ajaxs[0]; }
			set
			{

				if ( null != value )
					this.ajaxs[0] = value;

			}
		}
		#endregion

		/// <summary>
		/// 创建一个折叠列表设置.
		/// </summary>
		public AccordionSetting ( )
			: base ( WidgetType.accordion, 1 )
		{ }

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine ( )
		{
			this.ChangeAsync.EventType = EventType.accordionchange;

			base.Recombine ( );
		}

	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/TabsSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " TabsSetting "
	/// <summary>
	/// 分组标签设置.
	/// </summary>
	public sealed class TabsSetting
		: WidgetSetting
	{

		#region " option "
		/// <summary>
		/// 获取或设置分组标签是否可用, 或者禁用的标签的索引, 默认为 false.
		/// </summary>
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.disabled, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.disabled, value, false); }
		}

		/// <summary>
		/// 获取或设置标签内容的 Ajax 选项, 比如: "{ async: false }", 默认为空字符串.
		/// </summary>
		public string AjaxOptions
		{
			get { return this.settingHelper.GetOptionValue(OptionType.ajaxOptions); }
			set { this.settingHelper.SetOptionValue(OptionType.ajaxOptions, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置是否使用缓存, 默认为 false.
		/// </summary>
		public bool Cache
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.cache, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.cache, value, false); }
		}

		/// <summary>
		/// 获取或设置当再次选择已选中的标签时, 是否取消选中状态, 默认为 false.
		/// </summary>
		public bool Collapsible
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.collapsible, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.collapsible, value, false); }
		}

		/// <summary>
		/// 获取或设置 cookie 的设置, 比如: "{ expires: 7, path: '/', domain: 'jquery.com', secure: true }", 默认为空字符串.
		/// </summary>
		public string Cookie
		{
			get { return this.settingHelper.GetOptionValue(OptionType.cookie); }
			set { this.settingHelper.SetOptionValue(OptionType.cookie, value, string.Empty); }
		}

		/// <summary>
		/// 请使用 Collapsible.
		/// </summary>
		public bool Deselectable
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.deselectable, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.deselectable, value, false); }
		}

		/// <summary>
		/// 获取或设置触发切换的事件名称, 默认为 click.
		/// </summary>
		public EventType Event
		{
			get { return this.settingHelper.GetOptionValueToEnum<EventType>(OptionType.@event, EventType.click); }
			set { this.settingHelper.SetOptionValueToString(OptionType.@event, value.ToString(), EventType.click.ToString()); }
		}

		/// <summary>
		/// 获取或设置显示或者隐藏的动画效果, 比如: "{ opacity: 'toggle' }", 默认为空字符串.
		/// </summary>
		public string Fx
		{
			get { return this.settingHelper.GetOptionValue(OptionType.fx); }
			set { this.settingHelper.SetOptionValue(OptionType.fx, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置 id 的前缀, 默认为 "ui-tabs-".
		/// </summary>
		public string IdPrefix
		{
			get { return this.settingHelper.GetOptionValueToString(OptionType.idPrefix, "ui-tabs-"); }
			set { this.settingHelper.SetOptionValueToString(OptionType.idPrefix, value, "ui-tabs-"); }
		}

		/// <summary>
		/// 获取或设置面板的模板内容.
		/// </summary>
		public string PanelTemplate
		{
			get { return this.settingHelper.GetOptionValueToString(OptionType.panelTemplate, "<div></div>"); }
			set { this.settingHelper.SetOptionValueToString(OptionType.panelTemplate, value, "<div></div>"); }
		}

		/// <summary>
		/// 获取或设置选中的标签, 默认为 0.
		/// </summary>
		public int Selected
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.selected, 0); }
			set { this.settingHelper.SetOptionValue(OptionType.selected, (value <= 0) ? "0" : value.ToString(), "0"); }
		}

		/// <summary>
		/// 获取或设置载入条的内容.
		/// </summary>
		public string Spinner
		{
			get { return this.settingHelper.GetOptionValueToString(OptionType.spinner, "<em>Loading&#8230;</em>"); }
			set { this.settingHelper.SetOptionValueToString(OptionType.spinner, value, "<em>Loading&#8230;</em>"); }
		}

		/// <summary>
		/// 获取或设置表头的模板内容.
		/// </summary>
		public string TabTemplate
		{
			get { return this.settingHelper.GetOptionValueToString(OptionType.tabTemplate, "<li><a href=#{href}><span>#{label}</span></a></li>"); }
			set { this.settingHelper.SetOptionValueToString(OptionType.tabTemplate, value, "<li><a href=#{href}><span>#{label}</span></a></li>"); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置分组标签被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Create
		{
			get { return this.settingHelper.GetOptionValue(OptionType.create); }
			set { this.settingHelper.SetOptionValue(OptionType.create, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置分组标签被选中时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Select
		{
			get { return this.settingHelper.GetOptionValue(OptionType.select); }
			set { this.settingHelper.SetOptionValue(OptionType.select, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置内容载入时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Load
		{
			get { return this.settingHelper.GetOptionValue(OptionType.load); }
			set { this.settingHelper.SetOptionValue(OptionType.load, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置标签显示时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Show
		{
			get { return this.settingHelper.GetOptionValue(OptionType.show); }
			set { this.settingHelper.SetOptionValue(OptionType.show, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置标签被添加时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Add
		{
			get { return this.settingHelper.GetOptionValue(OptionType.add); }
			set { this.settingHelper.SetOptionValue(OptionType.add, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置标签被删除时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Remove
		{
			get { return this.settingHelper.GetOptionValue(OptionType.remove); }
			set { this.settingHelper.SetOptionValue(OptionType.remove, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置标签被启用时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Enable
		{
			get { return this.settingHelper.GetOptionValue(OptionType.enable); }
			set { this.settingHelper.SetOptionValue(OptionType.enable, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置标签被禁用时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Disable
		{
			get { return this.settingHelper.GetOptionValue(OptionType.disable); }
			set { this.settingHelper.SetOptionValue(OptionType.disable, value, string.Empty); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置分组标签选中时触发的 Ajax 操作的相关设置.
		/// </summary>
		public AjaxSetting SelectAsync
		{
			get { return this.ajaxs[0]; }
			set
			{

				if (null != value)
					this.ajaxs[0] = value;

			}
		}
		#endregion

		/// <summary>
		/// 创建一个分组标签设置.
		/// </summary>
		public TabsSetting()
			: base(WidgetType.tabs, 1)
		{ }

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine()
		{
			this.SelectAsync.EventType = EventType.tabsselect;

			base.Recombine ( );
		}

	}
	#endregion

}

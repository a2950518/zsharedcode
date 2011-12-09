/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SliderSetting.cs
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

	#region " SliderSetting "
	/// <summary>
	/// 分割条设置.
	/// </summary>
	public sealed class SliderSetting
		: WidgetSetting
	{

		#region " Enum "
		/// <summary>
		/// Orientation 类型.
		/// </summary>
		public enum OrientationType
		{
			/// <summary>
			/// 水平.
			/// </summary>
			horizontal = 0,
			/// <summary>
			/// 垂直.
			/// </summary>
			vertical = 1,
		}
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置分割条是否可用, 默认为 false.
		/// </summary>
		[Category("行为")]
		[DefaultValue(false)]
		[Description("指示分割条是否可用, 默认为 false")]
		[NotifyParentProperty(true)]
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.disabled, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.disabled, value, false); }
		}

		/// <summary>
		/// 获取或设置是否播放动画, 默认为 false.
		/// </summary>
		[Category("动画")]
		[DefaultValue(false)]
		[Description("指示是否播放动画, 默认为 false")]
		[NotifyParentProperty(true)]
		public bool Animate
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.animate, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.animate, value, false); }
		}

		/// <summary>
		/// 获取或设置分割条最大值, 默认为 100.
		/// </summary>
		[Category("外观")]
		[DefaultValue(100)]
		[Description("指示分割条最大值, 默认为 100")]
		[NotifyParentProperty(true)]
		public int Max
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.max, 100); }
			set { this.settingHelper.SetOptionValue(OptionType.max, (value <= 0) ? "100" : value.ToString(), "100"); }
		}

		/// <summary>
		/// 获取或设置分割条最小值, 比如: 0.
		/// </summary>
		[Category("外观")]
		[DefaultValue(0)]
		[Description("指示分割条最小值, 比如: 0")]
		[NotifyParentProperty(true)]
		public int Min
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.min, 0); }
			set { this.settingHelper.SetOptionValue(OptionType.min, (value <= 0) ? "0" : value.ToString(), "0"); }
		}

		/// <summary>
		/// 获取或设置分割条的方向, 默认为 horizontal.
		/// </summary>
		[Category("外观")]
		[DefaultValue(OrientationType.horizontal)]
		[Description("指示分割条的方向, 默认为 horizontal")]
		[NotifyParentProperty(true)]
		public OrientationType Orientation
		{
			get { return this.settingHelper.GetOptionValueToEnum<OrientationType>(OptionType.orientation, OrientationType.horizontal); }
			set { this.settingHelper.SetOptionValueToString(OptionType.orientation, value.ToString(), OrientationType.horizontal.ToString()); }
		}

		/// <summary>
		/// 获取或设置分割条是否使用范围, 默认为 false.
		/// </summary>
		[Category("行为")]
		[DefaultValue(false)]
		[Description("指示分割条是否使用范围, 默认为 false")]
		[NotifyParentProperty(true)]
		public bool Range
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.range, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.range, value, false); }
		}

		/// <summary>
		/// 获取或设置分割条的步长, 默认为 1.
		/// </summary>
		[Category("行为")]
		[DefaultValue(1)]
		[Description("指示分割条的步长, 默认为 1")]
		[NotifyParentProperty(true)]
		public int Step
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.step, 1); }
			set { this.settingHelper.SetOptionValue(OptionType.step, (value <= 0) ? "1" : value.ToString(), "1"); }
		}

		/// <summary>
		/// 获取或设置分割条的值, 默认为 0.
		/// </summary>
		[Category("行为")]
		[DefaultValue(0)]
		[Description("指示分割条的值, 默认为 0")]
		[NotifyParentProperty(true)]
		public int Value
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.value, 0); }
			set { this.settingHelper.SetOptionValue(OptionType.value, (value <= 0) ? "0" : value.ToString(), "0"); }
		}

		/// <summary>
		/// 获取或设置分割条的范围值, 比如: [1, 4, 10], 默认为空字符串.
		/// </summary>
		[Category("行为")]
		[DefaultValue("")]
		[Description("指示分割条的范围值, 比如: [1, 4, 10], 默认为空字符串")]
		[NotifyParentProperty(true)]
		public string Values
		{
			get { return this.settingHelper.GetOptionValue(OptionType.values); }
			set { this.settingHelper.SetOptionValue(OptionType.values, value, string.Empty); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置分割条被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示分割条被创建时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Create
		{
			get { return this.settingHelper.GetOptionValue(OptionType.create); }
			set { this.settingHelper.SetOptionValue(OptionType.create, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置分割条开始拖动时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示分割条开始拖动时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Start
		{
			get { return this.settingHelper.GetOptionValue(OptionType.start); }
			set { this.settingHelper.SetOptionValue(OptionType.start, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置分割条拖动时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示分割条拖动时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Slide
		{
			get { return this.settingHelper.GetOptionValue(OptionType.slide); }
			set { this.settingHelper.SetOptionValue(OptionType.slide, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置分割条改变时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示分割条改变时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Change
		{
			get { return this.settingHelper.GetOptionValue(OptionType.change); }
			set { this.settingHelper.SetOptionValue(OptionType.change, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置分割条结束拖动时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示分割条结束拖动时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Stop
		{
			get { return this.settingHelper.GetOptionValue(OptionType.stop); }
			set { this.settingHelper.SetOptionValue(OptionType.stop, value, string.Empty); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置分割条改变时触发的 Ajax 操作的相关设置.
		/// </summary>
		[Category("Ajax")]
		[Description("Change 操作相关的 Ajax 设置")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		[NotifyParentProperty(true)]
		public AjaxSetting ChangeAsync
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
		/// 创建一个分割条设置.
		/// </summary>
		public SliderSetting()
			: base(WidgetType.slider, 1)
		{ }

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine()
		{ 
			this.ChangeAsync.EventType = EventType.slidechange;

			base.Recombine ( );
		}

	}
	#endregion

}

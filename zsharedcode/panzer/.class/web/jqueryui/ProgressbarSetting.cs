/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ProgressbarSetting.cs
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

	#region " ProgressbarSetting "
	/// <summary>
	/// 进度条设置.
	/// </summary>
	public sealed class ProgressbarSetting
		: WidgetSetting
	{

		#region " option "
		/// <summary>
		/// 获取或设置进度条是否可用, 默认为 false.
		/// </summary>
		[Category("行为")]
		[DefaultValue(false)]
		[Description("指示进度条是否可用, 默认为 false")]
		[NotifyParentProperty(true)]
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.disabled, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.disabled, value, false); }
		}

		/// <summary>
		/// 获取或设置进度条当前的值, 默认为 0.
		/// </summary>
		[Category("行为")]
		[DefaultValue(0)]
		[Description("指示进度条当前的值, 默认为 0")]
		[NotifyParentProperty(true)]
		public int Value
		{
			get { return this.settingHelper.GetOptionValueToInteger(OptionType.value, 0); }
			set { this.settingHelper.SetOptionValue(OptionType.value, (value <= 0) ? "0" : value.ToString(), "0"); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置进度条被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示进度条被创建时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Create
		{
			get { return this.settingHelper.GetOptionValue(OptionType.create); }
			set { this.settingHelper.SetOptionValue(OptionType.create, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置进度条当前值改变时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示进度条当前值改变时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Change
		{
			get { return this.settingHelper.GetOptionValue(OptionType.change); }
			set { this.settingHelper.SetOptionValue(OptionType.change, value, string.Empty); }
		}

		/// <summary>
		/// 获取或设置进度条完成时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category("事件")]
		[DefaultValue("")]
		[Description("指示进度条完成时的事件, 类似于: function(event, ui) { }")]
		[NotifyParentProperty(true)]
		public string Complete
		{
			get { return this.settingHelper.GetOptionValue(OptionType.complete); }
			set { this.settingHelper.SetOptionValue(OptionType.complete, value, string.Empty); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置进度条改变时触发的 Ajax 操作的相关设置.
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
		/// <summary>
		/// 获取或设置进度条完成时触发的 Ajax 操作的相关设置.
		/// </summary>
		[Category("Ajax")]
		[Description("Complete 操作相关的 Ajax 设置")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		[NotifyParentProperty(true)]
		public AjaxSetting CompleteAsync
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
		/// 创建一个进度条设置.
		/// </summary>
		public ProgressbarSetting()
			: base(WidgetType.progressbar, 2)
		{ }

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine()
		{
			this.ChangeAsync.EventType = EventType.progressbarchange;
			this.CompleteAsync.EventType = EventType.progressbarcomplete;

			base.Recombine ( );
		}

	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ButtonSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ButtonSetting "
	/// <summary>
	/// 按钮设置.
	/// </summary>
	public sealed class ButtonSetting
		: WidgetSetting
	{
		private string primaryIcon;
		private string secondaryIcon;

		/// <summary>
		/// 获取或设置按钮显示的主图标, 比如: ui-icon-gear, 也可以通过 Icons 属性设置.
		/// </summary>
		public string PrimaryIcon
		{
			get { return this.primaryIcon; }
			set
			{
				this.primaryIcon = value;
				this.refreshIcons();
			}
		}

		/// <summary>
		/// 获取或设置按钮显示的第二图标, 比如: ui-icon-triangle-1-s, 也可以通过 Icons 属性设置.
		/// </summary>
		public string SecondaryIcon
		{
			get { return this.secondaryIcon; }
			set
			{
				this.secondaryIcon = value;
				this.refreshIcons();
			}
		}

		#region " option "
		/// <summary>
		/// 获取或设置按钮是否可用, 默认为 false.
		/// </summary>
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.disabled, false); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.disabled, value, false); }
		}

		/// <summary>
		/// 获取或设置按钮是否显示文本, 默认为 true.
		/// </summary>
		public bool Text
		{
			get { return this.settingHelper.GetOptionValueToBoolean(OptionType.text, true); }
			set { this.settingHelper.SetOptionValueToBoolean(OptionType.text, value, true); }
		}

		/// <summary>
		/// 获取或设置按钮显示的图标, 默认为 { primary: null, secondary: null }.
		/// </summary>
		public string Icons
		{
			get { return this.settingHelper.GetOptionValue(OptionType.icons, "{ primary: null, secondary: null }"); }
			set { this.settingHelper.SetOptionValue(OptionType.icons, value, "{ primary: null, secondary: null }"); }
		}

		/// <summary>
		/// 获取或设置按钮显示的文本, 默认为空字符串.
		/// </summary>
		public string Label
		{
			get { return this.settingHelper.GetOptionValueToString(OptionType.label, string.Empty); }
			set { this.settingHelper.SetOptionValueToString(OptionType.label, value, string.Empty); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置按钮被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Create
		{
			get { return this.settingHelper.GetOptionValue(OptionType.create); }
			set { this.settingHelper.SetOptionValue(OptionType.create, value, string.Empty); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置按钮点击时触发的 Ajax 操作的相关设置.
		/// </summary>
		public AjaxSetting ClickAsync
		{
			get { return this.ajaxs[0]; }
			set
			{

				if (null != value)
					this.ajaxs[0] = value;

			}
		}
		#endregion

		#region " client "
		/// <summary>
		/// 获取或设置按钮被点击时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Click
		{
			get { return this.settingHelper.GetEventValue(EventType.click); }
			set { this.settingHelper.SetEventValue(EventType.click, value); }
		}
		#endregion

		private void refreshIcons()
		{
			string icons = string.Empty;

			if (!string.IsNullOrEmpty(this.primaryIcon) && !string.IsNullOrEmpty(this.secondaryIcon))
				icons = "{" + string.Format(" primary: '{0}', secondary: '{1}' ", this.primaryIcon, this.secondaryIcon) + "}";
			else if (!string.IsNullOrEmpty(this.secondaryIcon) && string.IsNullOrEmpty(this.primaryIcon))
				icons = "{" + string.Format(" secondary: '{0}' ", this.secondaryIcon) + "}";
			else if (!string.IsNullOrEmpty(this.primaryIcon) && string.IsNullOrEmpty(this.secondaryIcon))
				icons = "{" + string.Format(" primary: '{0}' ", this.primaryIcon) + "}";

			this.Icons = icons;
		}

		/// <summary>
		/// 创建一个按钮设置.
		/// </summary>
		public ButtonSetting()
			: base(WidgetType.button, 1)
		{ }

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine()
		{
			this.ClickAsync.EventType = EventType.click;

			base.Recombine ( );
		}

	}
	#endregion

}

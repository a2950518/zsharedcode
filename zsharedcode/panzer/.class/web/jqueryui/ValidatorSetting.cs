/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ValidatorSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui.plusin
{

	#region " ValidatorSetting "
	/// <summary>
	/// 自定义 Validator 设置.
	/// </summary>
	public sealed class ValidatorSetting
		: PlusinSetting
	{

		#region " option "
		/// <summary>
		/// 获取或设置参与过滤字段的默认值, 默认为空字符串.
		/// </summary>
		public string DefaultValue
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.defaultvalue, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.defaultvalue, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置等于目标的选择器, 默认为空字符串.
		/// </summary>
		public string Equal
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.equal, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.equal, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置两个值不相等时的提示, 默认为空字符串.
		/// </summary>
		public string EqualTip
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.equaltip, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.equaltip, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置出发验证的事件, 默认为 "change".
		/// </summary>
		public string Event
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.@event, "change" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.@event, value, "change" ); }
		}

		/// <summary>
		/// 获取或设置最大值, 默认为 -1111, 表示没有最大值限制.
		/// </summary>
		public int Max
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.max, -1111 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.max, value.ToString ( ), "-1111" ); }
		}

		/// <summary>
		/// 获取或设置超出最大值的提示, 默认为空字符串.
		/// </summary>
		public string MaxTip
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.maxtip, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.maxtip, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置最小值, 默认为 -1111, 表示没有最小值限制.
		/// </summary>
		public int Min
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.min, -1111 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.min, value.ToString ( ), "-1111" ); }
		}

		/// <summary>
		/// 获取或设置超出最小值的提示, 默认为空字符串.
		/// </summary>
		public string MinTip
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.mintip, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.mintip, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置验证项的名称, 默认为空字符串.
		/// </summary>
		public string Name
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.name, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.name, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否为必需, 默认为 false.
		/// </summary>
		public bool Need
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.need, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.need, value, false ); }
		}

		/// <summary>
		/// 获取或设置缺少时的提示, 默认为空字符串.
		/// </summary>
		public string NeedTip
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.needtip, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.needtip, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置转化值的自定义函数, 形式为 "function(value) { }", 默认没有自定义函数.
		/// </summary>
		public string Provider
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.provider, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.provider, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置用于验证的正则表达式, 默认为空.
		/// </summary>
		public string Reg
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.reg, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.reg, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置不符合正则表达式时的提示, 默认为空字符串.
		/// </summary>
		public string RegTip
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.regtip, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.regtip, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否显示提示, 默认为 true.
		/// </summary>
		public bool ShowTip
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showtip, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showtip, value, true ); }
		}

		/// <summary>
		/// 获取或设置成功时的提示, 默认为空字符串.
		/// </summary>
		public string SuccessTip
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.successtip, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.successtip, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置验证目标的选择器, 默认为空字符串.
		/// </summary>
		public string Target
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.target, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.target, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置数据的类型, 默认为空字符串.
		/// </summary>
		public string Type
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.type, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.type, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置类型不符时的提示, 默认为空字符串.
		/// </summary>
		public string TypeTip
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.typetip, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.typetip, value, string.Empty ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置检测的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		public string Check
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.check ); }
			set { this.settingHelper.SetOptionValue ( OptionType.check, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置检测后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		public string Checked
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.@checked ); }
			set { this.settingHelper.SetOptionValue ( OptionType.@checked, value, string.Empty ); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置验证时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Check.
		/// </summary>
		public AjaxSetting CheckAsync
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
		/// 创建一个自定义 Validator 设置.
		/// </summary>
		public ValidatorSetting ( )
			: base ( PlusinType.validator, 1 )
		{ }

		/// <summary>
		/// 获取 Validator 所需的基础脚本.
		/// </summary>
		/// <returns>Validator 所需的基础脚本.</returns>
		public override Dictionary<string, string> GetDependentScripts ( )
		{
			Dictionary<string, string> plusins = base.GetDependentScripts ( );

			plusins.Add ( "validator", Resources.validator_min );

			return plusins;
		}

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine ( )
		{
			this.Target = CreateJQuerySelector ( this.Target );
			this.Equal = CreateJQuerySelector ( this.Equal );

			this.CheckAsync.EventType = EventType.check;
			this.CheckAsync.Success = "function(data){e.callback.call(pe.jquery, pe, (null == -:data.value ? e.value : -:data.value), -:data.tip, -:data.valid, -:data.custom);}";
			this.CheckAsync.Error = "function(){e.callback.call(pe.jquery, pe, {}, false, null);}";

			WidgetSetting.AppendParameter ( this.CheckAsync,
				new Parameter[]
				{
					new Parameter("value", ParameterType.Expression, "e.value")
				} );

			base.Recombine ( );
		}

	}
	#endregion

}

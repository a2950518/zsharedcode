/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/PlotSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " PlotSetting "
	/// <summary>
	/// 图表设置.
	/// </summary>
	public sealed class PlotSetting
		: PlusinSetting
	{

		#region " option "
		/// <summary>
		/// 获取或设置点, 默认为 [].
		/// </summary>
		public string Points
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.points, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.points, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置图表选项, 默认为空.
		/// </summary>
		public string Options
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.options, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.options, value, string.Empty ); }
		}
		#endregion

		/// <summary>
		/// 创建一个自定义时钟设置.
		/// </summary>
		public PlotSetting ( )
			: base ( PlusinType.plot, 0 )
		{ }

		/// <summary>
		/// 获取时钟所需的基础脚本.
		/// </summary>
		/// <returns>时钟所需的基础脚本.</returns>
		public override Dictionary<string, string> GetDependentScripts ( )
		{
			Dictionary<string, string> plusins = base.GetDependentScripts ( );

			plusins.Add("plot", Resources.plot_min);

			return plusins;
		}

	}
	#endregion

}

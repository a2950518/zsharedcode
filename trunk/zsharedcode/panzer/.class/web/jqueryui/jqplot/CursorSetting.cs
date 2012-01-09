/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/CursorSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;
using System.ComponentModel;

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " CursorSetting "
	/// <summary>
	/// 图表鼠标的设置.
	/// </summary>
	public sealed class CursorSetting
	{
		private readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " option "
		/// <summary>
		/// 获取或设置是否鼠标位置跟随鼠标, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否鼠标位置跟随鼠标, 默认为 false" )]
		public bool FollowMouse
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.followMouse, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.followMouse, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否显示鼠标样式, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示鼠标样式, 默认为 false" )]
		public bool Show
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.show, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.show, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否显示鼠标位置, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示鼠标位置, 默认为 true" )]
		public bool ShowToolTip
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showTooltip, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showTooltip, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示鼠标的像素位置, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示鼠标的像素位置, 默认为 false" )]
		public bool ShowToolTipGridPosition
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showTooltipGridPosition, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showTooltipGridPosition, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否显示鼠标的数据位置, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示鼠标的数据位置, 默认为 true" )]
		public bool ShowToolTipUnitPosition
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showTooltipUnitPosition, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showTooltipUnitPosition, value, true ); }
		}

		/// <summary>
		/// 获取或设置鼠标样式, 默认为 "crosshair".
		/// </summary>
		[Category ( "外观" )]
		[Description ( "鼠标样式, 默认为 crosshair" )]
		public string Style
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.style, "crosshair" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.style, value, "crosshair" ); }
		}

		/// <summary>
		/// 获取或设置显示提示的轴, 比如: "[['xaxis', 'yaxis'], ['xaxis', 'y2axis']]", 默认为 "[]".
		/// </summary>
		[Category ( "外观" )]
		[Description ( "显示提示的轴, 比如: [['xaxis', 'yaxis'], ['xaxis', 'y2axis']], 默认为 []" )]
		public string ToolTipAxesGroups
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.tooltipAxesGroups, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.tooltipAxesGroups, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置提示位置, 默认为 "%.4P".
		/// </summary>
		[Category ( "外观" )]
		[Description ( "提示位置, 默认为 %.4P" )]
		public string ToolTipFormatString
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.tooltipFormatString, "%.4P" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.tooltipFormatString, value, "%.4P" ); }
		}

		/// <summary>
		/// 获取或设置提示位置, 默认为 se.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "提示位置, 默认为 se" )]
		public LocationType ToolTipLocation
		{
			get { return this.settingHelper.GetOptionValueToEnum<LocationType> ( OptionType.tooltipLocation, LocationType.se ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.tooltipLocation, value.ToString(), LocationType.se.ToString() ); }
		}

		/// <summary>
		/// 获取或设置提示位置, 默认为 6.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "提示位置, 默认为 6" )]
		public int ToolTipOffset
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.tooltipOffset, 6 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.tooltipOffset, value.ToString ( ), "6" ); }
		}

		/// <summary>
		/// 获取或设置是否使用轴的格式, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否使用轴的格式, 默认为 true" )]
		public bool UseAxesFormatters
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.useAxesFormatters, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.useAxesFormatters, value, true ); }
		}
		#endregion

		/// <summary>
		/// 创建一个图表鼠标的设置.
		/// </summary>
		public CursorSetting ( )
		{ }

		/// <summary>
		/// 创建选项数组.
		/// </summary>
		/// <returns>选项数组.</returns>
		public Option[] CreateOptions ( )
		{ return this.settingHelper.CreateOptions ( ); }

	}
	#endregion

}

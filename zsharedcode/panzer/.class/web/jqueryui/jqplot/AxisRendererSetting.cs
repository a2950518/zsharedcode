/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/AxisRendererSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " AxisRendererSetting "
	/// <summary>
	/// 轴绘制设置.
	/// </summary>
	public sealed class AxisRendererSetting
	{
		private readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " common option "

		/// <summary>
		/// 获取或设置基线颜色, 默认为 Transparent.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "基线颜色, 默认为 Transparent" )]
		public Color BaselineColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.baselineColor, Color.Transparent ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.baselineColor, value, Color.Transparent ); }
		}

		/// <summary>
		/// 获取或设置基线宽度, 默认为 -1.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "基线宽度, 默认为 -1" )]
		public int BaselineWidth
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.baselineWidth, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.baselineWidth, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置是否绘制基线, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否绘制基线, 默认为 true" )]
		public bool DrawBaseline
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.drawBaseline, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.drawBaseline, value, true ); }
		}

		/// <summary>
		/// 获取或设置刻度的内距, 默认为 0.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "刻度的内距, 默认为 0" )]
		public double TickInset
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.tickInset, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.tickInset, value < 0 || value > 1 ? "0" : value.ToString ( ), "0" ); }
		}

		/// <summary>
		/// 获取或设置刻度的绘制方式, 默认为 AxisTickRenderer.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "刻度的绘制方式, 默认为 AxisTickRenderer" )]
		public PlotPlusinType TickRenderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.tickRenderer, PlotPlusinType.AxisTickRenderer.ToString ( ) ), PlotPlusinType.AxisTickRenderer ); }
			set { this.settingHelper.SetOptionValue ( OptionType.tickRenderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.AxisTickRenderer ) ); }
		}
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置对齐刻度, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "对齐刻度, 默认为 false" )]
		public bool AlignTicks
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.alignTicks, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.alignTicks, value, false ); }
		}

		/// <summary>
		/// 获取或设置断开点, 默认为空.
		/// </summary>
		[Category ( "数据" )]
		[Description ( "断开点, 默认为空" )]
		public string BreakPoints
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.breakPoints, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.breakPoints, value, string.Empty ); }
		}
		
		/// <summary>
		/// 获取或设置断开刻度的标签, 默认为 "".
		/// </summary>
		[Category ( "外观" )]
		[Description ( "断开刻度的标签, 默认为 " )]
		public string BreakTickLabel
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.breakTickLabel, "" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.breakTickLabel, value, "" ); }
		}
		
		/// <summary>
		/// 获取或设置是否必须有 0 刻度, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否必须有 0 刻度, 默认为 false" )]
		public bool ForceTickAt0
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.forceTickAt0, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.forceTickAt0, value, false ); }
		}
		
		/// <summary>
		/// 获取或设置是否必须有 100 刻度, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否必须有 100 刻度, 默认为 false" )]
		public bool ForceTickAt100
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.forceTickAt100, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.forceTickAt100, value, false ); }
		}
		
		/// <summary>
		/// 获取或设置次要刻度的个数, 默认为 0.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "次要刻度的个数, 默认为 0" )]
		public int MinorTicks
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.minorTicks, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.minorTicks, value < 0 ? "0" : value.ToString ( ), "0" ); }
		}
		
		#endregion

		#region " category option "
		
		/// <summary>
		/// 获取或设置是否排序合并的标签, 默认为 false.
		/// </summary>
		[Category ( "分类" )]
		[Description ( "是否排序合并的标签, 默认为 false" )]
		public bool SortMergedLabels
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.sortMergedLabels, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.sortMergedLabels, value, false ); }
		}

		#endregion

		/// <summary>
		/// 创建一个轴绘制设置.
		/// </summary>
		public AxisRendererSetting ( )
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

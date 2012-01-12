/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/Axis.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " Axis "
	/// <summary>
	/// 轴.
	/// </summary>
	public sealed class Axis
	{
		private readonly SettingHelper settingHelper = new SettingHelper ( );
		private TickRendererSetting tickRendererSetting;
		private AxisRendererSetting rendererSetting;
		private AxisLabelRendererSetting lableRendererSetting;

		#region " option "
		/// <summary>
		/// 获取或设置是否自动缩放, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否自动缩放, 默认为 false" )]
		public bool AutoScale
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.autoscale, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.autoscale, value, false ); }
		}

		/// <summary>
		/// 获取或设置边框颜色, 默认为 Transparent.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "边框颜色, 默认为 Transparent" )]
		public Color BorderColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.borderColor, Color.Transparent ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.borderColor, value, Color.Transparent ); }
		}

		/// <summary>
		/// 获取或设置轴的宽度, 默认为 -1, 不设置.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "轴的宽度, 默认为 -1, 不设置" )]
		public double BorderWidth
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.borderWidth, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.borderWidth, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置是否绘制主要网格线, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否绘制主要网格线, 默认为 true" )]
		public bool DrawMajorGridlines
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.drawMajorGridlines, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.drawMajorGridlines, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否绘制次要网格线, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否绘制次要网格线, 默认为 false" )]
		public bool DrawMinorGridlines
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.drawMinorGridlines, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.drawMinorGridlines, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否绘制主要刻度线标记, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否绘制主要刻度线标记, 默认为 true" )]
		public bool DrawMajorTickMarks 
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.drawMajorTickMarks, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.drawMajorTickMarks, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否绘制次要刻度线标记, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否绘制次要刻度线标记, 默认为 true" )]
		public bool DrawMinorTickMarks
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.drawMinorTickMarks, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.drawMinorTickMarks, value, true ); }
		}

		/// <summary>
		/// 获取或设置轴标题, 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "轴标题, 默认为空字符串" )]
		public string Label
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.label, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.label, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置标签的绘制方式, 默认为 AxisLabelRenderer.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "标签的绘制方式, 默认为 AxisLabelRenderer" )]
		public PlotPlusinType LabelRenderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.labelRenderer, PlotPlusinType.AxisLabelRenderer.ToString ( ) ), PlotPlusinType.AxisLabelRenderer ); }
			set { this.settingHelper.SetOptionValue ( OptionType.labelRenderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.AxisLabelRenderer ) ); }
		}

		/// <summary>
		/// 获取或设置轴标签设置.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "轴标签设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AxisLabelRendererSetting LabelRendererSetting
		{
			get
			{

				if ( null == this.lableRendererSetting )
					this.lableRendererSetting = new AxisLabelRendererSetting ( );

				return this.lableRendererSetting;
			}
		}

		/// <summary>
		/// 获取或设置标签绘制设置, 默认为 "{}".
		/// </summary>
		[Category ( "选项" )]
		[Description ( "标签绘制设置, 默认为 {}" )]
		public string LabelOptions
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.labelOptions, "{}" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.labelOptions, value, "{}" ); }
		}

		/// <summary>
		/// 获取或设置刻度的个数, 默认为 -1, 不设置.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "刻度的个数, 默认为 -1, 不设置" )]
		public int NumberTicks
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.numberTicks, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.numberTicks, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置轴最大值, 比如 "12", "'2011-1-1'", 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "轴最大值, 比如 12, '2011-1-1', 默认为空" )]
		public string Max
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.max, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.max, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置轴最小值, 比如 "12", "'2011-1-1'", 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "轴最小值, 比如 12, '2011-1-1', 默认为空" )]
		public string Min
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.min, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.min, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置填充倍数, 默认为 1.2.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "填充倍数, 默认为 1.2" )]
		public double Pad
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.pad, 1.2 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.pad, value < 0 ? "1.2" : value.ToString ( ), "1.2" ); }
		}

		/// <summary>
		/// 获取或设置最大值的填充倍数, 默认为 -1, 不设置.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "最大值的填充倍数, 默认为 -1, 不设置" )]
		public double PadMax
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.padMax, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.padMax, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置最小值的填充倍数, 默认为 -1, 不设置.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "最小值的填充倍数, 默认为 -1, 不设置" )]
		public double PadMin
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.padMin, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.padMin, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置绘制方式, 默认为 LinearAxisRenderer.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "绘制方式, 默认为 LinearAxisRenderer" )]
		public PlotPlusinType Renderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.renderer, PlotPlusinType.LinearAxisRenderer.ToString ( ) ), PlotPlusinType.LinearAxisRenderer ); }
			set { this.settingHelper.SetOptionValue ( OptionType.renderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.LinearAxisRenderer ) ); }
		}

		/// <summary>
		/// 获取或设置轴设置.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "轴设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AxisRendererSetting RendererSetting
		{
			get
			{

				if ( null == this.rendererSetting )
					this.rendererSetting = new AxisRendererSetting ( );

				return this.rendererSetting;
			}
		}

		/// <summary>
		/// 获取或设置绘制设置, 默认为 "{}".
		/// </summary>
		[Category ( "选项" )]
		[Description ( "绘制设置, 默认为 {}" )]
		public string RendererOptions
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.rendererOptions, "{}" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.rendererOptions, value, "{}" ); }
		}

		/// <summary>
		/// 获取或设置是否在图片中显示, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否在图片中显示, 默认为 false" )]
		public bool Show
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.show, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.show, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否显示标题, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示标题, 默认为 true" )]
		public bool ShowLabel
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showLabel, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showLabel, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示刻度, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示刻度, 默认为 true" )]
		public bool ShowTicks
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showTicks, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showTicks, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示刻度标记, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示刻度标记, 默认为 true" )]
		public bool ShowTickMarks
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showTickMarks, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showTickMarks, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示最小刻度, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示最小刻度, 默认为 true" )]
		public bool ShowMinorTicks
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showMinorTicks, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showMinorTicks, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否同步刻度, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否同步刻度, 默认为 false" )]
		public bool SyncTicks
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.syncTicks, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.syncTicks, value, false ); }
		}

		/// <summary>
		/// 获取或设置刻度之间的数据个数, 默认为 -1, 不设置.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "刻度之间的数据个数, 默认为 -1, 不设置" )]
		public int TickInterval
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.tickInterval, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.tickInterval, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
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

		/// <summary>
		/// 获取或设置刻度, 默认为 "[]".
		/// </summary>
		[Category ( "外观" )]
		[Description ( "刻度, 默认为 []" )]
		public string Ticks
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.ticks, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.ticks, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置刻度空白, 默认为 75.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "刻度空白, 默认为 75" )]
		public int TickSpacing
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.tickSpacing, 75 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.tickSpacing, value < 0 ? "75" : value.ToString ( ), "75" ); }
		}

		/// <summary>
		/// 获取或设置刻度绘制设置, 默认为 "{}".
		/// </summary>
		[Category ( "选项" )]
		[Description ( "刻度绘制设置, 默认为 {}" )]
		public string TickOptions
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.tickOptions, "{}" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.tickOptions, value, "{}" ); }
		}

		/// <summary>
		/// 获取或设置刻度设置.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "刻度设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public TickRendererSetting TickRendererSetting
		{
			get
			{

				if ( null == this.tickRendererSetting )
					this.tickRendererSetting = new TickRendererSetting ( );

				return this.tickRendererSetting;
			}
		}

		/// <summary>
		/// 获取或设置是否使用序列的颜色, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否使用序列的颜色, 默认为 false" )]
		public bool UseSeriesColor
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.useSeriesColor, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.useSeriesColor, value, false ); }
		}
		#endregion

		/// <summary>
		/// 创建一个轴.
		/// </summary>
		public Axis ( )
		{ }

		/// <summary>
		/// 创建选项数组.
		/// </summary>
		/// <returns>选项数组.</returns>
		public Option[] CreateOptions ( )
		{

			if ( this.RendererOptions == "{}" && null != this.rendererSetting )
				this.RendererOptions = JQueryUI.MakeOptionExpression ( this.rendererSetting.CreateOptions ( ) );

			if ( this.TickOptions == "{}" && null != this.tickRendererSetting )
				this.TickOptions = JQueryUI.MakeOptionExpression ( this.tickRendererSetting.CreateOptions ( ) );

			if ( this.LabelOptions == "{}" && null != this.lableRendererSetting )
				this.LabelOptions = JQueryUI.MakeOptionExpression ( this.lableRendererSetting.CreateOptions ( ) );

			return this.settingHelper.CreateOptions ( );
		}

	}
	#endregion

}

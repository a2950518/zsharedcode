/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Series.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " Series "
	/// <summary>
	/// 序列.
	/// </summary>
	public sealed class Series
	{

		#region " FillAxisType "
		/// <summary>
		/// 填充轴类型.
		/// </summary>
		public enum FillAxisType
		{
			/// <summary>
			/// x 轴.
			/// </summary>
			x,
			/// <summary>
			/// y 轴.
			/// </summary>
			y,
		}
		#endregion

		#region " LineCapType "
		/// <summary>
		/// 线的端点类型.
		/// </summary>
		public enum LineCapType
		{
			/// <summary>
			/// 圆点.
			/// </summary>
			round,
			/// <summary>
			/// 桶.
			/// </summary>
			butt,
			/// <summary>
			/// 方形
			/// </summary>
			square,
		}
		#endregion

		#region " LineJoinType "
		/// <summary>
		/// 线的连接类型.
		/// </summary>
		public enum LineJoinType
		{
			/// <summary>
			/// 圆点.
			/// </summary>
			round,
			/// <summary>
			/// 桶.
			/// </summary>
			butt,
			/// <summary>
			/// 方形
			/// </summary>
			square,
		}
		#endregion

		#region " LinePatternType "
		/// <summary>
		/// 线类型.
		/// </summary>
		public enum LinePatternType
		{
			/// <summary>
			/// 虚线.
			/// </summary>
			dashed,
			/// <summary>
			/// 点线.
			/// </summary>
			dotted,
			/// <summary>
			/// 直线.
			/// </summary>
			solid,
		}
		#endregion

		#region " XAxisType "
		/// <summary>
		/// x 轴类型.
		/// </summary>
		public enum XAxisType
		{
			/// <summary>
			/// x 轴.
			/// </summary>
			xaxis,
			/// <summary>
			/// x 2 轴
			/// </summary>
			x2axis
		}
		#endregion

		#region " YAxisType "
		/// <summary>
		/// y 轴类型.
		/// </summary>
		public enum YAxisType
		{
			/// <summary>
			/// y 轴.
			/// </summary>
			yaxis,
			/// <summary>
			/// y 2 轴
			/// </summary>
			y2axis
		}
		#endregion

		private readonly SettingHelper settingHelper = new SettingHelper ( );
		private MarkerRendererSetting markerRendererSetting;
		private SeriesRendererSetting rendererSetting;

		#region " option "
		/// <summary>
		/// 获取或设置是否当没有数据时断开, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否当没有数据时断开, 默认为 false" )]
		public bool BreakOnNull
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.breakOnNull, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.breakOnNull, value, false ); }
		}

		/// <summary>
		/// 获取或设置颜色, 默认为 Transparent.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "颜色, 默认为 Transparent" )]
		public Color Color
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.color, Color.Transparent ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.color, value, Color.Transparent ); }
		}

		/// <summary>
		/// 获取或设置是否禁用堆栈, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否禁用堆栈, 默认为 false" )]
		public bool DisableStack
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.disableStack, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.disableStack, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否填充, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否填充, 默认为 false" )]
		public bool Fill
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.fill, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.fill, value, false ); }
		}

		/// <summary>
		/// 获取或设置阴影的透明度, 默认为 0.1.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的透明度, 默认为 0.1" )]
		public double FillAlpha
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.fillAlpha, 0.1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.fillAlpha, value < 0 || value > 1 ? "0.1" : value.ToString ( ), "0.1" ); }
		}

		/// <summary>
		/// 获取或设置是否描边, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否描边, 默认为 false" )]
		public bool FillAndStroke
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.fillAndStroke, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.fillAndStroke, value, false ); }
		}

		/// <summary>
		/// 获取或设置填充轴, 默认为 y.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "填充轴, 默认为 y" )]
		public FillAxisType FillAxis
		{
			get { return this.settingHelper.GetOptionValueToEnum<FillAxisType> ( OptionType.fillAxis, FillAxisType.y ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.fillAxis, value.ToString ( ), FillAxisType.y.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置填充颜色, 默认为 Transparent, 目前尚不可用.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "填充颜色, 默认为 Transparent, 目前尚不可用" )]
		public Color FillColor
		{
			get { return this.settingHelper.GetOptionValueToRgbaColor ( OptionType.fillColor, Color.Transparent ); }
			set { this.settingHelper.SetOptionValueToRgbaColor ( OptionType.fillColor, value, Color.Transparent ); }
		}

		/// <summary>
		/// 获取或设置填充至的值, 默认为 -10000, 不设置.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "填充至的值, 默认为 -10000, 不设置" )]
		public double FillToValue
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.fillToValue, -10000 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.fillToValue, value.ToString ( ), "-10000" ); }
		}

		/// <summary>
		/// 获取或设置是否填充至 0, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否填充至 0, 默认为 false" )]
		public bool FillToZero
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.fillToZero, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.fillToZero, value, false ); }
		}

		/// <summary>
		/// 获取或设置对应的数据的索引, 默认为 -1, 不设置.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "对应的数据的索引, 默认为 -1, 不设置" )]
		public int Index
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.index, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.index, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置鼠标临近阀值, 默认为 4.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "鼠标临近阀值, 默认为 4" )]
		public int NeighborThreshold
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.neighborThreshold, 4 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.neighborThreshold, value < 0 ? "4" : value.ToString ( ), "4" ); }
		}

		/// <summary>
		/// 获取或设置图例标题, 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "图例标题, 默认为空字符串" )]
		public string Label
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.label, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.label, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置线的端点, 默认为 round.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "线的端点, 默认为 round" )]
		public LineCapType LineCap
		{
			get { return this.settingHelper.GetOptionValueToEnum<LineCapType> ( OptionType.lineCap, LineCapType.round ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.lineCap, value.ToString ( ), LineCapType.round.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置线的连接方式, 默认为 round.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "线的连接方式, 默认为 round" )]
		public LineJoinType LineJoin
		{
			get { return this.settingHelper.GetOptionValueToEnum<LineJoinType> ( OptionType.lineJoin, LineJoinType.round ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.lineJoin, value.ToString ( ), LineJoinType.round.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置线类型, 默认为 solid.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "线类型, 默认为 solid" )]
		public LinePatternType LinePattern
		{
			get { return this.settingHelper.GetOptionValueToEnum<LinePatternType> ( OptionType.linePattern, LinePatternType.solid ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.linePattern, value.ToString ( ), LinePatternType.solid.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置线的宽度, 默认为 2.5.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "线的宽度, 默认为 2.5" )]
		public double LineWidth
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.lineWidth, 2.5 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.lineWidth, value < 0 ? "2.5" : value.ToString ( ), "2.5" ); }
		}

		/// <summary>
		/// 获取或设置标记绘制设置, 默认为 "{}".
		/// </summary>
		[Category ( "选项" )]
		[Description ( "标记绘制设置, 默认为 {}" )]
		public string MarkerOptions
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.markerOptions, "{}" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.markerOptions, value, "{}" ); }
		}

		/// <summary>
		/// 获取或设置标记绘制方式, 默认为 MarkerRenderer.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "标记绘制方式, 默认为 MarkerRenderer" )]
		public PlotPlusinType MarkerRenderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.markerRenderer, PlotPlusinType.MarkerRenderer.ToString ( ) ), PlotPlusinType.MarkerRenderer ); }
			set { this.settingHelper.SetOptionValue ( OptionType.markerRenderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.MarkerRenderer ) ); }
		}

		/// <summary>
		/// 获取或设置标记设置.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "标记设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public MarkerRendererSetting MarkerRendererSetting
		{
			get
			{

				if ( null == this.markerRendererSetting )
					this.markerRendererSetting = new MarkerRendererSetting ( );

				return this.markerRendererSetting;
			}
		}

		/// <summary>
		/// 获取或设置填充区颜色, 默认为 Transparent.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "填充区颜色, 默认为 Transparent" )]
		public Color NegativeColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.negativeColor, Color.Transparent ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.negativeColor, value, Color.Transparent ); }
		}

		/// <summary>
		/// 获取或设置绘制方式, 默认为 LineRenderer.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "绘制方式, 默认为 LineRenderer" )]
		public PlotPlusinType Renderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.renderer, PlotPlusinType.LineRenderer.ToString ( ) ), PlotPlusinType.LineRenderer ); }
			set { this.settingHelper.SetOptionValue ( OptionType.renderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.LineRenderer ) ); }
		}

		/// <summary>
		/// 获取或设置绘制设置.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "绘制设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public SeriesRendererSetting RendererSetting
		{
			get
			{

				if ( null == this.rendererSetting )
					this.rendererSetting = new SeriesRendererSetting ( );

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
		/// 获取或设置阴影的透明度, 默认为 0.1.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的透明度, 默认为 0.1" )]
		public double ShadowAlpha
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.shadowAlpha, 0.1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowAlpha, value < 0 || value > 1 ? "0.1" : value.ToString ( ), "0.1" ); }
		}

		/// <summary>
		/// 获取或设置阴影的角度, 默认为 45.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的角度, 默认为 45" )]
		public int ShadowAngle
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.shadowAngle, 45 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowAngle, value < 0 || value >= 360 ? "45" : value.ToString ( ), "45" ); }
		}

		/// <summary>
		/// 获取或设置阴影的深度, 默认为 3.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的深度, 默认为 3" )]
		public int ShadowDepth
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.shadowDepth, 3 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowDepth, value < 0 ? "3" : value.ToString ( ), "3" ); }
		}

		/// <summary>
		/// 获取或设置阴影的偏移, 默认为 1.25.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的偏移, 默认为 1.25" )]
		public double ShadowOffset
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.shadowOffset, 1.25 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowOffset, value.ToString ( ), "1.25" ); }
		}

		/// <summary>
		/// 获取或设置是否显示标题, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示标题, 默认为 true" )]
		public bool Show
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.show, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.show, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示图例标题, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示图例标题, 默认为 true" )]
		public bool ShowLabel
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showLabel, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showLabel, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示线, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示线, 默认为 true" )]
		public bool ShowLine
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showLine, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.show, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示标记, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示标记, 默认为 true" )]
		public bool ShowMarker
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showMarker, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showMarker, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否使用负色, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否使用负色, 默认为 true" )]
		public bool UseNegativeColors
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.useNegativeColors, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.useNegativeColors, value, true ); }
		}

		/// <summary>
		/// 获取或设置序列关联的 x 轴, 默认为 xaxis.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "序列关联的 x 轴, 默认为 xaxis" )]
		public XAxisType XAxis
		{
			get { return this.settingHelper.GetOptionValueToEnum<XAxisType> ( OptionType.xaxis, XAxisType.xaxis ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.xaxis, value.ToString ( ), XAxisType.xaxis.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置序列关联的 y 轴, 默认为 yaxis.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "序列关联的 y 轴, 默认为 yaxis" )]
		public YAxisType YAxis
		{
			get { return this.settingHelper.GetOptionValueToEnum<YAxisType> ( OptionType.yaxis, YAxisType.yaxis ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.yaxis, value.ToString ( ), YAxisType.yaxis.ToString ( ) ); }
		}
		#endregion

		/// <summary>
		/// 创建一个序列.
		/// </summary>
		public Series ( )
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

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/SeriesRendererSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " SeriesRendererSetting "
	/// <summary>
	/// 轴标签绘制设置.
	/// </summary>
	public sealed class SeriesRendererSetting
	{

		#region " BarDirectionType "
		/// <summary>
		/// 柱状图方向.
		/// </summary>
		public enum BarDirectionType
		{
			/// <summary>
			/// 垂直.
			/// </summary>
			vertical,
			/// <summary>
			/// 水平.
			/// </summary>
			horizontal,
		}
		#endregion

		private readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " common option "

		/// <summary>
		/// 获取或设置高亮颜色, 默认为 "[]".
		/// </summary>
		[Category ( "通用" )]
		[Description ( "高亮颜色, 默认为 []" )]
		public string HighlightColors
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.highlightColors, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.highlightColors, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置鼠标滑过是否高亮, 默认为 true.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "鼠标滑过是否高亮, 默认为 true" )]
		public bool HighlightMouseOver
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.highlightMouseOver, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.highlightMouseOver, value, true ); }
		}

		/// <summary>
		/// 获取或设置鼠标按下是否高亮, 默认为 false.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "鼠标按下是否高亮, 默认为 false" )]
		public bool HighlightMouseDown
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.highlightMouseDown, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.highlightMouseDown, value, false ); }
		}

		#endregion

		#region " line option "

		/// <summary>
		/// 获取或设置高亮颜色, 默认为 Transparent.
		/// </summary>
		[Category ( "直线" )]
		[Description ( "高亮颜色, 默认为 Transparent" )]
		public Color HighlightColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.highlightColor, Color.Transparent ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.highlightColor, value, Color.Transparent ); }
		}

		#endregion

		#region " bar option "
		/// <summary>
		/// 获取或设置柱状图方向, 默认为 vertical.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "柱状图方向, 默认为 vertical" )]
		public BarDirectionType BarDirection
		{
			get { return this.settingHelper.GetOptionValueToEnum<BarDirectionType> ( OptionType.barDirection, BarDirectionType.vertical ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.barDirection, value.ToString ( ), BarDirectionType.vertical.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置外空白, 默认为 10.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "外空白, 默认为 10" )]
		public int BarMargin
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.barMargin, 10 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.barMargin, value < 0 ? "10" : value.ToString ( ), "10" ); }
		}

		/// <summary>
		/// 获取或设置内空白大小, 默认为 8.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "内空白大小, 默认为 8" )]
		public int BarPadding
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.barPadding, 8 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.barPadding, value < 0 ? "8" : value.ToString ( ), "8" ); }
		}

		/// <summary>
		/// 获取或设置柱状图宽度, 默认为 -1.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "柱状图宽度, 默认为 -1" )]
		public int BarWidth
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.barWidth, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.barWidth, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置分组的数目, 默认为 1.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "分组的数目, 默认为 1" )]
		public int Groups
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.groups, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.groups, value < 0 ? "1" : value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置阴影的透明度, 默认为 0.08.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "阴影的透明度, 默认为 0.08" )]
		public double ShadowAlpha
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.shadowAlpha, 0.08 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowAlpha, value < 0 || value > 1 ? "0.08" : value.ToString ( ), "0.08" ); }
		}

		/// <summary>
		/// 获取或设置阴影的深度, 默认为 5.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "阴影的深度, 默认为 5" )]
		public int ShadowDepth
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.shadowDepth, 5 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowDepth, value < 0 ? "5" : value.ToString ( ), "5" ); }
		}

		/// <summary>
		/// 获取或设置阴影的偏移, 默认为 2.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "阴影的偏移, 默认为 2" )]
		public int ShadowOffset
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.shadowOffset, 2 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowOffset, value.ToString ( ), "2" ); }
		}

		/// <summary>
		/// 获取或设置数据换位, 默认为 true.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "数据换位, 默认为 true" )]
		public bool TransposedData
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.transposedData, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.transposedData, value, true ); }
		}

		/// <summary>
		/// 获取或设置使用不同的颜色, 默认为 false.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "使用不同的颜色, 默认为 false" )]
		public bool VaryBarColor
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.varyBarColor, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.varyBarColor, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否使用瀑布, 默认为 false.
		/// </summary>
		[Category ( "柱状图" )]
		[Description ( "是否使用瀑布, 默认为 false" )]
		public bool Waterfall
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.waterfall, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.waterfall, value, false ); }
		}

		#endregion

		#region " block option "

		/// <summary>
		/// 获取或设置是否解释 html, 默认为 false.
		/// </summary>
		[Category ( "断点" )]
		[Description ( "是否解释 html, 默认为 false" )]
		public bool BlockEscapeHtml
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.escapeHtml, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.escapeHtml, value, false ); }
		}

		/// <summary>
		/// 获取或设置断点样式, 默认为 "{padding:'2px', border:'1px solid #999', textAlign:'center'}".
		/// </summary>
		[Category ( "断点" )]
		[Description ( "断点样式, 默认为 {padding:'2px', border:'1px solid #999', textAlign:'center'}" )]
		public string Css
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.css, "{padding:'2px', border:'1px solid #999', textAlign:'center'}" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.css, value, "{padding:'2px', border:'1px solid #999', textAlign:'center'}" ); }
		}

		/// <summary>
		/// 获取或设置是否插入换行, 默认为 true.
		/// </summary>
		[Category ( "断点" )]
		[Description ( "是否插入换行, 默认为 true" )]
		public bool InsertBreaks
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.insertBreaks, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.insertBreaks, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否使用不同颜色, 默认为 false.
		/// </summary>
		[Category ( "断点" )]
		[Description ( "是否使用不同颜色, 默认为 false" )]
		public bool VaryBlockColors
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.varyBlockColors, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.varyBlockColors, value, false ); }
		}

		#endregion

		#region " bubble option "

		/// <summary>
		/// 获取或设置是否解释 html, 默认为 true.
		/// </summary>
		[Category ( "泡泡图" )]
		[Description ( "是否解释 html, 默认为 true" )]
		public bool BubbleEscapeHtml
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.escapeHtml, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.escapeHtml, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否自动缩放, 默认为 true.
		/// </summary>
		[Category ( "泡泡图" )]
		[Description ( "是否自动缩放, 默认为 true" )]
		public bool AutoscaleBubbles
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.autoscaleBubbles, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.autoscaleBubbles, value, true ); }
		}

		/// <summary>
		/// 获取或设置自动缩放倍数, 默认为 1.0.
		/// </summary>
		[Category ( "泡泡图" )]
		[Description ( "自动缩放倍数, 默认为 1.0" )]
		public double AutoscaleMultiplier
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.autoscaleMultiplier, 1.0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.autoscaleMultiplier, value < 0 ? "1.0" : value.ToString ( ), "1.0" ); }
		}
		
		/// <summary>
		/// 获取或设置自动缩放因子, 默认为 -0.07.
		/// </summary>
		[Category ( "泡泡图" )]
		[Description ( "自动缩放因子, 默认为 -0.07" )]
		public double AutoscalePointsFactor
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.autoscalePointsFactor, -0.07 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.autoscalePointsFactor, value.ToString ( ), "-0.07" ); }
		}
		
		/// <summary>
		/// 获取或设置透明度, 默认为 1.0.
		/// </summary>
		[Category ( "泡泡图" )]
		[Description ( "透明度, 默认为 1.0" )]
		public double BubbleAlpha
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.bubbleAlpha, 1.0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.bubbleAlpha, value < 0 || value > 1 ? "1.0" : value.ToString ( ), "1.0" ); }
		}
		
		/// <summary>
		/// 获取或设置泡泡是否渐变, 默认为 false.
		/// </summary>
		[Category ( "泡泡图" )]
		[Description ( "泡泡是否渐变, 默认为 false" )]
		public bool BubbleGradients
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.bubbleGradients, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.bubbleGradients, value, false ); }
		}

		/// <summary>
		/// 获取或设置高亮透明度, 默认为 -1.
		/// </summary>
		[Category ( "泡泡图" )]
		[Description ( "高亮透明度, 默认为 -1" )]
		public double HighlightAlpha
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.highlightAlpha, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.highlightAlpha, value < 0 || value > 1 ? "-1" : value.ToString ( ), "-1" ); }
		}
		
		/// <summary>
		/// 获取或设置是否显示标签, 默认为 true.
		/// </summary>
		[Category ( "泡泡图" )]
		[Description ( "是否显示标签, 默认为 true" )]
		public bool ShowLabels
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showLabels, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showLabels, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否使用不同颜色, 默认为 true.
		/// </summary>
		[Category ( "泡泡图" )]
		[Description ( "是否使用不同颜色, 默认为 true" )]
		public bool VaryBubbleColors
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.varyBubbleColors, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.varyBubbleColors, value, true ); }
		}

		#endregion

		/// <summary>
		/// 创建一个轴标签绘制设置.
		/// </summary>
		public SeriesRendererSetting ( )
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

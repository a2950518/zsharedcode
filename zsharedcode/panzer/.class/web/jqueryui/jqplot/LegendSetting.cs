/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/LegendSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " LegendSetting "
	/// <summary>
	/// 图例的设置.
	/// </summary>
	public sealed class LegendSetting
	{
		#region " PlacementType "
		/// <summary>
		/// 放置的类型.
		/// </summary>
		public enum PlacementType
		{
			/// <summary>
			/// 在网格内部.
			/// </summary>
			insideGrid,
			/// <summary>
			/// 在网格外部.
			/// </summary>
			outsideGrid,
			/// <summary>
			/// 内部.
			/// </summary>
			inside,
			/// <summary>
			/// 外部.
			/// </summary>
			outside,
		}
		#endregion

		private readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " option "
		/// <summary>
		/// 获取或设置是否解释 html, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否解释 html, 默认为 false" )]
		public bool EscapeHtml
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.escapeHtml, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.escapeHtml, value, false ); }
		}

		/// <summary>
		/// 获取或设置背景, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "背景, 默认为空" )]
		public string Background
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.background, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.background, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置边框, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "边框, 默认为空" )]
		public string Border
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.border, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.border, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置字体, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "字体, 默认为空" )]
		public string FontFamily
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.fontFamily, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.fontFamily, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置字体大小, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "字体大小, 默认为空" )]
		public FontUnit FontSize
		{
			get { return this.settingHelper.GetOptionValueToFontUnit ( OptionType.fontSize, FontUnit.Empty ); }
			set { this.settingHelper.SetOptionValueToFontUnit ( OptionType.fontSize, value, FontUnit.Empty ); }
		}

		/// <summary>
		/// 获取或设置边框, 默认为 "[]".
		/// </summary>
		[Category ( "外观" )]
		[Description ( "边框, 默认为 []" )]
		public string Labels
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.labels, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.labels, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置提示位置, 默认为 ne.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "提示位置, 默认为 ne" )]
		public LocationType Location
		{
			get { return this.settingHelper.GetOptionValueToEnum<LocationType> ( OptionType.location, LocationType.ne ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.location, value.ToString ( ), LocationType.ne.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置图例的下方距离, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "图例的下方距离, 默认为空" )]
		public Unit MarginBottom
		{
			get { return this.settingHelper.GetOptionValueToUnit ( OptionType.marginBottom, Unit.Empty ); }
			set { this.settingHelper.SetOptionValueToUnit ( OptionType.marginBottom, value, Unit.Empty ); }
		}

		/// <summary>
		/// 获取或设置图例的左方距离, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "图例的左方距离, 默认为空" )]
		public Unit MarginLeft
		{
			get { return this.settingHelper.GetOptionValueToUnit ( OptionType.marginLeft, Unit.Empty ); }
			set { this.settingHelper.SetOptionValueToUnit ( OptionType.marginLeft, value, Unit.Empty ); }
		}

		/// <summary>
		/// 获取或设置图例的右方距离, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "图例的右方距离, 默认为空" )]
		public Unit MarginRight
		{
			get { return this.settingHelper.GetOptionValueToUnit ( OptionType.marginRight, Unit.Empty ); }
			set { this.settingHelper.SetOptionValueToUnit ( OptionType.marginRight, value, Unit.Empty ); }
		}

		/// <summary>
		/// 获取或设置图例的上方距离, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "图例的上方距离, 默认为空" )]
		public Unit MarginTop
		{
			get { return this.settingHelper.GetOptionValueToUnit ( OptionType.marginTop, Unit.Empty ); }
			set { this.settingHelper.SetOptionValueToUnit ( OptionType.marginTop, value, Unit.Empty ); }
		}

		/// <summary>
		/// 获取或设置图例位置, 默认为 insideGrid.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "图例位置, 默认为 insideGrid" )]
		public PlacementType Placement
		{
			get { return this.settingHelper.GetOptionValueToEnum<PlacementType> ( OptionType.placement, PlacementType.insideGrid ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.placement, value.ToString ( ), PlacementType.insideGrid.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置绘制方式, 默认为 None.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "绘制方式, 默认为 None" )]
		public PlotPlusinType Renderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.renderer, PlotPlusinType.None.ToString ( ) ), PlotPlusinType.None ); }
			set { this.settingHelper.SetOptionValue ( OptionType.renderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.None ) ); }
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
		/// 获取或设置字体大小, 默认为 0.5em.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "字体大小, 默认为 0.5em" )]
		public Unit RowSpacing
		{
			get { return this.settingHelper.GetOptionValueToUnit ( OptionType.rowSpacing, Unit.Parse ( "0.5em" ) ); }
			set { this.settingHelper.SetOptionValueToUnit ( OptionType.rowSpacing, value, Unit.Parse ( "0.5em" ) ); }
		}

		/// <summary>
		/// 获取或设置是否显示图例, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示图例, 默认为 false" )]
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
		public bool ShowLabels
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showLabels, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showLabels, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示颜色切换, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示颜色切换, 默认为 true" )]
		public bool ShowSwatch
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showSwatch, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showSwatch, value, true ); }
		}

		/// <summary>
		/// 获取或设置颜色, 默认为 Transparent.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "颜色, 默认为 Transparent" )]
		public Color TextColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.textColor, Color.Transparent ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.textColor, value, Color.Transparent ); }
		}

		/// <summary>
		/// 获取或设置 x 偏移值, 默认为 0.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "x 偏移值, 默认为 0" )]
		public int XOffset
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.xoffset, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.xoffset, value.ToString ( ), "0" ); }
		}

		/// <summary>
		/// 获取或设置 y 偏移值, 默认为 0.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "y 偏移值, 默认为 0" )]
		public int YOffset
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.yoffset, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.yoffset, value.ToString ( ), "0" ); }
		}
		#endregion

		/// <summary>
		/// 创建一个图例的设置.
		/// </summary>
		public LegendSetting ( )
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

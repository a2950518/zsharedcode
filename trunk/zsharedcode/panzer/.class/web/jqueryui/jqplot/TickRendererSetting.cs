/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/TickRendererSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " TickRendererSetting "
	/// <summary>
	/// 刻度绘制设置.
	/// </summary>
	public sealed class TickRendererSetting
	{

		#region " MarkType "
		/// <summary>
		/// 标记类型.
		/// </summary>
		public enum MarkType
		{
			/// <summary>
			/// 外部.
			/// </summary>
			outside,
			/// <summary>
			/// 内部.
			/// </summary>
			inside,
			/// <summary>
			/// 穿过.
			/// </summary>
			cross,
		}
		#endregion

		#region " LabelPositionType "
		/// <summary>
		/// 标签位置类型.
		/// </summary>
		public enum LabelPositionType
		{
			/// <summary>
			/// 自动.
			/// </summary>
			auto,
			/// <summary>
			/// 开始位置.
			/// </summary>
			start,
			/// <summary>
			/// 中间位置.
			/// </summary>
			middle,
			/// <summary>
			/// 结束位置.
			/// </summary>
			end,
		}
		#endregion

		private readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " common option "

		/// <summary>
		/// 获取或设置格式化字符串, 默认为空字符串.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "格式化字符串, 默认为空字符串" )]
		public string FormatString
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.formatString, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.formatString, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置格式化工具, 默认为 DefaultTickFormatter.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "格式化工具, 默认为 DefaultTickFormatter" )]
		public PlotPlusinType Formatter
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.formatter, PlotPlusinType.DefaultTickFormatter.ToString ( ) ), PlotPlusinType.DefaultTickFormatter ); }
			set { this.settingHelper.SetOptionValue ( OptionType.formatter, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.DefaultTickFormatter ) ); }
		}

		/// <summary>
		/// 获取或设置是否为次要刻度, 默认为 false.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "是否为次要刻度, 默认为 false" )]
		public bool IsMinorTick
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.isMinorTick, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.isMinorTick, value, false ); }
		}

		/// <summary>
		/// 获取或设置刻度标记类型, 默认为 outside.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "刻度标记类型, 默认为 outside" )]
		public MarkType Mark
		{
			get { return this.settingHelper.GetOptionValueToEnum<MarkType> ( OptionType.mark, MarkType.outside ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.mark, value.ToString ( ), MarkType.outside.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置标题前缀, 默认为空字符串.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "标题前缀, 默认为空字符串" )]
		public string Prefix
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.prefix, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.prefix, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否显示刻度, 默认为 true.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "是否显示刻度, 默认为 true" )]
		public bool Show
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.show, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.show, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示标签, 默认为 true.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "是否显示标签, 默认为 true" )]
		public bool ShowLabel
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showLabel, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showLabel, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示网格线, 默认为 true.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "是否显示网格线, 默认为 true" )]
		public bool ShowGridline
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showGridline, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showGridline, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否显示标记, 默认为 true.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "是否显示标记, 默认为 true" )]
		public bool ShowMark
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showMark, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showMark, value, true ); }
		}
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置是否解释 html, 默认为 false.
		/// </summary>
		[Category ( "普通" )]
		[Description ( "是否解释 html, 默认为 false" )]
		public bool EscapeHtml
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.escapeHTML, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.escapeHTML, value, false ); }
		}

		/// <summary>
		/// 获取或设置字体, 默认为空.
		/// </summary>
		[Category ( "普通" )]
		[Description ( "字体, 默认为空" )]
		public string FontFamily
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.fontFamily, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.fontFamily, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置字体大小, 默认为空.
		/// </summary>
		[Category ( "普通" )]
		[Description ( "字体大小, 默认为空" )]
		public FontUnit FontSize
		{
			get { return this.settingHelper.GetOptionValueToFontUnit ( OptionType.fontSize, FontUnit.Empty ); }
			set { this.settingHelper.SetOptionValueToFontUnit ( OptionType.fontSize, value, FontUnit.Empty ); }
		}

		/// <summary>
		/// 获取或设置刻度的尺寸, 默认为 6.
		/// </summary>
		[Category ( "普通" )]
		[Description ( "刻度的尺寸, 默认为 6" )]
		public int MarkSize
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.markSize, 6 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.markSize, value < 0 ? "6" : value.ToString ( ), "6" ); }
		}

		/// <summary>
		/// 获取或设置刻度的尺寸, 默认为 4.
		/// </summary>
		[Category ( "普通" )]
		[Description ( "刻度的尺寸, 默认为 4" )]
		public int Size
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.size, 4 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.size, value < 0 ? "4" : value.ToString ( ), "4" ); }
		}

		/// <summary>
		/// 获取或设置颜色, 默认为 Transparent.
		/// </summary>
		[Category ( "普通" )]
		[Description ( "颜色, 默认为 Transparent" )]
		public Color TextColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.textColor, Color.Transparent ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.textColor, value, Color.Transparent ); }
		}
		#endregion

		#region " canvas option "

		/// <summary>
		/// 获取或设置字体, 默认为 "Trebuchet MS, Arial, Helvetica, sans-serif".
		/// </summary>
		[Category ( "画布" )]
		[Description ( "字体, 默认为 Trebuchet MS, Arial, Helvetica, sans-serif" )]
		public string CanvasFontFamily
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.fontFamily, "Trebuchet MS, Arial, Helvetica, sans-serif" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.fontFamily, value, "Trebuchet MS, Arial, Helvetica, sans-serif" ); }
		}

		/// <summary>
		/// 获取或设置字体大小, 默认为 10pt.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "字体大小, 默认为 10pt" )]
		public FontUnit CanvasFontSize
		{
			get { return this.settingHelper.GetOptionValueToFontUnit ( OptionType.fontSize, FontUnit.Parse ( "10pt" ) ); }
			set { this.settingHelper.SetOptionValueToFontUnit ( OptionType.fontSize, value, FontUnit.Parse ( "10pt" ) ); }
		}

		/// <summary>
		/// 获取或设置刻度的尺寸, 默认为 4.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "刻度的尺寸, 默认为 4" )]
		public int CanvasMarkSize
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.markSize, 4 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.markSize, value < 0 ? "4" : value.ToString ( ), "4" ); }
		}

		/// <summary>
		/// 获取或设置颜色, 默认为 #666666.
		/// </summary>
		[Category ( "普通" )]
		[Description ( "颜色, 默认为 #666666" )]
		public Color CanvasTextColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.textColor, ColorTranslator.FromHtml ( "#666666" ) ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.textColor, value, ColorTranslator.FromHtml ( "#666666" ) ); }
		}

		/// <summary>
		/// 获取或设置阴影的角度, 默认为 0.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "阴影的角度, 默认为 0" )]
		public int Angle
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.angle, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.angle, value < -90 || value >= 90 ? "0" : value.ToString ( ), "0" ); }
		}

		/// <summary>
		/// 获取或设置是否启用字体支持, 默认为 true.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "是否启用字体支持, 默认为 true" )]
		public bool EnableFontSupport
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.enableFontSupport, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.enableFontSupport, value, true ); }
		}

		/// <summary>
		/// 获取或设置字体压缩倍数, 默认为 1.0.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "字体压缩倍数, 默认为 1.0" )]
		public double FontStretch
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.fontStretch, 1.0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.fontStretch, value < 0 ? "1.0" : value.ToString ( ), "1.0" ); }
		}

		/// <summary>
		/// 获取或设置字体粗细, 默认为 normal.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "字体粗细, 默认为 normal" )]
		public FontWeightType FontWeight
		{
			get { return this.settingHelper.GetOptionValueToEnum<FontWeightType> ( OptionType.fontWeight, FontWeightType.normal ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.fontWeight, value.ToString ( ), FontWeightType.normal.ToString ( ) ); }
		}
		
		/// <summary>
		/// 获取或设置标签位置, 默认为 auto.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "标签位置, 默认为 auto" )]
		public LabelPositionType LabelPosition
		{
			get { return this.settingHelper.GetOptionValueToEnum<LabelPositionType> ( OptionType.labelPosition, LabelPositionType.auto ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.labelPosition, value.ToString ( ), LabelPositionType.auto.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置 pt 转 px 的因子, 默认为 -1.
		/// </summary>
		[Category ( "画布" )]
		[Description ( " pt 转 px 的因子, 默认为 -1" )]
		public double Pt2Px
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.pt2px, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.pt2px, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
		}

		#endregion

		/// <summary>
		/// 创建一个刻度绘制设置.
		/// </summary>
		public TickRendererSetting ( )
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

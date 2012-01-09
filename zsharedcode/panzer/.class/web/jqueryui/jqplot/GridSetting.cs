/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/GridSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " GridSetting "
	/// <summary>
	/// 网格的设置.
	/// </summary>
	public sealed class GridSetting
	{
		private readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " option "
		/// <summary>
		/// 获取或设置背景颜色, 默认为 #fffdf6.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "背景颜色, 默认为 #fffdf6" )]
		public Color Background
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.background, ColorTranslator.FromHtml ( "#fffdf6" ) ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.background, value, ColorTranslator.FromHtml ( "#fffdf6" ) ); }
		}

		/// <summary>
		/// 获取或设置边框颜色, 默认为 #999999.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "边框颜色, 默认为 #999999" )]
		public Color BorderColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.borderColor, ColorTranslator.FromHtml ( "#999999" ) ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.borderColor, value, ColorTranslator.FromHtml ( "#999999" ) ); }
		}

		/// <summary>
		/// 获取或设置线的宽度, 默认为 2.0.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "线的宽度, 默认为 2.0" )]
		public double BorderWidth
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.borderWidth, 2.0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.borderWidth, value < 0 ? "2.0" : value.ToString ( ), "2.0" ); }
		}

		/// <summary>
		/// 获取或设置是否绘制边框, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否绘制边框, 默认为 true" )]
		public bool DrawBorder
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.drawBorder, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.drawBorder, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否绘制网格, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否绘制网格, 默认为 true" )]
		public bool DrawGridlines
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.drawGridlines, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.drawGridlines, value, true ); }
		}

		/// <summary>
		/// 获取或设置线的颜色, 默认为 #cccccc.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "线的颜色, 默认为 #cccccc" )]
		public Color GridLineColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.gridLineColor, ColorTranslator.FromHtml ( "#cccccc" ) ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.gridLineColor, value, ColorTranslator.FromHtml ( "#cccccc" ) ); }
		}

		/// <summary>
		/// 获取或设置线的宽度, 默认为 1.0.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "线的宽度, 默认为 1.0" )]
		public double GridLineWidth
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.gridLineWidth, 1.0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.gridLineWidth, value < 0 ? "1.0" : value.ToString ( ), "1.0" ); }
		}

		/// <summary>
		/// 获取或设置是否显示阴影, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示阴影, 默认为 true" )]
		public bool Shadow
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.shadow, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.shadow, value, true ); }
		}

		//! 因为 ShadowColor 生成的 'rgba(n, n, n, n)', 我们必须将这里的 ShadowAlpha 最为最后一个参数传入其中.
		/// <summary>
		/// 获取或设置阴影的透明度, 默认为 0.07, 尚不能与 ShadowColor 同时使用.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的透明度, 默认为 0.07, 尚不能与 ShadowColor 同时使用" )]
		public double ShadowAlpha
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.shadowAlpha, 0.07 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowAlpha, value < 0 || value > 1 ? "0.07" : value.ToString ( ), "0.07" ); }
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
		/// 获取或设置阴影的颜色, 默认为 Transparent, 尚不能与 ShadowAlpha 同时使用.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的颜色, 默认为 Transparent, 尚不能与 ShadowAlpha 同时使用" )]
		public Color ShadowColor
		{
			get { return this.settingHelper.GetOptionValueToRgbaColor ( OptionType.shadowColor, Color.Transparent ); }
			set { this.settingHelper.SetOptionValueToRgbaColor ( OptionType.shadowColor, value, Color.Transparent ); }
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
		/// 获取或设置阴影的偏移, 默认为 1.5.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的偏移, 默认为 1.5" )]
		public double ShadowOffset
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.shadowOffset, 1.5 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowOffset, value.ToString ( ), "1.5" ); }
		}

		/// <summary>
		/// 获取或设置阴影的宽度, 默认为 3.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的宽度, 默认为 3" )]
		public int ShadowWidth
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.shadowWidth, 3 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowWidth, value < 0 ? "3" : value.ToString ( ), "3" ); }
		}

		/// <summary>
		/// 获取或设置绘制方式, 默认为 CanvasGridRenderer.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "绘制方式, 默认为 CanvasGridRenderer" )]
		public PlotPlusinType Renderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.renderer, PlotPlusinType.CanvasGridRenderer.ToString ( ) ), PlotPlusinType.CanvasGridRenderer ); }
			set { this.settingHelper.SetOptionValue ( OptionType.renderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.CanvasGridRenderer ) ); }
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
		#endregion

		/// <summary>
		/// 创建一个网格的设置.
		/// </summary>
		public GridSetting ( )
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

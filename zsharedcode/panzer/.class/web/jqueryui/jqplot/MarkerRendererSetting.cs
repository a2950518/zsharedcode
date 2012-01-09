/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/MarkerRendererSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " MarkerRendererSetting "
	/// <summary>
	/// 标记绘制设置.
	/// </summary>
	public sealed class MarkerRendererSetting
	{

		#region " StyleType "
		/// <summary>
		/// 标记样式类型.
		/// </summary>
		public enum StyleType
		{
			/// <summary>
			/// 实心圆.
			/// </summary>
			filledCircle,
			/// <summary>
			/// 菱形.
			/// </summary>
			diamond,
			/// <summary>
			/// 圆.
			/// </summary>
			circle,
			/// <summary>
			/// 正方形.
			/// </summary>
			square,
			/// <summary>
			/// x.
			/// </summary>
			x,
			/// <summary>
			/// 加.
			/// </summary>
			plus,
			/// <summary>
			/// 短划线.
			/// </summary>
			dash,
			/// <summary>
			/// 实心菱形.
			/// </summary>
			filledDiamond,
			/// <summary>
			/// 实心正方形.
			/// </summary>
			filledSquare,
		}
		#endregion

		private readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " option "
		
		/// <summary>
		/// 获取或设置标记的颜色, 默认为 #666666.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "标记的颜色, 默认为 #666666" )]
		public Color Color
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.color, ColorTranslator.FromHtml("#666666") ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.color, value, ColorTranslator.FromHtml("#666666") ); }
		}

		/// <summary>
		/// 获取或设置线的宽度, 默认为 2.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "线的宽度, 默认为 2" )]
		public int LineWidth
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.lineWidth, 2 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.lineWidth, value < 0 ? "2" : value.ToString ( ), "2" ); }
		}
		
		/// <summary>
		/// 获取或设置是有阴影, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是有阴影, 默认为 true" )]
		public bool Shadow
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.shadow, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.shadow, value, true ); }
		}

		/// <summary>
		/// 获取或设置阴影的透明度, 默认为 0.07.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的透明度, 默认为 0.07" )]
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
		/// 获取或设置阴影的偏移, 默认为 1.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的偏移, 默认为 1" )]
		public int ShadowOffset
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.shadowOffset, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowOffset, value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置阴影的绘制方式, 默认为 ShadowRenderer.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "阴影的绘制方式, 默认为 ShadowRenderer" )]
		public PlotPlusinType ShadowRenderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.shadowRenderer, PlotPlusinType.ShadowRenderer.ToString ( ) ), PlotPlusinType.ShadowRenderer ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shadowRenderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.ShadowRenderer ) ); }
		}

		/// <summary>
		/// 获取或设置形状的绘制方式, 默认为 ShapeRenderer.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "形状的绘制方式, 默认为 ShapeRenderer" )]
		public PlotPlusinType ShapeRenderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.shapeRenderer, PlotPlusinType.ShapeRenderer.ToString ( ) ), PlotPlusinType.ShapeRenderer ); }
			set { this.settingHelper.SetOptionValue ( OptionType.shapeRenderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.ShapeRenderer ) ); }
		}

		/// <summary>
		/// 获取或设置是否显示标记, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示标记, 默认为 true" )]
		public bool Show
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.show, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.show, value, true ); }
		}
		
		/// <summary>
		/// 获取或设置标记的尺寸, 默认为 9.0.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "标记的尺寸, 默认为 9.0" )]
		public double Size
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.size, 9.0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.size, value < 0 ? "9.0" : value.ToString ( ), "9.0" ); }
		}

		/// <summary>
		/// 获取或设置标记样式, 默认为 filledCircle.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "标记样式, 默认为 filledCircle" )]
		public StyleType Style
		{
			get { return this.settingHelper.GetOptionValueToEnum<StyleType> ( OptionType.style, StyleType.filledCircle ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.style, value.ToString ( ), StyleType.filledCircle.ToString ( ) ); }
		}

		#endregion

		/// <summary>
		/// 创建一个轴绘制设置.
		/// </summary>
		public MarkerRendererSetting ( )
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

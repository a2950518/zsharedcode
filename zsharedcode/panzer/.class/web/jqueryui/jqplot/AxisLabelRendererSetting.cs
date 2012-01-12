/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/AxisLabelRendererSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " AxisLabelRendererSetting "
	/// <summary>
	/// 轴标签绘制设置.
	/// </summary>
	public sealed class AxisLabelRendererSetting
	{

		private readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " common option "

		/// <summary>
		/// 获取或设置是否显示, 默认为 true.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "是否显示, 默认为 true" )]
		public bool Show
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.show, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.show, value, true ); }
		}

		/// <summary>
		/// 获取或设置标签文本, 默认为空字符串.
		/// </summary>
		[Category ( "通用" )]
		[Description ( "标签文本, 默认为空字符串" )]
		public string Label
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.label, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.label, value, string.Empty ); }
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
		#endregion

		#region " canvas option "

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
		/// 获取或设置字体, 默认为 "Trebuchet MS, Arial, Helvetica, sans-serif".
		/// </summary>
		[Category ( "画布" )]
		[Description ( "字体, 默认为 Trebuchet MS, Arial, Helvetica, sans-serif" )]
		public string FontFamily
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.fontFamily, "Trebuchet MS, Arial, Helvetica, sans-serif" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.fontFamily, value, "Trebuchet MS, Arial, Helvetica, sans-serif" ); }
		}

		/// <summary>
		/// 获取或设置字体大小, 默认为 11pt.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "字体大小, 默认为 11pt" )]
		public FontUnit FontSize
		{
			get { return this.settingHelper.GetOptionValueToFontUnit ( OptionType.fontSize, FontUnit.Parse ( "11pt" ) ); }
			set { this.settingHelper.SetOptionValueToFontUnit ( OptionType.fontSize, value, FontUnit.Parse ( "11pt" ) ); }
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
		/// 获取或设置 pt 转 px 的因子, 默认为 -1.
		/// </summary>
		[Category ( "画布" )]
		[Description ( " pt 转 px 的因子, 默认为 -1" )]
		public double Pt2Px
		{
			get { return this.settingHelper.GetOptionValueToDouble ( OptionType.pt2px, -1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.pt2px, value < 0 ? "-1" : value.ToString ( ), "-1" ); }
		}

		/// <summary>
		/// 获取或设置是否显示标签, 默认为 true.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "是否显示标签, 默认为 true" )]
		public bool ShowLabel
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showLabel, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showLabel, value, true ); }
		}
		
		/// <summary>
		/// 获取或设置字体颜色, 默认为 #666666.
		/// </summary>
		[Category ( "画布" )]
		[Description ( "字体颜色, 默认为 #666666" )]
		public Color TextColor
		{
			get { return this.settingHelper.GetOptionValueToHtmlColor ( OptionType.textColor, ColorTranslator.FromHtml("#666666") ); }
			set { this.settingHelper.SetOptionValueToHtmlColor ( OptionType.textColor, value, ColorTranslator.FromHtml("#666666") ); }
		}

		#endregion

		/// <summary>
		/// 创建一个轴标签绘制设置.
		/// </summary>
		public AxisLabelRendererSetting ( )
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

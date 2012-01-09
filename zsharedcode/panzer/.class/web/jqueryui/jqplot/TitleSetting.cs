/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/TitleSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " TitleSetting "
	/// <summary>
	/// 标题的设置.
	/// </summary>
	public sealed class TitleSetting
	{

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
		/// 获取或设置标题文本, 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "标题文本, 默认为空字符串" )]
		public string Text
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.text, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.text, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置对齐方式, 默认为 inherit.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "对齐方式, 默认为 inherit" )]
		public TextAlignType TextAlign
		{
			get { return this.settingHelper.GetOptionValueToEnum<TextAlignType> ( OptionType.textAlign, TextAlignType.inherit ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.textAlign, value.ToString ( ), TextAlignType.inherit.ToString ( ) ); }
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
		/// 获取或设置绘制方式, 默认为 DivTitleRenderer.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "绘制方式, 默认为 DivTitleRenderer" )]
		public PlotPlusinType Renderer
		{
			get { return PlotPlusinTypeConvert.ToEnum ( this.settingHelper.GetOptionValue ( OptionType.renderer, PlotPlusinType.DivTitleRenderer.ToString ( ) ), PlotPlusinType.DivTitleRenderer ); }
			set { this.settingHelper.SetOptionValue ( OptionType.renderer, PlotPlusinTypeConvert.ToJavaScript ( value ), PlotPlusinTypeConvert.ToJavaScript ( PlotPlusinType.DivTitleRenderer ) ); }
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
		/// 获取或设置是否显示标题, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "是否显示标题, 默认为 true" )]
		public bool Show
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.show, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.show, value, true ); }
		}
		#endregion

		/// <summary>
		/// 创建一个标题的设置.
		/// </summary>
		public TitleSetting ( )
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

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/PlotSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.Collections.Generic;

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " FontWeightType "
	/// <summary>
	/// 字体粗细类型.
	/// </summary>
	public enum FontWeightType
	{
		/// <summary>
		/// 正常.
		/// </summary>
		normal,
		/// <summary>
		/// 粗.
		/// </summary>
		bold,
		/// <summary>
		/// 更粗.
		/// </summary>
		bolder,
		/// <summary>
		/// 更细.
		/// </summary>
		lighter,
	}
	#endregion

	#region " LocationType "
	/// <summary>
	/// 提示的方向.
	/// </summary>
	public enum LocationType
	{
		/// <summary>
		/// 北.
		/// </summary>
		n,
		/// <summary>
		/// 南.
		/// </summary>
		s,
		/// <summary>
		/// 西.
		/// </summary>
		w,
		/// <summary>
		/// 东.
		/// </summary>
		e,
		/// <summary>
		/// 东北.
		/// </summary>
		ne,
		/// <summary>
		/// 东南.
		/// </summary>
		se,
		/// <summary>
		/// 西北.
		/// </summary>
		nw,
		/// <summary>
		/// 西南.
		/// </summary>
		sw,
	}
	#endregion

	#region " PlotPlusinType "
	/// <summary>
	/// 各种插件方式.
	/// </summary>
	public enum PlotPlusinType
	{
		/// <summary>
		/// 空.
		/// </summary>
		None,
		/// <summary>
		/// Div 标题绘制.
		/// </summary>
		DivTitleRenderer,
		/// <summary>
		/// 增强图例绘制.
		/// </summary>
		EnhancedLegendRenderer,
		/// <summary>
		/// 画布网格绘制.
		/// </summary>
		CanvasGridRenderer,
		/// <summary>
		/// 直线绘制.
		/// </summary>
		LineRenderer,
		/// <summary>
		/// 标记绘制.
		/// </summary>
		MarkerRenderer,
		/// <summary>
		/// 轴刻度绘制.
		/// </summary>
		AxisTickRenderer,
		/// <summary>
		/// 轴标签绘制.
		/// </summary>
		AxisLabelRenderer,
		/// <summary>
		/// 直线轴绘制.
		/// </summary>
		LinearAxisRenderer,
		/// <summary>
		/// 默认刻度格式化工具.
		/// </summary>
		DefaultTickFormatter,
		/// <summary>
		/// 阴影绘制.
		/// </summary>
		ShadowRenderer,
		/// <summary>
		/// 形状绘制.
		/// </summary>
		ShapeRenderer,
		/// <summary>
		/// 柱状图绘制.
		/// </summary>
		BarRenderer,
		/// <summary>
		/// 贝塞尔曲线绘制.
		/// </summary>
		BezierCurveRenderer,
		/// <summary>
		/// 断点绘制.
		/// </summary>
		BlockRenderer,
		/// <summary>
		/// 画布轴标签绘制.
		/// </summary>
		CanvasAxisLabelRenderer,
		/// <summary>
		/// 日期轴绘制.
		/// </summary>
		DateAxisRenderer,
	}
	#endregion

	#region " PlotPlusinTypeConvert "
	/// <summary>
	/// 插件类型的转化工具.
	/// </summary>
	public sealed class PlotPlusinTypeConvert
	{

		/// <summary>
		/// 将字符串转化为 RendererType.
		/// </summary>
		/// <param name="text">需要转化的字符串.</param>
		/// <param name="defalutType">默认类型.</param>
		/// <returns>插件类型.</returns>
		public static PlotPlusinType ToEnum ( string text, PlotPlusinType defalutType )
		{

			if ( string.IsNullOrEmpty ( text ) )
				return defalutType;
			else
				return SettingHelper.ToEnum<PlotPlusinType> ( text.Replace ( "jQuery.jqplot.", string.Empty ), defalutType );

		}

		/// <summary>
		/// 将 RendererType 转化为 javascript 表达式.
		/// </summary>
		/// <param name="type">插件类型.</param>
		/// <returns>javascript 表达式.</returns>
		public static string ToJavaScript ( PlotPlusinType type )
		{

			if ( type == PlotPlusinType.None )
				return "null";
			else
				return string.Format ( "jQuery.jqplot.{0}", type );

		}

	}
	#endregion

	#region " PlotSetting "
	/// <summary>
	/// 图表设置.
	/// </summary>
	public sealed class PlotSetting
		: PlusinSetting
	{

		#region " option "
		/// <summary>
		/// 获取或设置点, 默认为 [].
		/// </summary>
		public string Data
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.data, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.data, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置图表选项, 默认为空.
		/// </summary>
		public string Options
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.options, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.options, value, string.Empty ); }
		}
		#endregion

		#region " event "

		/// <summary>
		/// 获取或设置填充时的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		public string Fill
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.fill ); }
			set { this.settingHelper.SetOptionValue ( OptionType.fill, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置填充后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		public string Filled
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.filled ); }
			set { this.settingHelper.SetOptionValue ( OptionType.filled, value, string.Empty ); }
		}

		#endregion

		#region " ajax "

		/// <summary>
		/// 获取或设置填充时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Fill.
		/// </summary>
		public AjaxSetting FillAsync
		{
			get { return this.ajaxs[0]; }
			set
			{

				if ( null != value )
					this.ajaxs[0] = value;

			}
		}

		#endregion

		/// <summary>
		/// 创建一个自定义时钟设置.
		/// </summary>
		public PlotSetting ( )
			: base ( PlusinType.plot, 1 )
		{ }

		/// <summary>
		/// 获取时钟所需的基础脚本.
		/// </summary>
		/// <returns>时钟所需的基础脚本.</returns>
		public override Dictionary<string, string> GetDependentScripts ( )
		{
			Dictionary<string, string> plusins = base.GetDependentScripts ( );

			plusins.Add ( "plot", Resources.plot_min );

			return plusins;
		}
		
		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine ( )
		{
			this.FillAsync.EventType = EventType.fill;
			this.FillAsync.Success = "function(data){e.callback.call(pe.jquery, pe, -:data, -:data.__success, -:data.custom);}";
			this.FillAsync.Error = "function(){e.callback.call(pe.jquery, pe, null, false, null);}";

			base.Recombine ( );
		}

	}
	#endregion

}

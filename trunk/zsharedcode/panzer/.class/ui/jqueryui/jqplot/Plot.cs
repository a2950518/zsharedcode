/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/jqplot/Plot.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web.jqueryui;
using zoyobar.shared.panzer.web.jqueryui.plusin.jqplot;

namespace zoyobar.shared.panzer.ui.jqueryui.plusin.jqplot
{

	/// <summary>
	/// 图表插件.
	/// </summary>
	[ToolboxData ( "<{0}:Plot runat=server></{0}:Plot>" )]
	[Resource ( SingleScript = "je.jquery.js;je.jquery.ui.js;je.jqplot.excanvas.js;je.jqplot.js", SingleStyle = "je.jquery.ui.css;je.jqplot.css" )]
	public sealed class Plot
		: JQueryPlusin<PlotSetting>
	{

		#region " option "
		/// <summary>
		/// 获取或设置点, 默认为 [].
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "[]" )]
		[Description ( "点, 默认为 []" )]
		[NotifyParentProperty ( true )]
		public string Data
		{
			get { return this.uiSetting.Data; }
			set { this.uiSetting.Data = value; }
		}

		/// <summary>
		/// 获取或设置图表选项, 默认为空.
		/// </summary>
		[Category ( "选项" )]
		[DefaultValue ( "" )]
		[Description ( "图表选项, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string Options
		{
			get { return this.uiSetting.Options; }
			set { this.uiSetting.Options = value; }
		}
		#endregion

		#region " event "

		/// <summary>
		/// 获取或设置填充时的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充时的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Fill
		{
			get { return this.uiSetting.Fill; }
			set { this.uiSetting.Fill = value; }
		}

		/// <summary>
		/// 获取或设置填充后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Filled
		{
			get { return this.uiSetting.Filled; }
			set { this.uiSetting.Filled = value; }
		}

		#endregion

		#region " ajax "

		/// <summary>
		/// 获取填充时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Fill.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "填充时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Fill" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting FillAsync
		{
			get { return this.uiSetting.FillAsync; }
		}

		#endregion

		#region " plot options "
		private readonly SettingHelper settingHelper = new SettingHelper ( );
		private AxesSetting axesSetting;
		private Axis axesDefaultsSetting;
		private CursorSetting cursorSetting;
		private DragableSetting dragableSetting;
		private GridSetting gridSetting;
		private LegendSetting legendSetting;
		private TitleSetting titleSetting;

		private SeriesSetting seriesSetting;
		private Series seriesDefaultsSetting;

		private DataSetting dataSetting;

		/// <summary>
		/// 获取或设置是否有动画效果, 默认为 false.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( false )]
		[Description ( "是否有动画效果, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Animate
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.animate, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.animate, value, false ); }
		}

		/// <summary>
		/// 获取或设置调用 replot 是否有动画效果, 默认为 false.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( false )]
		[Description ( "调用 replot 是否有动画效果, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool AnimateReplot
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.animateReplot, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.animateReplot, value, false ); }
		}

		/// <summary>
		/// 获取或设置图表的轴, 默认为空.
		/// </summary>
		[Category ( "轴" )]
		[DefaultValue ( "" )]
		[Description ( "图表的轴, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string Axes
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.axes, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.axes, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置图表的轴.
		/// </summary>
		[Category ( "轴" )]
		[Description ( "图表的轴" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AxesSetting AxesSetting
		{
			get
			{

				if ( null == this.axesSetting )
					this.axesSetting = new AxesSetting ( );

				return this.axesSetting;
			}
		}

		/// <summary>
		/// 获取或设置默认轴设置, 默认为空.
		/// </summary>
		[Category ( "轴" )]
		[DefaultValue ( "" )]
		[Description ( "默认轴设置, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string AxesDefaults
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.axesDefaults, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.axesDefaults, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置轴的默认设置.
		/// </summary>
		[Category ( "轴" )]
		[Description ( "轴的默认设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public Axis AxesDefaultsSetting
		{
			get
			{

				if ( null == this.axesDefaultsSetting )
					this.axesDefaultsSetting = new Axis ( );

				return this.axesDefaultsSetting;
			}
		}

		/// <summary>
		/// 获取或设置绘制数据的函数, 默认为空.
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "" )]
		[Description ( "绘制数据的函数, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string DataRenderer
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.dataRenderer, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.dataRenderer, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置绘制数据的选项, 默认为空.
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "" )]
		[Description ( "绘制数据的选项, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string DataRendererOptions
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.dataRendererOptions, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.dataRendererOptions, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置默认的开始轴, 默认为 1.
		/// </summary>
		[Category ( "轴" )]
		[DefaultValue ( 1 )]
		[Description ( "默认的开始轴, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public int DefaultAxisStart
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.defaultAxisStart, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.defaultAxisStart, value < 1 ? "1" : value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置拖动设置, 默认为空.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "拖动设置, 默认为空." )]
		[NotifyParentProperty ( true )]
		public string Dragable
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.dragable, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.dragable, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置拖动设置.
		/// </summary>
		[Category ( "行为" )]
		[Description ( "拖动设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public DragableSetting DragableSetting
		{
			get
			{

				if ( null == this.dragableSetting )
					this.dragableSetting = new DragableSetting ( );

				return this.dragableSetting;
			}
		}

		/// <summary>
		/// 获取或设置鼠标设置, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "鼠标设置, 默认为空." )]
		[NotifyParentProperty ( true )]
		public string Cursor
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.cursor, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.cursor, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置鼠标设置.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "鼠标设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public CursorSetting CursorSetting
		{
			get
			{

				if ( null == this.cursorSetting )
					this.cursorSetting = new CursorSetting ( );

				return this.cursorSetting;
			}
		}

		/// <summary>
		/// 获取或设置填充内容设置, 默认为 "{ series1: null, series2: null, color: null, baseSeries: 0, fill: true }".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "填充内容设置, 默认为 { series1: null, series2: null, color: null, baseSeries: 0, fill: true }." )]
		[NotifyParentProperty ( true )]
		public string FillBetween
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.fillBetween, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.fillBetween, value, string.Empty ); }
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
		/// 获取或设置网格设置, 默认为空.
		/// </summary>
		[Category ( "网格" )]
		[DefaultValue ( "" )]
		[Description ( "网格设置, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.grid, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.grid, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置网格设置.
		/// </summary>
		[Category ( "网格" )]
		[Description ( "网格设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public GridSetting GridSetting
		{
			get
			{

				if ( null == this.gridSetting )
					this.gridSetting = new GridSetting ( );

				return this.gridSetting;
			}
		}

		/// <summary>
		/// 获取或设置图例设置, 默认为空.
		/// </summary>
		[Category ( "图例" )]
		[DefaultValue ( "" )]
		[Description ( "图例设置, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string Legend
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.legend, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.legend, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置图例设置.
		/// </summary>
		[Category ( "图例" )]
		[Description ( "图例设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public LegendSetting LegendSetting
		{
			get
			{

				if ( null == this.legendSetting )
					this.legendSetting = new LegendSetting ( );

				return this.legendSetting;
			}
		}

		/// <summary>
		/// 获取或设置空数据指示器, 默认为空.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "空数据指示器, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string NoDataIndicator
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.noDataIndicator, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.noDataIndicator, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置序列, 默认为 "[]".
		/// </summary>
		[Category ( "序列" )]
		[DefaultValue ( "[]" )]
		[Description ( "序列, 默认为 []" )]
		[NotifyParentProperty ( true )]
		public string Series
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.series, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.series, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置序列设置.
		/// </summary>
		[Category ( "序列" )]
		[Description ( "序列设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public SeriesSetting SeriesSetting
		{
			get
			{

				if ( null == this.seriesSetting )
					this.seriesSetting = new SeriesSetting ( );

				return this.seriesSetting;
			}
		}

		/// <summary>
		/// 获取或设置图表序列的颜色, 默认为 "$.jqplot.config.defaultColors".
		/// </summary>
		[Category ( "序列" )]
		[DefaultValue ( "$.jqplot.config.defaultColors" )]
		[Description ( "图表序列的颜色, 默认为 $.jqplot.config.defaultColors" )]
		[NotifyParentProperty ( true )]
		public string SeriesColors
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.seriesColors, "$.jqplot.config.defaultColors" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.seriesColors, value, "$.jqplot.config.defaultColors" ); }
		}

		/// <summary>
		/// 获取或设置序列默认设置, 默认为空.
		/// </summary>
		[Category ( "序列" )]
		[DefaultValue ( "" )]
		[Description ( "序列默认设置, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string SeriesDefaults
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.seriesDefaults, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.seriesDefaults, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置序列默认设置.
		/// </summary>
		[Category ( "序列" )]
		[Description ( "序列默认设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public Series SeriesDefaultsSetting
		{
			get
			{

				if ( null == this.seriesDefaultsSetting )
					this.seriesDefaultsSetting = new Series ( );

				return this.seriesDefaultsSetting;
			}
		}

		/// <summary>
		/// 获取或设置是否对数据排序, 默认为 true.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( true )]
		[Description ( "是否对数据排序, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool SortData
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.sortData, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.sortData, value, true ); }
		}

		/// <summary>
		/// 获取或设置是否使用堆栈, 默认为 false.
		/// </summary>
		[Category ( "序列" )]
		[DefaultValue ( false )]
		[Description ( "是否使用堆栈, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool StackSeries
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.stackSeries, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.stackSeries, value, false ); }
		}

		/// <summary>
		/// 获取或设置图表标题设置, 默认为空.
		/// </summary>
		[Category ( "标题" )]
		[DefaultValue ( "" )]
		[Description ( "图表标题设置, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string Title
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.title, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.title, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置标题.
		/// </summary>
		[Category ( "标题" )]
		[Description ( "标题" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public TitleSetting TitleSetting
		{
			get
			{

				if ( null == this.titleSetting )
					this.titleSetting = new TitleSetting ( );

				return this.titleSetting;
			}
		}

		/// <summary>
		/// 获取或设置数据设置.
		/// </summary>
		[Category ( "数据" )]
		[Description ( "数据设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public DataSetting DataSetting
		{
			get
			{

				if ( null == this.dataSetting )
					this.dataSetting = new DataSetting ( );

				return this.dataSetting;
			}
		}


		#endregion

		/// <summary>
		/// 创建一个自定义图表.
		/// </summary>
		public Plot ( )
			: base ( new PlotSetting ( ), HtmlTextWriterTag.Div )
		{ }

		/// <summary>
		/// 添加数据.
		/// </summary>
		/// <param name="datas">数据的数组.</param>
		public void AppendData ( params Data[] datas )
		{

			if ( null == datas )
				return;

			foreach ( Data data in datas )
				if ( null != data )
					this.DataSetting.DataList.Add ( data );

		}

		protected override void renderJQuery ( JQueryUI jquery )
		{
			//! Cannot write these codes in PlotSetting.Recombine, because PlotSetting has no Title attributes

			if ( this.Axes == string.Empty && null != this.axesSetting )
				this.Axes = JQueryUI.MakeOptionExpression ( this.axesSetting.CreateOptions ( ) );

			if ( this.AxesDefaults == string.Empty && null != this.axesDefaultsSetting )
				this.AxesDefaults = JQueryUI.MakeOptionExpression ( this.axesDefaultsSetting.CreateOptions ( ) );

			if ( this.Cursor == string.Empty && null != this.cursorSetting )
				this.Cursor = JQueryUI.MakeOptionExpression ( this.cursorSetting.CreateOptions ( ) );

			if ( this.Dragable == string.Empty && null != this.dragableSetting )
				this.Dragable = JQueryUI.MakeOptionExpression ( this.dragableSetting.CreateOptions ( ) );

			if ( this.Grid == string.Empty && null != this.gridSetting )
				this.Grid = JQueryUI.MakeOptionExpression ( this.gridSetting.CreateOptions ( ) );

			if ( this.Legend == string.Empty && null != this.legendSetting )
				this.Legend = JQueryUI.MakeOptionExpression ( this.legendSetting.CreateOptions ( ) );

			if ( this.Title == string.Empty && null != this.titleSetting )
				this.Title = JQueryUI.MakeOptionExpression ( this.titleSetting.CreateOptions ( ) );

			if ( this.Series == "[]" && null != this.seriesSetting )
			{
				string setting = string.Empty;

				foreach ( Series series in this.seriesSetting.SeriesList )
					if ( null != series )
						setting += JQueryUI.MakeOptionExpression ( series.CreateOptions ( ) ) + ",";

				this.Series = string.Format ( "[{0}]", setting.TrimEnd ( ',' ) );
			}

			if ( this.SeriesDefaults == string.Empty && null != this.seriesDefaultsSetting )
				this.SeriesDefaults = JQueryUI.MakeOptionExpression ( this.seriesDefaultsSetting.CreateOptions ( ) );

			if ( this.Options == string.Empty )
				this.Options = JQueryUI.MakeOptionExpression ( this.settingHelper.CreateOptions ( ) );

			if ( this.Data == "[]" && null != this.dataSetting )
			{
				string dataExpression = string.Empty;

				foreach ( Data data in this.dataSetting.DataList )
					if ( null != data )
					{
						string pointExpression = string.Empty;

						foreach ( Point point in data.PointList )
							if ( null != point )
								pointExpression += string.Format ( ",[{0},{1},{2},{3}]",
									string.IsNullOrEmpty ( point.Param1 ) ? "null" : point.Param1,
									string.IsNullOrEmpty ( point.Param2 ) ? "null" : point.Param2,
									string.IsNullOrEmpty ( point.Param3 ) ? "null" : point.Param3,
									string.IsNullOrEmpty ( point.Param4 ) ? "null" : point.Param4
									);

						dataExpression += ",[" + pointExpression.TrimStart ( ',' ) + "]";
					}

				this.Data = "[" + dataExpression.TrimStart ( ',' ) + "]";
			}

			base.renderJQuery ( jquery );
		}

		protected override bool isFaceless ( )
		{ return this.DesignMode; }

		protected override bool isFace ( )
		{ return false; }

		protected override string facelessPrefix ( )
		{ return "Plot"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Data );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Plot.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;
using zoyobar.shared.panzer.web.jqueryui.plusin.jqplot;

namespace zoyobar.shared.panzer.ui.jqueryui.plusin.jqplot
{

	/// <summary>
	/// 图表插件.
	/// </summary>
	[ToolboxData ( "<{0}:Plot runat=server></{0}:Plot>" )]
	public class Plot
		: JQueryPlusin<PlotSetting>
	{

		#region " option "
		/// <summary>
		/// 获取或设置点, 默认为 [].
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "[]" )]
		[Description ( "点, 默认为 []." )]
		[NotifyParentProperty ( true )]
		public string Points
		{
			get { return this.uiSetting.Points; }
			set { this.uiSetting.Points = value; }
		}

		/// <summary>
		/// 获取或设置图表选项, 默认为空.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "图表选项, 默认为空." )]
		[NotifyParentProperty ( true )]
		public string Options
		{
			get { return this.uiSetting.Options; }
			set { this.uiSetting.Options = value; }
		}
		#endregion

		#region " plot options "
		private readonly SettingHelper settingHelper = new SettingHelper ( );
		private AxesSetting axesSetting;
		private CursorSetting cursorSetting;

		/// <summary>
		/// 获取或设置图表的轴, 默认为空.
		/// </summary>
		[Category ( "设置" )]
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
		[Category ( "设置" )]
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
		/// 获取或设置鼠标设置, 默认为空.
		/// </summary>
		[Category ( "设置" )]
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
		[Category ( "设置" )]
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
		/// 获取或设置图表标题, 比如: "['#ff0000', '#00ff00']", 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "图表标题, 比如: ['#ff0000', '#00ff00'], 默认为空" )]
		[NotifyParentProperty ( true )]
		public string SeriesColors
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.seriesColors, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.seriesColors, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否使用堆栈, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "是否使用堆栈, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool StackSeries
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.stackSeries, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.stackSeries, value, false ); }
		}

		/// <summary>
		/// 获取或设置图表标题, 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "图表标题, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Title
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.title, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.title, value, string.Empty ); }
		}
		#endregion

		/// <summary>
		/// 创建一个自定义图表.
		/// </summary>
		public Plot ( )
			: base ( new PlotSetting ( ), HtmlTextWriterTag.Div )
		{ }

		protected override void renderJQuery ( JQueryUI jquery )
		{
			//! Cannot write these codes in PlotSetting.Recombine, because PlotSetting has no Title attributes

			if ( this.Axes == string.Empty && null != this.axesSetting )
				this.Axes = JQueryUI.MakeOptionExpression ( this.axesSetting.CreateOptions ( ) );

			if ( this.Cursor == string.Empty && null != this.cursorSetting )
				this.Cursor = JQueryUI.MakeOptionExpression ( this.cursorSetting.CreateOptions ( ) );

			if ( this.Options == string.Empty )
				this.Options = JQueryUI.MakeOptionExpression ( this.settingHelper.CreateOptions ( ) );

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

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Points );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

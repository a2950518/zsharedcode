/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Datepicker.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 折叠列表插件.
	/// </summary>
	[ToolboxData ( "<{0}:Datepicker runat=server></{0}:Datepicker>" )]
	public class Datepicker
		: JQueryWidget<DatepickerSetting>
	{

		/// <summary>
		/// 创建一个 jQuery UI 日期框.
		/// </summary>
		public Datepicker ( )
			: base ( new DatepickerSetting ( ), HtmlTextWriterTag.Input )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置日期框是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示日期框是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置备用字段, 是一个选择器, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示备用字段, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AltField
		{
			get { return this.uiSetting.AltField; }
			set { this.uiSetting.AltField = value; }
		}

		/// <summary>
		/// 获取或设置在备用字段显示的日期格式, 比如: "yy-mm-dd", 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示在备用字段显示的日期格式, 比如: yy-mm-dd, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string AltFormat
		{
			get { return this.uiSetting.AltFormat; }
			set { this.uiSetting.AltFormat = value; }
		}

		/// <summary>
		/// 获取或设置显示在日期字段后的文本, 比如: "...", 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示在日期字段后的文本, 比如: ..., 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string AppendText
		{
			get { return this.uiSetting.AppendText; }
			set { this.uiSetting.AppendText = value; }
		}

		/// <summary>
		/// 获取或设置是否自动调整输入框的大小, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否自动调整输入框的大小, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool AutoSize
		{
			get { return this.uiSetting.AutoSize; }
			set { this.uiSetting.AutoSize = value; }
		}

		/// <summary>
		/// 获取或设置按钮的图片, 比如: "/images/datepicker.gif", 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的图片, 比如: /images/datepicker.gif, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string ButtonImage
		{
			get { return this.uiSetting.ButtonImage; }
			set { this.uiSetting.ButtonImage = value; }
		}

		/// <summary>
		/// 获取或设置是否按钮只显示图片, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否按钮只显示图片, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ButtonImageOnly
		{
			get { return this.uiSetting.ButtonImageOnly; }
			set { this.uiSetting.ButtonImageOnly = value; }
		}

		/// <summary>
		/// 获取或设置按钮的文本, 默认为 "...".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "..." )]
		[Description ( "指示按钮的文本, 默认为 ..." )]
		[NotifyParentProperty ( true )]
		public string ButtonText
		{
			get { return this.uiSetting.ButtonText; }
			set { this.uiSetting.ButtonText = value; }
		}

		/// <summary>
		/// 获取或设置区域设置, 默认 "$.datepicker.iso8601Week".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "$.datepicker.iso8601Week" )]
		[Description ( "指示区域设置, 默认 $.datepicker.iso8601Week" )]
		[NotifyParentProperty ( true )]
		public string CalculateWeek
		{
			get { return this.uiSetting.CalculateWeek; }
			set { this.uiSetting.CalculateWeek = value; }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变月份, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否允许使用下拉框改变月份, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ChangeMonth
		{
			get { return this.uiSetting.ChangeMonth; }
			set { this.uiSetting.ChangeMonth = value; }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变年份, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否允许使用下拉框改变年份, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ChangeYear
		{
			get { return this.uiSetting.ChangeYear; }
			set { this.uiSetting.ChangeYear = value; }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 默认为 "Done".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "Done" )]
		[Description ( "指示关闭链接的文本, 默认为 Done" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.uiSetting.CloseText; }
			set { this.uiSetting.CloseText = value; }
		}

		/// <summary>
		/// 获取或设置是否限制输入的格式, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否限制输入的格式, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool ConstrainInput
		{
			get { return this.uiSetting.ConstrainInput; }
			set { this.uiSetting.ConstrainInput = value; }
		}

		/// <summary>
		/// 获取或设置当天链接的文本, 比如: "Today".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "Today" )]
		[Description ( "指示当天链接的文本, 比如: Today" )]
		[NotifyParentProperty ( true )]
		public string CurrentText
		{
			get { return this.uiSetting.CurrentText; }
			set { this.uiSetting.CurrentText = value; }
		}

		/// <summary>
		/// 获取或设置日期的格式, 默认为 "mm/dd/yy".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "mm/dd/yy" )]
		[Description ( "指示日期的格式, 默认为 mm/dd/yy" )]
		[NotifyParentProperty ( true )]
		public string DateFormat
		{
			get { return this.uiSetting.DateFormat; }
			set { this.uiSetting.DateFormat = value; }
		}

		/// <summary>
		/// 获取或设置天的名称, 默认为 "['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" )]
		[Description ( "指示天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" )]
		[NotifyParentProperty ( true )]
		public string DayNames
		{
			get { return this.uiSetting.DayNames; }
			set { this.uiSetting.DayNames = value; }
		}

		/// <summary>
		/// 获取或设置天的最短名称, 比如: "['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[Description ( "指示天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesMin
		{
			get { return this.uiSetting.DayNamesMin; }
			set { this.uiSetting.DayNamesMin = value; }
		}

		/// <summary>
		/// 获取或设置天的短名称, 比如: "['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']" )]
		[Description ( "指示天的短名称, 比如: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesShort
		{
			get { return this.uiSetting.DayNamesShort; }
			set { this.uiSetting.DayNamesShort = value; }
		}

		/// <summary>
		/// 获取或设置默认日期.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "指示默认日期" )]
		[NotifyParentProperty ( true )]
		public DateTime DefaultDate
		{
			get { return this.uiSetting.DefaultDate; }
			set { this.uiSetting.DefaultDate = value; }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的日期显示速度, 或者使用 slow, normal, fast 中的一种, 默认为 normal.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( DatepickerSetting.DurationType.normal )]
		[Description ( "指示以毫秒为单位的日期显示速度, 或者使用 slow, normal, fast 中的一种, 默认为 normal" )]
		[NotifyParentProperty ( true )]
		public DatepickerSetting.DurationType Duration
		{
			get { return this.uiSetting.Duration; }
			set { this.uiSetting.Duration = value; }
		}

		/// <summary>
		/// 获取或设置哪一天作为一周的开始, 0 表示周日以此类推, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示哪一天作为一周的开始, 0 表示周日以此类推, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public int FirstDay
		{
			get { return this.uiSetting.FirstDay; }
			set { this.uiSetting.FirstDay = value; }
		}

		/// <summary>
		/// 获取或设置是否再点击当天链接后跳转到选中日期而不是当天, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否再点击当天链接后跳转到选中日期而不是当天, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool GotoCurrent
		{
			get { return this.uiSetting.GotoCurrent; }
			set { this.uiSetting.GotoCurrent = value; }
		}

		/// <summary>
		/// 获取或设置是否隐藏上一和下一链接, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否隐藏上一和下一链接, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool HideIfNoPrevNext
		{
			get { return this.uiSetting.HideIfNoPrevNext; }
			set { this.uiSetting.HideIfNoPrevNext = value; }
		}

		/// <summary>
		/// 获取或设置是否使用从右向左, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否使用从右向左, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool IsRTL
		{
			get { return this.uiSetting.IsRTL; }
			set { this.uiSetting.IsRTL = value; }
		}

		/// <summary>
		/// 获取或设置最大日期.
		/// </summary>
		[Category ( "行为" )]
		[Description ( "指示最大日期" )]
		[NotifyParentProperty ( true )]
		public DateTime MaxDate
		{
			get { return this.uiSetting.MaxDate; }
			set { this.uiSetting.MaxDate = value; }
		}

		/// <summary>
		/// 获取或设置最大日期.
		/// </summary>
		[Category ( "行为" )]
		[Description ( "指示最小日期" )]
		[NotifyParentProperty ( true )]
		public DateTime MinDate
		{
			get { return this.uiSetting.MinDate; }
			set { this.uiSetting.MinDate = value; }
		}

		/// <summary>
		/// 获取或设置月的名称, 默认为 "['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" )]
		[Description ( "指示月的名称, 默认为 ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" )]
		[NotifyParentProperty ( true )]
		public string MonthNames
		{
			get { return this.uiSetting.MonthNames; }
			set { this.uiSetting.MonthNames = value; }
		}

		/// <summary>
		/// 获取或设置月的短名称, 比如: "['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" )]
		[Description ( "指示月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" )]
		[NotifyParentProperty ( true )]
		public string MonthNamesShort
		{
			get { return this.uiSetting.MonthNamesShort; }
			set { this.uiSetting.MonthNamesShort = value; }
		}

		/// <summary>
		/// 获取或设置链接是否使用日期格式, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示链接是否使用日期格式, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool NavigationAsDateFormat
		{
			get { return this.uiSetting.NavigationAsDateFormat; }
			set { this.uiSetting.NavigationAsDateFormat = value; }
		}

		/// <summary>
		/// 获取或设置下一链接的文本, 默认为 "Next".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "Next" )]
		[Description ( "指示下一链接的文本, 默认为 Next" )]
		[NotifyParentProperty ( true )]
		public string NextText
		{
			get { return this.uiSetting.NextText; }
			set { this.uiSetting.NextText = value; }
		}

		/// <summary>
		/// 获取或设置显示的月数, 默认为 1.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 1 )]
		[Description ( "指示显示的月数, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public int NumberOfMonths
		{
			get { return this.uiSetting.NumberOfMonths; }
			set { this.uiSetting.NumberOfMonths = value; }
		}

		/// <summary>
		/// 获取或设置上一链接的文本, 默认为 "Prev".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "Prev" )]
		[Description ( "指示上一链接的文本, 默认为 Prev" )]
		[NotifyParentProperty ( true )]
		public string PrevText
		{
			get { return this.uiSetting.PrevText; }
			set { this.uiSetting.PrevText = value; }
		}

		/// <summary>
		/// 获取或设置是否可以选择其它的月份, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否可以选择其它的月份, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool SelectOtherMonths
		{
			get { return this.uiSetting.SelectOtherMonths; }
			set { this.uiSetting.SelectOtherMonths = value; }
		}

		/// <summary>
		/// 获取或设置短年份的设置, 默认为 "+10".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "+10" )]
		[Description ( "指示短年份的设置, 默认为 +10" )]
		[NotifyParentProperty ( true )]
		public string ShortYearCutoff
		{
			get { return this.uiSetting.ShortYearCutoff; }
			set { this.uiSetting.ShortYearCutoff = value; }
		}

		/// <summary>
		/// 获取或设置显示日期时的动画, 默认为 "show".
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "show" )]
		[Description ( "指示显示日期时的动画, 默认为 show" )]
		[NotifyParentProperty ( true )]
		public string ShowAnim
		{
			get { return this.uiSetting.ShowAnim; }
			set { this.uiSetting.ShowAnim = value; }
		}

		/// <summary>
		/// 获取或设置是否显示按钮面板, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否显示按钮面板, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowButtonPanel
		{
			get { return this.uiSetting.ShowButtonPanel; }
			set { this.uiSetting.ShowButtonPanel = value; }
		}

		/// <summary>
		/// 获取或设置当前月份的显示位置, 默认为 0.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 0 )]
		[Description ( "指示当前月份的显示位置, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public int ShowCurrentAtPos
		{
			get { return this.uiSetting.ShowCurrentAtPos; }
			set { this.uiSetting.ShowCurrentAtPos = value; }
		}

		/// <summary>
		/// 获取或设置是否在年后显示月份, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否在年后显示月份, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowMonthAfterYear
		{
			get { return this.uiSetting.ShowMonthAfterYear; }
			set { this.uiSetting.ShowMonthAfterYear = value; }
		}

		/// <summary>
		/// 获取或设置日期框显示方式, 可以是 focus, button, both 中的一种, 默认为 focus.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( DatepickerSetting.ShowOnType.focus )]
		[Description ( "指示日期框显示方式, 可以是 focus, button, both 中的一种, 默认为 focus" )]
		[NotifyParentProperty ( true )]
		public DatepickerSetting.ShowOnType ShowOn
		{
			get { return this.uiSetting.ShowOn; }
			set { this.uiSetting.ShowOn = value; }
		}

		/// <summary>
		/// 获取或设置显示选项, 默认为 "{}".
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "{}" )]
		[Description ( "指示显示选项, 默认为 {}" )]
		[NotifyParentProperty ( true )]
		public string ShowOptions
		{
			get { return this.uiSetting.ShowOptions; }
			set { this.uiSetting.ShowOptions = value; }
		}

		/// <summary>
		/// 获取或设置是否显示其它月份, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否显示其它月份, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowOtherMonths
		{
			get { return this.uiSetting.ShowOtherMonths; }
			set { this.uiSetting.ShowOtherMonths = value; }
		}

		/// <summary>
		/// 获取或设置是否显示当前为一年中的第几周, 默认为 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否显示当前为一年中的第几周, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowWeek
		{
			get { return this.uiSetting.ShowWeek; }
			set { this.uiSetting.ShowWeek = value; }
		}

		/// <summary>
		/// 获取或设置每一次跳转的月份数, 默认为 1.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示每一次跳转的月份数, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public int StepMonths
		{
			get { return this.uiSetting.StepMonths; }
			set { this.uiSetting.StepMonths = value; }
		}

		/// <summary>
		/// 获取或设置周的标题设置, 默认为 "Wk".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "Wk" )]
		[Description ( "指示周的标题设置, 默认为 Wk" )]
		[NotifyParentProperty ( true )]
		public string WeekHeader
		{
			get { return this.uiSetting.WeekHeader; }
			set { this.uiSetting.WeekHeader = value; }
		}

		/// <summary>
		/// 获取或设置可选择的年份范围, 默认为 "c-10:c+10".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "c-10:c+10" )]
		[Description ( "指示可选择的年份范围, 默认为 c-10:c+10" )]
		[NotifyParentProperty ( true )]
		public string YearRange
		{
			get { return this.uiSetting.YearRange; }
			set { this.uiSetting.YearRange = value; }
		}

		/// <summary>
		/// 获取或设置跟随在年后的文本, 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示跟随在年后的文本, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string YearSuffix
		{
			get { return this.uiSetting.YearSuffix; }
			set { this.uiSetting.YearSuffix = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置日期框被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置日期框显示时的事件, 类似于: "function(input, inst) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示时的事件, 类似于: function(input, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShow
		{
			get { return this.uiSetting.BeforeShow; }
			set { this.uiSetting.BeforeShow = value; }
		}

		/// <summary>
		/// 获取或设置日期框显示天时的事件, 类似于: "function(date) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示天时的事件, 类似于: function(date) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShowDay
		{
			get { return this.uiSetting.BeforeShowDay; }
			set { this.uiSetting.BeforeShowDay = value; }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: "function(year, month, inst) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示年和月改变时的事件, 类似于: function(year, month, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnChangeMonthYear
		{
			get { return this.uiSetting.OnChangeMonthYear; }
			set { this.uiSetting.OnChangeMonthYear = value; }
		}

		/// <summary>
		/// 获取或设置日期款关闭时的事件, 类似于: "function(dateText, inst) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期款关闭时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnClose
		{
			get { return this.uiSetting.OnClose; }
			set { this.uiSetting.OnClose = value; }
		}

		/// <summary>
		/// 获取或设置日期选择时的事件, 类似于: "function(dateText, inst) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期选择时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnSelect
		{
			get { return this.uiSetting.OnSelect; }
			set { this.uiSetting.OnSelect = value; }
		}
		#endregion

		protected override string facelessPrefix ( )
		{ return "Datepicker"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.CurrentText != "Today" )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.CurrentText );

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.DateFormat );

			return base.facelessPostfix ( ) + postfix;
		}

		protected override void AddAttributesToRender ( HtmlTextWriter writer )
		{
			base.AddAttributesToRender ( writer );

			if ( this.isFace ( ) )
				writer.AddAttribute ( HtmlTextWriterAttribute.Class,
					string.Format (
					"hasDatepicker{0}",
					this.Disabled ? " ui-datepicker-disabled ui-state-disabled" : string.Empty
					)
					);

		}

		protected override void RenderContents ( HtmlTextWriter writer )
		{
			base.RenderContents ( writer );

			if ( this.isFace ( ) )
			{

				string title;

				if ( this.ShowMonthAfterYear )
					title = "{1}&nbsp;{0}";
				else
					title = "{0}&nbsp;{1}";

				string[] dayNames;

				switch ( this.FirstDay )
				{
					case 1:
						dayNames = new string[] { "[Mo]", "[Tu]", "[We]", "[Th]", "[Fr]", "[Sa]", "[Su]" };
						break;

					case 2:
						dayNames = new string[] { "[Tu]", "[We]", "[Th]", "[Fr]", "[Sa]", "[Su]", "[Mo]" };
						break;

					case 3:
						dayNames = new string[] { "[We]", "[Th]", "[Fr]", "[Sa]", "[Su]", "[Mo]", "[Tu]" };
						break;

					case 4:
						dayNames = new string[] { "[Th]", "[Fr]", "[Sa]", "[Su]", "[Mo]", "[Tu]", "[We]" };
						break;

					case 5:
						dayNames = new string[] { "[Fr]", "[Sa]", "[Su]", "[Mo]", "[Tu]", "[We]", "[Th]" };
						break;

					case 6:
						dayNames = new string[] { "[Sa]", "[Su]", "[Mo]", "[Tu]", "[We]", "[Th]", "[Fr]" };
						break;

					case 0:
					default:
						dayNames = new string[] { "[Su]", "[Mo]", "[Tu]", "[We]", "[Th]", "[Fr]", "[Sa]" };
						break;
				}

				string head = string.Format ( "<tr>{7}<th class=\"ui-datepicker-week-end\"><span>{0}</span></th><th><span>{1}</span></th><th><span>{2}</span></th><th><span>{3}</span></th><th><span>{4}</span></th><th><span>{5}</span></th><th class=\"ui-datepicker-week-end\"><span>{6}</span></th></tr>", dayNames[0], dayNames[1], dayNames[2], dayNames[3], dayNames[4], dayNames[5], dayNames[6], this.ShowWeek ? "<th class=\"ui-datepicker-week-col\">" + ( this.WeekHeader == string.Empty ? "[Wk]" : this.WeekHeader ) + "</th>" : string.Empty );

				string table = string.Format (
					"<div style=\"display: block;{4}\" class=\"ui-datepicker-inline ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all\"><div class=\"ui-datepicker-header ui-widget-header ui-helper-clearfix ui-corner-all\"><a class=\"ui-datepicker-prev ui-corner-all\" title=\"Prev\"><span class=\"ui-icon ui-icon-circle-triangle-w\">Prev</span></a><a class=\"ui-datepicker-next ui-corner-all\" title=\"Next\"><span class=\"ui-icon ui-icon-circle-triangle-e\">Next</span></a><div class=\"ui-datepicker-title\">" + title + "</div></div><table class=\"ui-datepicker-calendar\"><thead>" + head + "</thead><tbody><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default ui-state-highlight ui-state-active\">1</a></td><td><a class=\"ui-state-default\">2</a></td><td><a class=\"ui-state-default\">3</a></td><td><a class=\"ui-state-default\">4</a></td><td><a class=\"ui-state-default\">5</a></td><td><a class=\"ui-state-default\">6</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">7</a></td></tr><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">8</a></td><td><a class=\"ui-state-default\">9</a></td><td><a class=\"ui-state-default\">10</a></td><td><a class=\"ui-state-default\">11</a></td><td><a class=\"ui-state-default\">12</a></td><td><a class=\"ui-state-default\">13</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">14</a></td></tr><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">15</a></td><td><a class=\"ui-state-default\">16</a></td><td><a class=\"ui-state-default\">17</a></td><td><a class=\"ui-state-default\">18</a></td><td><a class=\"ui-state-default\">19</a></td><td><a class=\"ui-state-default\">20</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">21</a></td></tr><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">22</a></td><td><a class=\"ui-state-default\">23</a></td><td><a class=\"ui-state-default\">24</a></td><td><a class=\"ui-state-default\">25</a></td><td><a class=\"ui-state-default\">26</a></td><td class=\"ui-datepicker-days-cell-over ui-datepicker-current-day ui-datepicker-today\"><a class=\"ui-state-default\">27</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">28</a></td></tr><tr>{3}<td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">29</a></td><td><a class=\"ui-state-default\">30</a></td><td><a class=\"ui-state-default\">31</a></td><td class=\"ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">{5}</td><td class=\"ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">{6}</td><td class=\"ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">{7}</td><td class=\"ui-datepicker-week-end ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">{8}</td></tr></tbody></table>{2}</div>",
					this.ChangeMonth ? "<select class=\"ui-datepicker-month\" style=\"position: relative; top: 3px; width: 100px;height: 22px;\"><option value=\"xxx\">{xxx}</option></select>" : "<span class=\"ui-datepicker-month\">{xxx}</span>",
					this.ChangeYear ? "<select class=\"ui-datepicker-year\" style=\"position: relative; top: 3px; width: 100px;height: 22px;\"><option value=\"20xx\">{20xx}</option></select>" : "<span class=\"ui-datepicker-year\">{20xx}</span>",
					this.ShowButtonPanel ? "<div class=\"ui-datepicker-buttonpane ui-widget-content\"><button class=\"ui-datepicker-current ui-state-default ui-priority-secondary ui-corner-all\">" + ( this.CurrentText == string.Empty ? "{Txx}" : this.CurrentText ) + "</button></div>" : string.Empty,
					this.ShowWeek ? "<td class=\"ui-datepicker-week-col\">xx</td>" : string.Empty,
					this.ShowWeek ? "width: 330px;" : string.Empty,
					this.ShowOtherMonths ? "<span class=\"ui-state-default\">1</span>" : "&nbsp;",
					this.ShowOtherMonths ? "<span class=\"ui-state-default\">2</span>" : "&nbsp;",
					this.ShowOtherMonths ? "<span class=\"ui-state-default\">3</span>" : "&nbsp;",
					this.ShowOtherMonths ? "<span class=\"ui-state-default\">4</span>" : "&nbsp;"
					);

				writer.Write ( table );
			}

		}

	}

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DatepickerSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DatepickerSetting "
	/// <summary>
	/// 日期框设置.
	/// </summary>
	public sealed class DatepickerSetting
		: WidgetSetting
	{

		#region " Enum "
		/// <summary>
		/// 显示日期框的方式.
		/// </summary>
		public enum ShowOnType
		{
			/// <summary>
			/// 获取焦点.
			/// </summary>
			focus = 0,
			/// <summary>
			/// 点击按钮.
			/// </summary>
			button = 1,
			/// <summary>
			/// 获取焦点或者点击按钮.
			/// </summary>
			both = 2,
		}

		/// <summary>
		/// 动画播放速度.
		/// </summary>
		public enum DurationType
		{
			/// <summary>
			/// 正常的.
			/// </summary>
			normal = 0,
			/// <summary>
			/// 缓慢的.
			/// </summary>
			slow = 1,
			/// <summary>
			/// 迅速的.
			/// </summary>
			fast = 2,
		}
		#endregion

		private DateTime defaultDate = DateTime.Today;
		private DateTime maxDate = DateTime.MaxValue;
		private DateTime minDate = DateTime.MinValue;

		#region " option "
		/// <summary>
		/// 获取或设置日期框是否可用, 默认为 false.
		/// </summary>
		public bool Disabled
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.disabled, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.disabled, value, false ); }
		}

		/// <summary>
		/// 获取或设置备用字段, 是一个选择器, 默认为空字符串.
		/// </summary>
		public string AltField
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.altField, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.altField, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置在备用字段显示的日期格式, 比如: "yy-mm-dd", 默认为空字符串.
		/// </summary>
		public string AltFormat
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.altFormat, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.altFormat, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置显示在日期字段后的文本, 比如: "...", 默认为空字符串.
		/// </summary>
		public string AppendText
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.appendText, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.appendText, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否自动调整输入框的大小, 默认为 false.
		/// </summary>
		public bool AutoSize
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.autoSize, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.autoSize, value, false ); }
		}

		/// <summary>
		/// 获取或设置按钮的图片, 比如: "/images/datepicker.gif", 默认为空字符串.
		/// </summary>
		public string ButtonImage
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.buttonImage, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.buttonImage, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否按钮只显示图片, 默认为 false.
		/// </summary>
		public bool ButtonImageOnly
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.buttonImageOnly, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.buttonImageOnly, value, false ); }
		}

		/// <summary>
		/// 获取或设置按钮的文本, 默认为 "...".
		/// </summary>
		public string ButtonText
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.buttonText, "..." ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.buttonText, value, "..." ); }
		}

		/// <summary>
		/// 获取或设置区域设置, 默认 "$.datepicker.iso8601Week".
		/// </summary>
		public string CalculateWeek
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.calculateWeek, "$.datepicker.iso8601Week" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.calculateWeek, value, "$.datepicker.iso8601Week" ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变月份, 默认为 false.
		/// </summary>
		public bool ChangeMonth
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.changeMonth, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.changeMonth, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变年份, 默认为 false.
		/// </summary>
		public bool ChangeYear
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.changeYear, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.changeYear, value, false ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 默认为 "Done".
		/// </summary>
		public string CloseText
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.closeText, "Done" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.closeText, value, "Done" ); }
		}

		/// <summary>
		/// 获取或设置是否限制输入的格式, 默认为 true.
		/// </summary>
		public bool ConstrainInput
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.constrainInput, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.constrainInput, value, true ); }
		}

		/// <summary>
		/// 获取或设置当天链接的文本, 比如: "Today".
		/// </summary>
		public string CurrentText
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.currentText, "Today" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.currentText, value, "Today" ); }
		}

		/// <summary>
		/// 获取或设置日期的格式, 默认为 "mm/dd/yy".
		/// </summary>
		public string DateFormat
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.dateFormat, "mm/dd/yy" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.dateFormat, value, "mm/dd/yy" ); }
		}

		/// <summary>
		/// 获取或设置天的名称, 默认为 "['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']".
		/// </summary>
		public string DayNames
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.dayNames, "['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.dayNames, value, "['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" ); }
		}

		/// <summary>
		/// 获取或设置天的最短名称, 比如: "['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']".
		/// </summary>
		public string DayNamesMin
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.dayNamesMin, "['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.dayNamesMin, value, "['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" ); }
		}

		/// <summary>
		/// 获取或设置天的短名称, 比如: "['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']".
		/// </summary>
		public string DayNamesShort
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.dayNamesShort, "['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.dayNamesShort, value, "['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']" ); }
		}

		/// <summary>
		/// 获取或设置默认日期, 默认为空字符串.
		/// </summary>
		public DateTime DefaultDate
		{
			get { return this.defaultDate; }
			set
			{
				this.defaultDate = value;

				this.settingHelper.SetOptionValue ( OptionType.defaultDate, string.Format ( "new Date({0}, {1}, {2})", value.Year, value.Month - 1, value.Day ), string.Empty );
			}
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的日期显示速度, 或者使用 slow, normal, fast 中的一种, 默认为 normal.
		/// </summary>
		public DurationType Duration
		{
			get { return this.settingHelper.GetOptionValueToEnum<DurationType> ( OptionType.duration, DurationType.normal ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.duration, value.ToString ( ), DurationType.normal.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置哪一天作为一周的开始, 0 表示周日以此类推, 默认为 0.
		/// </summary>
		public int FirstDay
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.firstDay, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.firstDay, ( value <= 0 || value > 6 ) ? "0" : value.ToString ( ), "0" ); }
		}

		/// <summary>
		/// 获取或设置是否再点击当天链接后跳转到选中日期而不是当天, 默认为 false.
		/// </summary>
		public bool GotoCurrent
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.gotoCurrent, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.gotoCurrent, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否隐藏上一和下一链接, 默认为 false.
		/// </summary>
		public bool HideIfNoPrevNext
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.hideIfNoPrevNext, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.hideIfNoPrevNext, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否使用从右向左, 默认为 false.
		/// </summary>
		public bool IsRTL
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.isRTL, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.isRTL, value, false ); }
		}

		/// <summary>
		/// 获取或设置最大日期.
		/// </summary>
		public DateTime MaxDate
		{
			get { return this.maxDate; }
			set
			{
				this.maxDate = value;

				this.settingHelper.SetOptionValueToDateTime ( OptionType.maxDate, value, DateTime.MaxValue );
			}
		}

		/// <summary>
		/// 获取或设置最大日期.
		/// </summary>
		public DateTime MinDate
		{
			get { return this.minDate; }
			set
			{
				this.minDate = value;

				this.settingHelper.SetOptionValueToDateTime ( OptionType.minDate, value, DateTime.MinValue );
			}
		}

		/// <summary>
		/// 获取或设置月的名称, 默认为 "['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']".
		/// </summary>
		public string MonthNames
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.monthNames, "['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.monthNames, value, "['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" ); }
		}

		/// <summary>
		/// 获取或设置月的短名称, 比如: "['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']".
		/// </summary>
		public string MonthNamesShort
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.monthNamesShort, "['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.monthNamesShort, value, "['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" ); }
		}

		/// <summary>
		/// 获取或设置链接是否使用日期格式, 默认为 false.
		/// </summary>
		public bool NavigationAsDateFormat
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.navigationAsDateFormat, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.navigationAsDateFormat, value, false ); }
		}

		/// <summary>
		/// 获取或设置下一链接的文本, 默认为 "Next".
		/// </summary>
		public string NextText
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.nextText, "Next" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.nextText, value, "Next" ); }
		}

		/// <summary>
		/// 获取或设置显示的月数, 默认为 1.
		/// </summary>
		public int NumberOfMonths
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.numberOfMonths, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.numberOfMonths, ( value <= 0 ) ? "1" : value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置上一链接的文本, 默认为 "Prev".
		/// </summary>
		public string PrevText
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.prevText, "Prev" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.prevText, value, "Prev" ); }
		}

		/// <summary>
		/// 获取或设置是否可以选择其它的月份, 默认为 false.
		/// </summary>
		public bool SelectOtherMonths
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.selectOtherMonths, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.selectOtherMonths, value, false ); }
		}

		/// <summary>
		/// 获取或设置短年份的设置, 默认为 "+10".
		/// </summary>
		public string ShortYearCutoff
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.shortYearCutoff, "+10" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.shortYearCutoff, value, "+10" ); }
		}

		/// <summary>
		/// 获取或设置显示日期时的动画, 默认为 "show".
		/// </summary>
		public string ShowAnim
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.showAnim, "show" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.showAnim, value, "show" ); }
		}

		/// <summary>
		/// 获取或设置是否显示按钮面板, 默认为 false.
		/// </summary>
		public bool ShowButtonPanel
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showButtonPanel, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showButtonPanel, value, false ); }
		}

		/// <summary>
		/// 获取或设置当前月份的显示位置, 默认为 0.
		/// </summary>
		public int ShowCurrentAtPos
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.showCurrentAtPos, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.showCurrentAtPos, ( value <= 0 ) ? "0" : value.ToString ( ), "0" ); }
		}

		/// <summary>
		/// 获取或设置是否在年后显示月份, 默认为 false.
		/// </summary>
		public bool ShowMonthAfterYear
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showMonthAfterYear, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showMonthAfterYear, value, false ); }
		}

		/// <summary>
		/// 获取或设置日期框显示方式, 可以是 focus, button, both 中的一种, 默认为 focus.
		/// </summary>
		public ShowOnType ShowOn
		{
			get { return this.settingHelper.GetOptionValueToEnum<ShowOnType> ( OptionType.showOn, ShowOnType.focus ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.showOn, value.ToString ( ), ShowOnType.focus.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置显示选项, 默认为 "{}".
		/// </summary>
		public string ShowOptions
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.showOptions, "{}" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.showOptions, value, "{}" ); }
		}

		/// <summary>
		/// 获取或设置是否显示其它月份, 默认为 false.
		/// </summary>
		public bool ShowOtherMonths
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showOtherMonths, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showOtherMonths, value, false ); }
		}

		/// <summary>
		/// 获取或设置是否显示当前为一年中的第几周, 默认为 false.
		/// </summary>
		public bool ShowWeek
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.showWeek, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.showWeek, value, false ); }
		}

		/// <summary>
		/// 获取或设置每一次跳转的月份数, 默认为 1.
		/// </summary>
		public int StepMonths
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.stepMonths, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.stepMonths, ( value <= 0 ) ? "1" : value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置周的标题设置, 默认为 "Wk".
		/// </summary>
		public string WeekHeader
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.weekHeader, "Wk" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.weekHeader, value, "Wk" ); }
		}

		/// <summary>
		/// 获取或设置可选择的年份范围, 默认为 "c-10:c+10".
		/// </summary>
		public string YearRange
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.yearRange, "c-10:c+10" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.yearRange, value, "c-10:c+10" ); }
		}

		/// <summary>
		/// 获取或设置跟随在年后的文本, 默认为空字符串.
		/// </summary>
		public string YearSuffix
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.yearSuffix, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.yearSuffix, value, string.Empty ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置日期框被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		public string Create
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.create ); }
			set { this.settingHelper.SetOptionValue ( OptionType.create, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置日期框显示时的事件, 类似于: "function(input, inst) { }".
		/// </summary>
		public string BeforeShow
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.beforeShow ); }
			set { this.settingHelper.SetOptionValue ( OptionType.beforeShow, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置日期框显示天时的事件, 类似于: "function(date) { }".
		/// </summary>
		public string BeforeShowDay
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.beforeShowDay ); }
			set { this.settingHelper.SetOptionValue ( OptionType.beforeShowDay, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: "function(year, month, inst) { }".
		/// </summary>
		public string OnChangeMonthYear
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.onChangeMonthYear ); }
			set { this.settingHelper.SetOptionValue ( OptionType.onChangeMonthYear, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置日期款关闭时的事件, 类似于: "function(dateText, inst) { }".
		/// </summary>
		public string OnClose
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.onClose ); }
			set { this.settingHelper.SetOptionValue ( OptionType.onClose, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置日期选择时的事件, 类似于: "function(dateText, inst) { }".
		/// </summary>
		public string OnSelect
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.onSelect ); }
			set { this.settingHelper.SetOptionValue ( OptionType.onSelect, value, string.Empty ); }
		}
		#endregion

		/// <summary>
		/// 创建一个日期框设置.
		/// </summary>
		public DatepickerSetting ( )
			: base ( WidgetType.datepicker, 0 )
		{ }

	}
	#endregion

}

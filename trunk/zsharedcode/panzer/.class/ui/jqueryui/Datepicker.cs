/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepicker
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerDurationType
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerShowOnType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Datepicker.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 折叠列表插件.
	/// </summary>
	[ToolboxData ( "<{0}:Datepicker runat=server></{0}:Datepicker>" )]
	[DesignerAttribute ( typeof ( DatepickerDesigner ) )]
	public class Datepicker
		: BaseWidget
	{

		#region " Enum "
		/// <summary>
		/// ShowOn 类型.
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
		/// Duration 类型.
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

		private readonly AjaxSettingEdit changeAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 折叠列表.
		/// </summary>
		public Datepicker ( )
			: base ( WidgetType.datepicker )
		{ this.elementType = ElementType.Div; }

		#region " Option "
		/// <summary>
		/// 获取或设置日期框是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示日期框是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.Disabled, false ); }
			set { this.widgetSetting.DatepickerSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置备用字段, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示备用字段, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AltField
		{
			get { return this.widgetSetting.DatepickerSetting.AltField.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.AltField = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置在备用字段显示的日期格式, 比如: yy-mm-dd.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示在备用字段显示的日期格式, 比如: yy-mm-dd" )]
		[NotifyParentProperty ( true )]
		public string AltFormat
		{
			get { return this.widgetSetting.DatepickerSetting.AltFormat.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.AltFormat = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置显示在日期字段后的文本, 比如: ....
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示在日期字段后的文本, 比如: ..." )]
		[NotifyParentProperty ( true )]
		public string AppendText
		{
			get { return this.widgetSetting.DatepickerSetting.AppendText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.AppendText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否自动调整输入框的大小, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否自动调整输入框的大小, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool AutoSize
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.AutoSize, false ); }
			set { this.widgetSetting.DatepickerSetting.AutoSize = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置按钮的图片, 比如: /images/datepicker.gif.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的图片, 比如: /images/datepicker.gif" )]
		[NotifyParentProperty ( true )]
		public string ButtonImage
		{
			get { return this.widgetSetting.DatepickerSetting.ButtonImage.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.ButtonImage = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否按钮只显示图片, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否按钮只显示图片, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ButtonImageOnly
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ButtonImageOnly, false ); }
			set { this.widgetSetting.DatepickerSetting.ButtonImageOnly = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置按钮的文本, 比如: ....
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的文本, 比如: ..." )]
		[NotifyParentProperty ( true )]
		public string ButtonText
		{
			get { return this.widgetSetting.DatepickerSetting.ButtonText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.ButtonText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置区域设置, 默认 $.datepicker.iso8601Week.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示区域设置, 默认 $.datepicker.iso8601Week" )]
		[NotifyParentProperty ( true )]
		public string CalculateWeek
		{
			get { return this.widgetSetting.DatepickerSetting.CalculateWeek; }
			set { this.widgetSetting.DatepickerSetting.CalculateWeek = value; }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否允许使用下拉框改变月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ChangeMonth
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ChangeMonth, false ); }
			set { this.widgetSetting.DatepickerSetting.ChangeMonth = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变年份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否允许使用下拉框改变年份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ChangeYear
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ChangeYear, false ); }
			set { this.widgetSetting.DatepickerSetting.ChangeYear = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 比如: 'X'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭链接的文本, 比如: 'X'" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.widgetSetting.DatepickerSetting.CloseText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.CloseText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否限制输入的格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否限制输入的格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ConstrainInput
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ConstrainInput, true ); }
			set { this.widgetSetting.DatepickerSetting.ConstrainInput = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置当天链接的文本, 比如: '今天'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示当天链接的文本, 比如: '今天'" )]
		[NotifyParentProperty ( true )]
		public string CurrentText
		{
			get { return this.widgetSetting.DatepickerSetting.CurrentText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.CurrentText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置日期的格式, 比如: mm/dd/yy.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期的格式, 比如: mm/dd/yy" )]
		[NotifyParentProperty ( true )]
		public string DateFormat
		{
			get { return this.widgetSetting.DatepickerSetting.DateFormat.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.DateFormat = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" )]
		[NotifyParentProperty ( true )]
		public string DayNames
		{
			get { return this.widgetSetting.DatepickerSetting.DayNames; }
			set { this.widgetSetting.DatepickerSetting.DayNames = value; }
		}

		/// <summary>
		/// 获取或设置天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesMin
		{
			get { return this.widgetSetting.DatepickerSetting.DayNamesMin; }
			set { this.widgetSetting.DatepickerSetting.DayNamesMin = value; }
		}

		/// <summary>
		/// 获取或设置天的短名称, 比如: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesShort
		{
			get { return this.widgetSetting.DatepickerSetting.DayNamesShort; }
			set { this.widgetSetting.DatepickerSetting.DayNamesShort = value; }
		}

		/// <summary>
		/// 获取或设置默认日期, 可以是日期, 数字或者字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示默认日期, 可以是日期, 数字或者字符串" )]
		[NotifyParentProperty ( true )]
		public string DefaultDate
		{
			get { return this.widgetSetting.DatepickerSetting.DefaultDate.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.DefaultDate = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的日期显示速度, 或者使用 slow, normal, fast 中的一种.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( DurationType.normal )]
		[Description ( "指示以毫秒为单位的日期显示速度, 或者使用 slow, normal, fast 中的一种" )]
		[NotifyParentProperty ( true )]
		public DurationType Duration
		{
			get { return this.getEnum<DurationType> ( this.widgetSetting.DatepickerSetting.Duration, DurationType.normal ); }
			set { this.widgetSetting.DatepickerSetting.Duration = value == DurationType.normal ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置哪一天作为一周的开始, 0 表示周日以此类推.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示哪一天作为一周的开始, 0 表示周日以此类推" )]
		[NotifyParentProperty ( true )]
		public int FirstDay
		{
			get { return this.getInteger ( this.widgetSetting.DatepickerSetting.FirstDay, 0 ); }
			set { this.widgetSetting.DatepickerSetting.FirstDay = value <= 0 || value > 6 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool GotoCurrent
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.GotoCurrent, false ); }
			set { this.widgetSetting.DatepickerSetting.GotoCurrent = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否隐藏上一和下一链接, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否隐藏上一和下一链接, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool HideIfNoPrevNext
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.HideIfNoPrevNext, false ); }
			set { this.widgetSetting.DatepickerSetting.HideIfNoPrevNext = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否使用从右向左, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否使用从右向左, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool IsRTL
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.IsRTL, false ); }
			set { this.widgetSetting.DatepickerSetting.IsRTL = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置最大日期, 可以是日期, 数字或者字符串, 比如: +1m +1w, 表示推后一月零一周.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大日期, 可以是日期, 数字或者字符串, 比如: +1m +1w', 表示推后一月零一周" )]
		[NotifyParentProperty ( true )]
		public string MaxDate
		{
			get { return this.widgetSetting.DatepickerSetting.MaxDate.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.MaxDate = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置最大日期, 可以是日期, 数字或者字符串, 比如: +1m +1w, 表示推后一月零一周.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小日期, 可以是日期, 数字或者字符串, 比如: -1m -1w, 表示推前一月零一周" )]
		[NotifyParentProperty ( true )]
		public string MinDate
		{
			get { return this.widgetSetting.DatepickerSetting.MinDate.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.MinDate = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" )]
		[NotifyParentProperty ( true )]
		public string MonthNames
		{
			get { return this.widgetSetting.DatepickerSetting.MonthNames; }
			set { this.widgetSetting.DatepickerSetting.MonthNames = value; }
		}

		/// <summary>
		/// 获取或设置月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" )]
		[NotifyParentProperty ( true )]
		public string MonthNamesShort
		{
			get { return this.widgetSetting.DatepickerSetting.MonthNamesShort; }
			set { this.widgetSetting.DatepickerSetting.MonthNamesShort = value; }
		}

		/// <summary>
		/// 获取或设置链接是否使用日期格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示链接是否使用日期格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool NavigationAsDateFormat
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.NavigationAsDateFormat, false ); }
			set { this.widgetSetting.DatepickerSetting.NavigationAsDateFormat = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置下一链接的文本, 比如: ....
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示下一链接的文本, 比如: ..." )]
		[NotifyParentProperty ( true )]
		public string NextText
		{
			get { return this.widgetSetting.DatepickerSetting.NextText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.NextText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
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
			get { return this.getInteger ( this.widgetSetting.DatepickerSetting.NumberOfMonths, 1 ); }
			set { this.widgetSetting.DatepickerSetting.NumberOfMonths = value <= 1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置上一链接的文本, 比如: ....
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示上一链接的文本, 比如: ..." )]
		[NotifyParentProperty ( true )]
		public string PrevText
		{
			get { return this.widgetSetting.DatepickerSetting.PrevText.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.PrevText = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否可以选择其它的月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否可以选择其它的月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool SelectOtherMonths
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.SelectOtherMonths, false ); }
			set { this.widgetSetting.DatepickerSetting.SelectOtherMonths = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置短年份的设置, 可以是数字或者字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示短年份的设置, 可以是数字或者字符串" )]
		[NotifyParentProperty ( true )]
		public string ShortYearCutoff
		{
			get { return this.widgetSetting.DatepickerSetting.ShortYearCutoff.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.ShortYearCutoff = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置显示日期时的动画, 比如: show.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示日期时的动画, 比如: show" )]
		[NotifyParentProperty ( true )]
		public string ShowAnim
		{
			get { return this.widgetSetting.DatepickerSetting.ShowAnim.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.ShowAnim = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否显示按钮面板, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否显示按钮面板, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowButtonPanel
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ShowButtonPanel, false ); }
			set { this.widgetSetting.DatepickerSetting.ShowButtonPanel = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置当前月份的显示位置.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 0 )]
		[Description ( "指示当前月份的显示位置" )]
		[NotifyParentProperty ( true )]
		public int ShowCurrentAtPos
		{
			get { return this.getInteger ( this.widgetSetting.DatepickerSetting.ShowCurrentAtPos, 0 ); }
			set { this.widgetSetting.DatepickerSetting.ShowCurrentAtPos = value <= 0 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置是否在年后显示月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否在年后显示月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowMonthAfterYear
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ShowMonthAfterYear, false ); }
			set { this.widgetSetting.DatepickerSetting.ShowMonthAfterYear = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置日期框显示方式, 可以是 focus, button, both 中的一种.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( ShowOnType.focus )]
		[Description ( "指示日期框显示方式, 可以是 focus, button, both 中的一种" )]
		[NotifyParentProperty ( true )]
		public ShowOnType ShowOn
		{
			get { return this.getEnum<ShowOnType> ( this.widgetSetting.DatepickerSetting.ShowOn, ShowOnType.focus ); }
			set { this.widgetSetting.DatepickerSetting.ShowOn = value == ShowOnType.focus ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置显示选项, 比如: {direction: 'up' }.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示选项, 比如: {direction: 'up' }" )]
		[NotifyParentProperty ( true )]
		public string ShowOptions
		{
			get { return this.widgetSetting.DatepickerSetting.ShowOptions; }
			set { this.widgetSetting.DatepickerSetting.ShowOptions = value; }
		}

		/// <summary>
		/// 获取或设置是否显示其它月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否显示其它月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowOtherMonths
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ShowOtherMonths, false ); }
			set { this.widgetSetting.DatepickerSetting.ShowOtherMonths = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置是否显示当前为一年中的第几周, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( false )]
		[Description ( "指示是否显示当前为一年中的第几周, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool ShowWeek
		{
			get { return this.getBoolean ( this.widgetSetting.DatepickerSetting.ShowWeek, false ); }
			set { this.widgetSetting.DatepickerSetting.ShowWeek = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置每一次跳转的月份数, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示每一次跳转的月份数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public int StepMonths
		{
			get { return this.getInteger ( this.widgetSetting.DatepickerSetting.StepMonths, 1 ); }
			set { this.widgetSetting.DatepickerSetting.StepMonths = value <= 1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置周的标题设置, 默认: Wk.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示周的标题设置, 默认: Wk" )]
		[NotifyParentProperty ( true )]
		public string WeekHeader
		{
			get { return this.widgetSetting.DatepickerSetting.WeekHeader.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.WeekHeader = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置可选择的年份范围, 默认: c-10:c+10.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示可选择的年份范围, 默认: c-10:c+10" )]
		[NotifyParentProperty ( true )]
		public string YearRange
		{
			get { return this.widgetSetting.DatepickerSetting.YearRange.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.YearRange = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置跟随在年后的文本, 比如: Y.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示跟随在年后的文本, 比如: Y" )]
		[NotifyParentProperty ( true )]
		public string YearSuffix
		{
			get { return this.widgetSetting.DatepickerSetting.YearSuffix.Trim ( '\'' ); }
			set { this.widgetSetting.DatepickerSetting.YearSuffix = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置日期框被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.DatepickerSetting.Create; }
			set { this.widgetSetting.DatepickerSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置日期框显示时的事件, 类似于: function(input, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示时的事件, 类似于: function(input, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShow
		{
			get { return this.widgetSetting.DatepickerSetting.BeforeShow; }
			set { this.widgetSetting.DatepickerSetting.BeforeShow = value; }
		}

		/// <summary>
		/// 获取或设置日期框显示天时的事件, 类似于: function(date) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示天时的事件, 类似于: function(date) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShowDay
		{
			get { return this.widgetSetting.DatepickerSetting.BeforeShowDay; }
			set { this.widgetSetting.DatepickerSetting.BeforeShowDay = value; }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(year, month, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示年和月改变时的事件, 类似于: function(year, month, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnChangeMonthYear
		{
			get { return this.widgetSetting.DatepickerSetting.OnChangeMonthYear; }
			set { this.widgetSetting.DatepickerSetting.OnChangeMonthYear = value; }
		}

		/// <summary>
		/// 获取或设置日期款关闭时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期款关闭时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnClose
		{
			get { return this.widgetSetting.DatepickerSetting.OnClose; }
			set { this.widgetSetting.DatepickerSetting.OnClose = value; }
		}

		/// <summary>
		/// 获取或设置日期选择时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期选择时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnSelect
		{
			get { return this.widgetSetting.DatepickerSetting.OnSelect; }
			set { this.widgetSetting.DatepickerSetting.OnSelect = value; }
		}
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.DatepickerSetting.SetEditHelper ( this.editHelper );
			}
			else if ( this.selector == string.Empty )
				switch ( this.widgetSetting.Type )
				{
					case WidgetType.datepicker:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );

						//<div id=\"Dp\" class=\"hasDatepicker\"></div>
						writer.Write (
							"<{6} id=\"{0}\" class=\"{3}hasDatepicker{2}\" style=\"{4}\" title=\"{5}\">{1}</{6}>",
							this.ClientID,
							"<div style=\"display: block;\" class=\"ui-datepicker-inline ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all\"><div class=\"ui-datepicker-header ui-widget-header ui-helper-clearfix ui-corner-all\"><a class=\"ui-datepicker-prev ui-corner-all\" title=\"Prev\"><span class=\"ui-icon ui-icon-circle-triangle-w\">Prev</span></a><a class=\"ui-datepicker-next ui-corner-all\" title=\"Next\"><span class=\"ui-icon ui-icon-circle-triangle-e\">Next</span></a><div class=\"ui-datepicker-title\"><span class=\"ui-datepicker-month\">xxx</span>&nbsp;<span class=\"ui-datepicker-year\">20xx</span></div></div><table class=\"ui-datepicker-calendar\"><thead><tr><th class=\"ui-datepicker-week-end\"><span title=\"Sunday\">Su</span></th><th><span title=\"Monday\">Mo</span></th><th><span title=\"Tuesday\">Tu</span></th><th><span title=\"Wednesday\">We</span></th><th><span title=\"Thursday\">Th</span></th><th><span title=\"Friday\">Fr</span></th><th class=\"ui-datepicker-week-end\"><span title=\"Saturday\">Sa</span></th></tr></thead><tbody><tr><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default ui-state-highlight ui-state-active\">1</a></td><td><a class=\"ui-state-default\">2</a></td><td><a class=\"ui-state-default\">3</a></td><td><a class=\"ui-state-default\">4</a></td><td><a class=\"ui-state-default\">5</a></td><td><a class=\"ui-state-default\">6</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">7</a></td></tr><tr><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">8</a></td><td><a class=\"ui-state-default\">9</a></td><td><a class=\"ui-state-default\">10</a></td><td><a class=\"ui-state-default\">11</a></td><td><a class=\"ui-state-default\">12</a></td><td><a class=\"ui-state-default\">13</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">14</a></td></tr><tr><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">15</a></td><td><a class=\"ui-state-default\">16</a></td><td><a class=\"ui-state-default\">17</a></td><td><a class=\"ui-state-default\">18</a></td><td><a class=\"ui-state-default\">19</a></td><td><a class=\"ui-state-default\">20</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">21</a></td></tr><tr><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">22</a></td><td><a class=\"ui-state-default\">23</a></td><td><a class=\"ui-state-default\">24</a></td><td><a class=\"ui-state-default\">25</a></td><td><a class=\"ui-state-default\">26</a></td><td class=\"ui-datepicker-days-cell-over ui-datepicker-current-day ui-datepicker-today\"><a class=\"ui-state-default\">27</a></td><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">28</a></td></tr><tr><td class=\"ui-datepicker-week-end\"><a class=\"ui-state-default\">29</a></td><td><a class=\"ui-state-default\">30</a></td><td><a class=\"ui-state-default\">31</a></td><td class=\"ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">&nbsp;</td><td class=\"ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">&nbsp;</td><td class=\"ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">&nbsp;</td><td class=\"ui-datepicker-week-end ui-datepicker-other-month ui-datepicker-unselectable ui-state-disabled\">&nbsp;</td></tr></tbody></table></div>",
							this.Disabled ? " ui-datepicker-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( )
							);
						return;
				}

			base.Render ( writer );
		}

	}

	#region " DatepickerDesigner "
	/// <summary>
	/// 折叠列表设计器.
	/// </summary>
	public class DatepickerDesigner : JQueryElementDesigner
	{

		/// <summary>
		/// 获取行为列表.
		/// </summary>
		public override DesignerActionListCollection ActionLists
		{
			get { return new DesignerActionListCollection ( ); }
		}

	}
	#endregion

}

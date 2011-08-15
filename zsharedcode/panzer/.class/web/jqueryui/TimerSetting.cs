/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/TimerSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " TimerSetting "
	/// <summary>
	/// 自定义时钟设置.
	/// </summary>
	public sealed class TimerSetting
		: PlusinSetting
	{

		#region " plusin code "
		private static string timerPlusinCode =
		"var __installTimer = function ($) {" +
		"$.fn.__timer = function () {" +

		"	if (this.length == 0) { return this; }" +

		"	var tag = this.get(0);" +
		"	var action = 'create';" +

		"	if (typeof (arguments[0]) == 'string') {" +

		"		if (null == tag.__timer) { return this; }" +

		"		if (arguments[0] == 'option') { action = (arguments.length == 2 ? 'get' : 'set'); } else { action = 'method'; }" +

		"	}" +
		"	else { arguments[0] = $.extend({}, $.fn.__timer.defaults, arguments[0]); }" +

		"	switch (action) {" +
		"		case 'get':" +
		"			return tag.__timer[arguments[1]];" +

		"		case 'set':" +
		"			return tag.__timer[arguments[1]] = arguments[2];" +

		"		case 'method':" +

		"			switch (arguments[0]) {" +
		"				case 'start':" +
		"					__start.call(this, tag);" +
		"					break;" +

		"				case 'stop':" +
		"					__stop.call(this, tag);" +
		"					break;" +
		"			}" +

		"			return this;" +

		"		default:" +

		"			if (null != tag.__timer) { __stop(tag); }" +

		"			arguments[0].interval = (null == arguments[0].interval || arguments[0].interval <= 0) ? 1000 : arguments[0].interval;\n" +
		"			tag.__timer = arguments[0];" +
		"			return this;" +
		"	}" +

		"};" +
		"function __start(tag) {" +
		"	__stop(tag);" +

		"	var option = tag.__timer;" +
		"	option.handler = setInterval(function () { if (null != option.tick) { option.tick.call(this); } }, option.interval);" +
		"}" +
		"function __stop(tag) {" +
		"	var option = tag.__timer;" +
		"	if (null != option.handler) { clearInterval(option.handler); }" +
		"}" +
		"$.fn.__timer.defaults = {" +
		"	interval: 1000," +
		"	tick: null" +
		"};" +
		"};" +
		"__installTimer(jQuery);";
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置时钟触发的间隔, 以毫秒为单位, 默认为 1000.
		/// </summary>
		public int Interval
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.interval, 1000 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.interval, ( value <= 0 ) ? "1000" : value.ToString ( ), "1000" ); }
		}

		/// <summary>
		/// 获取或设置时钟触发的事件, 类似于: "function(j) { }".
		/// </summary>
		public string Tick
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.tick ); }
			set { this.settingHelper.SetOptionValue ( OptionType.tick, value, string.Empty ); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置时钟触发时的 Ajax 操作的相关设置.
		/// </summary>
		public AjaxSetting TickAsync
		{
			get { return this.ajaxs[0]; }
			set { this.ajaxs[0] = value; }
		}
		#endregion

		/// <summary>
		/// 创建一个自定义时钟设置.
		/// </summary>
		public TimerSetting ( )
			: base ( PlusinType.timer, 1 )
		{ this.ajaxs[0].EventType = EventType.tick; }

		public override string GetPlusinCode ( )
		{ return timerPlusinCode; }

	}
	#endregion

}

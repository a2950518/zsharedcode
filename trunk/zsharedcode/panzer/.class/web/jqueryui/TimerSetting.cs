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
		"(function(c){function e(a){d(a);var b=a.__timer;b.handler=setInterval(function(){null!=b.tick&&b.tick.call(this,a,{})},b.interval)}function d(a){a=a.__timer;null!=a.handler&&clearInterval(a.handler)}c.fn.__timer=function(){if(this.length==0)return this;var a=this.get(0),b=\"create\";if(typeof arguments[0]==\"string\"){if(null==a.__timer)return this;b=arguments[0]==\"option\"?arguments.length==2?\"get\":\"set\":\"method\"}else arguments[0]=c.extend({},c.fn.__timer.defaults,arguments[0]);switch(b){case \"get\":return a.__timer[arguments[1]];" +
"case \"set\":return a.__timer[arguments[1]]=arguments[2];case \"method\":switch(arguments[0]){case \"start\":e.call(this,a);break;case \"stop\":d.call(this,a)}return this;default:return null!=a.__timer&&d(a),arguments[0].interval=null==arguments[0].interval||arguments[0].interval<=0?1E3:arguments[0].interval,a.__timer=arguments[0],this}};c.fn.__timer.defaults={interval:1E3,tick:null,handler:null}})(jQuery);";
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
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置时钟触发时的事件, 类似于 "function(tag, e) { }".
		/// </summary>
		public string Tick
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.tick ); }
			set { this.settingHelper.SetOptionValue ( OptionType.tick, value, string.Empty ); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置时钟触发时相关的 Ajax 设置, 如果设置有效将覆盖 Tick.
		/// </summary>
		public AjaxSetting TickAsync
		{
			get { return this.ajaxs[0]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.tick;
				this.ajaxs[0] = value;
			}
		}
		#endregion

		/// <summary>
		/// 创建一个自定义时钟设置.
		/// </summary>
		public TimerSetting ( )
			: base ( PlusinType.timer, 1 )
		{ this.TickAsync = this.ajaxs[0]; }

		/// <summary>
		/// 获取自定义时钟插件的安装脚本.
		/// </summary>
		/// <returns>自定义时钟插件的安装脚本.</returns>
		public override string GetPlusinCode ( )
		{ return timerPlusinCode; }

	}
	#endregion

}

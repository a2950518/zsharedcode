/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/TimerSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " TimerSetting "
	/// <summary>
	/// 自定义时钟设置.
	/// </summary>
	public sealed class TimerSetting
		: PlusinSetting
	{

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
		//{ return ""; }
		{ return Resources.timer_min; }

	}
	#endregion

}

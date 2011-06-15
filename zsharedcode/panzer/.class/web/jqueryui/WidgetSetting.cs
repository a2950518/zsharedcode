/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIWidgetSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.Collections.Generic;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " WidgetType "
	/// <summary>
	/// Widget 类型.
	/// </summary>
	public enum WidgetType
	{
		/// <summary>
		/// 没有任何类型.
		/// </summary>
		none = 0,
		/// <summary>
		/// 折叠列表.
		/// </summary>
		accordion = 1,
		/// <summary>
		/// 自动填充.
		/// </summary>
		autocomplete = 2,
		/// <summary>
		/// 按钮.
		/// </summary>
		button = 3,
		/// <summary>
		/// 日期框.
		/// </summary>
		datepicker = 4,
		/// <summary>
		/// 对话框.
		/// </summary>
		dialog = 5,
		/// <summary>
		/// 进度条.
		/// </summary>
		progressbar = 6,
		/// <summary>
		/// 分割条.
		/// </summary>
		slider = 7,
		/// <summary>
		/// 分组标签.
		/// </summary>
		tabs = 8,
		/// <summary>
		/// 空的 Widget.
		/// </summary>
		empty = 9,
	}
	#endregion

	#region " WidgetSetting "
	/// <summary>
	/// jQuery UI Widget 设置.
	/// </summary>
	public sealed class WidgetSetting
	{
		/// <summary>
		/// Widget 相关事件.
		/// </summary>
		public readonly List<Event> Events = new List<Event> ( );
		/// <summary>
		/// Widget 相关设置.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// Widget 类型.
		/// </summary>
		public readonly WidgetType WidgetType;
		/// <summary>
		/// Ajax 相关设置.
		/// </summary>
		public readonly List<AjaxSetting> AjaxSettings = new List<AjaxSetting> ( );

		/// <summary>
		/// 创建 jQuery UI Widget 设置.
		/// </summary>
		/// <param name="widgetEventType">和 Widget 相关的触发事件.</param>
		/// <param name="options">Widget 相关设置.</param>
		/// <param name="events">Widget 相关事件.</param>
		/// <param name="ajaxSettings">Ajax 相关设置.</param>
		public WidgetSetting ( WidgetType widgetEventType, Option[] options, Event[] events, AjaxSetting[] ajaxSettings )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			if ( null != events )
				foreach ( Event @event in events )
					if ( null != @event )
						this.Events.Add ( @event );

			if ( null != ajaxSettings )
				foreach ( AjaxSetting ajaxSetting in ajaxSettings )
					if ( null != ajaxSetting )
						this.AjaxSettings.Add ( ajaxSetting );

			this.WidgetType = widgetEventType;
		}

	}
	#endregion

}

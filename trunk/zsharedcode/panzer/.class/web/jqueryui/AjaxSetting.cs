/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.Collections.Generic;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DataType "
	/// <summary>
	/// Ajax 获取的数据类型.
	/// </summary>
	public enum DataType
	{
		/// <summary>
		/// json 数据.
		/// </summary>
		JSon = 1,
		/// <summary>
		/// 脚本代码.
		/// </summary>
		Script = 2,
		/// <summary>
		/// xml 数据.
		/// </summary>
		Xml = 3,
		/// <summary>
		/// html 代码.
		/// </summary>
		Html = 4,
	}
	#endregion

	#region " AjaxSetting "
	/// <summary>
	/// jQuery UI Ajax 设置.
	/// </summary>
	public sealed class AjaxSetting
	{
		/// <summary>
		/// Ajax 相关事件.
		/// </summary>
		public readonly List<Event> Events = new List<Event> ( );
		/// <summary>
		/// 和 Widget 相关的触发事件.
		/// </summary>
		public readonly EventType WidgetEventType;
		/// <summary>
		/// 请求的地址.
		/// </summary>
		public readonly string Url;
		/// <summary>
		/// 获取的数据类型.
		/// </summary>
		public readonly DataType DataType;
		/// <summary>
		/// 用作传递参数的表单.
		/// </summary>
		public readonly string Form;
		/// <summary>
		/// 用作传递的参数.
		/// </summary>
		public readonly List<Parameter> Parameters = new List<Parameter> ( );
		/// <summary>
		/// 是否为字符串使用单引号.
		/// </summary>
		public readonly bool IsSingleQuote;

		/// <summary>
		/// 创建 jQuery UI Ajax 设置.
		/// </summary>
		/// <param name="widgetEventType">和 Widget 相关的触发事件.</param>
		/// <param name="url">请求的地址, 比如: "''".</param>
		/// <param name="dataType">获取的数据类型.</param>
		/// <param name="form">用作传递参数的表单.</param>
		/// <param name="parameters">用作传递的参数, 如果指定了 form 参数, 则忽略 parameters.</param>
		/// <param name="events">Ajax 相关事件.</param>
		/// <param name="isSingleQuote">是否为字符串使用单引号.</param>
		public AjaxSetting ( EventType widgetEventType, string url, DataType dataType, string form, Parameter[] parameters, Event[] events, bool isSingleQuote )
		{

			if ( string.IsNullOrEmpty ( url ) )
				url = "/";

			if ( string.IsNullOrEmpty ( form ) )
				if ( null != parameters )
					foreach ( Parameter parameter in parameters )
						if ( null != parameter )
							this.Parameters.Add ( parameter );

			if ( null != events )
				foreach ( Event @event in events )
					if ( null != @event )
						this.Events.Add ( @event );

			this.Url = url;
			this.DataType = dataType;
			this.WidgetEventType = widgetEventType;
			this.Form = form;

			this.IsSingleQuote = isSingleQuote;
		}

	}
	#endregion

}

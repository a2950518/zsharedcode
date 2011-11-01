/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " WidgetType "
	/// <summary>
	/// 插件类型.
	/// </summary>
	public enum WidgetType
	{
		/// <summary>
		/// 自定义插件.
		/// </summary>
		custom = 0,
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
	}
	#endregion

	#region " WidgetSetting "
	/// <summary>
	/// 派生所有 jQuery UI 插件设置的基础类.
	/// </summary>
	public abstract class WidgetSetting
		: UISetting
	{
	
		/// <summary>
		/// 重新构造.
		/// </summary>
		public abstract void Recombine();

		/// <summary>
		/// 获取所需的基础脚本.
		/// </summary>
		/// <returns>基础自定义插件类型.</returns>
		public virtual Dictionary<string, string> GetDependentScripts ( )
		{
			Dictionary<string, string> scripts = new Dictionary<string, string> ( );

			scripts.Add ( "panzer", Resources.panzer_min );

			return scripts;
		}

		#region " property "
		private WidgetType widgetType;
		protected readonly AjaxSetting[] ajaxs;

		/// <summary>
		/// 获取或设置插件的类型.
		/// </summary>
		public WidgetType WidgetType
		{
			get { return this.widgetType; }
			set { this.widgetType = value; }
		}

		/// <summary>
		/// 获取 Ajax 设置数组.
		/// </summary>
		public AjaxSetting[] Ajaxs
		{
			get { return this.ajaxs; }
		}
		#endregion

		protected WidgetSetting ( WidgetType widgetType, int ajaxCount )
			: base ( )
		{
			this.widgetType = widgetType;

			this.ajaxs = new AjaxSetting[ajaxCount < 0 ? 0 : ajaxCount];

			for ( int index = 0; index < ajaxCount; index++ )
				this.ajaxs[index] = new AjaxSetting ( );

		}

	}
	#endregion

}

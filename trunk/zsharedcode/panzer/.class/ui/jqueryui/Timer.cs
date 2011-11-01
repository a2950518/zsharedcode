/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Timer.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;
using zoyobar.shared.panzer.web.jqueryui.plusin;

namespace zoyobar.shared.panzer.ui.jqueryui.plusin
{

	/// <summary>
	/// 自定义时钟插件.
	/// </summary>
	[ToolboxData ( "<{0}:Timer runat=server></{0}:Timer>" )]
	public class Timer
		: JQueryPlusin<TimerSetting>
	{

		#region " option "
		/// <summary>
		/// 获取或设置时钟触发的间隔, 以毫秒为单位, 默认为 1000.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1000 )]
		[Description ( "指示时钟触发的间隔, 以毫秒为单位, 默认为 1000" )]
		[NotifyParentProperty ( true )]
		public int Interval
		{
			get { return this.uiSetting.Interval; }
			set { this.uiSetting.Interval = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置时钟触发时的事件, 类似于 "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示时钟触发时的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Tick
		{
			get { return this.uiSetting.Tick; }
			set { this.uiSetting.Tick = value; }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取时钟触发时相关的 Ajax 设置, 如果设置有效将覆盖 Tick.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "触发时相关的 Ajax 设置, 如果设置有效将覆盖 Tick" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting TickAsync
		{
			get { return this.uiSetting.TickAsync; }
		}
		#endregion

		/// <summary>
		/// 创建一个自定义时钟.
		/// </summary>
		public Timer ( )
			: base ( new TimerSetting ( ), HtmlTextWriterTag.Code )
		{ }

		protected override bool isFaceless ( )
		{ return this.DesignMode; }

		protected override bool isFace ( )
		{ return false; }

		protected override string facelessPrefix ( )
		{ return "Timer"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Interval );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

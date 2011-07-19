/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITimer
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Timer.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// JQueryElement 的时钟插件.
	/// </summary>
	[ToolboxData ( "<{0}:Timer runat=server></{0}:Timer>" )]
	[Designer ( typeof ( TimerDesigner ) )]
	public class Timer
		: BaseJQueryElement
	{

		#region " hide "
		/// <summary>
		/// 获取或设置元素的拖动设置.
		/// </summary>
		[Browsable ( false )]
		public override DraggableSettingEdit DraggableSetting
		{
			get { return base.DraggableSetting; }
			set { base.DraggableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的拖放设置.
		/// </summary>
		[Browsable ( false )]
		public override DroppableSettingEdit DroppableSetting
		{
			get { return base.DroppableSetting; }
			set { base.DroppableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的排列设置.
		/// </summary>
		[Browsable ( false )]
		public override SortableSettingEdit SortableSetting
		{
			get { return base.SortableSetting; }
			set { base.SortableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的选中设置.
		/// </summary>
		[Browsable ( false )]
		public override SelectableSettingEdit SelectableSetting
		{
			get { return base.SelectableSetting; }
			set { base.SelectableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的缩放设置.
		/// </summary>
		[Browsable ( false )]
		public override ResizableSettingEdit ResizableSetting
		{
			get { return base.ResizableSetting; }
			set { base.ResizableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的 Widget 设置.
		/// </summary>
		[Browsable ( false )]
		public override WidgetSettingEdit WidgetSetting
		{
			get { return base.WidgetSetting; }
			set { base.WidgetSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的 Repeater 设置.
		/// </summary>
		[Browsable ( false )]
		public override RepeaterSettingEdit RepeaterSetting
		{
			get { return base.RepeaterSetting; }
			set { base.RepeaterSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的 Timer 设置.
		/// </summary>
		[Browsable ( false )]
		public override TimerSettingEdit TimerSetting
		{
			get { return base.TimerSetting; }
			set { base.TimerSetting = value; }
		}
		#endregion

		/// <summary>
		/// 获取或设置时钟触发的间隔, 以毫秒为单位.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 100 )]
		[Description ( "指示时钟触发的间隔, 以毫秒为单位" )]
		[NotifyParentProperty ( true )]
		public int Interval
		{
			get { return this.timerSetting.Interval; }
			set { this.timerSetting.Interval = value; }
		}

		/// <summary>
		/// 获取或设置时钟触发时的事件.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示时钟触发时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Tick
		{
			get { return this.timerSetting.Tick; }
			set { this.timerSetting.Tick = value; }
		}

		/// <summary>
		/// 获取 Tick 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Tick 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSettingEdit TickAjax
		{
			get { return this.timerSetting.TickAsync; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 按钮.
		/// </summary>
		public Timer ( )
			: base ( )
		{ this.elementType = ElementType.None; }

		protected override void Render ( HtmlTextWriter writer )
		{
			this.timerSetting.IsTimable = true;

			base.Render ( writer );
		}

	}

	#region " TimerDesigner "
	/// <summary>
	/// 按钮设计器.
	/// </summary>
	public class TimerDesigner : JQueryElementDesigner
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

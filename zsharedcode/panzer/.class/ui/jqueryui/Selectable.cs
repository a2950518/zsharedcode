/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Selectable.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 完成页面元素选中功能的控件类.
	/// </summary>
	[ToolboxData ( "<{0}:Selectable runat=server></{0}:Selectable>" )]
	public sealed class Selectable
		: JQueryInteraction<SelectableSetting>
	{

		/// <summary>
		/// 创建一个选中功能的控件类.
		/// </summary>
		public Selectable ( )
			: base ( new SelectableSetting ( ), HtmlTextWriterTag.Ul )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置选中是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示选中是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置选中是否自动刷新, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示选中是否自动刷新, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool AutoRefresh
		{
			get { return this.uiSetting.AutoRefresh; }
			set { this.uiSetting.AutoRefresh = value; }
		}

		/// <summary>
		/// 获取或设置不参加选中的元素, 是一个选择器, 默认为 ":input,option".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( ":input,option" )]
		[Description ( "指示不参加选中的元素, 是一个选择器, 默认为 :input,option" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.uiSetting.Cancel; }
			set { this.uiSetting.Cancel = value; }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示鼠标的延迟, 以毫秒计算, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public int Delay
		{
			get { return this.uiSetting.Delay; }
			set { this.uiSetting.Delay = value; }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发选中, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示鼠标移动多少像素触发选中, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public int Distance
		{
			get { return this.uiSetting.Distance; }
			set { this.uiSetting.Distance = value; }
		}

		/// <summary>
		/// 获取或设置参加选中的元素, 是一个选择器, 默认 "*".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "*" )]
		[Description ( "指示参加选中的元素, 是一个选择器, 默认 *" )]
		[NotifyParentProperty ( true )]
		public string Filter
		{
			get { return this.uiSetting.Filter; }
			set { this.uiSetting.Filter = value; }
		}

		/// <summary>
		/// 获取或设置排列中选中的触发方式, 默认为 touch.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( SelectableSetting.ToleranceType.touch )]
		[Description ( "指示排列中选中的触发方式, 默认为 touch" )]
		[NotifyParentProperty ( true )]
		public SelectableSetting.ToleranceType Tolerance
		{
			get { return this.uiSetting.Tolerance; }
			set { this.uiSetting.Tolerance = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置选中被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置选中后的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中后的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Selected
		{
			get { return this.uiSetting.Selected; }
			set { this.uiSetting.Selected = value; }
		}

		/// <summary>
		/// 获取或设置选中时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Selecting
		{
			get { return this.uiSetting.Selecting; }
			set { this.uiSetting.Selecting = value; }
		}

		/// <summary>
		/// 获取或设置选中开始时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.uiSetting.Start; }
			set { this.uiSetting.Start = value; }
		}

		/// <summary>
		/// 获取或设置选中停止时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.uiSetting.Stop; }
			set { this.uiSetting.Stop = value; }
		}

		/// <summary>
		/// 获取或设置取消选中的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示取消选中的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Unselected
		{
			get { return this.uiSetting.Unselected; }
			set { this.uiSetting.Unselected = value; }
		}

		/// <summary>
		/// 获取或设置取消选中时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示取消选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Unselecting
		{
			get { return this.uiSetting.Unselecting; }
			set { this.uiSetting.Unselecting = value; }
		}
		#endregion

		protected override string facelessPrefix ( )
		{ return "Selectable"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Tolerance );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

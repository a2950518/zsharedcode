/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Draggable.cs
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
	/// 完成页面元素拖动功能的控件类.
	/// </summary>
	[ToolboxData ( "<{0}:Draggable runat=server></{0}:Draggable>" )]
	public sealed class Draggable
		: JQueryInteraction<DraggableSetting>
	{

		/// <summary>
		/// 创建一个拖动功能的控件类.
		/// </summary>
		public Draggable ( )
			: base ( new DraggableSetting ( ), HtmlTextWriterTag.Span )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置拖动是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示拖动是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置是否添加样式, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( true )]
		[Description ( "指示是否添加样式, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool AddClasses
		{
			get { return this.uiSetting.AddClasses; }
			set { this.uiSetting.AddClasses = value; }
		}
		/// <summary>
		/// 获取或设置鼠标点击在何处拖动有效, 可以是 "parent", "body" 等, 默认为 "parent".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "parent" )]
		[Description ( "指示鼠标点击在何处拖动有效, 可以是 parent, body 等, 默认为 parent" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.uiSetting.AppendTo; }
			set { this.uiSetting.AppendTo = value; }
		}

		/// <summary>
		/// 获取或设置拖动的方向, 可以是 x, y, 默认为 null.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( DraggableSetting.AxisType.@null )]
		[Description ( "指示拖动的方向, 可以是 x, y, 默认为 null" )]
		[NotifyParentProperty ( true )]
		public DraggableSetting.AxisType Axis
		{
			get { return this.uiSetting.Axis; }
			set { this.uiSetting.Axis = value; }
		}

		/// <summary>
		/// 获取或设置不参加拖动的元素, 是一个选择器, 默认为 ":input,option".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( ":input,option" )]
		[Description ( "指示不参加拖动的元素, 是一个选择器, 默认为 :input,option" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.uiSetting.Cancel; }
			set { this.uiSetting.Cancel = value; }
		}

		/// <summary>
		/// 获取或设置关联的排列, 是一个选择器, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示关联的排列, 是一个选择器, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string ConnectToSortable
		{
			get { return this.uiSetting.ConnectToSortable; }
			set { this.uiSetting.ConnectToSortable = value; }
		}

		/// <summary>
		/// 获取或设置拖动所在的容器, 默认为 null.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( DraggableSetting.ContainmentType.@null )]
		[Description ( "指示拖动所在的容器, 默认为 null" )]
		[NotifyParentProperty ( true )]
		public DraggableSetting.ContainmentType Containment
		{
			get { return this.uiSetting.Containment; }
			set { this.uiSetting.Containment = value; }
		}

		/// <summary>
		/// 获取或设置鼠标样式, 默认为 "auto".
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "auto" )]
		[Description ( "指示鼠标样式, 默认为 auto" )]
		[NotifyParentProperty ( true )]
		public string Cursor
		{
			get { return this.uiSetting.Cursor; }
			set { this.uiSetting.Cursor = value; }
		}

		/// <summary>
		/// 获取或设置鼠标的相对位置, 对应一个 javascript 对象, "{ top: 1, left: 2, right: 3, bottom: 4 }", 需要具有选择其中的一个或者两个属性, 默认为空字符串.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string CursorAt
		{
			get { return this.uiSetting.CursorAt; }
			set { this.uiSetting.CursorAt = value; }
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
		/// 获取或设置鼠标移动多少像素触发拖动, 默认为 1.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示鼠标移动多少像素触发排列, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public int Distance
		{
			get { return this.uiSetting.Distance; }
			set { this.uiSetting.Distance = value; }
		}

		/// <summary>
		/// 获取或设置按照矩阵来移动元素, 为一个数组, 比如: "[10, 30]", 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来移动元素, 为一个数组, 比如: [10, 30], 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.uiSetting.Grid; }
			set { this.uiSetting.Grid = value; }
		}

		/// <summary>
		/// 获取或设置用于点击的元素, 点击后拖动才有效, 对应一个 dom 元素或者选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于点击的元素, 点击后拖动才有效, 对应一个 dom 元素或者选择器" )]
		[NotifyParentProperty ( true )]
		public string Handle
		{
			get { return this.uiSetting.Handle; }
			set { this.uiSetting.Handle = value; }
		}

		/// <summary>
		/// 获取或设置是否使用副本 original 针对元素本身, clone 针对元素的副本, 默认为 original.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( DraggableSetting.HelperType.original )]
		[Description ( "指示是否使用副本 original 针对元素本身, clone 针对元素的副本, 默认为 original" )]
		[NotifyParentProperty ( true )]
		public DraggableSetting.HelperType Helper
		{
			get { return this.uiSetting.Helper; }
			set { this.uiSetting.Helper = value; }
		}

		/// <summary>
		/// 获取或设置是否引发 iframe 中的事件, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否引发 iframe 中的事件, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool IFrameFix
		{
			get { return this.uiSetting.IFrameFix; }
			set { this.uiSetting.IFrameFix = value; }
		}

		/// <summary>
		/// 获取或设置元素拖动时的透明度, 0 到 1 之间, 默认为 1.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 1.0 )]
		[Description ( "指示元素拖动时的透明度, 0 到 1 之间, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public double Opacity
		{
			get { return this.uiSetting.Opacity; }
			set { this.uiSetting.Opacity = value; }
		}

		/// <summary>
		/// 获取或设置是否刷新位置, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否刷新位置, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool RefreshPositions
		{
			get { return this.uiSetting.RefreshPositions; }
			set { this.uiSetting.RefreshPositions = value; }
		}

		/// <summary>
		/// 获取或设置是否在拖动后播放恢复原位的动画, 默认为 false.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( false )]
		[Description ( "指示是否在拖动后播放恢复原位的动画, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Revert
		{
			get { return this.uiSetting.Revert; }
			set { this.uiSetting.Revert = value; }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画播放时间, 默认为 500.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( 500 )]
		[Description ( "指示以毫秒为单位的动画播放时间, 比如: 500" )]
		[NotifyParentProperty ( true )]
		public int RevertDuration
		{
			get { return this.uiSetting.RevertDuration; }
			set { this.uiSetting.RevertDuration = value; }
		}

		/// <summary>
		/// 获取或设置范围, 默认为 "default".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "default" )]
		[Description ( "指示范围, 默认为 default" )]
		[NotifyParentProperty ( true )]
		public string Scope
		{
			get { return this.uiSetting.Scope; }
			set { this.uiSetting.Scope = value; }
		}

		/// <summary>
		/// 获取或设置是否可以显示滚动轴, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否可以显示滚动轴, 比如: true" )]
		[NotifyParentProperty ( true )]
		public bool Scroll
		{
			get { return this.uiSetting.Scroll; }
			set { this.uiSetting.Scroll = value; }
		}

		/// <summary>
		/// 获取或设置滚动轴的灵敏度, 默认为 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 20 )]
		[Description ( "指示滚动轴的灵敏度, 默认为 20" )]
		[NotifyParentProperty ( true )]
		public int ScrollSensitivity
		{
			get { return this.uiSetting.ScrollSensitivity; }
			set { this.uiSetting.ScrollSensitivity = value; }
		}

		/// <summary>
		/// 获取或设置滚动轴的速度, 默认为 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 20 )]
		[Description ( "指示滚动轴的速度, 默认为 20" )]
		[NotifyParentProperty ( true )]
		public int ScrollSpeed
		{
			get { return this.uiSetting.ScrollSpeed; }
			set { this.uiSetting.ScrollSpeed = value; }
		}

		/// <summary>
		/// 获取或设置是否附着, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否附着, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Snap
		{
			get { return this.uiSetting.Snap; }
			set { this.uiSetting.Snap = value; }
		}

		/// <summary>
		/// 获取或设置附着模式, 可以是 inner, outer, 默认为 both.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( DraggableSetting.SnapModeType.both )]
		[Description ( "指示附着模式, 可以是 inner, outer, 默认为 both" )]
		[NotifyParentProperty ( true )]
		public DraggableSetting.SnapModeType SnapMode
		{
			get { return this.uiSetting.SnapMode; }
			set { this.uiSetting.SnapMode = value; }
		}

		/// <summary>
		/// 获取或设置附着发生的距离, 默认为 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 20 )]
		[Description ( "指示附着发生的距离, 默认为 20" )]
		[NotifyParentProperty ( true )]
		public int SnapTolerance
		{
			get { return this.uiSetting.SnapTolerance; }
			set { this.uiSetting.SnapTolerance = value; }
		}

		/// <summary>
		/// 获取或设置控制 z 轴顺序, 对应一个选择器, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示控制 z 轴顺序, 对应一个选择器, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Stack
		{
			get { return this.uiSetting.Stack; }
			set { this.uiSetting.Stack = value; }
		}

		/// <summary>
		/// 获取或设置 Z 轴顺序, 默认 -1 不设置顺序.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( -1 )]
		[Description ( "指示 Z 轴顺序, 默认 -1 不设置顺序" )]
		[NotifyParentProperty ( true )]
		public int ZIndex
		{
			get { return this.uiSetting.ZIndex; }
			set { this.uiSetting.ZIndex = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置拖动被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置拖动开始的时候的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.uiSetting.Start; }
			set { this.uiSetting.Start = value; }
		}

		/// <summary>
		/// 获取或设置拖动完成时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drag
		{
			get { return this.uiSetting.Drag; }
			set { this.uiSetting.Drag = value; }
		}

		/// <summary>
		/// 获取或设置拖动停止的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.uiSetting.Stop; }
			set { this.uiSetting.Stop = value; }
		}
		#endregion

		protected override string facelessPrefix ( )
		{ return "Draggable"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.Axis != DraggableSetting.AxisType.@null )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Axis );

			if ( this.Helper != DraggableSetting.HelperType.original )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Helper );

			if ( this.Snap )
				postfix += string.Format ( " <span style=\"color: #660066\">snap({0},{1})</span>", this.SnapMode, this.SnapTolerance );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

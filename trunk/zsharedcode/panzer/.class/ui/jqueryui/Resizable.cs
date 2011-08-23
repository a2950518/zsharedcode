/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Resizable.cs
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
	/// 完成页面元素缩放功能的控件类.
	/// </summary>
	[ToolboxData ( "<{0}:Resizable runat=server></{0}:Resizable>" )]
	public sealed class Resizable
		: JQueryInteraction<ResizableSetting>
	{

		/// <summary>
		/// 创建一个缩放功能的控件类.
		/// </summary>
		public Resizable ( )
			: base ( new ResizableSetting ( ), HtmlTextWriterTag.Div )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置缩放是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示缩放是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置同时缩放的内容, 对应一个选择器, 默认空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示同时缩放的内容, 对应一个选择器, 默认空字符串" )]
		[NotifyParentProperty ( true )]
		public string AlsoResize
		{
			get { return this.uiSetting.AlsoResize; }
			set { this.uiSetting.AlsoResize = value; }
		}

		/// <summary>
		/// 获取或设置是否播放缩放的动画, 默认为 false.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( false )]
		[Description ( "指示是否播放缩放的动画, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Animate
		{
			get { return this.uiSetting.Animate; }
			set { this.uiSetting.Animate = value; }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画时长, 默认为 slow.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( ResizableSetting.AnimateDurationType.slow )]
		[Description ( "指示以毫秒为单位的动画时长, 默认为 slow" )]
		[NotifyParentProperty ( true )]
		public ResizableSetting.AnimateDurationType AnimateDuration
		{
			get { return this.uiSetting.AnimateDuration; }
			set { this.uiSetting.AnimateDuration = value; }
		}

		/// <summary>
		/// 获取或设置动画效果, 默认为 swing.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "swing" )]
		[Description ( "指示动画效果, 默认为 swing" )]
		[NotifyParentProperty ( true )]
		public string AnimateEasing
		{
			get { return this.uiSetting.AnimateEasing; }
			set { this.uiSetting.AnimateEasing = value; }
		}

		/// <summary>
		/// 获取或设置宽高比例, 比如: 9 / 16, 默认 -1 不设置.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( -1.0 )]
		[Description ( "指示宽高比例, 比如: 9 / 16, 默认 -1 不设置" )]
		[NotifyParentProperty ( true )]
		public double AspectRatio
		{
			get { return this.uiSetting.AspectRatio; }
			set { this.uiSetting.AspectRatio = value; }
		}

		/// <summary>
		/// 获取或设置是否自动隐藏, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否自动隐藏, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool AutoHide
		{
			get { return this.uiSetting.AutoHide; }
			set { this.uiSetting.AutoHide = value; }
		}

		/// <summary>
		/// 获取或设置不参加缩放的元素, 是一个选择器, 默认为 ":input,option".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( ":input,option" )]
		[Description ( "指示不参加缩放的元素, 是一个选择器, 默认为 :input,option" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.uiSetting.Cancel; }
			set { this.uiSetting.Cancel = value; }
		}

		/// <summary>
		/// 获取或设置缩放所在的容器, 默认为 null.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( ResizableSetting.ContainmentType.@null )]
		[Description ( "指示缩放的容器, 默认为 null" )]
		[NotifyParentProperty ( true )]
		public ResizableSetting.ContainmentType Containment
		{
			get { return this.uiSetting.Containment; }
			set { this.uiSetting.Containment = value; }
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
		/// 获取或设置鼠标移动多少像素触发缩放, 默认为 1.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示鼠标移动多少像素触发缩放, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public int Distance
		{
			get { return this.uiSetting.Distance; }
			set { this.uiSetting.Distance = value; }
		}

		/// <summary>
		/// 获取或设置是否在缩放时使用阴影, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否在缩放时使用阴影, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Ghost
		{
			get { return this.uiSetting.Ghost; }
			set { this.uiSetting.Ghost = value; }
		}

		/// <summary>
		/// 获取或设置按照矩阵来缩放, 为一个数组, 比如: "[10, 30]", 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来缩放, 为一个数组, 比如: [10, 30], 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.uiSetting.Grid; }
			set { this.uiSetting.Grid = value; }
		}

		/// <summary>
		/// 获取或设置缩放的方向, 为一个字符串, 默认为 "e, s, se".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "e, s, se" )]
		[Description ( "指示缩放的方向, 为一个字符串, 默认为 e, s, se" )]
		[NotifyParentProperty ( true )]
		public string Handles
		{
			get { return this.uiSetting.Handles; }
			set { this.uiSetting.Handles = value; }
		}

		/// <summary>
		/// 获取或设置 helper 的样式, 默认空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示 helper 的样式, 默认空字符串" )]
		[NotifyParentProperty ( true )]
		public string Helper
		{
			get { return this.uiSetting.Helper; }
			set { this.uiSetting.Helper = value; }
		}

		/// <summary>
		/// 获取或设置缩放的最大高度, 默认 -1 不设置.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( -1 )]
		[Description ( "指示缩放的最大高度, 默认 -1 不设置" )]
		[NotifyParentProperty ( true )]
		public int MaxHeight
		{
			get { return this.uiSetting.MaxHeight; }
			set { this.uiSetting.MaxHeight = value; }
		}

		/// <summary>
		/// 获取或设置缩放的最大宽度, 默认 -1 不设置.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( -1 )]
		[Description ( "指示缩放的最大宽度, 默认 -1 不设置" )]
		[NotifyParentProperty ( true )]
		public int MaxWidth
		{
			get { return this.uiSetting.MaxWidth; }
			set { this.uiSetting.MaxWidth = value; }
		}

		/// <summary>
		/// 获取或设置缩放的最小高度, 默认为 10.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( 10 )]
		[Description ( "指示缩放的最小高度, 默认为 10" )]
		[NotifyParentProperty ( true )]
		public int MinHeight
		{
			get { return this.uiSetting.MinHeight; }
			set { this.uiSetting.MinHeight = value; }
		}

		/// <summary>
		/// 获取或设置缩放的最小宽度, 默认为 10.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( 10 )]
		[Description ( "指示缩放的最小宽度, 默认为 10" )]
		[NotifyParentProperty ( true )]
		public int MinWidth
		{
			get { return this.uiSetting.MinWidth; }
			set { this.uiSetting.MinWidth = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置缩放被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置缩放开始的时候的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.uiSetting.Start; }
			set { this.uiSetting.Start = value; }
		}

		/// <summary>
		/// 获取或设置缩放时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Resize
		{
			get { return this.uiSetting.Resize; }
			set { this.uiSetting.Resize = value; }
		}

		/// <summary>
		/// 获取或设置缩放停止的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.uiSetting.Stop; }
			set { this.uiSetting.Stop = value; }
		}
		#endregion

		protected override string facelessPrefix ( )
		{ return "Resizable"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.Ghost )
				postfix += " <span style=\"color: #660066\">ghost</span>";

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Handles );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

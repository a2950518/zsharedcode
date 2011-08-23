/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Sortable.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 完成页面元素排列功能的控件类.
	/// </summary>
	[ToolboxData ( "<{0}:Sortable runat=server></{0}:Sortable>" )]
	public sealed class Sortable
		: JQueryInteraction<SortableSetting>
	{

		/// <summary>
		/// 创建一个排列功能的控件类.
		/// </summary>
		public Sortable ( )
			: base ( new SortableSetting ( ), HtmlTextWriterTag.Ul )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置排列是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示排列是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置鼠标点击在何处排序有效, 可以是 "parent", "body" 等, 默认为 "parent".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "parent" )]
		[Description ( "指示鼠标点击在何处排序有效, 可以是 parent, body 等, 默认为 parent" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.uiSetting.AppendTo; }
			set { this.uiSetting.AppendTo = value; }
		}

		/// <summary>
		/// 获取或设置排列时拖动的方向, 可以是 x, y, 默认为 null.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( SortableSetting.AxisType.@null )]
		[Description ( "指示排列时拖动的方向, 可以是 x, y, 默认为 null" )]
		[NotifyParentProperty ( true )]
		public SortableSetting.AxisType Axis
		{
			get { return this.uiSetting.Axis; }
			set { this.uiSetting.Axis = value; }
		}

		/// <summary>
		/// 获取或设置不参加排列的元素, 是一个选择器, 默认为 ":input,option".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( ":input,option" )]
		[Description ( "指示不参加排列的元素, 是一个选择器, 默认为 :input,option" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.uiSetting.Cancel; }
			set { this.uiSetting.Cancel = value; }
		}

		/// <summary>
		/// 获取或设置关联的排列, 可以将元素拖放在关联列表中, 是一个选择器, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示关联的排列, 可以将元素拖放在关联列表中, 是一个选择器, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string ConnectWith
		{
			get { return this.uiSetting.ConnectWith; }
			set { this.uiSetting.ConnectWith = value; }
		}

		/// <summary>
		/// 获取或设置排列所在的容器, 默认为 null.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( SortableSetting.ContainmentType.@null )]
		[Description ( "指示排列所在的容器, 默认为 null" )]
		[NotifyParentProperty ( true )]
		public SortableSetting.ContainmentType Containment
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
		/// 获取或设置鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性, 默认为空字符串.
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
		/// 获取或设置鼠标移动多少像素触发排列, 默认为 1.
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
		/// 获取或设置是否可以将条目拖放到空的关联列表中, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否可以将条目拖放到空的关联列表中, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool DropOnEmpty
		{
			get { return this.uiSetting.DropOnEmpty; }
			set { this.uiSetting.DropOnEmpty = value; }
		}

		/// <summary>
		/// 获取或设置是否强制 helper 拥有尺寸, 默认为 false.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( false )]
		[Description ( "指示是否强制 helper 拥有尺寸, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ForceHelperSize
		{
			get { return this.uiSetting.ForceHelperSize; }
			set { this.uiSetting.ForceHelperSize = value; }
		}

		/// <summary>
		/// 获取或设置是否强制 placeholder 拥有尺寸, 默认为 false.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( false )]
		[Description ( "指示是否强制 placeholder 拥有尺寸, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool ForcePlaceholderSize
		{
			get { return this.uiSetting.ForcePlaceholderSize; }
			set { this.uiSetting.ForcePlaceholderSize = value; }
		}

		/// <summary>
		/// 获取或设置按照矩阵来移动元素, 为一个数组, 比如: [10, 30], 默认为空字符串.
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
		/// 获取或设置用于点击的元素, 点击后排列才有效, 对应一个 dom 元素或者选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于点击的元素, 点击后排列才有效, 对应一个 dom 元素或者选择器" )]
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
		[DefaultValue ( SortableSetting.HelperType.original )]
		[Description ( "指示是否使用副本 original 针对元素本身, clone 针对元素的副本, 默认为 original" )]
		[NotifyParentProperty ( true )]
		public SortableSetting.HelperType Helper
		{
			get { return this.uiSetting.Helper; }
			set { this.uiSetting.Helper = value; }
		}

		/// <summary>
		/// 获取或设置参与排列的元素, 对应选择器, 默认为 "> *".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "> *" )]
		[Description ( "指示参与排列的元素, 对应选择器, 默认为  > *" )]
		[NotifyParentProperty ( true )]
		public string Items
		{
			get { return this.uiSetting.Items; }
			set { this.uiSetting.Items = value; }
		}

		/// <summary>
		/// 获取或设置元素排列时的透明度, 0 到 1 之间, 默认为 1.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 1.0 )]
		[Description ( "指示元素排列时的透明度, 0 到 1 之间, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public double Opacity
		{
			get { return this.uiSetting.Opacity; }
			set { this.uiSetting.Opacity = value; }
		}

		/// <summary>
		/// 获取或设置 placeholder 的样式, 默认空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示 placeholder 的样式, 默认空字符串" )]
		[NotifyParentProperty ( true )]
		public string Placeholder
		{
			get { return this.uiSetting.Placeholder; }
			set { this.uiSetting.Placeholder = value; }
		}

		/// <summary>
		/// 获取或设置是否在排列后播放恢复原位的动画, 默认为 false.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( false )]
		[Description ( "指示是否在排列后播放恢复原位的动画, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Revert
		{
			get { return this.uiSetting.Revert; }
			set { this.uiSetting.Revert = value; }
		}

		/// <summary>
		/// 获取或设置是否可以显示滚动轴, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否可以显示滚动轴, 默认为 true" )]
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
		/// 获取或设置排列中拖放的触发方式, 默认 intersect.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( SortableSetting.ToleranceType.intersect )]
		[Description ( "指示排列中拖放的触发方式, 默认 intersect" )]
		[NotifyParentProperty ( true )]
		public SortableSetting.ToleranceType Tolerance
		{
			get { return this.uiSetting.Tolerance; }
			set { this.uiSetting.Tolerance = value; }
		}

		/// <summary>
		/// 获取或设置 Z 轴顺序, 默认 1000.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( 1000 )]
		[Description ( "指示 Z 轴顺序, 默认 1000" )]
		[NotifyParentProperty ( true )]
		public int ZIndex
		{
			get { return this.uiSetting.ZIndex; }
			set { this.uiSetting.ZIndex = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置排列被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置排列开始的时候的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.uiSetting.Start; }
			set { this.uiSetting.Start = value; }
		}

		/// <summary>
		/// 获取或设置排列时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Sort
		{
			get { return this.uiSetting.Sort; }
			set { this.uiSetting.Sort = value; }
		}

		/// <summary>
		/// 获取或设置排列改变的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列改变的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.uiSetting.Change; }
			set { this.uiSetting.Change = value; }
		}

		/// <summary>
		/// 获取或设置排列停止之前的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列停止之前的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeStop
		{
			get { return this.uiSetting.BeforeStop; }
			set { this.uiSetting.BeforeStop = value; }
		}

		/// <summary>
		/// 获取或设置排列停止的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.uiSetting.Stop; }
			set { this.uiSetting.Stop = value; }
		}

		/// <summary>
		/// 获取或设置 dom 元素改变的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 dom 元素改变的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Update
		{
			get { return this.uiSetting.Update; }
			set { this.uiSetting.Update = value; }
		}

		/// <summary>
		/// 获取或设置接收到元素的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示接收到元素的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Receive
		{
			get { return this.uiSetting.Receive; }
			set { this.uiSetting.Receive = value; }
		}

		/// <summary>
		/// 获取或设置元素被移除的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素被移除的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.uiSetting.Remove; }
			set { this.uiSetting.Remove = value; }
		}

		/// <summary>
		/// 获取或设置元素滑过时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑过时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Over
		{
			get { return this.uiSetting.Over; }
			set { this.uiSetting.Over = value; }
		}

		/// <summary>
		/// 获取或设置元素滑出时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑出时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Out
		{
			get { return this.uiSetting.Out; }
			set { this.uiSetting.Out = value; }
		}

		/// <summary>
		/// 获取或设置排列被激活时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列被激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Activate
		{
			get { return this.uiSetting.Activate; }
			set { this.uiSetting.Activate = value; }
		}

		/// <summary>
		/// 获取或设置排列取消激活时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列取消激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Deactivate
		{
			get { return this.uiSetting.Deactivate; }
			set { this.uiSetting.Deactivate = value; }
		}
		#endregion

		protected override string facelessPrefix ( )
		{ return "Sortable"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.Axis != SortableSetting.AxisType.@null )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Axis );

			if ( this.Helper != SortableSetting.HelperType.original )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Helper );

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Tolerance );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

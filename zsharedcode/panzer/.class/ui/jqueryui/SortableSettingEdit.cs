/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISortableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISortableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SortableSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Web.UI;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " SortableSettingEdit "
	/// <summary>
	/// jQuery UI 排列的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( SortableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class SortableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isSortable = false;

		/// <summary>
		/// 获取元素的排列设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的排列设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以排列.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以排列" )]
		[NotifyParentProperty ( true )]
		public bool IsSortable
		{
			get { return this.isSortable; }
			set { this.isSortable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置排列是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标点击在何处排序有效, 可以是 'parent', 'body' 等.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标点击在何处排序有效, 可以是 'parent', 'body' 等" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendTo ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendTo, value ); }
		}

		/// <summary>
		/// 获取或设置排列时拖动的方向, 可以是 'x', 'y'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列时拖动的方向, 可以是 'x', 'y'" )]
		[NotifyParentProperty ( true )]
		public string Axis
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.axis ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.axis, value ); }
		}

		/// <summary>
		/// 获取或设置不参加排列的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加排列的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置关联的排列, 可以将元素拖放在关联列表中, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示关联的排列, 可以将元素拖放在关联列表中, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string ConnectWith
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.connectWith ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.connectWith, value ); }
		}

		/// <summary>
		/// 获取或设置排列所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" )]
		[NotifyParentProperty ( true )]
		public string Containment
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.containment ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.containment, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标样式, 比如: 'auto'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标样式, 比如: 'auto'" )]
		[NotifyParentProperty ( true )]
		public string Cursor
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursor ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursor, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性" )]
		[NotifyParentProperty ( true )]
		public string CursorAt
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursorAt ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursorAt, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的延迟, 以毫秒计算" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发排列, 比如: 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发排列, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以将条目拖放到空的关联列表中, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以将条目拖放到空的关联列表中, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string DropOnEmpty
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dropOnEmpty ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dropOnEmpty, value ); }
		}

		/// <summary>
		/// 获取或设置是否强制 helper 拥有尺寸, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否强制 helper 拥有尺寸, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ForceHelperSize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.forceHelperSize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.forceHelperSize, value ); }
		}

		/// <summary>
		/// 获取或设置是否强制 placeholder 拥有尺寸, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否强制 placeholder 拥有尺寸, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ForcePlaceholderSize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.forcePlaceholderSize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.forcePlaceholderSize, value ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来移动元素, 为一个数组, 比如: [10, 30].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来移动元素, 为一个数组, 比如: [10, 30]" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.grid ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.grid, value ); }
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
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.handle ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.handle, value ); }
		}

		/// <summary>
		/// 获取或设置 helper 的行为, 可以是 'original', 'clone'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 helper 的行为, 可以是 'original', 'clone'" )]
		[NotifyParentProperty ( true )]
		public string Helper
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.helper ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.helper, value ); }
		}

		/// <summary>
		/// 获取或设置参与排列的元素, 对应选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示参与排列的元素, 对应选择器" )]
		[NotifyParentProperty ( true )]
		public string Items
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.items ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.items, value ); }
		}

		/// <summary>
		/// 获取或设置元素排列时的透明度, 0 到 1 之间.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素排列时的透明度, 0 到 1 之间" )]
		[NotifyParentProperty ( true )]
		public string Opacity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.opacity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.opacity, value ); }
		}

		/// <summary>
		/// 获取或设置 placeholder 的样式, 比如: 'ui-state-highlight'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示 placeholder 的样式, 比如: 'ui-state-highlight'" )]
		[NotifyParentProperty ( true )]
		public string Placeholder
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.placeholder ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.placeholder, value ); }
		}

		/// <summary>
		/// 获取或设置是否在排列后播放恢复原位的动画, 比如: true, 或者是以毫秒为单位的动画播放时间, 比如: 500.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在排列后播放恢复原位的动画, 比如: true, 或者是以毫秒为单位的动画播放时间, 比如: 500" )]
		[NotifyParentProperty ( true )]
		public string Revert
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.revert ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.revert, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以显示滚动轴.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以显示滚动轴, 比如: true" )]
		[NotifyParentProperty ( true )]
		public string Scroll
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scroll ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scroll, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的灵敏度, 比如: 40.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的灵敏度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSensitivity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSensitivity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSensitivity, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的速度, 比如: 40.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的速度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSpeed
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSpeed ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSpeed, value ); }
		}

		/// <summary>
		/// 获取或设置排列中拖放的触发方式, 可以是 'intersect' 或者 'pointer'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列中拖放的触发方式, 可以是 'intersect' 或者 'pointer'" )]
		[NotifyParentProperty ( true )]
		public string Tolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tolerance, value ); }
		}

		/// <summary>
		/// 获取或设置 Z 轴顺序, 比如: 5.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示 Z 轴顺序, 比如: 5" )]
		[NotifyParentProperty ( true )]
		public string ZIndex
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.zIndex ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.zIndex, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置排列被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置排列开始的时候的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置排列时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Sort
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.sort ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.sort, value ); }
		}

		/// <summary>
		/// 获取或设置排列改变的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列改变的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置排列停止之前的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列停止之前的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeStop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeStop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeStop, value ); }
		}

		/// <summary>
		/// 获取或设置排列停止的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}

		/// <summary>
		/// 获取或设置 dom 元素改变的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 dom 元素改变的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Update
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.update ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.update, value ); }
		}

		/// <summary>
		/// 获取或设置接收到元素的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示接收到元素的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Receive
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.receive ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.receive, value ); }
		}

		/// <summary>
		/// 获取或设置元素被移除的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素被移除的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.remove ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.remove, value ); }
		}

		/// <summary>
		/// 获取或设置元素滑过时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑过时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Over
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.over ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.over, value ); }
		}

		/// <summary>
		/// 获取或设置元素滑出时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑出时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Out
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@out ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@out, value ); }
		}

		/// <summary>
		/// 获取或设置排列被激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列被激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Activate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.activate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.activate, value ); }
		}

		/// <summary>
		/// 获取或设置排列取消激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列取消激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Deactivate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.deactivate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.deactivate, value ); }
		}
		#endregion

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 排列的相关设置.
		/// </summary>
		/// <returns>jQuery UI 排列的相关设置.</returns>
		public SortableSetting CreateSortableSetting ( )
		{ return new SortableSetting ( this.isSortable, this.editHelper.CreateOptions ( ) ); }

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.isSortable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isSortable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " SortableSettingEditConverter "
	/// <summary>
	/// jQuery UI 排列设置编辑器的转换器.
	/// </summary>
	public sealed class SortableSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			SortableSettingEdit edit = new SortableSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsSortable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SortableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SortableSettingEdit setting = value as SortableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsSortable, setting.EditHelper );
		}

	}
	#endregion

}

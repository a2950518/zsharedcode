/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDraggableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDraggableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DraggableSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
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

	#region " DraggableSettingEdit "
	/// <summary>
	/// jQuery UI 拖动的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DraggableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DraggableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isDraggable = false;

		/// <summary>
		/// 获取元素的拖动设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的拖动设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以拖动.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以拖动" )]
		[NotifyParentProperty ( true )]
		public bool IsDraggable
		{
			get { return this.isDraggable; }
			set { this.isDraggable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置拖动是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置是否添加样式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否添加样式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AddClasses
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.addClasses ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.addClasses, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标点击在何处拖动有效, 可以是 'parent', 'body' 等.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标点击在何处拖动有效, 可以是 'parent', 'body' 等" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendTo ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendTo, value ); }
		}

		/// <summary>
		/// 获取或设置拖动的方向, 可以是 'x', 'y'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动的方向, 可以是 'x', 'y'" )]
		[NotifyParentProperty ( true )]
		public string Axis
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.axis ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.axis, value ); }
		}

		/// <summary>
		/// 获取或设置不参加拖动的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加拖动的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置关联的排列, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示关联的排列, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string ConnectToSortable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.connectToSortable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.connectToSortable, value ); }
		}

		/// <summary>
		/// 获取或设置拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" )]
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
		/// 获取或设置鼠标移动多少像素触发拖动, 比如: 20.
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
		/// 获取或设置用于点击的元素, 点击后拖动才有效, 对应一个 dom 元素或者选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于点击的元素, 点击后拖动才有效, 对应一个 dom 元素或者选择器" )]
		[NotifyParentProperty ( true )]
		public string Handle
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.handle ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.handle, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用副本 'original' 针对元素本身, 'clone' 针对元素的副本.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用副本 'original' 针对元素本身, 'clone' 针对元素的副本" )]
		[NotifyParentProperty ( true )]
		public string Helper
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.helper ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.helper, value ); }
		}

		/// <summary>
		/// 获取或设置是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器..
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器" )]
		[NotifyParentProperty ( true )]
		public string IFrameFix
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.iframeFix ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.iframeFix, value ); }
		}

		/// <summary>
		/// 获取或设置元素拖动时的透明度, 0 到 1 之间.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素拖动时的透明度, 0 到 1 之间" )]
		[NotifyParentProperty ( true )]
		public string Opacity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.opacity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.opacity, value ); }
		}

		/// <summary>
		/// 获取或设置是否刷新位置, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否刷新位置, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string RefreshPositions
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.refreshPositions ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.refreshPositions, value ); }
		}

		/// <summary>
		/// 获取或设置是否在拖动后播放恢复原位的动画, 比如: true, 或者是 'valid', 'invalid'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在拖动后播放恢复原位的动画, 比如: true, 或者是 'valid', 'invalid'" )]
		[NotifyParentProperty ( true )]
		public string Revert
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.revert ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.revert, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画播放时间, 比如: 500.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的动画播放时间, 比如: 500" )]
		[NotifyParentProperty ( true )]
		public string RevertDuration
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.revertDuration ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.revertDuration, value ); }
		}

		/// <summary>
		/// 获取或设置范围, 比如: 'default'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示范围, 比如: 'default'" )]
		[NotifyParentProperty ( true )]
		public string Scope
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scope ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scope, value ); }
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
		/// 获取或设置是否附着, 比如: true, 或者附着的目标元素的选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否附着, 比如: true, 或者附着的目标元素的选择器" )]
		[NotifyParentProperty ( true )]
		public string Snap
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.snap ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.snap, value ); }
		}

		/// <summary>
		/// 获取或设置附着模式, 可以是 'inner', 'outer', 'both'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示附着模式, 可以是 'inner', 'outer', 'both'" )]
		[NotifyParentProperty ( true )]
		public string SnapMode
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.snapMode ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.snapMode, value ); }
		}

		/// <summary>
		/// 获取或设置附着发生的距离, 比如: 100.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示附着发生的距离, 比如: 100" )]
		[NotifyParentProperty ( true )]
		public string SnapTolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.snapTolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.snapTolerance, value ); }
		}

		/// <summary>
		/// 获取或设置控制 z 轴顺序, 对应一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示控制 z 轴顺序, 对应一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Stack
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stack ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stack, value ); }
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
		/// 获取或设置拖动被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置拖动开始的时候的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置拖动完成时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drag
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.drag ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.drag, value ); }
		}

		/// <summary>
		/// 获取或设置拖动停止的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
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
		/// 创建一个 jQuery UI 拖动的相关设置.
		/// </summary>
		/// <returns>jQuery UI 拖动的相关设置.</returns>
		public DraggableSetting CreateDraggableSetting ( )
		{ return new DraggableSetting ( this.isDraggable, this.editHelper.CreateOptions ( ) ); }

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
				this.isDraggable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isDraggable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DraggableSettingEditConverter "
	/// <summary>
	/// jQuery UI 拖动设置编辑器的转换器.
	/// </summary>
	public sealed class DraggableSettingEditConverter : ExpandableObjectConverter
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
			DraggableSettingEdit edit = new DraggableSettingEdit ( );

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
					edit.IsDraggable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DraggableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DraggableSettingEdit setting = value as DraggableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsDraggable, setting.EditHelper );
		}

	}
	#endregion

}

/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ResizableSettingEdit.cs
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

	#region " ResizableSettingEdit "
	/// <summary>
	/// jQuery UI 缩放的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( ResizableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ResizableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isResizable = false;

		/// <summary>
		/// 获取元素的缩放设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的缩放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以缩放.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以缩放" )]
		[NotifyParentProperty ( true )]
		public bool IsResizable
		{
			get { return this.isResizable; }
			set { this.isResizable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置缩放是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置同时缩放的内容, 对应一个 dom 元素, 选择器或者 jQuery.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示同时缩放的内容, 对应一个 dom 元素, 选择器或者 jQuery" )]
		[NotifyParentProperty ( true )]
		public string AlsoResize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.alsoResize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.alsoResize, value ); }
		}

		/// <summary>
		/// 获取或设置是否播放缩放的动画, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否播放缩放的动画, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Animate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animate, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画时长, 比如: 1000.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的动画时长, 比如: 1000" )]
		[NotifyParentProperty ( true )]
		public string AnimateDuration
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animateDuration ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animateDuration, value ); }
		}

		/// <summary>
		/// 获取或设置动画效果, 比如: 'swing'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示动画效果, 比如: 'swing'" )]
		[NotifyParentProperty ( true )]
		public string AnimateEasing
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animateEasing ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animateEasing, value ); }
		}

		/// <summary>
		/// 获取或设置宽高比例, 比如: 9 / 16, 或者 true, false.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示宽高比例, 比如: 9 / 16, 或者 true, false" )]
		[NotifyParentProperty ( true )]
		public string AspectRatio
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.aspectRatio ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.aspectRatio, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动隐藏, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动隐藏, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoHide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoHide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoHide, value ); }
		}

		/// <summary>
		/// 获取或设置不参加缩放的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加缩放的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置缩放所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string Containment
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.containment ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.containment, value ); }
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
		/// 获取或设置鼠标移动多少像素触发缩放, 比如: 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发缩放, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置是否在缩放时使用阴影, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在缩放时使用阴影, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Ghost
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.ghost ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.ghost, value ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来缩放, 为一个数组, 比如: [10, 30].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来缩放, 为一个数组, 比如: [10, 30]" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.grid ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.grid, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的方向, 为一个字符串, 比如: 'n, e, s, w', 可以从 'n, e, s, w, ne, se, sw, nw, all' 中取值.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的方向, 为一个字符串, 比如: 'n, e, s, w', 可以从 'n, e, s, w, ne, se, sw, nw, all' 中取值" )]
		[NotifyParentProperty ( true )]
		public string Handles
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.handles ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.handles, value ); }
		}

		/// <summary>
		/// 获取或设置 helper 的样式, 比如: 'ui-state-highlight'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示 helper 的样式, 比如: 'ui-state-highlight'" )]
		[NotifyParentProperty ( true )]
		public string Helper
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.helper ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.helper, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最大高度, 比如: 200.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最大高度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MaxHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxHeight, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最大宽度, 比如: 200.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最大宽度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MaxWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxWidth, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最小高度, 比如: 200.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最小高度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MinHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minHeight, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最小宽度, 比如: 200.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最小宽度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MinWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minWidth, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置缩放被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置缩放开始的时候的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置缩放时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Resize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resize, value ); }
		}

		/// <summary>
		/// 获取或设置缩放停止的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放停止的事件, 类似于: function(event, ui) { }" )]
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
		/// 创建一个 jQuery UI 缩放的相关设置.
		/// </summary>
		/// <returns>jQuery UI 缩放的相关设置.</returns>
		public ResizableSetting CreateResizableSetting ( )
		{ return new ResizableSetting ( this.isResizable, this.editHelper.CreateOptions ( ) ); }

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
				this.isResizable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isResizable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ResizableSettingEditConverter "
	/// <summary>
	/// jQuery UI 缩放设置编辑器的转换器.
	/// </summary>
	public sealed class ResizableSettingEditConverter : ExpandableObjectConverter
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
			ResizableSettingEdit edit = new ResizableSettingEdit ( );

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
					edit.IsResizable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ResizableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ResizableSettingEdit setting = value as ResizableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsResizable, setting.EditHelper );
		}

	}
	#endregion

}

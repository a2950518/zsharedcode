/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISelectableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISelectableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SelectableSettingEdit.cs
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

	#region " SelectableSettingEdit "
	/// <summary>
	/// jQuery UI 选中的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( SelectableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class SelectableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isSelectable = false;

		/// <summary>
		/// 获取元素的选中设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的选中设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以选中.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以选中" )]
		[NotifyParentProperty ( true )]
		public bool IsSelectable
		{
			get { return this.isSelectable; }
			set { this.isSelectable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置选中是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置选中是否自动刷新, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中是否自动刷新, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoRefresh
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoRefresh ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoRefresh, value ); }
		}

		/// <summary>
		/// 获取或设置不参加选中的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加选中的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
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
		/// 获取或设置鼠标移动多少像素触发选中, 比如: 20.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发选中, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置参加选中的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示参加选中的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Filter
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.filter ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.filter, value ); }
		}

		/// <summary>
		/// 获取或设置排列中选中的触发方式, 可以是 'touch' 或者 'fit'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列中选中的触发方式, 可以是 'touch' 或者 'fit'" )]
		[NotifyParentProperty ( true )]
		public string Tolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tolerance, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置选中被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置选中后的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中后的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Selected 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selected ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selected, value ); }
		}

		/// <summary>
		/// 获取或设置选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Selecting 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selecting ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selecting, value ); }
		}

		/// <summary>
		/// 获取或设置选中开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置选中停止时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}

		/// <summary>
		/// 获取或设置取消选中的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示取消选中的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Unselected 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.unselected ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.unselected, value ); }
		}

		/// <summary>
		/// 获取或设置取消选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示取消选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Unselecting 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.unselecting ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.unselecting, value ); }
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
		/// 创建一个 jQuery UI 选中的相关设置.
		/// </summary>
		/// <returns>jQuery UI 选中的相关设置.</returns>
		public SelectableSetting CreateSelectableSetting ( )
		{ return new SelectableSetting ( this.isSelectable, this.editHelper.CreateOptions ( ) ); }

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
				this.isSelectable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isSelectable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " SelectableSettingEditConverter "
	/// <summary>
	/// jQuery UI 选中设置编辑器的转换器.
	/// </summary>
	public sealed class SelectableSettingEditConverter : ExpandableObjectConverter
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
			SelectableSettingEdit edit = new SelectableSettingEdit ( );

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
					edit.IsSelectable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SelectableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SelectableSettingEdit setting = value as SelectableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsSelectable, setting.EditHelper );
		}

	}
	#endregion

}

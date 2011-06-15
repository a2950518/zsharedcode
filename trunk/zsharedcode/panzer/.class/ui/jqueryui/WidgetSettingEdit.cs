/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIWidgetSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIWidgetSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAccordionSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAccordionSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAutocompleteSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAutocompleteSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIButtonSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIButtonSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDialogSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDialogSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIProgressbarSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIProgressbarSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISliderSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISliderSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITabsSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITabsSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEmptySettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEmptySettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/WidgetSettingEdit.cs
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

	#region " WidgetSettingEdit "
	/// <summary>
	/// jQuery UI Widget 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( WidgetSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class WidgetSettingEdit
		: IStateManager
	{
		private readonly List<AjaxSettingEdit> ajaxSettings = new List<AjaxSettingEdit> ( );
		private WidgetType type = WidgetType.empty;

		private readonly AccordionSettingEdit accordionSetting = new AccordionSettingEdit ( );
		private readonly AutocompleteSettingEdit autocompleteSetting = new AutocompleteSettingEdit ( );
		private readonly ButtonSettingEdit buttonSetting = new ButtonSettingEdit ( );
		private readonly DatepickerSettingEdit datepickerSetting = new DatepickerSettingEdit ( );
		private readonly DialogSettingEdit dialogSetting = new DialogSettingEdit ( );
		private readonly ProgressbarSettingEdit progressbarSetting = new ProgressbarSettingEdit ( );
		private readonly SliderSettingEdit sliderSetting = new SliderSettingEdit ( );
		private readonly TabsSettingEdit tabsSetting = new TabsSettingEdit ( );
		private readonly EmptySettingEdit emptySetting = new EmptySettingEdit ( );

		/// <summary>
		/// 获取元素的 Widget 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( AjaxSettingEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<AjaxSettingEdit> AjaxSettings
		{
			get { return this.ajaxSettings; }
		}

		/// <summary>
		/// 获取或设置 Widget 类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( WidgetType.empty )]
		[Description ( "指示 Widget 类型" )]
		[NotifyParentProperty ( true )]
		public WidgetType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取元素的折叠列表设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的折叠列表设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AccordionSettingEdit AccordionSetting
		{
			get { return this.accordionSetting; }
		}

		/// <summary>
		/// 获取元素的自动填充设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的自动填充设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AutocompleteSettingEdit AutocompleteSetting
		{
			get { return this.autocompleteSetting; }
		}

		/// <summary>
		/// 获取元素的 Button 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的 Button 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public ButtonSettingEdit ButtonSetting
		{
			get { return this.buttonSetting; }
		}

		/// <summary>
		/// 获取元素的日期框设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的日期框设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public DatepickerSettingEdit DatepickerSetting
		{
			get { return this.datepickerSetting; }
		}

		/// <summary>
		/// 获取元素的对话框设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的对话框设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public DialogSettingEdit DialogSetting
		{
			get { return this.dialogSetting; }
		}

		/// <summary>
		/// 获取元素的进度条设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的进度条设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public ProgressbarSettingEdit ProgressbarSetting
		{
			get { return this.progressbarSetting; }
		}

		/// <summary>
		/// 获取元素的分割条设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的分割条设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public SliderSettingEdit SliderSetting
		{
			get { return this.sliderSetting; }
		}

		/// <summary>
		/// 获取元素的分组标签设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的分组标签设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public TabsSettingEdit TabsSetting
		{
			get { return this.tabsSetting; }
		}

		/// <summary>
		/// 获取元素的空设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的空设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public EmptySettingEdit EmptySetting
		{
			get { return this.emptySetting; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 排列的相关设置.
		/// </summary>
		/// <returns>jQuery UI 排列的相关设置.</returns>
		public WidgetSetting CreateWidgetSetting ( )
		{
			List<AjaxSetting> ajaxSettings = new List<AjaxSetting> ( );

			foreach ( AjaxSettingEdit edit in this.ajaxSettings )
				ajaxSettings.Add ( edit.CreateAjaxSetting ( ) );

			SettingEditHelper editHelper;

			switch ( this.type )
			{
				case WidgetType.accordion:
					editHelper = this.accordionSetting.EditHelper;
					break;

				case WidgetType.autocomplete:
					editHelper = this.autocompleteSetting.EditHelper;
					break;

				case WidgetType.button:
					editHelper = this.buttonSetting.EditHelper;
					break;

				case WidgetType.datepicker:
					editHelper = this.datepickerSetting.EditHelper;
					break;

				case WidgetType.dialog:
					editHelper = this.dialogSetting.EditHelper;
					break;

				case WidgetType.progressbar:
					editHelper = this.progressbarSetting.EditHelper;
					break;

				case WidgetType.slider:
					editHelper = this.sliderSetting.EditHelper;
					break;

				case WidgetType.tabs:
					editHelper = this.tabsSetting.EditHelper;
					break;

				case WidgetType.empty:
				default:
					editHelper = this.emptySetting.EditHelper;
					break;
			}

			return new WidgetSetting ( this.type, editHelper.CreateOptions ( ), editHelper.CreateEvents ( ), ajaxSettings.ToArray ( ) );
		}

		/// <summary>
		/// 转化为等效的字符串. (用于在程序集内容使用)
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
				this.type = ( WidgetType ) states[0];

			if ( states.Count >= 2 )
			{
				/*
				List<object> ajaxSettingStates = states[1] as List<object>;

				for ( int index = 0; index < ajaxSettingStates.Count; index++ )
					( this.ajaxSettings[index] as IStateManager ).LoadViewState ( ajaxSettingStates[index] );
				*/
			}

			if ( states.Count >= 3 )
				( this.buttonSetting as IStateManager ).LoadViewState ( states[2] );

			if ( states.Count >= 4 )
				( this.accordionSetting as IStateManager ).LoadViewState ( states[3] );

			if ( states.Count >= 5 )
				( this.autocompleteSetting as IStateManager ).LoadViewState ( states[4] );

			if ( states.Count >= 6 )
				( this.datepickerSetting as IStateManager ).LoadViewState ( states[5] );

			if ( states.Count >= 7 )
				( this.dialogSetting as IStateManager ).LoadViewState ( states[6] );

			if ( states.Count >= 8 )
				( this.progressbarSetting as IStateManager ).LoadViewState ( states[7] );

			if ( states.Count >= 9 )
				( this.sliderSetting as IStateManager ).LoadViewState ( states[8] );

			if ( states.Count >= 10 )
				( this.tabsSetting as IStateManager ).LoadViewState ( states[9] );

			if ( states.Count >= 11 )
				( this.emptySetting as IStateManager ).LoadViewState ( states[10] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.type );

			List<object> ajaxSettingStates = new List<object> ( );

			foreach ( AjaxSettingEdit edit in this.ajaxSettings )
				ajaxSettingStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( /*ajaxSettingStates*/ null );

			states.Add ( ( this.buttonSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.accordionSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.autocompleteSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.datepickerSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.dialogSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.progressbarSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.sliderSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.tabsSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.emptySetting as IStateManager ).SaveViewState ( ) );
			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " WidgetSettingEditConverter "
	/// <summary>
	/// jQuery UI Widget 设置编辑器的转换器.
	/// </summary>
	public sealed class WidgetSettingEditConverter : ExpandableObjectConverter
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
			WidgetSettingEdit edit = new WidgetSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				try
				{ edit.Type = ( WidgetType ) Enum.Parse ( typeof ( WidgetType ), expressionHelper[0].Value, true ); }
				catch
				{ }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is WidgetSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			WidgetSettingEdit setting = value as WidgetSettingEdit;

			return string.Format ( "{0}`;", setting.Type );
		}

	}
	#endregion

	#region " ButtonSettingEdit "
	/// <summary>
	/// jQuery UI Button 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( ButtonSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ButtonSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的 Button 设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "Button 相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的 Button 事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "Button 相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置按钮是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置按钮是否显示文本, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮是否显示文本, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Text
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.text ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.text, value ); }
		}

		/// <summary>
		/// 获取或设置按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }" )]
		[NotifyParentProperty ( true )]
		public string Icons
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.icons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.icons, value ); }
		}

		/// <summary>
		/// 获取或设置按钮显示的文本, 比如: 'ok'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的文本, 比如: 'ok'" )]
		[NotifyParentProperty ( true )]
		public string Label
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.label ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.label, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置按钮被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
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
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ButtonSettingEditConverter "
	/// <summary>
	/// jQuery UI Button 设置编辑器的转换器.
	/// </summary>
	public sealed class ButtonSettingEditConverter : ExpandableObjectConverter
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
			ButtonSettingEdit edit = new ButtonSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ButtonSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ButtonSettingEdit setting = value as ButtonSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " AccordionSettingEdit "
	/// <summary>
	/// jQuery UI 折叠列表的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( AccordionSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class AccordionSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的折叠列表设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "Button 相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的折叠列表事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "Button 相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置折叠列表是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示折叠列表是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置被激活的列表, 对应一个选择器, 元素, 数值或者布尔值.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示被激活的列表, 对应一个选择器, 元素, 数值或者布尔值" )]
		[NotifyParentProperty ( true )]
		public string Active
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.active ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.active, value ); }
		}

		/// <summary>
		/// 获取或设置列表切换的动画, 比如: 'bounceslide', 'slide', 也可以设置为 false, 来禁止动画.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表切换的动画, 比如: 'bounceslide', 'slide', 也可以设置为 false, 来禁止动画" )]
		[NotifyParentProperty ( true )]
		public string Animated
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animated ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animated, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动调整与最高的列表同高, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动调整与最高的列表同高, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoHeight, value ); }
		}

		/// <summary>
		/// 获取或设置是否在动画结束后清除 height, overflow 样式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在动画结束后清除 height, overflow 样式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ClearStyle
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.clearStyle ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.clearStyle, value ); }
		}

		/// <summary>
		/// 获取或设置是否关闭所有的列表, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否关闭所有的列表, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Collapsible
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.collapsible ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.collapsible, value ); }
		}

		/// <summary>
		/// 获取或设置触发列表的事件, 比如: 'mouseover'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示触发列表的事件, 比如: 'mouseover'" )]
		[NotifyParentProperty ( true )]
		public string Event
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@event ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@event, value ); }
		}

		/// <summary>
		/// 获取或设置是否以父容器填充高度, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否以父容器填充高度, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string FillSpace
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.fillSpace ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.fillSpace, value ); }
		}

		/// <summary>
		/// 获取或设置作为标题的元素, 可以是选择器或者 jQuery 对象, 默认为 '> li > :first-child, > :not(li):even'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示作为标题的元素, 可以是选择器或者 jQuery 对象, 默认为 '> li > :first-child, > :not(li):even'" )]
		[NotifyParentProperty ( true )]
		public string Header
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.header ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.header, value ); }
		}

		/// <summary>
		/// 获取或设置列表显示的图标, 默认为: { 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表显示的图标, 默认为: { 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }" )]
		[NotifyParentProperty ( true )]
		public string Icons
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.icons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.icons, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以导航, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以导航, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Navigation
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.navigation ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.navigation, value ); }
		}

		/// <summary>
		/// 获取或设置选择导航的函数.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择导航的函数" )]
		[NotifyParentProperty ( true )]
		public string NavigationFilter
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.navigationFilter ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.navigationFilter, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置列表被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置列表改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置列表开始改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表开始改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Changestart
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.changestart ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.changestart, value ); }
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
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " AccordionSettingEditConverter "
	/// <summary>
	/// jQuery UI 折叠列表设置编辑器的转换器.
	/// </summary>
	public sealed class AccordionSettingEditConverter : ExpandableObjectConverter
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
			AccordionSettingEdit edit = new AccordionSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AccordionSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AccordionSettingEdit setting = value as AccordionSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " AutocompleteSettingEdit "
	/// <summary>
	/// jQuery UI 自动填充的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( AutocompleteSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class AutocompleteSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的自动填充设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "自动填充相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的自动填充事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "自动填充相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置自动填充是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示自动填充是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置填充对应的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充对应的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendTo ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendTo, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动对焦到第一个条目, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动对焦到第一个条目, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoFocus
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoFocus ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoFocus, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的激活自动填充的延迟, 比如: 300.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的激活自动填充的延迟, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置激活填充需要最小的输入字符数, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示激活填充需要最小的输入字符数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public string MinLength
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minLength ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minLength, value ); }
		}

		/// <summary>
		/// 获取或设置填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.position ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.position, value ); }
		}

		/// <summary>
		/// 获取或设置用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数" )]
		[NotifyParentProperty ( true )]
		public string Source
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.source ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.source, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置填充被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置搜索匹配项时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示搜索匹配项时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Search
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.search ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.search, value ); }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.open ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.open, value ); }
		}

		/// <summary>
		/// 获取或设置获得焦点时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Focus
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.focus ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.focus, value ); }
		}

		/// <summary>
		/// 获取或设置选择某个条目的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择某个条目的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.select ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.select, value ); }
		}

		/// <summary>
		/// 获取或设置列表关闭时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.close ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.close, value ); }
		}

		/// <summary>
		/// 获取或设置选择的条目改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择的条目改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
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
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " AutocompleteSettingEditConverter "
	/// <summary>
	/// jQuery UI 自动填充设置编辑器的转换器.
	/// </summary>
	public sealed class AutocompleteSettingEditConverter : ExpandableObjectConverter
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
			AutocompleteSettingEdit edit = new AutocompleteSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AutocompleteSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AutocompleteSettingEdit setting = value as AutocompleteSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " DatepickerSettingEdit "
	/// <summary>
	/// jQuery UI 日期框的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DatepickerSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DatepickerSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的日期框设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "日期框相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的日期框事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "日期框相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置日期框是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置备用字段, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示备用字段, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AltField
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.altField ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.altField, value ); }
		}

		/// <summary>
		/// 获取或设置在备用字段显示的日期格式, 比如: 'yy-mm-dd'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示在备用字段显示的日期格式, 比如: 'yy-mm-dd'" )]
		[NotifyParentProperty ( true )]
		public string AltFormat
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.altFormat ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.altFormat, value ); }
		}

		/// <summary>
		/// 获取或设置显示在日期字段后的文本, 比如: '...'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示在日期字段后的文本, 比如: '...'" )]
		[NotifyParentProperty ( true )]
		public string AppendText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendText, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动调整输入框的大小, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动调整输入框的大小, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoSize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoSize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoSize, value ); }
		}

		/// <summary>
		/// 获取或设置按钮的图片, 比如: '/images/datepicker.gif'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的图片, 比如: '/images/datepicker.gif'" )]
		[NotifyParentProperty ( true )]
		public string ButtonImage
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttonImage ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttonImage, value ); }
		}

		/// <summary>
		/// 获取或设置是否按钮只显示图片, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否按钮只显示图片, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ButtonImageOnly
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttonImageOnly ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttonImageOnly, value ); }
		}

		/// <summary>
		/// 获取或设置按钮的文本, 默认 '...'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的文本, 默认 '...'" )]
		[NotifyParentProperty ( true )]
		public string ButtonText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttonText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttonText, value ); }
		}

		/// <summary>
		/// 获取或设置区域设置, 默认 $.datepicker.iso8601Week.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示区域设置, 默认 $.datepicker.iso8601Week" )]
		[NotifyParentProperty ( true )]
		public string CalculateWeek
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.calculateWeek ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.calculateWeek, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许使用下拉框改变月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ChangeMonth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.changeMonth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.changeMonth, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变年份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许使用下拉框改变年份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ChangeYear
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.changeYear ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.changeYear, value ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 比如: 'X'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭链接的文本, 比如: 'X'" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeText, value ); }
		}

		/// <summary>
		/// 获取或设置是否限制输入的格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否限制输入的格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ConstrainInput
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.constrainInput ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.constrainInput, value ); }
		}

		/// <summary>
		/// 获取或设置当天链接的文本, 比如: '今天'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示当天链接的文本, 比如: '今天'" )]
		[NotifyParentProperty ( true )]
		public string CurrentText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.currentText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.currentText, value ); }
		}

		/// <summary>
		/// 获取或设置日期的格式, 比如: 'mm/dd/yy'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期的格式, 比如: 'mm/dd/yy'" )]
		[NotifyParentProperty ( true )]
		public string DateFormat
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dateFormat ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dateFormat, value ); }
		}

		/// <summary>
		/// 获取或设置天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" )]
		[NotifyParentProperty ( true )]
		public string DayNames
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dayNames ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dayNames, value ); }
		}

		/// <summary>
		/// 获取或设置天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesMin
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dayNamesMin ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dayNamesMin, value ); }
		}

		/// <summary>
		/// 获取或设置天的短名称, 比如: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesShort
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dayNamesShort ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dayNamesShort, value ); }
		}

		/// <summary>
		/// 获取或设置默认日期, 可以是日期, 数字或者字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示默认日期, 可以是日期, 数字或者字符串" )]
		[NotifyParentProperty ( true )]
		public string DefaultDate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.defaultDate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.defaultDate, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的日期显示速度, 或者使用 'slow', 'normal', 'fast' 中的一种.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的日期显示速度, 或者使用 'slow', 'normal', 'fast' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string Duration
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.duration ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.duration, value ); }
		}

		/// <summary>
		/// 获取或设置哪一天作为一周的开始, 0 表示周日以此类推.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示哪一天作为一周的开始, 0 表示周日以此类推" )]
		[NotifyParentProperty ( true )]
		public string FirstDay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.firstDay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.firstDay, value ); }
		}

		/// <summary>
		/// 获取或设置是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string GotoCurrent
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.gotoCurrent ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.gotoCurrent, value ); }
		}

		/// <summary>
		/// 获取或设置是否隐藏上一和下一链接, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否隐藏上一和下一链接, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string HideIfNoPrevNext
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.hideIfNoPrevNext ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.hideIfNoPrevNext, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用从右向左, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用从右向左, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string IsRTL
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.isRTL ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.isRTL, value ); }
		}

		/// <summary>
		/// 获取或设置最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周" )]
		[NotifyParentProperty ( true )]
		public string MaxDate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxDate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxDate, value ); }
		}

		/// <summary>
		/// 获取或设置最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小日期, 可以是日期, 数字或者字符串, 比如: '-1m -1w', 表示推前一月零一周" )]
		[NotifyParentProperty ( true )]
		public string MinDate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minDate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minDate, value ); }
		}

		/// <summary>
		/// 获取或设置月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" )]
		[NotifyParentProperty ( true )]
		public string MonthNames
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.monthNames ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.monthNames, value ); }
		}

		/// <summary>
		/// 获取或设置月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" )]
		[NotifyParentProperty ( true )]
		public string MonthNamesShort
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.monthNamesShort ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.monthNamesShort, value ); }
		}

		/// <summary>
		/// 获取或设置链接是否使用日期格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示链接是否使用日期格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string NavigationAsDateFormat
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.navigationAsDateFormat ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.navigationAsDateFormat, value ); }
		}

		/// <summary>
		/// 获取或设置下一链接的文本, 比如: '...'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示下一链接的文本, 比如: '...'" )]
		[NotifyParentProperty ( true )]
		public string NextText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.nextText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.nextText, value ); }
		}

		/// <summary>
		/// 获取或设置显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3]" )]
		[NotifyParentProperty ( true )]
		public string NumberOfMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.numberOfMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.numberOfMonths, value ); }
		}

		/// <summary>
		/// 获取或设置上一链接的文本, 比如: '...'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示上一链接的文本, 比如: '...'" )]
		[NotifyParentProperty ( true )]
		public string PrevText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.prevText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.prevText, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以选择其它的月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以选择其它的月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string SelectOtherMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selectOtherMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selectOtherMonths, value ); }
		}

		/// <summary>
		/// 获取或设置短年份的设置, 可以是数字或者字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示短年份的设置, 可以是数字或者字符串" )]
		[NotifyParentProperty ( true )]
		public string ShortYearCutoff
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.shortYearCutoff ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.shortYearCutoff, value ); }
		}

		/// <summary>
		/// 获取或设置显示日期时的动画, 比如: 'show'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示日期时的动画, 比如: 'show'" )]
		[NotifyParentProperty ( true )]
		public string ShowAnim
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showAnim ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showAnim, value ); }
		}

		/// <summary>
		/// 获取或设置是否显示按钮面板, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否显示按钮面板, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowButtonPanel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showButtonPanel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showButtonPanel, value ); }
		}

		/// <summary>
		/// 获取或设置当前月份的显示位置.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示当前月份的显示位置" )]
		[NotifyParentProperty ( true )]
		public string ShowCurrentAtPos
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showCurrentAtPos ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showCurrentAtPos, value ); }
		}

		/// <summary>
		/// 获取或设置是否在年后显示月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在年后显示月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowMonthAfterYear
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showMonthAfterYear ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showMonthAfterYear, value ); }
		}

		/// <summary>
		/// 获取或设置日期框显示方式, 可以是 'focus', 'button' , 'both' 中的一种.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示方式, 可以是 'focus', 'button' , 'both' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string ShowOn
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showOn ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showOn, value ); }
		}

		/// <summary>
		/// 获取或设置显示选项, 比如: {direction: 'up' }.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示选项, 比如: {direction: 'up' }" )]
		[NotifyParentProperty ( true )]
		public string ShowOptions
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showOptions ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showOptions, value ); }
		}

		/// <summary>
		/// 获取或设置是否显示其它月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否显示其它月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowOtherMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showOtherMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showOtherMonths, value ); }
		}

		/// <summary>
		/// 获取或设置是否显示当前为一年中的第几周, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否显示当前为一年中的第几周, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowWeek
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showWeek ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showWeek, value ); }
		}

		/// <summary>
		/// 获取或设置每一次跳转的月份数, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示每一次跳转的月份数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public string StepMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stepMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stepMonths, value ); }
		}

		/// <summary>
		/// 获取或设置周的标题设置, 默认: 'Wk'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示周的标题设置, 默认: 'Wk'" )]
		[NotifyParentProperty ( true )]
		public string WeekHeader
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.weekHeader ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.weekHeader, value ); }
		}

		/// <summary>
		/// 获取或设置可选择的年份范围, 默认: 'c-10:c+10'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示可选择的年份范围, 默认: 'c-10:c+10'" )]
		[NotifyParentProperty ( true )]
		public string YearRange
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.yearRange ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.yearRange, value ); }
		}

		/// <summary>
		/// 获取或设置跟随在年后的文本, 比如: 'Y'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示跟随在年后的文本, 比如: 'Y'" )]
		[NotifyParentProperty ( true )]
		public string YearSuffix
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.yearSuffix ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.yearSuffix, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置日期框被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置日期框显示时的事件, 类似于: function(input, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示时的事件, 类似于: function(input, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShow
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeShow ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeShow, value ); }
		}

		/// <summary>
		/// 获取或设置日期框显示天时的事件, 类似于: function(date) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示天时的事件, 类似于: function(date) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShowDay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeShowDay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeShowDay, value ); }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(year, month, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示年和月改变时的事件, 类似于: function(year, month, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnChangeMonthYear
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.onChangeMonthYear ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.onChangeMonthYear, value ); }
		}

		/// <summary>
		/// 获取或设置日期款关闭时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期款关闭时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnClose
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.onClose ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.onClose, value ); }
		}

		/// <summary>
		/// 获取或设置日期选择时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期选择时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnSelect
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.onSelect ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.onSelect, value ); }
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
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DatepickerSettingEditConverter "
	/// <summary>
	/// jQuery UI 日期框设置编辑器的转换器.
	/// </summary>
	public sealed class DatepickerSettingEditConverter : ExpandableObjectConverter
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
			DatepickerSettingEdit edit = new DatepickerSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DatepickerSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DatepickerSettingEdit setting = value as DatepickerSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " DialogSettingEdit "
	/// <summary>
	/// jQuery UI 对话框的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DialogSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DialogSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的对话框设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "对话框相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的对话框事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "对话框相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置对话框是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置对话框是否自动打开, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框是否自动打开, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoOpen
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoOpen ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoOpen, value ); }
		}

		/// <summary>
		/// 获取或设置对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }" )]
		[NotifyParentProperty ( true )]
		public string Buttons
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttons, value ); }
		}

		/// <summary>
		/// 获取或设置是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string CloseOnEscape
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeOnEscape ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeOnEscape, value ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 默认 'close'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭链接的文本, 默认 'close'" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeText, value ); }
		}

		/// <summary>
		/// 获取或设置对话框的样式, 比如: 'alert'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框的样式, 比如: 'alert'" )]
		[NotifyParentProperty ( true )]
		public string DialogClass
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dialogClass ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dialogClass, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许拖动, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许拖动, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Draggable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.draggable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.draggable, value ); }
		}

		/// <summary>
		/// 获取或设置对话框高度, 比如: 300.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框高度, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public string Height
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.height ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.height, value ); }
		}

		/// <summary>
		/// 获取或设置关闭对话框时的动画, 比如: 'slide'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭对话框时的动画, 比如: 'slide'" )]
		[NotifyParentProperty ( true )]
		public string Hide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.hide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.hide, value ); }
		}

		/// <summary>
		/// 获取或设置最大高度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大高度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MaxHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxHeight, value ); }
		}

		/// <summary>
		/// 获取或设置最大宽度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大宽度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MaxWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxWidth, value ); }
		}

		/// <summary>
		/// 获取或设置最小高度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小高度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MinHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minHeight, value ); }
		}

		/// <summary>
		/// 获取或设置最小宽度, 比如: 400.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小宽度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MinWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minWidth, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用 modal 模式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用 modal 模式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Modal
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.modal ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.modal, value ); }
		}

		/// <summary>
		/// 获取或设置对话框的位置, 比如: ['right','top'], [100, 200].
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框的位置, 比如: ['right','top'], [100, 200]" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.position ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.position, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许缩放, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许缩放, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Resizable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resizable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizable, value ); }
		}

		/// <summary>
		/// 获取或设置显示时的动画, 比如: 'slide'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示时的动画, 比如: 'slide'" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.show ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.show, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动置顶, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动置顶, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Stack
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stack ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stack, value ); }
		}

		/// <summary>
		/// 获取或设置对话框标题, 比如: 'my title'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框标题, 比如: 'my title'" )]
		[NotifyParentProperty ( true )]
		public string Title
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.title ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.title, value ); }
		}

		/// <summary>
		/// 获取或设置对话框宽度, 比如: 300.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框宽度, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public string Width
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.width ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.width, value ); }
		}

		/// <summary>
		/// 获取或设置对话框 Z 轴顺序, 比如: 2.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框 Z 轴顺序, 比如: 2" )]
		[NotifyParentProperty ( true )]
		public string ZIndex
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.zIndex ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.zIndex, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置对话框被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置对话框关闭之前的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭之前的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeClose
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeClose ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeClose, value ); }
		}

		/// <summary>
		/// 获取或设置对话框打开时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.open ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.open, value ); }
		}

		/// <summary>
		/// 获取或设置对话框获得焦点时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Focus
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.focus ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.focus, value ); }
		}

		/// <summary>
		/// 获取或设置对话框拖动开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStart
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dragStart ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dragStart, value ); }
		}

		/// <summary>
		/// 获取或设置对话框拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drag
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.drag ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.drag, value ); }
		}

		/// <summary>
		/// 获取或设置对话框拖动结束时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dragStop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dragStop, value ); }
		}

		/// <summary>
		/// 获取或设置对话框缩放开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStart
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resizeStart ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizeStart, value ); }
		}

		/// <summary>
		/// 获取或设置对话框缩放时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Resize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resize, value ); }
		}

		/// <summary>
		/// 获取或设置对话框缩放结束时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resizeStop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizeStop, value ); }
		}

		/// <summary>
		/// 获取或设置对话框关闭时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.close ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.close, value ); }
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
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DialogSettingEditConverter "
	/// <summary>
	/// jQuery UI 对话框设置编辑器的转换器.
	/// </summary>
	public sealed class DialogSettingEditConverter : ExpandableObjectConverter
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
			DialogSettingEdit edit = new DialogSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DialogSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DialogSettingEdit setting = value as DialogSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " ProgressbarSettingEdit "
	/// <summary>
	/// jQuery UI 进度条的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( ProgressbarSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ProgressbarSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的进度条设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "进度条相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的进度条事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "进度条相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置进度条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置进度条当前的值, 比如: 37.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条当前的值, 比如: 37" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.value ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.value, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置进度条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置进度条当前值改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条当前值改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置进度条完成时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Complete
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.complete ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.complete, value ); }
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
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ProgressbarSettingEditConverter "
	/// <summary>
	/// jQuery UI 进度条设置编辑器的转换器.
	/// </summary>
	public sealed class ProgressbarSettingEditConverter : ExpandableObjectConverter
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
			ProgressbarSettingEdit edit = new ProgressbarSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ProgressbarSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ProgressbarSettingEdit setting = value as ProgressbarSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " SliderSettingEdit "
	/// <summary>
	/// jQuery UI 分割条的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( SliderSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class SliderSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的分割条设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "分割条相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的分割条事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "分割条相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置分割条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'" )]
		[NotifyParentProperty ( true )]
		public string Animate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animate, value ); }
		}

		/// <summary>
		/// 获取或设置分割条最大值, 比如: 100.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条最大值, 比如: 100" )]
		[NotifyParentProperty ( true )]
		public string Max
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.max ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.max, value ); }
		}

		/// <summary>
		/// 获取或设置分割条最小值, 比如: 0.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条最小值, 比如: 0" )]
		[NotifyParentProperty ( true )]
		public string Min
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.min ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.min, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的方向, 比如: 'horizontal', 'vertical'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的方向, 比如: 'horizontal', 'vertical'" )]
		[NotifyParentProperty ( true )]
		public string Orientation
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.orientation ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.orientation, value ); }
		}

		/// <summary>
		/// 获取或设置分割条是否使用范围, 或者为 'min', 'max' 中的一种.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条是否使用范围, 或者为 'min', 'max' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string Range
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.range ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.range, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的步长, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的步长, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public string Step
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.step ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.step, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的值, 比如: 30.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的值, 比如: 30" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.value ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.value, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的范围值, 比如: [1, 4, 10].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的范围值, 比如: [1, 4, 10]" )]
		[NotifyParentProperty ( true )]
		public string Values
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.values ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.values, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置分割条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置分割条开始拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条开始拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置分割条拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Slide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.slide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.slide, value ); }
		}

		/// <summary>
		/// 获取或设置分割条改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置分割条结束拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条结束拖动时的事件, 类似于: function(event, ui) { }" )]
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
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " SliderSettingEditConverter "
	/// <summary>
	/// jQuery UI 分割条设置编辑器的转换器.
	/// </summary>
	public sealed class SliderSettingEditConverter : ExpandableObjectConverter
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
			SliderSettingEdit edit = new SliderSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SliderSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SliderSettingEdit setting = value as SliderSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " TabsSettingEdit "
	/// <summary>
	/// jQuery UI 分组标签的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( TabsSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class TabsSettingEdit
		: IStateManager
	{
		private SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的分组标签设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "分组标签相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的分组标签事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "分组标签相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置分组标签是否可用, 或者禁用的标签的索引, 可以设置为 true, false, 或者 [0, 1].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签是否可用, 或者禁用的标签的索引, 可以设置为 true, false, 或者 [0, 1]" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置标签内容的 Ajax 选项, 比如: { async: false }.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签内容的 Ajax 选项, 比如: { async: false }" )]
		[NotifyParentProperty ( true )]
		public string AjaxOptions
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.ajaxOptions ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.ajaxOptions, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用缓存, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用缓存, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Cache
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cache ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cache, value ); }
		}

		/// <summary>
		/// 获取或设置当再次选择已选中的标签时, 是否取消选中状态, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示当再次选择已选中的标签时, 是否取消选中状态, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Collapsible
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.collapsible ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.collapsible, value ); }
		}

		/// <summary>
		/// 获取或设置 cookie 的设置, 比如: { expires: 7, path: '/', domain: 'jquery.com', secure: true }.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 cookie 的设置, 比如: { expires: 7, path: '/', domain: 'jquery.com', secure: true }" )]
		[NotifyParentProperty ( true )]
		public string Cookie
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cookie ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cookie, value ); }
		}

		/// <summary>
		/// 请使用 Collapsible.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "请使用 Collapsible" )]
		[NotifyParentProperty ( true )]
		public string Deselectable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.deselectable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.deselectable, value ); }
		}

		/// <summary>
		/// 获取或设置触发切换的事件名称, 默认: 'click'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示触发切换的事件名称, 默认: 'click'" )]
		[NotifyParentProperty ( true )]
		public string Event
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@event ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@event, value ); }
		}

		/// <summary>
		/// 获取或设置显示或者隐藏的动画效果, 比如: { opacity: 'toggle' }, 'slow', 'normal', 'fast'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示或者隐藏的动画效果, 比如: { opacity: 'toggle' }, 'slow', 'normal', 'fast'" )]
		[NotifyParentProperty ( true )]
		public string Fx
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.fx ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.fx, value ); }
		}

		/// <summary>
		/// 获取或设置 id 的前缀, 默认为 'ui-tabs-'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 id 的前缀, 默认为 'ui-tabs-'" )]
		[NotifyParentProperty ( true )]
		public string IdPrefix
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.idPrefix ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.idPrefix, value ); }
		}

		/// <summary>
		/// 获取或设置面板的模板内容.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示面板的模板内容, 默认为 '<div></div>'" )]
		[NotifyParentProperty ( true )]
		public string PanelTemplate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.panelTemplate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.panelTemplate, value ); }
		}

		/// <summary>
		/// 获取或设置选中的标签, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中的标签, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public string Selected
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selected ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selected, value ); }
		}

		/// <summary>
		/// 获取或设置载入条的内容.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示载入条的内容" )]
		[NotifyParentProperty ( true )]
		public string Spinner
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.spinner ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.spinner, value ); }
		}

		/// <summary>
		/// 获取或设置表头的模板内容.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示表头的模板内容, 默认为 '<li><a href=#{href}><span>#{label}</span></a></li>'" )]
		[NotifyParentProperty ( true )]
		public string TabTemplate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tabTemplate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tabTemplate, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置分组标签被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置分组标签被选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.select ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.select, value ); }
		}

		/// <summary>
		/// 获取或设置内容载入时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示内容载入时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Load
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.load ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.load, value ); }
		}

		/// <summary>
		/// 获取或设置标签显示时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签显示时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.show ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.show, value ); }
		}

		/// <summary>
		/// 获取或设置标签被添加时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被添加时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Add
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.add ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.add, value ); }
		}

		/// <summary>
		/// 获取或设置标签被删除时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被删除时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.remove ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.remove, value ); }
		}

		/// <summary>
		/// 获取或设置标签被启用时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被启用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Enable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.enable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.enable, value ); }
		}

		/// <summary>
		/// 获取或设置标签被禁用时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被禁用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Disable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disable, value ); }
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
		/// 设置 OptionEdit, EventEdit 辅助类. (用于在程序集内容使用)
		/// </summary>
		/// <param name="editHelper">辅助类.</param>
		public void SetEditHelper ( SettingEditHelper editHelper )
		{

			if ( null != editHelper )
				this.editHelper = editHelper;

		}

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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " TabsSettingEditConverter "
	/// <summary>
	/// jQuery UI 分组标签设置编辑器的转换器.
	/// </summary>
	public sealed class TabsSettingEditConverter : ExpandableObjectConverter
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
			TabsSettingEdit edit = new TabsSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is TabsSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			TabsSettingEdit setting = value as TabsSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " EmptySettingEdit "
	/// <summary>
	/// jQuery UI 空的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( EmptySettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class EmptySettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的空设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "空相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的空事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "空相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
		}

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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " EmptySettingEditConverter "
	/// <summary>
	/// jQuery UI 空设置编辑器的转换器.
	/// </summary>
	public sealed class EmptySettingEditConverter : ExpandableObjectConverter
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
			EmptySettingEdit edit = new EmptySettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is EmptySettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			EmptySettingEdit setting = value as EmptySettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

}

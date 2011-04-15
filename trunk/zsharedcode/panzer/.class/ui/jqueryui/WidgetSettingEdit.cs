/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIWidgetSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIWidgetSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/WidgetSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
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
		private List<OptionEdit> options = new List<OptionEdit> ( );
		private List<EventEdit> events = new List<EventEdit> ( );
		private List<AjaxSettingEdit> ajaxSettings = new List<AjaxSettingEdit> ( );
		private WidgetType type = WidgetType.empty;

		/// <summary>
		/// 获取元素的 Widget 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的排列设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.options; }
		}

		/// <summary>
		/// 获取元素的 Widget 事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.events; }
		}

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
		/// 创建一个 jQuery UI 排列的相关设置.
		/// </summary>
		/// <returns>jQuery UI 排列的相关设置.</returns>
		public WidgetSetting CreateWidgetSetting ( )
		{
			List<Option> options = new List<Option> ( );

			foreach ( OptionEdit edit in this.options )
				options.Add ( edit.CreateOption ( ) );

			List<Event> events = new List<Event> ( );

			foreach ( EventEdit edit in this.events )
				events.Add ( edit.CreateEvent ( ) );

			List<AjaxSetting> ajaxSettings = new List<AjaxSetting> ( );

			foreach ( AjaxSettingEdit edit in this.ajaxSettings )
				ajaxSettings.Add ( edit.CreateAjaxSetting ( ) );

			return new WidgetSetting ( this.type, options.ToArray ( ), events.ToArray ( ), ajaxSettings.ToArray ( ) );
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
				this.type = ( WidgetType ) states[0];

			if ( states.Count >= 2 )
			{
				List<object> optionStates = states[1] as List<object>;

				for ( int index = 0; index < optionStates.Count; index++ )
					( this.options[index] as IStateManager ).LoadViewState ( optionStates[index] );

			}

			if ( states.Count >= 3 )
			{
				List<object> eventStates = states[2] as List<object>;

				for ( int index = 0; index < eventStates.Count; index++ )
					( this.events[index] as IStateManager ).LoadViewState ( eventStates[index] );

			}

			if ( states.Count >= 4 )
			{
				List<object> ajaxSettingStates = states[3] as List<object>;

				for ( int index = 0; index < ajaxSettingStates.Count; index++ )
					( this.ajaxSettings[index] as IStateManager ).LoadViewState ( ajaxSettingStates[index] );

			}

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.type );

			List<object> optionStates = new List<object> ( );

			foreach ( OptionEdit edit in this.options )
				optionStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( optionStates );


			List<object> eventStates = new List<object> ( );

			foreach ( EventEdit edit in this.events )
				eventStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( eventStates );


			List<object> ajaxSettingStates = new List<object> ( );

			foreach ( AjaxSettingEdit edit in this.ajaxSettings )
				ajaxSettingStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( ajaxSettingStates );

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

}

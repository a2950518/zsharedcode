/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ParameterEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Globalization;
using System.Web.UI;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

// HACK: 避免在 allinone 文件中的名称冲突
using NParameter = zoyobar.shared.panzer.web.jqueryui.Parameter;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " AjaxSettingEdit "
	/// <summary>
	/// jQuery UI Ajax 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( AjaxSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class AjaxSettingEdit
		: IStateManager
	{
		private List<EventEdit> events = new List<EventEdit> ( );
		private EventType widgetEventType;
		private string url;
		private DataType dataType;
		private string form;
		private List<ParameterEdit> parameters = new List<ParameterEdit> ( );
		private bool isSingleQuote;

		/// <summary>
		/// 获取元素的 Ajax 事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的 Ajax 事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.events; }
		}

		/// <summary>
		/// 获取或设置和 Widget 相关的触发事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( EventType.none )]
		[Description ( "指示和 Widget 相关的触发事件" )]
		[NotifyParentProperty ( true )]
		public EventType WidgetEventType
		{
			get { return this.widgetEventType; }
			set { this.widgetEventType = value; }
		}

		/// <summary>
		/// 获取或设置请求的地址.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示请求的地址" )]
		[NotifyParentProperty ( true )]
		[UrlProperty ( )]
		public string Url
		{
			get { return this.url; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.url = value;

			}
		}

		/// <summary>
		/// 获取或设置获取的数据类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( DataType.json )]
		[Description ( "指示获取的数据类型" )]
		[NotifyParentProperty ( true )]
		public DataType DataType
		{
			get { return this.dataType; }
			set { this.dataType = value; }
		}

		/// <summary>
		/// 获取或设置用作传递参数的表单.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示用作传递参数的表单, 可以是一个选择器或元素" )]
		[NotifyParentProperty ( true )]
		public string Form
		{
			get { return this.form; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.form = value;

			}
		}

		/// <summary>
		/// 获取用作传递的参数.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "用作传递的参数" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( ParameterEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<ParameterEdit> Parameters
		{
			get { return this.parameters; }
		}

		/// <summary>
		/// 获取或设置是否为字符串使用单引号.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( true )]
		[Description ( "指示是否为字符串使用单引号" )]
		[NotifyParentProperty ( true )]
		public bool IsSingleQuote
		{
			get { return this.isSingleQuote; }
			set { this.isSingleQuote = value; }
		}

		/// <summary>
		/// 创建一个 jQuery UI Ajax 的相关设置.
		/// </summary>
		/// <returns>jQuery UI Ajax 的相关设置.</returns>
		public AjaxSetting CreateAjaxSetting ( )
		{
			List<Event> events = new List<Event> ( );

			foreach ( EventEdit edit in this.events )
				events.Add ( edit.CreateEvent ( ) );

			List<NParameter> parameters = new List<NParameter> ( );

			foreach ( ParameterEdit edit in this.parameters )
				parameters.Add ( edit.CreateParameter ( ) );

			return new AjaxSetting ( this.widgetEventType, this.url, this.dataType, this.form, parameters.ToArray ( ), events.ToArray ( ), this.isSingleQuote );
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
				this.widgetEventType = ( EventType ) states[0];

			if ( states.Count >= 2 )
				this.Url = states[1] as string;

			if ( states.Count >= 3 )
				this.dataType = ( DataType ) states[2];

			if ( states.Count >= 4 )
				this.Form = states[3] as string;

			if ( states.Count >= 5 )
				this.isSingleQuote = ( bool ) states[4];

			if ( states.Count >= 6 )
			{
				List<object> eventStates = states[5] as List<object>;

				for ( int index = 0; index < eventStates.Count; index++ )
					( this.events[index] as IStateManager ).LoadViewState ( eventStates[index] );

			}

			if ( states.Count >= 7 )
			{
				List<object> parameterStates = states[6] as List<object>;

				for ( int index = 0; index < parameterStates.Count; index++ )
					( this.parameters[index] as IStateManager ).LoadViewState ( parameterStates[index] );

			}

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.widgetEventType );
			states.Add ( this.url );
			states.Add ( this.dataType );
			states.Add ( this.form );
			states.Add ( this.isSingleQuote );

			List<object> eventStates = new List<object> ( );

			foreach ( EventEdit edit in this.events )
				eventStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( eventStates );


			List<object> parameterStates = new List<object> ( );

			foreach ( ParameterEdit edit in this.parameters )
				parameterStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( parameterStates );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " AjaxSettingEditConverter "
	/// <summary>
	/// jQuery UI Ajax 设置编辑器的转换器.
	/// </summary>
	public sealed class AjaxSettingEditConverter : ExpandableObjectConverter
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
			AjaxSettingEdit edit = new AjaxSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 5 )
				try
				{

					if ( expressionHelper[0].Value != string.Empty )
						edit.WidgetEventType = ( EventType ) Enum.Parse ( typeof ( EventType ), expressionHelper[0].Value );

					if ( expressionHelper[1].Value != string.Empty )
						edit.Url = expressionHelper[1].Value;

					if ( expressionHelper[2].Value != string.Empty )
						edit.DataType = ( DataType ) Enum.Parse ( typeof ( DataType ), expressionHelper[2].Value );

					if ( expressionHelper[3].Value != string.Empty )
						edit.Form = expressionHelper[3].Value;

					if ( expressionHelper[4].Value != string.Empty )
						edit.IsSingleQuote = StringConvert.ToObject<bool> ( expressionHelper[4].Value );

				}
				catch { }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AjaxSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AjaxSettingEdit setting = value as AjaxSettingEdit;

			return string.Format ( "{0}`;{1}`;{2}`;{3}`;{4}`;", setting.WidgetEventType, setting.Url, setting.DataType, setting.Form, setting.IsSingleQuote );
		}

	}
	#endregion

	#region " AjaxSettingEditCollectionEditor "
	/// <summary>
	/// jQuery UI 选项的集合编辑器.
	/// </summary>
	public class AjaxSettingEditCollectionEditor : CollectionEditor
	{

		public AjaxSettingEditCollectionEditor ( Type type )
			: base ( type )
		{ }

		protected override bool CanSelectMultipleInstances ( )
		{ return false; }

		protected override Type CreateCollectionItemType ( )
		{ return typeof ( AjaxSettingEdit ); }

	}
	#endregion

}

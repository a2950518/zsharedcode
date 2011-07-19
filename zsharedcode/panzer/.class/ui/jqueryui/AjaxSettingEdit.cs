/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSettingEditCollectionEditor
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxSettingEdit.cs
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
using zoyobar.shared.panzer.web;
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
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private EventType widgetEventType = EventType.none;
		private string url = string.Empty;
		private string methodName = string.Empty;
		private DataType dataType = DataType.json;
		private RequestType type = RequestType.GET;
		private string contentType = string.Empty;
		private string form = string.Empty;
		private readonly List<ParameterEdit> parameters = new List<ParameterEdit> ( );
		private bool isSingleQuote = true;

		/// <summary>
		/// 获取元素的 Ajax 事件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的 Ajax 事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Event "
		/// <summary>
		/// 获取或设置 ajax 完成时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 完成时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Complete
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.complete ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.complete, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 错误时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 错误时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Error
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.error ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.error, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 成功时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 成功时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Success
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.success ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.success, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 发送时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 发送时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Send
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.send ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.send, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 开始时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 开始时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.start ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.start, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 停止时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 停止时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterEventEditValue ( EventType.stop ); }
			set { this.editHelper.SetOuterEventEditValue ( EventType.stop, value ); }
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
		/// 获取或设置和 Widget 相关的触发事件.
		/// </summary>
		[Category ( "行为" )]
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
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示请求的地址" )]
		[NotifyParentProperty ( true )]
		[UrlProperty ( )]
		public string Url
		{
			get { return this.url; }
			set { this.url = value; }
		}

		/// <summary>
		/// 获取或设置 WebService 的方法名称, 设置将可能修改 Type, ContentType 以及 DataType 属性.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 WebService 的方法名称, 设置将可能修改 Type, ContentType 以及 DataType 属性" )]
		[NotifyParentProperty ( true )]
		public string MethodName
		{
			get { return this.methodName; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
				{
					this.type = RequestType.POST;
					this.dataType = DataType.json;

					if ( string.IsNullOrEmpty ( this.contentType ) )
						this.contentType = "application/json;charset=utf-8";

				}

				this.methodName = value;
			}
		}

		/// <summary>
		/// 获取或设置获取的数据类型.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( DataType.json )]
		[Description ( "指示获取的数据类型" )]
		[NotifyParentProperty ( true )]
		public DataType DataType
		{
			get { return this.dataType; }
			set { this.dataType = value; }
		}

		/// <summary>
		/// 获取或设置请求的类型.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( RequestType.GET )]
		[Description ( "指示请求的类型" )]
		[NotifyParentProperty ( true )]
		public RequestType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置请求内容的类型.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示请求内容的类型" )]
		[NotifyParentProperty ( true )]
		public string ContentType
		{
			get { return this.contentType; }
			set { this.contentType = value; }
		}

		/// <summary>
		/// 获取或设置用作传递参数的表单.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用作传递参数的表单, 可以是一个选择器或元素" )]
		[NotifyParentProperty ( true )]
		public string Form
		{
			get { return this.form; }
			set { this.form = value; }
		}

		/// <summary>
		/// 获取用作传递的参数.
		/// </summary>
		[Category ( "基本" )]
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
		[Category ( "行为" )]
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
			List<NParameter> parameters = new List<NParameter> ( );

			foreach ( ParameterEdit edit in this.parameters )
				parameters.Add ( edit.CreateParameter ( ) );

			return new AjaxSetting ( this.widgetEventType, this.url, this.methodName, this.dataType, this.type, this.contentType, this.form, parameters.ToArray ( ), this.editHelper.CreateEvents ( ), this.isSingleQuote );
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
				( this.editHelper as IStateManager ).LoadViewState ( states[5] );

			if ( states.Count >= 7 )
			{
				List<object> parameterStates = states[6] as List<object>;

				for ( int index = 0; index < parameterStates.Count; index++ )
					( this.parameters[index] as IStateManager ).LoadViewState ( parameterStates[index] );

			}

			if ( states.Count >= 8 )
				this.type = ( RequestType ) states[7];

			if ( states.Count >= 9 )
				this.contentType = states[8] as string;

			if ( states.Count >= 10 )
				this.contentType = states[9] as string;

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.widgetEventType );
			states.Add ( this.url );
			states.Add ( this.dataType );
			states.Add ( this.form );
			states.Add ( this.isSingleQuote );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			List<object> parameterStates = new List<object> ( );

			foreach ( ParameterEdit edit in this.parameters )
				parameterStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( parameterStates );
			states.Add ( this.type );
			states.Add ( this.contentType );
			states.Add ( this.methodName );

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

			if ( expressionHelper.ChildCount == 9 )
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

					if ( expressionHelper[5].Value != string.Empty )
						edit.EditHelper.FromString ( expressionHelper[5].Value );

					if ( expressionHelper[6].Value != string.Empty )
						edit.Type = ( RequestType ) Enum.Parse ( typeof ( RequestType ), expressionHelper[6].Value );

					if ( expressionHelper[7].Value != string.Empty )
						edit.ContentType = expressionHelper[7].Value;

					if ( expressionHelper[8].Value != string.Empty )
						edit.MethodName = expressionHelper[8].Value;

				}
				catch { }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AjaxSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AjaxSettingEdit setting = value as AjaxSettingEdit;

			return string.Format ( "{0}`;{1}`;{2}`;{3}`;{4}`;{5}`;{6}`;{7}`;{8}", setting.WidgetEventType, setting.Url, setting.DataType, setting.Form, setting.IsSingleQuote, setting.EditHelper, setting.Type, setting.ContentType, setting.MethodName );
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

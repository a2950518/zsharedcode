/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameterEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameterEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameterEditCollectionEditor
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ParameterEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " ParameterEdit "
	/// <summary>
	/// jQuery UI 的参数编辑器.
	/// </summary>
	// [DefaultProperty ( "Value" )]
	// [ToolboxData ( "<{0}:ParameterEdit />" )]
	// [ControlBuilder ( typeof ( ListItemControlBuilder ) )]
	[DefaultProperty ( "Value" )]
	[TypeConverter ( typeof ( ParameterEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ParameterEdit
		: IStateManager
	{
		private ParameterType type = ParameterType.Selector;
		private string value = string.Empty;
		private string name = string.Empty;

		/// <summary>
		/// 获取或设置参数的名称.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "参数的名称" )]
		[NotifyParentProperty ( true )]
		public string Name
		{
			get { return this.name; }
			set
			{

				if ( null != value )
					this.name = value;

			}
		}

		/// <summary>
		/// 获取或设置参数的类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( ParameterType.Selector )]
		[Description ( "参数的类型" )]
		[NotifyParentProperty ( true )]
		public ParameterType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置参数的数据.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "参数的数据" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.value; }
			set
			{

				if ( null != value )
					this.value = value;

			}
		}

		/// <summary>
		/// 创建一个 jQuery UI 参数.
		/// </summary>
		/// <returns>jQuery UI 参数</returns>
		public Parameter CreateParameter ( )
		{ return new Parameter ( this.name, this.type, this.value ); }

		/// <summary>
		/// 转换为等效字符串.
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
				this.Name = states[0] as string;

			if ( states.Count >= 2 )
				this.type = ( ParameterType ) states[1];

			if ( states.Count >= 3 )
				this.Value = states[2] as string;

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.name );
			states.Add ( this.type );
			states.Add ( this.value );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ParameterEditConverter "
	/// <summary>
	/// jQuery UI 参数编辑器的转换器.
	/// </summary>
	public sealed class ParameterEditConverter : ExpandableObjectConverter
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
			ParameterEdit edit = new ParameterEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 3 )
				try
				{
					edit.Name = expressionHelper[0].Value;
					edit.Type = ( ParameterType ) Enum.Parse ( typeof ( ParameterType ), expressionHelper[1].Value, true );
					edit.Value = expressionHelper[2].Value;
				}
				catch
				{ }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ParameterEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType );

			ParameterEdit edit = value as ParameterEdit;

			return string.Format ( "{0}`;{1}`;{2}`;", edit.Name, edit.Type, edit.Value );
		}

	}
	#endregion

	#region " ParameterEditCollectionEditor "
	/// <summary>
	/// jQuery UI 参数的集合编辑器.
	/// </summary>
	public class ParameterEditCollectionEditor : CollectionEditor
	{

		public ParameterEditCollectionEditor ( Type type )
			: base ( type )
		{ }

		protected override bool CanSelectMultipleInstances ( )
		{ return false; }

		protected override Type CreateCollectionItemType ( )
		{ return typeof ( ParameterEdit ); }

	}
	#endregion

}

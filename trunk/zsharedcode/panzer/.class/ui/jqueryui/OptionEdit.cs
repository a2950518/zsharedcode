/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOptionEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOptionEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOptionEditCollectionEditor
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
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

	#region " OptionEdit "
	/// <summary>
	/// jQuery UI 的选项编辑器.
	/// </summary>
	// [DefaultProperty ( "Value" )]
	// [ToolboxData ( "<{0}:OptionEdit />" )]
	// [ControlBuilder ( typeof ( ListItemControlBuilder ) )]
	[TypeConverter ( typeof ( OptionEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class OptionEdit
		: IStateManager
	{
		private OptionType type = OptionType.none;
		private string value = string.Empty;

		/// <summary>
		/// 获取或设置选项的类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( OptionType.none )]
		[Description ( "选项的类型" )]
		[NotifyParentProperty ( true )]
		public OptionType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置选项的数据.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "选项的数据" )]
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
		/// 创建一个 jQuery UI 选项.
		/// </summary>
		/// <returns>jQuery UI 选项.</returns>
		public Option CreateOption ( )
		{ return new Option ( this.type, this.value ); }

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
				this.type = ( OptionType ) states[0];
			
			if ( states.Count >= 2 )
				this.Value = states[1] as string;

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.type );
			states.Add ( this.value );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " OptionEditConverter "
	/// <summary>
	/// jQuery UI 选项编辑器的转换器.
	/// </summary>
	public sealed class OptionEditConverter : ExpandableObjectConverter
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
			OptionEdit edit = new OptionEdit ( );

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
				try
				{
					edit.Type = ( OptionType ) Enum.Parse ( typeof ( OptionType ), expressionHelper[0].Value, true );
					edit.Value = expressionHelper[1].Value;
				}
				catch
				{ }
			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is OptionEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType );

			OptionEdit edit = value as OptionEdit;

			return string.Format ( "{0}`;{1}", edit.Type.ToString ( ), edit.Value );
		}

	}
	#endregion

	#region " OptionEditCollectionEditor "
	/// <summary>
	/// jQuery UI 选项的集合编辑器.
	/// </summary>
	public class OptionEditCollectionEditor : CollectionEditor
	{

		public OptionEditCollectionEditor ( Type type )
			: base ( type )
		{ }

		protected override bool CanSelectMultipleInstances ( )
		{ return false; }

		protected override Type CreateCollectionItemType ( )
		{ return typeof ( OptionEdit ); }
	}
	#endregion

}

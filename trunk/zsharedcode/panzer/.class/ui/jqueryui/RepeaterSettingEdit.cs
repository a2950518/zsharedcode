/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIRepeaterSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIRepeaterSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/RepeaterSettingEdit.cs
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
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

// HACK: 避免在 allinone 文件中的名称冲突
using NParameter = zoyobar.shared.panzer.web.jqueryui.Parameter;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " RepeaterSettingEdit "
	/// <summary>
	/// jQuery UI Repeater 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( RepeaterSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class RepeaterSettingEdit
		: IStateManager
	{
		private string field = string.Empty;
		private string attribute = string.Empty;

		private readonly PlaceHolder header = new PlaceHolder ( );
		private readonly PlaceHolder footer = new PlaceHolder ( );
		private readonly PlaceHolder item = new PlaceHolder ( );
		private readonly PlaceHolder editItem = new PlaceHolder ( );
		private readonly PlaceHolder empty = new PlaceHolder ( );

		private string rowsName = "rows";

		private bool isRepeatable = false;

		/// <summary>
		/// 获取或设置字段的名称, 使用 ; 号分隔, 区分大小写.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "参加绑定的字段的名称, 使用 ; 号分隔, 区分大小写" )]
		[NotifyParentProperty ( true )]
		public string Field
		{
			get { return this.field; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.field = value;

			}
		}

		/// <summary>
		/// 获取或设置属性的名称, 使用 ; 号分隔, 区分大小写.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "参加绑定的属性的名称, 使用 ; 号分隔, 区分大小写" )]
		[NotifyParentProperty ( true )]
		public string Attribute
		{
			get { return this.attribute; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.attribute = value;

			}
		}

		/// <summary>
		/// 获取或设置 json 中行的属性名.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "rows" )]
		[Description ( "指示 json 中行的属性名" )]
		[NotifyParentProperty ( true )]
		public string RowsName
		{
			get { return this.rowsName; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.rowsName = value;

			}
		}

		/// <summary>
		/// 获取或设置是否可以使用 Repeater.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( false )]
		[Description ( "指示 Repeater 是否可用" )]
		[NotifyParentProperty ( true )]
		public bool IsRepeatable
		{
			get { return this.isRepeatable; }
			set { this.isRepeatable = value; }
		}

		/// <summary>
		/// 获取标题模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置标题模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Header
		{
			get { return this.header; }
		}

		/// <summary>
		/// 获取结尾模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置结尾模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Footer
		{
			get { return this.footer; }
		}

		/// <summary>
		/// 获取行模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置行模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Item
		{
			get { return this.item; }
		}

		/// <summary>
		/// 获取行编辑模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置行编辑模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder EditItem
		{
			get { return this.editItem; }
		}

		/// <summary>
		/// 获取空数据模板, 其中包含了 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置空数据模板" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Empty
		{
			get { return this.empty; }
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
				this.Field = states[0] as string;

			if ( states.Count >= 2 )
				this.isRepeatable = (bool) states[1];

			if ( states.Count >= 3 )
				this.RowsName = states[2] as string;

			if ( states.Count >= 4 )
				this.attribute = states[3] as string;

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.field );
			states.Add ( this.isRepeatable );
			states.Add ( this.rowsName );
			states.Add ( this.attribute );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " RepeaterSettingEditConverter "
	/// <summary>
	/// jQuery UI Repeater 设置编辑器的转换器.
	/// </summary>
	public sealed class RepeaterSettingEditConverter : ExpandableObjectConverter
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
			RepeaterSettingEdit edit = new RepeaterSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 4 )
				try
				{

					if ( expressionHelper[0].Value != string.Empty )
						edit.IsRepeatable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

					if ( expressionHelper[1].Value != string.Empty )
						edit.RowsName = expressionHelper[1].Value;

					if ( expressionHelper[2].Value != string.Empty )
						edit.Field = expressionHelper[2].Value;

					if ( expressionHelper[3].Value != string.Empty )
						edit.Attribute = expressionHelper[3].Value;

				}
				catch { }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is RepeaterSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			RepeaterSettingEdit setting = value as RepeaterSettingEdit;

			return string.Format ( "{0}`;{1}`;{2}`;{3}`;", setting.IsRepeatable, setting.RowsName, setting.Field, setting.Attribute );
		}

	}
	#endregion

}

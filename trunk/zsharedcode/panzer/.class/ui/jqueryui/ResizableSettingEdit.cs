﻿/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ResizableSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
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
		private List<OptionEdit> options = new List<OptionEdit> ( );
		private bool isResizable;

		/// <summary>
		/// 获取元素的缩放设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的缩放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.options; }
		}

		/// <summary>
		/// 获取或设置是否可以缩放.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以缩放" )]
		[NotifyParentProperty ( true )]
		public bool IsResizable
		{
			get { return this.isResizable; }
			set { this.isResizable = value; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 缩放的相关设置.
		/// </summary>
		/// <returns>jQuery UI 缩放的相关设置.</returns>
		public ResizableSetting CreateResizableSetting ( )
		{
			List<Option> options = new List<Option> ( );

			foreach ( OptionEdit edit in this.options )
				options.Add ( edit.CreateOption ( ) );

			return new ResizableSetting ( this.isResizable, options.ToArray ( ) );
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
				this.isResizable = ( bool ) states[0];

			for ( int index = 0; index < this.options.Count; index++ )
				( this.options[index] as IStateManager ).LoadViewState ( states[index + 1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isResizable );

			foreach ( OptionEdit edit in this.options )
				states.Add ( ( edit as IStateManager ).SaveViewState ( ) );

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

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.IsResizable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ResizableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ResizableSettingEdit setting = value as ResizableSettingEdit;

			return string.Format ( "{0}`;", setting.IsResizable );
		}

	}
	#endregion

}

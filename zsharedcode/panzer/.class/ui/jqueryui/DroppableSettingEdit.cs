/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDroppableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDroppableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DroppableSettingEdit.cs
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

	#region " DroppableSettingEdit "
	/// <summary>
	/// jQuery UI 拖放的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DroppableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DroppableSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isDroppable = false;

		/// <summary>
		/// 获取元素的拖放设置.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "元素相关的拖放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取或设置是否可以拖放.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以拖放" )]
		[NotifyParentProperty ( true )]
		public bool IsDroppable
		{
			get { return this.isDroppable; }
			set { this.isDroppable = value; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置拖放是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置拖放接受的目标, 对应一个函数或者选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放接受的目标, 对应一个函数或者选择器" )]
		[NotifyParentProperty ( true )]
		public string Accept
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.accept ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.accept, value ); }
		}

		/// <summary>
		/// 获取或设置拖放被激活时的样式, 对应一个函数或者选择器.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放被激活时的样式, 对应一个函数或者选择器" )]
		[NotifyParentProperty ( true )]
		public string ActiveClass 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.activeClass ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.activeClass, value ); }
		}

		/// <summary>
		/// 获取或设置是否添加样式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否添加样式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AddClasses
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.addClasses ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.addClasses, value ); }
		}

		/// <summary>
		/// 获取或设置是否阻止事件传播, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否阻止事件传播, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Greedy
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.greedy ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.greedy, value ); }
		}

		/// <summary>
		/// 获取或设置悬停样式, 比如: 'drophover'.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示悬停样式, 比如: 'drophover'" )]
		[NotifyParentProperty ( true )]
		public string HoverClass
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.hoverClass ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.hoverClass, value ); }
		}

		/// <summary>
		/// 获取或设置范围, 比如: 'default'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示范围, 比如: 'default'" )]
		[NotifyParentProperty ( true )]
		public string Scope
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scope ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scope, value ); }
		}

		/// <summary>
		/// 获取或设置拖放的触发方式, 可以是 'fit', 'intersect', 'pointer', 'touch'.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放的触发方式, 可以是 'fit', 'intersect', 'pointer', 'touch'" )]
		[NotifyParentProperty ( true )]
		public string Tolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tolerance, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置拖放被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置拖放被激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放被激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Activate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.activate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.activate, value ); }
		}

		/// <summary>
		/// 获取或设置拖放取消激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放取消激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Deactivate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.deactivate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.deactivate, value ); }
		}

		/// <summary>
		/// 获取或设置元素滑过时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑过时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Over
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.over ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.over, value ); }
		}

		/// <summary>
		/// 获取或设置元素滑出时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑出时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Out
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@out ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@out, value ); }
		}

		/// <summary>
		/// 获取或设置拖放时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.drop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.drop, value ); }
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
		/// 创建一个 jQuery UI 拖放的相关设置.
		/// </summary>
		/// <returns>jQuery UI 拖放的相关设置.</returns>
		public DroppableSetting CreateDroppableSetting ( )
		{ return new DroppableSetting ( this.isDroppable, this.editHelper.CreateOptions ( ) ); }

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
				this.isDroppable = ( bool ) states[0];

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isDroppable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DroppableSettingEditConverter "
	/// <summary>
	/// jQuery UI 拖放设置编辑器的转换器.
	/// </summary>
	public sealed class DroppableSettingEditConverter : ExpandableObjectConverter
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
			DroppableSettingEdit edit = new DroppableSettingEdit ( );

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
					edit.IsDroppable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DroppableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DroppableSettingEdit setting = value as DroppableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsDroppable, setting.EditHelper );
		}

	}
	#endregion

}

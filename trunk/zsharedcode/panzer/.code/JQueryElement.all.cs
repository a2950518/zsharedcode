/* allinone合并了多个文件,下载使用多个allinone代码,可能会遇到重复的类型定义,http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/JQueryElement.all.cs */
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Globalization;
using zoyobar.shared.panzer.code;
using System.ComponentModel.Design;
using System.Reflection;
using NControl = System.Web.UI.Control;
// ../.class/ui/jqueryui/JQueryElement.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryElement
 * http://code.google.com/p/zsharedcode/wiki/JQueryElementType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryElement.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DraggableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DroppableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SortableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SelectableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ResizableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ParameterEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/WidgetSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryCoder.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/JQueryUI.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " ElementType "
	/// <summary>
	/// 页面元素的类型.
	/// </summary>
	public enum ElementType
	{
		/// <summary>
		/// 没有任何页面元素.
		/// </summary>
		None = 0,
		/// <summary>
		/// div 元素.
		/// </summary>
		Div = 1,
		/// <summary>
		/// span 元素.
		/// </summary>
		Span = 2,
		/// <summary>
		/// p 元素.
		/// </summary>
		P = 3,
		/// <summary>
		/// ul 元素.
		/// </summary>
		Ul = 4,
		/// <summary>
		/// li 元素.
		/// </summary>
		Li = 5,
	}
	#endregion

	#region " JQueryElement "
	/// <summary>
	/// 实现 jQuery UI 的服务器控件.
	/// </summary>
	// [DefaultProperty ( "Html" )]
	[ToolboxData ( "<{0}:JQueryElement runat=server></{0}:JQueryElement>" )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public class JQueryElement
		: WebControl, INamingContainer
	{
		private ElementType elementType;

		private readonly DraggableSettingEdit draggableSetting = new DraggableSettingEdit ( );
		private readonly DroppableSettingEdit droppableSetting = new DroppableSettingEdit ( );
		private readonly SortableSettingEdit sortableSetting = new SortableSettingEdit ( );
		private readonly SelectableSettingEdit selectableSetting = new SelectableSettingEdit ( );
		private readonly ResizableSettingEdit resizableSetting = new ResizableSettingEdit ( );

		private readonly WidgetSettingEdit widgetSetting = new WidgetSettingEdit ( );

		private readonly PlaceHolder html = new PlaceHolder ( );

		/// <summary>
		/// 获取元素的拖动设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的拖动设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public DraggableSettingEdit DraggableSetting
		{
			get { return this.draggableSetting; }
		}

		/// <summary>
		/// 获取元素的拖放设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的拖放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public DroppableSettingEdit DroppableSetting
		{
			get { return this.droppableSetting; }
		}

		/// <summary>
		/// 获取元素的排列设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的排列设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public SortableSettingEdit SortableSetting
		{
			get { return this.sortableSetting; }
		}

		/// <summary>
		/// 获取元素的选中设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的选中设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public SelectableSettingEdit SelectableSetting
		{
			get { return this.selectableSetting; }
		}

		/// <summary>
		/// 获取元素的缩放设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的缩放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ResizableSettingEdit ResizableSetting
		{
			get { return this.resizableSetting; }
		}

		/// <summary>
		/// 获取元素的 Widget 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的 Widget 设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public WidgetSettingEdit WidgetSetting
		{
			get { return this.widgetSetting; }
		}

		/// <summary>
		/// 获取 PlaceHolder 控件, 其中包含了元素中包含的 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置元素中包含的 html 代码" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Html
		{
			get { return this.html; }
		}

		/// <summary>
		/// 获取或设置元素的类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "最终在页面上生成的元素类型, 比如: Span, Div, 默认为 None, 不生成任何元素" )]
		[DefaultValue ( ElementType.None )]
		public ElementType ElementType
		{
			get { return this.elementType; }
			set { this.elementType = value; }
		}

		#region " hide "

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override string AccessKey
		{
			get { return string.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Color BackColor
		{
			get { return Color.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Color BorderColor
		{
			get { return Color.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override BorderStyle BorderStyle
		{
			get { return BorderStyle.None; }
			set { }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Unit BorderWidth
		{
			get { return Unit.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override bool Enabled
		{
			get { return true; }
			set { }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override bool EnableTheming
		{
			get { return false; }
			set { }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override FontInfo Font
		{
			get { return base.Font; }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Color ForeColor
		{
			get { return Color.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override string SkinID
		{
			get { return string.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryElement 中无效.
		/// </summary>
		[Browsable ( false )]
		public override short TabIndex
		{
			get { return -1; }
			set { }
		}

		#endregion

		/// <summary>
		/// 创建一个 JQueryElement.
		/// </summary>
		public JQueryElement ( )
			: base ( )
		{ this.EnableViewState = false; }

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.Visible )
				return;

			JQueryUI jquery = new JQueryUI ( string.Format ( "'#{0}'", this.ClientID ) );

			if ( this.elementType != ElementType.None )
			{
				string style = string.Empty;

				if ( this.Width != Unit.Empty )
					style += string.Format( "width:{0};", this.Width );

				if ( this.Height != Unit.Empty )
					style += string.Format ( "height:{0};", this.Height );

				writer.Write (
					"<{0} id={1}{2}{3}{4}>",
					this.elementType.ToString ( ).ToLower ( ),
					this.ClientID,
					string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : " class=" + WebUtility.HtmlEncode ( this.CssClass ),
					string.IsNullOrEmpty ( this.ToolTip ) ? string.Empty : " title=" + WebUtility.HtmlEncode ( this.ToolTip ),
					string.IsNullOrEmpty ( style ) ? string.Empty : " style=" + WebUtility.HtmlEncode ( style )
					);
			}

			this.html.RenderControl ( writer );
			// base.Render ( writer );

			if ( this.elementType != ElementType.None )
				writer.Write ( "</{0}>", this.elementType.ToString ( ).ToLower ( ) );

			jquery.Draggable ( this.draggableSetting.CreateDraggableSetting ( ) );
			jquery.Droppable ( this.droppableSetting.CreateDroppableSetting ( ) );
			jquery.Sortable ( this.sortableSetting.CreateSortableSetting ( ) );
			jquery.Selectable ( this.selectableSetting.CreateSelectableSetting ( ) );
			jquery.Resizable ( this.resizableSetting.CreateResizableSetting ( ) );

			jquery.Widget ( this.widgetSetting.CreateWidgetSetting ( ) );

			jquery.Code = "$(function(){" + JQueryCoder.Encode ( this, jquery.Code ) + ";});";
			jquery.Build ( this, this.ClientID, ScriptBuildOption.Startup );
		}

		protected override void LoadViewState ( object savedState )
		{
			base.LoadViewState ( savedState );

			( this.draggableSetting as IStateManager ).LoadViewState ( this.ViewState["DraggableSetting"] );
			( this.droppableSetting as IStateManager ).LoadViewState ( this.ViewState["DroppableSetting"] );
			( this.sortableSetting as IStateManager ).LoadViewState ( this.ViewState["SortableSetting"] );
			( this.selectableSetting as IStateManager ).LoadViewState ( this.ViewState["SelectableSetting"] );
			( this.resizableSetting as IStateManager ).LoadViewState ( this.ViewState["ResizableSetting"] );

			( this.widgetSetting as IStateManager ).LoadViewState ( this.ViewState["WidgetSetting"] );
		}

		protected override object SaveViewState ( )
		{
			this.ViewState["DraggableSetting"] = ( this.draggableSetting as IStateManager ).SaveViewState ( );
			this.ViewState["DroppableSetting"] = ( this.droppableSetting as IStateManager ).SaveViewState ( );
			this.ViewState["SortableSetting"] = ( this.sortableSetting as IStateManager ).SaveViewState ( );
			this.ViewState["SelectableSetting"] = ( this.selectableSetting as IStateManager ).SaveViewState ( );
			this.ViewState["ResizableSetting"] = ( this.resizableSetting as IStateManager ).SaveViewState ( );

			this.ViewState["WidgetSetting"] = ( this.widgetSetting as IStateManager ).SaveViewState ( );

			return base.SaveViewState ( );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/DraggableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDraggableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDraggableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DraggableSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " DraggableSettingEdit "
	/// <summary>
	/// jQuery UI 拖动的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DraggableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DraggableSettingEdit
		: IStateManager
	{
		private List<OptionEdit> options = new List<OptionEdit> ( );
		private bool isDraggable;

		/// <summary>
		/// 获取元素的拖动设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的拖动设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.options; }
		}

		/// <summary>
		/// 获取或设置是否可以拖动.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以拖动" )]
		[NotifyParentProperty ( true )]
		public bool IsDraggable
		{
			get { return this.isDraggable; }
			set { this.isDraggable = value; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 拖动的相关设置.
		/// </summary>
		/// <returns>jQuery UI 拖动的相关设置.</returns>
		public DraggableSetting CreateDraggableSetting ( )
		{
			List<Option> options = new List<Option> ( );

			foreach ( OptionEdit edit in this.options )
				options.Add ( edit.CreateOption ( ) );

			return new DraggableSetting ( this.isDraggable, options.ToArray ( ) );
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
				this.isDraggable = ( bool ) states[0];

			for ( int index = 0; index < this.options.Count; index++ )
				( this.options[index] as IStateManager ).LoadViewState ( states[index + 1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isDraggable );

			foreach ( OptionEdit edit in this.options )
				states.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DraggableSettingEditConverter "
	/// <summary>
	/// jQuery UI 拖动设置编辑器的转换器.
	/// </summary>
	public sealed class DraggableSettingEditConverter : ExpandableObjectConverter
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
			DraggableSettingEdit edit = new DraggableSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 )
				edit.IsDraggable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DraggableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DraggableSettingEdit setting = value as DraggableSettingEdit;

			return string.Format ( "{0}`;", setting.IsDraggable );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/DroppableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDroppableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDroppableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DroppableSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



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
		private List<OptionEdit> options = new List<OptionEdit> ( );
		private bool isDroppable;

		/// <summary>
		/// 获取元素的拖放设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的拖放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.options; }
		}

		/// <summary>
		/// 获取或设置是否可以拖放.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以拖放" )]
		[NotifyParentProperty ( true )]
		public bool IsDroppable
		{
			get { return this.isDroppable; }
			set { this.isDroppable = value; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 拖放的相关设置.
		/// </summary>
		/// <returns>jQuery UI 拖放的相关设置.</returns>
		public DroppableSetting CreateDroppableSetting ( )
		{
			List<Option> options = new List<Option> ( );

			foreach ( OptionEdit edit in this.options )
				options.Add ( edit.CreateOption ( ) );

			return new DroppableSetting ( this.isDroppable, options.ToArray ( ) );
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
				this.isDroppable = ( bool ) states[0];

			for ( int index = 0; index < this.options.Count; index++ )
				( this.options[index] as IStateManager ).LoadViewState ( states[index + 1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isDroppable );

			foreach ( OptionEdit edit in this.options )
				states.Add ( ( edit as IStateManager ).SaveViewState ( ) );

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

			if ( expressionHelper.ChildCount == 1 )
				edit.IsDroppable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DroppableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DroppableSettingEdit setting = value as DroppableSettingEdit;

			return string.Format ( "{0}`;", setting.IsDroppable );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/ResizableSettingEdit.cs
/*
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

			if ( expressionHelper.ChildCount == 1 )
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
// ../.class/ui/jqueryui/SelectableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISelectableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISelectableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SelectableSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



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
		private List<OptionEdit> options = new List<OptionEdit> ( );
		private bool isSelectable;

		/// <summary>
		/// 获取元素的选中设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的选中设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.options; }
		}

		/// <summary>
		/// 获取或设置是否可以选中.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以选中" )]
		[NotifyParentProperty ( true )]
		public bool IsSelectable
		{
			get { return this.isSelectable; }
			set { this.isSelectable = value; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 选中的相关设置.
		/// </summary>
		/// <returns>jQuery UI 选中的相关设置.</returns>
		public SelectableSetting CreateSelectableSetting ( )
		{
			List<Option> options = new List<Option> ( );

			foreach ( OptionEdit edit in this.options )
				options.Add ( edit.CreateOption ( ) );

			return new SelectableSetting ( this.isSelectable, options.ToArray ( ) );
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
				this.isSelectable = ( bool ) states[0];

			for ( int index = 0; index < this.options.Count; index++ )
				( this.options[index] as IStateManager ).LoadViewState ( states[index + 1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isSelectable );

			foreach ( OptionEdit edit in this.options )
				states.Add ( ( edit as IStateManager ).SaveViewState ( ) );

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

			if ( expressionHelper.ChildCount == 1 )
				edit.IsSelectable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SelectableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SelectableSettingEdit setting = value as SelectableSettingEdit;

			return string.Format ( "{0}`;", setting.IsSelectable );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/SortableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISortableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISortableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SortableSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " SortableSettingEdit "
	/// <summary>
	/// jQuery UI 排列的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( SortableSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class SortableSettingEdit
		: IStateManager
	{
		private List<OptionEdit> options = new List<OptionEdit> ( );
		private bool isSortable;

		/// <summary>
		/// 获取元素的排列设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的排列设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.options; }
		}

		/// <summary>
		/// 获取或设置是否可以排列.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( false )]
		[Description ( "指示元素是否可以排列" )]
		[NotifyParentProperty ( true )]
		public bool IsSortable
		{
			get { return this.isSortable; }
			set { this.isSortable = value; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 排列的相关设置.
		/// </summary>
		/// <returns>jQuery UI 排列的相关设置.</returns>
		public SortableSetting CreateSortableSetting ( )
		{
			List<Option> options = new List<Option> ( );

			foreach ( OptionEdit edit in this.options )
				options.Add ( edit.CreateOption ( ) );

			return new SortableSetting ( this.isSortable, options.ToArray ( ) );
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
				this.isSortable = ( bool ) states[0];

			for ( int index = 0; index < this.options.Count; index++ )
				( this.options[index] as IStateManager ).LoadViewState ( states[index + 1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isSortable );

			foreach ( OptionEdit edit in this.options )
				states.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " SortableSettingEditConverter "
	/// <summary>
	/// jQuery UI 排列设置编辑器的转换器.
	/// </summary>
	public sealed class SortableSettingEditConverter : ExpandableObjectConverter
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
			SortableSettingEdit edit = new SortableSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 )
				edit.IsSortable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SortableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SortableSettingEdit setting = value as SortableSettingEdit;

			return string.Format ( "{0}`;", setting.IsSortable );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/OptionEdit.cs
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



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " OptionEdit "
	/// <summary>
	/// jQuery UI 的选项编辑器.
	/// </summary>
	// [DefaultProperty ( "Value" )]
	// [ToolboxData ( "<{0}:OptionEdit />" )]
	// [ControlBuilder ( typeof ( ListItemControlBuilder ) )]
	[DefaultProperty ( "Value" )]
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
				try
				{
					edit.Type = ( OptionType ) Enum.Parse ( typeof ( OptionType ), expressionHelper[0].Value, true );
					edit.Value = expressionHelper[1].Value;
				}
				catch
				{ }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is OptionEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType );

			OptionEdit edit = value as OptionEdit;

			return string.Format ( "{0}`;{1}`;", edit.Type, edit.Value );
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
// ../.class/ui/jqueryui/EventEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEventEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEventEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEventEditCollectionEditor
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " EventEdit "
	/// <summary>
	/// jQuery UI 的事件编辑器.
	/// </summary>
	// [DefaultProperty ( "Value" )]
	// [ToolboxData ( "<{0}:EventEdit />" )]
	// [ControlBuilder ( typeof ( ListItemControlBuilder ) )]
	[DefaultProperty ( "Value" )]
	[TypeConverter ( typeof ( EventEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class EventEdit
		: IStateManager
	{
		private EventType type = EventType.None;
		private string value = string.Empty;

		/// <summary>
		/// 获取或设置事件的类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( EventType.None )]
		[Description ( "事件的类型" )]
		[NotifyParentProperty ( true )]
		public EventType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置事件的内容.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "事件的内容" )]
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
		/// 创建一个 jQuery UI 事件.
		/// </summary>
		/// <returns>jQuery UI 事件.</returns>
		public Event CreateEvent ( )
		{ return new Event ( this.type, this.value ); }

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
				this.type = ( EventType ) states[0];

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

	#region " EventEditConverter "
	/// <summary>
	/// jQuery UI 选项编辑器的转换器.
	/// </summary>
	public sealed class EventEditConverter : ExpandableObjectConverter
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
			EventEdit edit = new EventEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 2 )
				try
				{
					edit.Type = ( EventType ) Enum.Parse ( typeof ( EventType ), expressionHelper[0].Value, true );
					edit.Value = expressionHelper[1].Value;
				}
				catch
				{ }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is EventEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType );

			EventEdit edit = value as EventEdit;

			return string.Format ( "{0}`;{1}`;", edit.Type.ToString ( ), edit.Value );
		}

	}
	#endregion

	#region " EventEditCollectionEditor "
	/// <summary>
	/// jQuery UI 选项的集合编辑器.
	/// </summary>
	public class EventEditCollectionEditor : CollectionEditor
	{

		public EventEditCollectionEditor ( Type type )
			: base ( type )
		{ }

		protected override bool CanSelectMultipleInstances ( )
		{ return false; }

		protected override Type CreateCollectionItemType ( )
		{ return typeof ( EventEdit ); }

	}
	#endregion

}
// ../.class/ui/jqueryui/ParameterEdit.cs
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
// ../.class/ui/jqueryui/AjaxSettingEdit.cs
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
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.events; }
		}

		/// <summary>
		/// 获取或设置和 Widget 相关的触发事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( EventType.None )]
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
		[UrlProperty()]
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
		[DefaultValue ( DataType.JSon )]
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

			List<Parameter> parameters = new List<Parameter> ( );

			foreach ( ParameterEdit edit in this.parameters )
				parameters.Add ( edit.CreateParameter ( ) );

			return new AjaxSetting ( this.widgetEventType, this.url, this.dataType, this.form, parameters.ToArray(), events.ToArray ( ), this.isSingleQuote );
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
					edit.WidgetEventType = ( EventType ) Enum.Parse ( typeof ( EventType ), expressionHelper[0].Value );
					edit.Url = expressionHelper[1].Value;
					edit.DataType = ( DataType ) Enum.Parse ( typeof ( DataType ), expressionHelper[2].Value );
					edit.Form = expressionHelper[3].Value;
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
// ../.class/ui/jqueryui/WidgetSettingEdit.cs
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
		private WidgetType type;

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
		[DefaultValue ( false )]
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

			if ( expressionHelper.ChildCount == 1 )
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
// ../.class/ui/jqueryui/JQueryScript.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryScript
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryScript.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " JQueryScript "
	/// <summary>
	/// 实现 jQuery UI 的服务器控件.
	/// </summary>
	// [DefaultProperty ( "Html" )]
	[ToolboxData ( "<{0}:JQueryScript runat=server></{0}:JQueryScript>" )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public class JQueryScript
		: WebControl, INamingContainer
	{

		private readonly PlaceHolder html = new PlaceHolder ( );

		/// <summary>
		/// 获取 PlaceHolder 控件, 其中包含了元素中包含的 script 标签的代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置元素中包含的 script 标签的代码" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Html
		{
			get { return this.html; }
		}

		#region " hide "

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override string AccessKey
		{
			get { return string.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Color BackColor
		{
			get { return Color.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Color BorderColor
		{
			get { return Color.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override BorderStyle BorderStyle
		{
			get { return BorderStyle.None; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Unit BorderWidth
		{
			get { return Unit.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override bool Enabled
		{
			get { return true; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override bool EnableTheming
		{
			get { return false; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override FontInfo Font
		{
			get { return base.Font; }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override Color ForeColor
		{
			get { return Color.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override string SkinID
		{
			get { return string.Empty; }
			set { }
		}

		/// <summary>
		/// 在 JQueryScript 中无效.
		/// </summary>
		[Browsable ( false )]
		public override short TabIndex
		{
			get { return -1; }
			set { }
		}

		#endregion

		/// <summary>
		/// 创建一个 JQueryScript.
		/// </summary>
		public JQueryScript ( )
			: base ( )
		{ this.EnableViewState = false; }

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.Visible || this.html.Controls.Count != 1)
				return;

			LiteralControl literal = this.html.Controls[0] as LiteralControl;

			if ( null == literal )
				return;

			literal.Text = JQueryCoder.Encode ( this, literal.Text );

			this.html.RenderControl ( writer );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/JQueryCoder.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryCoder
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryCoder.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 为 JQueryElement 以及相关控件中的内嵌语法执行操作.
	/// </summary>
	public sealed class JQueryCoder
	{

		/// <summary>
		/// 编码内嵌语法.
		/// </summary>
		/// <param name="control">控件.</param>
		/// <param name="code">包含内嵌语法的代码.</param>
		/// <returns>编码后的代码.</returns>
		public static string Encode ( Control control, string code )
		{

			if ( string.IsNullOrEmpty ( code ) || null == control || null == control.Page )
				return string.Empty;

			int beginIndex;
			int endIndex;

			while ( true )
			{
				endIndex = code.IndexOf ( "%]" );

				if ( endIndex == -1 )
					break;

				beginIndex = code.LastIndexOf ( "[%", endIndex );

				if ( beginIndex == -1 )
					break;

				string expression = code.Substring ( beginIndex, endIndex - beginIndex + 2 );

				string command = expression.Replace ( "[%", string.Empty ).Replace ( "%]", string.Empty ).Trim();

				beginIndex = command.IndexOf(':');

				if(beginIndex <= 0 || beginIndex == command.Length - 1)
					break;

				string commandName = command.Substring ( 0, beginIndex ).Trim ( ).ToLower();
				string commandParameter = command.Substring ( beginIndex + 1 ).Trim ( );

				if ( commandName == string.Empty || commandParameter == string.Empty )
					break;

				string result = string.Empty;

				switch ( commandName )
				{
					case "id":
						Control aimControl = control.Page.FindControl ( commandParameter );

						if ( null != aimControl )
							result = aimControl.ClientID;

						break;

					case "fun":
						MethodInfo methodInfo;
						Control currentControl = control;

						while ( true )
						{
							methodInfo = currentControl.GetType ( ).GetMethod ( commandParameter, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic );

							if ( null != methodInfo || null == currentControl.Parent )
								break;

							currentControl = currentControl.Parent;
						}

						if ( null != methodInfo )
							if ( methodInfo.IsStatic )
								result = methodInfo.Invoke ( null, null ) as string;
							else
								result = methodInfo.Invoke ( currentControl, null ) as string;

						if ( null == result )
							result = string.Empty;

						break;
				}

				code = code.Replace ( expression, result );
			}

			return code;
		}

	}

}
// ../.class/web/jqueryui/DraggableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIDraggableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DraggableSetting "
	/// <summary>
	/// jQuery UI 拖动的相关设置.
	/// </summary>
	public sealed class DraggableSetting
	{
		/// <summary>
		/// 拖动相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以拖动.
		/// </summary>
		public readonly bool IsDraggable;

		/// <summary>
		/// 创建 jQuery UI 拖动的相关设置.
		/// </summary>
		/// <param name="isDraggable">是否可以拖动.</param>
		/// <param name="options">拖动相关选项.</param>
		public DraggableSetting ( bool isDraggable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsDraggable = isDraggable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/DroppableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIDroppableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DroppableSetting "
	/// <summary>
	/// jQuery UI 拖放的相关设置.
	/// </summary>
	public sealed class DroppableSetting
	{
		/// <summary>
		/// 拖放相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以拖放.
		/// </summary>
		public readonly bool IsDroppable;

		/// <summary>
		/// 创建 jQuery UI 拖放的相关设置.
		/// </summary>
		/// <param name="isDroppable">是否可以拖放.</param>
		/// <param name="options">拖放相关选项.</param>
		public DroppableSetting ( bool isDroppable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsDroppable = isDroppable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/ResizableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ResizableSetting "
	/// <summary>
	/// jQuery UI 缩放的相关设置.
	/// </summary>
	public sealed class ResizableSetting
	{
		/// <summary>
		/// 缩放相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以缩放.
		/// </summary>
		public readonly bool IsResizable;

		/// <summary>
		/// 创建 jQuery UI 缩放的相关设置.
		/// </summary>
		/// <param name="isResizable">是否可以缩放.</param>
		/// <param name="options">缩放相关选项.</param>
		public ResizableSetting ( bool isResizable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsResizable = isResizable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/SelectableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUISelectableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " SelectableSetting "
	/// <summary>
	/// jQuery UI 选中的相关设置.
	/// </summary>
	public sealed class SelectableSetting
	{
		/// <summary>
		/// 选中相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以选中.
		/// </summary>
		public readonly bool IsSelectable;

		/// <summary>
		/// 创建 jQuery UI 选中的相关设置.
		/// </summary>
		/// <param name="isSelectable">是否可以选中.</param>
		/// <param name="options">选中相关选项.</param>
		public SelectableSetting ( bool isSelectable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsSelectable = isSelectable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/SortableSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUISortableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " SortableSetting "
	/// <summary>
	/// jQuery UI 排列的相关设置.
	/// </summary>
	public sealed class SortableSetting
	{
		/// <summary>
		/// 排列相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以排列.
		/// </summary>
		public readonly bool IsSortable;

		/// <summary>
		/// 创建 jQuery UI 排列的相关设置.
		/// </summary>
		/// <param name="isSortable">是否可以排列.</param>
		/// <param name="options">排列相关选项.</param>
		public SortableSetting ( bool isSortable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsSortable = isSortable;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/ExpressionHelper.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/ExpressionHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ExpressionHelper "
	/// <summary>
	/// jQuery UI 的 ViewState 数据转换辅助类.
	/// </summary>
	public sealed class ExpressionHelper
	{
		private readonly List<ExpressionHelper> childExpressionHelpers = new List<ExpressionHelper> ( );

		private readonly string value = string.Empty;
		private readonly string name = string.Empty;

		/// <summary>
		/// 子数据转换辅助类.
		/// </summary>
		public List<ExpressionHelper> ChildExpressionHelpers
		{
			get { return this.childExpressionHelpers; }
		}

		/// <summary>
		/// 获取数据项名称.
		/// </summary>
		public string Name
		{
			get { return this.name; }
		}

		/// <summary>
		/// 获取数据项值.
		/// </summary>
		public string Value
		{
			get { return this.value; }
		}

		/// <summary>
		/// 获取是否有子数据.
		/// </summary>
		public bool IsHasChild
		{
			get { return this.ChildCount != 0; }
		}

		/// <summary>
		/// 获取子数据数量.
		/// </summary>
		public int ChildCount
		{
			get { return this.childExpressionHelpers.Count; }
		}

		/// <summary>
		/// 获取子数据的辅助类.
		/// </summary>
		/// <param name="index">子数据的索引.</param>
		/// <returns>子数据的辅助类.</returns>
		public ExpressionHelper this[int index]
		{
			get
			{

				if ( index < 0 || index >= this.ChildCount )
					return null;

				return this.childExpressionHelpers[index];
			}
		}

		/// <summary>
		/// 创建一个 jQuery UI 的 ViewState 数据转换辅助类.
		/// </summary>
		/// <param name="expression">数据字符串.</param>
		public ExpressionHelper ( string expression )
		{

			if ( null == expression )
				throw new ArgumentNullException ( "expression", "表达式不能为空" );

			expression = expression.Trim ( );

			if ( expression.Contains ( "`;" ) )
				foreach ( string part in expression.Split ( new string[] { "`;" }, StringSplitOptions.RemoveEmptyEntries ) )
					this.childExpressionHelpers.Add ( new ExpressionHelper ( part ) );
			else if ( expression.StartsWith ( "`|" ) && expression.EndsWith ( "|`" ) )
			{
				expression = expression.Trim ( '`' ).Trim ( '|' );

				foreach ( string part in expression.Split ( new string[] { "`," }, StringSplitOptions.RemoveEmptyEntries ) )
					this.childExpressionHelpers.Add ( new ExpressionHelper ( part ) );

			}
			else if ( expression.Contains ( "`:" ) )
			{
				string[] parts = expression.Split ( new string[] { "`:" }, StringSplitOptions.RemoveEmptyEntries );

				this.name = parts[0].Trim ( );
				this.value = parts[1].Trim ( );
			}
			else
				this.value = expression;


		}

	}
	#endregion

}
// ../.class/web/jqueryui/JQueryUI.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUI
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/JQueryUI.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " JQueryUI "
	/// <summary>
	/// jQuery UI 辅助类.
	/// </summary>
	public sealed class JQueryUI
		: JQuery
	{

		private static string makeOptionExpression ( List<Option> options )
		{

			if ( null == options || options.Count == 0 )
				return string.Empty;

			string optionExpression = "{";

			foreach ( Option option in options )
				if ( null != option )
					optionExpression += string.Format ( " {0}: {1},", option.Type, option.Value );

			return optionExpression.TrimEnd ( ',' ) + " }";
		}

		private static string makeParameterExpression ( List<Parameter> parameters )
		{

			if ( null == parameters || parameters.Count == 0 )
				return string.Empty;

			string parameterExpression = "{";

			foreach ( Parameter parameter in parameters )
				if ( null != parameter )
					switch ( parameter.Type )
					{
						case ParameterType.Selector:
							parameterExpression += string.Format ( " {0}: {1},", parameter.Name, JQuery.Create ( parameter.Value ).Val ( ).Code );
							break;

						case ParameterType.Expression:
							parameterExpression += string.Format ( " {0}: {1},", parameter.Name, parameter.Value );
							break;
					}

			return parameterExpression.TrimEnd ( ',' ) + " }";
		}

		#region " 构造 "

		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery UI 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( JQueryUI jQuery )
		{ return new JQueryUI ( jQuery ); }

		/// <summary>
		/// 创建使用别名的空的 JQuery UI.
		/// </summary>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( )
		{ return Create ( null, null, true ); }
		/// <summary>
		/// 创建空的 JQuery UI.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( bool isAlias )
		{ return Create ( null, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( string expressionI )
		{ return Create ( expressionI, null, true ); }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( string expressionI, bool isAlias )
		{ return Create ( expressionI, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( string expressionI, string expressionII )
		{ return Create ( expressionI, expressionII, true ); }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( string expressionI, string expressionII, bool isAlias )
		{ return new JQueryUI ( expressionI, expressionII, isAlias ); }

		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( bool isInstance, bool isAlias )
		{ return new JQueryUI ( isInstance, isAlias ); }


		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery UI 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		public JQueryUI ( JQueryUI jQuery )
			: base ( jQuery )
		{ }

		/// <summary>
		/// 创建使用别名的空的 JQuery UI.
		/// </summary>
		public JQueryUI ( )
			: this ( null, null, true )
		{ }
		/// <summary>
		/// 创建空的 JQuery UI.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( bool isAlias )
			: this ( null, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		public JQueryUI ( string expressionI )
			: this ( expressionI, null, true )
		{ }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( string expressionI, bool isAlias )
			: this ( expressionI, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		public JQueryUI ( string expressionI, string expressionII )
			: this ( expressionI, expressionII, true )
		{ }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( string expressionI, string expressionII, bool isAlias )
			: base ( expressionI, expressionII, isAlias )
		{ }

		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( bool isInstance, bool isAlias )
			: base ( isInstance, isAlias )
		{ }

		#endregion

		/// <summary>
		/// 拖动操作.
		/// </summary>
		/// <param name="setting">拖动的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Draggable ( DraggableSetting setting )
		{

			if ( null == setting || !setting.IsDraggable )
				return this;

			return this.Execute ( "draggable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// 拖放操作.
		/// </summary>
		/// <param name="setting">拖放的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Droppable ( DroppableSetting setting )
		{

			if ( null == setting || !setting.IsDroppable )
				return this;

			return this.Execute ( "droppable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// 排列操作.
		/// </summary>
		/// <param name="setting">排列的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Sortable ( SortableSetting setting )
		{

			if ( null == setting || !setting.IsSortable )
				return this;

			return this.Execute ( "sortable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// 选中操作.
		/// </summary>
		/// <param name="setting">选中的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Selectable ( SelectableSetting setting )
		{

			if ( null == setting || !setting.IsSelectable )
				return this;

			return this.Execute ( "selectable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// 缩放操作.
		/// </summary>
		/// <param name="setting">缩放的相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Resizable ( ResizableSetting setting )
		{

			if ( null == setting || !setting.IsResizable )
				return this;

			return this.Execute ( "resizable", makeOptionExpression ( setting.Options ) ) as JQueryUI;
		}

		/// <summary>
		/// Widget 操作.
		/// </summary>
		/// <param name="setting">Widget 相关设置.</param>
		/// <returns>更新后的 JQueryUI 对象.</returns>
		public JQueryUI Widget ( WidgetSetting setting )
		{

			if ( null == setting || setting.WidgetType == WidgetType.None )
				return this;

			this.Execute ( setting.WidgetType.ToString ( ).ToLower ( ), makeOptionExpression ( setting.Options ) );

			foreach ( Event @event in setting.Events )
				this.Execute ( @event.Type.ToString ( ).ToLower ( ), @event.Value );

			foreach ( AjaxSetting ajaxSetting in setting.AjaxSettings )
			{

				if ( ajaxSetting.WidgetEventType == EventType.None )
					continue;

				string quote;

				if ( ajaxSetting.IsSingleQuote )
					quote = "'";
				else
					quote = "\"";

				string data;

				if ( string.IsNullOrEmpty ( ajaxSetting.Form ) )
					data = makeParameterExpression ( ajaxSetting.Parameters );
				else
					data = JQuery.Create ( ajaxSetting.Form ).Serialize ( ).Code;

				JQuery jQuery = JQuery.Create ( false, true );
				string map = string.Format ( "url: {0}{1}{0}, dataType: {0}{2}{0}, data: {3}", quote, ajaxSetting.Url, ajaxSetting.DataType.ToString ( ).ToLower ( ), data );

				foreach ( Event @event in ajaxSetting.Events )
					map += ", " + @event.Type.ToString ( ).ToLower ( ) + ": " + @event.Value;

				jQuery.Ajax ( "{" + map + "}" );

				this.Execute ( ajaxSetting.WidgetEventType.ToString ( ).ToLower ( ), "function(e){" + jQuery.Code + "}" );
			}

			return this;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/Option.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOption
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOptionType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " OptionType "
	/// <summary>
	/// jQuery UI 的选项类型.
	/// </summary>
	public enum OptionType
	{
		/// <summary>
		/// 空的选项.
		/// </summary>
		none = 0,

		/// <summary>
		/// 禁用, 对应一个 javascript 布尔值.
		/// </summary>
		disabled = 1,

		/// <summary>
		/// 是否添加默认样式, 对应一个 javascript 布尔值.
		/// </summary>
		addClasses = 2,

		/// <summary>
		/// 追加位置, 对应一个 javascript 元素或者选择器.
		/// </summary>
		appendTo = 3,

		/// <summary>
		/// 指定 x/y 轴, 对应一个 javascript 字符串, 'x' 或者 'y'.
		/// </summary>
		axis = 4,

		/// <summary>
		/// 在符合选择器的元素上取消操作, 对应选择器.
		/// </summary>
		cancel = 5,

		/// <summary>
		/// 关联符合选择器的排序, 对应选择器.
		/// </summary>
		connectToSortable = 6,

		/// <summary>
		/// 操作所在的容器, 对应选择器, javascript 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		containment = 7,

		/// <summary>
		/// 鼠标样式, 对应一个 javascript 字符串.
		/// </summary>
		cursor = 8,

		/// <summary>
		/// 鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性.
		/// </summary>
		cursorAt = 9,

		/// <summary>
		/// 以毫秒计算的延迟, 对应一个 javascript 数值.
		/// </summary>
		delay = 10,

		/// <summary>
		/// 距离, 对应一个 javascript 数值.
		/// </summary>
		distance = 11,

		/// <summary>
		/// 表格, 对应一个 javascript 数组, [10, 20].
		/// </summary>
		grid = 12,

		/// <summary>
		/// 限制或者相关的句柄, 对应一个 javascript 元素或者选择器.
		/// </summary>
		handle = 13,

		/// <summary>
		/// 行为方式, 对应一个 javascript 字符串或者返回字符串的函数, 'original' 针对元素本身, 'clone' 针对元素的副本.
		/// </summary>
		helper = 14,

		/// <summary>
		/// 是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器.
		/// </summary>
		iframeFix = 15,

		/// <summary>
		/// 透明度, 对应一个 javascript 数值, 0 到 1 之间.
		/// </summary>
		opacity = 16,

		/// <summary>
		/// 刷新位置, 对应一个 javascript 布尔值.
		/// </summary>
		refreshPositions = 17,

		/// <summary>
		/// 恢复原始状态, 对应一个 javascript 布尔值.
		/// </summary>
		revert = 18,

		/// <summary>
		/// 恢复原始状态的延迟, 以毫秒计算, 对应一个 javascript 数值.
		/// </summary>
		revertDuration = 19,

		/// <summary>
		/// 使用范围, 将各种操作功能关联, 对应一个 javascript 字符串.
		/// </summary>
		scope = 20,

		/// <summary>
		/// 使用滚动轴, 对应一个 javascript 布尔值.
		/// </summary>
		scroll = 21,

		/// <summary>
		/// 滚动轴灵敏度, 对应一个 javascript 数值.
		/// </summary>
		scrollSensitivity = 22,

		/// <summary>
		/// 滚动轴速度, 对应一个 javascript 数值.
		/// </summary>
		scrollSpeed = 23,

		/// <summary>
		/// 附着, 对应一个 javascript 布尔值或选择器.
		/// </summary>
		snap = 24,

		/// <summary>
		/// 附着模式, 对应一个 javascript 字符串, 可以是 'inner', 'outer', 'both'.
		/// </summary>
		snapMode = 25,

		/// <summary>
		/// 附着距离, 对应一个 javascript 数值.
		/// </summary>
		snapTolerance = 26,

		/// <summary>
		/// 控制 z 轴顺序, 对应一个选择器.
		/// </summary>
		stack = 27,

		/// <summary>
		/// z 轴顺序, 对应一个 javascript 数值.
		/// </summary>
		zIndex = 28,

		/// <summary>
		/// 被创建时, 对应一个 javascript 函数.
		/// </summary>
		create = 29,

		/// <summary>
		/// 动作开始时, 对应一个 javascript 函数.
		/// </summary>
		start = 30,

		/// <summary>
		/// 拖动时, 对应一个 javascript 函数.
		/// </summary>
		drag = 31,

		/// <summary>
		/// 动作停止时, 对应一个 javascript 函数.
		/// </summary>
		stop = 32,

		/// <summary>
		/// 动作接受的目标, 对应一个 javascript 函数或者选择器.
		/// </summary>
		accept = 33,

		/// <summary>
		/// 提供可用时的样式, 对应一个 javascript 字符串.
		/// </summary>
		activeClass = 34,

		/// <summary>
		/// 阻止事件的传播, 对应一个 javascript 布尔值.
		/// </summary>
		greedy = 35,

		/// <summary>
		/// 提供悬浮样式, 对应一个 javascript 字符串.
		/// </summary>
		hoverClass = 36,

		/// <summary>
		/// 接触的模式, 对应一个 javascript 字符串, 为 'fit', 'intersect', 'pointer', 'touch' 中的一种.
		/// </summary>
		tolerance = 37,

		/// <summary>
		/// 被激活时, 对应一个 javascript 函数.
		/// </summary>
		activate = 38,

		/// <summary>
		/// 取消激活时, 对应一个 javascript 函数.
		/// </summary>
		deactivate = 39,

		/// <summary>
		/// 在元素上时, 对应一个 javascript 函数.
		/// </summary>
		over = 40,

		/// <summary>
		/// 在元素之外时, 对应一个 javascript 函数.
		/// </summary>
		@out = 41,

		/// <summary>
		/// 元素放下时, 对应一个 javascript 函数.
		/// </summary>
		drop = 42,

		/// <summary>
		/// 关联的元素, 对应一个选择器.
		/// </summary>
		connectWith = 43,

		/// <summary>
		/// 是否允许拖放目标为空, 对应一个 javascript 布尔值.
		/// </summary>
		dropOnEmpty = 44,

		/// <summary>
		/// 强制 helper 拥有尺寸, 对应一个 javascript 布尔值.
		/// </summary>
		forceHelperSize = 45,

		/// <summary>
		/// 强制 placeholder 拥有尺寸, 对应一个 javascript 布尔值.
		/// </summary>
		forcePlaceholderSize = 46,

		/// <summary>
		/// 针对的条目, 对应一个选择器.
		/// </summary>
		items = 47,

		/// <summary>
		/// 应用于空白的样式, 对应一个 javascript 字符串.
		/// </summary>
		placeholder = 48,

		/// <summary>
		/// 排序时, 对应一个 javascript 函数.
		/// </summary>
		sort = 49,

		/// <summary>
		/// 改变时, 对应一个 javascript 函数.
		/// </summary>
		change = 50,

		/// <summary>
		/// 动作停止之前, 对应一个 javascript 函数.
		/// </summary>
		beforeStop = 51,

		/// <summary>
		/// 更新后, 对应一个 javascript 函数.
		/// </summary>
		update = 52,

		/// <summary>
		/// 接收时, 对应一个 javascript 函数.
		/// </summary>
		receive = 53,

		/// <summary>
		/// 移除后, 对应一个 javascript 函数.
		/// </summary>
		remove = 54,

		/// <summary>
		/// 自动刷新, 对应一个 javascript 布尔值.
		/// </summary>
		autoRefresh = 55,

		/// <summary>
		/// 对目标的过滤, 对应选择器.
		/// </summary>
		filter = 56,

		/// <summary>
		/// 选择后, 对应一个 javascript 函数.
		/// </summary>
		selected = 57,

		/// <summary>
		/// 选择时, 对应一个 javascript 函数.
		/// </summary>
		selecting = 58,

		/// <summary>
		/// 取消选择后, 对应一个 javascript 函数.
		/// </summary>
		unselected = 59,

		/// <summary>
		/// 取消选择时, 对应一个 javascript 函数.
		/// </summary>
		unselecting = 60,
	}
	#endregion

	#region " Option "
	/// <summary>
	/// jQuery UI 的选项.
	/// </summary>
	public sealed class Option
	{
		/// <summary>
		/// 选项类型.
		/// </summary>
		public readonly OptionType Type;
		/// <summary>
		/// 选项值.
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// 创建一个 jQuery UI 选项.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">选项值.</param>
		public Option ( OptionType type, string value )
		{

			if ( null == value )
				value = string.Empty;

			this.Type = type;
			this.Value = value;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/Event.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEvent
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEventType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " EventType "
	/// <summary>
	/// jQuery UI 的事件类型.
	/// </summary>
	public enum EventType
	{
		/// <summary>
		/// 没有任何事件.
		/// </summary>
		None = 0,
		/// <summary>
		/// 完成时.
		/// </summary>
		Complete = 1,
		/// <summary>
		/// 出错时.
		/// </summary>
		Error = 2,
		/// <summary>
		/// 成功时.
		/// </summary>
		Success = 3,
		/// <summary>
		/// 点击时.
		/// </summary>
		Click = 4,
	}
	#endregion

	#region " Event "
	/// <summary>
	/// jQuery UI 的事件.
	/// </summary>
	public sealed class Event
	{
		/// <summary>
		/// 事件类型.
		/// </summary>
		public readonly EventType Type;
		/// <summary>
		/// 事件内容.
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// 创建一个 jQuery UI 事件.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <param name="value">事件内容.</param>
		public Event ( EventType type, string value )
		{

			if ( null == value )
				value = string.Empty;

			this.Type = type;
			this.Value = value;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/Parameter.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameterType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ParameterType "
	/// <summary>
	/// jQuery UI 的参数类型.
	/// </summary>
	public enum ParameterType
	{
		/// <summary>
		/// 表达式.
		/// </summary>
		Expression = 1,
		/// <summary>
		/// 选择器.
		/// </summary>
		Selector = 2,
	}
	#endregion

	#region " Parameter "
	/// <summary>
	/// jQuery UI 的参数.
	/// </summary>
	public sealed class Parameter
	{
		/// <summary>
		/// 参数名称.
		/// </summary>
		public readonly string Name;
		/// <summary>
		/// 参数类型.
		/// </summary>
		public readonly ParameterType Type;
		/// <summary>
		/// 参数值.
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// 创建一个 jQuery UI 参数.
		/// </summary>
		/// <param name="name">参数名称.</param>
		/// <param name="type">参数类型.</param>
		/// <param name="value">参数值.</param>
		public Parameter ( string name, ParameterType type, string value )
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", "参数名称不能为空" );

			if ( null == value )
				value = string.Empty;

			this.Name = name;
			this.Type = type;
			this.Value = value;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/AjaxSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DataType "
	/// <summary>
	/// Ajax 获取的数据类型.
	/// </summary>
	public enum DataType
	{
		/// <summary>
		/// json 数据.
		/// </summary>
		JSon = 1,
		/// <summary>
		/// 脚本代码.
		/// </summary>
		Script = 2,
		/// <summary>
		/// xml 数据.
		/// </summary>
		Xml = 3,
		/// <summary>
		/// html 代码.
		/// </summary>
		Html = 4,
	}
	#endregion

	#region " AjaxSetting "
	/// <summary>
	/// jQuery UI Ajax 设置.
	/// </summary>
	public sealed class AjaxSetting
	{
		/// <summary>
		/// Ajax 相关事件.
		/// </summary>
		public readonly List<Event> Events = new List<Event> ( );
		/// <summary>
		/// 和 Widget 相关的触发事件.
		/// </summary>
		public readonly EventType WidgetEventType;
		/// <summary>
		/// 请求的地址.
		/// </summary>
		public readonly string Url;
		/// <summary>
		/// 获取的数据类型.
		/// </summary>
		public readonly DataType DataType;
		/// <summary>
		/// 用作传递参数的表单.
		/// </summary>
		public readonly string Form;
		/// <summary>
		/// 用作传递的参数.
		/// </summary>
		public readonly List<Parameter> Parameters = new List<Parameter> ( );
		/// <summary>
		/// 是否为字符串使用单引号.
		/// </summary>
		public readonly bool IsSingleQuote;

		/// <summary>
		/// 创建 jQuery UI Ajax 设置.
		/// </summary>
		/// <param name="widgetEventType">和 Widget 相关的触发事件.</param>
		/// <param name="url">请求的地址, 比如: "''".</param>
		/// <param name="dataType">获取的数据类型.</param>
		/// <param name="form">用作传递参数的表单.</param>
		/// <param name="parameters">用作传递的参数, 如果指定了 form 参数, 则忽略 parameters.</param>
		/// <param name="events">Ajax 相关事件.</param>
		/// <param name="isSingleQuote">是否为字符串使用单引号.</param>
		public AjaxSetting ( EventType widgetEventType, string url, DataType dataType, string form, Parameter[] parameters, Event[] events, bool isSingleQuote )
		{

			if ( string.IsNullOrEmpty ( url ) )
				url = "/";

			if ( string.IsNullOrEmpty ( form ) )
				if ( null != parameters )
					foreach ( Parameter parameter in parameters )
						if ( null != parameter )
							this.Parameters.Add ( parameter );

			if ( null != events )
				foreach ( Event @event in events )
					if ( null != @event )
						this.Events.Add ( @event );

			this.Url = url;
			this.DataType = dataType;
			this.WidgetEventType = widgetEventType;
			this.Form = form;

			this.IsSingleQuote = isSingleQuote;
		}

	}
	#endregion

}
// ../.class/web/jqueryui/WidgetSetting.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIWidgetSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */


namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " WidgetType "
	/// <summary>
	/// Widget 类型.
	/// </summary>
	public enum WidgetType
	{
		/// <summary>
		/// 没有任何类型.
		/// </summary>
		None = 0,
		/// <summary>
		/// 按钮.
		/// </summary>
		Button = 1,
	}
	#endregion

	#region " WidgetSetting "
	/// <summary>
	/// jQuery UI Widget 设置.
	/// </summary>
	public sealed class WidgetSetting
	{
		/// <summary>
		/// Widget 相关事件.
		/// </summary>
		public readonly List<Event> Events = new List<Event> ( );
		/// <summary>
		/// Widget 相关设置.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// Widget 类型.
		/// </summary>
		public readonly WidgetType WidgetType;
		/// <summary>
		/// Ajax 相关设置.
		/// </summary>
		public readonly List<AjaxSetting> AjaxSettings = new List<AjaxSetting> ( );

		/// <summary>
		/// 创建 jQuery UI Widget 设置.
		/// </summary>
		/// <param name="widgetEventType">和 Widget 相关的触发事件.</param>
		/// <param name="options">Widget 相关设置.</param>
		/// <param name="events">Widget 相关事件.</param>
		/// <param name="ajaxSettings">Ajax 相关设置.</param>
		public WidgetSetting ( WidgetType widgetEventType, Option[] options, Event[] events, AjaxSetting[] ajaxSettings )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			if ( null != events )
				foreach ( Event @event in events )
					if ( null != @event )
						this.Events.Add ( @event );

			if ( null != ajaxSettings )
				foreach ( AjaxSetting ajaxSetting in ajaxSettings )
					if ( null != ajaxSetting )
						this.AjaxSettings.Add ( ajaxSetting );

			this.WidgetType = widgetEventType;
		}

	}
	#endregion

}
// ../.class/web/JQuery.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQuery
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// JQuery 用于编写构造 jQuery 脚本, 包含了 jQuery 中的方法等. (尚未包含 Effects, Utilities 的部分方法)
	/// </summary>
	public class JQuery
		: ScriptHelper
	{

		/// <summary>
		/// 获取 1.4.2 版本的 jQuery 脚本官方地址.
		/// </summary>
		public static string Script_1_4_2_Url
		{
			get { return "http://code.jquery.com/jquery-1.4.2.min.js"; }
		}

		/// <summary>
		/// 获取 1.4.1 版本的 jQuery 脚本 zoyobar.googlecode.com 地址.
		/// </summary>
		public static string Script_1_4_1_Url
		{
			get { return "http://zoyobar.googlecode.com/files/jquery-1.4.1.min.js"; }
		}

		#region " 构造 "

		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( JQuery jQuery )
		{ return new JQuery ( jQuery ); }

		/// <summary>
		/// 创建使用别名的空的 JQuery.
		/// </summary>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( )
		{ return Create ( null, null, true ); }
		/// <summary>
		/// 创建空的 JQuery.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( bool isAlias )
		{ return Create ( null, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI )
		{ return Create ( expressionI, null, true ); }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, bool isAlias )
		{ return Create ( expressionI, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, string expressionII )
		{ return Create ( expressionI, expressionII, true ); }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, string expressionII, bool isAlias )
		{ return new JQuery ( expressionI, expressionII, isAlias ); }

		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( bool isInstance, bool isAlias )
		{ return new JQuery ( isInstance, isAlias ); }


		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		public JQuery ( JQuery jQuery )
			: base ( ScriptType.JavaScript )
		{

			if ( null == jQuery )
				return;

			this.code = jQuery.code;
		}

		/// <summary>
		/// 创建使用别名的空的 JQuery.
		/// </summary>
		public JQuery ( )
			: this ( null, null, true )
		{ }
		/// <summary>
		/// 创建空的 JQuery.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( bool isAlias )
			: this ( null, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		public JQuery ( string expressionI )
			: this ( expressionI, null, true )
		{ }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( string expressionI, bool isAlias )
			: this ( expressionI, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		public JQuery ( string expressionI, string expressionII )
			: this ( expressionI, expressionII, true )
		{ }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( string expressionI, string expressionII, bool isAlias )
			: base ( ScriptType.JavaScript )
		{

			string constructor;

			if ( isAlias )
				constructor = "$";
			else
				constructor = "jQuery";

			if ( string.IsNullOrEmpty ( expressionI ) )
				this.AppendCode ( string.Format ( "{0}()", constructor ) );
			else
				if ( string.IsNullOrEmpty ( expressionII ) )
					this.AppendCode ( string.Format ( "{0}({1})", constructor, expressionI ) );
				else
					this.AppendCode ( string.Format ( "{0}({1}, {2})", constructor, expressionI, expressionII ) );

		}

		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( bool isInstance, bool isAlias )
			: base ( ScriptType.JavaScript )
		{

			if ( isAlias )
				this.AppendCode ( "$" );
			else
				this.AppendCode ( "jQuery" );

			if ( isInstance )
				this.AppendCode ( "()" );

		}

		#endregion

		#region " 基本 "

		/// <summary>
		/// 创建当前 JQuery 的副本, 拥有相同的 Code 属性.
		/// </summary>
		/// <returns>JQuery 的副本.</returns>
		public JQuery Copy ( )
		{ return new JQuery ( this ); }

		/// <summary>
		/// 添加语句的结尾符号.
		/// </summary>
		/// <returns>添加结尾符号后的 JQuery.</returns>
		public JQuery EndLine ( )
		{
			this.AppendCode ( this.EndOfLine );
			return this;
		}

		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName )
		{ return this.Execute ( methodName, null, null, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI )
		{ return this.Execute ( methodName, expressionI, null, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII )
		{ return this.Execute ( methodName, expressionI, expressionII, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <param name="expressionIII">方法的第 3 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( methodName, expressionI, expressionII, expressionIII, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <param name="expressionIII">方法的第 3 个参数的表达式.</param>
		/// <param name="expressionIV">方法的第 4 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII, string expressionIII, string expressionIV )
		{

			if ( string.IsNullOrEmpty ( methodName ) )
				return this;

			if ( string.IsNullOrEmpty ( expressionI ) )
				this.AppendCode ( string.Format ( ".{0}()", methodName ) );
			else
				if ( string.IsNullOrEmpty ( expressionII ) )
					this.AppendCode ( string.Format ( ".{0}({1})", methodName, expressionI ) );
				else
					if ( string.IsNullOrEmpty ( expressionIII ) )
						this.AppendCode ( string.Format ( ".{0}({1}, {2})", methodName, expressionI, expressionII ) );
					else
						if ( string.IsNullOrEmpty ( expressionIV ) )
							this.AppendCode ( string.Format ( ".{0}({1}, {2}, {3})", methodName, expressionI, expressionII, expressionIII ) );
						else
							this.AppendCode ( string.Format ( ".{0}({1}, {2}, {3}, {4})", methodName, expressionI, expressionII, expressionIII, expressionIV ) );

			return this;
		}

		#endregion

		#region " 方法 A "

		/// <summary>
		/// 合并新的元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 或者是一段 html 代码, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Add ( string expressionI )
		{ return this.Add ( expressionI, null ); }
		/// <summary>
		/// 合并新的元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">选择器, 比如: "'body table .red'".</param>
		/// <param name="expressionII">document 元素, 指定选择器搜索的文档.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Add ( string expressionI, string expressionII )
		{ return this.Execute ( "add", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的包含的页面元素添加新的样式.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 可以是多个样式的名称, 比如: "'box red'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AddClass ( string expression )
		{ return this.Execute ( "addClass", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i) { return this.className + i.toString;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery After ( string expressionI )
		{ return this.After ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery After ( string expressionI, string expressionII )
		{ return this.Execute ( "after", expressionI, expressionII ); }

		/// <summary>
		/// 执行 ajax 操作, 并返回 jqXHR javascript 对象.
		/// </summary>
		/// <param name="expressionI">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ajax ( string expressionI )
		{ return this.Ajax ( expressionI, null ); }
		/// <summary>
		/// 执行 ajax 操作, 并返回 jqXHR javascript 对象. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "'js/test.js'".</param>
		/// <param name="expressionII">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ajax ( string expressionI, string expressionII )
		{ return this.Execute ( "ajax", expressionI, expressionII ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求完成的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxComplete ( string expression )
		{ return this.Execute ( "ajaxComplete", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求失败的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, g, a, t){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxError ( string expression )
		{ return this.Execute ( "ajaxError", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求发出的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSend ( string expression )
		{ return this.Execute ( "ajaxSend", expression ); }

		/// <summary>
		/// 设置之后 ajax 操作的默认设置. (需要 1.1 版本以上)
		/// </summary>
		/// <param name="expression">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSetup ( string expression )
		{ return this.Execute ( "ajaxSetup", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加第一个 ajax 请求的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxStart ( string expression )
		{ return this.Execute ( "ajaxStart", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加所有 ajax 请求结束的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxStop ( string expression )
		{ return this.Execute ( "ajaxStop", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加所有 ajax 请求成功的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSuccess ( string expression )
		{ return this.Execute ( "ajaxSuccess", expression ); }

		/// <summary>
		/// 合并 jQuery 匹配到的上一批元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AndSelf ( )
		{ return this.Execute ( "andSelf" ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i, h) { return 'old html is ' + h;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Append ( string expressionI )
		{ return this.Append ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Append ( string expressionI, string expressionII )
		{ return this.Execute ( "append", expressionI, expressionII ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素追加到指定目标之后.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'.red'", 可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AppendTo ( string expression )
		{ return this.Execute ( "appendTo", expression ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的属性, 或者设置所有元素的多个属性.
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'", 也可以是属性集合, 比如: "{type: 'text', title: 'test'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Attr ( string expressionI )
		{ return this.Attr ( expressionI, null ); }
		/// <summary>
		/// 设置 jQuery 中元素的属性.
		/// </summary>
		/// <param name="expressionI">可以是属性名称, 比如: "'title'".</param>
		/// <param name="expressionII">返回属性名称的表达式, 比如: "'just test'", 或者返回属性值的函数, 比如: "function(i, a){ return 'my_' + i.toString(); }". (如果使用函数需要 1.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Attr ( string expressionI, string expressionII )
		{ return this.Execute ( "attr", expressionI, expressionII ); }

		#endregion

		#region " 方法 B "

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i) { return this.className + i.toString;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Before ( string expressionI )
		{ return this.Before ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Before ( string expressionI, string expressionII )
		{ return this.Execute ( "before", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加事件. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI )
		{ return this.Bind ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示停止事件的冒泡. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI, string expressionII )
		{ return this.Bind ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示停止事件的冒泡. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "bind", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加失去焦点事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( )
		{ return this.Blur ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加失去焦点的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( string expressionI )
		{ return this.Blur ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加失去焦点的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( string expressionI, string expressionII )
		{ return this.Execute ( "blur", expressionI, expressionII ); }

		#endregion

		#region " 方法 C "

		/// <summary>
		/// 触发 jQuery 中的元素的添加数据改变事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( )
		{ return this.Change ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加数据改变的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( string expressionI )
		{ return this.Change ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加数据改变的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( string expressionI, string expressionII )
		{ return this.Execute ( "change", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级子元素, 不包含文本元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Children ( )
		{ return this.Children ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素中符合选择器的第一级子元素, 不包含文本元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Children ( string expression )
		{ return this.Execute ( "children", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加单击事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( )
		{ return this.Click ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加单击的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( string expressionI )
		{ return this.Click ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加单击的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( string expressionI, string expressionII )
		{ return this.Execute ( "click", expressionI, expressionII ); }

		/// <summary>
		/// 复制当前 jQuery 中包含的元素, 对于是否复制元素的事件和数据, 1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false, 不复制元素的子元素的事件和数据.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( )
		{ return this.Clone ( null, null ); }
		/// <summary>
		/// 复制当前 jQuery 中包含的元素, 不复制元素的子元素的事件和数据.
		/// </summary>
		/// <param name="expressionI">一个布尔表达式, 比如: "true", 表示是否复制元素的事件和数据. (1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( string expressionI )
		{ return this.Clone ( expressionI, null ); }
		/// <summary>
		/// 复制当前 jQuery 中包含的元素. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expressionI">一个布尔表达式, 比如: "true", 表示是否复制元素的事件和数据. (1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false)</param>
		/// <param name="expressionII">一个布尔表达式, 比如: "true", 表示是否复制元素的子元素的事件和数据.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( string expressionI, string expressionII )
		{ return this.Execute ( "clone", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中元素的第一个符合选择器的父元素, 从当前 jQuery 元素开始搜索. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是一个选择器, 比如: "'strong'", 或者选择器的数组, 比如: "['body', 'ul']". (如果使用数组需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Closest ( string expressionI )
		{ return this.Closest ( expressionI, null ); }
		/// <summary>
		/// 获取当前 jQuery 中元素的第一个符合选择器的父元素, 从当前 jQuery 元素开始搜索. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是一个选择器, 比如: "'strong'", 或者选择器的数组, 比如: "['body', 'ul']".</param>
		/// <param name="expressionII">返回页面元素的表达式, 指定搜索的位置.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Closest ( string expressionI, string expressionII )
		{ return this.Execute ( "closest", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有子元素, 包含文本和注释. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Contents ( )
		{ return this.Execute ( "contents" ); }

		/// <summary>
		/// 获取当前 jQuery 中第一个元素的样式或者设置所有元素的多个样式.
		/// </summary>
		/// <param name="expressionI">返回要获取的样式名称的表达式, 比如: "'color'", 或者要设置的多个样式, 比如: "{'background-color' : '#ddd', 'font-weight' : '', 'color' : 'rgb(0,40,244)'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Css ( string expressionI )
		{ return this.Css ( expressionI, null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的样式.
		/// </summary>
		/// <param name="expressionI">返回要设置的样式名称的表达式, 比如: "'color'".</param>
		/// <param name="expressionII">返回样式值的表达式, 比如: "'red'", 或者返回值的函数, 比如: "function(i, v){return i.toString() + 'px';}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Css ( string expressionI, string expressionII )
		{ return this.Execute ( "css", expressionI, expressionII ); }

		/// <summary>
		/// 获得 jQuery 的 cssHooks 属性, 用于设置新的样式规则. (需要 1.4.3 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery CssHooks ( )
		{
			this.AppendCode ( ".cssHooks" );
			return this;
		}

		#endregion

		#region " 方法 D "

		/// <summary>
		/// 触发 jQuery 中的元素的添加双击事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( )
		{ return this.Dblclick ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加双击的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( string expressionI )
		{ return this.Dblclick ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加双击的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( string expressionI, string expressionII )
		{ return this.Execute ( "dblclick", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Delegate ( string expressionI, string expressionII, string expressionIII )
		{ return this.Delegate ( expressionI, expressionII, expressionIII, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIV">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Delegate ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "delegate", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 将当前 jQuery 中的元素从页面中删除, 但仍保存在 jQuery 中. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Detach ( )
		{ return this.Detach ( null ); }
		/// <summary>
		/// 将当前 jQuery 中符合选择器的元素从页面中删除, 但仍保存在 jQuery 中. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择删除元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Detach ( string expression )
		{ return this.Execute ( "detach", expression ); }

		/// <summary>
		/// 取消所有使用 live 方法绑定的事件. (需要 1.4.1 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( )
		{ return this.Die ( null, null ); }
		/// <summary>
		/// 取消使用 live 方法绑定的指定事件. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( string expressionI )
		{ return this.Die ( expressionI, null ); }
		/// <summary>
		/// 取消使用 live 方法绑定的指定事件的某个函数. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "clickfunction", 将取消函数作为事件的处理.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( string expressionI, string expressionII )
		{ return this.Execute ( "die", expressionI, expressionII ); }

		#endregion

		#region " 方法 E "

		/// <summary>
		/// 对当前 jQuery 中包含的元素执行对应的 javascript 函数.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(i, e){ $(e).html(i.toString()); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Each ( string expression )
		{ return this.Execute ( "each", expression ); }

		/// <summary>
		/// 将当前 jQuery 中元素的子元素从页面中删除, 包含文本.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Empty ( )
		{ return this.Execute ( "empty" ); }

		/// <summary>
		/// 将最初搜索的一批元素恢复到 jQuery 中. 
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery End ( )
		{ return this.Execute ( "end" ); }

		/// <summary>
		/// 获取当前 jQuery 中指定索引的元素. (需要 1.1.2 版本以上)
		/// </summary>
		/// <param name="expression">返回元素的索引值的表达式, 比如: "0", 如果是 "-1", 则表示最后一个元素. (如果使用负数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Eq ( string expression )
		{ return this.Execute ( "eq", expression ); }

		/// <summary>
		/// 为 jQuery 中的元素添加处理错误的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Error ( string expressionI )
		{ return this.Error ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加处理错误的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Error ( string expressionI, string expressionII )
		{ return this.Execute ( "error", expressionI, expressionII ); }

		#endregion

		#region " 方法 F "

		/// <summary>
		/// 选择当前 jQuery 中符合选择器, 筛选函数, 元素或者 jQuery 中元素的元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')", 或者是另一个 jQuery 对象, 比如: "$('#li64')". (如果元素或者 jQuery 需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Filter ( string expression )
		{ return this.Execute ( "filter", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中包含元素的符合选择器的子元素.
		/// </summary>
		/// <param name="expression">用于筛选子元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Find ( string expression )
		{ return this.Execute ( "find", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中第一个元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery First ( )
		{ return this.Execute ( "first" ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加获取焦点事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( )
		{ return this.Focus ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取焦点的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( string expressionI )
		{ return this.Focus ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取焦点的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( string expressionI, string expressionII )
		{ return this.Execute ( "focus", expressionI, expressionII ); }

		#endregion

		#region " 方法 G "

		/// <summary>
		/// 使用 GET 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Get ( string expressionI )
		{ return this.Get ( expressionI, null, null, null ); }
		/// <summary>
		/// 使用 GET 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <param name="expressionIV">指定获取数据类型的字符串, "'xml'", "'json'", "'script'", "'html'" 中的一种.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Get ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "get", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 使用 GET 获取请求 json 数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "test.aspx".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetJSON ( string expressionI )
		{ return this.GetJSON ( expressionI, null, null ); }
		/// <summary>
		/// 使用 GET 获取请求 json 数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "test.aspx".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetJSON ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "getJSON", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 使用 GET 获取请求 javascript 脚本并执行.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetScript ( string expressionI )
		{ return this.GetScript ( expressionI, null ); }
		/// <summary>
		/// 使用 GET 获取请求 javascript 脚本并执行.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetScript ( string expressionI, string expressionII)
		{ return this.Execute ( "getScript", expressionI, expressionII ); }

		#endregion

		#region " 方法 H "

		/// <summary>
		/// 选择 jQuery 中元素, 其子元素符合选择器或者元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 或者是元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Has ( string expression )
		{ return this.Execute ( "has", expression ); }

		/// <summary>
		/// 判断样式是否存在.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 比如: "'box'", 将判断样式是否存在.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery HasClass ( string expression )
		{ return this.Execute ( "hasClass", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Height ( )
		{ return this.Height ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的高度.
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110", 或者一个返回数值的函数, 比如: "function(i, h){ return i + h; }". (如果使用函数需要 1.4.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Height ( string expression )
		{ return this.Execute ( "height", expression ); }

		/// <summary>
		/// 设置当前 jQuery 元素的鼠标进入和离开的事件. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标进入和离开的共同事件.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Hover ( string expressionI )
		{ return this.Hover ( expressionI, null ); }
		/// <summary>
		/// 设置当前 jQuery 元素的鼠标进入和离开的事件. (需要 1.4.1 版本以上)
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标进入事件.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标离开事件.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Hover ( string expressionI, string expressionII )
		{ return this.Execute ( "hover", expressionI, expressionII ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 innerHTML 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Html ( )
		{ return this.Html ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含元素的 innerHTML 属性.
		/// </summary>
		/// <param name="expression">返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 或者返回 html 代码的函数, 比如: "function(i, h){ return '&lt;stong&gt;&lt;/stong&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Html ( string expression )
		{ return this.Execute ( "html", expression ); }

		#endregion

		#region " 方法 I "

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 不包含边框. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InnerHeight ( )
		{ return this.Execute ( "innerHeight" ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 不包含边框. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InnerWidth ( )
		{ return this.Execute ( "innerWidth" ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素添加到目标之后作为兄弟元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InsertAfter ( string expression )
		{ return this.Execute ( "insertAfter", expression ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素添加到目标之前作为兄弟元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InsertBefore ( string expression )
		{ return this.Execute ( "insertBefore", expression ); }

		/// <summary>
		///判断当前 jQuery 元素是否符合选择器, 如果至少一个符合时, 将在 javascript 中返回 true.
		/// </summary>
		/// <param name="expression">选择器, 比如: "'.box'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Is ( string expression )
		{ return this.Execute ( "is", expression ); }

		#endregion

		#region " 方法 K "

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘按下事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( )
		{ return this.Keydown ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按下的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( string expressionI )
		{ return this.Keydown ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按下的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( string expressionI, string expressionII )
		{ return this.Execute ( "keydown", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘按住事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( )
		{ return this.Keypress ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按住的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( string expressionI )
		{ return this.Keypress ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按住的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( string expressionI, string expressionII )
		{ return this.Execute ( "keypress", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘松开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( )
		{ return this.Keyup ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘松开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( string expressionI )
		{ return this.Keyup ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘松开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( string expressionI, string expressionII )
		{ return this.Execute ( "keyup", expressionI, expressionII ); }

		#endregion

		#region " 方法 L "

		/// <summary>
		/// 选择当前 jQuery 中最后一个元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Last ( )
		{ return this.Execute ( "last" ); }

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Length ( )
		{
			this.AppendCode ( ".length" );
			return this;
		}

		/// <summary>
		/// 为 jQuery 中的元素添加事件, 可以用 die 方法取消. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI )
		{ return this.Live ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件, 可以用 die 方法取消. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI, string expressionII )
		{ return this.Live ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件, 可以用 die 方法取消. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "live", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加载入的事件, 或者使用 GET 请求 html 代码.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 或者返回地址的表达式, 比如: "'test.html'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI )
		{ return this.Load ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加载入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI, string expressionII )
		{ return this.Load ( expressionI, expressionII, null ); }
		/// <summary>
		/// 使用 GET 请求 html 代码.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "'test.html'".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回完成时回调函数的表达式, 比如: "function(r, t, x){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "load", expressionI, expressionII, expressionIII ); }

		#endregion

		#region " 方法 M "

		/// <summary>
		/// 对当前 jQuery 中的元素执行函数, 并将执行的结果返回为一个 javascript 数组. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">返回调用函数的表达式, 比如: "function(i, o){ return 'my_' + i.toString(); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Map ( string expression )
		{ return this.Execute ( "map", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标按下事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( )
		{ return this.Mousedown ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标按下的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( string expressionI )
		{ return this.Mousedown ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标按下的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( string expressionI, string expressionII )
		{ return this.Execute ( "mousedown", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标进入事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( )
		{ return this.Mouseenter ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标进入的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( string expressionI )
		{ return this.Mouseenter ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标进入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseenter", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标离开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( )
		{ return this.Mouseleave ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标离开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( string expressionI )
		{ return this.Mouseleave ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标离开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseleave", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑动事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( )
		{ return this.Mousemove ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑动的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( string expressionI )
		{ return this.Mousemove ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑动的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( string expressionI, string expressionII )
		{ return this.Execute ( "mousemove", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑出事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( )
		{ return this.Mouseout ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑出的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( string expressionI )
		{ return this.Mouseout ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑出的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseout", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑入事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( )
		{ return this.Mouseover ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑入的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( string expressionI )
		{ return this.Mouseover ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseover", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标松开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( )
		{ return this.Mouseup ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标松开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( string expressionI )
		{ return this.Mouseup ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标松开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseup", expressionI, expressionII ); }

		#endregion

		#region " 方法 N "

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的第一个兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Next ( )
		{ return this.Next ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的符合选择器的第一个兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Next ( string expression )
		{ return this.Execute ( "next", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextAll ( )
		{ return this.NextAll ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的符合选择器的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextAll ( string expression )
		{ return this.Execute ( "nextAll", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素向后的所有兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextUntil ( )
		{ return this.NextUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素向后的所有兄弟元素, 出现符合选择器的兄弟元素为止, 不包含此符合选择器的兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextUntil ( string expression )
		{ return this.Execute ( "nextUntil", expression ); }

		/// <summary>
		/// 卸载 jQuery 在页面中 $ 的定义.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NoConflict ( )
		{ return this.NoConflict ( null ); }
		/// <summary>
		/// 卸载 jQuery 在页面中 $ 的定义.
		/// </summary>
		/// <param name="expression">一个返回布尔值的表达式, 比如: "true", "1 > 2" 或者 "isOK", 其中 isOK 是 javascript 脚本中的变量, 如果表达式为 true, 则卸载 $ 和 jQuery 的定义, 否则只卸载 $ 的定义.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NoConflict ( string expression )
		{ return this.Execute ( "noConflict", expression ); }

		/// <summary>
		/// 去除当前 jQuery 中符合条件的元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Not ( string expression )
		{ return this.Execute ( "not", expression ); }

		#endregion

		#region " 方法 O "

		/// <summary>
		/// 获取当前 jQuery 中第一个元素相对于 document 的位置, 返回值保存一个拥有 top 和 left 属性的对象中.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Offset ( )
		{ return this.Offset ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素相对于 document 的位置.
		/// </summary>
		/// <param name="expression">返回具有 top 和 left 属性的对象的表达式, 比如: "{ top: 10, left: 20 }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Offset ( string expression )
		{ return this.Execute ( "offset", expression ); }

		/// <summary>
		/// 获取 jQuery 中包含元素的第一个设置了 position 样式为 relative, absolute 或者 fixed 的父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OffsetParent ( )
		{ return this.Execute ( "offsetParent" ); }

		/// <summary>
		/// 为 jQuery 中的元素添加只执行一次的事件. (需要 1.1 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery One ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "one", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 包含边框, padding. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterHeight ( )
		{ return this.OuterHeight ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 包含边框, padding, 可选 margin. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个布尔表达式, 比如: "true", 指定是否包含 margin, 默认为 false.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterHeight ( string expression )
		{ return this.Execute ( "outerHeight", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 包含边框, padding. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterWidth ( )
		{ return this.OuterWidth ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 包含边框, padding, 可选 margin. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个布尔表达式, 比如: "true", 指定是否包含 margin, 默认为 false.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterWidth ( string expression )
		{ return this.Execute ( "outerWidth", expression ); }

		#endregion

		#region " 方法  P "

		/// <summary>
		/// 将对象或者数组转化为 url 参数.
		/// </summary>
		/// <param name="expressionI">对象或者数组, 比如: "{name: 'abc', age: 12}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Param ( string expressionI )
		{ return this.Param ( expressionI, null ); }
		/// <summary>
		/// 将对象或者数组转化为 url 参数.
		/// </summary>
		/// <param name="expressionI">对象或者数组, 比如: "{name: 'abc', age: 12}".</param>
		/// <param name="expressionII">返回布尔值的表达式, 比如: "true", 指示是否深度转化.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Param ( string expressionI, string expressionII )
		{ return this.Execute ( "param", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parent ( )
		{ return this.Parent ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级符合选择器的父元素.
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parent ( string expression )
		{ return this.Execute ( "parent", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parents ( )
		{ return this.Parents ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有符合选择器的父元素.
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parents ( string expression )
		{ return this.Execute ( "parents", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的所有父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ParentsUntil ( )
		{ return this.ParentsUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的所有父元素, 出现符合选择器的父元素为止, 不包含此符合选择器的父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ParentsUntil ( string expression )
		{ return this.Execute ( "parentsUntil", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中第一个元素相对于父元素的位置, 返回值保存一个拥有 top 和 left 属性的对象中.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Position ( )
		{ return this.Execute ( "position" ); }

		/// <summary>
		/// 使用 POST 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Post ( string expressionI )
		{ return this.Post ( expressionI, null, null, null ); }
		/// <summary>
		/// 使用 POST 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <param name="expressionIV">指定获取数据类型的字符串, "'xml'", "'json'", "'script'", "'html'" 中的一种.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Post ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "post", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i, h) { return 'old html is ' + h;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prepend ( string expressionI )
		{ return this.Prepend ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prepend ( string expressionI, string expressionII )
		{ return this.Execute ( "prepend", expressionI, expressionII ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素追加到指定目标之前.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'.red'", 可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrependTo ( string expression )
		{ return this.Execute ( "prependTo", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的第一个兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prev ( )
		{ return this.Prev ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的符合选择器的第一个兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prev ( string expression )
		{ return this.Execute ( "prev", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevAll ( )
		{ return this.PrevAll ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的符合选择器的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevAll ( string expression )
		{ return this.Execute ( "prevAll", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素向前的所有兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevUntil ( )
		{ return this.PrevUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素向前的所有兄弟元素, 出现符合选择器的兄弟元素为止, 不包含此符合选择器的兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevUntil ( string expression )
		{ return this.Execute ( "prevUntil", expression ); }

		/// <summary>
		/// 产生新的函数, 并指定新的上下文. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">函数的原型, 比如: "function(){ return this.toString(); }", 如果 expressionII 是函数名称, 也可以是新的上下文的表达式, 比如: "someobj".</param>
		/// <param name="expressionII">新的上下文的表达式, 比如: "someobj", 如果 expressionI 是上下文的表达式, 也可以是函数名称, 比如: "'test'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Proxy ( string expressionI, string expressionII )
		{ return this.Execute ( "proxy", expressionI, expressionII ); }

		#endregion

		#region " 方法 R "

		/// <summary>
		/// 添加当整个页面载入后的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ready ( string expression )
		{ return this.Execute ( "", expression ); }

		/// <summary>
		/// 将当前 jQuery 中的元素从页面中删除.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Remove ( )
		{ return this.Remove ( null ); }
		/// <summary>
		/// 将当前 jQuery 中符合选择器的元素从页面中删除.
		/// </summary>
		/// <param name="expression">用于选择删除元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Remove ( string expression )
		{ return this.Execute ( "remove", expression ); }

		/// <summary>
		/// 删除 jQuery 中包含的元素的属性.
		/// </summary>
		/// <param name="expression">返回属性名称的表达式, 比如: "'title'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveAttr ( string expression )
		{ return this.Execute ( "removeAttr", expression ); }

		/// <summary>
		/// 删除 jQuery 中包含的元素的所有样式.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveClass ( )
		{ return this.RemoveClass ( null ); }
		/// <summary>
		/// 删除 jQuery 中包含的元素的指定样式.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveClass ( string expression )
		{ return this.Execute ( "removeClass", expression ); }

		/// <summary>
		/// 使用当前 jQuery 中的元素替换符合选择器的元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">选择被替换到的元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ReplaceAll ( string expression )
		{ return this.Execute ( "replaceAll", expression ); }

		/// <summary>
		/// 使用新的元素替换当前 jQuery 中的元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(){ document.getElementById('abc') }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ReplaceWith ( string expression )
		{ return this.Execute ( "replaceWith", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加大小改变事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( )
		{ return this.Resize ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加大小改变的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( string expressionI )
		{ return this.Resize ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加大小改变的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( string expressionI, string expressionII )
		{ return this.Execute ( "resize", expressionI, expressionII ); }

		#endregion

		#region " 方法 S "

		/// <summary>
		/// 触发 jQuery 中的元素的添加滚动轴事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( )
		{ return this.Scroll ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加滚动轴的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( string expressionI )
		{ return this.Scroll ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加滚动轴的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( string expressionI, string expressionII )
		{ return this.Execute ( "scroll", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的水平滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollLeft ( )
		{ return this.ScrollLeft ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的水平滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollLeft ( string expression )
		{ return this.Execute ( "scrollLeft", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的垂直滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollTop ( )
		{ return this.ScrollTop ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的垂直滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollTop ( string expression )
		{ return this.Execute ( "scrollTop", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加选择事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( )
		{ return this.Select ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加选择的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( string expressionI )
		{ return this.Select ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加选择的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( string expressionI, string expressionII )
		{ return this.Execute ( "select", expressionI, expressionII ); }

		/// <summary>
		/// 将表单中包含的值转化为 url 参数字符串.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Serialize ( )
		{ return this.Execute ( "serialize" ); }

		/// <summary>
		/// 将表单中包含的值转化为数组.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery SerializeArray ( )
		{ return this.Execute ( "serializeArray" ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Siblings ( )
		{ return this.Siblings ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有符合选择器的兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Siblings ( string expression )
		{ return this.Execute ( "siblings", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中从某个位置开始到结束范围的元素, 0 是第 1 个元素, -1 是最后一个元素. (需要 1.1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Slice ( string expressionI )
		{ return this.Slice ( expressionI, null ); }
		/// <summary>
		/// 选择当前 jQuery 中某个范围的元素, 0 是第 1 个元素, -1 是最后一个元素. (需要 1.1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <param name="expressionII">结束索引, 比如: "2", 结束位置的元素不会被选择.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Slice ( string expressionI, string expressionII )
		{ return this.Execute ( "slice", expressionI, expressionII ); }

		/// <summary>
		/// 创建主 jQuery 对象的副本.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Sub ( )
		{ return this.Execute ( "sub" ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加提交事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( )
		{ return this.Submit ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加提交的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( string expressionI )
		{ return this.Submit ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加提交的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( string expressionI, string expressionII )
		{ return this.Execute ( "submit", expressionI, expressionII ); }

		#endregion

		#region " 方法 T "

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 innerText 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Text ( )
		{ return this.Text ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含元素的 innerText 属性.
		/// </summary>
		/// <param name="expression">一个字符串表达式, 比如: "'this is abc'", 或者返回字符串的函数, 比如: "function(i, t){ return 'old text is ' + t; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Text ( string expression )
		{ return this.Execute ( "text", expression ); }

		/// <summary>
		/// 为当前 jQuery 元素添加多个点击事件, 将根据点击次数在这些事件中切换.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <param name="expressionII">同 expressionI, 可以为 null.</param>
		/// <param name="expressionIII">同 expressionI, 可以为 null.</param>
		/// <param name="expressionIV">同 expressionI, 可以为 null.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Toggle ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "toggle", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 切换 jQuery 中包含的元素的样式, 样式存在则删除, 如果不存在则添加.
		/// </summary>
		/// <param name="expressionI">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ToggleClass ( string expressionI )
		{ return this.ToggleClass ( expressionI, null ); }
		/// <summary>
		/// 添加或者删除 jQuery 中包含的元素的样式. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <param name="expressionII">返回布尔值的表达式, 表示添加还是删除样式.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ToggleClass ( string expressionI, string expressionII )
		{ return this.Execute ( "toggleClass", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中元素的事件. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Trigger ( string expressionI )
		{ return this.Trigger ( expressionI, null ); }
		/// <summary>
		/// 触发 jQuery 中元素的事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">扩展的参数数组, 比如: "[age: 10, size: 100]".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Trigger ( string expressionI, string expressionII )
		{ return this.Execute ( "trigger", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中第一个元素的事件, 不引发元素的默认行文. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">扩展的参数数组, 比如: "[age: 10, size: 100]".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery TriggerHandler ( string expressionI, string expressionII )
		{ return this.Execute ( "triggerHandler", expressionI, expressionII ); }

		#endregion

		#region " 方法 U "

		/// <summary>
		/// 为 jQuery 中的元素取消所有事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( )
		{ return this.Unbind ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件.
		/// </summary>
		/// <param name="expressionI">可以是事件类型, 比如: "'click'", "'click mouseover'", 也可以是包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( string expressionI )
		{ return this.Unbind ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示取消停止冒泡的事件. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( string expressionI, string expressionII )
		{ return this.Execute ( "unbind", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的元素取消所有事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( )
		{ return this.Undelegate ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI, string expressionII )
		{ return this.Undelegate ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "undelegate", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加卸载的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unload ( string expressionI )
		{ return this.Unload ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加卸载的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unload ( string expressionI, string expressionII )
		{ return this.Execute ( "unload", expressionI, expressionII ); }

		/// <summary>
		/// 删除调用 wrap 方法产生的父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unwrap ( )
		{ return this.Execute ( "unwrap" ); }

		#endregion

		#region " 方法 V "

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 value 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Val ( )
		{ return this.Val ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含的元素 value 属性.
		/// </summary>
		/// <param name="expression">一个表达式, 比如: "'my name'", 或者是一个返回值的函数, 比如: "function(i, v){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Val ( string expression )
		{ return this.Execute ( "val", expression ); }

		#endregion

		#region " 方法 W "

		/// <summary>
		/// 调用 when 方法, 传递一个或者多个 javascript 对象, 之后可再通过 done, then 等方法编写这些对象载入后的处理方法. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expression">一个或者多个对象的表达式, 比如: "$.ajax('test.aspx')", 或者 "{ testing: 123 }, { name: 'jack' }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery When ( string expression )
		{ return this.Execute ( "when", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Width ( )
		{ return this.Width ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的宽度.
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110", 或者一个返回数值的函数, 比如: "function(i, w){ return i + w; }". (如果使用函数需要 1.4.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Width ( string expression )
		{ return this.Execute ( "width", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的每一个元素添加父元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(i){ return '&lt;div&gt;&lt;/div&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Wrap ( string expression )
		{ return this.Execute ( "wrap", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的元素添加一个共同的父元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery WrapAll ( string expression )
		{ return this.Execute ( "wrapAll", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的每一个元素添加一个子元素, 这个子元素包含原来所有的子元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(){ return '&lt;div&gt;&lt;/div&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery WrapInner ( string expression )
		{ return this.Execute ( "wrapInner", expression ); }

		#endregion

	}

}
// ../.class/web/ScriptHelper.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ScriptHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * 测试文件:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/testsite/TestScriptHelper.aspx
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/testsite/TestScriptHelper.aspx.cs
 * 合并下载:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/ScriptHelper.all.cs
 * 版本: 1.1, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
* */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

// HACK: 如果代码不能编译, 请尝试在项目中定义编译符号 V4, V3_5, V3, V2 以表示不同的 .NET 版本


// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 此类可以完成客户端脚本的编写, 修改标签属性, 包含脚本文件, 设置时钟等操作.
	/// </summary>
	public partial class ScriptHelper
	{

		private static readonly Random random = new Random ( );

#if PARAM
		/// <summary>
		/// 从一个字符串生成脚本的 id.
		/// </summary>
		/// <param name="key">字符串, 作为 id 的一部分, 默认为 "script_yyyyMMddhhmmss".</param>
		/// <returns>脚本 id.</returns>
		public static string MakeKey ( string key = null )
#else
		/// <summary>
		/// 从一个字符串生成脚本的 id.
		/// </summary>
		/// <param name="key">字符串, 作为 id 的一部分.</param>
		/// <returns>脚本 id.</returns>
		public static string MakeKey ( string key )
#endif
		{

			if ( string.IsNullOrEmpty ( key ) )
				key = DateTime.Now.ToString ( "yyyyMMddhhmmss" ) + random.Next ( 0, int.MaxValue );

			return string.Format ( "script_{0}", key );
		}

#if PARAM
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本, 默认为 None.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( NControl control, string key, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( NControl control, string key, ScriptBuildOption option )
#endif
		{

			if ( null == control )
				return false;

			return IsBuilt ( control.Page, key, option );
		}

#if PARAM
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="page">代码块所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本, 默认为 None.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( Page page, string key, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 指定名称的代码块是否已经存在?
		/// </summary>
		/// <param name="page">代码块所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 用于判断是否作为 Startup 脚本.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( Page page, string key, ScriptBuildOption option )
#endif
		{

			if ( null == page || null == page.ClientScript )
				return false;

#if V4
			if ( option.HasFlag ( ScriptBuildOption.Startup ) )
#else
			if ( ( option & ScriptBuildOption.Startup ) == ScriptBuildOption.Startup )
#endif
				return page.ClientScript.IsStartupScriptRegistered ( page.GetType ( ), MakeKey ( key ) );
			else
				return page.ClientScript.IsClientScriptBlockRegistered ( page.GetType ( ), MakeKey ( key ) );

		}

		protected string code = string.Empty;

		protected readonly ScriptType scriptType;

		/// <summary>
		/// 获取或设置脚本代码.
		/// </summary>
		public string Code
		{
			get { return this.code; }
			set
			{

				if ( null != value )
					this.code = value;

			}
		}

		/// <summary>
		/// 获取脚本类型.
		/// </summary>
		public ScriptType ScriptType
		{
			get { return this.scriptType; }
		}

		/// <summary>
		/// 获取脚本类型对应的 Return 语句.
		/// </summary>
		public string Return
		{
			get
			{

				switch ( this.scriptType )
				{
					case ScriptType.VBScript:
						return string.Empty;

					case ScriptType.JavaScript:
					default:
						return "return";
				}

			}
		}

		/// <summary>
		/// 获取脚本类型对应的语句结束符号.
		/// </summary>
		public string EndOfLine
		{
			get
			{

				switch ( this.scriptType )
				{
					case ScriptType.VBScript:
						return string.Empty;

					case ScriptType.JavaScript:
					default:
						return ";";
				}

			}
		}

#if PARAM
		/// <summary>
		/// 创建脚本帮手.
		/// </summary>
		/// <param name="scriptType">脚本类型, 目前只有 JavaScript 类型可用, 默认为 JavaScript.</param>
		public ScriptHelper ( ScriptType scriptType = ScriptType.JavaScript )
#else
		/// <summary>
		/// 创建脚本帮手.
		/// </summary>
		/// <param name="scriptType">脚本类型, 目前只有 JavaScript 类型可用.</param>
		public ScriptHelper ( ScriptType scriptType )
#endif
		{
			this.scriptType = scriptType;

			switch ( scriptType )
			{
				case ScriptType.VBScript:
					throw new ArgumentException ( "目前不支持 VBScript, 请使用 JavaScript", "quotationType" );
			}

		}

#if PARAM
		/// <summary>
		/// 生成弹出消息的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>弹出消息框的代码.</returns>
		public string Alert ( string message, bool isAppend = true )
#else
		/// <summary>
		/// 生成弹出消息的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>弹出消息框的代码.</returns>
		public string Alert ( string message, bool isAppend )
#endif
		{

			string code = string.Empty;

			if ( string.IsNullOrEmpty ( message ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "alert({0});", message );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回结果到变量等的确认消息函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户确认结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 默认不返回值到变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回结果到变量等的确认消息函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户确认结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( message ) )
				return code;

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{1}confirm({0});", message, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回结果到变量的输入框函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'10'", 也可以是计算表达式, 比如: "defaultAge", 默认为 "''".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 默认不返回值到变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string defaultValue = null, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回结果到变量的输入框函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'10'", 也可以是计算表达式, 比如: "defaultAge".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性?</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string defaultValue, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( null == message )
				return code;

			if ( null == defaultValue )
				defaultValue = "''";

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}prompt({0}, {1});", message, defaultValue, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

		/// <summary>
		/// 清除所有的代码.
		/// </summary>
		public void Clear ( )
		{ this.code = string.Empty; }

		/// <summary>
		/// 添加代码到当前代码结尾处.
		/// </summary>
		/// <param name="code">被添加的代码.</param>
		public void AppendCode ( string code )
		{

			if ( string.IsNullOrEmpty ( code ) )
				return;

			this.code += code;
		}

#if PARAM
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称, 默认自动生成.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效, 默认 None.</param>
		public void Build ( NControl control, string key = null, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( NControl control, string key, ScriptBuildOption option )
#endif
		{

			if ( null == control )
				return;

			this.Build ( control.Page, key, option );
		}

#if PARAM
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="key">代码块的名称, 默认自动生成.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效, 默认 None.</param>
		public void Build ( Page page, string key = null, ScriptBuildOption option = ScriptBuildOption.None )
#else
		/// <summary>
		/// 生成代码块.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( Page page, string key, ScriptBuildOption option )
#endif
		{

			if ( this.code == string.Empty || null == page || null == page.ClientScript || IsBuilt ( page, key, option ) )
				return;

			string type;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					type = "text/javascript";
					break;
			}

			string script;

#if V4
			if ( option.HasFlag ( ScriptBuildOption.OnlyCode ) )
#else
			if ( ( option & ScriptBuildOption.OnlyCode ) == ScriptBuildOption.OnlyCode )
#endif
				script = this.code;
			else
				script = string.Format ( "<script language='{0}' type='{1}'>\n{2}\n</script>", this.scriptType.ToString ( ).ToLower ( ), type, this.code );

			key = MakeKey ( key );

#if V4
			if ( option.HasFlag ( ScriptBuildOption.Startup ) )
#else
			if ( ( option & ScriptBuildOption.Startup ) == ScriptBuildOption.Startup )
#endif
				page.ClientScript.RegisterStartupScript ( page.GetType ( ), key, script );
			else
				page.ClientScript.RegisterClientScriptBlock ( page.GetType ( ), key, script );

			// if ( option.HasFlag ( ScriptBuildOption.EndResponse ) && null != page.Response )
			//     page.Response.End ();

		}

#if PARAM
		/// <summary>
		/// 生成导航的函数, 地址选项在实际代码中将使用单引号, 比如: '_blank', 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航窗口选项, 默认为 SelfWindow.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, NavigateOption option = NavigateOption.SelfWindow, bool isAppend = true )
#else
		/// <summary>
		/// 生成导航的函数, 地址选项在实际代码中将使用单引号, 比如: '_blank', 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航窗口选项.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, NavigateOption option, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( location ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:

					switch ( option )
					{
						case NavigateOption.NewWindow:
							code = string.Format (
								"window.open({0}, '{1}');",
								location,
								"_blank"
								);
							break;

						case NavigateOption.ParentWindow:
							code = string.Format (
								"window.open({0}, '{1}');",
								location,
								"_parent"
								);
							break;

						case NavigateOption.SelfWindow:
						default:
							code = string.Format ( "location.href = {0};", location );
							break;
					}

					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成清除时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>清除时钟的代码.</returns>
		public string ClearTimeout ( string handler, bool isAppend = true )
#else
		/// <summary>
		/// 生成清除时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>清除时钟的代码.</returns>
		public string ClearTimeout ( string handler, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( handler ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "clearTimeout({0});", handler );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回句柄到变量的时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 默认不保存到任何变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回句柄到变量的时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( runCode ) )
				return code;

			if ( delay <= 0 )
				delay = 1;

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}setTimeout({0}, {1});", runCode, delay, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成清除循环时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>清除循环时钟的代码.</returns>
		public string ClearInterval ( string handler, bool isAppend = true )
#else
		/// <summary>
		/// 生成清除循环时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>清除循环时钟的代码.</returns>
		public string ClearInterval ( string handler, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( handler ) )
				return code;

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "clearInterval({0});", handler );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 生成返回句柄到变量的循环时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 默认不保存到任何变量.</param>
		/// <param name="isAppend">是否追加到 Code 属性, 默认为 true.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, string result = null, bool isAppend = true )
#else
		/// <summary>
		/// 生成返回句柄到变量的循环时钟函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, string result, bool isAppend )
#endif
		{
			string code = string.Empty;

			if ( string.IsNullOrEmpty ( runCode ) )
				return code;

			if ( delay <= 0 )
				delay = 1;

			if ( null == result )
				result = string.Empty;

			if ( result != string.Empty )
				result += " = ";

			switch ( this.scriptType )
			{
				case ScriptType.JavaScript:
				default:
					code = string.Format ( "{2}setInterval({0}, {1});", runCode, delay, result );
					break;
			}

			if ( isAppend )
				this.code += code;

			return code;
		}

#if PARAM
		/// <summary>
		/// 添加一个数组到控件所在页面的脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 默认不包含值.</param>
		public static void RegisterArray ( NControl control, string arrayName, string arrayValue = null )
#else
		/// <summary>
		/// 添加一个数组到控件所在页面的脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 也可以设置为 null.</param>
		public static void RegisterArray ( NControl control, string arrayName, string arrayValue )
#endif
		{

			if ( null == control )
				return;

			RegisterArray ( control.Page, arrayName, arrayValue );
		}

#if PARAM
		/// <summary>
		/// 添加一个数组到页面脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 默认不包含值.</param>
		public static void RegisterArray ( Page page, string arrayName, string arrayValue = null )
#else
		/// <summary>
		/// 添加一个数组到页面脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		/// <param name="arrayValue">数组中的元素, 用逗号分隔, 比如: "'jack', 'tom'", 也可以设置为 null.</param>
		public static void RegisterArray ( Page page, string arrayName, string arrayValue )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( arrayName ) )
				return;

			if ( null == arrayValue )
				arrayValue = "";

			page.ClientScript.RegisterArrayDeclaration ( arrayName, arrayValue );
		}


#if PARAM
		/// <summary>
		/// 添加脚本包含到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称, 默认自动生成.</param>
		public static void RegisterInclude ( NControl control, string url, string key = null )
#else
		/// <summary>
		/// 添加脚本包含到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称.</param>
		public static void RegisterInclude ( NControl control, string url, string key )
#endif
		{

			if ( null == control )
				return;

			RegisterInclude ( control.Page, key, url );
		}

#if PARAM
		/// <summary>
		/// 添加脚本包含到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称, 默认自动生成.</param>
		public static void RegisterInclude ( Page page, string url, string key = null )
#else
		/// <summary>
		/// 添加脚本包含到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		/// <param name="key">包含的名称.</param>
		public static void RegisterInclude ( Page page, string url, string key )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( url ) )
				return;

			key = MakeKey ( key );

			if ( page.ClientScript.IsClientScriptIncludeRegistered ( page.GetType ( ), key ) )
				return;

			page.ClientScript.RegisterClientScriptInclude ( page.GetType ( ), key, url );
		}


		/// <summary>
		/// 添加设置标签属性的脚本到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性, 但不能对同一标签的同一属性设置两次.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加设置标签属性的脚本.</param>
		/// <param name="id">标签的 id 属性, 比如: "spanTest", 标签应该是页面上存在的元素.</param>
		/// <param name="attributeName">标签的属性, 比如: "innerHTML" 或者 "style.color".</param>
		/// <param name="attributeValue">属性的值, 比如: "你好" 或者 "#ff0000", 可以为 null.</param>
		public static void RegisterAttribute ( NControl control, string id, string attributeName, string attributeValue )
		{

			if ( null == control )
				return;

			RegisterAttribute ( control.Page, id, attributeName, attributeValue );
		}
		/// <summary>
		/// 添加设置标签属性的脚本到页面, 不需要使用 Build 方法, 也不影响 Code 属性, 但不能对同一标签的同一属性设置两次.
		/// </summary>
		/// <param name="page">添加设置标签属性脚本的页面.</param>
		/// <param name="id">标签的 id 属性, 比如: "spanTest", 标签应该是页面上存在的元素.</param>
		/// <param name="attributeName">标签的属性, 比如: "innerHTML" 或者 "style.color".</param>
		/// <param name="attributeValue">属性的值, 比如: "你好" 或者 "#ff0000", 可以为 null.</param>
		public static void RegisterAttribute ( Page page, string id, string attributeName, string attributeValue )
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( id ) || string.IsNullOrEmpty ( attributeName ) )
				return;

			if ( null == attributeValue )
				attributeValue = string.Empty;

			try
			{ page.ClientScript.RegisterExpandoAttribute ( id, attributeName, attributeValue, true ); }
			catch { }

		}

		/// <summary>
		/// 添加隐藏值到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加隐藏值.</param>
		/// <param name="name">隐藏值的名称.</param>
		/// <param name="value">隐藏值, 可以为 null.</param>
		public static void RegisterHidden ( NControl control, string name, string value )
		{

			if ( null == control )
				return;

			RegisterHidden ( control.Page, name, value );
		}
		/// <summary>
		/// 添加隐藏值到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加隐藏值的页面.</param>
		/// <param name="name">隐藏值的名称.</param>
		/// <param name="value">隐藏值, 可以为 null.</param>
		public static void RegisterHidden ( Page page, string name, string value )
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( name ) )
				return;

			if ( null == value )
				value = string.Empty;

			page.ClientScript.RegisterHiddenField ( name, value );
		}

#if PARAM
		/// <summary>
		/// 添加 OnSubmit 脚本到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称, 默认自动生成.</param>
		public static void RegisterSubmit ( NControl control, string code, string key = null )
#else
		/// <summary>
		/// 添加 OnSubmit 脚本到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称.</param>
		public static void RegisterSubmit ( NControl control, string code, string key )
#endif
		{

			if ( null == control )
				return;

			RegisterSubmit ( control.Page, key, code );
		}

#if PARAM
		/// <summary>
		/// 添加 OnSubmit 脚本到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称, 默认自动生成.</param>
		public static void RegisterSubmit ( Page page, string code, string key = null )
#else
		/// <summary>
		/// 添加 OnSubmit 脚本到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="code">脚本的内容, 比如: "alert('OK!');".</param>
		/// <param name="key">脚本的名称.</param>
		public static void RegisterSubmit ( Page page, string code, string key )
#endif
		{

			if ( null == page || null == page.ClientScript || string.IsNullOrEmpty ( code ) )
				return;

			key = MakeKey ( key );

			if ( page.ClientScript.IsOnSubmitStatementRegistered ( page.GetType ( ), key ) )
				return;

			page.ClientScript.RegisterOnSubmitStatement ( page.GetType ( ), key, code );
		}

	}

	partial class ScriptHelper
	{
#if !PARAM
		/// <summary>
		/// 添加脚本包含到页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本包含的页面.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		public static void RegisterInclude ( Page page, string url )
		{ RegisterInclude ( page, url, null ); }

		/// <summary>
		/// 添加脚本包含到控件所在页面, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本包含.</param>
		/// <param name="url">脚本的地址, 不支持 ~ 转化.</param>
		public static void RegisterInclude ( NControl control, string url )
		{ RegisterInclude ( control, url, null ); }

		/// <summary>
		/// 添加一个数组到页面脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="page">添加脚本的页面.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		public static void RegisterArray ( Page page, string arrayName )
		{ RegisterArray ( page, arrayName, null ); }

		/// <summary>
		/// 添加一个数组到控件所在页面的脚本, 同名数组的元素将被追加, 不需要使用 Build 方法, 也不影响 Code 属性.
		/// </summary>
		/// <param name="control">控件, 其所在页面将添加脚本.</param>
		/// <param name="arrayName">数组名称, 需要一个合法的变量名, 比如: "names".</param>
		public static void RegisterArray ( NControl control, string arrayName )
		{ RegisterArray ( control, arrayName, null ); }

		/// <summary>
		/// 添加循环时钟的函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay )
		{ return this.SetInterval ( runCode, delay, null, true ); }
		/// <summary>
		/// 添加返回句柄到变量的循环时钟函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, string result )
		{ return this.SetInterval ( runCode, delay, result, true ); }
		/// <summary>
		/// 生成循环时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="isAppend">是否追加到 Code 属性?</param>
		/// <returns>循环时钟的代码.</returns>
		public string SetInterval ( string runCode, int delay, bool isAppend )
		{ return this.SetInterval ( runCode, delay, null, isAppend ); }

		/// <summary>
		/// 添加清除循环时钟的函数到代码.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <returns>清除循环时钟的代码.</returns>
		public string ClearInterval ( string handler )
		{ return this.ClearInterval ( handler, true ); }

		/// <summary>
		/// 添加时钟的函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay )
		{ return this.SetTimeout ( runCode, delay, null, true ); }
		/// <summary>
		/// 添加返回句柄到变量的时钟函数到代码.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="result">保存时钟句柄的变量等, 请书写合法的变量名, 比如: "timer1" 或者 "window.MyTimer", 可以设置为 null.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, string result )
		{ return this.SetTimeout ( runCode, delay, result, true ); }
		/// <summary>
		/// 生成时钟的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="runCode">时钟触发运行的代码, 比如: "'alert(\"hello\");'", "function () {alert();}".</param>
		/// <param name="delay">时钟触发的间隔, 以毫秒为单位.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>时钟的代码.</returns>
		public string SetTimeout ( string runCode, int delay, bool isAppend )
		{ return this.SetTimeout ( runCode, delay, null, isAppend ); }

		/// <summary>
		/// 添加循环时钟的函数到代码.
		/// </summary>
		/// <param name="handler">时钟的句柄, 比如: "100000", 或者保存句柄的变量, "timer1".</param>
		/// <returns>清除时钟的代码.</returns>
		public string ClearTimeout ( string handler )
		{ return this.ClearTimeout ( handler, true ); }

		/// <summary>
		/// 添加导航的函数到代码, 在自身窗口打开.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location )
		{ return this.Navigate ( location, NavigateOption.SelfWindow, true ); }
		/// <summary>
		/// 添加导航的函数到代码, 地址选项在实际代码中将使用单引号, 比如: '_blank'.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="option">导航窗口选项.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, NavigateOption option )
		{ return this.Navigate ( location, option, true ); }
		/// <summary>
		/// 生成导航的函数, 在自身窗口打开, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="location">导航的地址, 比如: "'www.google.com'", 也可以是计算表达式, 比如: "'www.' + mydomain + '.com'".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>导航的代码.</returns>
		public string Navigate ( string location, bool isAppend )
		{ return this.Navigate ( location, NavigateOption.SelfWindow, isAppend ); }

		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		public void Build ( Page page )
		{ this.Build ( page, null, ScriptBuildOption.None ); }
		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( Page page, ScriptBuildOption option )
		{ this.Build ( page, null, option ); }
		/// <summary>
		/// 生成代码块, 带有 script 标签, 但不结束页面处理.
		/// </summary>
		/// <param name="page">生成代码块的页面.</param>
		/// <param name="key">代码块的名称.</param>
		public void Build ( Page page, string key )
		{ this.Build ( page, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		public void Build ( NControl control )
		{ this.Build ( control, null, ScriptBuildOption.None ); }
		/// <summary>
		/// 生成代码块, 但不结束页面处理.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="option">生成选项, 目前 EndResponse 无效.</param>
		public void Build ( NControl control, ScriptBuildOption option )
		{ this.Build ( control, null, option ); }
		/// <summary>
		/// 生成代码块, 带有 script 标签, 但不结束页面处理.
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		public void Build ( NControl control, string key )
		{ this.Build ( control, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 添加返回结果到变量的输入框函数到代码.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string result )
		{ return this.Prompt ( message, null, result, true ); }
		/// <summary>
		/// 添加返回结果到变量的输入框函数到代码.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="defaultValue">默认的输入内容, 比如: "'10'", 也可以是计算表达式, 比如: "defaultAge".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string defaultValue, string result )
		{ return this.Prompt ( message, defaultValue, result, true ); }
		/// <summary>
		/// 生成返回结果到变量的输入框函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">输入提示的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户输入结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>输入框的代码.</returns>
		public string Prompt ( string message, string result, bool isAppend )
		{ return this.Prompt ( message, null, result, isAppend ); }

		/// <summary>
		/// 添加确认消息的函数到代码.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message )
		{ return this.Confirm ( message, null, true ); }
		/// <summary>
		/// 添加返回结果到变量等的确认消息函数到代码.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="result">保存用户确认结果的变量等, 请书写合法的变量名, 比如: "age" 或者 "window.MyAge", 可以设置为 null.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, string result )
		{ return this.Confirm ( message, result, true ); }
		/// <summary>
		/// 生成确认消息的函数, 可以选择是否添加到 Code 属性.
		/// </summary>
		/// <param name="message">确认的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <param name="isAppend">是否追加到 Code 属性.</param>
		/// <returns>确认消息的代码.</returns>
		public string Confirm ( string message, bool isAppend )
		{ return this.Confirm ( message, null, isAppend ); }

		/// <summary>
		/// 添加弹出消息的函数到代码.
		/// </summary>
		/// <param name="message">弹出的内容, 比如: "'jack'", 也可以是计算表达式, 比如: "'name is ' + myname".</param>
		/// <returns>弹出消息框的代码.</returns>
		public string Alert ( string message )
		{ return Alert ( message, true ); }

		/// <summary>
		/// 创建脚本帮手, 脚本类型为 JavaScript.
		/// </summary>
		public ScriptHelper ()
			: this ( ScriptType.JavaScript )
		{ }

		/// <summary>
		/// 指定名称的普通代码块是否已经存在?
		/// </summary>
		/// <param name="page">代码块所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <returns>是否存在代码块?</returns>
		public static bool IsBuilt ( Page page, string key )
		{ return IsBuilt ( page, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 指定名称的普通代码块是否已经存在?
		/// </summary>
		/// <param name="control">控件, 代码块在控件所在的页面.</param>
		/// <param name="key">代码块的名称.</param>
		/// <returns>是否存在代码块.</returns>
		public static bool IsBuilt ( NControl control, string key )
		{ return IsBuilt ( control, key, ScriptBuildOption.None ); }

		/// <summary>
		/// 生成一个随机的脚本 id.
		/// </summary>
		/// <returns>脚本 id.</returns>
		public static string MakeKey ()
		{ return MakeKey ( null ); }
#endif
	}

}
// ../.enum/web/NavigateOption.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/NavigateOption
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 导航选项.
	/// </summary>
	public enum NavigateOption
	{
		/// <summary>
		/// 空设置.
		/// </summary>
		None = 0,
		/// <summary>
		/// 新窗口.
		/// </summary>
		NewWindow = 1,
		/// <summary>
		/// 在自身的窗口.
		/// </summary>
		SelfWindow = 2,
		/// <summary>
		/// 在父窗口中.
		/// </summary>
		ParentWindow = 3
	}

}
// ../.enum/web/ScriptBuildOption.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ScriptBuildOption
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 脚本编译选项.
	/// </summary>
	public enum ScriptBuildOption
	{
		/// <summary>
		/// 默认, 带有 script 标签, 普通脚本块, 不结束页面处理.
		/// </summary>
		None = 0,
		/// <summary>
		/// 结束页面处理.
		/// </summary>
		EndResponse = 1,
		/// <summary>
		/// 不带有 script 标签.
		/// </summary>
		OnlyCode = 2,
		/// <summary>
		/// 做为启动脚本.
		/// </summary>
		Startup = 4
	}

}
// ../.enum/web/ScriptType.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ScriptType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 脚本的类型.
	/// </summary>
	public enum ScriptType
	{
		/// <summary>
		/// Java 脚本.
		/// </summary>
		JavaScript = 1,
		/// <summary>
		/// VB 脚本.
		/// </summary>
		VBScript = 2
	}

}
// ../.class/code/StringConvert.cs
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/StringConvert
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

// HACK: 如果代码不能编译, 请尝试在项目中定义编译符号 V4, V3_5, V3, V2 以表示不同的 .NET 版本


namespace zoyobar.shared.panzer.code
{

	/// <summary>
	/// 字符串转换器.
	/// </summary>
	public sealed class StringConvert
	{

		/// <summary>
		/// 将对象转化为字符串.
		/// </summary>
		/// <param name="value">需要转化的对象.</param>
		/// <returns>转化后的字符串.</returns>
		public static string ToString ( object value )
		{

			if ( null == value )
				return string.Empty;

			if ( value.GetType ( ) == typeof ( Color ) )
				return ( ( Color ) value ).ToArgb ( ).ToString ( );
			else
				return value.ToString ( );

		}

		/// <summary>
		/// 将字符串转化为指定类型的对象.
		/// </summary>
		/// <param name="value">需要转化的字符串.</param>
		/// <returns>转化后的对象.</returns>
		public static T ToObject<T> ( string value )
		{

			if ( null == value )
				return default ( T );

			Type type = typeof ( T );

			try
			{

#if V4
				if ( type == typeof ( Guid ) )
					return ( T ) ( object ) new Guid ( value );
				else if ( type == typeof ( Color ) )
					return ( T ) ( object ) Color.FromArgb ( Convert.ToInt32 ( value ) );
				else if ( type == typeof ( string ) )
					return ( T ) ( object ) value.ToString ( );
				else if ( type == typeof ( int ) )
					return ( T ) ( object ) int.Parse ( value );
				else if ( type == typeof ( short ) )
					return ( T ) ( object ) short.Parse ( value );
				else if ( type == typeof ( long ) )
					return ( T ) ( object ) long.Parse ( value );
				else if ( type == typeof ( decimal ) )
					return ( T ) ( object ) decimal.Parse ( value );
				else if ( type == typeof ( bool ) )
					return ( T ) ( object ) bool.Parse ( value );
				else if ( type == typeof ( DateTime ) )
					return ( T ) ( object ) DateTime.Parse ( value );
				else if ( type == typeof ( float ) )
					return ( T ) ( object ) float.Parse ( value );
				else if ( type == typeof ( double ) )
					return ( T ) ( object ) double.Parse ( value );
				else
					return ( T ) ( object ) value;
#else
				if ( object.ReferenceEquals ( type, typeof ( Guid ) ) )
					return ( T ) ( object ) new Guid ( value );
				else if ( object.ReferenceEquals ( type, typeof ( Color ) ) )
					return ( T ) ( object ) Color.FromArgb ( Convert.ToInt32 ( value ) );
				else if ( object.ReferenceEquals ( type, typeof ( string ) ) )
					return ( T ) ( object ) value.ToString ( );
				else if ( object.ReferenceEquals ( type, typeof ( int ) ) )
					return ( T ) ( object ) int.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( short ) ) )
					return ( T ) ( object ) short.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( long ) ) )
					return ( T ) ( object ) long.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( decimal ) ) )
					return ( T ) ( object ) decimal.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( bool ) ) )
					return ( T ) ( object ) bool.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( DateTime ) ) )
					return ( T ) ( object ) DateTime.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( float ) ) )
					return ( T ) ( object ) float.Parse ( value );
				else if ( object.ReferenceEquals ( type, typeof ( double ) ) )
					return ( T ) ( object ) double.Parse ( value );
				else
					return ( T ) ( object ) value;
#endif

			}
			catch
			{ return default ( T ); }

		}

	}

}

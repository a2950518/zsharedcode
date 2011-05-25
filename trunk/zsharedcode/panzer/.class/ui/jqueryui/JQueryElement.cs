/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryElement
 * http://code.google.com/p/zsharedcode/wiki/JQueryElementType
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIBaseWidget
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
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/RepeaterSettingEdit.cs
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;

// HACK: 避免在 allinone 文件中的名称冲突
using NBorderStyle = System.Web.UI.WebControls.BorderStyle;

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
		/// <summary>
		/// input 元素.
		/// </summary>
		Input = 6,
		/// <summary>
		/// button 元素.
		/// </summary>
		Button = 7,
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
	[DesignerAttribute ( typeof ( JQueryElementDesigner ) )]
	public class JQueryElement
		: WebControl, INamingContainer
	{

		private static string escapeCharacter ( string text )
		{

			if ( string.IsNullOrEmpty ( text ) )
				return string.Empty;

			return text.Replace ( "\\", "\\\\" ).Replace ( "\'", "\\'" ).Replace ( "\"", "\\\"" ).Replace ( "\n", "\\n" ).Replace ( "\t", "\\t" ).Replace ( "\r", "\\r" );
		}

		public static string renderTemplate ( PlaceHolder holder )
		{

			if ( null == holder )
				return string.Empty;

			StringWriter writer = new StringWriter ( );

			holder.RenderControl ( new HtmlTextWriter ( writer ) );

			return writer.ToString ( );
		}

		protected ElementType elementType = ElementType.None;
		protected string attribute;
		private bool isVariable = false;
		protected string selector;

		private DraggableSettingEdit draggableSetting = new DraggableSettingEdit ( );
		private DroppableSettingEdit droppableSetting = new DroppableSettingEdit ( );
		private SortableSettingEdit sortableSetting = new SortableSettingEdit ( );
		private SelectableSettingEdit selectableSetting = new SelectableSettingEdit ( );
		private ResizableSettingEdit resizableSetting = new ResizableSettingEdit ( );

		protected WidgetSettingEdit widgetSetting = new WidgetSettingEdit ( );

		private RepeaterSettingEdit repeaterSetting = new RepeaterSettingEdit ( );

		protected readonly PlaceHolder html = new PlaceHolder ( );

		/// <summary>
		/// 获取或设置元素的拖动设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的拖动设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public virtual DraggableSettingEdit DraggableSetting
		{
			get { return this.draggableSetting; }
			set
			{

				if ( null != value )
					this.draggableSetting = value;

			}
		}

		/// <summary>
		/// 获取或设置元素的拖放设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的拖放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public virtual DroppableSettingEdit DroppableSetting
		{
			get { return this.droppableSetting; }
			set
			{

				if ( null != value )
					this.droppableSetting = value;

			}
		}

		/// <summary>
		/// 获取或设置元素的排列设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的排列设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public virtual SortableSettingEdit SortableSetting
		{
			get { return this.sortableSetting; }
			set
			{

				if ( null != value )
					this.sortableSetting = value;

			}
		}

		/// <summary>
		/// 获取或设置元素的选中设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的选中设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public virtual SelectableSettingEdit SelectableSetting
		{
			get { return this.selectableSetting; }
			set
			{

				if ( null != value )
					this.selectableSetting = value;

			}
		}

		/// <summary>
		/// 获取或设置元素的缩放设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的缩放设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public virtual ResizableSettingEdit ResizableSetting
		{
			get { return this.resizableSetting; }
			set
			{

				if ( null != value )
					this.resizableSetting = value;

			}
		}

		/// <summary>
		/// 获取或设置元素的 Widget 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的 Widget 设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public virtual WidgetSettingEdit WidgetSetting
		{
			get { return this.widgetSetting; }
			set
			{

				if ( null != value )
					this.widgetSetting = value;

			}
		}

		/// <summary>
		/// 获取或设置元素的 Repeater 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的 Repeater 设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public virtual RepeaterSettingEdit RepeaterSetting
		{
			get { return this.repeaterSetting; }
			set
			{

				if ( null != value )
					this.repeaterSetting = value;

			}
		}

		/// <summary>
		/// 获取 PlaceHolder 控件, 其中包含了元素中包含的 html 代码. 
		/// </summary>
		[Browsable ( false )]
		[Category ( "jQuery UI" )]
		[Description ( "设置元素中包含的 html 代码" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public virtual PlaceHolder Html
		{
			get { return this.html; }
		}

		/// <summary>
		/// 获取或设置元素的类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "最终在页面上生成的元素类型, 比如: Span, Div, 默认为 None, 不生成任何元素" )]
		[DefaultValue ( ElementType.None )]
		public virtual ElementType ElementType
		{
			get { return this.elementType; }
			set { this.elementType = value; }
		}

		/// <summary>
		/// 获取或设置是否生成 jquery 对应的 javascript 变量, 如果使用了 Repeater, 则在运行时自动调整为 true.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "是否以 ClientID 生成对应的 javascript 变量, 如果使用了 Repeater, 则在运行时自动调整为 true" )]
		[DefaultValue ( false )]
		public virtual bool IsVariable
		{
			get { return this.isVariable; }
			set { this.isVariable = value; }
		}

		/// <summary>
		/// 获取或设置选择器, 将针对此选择器对应的元素执行操作, 比如: "'#age'", 默认为自身.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "选择器, 将针对此选择器对应的元素执行操作, 比如: \"'#age'\", 默认为自身" )]
		[DefaultValue ( "" )]
		public virtual string Selector
		{
			get { return this.selector; }
			set { this.selector = value; }
		}

		/// <summary>
		/// 获取或设置元素的属性.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "最终在页面上生成的元素的属性" )]
		[DefaultValue ( "" )]
		public virtual string Attribute
		{
			get { return this.attribute; }
			set
			{

				if ( null != value )
					this.attribute = value;

			}
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
		public override NBorderStyle BorderStyle
		{
			get { return NBorderStyle.None; }
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
		{
			this.EnableViewState = false;

			this.Controls.Add ( this.html );
			this.Controls.Add ( this.repeaterSetting.Header );
			this.Controls.Add ( this.repeaterSetting.Item );
			this.Controls.Add ( this.repeaterSetting.EditItem );
			this.Controls.Add ( this.repeaterSetting.Empty );
			this.Controls.Add ( this.repeaterSetting.Footer );
		}

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.Visible )
				return;

			JQueryUI jquery = new JQueryUI ( string.IsNullOrEmpty ( this.selector ) ? string.Format ( "'#{0}'", this.ClientID ) : this.selector );

			if ( this.elementType != ElementType.None )
			{
				string style = string.Empty;

				if ( this.Width != Unit.Empty )
					style += string.Format ( "width:{0};", this.Width );

				if ( this.Height != Unit.Empty )
					style += string.Format ( "height:{0};", this.Height );

				string attribute = string.Empty;

				foreach ( string key in this.Attributes.Keys )
					attribute += string.Format ( " {0}={1}", key, this.Attributes[key] );

				writer.Write (
					"<{0} id={1}{2}{3}{4}{5}{6}{7}>",
					this.elementType.ToString ( ).ToLower ( ),
					this.ClientID,
					string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : " class=" + HttpUtility.HtmlEncode ( this.CssClass ),
					string.IsNullOrEmpty ( this.ToolTip ) ? string.Empty : " title=" + HttpUtility.HtmlEncode ( this.ToolTip ),
					string.IsNullOrEmpty ( style ) ? string.Empty : " style=" + HttpUtility.HtmlEncode ( style ),
					string.IsNullOrEmpty ( this.attribute ) ? string.Empty : " " + this.attribute.Trim ( ),
					attribute,
					( this.elementType == ElementType.Input ) ? " /" : string.Empty
					);
			}

			if ( this.elementType != ElementType.Input )
			{
				// base.Render ( writer );

				if ( this.html.Controls.Count != 0 )
					this.html.RenderControl ( writer );
				else if ( this.DesignMode )
					writer.Write ( "<span style='font-size: 12px;'>[<strong>JE:</strong> {0}]</span>", this.ClientID );

				if ( this.elementType != ElementType.None )
					writer.Write ( "</{0}>", this.elementType.ToString ( ).ToLower ( ) );

			}

			jquery.Draggable ( this.draggableSetting.CreateDraggableSetting ( ) );
			jquery.Droppable ( this.droppableSetting.CreateDroppableSetting ( ) );
			jquery.Sortable ( this.sortableSetting.CreateSortableSetting ( ) );
			jquery.Selectable ( this.selectableSetting.CreateSelectableSetting ( ) );
			jquery.Resizable ( this.resizableSetting.CreateResizableSetting ( ) );

			jquery.Widget ( this.widgetSetting.CreateWidgetSetting ( ) );

			#region " repeater "
			string repeaterCode = string.Empty;

			if ( this.repeaterSetting.IsRepeatable )
			{
				this.isVariable = true;

				if ( !ScriptHelper.IsBuilt ( this, "__jsRepeater" ) )
				{
					ScriptHelper script = new ScriptHelper ( );

					script.AppendCode ( "function repeater(je, fields, attribute, header, footer, item, editItem, empty, rowsName) {\n" +

						"	if (null == je)\n" +
						"		return;\n" +

						"	je.__fields = (null == fields) ? [] : fields;\n" +
						"	je.__attributes = (null == attribute) ? [] : attribute;\n" +
						"	je.__template = { header: (null == header) ? '' : header, footer: (null == footer) ? '' : footer, item: (null == item) ? '' : item, editItem: (null == editItem) ? '' : editItem, empty: (null == empty) ? '' : empty };\n" +
						"	je.__setting = { rowsName: (null == rowsName) ? 'rows' : rowsName };\n" +

						"	je.__bind = function (data) {\n" +
						"		var html = '';\n" +
						"		var isEmpty = false;\n" +
						"		html += je.__template.header;\n" +

						"		if (null == data)\n" +
						"			isEmpty = true;\n" +
						"		else {\n" +
						"			var rows = data[je.__setting.rowsName];\n" +

						"			if (null == rows || rows.length == 0)\n" +
						"				isEmpty = true;\n" +
						"			else\n" +
						"				try {\n" +

						"					for (var x = 0; x < rows.length; x++) {\n" +
						"						var row = rows[x];\n" +
						"						var rowHtml = je.__template.item;\n" +

						"						for (var y = 0; y < je.__fields.length; y++)\n" +
						"							rowHtml = rowHtml.replace(eval('/#' + je.__fields[y] + '/g'), row[je.__fields[y]]);\n" +

						"							html += rowHtml;\n" +
						"					}\n" +

						"				}\n" +
						"				catch (err) {\n" +
						"					isEmpty = true;\n" +
						"				}\n" +

						"		}\n" +

						"		if (isEmpty)\n" +
						"			html += je.__template.empty;\n" +

						"		html += je.__template.footer;\n" +

						"		for (var x = 0; x < je.__attributes.length; x++)\n" +
						"			html = html.replace(eval('/\\@' + je.__attributes[x] + '/g'), data[je.__attributes[x]]);\n" +

						"		je.html(html);\n" +
						"	};\n" +

						"}"
						);

					script.Build ( this, "__jsRepeater", ScriptBuildOption.Startup );
				}

				string fieldsCode = string.Empty;
				string attributesCode = string.Empty;

				foreach ( string field in this.repeaterSetting.Field.Split ( ';' ) )
					fieldsCode += "'" + escapeCharacter ( field.Trim ( ) ) + "',";

				foreach ( string attribute in this.repeaterSetting.Attribute.Split ( ';' ) )
					attributesCode += "'" + escapeCharacter ( attribute.Trim ( ) ) + "',";

				repeaterCode += "repeater(window['" + this.ClientID + "'], " +
					( fieldsCode == string.Empty ? "null" : "[" + fieldsCode.TrimEnd ( ',' ) + "]" ) + "," +
					( attributesCode == string.Empty ? "null" : "[" + attributesCode.TrimEnd ( ',' ) + "]" ) + "," +
					"'" + escapeCharacter ( renderTemplate ( this.repeaterSetting.Header ) ) + "'," +
					"'" + escapeCharacter ( renderTemplate ( this.repeaterSetting.Footer ) ) + "'," +
					"'" + escapeCharacter ( renderTemplate ( this.repeaterSetting.Item ) ) + "'," +
					"'" + escapeCharacter ( renderTemplate ( this.repeaterSetting.EditItem ) ) + "'," +
					"'" + escapeCharacter ( renderTemplate ( this.repeaterSetting.Empty ) ) + "'," +
					"'" + this.repeaterSetting.RowsName + "'" +
					");";
			}
			#endregion

			jquery.Code = "$(function(){" + ( this.isVariable ? ( "window['" + this.ClientID + "'] = " ) : string.Empty ) + JQueryCoder.Encode ( this, jquery.Code ) + ";" + JQueryCoder.Encode ( this, repeaterCode ) + "});";
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

			List<object> states = this.ViewState["JQueryElement"] as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
				this.elementType = ( ElementType ) states[0];

			if ( states.Count >= 2 )
				this.attribute = states[1] as string;

			if ( states.Count >= 3 )
				this.isVariable = ( bool ) states[2];

			if ( states.Count >= 4 )
				this.selector = states[3] as string;

		}

		protected override object SaveViewState ( )
		{
			this.ViewState["DraggableSetting"] = ( this.draggableSetting as IStateManager ).SaveViewState ( );
			this.ViewState["DroppableSetting"] = ( this.droppableSetting as IStateManager ).SaveViewState ( );
			this.ViewState["SortableSetting"] = ( this.sortableSetting as IStateManager ).SaveViewState ( );
			this.ViewState["SelectableSetting"] = ( this.selectableSetting as IStateManager ).SaveViewState ( );
			this.ViewState["ResizableSetting"] = ( this.resizableSetting as IStateManager ).SaveViewState ( );

			this.ViewState["WidgetSetting"] = ( this.widgetSetting as IStateManager ).SaveViewState ( );

			List<object> states = new List<object> ( );
			states.Add ( this.elementType );
			states.Add ( this.attribute );
			states.Add ( this.isVariable );
			states.Add ( this.selector );

			this.ViewState["JQueryElement"] = states;

			return base.SaveViewState ( );
		}

	}
	#endregion

	#region " JQueryElementDesigner "
	/// <summary>
	/// JQueryElement 设计器.
	/// </summary>
	public class JQueryElementDesigner : ControlDesigner
	{

		/// <summary>
		/// 获取行为列表.
		/// </summary>
		public override DesignerActionListCollection ActionLists
		{
			get
			{

				DesignerActionListCollection actions = new DesignerActionListCollection ( );
				actions.Add ( new BaseDesignerAction ( this ) );

				switch ( this.JQueryElement.WidgetSetting.Type )
				{
					case WidgetType.accordion:
						actions.Add ( new AccordionDesignerAction ( this ) );
						break;

					case WidgetType.autocomplete:
						actions.Add ( new AutocompleteDesignerAction ( this ) );
						break;

					case WidgetType.button:
						actions.Add ( new ButtonDesignerAction ( this ) );
						break;

					case WidgetType.datepicker:
						actions.Add ( new DatepickerDesignerAction ( this ) );
						break;

					case WidgetType.dialog:
						actions.Add ( new DialogDesignerAction ( this ) );
						break;

					case WidgetType.progressbar:
						actions.Add ( new ProgressbarDesignerAction ( this ) );
						break;

					case WidgetType.slider:
						actions.Add ( new SliderDesignerAction ( this ) );
						break;

					case WidgetType.tabs:
						actions.Add ( new TabsDesignerAction ( this ) );
						break;
				}

				if ( this.JQueryElement.WidgetSetting.Type != WidgetType.none )
					actions.Add ( new AjaxDesignerAction ( this ) );

				if ( this.JQueryElement.DraggableSetting.IsDraggable )
					actions.Add ( new DraggableDesignerAction ( this ) );

				if ( this.JQueryElement.DroppableSetting.IsDroppable )
					actions.Add ( new DroppableDesignerAction ( this ) );

				if ( this.JQueryElement.ResizableSetting.IsResizable )
					actions.Add ( new ResizableDesignerAction ( this ) );

				if ( this.JQueryElement.SelectableSetting.IsSelectable )
					actions.Add ( new SelectableDesignerAction ( this ) );

				if ( this.JQueryElement.SortableSetting.IsSortable )
					actions.Add ( new SortableDesignerAction ( this ) );

				return actions;
			}
		}

		/// <summary>
		/// 获取 JQueryElement 对象.
		/// </summary>
		public JQueryElement JQueryElement
		{
			get { return this.Component as JQueryElement; }
		}

		#region " JQueryElementDesignerAction "
		/// <summary>
		/// JQueryElement 的设计行为.
		/// </summary>
		public class JQueryElementDesignerAction : DesignerActionList
		{
			protected readonly JQueryElementDesigner designer;

			/// <summary>
			/// 获取 JQueryElement 对象.
			/// </summary>
			public JQueryElement JQueryElement
			{
				get { return this.Component as JQueryElement; }
			}

			/// <summary>
			/// 创建 JQueryElement 的设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public JQueryElementDesignerAction ( JQueryElementDesigner designer )
				: base ( designer.Component )
			{ this.designer = designer; }

			protected bool fetchEnum<T> ( string text, T defalutValue, out T value )
				where T : struct
			{
				value = defalutValue;

				bool isSuccess = true;
				int test;

				if ( !string.IsNullOrEmpty ( text ) )
					if ( this.fetchInteger ( text, 0, out test ) )
						isSuccess = false;
					else
						// HACK: 可能需要添加 V5
#if V4
						isSuccess = Enum.TryParse<T> ( text.Trim ( '\'' ).Trim ( '"' ), out value );
#else
						try
						{ value = ( T ) Enum.Parse ( typeof ( T ), text.Trim ( '\'' ).Trim ( '"' ), true ); }
						catch
						{ isSuccess = false; }
#endif

				return isSuccess;
			}

			protected bool fetchBoolean ( string text, bool defaultValue, out bool value )
			{
				value = defaultValue;

				bool isSuccess;

				if ( string.IsNullOrEmpty ( text ) )
					isSuccess = false;
				else
					isSuccess = bool.TryParse ( text, out value );

				return isSuccess;
			}

			protected bool fetchDecimal ( string text, decimal defaultValue, out decimal value )
			{
				value = defaultValue;

				bool isSuccess;

				if ( string.IsNullOrEmpty ( text ) )
					isSuccess = false;
				else
					isSuccess = decimal.TryParse ( text, out value );

				return isSuccess;
			}

			protected bool fetchInteger ( string text, int defaultValue, out int value )
			{
				value = defaultValue;

				bool isSuccess;

				if ( string.IsNullOrEmpty ( text ) )
					isSuccess = false;
				else
					isSuccess = int.TryParse ( text, out value );

				return isSuccess;
			}

			protected void refreshWidgetSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["WidgetSetting"].SetValue ( this.JQueryElement, this.JQueryElement.WidgetSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshDraggableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["DraggableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.DraggableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshDroppableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["DroppableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.DroppableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshResizableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["ResizableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.ResizableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshSelectableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["SelectableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.SelectableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

			protected void refreshSortableSetting ( )
			{
				TypeDescriptor.GetProperties ( this.JQueryElement )["SortableSetting"].SetValue ( this.JQueryElement, this.JQueryElement.SortableSetting );
				this.designer.Tag.SetDirty ( true );
				this.designer.UpdateDesignTimeHtml ( );
			}

		}
		#endregion

		#region " BaseDesignerAction "
		/// <summary>
		/// JQueryElement 的基本设计行为.
		/// </summary>
		public class BaseDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建 JQueryElement 的基本设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public BaseDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );
				items.Add ( new DesignerActionHeaderItem ( "基本设置", "base" ) );
				items.Add ( new DesignerActionPropertyItem ( "ElementType", "元素类型", "base" ) );
				items.Add ( new DesignerActionPropertyItem ( "WidgetSettingType", "Widget 类型", "base" ) );
				items.Add ( new DesignerActionPropertyItem ( "Selector", "选择器", "base", "选择器, 将针对此选择器对应的元素执行操作, 比如: \"'#age'\", 默认为自身" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsVariable", "生成 javascript 变量", "base" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsDraggable", "启用拖动", "base-e" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsDroppable", "启用拖放", "base-e" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsResizable", "启用缩放", "base-e" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsSelectable", "启用选中", "base-e" ) );
				items.Add ( new DesignerActionPropertyItem ( "IsSortable", "启用排列", "base-e" ) );

				return items;
			}

			/// <summary>
			/// 获取或设置页面元素类型.
			/// </summary>
			public ElementType ElementType
			{
				get
				{ return this.JQueryElement.ElementType; }
				set
				{
					TypeDescriptor.GetProperties ( this.JQueryElement )["ElementType"].SetValue ( this.JQueryElement, value );
					this.designer.UpdateDesignTimeHtml ( );
				}
			}

			/// <summary>
			/// 获取或设置 Widget 类型.
			/// </summary>
			public WidgetType WidgetSettingType
			{
				get
				{ return this.JQueryElement.WidgetSetting.Type; }
				set
				{
					this.JQueryElement.WidgetSetting.Type = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置选择器.
			/// </summary>
			public string Selector
			{
				get
				{ return this.JQueryElement.Selector; }
				set
				{
					TypeDescriptor.GetProperties ( this.JQueryElement )["Selector"].SetValue ( this.JQueryElement, value );
					this.designer.UpdateDesignTimeHtml ( );
				}
			}

			/// <summary>
			/// 获取或设置是否生成 javascript 变量.
			/// </summary>
			public bool IsVariable
			{
				get { return this.JQueryElement.IsVariable; }
				set { TypeDescriptor.GetProperties ( this.JQueryElement )["IsVariable"].SetValue ( this.JQueryElement, value ); }
			}

			/// <summary>
			/// 获取或设置是否可以拖动.
			/// </summary>
			public bool IsDraggable
			{
				get { return this.JQueryElement.DraggableSetting.IsDraggable; }
				set
				{
					this.JQueryElement.DraggableSetting.IsDraggable = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以拖放.
			/// </summary>
			public bool IsDroppable
			{
				get { return this.JQueryElement.DroppableSetting.IsDroppable; }
				set
				{
					this.JQueryElement.DroppableSetting.IsDroppable = value;
					this.refreshDroppableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以缩放.
			/// </summary>
			public bool IsResizable
			{
				get { return this.JQueryElement.ResizableSetting.IsResizable; }
				set
				{
					this.JQueryElement.ResizableSetting.IsResizable = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以选中.
			/// </summary>
			public bool IsSelectable
			{
				get { return this.JQueryElement.SelectableSetting.IsSelectable; }
				set
				{
					this.JQueryElement.SelectableSetting.IsSelectable = value;
					this.refreshSelectableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以排列.
			/// </summary>
			public bool IsSortable
			{
				get { return this.JQueryElement.SortableSetting.IsSortable; }
				set
				{
					this.JQueryElement.SortableSetting.IsSortable = value;
					this.refreshSortableSetting ( );
				}
			}

		}
		#endregion

		#region " DraggableDesignerAction "
		/// <summary>
		/// 拖动的设计行为.
		/// </summary>
		public class DraggableDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// Axis 类型.
			/// </summary>
			public enum AxisType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// x 轴拖动.
				/// </summary>
				x = 1,
				/// <summary>
				/// y 轴拖动.
				/// </summary>
				y = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Containment 类型.
			/// </summary>
			public enum ContainmentType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 容器为 parent.
				/// </summary>
				parent = 1,
				/// <summary>
				/// 容器为 document.
				/// </summary>
				document = 2,
				/// <summary>
				/// 容器为 window.
				/// </summary>
				window = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Helper 类型.
			/// </summary>
			public enum HelperType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 使用自身.
				/// </summary>
				original = 1,
				/// <summary>
				/// 使用副本.
				/// </summary>
				clone = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// SnapMode 类型.
			/// </summary>
			public enum SnapModeType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 内部附着.
				/// </summary>
				inner = 1,
				/// <summary>
				/// 外部附着.
				/// </summary>
				outer = 2,
				/// <summary>
				/// 内部和外部附着.
				/// </summary>
				both = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个拖动设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public DraggableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "拖动设置", "draggable" ) );

				AxisType axisType;

				if ( this.fetchEnum<AxisType> ( this.JQueryElement.DraggableSetting.Axis, AxisType.@null, out axisType ) )
					items.Add ( new DesignerActionPropertyItem ( "Axis", "方向", "draggable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AxisText", "方向", "draggable", "指示拖动的方向, 可以是 'x', 'y'" ) );

				ContainmentType containmentType;

				if ( this.fetchEnum<ContainmentType> ( this.JQueryElement.DraggableSetting.Containment, ContainmentType.@null, out containmentType ) )
					items.Add ( new DesignerActionPropertyItem ( "Containment", "容器", "draggable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ContainmentText", "容器", "draggable", "指示拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" ) );

				HelperType helperType;

				if ( this.fetchEnum<HelperType> ( this.JQueryElement.DraggableSetting.Helper, HelperType.@null, out helperType ) )
					items.Add ( new DesignerActionPropertyItem ( "Helper", "helper", "draggable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "HelperText", "helper", "draggable", "指示是否使用副本 'original' 针对元素本身, 'clone' 针对元素的副本" ) );

				decimal opacity;

				if ( this.fetchDecimal ( this.JQueryElement.DraggableSetting.Opacity, 1, out opacity ) )
					items.Add ( new DesignerActionPropertyItem ( "Opacity", "透明度", "draggable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "OpacityText", "透明度", "draggable" ) );

				bool isRevert;

				if ( this.JQueryElement.DraggableSetting.Revert == string.Empty || this.fetchBoolean ( this.JQueryElement.DraggableSetting.Revert, false, out isRevert ) )
				{
					items.Add ( new DesignerActionPropertyItem ( "Revert", "播放恢复动画", "draggable" ) );

					if ( this.Revert )
						items.Add ( new DesignerActionPropertyItem ( "RevertDuration", "恢复动画时长", "draggable" ) );

				}
				else
				{
					items.Add ( new DesignerActionPropertyItem ( "RevertText", "播放恢复动画", "draggable", "指示是否在拖动后播放恢复原位的动画, 比如: true, 或者是 'valid', 'invalid'" ) );
					items.Add ( new DesignerActionPropertyItem ( "RevertDuration", "恢复动画时长", "draggable" ) );
				}

				items.Add ( new DesignerActionPropertyItem ( "Snap", "附着", "draggable" ) );

				if ( this.Snap )
				{
					items.Add ( new DesignerActionPropertyItem ( "SnapText", "附着目标", "draggable" ) );
					items.Add ( new DesignerActionPropertyItem ( "SnapMode", "附着模式", "draggable" ) );
					items.Add ( new DesignerActionPropertyItem ( "SnapTolerance", "附着距离", "draggable" ) );
				}

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多拖动设置...", "draggable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多拖动设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.DraggableSetting, this.JQueryElement.ID + " 拖动设置" ).ShowDialog ( );
				this.refreshDraggableSetting ( );
			}

			/// <summary>
			/// 获取或设置拖动的方向.
			/// </summary>
			public AxisType Axis
			{
				get
				{
					AxisType type;
					this.fetchEnum<AxisType> ( this.JQueryElement.DraggableSetting.Axis, AxisType.@null, out type );

					return type;
				}
				set
				{

					if ( value == AxisType.other )
						this.JQueryElement.DraggableSetting.Axis = "null /*javascript 代码*/";
					else
						this.JQueryElement.DraggableSetting.Axis = ( value == AxisType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动的方向.
			/// </summary>
			public string AxisText
			{
				get { return this.JQueryElement.DraggableSetting.Axis; }
				set
				{
					this.JQueryElement.DraggableSetting.Axis = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public ContainmentType Containment
			{
				get
				{
					ContainmentType type;
					this.fetchEnum<ContainmentType> ( this.JQueryElement.DraggableSetting.Containment, ContainmentType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ContainmentType.other )
						this.JQueryElement.DraggableSetting.Containment = "null /*javascript 代码*/";
					else
						this.JQueryElement.DraggableSetting.Containment = ( value == ContainmentType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public string ContainmentText
			{
				get { return this.JQueryElement.DraggableSetting.Containment; }
				set
				{
					this.JQueryElement.DraggableSetting.Containment = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否使用副本.
			/// </summary>
			public HelperType Helper
			{
				get
				{
					HelperType type;
					this.fetchEnum<HelperType> ( this.JQueryElement.DraggableSetting.Helper, HelperType.@null, out type );

					return type;
				}
				set
				{

					if ( value == HelperType.other )
						this.JQueryElement.DraggableSetting.Helper = "null /*javascript 代码*/";
					else
						this.JQueryElement.DraggableSetting.Helper = ( value == HelperType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置使用副本.
			/// </summary>
			public string HelperText
			{
				get { return this.JQueryElement.DraggableSetting.Helper; }
				set
				{
					this.JQueryElement.DraggableSetting.Helper = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动时的透明度.
			/// </summary>
			public decimal Opacity
			{
				get
				{
					decimal opacity;
					this.fetchDecimal ( this.JQueryElement.DraggableSetting.Opacity, 1, out opacity );

					return opacity;
				}
				set
				{

					this.JQueryElement.DraggableSetting.Opacity = ( value < 0 || value >= 1 ) ? string.Empty : value.ToString ( );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动时的透明度.
			/// </summary>
			public string OpacityText
			{
				get { return this.JQueryElement.DraggableSetting.Opacity; }
				set
				{
					this.JQueryElement.DraggableSetting.Opacity = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复原位的动画.
			/// </summary>
			public bool Revert
			{
				get
				{
					bool isRevert;
					this.fetchBoolean ( this.JQueryElement.DraggableSetting.Revert, false, out isRevert );

					return isRevert;
				}
				set
				{
					this.JQueryElement.DraggableSetting.Revert = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复原位的动画.
			/// </summary>
			public string RevertText
			{
				get { return this.JQueryElement.DraggableSetting.Revert; }
				set
				{
					this.JQueryElement.DraggableSetting.Revert = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复原位的动画时长.
			/// </summary>
			public int RevertDuration
			{
				get
				{
					int duration;
					this.fetchInteger ( this.JQueryElement.DraggableSetting.RevertDuration, 500, out duration );

					return duration;
				}
				set
				{
					this.JQueryElement.DraggableSetting.RevertDuration = ( value < 0 || value == 500 ? string.Empty : value.ToString ( ) );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否附着.
			/// </summary>
			public bool Snap
			{
				get { return this.JQueryElement.DraggableSetting.Snap != string.Empty; }
				set
				{
					this.JQueryElement.DraggableSetting.Snap = ( value ? "null /*选择器*/" : string.Empty );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置附着的目标.
			/// </summary>
			public string SnapText
			{
				get { return this.JQueryElement.DraggableSetting.Snap; }
				set
				{
					this.JQueryElement.DraggableSetting.Snap = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置附着模式.
			/// </summary>
			public SnapModeType SnapMode
			{
				get
				{
					SnapModeType type;
					this.fetchEnum<SnapModeType> ( this.JQueryElement.DraggableSetting.SnapMode, SnapModeType.@null, out type );

					return type;
				}
				set
				{

					if ( value == SnapModeType.other )
						this.JQueryElement.DraggableSetting.SnapMode = "null /*javascript 代码*/";
					else
						this.JQueryElement.DraggableSetting.SnapMode = ( value == SnapModeType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置附着模式.
			/// </summary>
			public string SnapModeText
			{
				get { return this.JQueryElement.DraggableSetting.SnapMode; }
				set
				{
					this.JQueryElement.DraggableSetting.SnapMode = value;
					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置附着模式的有效距离.
			/// </summary>
			public int SnapTolerance
			{
				get
				{
					int tolerance;
					this.fetchInteger ( this.JQueryElement.DraggableSetting.SnapTolerance, 20, out tolerance );

					return tolerance;
				}
				set
				{
					this.JQueryElement.DraggableSetting.SnapTolerance = ( value < 0 || value == 20 ? string.Empty : value.ToString ( ) );

					this.refreshDraggableSetting ( );
				}
			}

		}
		#endregion

		#region " DroppableDesignerAction "
		/// <summary>
		/// 拖放的设计行为.
		/// </summary>
		public class DroppableDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// Tolerance 类型.
			/// </summary>
			public enum ToleranceType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 完全进入可以拖放.
				/// </summary>
				fit = 1,
				/// <summary>
				/// 一半进入可以拖放.
				/// </summary>
				intersect = 2,
				/// <summary>
				/// 鼠标进入即可拖放.
				/// </summary>
				pointer = 3,
				/// <summary>
				/// 接触即可拖放.
				/// </summary>
				touch = 4,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// 创建一个拖放设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public DroppableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "拖放设置", "droppable" ) );

				items.Add ( new DesignerActionPropertyItem ( "Accept", "接受目标", "droppable", "指示拖放接受的目标, 对应一个函数或者选择器" ) );

				ToleranceType toleranceType;

				if ( this.fetchEnum<ToleranceType> ( this.JQueryElement.DroppableSetting.Tolerance, ToleranceType.@null, out toleranceType ) )
					items.Add ( new DesignerActionPropertyItem ( "Tolerance", "触发方式", "droppable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ToleranceText", "触发方式", "droppable", "拖放的触发方式, 可以是 'fit', 'intersect', 'pointer', 'touch'" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多拖放设置...", "droppable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多拖放设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.DroppableSetting, this.JQueryElement.ID + " 拖放设置" ).ShowDialog ( );
				this.refreshDroppableSetting ( );
			}

			/// <summary>
			/// 获取或设置拖动接受的目标.
			/// </summary>
			public string Accept
			{
				get { return this.JQueryElement.DroppableSetting.Accept; }
				set
				{
					this.JQueryElement.DroppableSetting.Accept = value;
					this.refreshDroppableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动触发方式.
			/// </summary>
			public ToleranceType Tolerance
			{
				get
				{
					ToleranceType type;
					this.fetchEnum<ToleranceType> ( this.JQueryElement.DroppableSetting.Tolerance, ToleranceType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ToleranceType.other )
						this.JQueryElement.DroppableSetting.Tolerance = "null /*javascript 代码*/";
					else
						this.JQueryElement.DroppableSetting.Tolerance = ( value == ToleranceType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshDroppableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动触发方式.
			/// </summary>
			public string ToleranceText
			{
				get { return this.JQueryElement.DroppableSetting.Tolerance; }
				set
				{
					this.JQueryElement.DroppableSetting.Tolerance = value;
					this.refreshDroppableSetting ( );
				}
			}

		}
		#endregion

		#region " ResizableDesignerAction "
		/// <summary>
		/// 缩放的设计行为.
		/// </summary>
		public class ResizableDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// AnimateDuration 类型.
			/// </summary>
			public enum AnimateDurationType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 缓慢的播放.
				/// </summary>
				slow = 1,
				/// <summary>
				/// 正常的播放.
				/// </summary>
				normal = 2,
				/// <summary>
				/// 快速的播放.
				/// </summary>
				fast = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Containment 类型.
			/// </summary>
			public enum ContainmentType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 容器为 parent.
				/// </summary>
				parent = 1,
				/// <summary>
				/// 容器为 document.
				/// </summary>
				document = 2,
				/// <summary>
				/// 容器为 window.
				/// </summary>
				window = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个缩放设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public ResizableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "缩放设置", "resizable" ) );

				ContainmentType containmentType;

				if ( this.fetchEnum<ContainmentType> ( this.JQueryElement.ResizableSetting.Containment, ContainmentType.@null, out containmentType ) )
					items.Add ( new DesignerActionPropertyItem ( "Containment", "容器", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ContainmentText", "容器", "resizable", "指示缩放所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" ) );

				items.Add ( new DesignerActionPropertyItem ( "Handles", "方向", "resizable", "指示缩放的方向, 为一个字符串, 比如: 'n, e, s, w', 可以从 'n, e, s, w, ne, se, sw, nw, all' 中取值" ) );

				int maxHeight;

				if ( this.fetchInteger ( this.JQueryElement.ResizableSetting.MaxHeight, 0, out maxHeight ) )
					items.Add ( new DesignerActionPropertyItem ( "MaxHeight", "最大高度", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MaxHeightText", "最大高度", "resizable" ) );

				int maxWidth;

				if ( this.fetchInteger ( this.JQueryElement.ResizableSetting.MaxWidth, 0, out maxWidth ) )
					items.Add ( new DesignerActionPropertyItem ( "MaxWidth", "最大宽度", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MaxWidthText", "最大宽度", "resizable" ) );

				int minHeight;

				if ( this.fetchInteger ( this.JQueryElement.ResizableSetting.MinHeight, 0, out minHeight ) )
					items.Add ( new DesignerActionPropertyItem ( "MinHeight", "最小高度", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MinHeightText", "最小高度", "resizable" ) );

				int minWidth;

				if ( this.fetchInteger ( this.JQueryElement.ResizableSetting.MinWidth, 0, out minWidth ) )
					items.Add ( new DesignerActionPropertyItem ( "MinWidth", "最小宽度", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MinWidthText", "最小宽度", "resizable" ) );

				bool isGhost;

				if ( this.JQueryElement.ResizableSetting.Ghost == string.Empty || this.fetchBoolean ( this.JQueryElement.ResizableSetting.Ghost, false, out isGhost ) )
					items.Add ( new DesignerActionPropertyItem ( "Ghost", "使用背影", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "GhostText", "使用背影", "resizable", "指示是否在缩放时使用阴影, 可以设置为 true 或者 false" ) );

				bool isAutoHide;

				if ( this.JQueryElement.ResizableSetting.AutoHide == string.Empty || this.fetchBoolean ( this.JQueryElement.ResizableSetting.AutoHide, false, out isAutoHide ) )
					items.Add ( new DesignerActionPropertyItem ( "AutoHide", "自动隐藏", "resizable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AutoHideText", "自动隐藏", "resizable", "指示是否自动隐藏, 可以设置为 true 或者 false" ) );

				bool isAnimate;

				if ( this.JQueryElement.ResizableSetting.Animate == string.Empty || this.fetchBoolean ( this.JQueryElement.ResizableSetting.Animate, false, out isAnimate ) )
				{
					items.Add ( new DesignerActionPropertyItem ( "Animate", "播放缩放动画", "resizable" ) );

					if ( this.Animate )
					{
						AnimateDurationType animateDurationType;

						if ( this.fetchEnum<AnimateDurationType> ( this.JQueryElement.ResizableSetting.AnimateDuration, AnimateDurationType.@null, out animateDurationType ) )
							items.Add ( new DesignerActionPropertyItem ( "AnimateDuration", "缩放动画时长", "resizable" ) );
						else
							items.Add ( new DesignerActionPropertyItem ( "AnimateDurationText", "缩放动画时长", "resizable" ) );

						items.Add ( new DesignerActionPropertyItem ( "AnimateEasing", "缩放动画效果", "resizable" ) );
					}

				}
				else
				{
					items.Add ( new DesignerActionPropertyItem ( "AnimateText", "播放缩放动画", "resizable", "指示是否播放缩放的动画, 可以设置为 true 或者 false" ) );

					AnimateDurationType animateDurationType;

					if ( this.fetchEnum<AnimateDurationType> ( this.JQueryElement.ResizableSetting.AnimateDuration, AnimateDurationType.@null, out animateDurationType ) )
						items.Add ( new DesignerActionPropertyItem ( "AnimateDuration", "缩放动画时长", "resizable" ) );
					else
						items.Add ( new DesignerActionPropertyItem ( "AnimateDurationText", "缩放动画时长", "resizable" ) );

					items.Add ( new DesignerActionPropertyItem ( "AnimateEasing", "缩放动画效果", "resizable" ) );
				}


				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多缩放设置...", "resizable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多缩放设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.ResizableSetting, this.JQueryElement.ID + " 缩放设置" ).ShowDialog ( );
				this.refreshResizableSetting ( );
			}

			/// <summary>
			/// 获取或设置是否播放恢复动画.
			/// </summary>
			public bool Animate
			{
				get
				{
					bool isAnimate;
					this.fetchBoolean ( this.JQueryElement.ResizableSetting.Animate, false, out isAnimate );

					return isAnimate;
				}
				set
				{
					this.JQueryElement.ResizableSetting.Animate = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复动画.
			/// </summary>
			public string AnimateText
			{
				get { return this.JQueryElement.ResizableSetting.Animate; }
				set
				{
					this.JQueryElement.ResizableSetting.Animate = value;

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置播放动画的时长.
			/// </summary>
			public AnimateDurationType AnimateDuration
			{
				get
				{
					AnimateDurationType type;
					this.fetchEnum<AnimateDurationType> ( this.JQueryElement.ResizableSetting.AnimateDuration, AnimateDurationType.@null, out type );

					return type;
				}
				set
				{

					if ( value == AnimateDurationType.other )
						this.JQueryElement.ResizableSetting.AnimateDuration = "null /*javascript 代码*/";
					else
						this.JQueryElement.ResizableSetting.AnimateDuration = ( value == AnimateDurationType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置播放动画的时长.
			/// </summary>
			public string AnimateDurationText
			{
				get { return this.JQueryElement.ResizableSetting.AnimateDuration; }
				set
				{
					this.JQueryElement.ResizableSetting.AnimateDuration = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置动画效果.
			/// </summary>
			public string AnimateEasing
			{
				get { return this.JQueryElement.ResizableSetting.AnimateEasing; }
				set
				{
					this.JQueryElement.ResizableSetting.AnimateEasing = value;

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置宽高比.
			/// </summary>
			public decimal AspectRatio
			{
				get
				{
					decimal aspectRatio;
					this.fetchDecimal ( this.JQueryElement.ResizableSetting.AspectRatio, 1, out aspectRatio );

					return aspectRatio;
				}
				set
				{

					this.JQueryElement.ResizableSetting.AspectRatio = ( value < 0 ) ? string.Empty : value.ToString ( );

					this.refreshDraggableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动隐藏.
			/// </summary>
			public bool AutoHide
			{
				get
				{
					bool isAutoHide;
					this.fetchBoolean ( this.JQueryElement.ResizableSetting.AutoHide, false, out isAutoHide );

					return isAutoHide;
				}
				set
				{
					this.JQueryElement.ResizableSetting.AutoHide = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动隐藏.
			/// </summary>
			public string AutoHideText
			{
				get { return this.JQueryElement.ResizableSetting.AutoHide; }
				set
				{
					this.JQueryElement.ResizableSetting.AutoHide = value;

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public ContainmentType Containment
			{
				get
				{
					ContainmentType type;
					this.fetchEnum<ContainmentType> ( this.JQueryElement.ResizableSetting.Containment, ContainmentType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ContainmentType.other )
						this.JQueryElement.ResizableSetting.Containment = "null /*javascript 代码*/";
					else
						this.JQueryElement.ResizableSetting.Containment = ( value == ContainmentType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public string ContainmentText
			{
				get { return this.JQueryElement.ResizableSetting.Containment; }
				set
				{
					this.JQueryElement.ResizableSetting.Containment = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复动画.
			/// </summary>
			public bool Ghost
			{
				get
				{
					bool isGhost;
					this.fetchBoolean ( this.JQueryElement.ResizableSetting.Ghost, false, out isGhost );

					return isGhost;
				}
				set
				{
					this.JQueryElement.ResizableSetting.Ghost = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放恢复动画.
			/// </summary>
			public string GhostText
			{
				get { return this.JQueryElement.ResizableSetting.Ghost; }
				set
				{
					this.JQueryElement.ResizableSetting.Ghost = value;

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置缩放的方向.
			/// </summary>
			public string Handles
			{
				get { return this.JQueryElement.ResizableSetting.Handles; }
				set
				{
					this.JQueryElement.ResizableSetting.Handles = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大高度.
			/// </summary>
			public int MaxHeight
			{
				get
				{
					int length;
					this.fetchInteger ( this.JQueryElement.ResizableSetting.MaxHeight, 0, out length );

					return length;
				}
				set
				{
					this.JQueryElement.ResizableSetting.MaxHeight = ( value <= 0 ? string.Empty : value.ToString ( ) );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大高度.
			/// </summary>
			public string MaxHeightText
			{
				get { return this.JQueryElement.ResizableSetting.MaxHeight; }
				set
				{
					this.JQueryElement.ResizableSetting.MaxHeight = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大宽度.
			/// </summary>
			public int MaxWidth
			{
				get
				{
					int length;
					this.fetchInteger ( this.JQueryElement.ResizableSetting.MaxWidth, 0, out length );

					return length;
				}
				set
				{
					this.JQueryElement.ResizableSetting.MaxWidth = ( value <= 0 ? string.Empty : value.ToString ( ) );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大宽度.
			/// </summary>
			public string MaxWidthText
			{
				get { return this.JQueryElement.ResizableSetting.MaxWidth; }
				set
				{
					this.JQueryElement.ResizableSetting.MaxWidth = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小高度.
			/// </summary>
			public int MinHeight
			{
				get
				{
					int length;
					this.fetchInteger ( this.JQueryElement.ResizableSetting.MinHeight, 10, out length );

					return length;
				}
				set
				{
					this.JQueryElement.ResizableSetting.MinHeight = ( value <= 0 || value == 10 ? string.Empty : value.ToString ( ) );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小高度.
			/// </summary>
			public string MinHeightText
			{
				get { return this.JQueryElement.ResizableSetting.MinHeight; }
				set
				{
					this.JQueryElement.ResizableSetting.MinHeight = value;
					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小宽度.
			/// </summary>
			public int MinWidth
			{
				get
				{
					int length;
					this.fetchInteger ( this.JQueryElement.ResizableSetting.MinWidth, 10, out length );

					return length;
				}
				set
				{
					this.JQueryElement.ResizableSetting.MinWidth = ( value < 0 || value == 10 ? string.Empty : value.ToString ( ) );

					this.refreshResizableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小宽度.
			/// </summary>
			public string MinWidthText
			{
				get { return this.JQueryElement.ResizableSetting.MinWidth; }
				set
				{
					this.JQueryElement.ResizableSetting.MinWidth = value;
					this.refreshResizableSetting ( );
				}
			}

		}
		#endregion

		#region " SelectableDesignerAction "
		/// <summary>
		/// 选中的设计行为.
		/// </summary>
		public class SelectableDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// Tolerance 类型.
			/// </summary>
			public enum ToleranceType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 全部进入后选中.
				/// </summary>
				fit = 1,
				/// <summary>
				/// 接触后即可选中.
				/// </summary>
				touch = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个选中设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public SelectableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "选中设置", "selectable" ) );

				ToleranceType toleranceType;

				if ( this.fetchEnum<ToleranceType> ( this.JQueryElement.SelectableSetting.Tolerance, ToleranceType.@null, out toleranceType ) )
					items.Add ( new DesignerActionPropertyItem ( "Tolerance", "触发方式", "selectable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ToleranceText", "触发方式", "selectable", "指示排列中选中的触发方式, 可以是 'touch' 或者 'fit'" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多选中设置...", "selectable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多选中设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.SelectableSetting, this.JQueryElement.ID + " 选中设置" ).ShowDialog ( );
				this.refreshSelectableSetting ( );
			}

			/// <summary>
			/// 获取或设置触发方式.
			/// </summary>
			public ToleranceType Tolerance
			{
				get
				{
					ToleranceType type;
					this.fetchEnum<ToleranceType> ( this.JQueryElement.SelectableSetting.Tolerance, ToleranceType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ToleranceType.other )
						this.JQueryElement.SelectableSetting.Tolerance = "null /*javascript 代码*/";
					else
						this.JQueryElement.SelectableSetting.Tolerance = ( value == ToleranceType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSelectableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置触发方式.
			/// </summary>
			public string ToleranceText
			{
				get { return this.JQueryElement.SelectableSetting.Tolerance; }
				set
				{
					this.JQueryElement.SelectableSetting.Tolerance = value;
					this.refreshSelectableSetting ( );
				}
			}

		}
		#endregion

		#region " SortableDesignerAction "
		/// <summary>
		/// 排列的设计行为.
		/// </summary>
		public class SortableDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// Axis 类型.
			/// </summary>
			public enum AxisType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// x 轴拖动.
				/// </summary>
				x = 1,
				/// <summary>
				/// y 轴拖动.
				/// </summary>
				y = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Containment 类型.
			/// </summary>
			public enum ContainmentType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 容器为 parent.
				/// </summary>
				parent = 1,
				/// <summary>
				/// 容器为 document.
				/// </summary>
				document = 2,
				/// <summary>
				/// 容器为 window.
				/// </summary>
				window = 3,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Helper 类型.
			/// </summary>
			public enum HelperType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 使用自身.
				/// </summary>
				original = 1,
				/// <summary>
				/// 使用副本.
				/// </summary>
				clone = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}

			/// <summary>
			/// Tolerance 类型.
			/// </summary>
			public enum ToleranceType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 一半进入可以排列.
				/// </summary>
				intersect = 1,
				/// <summary>
				/// 鼠标进入即可排列.
				/// </summary>
				pointer = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个排列设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public SortableDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "排列设置", "sortable" ) );

				AxisType axisType;

				if ( this.fetchEnum<AxisType> ( this.JQueryElement.SortableSetting.Axis, AxisType.@null, out axisType ) )
					items.Add ( new DesignerActionPropertyItem ( "Axis", "方向", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AxisText", "方向", "sortable", "指示拖动的方向, 可以是 'x', 'y'" ) );

				items.Add ( new DesignerActionPropertyItem ( "ConnectWith", "关联", "sortable", "指示关联的排列, 可以将元素拖放在关联列表中, 是一个选择器" ) );

				ContainmentType containmentType;

				if ( this.fetchEnum<ContainmentType> ( this.JQueryElement.SortableSetting.Containment, ContainmentType.@null, out containmentType ) )
					items.Add ( new DesignerActionPropertyItem ( "Containment", "容器", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ContainmentText", "容器", "sortable", "指示拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" ) );

				HelperType helperType;

				if ( this.fetchEnum<HelperType> ( this.JQueryElement.SortableSetting.Helper, HelperType.@null, out helperType ) )
					items.Add ( new DesignerActionPropertyItem ( "Helper", "helper", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "HelperText", "helper", "sortable", "指示是否使用副本 'original' 针对元素本身, 'clone' 针对元素的副本" ) );

				ToleranceType toleranceType;

				if ( this.fetchEnum<ToleranceType> ( this.JQueryElement.SortableSetting.Tolerance, ToleranceType.@null, out toleranceType ) )
					items.Add ( new DesignerActionPropertyItem ( "Tolerance", "触发方式", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ToleranceText", "触发方式", "sortable", "指示排列中拖放的触发方式, 可以是 'intersect' 或者 'pointer'" ) );

				decimal opacity;

				if ( this.fetchDecimal ( this.JQueryElement.DraggableSetting.Opacity, 1, out opacity ) )
					items.Add ( new DesignerActionPropertyItem ( "Opacity", "透明度", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "OpacityText", "透明度", "sortable" ) );

				bool isDropOnEmpty;

				if ( this.JQueryElement.SortableSetting.DropOnEmpty == string.Empty || this.fetchBoolean ( this.JQueryElement.SortableSetting.DropOnEmpty, true, out isDropOnEmpty ) )
					items.Add ( new DesignerActionPropertyItem ( "DropOnEmpty", "拖放空表", "sortable", "指示是否可以将条目拖放到空的关联列表中" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "DropOnEmptyText", "拖放空表", "sortable", "指示是否可以将条目拖放到空的关联列表中, 可以设置为 true 或者 false" ) );

				bool isRevert;

				if ( this.JQueryElement.SortableSetting.Revert == string.Empty || this.fetchBoolean ( this.JQueryElement.SortableSetting.Revert, false, out isRevert ) )
					items.Add ( new DesignerActionPropertyItem ( "Revert", "播放排列动画", "sortable" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "RevertText", "播放排列动画", "sortable", "指示是否在排列后播放恢复原位的动画, 比如: true, 或者是以毫秒为单位的动画播放时间, 比如: 500" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多排列设置...", "sortable" ) );
				return items;
			}

			/// <summary>
			/// 设置更多排列设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.SortableSetting, this.JQueryElement.ID + " 排列设置" ).ShowDialog ( );
				this.refreshSortableSetting ( );
			}

			/// <summary>
			/// 获取或设置排列拖动时的方向.
			/// </summary>
			public AxisType Axis
			{
				get
				{
					AxisType type;
					this.fetchEnum<AxisType> ( this.JQueryElement.SortableSetting.Axis, AxisType.@null, out type );

					return type;
				}
				set
				{

					if ( value == AxisType.other )
						this.JQueryElement.SortableSetting.Axis = "null /*javascript 代码*/";
					else
						this.JQueryElement.SortableSetting.Axis = ( value == AxisType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置排列拖动时的方向.
			/// </summary>
			public string AxisText
			{
				get { return this.JQueryElement.SortableSetting.Axis; }
				set
				{
					this.JQueryElement.SortableSetting.Axis = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置另一个关联的列表, 对应一个选择器.
			/// </summary>
			public string ConnectWith
			{
				get { return this.JQueryElement.SortableSetting.ConnectWith; }
				set
				{
					this.JQueryElement.SortableSetting.ConnectWith = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public ContainmentType Containment
			{
				get
				{
					ContainmentType type;
					this.fetchEnum<ContainmentType> ( this.JQueryElement.SortableSetting.Containment, ContainmentType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ContainmentType.other )
						this.JQueryElement.SortableSetting.Containment = "null /*javascript 代码*/";
					else
						this.JQueryElement.SortableSetting.Containment = ( value == ContainmentType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置容器.
			/// </summary>
			public string ContainmentText
			{
				get { return this.JQueryElement.SortableSetting.Containment; }
				set
				{
					this.JQueryElement.SortableSetting.Containment = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以拖放到空列表中.
			/// </summary>
			public bool DropOnEmpty
			{
				get
				{
					bool isDropOnEmpty;
					this.fetchBoolean ( this.JQueryElement.SortableSetting.DropOnEmpty, true, out isDropOnEmpty );

					return isDropOnEmpty;
				}
				set
				{
					this.JQueryElement.SortableSetting.DropOnEmpty = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以拖放到空列表中.
			/// </summary>
			public string DropOnEmptyText
			{
				get { return this.JQueryElement.SortableSetting.DropOnEmpty; }
				set
				{
					this.JQueryElement.SortableSetting.DropOnEmpty = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否使用副本.
			/// </summary>
			public HelperType Helper
			{
				get
				{
					HelperType type;
					this.fetchEnum<HelperType> ( this.JQueryElement.SortableSetting.Helper, HelperType.@null, out type );

					return type;
				}
				set
				{

					if ( value == HelperType.other )
						this.JQueryElement.SortableSetting.Helper = "null /*javascript 代码*/";
					else
						this.JQueryElement.SortableSetting.Helper = ( value == HelperType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置使用副本.
			/// </summary>
			public string HelperText
			{
				get { return this.JQueryElement.SortableSetting.Helper; }
				set
				{
					this.JQueryElement.SortableSetting.Helper = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置排列拖动时的透明度.
			/// </summary>
			public decimal Opacity
			{
				get
				{
					decimal opacity;
					this.fetchDecimal ( this.JQueryElement.SortableSetting.Opacity, 1, out opacity );

					return opacity;
				}
				set
				{

					this.JQueryElement.SortableSetting.Opacity = ( value < 0 || value >= 1 ) ? string.Empty : value.ToString ( );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置排列拖动时的透明度.
			/// </summary>
			public string OpacityText
			{
				get { return this.JQueryElement.SortableSetting.Opacity; }
				set
				{
					this.JQueryElement.SortableSetting.Opacity = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放排列动画.
			/// </summary>
			public bool Revert
			{
				get
				{
					bool isRevert;
					this.fetchBoolean ( this.JQueryElement.SortableSetting.Revert, false, out isRevert );

					return isRevert;
				}
				set
				{
					this.JQueryElement.SortableSetting.Revert = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否播放排列动画.
			/// </summary>
			public string RevertText
			{
				get { return this.JQueryElement.SortableSetting.Revert; }
				set
				{
					this.JQueryElement.SortableSetting.Revert = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动触发方式.
			/// </summary>
			public ToleranceType Tolerance
			{
				get
				{
					ToleranceType type;
					this.fetchEnum<ToleranceType> ( this.JQueryElement.SortableSetting.Tolerance, ToleranceType.@null, out type );

					return type;
				}
				set
				{

					if ( value == ToleranceType.other )
						this.JQueryElement.SortableSetting.Tolerance = "null /*javascript 代码*/";
					else
						this.JQueryElement.SortableSetting.Tolerance = ( value == ToleranceType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置拖动触发方式.
			/// </summary>
			public string ToleranceText
			{
				get { return this.JQueryElement.SortableSetting.Tolerance; }
				set
				{
					this.JQueryElement.SortableSetting.Tolerance = value;
					this.refreshSortableSetting ( );
				}
			}

		}
		#endregion

		#region " AccordionDesignerAction "
		/// <summary>
		/// 折叠列表的设计行为.
		/// </summary>
		public class AccordionDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个折叠列表设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public AccordionDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "折叠列表设置", "accordion" ) );

				bool isAutoHeight;

				if ( this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight, true, out isAutoHeight ) )
					items.Add ( new DesignerActionPropertyItem ( "AutoHeight", "相同最大高度", "accordion", "指示是否自动调整与最高的列表同高" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AutoHeightText", "相同最大高度", "accordion", "指示是否自动调整与最高的列表同高, 可以设置为 true 或者 false" ) );

				bool isCollapsible;

				if ( this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible, false, out isCollapsible ) )
					items.Add ( new DesignerActionPropertyItem ( "Collapsible", "可关闭所有", "accordion", "指示是否关闭所有的列表" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "CollapsibleText", "可关闭所有", "accordion", "指示是否关闭所有的列表, 可以设置为 true 或者 false" ) );

				bool isFillSpace;

				if ( this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace, false, out isFillSpace ) )
					items.Add ( new DesignerActionPropertyItem ( "FillSpace", "使用父容器高度", "accordion", "指示是否以父容器填充高度" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "FillSpaceText", "使用父容器高度", "accordion", "指示是否以父容器填充高度, 可以设置为 true 或者 false" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多折叠列表设置...", "accordion" ) );
				return items;
			}

			/// <summary>
			/// 设置更多折叠列表设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AccordionSetting, this.JQueryElement.ID + " 折叠列表设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置是否自动调整与最高的列表同高.
			/// </summary>
			public bool AutoHeight
			{
				get
				{
					bool isAutoHeight;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight, true, out isAutoHeight );

					return isAutoHeight;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动调整与最高的列表同高.
			/// </summary>
			public string AutoHeightText
			{
				get { return this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight; }
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.AutoHeight = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否关闭所有的列表.
			/// </summary>
			public bool Collapsible
			{
				get
				{
					bool isCollapsible;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible, false, out isCollapsible );

					return isCollapsible;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否关闭所有的列表.
			/// </summary>
			public string CollapsibleText
			{
				get { return this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible; }
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.Collapsible = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否以父容器填充高度.
			/// </summary>
			public bool FillSpace
			{
				get
				{
					bool isFillSpace;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace, false, out isFillSpace );

					return isFillSpace;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否以父容器填充高度.
			/// </summary>
			public string FillSpaceText
			{
				get { return this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace; }
				set
				{
					this.JQueryElement.WidgetSetting.AccordionSetting.FillSpace = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " AutocompleteDesignerAction "
		/// <summary>
		/// 自动填充的设计行为.
		/// </summary>
		public class AutocompleteDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个自动填充设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public AutocompleteDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "自动填充设置", "autocomplete" ) );

				int minLength;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength, 1, out minLength ) )
					items.Add ( new DesignerActionPropertyItem ( "MinLength", "最小字符数", "autocomplete", "指示激活填充需要最小的输入字符数, 比如: 3, 默认为 1" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MinLengthText", "最小字符数", "autocomplete", "指示激活填充需要最小的输入字符数, 比如: 3, 默认为 1" ) );

				items.Add ( new DesignerActionPropertyItem ( "Source", "源", "autocomplete", "指示用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数" ) );

				bool isAutoFocus;

				if ( this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus, true, out isAutoFocus ) )
					items.Add ( new DesignerActionPropertyItem ( "AutoFocus", "自动获得焦点", "autocomplete", "指示是否自动对焦到第一个条目" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AutoFocusText", "自动获得焦点", "autocomplete", "指示是否自动对焦到第一个条目, 可以设置为 true 或者 false" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多自动填充设置...", "autocomplete" ) );
				return items;
			}

			/// <summary>
			/// 设置更多自动填充设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AutocompleteSetting, this.JQueryElement.ID + " 自动填充设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置是否自动获得焦点.
			/// </summary>
			public bool AutoFocus
			{
				get
				{
					bool isAutoFocus;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus, false, out isAutoFocus );

					return isAutoFocus;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动获得焦点.
			/// </summary>
			public string AutoFocusText
			{
				get { return this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus; }
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.AutoFocus = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置激活填充需要最小的输入字符数.
			/// </summary>
			public int MinLength
			{
				get
				{
					int minLength;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength, 1, out minLength );

					return minLength;
				}
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength = ( value < 0 || value == 1 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置激活填充需要最小的输入字符数.
			/// </summary>
			public string MinLengthText
			{
				get { return this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength; }
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.MinLength = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置源.
			/// </summary>
			public string Source
			{
				get { return this.JQueryElement.WidgetSetting.AutocompleteSetting.Source; }
				set
				{
					this.JQueryElement.WidgetSetting.AutocompleteSetting.Source = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " ButtonDesignerAction "
		/// <summary>
		/// 按钮的设计行为.
		/// </summary>
		public class ButtonDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个按钮设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public ButtonDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "按钮设置", "button" ) );

				bool isText;

				if ( this.JQueryElement.WidgetSetting.ButtonSetting.Text == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.ButtonSetting.Text, true, out isText ) )
				{

					if ( this.Text )
						items.Add ( new DesignerActionPropertyItem ( "Label", "文本", "button", "指示按钮显示的文本, 比如: 'ok'" ) );
					else
						items.Add ( new DesignerActionPropertyItem ( "Icons", "图标", "button", "指示按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }" ) );

					items.Add ( new DesignerActionPropertyItem ( "Text", "显示文本", "button" ) );
				}
				else
				{
					items.Add ( new DesignerActionPropertyItem ( "Label", "文本", "button", "指示按钮显示的文本, 比如: 'ok'" ) );
					items.Add ( new DesignerActionPropertyItem ( "Icons", "图标", "button", "指示按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }" ) );

					items.Add ( new DesignerActionPropertyItem ( "TextText", "显示文本", "button", "指示按钮是否显示文本, 可以设置为 true 或者 false" ) );
				}

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多按钮设置...", "button" ) );
				return items;
			}

			/// <summary>
			/// 设置更多按钮设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.ButtonSetting, this.JQueryElement.ID + " 按钮设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置按钮文本.
			/// </summary>
			public string Label
			{
				get
				{ return this.JQueryElement.WidgetSetting.ButtonSetting.Label; }
				set
				{
					this.JQueryElement.WidgetSetting.ButtonSetting.Label = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置按钮图标.
			/// </summary>
			public string Icons
			{
				get
				{ return this.JQueryElement.WidgetSetting.ButtonSetting.Icons; }
				set
				{
					this.JQueryElement.WidgetSetting.ButtonSetting.Icons = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置按钮是否显示图标.
			/// </summary>
			public bool Text
			{
				get
				{
					bool isText;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.ButtonSetting.Text, true, out isText );

					return isText;
				}
				set
				{
					this.JQueryElement.WidgetSetting.ButtonSetting.Text = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置按钮是否显示图标.
			/// </summary>
			public string TextText
			{
				get { return this.JQueryElement.WidgetSetting.ButtonSetting.Text; }
				set
				{
					this.JQueryElement.WidgetSetting.ButtonSetting.Text = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " DatepickerDesignerAction "
		/// <summary>
		/// 日期框的设计行为.
		/// </summary>
		public class DatepickerDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个日期框设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public DatepickerDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "日期框设置", "datepicker" ) );

				items.Add ( new DesignerActionPropertyItem ( "CurrentText", "当天文本", "datepicker", "指示当天链接的文本, 比如: '今天'" ) );
				items.Add ( new DesignerActionPropertyItem ( "DayNames", "天的名称", "datepicker", "指示天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" ) );
				items.Add ( new DesignerActionPropertyItem ( "DayNamesMin", "天的最短名称", "datepicker", "指示天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" ) );
				items.Add ( new DesignerActionPropertyItem ( "DayNamesShort", "天的短名称", "datepicker", "指示天的短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" ) );
				items.Add ( new DesignerActionPropertyItem ( "MonthNames", "月的名称", "datepicker", "指示月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" ) );
				items.Add ( new DesignerActionPropertyItem ( "MonthNamesShort", "月的短名称", "datepicker", "指示月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" ) );

				int numberOfMonths;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths, 1, out numberOfMonths ) )
					items.Add ( new DesignerActionPropertyItem ( "NumberOfMonths", "显示月份数", "datepicker", "指示显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3]" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "NumberOfMonthsText", "显示月份数", "datepicker", "指示显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3]" ) );

				items.Add ( new DesignerActionPropertyItem ( "MaxDate", "最大日期", "datepicker", "指示最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周" ) );
				items.Add ( new DesignerActionPropertyItem ( "MinDate", "最小日期", "datepicker", "指示最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周" ) );

				bool isChangeMonth;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth, false, out isChangeMonth ) )
					items.Add ( new DesignerActionPropertyItem ( "ChangeMonth", "可选择月份", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ChangeMonthText", "可选择月份", "datepicker", "指示是否允许使用下拉框改变月份, 可以设置为 true 或者 false" ) );

				bool isChangeYear;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear, false, out isChangeYear ) )
					items.Add ( new DesignerActionPropertyItem ( "ChangeYear", "可选择年份", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ChangeYearText", "可选择年份", "datepicker", "指示是否允许使用下拉框改变年份, 可以设置为 true 或者 false" ) );

				bool isSelectOtherMonths;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths, false, out isSelectOtherMonths ) )
					items.Add ( new DesignerActionPropertyItem ( "SelectOtherMonths", "可选择其它月份", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "SelectOtherMonthsText", "可选择其它月份", "datepicker", "指示是否可以选择其它的月份, 可以设置为 true 或者 false" ) );

				bool isShowOtherMonths;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths, false, out isShowOtherMonths ) )
					items.Add ( new DesignerActionPropertyItem ( "ShowOtherMonths", "显示其它月份", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ShowOtherMonthsText", "显示其它月份", "datepicker", "指示是否显示其它月份, 可以设置为 true 或者 false" ) );

				bool isShowButtonPanel;

				if ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel, false, out isShowButtonPanel ) )
					items.Add ( new DesignerActionPropertyItem ( "ShowButtonPanel", "显示按钮面板", "datepicker" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ShowButtonPanelText", "显示按钮面板", "datepicker", "是否显示按钮面板, 可以设置为 true 或者 false" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多日期框设置...", "datepicker" ) );
				return items;
			}

			/// <summary>
			/// 设置更多日期框设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.DatepickerSetting, this.JQueryElement.ID + " 日期框设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置当天文本.
			/// </summary>
			public string CurrentText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.CurrentText; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.CurrentText = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置天的名称.
			/// </summary>
			public string DayNames
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.DayNames; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.DayNames = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置天的最短名称.
			/// </summary>
			public string DayNamesMin
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.DayNamesMin; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.DayNamesMin = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置天的短名称.
			/// </summary>
			public string DayNamesShort
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.DayNamesShort; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.DayNamesShort = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置月的名称.
			/// </summary>
			public string MonthNames
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.MonthNames; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.MonthNames = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置月的短名称.
			/// </summary>
			public string MonthNamesShort
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.MonthNamesShort; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.MonthNamesShort = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置显示月份数.
			/// </summary>
			public int NumberOfMonths
			{
				get
				{
					int numberOfMonths;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths, 1, out numberOfMonths );

					return numberOfMonths;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths = ( value < 0 || value == 1 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置显示月份数.
			/// </summary>
			public string NumberOfMonthsText
			{
				get { return this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.NumberOfMonths = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大日期.
			/// </summary>
			public string MaxDate
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.MaxDate; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.MaxDate = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小日期.
			/// </summary>
			public string MinDate
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.MinDate; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.MinDate = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以更改月份.
			/// </summary>
			public bool ChangeMonth
			{
				get
				{
					bool isChangeMonth;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth, false, out isChangeMonth );

					return isChangeMonth;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以更改月份.
			/// </summary>
			public string ChangeMonthText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeMonth = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以更改年份.
			/// </summary>
			public bool ChangeYear
			{
				get
				{
					bool isChangeYear;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear, false, out isChangeYear );

					return isChangeYear;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以更改年份.
			/// </summary>
			public string ChangeYearText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ChangeYear = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以选择其它月份.
			/// </summary>
			public bool SelectOtherMonths
			{
				get
				{
					bool isSelectOtherMonths;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths, false, out isSelectOtherMonths );

					return isSelectOtherMonths;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可以选择其它月份.
			/// </summary>
			public string SelectOtherMonthsText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.SelectOtherMonths = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否显示其它月份.
			/// </summary>
			public bool ShowOtherMonths
			{
				get
				{
					bool isShowOtherMonths;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths, false, out isShowOtherMonths );

					return isShowOtherMonths;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否显示其它月份.
			/// </summary>
			public string ShowOtherMonthsText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ShowOtherMonths = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否显示按钮面板.
			/// </summary>
			public bool ShowButtonPanel
			{
				get
				{
					bool isShowButtonPanel;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel, false, out isShowButtonPanel );

					return isShowButtonPanel;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否显示按钮面板.
			/// </summary>
			public string ShowButtonPanelText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel; }
				set
				{
					this.JQueryElement.WidgetSetting.DatepickerSetting.ShowButtonPanel = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " DialogDesignerAction "
		/// <summary>
		/// 对话框的设计行为.
		/// </summary>
		public class DialogDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个对话框设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public DialogDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "对话框设置", "dialog" ) );

				items.Add ( new DesignerActionPropertyItem ( "Buttons", "按钮", "dialog", "指示对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }" ) );
				items.Add ( new DesignerActionPropertyItem ( "Title", "标题", "dialog", "指示对话框标题, 比如: 'my title'" ) );
				items.Add ( new DesignerActionPropertyItem ( "Position", "位置", "dialog", "指示对话框的位置, 比如: ['right','top'], [100, 200]" ) );

				int height;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.DialogSetting.Height, 0, out height ) )
					items.Add ( new DesignerActionPropertyItem ( "Height", "高度", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "HeightText", "高度", "dialog" ) );

				int width;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.DialogSetting.Width, 0, out width ) )
					items.Add ( new DesignerActionPropertyItem ( "Width", "宽度", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "WidthText", "宽度", "dialog" ) );

				bool isAutoOpen;

				if ( this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen, true, out isAutoOpen ) )
					items.Add ( new DesignerActionPropertyItem ( "AutoOpen", "自动打开", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "AutoOpenText", "自动打开", "dialog", "指示对话框是否自动打开, 可以设置为 true 或者 false" ) );

				bool isCloseOnEscape;

				if ( this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape, true, out isCloseOnEscape ) )
					items.Add ( new DesignerActionPropertyItem ( "CloseOnEscape", "Esc 关闭", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "CloseOnEscapeText", "Esc 关闭", "dialog", "指示是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false" ) );

				bool isDraggable;

				if ( this.JQueryElement.WidgetSetting.DialogSetting.Draggable == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.Draggable, true, out isDraggable ) )
					items.Add ( new DesignerActionPropertyItem ( "Draggable", "可拖动", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "DraggableText", "可拖动", "dialog", "指示是否允许拖动, 可以设置为 true 或者 false" ) );

				bool isResizable;

				if ( this.JQueryElement.WidgetSetting.DialogSetting.Resizable == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.Resizable, true, out isResizable ) )
					items.Add ( new DesignerActionPropertyItem ( "Resizable", "可缩放", "dialog" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ResizableText", "可缩放", "dialog", "指示是否允许缩放, 可以设置为 true 或者 false" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多对话框设置...", "dialog" ) );
				return items;
			}

			/// <summary>
			/// 设置更多对话框设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.DialogSetting, this.JQueryElement.ID + " 对话框设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置对话框按钮.
			/// </summary>
			public string Buttons
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Buttons; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Buttons = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置对话框标题.
			/// </summary>
			public string Title
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Title; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Title = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置位置.
			/// </summary>
			public string Position
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Position; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Position = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置高度.
			/// </summary>
			public int Height
			{
				get
				{
					int height;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.DialogSetting.Height, 0, out height );

					return height;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Height = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置高度.
			/// </summary>
			public string HeightText
			{
				get { return this.JQueryElement.WidgetSetting.DialogSetting.Height; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Height = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置宽度.
			/// </summary>
			public int Width
			{
				get
				{
					int width;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.DialogSetting.Width, 0, out width );

					return width;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Width = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置宽度.
			/// </summary>
			public string WidthText
			{
				get { return this.JQueryElement.WidgetSetting.DialogSetting.Width; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Width = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动打开.
			/// </summary>
			public bool AutoOpen
			{
				get
				{
					bool isAutoOpen;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen, true, out isAutoOpen );

					return isAutoOpen;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否自动打开.
			/// </summary>
			public string AutoOpenText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.AutoOpen = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否按下 Esc 关闭.
			/// </summary>
			public bool CloseOnEscape
			{
				get
				{
					bool isCloseOnEscape;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape, true, out isCloseOnEscape );

					return isCloseOnEscape;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否按下 Esc 关闭.
			/// </summary>
			public string CloseOnEscapeText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.CloseOnEscape = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可拖动.
			/// </summary>
			public bool Draggable
			{
				get
				{
					bool isDraggable;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.Draggable, true, out isDraggable );

					return isDraggable;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Draggable = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可拖动.
			/// </summary>
			public string DraggableText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Draggable; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Draggable = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可缩放.
			/// </summary>
			public bool Resizable
			{
				get
				{
					bool isResizable;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.DialogSetting.Resizable, true, out isResizable );

					return isResizable;
				}
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Resizable = ( value ? string.Empty : value.ToString ( ).ToLower ( ) );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否可缩放.
			/// </summary>
			public string ResizableText
			{
				get
				{ return this.JQueryElement.WidgetSetting.DialogSetting.Resizable; }
				set
				{
					this.JQueryElement.WidgetSetting.DialogSetting.Resizable = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " ProgressbarDesignerAction "
		/// <summary>
		/// 进度条的设计行为.
		/// </summary>
		public class ProgressbarDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个进度条设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public ProgressbarDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "进度条设置", "progressbar" ) );

				int value;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.ProgressbarSetting.Value, 0, out value ) )
					items.Add ( new DesignerActionPropertyItem ( "Value", "进度", "progressbar" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "ValueText", "进度", "progressbar" ) );

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多进度条设置...", "progressbar" ) );
				return items;
			}

			/// <summary>
			/// 设置更多进度条设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.ProgressbarSetting, this.JQueryElement.ID + " 进度条设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置进度.
			/// </summary>
			public int Value
			{
				get
				{
					int value;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.ProgressbarSetting.Value, 0, out value );

					return value;
				}
				set
				{
					this.JQueryElement.WidgetSetting.ProgressbarSetting.Value = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置进度.
			/// </summary>
			public string ValueText
			{
				get { return this.JQueryElement.WidgetSetting.ProgressbarSetting.Value; }
				set
				{
					this.JQueryElement.WidgetSetting.ProgressbarSetting.Value = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " SliderDesignerAction "
		/// <summary>
		/// 分割条的设计行为.
		/// </summary>
		public class SliderDesignerAction : JQueryElementDesignerAction
		{

			#region " Enum "
			/// <summary>
			/// Orientation 类型.
			/// </summary>
			public enum OrientationType
			{
				/// <summary>
				/// 空.
				/// </summary>
				@null = 0,
				/// <summary>
				/// 水平.
				/// </summary>
				horizontal = 1,
				/// <summary>
				/// 垂直.
				/// </summary>
				vertical = 2,
				/// <summary>
				/// 无关的操作.
				/// </summary>
				other = -1,
			}
			#endregion

			/// <summary>
			/// 创建一个分割条设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public SliderDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "分割条设置", "slider" ) );

				int max;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Max, 100, out max ) )
					items.Add ( new DesignerActionPropertyItem ( "Max", "最大值", "slider" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MaxText", "最大值", "slider" ) );

				int min;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Min, 0, out min ) )
					items.Add ( new DesignerActionPropertyItem ( "Min", "最小值", "slider" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "MinText", "最小值", "slider" ) );

				int step;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Step, 1, out step ) )
					items.Add ( new DesignerActionPropertyItem ( "Step", "步长", "slider" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "StepText", "步长", "slider" ) );

				OrientationType orientationType;

				if ( this.fetchEnum<OrientationType> ( this.JQueryElement.WidgetSetting.SliderSetting.Orientation, OrientationType.@null, out orientationType ) )
					items.Add ( new DesignerActionPropertyItem ( "Orientation", "方向", "slider" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "OrientationText", "方向", "slider", "指示分割条的方向, 比如: 'horizontal', 'vertical'" ) );

				bool isRange;

				if ( this.JQueryElement.WidgetSetting.SliderSetting.Range == string.Empty || this.fetchBoolean ( this.JQueryElement.WidgetSetting.SliderSetting.Range, false, out isRange ) )
				{

					if ( this.Range )
						items.Add ( new DesignerActionPropertyItem ( "Values", "范围值", "slider", "指示分割条的范围值, 比如: [1, 4, 10]" ) );
					else
					{
						int value;

						if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Value, 0, out value ) )
							items.Add ( new DesignerActionPropertyItem ( "Value", "值", "slider" ) );
						else
							items.Add ( new DesignerActionPropertyItem ( "ValueText", "值", "slider" ) );

					}

					items.Add ( new DesignerActionPropertyItem ( "Range", "使用范围", "slider" ) );
				}
				else
				{
					int value;

					if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Value, 0, out value ) )
						items.Add ( new DesignerActionPropertyItem ( "Value", "值", "slider" ) );
					else
						items.Add ( new DesignerActionPropertyItem ( "ValueText", "值", "slider" ) );

					items.Add ( new DesignerActionPropertyItem ( "Values", "范围值", "slider", "指示分割条的范围值, 比如: [1, 4, 10]" ) );

					items.Add ( new DesignerActionPropertyItem ( "RangeText", "使用范围", "slider", "指示分割条是否使用范围, 或者为 'min', 'max' 中的一种" ) );
				}

				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多分割条设置...", "slider" ) );
				return items;
			}

			/// <summary>
			/// 设置更多分割条设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.SliderSetting, this.JQueryElement.ID + " 分割条设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置范围值.
			/// </summary>
			public string Values
			{
				get
				{ return this.JQueryElement.WidgetSetting.SliderSetting.Values; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Values = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置值.
			/// </summary>
			public int Value
			{
				get
				{
					int value;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Value, 0, out value );

					return value;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Value = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置值.
			/// </summary>
			public string ValueText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Value; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Value = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大值.
			/// </summary>
			public int Max
			{
				get
				{
					int max;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Max, 100, out max );

					return max;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Max = ( value < 0 || value == 100 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最大值.
			/// </summary>
			public string MaxText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Max; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Max = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小值.
			/// </summary>
			public int Min
			{
				get
				{
					int min;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Min, 0, out min );

					return min;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Min = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置最小值.
			/// </summary>
			public string MinText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Min; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Min = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置步长.
			/// </summary>
			public int Step
			{
				get
				{
					int min;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.SliderSetting.Step, 1, out min );

					return min;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Step = ( value < 0 || value == 1 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置步长.
			/// </summary>
			public string StepText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Step; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Step = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置方向.
			/// </summary>
			public OrientationType Orientation
			{
				get
				{
					OrientationType type;
					this.fetchEnum<OrientationType> ( this.JQueryElement.WidgetSetting.SliderSetting.Orientation, OrientationType.@null, out type );

					return type;
				}
				set
				{

					if ( value == OrientationType.other )
						this.JQueryElement.WidgetSetting.SliderSetting.Orientation = "null /*javascript 代码*/";
					else
						this.JQueryElement.WidgetSetting.SliderSetting.Orientation = ( value == OrientationType.@null ) ? string.Empty : string.Format ( "'{0}'", value );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置方向.
			/// </summary>
			public string OrientationText
			{
				get { return this.JQueryElement.WidgetSetting.SliderSetting.Orientation; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Orientation = value;
					this.refreshSortableSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否使用范围.
			/// </summary>
			public bool Range
			{
				get
				{
					bool isRange;
					this.fetchBoolean ( this.JQueryElement.WidgetSetting.SliderSetting.Range, false, out isRange );

					return isRange;
				}
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Range = ( value ? value.ToString ( ).ToLower ( ) : string.Empty );
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置是否使用范围.
			/// </summary>
			public string RangeText
			{
				get
				{ return this.JQueryElement.WidgetSetting.SliderSetting.Range; }
				set
				{
					this.JQueryElement.WidgetSetting.SliderSetting.Range = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " TabsDesignerAction "
		/// <summary>
		/// 分组标签的设计行为.
		/// </summary>
		public class TabsDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个分组标签设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public TabsDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "分组标签设置", "tabs" ) );

				int selected;

				if ( this.fetchInteger ( this.JQueryElement.WidgetSetting.TabsSetting.Selected, 0, out selected ) )
					items.Add ( new DesignerActionPropertyItem ( "Selected", "选中标签索引", "tabs" ) );
				else
					items.Add ( new DesignerActionPropertyItem ( "SelectedText", "选中标签索引", "tabs" ) );

				items.Add ( new DesignerActionPropertyItem ( "Event", "触发事件", "tabs", "指示触发切换的事件名称, 默认: 'click'" ) );
				items.Add ( new DesignerActionMethodItem ( this, "DesignerWindow", "更多分组标签设置...", "tabs" ) );
				return items;
			}

			/// <summary>
			/// 设置更多分组标签设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.TabsSetting, this.JQueryElement.ID + " 分组标签设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// 获取或设置选中标签索引.
			/// </summary>
			public int Selected
			{
				get
				{
					int value;
					this.fetchInteger ( this.JQueryElement.WidgetSetting.TabsSetting.Selected, 0, out value );

					return value;
				}
				set
				{
					this.JQueryElement.WidgetSetting.TabsSetting.Selected = ( value < 0 ? string.Empty : value.ToString ( ) );

					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置选中标签索引.
			/// </summary>
			public string SelectedText
			{
				get { return this.JQueryElement.WidgetSetting.TabsSetting.Selected; }
				set
				{
					this.JQueryElement.WidgetSetting.TabsSetting.Selected = value;
					this.refreshWidgetSetting ( );
				}
			}

			/// <summary>
			/// 获取或设置触发事件.
			/// </summary>
			public string Event
			{
				get { return this.JQueryElement.WidgetSetting.TabsSetting.Event; }
				set
				{
					this.JQueryElement.WidgetSetting.TabsSetting.Event = value;
					this.refreshWidgetSetting ( );
				}
			}

		}
		#endregion

		#region " AjaxDesignerAction "
		/// <summary>
		/// Ajax 设计行为.
		/// </summary>
		public class AjaxDesignerAction : JQueryElementDesignerAction
		{

			/// <summary>
			/// 创建一个 Ajax 设计行为.
			/// </summary>
			/// <param name="designer">设计器.</param>
			public AjaxDesignerAction ( JQueryElementDesigner designer )
				: base ( designer )
			{ }

			/// <summary>
			/// 获取行为.
			/// </summary>
			/// <returns>行为.</returns>
			public override DesignerActionItemCollection GetSortedActionItems ( )
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection ( );

				items.Add ( new DesignerActionHeaderItem ( "Ajax 设置", "ajax" ) );

				for ( int index = 0; index < 4 && index < this.JQueryElement.WidgetSetting.AjaxSettings.Count; index++ )
					items.Add ( new DesignerActionMethodItem ( this, string.Format ( "DesignerWindow{0}", index + 1 ), string.Format ( "Ajax[{0}] 设置...", index + 1 ), "ajax" ) );

				items.Add ( new DesignerActionTextItem ( "请在源视图中添加 Ajax 操作", "ajax" ) );
				return items;
			}

			/// <summary>
			/// 设置更多 Ajax 设置.
			/// </summary>
			public void DesignerWindow ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings, this.JQueryElement.ID + " Ajax 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// Ajax 1 设置.
			/// </summary>
			public void DesignerWindow1 ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings[0], this.JQueryElement.ID + " Ajax 1 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// Ajax 1 设置.
			/// </summary>
			public void DesignerWindow2 ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings[1], this.JQueryElement.ID + " Ajax 2 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// Ajax 1 设置.
			/// </summary>
			public void DesignerWindow3 ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings[2], this.JQueryElement.ID + " Ajax 3 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

			/// <summary>
			/// Ajax 4 设置.
			/// </summary>
			public void DesignerWindow4 ( )
			{
				new FormDesigner ( this.JQueryElement.WidgetSetting.AjaxSettings[3], this.JQueryElement.ID + " Ajax 4 设置" ).ShowDialog ( );
				this.refreshWidgetSetting ( );
			}

		}
		#endregion

		#region " FormDesigner "
		/// <summary>
		/// 设计器窗体.
		/// </summary>
		public sealed class FormDesigner : Form
		{
			private readonly PropertyGrid propertyGrid;

			/// <summary>
			/// 创建一个设计器窗体.
			/// </summary>
			public FormDesigner ( object setting, string text )
			{
				this.propertyGrid = new PropertyGrid ( );

				this.propertyGrid.Dock = DockStyle.Fill;
				this.propertyGrid.Name = "propertyGrid";
				this.propertyGrid.SelectedObject = setting;

				try
				{ this.propertyGrid.Font = new Font ( "Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ( ( byte ) ( 0 ) ) ); }
				catch { }


				this.Controls.Add ( this.propertyGrid );
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "FormDesigner";
				this.ShowIcon = false;
				this.ShowInTaskbar = false;
				this.Text = text;
				this.TopMost = true;

				this.StartPosition = FormStartPosition.CenterScreen;
			}

		}
		#endregion

	}
	#endregion

	#region " BaseWidget "
	/// <summary>
	/// 插件的基础类.
	/// </summary>
	public class BaseWidget
		: JQueryElement
	{
		protected readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		protected readonly WidgetType type;

		#region " hide "

		/// <summary>
		/// 获取或设置元素的拖动设置.
		/// </summary>
		[Browsable ( false )]
		public override DraggableSettingEdit DraggableSetting
		{
			get { return base.DraggableSetting; }
			set { base.DraggableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的拖放设置.
		/// </summary>
		[Browsable ( false )]
		public override DroppableSettingEdit DroppableSetting
		{
			get { return base.DroppableSetting; }
			set { base.DroppableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的排列设置.
		/// </summary>
		[Browsable ( false )]
		public override SortableSettingEdit SortableSetting
		{
			get { return base.SortableSetting; }
			set { base.SortableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的选中设置.
		/// </summary>
		[Browsable ( false )]
		public override SelectableSettingEdit SelectableSetting
		{
			get { return base.SelectableSetting; }
			set { base.SelectableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的缩放设置.
		/// </summary>
		[Browsable ( false )]
		public override ResizableSettingEdit ResizableSetting
		{
			get { return base.ResizableSetting; }
			set { base.ResizableSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的 Widget 设置.
		/// </summary>
		[Browsable ( false )]
		public override WidgetSettingEdit WidgetSetting
		{
			get { return base.WidgetSetting; }
			set { base.WidgetSetting = value; }
		}

		/// <summary>
		/// 获取或设置元素的 Repeater 设置.
		/// </summary>
		[Browsable ( false )]
		public override RepeaterSettingEdit RepeaterSetting
		{
			get { return base.RepeaterSetting; }
			set { base.RepeaterSetting = value; }
		}
		#endregion

		/// <summary>
		/// 创建一个插件的基础类.
		/// </summary>
		/// <param name="type">插件的类型.</param>
		public BaseWidget ( WidgetType type )
			: base ( )
		{ this.type = type; }

		protected T getEnum<T> ( string text, T defalutValue )
			where T : struct
		{
			T value;

			if ( string.IsNullOrEmpty ( text ) )
				value = defalutValue;
			// HACK: 可能需要添加 V5
#if V4
			else if ( !Enum.TryParse ( text, out value ) )
				value = defalutValue;
#else
			else
				try
				{ value = ( T ) Enum.Parse ( typeof ( T ), text.Trim ( '\'' ).Trim ( '"' ), true ); }
				catch
				{ value = defalutValue; }
#endif

			return value;
		}

		protected decimal getDecimal ( string text, decimal defaultValue )
		{
			decimal value;

			if ( string.IsNullOrEmpty ( text ) || !decimal.TryParse ( text, out value ) )
				value = defaultValue;

			return value;
		}

		protected bool getBoolean ( string text, bool defaultValue )
		{
			bool value;

			if ( string.IsNullOrEmpty ( text ) || !bool.TryParse ( text, out value ) )
				value = defaultValue;

			return value;
		}

		protected int getInteger ( string text, int defaultValue )
		{
			int value;

			if ( string.IsNullOrEmpty ( text ) || !int.TryParse ( text, out value ) )
				value = defaultValue;

			return value;
		}

		protected override void LoadViewState ( object savedState )
		{
			base.LoadViewState ( savedState );

			( this.editHelper as IStateManager ).LoadViewState ( this.ViewState["EditHelper"] );
		}

		protected override object SaveViewState ( )
		{
			this.ViewState["EditHelper"] = ( this.editHelper as IStateManager ).SaveViewState ( );

			return base.SaveViewState ( );
		}

	}
	#endregion

}

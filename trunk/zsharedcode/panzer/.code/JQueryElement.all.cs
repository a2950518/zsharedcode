/* allinone合并了多个文件,下载使用多个allinone代码,可能会遇到重复的类型定义,http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/JQueryElement.all.cs */
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;
using System;
using System.Drawing.Design;
using System.Globalization;
using zoyobar.shared.panzer.code;
using System.ComponentModel.Design;
using NParameter = zoyobar.shared.panzer.web.jqueryui.Parameter;
using System.Reflection;
using System.Web;
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

		private ElementType elementType = ElementType.None;
		private string attribute;
		private bool isVariable = false;

		private readonly DraggableSettingEdit draggableSetting = new DraggableSettingEdit ( );
		private readonly DroppableSettingEdit droppableSetting = new DroppableSettingEdit ( );
		private readonly SortableSettingEdit sortableSetting = new SortableSettingEdit ( );
		private readonly SelectableSettingEdit selectableSetting = new SelectableSettingEdit ( );
		private readonly ResizableSettingEdit resizableSetting = new ResizableSettingEdit ( );

		private readonly WidgetSettingEdit widgetSetting = new WidgetSettingEdit ( );

		private readonly RepeaterSettingEdit repeaterSetting = new RepeaterSettingEdit ( );

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
		/// 获取元素的 Repeater 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "元素相关的 Repeater 设置, 前提 ElementType 不能为 None" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public RepeaterSettingEdit RepeaterSetting
		{
			get { return this.repeaterSetting; }
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

		/// <summary>
		/// 获取或设置是否生成 jquery 对应的 javascript 变量, 如果使用了 Repeater, 则在运行时自动调整为 true.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "是否以 ClientID 生成对应的 javascript 变量, 如果使用了 Repeater, 则在运行时自动调整为 true" )]
		[DefaultValue ( false )]
		public bool IsVariable
		{
			get { return this.isVariable; }
			set { this.isVariable = value; }
		}

		/// <summary>
		/// 获取或设置元素的属性.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "最终在页面上生成的元素的属性" )]
		[DefaultValue ( "" )]
		public string Attribute
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

			JQueryUI jquery = new JQueryUI ( string.Format ( "'#{0}'", this.ClientID ) );

			if ( this.elementType != ElementType.None )
			{
				string style = string.Empty;

				if ( this.Width != Unit.Empty )
					style += string.Format ( "width:{0};", this.Width );

				if ( this.Height != Unit.Empty )
					style += string.Format ( "height:{0};", this.Height );

				writer.Write (
					"<{0} id={1}{2}{3}{4}{5}{6}>",
					this.elementType.ToString ( ).ToLower ( ),
					this.ClientID,
					string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : " class=" + WebUtility.HtmlEncode ( this.CssClass ),
					string.IsNullOrEmpty ( this.ToolTip ) ? string.Empty : " title=" + WebUtility.HtmlEncode ( this.ToolTip ),
					string.IsNullOrEmpty ( style ) ? string.Empty : " style=" + WebUtility.HtmlEncode ( style ),
					string.IsNullOrEmpty ( this.attribute ) ? string.Empty : " " + this.attribute.Trim ( ),
					( this.elementType == ElementType.Input ) ? " /" : string.Empty
					);
			}

			if ( this.elementType != ElementType.Input )
			{
				this.html.RenderControl ( writer );
				// base.Render ( writer );

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

			this.ViewState["JQueryElement"] = states;

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
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
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
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isDraggable = false;

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
			get { return this.editHelper.InnerOptionEdits; }
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

		#region " Option "
		/// <summary>
		/// 获取或设置拖动是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置是否添加样式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否添加样式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AddClasses
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.addClasses ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.addClasses, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标点击在何处拖动有效, 可以是 'parent', 'body' 等.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标点击在何处拖动有效, 可以是 'parent', 'body' 等" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendTo ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendTo, value ); }
		}

		/// <summary>
		/// 获取或设置拖动的方向, 可以是 'x', 'y'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动的方向, 可以是 'x', 'y'" )]
		[NotifyParentProperty ( true )]
		public string Axis
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.axis ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.axis, value ); }
		}

		/// <summary>
		/// 获取或设置不参加拖动的元素, 是一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加拖动的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置关联的排列, 是一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示关联的排列, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string ConnectToSortable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.connectToSortable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.connectToSortable, value ); }
		}

		/// <summary>
		/// 获取或设置拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" )]
		[NotifyParentProperty ( true )]
		public string Containment
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.containment ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.containment, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标样式, 比如: 'auto'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标样式, 比如: 'auto'" )]
		[NotifyParentProperty ( true )]
		public string Cursor
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursor ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursor, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性" )]
		[NotifyParentProperty ( true )]
		public string CursorAt
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursorAt ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursorAt, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的延迟, 以毫秒计算" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发拖动, 比如: 20.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发排列, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来移动元素, 为一个数组, 比如: [10, 30].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来移动元素, 为一个数组, 比如: [10, 30]" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.grid ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.grid, value ); }
		}

		/// <summary>
		/// 获取或设置用于点击的元素, 点击后拖动才有效, 对应一个 dom 元素或者选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于点击的元素, 点击后拖动才有效, 对应一个 dom 元素或者选择器" )]
		[NotifyParentProperty ( true )]
		public string Handle
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.handle ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.handle, value ); }
		}

		/// <summary>
		/// 获取或设置是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器..
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器" )]
		[NotifyParentProperty ( true )]
		public string IFrameFix
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.iframeFix ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.iframeFix, value ); }
		}

		/// <summary>
		/// 获取或设置元素拖动时的透明度, 0 到 1 之间.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素拖动时的透明度, 0 到 1 之间" )]
		[NotifyParentProperty ( true )]
		public string Opacity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.opacity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.opacity, value ); }
		}

		/// <summary>
		/// 获取或设置元素拖动时的透明度, 0 到 1 之间.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否刷新位置, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string RefreshPositions
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.refreshPositions ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.refreshPositions, value ); }
		}

		/// <summary>
		/// 获取或设置是否在拖动后播放恢复原位的动画, 比如: true, 或者是 'valid', 'invalid'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在拖动后播放恢复原位的动画, 比如: true, 或者是 'valid', 'invalid'" )]
		[NotifyParentProperty ( true )]
		public string Revert
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.revert ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.revert, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画播放时间, 比如: 500.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的动画播放时间, 比如: 500" )]
		[NotifyParentProperty ( true )]
		public string RevertDuration
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.revertDuration ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.revertDuration, value ); }
		}

		/// <summary>
		/// 获取或设置范围, 比如: 'default'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示范围, 比如: 'default'" )]
		[NotifyParentProperty ( true )]
		public string Scope
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scope ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scope, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以显示滚动轴.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以显示滚动轴, 比如: true" )]
		[NotifyParentProperty ( true )]
		public string Scroll
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scroll ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scroll, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的灵敏度, 比如: 40.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的灵敏度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSensitivity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSensitivity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSensitivity, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的速度, 比如: 40.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的速度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSpeed
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSpeed ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSpeed, value ); }
		}

		/// <summary>
		/// 获取或设置是否附着, 比如: true, 或者附着的目标元素的选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否附着, 比如: true, 或者附着的目标元素的选择器" )]
		[NotifyParentProperty ( true )]
		public string Snap
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.snap ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.snap, value ); }
		}

		/// <summary>
		/// 获取或设置附着模式, 可以是 'inner', 'outer', 'both'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示附着模式, 可以是 'inner', 'outer', 'both'" )]
		[NotifyParentProperty ( true )]
		public string SnapMode
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.snapMode ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.snapMode, value ); }
		}

		/// <summary>
		/// 获取或设置附着发生的距离, 比如: 100.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示附着发生的距离, 比如: 100" )]
		[NotifyParentProperty ( true )]
		public string SnapTolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.snapTolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.snapTolerance, value ); }
		}

		/// <summary>
		/// 获取或设置控制 z 轴顺序, 对应一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示控制 z 轴顺序, 对应一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Stack
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stack ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stack, value ); }
		}

		/// <summary>
		/// 获取或设置 Z 轴顺序, 比如: 5.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示 Z 轴顺序, 比如: 5" )]
		[NotifyParentProperty ( true )]
		public string ZIndex
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.zIndex ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.zIndex, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置拖动被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置拖动开始的时候的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置拖动完成时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drag
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.drag ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.drag, value ); }
		}

		/// <summary>
		/// 获取或设置拖动停止的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖动停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
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
		/// 创建一个 jQuery UI 拖动的相关设置.
		/// </summary>
		/// <returns>jQuery UI 拖动的相关设置.</returns>
		public DraggableSetting CreateDraggableSetting ( )
		{ return new DraggableSetting ( this.isDraggable, this.editHelper.CreateOptions ( ) ); }

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

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isDraggable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

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

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsDraggable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DraggableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DraggableSettingEdit setting = value as DraggableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsDraggable, setting.EditHelper );
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
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
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
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isDroppable = false;

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
			get { return this.editHelper.InnerOptionEdits; }
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

		#region " Option "
		/// <summary>
		/// 获取或设置拖放是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
// ../.class/ui/jqueryui/ResizableSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIResizableSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ResizableSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
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
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isResizable = false;

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
			get { return this.editHelper.InnerOptionEdits; }
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

		#region " Option "
		/// <summary>
		/// 获取或设置缩放是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置同时缩放的内容, 对应一个 dom 元素, 选择器或者 jQuery.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示同时缩放的内容, 对应一个 dom 元素, 选择器或者 jQuery" )]
		[NotifyParentProperty ( true )]
		public string AlsoResize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.alsoResize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.alsoResize, value ); }
		}

		/// <summary>
		/// 获取或设置是否播放缩放的动画, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否播放缩放的动画, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Animate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animate, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的动画时长, 比如: 1000.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的动画时长, 比如: 1000" )]
		[NotifyParentProperty ( true )]
		public string AnimateDuration
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animateDuration ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animateDuration, value ); }
		}

		/// <summary>
		/// 获取或设置动画效果, 比如: 'swing'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示动画效果, 比如: 'swing'" )]
		[NotifyParentProperty ( true )]
		public string AnimateEasing
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animateEasing ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animateEasing, value ); }
		}

		/// <summary>
		/// 获取或设置宽高比例, 比如: 9 / 16, 或者 true, false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示宽高比例, 比如: 9 / 16, 或者 true, false" )]
		[NotifyParentProperty ( true )]
		public string AspectRatio
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.aspectRatio ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.aspectRatio, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动隐藏, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动隐藏, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoHide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoHide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoHide, value ); }
		}

		/// <summary>
		/// 获取或设置不参加缩放的元素, 是一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加缩放的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置缩放所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string Containment
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.containment ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.containment, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的延迟, 以毫秒计算" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发缩放, 比如: 20.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发缩放, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置是否在缩放时使用阴影, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在缩放时使用阴影, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Ghost
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.ghost ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.ghost, value ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来缩放, 为一个数组, 比如: [10, 30].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来缩放, 为一个数组, 比如: [10, 30]" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.grid ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.grid, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的方向, 为一个字符串, 比如: 'n, e, s, w', 可以从 'n, e, s, w, ne, se, sw, nw, all' 中取值.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的方向, 为一个字符串, 比如: 'n, e, s, w', 可以从 'n, e, s, w, ne, se, sw, nw, all' 中取值" )]
		[NotifyParentProperty ( true )]
		public string Handles
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.handles ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.handles, value ); }
		}

		/// <summary>
		/// 获取或设置 helper 的样式, 比如: 'ui-state-highlight'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示 helper 的样式, 比如: 'ui-state-highlight'" )]
		[NotifyParentProperty ( true )]
		public string Helper
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.helper ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.helper, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最大高度, 比如: 200.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最大高度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MaxHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxHeight, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最大宽度, 比如: 200.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最大宽度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MaxWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxWidth, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最小高度, 比如: 200.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最小高度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MinHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minHeight, value ); }
		}

		/// <summary>
		/// 获取或设置缩放的最小宽度, 比如: 200.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放的最小宽度, 比如: 200" )]
		[NotifyParentProperty ( true )]
		public string MinWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minWidth, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置缩放被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置缩放开始的时候的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置缩放时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Resize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resize, value ); }
		}

		/// <summary>
		/// 获取或设置缩放停止的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示缩放停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
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
		/// 创建一个 jQuery UI 缩放的相关设置.
		/// </summary>
		/// <returns>jQuery UI 缩放的相关设置.</returns>
		public ResizableSetting CreateResizableSetting ( )
		{ return new ResizableSetting ( this.isResizable, this.editHelper.CreateOptions ( ) ); }

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

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isResizable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

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

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsResizable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ResizableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ResizableSettingEdit setting = value as ResizableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsResizable, setting.EditHelper );
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
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
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
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isSelectable = false;

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
			get { return this.editHelper.InnerOptionEdits; }
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

		#region " Option "
		/// <summary>
		/// 获取或设置选中是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置选中是否自动刷新, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中是否自动刷新, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoRefresh
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoRefresh ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoRefresh, value ); }
		}

		/// <summary>
		/// 获取或设置不参加选中的元素, 是一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加选中的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的延迟, 以毫秒计算" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发选中, 比如: 20.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发选中, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置参加选中的元素, 是一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示参加选中的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Filter
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.filter ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.filter, value ); }
		}

		/// <summary>
		/// 获取或设置排列中选中的触发方式, 可以是 'intersect' 或者 'pointer'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列中选中的触发方式, 可以是 'touch' 或者 'fit'" )]
		[NotifyParentProperty ( true )]
		public string Tolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tolerance, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置选中被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置选中后的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中后的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Selected 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selected ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selected, value ); }
		}

		/// <summary>
		/// 获取或设置选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Selecting 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selecting ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selecting, value ); }
		}

		/// <summary>
		/// 获取或设置选中开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置选中停止时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}

		/// <summary>
		/// 获取或设置取消选中的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示取消选中的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Unselected 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.unselected ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.unselected, value ); }
		}

		/// <summary>
		/// 获取或设置取消选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示取消选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Unselecting 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.unselecting ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.unselecting, value ); }
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
		/// 创建一个 jQuery UI 选中的相关设置.
		/// </summary>
		/// <returns>jQuery UI 选中的相关设置.</returns>
		public SelectableSetting CreateSelectableSetting ( )
		{ return new SelectableSetting ( this.isSelectable, this.editHelper.CreateOptions ( ) ); }

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

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isSelectable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

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

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsSelectable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SelectableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SelectableSettingEdit setting = value as SelectableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsSelectable, setting.EditHelper );
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
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
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
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );
		private bool isSortable = false;

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
			get { return this.editHelper.InnerOptionEdits; }
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

		#region " Option "
		/// <summary>
		/// 获取或设置排列是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标点击在何处排序有效, 可以是 'parent', 'body' 等.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标点击在何处排序有效, 可以是 'parent', 'body' 等" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendTo ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendTo, value ); }
		}

		/// <summary>
		/// 获取或设置排列时拖动的方向, 可以是 'x', 'y'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列时拖动的方向, 可以是 'x', 'y'" )]
		[NotifyParentProperty ( true )]
		public string Axis
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.axis ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.axis, value ); }
		}

		/// <summary>
		/// 获取或设置不参加排列的元素, 是一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示不参加排列的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string Cancel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cancel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cancel, value ); }
		}

		/// <summary>
		/// 获取或设置关联的排列, 可以将元素拖放在关联列表中, 是一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示关联的排列, 可以将元素拖放在关联列表中, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string ConnectWith
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.connectWith ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.connectWith, value ); }
		}

		/// <summary>
		/// 获取或设置排列所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列所在的容器, 对应选择器, dom 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400]" )]
		[NotifyParentProperty ( true )]
		public string Containment
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.containment ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.containment, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标样式, 比如: 'auto'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标样式, 比如: 'auto'" )]
		[NotifyParentProperty ( true )]
		public string Cursor
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursor ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursor, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性" )]
		[NotifyParentProperty ( true )]
		public string CursorAt
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cursorAt ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cursorAt, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标的延迟, 以毫秒计算.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标的延迟, 以毫秒计算" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置鼠标移动多少像素触发排列, 比如: 20.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示鼠标移动多少像素触发排列, 比如: 20" )]
		[NotifyParentProperty ( true )]
		public string Distance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.distance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.distance, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以将条目拖放到空的关联列表中, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以将条目拖放到空的关联列表中, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string DropOnEmpty
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dropOnEmpty ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dropOnEmpty, value ); }
		}

		/// <summary>
		/// 获取或设置是否强制 helper 拥有尺寸, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否强制 helper 拥有尺寸, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ForceHelperSize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.forceHelperSize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.forceHelperSize, value ); }
		}

		/// <summary>
		/// 获取或设置是否强制 placeholder 拥有尺寸, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否强制 placeholder 拥有尺寸, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ForcePlaceholderSize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.forcePlaceholderSize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.forcePlaceholderSize, value ); }
		}

		/// <summary>
		/// 获取或设置按照矩阵来移动元素, 为一个数组, 比如: [10, 30].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按照矩阵来移动元素, 为一个数组, 比如: [10, 30]" )]
		[NotifyParentProperty ( true )]
		public string Grid
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.grid ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.grid, value ); }
		}

		/// <summary>
		/// 获取或设置用于点击的元素, 点击后排列才有效, 对应一个 dom 元素或者选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于点击的元素, 点击后排列才有效, 对应一个 dom 元素或者选择器" )]
		[NotifyParentProperty ( true )]
		public string Handle
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.handle ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.handle, value ); }
		}

		/// <summary>
		/// 获取或设置 helper 的行为, 可以是 'original', 'clone'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示 helper 的行为, 可以是 'original', 'clone'" )]
		[NotifyParentProperty ( true )]
		public string Helper
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.helper ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.helper, value ); }
		}

		/// <summary>
		/// 获取或设置参与排列的元素, 对应选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示参与排列的元素, 对应选择器" )]
		[NotifyParentProperty ( true )]
		public string Items
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.items ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.items, value ); }
		}

		/// <summary>
		/// 获取或设置元素排列时的透明度, 0 到 1 之间.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素排列时的透明度, 0 到 1 之间" )]
		[NotifyParentProperty ( true )]
		public string Opacity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.opacity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.opacity, value ); }
		}

		/// <summary>
		/// 获取或设置 placeholder 的样式, 比如: 'ui-state-highlight'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示 placeholder 的样式, 比如: 'ui-state-highlight'" )]
		[NotifyParentProperty ( true )]
		public string Placeholder
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.placeholder ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.placeholder, value ); }
		}

		/// <summary>
		/// 获取或设置是否在排列后播放恢复原位的动画, 比如: true, 或者是以毫秒为单位的动画播放时间, 比如: 500.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在排列后播放恢复原位的动画, 比如: true, 或者是以毫秒为单位的动画播放时间, 比如: 500" )]
		[NotifyParentProperty ( true )]
		public string Revert
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.revert ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.revert, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以显示滚动轴.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以显示滚动轴, 比如: true" )]
		[NotifyParentProperty ( true )]
		public string Scroll
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scroll ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scroll, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的灵敏度, 比如: 40.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的灵敏度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSensitivity
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSensitivity ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSensitivity, value ); }
		}

		/// <summary>
		/// 获取或设置滚动轴的速度, 比如: 40.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示滚动轴的速度, 比如: 40" )]
		[NotifyParentProperty ( true )]
		public string ScrollSpeed
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.scrollSpeed ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.scrollSpeed, value ); }
		}

		/// <summary>
		/// 获取或设置排列中拖放的触发方式, 可以是 'intersect' 或者 'pointer'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列中拖放的触发方式, 可以是 'intersect' 或者 'pointer'" )]
		[NotifyParentProperty ( true )]
		public string Tolerance
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tolerance ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tolerance, value ); }
		}

		/// <summary>
		/// 获取或设置 Z 轴顺序, 比如: 5.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示 Z 轴顺序, 比如: 5" )]
		[NotifyParentProperty ( true )]
		public string ZIndex
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.zIndex ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.zIndex, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置排列被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置排列开始的时候的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列开始的时候的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置排列时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Sort
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.sort ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.sort, value ); }
		}

		/// <summary>
		/// 获取或设置排列改变的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列改变的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置排列停止之前的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列停止之前的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeStop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeStop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeStop, value ); }
		}

		/// <summary>
		/// 获取或设置排列停止的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列停止的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}

		/// <summary>
		/// 获取或设置 dom 元素改变的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示 dom 元素改变的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Update
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.update ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.update, value ); }
		}

		/// <summary>
		/// 获取或设置接收到元素的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示接收到元素的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Receive
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.receive ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.receive, value ); }
		}

		/// <summary>
		/// 获取或设置元素被移除的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素被移除的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.remove ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.remove, value ); }
		}

		/// <summary>
		/// 获取或设置元素滑过时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑出时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Out
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@out ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@out, value ); }
		}

		/// <summary>
		/// 获取或设置排列被激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列被激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Activate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.activate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.activate, value ); }
		}

		/// <summary>
		/// 获取或设置排列取消激活时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示排列取消激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Deactivate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.deactivate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.deactivate, value ); }
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
		/// 创建一个 jQuery UI 排列的相关设置.
		/// </summary>
		/// <returns>jQuery UI 排列的相关设置.</returns>
		public SortableSetting CreateSortableSetting ( )
		{ return new SortableSetting ( this.isSortable, this.editHelper.CreateOptions ( ) ); }

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

			if ( states.Count >= 2 )
				( this.editHelper as IStateManager ).LoadViewState ( states[1] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.isSortable );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

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

			if ( expressionHelper.ChildCount == 2 )
			{

				if ( expressionHelper[0].Value != string.Empty )
					edit.IsSortable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

				if ( expressionHelper[1].Value != string.Empty )
					edit.EditHelper.FromString ( expressionHelper[1].Value );

			}

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SortableSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SortableSettingEdit setting = value as SortableSettingEdit;

			return string.Format ( "{0}`;{1}", setting.IsSortable, setting.EditHelper );
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

					if ( expressionHelper[0].Value != string.Empty )
						edit.Type = ( OptionType ) Enum.Parse ( typeof ( OptionType ), expressionHelper[0].Value, true );

					if ( expressionHelper[1].Value != string.Empty )
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
		private EventType type = EventType.none;
		private string value = string.Empty;

		/// <summary>
		/// 获取或设置事件的类型.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( EventType.none )]
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

					if ( expressionHelper[0].Value != string.Empty )
						edit.Type = ( EventType ) Enum.Parse ( typeof ( EventType ), expressionHelper[0].Value, true );

					if ( expressionHelper[1].Value != string.Empty )
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



// HACK: 避免在 allinone 文件中的名称冲突

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
		public NParameter CreateParameter ( )
		{ return new NParameter ( this.name, this.type, this.value ); }

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

					if ( expressionHelper[0].Value != string.Empty )
						edit.Name = expressionHelper[0].Value;

					if ( expressionHelper[1].Value != string.Empty )
						edit.Type = ( ParameterType ) Enum.Parse ( typeof ( ParameterType ), expressionHelper[1].Value, true );

					if ( expressionHelper[2].Value != string.Empty )
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
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAjaxSettingEditCollectionEditor
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ParameterEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



// HACK: 避免在 allinone 文件中的名称冲突

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
		private string url;
		private DataType dataType = DataType.json;
		private string form;
		private readonly List<ParameterEdit> parameters = new List<ParameterEdit> ( );
		private bool isSingleQuote = true;

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
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Event "
		/// <summary>
		/// 获取或设置 ajax 完成时的事件, 类似于: function() { }.
		/// </summary>
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
		[Category ( "jQuery UI" )]
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
			List<NParameter> parameters = new List<NParameter> ( );

			foreach ( ParameterEdit edit in this.parameters )
				parameters.Add ( edit.CreateParameter ( ) );

			return new AjaxSetting ( this.widgetEventType, this.url, this.dataType, this.form, parameters.ToArray ( ), this.editHelper.CreateEvents(), this.isSingleQuote );
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

			if ( expressionHelper.ChildCount == 6 )
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

				}
				catch { }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AjaxSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AjaxSettingEdit setting = value as AjaxSettingEdit;

			return string.Format ( "{0}`;{1}`;{2}`;{3}`;{4}`;{5}", setting.WidgetEventType, setting.Url, setting.DataType, setting.Form, setting.IsSingleQuote, setting.EditHelper );
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
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAccordionSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAccordionSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAutocompleteSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAutocompleteSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIButtonSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIButtonSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDatepickerSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDialogSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIDialogSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIProgressbarSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIProgressbarSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISliderSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISliderSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITabsSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITabsSettingEditConverter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEmptySettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEmptySettingEditConverter
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
		private readonly List<AjaxSettingEdit> ajaxSettings = new List<AjaxSettingEdit> ( );
		private WidgetType type = WidgetType.empty;

		private readonly AccordionSettingEdit accordionSetting = new AccordionSettingEdit ( );
		private readonly AutocompleteSettingEdit autocompleteSetting = new AutocompleteSettingEdit ( );
		private readonly ButtonSettingEdit buttonSetting = new ButtonSettingEdit ( );
		private readonly DatepickerSettingEdit datepickerSetting = new DatepickerSettingEdit ( );
		private readonly DialogSettingEdit dialogSetting = new DialogSettingEdit ( );
		private readonly ProgressbarSettingEdit progressbarSetting = new ProgressbarSettingEdit ( );
		private readonly SliderSettingEdit sliderSetting = new SliderSettingEdit ( );
		private readonly TabsSettingEdit tabsSetting = new TabsSettingEdit ( );
		private readonly EmptySettingEdit emptySetting = new EmptySettingEdit ( );

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
		/// 获取元素的折叠列表设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的折叠列表设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AccordionSettingEdit AccordionSetting
		{
			get { return this.accordionSetting; }
		}

		/// <summary>
		/// 获取元素的自动填充设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的自动填充设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AutocompleteSettingEdit AutocompleteSetting
		{
			get { return this.autocompleteSetting; }
		}

		/// <summary>
		/// 获取元素的 Button 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的 Button 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public ButtonSettingEdit ButtonSetting
		{
			get { return this.buttonSetting; }
		}

		/// <summary>
		/// 获取元素的日期框设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的日期框设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public DatepickerSettingEdit DatepickerSetting
		{
			get { return this.datepickerSetting; }
		}

		/// <summary>
		/// 获取元素的对话框设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的对话框设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public DialogSettingEdit DialogSetting
		{
			get { return this.dialogSetting; }
		}

		/// <summary>
		/// 获取元素的进度条设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的进度条设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public ProgressbarSettingEdit ProgressbarSetting
		{
			get { return this.progressbarSetting; }
		}

		/// <summary>
		/// 获取元素的分割条设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的分割条设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public SliderSettingEdit SliderSetting
		{
			get { return this.sliderSetting; }
		}

		/// <summary>
		/// 获取元素的分组标签设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的分组标签设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public TabsSettingEdit TabsSetting
		{
			get { return this.tabsSetting; }
		}

		/// <summary>
		/// 获取元素的空设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Widget 相关的空设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public EmptySettingEdit EmptySetting
		{
			get { return this.emptySetting; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 排列的相关设置.
		/// </summary>
		/// <returns>jQuery UI 排列的相关设置.</returns>
		public WidgetSetting CreateWidgetSetting ( )
		{
			List<AjaxSetting> ajaxSettings = new List<AjaxSetting> ( );

			foreach ( AjaxSettingEdit edit in this.ajaxSettings )
				ajaxSettings.Add ( edit.CreateAjaxSetting ( ) );

			SettingEditHelper editHelper;

			switch ( this.type )
			{
				case WidgetType.accordion:
					editHelper = this.accordionSetting.EditHelper;
					break;

				case WidgetType.autocomplete:
					editHelper = this.autocompleteSetting.EditHelper;
					break;

				case WidgetType.button:
					editHelper = this.buttonSetting.EditHelper;
					break;

				case WidgetType.datepicker:
					editHelper = this.datepickerSetting.EditHelper;
					break;

				case WidgetType.dialog:
					editHelper = this.dialogSetting.EditHelper;
					break;

				case WidgetType.progressbar:
					editHelper = this.progressbarSetting.EditHelper;
					break;

				case WidgetType.slider:
					editHelper = this.sliderSetting.EditHelper;
					break;

				case WidgetType.tabs:
					editHelper = this.tabsSetting.EditHelper;
					break;

				case WidgetType.empty:
				default:
					editHelper = this.emptySetting.EditHelper;
					break;
			}

			return new WidgetSetting ( this.type, editHelper.CreateOptions ( ), editHelper.CreateEvents ( ), ajaxSettings.ToArray ( ) );
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
				List<object> ajaxSettingStates = states[1] as List<object>;

				for ( int index = 0; index < ajaxSettingStates.Count; index++ )
					( this.ajaxSettings[index] as IStateManager ).LoadViewState ( ajaxSettingStates[index] );

			}

			if ( states.Count >= 3 )
				( this.buttonSetting as IStateManager ).LoadViewState ( states[2] );

			if ( states.Count >= 4 )
				( this.accordionSetting as IStateManager ).LoadViewState ( states[3] );

			if ( states.Count >= 5 )
				( this.autocompleteSetting as IStateManager ).LoadViewState ( states[4] );

			if ( states.Count >= 6 )
				( this.datepickerSetting as IStateManager ).LoadViewState ( states[5] );

			if ( states.Count >= 7 )
				( this.dialogSetting as IStateManager ).LoadViewState ( states[6] );

			if ( states.Count >= 8 )
				( this.progressbarSetting as IStateManager ).LoadViewState ( states[7] );

			if ( states.Count >= 9 )
				( this.sliderSetting as IStateManager ).LoadViewState ( states[8] );

			if ( states.Count >= 10 )
				( this.tabsSetting as IStateManager ).LoadViewState ( states[9] );

			if ( states.Count >= 11 )
				( this.emptySetting as IStateManager ).LoadViewState ( states[10] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.type );

			List<object> ajaxSettingStates = new List<object> ( );

			foreach ( AjaxSettingEdit edit in this.ajaxSettings )
				ajaxSettingStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( ajaxSettingStates );

			states.Add ( ( this.buttonSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.accordionSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.autocompleteSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.datepickerSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.dialogSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.progressbarSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.sliderSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.tabsSetting as IStateManager ).SaveViewState ( ) );
			states.Add ( ( this.emptySetting as IStateManager ).SaveViewState ( ) );
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

	#region " ButtonSettingEdit "
	/// <summary>
	/// jQuery UI Button 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( ButtonSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ButtonSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的 Button 设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Button 相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的 Button 事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Button 相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置按钮是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置按钮是否显示文本, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮是否显示文本, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Text
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.text ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.text, value ); }
		}

		/// <summary>
		/// 获取或设置按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的图标, 比如: { primary: 'ui-icon-gear', secondary: 'ui-icon-triangle-1-s' }" )]
		[NotifyParentProperty ( true )]
		public string Icons
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.icons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.icons, value ); }
		}

		/// <summary>
		/// 获取或设置按钮显示的文本, 比如: 'ok'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的文本, 比如: 'ok'" )]
		[NotifyParentProperty ( true )]
		public string Label
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.label ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.label, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置按钮被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ButtonSettingEditConverter "
	/// <summary>
	/// jQuery UI Button 设置编辑器的转换器.
	/// </summary>
	public sealed class ButtonSettingEditConverter : ExpandableObjectConverter
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
			ButtonSettingEdit edit = new ButtonSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ButtonSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ButtonSettingEdit setting = value as ButtonSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " AccordionSettingEdit "
	/// <summary>
	/// jQuery UI 折叠列表的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( AccordionSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class AccordionSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的折叠列表设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Button 相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的折叠列表事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "Button 相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置折叠列表是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示折叠列表是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置被激活的列表, 对应一个选择器, 元素, 数值或者布尔值.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示被激活的列表, 对应一个选择器, 元素, 数值或者布尔值" )]
		[NotifyParentProperty ( true )]
		public string Active
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.active ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.active, value ); }
		}

		/// <summary>
		/// 获取或设置列表切换的动画, 比如: 'bounceslide', 'slide', 也可以设置为 false, 来禁止动画.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表切换的动画, 比如: 'bounceslide', 'slide', 也可以设置为 false, 来禁止动画" )]
		[NotifyParentProperty ( true )]
		public string Animated
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animated ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animated, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动调整与最高的列表同高, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动调整与最高的列表同高, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoHeight, value ); }
		}

		/// <summary>
		/// 获取或设置是否在动画结束后清除 height, overflow 样式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在动画结束后清除 height, overflow 样式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ClearStyle
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.clearStyle ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.clearStyle, value ); }
		}

		/// <summary>
		/// 获取或设置是否关闭所有的列表, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否关闭所有的列表, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Collapsible
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.collapsible ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.collapsible, value ); }
		}

		/// <summary>
		/// 获取或设置触发列表的事件, 比如: 'mouseover'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示触发列表的事件, 比如: 'mouseover'" )]
		[NotifyParentProperty ( true )]
		public string Event
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@event ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@event, value ); }
		}

		/// <summary>
		/// 获取或设置是否以父容器填充高度, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否以父容器填充高度, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string FillSpace
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.fillSpace ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.fillSpace, value ); }
		}

		/// <summary>
		/// 获取或设置作为标题的元素, 可以是选择器或者 jQuery 对象, 默认为 '> li > :first-child, > :not(li):even'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示作为标题的元素, 可以是选择器或者 jQuery 对象, 默认为 '> li > :first-child, > :not(li):even'" )]
		[NotifyParentProperty ( true )]
		public string Header
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.header ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.header, value ); }
		}

		/// <summary>
		/// 获取或设置列表显示的图标, 默认为: { 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表显示的图标, 默认为: { 'header': 'ui-icon-triangle-1-e', 'headerSelected': 'ui-icon-triangle-1-s' }" )]
		[NotifyParentProperty ( true )]
		public string Icons
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.icons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.icons, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以导航, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以导航, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Navigation
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.navigation ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.navigation, value ); }
		}

		/// <summary>
		/// 获取或设置选择导航的函数.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择导航的函数" )]
		[NotifyParentProperty ( true )]
		public string NavigationFilter
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.navigationFilter ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.navigationFilter, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置列表被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置列表改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置列表开始改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表开始改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Changestart
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.changestart ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.changestart, value ); }
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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " AccordionSettingEditConverter "
	/// <summary>
	/// jQuery UI 折叠列表设置编辑器的转换器.
	/// </summary>
	public sealed class AccordionSettingEditConverter : ExpandableObjectConverter
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
			AccordionSettingEdit edit = new AccordionSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AccordionSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AccordionSettingEdit setting = value as AccordionSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " AutocompleteSettingEdit "
	/// <summary>
	/// jQuery UI 自动填充的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( AutocompleteSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class AutocompleteSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的自动填充设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "自动填充相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的自动填充事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "自动填充相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置自动填充是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示自动填充是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置填充对应的元素, 是一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充对应的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendTo ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendTo, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动对焦到第一个条目, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动对焦到第一个条目, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoFocus
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoFocus ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoFocus, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的激活自动填充的延迟, 比如: 300.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的激活自动填充的延迟, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public string Delay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.delay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.delay, value ); }
		}

		/// <summary>
		/// 获取或设置激活填充需要最小的输入字符数, 比如: 3.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示激活填充需要最小的输入字符数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public string MinLength
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minLength ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minLength, value ); }
		}

		/// <summary>
		/// 获取或设置填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.position ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.position, value ); }
		}

		/// <summary>
		/// 获取或设置用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数" )]
		[NotifyParentProperty ( true )]
		public string Source
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.source ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.source, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置填充被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置搜索匹配项时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示搜索匹配项时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Search
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.search ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.search, value ); }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.open ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.open, value ); }
		}

		/// <summary>
		/// 获取或设置获得焦点时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Focus
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.focus ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.focus, value ); }
		}

		/// <summary>
		/// 获取或设置选择某个条目的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择某个条目的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.select ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.select, value ); }
		}

		/// <summary>
		/// 获取或设置列表关闭时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.close ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.close, value ); }
		}

		/// <summary>
		/// 获取或设置选择的条目改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择的条目改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " AutocompleteSettingEditConverter "
	/// <summary>
	/// jQuery UI 自动填充设置编辑器的转换器.
	/// </summary>
	public sealed class AutocompleteSettingEditConverter : ExpandableObjectConverter
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
			AutocompleteSettingEdit edit = new AutocompleteSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is AutocompleteSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			AutocompleteSettingEdit setting = value as AutocompleteSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " DatepickerSettingEdit "
	/// <summary>
	/// jQuery UI 日期框的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DatepickerSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DatepickerSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的日期框设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "日期框相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的日期框事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "日期框相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置日期框是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置备用字段, 是一个选择器.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示备用字段, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AltField
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.altField ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.altField, value ); }
		}

		/// <summary>
		/// 获取或设置在备用字段显示的日期格式, 比如: 'yy-mm-dd'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示在备用字段显示的日期格式, 比如: 'yy-mm-dd'" )]
		[NotifyParentProperty ( true )]
		public string AltFormat
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.altFormat ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.altFormat, value ); }
		}

		/// <summary>
		/// 获取或设置显示在日期字段后的文本, 比如: '...'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示在日期字段后的文本, 比如: '...'" )]
		[NotifyParentProperty ( true )]
		public string AppendText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.appendText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.appendText, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动调整输入框的大小, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动调整输入框的大小, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoSize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoSize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoSize, value ); }
		}

		/// <summary>
		/// 获取或设置按钮的图片, 比如: '/images/datepicker.gif'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的图片, 比如: '/images/datepicker.gif'" )]
		[NotifyParentProperty ( true )]
		public string ButtonImage
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttonImage ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttonImage, value ); }
		}

		/// <summary>
		/// 获取或设置是否按钮只显示图片, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否按钮只显示图片, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ButtonImageOnly
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttonImageOnly ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttonImageOnly, value ); }
		}

		/// <summary>
		/// 获取或设置按钮的文本, 默认 '...'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮的文本, 默认 '...'" )]
		[NotifyParentProperty ( true )]
		public string ButtonText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttonText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttonText, value ); }
		}

		/// <summary>
		/// 获取或设置区域设置, 默认 $.datepicker.iso8601Week.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示区域设置, 默认 $.datepicker.iso8601Week" )]
		[NotifyParentProperty ( true )]
		public string CalculateWeek
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.calculateWeek ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.calculateWeek, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许使用下拉框改变月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ChangeMonth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.changeMonth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.changeMonth, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许使用下拉框改变年份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许使用下拉框改变年份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ChangeYear
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.changeYear ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.changeYear, value ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 比如: 'X'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭链接的文本, 比如: 'X'" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeText, value ); }
		}

		/// <summary>
		/// 获取或设置是否限制输入的格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否限制输入的格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ConstrainInput
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.constrainInput ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.constrainInput, value ); }
		}

		/// <summary>
		/// 获取或设置当天链接的文本, 比如: '今天'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示当天链接的文本, 比如: '今天'" )]
		[NotifyParentProperty ( true )]
		public string CurrentText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.currentText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.currentText, value ); }
		}

		/// <summary>
		/// 获取或设置日期的格式, 比如: 'mm/dd/yy'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期的格式, 比如: 'mm/dd/yy'" )]
		[NotifyParentProperty ( true )]
		public string DateFormat
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dateFormat ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dateFormat, value ); }
		}

		/// <summary>
		/// 获取或设置天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的名称, 比如: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']" )]
		[NotifyParentProperty ( true )]
		public string DayNames
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dayNames ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dayNames, value ); }
		}

		/// <summary>
		/// 获取或设置天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的最短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesMin
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dayNamesMin ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dayNamesMin, value ); }
		}

		/// <summary>
		/// 获取或设置天的短名称, 比如: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示天的短名称, 比如: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']" )]
		[NotifyParentProperty ( true )]
		public string DayNamesShort
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dayNamesShort ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dayNamesShort, value ); }
		}

		/// <summary>
		/// 获取或设置默认日期, 可以是日期, 数字或者字符串.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示默认日期, 可以是日期, 数字或者字符串" )]
		[NotifyParentProperty ( true )]
		public string DefaultDate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.defaultDate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.defaultDate, value ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的日期显示速度, 或者使用 'slow', 'normal', 'fast' 中的一种.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示以毫秒为单位的日期显示速度, 或者使用 'slow', 'normal', 'fast' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string Duration
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.duration ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.duration, value ); }
		}

		/// <summary>
		/// 获取或设置哪一天作为一周的开始, 0 表示周日以此类推.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示哪一天作为一周的开始, 0 表示周日以此类推" )]
		[NotifyParentProperty ( true )]
		public string FirstDay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.firstDay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.firstDay, value ); }
		}

		/// <summary>
		/// 获取或设置是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否再点击当天链接后跳转到选中日期而不是当天, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string GotoCurrent
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.gotoCurrent ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.gotoCurrent, value ); }
		}

		/// <summary>
		/// 获取或设置是否隐藏上一和下一链接, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否隐藏上一和下一链接, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string HideIfNoPrevNext
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.hideIfNoPrevNext ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.hideIfNoPrevNext, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用从右向左, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用从右向左, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string IsRTL
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.isRTL ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.isRTL, value ); }
		}

		/// <summary>
		/// 获取或设置最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周" )]
		[NotifyParentProperty ( true )]
		public string MaxDate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxDate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxDate, value ); }
		}

		/// <summary>
		/// 获取或设置最大日期, 可以是日期, 数字或者字符串, 比如: '+1m +1w', 表示推后一月零一周.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小日期, 可以是日期, 数字或者字符串, 比如: '-1m -1w', 表示推前一月零一周" )]
		[NotifyParentProperty ( true )]
		public string MinDate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minDate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minDate, value ); }
		}

		/// <summary>
		/// 获取或设置月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的名称, 比如: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']" )]
		[NotifyParentProperty ( true )]
		public string MonthNames
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.monthNames ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.monthNames, value ); }
		}

		/// <summary>
		/// 获取或设置月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示月的短名称, 比如: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']" )]
		[NotifyParentProperty ( true )]
		public string MonthNamesShort
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.monthNamesShort ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.monthNamesShort, value ); }
		}

		/// <summary>
		/// 获取或设置链接是否使用日期格式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示链接是否使用日期格式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string NavigationAsDateFormat
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.navigationAsDateFormat ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.navigationAsDateFormat, value ); }
		}

		/// <summary>
		/// 获取或设置下一链接的文本, 比如: '...'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示下一链接的文本, 比如: '...'" )]
		[NotifyParentProperty ( true )]
		public string NextText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.nextText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.nextText, value ); }
		}

		/// <summary>
		/// 获取或设置显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示的月数, 默认为 1, 也可以是指示行数列数的数组, 比如: [2, 3]" )]
		[NotifyParentProperty ( true )]
		public string NumberOfMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.numberOfMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.numberOfMonths, value ); }
		}

		/// <summary>
		/// 获取或设置上一链接的文本, 比如: '...'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示上一链接的文本, 比如: '...'" )]
		[NotifyParentProperty ( true )]
		public string PrevText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.prevText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.prevText, value ); }
		}

		/// <summary>
		/// 获取或设置是否可以选择其它的月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以选择其它的月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string SelectOtherMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selectOtherMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selectOtherMonths, value ); }
		}

		/// <summary>
		/// 获取或设置短年份的设置, 可以是数字或者字符串.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示短年份的设置, 可以是数字或者字符串" )]
		[NotifyParentProperty ( true )]
		public string ShortYearCutoff
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.shortYearCutoff ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.shortYearCutoff, value ); }
		}

		/// <summary>
		/// 获取或设置显示日期时的动画, 比如: 'show'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示日期时的动画, 比如: 'show'" )]
		[NotifyParentProperty ( true )]
		public string ShowAnim
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showAnim ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showAnim, value ); }
		}

		/// <summary>
		/// 获取或设置是否显示按钮面板, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否显示按钮面板, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowButtonPanel
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showButtonPanel ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showButtonPanel, value ); }
		}

		/// <summary>
		/// 获取或设置当前月份的显示位置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示当前月份的显示位置" )]
		[NotifyParentProperty ( true )]
		public string ShowCurrentAtPos
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showCurrentAtPos ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showCurrentAtPos, value ); }
		}

		/// <summary>
		/// 获取或设置是否在年后显示月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在年后显示月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowMonthAfterYear
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showMonthAfterYear ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showMonthAfterYear, value ); }
		}

		/// <summary>
		/// 获取或设置日期框显示方式, 可以是 'focus', 'button' , 'both' 中的一种.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示方式, 可以是 'focus', 'button' , 'both' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string ShowOn
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showOn ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showOn, value ); }
		}

		/// <summary>
		/// 获取或设置显示选项, 比如: {direction: 'up' }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示选项, 比如: {direction: 'up' }" )]
		[NotifyParentProperty ( true )]
		public string ShowOptions
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showOptions ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showOptions, value ); }
		}

		/// <summary>
		/// 获取或设置是否显示其它月份, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否显示其它月份, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowOtherMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showOtherMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showOtherMonths, value ); }
		}

		/// <summary>
		/// 获取或设置是否显示当前为一年中的第几周, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否显示当前为一年中的第几周, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string ShowWeek
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.showWeek ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.showWeek, value ); }
		}

		/// <summary>
		/// 获取或设置每一次跳转的月份数, 比如: 3.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示每一次跳转的月份数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public string StepMonths
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stepMonths ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stepMonths, value ); }
		}

		/// <summary>
		/// 获取或设置周的标题设置, 默认: 'Wk'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示周的标题设置, 默认: 'Wk'" )]
		[NotifyParentProperty ( true )]
		public string WeekHeader
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.weekHeader ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.weekHeader, value ); }
		}

		/// <summary>
		/// 获取或设置可选择的年份范围, 默认: 'c-10:c+10'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示可选择的年份范围, 默认: 'c-10:c+10'" )]
		[NotifyParentProperty ( true )]
		public string YearRange
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.yearRange ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.yearRange, value ); }
		}

		/// <summary>
		/// 获取或设置跟随在年后的文本, 比如: 'Y'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示跟随在年后的文本, 比如: 'Y'" )]
		[NotifyParentProperty ( true )]
		public string YearSuffix
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.yearSuffix ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.yearSuffix, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置日期框被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置日期框显示时的事件, 类似于: function(input, inst) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示时的事件, 类似于: function(input, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShow
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeShow ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeShow, value ); }
		}

		/// <summary>
		/// 获取或设置日期框显示天时的事件, 类似于: function(date) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期框显示天时的事件, 类似于: function(date) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeShowDay
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeShowDay ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeShowDay, value ); }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(year, month, inst) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示年和月改变时的事件, 类似于: function(year, month, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnChangeMonthYear
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.onChangeMonthYear ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.onChangeMonthYear, value ); }
		}

		/// <summary>
		/// 获取或设置日期款关闭时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期款关闭时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnClose
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.onClose ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.onClose, value ); }
		}

		/// <summary>
		/// 获取或设置日期选择时的事件, 类似于: function(dateText, inst) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示日期选择时的事件, 类似于: function(dateText, inst) { }" )]
		[NotifyParentProperty ( true )]
		public string OnSelect
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.onSelect ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.onSelect, value ); }
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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DatepickerSettingEditConverter "
	/// <summary>
	/// jQuery UI 日期框设置编辑器的转换器.
	/// </summary>
	public sealed class DatepickerSettingEditConverter : ExpandableObjectConverter
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
			DatepickerSettingEdit edit = new DatepickerSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DatepickerSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DatepickerSettingEdit setting = value as DatepickerSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " DialogSettingEdit "
	/// <summary>
	/// jQuery UI 对话框的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( DialogSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class DialogSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的对话框设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "对话框相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的对话框事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "对话框相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置对话框是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置对话框是否自动打开, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框是否自动打开, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string AutoOpen
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.autoOpen ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.autoOpen, value ); }
		}

		/// <summary>
		/// 获取或设置对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框上的按钮, 比如: { 'OK': function() { $(this).dialog('close'); } }" )]
		[NotifyParentProperty ( true )]
		public string Buttons
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.buttons ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.buttons, value ); }
		}

		/// <summary>
		/// 获取或设置是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否在按下 Esc 时关闭对话框, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string CloseOnEscape
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeOnEscape ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeOnEscape, value ); }
		}

		/// <summary>
		/// 获取或设置关闭链接的文本, 默认 'close'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭链接的文本, 默认 'close'" )]
		[NotifyParentProperty ( true )]
		public string CloseText
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.closeText ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.closeText, value ); }
		}

		/// <summary>
		/// 获取或设置对话框的样式, 比如: 'alert'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框的样式, 比如: 'alert'" )]
		[NotifyParentProperty ( true )]
		public string DialogClass
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dialogClass ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dialogClass, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许拖动, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许拖动, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Draggable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.draggable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.draggable, value ); }
		}

		/// <summary>
		/// 获取或设置对话框高度, 比如: 300.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框高度, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public string Height
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.height ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.height, value ); }
		}

		/// <summary>
		/// 获取或设置关闭对话框时的动画, 比如: 'slide'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示关闭对话框时的动画, 比如: 'slide'" )]
		[NotifyParentProperty ( true )]
		public string Hide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.hide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.hide, value ); }
		}

		/// <summary>
		/// 获取或设置最大高度, 比如: 400.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大高度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MaxHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxHeight, value ); }
		}

		/// <summary>
		/// 获取或设置最大宽度, 比如: 400.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示最大宽度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MaxWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.maxWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.maxWidth, value ); }
		}

		/// <summary>
		/// 获取或设置最小高度, 比如: 400.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小高度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MinHeight
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minHeight ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minHeight, value ); }
		}

		/// <summary>
		/// 获取或设置最小宽度, 比如: 400.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示最小宽度, 比如: 400" )]
		[NotifyParentProperty ( true )]
		public string MinWidth
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.minWidth ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.minWidth, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用 modal 模式, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用 modal 模式, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Modal
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.modal ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.modal, value ); }
		}

		/// <summary>
		/// 获取或设置对话框的位置, 比如: ['right','top'], [100, 200].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框的位置, 比如: ['right','top'], [100, 200]" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.position ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.position, value ); }
		}

		/// <summary>
		/// 获取或设置是否允许缩放, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否允许缩放, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Resizable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resizable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizable, value ); }
		}

		/// <summary>
		/// 获取或设置显示时的动画, 比如: 'slide'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示时的动画, 比如: 'slide'" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.show ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.show, value ); }
		}

		/// <summary>
		/// 获取或设置是否自动置顶, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否自动置顶, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Stack
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stack ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stack, value ); }
		}

		/// <summary>
		/// 获取或设置对话框标题, 比如: 'my title'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框标题, 比如: 'my title'" )]
		[NotifyParentProperty ( true )]
		public string Title
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.title ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.title, value ); }
		}

		/// <summary>
		/// 获取或设置对话框宽度, 比如: 300.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框宽度, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public string Width
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.width ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.width, value ); }
		}

		/// <summary>
		/// 获取或设置对话框 Z 轴顺序, 比如: 2.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框 Z 轴顺序, 比如: 2" )]
		[NotifyParentProperty ( true )]
		public string ZIndex
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.zIndex ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.zIndex, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置对话框被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置对话框关闭之前的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭之前的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string BeforeClose
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.beforeClose ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.beforeClose, value ); }
		}

		/// <summary>
		/// 获取或设置对话框打开时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.open ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.open, value ); }
		}

		/// <summary>
		/// 获取或设置对话框获得焦点时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Focus
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.focus ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.focus, value ); }
		}

		/// <summary>
		/// 获取或设置对话框拖动开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStart
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dragStart ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dragStart, value ); }
		}

		/// <summary>
		/// 获取或设置对话框拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drag
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.drag ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.drag, value ); }
		}

		/// <summary>
		/// 获取或设置对话框拖动结束时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框拖动结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string DragStop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.dragStop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.dragStop, value ); }
		}

		/// <summary>
		/// 获取或设置对话框缩放开始时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放开始时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStart
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resizeStart ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizeStart, value ); }
		}

		/// <summary>
		/// 获取或设置对话框缩放时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Resize
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resize ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resize, value ); }
		}

		/// <summary>
		/// 获取或设置对话框缩放结束时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框缩放结束时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string ResizeStop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.resizeStop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.resizeStop, value ); }
		}

		/// <summary>
		/// 获取或设置对话框关闭时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示对话框关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.close ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.close, value ); }
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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " DialogSettingEditConverter "
	/// <summary>
	/// jQuery UI 对话框设置编辑器的转换器.
	/// </summary>
	public sealed class DialogSettingEditConverter : ExpandableObjectConverter
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
			DialogSettingEdit edit = new DialogSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is DialogSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			DialogSettingEdit setting = value as DialogSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " ProgressbarSettingEdit "
	/// <summary>
	/// jQuery UI 进度条的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( ProgressbarSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class ProgressbarSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的进度条设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "进度条相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的进度条事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "进度条相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置进度条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置进度条当前的值, 比如: 37.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条当前的值, 比如: 37" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.value ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.value, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置进度条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置进度条当前值改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条当前值改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置进度条完成时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Complete
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.complete ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.complete, value ); }
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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " ProgressbarSettingEditConverter "
	/// <summary>
	/// jQuery UI 进度条设置编辑器的转换器.
	/// </summary>
	public sealed class ProgressbarSettingEditConverter : ExpandableObjectConverter
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
			ProgressbarSettingEdit edit = new ProgressbarSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is ProgressbarSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			ProgressbarSettingEdit setting = value as ProgressbarSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " SliderSettingEdit "
	/// <summary>
	/// jQuery UI 分割条的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( SliderSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class SliderSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的分割条设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "分割条相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的分割条事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "分割条相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置分割条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'" )]
		[NotifyParentProperty ( true )]
		public string Animate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.animate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animate, value ); }
		}

		/// <summary>
		/// 获取或设置分割条最大值, 比如: 100.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条最大值, 比如: 100" )]
		[NotifyParentProperty ( true )]
		public string Max
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.max ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.max, value ); }
		}

		/// <summary>
		/// 获取或设置分割条最小值, 比如: 0.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条最小值, 比如: 0" )]
		[NotifyParentProperty ( true )]
		public string Min
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.min ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.min, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的方向, 比如: 'horizontal', 'vertical'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的方向, 比如: 'horizontal', 'vertical'" )]
		[NotifyParentProperty ( true )]
		public string Orientation
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.orientation ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.orientation, value ); }
		}

		/// <summary>
		/// 获取或设置分割条是否使用范围, 或者为 'min', 'max' 中的一种.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条是否使用范围, 或者为 'min', 'max' 中的一种" )]
		[NotifyParentProperty ( true )]
		public string Range
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.range ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.range, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的步长, 比如: 3.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的步长, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public string Step
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.step ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.step, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的值, 比如: 30.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的值, 比如: 30" )]
		[NotifyParentProperty ( true )]
		public string Value
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.value ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.value, value ); }
		}

		/// <summary>
		/// 获取或设置分割条的范围值, 比如: [1, 4, 10].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的范围值, 比如: [1, 4, 10]" )]
		[NotifyParentProperty ( true )]
		public string Values
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.values ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.values, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置分割条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置分割条开始拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条开始拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置分割条拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Slide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.slide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.slide, value ); }
		}

		/// <summary>
		/// 获取或设置分割条改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置分割条结束拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条结束拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " SliderSettingEditConverter "
	/// <summary>
	/// jQuery UI 分割条设置编辑器的转换器.
	/// </summary>
	public sealed class SliderSettingEditConverter : ExpandableObjectConverter
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
			SliderSettingEdit edit = new SliderSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is SliderSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			SliderSettingEdit setting = value as SliderSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " TabsSettingEdit "
	/// <summary>
	/// jQuery UI 分组标签的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( TabsSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class TabsSettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的分组标签设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "分组标签相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的分组标签事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "分组标签相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		#region " Option "
		/// <summary>
		/// 获取或设置分组标签是否可用, 或者禁用的标签的索引, 可以设置为 true, false, 或者 [0, 1].
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签是否可用, 或者禁用的标签的索引, 可以设置为 true, false, 或者 [0, 1]" )]
		[NotifyParentProperty ( true )]
		public string Disabled
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value ); }
		}

		/// <summary>
		/// 获取或设置标签内容的 Ajax 选项, 比如: { async: false }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签内容的 Ajax 选项, 比如: { async: false }" )]
		[NotifyParentProperty ( true )]
		public string AjaxOptions
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.ajaxOptions ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.ajaxOptions, value ); }
		}

		/// <summary>
		/// 获取或设置是否使用缓存, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否使用缓存, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Cache
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cache ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cache, value ); }
		}

		/// <summary>
		/// 获取或设置当再次选择已选中的标签时, 是否取消选中状态, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示当再次选择已选中的标签时, 是否取消选中状态, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public string Collapsible
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.collapsible ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.collapsible, value ); }
		}

		/// <summary>
		/// 获取或设置 cookie 的设置, 比如: { expires: 7, path: '/', domain: 'jquery.com', secure: true }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示 cookie 的设置, 比如: { expires: 7, path: '/', domain: 'jquery.com', secure: true }" )]
		[NotifyParentProperty ( true )]
		public string Cookie
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.cookie ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.cookie, value ); }
		}

		/// <summary>
		/// 请使用 Collapsible.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "请使用 Collapsible" )]
		[NotifyParentProperty ( true )]
		public string Deselectable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.deselectable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.deselectable, value ); }
		}

		/// <summary>
		/// 获取或设置触发切换的事件名称, 默认: 'click'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示触发切换的事件名称, 默认: 'click'" )]
		[NotifyParentProperty ( true )]
		public string Event
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.@event ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.@event, value ); }
		}

		/// <summary>
		/// 获取或设置显示或者隐藏的动画效果, 比如: { opacity: 'toggle' }, 'slow', 'normal', 'fast'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示显示或者隐藏的动画效果, 比如: { opacity: 'toggle' }, 'slow', 'normal', 'fast'" )]
		[NotifyParentProperty ( true )]
		public string Fx
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.fx ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.fx, value ); }
		}

		/// <summary>
		/// 获取或设置 id 的前缀, 默认为 'ui-tabs-'.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示 id 的前缀, 默认为 'ui-tabs-'" )]
		[NotifyParentProperty ( true )]
		public string IdPrefix
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.idPrefix ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.idPrefix, value ); }
		}

		/// <summary>
		/// 获取或设置面板的模板内容.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示面板的模板内容, 默认为 '<div></div>'" )]
		[NotifyParentProperty ( true )]
		public string PanelTemplate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.panelTemplate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.panelTemplate, value ); }
		}

		/// <summary>
		/// 获取或设置选中的标签, 默认为 0.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示选中的标签, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public string Selected
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.selected ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.selected, value ); }
		}

		/// <summary>
		/// 获取或设置载入条的内容.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示载入条的内容" )]
		[NotifyParentProperty ( true )]
		public string Spinner
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.spinner ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.spinner, value ); }
		}

		/// <summary>
		/// 获取或设置表头的模板内容.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示表头的模板内容, 默认为 '<li><a href=#{href}><span>#{label}</span></a></li>'" )]
		[NotifyParentProperty ( true )]
		public string TabTemplate
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.tabTemplate ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.tabTemplate, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置分组标签被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置分组标签被选中时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示分组标签被选中时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.select ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.select, value ); }
		}

		/// <summary>
		/// 获取或设置内容载入时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示内容载入时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Load
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.load ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.load, value ); }
		}

		/// <summary>
		/// 获取或设置标签显示时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签显示时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Show
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.show ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.show, value ); }
		}

		/// <summary>
		/// 获取或设置标签被添加时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被添加时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Add
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.add ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.add, value ); }
		}

		/// <summary>
		/// 获取或设置标签被删除时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被删除时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.remove ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.remove, value ); }
		}

		/// <summary>
		/// 获取或设置标签被启用时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被启用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Enable
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.enable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.enable, value ); }
		}

		/// <summary>
		/// 获取或设置标签被禁用时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "指示标签被禁用时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Disable 
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.disable ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disable, value ); }
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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " TabsSettingEditConverter "
	/// <summary>
	/// jQuery UI 分组标签设置编辑器的转换器.
	/// </summary>
	public sealed class TabsSettingEditConverter : ExpandableObjectConverter
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
			TabsSettingEdit edit = new TabsSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is TabsSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			TabsSettingEdit setting = value as TabsSettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

	#region " EmptySettingEdit "
	/// <summary>
	/// jQuery UI 空的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( EmptySettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class EmptySettingEdit
		: IStateManager
	{
		private readonly SettingEditHelper editHelper = new SettingEditHelper ( );

		/// <summary>
		/// 获取元素的空设置.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "空相关的设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( OptionEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<OptionEdit> Options
		{
			get { return this.editHelper.InnerOptionEdits; }
		}

		/// <summary>
		/// 获取元素的空事件.
		/// </summary>
		[Category ( "jQuery UI" )]
		[Description ( "空相关的事件" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[Editor ( typeof ( EventEditCollectionEditor ), typeof ( UITypeEditor ) )]
		[NotifyParentProperty ( true )]
		public List<EventEdit> Events
		{
			get { return this.editHelper.InnerEventEdits; }
		}

		/// <summary>
		/// 获取 OptionEdit, EventEdit 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingEditHelper EditHelper
		{
			get { return this.editHelper; }
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
				( this.editHelper as IStateManager ).LoadViewState ( states[0] );

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			states.Add ( ( this.editHelper as IStateManager ).SaveViewState ( ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " EmptySettingEditConverter "
	/// <summary>
	/// jQuery UI 空设置编辑器的转换器.
	/// </summary>
	public sealed class EmptySettingEditConverter : ExpandableObjectConverter
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
			EmptySettingEdit edit = new EmptySettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 1 && expressionHelper[0].Value != string.Empty )
				edit.EditHelper.FromString ( expressionHelper[0].Value );

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is EmptySettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			EmptySettingEdit setting = value as EmptySettingEdit;

			return string.Format ( "{0}", setting.EditHelper );
		}

	}
	#endregion

}
// ../.class/ui/jqueryui/RepeaterSettingEdit.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIRepeaterSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIRepeaterSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/RepeaterSettingEdit.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



// HACK: 避免在 allinone 文件中的名称冲突

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
// ../.class/ui/jqueryui/SettingEditHelper.cs
/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISettingEditHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs

 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */



namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 编辑 OptionEdit, EventEdit 的辅助类.
	/// </summary>
	public sealed class SettingEditHelper
		: IStateManager
	{
		/// <summary>
		/// 内部的 OptionEdit 集合.
		/// </summary>
		public readonly List<OptionEdit> InnerOptionEdits = new List<OptionEdit> ( );
		/// <summary>
		/// 内部的 EventEdit 集合.
		/// </summary>
		public readonly List<EventEdit> InnerEventEdits = new List<EventEdit> ( );
		/// <summary>
		/// 外部的 OptionEdit 集合.
		/// </summary>
		public readonly List<OptionEdit> OuterOptionEdits = new List<OptionEdit> ( );
		/// <summary>
		/// 外部的 EventEdit 集合.
		/// </summary>
		public readonly List<EventEdit> OuterEventEdits = new List<EventEdit> ( );

		/// <summary>
		/// 创建对应的 Option 数组.
		/// </summary>
		/// <returns>Option 数组</returns>
		public Option[] CreateOptions ( )
		{
			List<Option> options = new List<Option> ( );

			foreach ( OptionEdit edit in this.InnerOptionEdits )
				options.Add ( edit.CreateOption ( ) );

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				options.Add ( edit.CreateOption ( ) );

			return options.ToArray ( );
		}

		/// <summary>
		/// 创建对应的 Event 数组.
		/// </summary>
		/// <returns>Event 数组</returns>
		public Event[] CreateEvents ( )
		{
			List<Event> events = new List<Event> ( );

			foreach ( EventEdit edit in this.OuterEventEdits )
				events.Add ( edit.CreateEvent ( ) );

			foreach ( EventEdit edit in this.InnerEventEdits )
				events.Add ( edit.CreateEvent ( ) );

			return events.ToArray ( );
		}

		/// <summary>
		/// 得到外部 OptionEdit 的值.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <returns>选项值.</returns>
		public string GetOuterOptionEditValue ( OptionType type )
		{

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				if ( edit.Type == type )
					return edit.Value;

			return string.Empty;
		}

		/// <summary>
		/// 设置外部 OptionEdit 的值.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">选项值.</param>
		public void SetOuterOptionEditValue ( OptionType type, string value )
		{

			if ( null == value )
				return;

			bool isExist = false;

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				if ( edit.Type == type )
				{
					edit.Value = value;
					isExist = true;
				}

			if ( !isExist )
			{
				OptionEdit edit = new OptionEdit ( );
				edit.Type = type;
				edit.Value = value;

				this.OuterOptionEdits.Add ( edit );
			}

		}

		/// <summary>
		/// 得到外部 EventEdit 的值.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <returns>事件值.</returns>
		public string GetOuterEventEditValue ( EventType type )
		{

			foreach ( EventEdit edit in this.OuterEventEdits )
				if ( edit.Type == type )
					return edit.Value;

			return string.Empty;
		}

		/// <summary>
		/// 设置外部 EventEdit 的值.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <param name="value">事件值.</param>
		public void SetOuterEventEditValue ( EventType type, string value )
		{

			if ( null == value )
				return;

			bool isExist = false;

			foreach ( EventEdit edit in this.OuterEventEdits )
				if ( edit.Type == type )
				{
					edit.Value = value;
					break;
				}

			if ( !isExist )
			{
				EventEdit edit = new EventEdit ( );
				edit.Type = type;
				edit.Value = value;

				this.OuterEventEdits.Add ( edit );
			}

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>字符串</returns>
		public override string ToString ( )
		{
			string optionExpression = string.Empty;

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				if ( edit.Value != string.Empty )
					optionExpression += string.Format ( "{0}={1}`;", edit.Type, edit.Value );

			optionExpression = "{" + optionExpression + "}`;";

			string eventExpression = string.Empty;

			foreach ( EventEdit edit in this.OuterEventEdits )
				if ( edit.Value != string.Empty )
					eventExpression += string.Format ( "{0}={1}`;", edit.Type, edit.Value );

			eventExpression = "{" + eventExpression + "}`;";

			return optionExpression + eventExpression;
		}

		/// <summary>
		/// 从字符串转化.
		/// </summary>
		/// <param name="expression">字符串.</param>
		public void FromString ( string expression )
		{

			if ( string.IsNullOrEmpty ( expression ) )
				return;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );


			if ( expressionHelper.ChildCount == 2 )
			{
				this.OuterOptionEdits.Clear ( );

				for ( int index = 0; index < expressionHelper[0].ChildCount; index++ )
				{
					string[] parts = expressionHelper[0][index].Value.Split ( '=' );

					if ( parts.Length != 2 || parts[1] == string.Empty )
						continue;

					try
					{ this.SetOuterOptionEditValue ( ( OptionType ) Enum.Parse ( typeof ( OptionType ), parts[0] ), parts[1] ); }
					catch { }

				}

				this.OuterEventEdits.Clear ( );

				for ( int index = 0; index < expressionHelper[1].ChildCount; index++ )
				{
					string[] parts = expressionHelper[1][index].Value.Split ( '=' );

					if ( parts.Length != 2 || parts[1] == string.Empty )
						continue;

					try
					{ this.SetOuterEventEditValue ( ( EventType ) Enum.Parse ( typeof ( EventType ), parts[0] ), parts[1] ); }
					catch { }

				}

			}

		}

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
			{
				List<object> optionStates = states[0] as List<object>;

				if ( null != optionStates )
					for ( int index = 0; index < this.InnerOptionEdits.Count; index++ )
						if ( index < optionStates.Count )
							( this.InnerOptionEdits[index] as IStateManager ).LoadViewState ( optionStates[index] );
						else
							break;

			}

			if ( states.Count >= 2 )
			{
				List<object> eventStates = states[1] as List<object>;

				if ( null != eventStates )
					for ( int index = 0; index < this.InnerEventEdits.Count; index++ )
						if ( index < eventStates.Count )
							( this.InnerEventEdits[index] as IStateManager ).LoadViewState ( eventStates[index] );
						else
							break;

			}

			if ( states.Count >= 3 )
			{
				List<object> optionStates = states[2] as List<object>;

				if ( null != optionStates )
					for ( int index = 0; index < this.OuterOptionEdits.Count; index++ )
						if ( index < optionStates.Count )
							( this.OuterOptionEdits[index] as IStateManager ).LoadViewState ( optionStates[index] );
						else
							break;

			}

			if ( states.Count >= 4 )
			{
				List<object> eventStates = states[3] as List<object>;

				if ( null != eventStates )
					for ( int index = 0; index < this.OuterEventEdits.Count; index++ )
						if ( index < eventStates.Count )
							( this.OuterEventEdits[index] as IStateManager ).LoadViewState ( eventStates[index] );
						else
							break;

			}

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			List<object> optionStates = new List<object> ( );

			foreach ( OptionEdit edit in this.InnerOptionEdits )
				optionStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( optionStates );

			List<object> eventStates = new List<object> ( );

			foreach ( EventEdit edit in this.InnerEventEdits )
				eventStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( eventStates );

			optionStates = new List<object> ( );

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				optionStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( optionStates );

			eventStates = new List<object> ( );

			foreach ( EventEdit edit in this.OuterEventEdits )
				eventStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( eventStates );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}

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

				string command = expression.Replace ( "[%", string.Empty ).Replace ( "%]", string.Empty ).Trim ( );

				beginIndex = command.IndexOf ( ':' );

				if ( beginIndex <= 0 || beginIndex == command.Length - 1 )
					break;

				string commandName = command.Substring ( 0, beginIndex ).Trim ( ).ToLower ( );
				string commandParameter = command.Substring ( beginIndex + 1 ).Trim ( );

				if ( commandName == string.Empty || commandParameter == string.Empty )
					break;

				string result = null;

				switch ( commandName )
				{
					case "id":
						Control aimControl = control.Page.FindControl ( commandParameter );

						if ( null != aimControl )
							result = aimControl.ClientID;

						break;

					case "param":

						try
						{ result = HttpContext.Current.Request[commandParameter]; }
						catch { }

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

						break;
				}

				code = code.Replace ( expression, string.IsNullOrEmpty ( result ) ? "null" : result );
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
				if ( null != option && option.Type != OptionType.none && option.Value != string.Empty )
					optionExpression += string.Format ( " {0}: {1},", option.Type, option.Value );

			return optionExpression.TrimEnd ( ',' ) + " }";
		}

		private static string makeParameterExpression ( List<Parameter> parameters )
		{

			if ( null == parameters || parameters.Count == 0 )
				return string.Empty;

			string parameterExpression = "{";

			foreach ( Parameter parameter in parameters )
				if ( null != parameter && parameter.Value != string.Empty )
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
		public new static JQueryUI Create ( JQueryUI jQuery )
		{ return new JQueryUI ( jQuery ); }

		/// <summary>
		/// 创建使用别名的空的 JQuery UI.
		/// </summary>
		/// <returns>JQuery UI 实例.</returns>
		public new static JQueryUI Create ( )
		{ return Create ( null, null, true ); }
		/// <summary>
		/// 创建空的 JQuery UI.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public new static JQueryUI Create ( bool isAlias )
		{ return Create ( null, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <returns>JQuery UI 实例.</returns>
		public new static JQueryUI Create ( string expressionI )
		{ return Create ( expressionI, null, true ); }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public new static JQueryUI Create ( string expressionI, bool isAlias )
		{ return Create ( expressionI, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <returns>JQuery UI 实例.</returns>
		public new static JQueryUI Create ( string expressionI, string expressionII )
		{ return Create ( expressionI, expressionII, true ); }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public new static JQueryUI Create ( string expressionI, string expressionII, bool isAlias )
		{ return new JQueryUI ( expressionI, expressionII, isAlias ); }

		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public new static JQueryUI Create ( bool isInstance, bool isAlias )
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

			if ( null == setting || setting.WidgetType == WidgetType.none )
				return this;

			if ( setting.WidgetType != WidgetType.empty )
				this.Execute ( setting.WidgetType.ToString ( ), makeOptionExpression ( setting.Options ) );

			foreach ( Event @event in setting.Events )
				if ( @event.Type != EventType.none && @event.Type != EventType.__init )
					this.Execute ( @event.Type.ToString ( ), @event.Value );

			foreach ( AjaxSetting ajaxSetting in setting.AjaxSettings )
			{

				if ( ajaxSetting.WidgetEventType == EventType.none )
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
				string map = string.Format ( "url: {0}{1}{0}, dataType: {0}{2}{0}, data: {3}", quote, ajaxSetting.Url, ajaxSetting.DataType, string.IsNullOrEmpty(data) ? "{ }" : data );

				foreach ( Event @event in ajaxSetting.Events )
					if ( @event.Type != EventType.none && @event.Type != EventType.__init )
						map += ", " + @event.Type + ": " + @event.Value;

				jQuery.Ajax ( "{" + map + "}" );

				if ( ajaxSetting.WidgetEventType == EventType.__init )
					this.EndLine ( ).AppendCode ( jQuery.Code );
				else
					this.Execute ( ajaxSetting.WidgetEventType.ToString ( ), "function(e){" + jQuery.Code + "}" );
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
		/// 禁用, 对应一个 javascript 布尔值或者数组.
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
		/// 恢复原始状态, 对应一个 javascript 布尔值, 或者恢复的毫秒数.
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

		/// <summary>
		/// 同时缩放, 对应一个 javascript 元素, 选择器或者 jQuery.
		/// </summary>
		alsoResize = 61,

		/// <summary>
		/// 播放动画, 对应一个 javascript 布尔值.
		/// </summary>
		animate = 62,

		/// <summary>
		/// 播放动画延迟, 对应一个 javascript 数值.
		/// </summary>
		animateDuration = 63,

		/// <summary>
		/// 动画效果, 对应一个 javascript 字符串.
		/// </summary>
		animateEasing = 64,

		/// <summary>
		/// 宽高比例, 对应一个 javascript 布尔值或者数值.
		/// </summary>
		aspectRatio = 65,

		/// <summary>
		/// 自动隐藏, 对应一个 javascript 布尔值.
		/// </summary>
		autoHide = 66,

		/// <summary>
		/// 复制, 对应一个 javascript 布尔值.
		/// </summary>
		ghost = 67,

		/// <summary>
		/// 缩放的方式, 对应一个 javascript 字符串或者对象.
		/// </summary>
		handles = 68,

		/// <summary>
		/// 最大高度, 对应一个 javascript 数值.
		/// </summary>
		maxHeight = 69,

		/// <summary>
		/// 最大宽度, 对应一个 javascript 数值.
		/// </summary>
		maxWidth = 70,

		/// <summary>
		/// 最小高度, 对应一个 javascript 数值.
		/// </summary>
		minHeight = 71,

		/// <summary>
		/// 最小宽度, 对应一个 javascript 数值.
		/// </summary>
		minWidth = 72,

		/// <summary>
		/// 大小缩放时, 对应一个 javascript 函数.
		/// </summary>
		resize = 73,

		/// <summary>
		/// 是否使用文本, 对应一个 javascript 布尔值.
		/// </summary>
		text = 74,

		/// <summary>
		/// 图标, 对应一个 javascript 对象.
		/// </summary>
		icons = 75,

		/// <summary>
		/// 标签, 对应一个 javascript 字符串.
		/// </summary>
		label = 76,

		/// <summary>
		/// 激活的内容, 对应一个选择器, 元素, 数值或者布尔值.
		/// </summary>
		active = 77,

		/// <summary>
		/// 动画, 对应一个 javascript 字符串或者布尔值.
		/// </summary>
		animated = 78,

		/// <summary>
		/// 自动调整高度, 对应一个 javascript 布尔值.
		/// </summary>
		autoHeight = 79,

		/// <summary>
		/// 清除样式, 对应一个 javascript 布尔值.
		/// </summary>
		clearStyle = 80,

		/// <summary>
		/// 是否合并, 对应一个 javascript 布尔值.
		/// </summary>
		collapsible = 81,

		/// <summary>
		/// 触发的事件, 对应一个 javascript 字符串.
		/// </summary>
		@event = 82,

		/// <summary>
		/// 是否填充空白, 对应一个 javascript 布尔值.
		/// </summary>
		fillSpace = 83,

		/// <summary>
		/// 标题内容, 对应一个选择器或者 jQuery.
		/// </summary>
		header = 84,

		/// <summary>
		/// 是否导航, 对应一个 javascript 布尔值.
		/// </summary>
		navigation = 85,

		/// <summary>
		/// 导航过滤, 对应一个 javascript 函数.
		/// </summary>
		navigationFilter = 86,

		/// <summary>
		/// 改变开始时, 对应一个 javascript 函数.
		/// </summary>
		changestart = 87,

		/// <summary>
		/// 自动获得焦点, 对应一个 javascript 布尔值.
		/// </summary>
		autoFocus = 88,

		/// <summary>
		/// 最小长度, 对应一个 javascript 数值.
		/// </summary>
		minLength = 89,

		/// <summary>
		/// 位置, 对应一个 javascript 对象.
		/// </summary>
		position = 90,

		/// <summary>
		/// 源, 对应一个 javascript 字符串或者数组.
		/// </summary>
		source = 91,

		/// <summary>
		/// 搜索时, 对应一个 javascript 函数.
		/// </summary>
		search = 92,

		/// <summary>
		/// 打开时, 对应一个 javascript 函数.
		/// </summary>
		open = 93,

		/// <summary>
		/// 获得焦点时, 对应一个 javascript 函数.
		/// </summary>
		focus = 94,

		/// <summary>
		/// 选择时或者选中的, 对应一个 javascript 函数或者数组.
		/// </summary>
		select = 95,

		/// <summary>
		/// 关闭时, 对应一个 javascript 函数.
		/// </summary>
		close = 96,

		/// <summary>
		/// 进度值, 对应一个 javascript 数值.
		/// </summary>
		value = 97,

		/// <summary>
		/// 完成时, 对应一个 javascript 函数.
		/// </summary>
		complete = 98,

		/// <summary>
		/// 提示元素, 对应一个选择器或者元素.
		/// </summary>
		altField = 99,

		/// <summary>
		/// 提示的格式, 对应一个 javascript 字符串.
		/// </summary>
		altFormat = 100,

		/// <summary>
		/// 追加的文本, 对应一个 javascript 字符串.
		/// </summary>
		appendText = 101,

		/// <summary>
		/// 自动改变大小, 对应一个 javascript 布尔值.
		/// </summary>
		autoSize = 102,

		/// <summary>
		/// 按钮图片, 对应一个 javascript 字符串.
		/// </summary>
		buttonImage = 103,

		/// <summary>
		/// 只显示按钮图片, 对应一个 javascript 布尔值.
		/// </summary>
		buttonImageOnly = 104,

		/// <summary>
		/// 按钮文本, 对应一个 javascript 字符串.
		/// </summary>
		buttonText = 105,

		/// <summary>
		/// 如何计算周.
		/// </summary>
		calculateWeek = 106,

		/// <summary>
		/// 是否可以改变月份, 对应一个 javascript 布尔值.
		/// </summary>
		changeMonth = 107,

		/// <summary>
		/// 是否可以改变年份, 对应一个 javascript 布尔值.
		/// </summary>
		changeYear = 108,

		/// <summary>
		/// 关闭的文本, 对应一个 javascript 字符串.
		/// </summary>
		closeText = 109,

		/// <summary>
		/// 是否限制输入, 对应一个 javascript 布尔值.
		/// </summary>
		constrainInput = 110,

		/// <summary>
		/// 当前日期的显示文本, 对应一个 javascript 字符串.
		/// </summary>
		currentText = 111,

		/// <summary>
		/// 日期格式, 对应一个 javascript 字符串.
		/// </summary>
		dateFormat = 112,

		/// <summary>
		/// 星期的名称, 对应一个 javascript 数组.
		/// </summary>
		dayNames = 113,

		/// <summary>
		/// 星期的最短名称, 对应一个 javascript 数组.
		/// </summary>
		dayNamesMin = 114,

		/// <summary>
		/// 星期的短名称, 对应一个 javascript 数组.
		/// </summary>
		dayNamesShort = 115,

		/// <summary>
		/// 默认的日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		defaultDate = 116,

		/// <summary>
		/// 间隔, 对应一个 javascript 字符串.
		/// </summary>
		duration = 117,

		/// <summary>
		/// 一周开始的一天, 对应一个 javascript 数值.
		/// </summary>
		firstDay = 118,

		/// <summary>
		/// 是否当前时间为选中时间, 对应一个 javascript 布尔值.
		/// </summary>
		gotoCurrent = 119,

		/// <summary>
		/// 是否隐藏上一和下一按钮, 对应一个 javascript 布尔值.
		/// </summary>
		hideIfNoPrevNext = 120,

		/// <summary>
		/// 是否从右到左, 对应一个 javascript 布尔值.
		/// </summary>
		isRTL = 121,

		/// <summary>
		/// 最大日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		maxDate = 122,

		/// <summary>
		/// 最小日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		minDate = 123,

		/// <summary>
		/// 月的名称, 对应一个 javascript 数组.
		/// </summary>
		monthNames = 124,

		/// <summary>
		/// 月的短名称, 对应一个 javascript 数组.
		/// </summary>
		monthNamesShort = 125,

		/// <summary>
		/// 导航应用日期格式, 对应一个 javascript 布尔值.
		/// </summary>
		navigationAsDateFormat = 126,

		/// <summary>
		/// 下一个的文本, 对应一个 javascript 字符串.
		/// </summary>
		nextText = 127,

		/// <summary>
		/// 显示的月数, 对应一个 javascript 数值.
		/// </summary>
		numberOfMonths = 128,

		/// <summary>
		/// 上一个的文本, 对应一个 javascript 字符串.
		/// </summary>
		prevText = 129,

		/// <summary>
		/// 是否可以选择其它月, 对应一个 javascript 布尔值.
		/// </summary>
		selectOtherMonths = 130,

		/// <summary>
		/// 尚不明确, 对应一个 javascript 字符串或者数值.
		/// </summary>
		shortYearCutoff = 131,

		/// <summary>
		/// 显示动画, 对应一个 javascript 字符串.
		/// </summary>
		showAnim = 132,

		/// <summary>
		/// 是否显示按钮栏, 对应一个 javascript 布尔值.
		/// </summary>
		showButtonPanel = 133,

		/// <summary>
		/// 当前月份显示的位置, 对应一个 javascript 数值.
		/// </summary>
		showCurrentAtPos = 134,

		/// <summary>
		/// 是否在年后显示月份, 对应一个 javascript 布尔值.
		/// </summary>
		showMonthAfterYear = 135,

		/// <summary>
		/// 是否显示按钮效果, 对应一个 javascript 字符串.
		/// </summary>
		showOn = 136,

		/// <summary>
		/// 显示的样式, 对应一个 javascript 对象.
		/// </summary>
		showOptions = 137,

		/// <summary>
		/// 是否显示其它月, 对应一个 javascript 布尔值.
		/// </summary>
		showOtherMonths = 138,

		/// <summary>
		/// 是否显示周, 对应一个 javascript 布尔值.
		/// </summary>
		showWeek = 139,

		/// <summary>
		/// 一次跳转的月份数, 对应一个 javascript 数值.
		/// </summary>
		stepMonths = 140,

		/// <summary>
		/// 周的标题, 对应一个 javascript 字符串.
		/// </summary>
		weekHeader = 141,

		/// <summary>
		/// 年的跨度, 对应一个 javascript 数值.
		/// </summary>
		yearRange = 142,

		/// <summary>
		/// 年份的附加标题, 对应一个 javascript 字符串.
		/// </summary>
		yearSuffix = 143,

		/// <summary>
		/// 显示之前, 对应一个 javascript 函数.
		/// </summary>
		beforeShow = 144,

		/// <summary>
		/// 显示日期之前, 对应一个 javascript 函数.
		/// </summary>
		beforeShowDay = 145,

		/// <summary>
		/// 改变月年时, 对应一个 javascript 函数.
		/// </summary>
		onChangeMonthYear = 146,

		/// <summary>
		/// 关闭时, 对应一个 javascript 函数.
		/// </summary>
		onClose = 147,

		/// <summary>
		/// 选择时, 对应一个 javascript 函数.
		/// </summary>
		onSelect = 148,

		/// <summary>
		/// 是否自动打开, 对应一个 javascript 布尔值.
		/// </summary>
		autoOpen = 149,

		/// <summary>
		/// 按钮, 对应一个 javascript 对象或者数组.
		/// </summary>
		buttons = 150,

		/// <summary>
		/// 是否按下 Esc 建关闭, 对应一个 javascript 布尔值.
		/// </summary>
		closeOnEscape = 151,

		/// <summary>
		/// 对话框的样式, 对应一个 javascript 字符串.
		/// </summary>
		dialogClass = 152,

		/// <summary>
		/// 是否允许拖动, 对应一个 javascript 布尔值.
		/// </summary>
		draggable = 153,

		/// <summary>
		/// 高度, 对应一个 javascript 数值.
		/// </summary>
		height = 154,

		/// <summary>
		/// 关闭时的效果, 对应一个 javascript 字符串.
		/// </summary>
		hide = 155,

		/// <summary>
		/// 是否使用 modal, 对应一个 javascript 布尔值.
		/// </summary>
		modal = 156,

		/// <summary>
		/// 是否可以缩放, 对应一个 javascript 布尔值.
		/// </summary>
		resizable = 157,

		/// <summary>
		/// 显示时的效果, 对应一个 javascript 字符串.
		/// </summary>
		show = 158,

		/// <summary>
		/// 标题, 对应一个 javascript 字符串.
		/// </summary>
		title = 161,

		/// <summary>
		/// 宽度, 对应一个 javascript 数值.
		/// </summary>
		width = 162,

		/// <summary>
		/// 关闭之前, 对应一个 javascript 函数.
		/// </summary>
		beforeClose = 163,

		/// <summary>
		/// 拖动开始, 对应一个 javascript 函数.
		/// </summary>
		dragStart = 164,

		/// <summary>
		/// 拖动停止, 对应一个 javascript 函数.
		/// </summary>
		dragStop = 165,

		/// <summary>
		/// 缩放开始, 对应一个 javascript 函数.
		/// </summary>
		resizeStart = 166,

		/// <summary>
		/// 缩放停止, 对应一个 javascript 函数.
		/// </summary>
		resizeStop = 166,

		/// <summary>
		/// 最大值, 对应一个 javascript 数值.
		/// </summary>
		max = 167,

		/// <summary>
		/// 最小值, 对应一个 javascript 数值.
		/// </summary>
		min = 168,

		/// <summary>
		/// 方向, 对应一个 javascript 字符串.
		/// </summary>
		orientation = 169,

		/// <summary>
		/// 使用范围, 对应一个 javascript 字符串或者布尔值.
		/// </summary>
		range = 170,

		/// <summary>
		/// 步长, 对应一个 javascript 数值.
		/// </summary>
		step = 171,

		/// <summary>
		/// 值, 对应一个 javascript 数组.
		/// </summary>
		values = 172,

		/// <summary>
		/// 滑动时, 对应一个 javascript 函数.
		/// </summary>
		slide = 173,

		/// <summary>
		/// Ajax 选项, 对应一个 javascript 对象.
		/// </summary>
		ajaxOptions = 174,

		/// <summary>
		/// 是否缓存, 对应一个 javascript 布尔值.
		/// </summary>
		cache = 175,

		/// <summary>
		/// Cookie, 对应一个 javascript 对象.
		/// </summary>
		cookie = 176,

		/// <summary>
		/// 应使用 collapsible.
		/// </summary>
		deselectable = 177,

		/// <summary>
		/// 效果, 对应一个 javascript 对象或者数组.
		/// </summary>
		fx = 179,

		/// <summary>
		/// id 前缀, 对应一个 javascript 字符串.
		/// </summary>
		idPrefix = 180,

		/// <summary>
		/// 面板模板, 对应一个 javascript 字符串.
		/// </summary>
		panelTemplate = 181,

		/// <summary>
		/// 载入条, 对应一个 javascript 字符串.
		/// </summary>
		spinner = 183,

		/// <summary>
		/// 标签模板, 对应一个 javascript 字符串.
		/// </summary>
		tabTemplate = 184,

		/// <summary>
		/// 载入时, 对应一个 javascript 函数.
		/// </summary>
		load = 185,
		
		/// <summary>
		/// 添加时, 对应一个 javascript 函数.
		/// </summary>
		add = 186,

		/// <summary>
		/// 可用时, 对应一个 javascript 函数.
		/// </summary>
		enable = 187,

		/// <summary>
		/// 禁用时, 对应一个 javascript 函数.
		/// </summary>
		disable = 188,
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
		none = 0,
		/// <summary>
		/// 完成时.
		/// </summary>
		complete,
		/// <summary>
		/// 出错时.
		/// </summary>
		error,
		/// <summary>
		/// 成功时.
		/// </summary>
		success,
		/// <summary>
		/// 点击时.
		/// </summary>
		click,
		/// <summary>
		/// 提交时.
		/// </summary>
		submit,
		/// <summary>
		/// 选中时.
		/// </summary>
		select,
		/// <summary>
		/// 滚动轴事件.
		/// </summary>
		scroll,
		/// <summary>
		/// document 准备好时.
		/// </summary>
		ready,
		/// <summary>
		/// 尺寸改变时.
		/// </summary>
		resize,
		/// <summary>
		/// 鼠标按下时.
		/// </summary>
		mousedown,
		/// <summary>
		/// 鼠标进入时.
		/// </summary>
		mouseenter,
		/// <summary>
		/// 鼠标离开时.
		/// </summary>
		mouseleave,
		/// <summary>
		/// 鼠标移动时.
		/// </summary>
		mousemove,
		/// <summary>
		/// 鼠标移出时.
		/// </summary>
		mouseout,
		/// <summary>
		/// 鼠标在其上时.
		/// </summary>
		mouseover,
		/// <summary>
		/// 鼠标松开时.
		/// </summary>
		mouseup,
		/// <summary>
		/// 载入时.
		/// </summary>
		load,
		/// <summary>
		/// 按键按下.
		/// </summary>
		keydown,
		/// <summary>
		/// 按键按住.
		/// </summary>
		keypress,
		/// <summary>
		/// 按键松开.
		/// </summary>
		keyup,
		/// <summary>
		/// 悬停.
		/// </summary>
		hover,
		/// <summary>
		/// 获得焦点.
		/// </summary>
		focus,
		/// <summary>
		/// 双击时.
		/// </summary>
		dblclick,
		/// <summary>
		/// 改变时.
		/// </summary>
		change,
		/// <summary>
		/// 失去焦点时.
		/// </summary>
		blur,
		/// <summary>
		/// 在定义后执行.
		/// </summary>
		__init,
		/// <summary>
		/// 开始时.
		/// </summary>
		start,
		/// <summary>
		/// 停止时.
		/// </summary>
		stop,
		/// <summary>
		/// 发送时.
		/// </summary>
		send
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
		json = 1,
		/// <summary>
		/// 脚本代码.
		/// </summary>
		script = 2,
		/// <summary>
		/// xml 数据.
		/// </summary>
		xml = 3,
		/// <summary>
		/// html 代码.
		/// </summary>
		html = 4,
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
		none = 0,
		/// <summary>
		/// 按钮.
		/// </summary>
		button = 1,
		/// <summary>
		/// 折叠列表.
		/// </summary>
		accordion = 2,
		/// <summary>
		/// 自动填充.
		/// </summary>
		autocomplete = 3,
		/// <summary>
		/// 日期框.
		/// </summary>
		datepicker = 4,
		/// <summary>
		/// 对话框.
		/// </summary>
		dialog = 5,
		/// <summary>
		/// 进度条.
		/// </summary>
		progressbar = 6,
		/// <summary>
		/// 分割条.
		/// </summary>
		slider = 7,
		/// <summary>
		/// 分组标签.
		/// </summary>
		tabs = 8,
		/// <summary>
		/// 空的 Widget.
		/// </summary>
		empty = 9,
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

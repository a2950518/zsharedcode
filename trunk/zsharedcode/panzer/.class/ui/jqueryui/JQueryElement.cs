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

using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;

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

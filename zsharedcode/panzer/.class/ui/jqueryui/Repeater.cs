/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Repeater.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 自定义 Repeater 插件.
	/// </summary>
	[ToolboxData ( "<{0}:Repeater runat=server></{0}:Repeater>" )]
	public class Repeater
		: JQueryPlusin<RepeaterSetting>
	{

		#region " option "
		/// <summary>
		/// 获取或设置包含的属性, 为一个数组, 默认为 "[]".
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "[]" )]
		[Description ( "包含的属性, 为一个数组, 默认为 []" )]
		[NotifyParentProperty ( true )]
		public string Attribute
		{
			get { return this.uiSetting.Attribute; }
			set { this.uiSetting.Attribute = value; }
		}

		/// <summary>
		/// 获取或设置行编辑模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号. 
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "行编辑模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string EditItem
		{
			get { return this.uiSetting.EditItem; }
			set { this.uiSetting.EditItem = value; }
		}

		/// <summary>
		/// 获取或设置空数据模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号. 
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "空数据模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string Empty
		{
			get { return this.uiSetting.Empty; }
			set { this.uiSetting.Empty = value; }
		}

		/// <summary>
		/// 获取或设置包含的字段, 为一个数组, 默认为 "[]".
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "[]" )]
		[Description ( "包含的字段, 为一个数组, 默认为 []" )]
		[NotifyParentProperty ( true )]
		public string Field
		{
			get { return this.uiSetting.Field; }
			set { this.uiSetting.Field = value; }
		}

		/// <summary>
		/// 获取或设置结尾模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号. 
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "结尾模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string Footer
		{
			get { return this.uiSetting.Footer; }
			set { this.uiSetting.Footer = value; }
		}

		/// <summary>
		/// 获取或设置标题模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号. 
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "标题模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string Header
		{
			get { return this.uiSetting.Header; }
			set { this.uiSetting.Header = value; }
		}

		/// <summary>
		/// 获取或设置行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号. 
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string Item
		{
			get { return this.uiSetting.Item; }
			set { this.uiSetting.Item = value; }
		}

		/*
		/// <summary>
		/// 获取或设置是否可以多行编辑, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "是否可以多行编辑, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool MultipleEdit
		{
			get { return this.uiSetting.MultipleEdit; }
			set { this.uiSetting.MultipleEdit = value; }
		}
		*/

		/// <summary>
		/// 获取或设置新建行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "新建行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string NewItem
		{
			get { return this.uiSetting.NewItem; }
			set { this.uiSetting.NewItem = value; }
		}

		/// <summary>
		/// 获取或设置页码, 默认为 1.
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( 1 )]
		[Description ( "页码, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public int PageIndex
		{
			get { return this.uiSetting.PageIndex; }
			set { this.uiSetting.PageIndex = value; }
		}

		/// <summary>
		/// 获取或设置页的大小, 默认为 10.
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( 10 )]
		[Description ( "页的大小, 默认为 10" )]
		[NotifyParentProperty ( true )]
		public int PageSize
		{
			get { return this.uiSetting.PageSize; }
			set { this.uiSetting.PageSize = value; }
		}

		/// <summary>
		/// 获取或设置行的属性名称, 默认为 "rows".
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "rows" )]
		[Description ( "行的属性名称, 默认为 rows" )]
		[NotifyParentProperty ( true )]
		public string RowsName
		{
			get { return this.uiSetting.RowsName; }
			set { this.uiSetting.RowsName = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置修改行时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示修改行时的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Update
		{
			get { return this.uiSetting.Update; }
			set { this.uiSetting.Update = value; }
		}

		/// <summary>
		/// 获取或设置修改行后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示修改行后的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Updated
		{
			get { return this.uiSetting.Updated; }
			set { this.uiSetting.Updated = value; }
		}

		/// <summary>
		/// 获取或设置删除行时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示删除行时的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.uiSetting.Remove; }
			set { this.uiSetting.Remove = value; }
		}

		/// <summary>
		/// 获取或设置删除行后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示删除行后的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Removed
		{
			get { return this.uiSetting.Removed; }
			set { this.uiSetting.Removed = value; }
		}

		/// <summary>
		/// 获取或设置填充时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充时的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Fill
		{
			get { return this.uiSetting.Fill; }
			set { this.uiSetting.Fill = value; }
		}

		/// <summary>
		/// 获取或设置填充后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充后的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Filled
		{
			get { return this.uiSetting.Filled; }
			set { this.uiSetting.Filled = value; }
		}

		/// <summary>
		/// 获取或设置新建行时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示新建行时的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Insert
		{
			get { return this.uiSetting.Insert; }
			set { this.uiSetting.Insert = value; }
		}

		/// <summary>
		/// 获取或设置新建行后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示新建行后的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Inserted
		{
			get { return this.uiSetting.Inserted; }
			set { this.uiSetting.Inserted = value; }
		}

		/// <summary>
		/// 获取或设置到达第一页时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示到达第一页时的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string FirstPage
		{
			get { return this.uiSetting.FirstPage; }
			set { this.uiSetting.FirstPage = value; }
		}

		/// <summary>
		/// 获取或设置到达最后一页时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示到达最后一页时的事件, 类似于: function(tag, e) { }" )]
		[NotifyParentProperty ( true )]
		public string LastPage
		{
			get { return this.uiSetting.LastPage; }
			set { this.uiSetting.LastPage = value; }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取删除行时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Remove.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "删除行时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Remove" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting RemoveAsync
		{
			get { return this.uiSetting.RemoveAsync; }
		}

		/// <summary>
		/// 获取修改行时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Update.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "修改行时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Update" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting UpdateAsync
		{
			get { return this.uiSetting.UpdateAsync; }
		}

		/// <summary>
		/// 获取填充时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Fill.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "填充时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Fill" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting FillAsync
		{
			get { return this.uiSetting.FillAsync; }
		}

		/// <summary>
		/// 获取新建时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Insert.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "新建时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Insert" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting InsertAsync
		{
			get { return this.uiSetting.InsertAsync; }
		}
		#endregion

		#region " template "
		private ITemplate headerTemplate;
		private ITemplate footerTemplate;
		private ITemplate itemTemplate;
		private ITemplate editItemTemplate;
		private ITemplate newItemTemplate;
		private ITemplate emptyTemplate;

		/// <summary>
		/// 获取或设置头部 html 代码的模板, 如果有效, 将覆盖 Header. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate HeaderTemplate
		{
			get { return this.headerTemplate; }
			set { this.headerTemplate = value; }
		}

		/// <summary>
		/// 获取或设置尾部 html 代码的模板, 如果有效, 将覆盖 Footer. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate FooterTemplate
		{
			get { return this.footerTemplate; }
			set { this.footerTemplate = value; }
		}

		/// <summary>
		/// 获取或设置行的 html 代码的模板, 如果有效, 将覆盖 Item. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate ItemTemplate
		{
			get { return this.itemTemplate; }
			set { this.itemTemplate = value; }
		}

		/// <summary>
		/// 获取或设置编辑行的 html 代码的模板, 如果有效, 将覆盖 EditItem. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate EditItemTemplate
		{
			get { return this.editItemTemplate; }
			set { this.editItemTemplate = value; }
		}

		/// <summary>
		/// 获取或设置新行的 html 代码的模板, 如果有效, 将覆盖 NewItem. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate NewItemTemplate
		{
			get { return this.newItemTemplate; }
			set { this.newItemTemplate = value; }
		}

		/// <summary>
		/// 获取或设置空数据 html 代码的模板, 如果有效, 将覆盖 Empty. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate EmptyTemplate
		{
			get { return this.emptyTemplate; }
			set { this.emptyTemplate = value; }
		}
		#endregion

		/// <summary>
		/// 创建一个自定义 Repeater 插件.
		/// </summary>
		public Repeater ( )
			: base ( new RepeaterSetting ( ), HtmlTextWriterTag.Div )
		{ }

		protected override void renderJQuery ( JQueryUI jquery )
		{
			Literal header = renderTemplate ( this, this.headerTemplate );
			Literal footer = renderTemplate ( this, this.footerTemplate );
			Literal item = renderTemplate ( this, this.itemTemplate );
			Literal editItem = renderTemplate ( this, this.editItemTemplate );
			Literal newItem = renderTemplate ( this, this.newItemTemplate );
			Literal empty = renderTemplate ( this, this.emptyTemplate );

			if ( !string.IsNullOrEmpty ( header.Text ) )
				this.Header = ScriptHelper.EscapeCharacter ( header.Text, true );

			if ( !string.IsNullOrEmpty ( footer.Text ) )
				this.Footer = ScriptHelper.EscapeCharacter ( footer.Text, true );

			if ( !string.IsNullOrEmpty ( item.Text ) )
				this.Item = ScriptHelper.EscapeCharacter ( item.Text, true );

			if ( !string.IsNullOrEmpty ( editItem.Text ) )
				this.EditItem = ScriptHelper.EscapeCharacter ( editItem.Text, true );

			if ( !string.IsNullOrEmpty ( newItem.Text ) )
				this.NewItem = ScriptHelper.EscapeCharacter ( newItem.Text, true );

			if ( !string.IsNullOrEmpty ( empty.Text ) )
				this.Empty = ScriptHelper.EscapeCharacter ( empty.Text, true );

			base.renderJQuery ( jquery );
		}

		protected override bool isFaceless ( )
		{ return this.DesignMode; }

		protected override bool isFace ( )
		{ return false; }

		protected override string facelessPrefix ( )
		{ return "Repeater"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.Attribute != "[]" )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Attribute );

			if ( this.Field != "[]" )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Field );

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.RowsName );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

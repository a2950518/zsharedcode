/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Repeater.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;
using zoyobar.shared.panzer.web.jqueryui.plusin;

namespace zoyobar.shared.panzer.ui.jqueryui.plusin
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
		/// 获取或设置嵌入的模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号. 
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "嵌入的模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string Embed
		{
			get { return this.uiSetting.Embed; }
			set { this.uiSetting.Embed = value; }
		}

		/// <summary>
		/// 获取或设置默认包含的字段, 默认为 "[]".
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "[]" )]
		[Description ( "默认包含的字段, 默认为 []" )]
		[NotifyParentProperty ( true )]
		public string Field
		{
			get { return this.uiSetting.Field; }
			set { this.uiSetting.Field = value; }
		}

		/// <summary>
		/// 获取或设置验证字段的正则表达式, 默认为 "{}".
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "{}" )]
		[Description ( "验证字段的正则表达式, 默认为 {}" )]
		[NotifyParentProperty ( true )]
		public string FieldMask
		{
			get { return this.uiSetting.FieldMask; }
			set { this.uiSetting.FieldMask = value; }
		}

		/// <summary>
		/// 获取或设置过滤模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号. 
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "过滤模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string Filter
		{
			get { return this.uiSetting.Filter; }
			set { this.uiSetting.Filter = value; }
		}

		/// <summary>
		/// 获取或设置参与过滤的字段, 默认为 "[]".
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "[]" )]
		[Description ( "参与过滤的字段, 默认为 []" )]
		[NotifyParentProperty ( true )]
		public string FilterField
		{
			get { return this.uiSetting.FilterField; }
			set { this.uiSetting.FilterField = value; }
		}

		/// <summary>
		/// 获取或设置参与过滤字段的默认值, 默认为 "[]".
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "[]" )]
		[Description ( "参与过滤字段的默认值, 默认为 []" )]
		[NotifyParentProperty ( true )]
		public string FilterFieldDefault
		{
			get { return this.uiSetting.FilterFieldDefault; }
			set { this.uiSetting.FilterFieldDefault = value; }
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
		/// 获取或设置分组模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号. 
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "分组模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string Group
		{
			get { return this.uiSetting.Group; }
			set { this.uiSetting.Group = value; }
		}

		/// <summary>
		/// 获取或设置分组字段, 默认为空字符串.
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "" )]
		[Description ( "分组字段, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string GroupField
		{
			get { return this.uiSetting.GroupField; }
			set { this.uiSetting.GroupField = value; }
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
		/// 获取或设置新建后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "新建后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string InsertedItem
		{
			get { return this.uiSetting.InsertedItem; }
			set { this.uiSetting.InsertedItem = value; }
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
		/// 获取或设置是否可以选择多行, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "是否可以选择多行, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool MultipleSelect
		{
			get { return this.uiSetting.MultipleSelect; }
			set { this.uiSetting.MultipleSelect = value; }
		}

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
		/// 获取或设置删除后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "删除后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string RemovedItem
		{
			get { return this.uiSetting.RemovedItem; }
			set { this.uiSetting.RemovedItem = value; }
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

		/// <summary>
		/// 获取或设置是否为单程处理, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "是否为单程处理, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool SingleThread
		{
			get { return this.uiSetting.SingleThread; }
			set { this.uiSetting.SingleThread = value; }
		}

		/// <summary>
		/// 获取或设置提示模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号. 
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "提示模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string Tip
		{
			get { return this.uiSetting.Tip; }
			set { this.uiSetting.Tip = value; }
		}

		/// <summary>
		/// 获取或设置更新后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		[Category ( "模板" )]
		[DefaultValue ( "" )]
		[Description ( "更新后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号" )]
		[NotifyParentProperty ( true )]
		public string UpdatedItem
		{
			get { return this.uiSetting.UpdatedItem; }
			set { this.uiSetting.UpdatedItem = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置修改行之前的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示修改行之前的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string PreUpdate
		{
			get { return this.uiSetting.PreUpdate; }
			set { this.uiSetting.PreUpdate = value; }
		}

		/// <summary>
		/// 获取或设置修改行时的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示修改行时的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Update
		{
			get { return this.uiSetting.Update; }
			set { this.uiSetting.Update = value; }
		}

		/// <summary>
		/// 获取或设置修改行后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示修改行后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Updated
		{
			get { return this.uiSetting.Updated; }
			set { this.uiSetting.Updated = value; }
		}

		/// <summary>
		/// 获取或设置删除行之前的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示删除行之前的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string PreRemove
		{
			get { return this.uiSetting.PreRemove; }
			set { this.uiSetting.PreRemove = value; }
		}

		/// <summary>
		/// 获取或设置删除行时的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示删除行时的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Remove
		{
			get { return this.uiSetting.Remove; }
			set { this.uiSetting.Remove = value; }
		}

		/// <summary>
		/// 获取或设置删除行后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示删除行后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Removed
		{
			get { return this.uiSetting.Removed; }
			set { this.uiSetting.Removed = value; }
		}

		/// <summary>
		/// 获取或设置填充之前的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充之前的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string PreFill
		{
			get { return this.uiSetting.PreFill; }
			set { this.uiSetting.PreFill = value; }
		}

		/// <summary>
		/// 获取或设置填充时的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充时的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Fill
		{
			get { return this.uiSetting.Fill; }
			set { this.uiSetting.Fill = value; }
		}

		/// <summary>
		/// 获取或设置填充后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Filled
		{
			get { return this.uiSetting.Filled; }
			set { this.uiSetting.Filled = value; }
		}

		/// <summary>
		/// 获取或设置新建行之前的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示新建行之前的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string PreInsert
		{
			get { return this.uiSetting.PreInsert; }
			set { this.uiSetting.PreInsert = value; }
		}

		/// <summary>
		/// 获取或设置新建行时的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示新建行时的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Insert
		{
			get { return this.uiSetting.Insert; }
			set { this.uiSetting.Insert = value; }
		}

		/// <summary>
		/// 获取或设置新建行后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示新建行后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Inserted
		{
			get { return this.uiSetting.Inserted; }
			set { this.uiSetting.Inserted = value; }
		}

		/// <summary>
		/// 获取或设置是否可以导航发生改变后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示是否可以导航发生改变后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Navigable
		{
			get { return this.uiSetting.Navigable; }
			set { this.uiSetting.Navigable = value; }
		}

		/// <summary>
		/// 获取或设置发生阻塞时的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示发生阻塞时的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Blocked
		{
			get { return this.uiSetting.Blocked; }
			set { this.uiSetting.Blocked = value; }
		}

		/// <summary>
		/// 获取或设置执行操作之前的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示执行操作之前的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string PreExecute
		{
			get { return this.uiSetting.PreExecute; }
			set { this.uiSetting.PreExecute = value; }
		}

		/// <summary>
		/// 获取或设置执行操作之后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示执行操作之后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Executed
		{
			get { return this.uiSetting.Executed; }
			set { this.uiSetting.Executed = value; }
		}

		/// <summary>
		/// 获取或设置执行自定义操作之前的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示执行自定义操作之前的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string PreCustom
		{
			get { return this.uiSetting.PreCustom; }
			set { this.uiSetting.PreCustom = value; }
		}

		/// <summary>
		/// 获取或设置执行自定义操作的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示执行自定义操作的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Custom
		{
			get { return this.uiSetting.Custom; }
			set { this.uiSetting.Custom = value; }
		}

		/// <summary>
		/// 获取或设置执行自定义操作之后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示执行自定义操作之后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Customed
		{
			get { return this.uiSetting.Customed; }
			set { this.uiSetting.Customed = value; }
		}

		/// <summary>
		/// 获取或设置执行分步操作之前的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示执行分步操作之前的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string PreSubStep
		{
			get { return this.uiSetting.PreSubStep; }
			set { this.uiSetting.PreSubStep = value; }
		}

		/// <summary>
		/// 获取或设置执行分步操作时的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示执行分步操作时的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string SubStepping
		{
			get { return this.uiSetting.SubStepping; }
			set { this.uiSetting.SubStepping = value; }
		}

		/// <summary>
		/// 获取或设置执行分步操作之后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示执行分步操作之后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string SubStepped
		{
			get { return this.uiSetting.SubStepped; }
			set { this.uiSetting.SubStepped = value; }
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

		/// <summary>
		/// 获取或设置自定义操作时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Custom.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "执行自定义操作时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Custom" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting CustomAsync
		{
			get { return this.uiSetting.CustomAsync; }
		}
		#endregion

		#region " template "
		private ITemplate headerTemplate;
		private ITemplate footerTemplate;
		private ITemplate itemTemplate;
		private ITemplate editItemTemplate;
		private ITemplate newItemTemplate;
		private ITemplate emptyTemplate;
		private ITemplate insertedItemTemplate;
		private ITemplate updatedItemTemplate;
		private ITemplate removedItemTemplate;
		private ITemplate filterTemplate;
		private ITemplate tipTemplate;
		private ITemplate embedTemplate;
		private ITemplate groupTemplate;

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
		/// 获取或设置新建后行的 html 代码的模板, 如果有效, 将覆盖 InsertedItem. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate InsertedItemTemplate
		{
			get { return this.insertedItemTemplate; }
			set { this.insertedItemTemplate = value; }
		}

		/// <summary>
		/// 获取或设置更新后行的 html 代码的模板, 如果有效, 将覆盖 UpdatedItem. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate UpdatedItemTemplate
		{
			get { return this.updatedItemTemplate; }
			set { this.updatedItemTemplate = value; }
		}

		/// <summary>
		/// 获取或设置删除后行的 html 代码的模板, 如果有效, 将覆盖 RemovedItem. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate RemovedItemTemplate
		{
			get { return this.removedItemTemplate; }
			set { this.removedItemTemplate = value; }
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

		/// <summary>
		/// 获取或设置过滤条件的 html 代码的模板, 如果有效, 将覆盖 Filter. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate FilterTemplate
		{
			get { return this.filterTemplate; }
			set { this.filterTemplate = value; }
		}

		/// <summary>
		/// 获取或设置提示的 html 代码的模板, 如果有效, 将覆盖 Tip. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate TipTemplate
		{
			get { return this.tipTemplate; }
			set { this.tipTemplate = value; }
		}

		/// <summary>
		/// 获取或设置嵌入的 html 代码的模板, 如果有效, 将覆盖 Embed. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate EmbedTemplate
		{
			get { return this.embedTemplate; }
			set { this.embedTemplate = value; }
		}

		/// <summary>
		/// 获取或设置分组的 html 代码的模板, 如果有效, 将覆盖 Group. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate GroupTemplate
		{
			get { return this.groupTemplate; }
			set { this.groupTemplate = value; }
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
			Literal insertedItem = renderTemplate ( this, this.insertedItemTemplate );
			Literal updatedItem = renderTemplate ( this, this.updatedItemTemplate );
			Literal removedItem = renderTemplate ( this, this.removedItemTemplate );
			Literal filter = renderTemplate ( this, this.filterTemplate );
			Literal tip = renderTemplate ( this, this.tipTemplate );
			Literal embed = renderTemplate ( this, this.embedTemplate );
			Literal group = renderTemplate ( this, this.groupTemplate );

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

			if ( !string.IsNullOrEmpty ( insertedItem.Text ) )
				this.InsertedItem = ScriptHelper.EscapeCharacter ( insertedItem.Text, true );

			if ( !string.IsNullOrEmpty ( updatedItem.Text ) )
				this.UpdatedItem = ScriptHelper.EscapeCharacter ( updatedItem.Text, true );

			if ( !string.IsNullOrEmpty ( removedItem.Text ) )
				this.RemovedItem = ScriptHelper.EscapeCharacter ( removedItem.Text, true );

			if ( !string.IsNullOrEmpty ( filter.Text ) )
				this.Filter = ScriptHelper.EscapeCharacter ( filter.Text, true );

			if ( !string.IsNullOrEmpty ( tip.Text ) )
				this.Tip = ScriptHelper.EscapeCharacter ( tip.Text, true );

			if ( !string.IsNullOrEmpty ( embed.Text ) )
				this.Embed = ScriptHelper.EscapeCharacter ( embed.Text, true );

			if ( !string.IsNullOrEmpty ( group.Text ) )
				this.Group = ScriptHelper.EscapeCharacter ( group.Text, true );

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

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.RowsName );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

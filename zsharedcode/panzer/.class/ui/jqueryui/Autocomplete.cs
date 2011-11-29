/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Autocomplete.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 自动填充插件.
	/// </summary>
	[ToolboxData ( "<{0}:Autocomplete runat=server></{0}:Autocomplete>" )]
	public class Autocomplete
		: JQueryWidget<AutocompleteSetting>
	{

		/// <summary>
		/// 创建一个 jQuery UI 自动填充.
		/// </summary>
		public Autocomplete ( )
			: base ( new AutocompleteSetting ( ), HtmlTextWriterTag.Input )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置自动填充是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示自动填充是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置填充对应的元素, 是一个选择器, 默认为 "body".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "body" )]
		[Description ( "指示填充对应的元素, 是一个选择器, 默认为 body" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.uiSetting.AppendTo; }
			set { this.uiSetting.AppendTo = value; }
		}

		/// <summary>
		/// 获取或设置是否自动对焦到第一个条目, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否自动对焦到第一个条目, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool AutoFocus
		{
			get { return this.uiSetting.AutoFocus; }
			set { this.uiSetting.AutoFocus = value; }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的激活自动填充的延迟, 默认为 300.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 300 )]
		[Description ( "指示以毫秒为单位的激活自动填充的延迟, 默认为 300" )]
		[NotifyParentProperty ( true )]
		public int Delay
		{
			get { return this.uiSetting.Delay; }
			set { this.uiSetting.Delay = value; }
		}

		/// <summary>
		/// 获取或设置激活填充需要最小的输入字符数, 默认为 1.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示激活填充需要最小的输入字符数, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public int MinLength
		{
			get { return this.uiSetting.MinLength; }
			set { this.uiSetting.MinLength = value; }
		}

		/// <summary>
		/// 获取或设置填充列表的位置, 默认为: "{ my: 'left top', at: 'left bottom', collision: 'none' }".
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "{ my: 'left top', at: 'left bottom', collision: 'none' }" )]
		[Description ( "指示填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.uiSetting.Position; }
			set { this.uiSetting.Position = value; }
		}

		/// <summary>
		/// 获取或设置用于填充的源, 可以是数组, 比如: ['abc', 'def'], 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于填充的源, 可以是数组, 比如: ['abc', 'def'], 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Source
		{
			get { return this.uiSetting.Source; }
			set { this.uiSetting.Source = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置填充被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置搜索匹配项时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示搜索匹配项时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Search
		{
			get { return this.uiSetting.Search; }
			set { this.uiSetting.Search = value; }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.uiSetting.Open; }
			set { this.uiSetting.Open = value; }
		}

		/// <summary>
		/// 获取或设置获得焦点时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public new string Focus
		{
			get { return this.uiSetting.Focus; }
			set { this.uiSetting.Focus = value; }
		}

		/// <summary>
		/// 获取或设置选择某个条目的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择某个条目的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.uiSetting.Select; }
			set { this.uiSetting.Select = value; }
		}

		/// <summary>
		/// 获取或设置列表关闭时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.uiSetting.Close; }
			set { this.uiSetting.Close = value; }
		}

		/// <summary>
		/// 获取或设置选择的条目改变时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择的条目改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.uiSetting.Change; }
			set { this.uiSetting.Change = value; }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取 Change 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Change 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting ChangeAsync
		{
			get { return this.uiSetting.ChangeAsync; }
		}

		/// <summary>
		/// 获取读取填充源时的 Ajax 操作的相关设置, 如果设置将替换掉 Source.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "填充源时的 Ajax 操作的相关设置, 如果设置将替换掉 Source" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting SourceAsync
		{
			get { return this.uiSetting.SourceAsync; }
		}
		#endregion

		protected override string facelessPrefix ( )
		{ return "Autocomplete"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.AutoFocus )
				postfix += " <span style=\"color: #660066\">autoFocus</span>";

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.MinLength );

			return base.facelessPostfix ( ) + postfix;
		}

		protected override void AddAttributesToRender ( HtmlTextWriter writer )
		{
			base.AddAttributesToRender ( writer );

			if ( this.isFace ( ) )
			{
				writer.AddAttribute ( HtmlTextWriterAttribute.Class,
					string.Format (
					"ui-autocomplete-input{0}",
					this.Disabled ? " ui-autocomplete-disabled ui-state-disabled" : string.Empty
					)
					);
			}

		}

	}

}

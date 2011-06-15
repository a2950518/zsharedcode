/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIAutocomplete
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Autocomplete.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 自动填充插件.
	/// </summary>
	[ToolboxData ( "<{0}:Autocomplete runat=server></{0}:Autocomplete>" )]
	[DesignerAttribute ( typeof ( AutocompleteDesigner ) )]
	public class Autocomplete
		: BaseWidget
	{
		private readonly AjaxSettingEdit changeAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 自动填充.
		/// </summary>
		public Autocomplete ( )
			: base ( WidgetType.autocomplete )
		{ this.elementType = ElementType.Input; }

		#region " Option "
		/// <summary>
		/// 获取或设置自动填充是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示自动填充是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.widgetSetting.AutocompleteSetting.Disabled, false ); }
			set { this.widgetSetting.AutocompleteSetting.Disabled = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置填充对应的元素, 是一个选择器.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充对应的元素, 是一个选择器" )]
		[NotifyParentProperty ( true )]
		public string AppendTo
		{
			get { return this.widgetSetting.AutocompleteSetting.AppendTo.Trim ( '\'' ); }
			set { this.widgetSetting.AutocompleteSetting.AppendTo = string.IsNullOrEmpty ( value ) ? string.Empty : "'" + value + "'"; }
		}

		/// <summary>
		/// 获取或设置是否自动对焦到第一个条目, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否自动对焦到第一个条目, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool AutoFocus
		{
			get { return this.getBoolean ( this.widgetSetting.AutocompleteSetting.AutoFocus, false ); }
			set { this.widgetSetting.AutocompleteSetting.AutoFocus = value.ToString ( ).ToLower ( ); }
		}

		/// <summary>
		/// 获取或设置以毫秒为单位的激活自动填充的延迟, 比如: 300.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 300 )]
		[Description ( "指示以毫秒为单位的激活自动填充的延迟, 比如: 300" )]
		[NotifyParentProperty ( true )]
		public int Delay
		{
			get { return this.getInteger ( this.widgetSetting.AutocompleteSetting.Delay, 300 ); }
			set { this.widgetSetting.AutocompleteSetting.Delay = value <= 0 || value == 300 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置激活填充需要最小的输入字符数, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示激活填充需要最小的输入字符数, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public int MinLength
		{
			get { return this.getInteger ( this.widgetSetting.AutocompleteSetting.MinLength, 1 ); }
			set { this.widgetSetting.AutocompleteSetting.MinLength = value <= 1 ? string.Empty : value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充列表的位置, 默认为: { my: 'left top', at: 'left bottom', collision: 'none' }" )]
		[NotifyParentProperty ( true )]
		public string Position
		{
			get { return this.widgetSetting.AutocompleteSetting.Position; }
			set { this.widgetSetting.AutocompleteSetting.Position = value; }
		}

		/// <summary>
		/// 获取或设置用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用于填充的源, 可以是数组, 比如: ['abc', 'def'], 也可以是函数" )]
		[NotifyParentProperty ( true )]
		public string Source
		{
			get { return this.widgetSetting.AutocompleteSetting.Source; }
			set { this.widgetSetting.AutocompleteSetting.Source = value; }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置填充被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示填充被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.widgetSetting.AutocompleteSetting.Create; }
			set { this.widgetSetting.AutocompleteSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置搜索匹配项时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示搜索匹配项时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Search
		{
			get { return this.widgetSetting.AutocompleteSetting.Search; }
			set { this.widgetSetting.AutocompleteSetting.Search = value; }
		}

		/// <summary>
		/// 获取或设置列表打开时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表打开时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Open
		{
			get { return this.widgetSetting.AutocompleteSetting.Open; }
			set { this.widgetSetting.AutocompleteSetting.Open = value; }
		}

		/// <summary>
		/// 获取或设置获得焦点时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public new string Focus
		{
			get { return this.widgetSetting.AutocompleteSetting.Focus; }
			set { this.widgetSetting.AutocompleteSetting.Focus = value; }
		}

		/// <summary>
		/// 获取或设置选择某个条目的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择某个条目的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Select
		{
			get { return this.widgetSetting.AutocompleteSetting.Select; }
			set { this.widgetSetting.AutocompleteSetting.Select = value; }
		}

		/// <summary>
		/// 获取或设置列表关闭时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示列表关闭时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Close
		{
			get { return this.widgetSetting.AutocompleteSetting.Close; }
			set { this.widgetSetting.AutocompleteSetting.Close = value; }
		}

		/// <summary>
		/// 获取或设置选择的条目改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示选择的条目改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.widgetSetting.AutocompleteSetting.Change; }
			set { this.widgetSetting.AutocompleteSetting.Change = value; }
		}
		#endregion

		#region " Ajax "
		/// <summary>
		/// 获取 Change 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Change 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSettingEdit ChangeAsync
		{
			get { return this.changeAjax; }
		}
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				// this.widgetSetting.Type = this.type;

				// this.widgetSetting.AutocompleteSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.changeAjax.Url != string.Empty )
				{
					this.changeAjax.WidgetEventType = EventType.click;
					this.widgetSetting.AjaxSettings.Add ( this.changeAjax );
				}

			}
			else if ( string.IsNullOrEmpty ( this.selector ) )
				switch ( this.widgetSetting.Type )
				{
					case WidgetType.autocomplete:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );

						writer.Write (
							"<{5} id=\"{0}\" type=\"textbox\" class=\"{2}ui-autocomplete-input{1}\" style=\"{3}\" title=\"{4}\"/>",
							this.ClientID,
							this.Disabled ? " ui-autocomplete-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( )
							);
						return;
				}

			base.Render ( writer );
		}

	}

	#region " AutocompleteDesigner "
	/// <summary>
	/// 自动填充设计器.
	/// </summary>
	public class AutocompleteDesigner : JQueryElementDesigner
	{

		/// <summary>
		/// 获取行为列表.
		/// </summary>
		public override DesignerActionListCollection ActionLists
		{
			get { return new DesignerActionListCollection ( ); }
		}

	}
	#endregion

}

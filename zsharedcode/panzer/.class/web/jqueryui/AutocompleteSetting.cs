/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AutocompleteSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " AutocompleteSetting "
	/// <summary>
	/// 自动填充设置.
	/// </summary>
	public sealed class AutocompleteSetting
		: WidgetSetting
	{
		private AjaxSetting sourceAsync = new AjaxSetting ( );

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
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.disabled, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.disabled, value, false ); }
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
			get { return this.settingHelper.GetOptionValueToString ( OptionType.appendTo, "body" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.appendTo, value, "body" ); }
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
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.autoFocus, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.autoFocus, value, false ); }
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
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.delay, 300 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.delay, ( value <= 0 ) ? "300" : value.ToString ( ), "300" ); }
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
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.delay, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.delay, ( value <= 0 ) ? "1" : value.ToString ( ), "1" ); }
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
			get { return this.settingHelper.GetOptionValue ( OptionType.position, "{ my: 'left top', at: 'left bottom', collision: 'none' }" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.position, value, "{ my: 'left top', at: 'left bottom', collision: 'none' }" ); }
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
			get { return this.settingHelper.GetOptionValue ( OptionType.source ); }
			set { this.settingHelper.SetOptionValue ( OptionType.source, value, string.Empty ); }
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
			get { return this.settingHelper.GetOptionValue ( OptionType.create ); }
			set { this.settingHelper.SetOptionValue ( OptionType.create, value, string.Empty ); }
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
			get { return this.settingHelper.GetOptionValue ( OptionType.search ); }
			set { this.settingHelper.SetOptionValue ( OptionType.search, value, string.Empty ); }
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
			get { return this.settingHelper.GetOptionValue ( OptionType.open ); }
			set { this.settingHelper.SetOptionValue ( OptionType.open, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置获得焦点时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示获得焦点时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Focus
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.focus ); }
			set { this.settingHelper.SetOptionValue ( OptionType.focus, value, string.Empty ); }
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
			get { return this.settingHelper.GetOptionValue ( OptionType.select ); }
			set { this.settingHelper.SetOptionValue ( OptionType.select, value, string.Empty ); }
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
			get { return this.settingHelper.GetOptionValue ( OptionType.close ); }
			set { this.settingHelper.SetOptionValue ( OptionType.close, value, string.Empty ); }
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
			get { return this.settingHelper.GetOptionValue ( OptionType.change ); }
			set { this.settingHelper.SetOptionValue ( OptionType.change, value, string.Empty ); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置自动填充改变时触发的 Ajax 操作的相关设置.
		/// </summary>
		public AjaxSetting ChangeAsync
		{
			get { return this.ajaxs[0]; }
			set
			{

				if ( null != value )
					this.ajaxs[0] = value;

			}
		}

		/// <summary>
		/// 获取或设置读取填充源时的 Ajax 操作的相关设置, 如果设置将替换掉 Source.
		/// </summary>
		public AjaxSetting SourceAsync
		{
			get { return this.sourceAsync; }
			set
			{

				if ( null != value )
					this.sourceAsync = value;

			}
		}
		#endregion

		/// <summary>
		/// 创建一个自动填充设置.
		/// </summary>
		public AutocompleteSetting ( )
			: base ( WidgetType.autocomplete, 1 )
		{ }

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine ( )
		{
			this.ChangeAsync.EventType = EventType.autocompletechange;

			// request.term represents user input, it will passed to the server-side as parameter term
			this.sourceAsync.Data = "{ term: request.term }";

			//!+ The following code is similar with PlusinSetting.Recombine, AjaxManager.Render
			string data;

			if ( string.IsNullOrEmpty ( this.sourceAsync.MethodName ) )
				data = "data";
			else
			{

				// According to the .NET version to determine the location of JSON
				if ( Environment.Version.Major <= 2 || ( Environment.Version.Major == 3 && Environment.Version.Minor == 0 ) )
					data = "data";
				else
					data = "data.d";

				this.sourceAsync.Data = string.Format ( "jQuery.panzer.encodeData({0})", this.sourceAsync.Data );
			}

			// Through method response to set JSON Returned from the server-side to the autocomplete, JSON has the form ['a', 'b'] or [{label: 'a', value: 'a'}, {label: 'b', value: 'b'}]
			this.sourceAsync.Success = "function(data){response(-:data);}".Replace ( "-:data", data );

			// Generate ajax calling scripts, and used in the Source property
			JQuery ajax = JQueryUI.Create ( this.sourceAsync );

			if ( null != ajax )
			{
				ajax.EndLine ( );

				this.Source = "function(request, response) {" + ajax.Code + "}";
			}

			base.Recombine ( );
		}

	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Droppable.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 完成页面元素拖放功能的控件类.
	/// </summary>
	[ToolboxData ( "<{0}:Droppable runat=server></{0}:Droppable>" )]
	public sealed class Droppable
		: JQueryInteraction<DroppableSetting>
	{

		/// <summary>
		/// 创建一个拖放功能的控件类.
		/// </summary>
		public Droppable ( )
			: base ( new DroppableSetting ( ), HtmlTextWriterTag.Span )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置拖放是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示拖放是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置拖放接受的目标, 对应一个选择器, 默认 "*".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "*" )]
		[Description ( "指示拖放接受的目标, 对应一个选择器, 默认 *" )]
		[NotifyParentProperty ( true )]
		public string Accept
		{
			get { return this.uiSetting.Accept; }
			set { this.uiSetting.Accept = value; }
		}

		/// <summary>
		/// 获取或设置拖放被激活时的样式, 默认空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放被激活时的样式, 默认空字符串" )]
		[NotifyParentProperty ( true )]
		public string ActiveClass
		{
			get { return this.uiSetting.ActiveClass; }
			set { this.uiSetting.ActiveClass = value; }
		}

		/// <summary>
		/// 获取或设置是否添加样式, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( true )]
		[Description ( "指示是否添加样式, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool AddClasses
		{
			get { return this.uiSetting.AddClasses; }
			set { this.uiSetting.AddClasses = value; }
		}

		/// <summary>
		/// 获取或设置是否阻止事件传播, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示是否阻止事件传播, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Greedy
		{
			get { return this.uiSetting.Greedy; }
			set { this.uiSetting.Greedy = value; }
		}

		/// <summary>
		/// 获取或设置悬停样式, 默认空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示悬停样式, 默认空字符串" )]
		[NotifyParentProperty ( true )]
		public string HoverClass
		{
			get { return this.uiSetting.HoverClass; }
			set { this.uiSetting.HoverClass = value; }
		}

		/// <summary>
		/// 获取或设置范围, 默认为 default.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "default" )]
		[Description ( "指示范围, 默认为 default" )]
		[NotifyParentProperty ( true )]
		public string Scope
		{
			get { return this.uiSetting.Scope; }
			set { this.uiSetting.Scope = value; }
		}

		/// <summary>
		/// 获取或设置拖放的触发方式, 默认为 intersect.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( DroppableSetting.ToleranceType.intersect )]
		[Description ( "指示拖放的触发方式, 默认为 intersect" )]
		[NotifyParentProperty ( true )]
		public DroppableSetting.ToleranceType Tolerance
		{
			get { return this.uiSetting.Tolerance; }
			set { this.uiSetting.Tolerance = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置拖放被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置拖放被激活时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放被激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Activate
		{
			get { return this.uiSetting.Activate; }
			set { this.uiSetting.Activate = value; }
		}

		/// <summary>
		/// 获取或设置拖放取消激活时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放取消激活时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Deactivate
		{
			get { return this.uiSetting.Deactivate; }
			set { this.uiSetting.Deactivate = value; }
		}

		/// <summary>
		/// 获取或设置元素滑过时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑过时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Over
		{
			get { return this.uiSetting.Over; }
			set { this.uiSetting.Over = value; }
		}

		/// <summary>
		/// 获取或设置元素滑出时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示元素滑出时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Out
		{
			get { return this.uiSetting.Out; }
			set { this.uiSetting.Out = value; }
		}

		/// <summary>
		/// 获取或设置拖放时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示拖放时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Drop
		{
			get { return this.uiSetting.Drop; }
			set { this.uiSetting.Drop = value; }
		}
		#endregion

		protected override string facelessPrefix ( )
		{ return "Droppable"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.Accept != "*" )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Accept );

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Tolerance );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

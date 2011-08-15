/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Repeater.cs
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
	/// 自定义 Repeater 插件.
	/// </summary>
	[ToolboxData ( "<{0}:Repeater runat=server></{0}:Repeater>" )]
	public class Repeater
		: JQueryPlusin<RepeaterSetting>
	{

		#region " option "
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
		/// 获取或设置包含的属性, 为一个数组, 默认为 "[]".
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "[]" )]
		[Description ( "包含的属性, 为一个数组, 默认为 []" )]
		[NotifyParentProperty ( true )]
		public string Attribute
		{
			get { return this.uiSetting.Attribute; }
			set { this.uiSetting.Attribute = value; }
		}

		/// <summary>
		/// 获取或设置行的属性名称, 默认为 "rows".
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "rows" )]
		[Description ( "行的属性名称, 默认为 rows" )]
		[NotifyParentProperty ( true )]
		public string RowsName
		{
			get { return this.uiSetting.RowsName; }
			set { this.uiSetting.RowsName = value; }
		}

		/// <summary>
		/// 获取标题模板, 其中包含了 html 代码. 
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "设置标题模板" )]
		[NotifyParentProperty ( true )]
		public string Header
		{
			get { return this.uiSetting.Header; }
			set { this.uiSetting.Header = value; }
		}

		/// <summary>
		/// 获取结尾模板, 其中包含了 html 代码. 
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "设置结尾模板" )]
		[NotifyParentProperty ( true )]
		public string Footer
		{
			get { return this.uiSetting.Footer; }
			set { this.uiSetting.Footer = value; }
		}

		/// <summary>
		/// 获取行模板, 其中包含了 html 代码. 
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "设置行模板" )]
		[NotifyParentProperty ( true )]
		public string Item
		{
			get { return this.uiSetting.Item; }
			set { this.uiSetting.Item = value; }
		}

		/// <summary>
		/// 获取行编辑模板, 其中包含了 html 代码. 
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "设置行编辑模板" )]
		[NotifyParentProperty ( true )]
		public string EditItem
		{
			get { return this.uiSetting.EditItem; }
			set { this.uiSetting.EditItem = value; }
		}

		/// <summary>
		/// 获取空数据模板, 其中包含了 html 代码. 
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( "" )]
		[Description ( "设置空数据模板" )]
		[NotifyParentProperty ( true )]
		public string Empty
		{
			get { return this.uiSetting.Empty; }
			set { this.uiSetting.Empty = value; }
		}
		#endregion

		/// <summary>
		/// 创建一个自定义 Repeater 插件.
		/// </summary>
		public Repeater ( )
			: base ( new RepeaterSetting ( ), HtmlTextWriterTag.Div )
		{ }

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

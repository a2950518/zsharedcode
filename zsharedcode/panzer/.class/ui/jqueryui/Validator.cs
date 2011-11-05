/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Validator.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;
using zoyobar.shared.panzer.web.jqueryui.plusin;

namespace zoyobar.shared.panzer.ui.jqueryui.plusin
{

	/// <summary>
	/// 自定义 Validator 插件.
	/// </summary>
	[ToolboxData ( "<{0}:Validator runat=server></{0}:Validator>" )]
	public class Validator
		: JQueryPlusin<ValidatorSetting>
	{

		#region " option "
		/// <summary>
		/// 获取或设置参与过滤字段的默认值, 默认为空字符串.
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "" )]
		[Description ( "参与过滤字段的默认值, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string DefaultValue
		{
			get { return this.uiSetting.DefaultValue; }
			set { this.uiSetting.DefaultValue = value; }
		}

		/// <summary>
		/// 获取或设置等于目标的选择器, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "等于目标的选择器, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Equal
		{
			get { return this.uiSetting.Equal; }
			set { this.uiSetting.Equal = value; }
		}

		/// <summary>
		/// 获取或设置两个值不相等时的提示, 默认为空字符串.
		/// </summary>
		[Category ( "提示" )]
		[DefaultValue ( "" )]
		[Description ( "两个值不相等时的提示, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string EqualTip
		{
			get { return this.uiSetting.EqualTip; }
			set { this.uiSetting.EqualTip = value; }
		}

		/// <summary>
		/// 获取或设置出发验证的事件, 默认为 "change".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "change" )]
		[Description ( "出发验证的事件, 默认为 change" )]
		[NotifyParentProperty ( true )]
		public string Event
		{
			get { return this.uiSetting.Event; }
			set { this.uiSetting.Event = value; }
		}

		/// <summary>
		/// 获取或设置最大值, 默认为 -1111, 表示没有最大值限制.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( -1111 )]
		[Description ( "最大值, 默认为 -1111, 表示没有最大值限制" )]
		[NotifyParentProperty ( true )]
		public int Max
		{
			get { return this.uiSetting.Max; }
			set { this.uiSetting.Max = value; }
		}

		/// <summary>
		/// 获取或设置超出最大值的提示, 默认为空字符串.
		/// </summary>
		[Category ( "提示" )]
		[DefaultValue ( "" )]
		[Description ( "超出最大值的提示, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string MaxTip
		{
			get { return this.uiSetting.MaxTip; }
			set { this.uiSetting.MaxTip = value; }
		}

		/// <summary>
		/// 获取或设置最小值, 默认为 -1111, 表示没有最小值限制.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( -1111 )]
		[Description ( "最小值, 默认为 -1111, 表示没有最小值限制" )]
		[NotifyParentProperty ( true )]
		public int Min
		{
			get { return this.uiSetting.Min; }
			set { this.uiSetting.Min = value; }
		}

		/// <summary>
		/// 获取或设置超出最小值的提示, 默认为空字符串.
		/// </summary>
		[Category ( "提示" )]
		[DefaultValue ( "" )]
		[Description ( "超出最小值的提示, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string MinTip
		{
			get { return this.uiSetting.MinTip; }
			set { this.uiSetting.MinTip = value; }
		}

		/// <summary>
		/// 获取或设置验证项的名称, 默认为空字符串.
		/// </summary>
		[Category ( "数据" )]
		[DefaultValue ( "" )]
		[Description ( "验证项的名称, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Name
		{
			get { return this.uiSetting.Name; }
			set { this.uiSetting.Name = value; }
		}

		/// <summary>
		/// 获取或设置是否为必需, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false)]
		[Description ( "是否为必需, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Need
		{
			get { return this.uiSetting.Need; }
			set { this.uiSetting.Need = value; }
		}

		/// <summary>
		/// 获取或设置缺少时的提示, 默认为空字符串.
		/// </summary>
		[Category ( "提示" )]
		[DefaultValue ( "" )]
		[Description ( "缺少时的提示, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string NeedTip
		{
			get { return this.uiSetting.NeedTip; }
			set { this.uiSetting.NeedTip = value; }
		}

		/// <summary>
		/// 获取或设置转化值的自定义函数, 形式为 "function(value) { }", 默认没有自定义函数.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "转化值的自定义函数, 形式为 function(value) { }, 默认没有自定义函数" )]
		[NotifyParentProperty ( true )]
		public string Provider
		{
			get { return this.uiSetting.Provider; }
			set { this.uiSetting.Provider = value; }
		}

		/// <summary>
		/// 获取或设置用于验证的正则表达式, 默认为空.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "用于验证的正则表达式, 默认为空" )]
		[NotifyParentProperty ( true )]
		public string Reg
		{
			get { return this.uiSetting.Reg; }
			set { this.uiSetting.Reg = value; }
		}

		/// <summary>
		/// 获取或设置不符合正则表达式时的提示, 默认为空字符串.
		/// </summary>
		[Category ( "提示" )]
		[DefaultValue ( "" )]
		[Description ( "不符合正则表达式时的提示, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string RegTip
		{
			get { return this.uiSetting.RegTip; }
			set { this.uiSetting.RegTip = value; }
		}

		/// <summary>
		/// 获取或设置是否显示提示, 默认为 true.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "是否显示提示, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool ShowTip
		{
			get { return this.uiSetting.ShowTip; }
			set { this.uiSetting.ShowTip = value; }
		}

		/// <summary>
		/// 获取或设置成功时的提示, 默认为空字符串.
		/// </summary>
		[Category ( "提示" )]
		[DefaultValue ( "" )]
		[Description ( "成功时的提示, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string SuccessTip
		{
			get { return this.uiSetting.SuccessTip; }
			set { this.uiSetting.SuccessTip = value; }
		}

		/// <summary>
		/// 获取或设置验证目标的选择器, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "验证目标的选择器, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Target
		{
			get { return this.uiSetting.Target; }
			set { this.uiSetting.Target = value; }
		}

		/// <summary>
		/// 获取或设置数据的类型, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "数据的类型, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Type
		{
			get { return this.uiSetting.Type; }
			set { this.uiSetting.Type = value; }
		}

		/// <summary>
		/// 获取或设置类型不符时的提示, 默认为空字符串.
		/// </summary>
		[Category ( "提示" )]
		[DefaultValue ( "" )]
		[Description ( "类型不符时的提示, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string TypeTip
		{
			get { return this.uiSetting.TypeTip; }
			set { this.uiSetting.TypeTip = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置检测的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示检测的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Check
		{
			get { return this.uiSetting.Check; }
			set { this.uiSetting.Check = value; }
		}

		/// <summary>
		/// 获取或设置检测后的事件, 类似于: "function(pe, e) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示检测后的事件, 类似于: function(pe, e) { }" )]
		[NotifyParentProperty ( true )]
		public string Checked
		{
			get { return this.uiSetting.Checked; }
			set { this.uiSetting.Checked = value; }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取验证时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Check.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "验证时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Check" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting CheckAsync
		{
			get { return this.uiSetting.CheckAsync; }
		}
		#endregion

		/// <summary>
		/// 创建一个自定义 Validator 插件.
		/// </summary>
		public Validator ( )
			: base ( new ValidatorSetting ( ), HtmlTextWriterTag.Span )
		{ }

		protected override bool isFaceless ( )
		{ return this.DesignMode; }

		protected override bool isFace ( )
		{ return false; }

		protected override string facelessPrefix ( )
		{ return "Validator"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this );

			return base.facelessPostfix ( ) + postfix;
		}

	}

}

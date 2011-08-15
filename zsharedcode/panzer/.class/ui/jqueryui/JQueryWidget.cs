/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryWidget.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " JQueryWidget "
	/// <summary>
	/// 实现 jQuery UI 插件的服务器控件的基础类.
	/// </summary>
	public abstract class JQueryWidget<W>
		: JQueryElement<W>
		where W : WidgetSetting
	{

		/// <summary>
		/// 获取或设置 Ajax 操作列表.
		/// </summary>
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Hidden )]
		public override List<AjaxSetting> AjaxList
		{
			get { return base.AjaxList; }
		}

		protected JQueryWidget ( W widgetSetting, HtmlTextWriterTag elementType )
			: base ( widgetSetting, elementType )
		{ }

		protected override bool  isFaceless()
		{ return this.DesignMode && this.selector != string.Empty; }

		protected override bool isFace ( )
		{ return this.DesignMode && this.selector == string.Empty; }

		protected override void renderJQuery ( JQueryUI jquery )
		{
			base.renderJQuery ( jquery );
			jquery.Widget ( this.uiSetting );
		}

	}
	#endregion

}

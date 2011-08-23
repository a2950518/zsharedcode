/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryInteraction.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " JQueryInteraction "
	/// <summary>
	/// 实现 jQuery UI Interaction 控件服务器的基础类.
	/// </summary>
	public abstract class JQueryInteraction<I>
		: JQueryElement<I>
		where I : InteractionSetting
	{

		protected JQueryInteraction ( I interactionSetting, HtmlTextWriterTag elementType )
			: base ( interactionSetting, elementType )
		{ }

		protected override void renderJQuery ( JQueryUI jquery )
		{
			base.renderJQuery ( jquery );
			jquery.Interaction ( this.uiSetting );
		}

	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryPlusin.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " JQueryPlusin "
	/// <summary>
	/// 实现 jQuery UI 自定义插件服务器控件基础的类.
	/// </summary>
	public abstract class JQueryPlusin<P>
		: JQueryWidget<P>
		where P : PlusinSetting
	{

		protected JQueryPlusin ( P plusinSetting, HtmlTextWriterTag elementType )
			: base ( plusinSetting, elementType )
		{ }

		protected override void renderJQuery ( JQueryUI jquery )
		{
			base.renderJQuery ( jquery );

			string key = string.Format ( "__js{0}", this.uiSetting.PlusinType );

			if ( !ScriptHelper.IsBuilt ( new ASPXScriptHolder ( this ), key ) )
			{
				ScriptHelper script = new ScriptHelper ( );

				script.AppendCode ( this.uiSetting.GetPlusinCode ( ) );

				script.Build ( new ASPXScriptHolder ( this ), "key", ScriptBuildOption.Startup );
			}

			jquery.Plusin ( this.uiSetting );
		}

	}
	#endregion

}

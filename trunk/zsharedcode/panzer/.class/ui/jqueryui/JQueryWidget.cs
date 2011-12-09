/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryWidget.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web;
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

		protected override bool isFaceless ( )
		{ return this.DesignMode && this.selector != string.Empty; }

		protected override bool isFace ( )
		{ return this.DesignMode && this.selector == string.Empty; }

		protected override void renderJQuery ( JQueryUI jquery )
		{
			base.renderJQuery ( jquery );

			// Generate scripts that are needed by WIDGET, each class that inherits from WidgetSetting can add needed scripts through method GetDependentScripts
			foreach ( KeyValuePair<string, string> pair in this.uiSetting.GetDependentScripts ( ) )
			{
				string key = string.Format ( "__js{0}", pair.Key );

				if ( !ScriptHelper.IsBuilt ( new ASPXScriptHolder ( this ), key ) )
				{
					ScriptHelper script = new ScriptHelper ( );

					script.AppendCode ( pair.Value );

					script.Build ( new ASPXScriptHolder ( this ), key, ScriptBuildOption.Startup );
				}

			}

			for ( int index = 0; index < this.uiSetting.Ajaxs.Length; index++ )
			{
				AjaxSetting ajax = this.uiSetting.Ajaxs[index];

				if ( !string.IsNullOrEmpty ( ajax.ClientFunction ) )
				{
					AjaxManager manager = this.NamingContainer.FindControl ( ajax.AjaxManagerID ) as AjaxManager;

					if ( null == manager )
						throw new Exception ( string.Format ( "没有找到 ID 为 {0} 的 AjaxManager 控件", ajax.AjaxManagerID ) );

					foreach ( AjaxSetting target in manager.AjaxList )
						if ( target.ClientFunction == ajax.ClientFunction )
						{

							if ( ajax != target )
								this.uiSetting.Ajaxs[index] = target;

							break;
						}

				}

			}

			// Append scripts that create the WIDGET, such as: __repeater( ... )
			jquery.Widget ( this.uiSetting );
		}

	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/JQueryRazor.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */
#if V4
using System;
using System.Web.WebPages;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui.plusin;

namespace zoyobar.shared.panzer.web.jqueryui
{

	/// <summary>
	/// 用于 Razor 页面实现 jQuery UI 交互插件的类.
	/// </summary>
	public class JQueryRazor
	{
		private string code = string.Empty;
		private readonly WebPageBase page;

		/// <summary>
		/// 创建一个实现 jQuery UI 交互插件的类.
		/// </summary>
		/// <param name="page">Razor 页面自身.</param>
		public JQueryRazor ( WebPageBase page )
		{

			if ( null == page )
				throw new ArgumentNullException ( "page", "页面不能为空" );

			this.page = page;
		}

		/// <summary>
		/// 使页面上指定选择器的元素成为自定义插件.
		/// </summary>
		/// <param name="selector">用于指定页面上元素的选择器.</param>
		/// <param name="setting">自定义插件设置, 比如: TimerSetting, RepeaterSetting 等.</param>
		/// <param name="variableName">如果不为空, 则生成同名的 javascript 脚本变量.</param>
		public void Plusin ( string selector, PlusinSetting setting, string variableName = null )
		{

			if ( string.IsNullOrEmpty ( selector ) )
				throw new ArgumentNullException ( "selector", "选择器不能为空" );

			if ( null == setting )
				throw new ArgumentNullException ( "setting", "Plusin 设置不能为空" );

			string key = string.Format ( "__js{0}", setting.PlusinType );

			if ( !ScriptHelper.IsBuilt ( new RazorScriptHolder ( this.page ), key ) )
			{
				ScriptHelper script = new ScriptHelper ( );

				//foreach
				//script.AppendCode ( setting.GetDependentScripts ( ) );

				script.Build ( new RazorScriptHolder ( this.page ), key, ScriptBuildOption.Startup );
			}

			this.code += "$(function(){" + ( string.IsNullOrEmpty ( variableName ) ? string.Empty : ( "window['" + variableName + "'] = " ) ) + new JQueryUI ( selector ).Plusin ( setting ).Code + "});";
		}

		/// <summary>
		/// 使页面上指定选择器的元素具有交互效果.
		/// </summary>
		/// <param name="selector">用于指定页面上元素的选择器.</param>
		/// <param name="setting">交互设置, 比如: DraggableSetting, DroppableSetting 等.</param>
		/// <param name="variableName">如果不为空, 则生成同名的 javascript 脚本变量.</param>
		public void Interaction ( string selector, InteractionSetting setting, string variableName = null )
		{

			if ( string.IsNullOrEmpty ( selector ) )
				throw new ArgumentNullException ( "selector", "选择器不能为空" );

			if ( null == setting )
				throw new ArgumentNullException ( "setting", "Interaction 设置不能为空" );

			this.code += "$(function(){" + ( string.IsNullOrEmpty ( variableName ) ? string.Empty : ( "window['" + variableName + "'] = " ) ) + new JQueryUI ( selector ).Interaction ( setting ).Code + "});";
		}

		/// <summary>
		/// 使页面上指定选择器的元素成为插件.
		/// </summary>
		/// <param name="selector">用于指定页面上元素的选择器.</param>
		/// <param name="setting">插件设置, 比如: ButtonSetting, DatepickerSetting 等.</param>
		/// <param name="variableName">如果不为空, 则生成同名的 javascript 脚本变量.</param>
		public void Widget ( string selector, WidgetSetting setting, string variableName = null )
		{

			if ( string.IsNullOrEmpty ( selector ) )
				throw new ArgumentNullException ( "selector", "选择器不能为空" );

			if ( null == setting )
				throw new ArgumentNullException ( "setting", "Widget 设置不能为空" );

			this.code += "$(function(){" + ( string.IsNullOrEmpty ( variableName ) ? string.Empty : ( "window['" + variableName + "'] = " ) ) + new JQueryUI ( selector ).Widget ( setting ).Code + "});";
		}

		/// <summary>
		/// 将目前所有的脚本输出.
		/// </summary>
		/// <param name="key">脚本块的关键字.</param>
		public void WriteScript ( string key = null )
		{

			if ( this.code == string.Empty )
				return;

			ScriptHelper script = new ScriptHelper ( );
			script.AppendCode ( this.code );
			script.Build ( new RazorScriptHolder ( this.page ), key );
			this.code = string.Empty;
		}

	}

}
#endif

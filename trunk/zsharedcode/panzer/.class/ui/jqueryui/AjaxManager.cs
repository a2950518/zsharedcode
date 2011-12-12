/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxManager.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.UI;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// Ajax 管理器.
	/// </summary>
	[ToolboxData ( "<{0}:AjaxManager runat=server></{0}:AjaxManager>" )]
	[ParseChildren ( true, "AjaxList" )]
	[DefaultProperty ( "AjaxList" )]
	public class AjaxManager
		: Control, INamingContainer
	{
		private readonly List<AjaxSetting> ajaxs = new List<AjaxSetting> ( );

		/// <summary>
		/// 获取或设置 Ajax 调用列表.
		/// </summary>
		[Browsable ( false )]
		[Category ( "行为" )]
		[Description ( "Ajax 调用列表" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerDefaultProperty )]
		[NotifyParentProperty ( true )]
		public List<AjaxSetting> AjaxList
		{
			get { return this.ajaxs; }
		}

		private bool isFaceless ( )
		{ return this.DesignMode; }

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.Visible )
				return;

			if ( this.isFaceless ( ) )
				writer.Write ( "<span style=\"font-family: Verdana; background-color: #FFFFFF; font-size: 10pt;\"><strong>{0}:</strong> {1}</span>", "AjaxManager", this.ID );

			if ( this.DesignMode )
				return;

			ScriptHelper script = new ScriptHelper ( );

			//!+ The following code is similar with AutocompleteSetting.Recombine, WidgetSetting.Recombine

			foreach ( AjaxSetting ajax in this.ajaxs )
				if ( !string.IsNullOrEmpty ( ajax.ClientFunction ) )
				{
					string data;

					if ( string.IsNullOrEmpty ( ajax.MethodName ) )
						data = "data";
					else
						// According to the .NET version to determine the location of JSON
						if ( Environment.Version.Major <= 2 || ( Environment.Version.Major == 3 && Environment.Version.Minor == 0 ) )
							data = "data";
						else
							data = "data.d";

					if ( !string.IsNullOrEmpty ( ajax.Success ) )
						ajax.Success = ajax.Success.Replace ( "-:data", data );

					if ( !string.IsNullOrEmpty ( ajax.Complete ) )
						ajax.Complete = ajax.Complete.Replace ( "-:data", data );

					if ( !string.IsNullOrEmpty ( ajax.Error ) )
						ajax.Error = ajax.Error.Replace ( "-:data", data );

					JQuery jquery = JQueryUI.Create ( ajax );

					if(null != jquery)
						script.AppendCode ( "function " + ajax.ClientFunction + "(" + ajax.ClientParameter + ") {" + jquery.Code + "}" );

				}

			script.Build ( new ASPXScriptHolder ( this ), this.ClientID, ScriptBuildOption.Startup );
		}

	}

}

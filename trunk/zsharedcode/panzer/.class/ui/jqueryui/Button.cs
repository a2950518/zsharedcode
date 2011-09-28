/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Button.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 按钮插件.
	/// </summary>
	[ToolboxData ( "<{0}:Button runat=server></{0}:Button>" )]
	public class Button
		: JQueryWidget<ButtonSetting>, IPostBackEventHandler
	{

		/// <summary>
		/// 获取或设置按钮显示的主图标, 比如: ui-icon-gear, 也可以通过 Icons 属性设置.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的主图标, 比如: ui-icon-gear, 也可以通过 Icons 属性设置" )]
		[NotifyParentProperty ( true )]
		[CssClassProperty ( )]
		public string PrimaryIcon
		{
			get { return this.uiSetting.PrimaryIcon; }
			set { this.uiSetting.PrimaryIcon = value; }
		}

		/// <summary>
		/// 获取或设置按钮显示的第二图标, 比如: ui-icon-triangle-1-s, 也可以通过 Icons 属性设置.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的第二图标, 比如: ui-icon-triangle-1-s, 也可以通过 Icons 属性设置" )]
		[NotifyParentProperty ( true )]
		[CssClassProperty ( )]
		public string SecondaryIcon
		{
			get { return this.uiSetting.SecondaryIcon; }
			set { this.uiSetting.SecondaryIcon = value; }
		}

		/// <summary>
		/// 创建一个 jQuery UI 按钮.
		/// </summary>
		public Button ( )
			: base ( new ButtonSetting ( ), HtmlTextWriterTag.Span )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置按钮是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示按钮是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置按钮是否显示文本, 默认为 true.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( true )]
		[Description ( "指示按钮是否显示文本, 默认为 true" )]
		[NotifyParentProperty ( true )]
		public bool _Text
		{
			get { return this.uiSetting.Text; }
			set { this.uiSetting.Text = value; }
		}

		/// <summary>
		/// 获取或设置按钮显示的图标, 默认为 { primary: null, secondary: null }.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "{ primary: null, secondary: null }" )]
		[Description ( "指示按钮显示的图标, 默认为 { primary: null, secondary: null }" )]
		[NotifyParentProperty ( true )]
		public string Icons
		{
			get { return this.uiSetting.Icons; }
			set { this.uiSetting.Icons = value; }
		}

		/// <summary>
		/// 获取或设置按钮显示的文本, 默认为空字符串.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮显示的文本, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Label
		{
			get { return this.uiSetting.Label; }
			set { this.uiSetting.Label = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置按钮被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取 Click 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Click 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSetting ClickAsync
		{
			get { return this.uiSetting.ClickAsync; }
		}
		#endregion

		#region " client "
		/// <summary>
		/// 获取或设置按钮被点击时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮被点击时的客户端事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Click
		{
			get { return this.uiSetting.Click; }
			set { this.uiSetting.Click = value; }
		}
		#endregion

		#region " server "
		/// <summary>
		/// 在服务器端执行的点击事件.
		/// </summary>
		[Description ( "指示按钮被点击时的服务器端事件, 如果设置客户端事件将无效" )]
		public event EventHandler ClickSync;
		#endregion

		protected override string facelessPrefix ( )
		{ return "Button"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( this.Label != string.Empty )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Label );

			if ( this.PrimaryIcon != string.Empty )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.PrimaryIcon );

			if ( this.SecondaryIcon != string.Empty )
				postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.SecondaryIcon );

			return base.facelessPostfix ( ) + postfix;
		}

		protected override void AddAttributesToRender ( HtmlTextWriter writer )
		{
			base.AddAttributesToRender ( writer );

			if ( this.isFace ( ) )
			{
				string css = string.Empty;

				if ( !this._Text )
					css = " ui-button-icon-only";
				else if ( !string.IsNullOrEmpty ( this.PrimaryIcon ) && string.IsNullOrEmpty ( this.SecondaryIcon ) )
					css = " ui-button-text-icon-primary";
				else if ( !string.IsNullOrEmpty ( this.SecondaryIcon ) && string.IsNullOrEmpty ( this.PrimaryIcon ) )
					css = " ui-button-text-icon-secondary";
				else if ( !string.IsNullOrEmpty ( this.PrimaryIcon ) && !string.IsNullOrEmpty ( this.SecondaryIcon ) )
					css = " ui-button-text-icons";
				else
					css = " ui-button-text-only";

				writer.AddAttribute ( HtmlTextWriterAttribute.Class,
					string.Format (
					"ui-button ui-widget ui-state-default ui-corner-all{0}{1}",
					this.Disabled ? " ui-button-disabled ui-state-disabled" : string.Empty,
					css
					)
					);
			}

		}

		protected override void RenderContents ( HtmlTextWriter writer )
		{

			if ( null != this.ClickSync )
				this.Click = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "click" ) + "}";

			base.RenderContents ( writer );

			if ( this.isFace ( ) )
			{
				writer.RenderBeginTag ( HtmlTextWriterTag.Span );
				writer.AddAttribute ( HtmlTextWriterAttribute.Class, "ui-button-text" );
				if ( !string.IsNullOrEmpty ( this.PrimaryIcon ) )
					writer.Write ( "[p] " );

				if ( this.Label == string.Empty )
					writer.Write ( this.ID );
				else
					writer.Write ( this.Label );

				if ( !string.IsNullOrEmpty ( this.SecondaryIcon ) )
					writer.Write ( " [s]" );

				writer.RenderEndTag ( );
			}

		}

		public void RaisePostBackEvent ( string eventArgument )
		{

			switch ( eventArgument )
			{
				case "click":

					if ( null != this.ClickSync )
						this.ClickSync ( this, new EventArgs ( ) );

					break;
			}

		}

	}

}

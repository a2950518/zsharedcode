/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Progressbar.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 进度条插件.
	/// </summary>
	[ToolboxData ( "<{0}:Progressbar runat=server></{0}:Progressbar>" )]
	public class Progressbar
		: JQueryWidget<ProgressbarSetting>, IPostBackEventHandler
	{

		/// <summary>
		/// 创建一个 jQuery UI 进度条.
		/// </summary>
		public Progressbar ( )
			: base ( new ProgressbarSetting ( ), HtmlTextWriterTag.Div )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置进度条是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示进度条是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置进度条当前的值, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示进度条当前的值, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public int Value
		{
			get { return this.uiSetting.Value; }
			set { this.uiSetting.Value = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置进度条被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置进度条当前值改变时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条当前值改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.uiSetting.Change; }
			set { this.uiSetting.Change = value; }
		}

		/// <summary>
		/// 获取或设置进度条完成时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Complete
		{
			get { return this.uiSetting.Complete; }
			set { this.uiSetting.Complete = value; }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取 Change 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Change 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AjaxSetting ChangeAsync
		{
			get { return this.uiSetting.ChangeAsync; }
		}
		/// <summary>
		/// 获取 Complete 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Complete 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AjaxSetting CompleteAsync
		{
			get { return this.uiSetting.CompleteAsync; }
		}
		#endregion

		#region " server "
		/// <summary>
		/// 在服务器端执行的值改变事件.
		/// </summary>
		[Description ( "指示值改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event ProgressbarChangeEventHandler ChangeSync;
		/// <summary>
		/// 在服务器端执行的完成事件.
		/// </summary>
		[Description ( "指示完成的服务器端事件, 如果设置客户端事件将无效" )]
		public event ProgressbarCompleteEventHandler CompleteSync;
		#endregion

		protected override bool isFaceless ( )
		{ return this.DesignMode && ( this.selector != string.Empty || this.html == string.Empty ); }

		protected override bool isFace ( )
		{ return this.DesignMode && this.selector == string.Empty && this.html != string.Empty; }

		protected override string facelessPrefix ( )
		{ return "Progressbar"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Value );

			return base.facelessPostfix ( ) + postfix;
		}

		protected override void AddAttributesToRender ( HtmlTextWriter writer )
		{
			base.AddAttributesToRender ( writer );

			if ( this.isFace ( ) )
				writer.AddAttribute ( HtmlTextWriterAttribute.Class,
					string.Format (
					"ui-progressbar ui-widget ui-widget-content ui-corner-all{0}",
					this.Disabled ? " ui-progressbase-disabled ui-state-disabled" : string.Empty
					)
					);

		}

		protected override void RenderContents ( HtmlTextWriter writer )
		{

			if ( null != this.ChangeSync )
				this.Change = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "change;[%':$(this).progressbar(!sq!option!sq!, !sq!value!sq!)%]" ) + "}";

			if ( null != this.CompleteSync )
				this.Complete = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "complete;[%':$(this).progressbar(!sq!option!sq!, !sq!value!sq!)%]" ) + "}";

			base.RenderContents ( writer );

			if ( this.isFace ( ) )
			{
				writer.RenderBeginTag ( HtmlTextWriterTag.Div );
				writer.AddAttribute ( HtmlTextWriterAttribute.Class, "ui-progressbar-value ui-widget-header ui-corner-left" );
				writer.AddStyleAttribute ( HtmlTextWriterStyle.Width, this.Value.ToString ( ) + "%" );
				writer.Write ( "<span style=\"font-family: Verdana; background-color: #FFFFFF\">{0}%</span>", this.Value );
				writer.RenderEndTag ( );
			}

		}

		private void onChange ( ProgressbarEventArgs e )
		{ this.Value = e.Value; }

		private void onComplete ( ProgressbarEventArgs e )
		{ this.Value = e.Value; }

		public void RaisePostBackEvent ( string eventArgument )
		{

			if ( string.IsNullOrEmpty ( eventArgument ) )
				return;

			string[] parts = eventArgument.Split ( ';' );

			switch ( parts[0] )
			{
				case "change":

					if ( null != this.ChangeSync )
					{
						ProgressbarEventArgs e = new ProgressbarEventArgs ( StringConvert.ToObject<int> ( parts[1] ) );

						this.onChange ( e );
						this.ChangeSync ( this, e );
					}


					break;

				case "complete":

					if ( null != this.CompleteSync )
					{
						ProgressbarEventArgs e = new ProgressbarEventArgs ( StringConvert.ToObject<int> ( parts[1] ) );

						this.onComplete ( e );
						this.CompleteSync ( this, e );
					}

					break;
			}

		}

	}

	/// <summary>
	/// 进度条值改变事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void ProgressbarChangeEventHandler ( object sender, ProgressbarEventArgs e );

	/// <summary>
	/// 进度条完成事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void ProgressbarCompleteEventHandler ( object sender, ProgressbarEventArgs e );

	/// <summary>
	/// 进度条事件参数.
	/// </summary>
	public sealed class ProgressbarEventArgs
	{
		/// <summary>
		/// 值.
		/// </summary>
		public readonly int Value;

		/// <summary>
		/// 创建一个进度条事件参数.
		/// </summary>
		/// <param name="value">值.</param>
		public ProgressbarEventArgs ( int value )
		{

			if ( value < 0 )
				value = 0;

			this.Value = value;
		}

	}

}

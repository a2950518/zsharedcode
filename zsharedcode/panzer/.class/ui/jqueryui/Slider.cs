/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Slider.cs
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
	/// jQuery UI 分割条插件.
	/// </summary>
	[ToolboxData ( "<{0}:Slider runat=server></{0}:Slider>" )]
	public class Slider
		: JQueryWidget<SliderSetting>, IPostBackEventHandler
	{

		/// <summary>
		/// 创建一个 jQuery UI 分割条.
		/// </summary>
		public Slider ( )
			: base ( new SliderSetting ( ), HtmlTextWriterTag.Div )
		{ }

		#region " option "
		/// <summary>
		/// 获取或设置分割条是否可用, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示分割条是否可用, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.uiSetting.Disabled; }
			set { this.uiSetting.Disabled = value; }
		}

		/// <summary>
		/// 获取或设置是否播放动画, 默认为 false.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( false )]
		[Description ( "指示是否播放动画, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Animate
		{
			get { return this.uiSetting.Animate; }
			set { this.uiSetting.Animate = value; }
		}

		/// <summary>
		/// 获取或设置分割条最大值, 默认为 100.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 100 )]
		[Description ( "指示分割条最大值, 默认为 100" )]
		[NotifyParentProperty ( true )]
		public int Max
		{
			get { return this.uiSetting.Max; }
			set { this.uiSetting.Max = value; }
		}

		/// <summary>
		/// 获取或设置分割条最小值, 比如: 0.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 0 )]
		[Description ( "指示分割条最小值, 比如: 0" )]
		[NotifyParentProperty ( true )]
		public int Min
		{
			get { return this.uiSetting.Min; }
			set { this.uiSetting.Min = value; }
		}

		/// <summary>
		/// 获取或设置分割条的方向, 默认为 horizontal.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( SliderSetting.OrientationType.horizontal )]
		[Description ( "指示分割条的方向, 默认为 horizontal" )]
		[NotifyParentProperty ( true )]
		public SliderSetting.OrientationType Orientation
		{
			get { return this.uiSetting.Orientation; }
			set { this.uiSetting.Orientation = value; }
		}

		/// <summary>
		/// 获取或设置分割条是否使用范围, 默认为 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示分割条是否使用范围, 默认为 false" )]
		[NotifyParentProperty ( true )]
		public bool Range
		{
			get { return this.uiSetting.Range; }
			set { this.uiSetting.Range = value; }
		}

		/// <summary>
		/// 获取或设置分割条的步长, 默认为 1.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示分割条的步长, 默认为 1" )]
		[NotifyParentProperty ( true )]
		public int Step
		{
			get { return this.uiSetting.Step; }
			set { this.uiSetting.Step = value; }
		}

		/// <summary>
		/// 获取或设置分割条的值, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示分割条的值, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public int Value
		{
			get { return this.uiSetting.Value; }
			set { this.uiSetting.Value = value; }
		}

		/// <summary>
		/// 获取或设置分割条的范围值, 比如: [1, 4, 10], 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的范围值, 比如: [1, 4, 10], 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Values
		{
			get { return this.uiSetting.Values; }
			set { this.uiSetting.Values = value; }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置分割条被创建时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.uiSetting.Create; }
			set { this.uiSetting.Create = value; }
		}

		/// <summary>
		/// 获取或设置分割条开始拖动时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条开始拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.uiSetting.Start; }
			set { this.uiSetting.Start = value; }
		}

		/// <summary>
		/// 获取或设置分割条拖动时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Slide
		{
			get { return this.uiSetting.Slide; }
			set { this.uiSetting.Slide = value; }
		}

		/// <summary>
		/// 获取或设置分割条改变时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.uiSetting.Change; }
			set { this.uiSetting.Change = value; }
		}

		/// <summary>
		/// 获取或设置分割条结束拖动时的事件, 类似于: "function(event, ui) { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条结束拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.uiSetting.Stop; }
			set { this.uiSetting.Stop = value; }
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
		public AjaxSetting ChangeAsync
		{
			get { return this.uiSetting.ChangeAsync; }
		}
		#endregion

		#region " server "
		/// <summary>
		/// 在服务器端执行的值改变事件.
		/// </summary>
		[Description ( "指示值改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event SliderChangeEventHandler ChangeSync;
		#endregion

		protected override bool isFaceless ( )
		{ return this.DesignMode && ( this.selector != string.Empty || this.html == string.Empty ); }

		protected override bool isFace ( )
		{ return this.DesignMode && this.selector == string.Empty && this.html != string.Empty; }

		protected override string facelessPrefix ( )
		{ return "Slider"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Orientation );
			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.Value );

			return base.facelessPostfix ( ) + postfix;
		}

		protected override void AddAttributesToRender ( HtmlTextWriter writer )
		{
			base.AddAttributesToRender ( writer );

			if ( this.isFace ( ) )
				writer.AddAttribute ( HtmlTextWriterAttribute.Class,
					string.Format (
					"ui-slider ui-slider-{1} ui-widget ui-widget-content ui-corner-all{0}",
					this.Disabled ? " ui-accordion-disabled ui-state-disabled" : string.Empty,
					this.Orientation
					)
					);

		}

		protected override void RenderContents ( HtmlTextWriter writer )
		{

			if ( null != this.ChangeSync )
				this.Change = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "change;[%':ui.value%]" ) + "}";

			base.RenderContents ( writer );

			if ( this.isFace ( ) )
			{
				writer.RenderBeginTag ( HtmlTextWriterTag.Div );
				writer.AddAttribute ( HtmlTextWriterAttribute.Class, "ui-slider-handle ui-state-default ui-corner-all" );
				writer.AddStyleAttribute ( HtmlTextWriterStyle.Left, ( this.Value / this.Max ).ToString ( ) + "%" );
				writer.RenderEndTag ( );
			}

		}

		private void onChange ( SliderEventArgs e )
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
						SliderEventArgs e = new SliderEventArgs ( StringConvert.ToObject<int> ( parts[1] ) );

						this.onChange ( e );
						this.ChangeSync ( this, e );
					}

					break;

			}

		}

	}

	/// <summary>
	/// 分割条值改变事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void SliderChangeEventHandler ( object sender, SliderEventArgs e );

	/// <summary>
	/// 分割条事件参数.
	/// </summary>
	public sealed class SliderEventArgs
	{
		/// <summary>
		/// 值.
		/// </summary>
		public readonly int Value;

		/// <summary>
		/// 创建一个分割条事件参数.
		/// </summary>
		/// <param name="value">值.</param>
		public SliderEventArgs ( int value )
		{

			if ( value < 0 )
				value = 0;

			this.Value = value;
		}

	}

}

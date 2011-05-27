/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISlider
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISliderOrientationType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Slider.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/JQueryElement.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DraggableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DroppableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SortableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SelectableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ResizableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ParameterEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/WidgetSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/RepeaterSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryCoder.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/JQueryUI.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 分割条插件.
	/// </summary>
	[ToolboxData ( "<{0}:Slider runat=server></{0}:Slider>" )]
	[DesignerAttribute ( typeof ( SliderDesigner ) )]
	public class Slider
		: BaseWidget, IPostBackEventHandler
	{

		#region " Enum "
		/// <summary>
		/// Orientation 类型.
		/// </summary>
		public enum OrientationType
		{
			/// <summary>
			/// 水平.
			/// </summary>
			horizontal = 0,
			/// <summary>
			/// 垂直.
			/// </summary>
			vertical = 1,
		}
		#endregion


		private readonly AjaxSettingEdit changeAjax = new AjaxSettingEdit ( );
		private readonly AjaxSettingEdit completeAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 分割条.
		/// </summary>
		public Slider ( )
			: base ( WidgetType.slider )
		{ this.elementType = ElementType.Div; }

		#region " Option "
		/// <summary>
		/// 获取或设置分割条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示分割条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ), false ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value.ToString ( ).ToLower ( ) ); }
		}

		/// <summary>
		/// 获取或设置是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'.
		/// </summary>
		[Category ( "动画" )]
		[DefaultValue ( false )]
		[Description ( "指示是否播放动画, 为 true 或者 false, 或者 'slow', 'normal', 'fast'" )]
		[NotifyParentProperty ( true )]
		public bool Animate
		{
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.animate ), false ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.animate, value.ToString ( ).ToLower ( ) ); }
		}

		/// <summary>
		/// 获取或设置分割条最大值, 比如: 100.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( 100 )]
		[Description ( "指示分割条最大值, 比如: 100" )]
		[NotifyParentProperty ( true )]
		public int Max
		{
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.max ), 100 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.max, value <= 0 || value == 100 ? string.Empty : value.ToString ( ) ); }
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
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.min ), 0 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.min, value <= 0 ? string.Empty : value.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置分割条的方向.
		/// </summary>
		[Category ( "外观" )]
		[DefaultValue ( OrientationType.horizontal )]
		[Description ( "指示分割条的方向" )]
		[NotifyParentProperty ( true )]
		public OrientationType Orientation
		{
			get { return this.getEnum<OrientationType> ( this.editHelper.GetOuterOptionEditValue ( OptionType.orientation ), OrientationType.horizontal ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.orientation, value == OrientationType.horizontal ? string.Empty : "'" + value.ToString ( ) + "'" ); }
		}

		/// <summary>
		/// 获取或设置分割条是否使用范围, 或者为 'min', 'max' 中的一种.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示分割条是否使用范围, 或者为 'min', 'max' 中的一种" )]
		[NotifyParentProperty ( true )]
		public bool Range
		{
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.range ), false ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.range, value.ToString ( ).ToLower ( ) ); }
		}

		/// <summary>
		/// 获取或设置分割条的步长, 比如: 3.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 1 )]
		[Description ( "指示分割条的步长, 比如: 3" )]
		[NotifyParentProperty ( true )]
		public int Step
		{
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.step ), 1 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.step, value <= 1 ? string.Empty : value.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置分割条的值, 比如: 30.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示分割条的值, 比如: 30" )]
		[NotifyParentProperty ( true )]
		public int Value
		{
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.value ), 0 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.value, value <= 0 ? string.Empty : value.ToString ( ) ); }
		}

		/// <summary>
		/// 获取或设置分割条的范围值, 比如: [1, 4, 10].
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条的范围值, 比如: [1, 4, 10]" )]
		[NotifyParentProperty ( true )]
		public string Values
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.values ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.values, value ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置分割条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置分割条开始拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条开始拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.start ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.start, value ); }
		}

		/// <summary>
		/// 获取或设置分割条拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Slide
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.slide ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.slide, value ); }
		}

		/// <summary>
		/// 获取或设置分割条改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置分割条结束拖动时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示分割条结束拖动时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.stop ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.stop, value ); }
		}
		#endregion

		#region " Ajax "
		/// <summary>
		/// 获取 Change 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Change 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AjaxSettingEdit ChangeAsync
		{
			get { return this.changeAjax; }
		}
		#endregion

		#region " Server "
		/// <summary>
		/// 在服务器端执行的值改变事件.
		/// </summary>
		[Description ( "指示值改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event SliderChangeEventHandler ChangeSync;
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				this.widgetSetting.Type = this.type;

				this.widgetSetting.SliderSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.changeAjax.Url != string.Empty )
				{
					this.changeAjax.WidgetEventType = EventType.slidechange;
					this.widgetSetting.AjaxSettings.Add ( this.changeAjax );
				}

				if ( null != this.ChangeSync )
					this.Change = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "change;[%':ui.value%]" ) + "}";

			}
			else if ( this.selector == string.Empty )
				switch ( this.type )
				{
					case WidgetType.slider:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );
						//<DIV id=Sd class="ui-slider ui-slider-horizontal ui-widget ui-widget-content ui-corner-all" jQuery151036562766734722585="10"><A style="LEFT: 15%" class="ui-slider-handle ui-state-default ui-corner-all" href="http://localhost:55735/TestJQueryUI.aspx#" jQuery151036562766734722585="11"></A></DIV>
						writer.Write (
							"<{6} id=\"{0}\" class=\"{3}ui-slider ui-slider-{7} ui-widget ui-widget-content ui-corner-all{2}\" style=\"{4}\" title=\"{5}\"><a style=\"left: {1}%;\" class=\"ui-slider-handle ui-state-default ui-corner-all\"></div></{6}>",
							this.ClientID,
							this.Value / this.Max,
							this.Disabled ? " ui-slider-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( ),
							this.Orientation
							);
						return;
				}

			base.Render ( writer );
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

	#region " SliderDesigner "
	/// <summary>
	/// 分割条设计器.
	/// </summary>
	public class SliderDesigner : JQueryElementDesigner
	{

		/// <summary>
		/// 获取行为列表.
		/// </summary>
		public override DesignerActionListCollection ActionLists
		{
			get { return new DesignerActionListCollection ( ); }
		}

	}
	#endregion

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

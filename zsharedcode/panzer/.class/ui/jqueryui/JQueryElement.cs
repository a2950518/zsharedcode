/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryElement.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " JQueryElement "
	/// <summary>
	/// 派生所有 jQuery UI 服务器控件的基础类.
	/// </summary>
	[ParseChildren ( true )]
	[Resource ( SingleScript = "je.jquery.js;je.jquery.ui.js", SingleStyle = "je.jquery.ui.css" )]
	public abstract class JQueryElement<S>
		: WebControl, INamingContainer
		where S : UISetting
	{

		#region " static "
		protected static Literal renderTemplate ( WebControl control, ITemplate template )
		{
			Literal content = new Literal ( );

			if ( null == template )
				return content;
			else
			{
				PlaceHolder holder = new PlaceHolder ( );
				//template.InstantiateIn ( content );
				template.InstantiateIn ( holder );

				StringWriter writer = new StringWriter ( );
				holder.RenderControl ( new HtmlTextWriter ( writer ) );

				content.Text = JQueryCoder.Encode ( control, writer.ToString ( ) );
				//content.Text = JQueryCoder.Encode ( control, content.Text );
			}

			return content;
		}
		#endregion

		/// <summary>
		/// 创建一个 jQuery UI 的基础服务器控件.
		/// </summary>
		/// <param name="uiSetting">基础服务器控件的设置.</param>
		/// <param name="elementType">最终页面输出的元素类型.</param>
		protected JQueryElement ( S uiSetting, HtmlTextWriterTag elementType )
		{

			if ( null == uiSetting )
				throw new ArgumentNullException ( "uiSetting", "设置不能为空" );

			this.uiSetting = uiSetting;
			this.elementType = elementType;
		}

		#region " property "
		protected readonly S uiSetting;
		private List<AjaxSetting> ajaxs;
		private ViewStateHelper viewStateHelper;

		private HtmlTextWriterTag elementType = HtmlTextWriterTag.Span;

		private bool isVariable = false;
		protected string selector = string.Empty;

		protected string html = string.Empty;
		private string text = string.Empty;
		private ITemplate contentTemplate;

		private bool isShowMore = true;
		private string scriptPackageID = string.Empty;

		/// <summary>
		/// 获取或设置 Ajax 操作列表.
		/// </summary>
		[Browsable ( false )]
		[Category ( "基本" )]
		[Description ( "Ajax 操作" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public virtual List<AjaxSetting> AjaxList
		{
			get
			{

				if ( null == this.ajaxs )
					this.ajaxs = new List<AjaxSetting> ( );

				return this.ajaxs;
			}
		}

		/// <summary>
		/// 获取或设置元素的类型.
		/// </summary>
		[Category ( "Html" )]
		[Description ( "最终在页面上生成的元素类型, 比如: Span, Div, 默认为 Span, 不生成任何元素" )]
		[DefaultValue ( HtmlTextWriterTag.Span )]
		public HtmlTextWriterTag ElementType
		{
			get { return this.elementType; }
			set { this.elementType = value; }
		}

		/// <summary>
		/// 获取或设置是否生成 jquery 对应的 javascript 变量, 如果使用了 Repeater, Timer 则在运行时自动调整为 true.
		/// </summary>
		[Category ( "脚本" )]
		[Description ( "是否以 ClientID 生成对应的 javascript 变量, 如果使用了 Repeater, Timer 则在运行时自动调整为 true" )]
		[DefaultValue ( false )]
		public bool IsVariable
		{
			get { return this.isVariable; }
			set { this.isVariable = value; }
		}

		/// <summary>
		/// 获取或设置选择器, 将针对此选择器对应的元素执行操作, 比如: "'#age'", 默认为自身.
		/// </summary>
		[Category ( "脚本" )]
		[Description ( "选择器, 将针对此选择器对应的元素执行操作, 比如: \"'#age'\", 默认为自身" )]
		[DefaultValue ( "" )]
		public string Selector
		{
			get { return this.selector; }
			set
			{

				if ( null != value )
					this.selector = value;

			}
		}

		/// <summary>
		/// 获取或设置包含了元素中包含的 html 代码, Html 属性将覆盖 Text. 
		/// </summary>
		[Category ( "Html" )]
		[Description ( "设置包含了元素中包含的 html 代码, Html 属性将覆盖 Text" )]
		[DefaultValue ( "" )]
		public string Html
		{
			get { return this.html; }
			set
			{

				if ( null != value )
					this.html = value;

			}
		}

		/// <summary>
		/// 获取或设置包含了元素中包含的文本, Html 属性将覆盖 Text. 
		/// </summary>
		[Category ( "Html" )]
		[Description ( "设置包含了元素中包含的文本, Html 属性将覆盖 Text" )]
		[DefaultValue ( "" )]
		public string Text
		{
			get { return this.text; }
			set
			{

				if ( null != value )
					this.text = value;

			}
		}

		/// <summary>
		/// 获取或设置内部 html 代码的模板, 如果有效, 将覆盖 Html 和 Text 属性. 
		/// </summary>
		[Browsable ( false )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public ITemplate ContentTemplate
		{
			get { return this.contentTemplate; }
			set { this.contentTemplate = value; }
		}

		/// <summary>
		/// 获取或设置是否在设计视图显示重要选项的内容.
		/// </summary>
		[Category ( "设计" )]
		[Description ( "是否在设计视图显示重要选项的内容" )]
		[DefaultValue ( true )]
		public bool IsShowMore
		{
			get { return this.isShowMore; }
			set { this.isShowMore = value; }
		}

		/// <summary>
		/// 获取或设置脚本存放的 ScriptPackage 控件的 ID.
		/// </summary>
		[Category ( "脚本" )]
		[Description ( "脚本存放的 ScriptPackage 控件的 ID" )]
		[DefaultValue ( "" )]
		[IDReferenceProperty ( typeof ( ScriptPackage ) )]
		public string ScriptPackageID
		{
			get { return this.scriptPackageID; }
			set
			{

				if ( null != value )
					this.scriptPackageID = value;

			}
		}

		/// <summary>
		/// 获取或设置自定义选项, 比如: "helper = __jsVariable", 多个选项请用 ; 号分隔, 如果需要在表达式中使用 ; 或 = 可用 /; 或 /= 表示.
		/// </summary>
		[Category ( "基本" )]
		[DefaultValue ( "" )]
		[Description ( "指示自定义选项, 比如: helper = __jsVariable, 多个选项请用 ; 号分隔, 如果需要在表达式中使用 ; 或 = 可用 /; 或 /= 表示" )]
		[NotifyParentProperty ( true )]
		public string CustomOption
		{
			get { return this.uiSetting.CustomOption; }
			set { this.uiSetting.CustomOption = value; }
		}

		/// <summary>
		/// (无效) 获取或设置存储的属性列表, 多个属性可用 ; 号分割, 比如: "Student.Name;Student.Age".
		/// </summary>
		[Category ( "数据" )]
		[Description ( "(无效) 存储的属性列表, 多个属性可用 ; 号分割, 比如: \"Student.Name;Student.Age\"" )]
		[DefaultValue ( "" )]
		public string StoreProperty
		{
			get { return ( null == this.viewStateHelper ? string.Empty : this.viewStateHelper.StoreProperty ); }
			set
			{

				if ( string.IsNullOrEmpty ( value ) )
					return;

				if ( null == this.viewStateHelper )
					this.viewStateHelper = new ViewStateHelper ( this );

				this.viewStateHelper.StoreProperty = value;
			}
		}
		#endregion

		protected override HtmlTextWriterTag TagKey
		{
			get
			{

				if ( this.isFaceless ( ) || this.selector != string.Empty )
					return HtmlTextWriterTag.Code;
				else
					return this.elementType;

			}
		}

		protected virtual bool isFaceless ( )
		{ return this.DesignMode && ( this.selector != string.Empty || ( this.text == string.Empty && this.html == string.Empty ) ); }

		protected virtual bool isFace ( )
		{ return this.DesignMode && this.selector == string.Empty && ( this.text != string.Empty || this.html != string.Empty ); }

		protected virtual string facelessPrefix ( )
		{ return "JE"; }

		protected virtual string facelessPostfix ( )
		{
			string postfix = string.Empty;

			if ( ( this.uiSetting.OptionCount + this.uiSetting.EventCount ) != 0 )
				postfix += string.Format ( " <span style=\"color: #009933\">{0}</span>", this.uiSetting.OptionCount + this.uiSetting.EventCount );

			return postfix;
		}

		protected virtual void renderJQuery ( JQueryUI jquery )
		{

			if ( null != this.ajaxs )
				foreach ( AjaxSetting setting in this.ajaxs )
					jquery.Ajax ( setting );

		}

		protected override void RenderContents ( HtmlTextWriter writer )
		{
			base.RenderContents ( writer );

			if ( this.isFaceless ( ) )
				writer.Write ( "<span style=\"font-family: Verdana; background-color: #FFFFFF\"><strong>{0}:</strong> {1}{3}{2}</span>",
					this.facelessPrefix ( ), this.selector == string.Empty ? this.ID : "<span style=\"color: #0066FF\">" + this.selector + "</span>",
					this.isShowMore ? this.facelessPostfix ( ) : string.Empty,
					this.scriptPackageID == string.Empty ? string.Empty : " <span style=\"color: #666633\">" + this.scriptPackageID + "</span>"
					);
			else if ( null == this.contentTemplate )
				// If the ContentTemplate is null, then make the Html or Text as the display contents
				if ( this.html != string.Empty )
					writer.Write ( this.html );
				else if ( this.text != string.Empty )
					writer.WriteEncodedText ( this.text );

			// Does not generate jQuery scripts in design mode
			if ( this.DesignMode )
				return;

			JQueryUI jquery = new JQueryUI ( string.IsNullOrEmpty ( this.selector ) ? string.Format ( "'#{0}'", this.ClientID ) : string.Format ( "jQuery.panzer.createJQuery({0})", UISetting.CreateJQuerySelector ( this.selector ) ), false );

			// Classes that inherit from JQueryElement can generate jQuery script into variable jquery
			this.renderJQuery ( jquery );

			jquery.Code = "$(function(){" + ( this.isVariable ? ( "window['" + this.ClientID + "'] = " ) : string.Empty ) + JQueryCoder.Encode ( this, jquery.Code ) + "});";

			if ( this.scriptPackageID != string.Empty )
			{
				ScriptPackage package = this.NamingContainer.FindControl ( this.scriptPackageID ) as ScriptPackage;

				if ( null != package )
				{
					// To write the script in the ScriptPackage, so that you do not need to separately generated

					package.Code += jquery.Code;
					return;
				}

			}

			jquery.Build ( new ASPXScriptHolder ( this ), this.ClientID, ScriptBuildOption.Startup );
		}

		protected override void CreateChildControls ( )
		{

			if ( null == this.contentTemplate )
			{
				base.CreateChildControls ( );
				return;
			}

			this.Controls.Clear ( );
			this.Controls.Add ( renderTemplate ( this, this.contentTemplate ) );
		}

		/*
		protected override void LoadViewState ( object savedState )
		{
			base.LoadViewState ( savedState );
			if ( null != this.viewStateHelper )
				( this.viewStateHelper as IStateManager ).LoadViewState ( savedState );
		}

		protected override object SaveViewState ( )
		{

			if ( null == this.viewStateHelper )
				return base.SaveViewState ( );
			else
				return ( this.viewStateHelper as IStateManager ).SaveViewState ( );

		}
		*/

	}
	#endregion

}

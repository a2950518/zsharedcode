using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ABC
{

	[ParseChildren ( true )]
	[PersistChildren (false)]
	public class TTT
		: WebControl
	{
		private PL h = new PL ( );
		private PlaceHolder h1 = new PlaceHolder ( );

		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public string Name
		{
			get { return "sdf"; }
			set { }
		}

		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PL H
		{
			get { return this.h; }
		}

		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Html
		{
			get { return this.h1; }
		}
	}

	/// <summary>
	///PL 的摘要说明
	/// </summary>
	public class PL : System.Web.UI.WebControls.PlaceHolder
	{

		public PL ( )
		{
			//
			//TODO: 在此处添加构造函数逻辑
			//
		}
	}

	#region " JQueryElement "
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public class JQueryElement1
		: WebControl
	{

		////protected string attribute = string.Empty;
		////private bool isVariable = false;
		////protected string selector = string.Empty;

		//private PlaceHolder abc = new PlaceHolder ( );

		///// <summary>
		///// 获取 PlaceHolder 控件, 其中包含了元素中包含的 html 代码. 
		///// </summary>
		//[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		//[PersistenceMode ( PersistenceMode.InnerProperty )]
		//public PlaceHolder ABC
		//{
		//    get { return this.abc; }
		//}

		/////// <summary>
		/////// 获取或设置是否生成 jquery 对应的 javascript 变量, 如果使用了 Repeater, 则在运行时自动调整为 true.
		/////// </summary>
		////[Category ( "jQuery UI" )]
		////[Description ( "是否以 ClientID 生成对应的 javascript 变量, 如果使用了 Repeater, 则在运行时自动调整为 true" )]
		////[DefaultValue ( false )]
		////public virtual bool IsVariable
		////{
		////    get { return this.isVariable; }
		////    set
		////    {
		////        this.isVariable = value;
		////    }
		////}

		/////// <summary>
		/////// 获取或设置选择器, 将针对此选择器对应的元素执行操作, 比如: "'#age'", 默认为自身.
		/////// </summary>
		////[Category ( "jQuery UI" )]
		////[Description ( "选择器, 将针对此选择器对应的元素执行操作, 比如: \"'#age'\", 默认为自身" )]
		////[DefaultValue ( "" )]
		////public virtual string Selector
		////{
		////    get { return this.selector; }
		////    set { this.selector = value; }
		////}

		/////// <summary>
		/////// 获取或设置元素的属性.
		/////// </summary>
		////[Category ( "jQuery UI" )]
		////[Description ( "最终在页面上生成的元素的属性" )]
		////[DefaultValue ( "" )]
		////public virtual string Attribute
		////{
		////    get { return this.attribute; }
		////    set
		////    {

		////        if ( null != value )
		////            this.attribute = value;

		////    }
		////}

		///// <summary>
		///// 创建一个 JQueryElement.
		///// </summary>
		////public JQueryElement1 ( )
		////    : base ( )
		////{
		////    //this.EnableViewState = false;

		////    //this.Controls.Add ( this.html );
		////}

		////protected override void Render ( HtmlTextWriter writer )
		////{
		////    base.Render ( writer );
		////}
		private PlaceHolder h1 = new PlaceHolder ( );

		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public string ABC
		{
			get { return "sdf"; }
			set { }
		}

		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public PlaceHolder Html
		{
			get { return this.h1; }
		}

	}
	#endregion


}
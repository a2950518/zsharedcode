using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer;
using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.debug;

public partial class TestJQuery : System.Web.UI.Page
{

	protected void Page_Load ( object sender, EventArgs e )
	{

	}

	protected void cmdTestConstructor_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		result += "测试构造函数 JQuery<br />";

		foreach ( object jQuery in tracer.Execute ( null, typeof ( JQuery ), null, FunctionType.Constructor, null, null, null, null,
			new object[][] {
				new object[] { },
				new object[] { false },
				new object[] { "'body table'" },
				new object[] { "'body table'", false },
				new object[] { "'body table'", "document.body" },
				new object[] { "'body table'", "document.body", false },
			},
			false
			)
			)
			result += "返回: " + jQuery.ToString () + "<br />";
		
		this.lblResult.Text = result;
	}

	protected void cmdTestCreate_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		result += "测试方法 JQuery.Create()<br />";

		foreach ( object jQuery in tracer.Execute ( null, typeof ( JQuery ), "Create", FunctionType.Method, new Type[] { }, null, null, null,
			new object[][] {
				new object[] { }
			},
			false
			)
			)
			result += "返回: " + jQuery.ToString () + "<br />";

		result += "测试方法 JQuery.Create(bool)<br />";

		foreach ( object jQuery in tracer.Execute ( null, typeof ( JQuery ), "Create", FunctionType.Method, new Type[] { typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { false }
			},
			false
			)
			)
			result += "返回: " + jQuery.ToString () + "<br />";

		result += "测试方法 JQuery.Create(string)<br />";

		foreach ( object jQuery in tracer.Execute ( null, typeof ( JQuery ), "Create", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'table'" }
			},
			false
			)
			)
			result += "返回: " + jQuery.ToString () + "<br />";

		result += "测试方法 JQuery.Create(string, bool)<br />";

		foreach ( object jQuery in tracer.Execute ( null, typeof ( JQuery ), "Create", FunctionType.Method, new Type[] { typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'table'", false }
			},
			false
			)
			)
			result += "返回: " + jQuery.ToString () + "<br />";

		result += "测试方法 JQuery.Create(string, string)<br />";

		foreach ( object jQuery in tracer.Execute ( null, typeof ( JQuery ), "Create", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'table'", "document.body" }
			},
			false
			)
			)
			result += "返回: " + jQuery.ToString () + "<br />";

		result += "测试方法 JQuery.Create(string, string, bool)<br />";

		foreach ( object jQuery in tracer.Execute ( null, typeof ( JQuery ), "Create", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'table'", "document.body", false }
			},
			false
			)
			)
			result += "返回: " + jQuery.ToString () + "<br />";

		this.lblResult.Text = result;
	}

	protected void cmdTestClone_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ("'table'");

		result += "测试方法 jQuery.Clone()<br />";

		foreach ( object newJQuery in tracer.Execute ( jQuery, null, "Clone", FunctionType.Method, new Type[] { }, null, null, null,
			new object[][] {
				new object[] { }
			},
			false
			)
			)
			result += "newJQuery.Code = " + ( newJQuery as JQuery ).Code + "<br />";

		this.lblResult.Text = result;
	}

	protected void cmdTestEndLine_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'table'" );

		result += "测试方法 jQuery.EndLine()<br />";

		foreach ( object newJQuery in tracer.Execute ( jQuery, null, "EndLine", FunctionType.Method, new Type[] { }, null, null, null,
			new object[][] {
				new object[] { }
			},
			false
			)
			)
			result += "newJQuery.Code = " + ( newJQuery as JQuery ).Code + "<br />";

		this.lblResult.Text = result;
	}

	protected void cmdTestAddClass_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ("'table'");

		result += "测试方法 JQuery.AddClass(string)<br />";

		tracer.Execute ( jQuery, null, "AddClass", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'box'" },
				new object[] { "function(i, c){ return 'happy'; }" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestAttr_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery1 = new JQuery ( "'#myTable1'" );
		JQuery jQuery2 = new JQuery ( "'#myTable2'" );

		result += "测试方法 JQuery.Attr(string)<br />";

		tracer.Execute ( jQuery1, null, "Attr", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "{ border: '1' }" },
				new object[] { "'style'" }
			},
			false
			);

		result += "jQuery1.Code = " + jQuery1.Code + "<br />";

		result += "测试方法 JQuery.Attr(string, string)<br />";

		tracer.Execute ( jQuery2, null, "Attr", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'border'", "'1'" },
				new object[] { "'style'", "function(i, a){ return 'width: 700px'; }" }
			},
			false
			);

		result += "jQuery2.Code = " + jQuery2.Code + "<br />";

		this.lblResult.Text = result;

		jQuery1.Build ( this, option: ScriptBuildOption.Startup );
		jQuery2.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestHasClass_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'table'" );

		result += "测试方法 JQuery.HasClass(string)<br />";

		tracer.Execute ( jQuery, null, "HasClass", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'big'" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.Code + "<br />";

		ScriptHelper scriptHelper = new ScriptHelper ();
		scriptHelper.Alert ( "'table 是否拥有 big 样式? ' + " + jQuery.Code );

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestHtml_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery1 = new JQuery ( "'#myTable1'" );
		JQuery jQuery2 = new JQuery ( jQuery1 );

		result += "测试方法 JQuery.Html()<br />";

		tracer.Execute ( jQuery1, null, "Html", FunctionType.Method, new Type[] { }, null, null, null,
			new object[][] {
				new object[] { }
			},
			false
			);

		result += "jQuery1.Code = " + jQuery1.Code + "<br />";

		result += "测试方法 JQuery.Html(string)<br />";

		tracer.Execute ( jQuery2, null, "Html", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'<tr><td>jQuery2</td></tr>'" }
			},
			false
			);

		result += "jQuery2.Code = " + jQuery2.Code + "<br />";

		ScriptHelper scriptHelper = new ScriptHelper ();
		scriptHelper.Alert ( "'myTable1.innerHTML = ' + " + jQuery1.Code );

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
		jQuery2.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestRemoveAttr_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'#myTable2'" );

		result += "测试方法 JQuery.RemoveAttr(string)<br />";

		tracer.Execute ( jQuery, null, "RemoveAttr", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'class'" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestRemoveClass_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'#myTable2'" );

		result += "测试方法 JQuery.RemoveClass(string)<br />";

		tracer.Execute ( jQuery, null, "RemoveClass", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'big'" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestToggleClass_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'#myTable2'" );

		result += "测试方法 JQuery.ToggleClass(string)<br />";

		tracer.Execute ( jQuery, null, "ToggleClass", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'big'" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestVal_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery1 = new JQuery ( "'#myTextBox1'" );
		JQuery jQuery2 = new JQuery ( jQuery1 );

		result += "测试方法 JQuery.Val()<br />";

		tracer.Execute ( jQuery1, null, "Val", FunctionType.Method, new Type[] { }, null, null, null,
			new object[][] {
				new object[] { }
			},
			false
			);

		result += "jQuery1.Code = " + jQuery1.Code + "<br />";

		result += "测试方法 JQuery.Val(string)<br />";

		tracer.Execute ( jQuery2, null, "Val", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'jack'" }
			},
			false
			);

		result += "jQuery2.Code = " + jQuery2.Code + "<br />";

		ScriptHelper scriptHelper = new ScriptHelper ();
		scriptHelper.Alert ( "'myTextBox1.value = ' + " + jQuery1.Code );

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
		jQuery2.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestEq_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'li'" );

		result += "测试方法 JQuery.Eq(string)<br />";

		tracer.Execute ( jQuery, null, "Eq", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "-1" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.Html().Code + "<br />";

		ScriptHelper scriptHelper = new ScriptHelper ();
		scriptHelper.Alert ( "'li eq(-1).innerHTML = ' + " + jQuery.Code );

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestFilter_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'li'" );

		result += "测试方法 JQuery.Filter(string)<br />";

		tracer.Execute ( jQuery, null, "Filter", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "function(i){return i == 1;}" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.AddClass ( "'big'" ).Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestHas_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'ul'" );

		result += "测试方法 JQuery.Has(string)<br />";

		tracer.Execute ( jQuery, null, "Has", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'.happy'" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.AddClass ( "'big'" ).Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestIs_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'li'" );

		result += "测试方法 JQuery.Is(string)<br />";

		tracer.Execute ( jQuery, null, "Is", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'.happy'" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.Code + "<br />";

		ScriptHelper scriptHelper = new ScriptHelper ();
		scriptHelper.Alert ( "'li is(.happay) = ' + " + jQuery.Code );

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestFirst_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'li'" );

		result += "测试方法 JQuery.First()<br />";

		tracer.Execute ( jQuery, null, "First", FunctionType.Method, new Type[] { }, null, null, null,
			new object[][] {
				new object[] { }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.AddClass ( "'big'" ).Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestLast_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'li'" );

		result += "测试方法 JQuery.Last()<br />";

		tracer.Execute ( jQuery, null, "Last", FunctionType.Method, new Type[] { }, null, null, null,
			new object[][] {
				new object[] { }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.AddClass ( "'big'" ).Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestMap_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'li'" );

		result += "测试方法 JQuery.Map(string)<br />";

		tracer.Execute ( jQuery, null, "Map", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "function(i, o){return alert($(this).text());}" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestNot_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery = new JQuery ( "'li'" );

		result += "测试方法 JQuery.Not(string)<br />";

		tracer.Execute ( jQuery, null, "Not", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "':eq(0)'" }
			},
			false
			);

		result += "jQuery.Code = " + jQuery.AddClass ( "'big'" ).Code + "<br />";

		this.lblResult.Text = result;

		jQuery.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdTestSlice_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		JQuery jQuery1 = new JQuery ( "'li'" );
		JQuery jQuery2 = new JQuery ( "'li'" );

		result += "测试方法 JQuery.Slice(string)<br />";

		tracer.Execute ( jQuery1, null, "Slice", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "2" }
			},
			false
			);

		result += "jQuery1.Code = " + jQuery1.AddClass ( "'big'" ).Code + "<br />";

		result += "测试方法 JQuery.Slice(string, string)<br />";

		tracer.Execute ( jQuery2, null, "Slice", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "2", "4" }
			},
			false
			);

		result += "jQuery2.Code = " + jQuery2.AddClass ( "'happy'" ).Code + "<br />";

		this.lblResult.Text = result;

		jQuery1.Build ( this, option: ScriptBuildOption.Startup );
		jQuery2.Build ( this, option: ScriptBuildOption.Startup );
	}

}
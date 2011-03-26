using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer;
using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.debug;

public partial class TestScriptHelper : System.Web.UI.Page
{

	protected void Page_Load ( object sender, EventArgs e )
	{

	}

	#region " 测试 "

	protected void cmdTestConstructor_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		result += "测试构造函数 ScriptHelper, 分别使用 空; ScriptType.JavaScript; ScriptType.VBScript;<br />";

		foreach ( object scriptHelper in tracer.Execute ( null, typeof ( ScriptHelper ), null, FunctionType.Constructor, null, null, null, null,
			new object[][] {
				new object[] { },
				new object[] { ScriptType.JavaScript },
				new object[] { ScriptType.VBScript }
			},
			false
			)
			)
			result += "返回: " + scriptHelper.ToString () + "<br />";

		this.lblResult.Text = result;
	}

	protected void cmdTestAlert_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.Alert(string)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Alert", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'你好1'" },
				new object[] { "'\"你好2\"'" }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.Alert(string, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Alert", FunctionType.Method, new Type[] { typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'你好1, 追加? true'", true },
				new object[] { "'\"你好2\", 追加? false'", false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}

	protected void cmdTestConfirm_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.Confirm(string)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Confirm", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'确定1?'" },
				new object[] { "'\"确定2?\"'" }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.Confirm(string, string)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Confirm", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'确定? 返回结果到变量 c1'", "c1" },
				new object[] { "'确定? 但没有返回到变量'", null }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.Confirm(string, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Confirm", FunctionType.Method, new Type[] { typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'确定1? 追加? true'", true },
				new object[] { "'\"确定2?\", 追加? false'", false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.Confirm(string, string, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Confirm", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'确定? 返回结果到变量 c1, 追加? true'", "c1", true },
				new object[] { "'确定? 但没有返回到变量, 追加? false'", null, false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}

	protected void cmdTestPrompt_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.Prompt(string, string)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Prompt", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'姓名? 保存到 n1'", "n1" },
				new object[] { "'\"年龄? 保存到 a1\"'", "a1" }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.Prompt(string, string, string)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Prompt", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'姓名? 保存到 n1'", "'没有名字'", "n1" },
				new object[] { "'\"年龄? 保存到 a1\"'", "'10'", "a1" }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.Prompt(string, string, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Prompt", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'姓名? 保存到 n1, 追加? true'", "n1", true },
				new object[] { "'\"年龄? 保存到 a1\", 追加? false'", "a1", false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.Prompt(string, string, string, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Prompt", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ), typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'姓名? 保存到 n1, 追加? true'", "'没有名字'", "n1", true },
				new object[] { "'\"年龄? 保存到 a1\", 追加? false'", "'10'", "a1", false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}

	protected void cmdTestNavigate_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		/*
		result += "测试方法 ScriptHelper.Navigate(string)<br />";

		tracer.Execute ( scriptHelper, null, "Navigate", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'http://www.google.com/'" }
			},
			false
			);
		*/

		result += "测试方法 ScriptHelper.Navigate(string, NavigateOption)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Navigate", FunctionType.Method, new Type[] { typeof ( string ), typeof ( NavigateOption ) }, null, null, null,
			new object[][] {
				new object[] { "'http://www.google.com/'", NavigateOption.NewWindow },
				new object[] { "'http://www.google.com/'", NavigateOption.SelfWindow }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.Navigate(string, NavigateOption, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "Navigate", FunctionType.Method, new Type[] { typeof ( string ), typeof ( NavigateOption ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'http://www.google.com/'", NavigateOption.NewWindow, true },
				new object[] { "'http://www.google.com/'", NavigateOption.SelfWindow, false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}
	protected void cmdTestAppendScript_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.AppendScript(string)<br />";

		scriptHelper.Confirm ( "'有名字?'", "n" );

		tracer.Execute ( scriptHelper, null, "AppendScript", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "if(n){n = '有名字';}else{n = '没有名字';}" }
			},
			false
			);

		scriptHelper.Alert ( "'名字? ' + n" );

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}
	protected void cmdTestClear_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.Clear(string)<br />";

		scriptHelper.Confirm ( "'有名字?'", "n" );
		scriptHelper.Alert ( "'一句话'" );

		tracer.Execute ( scriptHelper, null, "Clear", FunctionType.Method, null, null, null, null,
			new object[][] {
				new object[] { }
			},
			false
			);

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}
	protected void cmdTestBuild_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.Build(Page)<br />";

		scriptHelper.Alert ( "'测试 Build 1'" );

		tracer.Execute ( scriptHelper, null, "Build", FunctionType.Method, new Type[] { typeof ( Page ) }, null, null, null,
			new object[][] {
				new object[] { this }
			},
			false
			);

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";
		result += "测试方法 ScriptHelper.Build(Page, ScriptBuildOption)<br />";

		scriptHelper.Clear ();
		scriptHelper.Alert ( "'测试 Build 2'" );

		tracer.Execute ( scriptHelper, null, "Build", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( ScriptBuildOption ) }, null, null, null,
			new object[][] {
				new object[] { this, ScriptBuildOption.OnlyCode }
			},
			false
			);

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";
		result += "测试方法 ScriptHelper.Build(Page, string)<br />";

		scriptHelper.Clear ();
		scriptHelper.Alert ( "'测试 Build 3'" );

		tracer.Execute ( scriptHelper, null, "Build", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { this, "myscript" },
				new object[] { this, "myscript" }
			},
			false
			);

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";
		result += "测试方法 ScriptHelper.Build(Page, string, ScriptBuildOption)<br />";

		scriptHelper.Clear ();
		scriptHelper.Alert ( "'测试 Build 4'" );

		tracer.Execute ( scriptHelper, null, "Build", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( string ), typeof ( ScriptBuildOption ) }, null, null, null,
			new object[][] {
				new object[] { this, "myscript1", ScriptBuildOption.None },
				new object[] { this, "myscript2", ScriptBuildOption.OnlyCode },
				new object[] { this, "myscript3", ScriptBuildOption.Startup },
				new object[] { this, "myscript3", ScriptBuildOption.Startup }
			},
			false
			);

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

	}

	protected void cmdTestRegisterArray_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		result += "测试方法 RegisterArray(Page, string)<br />";

		tracer.Execute ( null, typeof ( ScriptHelper ), "RegisterArray", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { this, "mynames" },
				new object[] { this, "myages" },
			},
			false
			);

		result += "测试方法 RegisterArray(Page, string, string)<br />";

		tracer.Execute ( null, typeof ( ScriptHelper ), "RegisterArray", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { this, "myns", "'jack', 'tom'" },
				new object[] { this, "myns", "'jack1', 'tom1'" }
			},
			false
			);

		this.lblResult.Text = result + "脚本, 请查看源文件<br />";

	}

	protected void cmdTestRegisterInclude_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		result += "测试方法 RegisterInclude(Page, string)<br />";

		tracer.Execute ( null, typeof ( ScriptHelper ), "RegisterInclude", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { this, "~/test.js" }
			},
			false
			);

		result += "测试方法 RegisterInclude(Page, string, string)<br />";

		tracer.Execute ( null, typeof ( ScriptHelper ), "RegisterInclude", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { this, "test1", "http://www.google.com/test.js" },
				new object[] { this, "test1", "http://www.google.com/test.js" }
			},
			false
			);

		this.lblResult.Text = result + "脚本, 请查看源文件<br />";

	}

	protected void cmdTestRegisterAttribute_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		result += "测试方法 RegisterAttribute(Page, string, string, string)<br />";

		tracer.Execute ( null, typeof ( ScriptHelper ), "RegisterAttribute", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( string ), typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { this, "spanTest", "innerHTML", "点击我" },
				new object[] { this, "spanTest", "style.color", "#ff0000" }
			},
			false
			);

		this.lblResult.Text = result + "脚本, 请查看源文件<br />";

	}

	protected void cmdTestRegisterHidden_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		result += "测试方法 RegisterHidden(Page, string, string)<br />";

		tracer.Execute ( null, typeof ( ScriptHelper ), "RegisterHidden", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { this, "hidden1", "1" },
				new object[] { this, "hidden1", "2" },
				new object[] { this, "hidden2", null }
			},
			false
			);

		this.lblResult.Text = result + "脚本, 请查看源文件<br />";

	}

	protected void cmdTestRegisterSubmit_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		result += "测试方法 RegisterSubmit(Page, string, string)<br />";

		tracer.Execute ( null, typeof ( ScriptHelper ), "RegisterSubmit", FunctionType.Method, new Type[] { typeof ( Page ), typeof ( string ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { this, "s1", "alert('OK1!');" },
				new object[] { this, "s1", "alert('OK2!');" },
				new object[] { this, "s2", "alert('OK3!');" }
			},
			false
			);

		this.lblResult.Text = result + "请点击\"填好了!\"按钮, 脚本, 请查看源文件<br />";

	}

	protected void cmdTestSetInterval_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.SetInterval(string, int)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "SetInterval", FunctionType.Method, new Type[] { typeof ( string ), typeof ( int ) }, null, null, null,
			new object[][] {
				new object[] { "'alert(\"hello, 每隔 5 秒钟触发\")'", 5000 },
				new object[] { "function(){alert('函数方式触发, 每隔 5 秒钟触发');}", 5000 }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.SetInterval(string, int, string)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "SetInterval", FunctionType.Method, new Type[] { typeof ( string ), typeof ( int ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'alert(\"hello, 每隔 20 秒钟触发, 句柄保存到 timer1\")'", 20000, "timer1" },
				new object[] { "function(){alert('函数方式触发, 每隔 20 秒钟触发, 句柄保存到 timer2');}", 20000, "timer2" }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.SetInterval(string, int, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "SetInterval", FunctionType.Method, new Type[] { typeof ( string ), typeof ( int ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'alert(\"hello, 每隔 5 秒钟触发, 不追加\")'", 5000, false },
				new object[] { "function(){alert('函数方式触发, 每隔 5 秒钟触发, 不追加');}", 5000, false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.SetInterval(string, int, string, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "SetInterval", FunctionType.Method, new Type[] { typeof ( string ), typeof ( int ), typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'alert(\"hello, 每隔 20 秒钟触发, 句柄保存到 timer1, 不追加\")'", 20000, "timer1", false },
				new object[] { "function(){alert('函数方式触发, 每隔 20 秒钟触发, 句柄保存到 timer2, 不追加');}", 20000, "timer2", false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}

	protected void cmdTestSetTimeout_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.SetTimeout(string, int)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "SetTimeout", FunctionType.Method, new Type[] { typeof ( string ), typeof ( int ) }, null, null, null,
			new object[][] {
				new object[] { "'alert(\"hello, 5 秒钟触发\")'", 5000 },
				new object[] { "function(){alert('函数方式触发, 5 秒钟触发');}", 5000 }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.SetTimeout(string, int, string)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "SetTimeout", FunctionType.Method, new Type[] { typeof ( string ), typeof ( int ), typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "'alert(\"hello, 20 秒钟触发, 句柄保存到 timer1\")'", 20000, "timer1" },
				new object[] { "function(){alert('函数方式触发, 20 秒钟触发, 句柄保存到 timer2');}", 20000, "timer2" }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.SetTimeout(string, int, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "SetTimeout", FunctionType.Method, new Type[] { typeof ( string ), typeof ( int ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'alert(\"hello, 5 秒钟触发, 不追加\")'", 5000, false },
				new object[] { "function(){alert('函数方式触发, 5 秒钟触发, 不追加');}", 5000, false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.SetTimeout(string, int, string, bool)<br />";

		foreach ( object code in tracer.Execute ( scriptHelper, null, "SetTimeout", FunctionType.Method, new Type[] { typeof ( string ), typeof ( int ), typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "'alert(\"hello, 20 秒钟触发, 句柄保存到 timer1, 不追加\")'", 20000, "timer1", false },
				new object[] { "function(){alert('函数方式触发, 20 秒钟触发, 句柄保存到 timer2, 不追加');}", 20000, "timer2", false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}

	protected void cmdTestClearInterval_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.ClearInterval(string)<br />";

		scriptHelper.SetInterval ( "'alert(\"句柄 timer1\");'", 5000, "timer1" );

		foreach ( object code in tracer.Execute ( scriptHelper, null, "ClearInterval", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "timer1" },
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.ClearInterval(string, bool)<br />";

		scriptHelper.SetInterval ( "'alert(\"句柄 timer2\");'", 5000, "timer2" );

		foreach ( object code in tracer.Execute ( scriptHelper, null, "ClearInterval", FunctionType.Method, new Type[] { typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "timer2", false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}

	protected void cmdTestClearTimeout_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		ScriptHelper scriptHelper = new ScriptHelper ();

		result += "测试方法 ScriptHelper.ClearTimeout(string)<br />";

		scriptHelper.SetInterval ( "'alert(\"句柄 timer1\");'", 5000, "timer1" );

		foreach ( object code in tracer.Execute ( scriptHelper, null, "ClearTimeout", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "timer1" },
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "测试方法 ScriptHelper.ClearTimeout(string, bool)<br />";

		scriptHelper.SetInterval ( "'alert(\"句柄 timer2\");'", 5000, "timer2" );

		foreach ( object code in tracer.Execute ( scriptHelper, null, "ClearTimeout", FunctionType.Method, new Type[] { typeof ( string ), typeof ( bool ) }, null, null, null,
			new object[][] {
				new object[] { "timer2", false }
			},
			false
			)
			)
			result += "返回: " + code.ToString () + "<br />";

		result += "scriptHelper.Code = " + scriptHelper.Code + "<br />";

		this.lblResult.Text = result;

		scriptHelper.Build ( this );
	}

	protected void cmdTestMakeKey_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ();

		result += "测试方法 ScriptHelper.MakeKey()<br />";

		foreach ( object key in tracer.Execute ( null, typeof ( ScriptHelper ), "MakeKey", FunctionType.Method, new Type[] { }, null, null, null,
			new object[][] {
				new object[] { },
			},
			false
			)
			)
			result += "返回: " + key.ToString () + "<br />";

		result += "测试方法 ScriptHelper.MakeKey(string)<br />";

		foreach ( object key in tracer.Execute ( null, typeof ( ScriptHelper ), "MakeKey", FunctionType.Method, new Type[] { typeof ( string ) }, null, null, null,
			new object[][] {
				new object[] { "testKey" }
			},
			false
			)
			)
			result += "返回: " + key.ToString () + "<br />";

		this.lblResult.Text = result;
	}

	#endregion

	#region " 示例 "

	protected void cmdAdd1_Click ( object sender, EventArgs e )
	{
		// 创建 ScriptHelper 对象
		ScriptHelper scriptHelper = new ScriptHelper ();
		string name = this.txtName1.Text;
		string ageString = this.txtAge1.Text;

		bool isInfoValid = true;

		int age = 0;

		if ( name == string.Empty )
		{
			// 没有写姓名, 添加弹出消息框的脚本
			scriptHelper.Alert ( "'请填写姓名'" );
			isInfoValid = false;
		}
		else if ( name.Length < 2 || name.Length > 4 )
		{
			// 姓名格式错误, 添加弹出消息框的脚本
			scriptHelper.Alert ( "'姓名应有 2 到 4 个字'" );
			isInfoValid = false;
		}
		else if ( !int.TryParse ( ageString, out age ) )
		{
			// 年龄格式错误, 添加弹出消息框的脚本
			scriptHelper.Alert ( "'年龄应该是数字'" );
			isInfoValid = false;
		}

		if ( !isInfoValid )
		{
			// 因为存在错误, 生成脚本到页面并返回
			scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
			return;
		}

		int result = 0;
		// 在这里将数据提交到数据库, 并将下面的语句去掉
		result = new Random ().Next ( 0, 2 );

		switch ( result )
		{
			case 0:
				// 添加成功, 添加显示成功消息的脚本
				scriptHelper.Alert ( "'添加成功'" );
				// 设置页面的标签 span1 为绿色并显示姓名和年龄
				ScriptHelper.RegisterAttribute ( this, "span1", "innerHTML", string.Format ( "被添加内容: {0}, {1}", name, age ) );
				ScriptHelper.RegisterAttribute ( this, "span1", "style.color", "#00ff00" );
				break;

			case 1:
				// 添加失败, 添加显示失败消息的脚本
				scriptHelper.Alert ( "'添加失败'" );
				// 设置页面的标签 span1 为红色并显示姓名和年龄
				ScriptHelper.RegisterAttribute ( this, "span1", "innerHTML", string.Format ( "被添加内容: {0}, {1}", name, age ) );
				ScriptHelper.RegisterAttribute ( this, "span1", "style.color", "#ff0000" );
				break;
		}

		// 生成脚本到页面
		scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdRun2_Click ( object sender, EventArgs e )
	{
		// 创建 ScriptHelper 对象
		ScriptHelper scriptHelper = new ScriptHelper ();
		string code = this.txtCode2.Text;

		if ( code == string.Empty )
		{
			// 没有脚本, 添加弹出消息框的脚本
			scriptHelper.Alert ( "'没有任何脚本'" );
			scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
			return;
		}

		ScriptHelper.RegisterAttribute ( this, this.lblCode2.ClientID, "innerText", code );
		scriptHelper.AppendCode ( code );

		// 生成脚本到页面
		scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdNext3_Click ( object sender, EventArgs e )
	{
		// 创建 ScriptHelper 对象
		ScriptHelper scriptHelper = new ScriptHelper ();
		string name = this.txtName3.Text;

		if ( name == string.Empty )
			// 没有写用户名, 添加弹出消息框的脚本
			scriptHelper.Alert ( "'请填写用户名'" );
		else
		{
			// 隐藏第一步, 显示第二步, 记录用户名到隐藏字段
			ScriptHelper.RegisterAttribute ( this, "r1", "style.display", "none" );
			ScriptHelper.RegisterAttribute ( this, "r2", "style.display", "block" );
			ScriptHelper.RegisterHidden ( this, "r1name", name );
		}

		// 生成脚本
		scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdOK3_Click ( object sender, EventArgs e )
	{
		// 创建 ScriptHelper 对象
		ScriptHelper scriptHelper = new ScriptHelper ();
		string password = this.txtPassword3.Text;

		// 隐藏第一步, 设置记录的用户名到隐藏字段
		ScriptHelper.RegisterAttribute ( this, "r1", "style.display", "none" );
		ScriptHelper.RegisterHidden ( this, "r1name", this.Request["r1name"] );

		if ( password == string.Empty )
		{
			// 没有写密码, 添加弹出消息框的脚本, 并显示第二步
			scriptHelper.Alert ( "'请填写密码'" );
			ScriptHelper.RegisterAttribute ( this, "r2", "style.display", "block" );
		}
		else
		{
			// 显示注册结果
			ScriptHelper.RegisterAttribute ( this, "r3", "style.display", "block" );
			ScriptHelper.RegisterAttribute ( this, "rr1", "innerText", string.Format ( "用户名: {0}, 密码: {1}", this.Request["r1name"], password ) );
		}

		// 生成脚本
		scriptHelper.Build ( this, option: ScriptBuildOption.Startup );
	}

	protected void cmdOK4_Click ( object sender, EventArgs e )
	{
		// 创建 ScriptHelper 对象
		ScriptHelper scriptHelper = new ScriptHelper ();

		// 声明用于存储颜色值得数组
		ScriptHelper.RegisterArray ( this, "colors", "10, 99, 10" );

		// 添加可以得到不同颜色的函数
		scriptHelper.AppendCode ( "function GetNextColor(){colors[0]++;colors[1]--;colors[2]+=2;if(colors[0]>99){colors[0]=10;}if(colors[1]<10){colors[1]=99;}if(colors[2]>99){colors[2]=10;}return '#' + colors[0].toString() + colors[1].toString() + colors[2].toString(); }" );

		// 设置时钟, 改变标签的颜色
		scriptHelper.SetInterval ( "function(){document.getElementById('span4').style.color = GetNextColor();}", 100 );

		// 生成脚本
		scriptHelper.Build ( this, option:ScriptBuildOption.Startup );
	}

	#endregion

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer;
using zoyobar.shared.panzer.ui.dweb;
using zoyobar.shared.panzer.debug;

public partial class TestDataWebCore : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected void cmdTestConstructor_Click ( object sender, EventArgs e )
	{
		string result = string.Empty;
		Tracer tracer = new Tracer ( );

		result += "测试构造函数 DW, 分别使用 空; ScriptType.JavaScript; ScriptType.VBScript;<br />";

		foreach ( object core in tracer.Execute ( null, typeof ( DataWebCore<IDataWeb<PagerSetting>, PagerSetting> ), null, FunctionType.Constructor, null, null, null, null,
			new object[][] {
				new object[] { null, null }
			},
			false
			)
			)
			result += "返回: " + core.ToString ( ) + "<br />";

		this.lblResult.Text = result;
	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web.jqueryui;

public partial class TestJQueryUI : System.Web.UI.Page
{

	public void D ( ExpressionHelper h )
	{
		this.Response.Write ( string.Format ( "{2}{0}={1}<br/>", h.Name, h.Value, h.IsHasChild ) );

		foreach ( ExpressionHelper sh in h.ChildExpressionHelpers )
			this.D ( sh );
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//ExpressionHelper h = new ExpressionHelper ( "false`;`|name`:'abc'`,age`:123|``;" );
		//this.D ( h );

		//new ListItem ( );
		//this.Response.Write(this.jqueryUI.DraggableSetting.Options.Count);
		//this.Response.Write ( this.jqueryUI.DraggableSetting.Options[0].Value );

	}
	protected void Button1_Click ( object sender, EventArgs e )
	{ this.jqueryUI.DraggableSetting.IsDraggable = true; }
	protected void Button2_Click ( object sender, EventArgs e )
	{
		//this.jqueryUI.DraggableSetting.Options[0].Value = "Button2_Click";
	}
}
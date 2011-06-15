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
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//ExpressionHelper h = new ExpressionHelper ( "false`;`|name`:'abc'`,age`:123|``;" );
		//this.D ( h );

		//new ListItem ( );
		//this.Response.Write(this.jqueryUI.DraggableSetting.Options.Count);
		//this.Response.Write ( this.jqueryUI.DraggableSetting.Options[0].Value );
		zoyobar.shared.panzer.web.ScriptHelper s = new zoyobar.shared.panzer.web.ScriptHelper ( );

		s.Alert ( "'abc'" );
		//s.Build ( this );
		new System.Web.UI.WebControls.Button();
		//new System.Web.UI.Desi
	}
	protected void Progressbar1_CompleteSync ( object sender, zoyobar.shared.panzer.ui.jqueryui.ProgressbarEventArgs e )
	{
		this.Response.Write ( e.Value.ToString ( ) + "sdfdfe" );
	}
	protected void Progressbar1_ChangeSync ( object sender, zoyobar.shared.panzer.ui.jqueryui.ProgressbarEventArgs e )
	{

	}
	protected void Sd_ChangeSync ( object sender, zoyobar.shared.panzer.ui.jqueryui.SliderEventArgs e )
	{
		this.Response.Write ( e.Value.ToString ( ) + "sdfdfe" );
	}
	protected void A_ChangeSync ( object sender, zoyobar.shared.panzer.ui.jqueryui.AccordionEventArgs e )
	{
		//this.Response.Write ( e.Index.ToString ( ) + "sdfdfe" );

	}
	protected void A_ChangeSync1 ( object sender, zoyobar.shared.panzer.ui.jqueryui.AccordionEventArgs e )
	{
		this.Response.Write ( e.Active.ToString ( ) + "sdfdfe" );

	}
}
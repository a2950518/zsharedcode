using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.ib;

namespace zoyobar.shared.panzer.test.web.ib
{

	public partial class FormIEBrowser3 : Form
	{
		private readonly IEBrowser ie;

		private readonly WebPageState state1 = new WebPageState (
			"load my google",
			new NavigateAction ( "http://www.google.com.hkkk/", 3 ),
			completedStateSetting: new WebPageNextStateSetting ( "load my google ok", true ),
			failedStateSetting: new WebPageNextStateSetting ( "load my google fail", true ),
			condition: new UrlCondition ( "google", "http://www.google.com.hkkk/", StringCompareMode.StartWith ),
			timeout: 10
			);

		private readonly WebPageState state2 = new WebPageState (
			"load my google ok",
			new ExecuteJavaScriptAction ( "alert('load my google ok');" )
			);

		private readonly WebPageState state3 = new WebPageState (
			"load my google fail",
			new NavigateAction ( "http://www.google.com.hk/", 3 )
			);

		public FormIEBrowser3 ( )
		{
			InitializeComponent ( );

			this.ie = new IEBrowser ( this.webBrowser, new WebPageState[] {
					this.state1, this.state2, this.state3
				}
				);

		}

		private void cmdTest_Click ( object sender, EventArgs e )
		{ this.ie.IEFlow.JumpToState ( "load my google" ); }

	}

}

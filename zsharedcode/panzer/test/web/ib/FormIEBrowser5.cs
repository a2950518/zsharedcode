using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

	public partial class FormIEBrowser5 : Form
	{
		private IEBrowser ie;

		public FormIEBrowser5 ( )
		{
			InitializeComponent ( );
			this.ie = new IEBrowser ( this.webBrowser );
		}

		private void cmdBegin_Click ( object sender, EventArgs e )
		{
			this.ie.IERecord.BeginRecord ( );
		}

		private void cmdEnd_Click ( object sender, EventArgs e )
		{
			this.ie.IERecord.EndRecord ( );
		}

		private void cmdReplay_Click ( object sender, EventArgs e )
		{
			this.ie.IERecord.BeginReplay ( );
		}

		private void button1_Click ( object sender, EventArgs e )
		{
			this.ie.ExecuteScript ( this.textBox1.Text );
		}

		private void cmdN_Click ( object sender, EventArgs e )
		{
			this.ie.Navigate ( "http://www.baidu.com/" );
			this.ie.IEFlow.Wait ( new UrlCondition ( "W", "http://www.baidu.com", StringCompareMode.StartWith ) );
			this.ie.IERecord.InstallRecord ( );
		}

		private void cmdGetActions_Click ( object sender, EventArgs e )
		{
			this.ie.__Get<object> ( "__actions" );
		}

		private void button2_Click ( object sender, EventArgs e )
		{
			this.ie.IERecord.EndReplay ( );
		}

	}

}

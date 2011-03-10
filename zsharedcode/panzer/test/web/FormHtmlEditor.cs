using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using zoyobar.shared.panzer.web;

namespace zoyobar.shared.panzer.test.web
{
	public partial class FormHtmlEditor : Form
	{
		private readonly HtmlEditHelper editHelper;

		public FormHtmlEditor ( )
		{
			InitializeComponent ( );

			this.editHelper = new HtmlEditHelper ( this.browser, "web/html.editor.htm" );
		}

		private void cmdBackColor_Click ( object sender, EventArgs e )
		{ this.editHelper.BackColor ( Color.Red ); }

		private void cmdBold_Click ( object sender, EventArgs e )
		{ this.editHelper.Bold ( ); }
	}
}

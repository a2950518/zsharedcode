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
		private readonly HtmlEditor editor;

		public FormHtmlEditor ( )
		{
			InitializeComponent ( );

			this.editor = new HtmlEditor ( this.browser );
		}

		private void cmdBackColor_Click ( object sender, EventArgs e )
		{
			this.editor.BackColor ( Color.Red );
		}
	}
}

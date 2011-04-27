using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zoyobar.shared.panzer.test.web.ib
{

	public partial class FormVCode : Form
	{
		public Image Image
		{
			set { this.pictureBox.Image = value; }
		}

		public string VCode
		{
			get { return this.txtVCode.Text.Trim ( ); }
		}

		public FormVCode ( )
		{
			InitializeComponent ( );
		}

		private void cmdOK_Click ( object sender, EventArgs e )
		{

			if ( this.txtVCode.Text.Trim ( ) != string.Empty )
				this.Close ( );

		}

	}

}

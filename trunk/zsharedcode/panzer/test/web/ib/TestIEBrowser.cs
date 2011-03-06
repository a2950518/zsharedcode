using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

using zoyobar.shared.panzer.ui;
using zoyobar.shared.panzer.debug;

namespace zoyobar.shared.panzer.test.web
{

	public class TestIEBrowser
	{

		private readonly Tracer tracer = new Tracer ();

		public void Test ()
		{

			if ( this.tracer.WaitInputAChar ( "是否测试 IEBrowser?" ) != 'y' )
				return;

			new ib.FormIEBrowser ( ).ShowDialog ( );
			new ib.FormIEBrowser2 ( ).ShowDialog ( );
			new ib.FormIEBrowser3 ( ).ShowDialog ( );
		}


	}

}

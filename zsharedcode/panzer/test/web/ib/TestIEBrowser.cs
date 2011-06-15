using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

using zoyobar.shared.panzer.web.ib;
using zoyobar.shared.panzer.debug;

namespace zoyobar.shared.panzer.test.web
{

	public class TestIEBrowser
	{
		private readonly Tracer tracer = new Tracer ( );

		public void Test ( )
		{

			if ( this.tracer.WaitInputAChar ( "是否测试 IEBrowser?" ) != 'y' )
				return;

			//new ib.FormIEBrowser ( ).ShowDialog ( );
			//new ib.FormIEBrowser2 ( ).ShowDialog ( );
			//new ib.FormIEBrowser3 ( ).ShowDialog ( );
			new ib.FormIEBrowserDoc ( ).ShowDialog ( );
			//new ib.FormIEBrowserTemp ( ).ShowDialog ( );
			//new ib.FormIEBrowserManaged ( ).ShowDialog ( );
			//new ib.FormIEBrowser4 ( ).ShowDialog ( );
			//new ib.FormIEBrowser5 ( ).ShowDialog ( );
			//new ib.ieplus.FormMain ( ).ShowDialog ( );
			//new ib.FormIEBrowserButtonClick ( ).ShowDialog ( );
		}


	}


}

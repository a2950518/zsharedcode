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

	public partial class FormIEBrowser4 : Form
	{

		public FormIEBrowser4 ( )
		{
			InitializeComponent ( );
		}

		private void cmdWait_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象.
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 导航到页面 http://www.google.com.hk/.
			ie.Navigate ( "http://www.google.com.hk/" );

			// 等待页面载入完毕.
			ie.IEFlow.Wait ( new UrlCondition ( "wait", "http://www.google.com.hk", StringCompareMode.StartWith ) );

			MessageBox.Show ( "页面已经载入" );
		}

	}

}

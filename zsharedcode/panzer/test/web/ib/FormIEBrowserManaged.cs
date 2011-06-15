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

	public partial class FormIEBrowserManaged : Form
	{

		public FormIEBrowserManaged ( )
		{
			InitializeComponent ( );

		}

		private void cmdManaged_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象.
			IEBrowser ie = new IEBrowser ( this.webBrowser, scripting: new ManagedForScript ( ) );

			// 安装跟踪脚本, 执行 jquery 和调用托管代码必需.
			ie.InstallTrace ( );

			// 安装本地的 jquery 脚本.
			ie.InstallScript ( Properties.Resources.jquery_1_5_2_min );

			// 得到搜索框的内容.
			string key = ie.ExecuteJQuery<string> ( JQuery.Create ( "'[name=q]:text'" ).Val ( ) );

			// 通过 javascript 调用托管的对象 ManagedForScript 的 MakeCondition, 生成新的搜索内容, 其实可以直接调用 MakeCondition, 这里只是演示如何调用托管代码.
			key = ie.ExecuteManaged<string> ( "MakeCondition", parameters: new string[] { "'" + key + "'" } );

			// 将新的搜索内容填写入搜索框.
			ie.ExecuteJQuery ( JQuery.Create ( "'[name=q]:text'" ).Val ( "'" + key + "'" ) );
		}

	}

	// 在 javascript 脚本中调用的对象的 ComVisible 必须设置为 true.
	[ComVisible ( true )]
	public class ManagedForScript
	{

		// 为搜索条件增加 site:www.baidu.com.
		public string MakeCondition ( string key )
		{

			if ( string.IsNullOrEmpty ( key ) )
			{
				// 当 javascript 调用时, 将类似于 alert 函数.
				MessageBox.Show ( "关键字为空" );
				return string.Empty;
			}

			return string.Format ( "{0} site:www.baidu.com", key );
		}

	}

}

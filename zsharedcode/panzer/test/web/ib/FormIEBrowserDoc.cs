using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using zoyobar.shared.panzer.web.ib;

namespace zoyobar.shared.panzer.test.web.ib
{

	public partial class FormIEBrowserDoc : Form
	{

		public FormIEBrowserDoc ( )
		{
			InitializeComponent ( );
		}

		private void cmdNavigate_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象.
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 将 WebBrowser 导航到 http://www.google.com.hk/.
			ie.Navigate ( "http://www.google.com.hk/" );
		}

		private void cmdExecuteJavscript_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象, WebBrowser 的 Url 属性已经设置为 "about:blank".
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 在当前页面上执行 javascript 脚本, 弹出对话框.
			ie.ExecuteScript ( "alert('你好, IEBrowser!');" );

			// 可以执行多条 javascript 脚本, 对于脚本中的字符串可以使用 " 或者 '.
			ie.ExecuteScript ( "var message = \"我\" + '又来了';alert(message);" );
		}

		private void cmdInstallJavascript_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象, WebBrowser 的 Url 属性已经设置为 "about:blank".
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 定义 javascript 脚本, 声明一个 showMessage 函数.
			string showMessageScript = "function showMessage(message){alert('消息:' + message);}";
			// 将脚本安装到 WebBrowser 中.
			ie.InstallScript ( showMessageScript );

			// 执行脚本, 调用 showMessage 函数.
			ie.ExecuteScript ( "showMessage('哈哈!');" );

			// 定义 javascript 脚本, 声明一个 add 函数.
			string addScript = "function add(num1, num2){return num1 + num2;}";
			// 将脚本安装到 WebBrowser 中, id 为 jsAdd.
			ie.InstallScript ( addScript, "jsAdd" );

			// 执行脚本, 调用 add 函数.
			ie.ExecuteScript ( "showMessage(add(1, 3));" );

			// 安装本地 jquery 脚本, 需要生成目录中存在 jquery-1.5.min.js 文件.
			ie.InstallScript ( new Uri ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory, @"jquery-1.5.min.js" ) ) );

			// 如果从网络位置载入脚本, 可以等待 5 秒钟, 以便脚本载入完毕.
			// ie.IEFlow.Wait ( 5 );

			// 等待脚本载入完毕后, 执行一条 jquery 命令.
			ie.ExecuteScript ( "showMessage($('*').length);" );
		}

		private void cmdInvokeJavascript_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象, WebBrowser 的 Url 属性已经设置为 "about:blank".
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 安装定义函数 setName 和 getName 的函数到 WebBrowser.
			ie.InstallScript ( "var name;function setName(name){this.name = name;}function getName(){return this.name;}" );

			// 调用 setName 函数, 参数为 "jack".
			ie.InvokeScript ( "setName", new object[] { "jack" } );

			// 调用 getName 函数, 得到结果并弹出对话框.
			MessageBox.Show ( ie.InvokeScript ( "getName" ).ToString ( ) );
		}

		private void cmdDataExchange_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象, WebBrowser 的 Url 属性已经设置为 "about:blank".
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 安装跟踪脚本到 WebBrowser, 从而使 __Get 和 __Set 方法可以使用.
			ie.InstallTrace ( );

			int age = 10;

			// 设置姓名和年龄到 WebBrowser, 对于脚本中的字符串可以使用 " 或者 '.
			ie.__Set ( "name", "'tom'" );
			ie.__Set ( "age", ( age + 1 ).ToString ( ) );

			// 获取 WebBrowser 中的 name 和 age, 并弹出对话框.
			MessageBox.Show ( string.Format ( "name={0}, age={1}", ie.__Get<string> ( "name" ), ie.__Get<int> ( "age" ) ) );
		}

	}

}

using System;
using System.IO;
using System.Windows.Forms;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.ib;

namespace zoyobar.shared.panzer.test.web.ib
{

	public partial class FormIEBrowserButtonClick : Form
	{

		public FormIEBrowserButtonClick ( )
		{
			InitializeComponent ( );
		}

		private void cmdAdd_Click ( object sender, EventArgs e )
		{
			// 创建 IEBrowser 对象, 用来控制窗口的 WebBrowser 控件.
			IEBrowser ie = new IEBrowser ( this.webBrowser );
			// 载入已经放在运行目录的页面 ButtonClick.htm.
			ie.Navigate ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory + "ButtonClick.htm" ) );

			// 等待 ButtonClick.htm 完全载入.
			ie.IEFlow.Wait ( new UrlCondition ( "wait", "ButtonClick.htm", StringCompareMode.EndWith ) );

			// 模拟具有惟一 id 属性的按钮点击.

			// 方法1: 执行 javascript 脚本来获取按钮并调用其 click 方法.
			ie.ExecuteScript ( "document.getElementById('cmdAdd').click();" );

			// 方法2: 安装跟踪和 jQuery 脚本后, 执行 jQuery 来模拟点击按钮.
			// 安装跟踪脚本.
			ie.InstallTrace ( );
			// 安装在资源中的 jQuery 脚本.
			ie.InstallScript ( Properties.Resources.jquery_1_5_2_min );
			// 执行获取按钮并模拟点击的 jQuery 脚本.
			ie.ExecuteJQuery ( JQuery.Create ( "'#cmdAdd'" ).Click ( ) );
		}

		private void cmdSub_Click ( object sender, EventArgs e )
		{
			// 创建 IEBrowser 对象, 用来控制窗口的 WebBrowser 控件.
			IEBrowser ie = new IEBrowser ( this.webBrowser );
			// 载入已经放在运行目录的页面 ButtonClick.htm.
			ie.Navigate ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory + "ButtonClick.htm" ) );

			// 等待 ButtonClick.htm 完全载入.
			ie.IEFlow.Wait ( new UrlCondition ( "wait", "ButtonClick.htm", StringCompareMode.EndWith ) );

			// 根据按钮显示的文本模拟按钮点击.

			// 方法1: 安装搜索按钮的 javascript 函数 clickButton 来获取按钮并调用其 click 方法.
			// 安装 clickButton 函数.
			ie.InstallScript ( "function clickButton(text){for(var i=0;i<document.all.length;i++){if(document.all[i].value==text){document.all[i].click();break;}}}" );
			// 调用 clickButton 函数, 模拟点击文本为 Sub 的按钮.
			ie.InvokeScript ( "clickButton", new object[] { "Sub" } );

			// 方法2: 安装跟踪和 jQuery 脚本后, 执行 jQuery 来模拟点击按钮.
			// 安装跟踪脚本.
			ie.InstallTrace ( );
			// 安装在资源中的 jQuery 脚本.
			ie.InstallScript ( Properties.Resources.jquery_1_5_2_min );
			// 执行获取按钮并模拟点击的 jQuery 脚本.
			ie.ExecuteJQuery ( JQuery.Create ( "'[value=Sub]:button'" ).Click ( ) );
		}

	}

}

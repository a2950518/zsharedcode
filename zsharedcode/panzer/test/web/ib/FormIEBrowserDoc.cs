using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using zoyobar.shared.panzer.web;
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

		private void cmdExecuteJQuery_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象.
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 导航到页面 http://www.google.com.hk/.
			ie.Navigate ( "http://www.google.com.hk/" );

			// 等待 5 秒钟, 以便页面载入完毕.
			ie.IEFlow.Wait ( 5 );

			// 安装跟踪脚本, 这可以执行更多的 jquery 操作.
			ie.InstallTrace ( );

			// 安装本地的 jquery 脚本.
			ie.InstallJQuery ( new Uri ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory, @"jquery-1.5.min.js" ) ) );

			// 执行 jquery 脚本 $('*').length, 获得页面上总元素个数.
			Console.WriteLine ( "页面上共有 {0} 个元素", ie.ExecuteJQuery ( JQuery.Create ( "'*'" ).Length ( ) ) );

			// 执行 jquery 脚本 $('a'), 获得页面上所有的 a 元素并将结果保存在 __jAs 变量中.
			ie.ExecuteJQuery ( JQuery.Create ( "'a'" ), "__jAs" );

			// 得到 __jAs 变量中包含的 a 元素的个数.
			int count = ie.ExecuteJQuery<int> ( JQuery.Create ( "__jAs" ).Length ( ) );

			for ( int index = 0; index < count; index++ )
			{
				// 得到 __jAs 变量中索引为 index 的 a 元素, 并保存在 __jA 变量中.
				ie.ExecuteJQuery ( JQuery.Create ( "__jAs" ).Eq ( index.ToString ( ) ), "__jA" );

				// 输出 a 元素的 innerText 和 href 属性.
				Console.WriteLine ( string.Format (
					"a[{0}], '{1}', '{2}'",
					index,
					ie.ExecuteJQuery<string> ( JQuery.Create ( "__jA" ).Text ( ) ),
					ie.ExecuteJQuery<string> ( JQuery.Create ( "__jA" ).Attr ( "'href'" ) )
					)
					);
			}

		}

		private void cmdFlowNWPC_Click ( object sender, EventArgs e )
		{
			// 定义载入 google 的页面状态.
			WebPageState loadGoogle = new WebPageState (
				"load google", // 状态的名称.
				completedStateSetting: new WebPageNextStateSetting ( "load blog", true ), // 在页面完成时, 自动跳转到载入 blog 的状态.
				startAction: new NavigateAction ( "http://www.google.com.hk" ), // 页面状态的开始动作为载入 http://www.google.com.hk.
				condition: new UrlCondition ( // 判断页面状态是否完成的地址条件.
					"google condition", // 条件名称.
					"http://www.google.com.hk", // 载入的页面以 http://www.google.com.hk 开始时, 认为此地址条件成立.
					StringCompareMode.StartWith
					)
				);

			// 定义载入 blog 的页面状态.
			WebPageState loadMyBlog = new WebPageState (
				"load blog", // 状态的名称.
				startAction: new NavigateAction ( "http://blog.sina.com.cn/zoyobar" ), // 页面状态的开始动作为载入 http://blog.sina.com.cn/zoyobar.
				completedAction: new ExecuteJavaScriptAction ( "alert('我是从 google 页面跳转过来的!');" ), // 当页面状态完成后, 执行一条 javascript 脚本.
				condition: new UrlCondition ( // 判断页面状态是否完成的地址条件.
					"blog condition", // 条件名称.
					"http://blog.sina.com.cn/zoyobar", // 载入的页面以 http://blog.sina.com.cn/zoyobar 开始时, 认为此地址条件成立.
					StringCompareMode.StartWith
					)
				);

			// 从当前的 WebBrowser 控件创建 IEBrowser 对象, 并赋予刚才定义的流程.
			IEBrowser ie = new IEBrowser ( this.webBrowser, new WebPageState[] { loadGoogle, loadMyBlog } );

			// 从载入 google 页面的状态开始.
			ie.IEFlow.JumpToState ( "load google" );
		}

		private void cmd163Blog_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象.
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 此处修改为您的 163 博客地址.
			ie.Navigate ( "http://<163 博客地址>" );
			ie.IEFlow.Wait ( 3 );

			// 安装 jquery 脚本.
			ie.InstallTrace ( );
			ie.InstallScript ( Properties.Resources.jquery_1_5_2_min, "jsJQuery" );

			// 弹出登录框.
			ie.ExecuteJQuery ( JQuery.Create ( "'a:contains(登录)'" ).Attr ( "'id'", "'denglu'" ) );
			ie.ExecuteScript ( "document.getElementById('denglu').click();" );

			// 填写用户信息并登录.
			ie.ExecuteJQuery ( JQuery.Create ( "'.ztxt:text'" ).Val ( "'<用户名>'" ) );
			ie.ExecuteJQuery ( JQuery.Create ( "'.ztxt:password'" ).Val ( "'<密码>'" ) );
			ie.ExecuteJQuery ( JQuery.Create ( "'.wbtnok:button'" ).Attr ( "'id'", "'dl'" ) );
			ie.ExecuteScript ( "document.getElementById('dl').click();" );
			ie.IEFlow.Wait ( 5 );

			// 安装 jquery 脚本.
			ie.InstallTrace ( );
			ie.InstallScript ( Properties.Resources.jquery_1_5_2_min, "jsJQuery" );

			// 跳转到日志页面.
			ie.ExecuteJQuery ( JQuery.Create ( "'a:contains(日志)' " ).Attr ( "'id'", "'rz'" ) );
			ie.ExecuteScript ( "document.getElementById('rz').click();" );
			ie.IEFlow.Wait ( 5 );

			// 安装 jquery 脚本.
			ie.InstallTrace ( );
			ie.InstallScript ( Properties.Resources.jquery_1_5_2_min, "jsJQuery" );

			// 跳转到编辑日志页面.
			ie.ExecuteJQuery ( JQuery.Create ( "'a:contains(写日志)' " ).Attr ( "'id'", "'xrz'" ) );
			ie.ExecuteScript ( "document.getElementById('xrz').click();" );
			ie.IEFlow.Wait ( 5 );

			// 安装 jquery 脚本.
			ie.InstallTrace ( );
			ie.InstallScript ( Properties.Resources.jquery_1_5_2_min, "jsJQuery" );

			// 填写日志内容.
			ie.ExecuteJQuery ( JQuery.Create ( "'.ztag:text'" ).Val ( "'<标题>'" ) );
			ie.ExecuteJQuery ( JQuery.Create ( "'#ne-auto-id-source'" ).Trigger ( "'click'" ) );

			ie.ExecuteJQuery ( JQuery.Create ( "'textarea.ztag'" ).Val ( string.Format ( "'{0}'", IEBrowser.EscapeCharacter ( "<日志 html 代码>" ) ) ) );

			ie.ExecuteJQuery ( JQuery.Create ( "'#ne-auto-id-source'" ).Trigger ( "'click'" ) );

			ie.ExecuteScript ( "document.getElementById('key-093402170-autotag').click();" );
			ie.IEFlow.Wait ( 5 );

			// 发布日志.
			ie.ExecuteJQuery ( JQuery.Create ( "'.fc09:button'" ).Attr ( "'id'", "'fb'" ) );
			ie.ExecuteScript ( "document.getElementById('fb').click();" );
		}

	}

}

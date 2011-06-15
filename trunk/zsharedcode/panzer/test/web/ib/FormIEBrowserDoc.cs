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
		// 在窗口的代码中定义 IEBrowser, 在窗口载入时初始化.
		private IEBrowser ie;

		public FormIEBrowserDoc ( )
		{
			InitializeComponent ( );

			// 从当前的 WebBrowser 控件创建 IEBrowser 对象.
			this.ie = new IEBrowser ( this.webBrowser );
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

			// 等待页面载入完毕.
			ie.IEFlow.Wait ( new UrlCondition ( "wait", "http://www.google.com.hk", StringCompareMode.StartWith ) );

			// 安装本地的 jquery 脚本.
			ie.InstallJQuery ( JQuery.CodeMin );

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
			ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );

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
			ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );

			// 跳转到日志页面.
			ie.ExecuteJQuery ( JQuery.Create ( "'a:contains(日志)' " ).Attr ( "'id'", "'rz'" ) );
			ie.ExecuteScript ( "document.getElementById('rz').click();" );
			ie.IEFlow.Wait ( 5 );

			// 安装 jquery 脚本.
			ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );

			// 跳转到编辑日志页面.
			ie.ExecuteJQuery ( JQuery.Create ( "'a:contains(写日志)' " ).Attr ( "'id'", "'xrz'" ) );
			ie.ExecuteScript ( "document.getElementById('xrz').click();" );
			ie.IEFlow.Wait ( 5 );

			// 安装 jquery 脚本.
			ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );

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

		private void cmdNoConflict_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象.
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 导航到页面 http://nt.discuz.net/, 此页面中已经定义了 $, 将和 jquery 的 $ 冲突.
			ie.Navigate ( "http://nt.discuz.net/" );

			// 等待 5 秒钟, 以便页面载入完毕.
			ie.IEFlow.Wait ( 5 );

			// 安装资源中的 jquery 脚本.
			ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );

			// 解除 jquery 的 $ 定义, 但仍然可以只用 jQuery 定义.
			ie.ExecuteJQuery ( JQuery.Create ( false, true ).NoConflict ( ) );

			// 执行 jquery 脚本 jQuery('*').length, 获得页面上总元素个数.
			Console.WriteLine ( "页面上共有 {0} 个元素", ie.ExecuteJQuery ( JQuery.Create ( "'*'", false ).Length ( ) ) );
		}

		private void cmdCopyImage_Click ( object sender, EventArgs e )
		{
			// 从当前的 WebBrowser 控件创建 IEBrowser 对象.
			IEBrowser ie = new IEBrowser ( this.webBrowser );

			// 导航到页面 http://www.google.com.hk/imghp.
			ie.Navigate ( "http://www.google.com.hk/imghp" );

			// 等待 5 秒钟, 以便页面载入完毕.
			ie.IEFlow.Wait ( 5 );

			// 获取 id 为 hplogo 的 img 的图片.
			this.pictureBox.Image = ie.CopyImage ( "'hplogo'" );
		}

		private void cmdDZ_Click ( object sender, EventArgs e )
		{
			Discuz ( new IEBrowser ( this.webBrowser ), "xueyu_zyc", "ads123", "http://nt.discuz.net/", "测试", "你好<br />" );
		}

		public static void Discuz ( IEBrowser ie, string userName, string password, string url, string title, string content )
		{

			// 导航到页面 dz 论坛的页面.
			ie.Navigate ( url );

			// 等待 10 秒钟, 以便页面载入完毕.
			ie.IEFlow.Wait ( 10 );

			// 安装资源中的 jquery 脚本.
			ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );

			// 解除 jquery 的 $ 定义, 但仍然可以只用 jQuery 定义.
			ie.ExecuteJQuery ( JQuery.Create ( false, true ).NoConflict ( ) );

			// 安装 javascript 函数 clickLink, 根据超链接的文本点击超链接.
			ie.InstallScript (
				"function clickLink(text) {" +
				"	links = document.getElementsByTagName('a');" +
				"	for(var index = 0; index < links.length; index++)" +
				"	{" +
				"		if(links[index].innerText == text)" +
				"		{" +
				"			links[index].click();" +
				"			break;" +
				"		}" +
				"	}" +
				"}"
				);

			// 是否存在已经登录后显示的短消息.
			if ( ie.ExecuteJQuery<int> ( JQuery.Create ( "'#pm_ntc'", false ).Length ( ) ) == 1 )
			{
				// 调用 javascript 函数 clickLink, 模拟点击退出链接.
				ie.InvokeScript ( "clickLink", new object[] { "退出" } );

				// 等待 3 秒钟, 以便退出完毕.
				ie.IEFlow.Wait ( 3 );

				// 重新调用自身.
				Discuz ( ie, userName, password, url, title, content );
				return;
			}

			// 设置用户名.
			ie.ExecuteJQuery ( JQuery.Create ( "'#ls_username'", false ).Val ( "'"+userName+"'" ) );

			// 设置密码.
			ie.ExecuteJQuery ( JQuery.Create ( "'#ls_password'", false ).Val ( "'"+password+"'" ) );

			// 密码框获得焦点.
			ie.ExecuteJQuery ( JQuery.Create ( "'#ls_password'", false ).Focus ( ) );

			// 等待 5 秒钟以显示验证码.
			ie.IEFlow.Wait ( 5 );

			// 获取验证码并显示给用户输入.
			FormVCode vCodeWindow = new FormVCode (  );
			vCodeWindow.Image = ie.CopyImage ( "'vcodeimg1'" );

			// 用户是否确认.
			if ( vCodeWindow.ShowDialog ( ) == DialogResult.OK )
			{
				// 验证码框获得焦点.
				ie.ExecuteJQuery ( JQuery.Create ( "'#vcodetext_header1'", false ).Focus ( ) );
				
				// 填写验证码并多加 1.
				ie.ExecuteJQuery ( JQuery.Create ( "'#vcodetext_header1'", false ).Val ( "'" + vCodeWindow.VCode + "1'" ) );

				// 模拟一个退格键, 删除掉 1.
				SendKeys.Send ( "{Backspace}" );

				// 等待 2 秒.
				ie.IEFlow.Wait ( 2 );

				// 登录框提交.
				ie.ExecuteJQuery ( JQuery.Create ( "'#lsform'", false ).Submit() );

				// 等待 5 秒, 以便登录完成.
				ie.IEFlow.Wait ( 5 );

				// 是否是验证码错误.
				if ( ie.ExecuteJQuery<int> ( JQuery.Create ( "'p:contains(验证码错误)'", false ).Length ( ) ) == 1 )
				{
					// 验证码错误重新登录.
					Discuz ( ie, userName, password, url, title, content );
					return;
				}

			TOPIC:
				// 随机导航至某一话题.
				ie.Navigate ( "http://nt.discuz.net/showtopic-" + new Random ( ).Next ( 11000, 18000 ).ToString() + ".html" );

				// 等待 5 秒, 以便页面完成.
				ie.IEFlow.Wait ( 5 );

				// 安装 jquery 脚本的一系列操作.
				ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );
				ie.ExecuteJQuery ( JQuery.Create ( false, true ).NoConflict ( ) );

				// 话题不存在则重新选择.
				if ( ie.ExecuteJQuery<int> ( JQuery.Create ( "'p:contains(该主题不存在)'", false ).Length ( ) ) == 1 )
					goto TOPIC;

				// 切换源码编辑方式.
				ie.InvokeScript ( "clickLink", new object[] { "Code" } );

				// 填写内容.
				ie.ExecuteJQuery ( JQuery.Create ( "'#quickpostmessage'", false ).Val ( "'" + content + "'" ) );

				// 验证码框获得焦点.
				ie.ExecuteJQuery ( JQuery.Create ( "'#vcodetext1'", false ).Focus ( ) );

				// 等待 5 秒钟以显示验证码.
				ie.IEFlow.Wait ( 3 );

				// 获取验证码并显示给用户输入.
				vCodeWindow = new FormVCode ( );
				vCodeWindow.Image = ie.CopyImage ( "'vcodeimg1'" );

				// 用户是否确认.
				if ( vCodeWindow.DialogResult == DialogResult.OK )
				{
					// 填写验证码并多加1.
					ie.ExecuteJQuery ( JQuery.Create ( "'#vcodetext1'", false ).Val ( "'" + vCodeWindow.VCode + "1'" ) );

					// 模拟一个退格键, 删除掉 1.
					SendKeys.Send ( "{Backspace}" );

					// 等待 2 秒.
					ie.IEFlow.Wait ( 3 );

					// 提交.
					ie.ExecuteJQuery ( JQuery.Create ( "'#quickpostsubmit'", false ).Click ( ) );
				}
				else
				{
					Discuz ( ie, userName, password, url, title, content );
					return;
				}

			}
			else
			{
				Discuz ( ie, userName, password, url, title, content );
				return;
			}

		}

		private void cmdRecord_Click ( object sender, EventArgs e )
		{
			// 在某一个控件的事件中, 开始记录 WebBrowser 中的用户操作.
			this.ie.IERecord.BeginRecord ( );

			// 在某一个控件的事件中, 结束记录 WebBrowser 中的用户操作, 并保存用户操作到文件.
			this.ie.IERecord.EndRecord ( );
			this.ie.IERecord.SaveAction ( @"iebrowser.record" );

			// 在某一个控件的事件中, 载入记录 WebBrowser 中的用户操作并回放.
			this.ie.IERecord.LoadAction ( @"iebrowser.record" );
			this.ie.IERecord.EndRecord ( );
		}

	}

}

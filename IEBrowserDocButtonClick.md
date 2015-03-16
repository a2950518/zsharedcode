#summary IEBrowser 按钮点击示例
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocButtonClick'>Translate this page</a></font>

<h3>ButtonClick.htm</h3>
<pre><code>&lt;!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN"&gt;<br>
&lt;html&gt;<br>
&lt;head&gt;<br>
	&lt;title&gt;IEBrowser 控制 WebBrowser 模拟点击按钮&lt;/title&gt;<br>
&lt;/head&gt;<br>
&lt;body&gt;<br>
	&lt;input id="cmdAdd" type="button" value="Add" onclick="alert((1 + 1).toString());" /&gt;<br>
	&lt;input type="button" value="Sub" onclick="alert((10 - 1).toString());" /&gt;<br>
&lt;/body&gt;<br>
&lt;/html&gt;<br>
</code></pre>

<h3>FormIEBrowserButtonClick.cs</h3>
<pre><code>using System;<br>
using System.IO;<br>
using System.Windows.Forms;<br>
<br>
using zoyobar.shared.panzer.web;<br>
using zoyobar.shared.panzer.web.ib;<br>
<br>
namespace zoyobar.shared.panzer.test.web.ib<br>
{<br>
<br>
	public partial class FormIEBrowserButtonClick : Form<br>
	{<br>
<br>
		public FormIEBrowserButtonClick ( )<br>
		{<br>
			InitializeComponent ( );<br>
		}<br>
<br>
		private void cmdAdd_Click ( object sender, EventArgs e )<br>
		{<br>
			// 创建 IEBrowser 对象, 用来控制窗口的 WebBrowser 控件.<br>
			IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
			// 载入已经放在运行目录的页面 ButtonClick.htm.<br>
			ie.Navigate ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory, "ButtonClick.htm" ) );<br>
<br>
			// 等待 ButtonClick.htm 完全载入.<br>
			ie.IEFlow.Wait ( new UrlCondition ( "wait", "ButtonClick.htm", StringCompareMode.EndWith ) );<br>
<br>
			// 模拟具有惟一 id 属性的按钮点击.<br>
<br>
			// 方法1: 执行 javascript 脚本来获取按钮并调用其 click 方法.<br>
			ie.ExecuteScript ( "document.getElementById('cmdAdd').click();" );<br>
<br>
			// 方法2: 安装跟踪和 jQuery 脚本后, 执行 jQuery 来模拟点击按钮.<br>
			// 安装跟踪脚本.<br>
			ie.InstallTrace ( );<br>
			// 安装在资源中的 jQuery 脚本.<br>
			ie.InstallScript ( Properties.Resources.jquery_1_5_2_min );<br>
			// 执行获取按钮并模拟点击的 jQuery 脚本.<br>
			ie.ExecuteJQuery ( JQuery.Create ( "'#cmdAdd'" ).Click ( ) );<br>
		}<br>
<br>
		private void cmdSub_Click ( object sender, EventArgs e )<br>
		{<br>
			// 创建 IEBrowser 对象, 用来控制窗口的 WebBrowser 控件.<br>
			IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
			// 载入已经放在运行目录的页面 ButtonClick.htm.<br>
			ie.Navigate ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory, "ButtonClick.htm" ) );<br>
<br>
			// 等待 ButtonClick.htm 完全载入.<br>
			ie.IEFlow.Wait ( new UrlCondition ( "wait", "ButtonClick.htm", StringCompareMode.EndWith ) );<br>
<br>
			// 根据按钮显示的文本模拟按钮点击.<br>
<br>
			// 方法1: 安装搜索按钮的 javascript 函数 clickButton 来获取按钮并调用其 click 方法.<br>
			// 安装 clickButton 函数.<br>
			ie.InstallScript ( "function clickButton(text){for(var i=0;i&lt;document.all.length;i++){if(document.all[i].value==text){document.all[i].click();break;}}}" );<br>
			// 调用 clickButton 函数, 模拟点击文本为 Sub 的按钮.<br>
			ie.InvokeScript ( "clickButton", new object[] { "Sub" } );<br>
<br>
			// 方法2: 安装跟踪和 jQuery 脚本后, 执行 jQuery 来模拟点击按钮.<br>
			// 安装跟踪脚本.<br>
			ie.InstallTrace ( );<br>
			// 安装在资源中的 jQuery 脚本.<br>
			ie.InstallScript ( Properties.Resources.jquery_1_5_2_min );<br>
			// 执行获取按钮并模拟点击的 jQuery 脚本.<br>
			ie.ExecuteJQuery ( JQuery.Create ( "'[value=Sub]:button'" ).Click ( ) );<br>
		}<br>
<br>
	}<br>
<br>
}<br>
</code></pre>

<h3>说明</h3>
<blockquote>对于拥有 id 属性的按钮, 可以通过 ExecuteScript 方法执行 getElementById 来获取按钮并调用其 click. 也可以在安装 jQuery 后, 使用 jQuery 完成模拟.</blockquote>

<blockquote>对于没有 id 属性的按钮, 则可以通过对比按钮的文本来获取具有指定文本的按钮, 或者使用 jQuery.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>讨论</h3>
<blockquote>版本 2.1, 讨论, 获取 IEBrowser 最新消息, 请加 QQ 群: 91824470 (IEBrowser 编程).<br>
</font>
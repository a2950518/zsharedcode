#summary IEBrowser 与页面进行数据交互
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocDataExchange'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象, WebBrowser 的 Url 属性已经设置为 "about:blank".<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 安装跟踪脚本到 WebBrowser, 从而使 __Get 和 __Set 方法可以使用.<br>
ie.InstallTrace ( );<br>
<br>
int age = 10;<br>
<br>
// 设置姓名和年龄到 WebBrowser, 对于脚本中的字符串可以使用 " 或者 '.<br>
ie.__Set ( "name", "'tom'" );<br>
ie.__Set ( "age", ( age + 1 ).ToString ( ) );<br>
<br>
// 获取 WebBrowser 中的 name 和 age, 并弹出对话框.<br>
MessageBox.Show ( string.Format ( "name={0}, age={1}", ie.__Get&lt;string&gt; ( "name" ), ie.__Get&lt;int&gt; ( "age" ) ) );<br>
</code></pre>

<h3>说明</h3>
<blockquote>通过 <a href='IEBrowser.md'>IEBrowser</a> 的 <code>__Get 和 __Set</code> 方法可以将 .NET 中的数据与页面中数据相互传递, 但需要先调用 InstallTrace 方法.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
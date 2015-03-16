#summary IEBrowser 调用 javascript 函数
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocInvokeJavaScript'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象, WebBrowser 的 Url 属性已经设置为 "about:blank".<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 安装定义函数 setName 和 getName 的函数到 WebBrowser.<br>
ie.InstallScript ( "var name;function setName(name){this.name = name;}function getName(){return this.name;}" );<br>
<br>
// 调用 setName 函数, 参数为 "jack".<br>
ie.InvokeScript ( "setName", new object[] { "jack" } );<br>
<br>
// 调用 getName 函数, 得到结果并弹出对话框.<br>
MessageBox.Show ( ie.InvokeScript ( "getName" ).ToString() );<br>
</code></pre>

<h3>说明</h3>
<blockquote>使用 <a href='IEBrowser.md'>IEBrowser</a> 的 InvokeScript 方法可以调用页面中的 javascript 中定义的函数, 并得到函数的返回值. 函数的参数通过一个 object 类型的数组来传递, 比如: <code>ie.InvokeScript ( "setName", new object[] { "jack" } );</code>.</blockquote>

<blockquote>虽然使用 ExecuteScript 方法也可以完成类似的效果, 但 InvokeScript 在参数传递上更加的简便.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<b>注意:</b> 执行的脚本中的字符串可以用 '' 来表示, 比如: <code>"'我是学生!'"</code>, 也可以使用 "", 比如: <code>"\"我是老师!\""</code>.<br>
<br>
<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
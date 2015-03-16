#summary IEBrowser 执行 javascript 脚本
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocExecuteJavaScript'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象, WebBrowser 的 Url 属性已经设置为 "about:blank".<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 在当前页面上执行 javascript 脚本, 弹出对话框.<br>
ie.ExecuteScript ( "alert('你好, IEBrowser!');" );<br>
<br>
// 可以执行多条 javascript 脚本, 对于脚本中的字符串可以使用 " 或者 '.<br>
ie.ExecuteScript ( "var message = \"我\" + '又来了';alert(message);" );<br>
</code></pre>

<h3>说明</h3>
<blockquote>当 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 中载入了页面之后, 如果希望调用页面中的 js 函数, 或者执行某些 js 语句, 可以使用 ExecuteScript 方法.</blockquote>

<blockquote>使用 <a href='IEBrowser.md'>IEBrowser</a> 的 ExecuteScript 方法即可执行 javascript 脚本, 比如: <code>ie.ExecuteScript ( "alert('你好, IEBrowser!');" );</code>.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<b>注意:</b> 执行的脚本中的字符串可以用 '' 来表示, 比如: <code>"'我是学生!'"</code>, 也可以使用 "", 比如: <code>"\"我是老师!\""</code>.<br>
<br>
<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
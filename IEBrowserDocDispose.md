#summary IEBrowser 释放 WebBrowser 的相关事件
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocDispose'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象, 则将为 webBrowser 添加相应的事件.<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 即使是在 cmdDispose_Click 声明的 ie, 在声明时为 webBrowser 添加的事件不会在 cmdDispose_Click 执行结束后自动删除.<br>
<br>
// 释放 ie 实例为 webBrowser 添加的事件.<br>
ie.Dispose ( );<br>
</code></pre>

<h3>说明</h3>
<blockquote>当每声明一个 <a href='IEBrowser.md'>IEBrowser</a> 对象时, 都会为对应的 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 添加事件, 比如: DocumentCompleted, Navigated. 而在对象不再使用后, 这些添加的事件可能仍然存在. 对于这种情况, 可以调用 <a href='IEBrowser.md'>IEBrowser</a> 的 Dispose 方法, 删除这些添加的事件.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
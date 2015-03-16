#summary IEBrowser 在 WebBrowser 自身打开新页面
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocIsNewWindowEnabled'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象, 默认情况下允许在新窗口中打开链接, WebBrowser 的 Url 属性已经设置为 "about:blank".<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 在页面中添加一个超链接并将 target 设置为在新窗口中打开.<br>
this.webBrowser.Document.Body.InnerHtml = "&lt;a id='linkGoogle' href='http://www.google.com.hk/' target='_blank'&gt;在新窗口中打开 Google&lt;/a&gt;";<br>
<br>
// 设置 IsNewWindowEnabled 为 false, 不允许在新窗口中打开页面.<br>
ie.IsNewWindowEnabled = false;<br>
<br>
// 用鼠标点击链接, 结果将在自身打开页面.<br>
</code></pre>

<h3>说明</h3>
<blockquote>如果页面中的超链接的 target 属性为 <code>_</code>blank, 则点击链接后, 可能会在新的 IE 中打开窗口, 为了在 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 自身打开这个新的页面, 可以将 IsNewWindowEnabled 属性设置为 false, 则在鼠标点击此链接时, 将在 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 打开页面.</blockquote>

<blockquote>也可以在创建 <a href='IEBrowser.md'>IEBrowser</a> 对象时, 传递 isNewWindowEnabled 参数, 和设置 IsNewWindowEnabled 属性是相同的作用, 而默认情况下 isNewWindowEnabled 参数为 true.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
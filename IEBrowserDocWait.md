#summary IEBrowser 等待页面载入
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocWait'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象.<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 导航到页面 http://www.google.com.hk/.<br>
ie.Navigate ( "http://www.google.com.hk/" );<br>
<br>
// 等待页面载入完毕.<br>
ie.IEFlow.Wait ( new UrlCondition ( "wait", "http://www.google.com.hk", StringCompareMode.StartWith ) );<br>
<br>
MessageBox.Show ( "页面已经载入" );<br>
</code></pre>

<h3>说明</h3>
<blockquote>通过使用 <a href='IEBrowser.md'>IEBrowser</a> 的 Wait 方法, 传递一个 <a href='UrlCondition.md'>UrlCondition</a> 作为参数, 当指定页面载入后, 代码将继续执行.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<b>注意:</b> 获取图片时, 可能页面上会弹出对话框.<br>
<br>
<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
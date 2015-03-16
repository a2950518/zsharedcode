#summary IEBrowser 记录回放用户操作
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocRecord'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 在窗口的代码中定义 IEBrowser, 在窗口载入时初始化.<br>
private IEBrowser ie;<br>
this.ie = new IEBrowser ( this.webBrowser );<br>
<br>
...<br>
<br>
// 在某一个控件的事件中, 开始记录 WebBrowser 中的用户操作.<br>
this.ie.IERecord.BeginRecord ( );<br>
<br>
...<br>
<br>
// 在某一个控件的事件中, 结束记录 WebBrowser 中的用户操作, 并保存用户操作到文件.<br>
this.ie.IERecord.EndRecord ( );<br>
this.ie.IERecord.SaveAction ( @"iebrowser.record" );<br>
<br>
...<br>
<br>
// 在某一个控件的事件中, 载入记录 WebBrowser 中的用户操作并回放, 也可以直接回放.<br>
this.ie.IERecord.LoadAction ( @"iebrowser.record" );<br>
this.ie.IERecord.EndRecord ( );<br>
</code></pre>

<h3>说明</h3>
<blockquote>当期望记录用户在 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 上的操作并可以回放这些操作时, 可以通过 <a href='IERecord.md'>IERecord</a> 的相关方法来实现.</blockquote>

<blockquote>实例代码中, 已经列举了一些 <a href='IERecord.md'>IERecord</a> 的主要方法, 由于记录和回放功能目前还是测试阶段, 也尚不确定是否继续完善其功能, 有些站点上可能不能完成记录.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<b>注意<sup>1</sup>:</b> 在记录之前, 请确保 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 已经导航到某个页面.<br>
<br>
<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
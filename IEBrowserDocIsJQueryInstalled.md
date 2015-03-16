#summary IEBrowser 判断是否安装了 jQuery 脚本
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocIsJQueryInstalled'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web;<br>
// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象, WebBrowser 的 Url 属性已经设置为 "about:blank".<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 安装跟踪脚本, 以便检测是否安装了 jQuery 脚本.<br>
ie.InstallTrace ( );<br>
<br>
// 显示是否安装了 jQuery 脚本.<br>
Console.WriteLine ( "是否安装了 jQuery ? {0}", ie.IsJQueryInstalled );<br>
<br>
// 安装 jQuery 脚本.<br>
ie.InstallJQuery ( JQuery.CodeMin );<br>
<br>
// 再次显示是否安装了 jQuery 脚本.<br>
Console.WriteLine ( "是否安装了 jQuery ? {0}", ie.IsJQueryInstalled );<br>
</code></pre>

<h3>说明</h3>
<blockquote>使用 <a href='IEBrowser.md'>IEBrowser</a> 的 IsJQueryInstalled 属性可以判断当前页面是否安装了 jQuery 脚本.</blockquote>

<blockquote>在示例中, 两次使用了 IsJQueryInstalled 属性, 第一次页面没有 jQuery 脚本, 所以返回 false, 而第二次安装了 jQuery 脚本, 因此返回 true.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
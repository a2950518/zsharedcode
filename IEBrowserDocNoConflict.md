#summary IEBrowser 解决 $ 定义冲突
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocNoConflict'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象.<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 导航到页面 http://nt.discuz.net/, 此页面中已经定义了 $, 将和 jquery 的 $ 冲突.<br>
ie.Navigate ( "http://nt.discuz.net/" );<br>
<br>
// 等待页面载入完毕.<br>
ie.IEFlow.Wait ( new UrlCondition ( "wait", "http://nt.discuz.net", StringCompareMode.StartWith ) );<br>
<br>
// 安装资源中的 jquery 脚本.<br>
ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );<br>
<br>
// 解除 jquery 的 $ 定义, 但仍然可以只用 jQuery 定义.<br>
ie.ExecuteJQuery ( JQuery.Create ( false, true ).NoConflict ( ) );<br>
<br>
// 执行 jquery 脚本 jQuery('*').length, 获得页面上总元素个数.<br>
Console.WriteLine ( "页面上共有 {0} 个元素", ie.ExecuteJQuery ( JQuery.Create ( "'*'", false ).Length ( ) ) );<br>
</code></pre>

<h3>说明</h3>
<blockquote>有些页面事先在 javascript 中定义了 $, 如果使用 <a href='IEBrowser.md'>IEBrowser</a> 安装 jquery 脚本, 将导致原来定义的 $ 失效, 为了使页面使用正常, 可以使用 <code>ie.ExecuteJQuery ( JQuery.Create ( false, true ).NoConflict ( ) );</code> 来解除 jquery 的 $ 定义, 恢复原本的 $ 的定义. 这并不代表你不能使用 jquery 了, 在之后的 Create 方法后加上一个 false 作为参数即可, 这指定使用 jQuery 而不是 $.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
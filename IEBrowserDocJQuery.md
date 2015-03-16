#summary IEBrowser 执行 jquery
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocJQuery'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web;<br>
// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
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
// 安装本地的 jquery 脚本.<br>
ie.InstallJQuery ( JQuery.CodeMin );<br>
<br>
// 执行 jquery 脚本 $('*').length, 获得页面上总元素个数.<br>
Console.WriteLine ( "页面上共有 {0} 个元素", ie.ExecuteJQuery ( JQuery.Create ( "'*'" ).Length ( ) ) );<br>
<br>
// 执行 jquery 脚本 $('a'), 获得页面上所有的 a 元素并将结果保存在 __jAs 变量中.<br>
ie.ExecuteJQuery ( JQuery.Create ( "'a'" ), "__jAs" );<br>
<br>
// 得到 __jAs 变量中包含的 a 元素的个数.<br>
int count = ie.ExecuteJQuery&lt;int&gt; ( JQuery.Create ( "__jAs" ).Length ( ) );<br>
<br>
for ( int index = 0; index &lt; count; index++ )<br>
{<br>
	// 得到 __jAs 变量中索引为 index 的 a 元素, 并保存在 __jA 变量中.<br>
	ie.ExecuteJQuery ( JQuery.Create ( "__jAs" ).Eq ( index.ToString ( ) ), "__jA" );<br>
<br>
	// 输出 a 元素的 innerText 和 href 属性.<br>
	Console.WriteLine ( string.Format (<br>
		"a[{0}], '{1}', '{2}'",<br>
		index,<br>
		ie.ExecuteJQuery&lt;string&gt; ( JQuery.Create ( "__jA" ).Text ( ) ),<br>
		ie.ExecuteJQuery&lt;string&gt; ( JQuery.Create ( "__jA" ).Attr ( "'href'" ) )<br>
		)<br>
		);<br>
}<br>
</code></pre>

<h3>说明</h3>
<blockquote>当需要在 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 的页面上执行较为复杂的命令时, 比如: 填写账户信息并登录. 可以通过 <a href='IEBrowser.md'>IEBrowser</a> 来为页面载入 jquery 脚本, 并执行相关的 jquery 命令.</blockquote>

<blockquote>使用 <a href='IEBrowser.md'>IEBrowser</a> 的 ExecuteJQuery 方法可以在页面上执行 jquery 命令, 比如: <code>int count = ie.ExecuteJQuery&lt;int&gt; ( JQuery.Create ( "'a'" ).Length ( ) );</code>, 这行代码将返回页面中 a 标签的个数. 使用 <a href='JQuery.md'>JQuery</a> 类可以创建一条 jquery 命令并提供给 <a href='IEBrowser.md'>IEBrowser</a> 执行.</blockquote>

<blockquote>在执行 ExecuteJQuery 方法前, 需要先执行 InstallJQuery 方法. InstallJQuery 可以从本地或者网络地址载入 jquery 脚本. <a href='IEBrowser.md'>IEBrowser</a> 2.3 之后版本不需要载调用 InstallTrace 方法.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<b>注意<sup>1</sup>:</b> <a href='JQuery.md'>JQuery</a> 本身并不是 jquery 脚本, 但包含于 jquery 相同的方法命名和参数, 关于 jquery 的各种用法可以参考 <a href='http://www.jquery.com/'>http://www.jquery.com/</a>.<br>
<br>
<b>注意<sup>2</sup>:</b> 安装过的 jquery 脚本, 只针对当前 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 中的页面, 当 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 刷新后, 需要重新安装 jquery.<br>
<br>
<b>注意<sup>3</sup>:</b> 采用 Uri 参数安装 jquery 脚本, 可能因为编码的问题导致脚本的错误. 这时, 可以将 jquery 脚本作为项目的资源文件导入, 让后采用带有 string 参数的 InstallScript 方法安装 jquery 脚本.<br>
<br>
<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
#summary IEBrowser 安装 javascript 脚本
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocInstallJavaScript'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象, WebBrowser 的 Url 属性已经设置为 "about:blank".<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 定义 javascript 脚本, 声明一个 showMessage 函数.<br>
string showMessageScript = "function showMessage(message){alert('消息:' + message);}";<br>
// 将脚本安装到 WebBrowser 中.<br>
ie.InstallScript ( showMessageScript );<br>
<br>
// 执行脚本, 调用 showMessage 函数.<br>
ie.ExecuteScript ( "showMessage('哈哈!');" );<br>
<br>
// 定义 javascript 脚本, 声明一个 add 函数.<br>
string addScript = "function add(num1, num2){return num1 + num2;}";<br>
// 将脚本安装到 WebBrowser 中, id 为 jsAdd.<br>
ie.InstallScript ( addScript, "jsAdd" );<br>
<br>
// 执行脚本, 调用 add 函数.<br>
ie.ExecuteScript ( "showMessage(add(1, 3));" );<br>
<br>
// 安装本地 jquery 脚本, 需要生成目录中存在 jquery-1.5.min.js 文件.<br>
ie.InstallScript ( new Uri ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory, @"jquery-1.5.min.js" ) ) );<br>
<br>
// 如果从网络位置载入脚本, 可以等待 5 秒钟, 以便脚本载入完毕.<br>
// ie.IEFlow.Wait ( 5 );<br>
<br>
// 等待脚本载入完毕后, 执行一条 jquery 命令.<br>
ie.ExecuteScript ( "showMessage($('*').length);" );<br>
</code></pre>

<h3>说明</h3>
<blockquote>当需要为 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 增加一段您自己的 javascript 脚本时, 比如: 一个显示日期的函数, 或者 jQuery 这样的函数库, 可以使用 InstallScript 方法.</blockquote>

<blockquote><a href='IEBrowser.md'>IEBrowser</a> 的 InstallScript 方法可以将脚本载入到  <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a>  中, 您可以直接载入脚本, 或者从网络, 本地中载入 js 文件.</blockquote>

<blockquote>对于直接载入的脚本, 比如: <code>ie.InstallScript ( showMessageScript );</code>, 字符串变量 showMessageScript 包含了脚本的内容, InstallScript 方法执行后可以直接调用脚本中定义的函数或者变量, 比如: <code>ie.ExecuteScript ( "showMessage('哈哈!');" );</code>, showMessage 就是刚才定义的 javascript 函数. <b>而对于从网络载入的脚本, 则需要等待脚本载入完成后, 才能调用.</b></blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<b>注意:</b> 安装过的脚本, 只针对当前 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 中的页面, 当 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 刷新后, 需要重新安装这些脚本.<br>
<br>
<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
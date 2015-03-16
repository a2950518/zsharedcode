#summary IEBrowser 登录 163 发布日志
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocS163Blog'>Translate this page</a></font>

<h3>简介</h3>
<b>示例编写者:</b> 雪鱼 (QQ: 422986811)<br>
<br>
<b>功能:</b> 完成 163 博客的登录和日志的发布<br>
<br>
<b>分析:</b> <a href='http://t.qq.com/zoyobar'>M.S.cxc</a>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象.<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 此处修改为您的 163 博客地址.<br>
ie.Navigate ( "http://&lt;163 博客地址&gt;" );<br>
ie.IEFlow.Wait ( 3 );<br>
<br>
// 安装 jquery 脚本.<br>
ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );<br>
<br>
// 弹出登录框.<br>
ie.ExecuteJQuery ( JQuery.Create ( "'a:contains(登录)'" ).Attr ( "'id'", "'denglu'" ) );<br>
ie.ExecuteScript ( "document.getElementById('denglu').click();" );<br>
<br>
// 填写用户信息并登录.<br>
ie.ExecuteJQuery ( JQuery.Create ( "'.ztxt:text'" ).Val ( "'&lt;用户名&gt;'" ) );<br>
ie.ExecuteJQuery ( JQuery.Create ( "'.ztxt:password'" ).Val ( "'&lt;密码&gt;'" ) );<br>
ie.ExecuteJQuery ( JQuery.Create ( "'.wbtnok:button'" ).Attr ( "'id'", "'dl'" ) );<br>
ie.ExecuteScript ( "document.getElementById('dl').click();" );<br>
ie.IEFlow.Wait ( 5 );<br>
<br>
// 安装 jquery 脚本.<br>
ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );<br>
<br>
// 跳转到日志页面.<br>
ie.ExecuteJQuery ( JQuery.Create ( "'a:contains(日志)' " ).Attr ( "'id'", "'rz'" ) );<br>
ie.ExecuteScript ( "document.getElementById('rz').click();" );<br>
ie.IEFlow.Wait ( 5 );<br>
<br>
// 安装 jquery 脚本.<br>
ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );<br>
<br>
// 跳转到编辑日志页面.<br>
ie.ExecuteJQuery ( JQuery.Create ( "'a:contains(写日志)' " ).Attr ( "'id'", "'xrz'" ) );<br>
ie.ExecuteScript ( "document.getElementById('xrz').click();" );<br>
ie.IEFlow.Wait ( 5 );<br>
<br>
// 安装 jquery 脚本.<br>
ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );<br>
<br>
// 填写日志内容.<br>
ie.ExecuteJQuery ( JQuery.Create ( "'.ztag:text'" ).Val ( "'&lt;标题&gt;'" ) );<br>
ie.ExecuteJQuery ( JQuery.Create ( "'#ne-auto-id-source'" ).Trigger ( "'click'" ) );<br>
<br>
ie.ExecuteJQuery ( JQuery.Create ( "'textarea.ztag'" ).Val ( string.Format ( "'{0}'", IEBrowser.EscapeCharacter ( "&lt;日志 html 代码&gt;" ) ) ) );<br>
<br>
ie.ExecuteJQuery ( JQuery.Create ( "'#ne-auto-id-source'" ).Trigger ( "'click'" ) );<br>
<br>
ie.ExecuteScript ( "document.getElementById('key-093402170-autotag').click();" );<br>
ie.IEFlow.Wait ( 5 );<br>
<br>
// 发布日志.<br>
ie.ExecuteJQuery ( JQuery.Create ( "'.fc09:button'" ).Attr ( "'id'", "'fb'" ) );<br>
ie.ExecuteScript ( "document.getElementById('fb').click();" );<br>
</code></pre>

<h3>说明</h3>
<blockquote>首先感谢雪鱼编写的这段示例代码, 可以完成登录 163 博客并发布日志的功能.</blockquote>

<blockquote>代码一开始创建了一个 <a href='IEBrowser.md'>IEBrowser</a> 对象 <code>IEBrowser ie = new IEBrowser ( this.webBrowser );</code>, 这是我们接下来对页面进行各种操作所必须的对象, 其中 webBrowser 是一个 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 控件.</blockquote>

<blockquote>接着, 代码让 <a href='http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.80).aspx'>WebBrowser</a> 导航到某个 163 博客的首页, 您可以填写为自己博客的地址, <code>ie.Navigate ( "http://&lt;163 博客地址&gt;" ); ie.IEFlow.Wait ( 3 );</code>, 在跳转之后使用了 Wait 方法, 主要是等待页面的载入, 否则代码将继续向下执行, 这会导致不期望的结果.</blockquote>

<blockquote>然后, 代码为载入的博客首页安装了 jquery 脚本, 这里 jquery 脚本是导入到了资源当中并作为 jquery_1_5_2_min 属性访问, <code>ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );</code>, 雪鱼是希望在页面上使用 jquery 了, 载入 jquery 的方式有多种. 更多可以参照 <a href='IEBrowserDocJQuery.md'>执行 jquery</a>.</blockquote>

<blockquote>再下来, 代码找到了名字包含日志的 a 标签, 然后模拟了 a 的点击, <code>ie.ExecuteJQuery ( JQuery.Create ( "'a:contains(日志)' " ).Attr ( "'id'", "'rz'" ) ); ie.ExecuteScript ( "document.getElementById('rz').click();" );</code>, 这里需要说明的是 1.5 的 jquery 脚本可能无法使用 trigger 来模拟 a 标签的点击, 所以代码是通过 ExecuteScript 来完成的点击超链接, 而第一句执行的 jquery 是为了给 a 标签增加一个 id 属性, 以提供给下面的 getElementById 使用. 其实你也可以直接 Navigate 导航到指定页面, 这里只是为了演示更多的代码.</blockquote>

<blockquote>还有一点, 在页面每跳转或刷新一次的情况下, 你需要重新安装一次 jquery, 如果你要使用 jquery 的话.</blockquote>

<blockquote>整个代码, 中多处 Wait 方法, 这可以通过 <a href='IEBrowserDocFlow.md'>页面流程控制</a> 这种编程方式来省去, 可以不再使用 Wait, 而是由你给出成功和失败的条件由程序来决定下一步如何进行.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<b>注意<sup>1</sup>:</b> 示例代码可能会因为 163 页面的改动或者使用 jquery 版本的差别而不同.<br>
<br>
<b>注意<sup>2</sup>:</b> 也可以用参数为 <a href='UrlCondition.md'>UrlCondition</a> 的 Wait 方法, 等待页面载入.<br>
<br>
<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
#summary IEBrowser 登录 DZ 发贴
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocSDZ'>Translate this page</a></font>

<h3>简介</h3>
<b>示例编写者:</b> 雪鱼 (QQ: 422986811), <a href='http://t.qq.com/zoyobar'>M.S.cxc</a>

<b>功能:</b> 完成某 DZ 论坛的发帖<br>
<br>
<b>分析:</b> <a href='http://t.qq.com/zoyobar'>M.S.cxc</a>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
public static void Discuz ( IEBrowser ie, string userName, string password, string url, string title, string content )<br>
{<br>
<br>
	// 导航到页面 dz 论坛的页面.<br>
	ie.Navigate ( url );<br>
<br>
	// 等待 10 秒钟, 以便页面载入完毕.<br>
	ie.IEFlow.Wait ( 10 );<br>
<br>
	// 安装资源中的 jquery 脚本.<br>
	ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );<br>
<br>
	// 解除 jquery 的 $ 定义, 但仍然可以只用 jQuery 定义.<br>
	ie.ExecuteJQuery ( JQuery.Create ( false, true ).NoConflict ( ) );<br>
<br>
	// 安装 javascript 函数 clickLink, 根据超链接的文本点击超链接.<br>
	ie.InstallScript (<br>
		"function clickLink(text) {" +<br>
		"	links = document.getElementsByTagName('a');" +<br>
		"	for(var index = 0; index &lt; links.length; index++)" +<br>
		"	{" +<br>
		"		if(links[index].innerText == text)" +<br>
		"		{" +<br>
		"			links[index].click();" +<br>
		"			break;" +<br>
		"		}" +<br>
		"	}" +<br>
		"}"<br>
		);<br>
<br>
	// 是否存在已经登录后显示的短消息.<br>
	if ( ie.ExecuteJQuery&lt;int&gt; ( JQuery.Create ( "'#pm_ntc'", false ).Length ( ) ) == 1 )<br>
	{<br>
		// 调用 javascript 函数 clickLink, 模拟点击退出链接.<br>
		ie.InvokeScript ( "clickLink", new object[] { "退出" } );<br>
<br>
		// 等待 3 秒钟, 以便退出完毕.<br>
		ie.IEFlow.Wait ( 3 );<br>
<br>
		// 重新调用自身.<br>
		Discuz ( ie, userName, password, url, title, content );<br>
		return;<br>
	}<br>
<br>
	// 设置用户名.<br>
	ie.ExecuteJQuery ( JQuery.Create ( "'#ls_username'", false ).Val ( "'"+userName+"'" ) );<br>
<br>
	// 设置密码.<br>
	ie.ExecuteJQuery ( JQuery.Create ( "'#ls_password'", false ).Val ( "'"+password+"'" ) );<br>
<br>
	// 密码框获得焦点.<br>
	ie.ExecuteJQuery ( JQuery.Create ( "'#ls_password'", false ).Focus ( ) );<br>
<br>
	// 等待 5 秒钟以显示验证码.<br>
	ie.IEFlow.Wait ( 5 );<br>
<br>
	// 获取验证码并显示给用户输入.<br>
	FormVCode vCodeWindow = new FormVCode (  );<br>
	vCodeWindow.Image = ie.CopyImage ( "'vcodeimg1'" );<br>
<br>
	// 用户是否确认.<br>
	if ( vCodeWindow.ShowDialog ( ) == DialogResult.OK )<br>
	{<br>
		// 验证码框获得焦点.<br>
		ie.ExecuteJQuery ( JQuery.Create ( "'#vcodetext_header1'", false ).Focus ( ) );<br>
				<br>
		// 填写验证码并多加 1.<br>
		ie.ExecuteJQuery ( JQuery.Create ( "'#vcodetext_header1'", false ).Val ( "'" + vCodeWindow.VCode + "1'" ) );<br>
<br>
		// 模拟一个退格键, 删除掉 1.<br>
		SendKeys.Send ( "{Backspace}" );<br>
<br>
		// 等待 2 秒.<br>
		ie.IEFlow.Wait ( 2 );<br>
<br>
		// 登录框提交.<br>
		ie.ExecuteJQuery ( JQuery.Create ( "'#lsform'", false ).Submit() );<br>
<br>
		// 等待 5 秒, 以便登录完成.<br>
		ie.IEFlow.Wait ( 5 );<br>
<br>
		// 是否是验证码错误.<br>
		if ( ie.ExecuteJQuery&lt;int&gt; ( JQuery.Create ( "'p:contains(验证码错误)'", false ).Length ( ) ) == 1 )<br>
		{<br>
			// 验证码错误重新登录.<br>
			Discuz ( ie, userName, password, url, title, content );<br>
			return;<br>
		}<br>
<br>
	TOPIC:<br>
		// 随机导航至某一话题.<br>
		ie.Navigate ( "http://nt.discuz.net/showtopic-" + new Random ( ).Next ( 11000, 18000 ).ToString() + ".html" );<br>
<br>
		// 等待 5 秒, 以便页面完成.<br>
		ie.IEFlow.Wait ( 5 );<br>
<br>
		// 安装 jquery 脚本的一系列操作.<br>
		ie.InstallJQuery ( Properties.Resources.jquery_1_5_2_min );<br>
		ie.ExecuteJQuery ( JQuery.Create ( false, true ).NoConflict ( ) );<br>
<br>
		// 话题不存在则重新选择.<br>
		if ( ie.ExecuteJQuery&lt;int&gt; ( JQuery.Create ( "'p:contains(该主题不存在)'", false ).Length ( ) ) == 1 )<br>
			goto TOPIC;<br>
			<br>
		// 安装 javascript 函数 clickLink, 根据超链接的文本点击超链接.<br>
		ie.InstallScript (<br>
			"function clickLink(text) {" +<br>
			"	links = document.getElementsByTagName('a');" +<br>
			"	for(var index = 0; index &lt; links.length; index++)" +<br>
			"	{" +<br>
			"		if(links[index].innerText == text)" +<br>
			"		{" +<br>
			"			links[index].click();" +<br>
			"			break;" +<br>
			"		}" +<br>
			"	}" +<br>
			"}"<br>
			);<br>
<br>
		// 切换源码编辑方式.<br>
		ie.InvokeScript ( "clickLink", new object[] { "Code" } );<br>
<br>
		// 填写内容.<br>
		ie.ExecuteJQuery ( JQuery.Create ( "'#quickpostmessage'", false ).Val ( "'" + content + "'" ) );<br>
<br>
		// 验证码框获得焦点.<br>
		ie.ExecuteJQuery ( JQuery.Create ( "'#vcodetext1'", false ).Focus ( ) );<br>
<br>
		// 等待 5 秒钟以显示验证码.<br>
		ie.IEFlow.Wait ( 3 );<br>
<br>
		// 获取验证码并显示给用户输入.<br>
		vCodeWindow = new FormVCode ( );<br>
		vCodeWindow.Image = ie.CopyImage ( "'vcodeimg1'" );<br>
<br>
		// 用户是否确认.<br>
		if ( vCodeWindow.DialogResult == DialogResult.OK )<br>
		{<br>
			// 填写验证码并多加1.<br>
			ie.ExecuteJQuery ( JQuery.Create ( "'#vcodetext1'", false ).Val ( "'" + vCodeWindow.VCode + "1'" ) );<br>
<br>
			// 模拟一个退格键, 删除掉 1.<br>
			SendKeys.Send ( "{Backspace}" );<br>
<br>
			// 等待 2 秒.<br>
			ie.IEFlow.Wait ( 3 );<br>
<br>
			// 提交.<br>
			ie.ExecuteJQuery ( JQuery.Create ( "'#quickpostsubmit'", false ).Click ( ) );<br>
		}<br>
		else<br>
		{<br>
			Discuz ( ie, userName, password, url, title, content );<br>
			return;<br>
		}<br>
<br>
	}<br>
	else<br>
	{<br>
		Discuz ( ie, userName, password, url, title, content );<br>
		return;<br>
	}<br>
<br>
}<br>
</code></pre>

<h3>说明</h3>
<blockquote>首先感谢雪鱼编写的这段示例代码, 可以完成某 DZ 论坛的发帖.</blockquote>

<blockquote>这次我就不再逐一的分析每一行代码的作用了, 上次的 <a href='IEBrowserDocS163Blog.md'>登录 163 发布日志</a> 里我们已经针对某些语句详细的讲过. 所以, 这里讲一些特别的问题.</blockquote>

<blockquote>这次的这个 DZ 论坛中已经定义了 $, 所以我们在安装 jquery 脚本后, 应该立刻解除 jquery 对 $ 的定义, <code>ie.ExecuteJQuery ( JQuery.Create ( false, true ).NoConflict ( ) );</code>, 这样可以保证原页面正常的运行, 详细可以参考 <a href='IEBrowserDocNoConflict.md'>解决 $ 定义冲突</a>.</blockquote>

<blockquote>代码中运用了 InvokeScript 方法, 而并没有使用 <a href='IEBrowserDocS163Blog.md'>登录 163 发布日志</a> 中的为 a 标签增加 id 属性, 然后再调用其 click 方法的作法, 雪鱼在每个 a 标签点击的地方都执行了类似的 javascript 脚本, 我将这些代码改用了 InstallScript 方法安装 clickLink javascript 函数, 以便展示 InvokeScript, <code>ie.InvokeScript ( "clickLink", new object[] { "Code" } );</code>.</blockquote>

<blockquote><code>vCodeWindow.Image = ie.CopyImage ( "'vcodeimg1'" );</code> 用于复制页面中的验证码图片, 其实这个 DZ 论坛即便刷新验证码也不会马上变化, 但我们为了保险, 使用 CopyImage 方法将验证码复制到内存中并转化为 Image 对象, 关于 CopyImage 可以参照 <a href='IEBrowserDocCopyImage.md'>复制并获取图片</a>.</blockquote>

<blockquote>最特别的地方是, 这个 DZ 论坛的验证码输入, 如果直接赋值登录, 将返回验证码错误. 雪鱼最后找到了一种解决方法, 验证码多输入一个 1, 然后使用 <code>SendKeys.Send ( "{Backspace}" );</code> 删除掉多余的 1, 呵呵...</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等. 如果您遇到 BUG 或者功能实现不正常可以联系雪鱼或者 <a href='http://t.qq.com/zoyobar'>M.S.cxc</a></i></blockquote>

<b>注意<sup>1</sup>:</b> 示例代码可能会因为 DZ 页面的改动或者使用 jquery 版本的差别而不同.<br>
<br>
<b>注意<sup>2</sup>:</b> 也可以用参数为 <a href='UrlCondition.md'>UrlCondition</a> 的 Wait 方法, 等待页面载入.<br>
<br>
<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
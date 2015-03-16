#summary IEBrowser 页面载入后跳转
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocFlowNWPC'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 定义载入 google 的页面状态.<br>
WebPageState loadGoogle = new WebPageState (<br>
	"load google", // 状态的名称.<br>
	completedStateSetting: new WebPageNextStateSetting ( "load blog", true ), // 在页面完成时, 自动跳转到载入 blog 的状态.<br>
	startAction: new NavigateAction ( "http://www.google.com.hk" ), // 页面状态的开始动作为载入 http://www.google.com.hk.<br>
	condition: new UrlCondition ( // 判断页面状态是否完成的地址条件.<br>
		"google condition", // 条件名称.<br>
		"http://www.google.com.hk", // 载入的页面以 http://www.google.com.hk 开始时, 认为此地址条件成立.<br>
		StringCompareMode.StartWith<br>
		)<br>
	);<br>
<br>
// 定义载入 blog 的页面状态.<br>
WebPageState loadMyBlog = new WebPageState (<br>
	"load blog", // 状态的名称.<br>
	startAction: new NavigateAction ( "http://blog.sina.com.cn/zoyobar" ), // 页面状态的开始动作为载入 http://blog.sina.com.cn/zoyobar.<br>
	completedAction: new ExecuteJavaScriptAction ( "alert('我是从 google 页面跳转过来的!');" ), // 当页面状态完成后, 执行一条 javascript 脚本.<br>
	condition: new UrlCondition ( // 判断页面状态是否完成的地址条件.<br>
		"blog condition", // 条件名称.<br>
		"http://blog.sina.com.cn/zoyobar", // 载入的页面以 http://blog.sina.com.cn/zoyobar 开始时, 认为此地址条件成立.<br>
		StringCompareMode.StartWith<br>
		)<br>
	);<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象, 并赋予刚才定义的流程.<br>
IEBrowser ie = new IEBrowser ( this.webBrowser, new WebPageState[] { loadGoogle, loadMyBlog } );<br>
<br>
// 从载入 google 页面的状态开始.<br>
ie.IEFlow.JumpToState ( "load google" );<br>
</code></pre>

<h3>说明</h3>
<blockquote>使用 <a href='WPANavigateAction.md'>NavigateAction</a> 可以在流程中执行页面的跳转, 一般这需要使用 <a href='UrlCondition.md'>UrlCondition</a> 来判断页面是否载入成功, <a href='StringCompareMode.md'>StringCompareMode</a> 表示如何判断地址, 可以选择当载入地址包含某个字符串时, 或者以某个字符串开始/结束时, 或者完全相等时.</blockquote>

<blockquote><a href='WPANavigateAction.md'>NavigateAction</a> 一般会作为一个页面状态的开始动作, 来实现跳转.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
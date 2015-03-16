#summary 在母版页中使用 JQueryElement
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JEMasterPage'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /master/Welcome.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/1xYM_Xnk6Ok/'>www.tudou.com/programs/view/1xYM_Xnk6Ok/</a></blockquote>

<blockquote>本文将说明如何在母版页中使用 JQueryElement 控件:</blockquote>

<ul><li>母版页<br>
</li><li>内容页<br>
</li><li>附录: 公共登录框</li></ul>

<img src='http://zsharedcode.googlecode.com/files/master1.jpg' />

<img src='http://zsharedcode.googlecode.com/files/master2.jpg' />

<h3>母版页</h3>
<blockquote>在母版页中使用 JQueryElement 控件和普通页面是相同的, 只需要引用必需的命名空间和 jQueryUI 的脚本和样式即可:<br>
<pre><code>&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.ui.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.ui.jqueryui.plusin"<br>
	TagPrefix="je" %&gt;<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.web.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
<br>
&lt;link type="text/css" rel="stylesheet" href="[样式路径]/jquery-ui-&lt;version&gt;.custom.css" /&gt;<br>
&lt;script type="text/javascript" src="[脚本路径]/jquery-&lt;version&gt;.min.js"&gt;&lt;/script&gt;<br>
&lt;script type="text/javascript" src="[脚本路径]/jquery-ui-&lt;version&gt;.custom.min.js"&gt;&lt;/script&gt;<br>
</code></pre>
也可以使用 ResourceLoader 来添加所需的脚本或样式, 详细请参考 <a href='ResourceLoader.md'>自动添加脚本和样式</a>.</blockquote>

<h3>内容页</h3>
<blockquote>而在内容页中只需要引用命名空间即可, 因为脚本已经由母版页引用.</blockquote>

<h3>附录: 公共登录框</h3>
<blockquote>在这一节中, 将介绍如何使用母版页来制作一个公共登录框, 首先来看下 WebService:<br>
<pre><code>[WebService ( Namespace = "http://tempuri.org/" )]<br>
[WebServiceBinding ( ConformsTo = WsiProfiles.BasicProfile1_1 )]<br>
[ScriptService]<br>
public class master_webservice : System.Web.Services.WebService<br>
{<br>
<br>
	[WebMethod ( true )]<br>
	[ScriptMethod]<br>
	public SortedDictionary&lt;string, object&gt; Check ( )<br>
	{<br>
		this.Context.Response.Cache.SetNoStore ( );<br>
<br>
		return SampleHelper.CreateJSONObject ( new KeyValuePair&lt;string, object&gt;[]<br>
			{<br>
			new KeyValuePair&lt;string, object&gt; ( "ok",<br>
				null != this.Session["master_un"] &amp;&amp;<br>
				this.Session["master_un"].ToString() != string.Empty ),<br>
			new KeyValuePair&lt;string, object&gt; ( "un", this.Session["master_un"] ),<br>
			}<br>
			);<br>
<br>
	}<br>
<br>
	[WebMethod ( true )]<br>
	[ScriptMethod]<br>
	public SortedDictionary&lt;string, object&gt; Login ( string username, string password )<br>
	{<br>
		this.Context.Response.Cache.SetNoStore ( );<br>
<br>
		this.Session["master_un"] = username;<br>
<br>
		return SampleHelper.CreateJSONObject ( new KeyValuePair&lt;string, object&gt;[]<br>
			{<br>
			new KeyValuePair&lt;string, object&gt; ( "ok",<br>
				null != this.Session["master_un"] &amp;&amp;<br>
				this.Session["master_un"].ToString() != string.Empty ),<br>
			new KeyValuePair&lt;string, object&gt; ( "un", username ),<br>
			}<br>
			);<br>
<br>
	}<br>
<br>
	[WebMethod ( true )]<br>
	[ScriptMethod]<br>
	public void Logout ( )<br>
	{<br>
		this.Context.Response.Cache.SetNoStore ( );<br>
<br>
		this.Session["master_un"] = null;<br>
	}<br>
<br>
	[WebMethod ( true )]<br>
	[ScriptMethod]<br>
	public SortedDictionary&lt;string, object&gt; GetContent ()<br>
	{<br>
		this.Context.Response.Cache.SetNoStore ( );<br>
<br>
		string html = string.Format (<br>
			"通过服务器端获取页面内容, " +<br>
			"&lt;span style='font-size: larger'&gt;&lt;strong&gt;isLogin&lt;strong&gt; = {0}, " +<br>
			"&lt;strong&gt;userName&lt;strong&gt; = {1}&lt;/span&gt;",<br>
			null != this.Session["master_un"] &amp;&amp;<br>
			this.Session["master_un"].ToString ( ) != string.Empty,<br>
			this.Session["master_un"] );<br>
<br>
		return SampleHelper.CreateJSONObject ( new KeyValuePair&lt;string, object&gt;[]<br>
			{<br>
			new KeyValuePair&lt;string, object&gt; ( "html", html )<br>
			}<br>
			);<br>
<br>
	}<br>
<br>
}<br>
</code></pre>
在 WebService 中, 定义了 4 个方法, Check 方法用于返回当前的用户状态, Login 和 Logout 方法用于登录和注销, GetContent 方法用于内容页获取页面内容. 对于如何返回 JSON, 请参考 <a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a>.</blockquote>

<blockquote>然后, 在母版页中通过 AjaxManager 来调用这些方法:<br>
<pre><code>&lt;je:AjaxManager ID="ajax" runat="server"&gt;<br>
	&lt;je:AjaxSetting ClientFunction="check" Url="webservice.asmx" MethodName="Check" Success="<br>
	function(data){<br>
		refreshUI(-:data.ok, -:data.un);<br>
	}<br>
	"&gt;<br>
	&lt;/je:AjaxSetting&gt;<br>
	&lt;je:AjaxSetting ClientFunction="login" Url="webservice.asmx" MethodName="Login" Success="<br>
	function(data){<br>
		refreshUI(-:data.ok, -:data.un);<br>
	}<br>
	"&gt;<br>
		&lt;je:Parameter Name="username" Type="Selector" Value="#un" /&gt;<br>
		&lt;je:Parameter Name="password" Type="Selector" Value="#pw" /&gt;<br>
	&lt;/je:AjaxSetting&gt;<br>
	&lt;je:AjaxSetting ClientFunction="logout" Url="webservice.asmx" MethodName="Logout"<br>
		Success="<br>
	function(data){<br>
		refreshUI(false, null);<br>
	}<br>
	"&gt;<br>
	&lt;/je:AjaxSetting&gt;<br>
&lt;/je:AjaxManager&gt;<br>
</code></pre>
上面的 AjaxSetting 使母版页中可以通过 check, login, logout 3 个 javascript 函数来调用服务器端的 Check, Login, Logout 方法. 其中为 Login 方法传递用户输入的用户名和密码, 在每一个方法调用成功后执行 refreshUI 函数. 更多 AjaxManager 的内容, 可以参考 <a href='AjaxManager.md'>生成调用服务器端方法的 javascript 函数</a>.</blockquote>

<blockquote>在页面载入时调用 check 函数获取用户登录信息, 在点击登录按钮和注销链接时, 分别调用 login 和 logout 函数:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	$(function () {<br>
		check();<br>
	});<br>
&lt;/script&gt;<br>
<br>
...<br>
<br>
(任意输入一个用户名即可) 用户名:<br>
&lt;input type="text" id="un" size="10" /&gt;<br>
密码:<br>
&lt;input type="password" id="pw" size="10" /&gt;<br>
&lt;je:Button ID="cmdLogin" runat="server" Label="登录"<br>
	ClickAsync-AjaxManagerID="ajax"<br>
	ClickAsync-ClientFunction="login"&gt;<br>
&lt;/je:Button&gt;<br>
<br>
...<br>
<br>
欢迎, &lt;span class="user-name"&gt;&lt;/span&gt;, &lt;a href="#" onclick="logout()"&gt;退出&lt;/a&gt;!<br>
</code></pre>
再来看下母版页的 refreshUI 函数:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	function refreshUI(isLogin, userName) {<br>
<br>
		if (isLogin) {<br>
			$('.login-panel').hide();<br>
			$('.user-name').text(userName);<br>
			$('.user-panel').show();<br>
		}<br>
		else {<br>
			$('.login-panel').show();<br>
			$('.user-panel').hide();<br>
		}<br>
<br>
		if (typeof (refreshSubUI) != 'undefined')<br>
			refreshSubUI(isLogin, userName);<br>
<br>
	}<br>
&lt;/script&gt;<br>
</code></pre>
在 refreshUI 中, 根据用户是否登录, 来显示或者隐藏登录框. 并且, 如果内容页定义了 refreshSubUI 函数, 还将调用 refreshSubUI.</blockquote>

<blockquote>在内容页中, 可以定义 refreshSubUI 函数, 来设置页面的内容:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	function refreshSubUI(isLogin, userName) {<br>
		$('#sub').html(<br>
			'通过 javascript 修改页面内容, ' +<br>
			'&lt;span style="font-size: larger"&gt;&lt;strong&gt;isLogin&lt;strong&gt; = ' +<br>
			isLogin.toString() +<br>
			', &lt;strong&gt;userName&lt;strong&gt; = ' + userName + '&lt;/span&gt;'<br>
			);<br>
	}<br>
&lt;/script&gt;<br>
</code></pre>
代码中, refreshSubUI 函数显示了参数 isLogin 和 userName 的值.</blockquote>

<blockquote>也可以在内容页中调用服务器端的 GetContent 方法:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	function refreshSubUI(isLogin, userName) {<br>
		getContentFromServer();<br>
	}<br>
&lt;/script&gt;<br>
<br>
&lt;je:AjaxManager ID="ajax" runat="server"&gt;<br>
	&lt;je:AjaxSetting ClientFunction="getContentFromServer"<br>
		Url="webservice.asmx" MethodName="GetContent"<br>
		Success="<br>
	function(data){<br>
		$('#sub').html(-:data.html);<br>
	}<br>
	"&gt;<br>
	&lt;/je:AjaxSetting&gt;<br>
&lt;/je:AjaxManager&gt;<br>
</code></pre>
这里同样是使用了 AjaxManager, 页面的内容来自于服务器返回的 html 代码.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='AjaxManager.md'>生成调用服务器端方法的 javascript 函数</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

<h3>修订历史</h3>
<blockquote>2012-1-26: 增加关于 ResourceLoader 的链接.</blockquote>

</font>
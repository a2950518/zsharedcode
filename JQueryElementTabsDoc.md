#summary JQueryElement 分组标签
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementTabsDoc'>Translate this page</a></font>

<h3>简介</h3>
<blockquote>使用 JQueryElement 的 Tabs 控件即可实现 jQuery UI 中的分组标签.</blockquote>

<h3>前提条件</h3>
<ol><li>请在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 3.0 或更高版本的 dll, 并为项目引用对应 .NET 版本的 dll.</li></ol>

<blockquote>2. 在页面添加如下指令:<br>
<pre><code>&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui" TagPrefix="je" %&gt;<br>
</code></pre></blockquote>

<blockquote>3. JQueryElement 并没有将 jQuery UI 的脚本和样式作为资源嵌入, 所以请将 jQuery UI 所需的脚本和样式复制到项目中并在页面中引用, 比如:<br>
<pre><code>&lt;script type="text/javascript" src="../js/jquery-1.5.1.min.js"&gt;&lt;/script&gt;<br>
&lt;script type="text/javascript" src="../js/jquery-ui-1.8.11.custom.min.js"&gt;&lt;/script&gt;<br>
&lt;link type="text/css" rel="Stylesheet" href="../css/smoothness/jquery-ui-1.8.15.custom.css" /&gt;<br>
</code></pre></blockquote>

<blockquote>4. 添加如下 js 脚本:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	function writeLine(selector, html) {<br>
		$(selector).html($(selector).html() + html + '&lt;br /&gt;');<br>
	}<br>
&lt;/script&gt;<br>
</code></pre></blockquote>

<blockquote>5. 页面包含如下自定义样式, 请参考文章尾部的 main.css.<br>
<pre><code>&lt;link type="text/css" rel="Stylesheet" href="../css/main.css" /&gt;<br>
</code></pre></blockquote>

<h3>添加 ScriptPackage 控件</h3>
<blockquote>添加 ScriptPackage 控件, 用来统一存放控件产生的 js 脚本, 也可以不添加. 需要将控件放到页面代码的尾部, 否则有些 js 脚本可能不会被包含.<br>
<pre><code>&lt;je:ScriptPackage ID="package" runat="server" /&gt;<br>
</code></pre></blockquote>

<h3>通过选择器实现分组标签</h3>
<blockquote>Tabs 可以使页面上其它的元素实现分组标签, 通过 Selector 属性, 将其设置为一个选择器, 比如: <code>'#dA'</code>, 表示选择页面中 id 为 dA 的元素, 注意使用了单引号, 那么 dA 将成为一个分组标签, 其对应的 js 脚本将生成到刚才添加的 ScriptPackage 控件中.<br>
<pre><code>&lt;div id="dA" style="width: 500px;"&gt;<br>
	&lt;ul&gt;<br>
		&lt;li&gt;&lt;a href="#tab11"&gt;欢迎&lt;/a&gt;&lt;/li&gt;<br>
		&lt;li&gt;&lt;a href="#tab13"&gt;联系方式&lt;/a&gt;&lt;/li&gt;<br>
	&lt;/ul&gt;<br>
	&lt;div id="tab11"&gt;<br>
		&lt;strong&gt;welcome&lt;/strong&gt;, 这是 Tabs.<br>
	&lt;/div&gt;<br>
	&lt;div id="tab13"&gt;<br>
		&lt;strong&gt;邮箱:&lt;/strong&gt; ...<br>
	&lt;/div&gt;<br>
&lt;/div&gt;<br>
&lt;je:Tabs ID="tA" runat="server" ScriptPackageID="package" Selector="'#dA'"&gt;<br>
&lt;/je:Tabs&gt;<br>
</code></pre></blockquote>

<h3>效果说明</h3>
<blockquote>通过设置 Tabs 的属性实现的部分效果如下, 具体请参考 tabs.aspx:<br>
</blockquote><ul><li>缓存载入的页面<br>
</li><li>再次点击激活的标签可以折叠<br>
</li><li>在为多个元素设置拖动效果时, 取消其中部分元素的拖动效果<br>
</li><li>设置激活的标签</li></ul>

<h3>事件说明</h3>
<blockquote>Tabs 控件具有如下事件, 具体请参考 tabs.aspx:<br>
</blockquote><ul><li>创建时<br>
</li><li>显示某个标签时</li></ul>

<h3>tabs.aspx</h3>
<pre><code>&lt;%@ Page Language="C#" %&gt;<br>
<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;<br>
&lt;script runat="server"&gt;<br>
<br>
	protected void tF_SelectSync ( object sender, TabsEventArgs e )<br>
	{<br>
		this.ClientScript.RegisterStartupScript ( this.GetType ( ), "tF_SelectSync", "alert('tF_SelectSync');", true );<br>
	}<br>
	<br>
&lt;/script&gt;<br>
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;<br>
&lt;head runat="server"&gt;<br>
	&lt;title&gt;JQuery UI 的 tabs&lt;/title&gt;<br>
	&lt;script type="text/javascript" src="../js/jquery-1.5.1.min.js"&gt;&lt;/script&gt;<br>
	&lt;script type="text/javascript" src="../js/jquery-ui-1.8.11.custom.min.js"&gt;&lt;/script&gt;<br>
	&lt;link type="text/css" rel="Stylesheet" href="../css/smoothness/jquery-ui-1.8.15.custom.css" /&gt;<br>
	&lt;link type="text/css" rel="Stylesheet" href="../css/main.css" /&gt;<br>
	&lt;script type="text/javascript"&gt;<br>
		function writeLine(selector, html) {<br>
			$(selector).html($(selector).html() + html + '&lt;br /&gt;');<br>
		}<br>
	&lt;/script&gt;<br>
&lt;/head&gt;<br>
&lt;body&gt;<br>
	&lt;form id="formTabs" runat="server"&gt;<br>
	&lt;div id="dA" style="width: 500px;"&gt;<br>
		&lt;ul&gt;<br>
			&lt;li&gt;&lt;a href="#tab11"&gt;欢迎&lt;/a&gt;&lt;/li&gt;<br>
			&lt;li&gt;&lt;a href="#tab13"&gt;联系方式&lt;/a&gt;&lt;/li&gt;<br>
		&lt;/ul&gt;<br>
		&lt;div id="tab11"&gt;<br>
			&lt;strong&gt;welcome&lt;/strong&gt;, 这是 Tabs.<br>
		&lt;/div&gt;<br>
		&lt;div id="tab13"&gt;<br>
			&lt;strong&gt;邮箱:&lt;/strong&gt; ...<br>
		&lt;/div&gt;<br>
	&lt;/div&gt;<br>
	&lt;je:Tabs ID="tA" runat="server" ScriptPackageID="package" Selector="'#dA'"&gt;<br>
	&lt;/je:Tabs&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Selector="'#dA'"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;div id="dB" style="width: 500px;"&gt;<br>
		&lt;ul&gt;<br>
			&lt;li&gt;&lt;a href="#tab21"&gt;欢迎&lt;/a&gt;&lt;/li&gt;<br>
			&lt;li&gt;&lt;a href="base.htm"&gt;基本信息&lt;/a&gt;&lt;/li&gt;<br>
			&lt;li&gt;&lt;a href="#tab23"&gt;联系方式&lt;/a&gt;&lt;/li&gt;<br>
		&lt;/ul&gt;<br>
		&lt;div id="tab21"&gt;<br>
			&lt;strong&gt;welcome&lt;/strong&gt;, 这是 Tabs, 缓存 "基本信息" 的 base.htm 页面.<br>
		&lt;/div&gt;<br>
		&lt;div id="tab23"&gt;<br>
			&lt;strong&gt;邮箱:&lt;/strong&gt; ...<br>
		&lt;/div&gt;<br>
	&lt;/div&gt;<br>
	&lt;je:Tabs ID="tB" runat="server" ScriptPackageID="package" Selector="'#dB'" Cache="True"&gt;<br>
	&lt;/je:Tabs&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Cache="True"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;div id="dC" style="width: 500px;"&gt;<br>
		&lt;ul&gt;<br>
			&lt;li&gt;&lt;a href="#tab31"&gt;欢迎&lt;/a&gt;&lt;/li&gt;<br>
			&lt;li&gt;&lt;a href="#tab33"&gt;联系方式&lt;/a&gt;&lt;/li&gt;<br>
		&lt;/ul&gt;<br>
		&lt;div id="tab31"&gt;<br>
			&lt;strong&gt;welcome&lt;/strong&gt;, 这是 Tabs, 允许折叠展开的内容.<br>
		&lt;/div&gt;<br>
		&lt;div id="tab33"&gt;<br>
			&lt;strong&gt;邮箱:&lt;/strong&gt; ...<br>
		&lt;/div&gt;<br>
	&lt;/div&gt;<br>
	&lt;je:Tabs ID="tC" runat="server" ScriptPackageID="package" Selector="'#dC'" Collapsible="True"&gt;<br>
	&lt;/je:Tabs&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Collapsible="True"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;div id="dD" style="width: 500px;"&gt;<br>
		&lt;ul&gt;<br>
			&lt;li&gt;&lt;a href="#tab41"&gt;欢迎&lt;/a&gt;&lt;/li&gt;<br>
			&lt;li&gt;&lt;a href="#tab43"&gt;联系方式&lt;/a&gt;&lt;/li&gt;<br>
		&lt;/ul&gt;<br>
		&lt;div id="tab41"&gt;<br>
			&lt;strong&gt;welcome&lt;/strong&gt;, 这是 Tabs.<br>
		&lt;/div&gt;<br>
		&lt;div id="tab43"&gt;<br>
			&lt;strong&gt;邮箱:&lt;/strong&gt; ..., 默认选中.<br>
		&lt;/div&gt;<br>
	&lt;/div&gt;<br>
	&lt;je:Tabs ID="tD" runat="server" ScriptPackageID="package" Selector="'#dD'" Selected="1"&gt;<br>
	&lt;/je:Tabs&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Selected="1"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;div id="dE" style="width: 500px;"&gt;<br>
		&lt;ul&gt;<br>
			&lt;li&gt;&lt;a href="#tab51"&gt;欢迎&lt;/a&gt;&lt;/li&gt;<br>
			&lt;li&gt;&lt;a href="#tab53"&gt;联系方式&lt;/a&gt;&lt;/li&gt;<br>
		&lt;/ul&gt;<br>
		&lt;div id="tab51"&gt;<br>
			&lt;strong&gt;welcome&lt;/strong&gt;, 这是 Tabs, 事件.<br>
		&lt;/div&gt;<br>
		&lt;div id="tab53"&gt;<br>
			&lt;strong&gt;邮箱:&lt;/strong&gt; ...<br>
		&lt;/div&gt;<br>
	&lt;/div&gt;<br>
	&lt;je:Tabs ID="tE" runat="server" ScriptPackageID="package" Selector="'#dE'" Create="function(){writeLine('#pE', '创建');}"<br>
		Select="function(){writeLine('#pE', '选择');}" Show="function(){writeLine('#pE', '显示');}"&gt;<br>
	&lt;/je:Tabs&gt;<br>
	&lt;p id="pE" class="panel" style="width: 80%;"&gt;<br>
	&lt;/p&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Create="..." Select="..." Show="..."&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;div id="dF" style="width: 500px;"&gt;<br>
		&lt;ul&gt;<br>
			&lt;li&gt;&lt;a href="#tab61"&gt;欢迎&lt;/a&gt;&lt;/li&gt;<br>
			&lt;li&gt;&lt;a href="#tab63"&gt;联系方式&lt;/a&gt;&lt;/li&gt;<br>
		&lt;/ul&gt;<br>
		&lt;div id="tab61"&gt;<br>
			&lt;strong&gt;welcome&lt;/strong&gt;, 这是 Tabs, 服务器端事件.<br>
		&lt;/div&gt;<br>
		&lt;div id="tab63"&gt;<br>
			&lt;strong&gt;邮箱:&lt;/strong&gt; ...<br>
		&lt;/div&gt;<br>
	&lt;/div&gt;<br>
	&lt;je:Tabs ID="tF" runat="server" ScriptPackageID="package" Selector="'#dF'" <br>
		onselectsync="tF_SelectSync"&gt;<br>
	&lt;/je:Tabs&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;onselectsync="tF_SelectSync"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:ScriptPackage ID="package" runat="server" /&gt;<br>
	&lt;/form&gt;<br>
&lt;/body&gt;<br>
&lt;/html&gt;<br>
</code></pre>

<h3>base.htm</h3>
<pre><code>&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;<br>
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;<br>
&lt;head&gt;<br>
	&lt;title&gt;基本信息&lt;/title&gt;<br>
&lt;/head&gt;<br>
&lt;body&gt;<br>
	页面 base.htm 里显示您的基本信息, ...<br>
&lt;/body&gt;<br>
&lt;/html&gt;<br>
</code></pre>

<h3>main.css</h3>
<pre><code>body<br>
{<br>
	font-family: "微软雅黑";<br>
	font-size: 9pt;<br>
}<br>
hr<br>
{<br>
	border: solid 1px #eeeeee;<br>
	margin-bottom: 50px;<br>
}<br>
li<br>
{<br>
	padding: 5px;<br>
}<br>
.panel<br>
{<br>
	border: solid 1px #cccccc;<br>
	padding: 10px;<br>
	background-color: #eeeeee;<br>
}<br>
.box<br>
{<br>
	border: solid 1px #999999;<br>
	padding: 2px 5px 2px 5px;<br>
	color: InfoText;<br>
	background-color: InfoBackground;<br>
}<br>
.code<br>
{<br>
	float: right;<br>
	font-style: italic;<br>
	font-size: x-small;<br>
	color: Blue;<br>
}<br>
.ui-selecting<br>
{<br>
	color: MenuText;<br>
	background-color: InactiveCaption;<br>
}<br>
.ui-selected<br>
{<br>
	color: MenuText;<br>
	background-color: ActiveCaption;<br>
}<br>
</code></pre>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i>
</font>
#summary JQueryElement 选中效果
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementSelectableDoc'>Translate this page</a></font>

<h3>简介</h3>
<blockquote>使用 JQueryElement 的 Selectable 控件即可实现 jQuery UI 中的选中效果, 在最终的用户页面中, 可以使用鼠标在一系列的元素中选中某个元素.</blockquote>

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

<h3>实现一个简单的选中</h3>
<blockquote>在页面中添加如下代码:<br>
<pre><code>&lt;je:Selectable ID="sA" runat="server" Html="&lt;li&gt;可选中 A1&lt;/li&gt;&lt;li&gt;可选中 A2&lt;/li&gt;" ScriptPackageID="package"&gt;<br>
&lt;/je:Selectable&gt;<br>
</code></pre>
这里实现了一个可以选中的元素, 其内部的 html 代码为 <code>&lt;li&gt;可选中 A1&lt;/li&gt;&lt;li&gt;可选中 A2&lt;/li&gt;</code>, 其对应的 js 脚本将生成到刚才添加的 ScriptPackage 控件中.</blockquote>

<h3>通过选择器实现选中</h3>
<blockquote>Selectable 可以使页面上其它的元素实现选中效果, 通过 Selector 属性, 将其设置为一个选择器, 比如: <code>'#uB'</code>, 表示选择页面中 id 为 uB 的元素, 注意使用了单引号, 那么 uB 将具有选中效果.<br>
<pre><code>&lt;ul id="uB"&gt;<br>
	&lt;li&gt;可选中 B1&lt;/li&gt;&lt;li&gt;可选中 B2&lt;/li&gt;&lt;li class="box"&gt;不可选中 B3, 取消了样式为 box 的 li 元素的缩放&lt;/li&gt;<br>
&lt;/ul&gt;<br>
&lt;je:Selectable ID="sB" runat="server" ScriptPackageID="package" Selector="'#uB'" Cancel=".box"&gt;<br>
&lt;/je:Selectable&gt;<br>
</code></pre></blockquote>

<h3>效果说明</h3>
<blockquote>通过设置 Selectable 的属性实现的部分效果如下, 具体请参考 selectable.aspx:<br>
</blockquote><ul><li>在为多个元素设置选中效果时, 取消其中部分元素的选中效果<br>
</li><li>限制鼠标按下一段时间或移动一段距离后产生选中效果</li></ul>

<h3>事件说明</h3>
<blockquote>Selectable 控件具有如下事件, 具体请参考 selectable.aspx:<br>
</blockquote><ul><li>创建时<br>
</li><li>开始选中时<br>
</li><li>取消选择中<br>
</li><li>取消选中时<br>
</li><li>选择中<br>
</li><li>选中时<br>
</li><li>结束选中时</li></ul>

<h3>selectable.aspx</h3>
<pre><code>&lt;%@ Page Language="C#" %&gt;<br>
<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;<br>
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;<br>
&lt;head runat="server"&gt;<br>
	&lt;title&gt;JQuery UI 的选中效果&lt;/title&gt;<br>
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
	&lt;form id="formSelectable" runat="server"&gt;<br>
	&lt;je:Selectable ID="sA" runat="server" Html="&lt;li&gt;可选中 A1&lt;/li&gt;&lt;li&gt;可选中 A2&lt;/li&gt;" ScriptPackageID="package"&gt;<br>
	&lt;/je:Selectable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;-&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;ul id="uB"&gt;<br>
		&lt;li&gt;可选中 B1&lt;/li&gt;&lt;li&gt;可选中 B2&lt;/li&gt;&lt;li class="box"&gt;不可选中 B3, 取消了样式为 box 的 li 元素的缩放&lt;/li&gt;<br>
	&lt;/ul&gt;<br>
	&lt;je:Selectable ID="sB" runat="server" ScriptPackageID="package" Selector="'#uB'"<br>
		Cancel=".box"&gt;<br>
	&lt;/je:Selectable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Selector="'#uB'" Cancel=".box"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Selectable ID="sC" runat="server" Html="&lt;li&gt;可选中 C1, 鼠标按下 0.5 秒后选中&lt;/li&gt;&lt;li&gt;可选中 C2, 鼠标按下 0.5 秒后选中&lt;/li&gt;"<br>
		ScriptPackageID="package" Delay="500"&gt;<br>
	&lt;/je:Selectable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Delay="500"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Selectable ID="sD" runat="server" Html="&lt;li&gt;可选中 D1, 鼠标按下并移动 50px 后产生缩放&lt;/li&gt;&lt;li&gt;可选中 D2, 鼠标按下并移动 50px 后产生缩放&lt;/li&gt;"<br>
		ScriptPackageID="package" Distance="50"&gt;<br>
	&lt;/je:Selectable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Distance="50"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Selectable ID="sE" runat="server" Html="&lt;li class='box'&gt;可选中 E1&lt;/li&gt;&lt;li&gt;不可选中 E2, 样式不会 box 的元素被排除&lt;/li&gt;"<br>
		ScriptPackageID="package" Filter=".box"&gt;<br>
	&lt;/je:Selectable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Filter=".box"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Selectable ID="sF" runat="server" Html="&lt;li&gt;可选中 F1&lt;/li&gt;&lt;li&gt;可选中 F2&lt;/li&gt;" ScriptPackageID="package"<br>
		Create="function(){writeLine('#pF', '创建');}" Selected="function(){writeLine('#pF', '选中');}"<br>
		Selecting="function(){writeLine('#pF', '选择中');}" Unselected="function(){writeLine('#pF', '取消选中');}"<br>
		Unselecting="function(){writeLine('#pF', '取消选择中');}" Start="function(){writeLine('#pF', '开始');}"<br>
		Stop="function(){writeLine('#pF', '结束');}"&gt;<br>
	&lt;/je:Selectable&gt;<br>
	&lt;p id="pF" class="panel" style="width: 80%;"&gt;<br>
	&lt;/p&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Create="..." Selected="..." Selecting="..." Unselected="..." Unselecting="..."<br>
		Start="..." Stop="..."&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:ScriptPackage ID="package" runat="server" /&gt;<br>
	&lt;/form&gt;<br>
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
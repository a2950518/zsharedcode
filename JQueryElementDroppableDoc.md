#summary JQueryElement 拖放效果
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementDroppableDoc'>Translate this page</a></font>

<h3>简介</h3>
<blockquote>使用 JQueryElement 的 Droppable 控件即可实现 jQuery UI 中的拖放效果, 在最终的用户页面中, 可以使用鼠标拖动某些元素到可拖放元素中.</blockquote>

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

<h3>实现一个简单的拖放</h3>
<blockquote>在页面中添加如下代码:<br>
<pre><code>&lt;je:Droppable ID="dA" runat="server" CssClass="panel" Html="&lt;strong&gt;可拖放 A, 将弹出对话框&lt;/strong&gt;" ScriptPackageID="package" Drop="function(){alert('释放');}"&gt;<br>
&lt;/je:Droppable&gt;<br>
&lt;je:Draggable ID="gA" runat="server" CssClass="box" Html="请拖动到 可拖放 A" ScriptPackageID="package"&gt;<br>
&lt;/je:Draggable&gt;<br>
</code></pre>
这里实现了一个可以拖放的元素, 其内部的 html 代码为 <code>&lt;strong&gt;可拖放 A, 将弹出对话框&lt;/strong&gt;</code>, 以及一个拖动元素, 其对应的 js 脚本将生成到刚才添加的 ScriptPackage 控件中.</blockquote>

<h3>通过选择器实现拖放</h3>
<blockquote>Droppable 可以使页面上其它的元素实现拖放效果, 通过 Selector 属性, 将其设置为一个选择器, 比如: <code>'#spanB'</code>, 表示选择页面中 id 为 spanB 的元素, 注意使用了单引号, 那么 spanB 将具有可拖放效果.<br>
<pre><code>&lt;span id="spanB" class="panel"&gt;可拖放 B, 只接受 span 元素&lt;/span&gt;<br>
&lt;je:Draggable ID="gB1" runat="server" CssClass="box" ElementType="Label" Text="请拖动 label 到 可拖放 B" ScriptPackageID="package"&gt;<br>
&lt;/je:Draggable&gt;<br>
&lt;je:Draggable ID="gB2" runat="server" CssClass="box" ElementType="Span" Text="请拖动 span 到 可拖放 B" ScriptPackageID="package"&gt;<br>
&lt;/je:Draggable&gt;<br>
&lt;je:Droppable ID="dB" runat="server" ScriptPackageID="package" Drop="function(){alert('释放');}" Selector="'#spanB'" Accept="span"&gt;<br>
&lt;/je:Droppable&gt;<br>
</code></pre></blockquote>

<h3>效果说明</h3>
<blockquote>通过设置 Droppable 的属性实现的部分效果如下, 具体请参考 droppable.aspx:<br>
</blockquote><ul><li>符合特定选择器的拖动元素才能拖放<br>
</li><li>具有相同 Scope 属性的拖动和<br>
</li><li>设置拖放元素和拖动元素如何接触会触发拖放</li></ul>

<h3>事件说明</h3>
<blockquote>Droppable 控件具有如下事件, 具体请参考 draggable.aspx:<br>
</blockquote><ul><li>创建时<br>
</li><li>拖放激活时<br>
</li><li>拖放完成时<br>
</li><li>拖动取消激活时<br>
</li><li>拖动元素离开可拖放元素时<br>
</li><li>拖动元素在可拖放元素悬停时</li></ul>

<h3>droppable.aspx</h3>
<pre><code>&lt;%@ Page Language="C#" %&gt;<br>
<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;<br>
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;<br>
&lt;head runat="server"&gt;<br>
	&lt;title&gt;JQuery UI 的拖放效果&lt;/title&gt;<br>
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
	&lt;form id="formDroppable" runat="server"&gt;<br>
	&lt;br /&gt;<br>
	&lt;je:Droppable ID="dA" runat="server" CssClass="panel" Html="&lt;strong&gt;可拖放 A, 将弹出对话框&lt;/strong&gt;"<br>
		ScriptPackageID="package" Drop="function(){alert('释放');}"&gt;<br>
	&lt;/je:Droppable&gt;<br>
	&lt;je:Draggable ID="gA" runat="server" CssClass="box" Html="请拖动到 可拖放 A" ScriptPackageID="package"&gt;<br>
	&lt;/je:Draggable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;-&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;span id="spanB" class="panel"&gt;可拖放 B, 只接受 span 元素&lt;/span&gt;<br>
	&lt;je:Draggable ID="gB1" runat="server" CssClass="box" ElementType="Label" Text="请拖动 label 到 可拖放 B"<br>
		ScriptPackageID="package"&gt;<br>
	&lt;/je:Draggable&gt;<br>
	&lt;je:Draggable ID="gB2" runat="server" CssClass="box" ElementType="Span" Text="请拖动 span 到 可拖放 B"<br>
		ScriptPackageID="package"&gt;<br>
	&lt;/je:Draggable&gt;<br>
	&lt;je:Droppable ID="dB" runat="server" ScriptPackageID="package" Drop="function(){alert('释放');}"<br>
		Selector="'#spanB'" Accept="span"&gt;<br>
	&lt;/je:Droppable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Accept="span"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Droppable ID="dC" runat="server" CssClass="panel" Text="可拖放 C, 只接受年龄" ScriptPackageID="package"<br>
		Drop="function(){alert('释放');}" Scope="age"&gt;<br>
	&lt;/je:Droppable&gt;<br>
	&lt;je:Draggable ID="gC1" runat="server" CssClass="box" Text="请拖动 年龄 10 到 可拖放 C" ScriptPackageID="package"<br>
		Scope="age"&gt;<br>
	&lt;/je:Draggable&gt;<br>
	&lt;je:Draggable ID="gC2" runat="server" CssClass="box" Text="请拖动 姓名 小明 到 可拖放 C" ScriptPackageID="package"<br>
		Scope="name"&gt;<br>
	&lt;/je:Draggable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Scope="age"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Droppable ID="dD" runat="server" CssClass="panel" Text="可拖放 D, 接触即认为可拖放" ScriptPackageID="package"<br>
		Drop="function(){alert('释放');}" Tolerance="touch"&gt;<br>
	&lt;/je:Droppable&gt;<br>
	&lt;je:Draggable ID="gD" runat="server" CssClass="box" Text="请拖动到 可拖放 D" ScriptPackageID="package"&gt;<br>
	&lt;/je:Draggable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Tolerance="touch"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Droppable ID="dE" runat="server" CssClass="panel" Text="可拖放 E, 事件" ScriptPackageID="package"<br>
		Drop="function(){writeLine('#pE', '释放');}" Activate="function(){writeLine('#pE', '激活');}"<br>
		Deactivate="function(){writeLine('#pE', '取消激活');}" Create="function(){writeLine('#pE', '创建');}"<br>
		Out="function(){writeLine('#pE', '移出');}" Over="function(){writeLine('#pE', '悬停');}"&gt;<br>
	&lt;/je:Droppable&gt;<br>
	&lt;je:Draggable ID="gE" runat="server" CssClass="box" Text="请拖动到 可拖放 E" ScriptPackageID="package"&gt;<br>
	&lt;/je:Draggable&gt;<br>
	&lt;p id="pE" class="panel" style="width: 80%;"&gt;<br>
	&lt;/p&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Drop="..." Activate="..." Deactivate="..." Create="..." Out="..."<br>
		Over="..."&lt;/span&gt;<br>
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
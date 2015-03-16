#summary JQueryElement 对话框
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementDialogDoc'>Translate this page</a></font>

<h3>简介</h3>
<blockquote>使用 JQueryElement 的 Dialog 控件即可实现 jQuery UI 中的对话框.</blockquote>

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

<h3>实现一个简单的对话框</h3>
<blockquote>在页面中添加如下代码:<br>
<pre><code>&lt;je:Dialog ID="dA" runat="server" ScriptPackageID="package" Title="对话框 A" Html="&lt;strong&gt;内容 A&lt;/strong&gt;" /&gt;<br>
</code></pre>
这里实现了一个对话框, 其对应的 js 脚本将生成到刚才添加的 ScriptPackage 控件中.</blockquote>

<h3>通过选择器实现对话框</h3>
<blockquote>Dialog 可以使页面上其它的元素实现对话框, 通过 Selector 属性, 将其设置为一个选择器, 比如: <code>'#divB'</code>, 表示选择页面中 id 为 divB 的元素, 注意使用了单引号, 那么 divB 将成为对话框.<br>
<pre><code>&lt;div id="divB"&gt;<br>
	内容 B, 按下 Esc 不关闭<br>
&lt;/div&gt;<br>
&lt;je:Dialog ID="dB" runat="server" ScriptPackageID="package" Selector="'#divB'" Title="对话框 B" CloseOnEscape="False" /&gt;<br>
</code></pre></blockquote>

<h3>效果说明</h3>
<blockquote>通过设置 Dialog 的属性实现的部分效果如下, 具体请参考 dialog.aspx:<br>
</blockquote><ul><li>按下 Esc 不关闭对话框<br>
</li><li>设置对话框最大最小尺寸<br>
</li><li>设置对话框显示位置<br>
</li><li>使对话框不可以缩放和拖动<br>
</li><li>为对话框添加按钮</li></ul>

<h3>事件说明</h3>
<blockquote>Dialog 控件具有如下事件, 具体请参考 dialog.aspx:<br>
</blockquote><ul><li>创建时<br>
</li><li>关闭之前<br>
</li><li>关闭时<br>
</li><li>开始拖动时<br>
</li><li>拖动时<br>
</li><li>结束拖动时<br>
</li><li>开始缩放时<br>
</li><li>缩放时<br>
</li><li>结束缩放时<br>
</li><li>打开时<br>
</li><li>获得焦点时<br>
</li><li>关闭时</li></ul>

<h3>dialog.aspx</h3>
<pre><code>&lt;%@ Page Language="C#" %&gt;<br>
<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;<br>
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;<br>
&lt;head runat="server"&gt;<br>
	&lt;title&gt;JQuery UI 的 dialog&lt;/title&gt;<br>
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
	&lt;form id="formDialog" runat="server"&gt;<br>
	&lt;je:Dialog ID="dA" runat="server" ScriptPackageID="package" Title="对话框 A" Html="&lt;strong&gt;内容 A&lt;/strong&gt;" /&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Title="对话框 A"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;div id="divB"&gt;<br>
		内容 B, 按下 Esc 不关闭<br>
	&lt;/div&gt;<br>
	&lt;je:Dialog ID="dB" runat="server" ScriptPackageID="package" Selector="'#divB'" Title="对话框 B"<br>
		CloseOnEscape="False" /&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;CloseOnEscape="False"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Dialog ID="dC" runat="server" ScriptPackageID="package" Title="对话框 C" Text="内容 C, 最大尺寸 300*300, 最小尺寸 100*100"<br>
		MaxHeight="300" MaxWidth="300" MinHeight="100" MinWidth="100" /&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;MaxHeight="300" MaxWidth="300" MinHeight="100" MinWidth="100"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Dialog ID="dD" runat="server" ScriptPackageID="package" Title="对话框 D" Text="内容 D, 右下角显示"<br>
		Position="['right', 'bottom']" /&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Position="['right', 'bottom']"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Dialog ID="dE" runat="server" ScriptPackageID="package" Title="对话框 E" Text="内容 E, 不可缩放和拖动"<br>
		Draggable="False" Resizable="False" /&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Draggable="False" Resizable="False"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Dialog ID="dF" runat="server" ScriptPackageID="package" Title="对话框 F" Text="内容 F, 按钮是"<br>
		IsVariable="true" Buttons="{ '是': function(){[%id:dF%].dialog('close');} }" /&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;IsVariable="true" Buttons="{ '是': function(){[%id:dF%].dialog('close');}<br>
		}"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Dialog ID="dG" runat="server" ScriptPackageID="package" Title="对话框 G" Text="内容 G, 事件"<br>
		BeforeClose="function(){writeLine('#pG', '关闭之前');}" Close="function(){writeLine('#pG', '关闭');}"<br>
		Create="function(){writeLine('#pG', '创建');}" Drag="function(){writeLine('#pG', '拖动中');}"<br>
		DragStart="function(){writeLine('#pG', '开始拖动');}" DragStop="function(){writeLine('#pG', '结束拖动');}"<br>
		Focus="function(){writeLine('#pG', '获得焦点');}" Open="function(){writeLine('#pG', '打开');}"<br>
		Resize="function(){writeLine('#pG', '缩放中');}" ResizeStart="function(){writeLine('#pG', '开始缩放');}"<br>
		ResizeStop="function(){writeLine('#pG', '结束缩放');}" /&gt;<br>
	&lt;p id="pG" class="panel" style="width: 80%;"&gt;<br>
	&lt;/p&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;BeforeClose="..." Close="..." Create="..." Drag="..." DragStart="..."<br>
		DragStop="..." Focus="..." Open="..." Resize="..." ResizeStart="..." ResizeStop="..."&lt;/span&gt;<br>
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
#summary JQueryElement 排列效果
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementSortableDoc'>Translate this page</a></font>

<h3>简介</h3>
<blockquote>使用 JQueryElement 的 Sortable 控件即可实现 jQuery UI 中的选中效果, 在最终的用户页面中, 可以使用鼠标对一系列的元素排列位置.</blockquote>

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

<h3>实现一个简单的排列</h3>
<blockquote>在页面中添加如下代码:<br>
<pre><code>&lt;je:Sortable ID="sA" runat="server" Html="&lt;li&gt;可换位 A1&lt;/li&gt;&lt;li&gt;可换位 A2&lt;/li&gt;" ScriptPackageID="package"&gt;<br>
&lt;/je:Sortable&gt;<br>
</code></pre>
这里实现了一个可以排列的元素, 其内部的 html 代码为 <code>&lt;li&gt;可换位 A1&lt;/li&gt;&lt;li&gt;可换位 A2&lt;/li&gt;</code>, 其对应的 js 脚本将生成到刚才添加的 ScriptPackage 控件中.</blockquote>

<h3>通过选择器实现排列</h3>
<blockquote>Sortable 可以使页面上其它的元素实现排列效果, 通过 Selector 属性, 将其设置为一个选择器, 比如: <code>'#uB'</code>, 表示选择页面中 id 为 uB 的元素, 注意使用了单引号, 那么 uB 将具有排列效果.<br>
<pre><code>&lt;ul id="uB"&gt;<br>
	&lt;li&gt;可换位 B1, 沿 y 轴方向&lt;/li&gt;&lt;li&gt;可换位 B2, 沿 y 轴方向&lt;/li&gt;<br>
&lt;/ul&gt;<br>
&lt;je:Sortable ID="sB" runat="server" ScriptPackageID="package" Selector="'#uB'" Axis="y"&gt;<br>
&lt;/je:Sortable&gt;<br>
</code></pre></blockquote>

<h3>效果说明</h3>
<blockquote>通过设置 Sortable 的属性实现的部分效果如下, 具体请参考 sortable.aspx:<br>
</blockquote><ul><li>限制沿 x/y 轴方向拖动<br>
</li><li>在为多个元素设置排列效果时, 取消其中部分元素的排列效果<br>
</li><li>和另一个排列元素关联, 使内部元素可以拖放到关联的排列元素中<br>
</li><li>内部元素的拖动范围限制在某个容器中<br>
</li><li>内部元素拖动时显示特定的鼠标样式<br>
</li><li>内部元素拖动时鼠标的位置<br>
</li><li>限制鼠标按下一段时间或移动一段距离后产生排列效果<br>
</li><li>内部元素不能被拖放到空的排列元素中<br>
</li><li>内部元素拖动时按照点阵移动<br>
</li><li>内部元素拖动具有拖影<br>
</li><li>内部元素拖动具有透明度</li></ul>

<h3>事件说明</h3>
<blockquote>Sortable 控件具有如下事件, 具体请参考 sortable.aspx:<br>
</blockquote><ul><li>创建时<br>
</li><li>开始排列时<br>
</li><li>激活时<br>
</li><li>取消激活时<br>
</li><li>排列时<br>
</li><li>内部元素被移除时<br>
</li><li>接收内部元素时<br>
</li><li>改变内部元素时<br>
</li><li>更新内部元素时<br>
</li><li>内部元素移出时<br>
</li><li>内部元素悬停时<br>
</li><li>排列停止前时<br>
</li><li>结束排列时</li></ul>

<h3>sortable.aspx</h3>
<pre><code>&lt;%@ Page Language="C#" %&gt;<br>
<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;<br>
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;<br>
&lt;head runat="server"&gt;<br>
	&lt;title&gt;JQuery UI 的排列效果&lt;/title&gt;<br>
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
	&lt;form id="formSortable" runat="server"&gt;<br>
	&lt;je:Sortable ID="sA" runat="server" Html="&lt;li&gt;可换位 A1&lt;/li&gt;&lt;li&gt;可换位 A2&lt;/li&gt;" ScriptPackageID="package"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;-&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;ul id="uB"&gt;<br>
		&lt;li&gt;可换位 B1, 沿 y 轴方向&lt;/li&gt;&lt;li&gt;可换位 B2, 沿 y 轴方向&lt;/li&gt;<br>
	&lt;/ul&gt;<br>
	&lt;je:Sortable ID="sB" runat="server" ScriptPackageID="package" Selector="'#uB'" Axis="y"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Selector="'#uB'" Axis="y"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sC" runat="server" Html="&lt;li&gt;可换位 C1&lt;/li&gt;&lt;li&gt;可换位 C2&lt;/li&gt;&lt;li class='box'&gt;不可被拖动换位 C3, 取消了样式为 box 的 li 元素的拖动&lt;/li&gt;"<br>
		ScriptPackageID="package" Cancel=".box"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Cancel=".box"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sD1" runat="server" Html="&lt;li&gt;可换位 D11, 可拖放到下面的列表中&lt;/li&gt;&lt;li&gt;可换位 D12, 可拖放到下面的列表中&lt;/li&gt;"<br>
		ScriptPackageID="package" ConnectWith="#[%id:sD2%]"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;je:Sortable ID="sD2" runat="server" CssClass="panel" Html="&lt;li&gt;可换位 D21&lt;/li&gt;&lt;li&gt;可换位 D22&lt;/li&gt;"<br>
		ScriptPackageID="package"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;ConnectWith="#[%id:sD2%]"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;div class="panel" style="width: 80%; height: 50px;"&gt;<br>
		&lt;je:Sortable ID="sE" runat="server" Html="&lt;li&gt;可换位 E1, 在 div 元素范围内&lt;/li&gt;&lt;li&gt;可换位 E2, 在 div 元素范围内&lt;/li&gt;"<br>
			ScriptPackageID="package" Containment="parent"&gt;<br>
		&lt;/je:Sortable&gt;<br>
	&lt;/div&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Containment="parent"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sF" runat="server" Html="&lt;li&gt;可换位 F1, 拖动显示十字鼠标&lt;/li&gt;&lt;li&gt;可换位 F2, 拖动显示十字鼠标&lt;/li&gt;"<br>
		ScriptPackageID="package" Cursor="crosshair"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Cursor="crosshair"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sG" runat="server" Html="&lt;li&gt;可换位 G1, 拖动时鼠标位于左上角偏移 5px, 50px&lt;/li&gt;&lt;li&gt;可换位 G2, 拖动时鼠标位于左上角偏移 5px, 50px&lt;/li&gt;"<br>
		ScriptPackageID="package" CursorAt="{top: 5, left: 50}"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;CursorAt="{top: 5, left: 50}"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sH" runat="server" Html="&lt;li&gt;可换位 H1, 鼠标按下 0.5 秒后产生拖动&lt;/li&gt;&lt;li&gt;可换位 H2, 鼠标按下 0.5 秒后产生拖动&lt;/li&gt;"<br>
		ScriptPackageID="package" Delay="500"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Delay="500"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sI" runat="server" Html="&lt;li&gt;可换位 I1, 鼠标按下并移动 50px 后产生拖动&lt;/li&gt;&lt;li&gt;可换位 I2, 鼠标按下并移动 50px 后产生拖动&lt;/li&gt;"<br>
		ScriptPackageID="package" Distance="50"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Distance="50"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sJ1" runat="server" Html="&lt;li&gt;可换位 J1, 不能拖放到空列表中&lt;/li&gt;&lt;li&gt;可换位 J2, 不能拖放到空列表中&lt;/li&gt;"<br>
		ScriptPackageID="package" ConnectWith="#[%id:sJ2%]" DropOnEmpty="False"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;je:Sortable ID="sJ2" runat="server" CssClass="panel" Html="空的列表" ScriptPackageID="package"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;ConnectWith="#[%id:sJ2%]" DropOnEmpty="False"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sK" runat="server" Html="&lt;li&gt;可换位 K1, 按照 10*10 的点阵移动&lt;/li&gt;&lt;li&gt;可换位 K2, 按照 10*10 的点阵移动&lt;/li&gt;"<br>
		ScriptPackageID="package" Grid="[10, 10]"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Grid="[10, 10]"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sL" runat="server" Html="&lt;li&gt;可换位 L1, 有拖影和 50% 的透明度, 并播放换位动画&lt;/li&gt;&lt;li&gt;可换位 L2, 有拖影和 50% 的透明度, 并换位动画&lt;/li&gt;"<br>
		ScriptPackageID="package" Helper="clone" Opacity="0.5" Revert="True"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Helper="clone" Opacity="0.5" Revert="True"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Sortable ID="sM" runat="server" Html="&lt;li&gt;可换位 M1, 事件&lt;/li&gt;&lt;li&gt;可换位 M2, 事件&lt;/li&gt;"<br>
		ScriptPackageID="package" Create="function(){writeLine('#pM', '创建');}" Activate="function(){writeLine('#pM', '创建');}"<br>
		BeforeStop="function(){writeLine('#pM', '换位停止前');}" Change="function(){writeLine('#pM', '改变');}"<br>
		Deactivate="function(){writeLine('#pM', '取消激活');}" Out="function(){writeLine('#pM', '移出');}"<br>
		Over="function(){writeLine('#pM', '悬停');}" Receive="function(){writeLine('#pM', '接收');}"<br>
		Remove="function(){writeLine('#pM', '移除');}" Sort="function(){writeLine('#pM', '排列');}"<br>
		Start="function(){writeLine('#pM', '换位开始');}" Stop="function(){writeLine('#pM', '换位停止');}"<br>
		Update="function(){writeLine('#pM', '更新');}"&gt;<br>
	&lt;/je:Sortable&gt;<br>
	&lt;p id="pM" class="panel" style="width: 80%;"&gt;<br>
	&lt;/p&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;Create="..." Activate="..." BeforeStop="..." Change="..." Deactivate="..."<br>
		Out="..." Over="..." Receive="..." Remove="..." Sort="..." Start="..." Stop="..."<br>
		Update="..."&lt;/span&gt;<br>
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
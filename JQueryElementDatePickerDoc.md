#summary JQueryElement 日期框
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementDatePickerDoc'>Translate this page</a></font>

<h3>简介</h3>
<blockquote>使用 JQueryElement 的 DatePicker 控件即可实现 jQuery UI 中的日期框.</blockquote>

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

<h3>实现一个简单的日期框</h3>
<blockquote>在页面中添加如下代码:<br>
<pre><code>&lt;je:Datepicker ID="dA" runat="server" ScriptPackageID="package" /&gt;<br>
</code></pre>
这里实现了一个日期框, 其对应的 js 脚本将生成到刚才添加的 ScriptPackage 控件中.</blockquote>

<h3>效果说明</h3>
<blockquote>通过设置 DatePicker 的属性实现的部分效果如下, 具体请参考 datepicker.aspx:<br>
</blockquote><ul><li>设置日期格式<br>
</li><li>设置选择的日期范围<br>
</li><li>可以直接选择年份或月份<br>
</li><li>可显示并选择其它月份</li></ul>

<h3>事件说明</h3>
<blockquote>DatePicker 控件具有如下事件, 具体请参考 datepicker.aspx:<br>
</blockquote><ul><li>改变年份月份时<br>
</li><li>选择时<br>
</li><li>关闭时</li></ul>

<h3>datepicker.aspx</h3>
<pre><code>&lt;%@ Page Language="C#" %&gt;<br>
<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;<br>
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;<br>
&lt;head runat="server"&gt;<br>
	&lt;title&gt;JQuery UI 的 datepicker&lt;/title&gt;<br>
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
	&lt;form id="formDatepicker" runat="server"&gt;<br>
	&lt;p&gt;<br>
		如需要显示中文, 请加载对应的脚本即可.<br>
	&lt;/p&gt;<br>
	&lt;je:Datepicker ID="dA" runat="server" ScriptPackageID="package" /&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;-&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;input id="iB" type="text" /&gt;<br>
	&lt;je:Datepicker ID="dB" runat="server" ScriptPackageID="package" ElementType="Span"<br>
		AltField="#iB" AltFormat="yy-mm-dd" /&gt;<br>
	日期格式为 yy-mm-dd<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;ElementType="Span" AltField="#iB" AltFormat="yy-mm-dd"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dC" runat="server" ScriptPackageID="package" AppendText="出生时间"<br>
		PrevText="前一个月" NextText="下一个月" /&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;AppendText="出生时间" PrevText="前一个月" NextText="下一个月"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dD" runat="server" ScriptPackageID="package" AutoSize="True" /&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;AutoSize="True"&lt;/span&gt; 自动调整文本框大小<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dE" runat="server" ScriptPackageID="package" ChangeMonth="True"<br>
		ChangeYear="True" /&gt;<br>
	可选择年份和月份<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;ChangeMonth="True" ChangeYear="True"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dF" runat="server" ScriptPackageID="package" DateFormat="yy-mm-dd" /&gt;<br>
	日期格式为 yy-mm-dd<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;DateFormat="yy-mm-dd"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dG" runat="server" ScriptPackageID="package" ConstrainInput="false" /&gt;<br>
	不限制文本框输入的内容<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;ConstrainInput="false"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dH" runat="server" ScriptPackageID="package" CurrentText="当天"<br>
		ShowButtonPanel="True" CloseText="关闭" /&gt;<br>
	显示按钮<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;CurrentText="当天" ShowButtonPanel="True" CloseText="关闭"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dI" runat="server" ScriptPackageID="package" FirstDay="1" /&gt;<br>
	周一<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;FirstDay="1"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dJ" runat="server" ScriptPackageID="package" DefaultDate="2011-12-12"<br>
		MaxDate="2020-01-01" MinDate="2011-01-01" /&gt;<br>
	日期范围<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;DefaultDate="2011-12-12" MaxDate="2020-01-01" MinDate="2011-01-01"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dK" runat="server" ScriptPackageID="package" NumberOfMonths="2" /&gt;<br>
	显示 2 个月的日期<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;NumberOfMonths="2"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dL" runat="server" ScriptPackageID="package" SelectOtherMonths="True"<br>
		ShowOtherMonths="True" /&gt;<br>
	显示并可选择其它月份<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;SelectOtherMonths="True" ShowOtherMonths="True"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dM" runat="server" ScriptPackageID="package" ShowMonthAfterYear="True" /&gt;<br>
	年份在月份前<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;ShowMonthAfterYear="True"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dN" runat="server" ScriptPackageID="package" ShowWeek="True" WeekHeader="week" /&gt;<br>
	显示周<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;ShowWeek="True" WeekHeader="week"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dO" runat="server" ScriptPackageID="package" StepMonths="2" /&gt;<br>
	每次跳转 2 个月份<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;StepMonths="2"&lt;/span&gt;<br>
	&lt;br /&gt;<br>
	&lt;hr /&gt;<br>
	&lt;je:Datepicker ID="dP" runat="server" ScriptPackageID="package" OnChangeMonthYear="function(){writeLine('#pP', '改变年份月份');}"<br>
		OnClose="function(){writeLine('#pP', '关闭');}" OnSelect="function(){writeLine('#pP', '选择');}"<br>
		ChangeYear="True" ChangeMonth="True" /&gt;<br>
	事件<br>
	&lt;p id="pP" class="panel" style="width: 80%;"&gt;<br>
	&lt;/p&gt;<br>
	&lt;br /&gt;<br>
	&lt;span class="code"&gt;OnChangeMonthYear="..." OnClose="..." OnSelect="..." ChangeYear="True"<br>
		ChangeMonth="True"&lt;/span&gt;<br>
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
﻿#summary JQueryElement 分割条
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementSliderDoc'>Translate this page</a></font>

<h3>简介</h3>
<blockquote>使用 JQueryElement 的 Slider 控件即可实现 jQuery UI 中的分割条.</blockquote>

<h3>前提条件</h3>
<ol><li>请在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 3.0 或更高版本的 dll, 并为项目引用对应 .NET 版本的 dll.</li></ol>

<blockquote>2. 在页面添加如下指令:<br>
<pre><code>&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui" TagPrefix="je" %&gt;
</code></pre></blockquote>

<blockquote>3. JQueryElement 并没有将 jQuery UI 的脚本和样式作为资源嵌入, 所以请将 jQuery UI 所需的脚本和样式复制到项目中并在页面中引用, 比如:<br>
<pre><code>&lt;script type="text/javascript" src="../js/jquery-1.5.1.min.js"&gt;&lt;/script&gt;
&lt;script type="text/javascript" src="../js/jquery-ui-1.8.11.custom.min.js"&gt;&lt;/script&gt;
&lt;link type="text/css" rel="Stylesheet" href="../css/smoothness/jquery-ui-1.8.15.custom.css" /&gt;
</code></pre></blockquote>

<blockquote>4. 添加如下 js 脚本:<br>
<pre><code>&lt;script type="text/javascript"&gt;
	function writeLine(selector, html) {
		$(selector).html($(selector).html() + html + '&lt;br /&gt;');
	}
&lt;/script&gt;
</code></pre></blockquote>

<blockquote>5. 页面包含如下自定义样式, 请参考文章尾部的 main.css.<br>
<pre><code>&lt;link type="text/css" rel="Stylesheet" href="../css/main.css" /&gt;
</code></pre></blockquote>

<h3>添加 ScriptPackage 控件</h3>
<blockquote>添加 ScriptPackage 控件, 用来统一存放控件产生的 js 脚本, 也可以不添加. 需要将控件放到页面代码的尾部, 否则有些 js 脚本可能不会被包含.<br>
<pre><code>&lt;je:ScriptPackage ID="package" runat="server" /&gt;
</code></pre></blockquote>

<h3>实现一个简单的分割条</h3>
<blockquote>在页面中添加如下代码:<br>
<pre><code>&lt;je:Slider ID="sA" runat="server" ScriptPackageID="package" Value="50"&gt;
&lt;/je:Slider&gt;
</code></pre>
这里实现了一个分割条, 其对应的 js 脚本将生成到刚才添加的 ScriptPackage 控件中.</blockquote>

<h3>通过选择器实现分割条</h3>
<blockquote>Slider 可以使页面上其它的元素实现分割条, 通过 Selector 属性, 将其设置为一个选择器, 比如: <code>'#iB'</code>, 表示选择页面中 id 为 iB 的元素, 注意使用了单引号, 那么 iB 将成为一个分割条.<br>
<pre><code>&lt;div id="dB"&gt;
&lt;/div&gt;
&lt;je:Slider ID="sB" runat="server" ScriptPackageID="package" Max="200" Min="100" Value="150"&gt;
&lt;/je:Slider&gt;
</code></pre></blockquote>

<h3>效果说明</h3>
<blockquote>通过设置 Slider 的属性实现的部分效果如下, 具体请参考 slider.aspx:<br>
</blockquote><ul><li>设置分割条的位置<br>
</li><li>设置分割条的最大最小值<br>
</li><li>设置分割条的步长<br>
</li><li>水平或者垂直方向的分割条</li></ul>

<h3>事件说明</h3>
<blockquote>Slider 控件具有如下事件, 具体请参考 slider.aspx:<br>
</blockquote><ul><li>创建时<br>
</li><li>开始滑动时<br>
</li><li>滑动时<br>
</li><li>结束滑动时<br>
</li><li>改变时</li></ul>

<h3>slider.aspx</h3>
<pre><code>&lt;%@ Page Language="C#" %&gt;

&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui"
	TagPrefix="je" %&gt;
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;
&lt;script runat="server"&gt;

	protected void sF_ChangeSync ( object sender, SliderEventArgs e )
	{
		this.ClientScript.RegisterStartupScript ( this.GetType ( ), "sF_ChangeSync", "alert('sF_ChangeSync');", true );
	}
	
&lt;/script&gt;
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;
&lt;head runat="server"&gt;
	&lt;title&gt;JQuery UI 的 slider&lt;/title&gt;
	&lt;script type="text/javascript" src="../js/jquery-1.5.1.min.js"&gt;&lt;/script&gt;
	&lt;script type="text/javascript" src="../js/jquery-ui-1.8.11.custom.min.js"&gt;&lt;/script&gt;
	&lt;link type="text/css" rel="Stylesheet" href="../css/smoothness/jquery-ui-1.8.15.custom.css" /&gt;
	&lt;link type="text/css" rel="Stylesheet" href="../css/main.css" /&gt;
	&lt;script type="text/javascript"&gt;
		function writeLine(selector, html) {
			$(selector).html($(selector).html() + html + '&lt;br /&gt;');
		}
	&lt;/script&gt;
&lt;/head&gt;
&lt;body&gt;
	&lt;form id="formSlider" runat="server"&gt;
	&lt;je:Slider ID="sA" runat="server" ScriptPackageID="package" Value="50"&gt;
	&lt;/je:Slider&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Value="50"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div id="dB"&gt;
	&lt;/div&gt;
	&lt;je:Slider ID="sB" runat="server" ScriptPackageID="package" Max="200" Min="100" Value="150"&gt;
	&lt;/je:Slider&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Max="200" Min="100" Value="150"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Slider ID="sC" runat="server" ScriptPackageID="package" Step="10"&gt;
	&lt;/je:Slider&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Step="10"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Slider ID="sD" runat="server" ScriptPackageID="package" Orientation="vertical"&gt;
	&lt;/je:Slider&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Orientation="vertical"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Slider ID="sE" runat="server" ScriptPackageID="package" Change="function(){writeLine('#pE', '改变');}"
		Create="function(){writeLine('#pE', '创建');}" Slide="function(){writeLine('#pE', '滑动');}"
		Start="function(){writeLine('#pE', '开始');}" Stop="function(){writeLine('#pE', '结束');}"&gt;
	&lt;/je:Slider&gt;
	&lt;p id="pE" class="panel" style="width: 80%;"&gt;
	&lt;/p&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Change="..." Create="..." Slide="..." Start="..." Stop="..."&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Slider ID="sF" runat="server" ScriptPackageID="package" OnChangeSync="sF_ChangeSync"&gt;
	&lt;/je:Slider&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;onchangesync="sF_ChangeSync"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:ScriptPackage ID="package" runat="server" /&gt;
	&lt;/form&gt;
&lt;/body&gt;
&lt;/html&gt;
</code></pre>

<h3>main.css</h3>
<pre><code>body
{
	font-family: "微软雅黑";
	font-size: 9pt;
}
hr
{
	border: solid 1px #eeeeee;
	margin-bottom: 50px;
}
li
{
	padding: 5px;
}
.panel
{
	border: solid 1px #cccccc;
	padding: 10px;
	background-color: #eeeeee;
}
.box
{
	border: solid 1px #999999;
	padding: 2px 5px 2px 5px;
	color: InfoText;
	background-color: InfoBackground;
}
.code
{
	float: right;
	font-style: italic;
	font-size: x-small;
	color: Blue;
}
.ui-selecting
{
	color: MenuText;
	background-color: InactiveCaption;
}
.ui-selected
{
	color: MenuText;
	background-color: ActiveCaption;
}
</code></pre>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i>
</font>
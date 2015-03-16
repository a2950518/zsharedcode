#summary 自动添加脚本和样式
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/ResourceLoader'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /resourceloader/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view//'>www.tudou.com/programs/view//</a></blockquote>

<blockquote>本文将说明如何使用 ResourceLoader 为页面添加脚本和样式引用:</blockquote>

<ul><li>准备<br>
</li><li>定义资源的路径<br>
</li><li>JQuery UI 控件<br>
</li><li>JQPlot 控件<br>
</li><li>指定需要的脚本和样式<br>
</li><li>自定义控件</li></ul>

<h3>准备</h3>
<blockquote>请确保已经在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 最新的版本.</blockquote>

<blockquote>请使用指令引用如下的命名空间:<br>
<pre><code>&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.ui.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
</code></pre></blockquote>

<h3>定义资源的路径</h3>
<blockquote>首先, 需要在 web.config 中定义脚本和样式的路径:<br>
<pre><code>&lt;appSettings&gt;<br>
	&lt;add key="je.jquery.js" value="&lt;jquery 脚本路径&gt;"/&gt;<br>
	&lt;add key="je.jquery.ui.js" value="&lt;jquery ui 脚本路径&gt;"/&gt;<br>
	&lt;add key="je.jquery.ui.css" value="&lt;jquery ui 样式路径&gt;"/&gt;<br>
	&lt;add key="je.jqplot.excanvas.js" value="&lt;jqplot excanvas 脚本路径&gt;"/&gt;<br>
	&lt;add key="je.jqplot.js" value="&lt;jqplot 脚本路径&gt;"/&gt;<br>
<br>
	&lt;add key="je.jqplot.&lt;插件名&gt;.js" value="&lt;jqplot 插件脚本路径&gt;"/&gt;<br>
	...<br>
<br>
	&lt;add key="je.jqplot.css" value="&lt;jqplot 样式路径&gt;"/&gt;<br>
<br>
	&lt;add key="&lt;自定义关键字&gt;" value="&lt;路径&gt;"/&gt;<br>
&lt;/appSettings&gt;<br>
<br>
<br>
&lt;appSettings&gt;<br>
	&lt;add key="je.jquery.js"<br>
		value="~/js/jquery-1.6.2.min.js"/&gt;<br>
	&lt;add key="je.jquery.ui.js"<br>
		value="~/js/jquery-ui-1.8.15.custom.min.js"/&gt;<br>
	&lt;add key="je.jquery.ui.css"<br>
		value="~/css/smoothness/jquery-ui-1.8.15.custom.css"/&gt;<br>
	&lt;add key="je.jqplot.excanvas.js"<br>
		value="~/js/excanvas.min.js"/&gt;<br>
	&lt;add key="je.jqplot.js"<br>
		value="~/js/jquery.jqplot.min.js"/&gt;<br>
<br>
	&lt;add key="je.jqplot.DateAxisRenderer.js"<br>
		value="~/js/plugins/jqplot.dateAxisRenderer.min.js"/&gt;<br>
	...<br>
<br>
	&lt;add key="je.jqplot.css"<br>
		value="~/css/jquery.jqplot.min.css"/&gt;<br>
<br>
	&lt;add key="my.key" value="~/js/my.js"/&gt;<br>
&lt;/appSettings&gt;<br>
</code></pre>
在 web.config 中, 使用特定的关键字来表示 jQuery, jQuery UI 和 jqplot 的脚本和样式.</blockquote>

<blockquote>可以加入自定义的关键字来表示自己的文件. 这些关键字将在自定义控件中使用.</blockquote>

<h3>JQuery UI 控件</h3>
<blockquote>在页面中添加一个 ResourceLoader 控件, 然后再添加类似于按钮的 JQueryElement 控件:<br>
<pre><code>&lt;head runat="server"&gt;<br>
	&lt;title&gt;JQuery UI 控件&lt;/title&gt;<br>
&lt;/head&gt;<br>
<br>
...<br>
<br>
&lt;je:ResourceLoader ID="resource" runat="server" /&gt;<br>
<br>
&lt;je:Button ID="button" runat="server" Label="一个按钮"&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
在上面的示例中, 不需要添加 jQuery UI 的脚本和样式, 因为 ResourceLoader 将根据需要添加这些脚本和样式.</blockquote>

<h3>JQPlot 控件</h3>
<blockquote>同样需要添加 ResourceLoader 控件, 但如果使用了某些 jqplot 插件, 还需要另外的设置一些 ResourceLoader 控件属性:<br>
<pre><code>&lt;je:ResourceLoader ID="resource" runat="server"<br>
	JQPlotDateAxisRenderer="true" /&gt;<br>
<br>
&lt;je:Plot ID="plot1" runat="server" IsVariable="true"&gt;<br>
	&lt;AxesSetting XAxisSetting-Renderer="DateAxisRenderer"&gt;<br>
	&lt;/AxesSetting&gt;<br>
	&lt;DataSetting&gt;<br>
		&lt;je:Data&gt;<br>
			&lt;je:Point Param1="'2011-1-1'" Param2="300" /&gt;<br>
			&lt;je:Point Param1="'2011-1-2'" Param2="320" /&gt;<br>
			&lt;je:Point Param1="'2011-1-3'" Param2="340" /&gt;<br>
			&lt;je:Point Param1="'2011-1-4'" Param2="400" /&gt;<br>
		&lt;/je:Data&gt;<br>
	&lt;/DataSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
上面的代码中, 使用了 jqplot 的日期轴插件, 因此需要设置 JQPlotDateAxisRenderer 属性为 true.</blockquote>

<blockquote>关于不同的插件如何设置, 请参考 jqplot 的相关文章.</blockquote>

<h3>指定需要的脚本和样式</h3>
<blockquote>可以通过 ResourceLoader 控件的 JQuery, JQueryUI, JQPlot 属性来强制的引用脚本和样式:<br>
<pre><code>&lt;je:ResourceLoader ID="resource" runat="server"<br>
	JQueryUI="true" /&gt;<br>
</code></pre>
上面的代码中, 设置 JQueryUI 属性为 true, 则页面将引用 jQuery UI 所需的脚本和样式.</blockquote>

<h3>自定义控件</h3>
<blockquote>可以为自定义控件指定需要引用的脚本和样式:<br>
<pre><code>&lt;%@ Control Language="C#" AutoEventWireup="true"<br>
	CodeFile="MyControl1.ascx.cs"<br>
	Inherits="resourceloader_MyControl1" %&gt;<br>
&lt;input type="button" class="my-button"<br>
	onclick="alert(sub(1,2,3));"<br>
	value="1 + 2 - 3" /&gt;<br>
</code></pre></blockquote>

<pre><code>using zoyobar.shared.panzer.ui.jqueryui;<br>
<br>
[Resource ( SingleScript = "my.js", SingleStyle = "my.css" )]<br>
public partial class resourceloader_MyControl1<br>
	: System.Web.UI.UserControl<br>
{<br>
	...<br>
}<br>
</code></pre>
<blockquote>使用 ResourceAttribute 的 SingleScript 和 SingleStyle 属性可以指定脚本和样式的关键字. 这些关键字在 web.config 中已经指定:<br>
<pre><code>&lt;appSettings&gt;<br>
	&lt;add key="my.js"<br>
		value="~/resourceloader/mycontrol.js"/&gt;<br>
	&lt;add key="my.css"<br>
		value="~/resourceloader/mycontrol.css"/&gt;<br>
<br>
	...<br>
<br>
&lt;/appSettings&gt;<br>
</code></pre>
可以指定多个脚本或样式, 使用分号分隔即可. 对于自定义的文件, 关键字的顺序也就是文件的加载顺序.</blockquote>

<blockquote>也可以使用 MultipleScript 属性来指定所需要的脚本, 如果 MultipleScript 指定的关键字在 web.config 中存在, 则将忽略 SingleScript:<br>
<pre><code>&lt;%@ Control Language="C#" AutoEventWireup="true"<br>
	CodeFile="MyControl2.ascx.cs"<br>
	Inherits="resourceloader_MyControl2" %&gt;<br>
&lt;input type="button" class="my-button"<br>
	onclick="alert(add(1,2));"<br>
	value="1 + 2" /&gt;<br>
</code></pre></blockquote>

<pre><code>using zoyobar.shared.panzer.ui.jqueryui;<br>
<br>
[Resource ( SingleScript = "my.js", MultipleScript="my1.js", SingleStyle = "my.css" )]<br>
public partial class resourceloader_MyControl2<br>
	: System.Web.UI.UserControl<br>
{<br>
	...<br>
}<br>
</code></pre>

<pre><code>&lt;appSettings&gt;<br>
	&lt;add key="my.js" value="~/resourceloader/mycontrol.js"/&gt;<br>
	&lt;add key="my1.js" value="~/resourceloader/mycontrol.1.js"/&gt;<br>
	&lt;add key="my2.js" value="~/resourceloader/mycontrol.2.js"/&gt;<br>
	&lt;add key="my.css" value="~/resourceloader/mycontrol.css"/&gt;<br>
<br>
	...<br>
<br>
&lt;/appSettings&gt;<br>
</code></pre>

</font>
#summary Plot 高亮显示数据
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JEPlotHighlighter'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /plot/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view//'>www.tudou.com/programs/view//</a></blockquote>

<blockquote>本文将详细的讲解如何在 Plot 图表中高亮显示数据, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>所需脚本<br>
</li><li>高亮<br>
</li><li>尺寸<br>
</li><li>提示<br>
</li><li>置前</li></ul>

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementPlotDoc.md'>Plot 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>所需脚本</h3>
<blockquote>需要在页面中引用高亮显示所需的脚本, 比如:<br>
<pre><code>&lt;script type="text/javascript"<br>
	src="js/plugins/jqplot.highlighter.min.js"&gt;<br>
&lt;/script&gt;<br>
</code></pre>
如果使用 ResourceLoader 来加载脚本, 则需要配置 web.config 并设置 ResourceLoader 的 JQPlotHighlighter 属性为 true, 比如:<br>
<pre><code>&lt;appSettings&gt;<br>
	...<br>
<br>
	&lt;add key="je.jqplot.Highlighter.js"<br>
		value="~/js/plugins/jqplot.highlighter.min.js"/&gt;<br>
&lt;/appSettings&gt;<br>
</code></pre></blockquote>

<pre><code>&lt;je:ResourceLoader ID="resource" runat="server"<br>
	JQPlotHighlighter="true" /&gt;<br>
</code></pre>
<blockquote>而更多关于 ResourceLoader 的内容, 可以参考 <a href='ResourceLoader.md'>自动添加脚本和样式</a>.</blockquote>

<h3>高亮</h3>
<blockquote>设置 HighlighterSetting 的 Show 属性为 true, 则将高亮显示鼠标悬停的数据:<br>
<pre><code>&lt;je:Plot ID="plot1" runat="server" IsVariable="true"<br>
	Data="[[[1,1],[3,2],[4,4],[5,8]]]"&gt;<br>
	&lt;HighlighterSetting Show="true" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plothighlighter1.jpg' /></blockquote>

<h3>尺寸</h3>
<blockquote>HighlighterSetting 的 SizeAdjust 属性表示了高亮时的尺寸:<br>
<pre><code>&lt;je:Plot ID="plot2" runat="server" IsVariable="true"<br>
	Data="[[[2,1],[3,2],[4,7],[5,8]]]"&gt;<br>
	&lt;HighlighterSetting Show="true"<br>
		SizeAdjust="10" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plothighlighter2.jpg' /></blockquote>

<h3>提示</h3>
<blockquote>HighlighterSetting 的 ToolTipLocation 属性表示提示显示的方向, ToolTipOffset 属性表示提示的偏移距离, ToolTipFadeSpeed 属性表示提示消失的速度:<br>
<pre><code>&lt;je:Plot ID="plot3" runat="server" IsVariable="true"<br>
	Data="[[[2,3],[3,7],[4,7],[5,9]]]"&gt;<br>
	&lt;HighlighterSetting Show="true"<br>
		ToolTipLocation="e"<br>
		ToolTipOffset="30"<br>
		ToolTipFadeSpeed="slow"<br>
		FormatString="x: %.5P, y: %.5P" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
FormatString 可以设置提示的内容, 默认第一个值为 x 轴的数据, 第二个值为 y 轴的数据.</blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plothighlighter3.jpg' /></blockquote>

<blockquote>如果将 ToolTipAxes 设置为 yx, 则第一个值为 y 轴的数据:<br>
<pre><code>&lt;je:Plot ID="plot4" runat="server" IsVariable="true"<br>
	Data="[[[2,3],[3,7],[4,7],[5,9]]]"&gt;<br>
	&lt;HighlighterSetting Show="true"<br>
		ToolTipAxes="yx" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plothighlighter4.jpg' /></blockquote>

<h3>置前</h3>
<blockquote>将 BringSeriesToFront 属性设置为 true, 则处于高亮的序列将被放置在最前端:<br>
<pre><code>&lt;je:Plot ID="plot5" runat="server" IsVariable="true"<br>
	Data="[[[1,1],[2,4],[3,7],[4,9]],[[1,2],[2,2],[3,3],[4,1]]]"&gt;<br>
	&lt;HighlighterSetting Show="true"<br>
		BringSeriesToFront="true" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plothighlighter5.jpg' /></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plothighlighter51.jpg' /></blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementPlotDoc.md'>Plot 完全参考</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

</font>
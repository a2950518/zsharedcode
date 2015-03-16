#summary Plot 标题图例和序列
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JEPlotTitleLegendSeries'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /plot/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/xIlCrBoRSc8/'>www.tudou.com/programs/view/xIlCrBoRSc8/</a></blockquote>

<blockquote>本文将详细的讲解如何设置 Plot 图表的标题, 图例和序列, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>标题<br>
</li><li>图例<br>
<ul><li>位置<br>
</li><li>文本<br>
</li></ul></li><li>序列<br>
<ul><li>直线<br>
</li><li>轴<br>
</li><li>填充<br>
</li><li>阴影<br>
</li><li>图例文本<br>
</li><li>默认设置<br>
</li></ul></li><li><font color='red'>(这里是没有完成的章节)</font></li></ul>

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementPlotDoc.md'>Plot 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>标题</h3>
<blockquote>通过 TitleSetting 属性可以设置图表的标题:<br>
<pre><code>&lt;je:Plot ID="plot1" runat="server" IsVariable="true"<br>
	Data="[[[1,2],[3,4]]]"&gt;<br>
	&lt;TitleSetting<br>
		Text="这里是一个标题"<br>
		TextAlign="right"<br>
		TextColor="Blue"<br>
		FontSize="10pt" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
Text 是标题的文本, TextAlign 是标题的对齐方式, TextColor 是标题的颜色, 而 FontSize 是字体的大小.</blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plottitle1.jpg' /></blockquote>

<h3>图例</h3>

<blockquote><h4><font color='green'>位置</font></h4>
通过 LegendSetting 的 Location 和 Placement 属性可以设置图例的显示位置:<br>
<pre><code>&lt;je:Plot ID="plot1" runat="server" IsVariable="true"<br>
	Data="[[[1,2],[3,4]]]"&gt;<br>
	&lt;LegendSetting<br>
		Show="true"<br>
		Location="sw"<br>
		Placement="outsideGrid" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotlegend1.jpg' /></blockquote>

<blockquote><h4><font color='green'>文本</font></h4>
通过 Labels 属性可以设置图例的文本, 形式为一个 javascript 数组, 每一个元素对应一个序列的图例文本, 默认为 <b><code>Series N</code></b>:<br>
<pre><code>&lt;je:Plot ID="plot2" runat="server" IsVariable="true"<br>
	Data="[[[1,2],[3,4]],[[3,2],[3,1]]]"&gt;<br>
	&lt;LegendSetting Show="true"<br>
		Labels="['直线 1','&lt;u&gt;直线 2&lt;/u&gt;']" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotlegend2.jpg' /></blockquote>

<blockquote>设置 EscapeHtml 属性为 true, 则 html 代码将显示为文本:<br>
<pre><code>&lt;je:Plot ID="plot3" runat="server" IsVariable="true"<br>
	Data="[[[1,2],[3,4]],[[3,2],[3,1]],[[5,0],[7,9]]]"&gt;<br>
	&lt;LegendSetting Show="true"<br>
		Labels="['直线 1','&lt;u&gt;直线 2&lt;/u&gt;']"<br>
		EscapeHtml="true" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotlegend3.jpg' /></blockquote>

<h3>序列</h3>
<blockquote>通过 SeriesSetting 可以设置每一个序列.</blockquote>

<blockquote><h4><font color='green'>直线</font></h4>
添加 Series 对象, 可以增加对序列的设置:<br>
<pre><code>&lt;je:Plot ID="plot1" runat="server" IsVariable="true"<br>
	Data="[[[1,2],[3,4]]]"&gt;<br>
	&lt;SeriesSetting&gt;<br>
		&lt;je:Series<br>
			Color="Green"<br>
			LineWidth="5"<br>
			LinePattern="dashed"&gt;<br>
		&lt;/je:Series&gt;<br>
	&lt;/SeriesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
在上面代码中, 设置第一个序列的颜色为绿色, 宽度为 5 像素, 样式为虚线.</blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotseries1.jpg' /></blockquote>

<blockquote><h4><font color='green'>轴</font></h4>
通过 XAxis 和 YAxis 可以设置序列所使用轴:<br>
<pre><code>&lt;je:Plot ID="plot2" runat="server" IsVariable="true"<br>
	Data="[[[1,2],[3,4]]]"&gt;<br>
	&lt;SeriesSetting&gt;<br>
		&lt;je:Series XAxis="x2axis" YAxis="y2axis"&gt;<br>
		&lt;/je:Series&gt;<br>
	&lt;/SeriesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotseries2.jpg' /></blockquote>

<blockquote><h4><font color='green'>填充</font></h4>
设置 Fill 为 true, 将填充直线和某个刻度之间的空白:<br>
<pre><code>&lt;je:Plot ID="plot3" runat="server" IsVariable="true"<br>
	Data="[[[2,2],[3,5],[5,3]]]"&gt;<br>
	&lt;SeriesSetting&gt;<br>
		&lt;je:Series Fill="true"&gt;<br>
		&lt;/je:Series&gt;<br>
	&lt;/SeriesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotseries3.jpg' /></blockquote>

<blockquote>通过 FillAlpha 和 FillColor 可以设置填充的透明度和颜色, 设置 FillAndStroke 为 true, 则将在显示填充的同时显示直线:<br>
<pre><code>&lt;je:Plot ID="plot4" runat="server" IsVariable="true"<br>
	Data="[[[-1,-1],[3,0],[4,3]]]"&gt;<br>
	&lt;SeriesSetting&gt;<br>
		&lt;je:Series Fill="true"<br>
			FillAlpha="0.4"<br>
			FillColor="Red"<br>
			FillAndStroke="true"&gt;<br>
		&lt;/je:Series&gt;<br>
	&lt;/SeriesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotseries4.jpg' /></blockquote>

<blockquote>设置 FillToZero 为 true, 则填充以 0 为基线:<br>
<pre><code>&lt;je:Plot ID="plot5" runat="server" IsVariable="true"<br>
	Data="[[[-1,-1],[2,0],[5,3]]]"&gt;<br>
	&lt;SeriesSetting&gt;<br>
		&lt;je:Series Fill="true"<br>
			FillToZero="true"&gt;<br>
		&lt;/je:Series&gt;<br>
	&lt;/SeriesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotseries5.jpg' /></blockquote>

<blockquote><h4><font color='green'>阴影</font></h4>
同样可是设置序列的阴影:<br>
<pre><code>&lt;je:Plot ID="plot6" runat="server" IsVariable="true"<br>
	Data="[[[1,1],[2,3],[5,3]]]"&gt;<br>
	&lt;SeriesSetting&gt;<br>
		&lt;je:Series<br>
			ShadowAngle="30"<br>
			ShadowDepth="10"<br>
			ShadowOffset="3"&gt;<br>
		&lt;/je:Series&gt;<br>
	&lt;/SeriesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotseries6.jpg' /></blockquote>

<blockquote><h4><font color='green'>图例文本</font></h4>
Label 属性表示序列在图例中的文本:<br>
<pre><code>&lt;je:Plot ID="plot7" runat="server" IsVariable="true"<br>
	Data="[[[1,2],[2,4],[3,3]]]" LegendSetting-Show="true"&gt;<br>
	&lt;SeriesSetting&gt;<br>
		&lt;je:Series Label="Hello!!!"&gt;<br>
		&lt;/je:Series&gt;<br>
	&lt;/SeriesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotseries7.jpg' /></blockquote>

<blockquote><h4><font color='green'>默认设置</font></h4>
通过 SeriesDefaultsSetting 可以设置所有的序列:<br>
<pre><code>&lt;je:Plot ID="plot8" runat="server" IsVariable="true"<br>
	Data="[[[1,3],[2,1],[3,5]],[[1,1],[2,0],[3,3]]]"&gt;<br>
	&lt;SeriesDefaultsSetting LineWidth="8"&gt;<br>
	&lt;/SeriesDefaultsSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<h3><font color='red'>(这里是没有完成的章节)</font></h3>
<blockquote>更多内容, 敬请期待...</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementPlotDoc.md'>Plot 完全参考</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

</font>
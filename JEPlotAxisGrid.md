#summary Plot 轴和网格
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JEPlotAxisGrid'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /plot/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/HZC250BM_TE/'>www.tudou.com/programs/view/HZC250BM_TE/</a></blockquote>

<blockquote>本文将详细的讲解如何设置 Plot 图表控件的轴和网格, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>轴<br>
<ul><li>标题<br>
</li><li>刻度<br>
</li><li>两边的空白<br>
</li><li>边框<br>
</li><li>X2, Y2<br>
</li><li>默认设置<br>
</li></ul></li><li>网格<br>
<ul><li>样式<br>
</li><li>阴影<br>
</li></ul></li><li>日期轴<br>
</li><li><font color='red'>(这里是没有完成的章节)</font></li></ul>

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementPlotDoc.md'>Plot 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>轴</h3>

<blockquote><h4><font color='green'>标题</font></h4>
通过 Title 属性可以设置轴的标题:<br>
<pre><code>&lt;je:Plot ID="plot1" runat="server" IsVariable="true" Width="500px"&gt;<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting<br>
			Label='这里是 &lt;span style="font-size: xx-large"&gt;x&lt;/span&gt; 轴'&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
	&lt;DataSetting&gt;<br>
		&lt;je:Data&gt;<br>
			&lt;je:Point Param1="10" Param2="1" /&gt;<br>
			&lt;je:Point Param1="11" Param2="10" /&gt;<br>
			&lt;je:Point Param1="13" Param2="22" /&gt;<br>
			&lt;je:Point Param1="20" Param2="30" /&gt;<br>
		&lt;/je:Data&gt;<br>
	&lt;/DataSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis1.jpg' /></blockquote>

<blockquote>如果希望标题中的 html 代码作为文字显示, 则需要设置 EscapeHtml 属性为 true:<br>
<pre><code>&lt;je:Plot ID="plot2" runat="server" IsVariable="true" Data="[[[1,1],[2,2]]]" Width="500px"&gt;<br>
	&lt;AxesSetting<br>
		YAxisSetting-Label='这里是 &lt;b&gt;y&lt;/b&gt; 轴'<br>
		YAxisSetting-LabelRendererSetting-EscapeHtml="true"&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis2.jpg' /></blockquote>

<blockquote><h4><font color='green'>刻度</font></h4>
通过 NumberTicks 和 TickInterval 属性可以设置刻度之间的距离:<br>
<pre><code>&lt;je:Plot ID="plot3" runat="server" IsVariable="true"<br>
	Data="[[[1,1],[2,2],[3,3],[4,4],[5,5],[6,6],[7,7]]]"&gt;<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting NumberTicks="4" TickInterval="3"&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis3.jpg' /></blockquote>

<blockquote>而通过 Ticks 属性可以设置在哪些位置显示刻度:<br>
<pre><code>&lt;je:Plot ID="plot8" runat="server" IsVariable="true"<br>
	Data="[[[0,1],[2,5],[3,7]]]"&gt;<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting Ticks="[0,1,3,5,10]"&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
上面的代码中, 将在 0, 1, 3, 5, 10 显示刻度.</blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis8.jpg' /></blockquote>

<blockquote>还可以设置刻度的颜色和文本的格式:<br>
<pre><code>&lt;je:Plot ID="plot11" runat="server" IsVariable="true"<br>
	Data="[[[100,1],[200,101],[20,50]]]"&gt;<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting&gt;<br>
			&lt;TickRendererSetting TextColor="Red"<br>
				Prefix="-" FormatString="(%d)" /&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis11.jpg' /></blockquote>

<blockquote>通过 Min 和 Max 可以设置刻度的最小值和最大值:<br>
<pre><code>&lt;je:Plot ID="plot6" runat="server" IsVariable="true"<br>
	Data="[[[2,5],[4,2],[3,7]]]"&gt;<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting Min="0" Max="10"&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis6.jpg' /></blockquote>

<blockquote>此外, 还可以设置刻度的样式和长度:<br>
<pre><code>&lt;je:Plot ID="plot10" runat="server" IsVariable="true"<br>
	Data="[[[-1,1],[2,10],[20,50]]]"&gt;<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting&gt;<br>
			&lt;TickRendererSetting Mark="outside" MarkSize="20" /&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis10.jpg' /></blockquote>

<blockquote><h4><font color='green'>两边的空白</font></h4>
通过 Pad, PadMax 和 PadMin 可以设置空白的比例:<br>
<pre><code>&lt;je:Plot ID="plot4" runat="server" IsVariable="true"<br>
	Data="[[[2,1],[2,2],[3,7]]]"&gt;<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting Pad="2"&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
<br>
&lt;je:Plot ID="plot5" runat="server" IsVariable="true"<br>
	Data="[[[2,1],[2,2],[3,7]]]"&gt;<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting PadMax="2"&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis4.jpg' /></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis5.jpg' /></blockquote>

<blockquote><h4><font color='green'>边框</font></h4>
通过 BorderColor 和 BorderWidth 属性可以设置边框的样式:<br>
<pre><code>&lt;je:Plot ID="plot9" runat="server" IsVariable="true"<br>
	Data="[[[-10,1],[20,10],[20,20]]]"&gt;<br>
	&lt;AxesSetting<br>
		XAxisSetting-BorderColor="Blue"<br>
		XAxisSetting-BorderWidth="3"&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>X2, Y2</font></h4>
除了 x 和 y 轴, 图表中还有 x2 和 y2 轴:<br>
<pre><code>&lt;je:Plot ID="plot12" runat="server" IsVariable="true"<br>
	Data="[[[0,1],[2,4],[5,7]]]"&gt;<br>
	&lt;AxesSetting<br>
		X2AxisSetting-BorderWidth="3"<br>
		X2AxisSetting-BorderColor="Blue"&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
上面的代码设置了 x2 轴的颜色和宽度.</blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis12.jpg' /></blockquote>

<blockquote><h4><font color='green'>默认设置</font></h4>
可以为 x, y, x2, y2 这些轴设置默认的参数:<br>
<pre><code>&lt;je:Plot ID="plot13" runat="server" IsVariable="true"<br>
	Data="[[[0,1],[2,4],[5,7]]]"&gt;<br>
	&lt;AxesDefaultsSetting<br>
		BorderColor="Red"<br>
		NumberTicks="3"&gt;<br>
	&lt;/AxesDefaultsSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotaxis13.jpg' /></blockquote>

<h3>网格</h3>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotgrid1.jpg' /></blockquote>

<blockquote><h4><font color='green'>样式</font></h4>
可设置直线的颜色和宽度等:<br>
<pre><code>&lt;je:Plot ID="plot2" runat="server" IsVariable="true"<br>
	Data="[[[0,0],[1,4],[2,4]]]"&gt;<br>
	&lt;GridSetting<br>
		Background="DarkGray"<br>
		BorderColor="Red" BorderWidth="5"<br>
		GridLineColor="Blue" GridLineWidth="2" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotgrid3.jpg' /></blockquote>

<blockquote><h4><font color='green'>阴影</font></h4>
关于阴影的设置参数也很多:<br>
<pre><code>&lt;je:Plot ID="plot3" runat="server" IsVariable="true"<br>
	Data="[[[1,10],[12,43],[22,4]]]"&gt;<br>
	&lt;GridSetting<br>
		ShadowDepth="5" ShadowWidth="6"<br>
		ShadowAngle="60" ShadowOffset="2" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotgrid4.jpg' /></blockquote>

<h3>日期轴</h3>
<blockquote>大部分情况下, 数据都是和日期相关的, 因此就需要在 jqplot 中显示日期, 详情请参考 <a href='JEPlotDateAxis.md'>Plot 日期轴</a>.</blockquote>

<h3><font color='red'>(这里是没有完成的章节)</font></h3>
<blockquote>更多内容, 敬请期待...</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementPlotDoc.md'>Plot 完全参考</a></blockquote>

<blockquote><a href='JEPlotDateAxis.md'>Plot 日期轴</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<h3>修订历史</h3>
<blockquote>2012-1-16: 增加关于轴的内容.</blockquote>

<blockquote>2012-1-29: 增加关于日期轴的链接.</blockquote>

</font>
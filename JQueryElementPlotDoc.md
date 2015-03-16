#summary Plot 完全参考
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementPlotDoc'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /plot/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/mkuQaMpuBvE/'>www.tudou.com/programs/view/mkuQaMpuBvE/</a></blockquote>

<blockquote>本文将初步的讲解如何设置 Plot 控件所使用的数据以及控件的部分属性, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>设置数据<br>
<ul><li>数据序列<br>
</li><li>DataSetting<br>
</li><li>AppendData 方法<br>
</li><li>Data 属性<br>
</li></ul></li><li>显示数据<br>
</li><li>播放动画<br>
</li><li>数据排序<br>
</li><li>轴和网格<br>
</li><li>标题图例和序列<br>
</li><li>光标位置和放大图表<br>
</li><li>高亮显示数据<br>
</li><li><font color='red'>(这里是没有完成的章节)</font></li></ul>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotdata4.jpg' /></blockquote>

<h3>准备</h3>
<blockquote>请确保已经在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 最新的版本.</blockquote>

<blockquote>请使用指令引用如下的命名空间:<br>
<pre><code>&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.ui.jqueryui.plusin.jqplot"<br>
	TagPrefix="je" %&gt;<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.web.jqueryui.plusin.jqplot"<br>
	TagPrefix="je" %&gt;<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.web.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
</code></pre>
除了命名空间, 还需要引用 jQueryUI 和 jqplot 的脚本和样式, 在 <a href='Download.md'>下载资源</a> 的 JQueryElement.dll 下载一节下载的压缩包中包含了一个自定义样式的 jQueryUI 和 jqplot, 如果需要更多样式, 可以在 <a href='http://jqueryui.com/download'>jqueryui.com/download</a> 下载:<br>
<pre><code>&lt;link type="text/css" rel="stylesheet" href="[样式路径]/jquery-ui-&lt;version&gt;.custom.css" /&gt;<br>
&lt;link type="text/css" rel="stylesheet" href="[样式路径]/jquery.jqplot.min.css" /&gt;<br>
&lt;script type="text/javascript" src="[脚本路径]/jquery-&lt;version&gt;.min.js"&gt;&lt;/script&gt;<br>
&lt;script type="text/javascript" src="[脚本路径]/jquery-ui-&lt;version&gt;.custom.min.js"&gt;&lt;/script&gt;<br>
&lt;script type="text/javascript" src="[脚本路径]/excanvas.min.js"&gt;&lt;/script&gt;<br>
&lt;script type="text/javascript" src="[脚本路径]/jquery.jqplot.min.js"&gt;&lt;/script&gt;<br>
</code></pre>
也可以使用 ResourceLoader 来添加所需的脚本或样式, 详细请参考 <a href='ResourceLoader.md'>自动添加脚本和样式</a>.</blockquote>

<h3>设置数据</h3>

<blockquote><h4><font color='green'>数据序列</font></h4>
Plot 可以显示多组数据, 比如, 同时显示两本图书各自的月销量, 每一本书相关的数据就是一个数据序列.</blockquote>

<blockquote><h4><font color='green'>DataSetting</font></h4>
通过 Plot 的 DataSetting, 可以添加数据:<br>
<pre><code>&lt;je:Plot ID="plot2" runat="server" IsVariable="true" Width="500px"&gt;<br>
	&lt;DataSetting&gt;<br>
		&lt;je:Data&gt;<br>
			&lt;je:Point Param1="1" Param2="2" /&gt;<br>
			&lt;je:Point Param1="2" Param2="4" /&gt;<br>
			&lt;je:Point Param1="3" Param2="8" /&gt;<br>
			&lt;je:Point Param1="4" Param2="16" /&gt;<br>
		&lt;/je:Data&gt;<br>
		&lt;je:Data&gt;<br>
			&lt;je:Point Param1="1" Param2="3" /&gt;<br>
			&lt;je:Point Param1="2" Param2="7" /&gt;<br>
			&lt;je:Point Param1="3" Param2="10" /&gt;<br>
			&lt;je:Point Param1="4" Param2="6" /&gt;<br>
		&lt;/je:Data&gt;<br>
	&lt;/DataSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
上面的代码中, 添加了 2 个序列, 每一个 Data 对象对应了一个序列. 通过添加 Point, 可以为序列增加点, Param1 属性对应点的第一个参数, 通常也就是 x 坐标, Param2 属性对应了第二个参数, 通常是 y 坐标. 在某些特殊情况下, 还会用到 Param3 和 Param4.</blockquote>

<blockquote><h4><font color='green'>AppendData 方法</font></h4>
在后台代码中, 可以通过 AppendData 方法来添加数据序列:<br>
<pre><code>protected void Page_Load ( object sender, EventArgs e )<br>
{<br>
	this.plot3.AppendData (<br>
		new Data (<br>
			new Point ( 1, 1 ),<br>
			new Point ( 2, 2 ),<br>
			new Point ( 3, 3 )<br>
			),<br>
		new Data (<br>
			new Point ( 1, 3 ),<br>
			new Point ( 2, 2 ),<br>
			new Point ( 3, 1 )<br>
			)<br>
		);<br>
}<br>
</code></pre>
在页面载入时, 为 plot3 添加了 2 个序列, 和 DataSetting 的结构类似, Data 对象表示一个序列, 而 Point 对象表示点.</blockquote>

<blockquote><h4><font color='green'>Data 属性</font></h4>
此外可以通过 Plot 的 Data 属性来设置序列:<br>
<pre><code>&lt;je:Plot ID="plot6" runat="server" IsVariable="true"<br>
	Data="[[[2,5],[4,6]],[[2,6],[4,7]]]"&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
Data 属性的格式为 <b><code>[&lt;序列, 比如: [&lt;点, 比如: [x, y]&gt;]&gt;]</code></b>.</blockquote>

<h3>显示数据</h3>
<blockquote>有了数据之后, 可以通过 fill 方法在 <b>plot</b> 中显示数据:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	$(function () {<br>
		plot1.__plot('fill');<br>
	});<br>
&lt;/script&gt;<br>
</code></pre>
上面的代码中, 在页面载入完成后, 显示数据. 其中 plot1 是通过 Plot 的 IsVariable 属性生成的 javascript 变量, 具体可以参考 <a href='JEBase.md'>JQueryElement 基本属性参考</a>.</blockquote>

<h3>播放动画</h3>
<blockquote>设置 Plot 的 Animate 属性为 true, 则在显示数据时将播放动画:<br>
<pre><code>&lt;span class="span-button" onclick="plot8.__plot('fill');"&gt;播放动画&lt;/span&gt;<br>
&lt;je:Plot ID="plot8" runat="server" IsVariable="true"<br>
	Data="[[[1,1],[3,5],[2,6],[4,7]]]"<br>
	Animate="true"&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<h3>数据排序</h3>
<blockquote>在默认的情况下, <b>plot</b> 会对数据进行排序, 可以将 SortData 属性设置为 false 来阻止排序, 比如:<br>
<pre><code>&lt;je:Plot ID="plot7" runat="server" IsVariable="true"<br>
	Data="[[[1,1],[3,5],[2,6],[4,7]]]"<br>
	SortData="false"&gt;<br>
&lt;/je:Plot&gt;<br>
<br>
&lt;je:Plot ID="plot8" runat="server" IsVariable="true"<br>
	Data="[[[1,1],[3,5],[2,6],[4,7]]]"&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
在 plot7 中, 第 2 个点 [3,5] 和第 3 个点 [2,6] 会交换顺序, 而在 plot8 中不会.</blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotdata7.8.jpg' /></blockquote>

<h3>轴和网格</h3>
<blockquote>通常轴就是指 x 和 y 轴, 网格也就是绘制数据的地方, 更多的内容请参考 <a href='JEPlotAxisGrid.md'>Plot 轴和网格</a>.</blockquote>

<h3>标题图例和序列</h3>
<blockquote>标题将显示在图表的上方, 图例可以说明每个序列的含义, 更多的内容请参考 <a href='JEPlotTitleLegendSeries.md'>Plot 标题图例和序列</a>.</blockquote>

<h3>光标位置和放大图表</h3>
<blockquote>jqplot 中可以显示光标的位置, 也可以放大某个区域, 更多的内容请参考 <a href='JEPlotCursor.md'>Plot 光标位置和放大图表</a>.</blockquote>

<h3>高亮显示数据</h3>
<blockquote>通过设置 HighlighterSetting 属性就可以让数据高亮显示, 更多的内容请参考 <a href='JEPlotHighlighter.md'>Plot 高亮显示数据</a>.</blockquote>

<h3><font color='red'>(这里是没有完成的章节)</font></h3>
<blockquote>更多内容, 敬请期待...</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JEPlotAxisGrid.md'>Plot 轴和网格</a></blockquote>

<blockquote><a href='JEPlotTitleLegendSeries.md'>Plot 标题图例和序列</a></blockquote>

<blockquote><a href='JEPlotCursor.md'>Plot 光标位置和放大图表</a></blockquote>

<blockquote><a href='JEPlotHighlighter.md'>Plot 高亮显示数据</a></blockquote>

<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

<h3>修订历史</h3>
<blockquote>2012-1-12: 增加脚本 excanvas.min.js 的引用, 增加轴和网格介绍.</blockquote>

<blockquote>2012-1-18: 增加标题图例和序列的介绍.</blockquote>

<blockquote>2012-1-26: 增加关于 ResourceLoader 的链接.</blockquote>

<blockquote>2012-1-31: 增加光标的介绍.</blockquote>

<blockquote>2012-2-2: 增加高亮的介绍.</blockquote>

</font>
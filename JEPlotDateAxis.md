#summary Plot 日期轴
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JEPlotDateAxis'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /plot/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/z34c999KKSA/'>www.tudou.com/programs/view/z34c999KKSA/</a></blockquote>

<blockquote>本文将详细的讲解如何在 Plot 图表中使用日期轴, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>所需脚本<br>
</li><li>Renderer 属性<br>
</li><li>格式</li></ul>

<h3>准备</h3>
<blockquote>请先查看 <a href='JEPlotAxisGrid.md'>Plot 轴和网格</a> 或者准备一节的内容.</blockquote>

<h3>所需脚本</h3>
<blockquote>需要在页面中引用日期轴所需的脚本, 比如:<br>
<pre><code>&lt;script type="text/javascript"<br>
	src="js/plugins/jqplot.dateAxisRenderer.min.js"&gt;<br>
&lt;/script&gt;<br>
</code></pre>
如果使用 ResourceLoader 来加载脚本, 则需要配置 web.config 并设置 ResourceLoader 的 JQPlotDateAxisRenderer 属性为 true, 比如:<br>
<pre><code>&lt;appSettings&gt;<br>
	...<br>
<br>
	&lt;add key="je.jqplot.DateAxisRenderer.js"<br>
		value="~/js/plugins/jqplot.dateAxisRenderer.min.js"/&gt;<br>
&lt;/appSettings&gt;<br>
</code></pre></blockquote>

<pre><code>&lt;je:ResourceLoader ID="resource" runat="server"<br>
	JQPlotDateAxisRenderer="true" /&gt;<br>
</code></pre>
<blockquote>而更多关于 ResourceLoader 的内容, 可以参考 <a href='ResourceLoader.md'>自动添加脚本和样式</a>.</blockquote>

<h3>Renderer 属性</h3>
<blockquote>设置轴的 Renderer 属性为 DateAxisRenderer, 该轴就可以显示日期:<br>
<pre><code>&lt;je:Plot ID="plot1" runat="server" IsVariable="true"&gt;<br>
	&lt;AxesSetting<br>
		XAxisSetting-Renderer="DateAxisRenderer"&gt;<br>
	&lt;/AxesSetting&gt;<br>
	<br>
	...<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotdateaxis1.jpg' /></blockquote>

<h3>格式</h3>
<blockquote>可以通过 FormatString 属性来设置日期显示的格式, 比如:<br>
<pre><code>&lt;je:Plot ID="plot2" runat="server" IsVariable="true"&gt;<br>
	&lt;AxesSetting<br>
		XAxisSetting-Renderer="DateAxisRenderer"<br>
		XAxisSetting-TickRendererSetting-FormatString="%R"&gt;<br>
	&lt;/AxesSetting&gt;<br>
	<br>
	...<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotdateaxis2.jpg' /></blockquote>

<pre><code>&lt;je:Plot ID="plot3" runat="server" IsVariable="true"&gt;<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting<br>
			Renderer="DateAxisRenderer"<br>
			TickRendererSetting-FormatString="%y-%#m-%#d%n%#I:%#M:%#S %p"<br>
			Ticks="['2011-1-1 1:25:30','2011-1-1 5:4:3','2011-1-1 10:2','2011-1-1 23:22:00']"&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
<br>
	...<br>
&lt;/je:Plot&gt;<br>
</code></pre>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotdateaxis3.jpg' /></blockquote>

<blockquote>更多格式如下:<br>
<pre><code>// 年<br>
%Y		2008<br>
%y		08<br>
<br>
// 月<br>
%m		09<br>
%#m		9<br>
%B		September<br>
%b		Sep<br>
<br>
// 日<br>
%d		05<br>
%#d		5<br>
%e		5<br>
%A		Sunday<br>
%a		Sun<br>
%w		0, 0 表示星期天, 6 表示星期六<br>
%o		th, 跟随在日后的字符串<br>
<br>
// 时<br>
%H		23<br>
%#H		3<br>
%I			11<br>
%#I		3<br>
%p		PM, 显示 AM 或者 PM<br>
<br>
// 分<br>
%M		09<br>
%#M		9<br>
<br>
// 秒<br>
%S		02<br>
%#S		2<br>
%s		1206567625723, 与 1970-01-01 00:00:00 相差的秒数<br>
<br>
// 毫秒<br>
%N		008<br>
%#N		8<br>
<br>
// 时区<br>
%O		360, 本地与 GMT 之间相差的分钟数<br>
%Z		Mountain Standard Time, 时区名称<br>
%G		-06:00, GMT 时间<br>
<br>
// 组合<br>
%F		2008-03-26, %Y-%m-%d<br>
%T		05:06:30, %H:%M:%S<br>
%X		05:06:30, %H:%M:%S<br>
%x		03/26/08, %m/%d/%y<br>
%D		03/26/08, %m/%d/%y<br>
%#c		Wed Mar 26 15:31:00 2008, %a %b %e %H:%M:%S %Y<br>
%v		3-Sep-2008, %e-%b-%Y<br>
%R		15:31, %H:%M<br>
%r		3:31:00 PM, %I:%M:%S %p<br>
<br>
// 特殊字符<br>
%n		\n, 换行<br>
%t		\t, 制表符<br>
%%		%, 百分号<br>
</code></pre></blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementPlotDoc.md'>Plot 完全参考</a></blockquote>

<blockquote><a href='JEPlotAxisGrid.md'>Plot 轴和网格</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

</font>
#summary Plot 光标位置和放大图表
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JEPlotCursor'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /plot/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/9XXZDJUs7wo/'>www.tudou.com/programs/view/9XXZDJUs7wo/</a></blockquote>

<blockquote>本文将详细的讲解如何设置 Plot 图表的光标和放大图表, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>所需脚本<br>
</li><li>光标<br>
<ul><li>位置和样式<br>
</li><li>跟随鼠标<br>
</li><li>显示垂直和水平线<br>
</li></ul></li><li>放大<br>
<ul><li>约束<br>
</li><li>恢复原图</li></ul></li></ul>

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementPlotDoc.md'>Plot 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>所需脚本</h3>
<blockquote>需要在页面中引用光标所需的脚本, 比如:<br>
<pre><code>&lt;script type="text/javascript"<br>
	src="js/plugins/jqplot.cursor.min.js"&gt;<br>
&lt;/script&gt;<br>
</code></pre>
如果使用 ResourceLoader 来加载脚本, 则需要配置 web.config 并设置 ResourceLoader 的 JQPlotCursor 属性为 true, 比如:<br>
<pre><code>&lt;appSettings&gt;<br>
	...<br>
<br>
	&lt;add key="je.jqplot.Cursor.js"<br>
		value="~/js/plugins/jqplot.cursor.min.js"/&gt;<br>
&lt;/appSettings&gt;<br>
</code></pre></blockquote>

<pre><code>&lt;je:ResourceLoader ID="resource" runat="server"<br>
	JQPlotCursor="true" /&gt;<br>
</code></pre>
<blockquote>而更多关于 ResourceLoader 的内容, 可以参考 <a href='ResourceLoader.md'>自动添加脚本和样式</a>.</blockquote>

<h3>光标</h3>
<blockquote>只需要设置 CursorSetting 的 Show 属性为 true, 即可以在图表中显示光标:<br>
<pre><code>&lt;je:Plot ID="plot1" runat="server" IsVariable="true"<br>
	Data="[[['2012-1-31',1],['2012-2-1',2],['2012-2-2',4],['2012-2-3',8]]]"&gt;<br>
<br>
	&lt;CursorSetting Show="true" /&gt;<br>
<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting<br>
			Renderer="DateAxisRenderer"<br>
			TickRendererSetting-FormatString="%Y-%#m-%#d"&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotcursor1.jpg' /></blockquote>

<blockquote><h4><font color='green'>位置和样式</font></h4>
通过 CursorSetting 的 ToolTipLocation 和 ToolTipOffset 属性可以控制提示的位置, Style 属性则表示光标的样式:<br>
<pre><code>&lt;je:Plot ID="plot2" runat="server" IsVariable="true"<br>
	Data="[[[1,1],[2,2],[2,4],[3,8]]]"&gt;<br>
	&lt;CursorSetting<br>
		Show="true"<br>
		ToolTipLocation="ne"<br>
		ToolTipOffset="20"<br>
		Style="pointer" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
Style 的值对应了 CSS 样式中 cursor 的值.</blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotcursor2.jpg' /></blockquote>

<blockquote><h4><font color='green'>跟随鼠标</font></h4>
设置 FollowMouse 属性为 true, 则位置信息跟随鼠标移动:<br>
<pre><code>&lt;je:Plot ID="plot3" runat="server" IsVariable="true"<br>
	Data="[[[1,1],[2,2],[2,4],[3,8]]]"&gt;<br>
	&lt;CursorSetting<br>
		Show="true"<br>
		FollowMouse="true" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotcursor3.jpg' /></blockquote>

<blockquote><h4><font color='green'>显示垂直和水平线</font></h4>
设置 ShowHorizontalLine, ShowVerticalLine 属性为 true, 则分别显示水平和垂直线:<br>
<pre><code>&lt;je:Plot ID="plot4" runat="server" IsVariable="true"<br>
	Data="[[[4,2],[2,5],[3,2],[2,8]]]"&gt;<br>
	&lt;CursorSetting Show="true"<br>
		ShowHorizontalLine="true"<br>
		ShowVerticalLine="true" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotcursor4.jpg' /></blockquote>

<h3>放大</h3>
<blockquote>只需要设置 Zoom 属性为 true, 即可以完整放大图表的功能:<br>
<pre><code>&lt;je:Plot ID="plot5" runat="server" IsVariable="true"&gt;<br>
	<br>
	&lt;CursorSetting Show="true" Zoom="true" /&gt;<br>
<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting TickRendererSetting-FormatString="%d"&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre>
用鼠标选中某个区域, 该区域就会被放大.</blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotcursor5.jpg' /></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotcursor51.jpg' /></blockquote>

<blockquote>另外, 上面例子中的数据是通过后台代码添加的:<br>
<pre><code>// ...<br>
<br>
using zoyobar.shared.panzer.web.jqueryui.plusin.jqplot;<br>
<br>
public partial class plot_Cursor1 : System.Web.UI.Page<br>
{<br>
<br>
	protected void Page_Load ( object sender, EventArgs e )<br>
	{<br>
		Data data = new Data ( );<br>
<br>
		for ( int x = 1; x &lt;= 12; x++ )<br>
			data.AppendPoint ( new Point ( x, x * x ) );<br>
<br>
		this.plot5.AppendData ( data );<br>
	}<br>
<br>
}<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>约束</font></h4>
通过设置 ConstrainZoomTo 属性, 可以限制只能在 x 或者 y 轴上放大:<br>
<pre><code>&lt;je:Plot ID="plot6" runat="server" IsVariable="true"<br>
	Data="[[['2012-1-1',1],['2012-1-2',4],['2012-1-3',9]]]"&gt;<br>
<br>
	&lt;CursorSetting<br>
		Show="true"<br>
		Zoom="true"<br>
		ConstrainZoomTo="x" /&gt;<br>
	<br>
	&lt;AxesSetting&gt;<br>
		&lt;XAxisSetting Renderer="DateAxisRenderer"&gt;<br>
		&lt;/XAxisSetting&gt;<br>
	&lt;/AxesSetting&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<blockquote><img src='http://zsharedcode.googlecode.com/files/plotcursor6.jpg' /></blockquote>

<blockquote><h4><font color='green'>恢复原图</font></h4>
在默认情况下, 双击图表可以恢复原图, 但可以设置 ClickReset 为 true, 这样单击就可以恢复原图:<br>
<pre><code>&lt;je:Plot ID="plot7" runat="server" IsVariable="true"<br>
	Data="[[[1,2],[3,4],[5,6]]]"&gt;<br>
	&lt;CursorSetting<br>
		Show="true"<br>
		Zoom="true"<br>
		ClickReset="true" /&gt;<br>
&lt;/je:Plot&gt;<br>
</code></pre></blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementPlotDoc.md'>Plot 完全参考</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

</font>
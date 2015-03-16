#summary Repeater 排序
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JERepeaterSorting'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /repeater/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/M6aS81RVlCw/'>www.tudou.com/programs/view/M6aS81RVlCw/</a></blockquote>

<blockquote>本文将详细的讲解如何在 Repeater 中根据字段对数据排序, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>调用 togglesort 函数<br>
</li><li>对多个字段排序<br>
</li><li>在服务器端排序<br>
</li><li>显示排序状态</li></ul>

<img src='http://zsharedcode.googlecode.com/files/personlist1.jpg' />

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>调用 togglesort 函数</h3>
<blockquote>一般情况下, 会通过点击表头的字段标题来完成排序, 因此可以在 HeaderTemplate 中调用 togglesort 函数:<br>
<pre><code>&lt;je:Repeater ID="personList" runat="server"	...	&gt;<br>
	&lt;HeaderTemplate&gt;<br>
		&lt;thead je-class="{header}"&gt;<br>
			&lt;tr&gt;<br>
				&lt;td je-onclick="togglesort,'realname'"&gt;<br>
					姓名<br>
				&lt;/td&gt;<br>
				&lt;td je-onclick="togglesort,'age'"&gt;<br>
					年龄<br>
				&lt;/td&gt;<br>
				&lt;td je-onclick="togglesort,'birthday'"&gt;<br>
					出生日期<br>
				&lt;/td&gt;<br>
			&lt;/tr&gt;<br>
		&lt;/thead&gt;<br>
	&lt;/HeaderTemplate&gt;<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
在示例中, 通过 je-onclick 来设置在 td 被点击时调用 togglesort 函数, togglesort 表示切换字段的排序状态, 切换的顺序为 asc, desc, none. 此外, 还需要指定被切换的字段, 也就是跟随在 togglesort 后的第一个参数.</blockquote>

<blockquote>另外, togglesort 函数将从服务器端重新获取数据, 所以不需要再调用 fill 函数.</blockquote>

<h3>对多个字段排序</h3>
<blockquote>默认情况下, 当点击一个不同的字段时, 之前排序的字段的排序状态会消失. 如果希望按照多个字段来排序, 则可以在点击字段时按住 Ctrl 建.</blockquote>

<h3>在服务器端排序</h3>
<blockquote>服务器端的方法可以接收到一个名为 order 的参数, 其中包含了有关排序的信息:<br>
<pre><code>public void ProcessRequest ( HttpContext context )<br>
{<br>
	context.Response.ContentType = "text/javascript";<br>
	context.Response.Cache.SetNoStore ( );<br>
<br>
	int pageindex = 1;<br>
	int pagesize = 3;<br>
<br>
	if ( null != context.Request["pageindex"] )<br>
		int.TryParse ( context.Request["pageindex"], out pageindex );<br>
<br>
	if ( null != context.Request["pagesize"] )<br>
		int.TryParse ( context.Request["pagesize"], out pagesize );<br>
<br>
	int beginIndex = pagesize * ( pageindex - 1 ) + 1;<br>
	int endIndex = pagesize * pageindex;<br>
<br>
	string order = context.Request["__order"];<br>
	// "realname asc, age desc"<br>
<br>
	// 返回 JSON 的代码<br>
}<br>
</code></pre>
上面的代码中, 使用了一般处理程序来返回 JSON 数据, 通过 Request 对象获取了 order 参数. 关于如何返回 JSON, 请参考 <a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a>.</blockquote>

<h3>显示排序状态</h3>
<blockquote>除了排序, 一般还要显示字段的排序状态, 比如用上箭头表示升序:<br>
<pre><code>&lt;je:Repeater ID="personList" runat="server"<br>
Selector="#list" IsVariable="true"<br>
PageSize="3" FillAsync-Url="person.ashx"&gt;<br>
&lt;HeaderTemplate&gt;<br>
	&lt;thead je-class="{header}"&gt;<br>
		&lt;tr&gt;<br>
<br>
			&lt;td je-onclick="togglesort,'realname'"&gt;<br>
				姓名<br>
&lt;span je-class="{sort,realname,,asc-arrow icon,desc-arrow icon}"&gt;<br>
&lt;/span&gt;<br>
			&lt;/td&gt;<br>
<br>
		&lt;/tr&gt;<br>
	&lt;/thead&gt;<br>
&lt;/HeaderTemplate&gt;<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
可以使用 je-class 来根据排序状态显示不同的样式, 语法为: <b><code>{sort,&lt;排序字段&gt;[,&lt;无排序样式&gt;[,&lt;升序样式&gt;[,&lt;降序样式&gt;]]]}</code></b>.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a></blockquote>

<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

</font>
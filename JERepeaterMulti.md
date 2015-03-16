#summary Repeater 多行操作
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JERepeaterMulti'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /repeater/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/ONIARMEopOE/'>www.tudou.com/programs/view/ONIARMEopOE/</a></blockquote>

<blockquote>本文将详细的讲解如何在 Repeater 中进行多行操作和显示进度, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>设置 MultipleSelect 属性<br>
</li><li>调用 toggleselect 函数<br>
</li><li>调用 selectall 函数<br>
</li><li>对多个行操作<br>
</li><li>获取进度</li></ul>

<img src='http://zsharedcode.googlecode.com/files/emaillist1.jpg' />

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>设置 MultipleSelect 属性</h3>
<blockquote>Repeater 的 MultipleSelect 属性表示是否可以选中多个行, 默认为 true. 如果设置为 false, 则同时只能有一行处于选中状态.</blockquote>

<h3>调用 toggleselect 函数</h3>
<blockquote>在 Repeater 的行模板中, 将 je-onclick 设置为 toggleselect, 可以为当前行切换选中状态:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="checkbox" je-checked="selected" je-onclick="toggleselect,false" /&gt;<br>
		&lt;/td&gt;<br>
<br>
	&lt;/tr&gt;<br>
&lt;/ItemTemplate&gt;<br>
</code></pre>
上面的代码中, toggleselect 后跟随了一个布尔类型的参数, 该参数默认为 true, 表示取消前一行的选中状态, 而这里设置为 false, 表示可以选中多个行. 这里并不和 MultipleSelect 属性冲突.</blockquote>

<blockquote>此外, 也可以对某一行调用 select, unselect 函数, 分别选中, 取消选中一行.</blockquote>

<h3>调用 selectall 函数</h3>
<blockquote>通常, 在尾模板中, 会添加全选按钮:<br>
<pre><code>&lt;FooterTemplate&gt;<br>
	&lt;tfoot&gt;<br>
	&lt;tr&gt;<br>
		&lt;td colspan="4"&gt;<br>
		&lt;a href="#" je-onclick="selectall"&gt;全选&lt;/a&gt;<br>
		&lt;a href="#" je-onclick="unselectall"&gt;全不选&lt;/a&gt;<br>
		&lt;a href="#" je-onclick="toggleselectall"&gt;反选&lt;/a&gt;<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
	&lt;/tfoot&gt;<br>
&lt;/FooterTemplate&gt;<br>
</code></pre>
将 je-onclick 设置为 selectall, 则在点击该链接时, 将选中所有的行.</blockquote>

<blockquote>此外, 也可以设置为 unselectall, toggleselectall, 分别表示取消选中所有的行, 切换所有行的选中状态.</blockquote>

<h3>对多个行操作</h3>
<blockquote>Repeater 支持使用 removeselected 和 customselected 函数来进行多行的操作:<br>
<pre><code>&lt;je:Repeater ID="emailRepeater" runat="server" Selector="#list"<br>
	CustomAsync-Url="webservice.asmx"<br>
	CustomAsync-MethodName="CustomEMail"<br>
	...	&gt;<br>
&lt;FooterTemplate&gt;<br>
	&lt;tfoot&gt;<br>
	&lt;tr&gt;<br>
		&lt;td colspan="4"&gt;<br>
		&lt;a href="#" je-onclick="customselected,'spam'"&gt;选中的都是垃圾&lt;/a&gt;<br>
		&lt;a href="#" je-onclick="customselected,'unspam'"&gt;选中的不是垃圾&lt;/a&gt;<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
	&lt;/tfoot&gt;<br>
&lt;/FooterTemplate&gt;<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
在上面的示例中, 调用了 customselected 来对选中的行来执行自定义操作, 自定义操作的名称是 spam, unspam. 自定义操作将调用 webservice.asmx 的 CustomEMail 方法:<br>
<pre><code>[WebMethod]<br>
[ScriptMethod]<br>
public SortedDictionary&lt;string, object&gt; CustomEMail ( int id, string no, bool isspam, string command )<br>
{<br>
	this.Context.Response.Cache.SetNoStore ( );<br>
<br>
	if ( command == "spam" )<br>
	{<br>
		isspam = true;<br>
		Thread.Sleep ( 1000 );<br>
	}<br>
	else if ( command == "unspam" )<br>
	{<br>
		isspam = false;<br>
		Thread.Sleep ( 1000 );<br>
	}<br>
	else if ( command == "togglespam" )<br>
		isspam = !isspam;<br>
<br>
	// 返回 JSON<br>
}<br>
</code></pre>
在 CustomEMail 方法中, 使用了 Thread 类的 Sleep 方法来延长执行的时间, 这样才可以在页面上看到执行的进度.</blockquote>

<h3>获取进度</h3>
<blockquote>可以将 SubStepping 属性设置为获取进度的 javascript 函数:<br>
<pre><code>&lt;je:Repeater ID="emailRepeater" runat="server" Selector="#list" PageSize="5" IsVariable="true"<br>
	...<br>
	CustomAsync-Url="webservice.asmx"<br>
	CustomAsync-MethodName="CustomEMail"<br>
	PreSubStep="<br>
	function(pe, e){<br>
		pb.progressbar('option', 'value', 0).show();<br>
	}<br>
	" SubStepping="<br>
	function(pe, e){<br>
		pb.progressbar('option', 'value', (100 * e.substep.completed / e.substep.count));<br>
		emailRepeater.__repeater('showtip', '完成 ' + e.substep.completed + ' 个');<br>
	}<br>
	" SubStepped="<br>
	function(pe, e){<br>
		pb.hide();<br>
	}<br>
	"&gt;<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
在 SubStepping 中, 参数 e 拥有一个名为 substep 的属性, 而 substep 的 count 属性表示总行数, completed 属性表示已经完成的行数. 此外, 通过 <b>repeater</b> 的 showtip 方法, 显示了进度的消息. 关于如何显示消息, 可以参考 <a href='JERepeaterShowTip.md'>Repeater 消息提示</a>.</blockquote>

<blockquote>PreSubStep 表示多行操作开始之前, SubStepped 表示多行操作结束之后.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JERepeaterShowTip.md'>Repeater 消息提示</a></blockquote>

<blockquote><a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

</font>
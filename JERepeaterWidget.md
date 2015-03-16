#summary Repeater 处理控件
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JERepeaterWidget'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /repeater/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/jiuV1nkeWNo/'>www.tudou.com/programs/view/jiuV1nkeWNo/</a></blockquote>

<blockquote>本文将详细的讲解 Repeater 控件的模板中如何处理控件, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>html 元素<br>
<ul><li>文本框<br>
</li><li>下拉框<br>
</li><li>多行文本框<br>
</li><li>复选框<br>
</li></ul></li><li>jQueryUI 插件<br>
<ul><li>jQueryUI 日期框<br>
</li><li>jQueryUI 按钮<br>
</li><li>jQueryUI 自动匹配</li></ul></li></ul>

<img src='http://zsharedcode.googlecode.com/files/widget1.jpg' />

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>html 元素</h3>
<blockquote>可以在模板中使用 html 文本框或者下拉框, 并进行赋值和读取数据.</blockquote>

<blockquote><h4><font color='green'>文本框</font></h4>
文本框可以用于编辑字段, 也可以配合 je-datepicker, je-autocomplete 创建日期框, 自动匹配.<br>
<pre><code>&lt;input je-id="&lt;字段名&gt;" type="text" value="&lt;绑定字段&gt;"&gt;<br>
<br>
&lt;je:Repeater ID="pictureRepeater" runat="server"<br>
	...	&gt;<br>
<br>
	&lt;EditItemTemplate&gt;<br>
<br>
		&lt;input je-id="realname" type="text" value="#{realname}" /&gt;<br>
<br>
	&lt;/EditItemTemplate&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
通过在 input 中添加 <b><code>value="#{&lt;绑定字段&gt;}"</code></b> 来设置文本框的值, 而使用 <b><code>je-id="&lt;字段名&gt;"</code></b> 可以让 <b>repeater</b> 在更新或新建行时, 知道该文本框的值对应了该字段.</blockquote>

<blockquote><h4><font color='green'>下拉框</font></h4>
下拉框可用于一些枚举值的编辑, 限制字段只能在指定的值中选择.<br>
<pre><code>&lt;select je-id="&lt;字段名&gt;"&gt;<br>
	&lt;option value="&lt;枚举值1&gt;" je-selected="&lt;布尔值1, 可以是绑定字段或者一个表达式&gt;"&gt;<br>
		&lt;显示值1&gt;<br>
	&lt;/option&gt;<br>
	&lt;option value="&lt;枚举值2&gt;" je-selected="&lt;布尔值2, 可以是绑定字段或者一个表达式&gt;"&gt;<br>
		&lt;显示值2&gt;<br>
	&lt;/option&gt;<br>
&lt;/select&gt;<br>
<br>
&lt;je:Repeater ID="pictureRepeater" runat="server"<br>
	...	&gt;<br>
<br>
	&lt;EditItemTemplate&gt;<br>
<br>
		&lt;select je-id="sex"&gt;<br>
			&lt;option value="true" je-selected="#{sex}"&gt;男&lt;/option&gt;<br>
			&lt;option value="false" je-selected="#{sex,!#}"&gt;女&lt;/option&gt;<br>
		&lt;/select&gt;<br>
<br>
		&lt;select je-id="major"&gt;<br>
			&lt;option value="jsj" je-selected="'#{major}' == 'jsj'"&gt;<br>
				计算机<br>
			&lt;/option&gt;<br>
			&lt;option value="gsgl" je-selected="'#{major}' == 'gsgl'"&gt;<br>
				工商管理<br>
			&lt;/option&gt;<br>
			&lt;option value="hy" je-selected="'#{major}' == 'hy'"&gt;<br>
				汉语<br>
			&lt;/option&gt;<br>
		&lt;/select&gt;<br>
<br>
	&lt;/EditItemTemplate&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
和文本框一样, 下拉框同样通过 je-id 绑定字段名, 在每一个 option 中通过 value 属性设置枚举值, 使用 je-selected 来设置一个返回布尔值的表达式, 如果表达式返回 true, 则该选项处于选中状态.</blockquote>

<blockquote>在上面的代码中, 由于 sex 字段是布尔类型的, 所以可以使用 <code>#{sex}</code> 这样的形式, <code>#{sex,!#}</code> 则是取 sex 字段的反. 也可以像这样 <code>#{major,# == 'jsj'}</code>, 表示 major 字段为 'jsj' 则选项处于选中状态. 还可以使用 <code>'#{major}' == 'jsj'</code> 来完成同样的效果, 但这里的 #{major} 需要用单引号括住.</blockquote>

<blockquote><h4><font color='green'>多行文本框</font></h4>
多行文本框和上面所说的文本框不同的是, 多行文本框使用 textarea 元素.<br>
<pre><code>&lt;textarea je-id="&lt;字段名&gt;"&gt;&lt;绑定字段&gt;&lt;/textarea&gt;<br>
</code></pre>
多行文本框直接将字段绑定为 textarea 的内容.</blockquote>

<blockquote><h4><font color='green'>复选框</font></h4>
复选框经常会用于编辑布尔类型的字段, 比如:<br>
<pre><code>&lt;input je-id="&lt;字段名&gt;" type="checkbox"<br>
	je-checked="&lt;布尔值, 可以是绑定字段或者一个表达式&gt;" /&gt;<br>
<br>
&lt;je:Repeater ID="pictureRepeater" runat="server"<br>
	...	&gt;<br>
<br>
	&lt;EditItemTemplate&gt;<br>
<br>
		&lt;input je-id="sex" type="checkbox" je-checked="#{sex}" /&gt;<br>
<br>
	&lt;/EditItemTemplate&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
上面的代码中, input 元素中设置 type 为 checkbox, 并通过 je-checked 绑定了布尔类型的 sex 字段. sex 为 true, 则复选框处于选中的状态.</blockquote>

<h3>jQueryUI 插件</h3>
<blockquote>在模板中使用 <b><code>je-&lt;jQueryUI 插件名&gt;="&lt;属性名n&gt;=&lt;属性值n&gt;;"</code></b> 的语法来创建 jQueryUI 插件, 其中的属性名和属性值可以参考 <a href='http://jqueryui.com'>jqueryui.com</a>.</blockquote>

<blockquote><h4><font color='green'>jQueryUI 日期框</font></h4>
日期框用于绑定编辑日期类型的字段:<br>
<pre><code>&lt;input je-id="&lt;字段名&gt;" je-datepicker="&lt;属性名n&gt;=&lt;属性值n&gt;;"<br>
	type="text" value="&lt;日期值&gt;" /&gt;<br>
<br>
&lt;je:Repeater ID="pictureRepeater" runat="server"<br>
	...	&gt;<br>
<br>
	&lt;EditItemTemplate&gt;<br>
<br>
		&lt;input je-id="birthday" je-datepicker="dateFormat='yy-mm-dd'"<br>
			type="text"<br>
			value="#{birthday,jQuery.panzer.formatDate(#,'yyyy-MM-dd')}" /&gt;<br>
<br>
	&lt;/EditItemTemplate&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
代码中 dateFormat 属性设置了日期框的日期格式, 可以设置更多的属性, 多个属性使用 ; 号分隔即可. 日期框的值绑定为字段 birthday, 不过日期使用了 jQuery.panzer.formatDate 函数来格式化日期的输出, 而这里的格式化形式类似于 .NET.</blockquote>

<blockquote><h4><font color='green'>jQueryUI 按钮</font></h4>
按钮通常用于执行一些命令:<br>
<pre><code>&lt;span je-button="&lt;属性名n&gt;=&lt;属性值n&gt;;" je-onclick="&lt;行为名&gt;"&gt;&lt;/span&gt;<br>
<br>
&lt;je:Repeater ID="pictureRepeater" runat="server"<br>
	...	&gt;<br>
<br>
	&lt;span je-button="label='保存';" je-onclick="update"&gt;&lt;/span&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
可以使用 span 元素来作为按钮, 也可以使用 input 元素. 在属性中 label 作为按钮的文本, 也可以将文本直接作为 span 元素的内容. 而常用的行为有 beginedit, endedit, update, insert, remove, next, prev, goto.</blockquote>

<blockquote><h4><font color='green'>jQueryUI 自动匹配</font></h4>
jQueryUI 的 autocomplete 插件可以在用户输入文字时, 自动匹配到相应的条目:<br>
<pre><code>&lt;input je-id="&lt;字段名&gt;" je-autocomplete="&lt;属性名n&gt;=&lt;属性值n&gt;;"<br>
	value="&lt;当前值&gt;" /&gt;<br>
<br>
&lt;je:Repeater ID="pictureRepeater" runat="server"<br>
	...	&gt;<br>
<br>
	&lt;input je-id="major" je-autocomplete="source=['jsj','gsgl','hy']"<br>
		value="#{major}" /&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
autocomplete 的 source 属性为用于匹配的条目的数组.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

</font>
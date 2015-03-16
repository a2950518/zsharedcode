#summary Repeater 消息提示
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JERepeaterShowTip'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /repeater/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/f44DaiWHcGE/'>www.tudou.com/programs/view/f44DaiWHcGE/</a></blockquote>

<blockquote>本文将详细的讲解如何在 Repeater 中提示消息, 比如数据下载成功, 字段内容不符合要求, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>设置 TipTemplate<br>
</li><li>调用 showtip 函数<br>
</li><li>设置 FieldMask 属性<br>
</li><li>消息的时效性</li></ul>

<img src='http://zsharedcode.googlecode.com/files/manageorder1.jpg' />

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>设置 TipTemplate</h3>
<blockquote>如果希望 <b>repeater</b> 可以显示一些提示信息, 则首先需要设置 TipTemplate 模板:<br>
<pre><code>&lt;TipTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td colspan="6" class="tip"&gt;<br>
		@{tip,'第 ' + (++tipCount).toString() + ' 条消息:' + @}<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/TipTemplate&gt;<br>
</code></pre>
代码中, 使用了 <b><code>@{&lt;属性名&gt;[,&lt;属性表达式&gt;]}</code></b> 来绑定属性 tip, tip 表示需要显示文本. 这和字段的绑定是类似, 不同的是 # 表示字段, 而 @ 表示属性, 可以参考 <a href='JERepeaterBindField.md'>Repeater 绑定/处理字段</a>. tip 的内容可能是来自于 showtip 函数, 也可能来自于 FieldMask 属性.</blockquote>

<h3>调用 showtip 函数</h3>
<blockquote>通过 <b><code>&lt;repeater 变量&gt;.__repeater('showtip', '&lt;提示消息&gt;')</code></b> 可以让 <b>repeater</b> 显示提示消息:<br>
<pre><code>&lt;je:Repeater ID="orderList" runat="server"<br>
	...<br>
Filled="<br>
function(pe, e){<br>
	orderList.__repeater('showtip', e.custom.message);<br>
}<br>
" PreUpdate="<br>
function(pe, e){<br>
	orderList.__repeater('showtip', '提交数据...');<br>
}<br>
" Updated="<br>
function(pe, e){<br>
<br>
	if(e.issuccess)<br>
		orderList.__repeater('showtip',<br>
		'修改了序号为 ' + e.row.id.toString() +<br>
		' 的订单, 目前总金额 ' + e.row.sum.toString());<br>
	else<br>
		orderList.__repeater('showtip',<br>
		'修改序号为 ' + e.row.id.toString() +<br>
		' 的订单失败');<br>
<br>
}<br>
" PreInsert="<br>
function(pe, e){<br>
	orderList.__repeater('showtip', '提交数据...');<br>
}<br>
" Inserted="<br>
function(pe, e){<br>
<br>
	if(e.issuccess)<br>
		orderList.__repeater('showtip',<br>
		'新建了序号为 ' + e.row.id.toString() +<br>
		' 的订单, 目前总金额 ' + e.row.sum.toString());<br>
	else<br>
		orderList.__repeater('showtip',<br>
		'新建序号为 ' + e.row.id.toString() +<br>
		' 的订单失败');<br>
<br>
}<br>
"&gt;<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
上面的示例中, 多处调用了 showtip 函数, 并传递需要显示的字符串, 在 Filled 属性中, 传递的则是 <code>e.custom.message</code>, 这是来自于服务器返回的消息.</blockquote>

<h3>设置 FieldMask 属性</h3>
<blockquote>FieldMask 本来是用于验证字段的, 但由于 FieldMask 中包含了错误提示, 所以 <b>repeater</b> 会在字段验证错误时, 显示这些提示:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	var mask = {<br>
		amount: {<br>
			type: 'number',<br>
			need: true,<br>
			max: 10,<br>
			min: 1,<br>
			tip: '数量需要在 1-10 之间'<br>
		},<br>
		price: {<br>
			type: 'number',<br>
			need: true,<br>
			max: 10000,<br>
			min: 1000,<br>
			tip: {<br>
				type: '单价是一个数字',<br>
				need: '请填写单价',<br>
				max: '单价不能超出 10000',<br>
				min: '单价不能小于 1000'<br>
			}<br>
		},<br>
		buyer: {<br>
			type: 'string',<br>
			need: true,<br>
			max: 10,<br>
			min: 3,<br>
			tip: '购买者长度需要在 3-10 之间'<br>
		},<br>
		address: {<br>
			type: 'string',<br>
			min: 1,<br>
			max: 100,<br>
			tip: '地址不能为空, 长度不能大于 100'<br>
		},<br>
		orderdate: {<br>
			type: 'date',<br>
			tip: '需要一个合法的日期'<br>
		},<br>
		iscompleted: {<br>
			type: 'boolean',<br>
			defaultvalue: false<br>
		}<br>
	};<br>
&lt;/script&gt;<br>
<br>
&lt;je:Repeater ID="orderList" runat="server"<br>
	...<br>
	FieldMask="mask"<br>
	...	&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
代码中, FieldMask 被赋值为 mask 变量, 而 mask 中包含了用于验证的规则, 可以参考 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 的设置字段一节.</blockquote>

<blockquote>mask 中的 tip 可以是一个字符串, 表示验证失败的提示, 也可以是一个对象, 包含更具体的提示消息.</blockquote>

<blockquote>而消息的提示是有 <b>repeater</b> 自动完成的, 前提是设置了有效的 TipTemplate.</blockquote>

<h3>消息的时效性</h3>
<blockquote>当需要显示新的消息, 或者 <b>repeater</b> 重新绑定数据时, 原有的消息将被替换或隐藏. 编辑行, 跳转到下一页, 调用 fill 方法都可以使 <b>repeater</b> 重新绑定数据.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JERepeaterBindField.md'>Repeater 绑定/处理字段</a></blockquote>

<blockquote><a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

</font>
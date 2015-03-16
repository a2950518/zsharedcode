﻿#summary Repeater 消息提示
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
<pre><code>&lt;TipTemplate&gt;
	&lt;tr&gt;
		&lt;td colspan="6" class="tip"&gt;
		@{tip,'第 ' + (++tipCount).toString() + ' 条消息:' + @}
		&lt;/td&gt;
	&lt;/tr&gt;
&lt;/TipTemplate&gt;
</code></pre>
代码中, 使用了 <b><code>@{&lt;属性名&gt;[,&lt;属性表达式&gt;]}</code></b> 来绑定属性 tip, tip 表示需要显示文本. 这和字段的绑定是类似, 不同的是 # 表示字段, 而 @ 表示属性, 可以参考 <a href='JERepeaterBindField.md'>Repeater 绑定/处理字段</a>. tip 的内容可能是来自于 showtip 函数, 也可能来自于 FieldMask 属性.</blockquote>

<h3>调用 showtip 函数</h3>
<blockquote>通过 <b><code>&lt;repeater 变量&gt;.__repeater('showtip', '&lt;提示消息&gt;')</code></b> 可以让 <b>repeater</b> 显示提示消息:<br>
<pre><code>&lt;je:Repeater ID="orderList" runat="server"
	...
Filled="
function(pe, e){
	orderList.__repeater('showtip', e.custom.message);
}
" PreUpdate="
function(pe, e){
	orderList.__repeater('showtip', '提交数据...');
}
" Updated="
function(pe, e){

	if(e.issuccess)
		orderList.__repeater('showtip',
		'修改了序号为 ' + e.row.id.toString() +
		' 的订单, 目前总金额 ' + e.row.sum.toString());
	else
		orderList.__repeater('showtip',
		'修改序号为 ' + e.row.id.toString() +
		' 的订单失败');

}
" PreInsert="
function(pe, e){
	orderList.__repeater('showtip', '提交数据...');
}
" Inserted="
function(pe, e){

	if(e.issuccess)
		orderList.__repeater('showtip',
		'新建了序号为 ' + e.row.id.toString() +
		' 的订单, 目前总金额 ' + e.row.sum.toString());
	else
		orderList.__repeater('showtip',
		'新建序号为 ' + e.row.id.toString() +
		' 的订单失败');

}
"&gt;
&lt;/je:Repeater&gt;
</code></pre>
上面的示例中, 多处调用了 showtip 函数, 并传递需要显示的字符串, 在 Filled 属性中, 传递的则是 <code>e.custom.message</code>, 这是来自于服务器返回的消息.</blockquote>

<h3>设置 FieldMask 属性</h3>
<blockquote>FieldMask 本来是用于验证字段的, 但由于 FieldMask 中包含了错误提示, 所以 <b>repeater</b> 会在字段验证错误时, 显示这些提示:<br>
<pre><code>&lt;script type="text/javascript"&gt;
	var mask = {
		amount: {
			type: 'number',
			need: true,
			max: 10,
			min: 1,
			tip: '数量需要在 1-10 之间'
		},
		price: {
			type: 'number',
			need: true,
			max: 10000,
			min: 1000,
			tip: {
				type: '单价是一个数字',
				need: '请填写单价',
				max: '单价不能超出 10000',
				min: '单价不能小于 1000'
			}
		},
		buyer: {
			type: 'string',
			need: true,
			max: 10,
			min: 3,
			tip: '购买者长度需要在 3-10 之间'
		},
		address: {
			type: 'string',
			min: 1,
			max: 100,
			tip: '地址不能为空, 长度不能大于 100'
		},
		orderdate: {
			type: 'date',
			tip: '需要一个合法的日期'
		},
		iscompleted: {
			type: 'boolean',
			defaultvalue: false
		}
	};
&lt;/script&gt;

&lt;je:Repeater ID="orderList" runat="server"
	...
	FieldMask="mask"
	...	&gt;

&lt;/je:Repeater&gt;
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
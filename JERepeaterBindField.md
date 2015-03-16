#summary Repeater 绑定/处理字段
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JERepeaterBindField'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /repeater/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/rwruM87J20s/'>www.tudou.com/programs/view/rwruM87J20s/</a></blockquote>

<blockquote>本文将详细的讲解 Repeater 控件中如何绑定和处理字段, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>使用范围<br>
</li><li>简单绑定<br>
</li><li>转换绑定<br>
</li><li>格式化日期字段<br>
</li><li>使用 jQuery 代替 $<br>
</li><li>根据字段设置样式</li></ul>

<img src='http://zsharedcode.googlecode.com/files/booklist1.jpg' />

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>使用范围</h3>
<blockquote>可以在 ItemTemplate/UpdatedItemTemplate/InsertedItemTemplate/RemovedItemTemplate/EditItemTemplate 模板中绑定字段.</blockquote>

<blockquote>可以将字段绑定在标签的属性中或者作为标签的内容.</blockquote>

<h3>简单绑定</h3>
<blockquote>可以使用 <b><code>#{&lt;字段名&gt;}</code></b> 来绑定字段, 比如:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
<br>
	&lt;td&gt;<br>
		#{bookname}<br>
	&lt;/td&gt;<br>
<br>
	&lt;td&gt;<br>
		&lt;strong&gt;评价:&lt;/strong&gt; &lt;span class="rank rank#{rank}"&gt;&lt;/span&gt;<br>
	&lt;/td&gt;<br>
<br>
&lt;/ItemTemplate&gt;<br>
</code></pre>
上面的例子中, 将字段 bookname 绑定为标签的内容, 将 rank 字段绑定在标签的属性 class 中.</blockquote>

<h3>转换绑定</h3>
<blockquote>使用 <b><code>#{&lt;字段名&gt;[,&lt;字段表达式&gt;]}</code></b> 来转换字段中的值, 然后输出, 比如:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
<br>
		&lt;td&gt;<br>
			&lt;strong&gt;折扣:&lt;/strong&gt;<br>
			#{discount,Math.floor(# * 100) / 10} 折<br>
			#{discount,convertDiscount(#)}<br>
		&lt;/td&gt;<br>
<br>
&lt;/ItemTemplate&gt;<br>
</code></pre>
在字段表达式中, 使用 # 号来表示被绑定的字段. 上面代码中的 discount 字段分别通过一个 javascript 表达式和一个函数来转换了字段的值并输出, javascript 函数如下:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	function convertDiscount(discount) {<br>
		return discount &gt;= 0.7 ? '&lt;strong&gt;清仓啦&lt;/strong&gt;' : '减价啦';<br>
	}<br>
&lt;/script&gt;<br>
</code></pre></blockquote>

<h3>格式化日期字段</h3>
<blockquote>对于采用默认参数返回的 JSON, 日期格式的字段的返回值可能类似于 <b><code>"\/Date(xxxxxxxxxx)\/"</code></b> 的字符串, 可以通过 <code>jQuery.panzer.formatDate</code> 函数来格式化日期, 或者使用 <code>jQuery.panzer.convertToDate</code> 将 <b><code>"\/Date(xxxxxxxxxx)\/"</code></b> 格式的字符串转化为日期类型, 例如:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
<br>
	&lt;td&gt;<br>
		&lt;strong&gt;出版日期:&lt;/strong&gt;<br>
		&lt;span class="publishdate"&gt;<br>
		#{publishdate,jQuery.panzer.formatDate(#,'yyyy年M月d号')}<br>
		&lt;/span&gt;<br>
	&lt;/td&gt;<br>
<br>
&lt;/ItemTemplate&gt;<br>
</code></pre>
函数 <code>jQuery.panzer.formatDate</code> 的第一个参数为 Date 类型的 javascript 变量或者格式为 <b><code>"\/Date(xxxxxxxxxx)\/"</code></b> 的字符串. 第二个参数为用于格式化的字符串, 这类似于 .NET 中的 DateTime 类型的 ToString 方法, 例如:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	var date = new Date(2011, 0, 1, 20, 1, 3);<br>
	// 2011 年 1 月 1 号, 20 时 1 分 3 秒<br>
<br>
	$.panzer.formatDate(date,'y年'); // 1年<br>
	$.panzer.formatDate(date,'yy年'); // 11年<br>
	$.panzer.formatDate(date,'yyyy'); // 2011<br>
<br>
	$.panzer.formatDate(date,'M月'); // 1月<br>
	$.panzer.formatDate(date,'MM月'); // 01月<br>
	$.panzer.formatDate(date,'yyyy-MM');<br>
	// 2011-01<br>
<br>
	$.panzer.formatDate(date,'d号'); // 1号<br>
	$.panzer.formatDate(date,'dd号'); // 01号<br>
	$.panzer.formatDate(date,'yyyy-MM-dd');<br>
	// 2011-01-01<br>
<br>
	$.panzer.formatDate(date,'H时'); // 20时<br>
	$.panzer.formatDate(date,'HH时'); // 20时<br>
	$.panzer.formatDate(date,'yyyy-MM-dd HH');<br>
	// 2011-01-01 20<br>
<br>
	$.panzer.formatDate(date,'h时'); // 8时<br>
	$.panzer.formatDate(date,'hh时'); // 08时<br>
	$.panzer.formatDate(date,'yyyy-MM-dd hh');<br>
	// 2011-01-01 08<br>
<br>
	$.panzer.formatDate(date,'m分'); // 1分<br>
	$.panzer.formatDate(date,'mm分'); // 01分<br>
	$.panzer.formatDate(date,'yyyy-MM-dd hh:mm');<br>
	// 2011-01-01 08:01<br>
<br>
	$.panzer.formatDate(date,'s秒'); // 3秒<br>
	$.panzer.formatDate(date,'ss秒'); // 03秒<br>
	$.panzer.formatDate(date,'yyyy-MM-dd hh:mm:ss');<br>
	// 2011-01-01 08:01:03<br>
&lt;/script&gt;<br>
</code></pre></blockquote>

<h3>使用 jQuery 代替 $</h3>
<blockquote>在字段表达式中应该使用 jQuery 来代替 $, 以防止由于压缩脚本而产生的问题.</blockquote>

<h3>根据字段设置样式</h3>
<blockquote>如果需要根据字段的值来显示不同的样式, 可以将字段绑定在 class 属性中, 比如:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
<br>
	&lt;td&gt;<br>
		&lt;strong&gt;评价:&lt;/strong&gt;<br>
		#{rank}<br>
		&lt;span class="rank rank#{rank}"&gt;&lt;/span&gt;<br>
	&lt;/td&gt;<br>
<br>
&lt;/ItemTemplate&gt;<br>
</code></pre>
在页面开始处定义了一些 rank 的样式:<br>
<pre><code>&lt;style type="text/css"&gt;<br>
	.rank<br>
	{<br>
		background-color: #cc0000;<br>
		height: 15px;<br>
		display: inline-block;<br>
	}<br>
	.rank1<br>
	{<br>
		width: 10px;<br>
	}<br>
	.rank2<br>
	{<br>
		width: 30px;<br>
	}<br>
	.rank3<br>
	{<br>
		width: 50px;<br>
	}<br>
	.rank4<br>
	{<br>
		width: 70px;<br>
	}<br>
	.rank5<br>
	{<br>
		width: 90px;<br>
	}<br>
&lt;/style&gt;<br>
</code></pre>
示例中 rank 字段中可能会是 1 到 5, 因此样式也定义了 rank1 到 rank5.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

</font>
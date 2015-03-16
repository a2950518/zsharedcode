#summary Repeater 检索数据
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JERepeaterSearch'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /repeater/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/HJmCQRpGQEg/'>www.tudou.com/programs/view/HJmCQRpGQEg/</a></blockquote>

<blockquote>本文将详细的讲解如何在 Repeater 中检索数据信息, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>设置 FilterTemplate<br>
</li><li>设置 FilterField 和 FilterFieldDefault<br>
</li><li>调用 setfilter 和 filter 函数</li></ul>

<img src='http://zsharedcode.googlecode.com/files/productlist1.jpg' />

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>设置 FilterTemplate</h3>
<blockquote>在 Repeater 的 FilterTemplate 属性中, 包含用于填写搜索条件的元素, 比如文本框, 日期框等. 此外, 也可以包含搜索按钮:<br>
<pre><code>&lt;je:Repeater ID="productList" runat="server"		...	&gt;<br>
<br>
	&lt;FilterTemplate&gt;<br>
		&lt;tr&gt;<br>
			&lt;td&gt;<br>
				&lt;input type="text" size="10"<br>
					je-id="productname"<br>
					je-value="productname" /&gt;<br>
			&lt;/td&gt;<br>
			&lt;td&gt;<br>
				&lt;input type="text" size="5"<br>
					je-id="model"<br>
					je-value="model" /&gt;<br>
			&lt;/td&gt;<br>
			&lt;td&gt;<br>
				&lt;input type="text" size="4"<br>
					je-id="price1"<br>
					je-value="price1" /&gt;<br>
				-<br>
				&lt;input type="text" size="4"<br>
					je-id="price2"<br>
					je-value="price2" /&gt;<br>
			&lt;/td&gt;<br>
			&lt;td&gt;<br>
				&lt;input type="text" size="3"<br>
					je-id="amount"<br>
					je-value="amount" /&gt;<br>
			&lt;/td&gt;<br>
			&lt;td&gt;<br>
				&lt;input type="text" size="10"<br>
je-datepicker="dateFormat='yy-mm-dd';changeMonth=true;changeYear=true"<br>
					je-id="manufactureDate1"<br>
					je-value="manufactureDate1" /&gt;<br>
				-<br>
				&lt;input<br>
je-datepicker="dateFormat='yy-mm-dd';changeMonth=true;changeYear=true"<br>
					type="text" size="10"<br>
					je-id="manufactureDate2"<br>
					je-value="manufactureDate2" /&gt;<br>
			&lt;/td&gt;<br>
		&lt;/tr&gt;<br>
		&lt;tr je-class="{highlight}"&gt;<br>
			&lt;td colspan="5" align="right"&gt;<br>
				&lt;span je-button=";" onclick="javascript:clearCondition();"&gt;清空&lt;/span&gt;<br>
				&lt;span je-button=";" je-onclick="filter"&gt;搜索&lt;/span&gt;<br>
			&lt;/td&gt;<br>
		&lt;/tr&gt;<br>
	&lt;/FilterTemplate&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
代码中, 使用了 input 元素来添加文本框和日期框, 通过 je-id 来与 FilterField 属性中的搜索字段关联, je-value 则是表示使用指定搜索条件来初始化.</blockquote>

<blockquote>上面还使用了 je-datepicker 创建日期框, 至于如何使用 <b><code>je-&lt;jQueryUI 插件名&gt;</code></b> 创建更多 jQueryUI 插件, 可以参考 <a href='JERepeaterWidget.md'>Repeater 处理控件</a>.</blockquote>

<blockquote>通过 je-button 和 je-onclick, 创建了用于搜索的按钮, je-onclick 被指定为 filter, 也就是将执行 <b>repeater</b> 的 filter 方法, 可以参考 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 的特殊绑定一节.</blockquote>

<h3>设置 FilterField 和 FilterFieldDefault</h3>
<blockquote>在 FilterField 中设置的字段名, 将作为参数传递给服务器端的方法:<br>
<pre><code>&lt;je:Repeater ID="productList" runat="server"<br>
	FilterField="['productname','price1','price2']"<br>
	FilterFieldDefault="['',-1,-1]"<br>
	FillAsync-Url="product.asmx"<br>
	FillAsync-MethodName="GetProductList"&gt;<br>
<br>
	&lt;FilterTemplate&gt;<br>
		&lt;tr&gt;<br>
			&lt;td&gt;<br>
				&lt;input type="text" size="10"<br>
					je-id="productname" je-value="productname" /&gt;<br>
			&lt;/td&gt;<br>
<br>
			&lt;td&gt;<br>
				&lt;input type="text" size="4"<br>
					je-id="price1" je-value="price1" /&gt;<br>
				-<br>
				&lt;input type="text" size="4"<br>
					je-id="price2" je-value="price2" /&gt;<br>
			&lt;/td&gt;<br>
<br>
		&lt;/tr&gt;<br>
	&lt;/FilterTemplate&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
代码中, 通过 FilterField 设置了 3 个用于搜索的字段 productname, price1, price2, 并通过 FilterFieldDefault 来设置这些搜索条件的默认值, 因此服务器端方法 GetProductList 可以采用如下的形式:<br>
<pre><code>public SortedDictionary&lt;string, object&gt; GetProductList (<br>
	int pageindex, int pagesize,<br>
	string productname, float price1, float price2 )<br>
{<br>
<br>
		if ( price1 != -1 )<br>
			...<br>
<br>
		if ( price2 != -1 )<br>
			...<br>
<br>
}<br>
</code></pre>
如果 price1 和 price2 等于 -1, 则表示用户没有设置关于价格的搜索条件. 至于服务器端返回数据的格式, 请参考 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 的请求/返回数据的格式一节.</blockquote>

<h3>调用 setfilter 和 filter 函数</h3>
<blockquote>经过上面简单的设置, 已经可以通过 FilterTemplate 中的搜索按钮来检索数据, 此外, 还可以使用另一个方法:<br>
<pre><code>&lt;input id="myproductname" type="text" size="10" /&gt;<br>
<br>
&lt;je:Button ID="cmdSearch" runat="server" Label="搜索 2" Click="<br>
function(){<br>
	productList.__repeater('setfilter', 'productname', $('#myproductname').val());<br>
	productList.__repeater('filter');<br>
}<br>
"&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
上面的示例中, id 为 myproductname 的文本框用来输入搜索的产品名称, 而在按钮的 Click 事件中, 调用 <b>repeater</b> 的 setfilter 方法来将 myproductname 中的值设置到 <b>repeater</b> 的过滤条件中, 调用 filter 方法来检索数据.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

</font>
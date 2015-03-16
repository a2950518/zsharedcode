#summary Repeater 子视图
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JERepeaterSubView'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /repeater/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/uVx2BBMHgOQ/'>www.tudou.com/programs/view/uVx2BBMHgOQ/</a></blockquote>

<blockquote>本文将详细的讲解 Repeater 控件中如何使用子视图, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>定义子视图样本<br>
</li><li>切换子视图状态<br>
</li><li>定义子视图容器</li></ul>

<img src='http://zsharedcode.googlecode.com/files/google.jpg' />

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>定义子视图样本</h3>
<blockquote>显示在 <b>repeater</b> 中的 <b>repeater</b> 被称为子视图, 每一个子视图都是子视图样本的副本, 并根据条件来展示不同的数据. 子视图样本的定义没有特别之处, 比如:<br>
<pre><code>&lt;je:Repeater ID="&lt;子视图 ID&gt;" runat="server"<br>
	FilterField="&lt;子视图搜索字段&gt;"&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
<br>
&lt;je:Repeater ID="pictureRepeater" runat="server"<br>
	FilterField="['url']"<br>
	FillAsync-Url="webservice.asmx"<br>
	FillAsync-MethodName="GetGooglePicture"&gt;<br>
	&lt;ItemTemplate&gt;<br>
		&lt;div&gt;<br>
			&lt;span class="url"&gt;#{url}&lt;/span&gt;<br>
			&lt;br /&gt;<br>
			&lt;br /&gt;<br>
			#{picture}<br>
		&lt;/div&gt;<br>
	&lt;/ItemTemplate&gt;<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
大多数情况下, 需要为子视图样本定义 FilterField 属性, 也就是搜索子视图数据所用到的字段或条件, 上面的代码中, 我们添加了 url 作为条件, 那么后台返回数据的代码可以这样编写:<br>
<pre><code>[WebMethod]<br>
public SortedDictionary&lt;string, object&gt; GetGooglePicture ( string url )<br>
{<br>
	// 返回 JSON<br>
}<br>
</code></pre>
由于, 只返回一行数据, 因此不必添加 pageindex 和 pagesize 参数.</blockquote>

<blockquote>关于如何返回 JSON, 请参考 <a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a>, 本示例所有代码为在 .NET 4.0 下编写.</blockquote>

<h3>切换子视图状态</h3>
<blockquote>如果需要在 Repeater 中控制子视图切换, 关闭和打开, 可以使用 shiftview, collapseview, expandview 三个函数, 比如:<br>
<pre><code>//	je-&lt;javascript 事件名&gt;="shiftview,'&lt;子视图 ID&gt;'[,&lt;子视图搜索字段值n&gt;]"<br>
<br>
&lt;div id="list"&gt;<br>
	&lt;je:Repeater ID="googleRepeater" runat="server"<br>
		Selector="#list" PageSize="2" IsVariable="true"<br>
		FillAsync-Url="webservice.asmx"<br>
		FillAsync-MethodName="SearchGoogle"&gt;<br>
		&lt;ItemTemplate&gt;<br>
<br>
			&lt;div class="picture"&gt;<br>
				&lt;div<br>
					je-button="label='更多';"<br>
					je-onclick="shiftview,'pictureRepeater','#{url}'"&gt;<br>
				&lt;/div&gt;<br>
				&lt;div je-id="pictureRepeater" style="display: none;"&gt;<br>
				&lt;/div&gt;<br>
			&lt;/div&gt;<br>
		<br>
		&lt;/ItemTemplate&gt;<br>
<br>
	&lt;/je:Repeater&gt;<br>
&lt;/div&gt;<br>
</code></pre>
以 shiftview 为例, 第一个参数为子视图的 ID, 之后的参数为用于搜索子视图数据的条件, 示例中将字段 url 作为参数, 对应了子视图样本 FilterField 属性中的 url. 如果有更多的条件, 继续添加即可, 顺序需要和子视图样本 FilterField 属性中条件一样.</blockquote>

<blockquote>expandview 方法和 shiftview 是类似的, 不同的是 expandview 打开子视图, 而 shiftview 是切换子视图的打开状态.</blockquote>

<blockquote>而 collapseview 方法是关闭子视图, 不需要传递条件.</blockquote>

<blockquote>默认情况下, 当子视图首次被打开时, 将自动调用 fill 方法来填充数据, 而之后的打开显示现存的数据, 不再刷新.</blockquote>

<h3>定义子视图容器</h3>
<blockquote>除了定义子视图样本之外, 还需要在行模板中定义子视图容器, 在刚才的代码中, 有这样一段:<br>
<pre><code>// je-id="&lt;子视图 ID&gt;"<br>
<br>
&lt;ItemTemplate&gt;<br>
<br>
	&lt;div class="picture"&gt;<br>
<br>
		&lt;div je-id="pictureRepeater" style="display: none;"&gt;<br>
		&lt;/div&gt;<br>
	&lt;/div&gt;<br>
		<br>
&lt;/ItemTemplate&gt;<br>
</code></pre>
通过 je-id 绑定为子视图 ID, 即可将元素绑定为子视图的容器, 而子视图将显示在目标容器中.</blockquote>

<blockquote>子视图默认为关闭状态, 因此代码中通过 <code>style="display: none;"</code> 使子视图容器在开始时隐藏.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a></blockquote>

<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

</font>
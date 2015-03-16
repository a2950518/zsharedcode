#summary JQueryElement 基本属性参考
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JEBase'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /JQueryElementBase.aspx.</blockquote>

<blockquote>本文将说明 JQueryElement 的主要属性的作用:</blockquote>

<ul><li>JQueryElement 选择器<br>
</li><li>ElementType 属性<br>
</li><li>设置内容<br>
</li><li>IsVariable 属性<br>
</li><li>ScriptPackageID 属性</li></ul>

<h3>JQueryElement 选择器</h3>
<blockquote>JQueryElement 选择器用于设置 JQueryElement 控件的容器, 可以用在 Selector 属性或者 Parameter 的 Value 属性中:<br>
<pre><code>按钮 1 在这里:<br>
&lt;je:Button ID="button1" runat="server" Label="按钮 1"&gt;<br>
&lt;/je:Button&gt;<br>
<br>
按钮 2 在这里: &lt;span id="button2"&gt;&lt;/span&gt;<br>
<br>
&lt;je:Button ID="cmd2" runat="server" Selector="#button2" Label="按钮 2"&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
当没有指定 Selector 属性时, JQueryElement 将选择自身作为容器, 上面示例中的 button1 就选择自身作为容器. 而 cmd2 的 Selector 属性为 #button2, 这是一个标准的 jQuery 选择器, 因此 span 元素成为了按钮 2的容器.</blockquote>

<blockquote>JQueryElement 选择器可以是一个 javascript 表达式, 例如:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	var div = "#button3";<br>
&lt;/script&gt;<br>
<br>
按钮 3 在这里: &lt;div&gt;按钮 div&lt;/div&gt; &lt;span id="button3"&gt;按钮 3&lt;/span&gt;<br>
<br>
&lt;je:Button ID="cmd3" runat="server" Selector="div"&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
Selector 属性被设置为 div, 但并不会被认为是一个 jQuery 选择器, 因为声明了名为 div 的 javascript 变量, 因此变量 div 的值被当作选择器, 而 id 属性为 button3 的 span 元素将作为按钮的容器.</blockquote>

<blockquote>那么, 如何解决这种冲突哪? 将选择器用单引号括住即可:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	var button = "#button4";<br>
&lt;/script&gt;<br>
<br>
按钮 4 在这里: &lt;button&gt;按钮 button&lt;/button&gt; &lt;span id="button4"&gt;按钮 4&lt;/span&gt;<br>
<br>
&lt;je:Button ID="cmd4" runat="server" Selector="'button'"&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
由于在 Selector 属性中使用了单引号, 因此会选择 button 元素作为容器, 而不是 id 属性为 button4 的 span 元素.</blockquote>

<h3>ElementType 属性</h3>
<blockquote>可以通过 ElementType 属性来设置 JQueryElement 控件的元素名称:<br>
<pre><code>&lt;je:Button ID="buttonSpan" runat="server" Label="按钮 span"&gt;<br>
&lt;/je:Button&gt;<br>
<br>
&lt;je:Button ID="buttonDiv" runat="server" ElementType="Div" Label="按钮 div"&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
Button 控件默认使用 span, 示例中, 将按钮 buttonDiv 的 ElementType 设置为 Div, 因此 buttonDiv 的容器将是 div 元素.</blockquote>

<h3>设置内容</h3>
<blockquote>可以通过 Html, Text, ContentTemplate 来设置 JQueryElement 控件的内容:<br>
<pre><code>&lt;je:Button ID="buttonText" runat="server" Text="按钮 text"&gt;<br>
&lt;/je:Button&gt;<br>
<br>
<br>
&lt;je:Button ID="buttonHtml" runat="server" Html="&lt;strong&gt;按钮 &lt;font color='red'&gt;html&lt;/font&gt;&lt;/strong&gt;"&gt;<br>
&lt;/je:Button&gt;<br>
<br>
<br>
&lt;je:Button ID="buttonContentTemplate" runat="server"&gt;<br>
	&lt;ContentTemplate&gt;<br>
		按钮 &lt;strong&gt;content&lt;/strong&gt;<br>
	&lt;/ContentTemplate&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
Button 控件将元素的内容作为文本, 因此通过 Html, Text, ContentTemplate 设置元素的内容后, 将显示为按钮的文本.</blockquote>

<blockquote>Text 属性可以设置元素中的文字.</blockquote>

<blockquote>Html 属性可以设置元素中的 html 代码, 如果设置, 则 Text 属性将无效.</blockquote>

<blockquote>ContentTemplate 同样设置元素的 html 代码, 如果设置, 则 Html, Text 属性将无效.</blockquote>

<h3>IsVariable 属性</h3>
<blockquote>IsVariable 属性将控制是否生成与 ClientID 属性相同的 javascript 变量:<br>
<pre><code>&lt;html&gt;<br>
<br>
	&lt;je:Button ID="buttonVariable1" runat="server" Text="按钮 variable 1" IsVariable="true"&gt;<br>
	&lt;/je:Button&gt;<br>
	&lt;je:Button ID="buttonVariable2" runat="server" Text="按钮 variable 2" IsVariable="true"&gt;<br>
	&lt;/je:Button&gt;<br>
	&lt;je:Button ID="buttonVariable3" runat="server" Text="按钮 variable 3"&gt;<br>
	&lt;/je:Button&gt;<br>
<br>
&lt;/html&gt;<br>
<br>
&lt;script type="text/javascript"&gt;<br>
	$(function () {<br>
		buttonVariable1.button('disable');<br>
		$('#buttonVariable3').button('disable');<br>
	});<br>
&lt;/script&gt;<br>
<br>
&lt;je:JQueryScript ID="jqueryScript" runat="server"&gt;<br>
	&lt;ContentTemplate&gt;<br>
		&lt;script type="text/javascript"&gt;<br>
		$(function () {<br>
			eval('[%id:buttonVariable2%]').button('disable');<br>
		});<br>
		&lt;/script&gt;<br>
	&lt;/ContentTemplate&gt;<br>
&lt;/je:JQueryScript&gt;<br>
</code></pre>
通过将 IsVariable 设置为 true, 按钮 buttonVariable1 和 buttonVariable2 分别生成了和 ClientID 相同的 javascript 变量, 因此通过变量 buttonVariable1 就可以访问 <b>button</b>.</blockquote>

<blockquote>buttonVariable3 没有生成 javascript 变量, 但仍然可以通过 ClientID 和 jQuery 来访问.</blockquote>

<blockquote>如果 ClientID 比较复杂, 则可以使用内嵌表达式 <b><code>[%id:&lt;控件 ID&gt;%]</code></b> 来获取 ClientID, 但需要写在 JQueryScript 控件或者 JQueryElement 控件的属性中.</blockquote>

<h3>ScriptPackageID 属性</h3>
<blockquote>ScriptPackageID 属性指示生成 javascript 脚本的 ScriptPackage 控件, 也就是 JQueryElement 控件对应的脚本将在 ScriptPackage 控件中生成:<br>
<pre><code>&lt;je:Button ID="buttonPackage1" runat="server" Text="按钮 package 1" ScriptPackageID="package"&gt;<br>
&lt;/je:Button&gt;<br>
&lt;je:Button ID="buttonPackage2" runat="server" Text="按钮 package 2" ScriptPackageID="package"&gt;<br>
&lt;/je:Button&gt;<br>
&lt;je:ScriptPackage ID="package" runat="server" /&gt;<br>
</code></pre></blockquote>

<h3>相关内容</h3>
<blockquote><a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a></blockquote>

</font>
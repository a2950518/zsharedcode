#summary 通过 Parameter 对象添加 Ajax 请求时的参数
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JEParameter'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>.</blockquote>

<blockquote>本文将说明 JQueryElement 当中的 Parameter 对象的作用和使用方法:</blockquote>

<ul><li>准备<br>
</li><li>语法<br>
</li><li>参数名<br>
</li><li>参数获取方式<br>
</li><li>默认值<br>
</li><li>数据类型<br>
</li><li>自定义转换函数<br>
</li><li>自动添加的参数<br>
</li><li>附录: Async 属性参考</li></ul>

<h3>准备</h3>
<blockquote>在此之前, 请确保已经了解 JQueryElement 中一些控件的使用.</blockquote>

<h3>语法</h3>
<blockquote>通过添加 Parameter, 可以为 Ajax 调用增加参数:<br>
<pre><code>&lt;je:Parameter<br>
	Name="&lt;参数名&gt;" Type="&lt;参数获取方式&gt;"<br>
	Value="&lt;参数表达式&gt;" Default="&lt;默认值&gt;"<br>
	DataType="&lt;数据类型&gt;" Provider="&lt;自定义转换函数&gt;" /&gt;<br>
<br>
&lt;je:Parameter Name="name" Type="Selector"<br>
	Value="#txtAName" DataType="String" /&gt;<br>
</code></pre>
每一个 Parameter 都需要包含在 ParameterList 中, 而 ParameterList 是所有 Async 对象的属性, 下面在点击的事件中, 增加了一个名为 name 的参数.<br>
<pre><code>&lt;ClickAsync Url="webservice.asmx" MethodName="Save" Success="<br>
function(data){<br>
	alert(data.d.message);<br>
}<br>
"&gt;<br>
	&lt;je:Parameter Name="name" Type="Selector" Value="#txtWName3" /&gt;<br>
&lt;/ClickAsync&gt;<br>
</code></pre></blockquote>

<h3>参数名</h3>
<blockquote>如果调用 WebService, 则参数名和服务器端的参数名是一致的, 比如:<br>
<pre><code>&lt;je:Button ID="cmdWNet3" runat="server"&gt;<br>
	&lt;ClickAsync Url="webservice.asmx" MethodName="Save"&gt;<br>
		&lt;je:Parameter Name="name" Type="Selector" Value="#txtWName3" /&gt;<br>
	&lt;/ClickAsync&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
代码中 Parameter 的 Name 属性设置的参数名为 name, 因此 Save 方法需要一个名为 name 的参数:<br>
<pre><code>[WebMethod]<br>
[ScriptMethod]<br>
public SortedDictionary&lt;string, object&gt; Save ( string name )<br>
{ }<br>
</code></pre>
如果使用 ashx 来接收参数, 则使用 <code>Request['name']</code> 即可.</blockquote>

<h3>参数获取方式</h3>
<blockquote>参数获取方式有两种, 一种是 Selector, 这表示 Value 属性是一个选择器, 通过选择器将选择页面上的一个元素, 通常是 input 元素, 将取此元素的值作为参数的值, 另一种是 Expression, 表示 Value 中的是一个 javascript 表达式, javascript 表达式计算的值将作为参数的值:<br>
<pre><code>&lt;je:Parameter Name="name" Type="Selector" Value="#txtWName3" /&gt;<br>
<br>
&lt;je:Parameter Name="value" Type="Expression" Value="123 + 321" DataType="Number" /&gt;<br>
&lt;je:Parameter Name="value" Type="Expression" Value="add(123, 321)" DataType="Number" /&gt;<br>
</code></pre>
代码中的选择器 #txtWName3 也可以使用单引号, 区别可以参考 <a href='JEBase.md'>JQueryElement 基本属性参考</a> 的 JQueryElement 选择器一节.</blockquote>

<blockquote>Value 作为 javascript 表达式, 则形式是多样的, 在代码中, 还调用了 javascript 函数 add.</blockquote>

<h3>默认值</h3>
<blockquote>通过 Default 属性, 可以设置当参数值为空时的默认值, 是一个 javascript 表达式.</blockquote>

<h3>数据类型</h3>
<blockquote>可以通过 DataType 转化参数的类型, 比如转化文本框中的字符串为数值类型:<br>
<pre><code>&lt;je:Parameter Name="name" Type="Selector" Value="#txtAge" DataType="number" /&gt;<br>
</code></pre>
DataType 属性可以设置为 Number, Boolean, String, Date, 其实, 在服务器端 WebService 自身也会进行一些转化, 详细可以参考 <a href='AjaxDataType.md'>Ajax 与服务器的数据类型转换</a>.</blockquote>

<h3>自定义转换函数</h3>
<blockquote>如果设置了 DataType, 则可以另外的设置 Provider 来提供自定义转换函数, 自定义转换函数将在不能正常转换时调用, 比如:<br>
<pre><code>&lt;je:Parameter Name="name" Type="Selector" Value="#txtAge" DataType="number" Provider="<br>
function(value){<br>
	if(value == '不惑')<br>
		return 40;<br>
	else<br>
		return 18;<br>
}<br>
" /&gt;<br>
</code></pre>
上面的代码中, 如果用户输入的年龄为 不惑 则将转化为 40, 否则为 18.</blockquote>

<h3>自动添加的参数</h3>
<blockquote>在一些控件的事件中, 会自动的添加一些参数, 比如 Repeater 的 FillAsync 中会添加 pageindex, pagesize 来表示页码等信息.</blockquote>

<h3>附录: Async 属性参考</h3>
<blockquote>Url - 请求的地址, 比如: <code>"http://www.???.com/???.asmx"</code>.</blockquote>

<blockquote>MethodName - WebService 的方法名称, 如果是一般处理程序可以忽略此属性.</blockquote>

<blockquote>EventType - 触发请求的事件类型.</blockquote>

<blockquote>Form - 一个表单的选择器, 表单中的数据将发送到服务器端.</blockquote>

<blockquote>Data - 额外传递的数据, 一个 javascript 表达式.</blockquote>

<blockquote>IsSingleQuote - 是否为字符串使用单引号.</blockquote>

<blockquote>ClientFunction - 调用的 javascript 函数名称.</blockquote>

<blockquote>AjaxManagerID - 包含被调用的 javascript 函数的 AjaxManager 的 ID.</blockquote>

<blockquote>其它属性的设置可以参考 <a href='http://api.jquery.com/jQuery.ajax/'>api.jquery.com/jQuery.ajax/</a>.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='AjaxDataType.md'>Ajax 与服务器的数据类型转换</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

<blockquote>2011-12-10: 增加 Async 属性参考.</blockquote>

<blockquote>2011-12-20: 修改 Parameter 对象的介绍.</blockquote>

</font>
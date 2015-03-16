#summary Ajax 与服务器的数据类型转换
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/AjaxDataType'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /ajaxdatatype/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/dlC1WPtjXEE/'>www.tudou.com/programs/view/dlC1WPtjXEE/</a></blockquote>

<blockquote>本文将说明在使用 Ajax 调用 WebService 时, 客户端和服务器端的数据类型转换:</blockquote>

<ul><li>准备<br>
</li><li>WebService 转换数据类型<br>
</li><li>通过 Parameter 在客户端转化数据类型<br>
</li><li>数据类型转换失败时<br>
</li><li>日期类型</li></ul>

<h3>准备</h3>
<blockquote>请先查看 <a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a> 或者准备一节的内容. 本文中的代码可以在 .NET 2.0 下运行, 不同版本中可能需要稍作改动.</blockquote>

<h3>WebService 转换数据类型</h3>
<blockquote>在 ASP.NET 中, 如果从客户端传递的参数类型和 WebService 所需要的参数类型不同, 则服务器端将试图将参数转化为所需的类型.</blockquote>

<blockquote>如果, 在 WebService 中拥有一个名为 StringToString 的方法:<br>
<pre><code>[WebMethod]<br>
[ScriptMethod]<br>
public string StringToString ( string value )<br>
{<br>
	this.Context.Response.Cache.SetNoStore ( );<br>
<br>
	return string.Format ( "{0}", value );<br>
}<br>
</code></pre>
StringToString 方法具有一个 string 类型的参数 value, 如果在客户端传递的 value 参数的类型为数值, 布尔值, 则将自动的转化为字符串.</blockquote>

<blockquote>下面是使用 JQueryElement 的 Button 控件来调用 WebService 的代码:<br>
<pre><code>&lt;je:Button ID="cmdString3" runat="server"<br>
	Label="传递布尔值 false 到 string StringToString(string)"&gt;<br>
	&lt;ClickAsync Url="webservice.asmx" MethodName="StringToString" Success="<br>
	function(data){<br>
		alert(data);<br>
	}<br>
	"&gt;<br>
		&lt;je:Parameter Name="value" Type="Expression" Value="true"<br>
			DataType="Boolean" /&gt;<br>
	&lt;/ClickAsync&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
通过 ClickAsync 来设置点击按钮时的 Ajax 操作, 在 Parameter 中, 设置 DataType 为 Boolean 来明确的表示传递给服务器的是一个布尔值, Type 为 Expression 表示 Value 中的是一个 javascript 表达式, 更多 Parameter 的信息, 请参考 <a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a>.</blockquote>

<blockquote>上面的代码传递布尔值 true 给方法 StringToString, 而 StringToString 需要一个字符串, 因此 ASP.NET 会自动的将 true 转化为字符串, 最后的结果将弹出 True.</blockquote>

<blockquote>ASP.NET 可以将传递来的数值, 布尔值转化为字符串. 可以将传递来的表示数字的字符串转化为数值类型, 比如将 "123" 转化为 123. 可以将字符串 "true" 或 "false" 转化为布尔值. 可以将空字符串或形式类似于 "2011-1-1 11:33:44" 的字符串转化为日期类型.</blockquote>

<h3>通过 Parameter 在客户端转化数据类型</h3>
<blockquote>在 JQueryElement 中, 可以使用 Parameter 来在客户端转化数据类型. 比如: 通过 jQuery 的 val 方法, 可以获取到文本框的值, 这个值是一个字符串, 使用 DataType 来选择需要转化为的类型.<br>
<pre><code>&lt;input type="text" id="txtInt1" /&gt;<br>
&lt;je:Button ID="cmdInt1" runat="server"<br>
	Label="传递数值到 string IntToString(int)"&gt;<br>
	&lt;ClickAsync Url="webservice.asmx" MethodName="IntToString" Success="<br>
	function(data){<br>
		$('#lblInt1').text('返回 ' + data + ', 类型为: ' + typeof data);<br>
	}<br>
	"&gt;<br>
		&lt;je:Parameter Name="value" Type="Selector" Value="#txtInt1"<br>
			DataType="Number" /&gt;<br>
	&lt;/ClickAsync&gt;<br>
&lt;/je:Button&gt;<br>
&lt;p id="lblInt1"&gt;&lt;/p&gt;<br>
</code></pre>
代码中, 设置 DataType 为 Number, 那么在请求之前, 文本框 txtInt1 中的内容将转化为数值.</blockquote>

<h3>数据类型转换失败时</h3>
<blockquote>如果, ASP.NET 在转换数据时发生错误, 那么将向客户端返回一个错误, 可以通过 Async 的 Error 来处理:<br>
<pre><code>&lt;input type="text" id="txtInt1" /&gt;<br>
&lt;je:Button ID="cmdInt1" runat="server"<br>
	Label="传递字符串到 string IntToString(int)"&gt;<br>
	&lt;ClickAsync Url="webservice.asmx" MethodName="IntToString" Success="<br>
	function(data){<br>
		$('#lblInt1').text('返回 ' + data + ', 类型为: ' + typeof data);<br>
	}<br>
	" Error="<br>
	function(data){<br>
		alert(data.responseText);<br>
	}<br>
	"&gt;<br>
		&lt;je:Parameter Name="value" Type="Selector" Value="#txtInt1"<br>
			DataType="String" /&gt;<br>
	&lt;/ClickAsync&gt;<br>
&lt;/je:Button&gt;<br>
&lt;p id="lblInt1"&gt;&lt;/p&gt;<br>
</code></pre>
代码中, 将文本框中的字符串传递给了 IntToString 方法, 因此当输入类似于 "abc" 这样的字符串时将发生错误, 在 Error 中通过 data.responseText 即可获取从服务器返回的错误消息.</blockquote>

<blockquote>如果是通过 Parameter 的 DataType 来转化数据类型, 在转化失败时, 将使用默认值来代替. 布尔值默认 true, 数值默认 0, 日期默认为当前时间.</blockquote>

<h3>日期类型</h3>
<blockquote>从服务器返回的日期类型默认为 <b><code>"\/Date(xxxxxxxxxx)\/"</code></b> 的形式, 是一个字符串, 可以通过 <code>jQuery.panzer.formatDate</code> 函数来格式化日期, 或者使用 <code>jQuery.panzer.convertToDate</code> 将 <b><code>"\/Date(xxxxxxxxxx)\/"</code></b> 格式的字符串转化为日期类型.</blockquote>

<blockquote>如果是从客户端发送日期到服务器, 则可以发送一个可以表示日期的字符串即可, 比如:<br>
<pre><code>[WebMethod]<br>
[ScriptMethod]<br>
public string DateToString ( DateTime value )<br>
{<br>
	this.Context.Response.Cache.SetNoStore ( );<br>
<br>
	return string.Format ( "{0}", value );<br>
}<br>
<br>
&lt;je:Button ID="cmdDate2" runat="server"<br>
	Label="传递日期到 string DateToString(DateTime)"&gt;<br>
	&lt;ClickAsync Url="webservice.asmx" MethodName="DateToString" Success="<br>
	function(data){<br>
		alert(data);<br>
	}<br>
	"&gt;<br>
		&lt;je:Parameter Name="value" Type="Expression" Value="new Date()"<br>
			DataType="Date" /&gt;<br>
	&lt;/ClickAsync&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
通过 Parameter 的设置, 将日期转化为可以被服务器端识别的当前日期的字符串形式.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

</font>
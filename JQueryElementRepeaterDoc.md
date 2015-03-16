#summary Repeater 完全参考
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementRepeaterDoc'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /JQueryElementTest.rar/3/Student.aspx 或 /repeater/Default.aspx.</blockquote>

<blockquote>本文将系统讲解 Repeater 控件的功能以及使用过程中的注意事项和技巧, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>主要功能<br>
<ul><li>绑定字段<br>
<ul><li>字段表达式<br>
</li></ul></li><li>绑定属性<br>
<ul><li>属性表达式<br>
</li></ul></li><li>基本设置<br>
</li><li>设置分页<br>
</li><li>设置字段<br>
</li><li>设置调用的服务端方法<br>
</li><li>请求/返回数据的格式<br>
<ul><li>填充/搜索<br>
</li><li>更新<br>
</li><li>删除<br>
</li><li>新建<br>
</li></ul></li><li>行状态说明<br>
</li><li>排序状态说明<br>
</li><li>设置模板<br>
<ul><li>ItemTemplate<br>
</li><li>UpdatedItemTemplate/InsertedItemTemplate<br>
</li><li>RemovedItemTemplate<br>
</li><li>EditItemTemplate<br>
</li><li>FilterTemplate/NewItemTemplate<br>
</li><li>HeaderTemplate/FooterTemplate/EmptyTemplate<br>
</li><li>TipTemplate<br>
</li></ul></li><li>特殊绑定<br>
<ul><li>je-id<br>
</li><li>je-<javascript 事件名><br>
</li><li>je-class<br>
</li><li>je-checked/selected/readonly<br>
</li><li>je-value<br>
</li><li>je-<jQueryUI 插件名><br>
</li><li>je-template<br>
</li></ul></li><li>子视图<br>
</li><li>数据分组<br>
</li><li>处理控件<br>
</li><li>消息提示<br>
</li><li>检索数据<br>
</li><li>排序<br>
</li><li>多行操作<br>
</li><li>事件<br>
</li><li>客户端方法</li></ul></li></ul>

<img src='http://zsharedcode.googlecode.com/files/widget1.jpg' />

<h3>准备</h3>
<blockquote>请确保已经在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 最新的版本.</blockquote>

<blockquote>请使用指令引用如下的命名空间:<br>
<pre><code>&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.ui.jqueryui.plusin"<br>
	TagPrefix="je" %&gt;<br>
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.web.jqueryui"<br>
	TagPrefix="je" %&gt;<br>
</code></pre>
除了命名空间, 还需要引用 jQueryUI 的脚本和样式, 在 <a href='Download.md'>下载资源</a> 的 JQueryElement.dll 下载一节下载的压缩包中包含了一个自定义样式的 jQueryUI, 如果需要更多样式, 可以在 <a href='http://jqueryui.com/download'>jqueryui.com/download</a> 下载:<br>
<pre><code>&lt;link type="text/css" rel="stylesheet" href="[样式路径]/jquery-ui-&lt;version&gt;.custom.css" /&gt;<br>
&lt;script type="text/javascript" src="[脚本路径]/jquery-&lt;version&gt;.min.js"&gt;&lt;/script&gt;<br>
&lt;script type="text/javascript" src="[脚本路径]/jquery-ui-&lt;version&gt;.custom.min.js"&gt;&lt;/script&gt;<br>
</code></pre>
也可以使用 ResourceLoader 来添加所需的脚本或样式, 详细请参考 <a href='ResourceLoader.md'>自动添加脚本和样式</a>.</blockquote>

<h3>主要功能</h3>

<blockquote><h4><font color='green'>绑定字段</font></h4>
在行模板中, 可以使用 <b><code>#{&lt;字段名&gt;[,&lt;字段表达式&gt;]}</code></b> 的形式来绑定字段, 比如:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
	&lt;span&gt;#{id}&lt;/span&gt;<br>
	&lt;span&gt;#{realname}&lt;/span&gt;<br>
	&lt;span&gt;#{age}&lt;/span&gt;<br>
&lt;/ItemTemplate&gt;<br>
</code></pre>
字段也可以被绑定在标签的属性中, 比如:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
	&lt;span&gt;#{id}&lt;/span&gt;<br>
	&lt;span title="#{realname}"&gt;#{realname}&lt;/span&gt;<br>
	&lt;span&gt;#{age}&lt;/span&gt;<br>
&lt;/ItemTemplate&gt;<br>
</code></pre></blockquote>

<blockquote><h5>字段表达式</h5>
当需要根据字段的值显示不同内容时, 可以使用字段表达式, 在表达式中 # 将表示字段本身, 示例:<br>
<pre><code>&lt;script type="text/javascript"&gt;<br>
	function convertAge(age) {<br>
<br>
		if(age &lt; 0) return age.toString() + '-未出世';<br>
		else if (age &lt; 4) return age.toString() + '-幼儿';<br>
		else if (age &lt; 10) return age.toString() + '-儿童';<br>
		else if (age &lt; 18) return age.toString() + '-少年';<br>
		else if (age &lt; 30) return age.toString() + '-青年';<br>
		else if (age &lt; 50) return age.toString() + '-中年';<br>
		else return age.toString() + '-老年';<br>
<br>
	}<br>
&lt;/script&gt;<br>
<br>
&lt;td&gt;<br>
	#{age,convertAge(#)}<br>
&lt;/td&gt;<br>
</code></pre>
在上面的例子中, <code>#{age,convertAge(#)}</code> 并不会直接输出 age 字段的值, 而是将 age 字段传递给 convertAge 函数, 然后将函数执行的结果输出.</blockquote>

<blockquote>除了调用函数外, 也可以直接书写 javascript 代码, 比如: <code>#{age,# &lt;= 0 ? '不可能吧' : #.toString()}</code>.</blockquote>

<blockquote>更多使用方法和说明请参考 <a href='JERepeaterBindField.md'>Repeater 绑定/处理字段</a>.</blockquote>

<blockquote><h4><font color='green'>绑定属性</font></h4>
在所有的模板中都可以绑定属性, 语法为 <b><code>@{&lt;属性名&gt;[,&lt;属性表达式&gt;]}</code></b>, 比如:<br>
<pre><code>&lt;FooterTemplate&gt;<br>
	第 @{pageindex}/@{pagecount} 页, @{itemcount} 条<br>
&lt;/FooterTemplate&gt;<br>
</code></pre>
在行模板中, 不会因为属性的改变而自动刷新, 如果需要刷新请调用 bind 函数.</blockquote>

<blockquote><h5>属性表达式</h5>
属性表达式和上面的字段表达式是类似的, 可以输出转换后的属性, 示例:<br>
<pre><code>&lt;td colspan="5"&gt;<br>
	第 @{pageindex}/@{pagecount,@ &lt;= 0 ? '-' : @} 页, @{itemcount,@ &lt;= 0 ? '-' : @} 条<br>
&lt;/td&gt;<br>
</code></pre>
我们判断属性 pagecount 和 itemcount 如果小于等于 0, 则显示连接线.</blockquote>

<blockquote><h4><font color='green'>基本设置</font></h4>
Repeater 的 Selector 属性是一个 javascript 表达式, 它将作为一个选择器, 写法可以参照 <a href='http://jquery.com'>jquery.com</a>, 选择器对应的元素将作为页面上最终的 <b>repeater</b> 来呈现, 示例:<br>
<pre><code>&lt;table id="list"&gt;&lt;/table&gt;<br>
<br>
&lt;je:Repeater ID="studentRepeater" runat="server"<br>
	Selector="#list"&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
设置 IsVariable 属性为 True, 则将在客户端生成与 ClientID 同名的 javascript 变量, 示例:<br>
<pre><code>&lt;je:Repeater ID="studentRepeater" runat="server"<br>
	IsVariable="true"&gt;<br>
&lt;/je:Repeater&gt;<br>
<br>
&lt;script type="text/javascript"&gt;<br>
	$(function () {<br>
		studentRepeater.__repeater('fill');<br>
	});<br>
&lt;/script&gt;<br>
</code></pre>
由于在此页面中 ClientID 与 ID 相同, 因此通过 <code>studentRepeater</code> 就可以访问 <b>repeater</b>. 此外, 也可以通过 JQueryScript 控件并使用内嵌语法 <code>[%id:studentRepeater%]</code> 来确保 ClientID 与 ID 不相同的页面也能访问 <b>repeater</b> 变量.</blockquote>

<blockquote><h4><font color='green'>设置分页</font></h4>
通过 Repeater 的 PageSize 属性设置每页包含多少条数据, PageIndex 属性设置初始的页码, PageIndex 默认为 1.</blockquote>

<blockquote><h4><font color='green'>设置字段</font></h4>
Repeater 的 Field 属性表示参与绑定的字段, 其形式为一个 javascript 字符串数组, 比如: <code>['id', 'realname', 'age']</code>, 如果不设置 Field 属性, 则由第一次填充的数据来确定, 但这将导致在没有数据的情况下无法新建.</blockquote>

<blockquote>FilterField 表示用于搜索的字段, 也是一个 javascript 字符串数组. FilterFieldDefault 为搜索字段的值为 null 或者 '' 时的默认值, 示例: <code>['', '', 0]</code>.</blockquote>

<blockquote>SortField 表示参与排序的字段, 比如: <code>['id']</code>.</blockquote>

<blockquote>FieldMask 表示用于验证字段的正则表达式, 在更新或新建时起效, 一般格式为:<br>
<pre><code>{&lt;字段名&gt;: {<br>
	reg: &lt;正则表达式&gt;,<br>
	tip: '&lt;错误提示信息&gt;',<br>
	type: '&lt;字段类型, 可以是 number, boolean, date&gt;',<br>
	max: &lt;字符串最大长度或数值的最大值&gt;,<br>
	min: &lt;字符串最小长度或数值的最小值&gt;,<br>
	need: &lt;是否必需, true 或者 false&gt;,<br>
	provider: &lt;自定义转换函数&gt;,<br>
	defaultvalue: &lt;默认值&gt;<br>
	}<br>
}<br>
</code></pre>
如果需要更详细的错误提示, 可以参用如下形式:<br>
<pre><code>{&lt;字段名&gt;: {<br>
	tip: {<br>
		reg: '&lt;不符合正则表达式时的提示&gt;',<br>
		type: '&lt;不符合特定类型时的提示&gt;',<br>
		max: '&lt;大于最大值时的提示&gt;',<br>
		min: '&lt;小于最大值时的提示&gt;',<br>
		need: '&lt;为空时的提示&gt;'<br>
		}<br>
	}<br>
}<br>
</code></pre>
这些设置其实和 Validator 的设置是类似的, 可以参考 <a href='JQueryElementValidator.md'>Validator 完全参考</a>.</blockquote>

<blockquote><h4><font color='green'>设置调用的服务端方法</font></h4>
可以通过 Async 来设置如何调用服务器端方法, 如果是调用 WebService, 则需要设置 MethodName, 如果是普通的 ashx 这样的一般处理程序, 则忽略 MethodName, 示例:<br>
<pre><code>&lt;je:Repeater ID="studentRepeater" runat="server"<br>
	FillAsync-Url="&lt;填充方法地址&gt;"<br>
	FillAsync-MethodName="&lt;填充方法名称&gt;"<br>
	UpdateAsync-Url="&lt;更新方法地址&gt;"<br>
	UpdateAsync-MethodName="&lt;更新方法名称&gt;"<br>
	InsertAsync-Url="&lt;新建方法地址&gt;"<br>
	InsertAsync-MethodName="&lt;新建方法名称&gt;"<br>
	RemoveAsync-Url="&lt;删除方法地址&gt;"<br>
	RemoveAsync-MethodName="&lt;删除方法名称&gt;"<br>
	&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
<br>
&lt;je:Repeater ID="studentRepeater" runat="server"<br>
	FillAsync-Url="Student.aspx"<br>
	FillAsync-MethodName="Fill"<br>
	UpdateAsync-Url="Student.aspx"<br>
	UpdateAsync-MethodName="Update"<br>
	InsertAsync-Url="Student.aspx"<br>
	InsertAsync-MethodName="Insert"<br>
	RemoveAsync-Url="Student.aspx"<br>
	RemoveAsync-MethodName="Remove"<br>
	&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
如果, 你需要为方法传递更多的参数, 则可以采用下面的形式:<br>
<pre><code>&lt;je:Repeater ID="studentRepeater" runat="server"&gt;<br>
&lt;FillAsync Url="&lt;填充方法地址&gt;" MethodName="&lt;填充方法名称&gt;"&gt;<br>
	&lt;je:Parameter Name="&lt;参数名1&gt;"<br>
		Type="Expression"<br>
		Value="&lt;值1&gt;"<br>
		Default="&lt;默认值1&gt;" /&gt;<br>
	&lt;je:Parameter Name="&lt;参数名2&gt;"<br>
		Type="Selector"<br>
		Value="&lt;选择器2&gt;"<br>
		Default="&lt;默认值2&gt;" /&gt;<br>
<br>
&lt;/FillAsync&gt;<br>
&lt;/je:Repeater&gt;<br>
<br>
&lt;je:Repeater ID="studentRepeater" runat="server"&gt;<br>
&lt;FillAsync Url="Student.aspx" MethodName="Fill"&gt;<br>
	&lt;je:Parameter Name="ws"<br>
		Type="Expression"<br>
		Value="website"<br>
		Default="'-'" /&gt;<br>
	&lt;je:Parameter Name="year"<br>
		Type="Selector"<br>
		Value="#year"<br>
		Default="2011" /&gt;<br>
<br>
&lt;/FillAsync&gt;<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
通过添加 Parameter, 可以传递更多的参数, Name 为参数名, Type 为 Expression 时, 则 Value 中包含的是一个 javascript 表达式, 当 Type 为 Selector 时, 则 Value 中的 javascript 表达式将作为选择器, 选择器的写法可以参照 <a href='http://jquery.com'>jquery.com</a>, 选择器对应的元素的值将作为参数的值. Default 中是默认值的 javascript 表达式, 当参数的值为 null 或者 '' 时, 将采用 Default 中的值, 更多 Parameter 的信息, 请参考 <a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a>.</blockquote>

<blockquote><h4><font color='green'>请求/返回数据的格式</font></h4>
关于如何返回 JSON, 请参考 <a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a>, 以下所有代码为在 .NET 4.0 下编写.</blockquote>

<blockquote><h5>填充/搜索</h5>
对于填充或者搜索操作, 以 WebService 为例, 服务端将接收如下参数, pageindex 页码, pagesize 每页中包含数据条数, 还可以接收与字段同名的参数或者通过 Parameter 增加的参数作为搜索条件, 或者接收形式为 <b><code>__order</code></b> 的用于排序的参数, 参数的值类似于 <code>name asc, age desc</code>, <b><code>__group</code></b> 形式的参数则用于接收分组的条件:<br>
<pre><code>[WebMethod ( )]<br>
public static object &lt;方法名称&gt; ( int pageindex, int pagesize<br>
	[, &lt;类型n, 如: string&gt; &lt;用于搜索的字段或条件名称n&gt;]<br>
	[, string __order]<br>
	[, string __group] )<br>
{<br>
}<br>
<br>
[WebMethod ( )]<br>
public static object Fill ( int pageindex, int pagesize<br>
	, string realname, int age<br>
	, string __order )<br>
{<br>
}<br>
</code></pre>
服务器还应返回如下格式的 json 数据作为填充数据, 其中 <code>__</code>success 默认为 true, itemcount 可以省略, 但将无法计算 pagecount 页码.<br>
<pre><code>{<br>
	"__success": &lt;表示是否成功的布尔值, 为 true 或者 false&gt;,<br>
	"rows": &lt;当前页包含行数据的 javascript 数组&gt;,<br>
	"itemcount": &lt;总行数&gt;<br>
	[, "custom": &lt;自定义对象, 比如: { message: 'ok' }&gt;]<br>
}<br>
<br>
{<br>
	"__success": true,<br>
	"rows":<br>
	[<br>
		{ "id": 1, "realname": "jack", "age": 20 },<br>
		{ "id": 2, "realname": "tom", "age": 21 }<br>
	],<br>
	"itemcount": 120<br>
}<br>
</code></pre>
在 .NET 4.0 中可以使用匿名类型来返回 json, 比如:<br>
<pre><code>[WebMethod ( )]<br>
public static object Fill ( /* 参数 */ )<br>
{<br>
	// ...<br>
	List&lt;object&gt; students = new List&lt;object&gt; ( );<br>
	students.Add ( new {<br>
		id = 1,<br>
		realname = "jack",<br>
		age = 20<br>
		} );<br>
	// ...<br>
	return new { __success = true, rows = students.ToArray ( ), itemcount = 120 };<br>
}<br>
</code></pre></blockquote>

<blockquote><h5>更新</h5>
对于更新操作, 以 WebService 为例, 服务端将接收与更新的字段同名的参数:<br>
<pre><code>[WebMethod ( )]<br>
public static object &lt;方法名称&gt; ( &lt;类型, 如: string&gt; &lt;用于更新的字段名称&gt;<br>
	[, &lt;类型n, 如: string&gt; &lt;用于更新的字段名称n&gt;])<br>
{<br>
}<br>
<br>
[WebMethod ( )]<br>
public static object Update ( int id<br>
	, string realname, int age )<br>
{<br>
}<br>
</code></pre>
服务器可以返回如下格式的 json 作为更新后的消息, 其中 <code>__</code>success 默认为 true, row 可以省略, 如果修改从客户端传递来的参数, 比如将小写的姓名改成大写, 那么可以用 row 来返回修改的字段.<br>
<pre><code>{<br>
	"__success": &lt;表示是否成功的布尔值, 为 true 或者 false&gt;,<br>
	"row": &lt;更新后的行, 不必包含所有字段&gt;<br>
	[, "custom": &lt;自定义对象, 比如: { message: 'ok' }&gt;]<br>
}<br>
<br>
{<br>
	"__success": true,<br>
	"row": { "realname": "JACK" }<br>
}<br>
</code></pre>
在 .NET 4.0 中可以使用匿名类型来返回 json, 比如:<br>
<pre><code>[WebMethod ( )]<br>
public static object Update ( /* 参数 */ )<br>
{<br>
	// ..., row 可以省略<br>
	return new { __success = true,<br>
		row = new { realname = "JACK" }<br>
		};<br>
}<br>
</code></pre></blockquote>

<blockquote><h5>删除</h5>
对于删除操作, 以 WebService 为例, 服务端将接收用于删除的字段作为参数:<br>
<pre><code>[WebMethod ( )]<br>
public static object &lt;方法名称&gt; ( &lt;类型, 如: string&gt; &lt;用于删除的字段名称&gt;<br>
	[, &lt;类型n, 如: string&gt; &lt;用于删除的字段名称n&gt;])<br>
{<br>
}<br>
<br>
[WebMethod ( )]<br>
public static object Remove ( int id )<br>
{<br>
}<br>
</code></pre>
服务器可以返回如下格式的 json 作为删除后的消息, 其中 <code>__</code>success 默认为 true.<br>
<pre><code>{<br>
	"__success": &lt;表示是否成功的布尔值, 为 true 或者 false&gt;<br>
	[, "custom": &lt;自定义对象, 比如: { message: 'ok' }&gt;]<br>
}<br>
<br>
{<br>
	"__success": true<br>
}<br>
</code></pre>
在 .NET 4.0 中可以使用匿名类型来返回 json, 比如:<br>
<pre><code>[WebMethod ( )]<br>
public static object Remove ( /* 参数 */ )<br>
{<br>
	// ..., row 可以省略<br>
	return new { __success = true };<br>
}<br>
</code></pre></blockquote>

<blockquote><h5>新建</h5>
对于新建操作, 以 WebService 为例, 服务端将接收与新建的字段同名的参数:<br>
<pre><code>[WebMethod ( )]<br>
public static object &lt;方法名称&gt; ( &lt;类型, 如: string&gt; &lt;用于新建的字段名称&gt;<br>
	[, &lt;类型n, 如: string&gt; &lt;用于新建的字段名称n&gt;])<br>
{<br>
}<br>
<br>
[WebMethod ( )]<br>
public static object Insert ( string realname<br>
	, int age )<br>
{<br>
}<br>
</code></pre>
服务器可以返回如下格式的 json 作为新建后的消息, 其中 <code>__</code>success 默认为 true.<br>
<pre><code>{<br>
	"__success": &lt;表示是否成功的布尔值, 为 true 或者 false&gt;,<br>
	"row": &lt;新建后的行&gt;<br>
	[, "custom": &lt;自定义对象, 比如: { message: 'ok' }&gt;]<br>
}<br>
<br>
{<br>
	"__success": true,<br>
	"row": { "id":10, "realname": "lili", "age": 12 }<br>
}<br>
</code></pre>
在 .NET 4.0 中可以使用匿名类型来返回 json, 比如:<br>
<pre><code>[WebMethod ( )]<br>
public static object Insert ( /* 参数 */ )<br>
{<br>
	// ..., row 可以省略<br>
	return new { __success = true,<br>
		row = new { id = 10, realname = "lili", age = 12 }<br>
		};<br>
}<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>行状态说明</font></h4>
在客户端的 javascript 脚本中, 行状态有 4 种, 分别是 unchanged 未改变, updated 更新过, inserted 新建后的行, removed 删除后的行.</blockquote>

<blockquote><h4><font color='green'>排序状态说明</font></h4>
在客户端的 javascript 脚本中, 排序状态有 3 种, 分别是 none 无排序或按照默认排序, asc 升序, desc 降序.</blockquote>

<blockquote><h4><font color='green'>设置模板</font></h4>
在 Repeater 的各种模板中, 可以设置 Repeater 最终显示的 html 代码, 这些 html 代码应该是完整的, 合法的, 否则可能导致最终显示的不正常.</blockquote>

<blockquote><h5>ItemTemplate</h5>
ItemTemplate 为行模板中的一种, 可以显示处于 unchanged 状态的行, 如果没有设置 UpdatedItemTemplate 或者 InsertedItemTemplate, 那么 updated, inserted 状态的行也显示在 ItemTemplate 中, 示例:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td&gt;<br>
			#{id}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{realname}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{age}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			/* 编辑和删除按钮 */<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/ItemTemplate&gt;<br>
</code></pre></blockquote>

<blockquote><h5>UpdatedItemTemplate/InsertedItemTemplate</h5>
与 ItemTemplate 不同的是, UpdatedItemTemplate 和 InsertedItemTemplate 分别用于显示状态为 updated 和 inserted 的行, 主要用于采用不同样式来显示不同状态的行, 但也可以使用更简便的 je-class 来完成同样的效果, 示例:<br>
<pre><code>&lt;UpdatedItemTemplate&gt;<br>
	&lt;tr style="font-weight: bold;"&gt;<br>
		&lt;td&gt;<br>
			#{id}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{realname}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{age}<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/UpdatedItemTemplate&gt;<br>
<br>
&lt;InsertedItemTemplate&gt;<br>
	&lt;tr style="color: green;"&gt;<br>
		&lt;td&gt;<br>
			#{id}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{realname}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{age}<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/InsertedItemTemplate&gt;<br>
</code></pre></blockquote>

<blockquote><h5>RemovedItemTemplate</h5>
默认情况下 removed 状态的行是不显示的, 除非设置了 RemovedItemTemplate, 示例:<br>
<pre><code>&lt;RemovedItemTemplate&gt;<br>
	&lt;tr style="color: red;"&gt;<br>
		&lt;td&gt;<br>
			#{id}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{realname}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{age}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			已经删除<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/RemovedItemTemplate&gt;<br>
</code></pre></blockquote>

<blockquote><h5>EditItemTemplate</h5>
EditItemTemplate 是用来编辑行的模板, 其中会包含一些文本框之类的元素, 如果需要在更新中获取字段的值, 还需要设置 <b><code>je-id="&lt;字段名&gt;"</code></b>, 示例:<br>
<pre><code>&lt;EditItemTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td&gt;<br>
			#{id}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="text" je-id="realname" value="#{realname}" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="text" je-id="age" value="#{age}" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			/* 取消和保存按钮 */<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/EditItemTemplate&gt;<br>
</code></pre></blockquote>

<blockquote><h5>FilterTemplate/NewItemTemplate</h5>
FilterTemplate 和 NewItemTemplate 有些相似之处, 同样包含一些文本框, 需要使用 je-id 来绑定 id, 示例:<br>
<pre><code>&lt;FilterTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="text" je-id="realname" value="#{realname}" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="text" je-id="age" value="#{age}" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			/* 搜索按钮 */<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/FilterTemplate&gt;<br>
<br>
&lt;NewItemTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="text" je-id="realname" value="#{realname}" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="text" je-id="age" value="#{age}" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			/* 新建按钮 */<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/NewItemTemplate&gt;<br>
</code></pre></blockquote>

<blockquote><h5>HeaderTemplate/FooterTemplate/EmptyTemplate</h5>
HeaderTemplate 表示头模板, FooterTemplate 表示尾模板, EmptyTemplate 表示在没有数据时的模板.</blockquote>

<blockquote><h5>TipTemplate</h5>
TipTemplate 为用于提示消息的模板, 其中可以使用 <code>@{tip}</code> 来绑定消息.</blockquote>

<blockquote><h4><font color='green'>特殊绑定</font></h4></blockquote>

<blockquote><h5>je-id</h5>
使用 <b><code>je-id="&lt;字段名&gt;"</code></b> 可以绑定特殊的 id, 可以使用在行模板或者 FilterTemplate, NewItemTemplate 中的 input 元素中.</blockquote>

<blockquote>在 EditItemTemplate 中, 被指定 je-id 的 input 将包含此字段的新值.</blockquote>

<blockquote>在 FilterTemplate 中, 指定 je-id 的 input 包含了用于搜索的字段的值, 这些字段应该包含在 FilterField 属性中.</blockquote>

<blockquote>在 NewItemTemplate 中, 指定 je-id 的 input 包含了用于新建的字段的值.</blockquote>

<blockquote><h5>je-<javascript 事件名></h5>
使用 <b><code>je-&lt;javascript 事件名&gt;="&lt;行为名&gt;"</code></b> 可以为事件绑定特殊的操作. 可以使用在各个模板中, 常用的行为有: beginedit 开始编辑, endedit 取消编辑, update 保存更新, remove 删除, toggleselect 切换选中状态, insert 新建, filter 搜索, togglesort 切换排序. 其中, 前 5 者只能用在行模板中, insert 可用在 NewItemTemplate 中, filter 可用在 FilterTemplate 中, togglesort 可用在 HeaderTemplate 中, 示例:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td&gt;<br>
			#{id}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{realname}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			#{age}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			&lt;span je-onclick="beginedit"&gt;编辑&lt;/span&gt;<br>
			&lt;span je-onclick="remove"&gt;删除&lt;/span&gt;<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/ItemTemplate&gt;<br>
<br>
&lt;EditItemTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td&gt;<br>
			#{id}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="text" je-id="realname" value="#{realname}" class="textbox" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="text" je-id="age" value="#{age}" class="textbox" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
			&lt;span je-onclick="endedit"&gt;取消&lt;/span&gt;<br>
			&lt;span je-onclick="update"&gt;保存&lt;/span&gt;<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/EditItemTemplate&gt;<br>
</code></pre>
需要说明的是, togglesort 还需要指定一个参数, 表示切换排序的字段, 这个字段已经在 SortField 中设置, 比如: <code>je-onclick="togglesort,'realname'"</code>.</blockquote>

<blockquote>如果绑定多个行为则, 可以使用 ; 号分隔, 比如 <code>je-onclick="setgroup,'realname';fill"</code>.</blockquote>

<blockquote><h5>je-class</h5>
使用 <b><code>je-class="&lt;样式&gt;"</code></b> 可以为元素绑定特殊的样式. 可以在各个模板中使用 je-class, 常用的样式有: {header} 表示 ui-widget-header, {active} 表示 ui-state-active, {highlight} 表示 ui-state-highlight, {disabled} 表示 ui-state-disabled, {error} 表示 ui-state-error, {default} 表示 ui-state-default, {state} 表示行状态, {sort} 表示排序状态, 示例:<br>
<pre><code>&lt;HeaderTemplate&gt;<br>
	&lt;thead je-class="{header}"&gt;<br>
		&lt;tr&gt;<br>
			&lt;td je-onclick="togglesort,'id'"&gt;<br>
&lt;span je-class="{sort,id,,ui-icon ui-icon-arrow-1-n icon,ui-icon ui-icon-arrow-1-s icon}"&gt;<br>
&lt;/span&gt;<br>
				序号<br>
			&lt;/td&gt;<br>
<br>
		&lt;/tr&gt;<br>
	&lt;/thead&gt;<br>
&lt;/HeaderTemplate&gt;<br>
<br>
&lt;ItemTemplate&gt;<br>
	&lt;tr je-class="{state}-item"&gt;<br>
<br>
	&lt;/tr&gt;<br>
&lt;/ItemTemplate&gt;<br>
</code></pre>
这里需要说明 {state} 和 {sort} 的语法, 分别为 <b><code>{state[,&lt;未改变行样式&gt;[,&lt;新建行样式&gt;[,&lt;修改行样式&gt;[,&lt;删除行样式&gt;]]]]}</code></b>, <b><code>{sort,&lt;排序字段&gt;[,&lt;无排序样式&gt;[,&lt;升序样式&gt;[,&lt;降序样式&gt;]]]}</code></b>. 对于 {state} 而言, 如果没有指定某种状态的样式, 则将使用行的状态名称来代替样式名称, 比如: <code>{state,,new-item}</code>, 由于没有指定未改变行的样式, 因此如果行的状态为 unchanged, 那么将返回 unchanged. 对于 {sort} 而言, 如果没有指定某种排序的样式, 将采用排序的状态来代替样式名称.</blockquote>

<blockquote><h5>je-checked/selected/readonly</h5>
在 ItemTemplate 中使用 <b><code>je-checked="selected"</code></b> 配合 <code>je-onclick="toggleselect"</code>来表示行是否处于选中的状态, je-selected 则可用于 EditItemTemplate 中的 select 元素, 示例:<br>
<pre><code>&lt;ItemTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td&gt;<br>
			&lt;input type="checkbox"<br>
				je-checked="selected"<br>
				je-onclick="toggleselect"<br>
				/&gt;&amp;nbsp;#{id}<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/ItemTemplate&gt;<br>
</code></pre>
在 FilterTemplate 中可以使用 <b><code>je-selected="&lt;布尔值, 可以是绑定字段或者一个表达式&gt;"</code></b> 来初始化处于选中状态的 option, 示例:<br>
<pre><code> &lt;FilterTemplate&gt;<br>
	&lt;tr&gt;<br>
		&lt;td&gt;<br>
			&lt;select je-id="type"&gt;<br>
				&lt;option je-selected="#{type,#=='normal'}"&gt;正常&lt;/option&gt;<br>
				&lt;option je-selected="#{type,#=='high'}"&gt;高&lt;/option&gt;<br>
				&lt;option je-selected="#{type,#=='low'}"&gt;低&lt;/option&gt;<br>
			&lt;/select&gt;<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/FilterTemplate&gt;<br>
</code></pre></blockquote>

<blockquote><h5>je-value</h5>
在 FilterTemplate 中使用 <b><code>je-value="&lt;搜索字段名&gt;"</code></b> 来绑定初始化的搜索条件.</blockquote>

<blockquote><h5>je-<jQueryUI 插件名></h5>
可以在任何模板中使用 <b><code>je-&lt;jQueryUI 插件名&gt;="&lt;属性名n&gt;=&lt;属性值n&gt;;"</code></b>, 来生成一个 jQueryUI 的插件, 但目前仅支持 je-button, je-datepicker, je-autocomplete, je-progressbar, je-slider, 示例:<br>
<pre><code>&lt;EditItemTemplate&gt;<br>
	&lt;tr je-class="{state}-item"&gt;<br>
		&lt;td&gt;<br>
&lt;input type="checkbox" je-checked="selected" je-onclick="toggleselect" /&gt;&amp;nbsp;#{id}<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
&lt;input type="text" je-id="realname" value="#{realname}" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
&lt;input type="text" je-id="age" value="#{age}" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
&lt;input type="text" je-id="birthday"<br>
	je-datepicker="dateFormat='yy-mm-dd';"<br>
	value="#{birthday}" /&gt;<br>
		&lt;/td&gt;<br>
		&lt;td&gt;<br>
&lt;span<br>
	je-button="label='编辑';icons={ primary: 'ui-icon-pencil' };"<br>
	je-onclick="beginedit"&gt;<br>
&lt;/span&gt;<br>
&lt;span<br>
	je-button="label='删除';icons={ primary: 'ui-icon-trash' };"<br>
	je-onclick="remove"&gt;<br>
&lt;/span&gt;<br>
		&lt;/td&gt;<br>
	&lt;/tr&gt;<br>
&lt;/EditItemTemplate&gt;<br>
</code></pre>
属性的设置是和 jQueryUI 插件的属性一致的, 可以参考 <a href='http://jqueryui.com'>jqueryui.com</a>.</blockquote>

<blockquote><h5>je-template</h5>
使用 <b><code>je-template="&lt;模板名&gt;"</code></b> 可以标记将作为模板的元素, 除了可以通过上面所讲的各种 Template, 也可以使用这种方法来设置模板, 示例:<br>
<pre><code>&lt;table id="list"&gt;<br>
	&lt;thead je-template="my-header"&gt;<br>
	&lt;/thead&gt;<br>
&lt;/table&gt;<br>
<br>
&lt;je:Repeater ID="studentRepeater" runat="server"<br>
	Selector="#list" Header="[je-template=my-header]"&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>子视图</font></h4>
在 Repeater 中, 可以通过 shiftview, collapseview, expandview 三个函数来切换, 关闭, 打开子视图, 比如:<br>
<pre><code>&lt;je:Repeater ID="&lt;子视图 ID&gt;" runat="server"<br>
	FilterField="&lt;子视图搜索字段&gt;"&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
<br>
&lt;je:Repeater ID="googleRepeater" runat="server"&gt;<br>
		&lt;ItemTemplate&gt;<br>
			&lt;div je-onclick="shiftview,'&lt;子视图 ID&gt;'[,&lt;子视图搜索字段值n&gt;]"&gt;<br>
			切换子视图<br>
			&lt;/div&gt;<br>
			&lt;div je-id="&lt;子视图 ID&gt;"&gt;<br>
			&lt;/div&gt;<br>
		&lt;/ItemTemplate&gt;<br>
&lt;/je:Repeater&gt;<br>
<br>
&lt;je:Repeater ID="pictureRepeater" runat="server"<br>
	FilterField="['url']"&gt;<br>
	&lt;ItemTemplate&gt;<br>
		&lt;div&gt;<br>
			&lt;span class="url"&gt;#{url}&lt;/span&gt;<br>
			&lt;br /&gt;<br>
			&lt;br /&gt;<br>
			#{picture}<br>
		&lt;/div&gt;<br>
	&lt;/ItemTemplate&gt;<br>
&lt;/je:Repeater&gt;<br>
<br>
&lt;div id="list"&gt;<br>
	&lt;je:Repeater ID="googleRepeater" runat="server" Selector="#list"&gt;<br>
		&lt;ItemTemplate&gt;<br>
			&lt;div<br>
				je-button="label='更多';"<br>
				je-onclick="shiftview,'pictureRepeater','#{url}'"&gt;<br>
			&lt;/div&gt;<br>
			&lt;div je-id="pictureRepeater" style="display: none;"&gt;<br>
			&lt;/div&gt;<br>
		&lt;/ItemTemplate&gt;<br>
	&lt;/je:Repeater&gt;<br>
&lt;/div&gt;<br>
</code></pre>
更多使用方法和说明请参考 <a href='JERepeaterSubView.md'>Repeater 子视图</a>.</blockquote>

<blockquote><h4><font color='green'>数据分组</font></h4>
可以通过 Repeater 的 GroupField 或者 setgroup 函数来设置分组的字段, 通过 GroupTemplate 来设置分组的模板, 在设置分组后调用 fill 函数重新获取数据即可:<br>
<pre><code>&lt;je:Repeater ID="mailRepeater" runat="server"<br>
	GroupField="&lt;分组字段&gt;"<br>
	FillAsync-Url="webservice.asmx"<br>
	FillAsync-MethodName="FillMailList"&gt;<br>
	&lt;HeaderTemplate&gt;<br>
<br>
		&lt;td<br>
			je-onclick="setgroup,'&lt;分组字段&gt;';togglesort,'&lt;排序字段&gt;'"&gt;<br>
			发送人<br>
		&lt;/td&gt;<br>
<br>
	&lt;/HeaderTemplate&gt;<br>
	&lt;GroupTemplate&gt;<br>
<br>
		&lt;td&gt;<br>
			@{groupfield}: @{groupname}<br>
		&lt;/td&gt;<br>
	<br>
	&lt;/GroupTemplate&gt;<br>
	&lt;ItemTemplate&gt;<br>
<br>
		&lt;td class="sender"&gt;<br>
			#{sender} #{displaydate}<br>
		&lt;/td&gt;<br>
<br>
	&lt;/ItemTemplate&gt;<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
更多使用方法和说明请参考 <a href='JERepeaterGroup.md'>Repeater 数据分组</a>.</blockquote>

<blockquote><h4><font color='green'>处理控件</font></h4>
除了上面所说的绑定 jQueryUI 插件, 对于一些 html 元素, 也有很多的处理方式:<br>
<pre><code>&lt;select je-id="major"&gt;<br>
	&lt;option value="jsj" je-selected="'#{major}' == 'jsj'"&gt;计算机&lt;/option&gt;<br>
	&lt;option value="gsgl" je-selected="'#{major}' == 'gsgl'"&gt;工商管理&lt;/option&gt;<br>
	&lt;option value="hy" je-selected="'#{major}' == 'hy'"&gt;汉语&lt;/option&gt;<br>
&lt;/select&gt;<br>
<br>
&lt;input je-id="major" je-autocomplete="source=['jsj','gsgl','hy']" value="#{major}" /&gt;<br>
<br>
&lt;input je-id="birthday"<br>
	je-datepicker="dateFormat='yy-mm-dd'"<br>
	type="text"<br>
	value="#{birthday,jQuery.panzer.formatDate(#,'yyyy-MM-dd')}" /&gt;<br>
</code></pre>
更多使用方法和说明请参考 <a href='JERepeaterWidget.md'>Repeater 处理控件</a>.</blockquote>

<blockquote><h4><font color='green'>消息提示</font></h4>
如果需要为用户显示 <b>repeater</b> 当前的操作或者结果, 则可以使用 showtip 函数或者设置 FieldMask 属性, 详细内容请参考 <a href='JERepeaterShowTip.md'>Repeater 消息提示</a>, 这里不再说明.</blockquote>

<blockquote><h4><font color='green'>检索数据</font></h4>
在多数情况下, 都会使用到数据检索的功能, 通过 Repeater 的 FilterTemplate 和 FilterField 等属性即可实现数据检索, 详细内容请参考 <a href='JERepeaterSearch.md'>Repeater 检索数据</a>.</blockquote>

<blockquote><h4><font color='green'>排序</font></h4>
使用 togglesort 函数就可以完成对字段的排序, 再配合 je-class 在不同排序状态下显示不同样式, 详细内容请参考 <a href='JERepeaterSorting.md'>Repeater 排序</a>.</blockquote>

<blockquote><h4><font color='green'>多行操作</font></h4>
可以使用 customselected, removeselected 函数来对 <b>repeater</b> 中选中的多个行进行操作, 详细内容请参考 <a href='JERepeaterMulti.md'>Repeater 多行操作</a>.</blockquote>

<blockquote><h4><font color='green'>事件</font></h4>
在 Repeater 所有的事件中都有具有 pe 和 e 两个参数, pe.option 中包含了 <b>repeater</b> 中的选项, pe.jquery 表示当前 <b>repeater</b>, e 则包含了事件的相关数据.</blockquote>

<blockquote>PreUpdate, Updated 更新前后的事件, PreRemove, Removed 删除前后的事件, PreInsert, Inserted 新建前后的事件. e.row 表示当前参与相关操作的行, e.index 表示行的索引, 而 Updated, Removed, Inserted 中 e.issuccess, 表示是否执行成功, 示例:<br>
<pre><code>&lt;je:Repeater ID="studentRepeater" runat="server"<br>
<br>
	PreUpdate="<br>
	function(pe, e){<br>
		if(e.row.realname == '' || e.row.age == '' || e.row.birthday == ''){<br>
			$('#message').text('请将信息填写完整');<br>
			return false;<br>
		}<br>
	}<br>
	" PreInsert="<br>
	function(pe, e){<br>
		if(e.row.realname == '' || e.row.age == '' || e.row.birthday == ''){<br>
			$('#message').text('请将信息填写完整');<br>
			return false;<br>
		}<br>
	}<br>
	" PreRemove="<br>
	function(pe, e){<br>
		if(!confirm('是否删除 ' + e.row.realname)){<br>
			return false;<br>
		}<br>
	}<br>
	" Updated="<br>
	function(pe, e){<br>
		$('#message').text('更新 ' + e.row.realname + (e.issuccess ? ' 成功' : ' 失败'));<br>
	}<br>
	" Inserted="<br>
	function(pe, e){<br>
		$('#message').text('新建 ' + e.row.realname + (e.issuccess ? ' 成功' : ' 失败'));<br>
	}<br>
	" Removed="<br>
	function(pe, e){<br>
		$('#message').text('删除 ' + e.row.realname + (e.issuccess ? ' 成功' : ' 失败'));<br>
	}<br>
	"&gt;<br>
<br>
&lt;/je:Repeater&gt;<br>
</code></pre>
PreFill, Filled 填充前后的事件, PreExecute, Executed 执行任何操作前后的事件, PreCustom, Customed 执行自定义操作前后的事件, 参数 e 包含 command 属性表示自定义操作的名称, PreSubStep, SubStepped 执行分布操作前后的事件, 参数 e 包含 count 属性表示总的条数, completed 属性表示已经处理完成的行数.</blockquote>

<blockquote>Navigable 当导航可用性变化时, 参数 e 包含 prev 属性表示是否有上一页, next 属性表示是否有下一页. Blocked 当有操作被阻塞时的事件.</blockquote>

<blockquote><h4><font color='green'>客户端方法</font></h4>
通过 <b><code>&lt;repeater 变量&gt;.__repeater('&lt;方法名&gt;'[, &lt;参数n&gt;])</code></b> 可以在 javascript 中调用 <b>repeater</b> 中包含的方法:</blockquote>

<table cellpadding='3' border='1' cellspacing='0' width='100%'>
<tr><td><b>方法</b></td><td><b>说明</b></td><td><b>示例</b></td></tr>
<tr><td>beginedit/begineditselected</td><td>开始编辑指定索引/选中的行.</td><td><code>&lt;repeater 变量&gt;.__repeater('beginedit', 0)</code> <code>&lt;repeater 变量&gt;.__repeater('begineditselected')</code></td></tr>
<tr><td>bind</td><td>绑定, 不会重新获取数据, 仅仅将现有数据绑定的到 <b>repeater</b>.</td><td><code>&lt;repeater 变量&gt;.__repeater('bind')</code></td></tr>
<tr><td>custom/customselected</td><td>对指定/所有的行执行自定义操作.</td><td><code>&lt;repeater 变量&gt;.__repeater('custom', 0)</code> <code>&lt;repeater 变量&gt;.__repeater('customselected')</code></td></tr>
<tr><td>endedit</td><td>结束编辑指定索引的行, 不保存编辑的内容.</td><td><code>&lt;repeater 变量&gt;.__repeater('endedit', 0)</code></td></tr>
<tr><td>fill</td><td>填充数据, 将调用服务端相关的方法.</td><td><code>&lt;repeater 变量&gt;.__repeater('fill')</code></td></tr>
<tr><td>filter</td><td>搜索, 和填充数据类似, 但是页码将变为 1.</td><td><code>&lt;repeater 变量&gt;.__repeater('filter')</code></td></tr>
<tr><td>first/last</td><td>跳转到第一页/最后一页.</td><td><code>&lt;repeater 变量&gt;.__repeater('first')</code></td></tr>
<tr><td>getrow</td><td>获取指定索引的行.</td><td><code>&lt;repeater 变量&gt;.__repeater('getrow', 0)</code></td></tr>
<tr><td>goto/next/prev</td><td>跳转到指定的页/下一页/上一页.</td><td><code>&lt;repeater 变量&gt;.__repeater('goto', 2)</code> <code>&lt;repeater 变量&gt;.__repeater('next')</code></td></tr>
<tr><td>hidetip/showtip</td><td>隐藏/显示提示.</td><td><code>&lt;repeater 变量&gt;.__repeater('hidetip')</code> <code>&lt;repeater 变量&gt;.__repeater('showtip', '请输入姓名')</code></td></tr>
<tr><td>insert</td><td>调用服务端方法新建行.</td><td><code>&lt;repeater 变量&gt;.__repeater('insert')</code></td></tr>
<tr><td>remove/removeselected</td><td>删除指定/所有的行.</td><td><code>&lt;repeater 变量&gt;.__repeater('remove', 0)</code> <code>&lt;repeater 变量&gt;.__repeater('removeselected')</code></td></tr>
<tr><td>select/unselect/toggleselect</td><td>设置/取消/切换指定索引的行的选中状态.</td><td><code>&lt;repeater 变量&gt;.__repeater('select', 0)</code></td></tr>
<tr><td>selectall/unselectall/toggleselectall</td><td>设置/取消/切换所有行的选中状态.</td><td><code>&lt;repeater 变量&gt;.__repeater('selectall')</code></td></tr>
<tr><td>setfilter</td><td>设置过滤条件.</td><td><code>&lt;repeater 变量&gt;.__repeater('setfilter', age, 12)</code></td></tr>
<tr><td>setgroup</td><td>设置分组字段.</td><td><code>&lt;repeater 变量&gt;.__repeater('setgroup', 'name')</code></td></tr>
<tr><td>setrow</td><td>设置指定索引的行的数据, 并指定是否重新绑定.</td><td><code>&lt;repeater 变量&gt;.__repeater('setrow', 0, {age: 10}, true)</code></td></tr>
<tr><td>sort/togglesort</td><td>设置/切换排序条件.</td><td><code>&lt;repeater 变量&gt;.__repeater('sort', 'id', 'desc')</code> <code>&lt;repeater 变量&gt;.__repeater('togglesort', 'id')</code></td></tr>
<tr><td>update</td><td>调用服务端方法更新指定索引的行.</td><td><code>&lt;repeater 变量&gt;.__repeater('update', 0)</code></td></tr>
</table>

<h3>相关内容</h3>
<blockquote><a href='JERepeaterBindField.md'>Repeater 绑定/处理字段</a></blockquote>

<blockquote><a href='JERepeaterSubView.md'>Repeater 子视图</a></blockquote>

<blockquote><a href='JERepeaterGroup.md'>Repeater 数据分组</a></blockquote>

<blockquote><a href='JERepeaterWidget.md'>Repeater 处理控件</a></blockquote>

<blockquote><a href='JERepeaterShowTip.md'>Repeater 消息提示</a></blockquote>

<blockquote><a href='JERepeaterSearch.md'>Repeater 检索数据</a></blockquote>

<blockquote><a href='JERepeaterSorting.md'>Repeater 排序</a></blockquote>

<blockquote><a href='JERepeaterMulti.md'>Repeater 多行操作</a></blockquote>

<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-11-17: 增加相关内容和一个对 Repeater 验证功能介绍的链接.</blockquote>

<blockquote>2011-11-19: 增加 Repeater 消息提示介绍的链接.</blockquote>

<blockquote>2011-11-22: 增加 Repeater 检索功能介绍的链接.</blockquote>

<blockquote>2011-11-25: 增加 Repeater 排序功能介绍的链接.</blockquote>

<blockquote>2011-11-26: 修改关于引用 jQueryUI 的介绍.</blockquote>

<blockquote>2011-12-5: 修改下载的链接, 增加 Repeater 多行操作介绍的链接.</blockquote>

<blockquote>2011-12-20: 修改 Parameter 对象的介绍.</blockquote>

<blockquote>2012-1-26: 增加关于 ResourceLoader 的链接.</blockquote>

</font>
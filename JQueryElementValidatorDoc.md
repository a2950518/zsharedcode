#summary Validator 完全参考
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementValidatorDoc'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /validator/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/vz3kFojbU58/'>www.tudou.com/programs/view/vz3kFojbU58/</a></blockquote>

<blockquote>本文将系统讲解 Validator 控件的功能以及使用过程中的注意事项和技巧, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>客户端验证<br>
<ul><li>必需填写<br>
</li><li>字符串长度范围<br>
</li><li>数值大小范围<br>
</li><li>验证邮箱, 网址, 日期<br>
</li></ul></li><li>获取是否验证成功和转化后的数据<br>
</li><li>服务器端验证</li></ul>

<img src='http://zsharedcode.googlecode.com/files/weiboregister1.jpg' />

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

<h3>客户端验证</h3>
<blockquote>通过简单的介绍 Validator 的属性, 便可以大致的了解如何进行客户端验证:</blockquote>

<blockquote>DefaultValue 表示在用户没有输入值时的默认值, 可以设置为字符串, 数值等, 比如: 'abc', 100.</blockquote>

<blockquote>Target/Equal 表示目标/匹配目标的选择器, 比如: #pw, #pw2, 不同于 Selector 属性, Target 和 Equal 不需要为选择器添加单引号, 如果不设置 Equal 则表示不判断两个目标的值是否相同.</blockquote>

<blockquote>Tip 表示在不符合某个规则时的提示信息, SuccessTip 除外, 因为 SuccessTip 表示验证成功时的信息, 比如: <code>MaxTip="最大值不能超过 100"</code>.</blockquote>

<blockquote>Event 表示触发验证操作的事件, 默认为 change.</blockquote>

<blockquote>Max/Min 如果数据为字符串, 则表示字符串的最大/最小长度, 如果数据为数值, 则表示数值的最大/最小值.</blockquote>

<blockquote>Name 为验证项设置的名称, 一般不设置.</blockquote>

<blockquote>Need 表示数据是否是必需的, 默认为 false.</blockquote>

<blockquote>Provider 为一个自定义的格式转换函数.</blockquote>

<blockquote>Reg 为一个数据必须符合的 javascript 正则表达式, 比如: /^d+$/.</blockquote>

<blockquote>ShowTip 表示是否显示提示, 默认为 true.</blockquote>

<blockquote>Type 表示一种数据类型, 可以是 string, number, boolean, date 中的一种, 如果设置为 string, number, boolean, 则表示数据应该可以被转化为字符串, 数值, 布尔值. 如果需要判断字符串最小长度大于等于 1, 在设置 <code>Min="1"</code> 的同时, 还需要设置 <code>Type="string"</code> 来表示是针对字符串的判断. 设置 Type 为 date 并不能判断数据是否为一个日期, 而是试图在 Ajax 中将数据转化为日期格式的字符串, 如果需要判断数据是否为日期格式, 请设置 <code>Reg="$.panzer.reg.dateISO"</code>.</blockquote>

<blockquote><h4><font color='green'>必需填写</font></h4>
设置 Need 属性为 true, 即可限制目标不能为空:<br>
<pre><code>&lt;input id="email" type="text" /&gt;<br>
&lt;je:Validator ID="vEmail" runat="server" IsVariable="true"<br>
	Target="#email" Need="true"<br>
	NeedTip='&lt;font color="red"&gt;请填写您的邮箱地址&lt;/font&gt;'<br>
	&gt;<br>
&lt;/je:Validator&gt;<br>
</code></pre>
代码中, 设置 Target 为 #email, 表示 Validator 的验证目标是 id 为 email 的文本框. Need 设置为 true, 表示用户必须填写邮箱地址. NeedTip 表示在没有填写邮箱地址时的提示信息, 可以包含 html 代码.</blockquote>

<blockquote><h4><font color='green'>字符串长度范围</font></h4>
通过设置 Max 和 Min 就可以限制字符串的长度, 建议同时设置 <code>Type="string"</code>, 因为如果不设置数据类型和默认值, 那么没有输入值将默认为 '':<br>
<pre><code>&lt;input id="password" type="password" /&gt;<br>
&lt;je:Validator ID="vPassword" runat="server" IsVariable="true" Target="#password"<br>
	Min="4" MinTip='&lt;font color="red"&gt;密码长度至少 4 位&lt;/font&gt;'<br>
	Max="10" MaxTip='&lt;font color="red"&gt;密码长度最多 10 位&lt;/font&gt;'&gt;<br>
&lt;/je:Validator&gt;<br>
</code></pre>
代码中并没有像建议中提到的设置 <code>Type="string"</code>, 因为即便默认为 '', 长度仍然是小于 4 的.</blockquote>

<blockquote><h4><font color='green'>数值大小范围</font></h4>
和限制字符串类似, 设置 Max 和 Min 同样可以限制数值的大小范围, 同时需要设置 <code>Type="number"</code>:<br>
<pre><code>&lt;input id="age" type="text" /&gt;<br>
&lt;je:Validator ID="vAge" runat="server" IsVariable="true" Target="#age"<br>
	Type="number" TypeTip='&lt;font color="red"&gt;请填写一个数字&lt;/font&gt;'<br>
	Min="10" MinTip="不能小于 10 岁"<br>
	Max="200" MaxTip="您还活着吗?"&gt;<br>
&lt;/je:Validator&gt;<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>验证邮箱, 网址, 日期</font></h4>
使用 Reg 属性可以使验证的功能更大强大, 可以使用在 <code>$.panzer.reg</code> 中预设的几个正则表达式来判断邮箱等格式:<br>
<pre><code>&lt;input id="email" type="text" /&gt;<br>
&lt;je:Validator ID="vEmail" runat="server" IsVariable="true" Target="#email"<br>
	Reg="$.panzer.reg.email" RegTip='&lt;font color="red"&gt;请填写一个正确的邮箱地址&lt;/font&gt;'&gt;<br>
&lt;/je:Validator&gt;<br>
</code></pre>
除了使用 <code>$.panzer.reg.email</code>, 你还可以使用 url 来验证网址, 使用 dateISO 来验证格式类似于 '2011-1-1' 的字符串.</blockquote>

<h3>获取是否验证成功和转化后的数据</h3>
<blockquote>使用客户端属性 valid 可以获取某个 Validator 控件对应的目标验证是否通过, 使用 value 则可以获取目标包含的数据:<br>
<pre><code>function refresh(value, tip, valid) {<br>
<br>
	if (vEmail.__validator('option', 'valid') &amp;&amp;<br>
		vPassword.__validator('option', 'valid') &amp;&amp;<br>
		vNickname.__validator('option', 'valid') &amp;&amp;<br>
		vAge.__validator('option', 'valid'))<br>
		cmdRegister.button('enable');<br>
	else<br>
		cmdRegister.button('disable');<br>
<br>
}<br>
</code></pre>
代码中的 vEmail 等为 Validator 控件的 ID, 这需要设置 Validator 的 IsVariable 属性为 true, 访问 <b>validator</b> 的 valid 属性, 可以获取到最后一次验证的结果, 如果返回 true, 则表示验证是成功的.</blockquote>

<blockquote>javascript 函数 refresh 将设置为每一个 Validator 控件的 Checked 事件, 这样在 <b>validator</b> 验证完目标后会调用 refresh, 来决定是否让注册按钮可用.</blockquote>

<blockquote>下面是注册按钮的代码, 点击按钮将调用方法 RegisterWeibo, 而参数的值是通过 <b>validator</b> 的 value 属性来获取的.<br>
<pre><code>&lt;je:Button ID="cmdRegister" runat="server" IsVariable="true" Label="注册" Disabled="true"&gt;<br>
	&lt;ClickAsync Url="webservice.asmx" MethodName="RegisterWeibo" Success="<br>
		function(data){<br>
		alert(data);<br>
		}<br>
		"&gt;<br>
		&lt;je:Parameter Name="email" Type="Expression"<br>
			Value="vEmail.__validator('option', 'value')" /&gt;<br>
		&lt;je:Parameter Name="password" Type="Expression"<br>
			Value="vPassword.__validator('option', 'value')" /&gt;<br>
		&lt;je:Parameter Name="nickname" Type="Expression"<br>
			Value="vNickname.__validator('option', 'value')" /&gt;<br>
		&lt;je:Parameter Name="age" Type="Expression"<br>
			Value="vAge.__validator('option', 'value')" /&gt;<br>
	&lt;/ClickAsync&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
也可以设置 Parameter 的 Type 属性为 Selector, Value 为选择器来获取文本框的值, 并配合 DataType 来设置传递给服务器的数据类型, 而这里使用 <b>validator</b> 的 value 属性也能达到同样的效果, 因为 value 的类型也就是通过 Validator 的 Type 属性设置的类型, 请参考 <a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a>.</blockquote>

<h3>服务器端验证</h3>
<blockquote>除了可以在客户端, 也可以在服务器端验证内容的合法性, 比如, 在服务器端验证昵称是否已经被注册:<br>
<pre><code>&lt;input id="nickname" type="text" /&gt;<br>
&lt;je:Validator ID="vNickname" runat="server"<br>
	Target="#nickname"<br>
	<br>
	&gt;<br>
<br>
	&lt;CheckAsync Url="webservice.asmx" MethodName="CheckNickname"<br>
		Success="<br>
		function(pe, e){<br>
					<br>
			if(!e.valid &amp;&amp; null != e.tip){<br>
				pe.jquery.html(e.tip);<br>
			}<br>
<br>
		}<br>
		"&gt;<br>
	&lt;/CheckAsync&gt;<br>
<br>
&lt;/je:Validator&gt;<br>
</code></pre>
通过 CheckAsync 可以设置验证时的 Ajax 操作设置, 这里调用了服务器端的 CheckNickname 方法. 在 Success 属性中设置处理返回结果的 javascript 函数, 参数 e 包含 value, tip, valid, custom 四个属性, 分别表示验证后的值, 提示信息, 是否验证成功, 以及一个自定义对象, 参数 pe 的 jquery 属性表示 <b>validator</b> 自身.</blockquote>

<blockquote>下面是服务器端的 CheckNickname 方法:<br>
<pre><code>[WebMethod]<br>
[ScriptMethod]<br>
public SortedDictionary&lt;string, object&gt; CheckNickname ( string value )<br>
{<br>
	this.Context.Response.Cache.SetNoStore ( );<br>
<br>
	SortedDictionary&lt;string, object&gt; values = new SortedDictionary&lt;string, object&gt; ( );<br>
	values.Add ( "value", value );<br>
	values.Add ( "tip", value == "abc" ?<br>
		"&lt;font color=\"red\"&gt;abc 这个昵称已经被注册了, 请换一个吧&lt;/font&gt;" : null );<br>
	values.Add ( "valid", value != "abc" );<br>
<br>
	return values;<br>
}<br>
</code></pre>
对于服务器端验证的方法应该具有名为 value 的参数, 参数的类型可以是 int, string, bool 等, 方法应该返回如下格式的 JSON:<br>
<pre><code>{<br>
	"value": &lt;值&gt;,<br>
	"tip": &lt;提示&gt;,<br>
	"valid": &lt;表示是否成功的布尔值, 为 true 或者 false&gt;<br>
	[, "custom": &lt;自定义对象, 比如: { message: 'ok' }&gt;]<br>
}<br>
</code></pre></blockquote>

<h3>相关内容</h3>
<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-11-26: 修改关于引用 jQueryUI 的介绍.</blockquote>

<blockquote>2011-12-5: 修改下载的链接.</blockquote>

<blockquote>2012-1-26: 增加关于 ResourceLoader 的链接.</blockquote>

</font>
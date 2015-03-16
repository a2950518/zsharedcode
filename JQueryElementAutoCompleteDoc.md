#summary Autocompelete 完全参考
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementAutoCompleteDoc'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /autocomplete/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/fZu-HcdijZA/'>www.tudou.com/programs/view/fZu-HcdijZA/</a></blockquote>

<blockquote>本文将说明 Autocomplete 控件的功能以及使用过程中的注意事项和技巧, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>Source 属性<br>
<ul><li>数组<br>
</li><li>地址<br>
</li><li>函数<br>
</li></ul></li><li>Delay 属性<br>
</li><li>MinLength 属性<br>
</li><li>其它属性和事件</li></ul>

<img src='http://zsharedcode.googlecode.com/files/acgoogle1.jpg' />

<h3>准备</h3>
<blockquote>请确保已经在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 最新的版本.</blockquote>

<blockquote>请使用指令引用如下的命名空间:<br>
<pre><code>&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"<br>
	Namespace="zoyobar.shared.panzer.ui.jqueryui"<br>
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

<h3>Source 属性</h3>
<blockquote>Source 属性是 Autocomplete 重要的属性之一, 包含建议的条目, 可以是如下三种形式: 数组, 一个返回数组的地址, 或者一个函数.</blockquote>

<blockquote><h4><font color='green'>数组</font></h4>
Source 属性可以被设置为一个 javascript 数组, 形式为: <b><code>['条目 1', '条目 N']</code></b> 或者 <b><code>[{ label: '条目 1', value: '值 1' }, { label: '条目 N', value: '值 N' }]</code></b>. 后一种形式中, label 表示建议条目的文本, value 则表示选择某个条目后, 文本框显示的文本:<br>
<pre><code>&lt;je:Autocomplete ID="aA" runat="server"<br>
	Source="['vs 2002','vs 2003','vs 2005','vs 2008','vs 2010']"&gt;<br>
&lt;/je:Autocomplete&gt;<br>
</code></pre>
上面的代码中, 如果用户输入了 vs 201, 则将显示建议的条目 vs 2010.</blockquote>

<blockquote><h4><font color='green'>地址</font></h4>
如果将 Source 属性指定为一个地址, 则该地址应该返回一个 javascript 数组, 形式和上面提到的相同:<br>
<pre><code>&lt;je:Autocomplete ID="aA" runat="server"<br>
	Source="'http:// ... /source.js'"&gt;<br>
&lt;/je:Autocomplete&gt;<br>
</code></pre>
需要说明的是, 这里的<b>地址需要使用单引号括住</b>, 否则将产生错误. 而上面的 source.js 可能如下:<br>
<pre><code>["tom", "tomas", "li", "lili"]<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>函数</font></h4>
使用函数可以动态的根据用户的输入显示建议条目, 但并不需要来编写这个函数, 因为在 Autocomplete 中可以通过 SourceAsync 属性来完成:<br>
<pre><code>&lt;je:Autocomplete ID="k" runat="server"<br>
	SourceAsync-Url="google_getitem.ashx"&gt;<br>
&lt;/je:Autocomplete&gt;<br>
</code></pre>
代码中, SourceAsync-Url 被设置为 google_getitem.ashx, 因此当用户输入变化时, <b>autocomplete</b> 将访问 google_getitem.ashx 来获取建议条目, google_getitem.ashx 的 ProcessRequest 方法:<br>
<pre><code>public void ProcessRequest ( HttpContext context )<br>
{<br>
	context.Response.ContentType = "text/javascript";<br>
	context.Response.Cache.SetNoStore ( );<br>
<br>
	string term = context.Request["term"];<br>
	List&lt;object&gt; items = new List&lt;object&gt; ( );<br>
<br>
	for ( int index = 0; index &lt; term.Length; index++ )<br>
		items.Add ( term + "-" + term.Substring ( 0, index + 1 ) );<br>
<br>
	context.Response.Write ( new JavaScriptSerializer ( ).Serialize (<br>
		SampleHelper.CreateJSONArray ( items.ToArray ( ) ) )<br>
		);<br>
<br>
	/*<br>
	 * [<br>
	 *	"建议词条1", "建议词条2"<br>
	 * ]<br>
	 * <br>
	 * [<br>
	 *  { "label": "建议词条1", "value": "实际内容1" },<br>
	 *  { "label": "建议词条2", "value": "实际内容2" }<br>
	 * ]<br>
	 * */<br>
}<br>
</code></pre>
在代码中, 通过 Request 对象获取了 term 参数, 这个参数是 <b>autocomplete</b> 传递来的, 表示了用户当前输入的文本. 根据 term 参数, 就能生成建议的条目, 并以 javascript 数组的形式返回给客户端.</blockquote>

<blockquote>如果需要在不同 .NET 版本中返回数据, 请参考 <a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a>.</blockquote>

<h3>Delay 属性</h3>
<blockquote>Delay 属性表示触发匹配操作的延迟, 默认为 300 毫秒.</blockquote>

<h3>MinLength 属性</h3>
<blockquote>MinLength 属性表示触发匹配操作的最少字符数, 也就是当用户输入多少个字符后才会进行匹配.</blockquote>

<h3>其它属性和事件</h3>
<blockquote>至于 <b>autocomplete</b> 的其它属性和事件, 可以参考 <a href='http://docs.jquery.com/UI/Autocomplete'>docs.jquery.com/UI/Autocomplete</a>.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

<blockquote>2012-1-26: 增加关于 ResourceLoader 的链接.</blockquote>

</font>
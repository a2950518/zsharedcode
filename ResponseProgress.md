#summary 显示页面加载进度
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/ResponseProgress'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /responseprogress/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/J3KX4SDMOjk/'>www.tudou.com/programs/view/J3KX4SDMOjk/</a></blockquote>

<blockquote>本文将说明如何使用 ResponseProgress 类来显示页面的加载进度:</blockquote>

<ul><li>准备<br>
</li><li>一个简单的例子<br>
</li><li>自定义模板<br>
</li><li>自定义函数</li></ul>

<img src='http://zsharedcode.googlecode.com/files/responseprogress1.jpg' />

<img src='http://zsharedcode.googlecode.com/files/responseprogress2.jpg' />

<h3>准备</h3>
<blockquote>请确保已经在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 最新的版本.</blockquote>

<blockquote>请在代码中引用如下的命名空间:<br>
<pre><code>using zoyobar.shared.panzer.web;<br>
</code></pre></blockquote>

<h3>一个简单的例子</h3>
<blockquote>在页面的 Page_Load 方法中, 可以创建 ResponseProgress 类并调用 Register, Set, Hide 方法来显示页面载入进度:<br>
<pre><code>using System.Threading;<br>
using zoyobar.shared.panzer.web;<br>
<br>
public partial class ResponseProgress_DefaultTemplate : System.Web.UI.Page<br>
{<br>
<br>
	protected void Page_Load(object sender, EventArgs e)<br>
	{<br>
		ResponseProgress progress = new ResponseProgress ( this.Response );<br>
<br>
		progress.Register ( );<br>
<br>
		progress.Set ( 1, "欢迎来到这里" );<br>
		Thread.Sleep ( 2000 );<br>
<br>
		progress.Set ( 100, "页面载入完成" );<br>
		Thread.Sleep ( 2000 );<br>
		progress.Hide ( );<br>
	}<br>
<br>
}<br>
</code></pre>
在上面的示例中, 为 ResponseProgress 传递了一个 HttpResponse 对象作为参数.</blockquote>

<blockquote>在 ResponseProgress 对象创建之后, 需要首先调用 Register 方法来将一些 html 和 javascript 函数注册到当前页面中. Register 方法会设置 HttpResponse 对象的 BufferOutput 属性为 false.</blockquote>

<blockquote>调用 ResponseProgress 的 Set 方法来设置需要显示给用户的内容, 参数 percent 表示载入的进度, 如果小于 0 则不显示进度, 参数 message 表示提示消息, 如果为 null 则不显示.</blockquote>

<blockquote>最后, 可以通过 Hide 方法来隐藏已经显示的内容. 代码中, 还调用了 Thread 的 Sleep 方法, 这可以确保在测试时看到进度消息.</blockquote>

<blockquote>以上提到的 3 个方法, 都会在结束时调用 HttpResponse 对象的 Flush 和 ClearContent 方法.</blockquote>

<h3>自定义模板</h3>
<blockquote>可以定义自己的模板, 请看下面的 CustomTemplate.htm 文件:<br>
<pre><code>&lt;body&gt;<br>
	&lt;center&gt;<br>
		&lt;div id="__progress"<br>
			style="width: 400px; padding: 10px"&gt;<br>
			&lt;div id="__message"<br>
				style="font-size: x-large; color: Green; text-align: left"&gt;<br>
				...<br>
			&lt;/div&gt;<br>
			&lt;div<br>
				style="font-size: xx-small; color: Blue; text-align: right;"&gt;<br>
				&lt;span id="__percent"&gt;&lt;/span&gt;<br>
			&lt;/div&gt;<br>
		&lt;/div&gt;<br>
	&lt;/center&gt;<br>
&lt;/body&gt;<br>
</code></pre>
如果没有自定义函数, 那么需要在模板中包含 id 为 progress, message 和 percent 的 3 个元素, 其中 id 为 message 的元素用于显示消息, id 为 percent 的元素用于显示百分比. 而整个的模板需要一个 body 元素.</blockquote>

<blockquote>在创建 ResponseProgress 类时, 需要传递自定义模板的路径:<br>
<pre><code>ResponseProgress progress =<br>
	new ResponseProgress ( this.Response,<br>
	@"~/responseprogress/CustomTemplate.htm"<br>
	);<br>
</code></pre></blockquote>

<h3>自定义函数</h3>
<blockquote>除了自定义模板, 也可以自定义函数:<br>
<pre><code>&lt;body&gt;<br>
	&lt;center&gt;<br>
		&lt;div id="bar"<br>
			style="width: 500px; padding: 10px"&gt;<br>
			&lt;div id="msg"<br>
				style="font-size: x-large; color: Red; text-align: left"&gt;<br>
				...<br>
			&lt;/div&gt;<br>
			&lt;div<br>
				style="font-size: xx-small; color: Gray; text-align: right;"&gt;<br>
				&lt;span id="per"&gt;&lt;/span&gt;<br>
			&lt;/div&gt;<br>
		&lt;/div&gt;<br>
	&lt;/center&gt;<br>
&lt;/body&gt;<br>
&lt;script type="text/javascript"&gt;<br>
	function showBar(data) {<br>
		document.getElementById('msg').innerText =<br>
			(null == data.message ? '没有消息' :<br>
				(data.message + ' ' + data.message.length.toString() + ' 个字符'));<br>
<br>
		document.getElementById('per').innerText =<br>
			(null == data.percent ? '没有百分比' : data.percent.toString() + ' per');<br>
	}<br>
	function hideBar() {<br>
		document.getElementById('bar').style.display = 'none';<br>
	}<br>
&lt;/script&gt;<br>
</code></pre>
一旦定义了自己的函数, 那么不需要再定义 id 为 progress, message 和 percent 的元素. 而函数名称也不是固定的, 上面的模板中, 函数 showBar 用来显示进度信息, 函数 hideBar 用来隐藏进度信息.</blockquote>

<blockquote>函数 hideBar 比较简单, 隐藏了 id 为 bar 的 div 元素. 函数 showBar 的第一个参数 data 包含了进度信息, data 的 message 属性表示提示消息, percent 属性表示百分比.</blockquote>

<blockquote>最后, 将这 2 个函数的名字传递给 ResponseProgress 即可:<br>
<pre><code>ResponseProgress progress =<br>
	new ResponseProgress ( this.Response,<br>
	@"~/responseprogress/CustomTemplate.htm",<br>
	"showBar", "hideBar"<br>
	);<br>
</code></pre></blockquote>

</font>
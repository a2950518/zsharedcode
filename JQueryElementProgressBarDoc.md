#summary Progressbar 完全参考
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementProgressBarDoc'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /progressbar/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/nkhyRcOuu6M/'>www.tudou.com/programs/view/nkhyRcOuu6M/</a></blockquote>

<blockquote>本文将说明 Progressbar 控件的功能以及使用过程中的注意事项和技巧, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>进度<br>
</li><li>附录: 显示资料完善度</li></ul>

<img src='http://zsharedcode.googlecode.com/files/userinfo1.jpg' />

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

<h3>进度</h3>
<blockquote>通过 Value 属性可以初始化 Progressbar 的进度, Value 应该在 0 到 100 之间.</blockquote>

<blockquote>也可以在客户端使用 javascript 来设置或获取 <b>progressbar</b> 的进度, 详细可以参考 <a href='http://docs.jquery.com/UI/Progressbar'>docs.jquery.com/UI/Progressbar</a>:<br>
<pre><code>&lt;je:Progressbar ID="pb" runat="server" ScriptPackageID="package"<br>
	CssClass="info-bar" IsVariable="true"&gt;<br>
&lt;/je:Progressbar&gt;<br>
<br>
&lt;script type="text/javascript"&gt;<br>
	$(function () {<br>
		var p = progressbar('option', 'value');<br>
		p += 20;<br>
<br>
		pb.progressbar('option', 'value', p);<br>
	});<br>
&lt;/script&gt;<br>
</code></pre>
在上面的示例中, 设置 Progressbar 的 IsVariable 属性为 true, 生成一个同名的 javascript 变量 pb. 然后通过 pb 来获取和设置 <b>progressbar</b> 的进度.</blockquote>

<h3>附录: 显示资料完善度</h3>
<blockquote>在这一节中, 将使用 Progressbar 来显示用户资料的完善度:<br>
<pre><code>&lt;je:Progressbar ID="pb" runat="server" ScriptPackageID="package" Value="20"&gt;<br>
&lt;/je:Progressbar&gt;<br>
<br>
...<br>
<br>
&lt;je:ScriptPackage ID="package" runat="server" /&gt;<br>
</code></pre>
这里实现了一个进度条, 其对应的 javascript 脚本将生成到 ID 为 package 的 ScriptPackage 控件中.</blockquote>

<blockquote>在页面载入后, 将调用由 AjaxManager 生成的 init 函数:<br>
<pre><code>&lt;je:AjaxManager ID="ajax" runat="server"&gt;<br>
	&lt;je:AjaxSetting ClientFunction="init" Url="userinfo1.ashx" Success="<br>
		function(data){<br>
			$('#prec').text(-:data.prec + '%');<br>
			pb.progressbar('option', 'value', -:data.prec);<br>
<br>
			$('#realname').val(-:data.realname);<br>
			$('#nickname').val(-:data.nickname);<br>
			$('#email').val(-:data.email);<br>
			$('#sex').val(-:data.sex);<br>
			$('#birthday').val(-:data.birthday);<br>
		}<br>
		"&gt;<br>
		&lt;je:Parameter Name="c" Type="Expression" Value="'get'" /&gt;<br>
	&lt;/je:AjaxSetting&gt;<br>
&lt;/je:AjaxManager&gt;<br>
<br>
...<br>
<br>
&lt;script type="text/javascript"&gt;<br>
	$(function () {<br>
		init();<br>
	});<br>
&lt;/script&gt;<br>
</code></pre>
init 函数的作用是从 userinfo1.ashx 获取用户信息, 其中包含资料完善度, 并将这些信息显示在页面上. 有关更多 AjaxManager 的信息, 请参考 <a href='AjaxManager.md'>生成调用服务器端方法的 javascript 函数</a>.</blockquote>

<blockquote>在上面的代码中, <code>-:data</code> 将根据不同的 .NET 版本替换为 data 或者 data.d, 详细请参考 <a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a>.</blockquote>

<blockquote>最后, 需要一个保存的按钮:<br>
<pre><code>&lt;je:Button ID="cmdSave" runat="server" ScriptPackageID="package" Label="即使警告也可以保存"&gt;<br>
	&lt;ClickAsync Url="userinfo1.ashx" Success="<br>
	function(data){<br>
		$('#prec').text(-:data.prec + '%');<br>
		pb.progressbar('option', 'value', -:data.prec);<br>
<br>
		alert('设置完毕');<br>
	}<br>
	"&gt;<br>
		&lt;je:Parameter Name="c" Type="Expression" Value="'save'" /&gt;<br>
		&lt;je:Parameter Name="realname" Type="Selector" Value="#realname" /&gt;<br>
		&lt;je:Parameter Name="nickname" Type="Selector" Value="#nickname" /&gt;<br>
		&lt;je:Parameter Name="email" Type="Selector" Value="#email" /&gt;<br>
		&lt;je:Parameter Name="sex" Type="Selector" Value="#sex" /&gt;<br>
		&lt;je:Parameter Name="birthday" Type="Selector" Value="#birthday" /&gt;<br>
	&lt;/ClickAsync&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
当点击按钮时, 将页面上的用户信息传递给 userinfo1.ashx, userinfo1.ashx 将返回资料完善度.</blockquote>

<blockquote>在 AjaxManager 和 Button 的 ClickAsync 中, 都使用了 Parameter 来增加参数, 更多内容可以参考 <a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a>.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='AjaxManager.md'>生成调用服务器端方法的 javascript 函数</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

<h3>修订历史</h3>
<blockquote>2012-1-26: 增加关于 ResourceLoader 的链接.</blockquote>

</font>
﻿#summary 生成调用服务器端方法的 javascript 函数
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/AjaxManager'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /ajaxmanager/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/Bbk5GvsEGKs/'>www.tudou.com/programs/view/Bbk5GvsEGKs/</a></blockquote>

<blockquote>本文将说明如何使用 AjaxManager 来生成调用服务器端方法的 javascript 函数, 以及如何调用这些函数:</blockquote>

<ul><li>准备<br>
</li><li>创建 javascript 函数<br>
</li><li>直接调用<br>
</li><li>通过 Async 属性调用<br>
</li><li>隐式添加的参数</li></ul>

<img src='http://zsharedcode.googlecode.com/files/ajaxmanager1.jpg' />

<h3>准备</h3>
<blockquote>请确保已经在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 最新的版本.</blockquote>

<blockquote>请使用指令引用如下的命名空间:<br>
<pre><code>&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"
	Namespace="zoyobar.shared.panzer.ui.jqueryui"
	TagPrefix="je" %&gt;
&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement"
	Namespace="zoyobar.shared.panzer.web.jqueryui"
	TagPrefix="je" %&gt;
</code></pre>
除了命名空间, 还需要引用 jQuery 的脚本:<br>
<pre><code>&lt;script type="text/javascript" src="[脚本路径]/jquery-&lt;version&gt;.min.js"&gt;&lt;/script&gt;
</code></pre>
也可以使用 ResourceLoader 来添加所需的脚本或样式, 详细请参考 <a href='ResourceLoader.md'>自动添加脚本和样式</a>.</blockquote>

<h3>创建 javascript 函数</h3>
<blockquote>在页面中添加一个 AjaxManager 控件, 来创建调用服务器端方法的 javascript 函数:<br>
<pre><code>&lt;je:AjaxManager ID="manager" runat="server"&gt;
	&lt;je:AjaxSetting
		ClientFunction="&lt;javascript 函数名&gt;"
		ClientParameter="&lt;javascript 参数, 比如: name, age&gt;"
		Url="&lt;服务器端方法地址&gt;" MethodName="&lt;服务器端方法名称&gt;"
		Success="&lt;调用成功时的 javascript 函数&gt;"
		Error="&lt;调用失败时的 javascript 函数&gt;"
		Complete="&lt;调用完成时的 javascript 函数&gt;"
		...
		&gt;
		&lt;参数&gt;
	&lt;/je:AjaxSetting&gt;
&lt;/je:AjaxManager&gt;

&lt;je:AjaxManager ID="manager" runat="server"&gt;
	&lt;je:AjaxSetting ClientFunction="add" Url="handler.ashx" Success="
	function(data){
		$('#result').text(-:data.result);
	}
	"&gt;
		&lt;je:Parameter Name="c" Type="Expression" Value="'add'" /&gt;
		&lt;je:Parameter Name="num1" Type="Selector"
			Value="#num1" DataType="Number" /&gt;
		&lt;je:Parameter Name="num2" Type="Selector"
			Value="#num2" DataType="Number" /&gt;
	&lt;/je:AjaxSetting&gt;
&lt;/je:AjaxManager&gt;
</code></pre>
上面的示例, 生成了一个名为 add 的 javascript 函数, 在此函数中将调用一般处理程序 handler.ashx 来返回 JSON 数据.</blockquote>

<blockquote>代码中的 <code>-:data</code> 将被替换为 data 或者 data.d, 更多内容请参考 <a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a>.</blockquote>

<blockquote>通过 Parameter 对象可以为 Ajax 调用增加参数, 详细内容请参考 <a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a>.</blockquote>

<h3>设置 javascript 函数的参数列表</h3>
<blockquote>通过 ClientParameter 属性, 可以为 javascript 函数设置参数列表:<br>
<pre><code>&lt;je:AjaxManager ID="manager" runat="server"&gt;
	&lt;je:AjaxSetting ClientFunction="add3" ClientParameter="othernum"
	Url="handler.ashx"
	...	&gt;
		&lt;je:Parameter Name="num3" Type="Expression" Value="othernum" /&gt;
	&lt;/je:AjaxSetting&gt;
&lt;/je:AjaxManager&gt;
</code></pre>
上面的示例中, 为 add3 函数增加了一个 othernum 参数, 而 othernum 参数将作为 num3 的值传递给服务器端. 可以像这样来调用 add3:<br>
<pre><code>&lt;input type="button" onclick="javascript:add3(1);" value="额外加 1" /&gt;
</code></pre></blockquote>

<h3>直接调用</h3>
<blockquote>在上面的例子中, 已经展示了直接调用, 就和调用普通的 javascript 函数是一样的:<br>
<pre><code>&lt;script&gt;
	$(function () {
		add3(1);
	});
&lt;/script&gt;
</code></pre></blockquote>

<h3>通过 Async 属性调用</h3>
<blockquote>对于 JQueryElement 的控件可以通过 Async 属性来调用 AjaxManager 生成的函数:<br>
<pre><code>&lt;je:Button ID="cmdSub" runat="server" IsVariable="true" Label="减" Disabled="true"
	ClickAsync-AjaxManagerID="manager" ClickAsync-ClientFunction="sub"&gt;
&lt;/je:Button&gt;
</code></pre>
通过 Async 的 AjaxManagerID 来指定需要调用的 javascript 函数所在的 AjaxManager, 通过 ClientFunction 来指定调用的 javascript 函数名称.</blockquote>

<h3>隐式添加的参数</h3>
<blockquote>部分 JQueryElement 控件会为 AjaxManager 增加 Parameter 对象, 比如 Repeater 会增加 pageindex, pagesize 等:<br>
<pre><code>&lt;je:Repeater ID="repeater" runat="server"
	FillAsync-AjaxManagerID="manager" FillAsync-ClientFunction="fill"&gt;
&lt;/je:Repeater&gt;

&lt;je:AjaxManager ID="manager" runat="server"&gt;
	&lt;je:AjaxSetting ClientFunction="fill" ClientParameter="othernum"
	Url="handler.ashx"
	...	&gt;
	&lt;/je:AjaxSetting&gt;
&lt;/je:AjaxManager&gt;
</code></pre>
虽然 AjaxManager 中的 fill 函数没有添加任何的 Parameter, 但由于 Repeater 的 FillAsync 被指定调用 fill 函数, 因此 fill 函数被隐式的添加 pageindex, pagesize 等参数.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a></blockquote>

<h3>修订历史</h3>
<blockquote>2012-1-26: 增加关于 ResourceLoader 的链接.</blockquote>

</font>
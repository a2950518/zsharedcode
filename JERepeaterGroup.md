﻿#summary Repeater 分组数据
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JERepeaterGroup'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /repeater/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/5KYgMnAdG6A/'>www.tudou.com/programs/view/5KYgMnAdG6A/</a></blockquote>

<blockquote>本文将详细的讲解 Repeater 控件中如何对数据分组, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>设置分组的字段<br>
</li><li>设置分组模板</li></ul>

<img src='http://zsharedcode.googlecode.com/files/qqmail2.jpg' />

<h3>准备</h3>
<blockquote>请先查看 <a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a> 或者准备一节的内容.</blockquote>

<h3>设置分组的字段</h3>
<blockquote>Repeater 每次只能根据一个字段来分组, 可以 GroupField 属性或者 setgroup 方法来设置用来分组的字段, 比如:<br>
<pre><code>&lt;je:Repeater ID="mailRepeater" runat="server"
	GroupField="&lt;分组字段&gt;"&gt;
	&lt;HeaderTemplate&gt;

		&lt;td class="group-header"
			je-onclick="setgroup,'&lt;分组字段&gt;';togglesort,'sender'"&gt;
			发送人
		&lt;/td&gt;

	&lt;/HeaderTemplate&gt;
&lt;/je:Repeater&gt;

&lt;je:Repeater ID="mailRepeater" runat="server"
	GroupField="displaydate"&gt;
	&lt;HeaderTemplate&gt;

		&lt;td class="group-header"
			je-onclick="setgroup,'sender';togglesort,'sender'"&gt;
			发送人
		&lt;/td&gt;

	&lt;/HeaderTemplate&gt;
&lt;/je:Repeater&gt;
</code></pre>
如果使用 setgroup 方法设置分组字段, 并不会自动重新获取数据, 所以需要调用 fill, togglesort 之类的函数来刷新数据.</blockquote>

<h3>设置分组模板</h3>
<blockquote>通过 GroupTemplate 可以设置分组模板, 这类似于一个表头, 相同分组的数据将显示在同一表头下, 比如:<br>
<pre><code>&lt;script type="text/javascript"&gt;
	function convertGroupField(groupfield) {
		switch (groupfield) {
			case 'displaydate':
				return '&lt;strong&gt;时间&lt;/strong&gt;';
			case 'sender':
				return '&lt;strong&gt;发送人&lt;/strong&gt;';
		}
	}
&lt;/script&gt;

&lt;je:Repeater ID="mailRepeater" runat="server"
	GroupField="displaydate"
	FillAsync-Url="webservice.asmx"
	FillAsync-MethodName="FillMailList"&gt;

	&lt;GroupTemplate&gt;
		&lt;tr&gt;
			&lt;td colspan="4"&gt;
				@{groupfield,convertGroupField(@)}:
				@{groupname}
			&lt;/td&gt;
		&lt;/tr&gt;
	&lt;/GroupTemplate&gt;
	&lt;ItemTemplate&gt;
		&lt;tr&gt;
			&lt;td&gt;
				&lt;input type="checkbox"
					je-checked="selected"
					je-onclick="toggleselect,false" /&gt;
			&lt;/td&gt;
			&lt;td&gt;
				#{sender}
			&lt;/td&gt;
			&lt;td&gt;
				&lt;strong&gt;#{title}&lt;/strong&gt;
			&lt;/td&gt;
			&lt;td&gt;
				&lt;strong&gt;#{displaydate}&lt;/strong&gt;
				#{receivedate,jQuery.panzer.formatDate(#,'yyyy-MM-dd h:m')}
			&lt;/td&gt;
		&lt;/tr&gt;
	&lt;/ItemTemplate&gt;
&lt;/je:Repeater&gt;
</code></pre>
在 GroupTemplate 中可以使用属性 groupfield 和 groupname 来表示分组字段和当前分组的值.</blockquote>

<h3>相关内容</h3>
<blockquote><a href='JQueryElementRepeaterDoc.md'>Repeater 完全参考</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

</font>
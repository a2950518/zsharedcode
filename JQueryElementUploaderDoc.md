#summary Validator 完全参考
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementUploaderDoc'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /uploader/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/-Zvwz5xsih8/'>www.tudou.com/programs/view/-Zvwz5xsih8/</a></blockquote>

<blockquote>本文将系统讲解 Uploader 控件的功能以及使用过程中的注意事项和技巧, 目录如下:</blockquote>

<ul><li>准备<br>
</li><li>创建保存页面<br>
<ul><li>添加 FileUpload 控件<br>
</li><li>设置 EnableSessionState<br>
</li><li>调用 Uploader 的 Save 方法<br>
</li></ul></li><li>创建获取进度的页面<br>
</li><li>创建上传页面<br>
<ul><li>设置保存页面<br>
</li><li>设置获取进度的页面<br>
</li><li>上传<br>
</li><li>隐藏保存页面<br>
</li><li>停止获取进度</li></ul></li></ul>

<img src='http://zsharedcode.googlecode.com/files/uploadmyphoto1.jpg' />

<img src='http://zsharedcode.googlecode.com/files/uploadmyphoto2.jpg' />

<img src='http://zsharedcode.googlecode.com/files/uploadmyphoto3.jpg' />

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

<h3>创建保存页面</h3>
<blockquote>保存页面是一个简单的页面, 主要完成文件的保存工作, 保存页面不会自己提交, 而是由上传页面提交.</blockquote>

<blockquote><h4><font color='green'>添加 FileUpload 控件</font></h4>
首先, 为保存页面添加 FileUpload 控件:<br>
<pre><code>&lt;form id="formFileUpload" runat="server"&gt;<br>
上传:&amp;nbsp;&lt;asp:FileUpload ID="file" runat="server" /&gt;<br>
&lt;/form&gt;<br>
</code></pre>
也可以添加 type 属性为 file 的 input 元素:<br>
<pre><code>&lt;form id="formFileUpload" runat="server" enctype="multipart/form-data"&gt;<br>
上传:&amp;nbsp;&lt;input type="file" id="file" runat="server" /&gt;<br>
&lt;/form&gt;<br>
</code></pre>
如果使用 input 元素, 则可能需要设置 form 的 enctype 属性为 multipart/form-data.</blockquote>

<blockquote><h4><font color='green'>设置 EnableSessionState</font></h4>
需要设置保存页面的 EnableSessionState 为 ReadOnly, 这样可以在保存页面保存文件时, 请求获取进度的页面. 这主要是由于, ASP.NET 顺序执行可以读写 Session 的页面:<br>
<pre><code>&lt;%@ Page Language="C#" AutoEventWireup="true"<br>
	CodeFile="FileUpload.aspx.cs" Inherits="uploader_FileUpload"<br>
	EnableSessionState="ReadOnly" %&gt;<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>调用 Uploader 的 Save 方法</font></h4>
在保存页面的 Page_Load 方法中, 调用 Uploader 控件的 Save 静态方法来保存文件:<br>
<pre><code>protected void Page_Load ( object sender, EventArgs e )<br>
{<br>
<br>
	if ( this.IsPostBack &amp;&amp; this.file.HasFile )<br>
		// TODO: 这里设置 waitSecond 参数是为了在测试时显示上传的进度,<br>
		// 在实际的使用中请不要设置 waitSecond, 并调整 bufferSize 为一个合理的值.<br>
		Uploader.Save (<br>
			this.Server.MapPath ( @"~/uploader/photo.jpg" ),<br>
			this.file.PostedFile,<br>
			this.Session["myphotouploadinfo"] as Uploader.UploadInfo,<br>
			1,<br>
			1 );<br>
		//	Uploader.Save (<br>
		//		this.Server.MapPath ( @"~/uploader/photo.jpg" ),<br>
		//		this.file.PostedFile,<br>
		//		this.Session["myphotouploadinfo"] as Uploader.UploadInfo );<br>
<br>
}<br>
</code></pre>
代码中, 通过 IsPostBack 和 HasFile 属性判断在用户提交了文件后, 才进行保存.</blockquote>

<blockquote>Save 方法的格式为 <b><code>Save ( string filePath, HttpPostedFile postedFile, Uploader.UploadInfo uploadInfo, int bufferSize, int waitSecond )</code></b>, filePath 参数是文件保存的完整路径, postedFile 参数是提供文件控制的 HttpPostedFile 对象, 可以从 FileUpload 控件获取, uploadInfo 参数是保存上传进度信息的对象, bufferSize 参数是保存文件时的缓存大小, 默认 128kb 保存一次, 最后一个参数 waitSecond 只在测试时使用, 表示缓存被保存后的等待时间, 这样可以确保看到进度.</blockquote>

<blockquote>上传大于 4mb 的文件, 请修改 web.config 的 maxRequestLength, 可以参考 <a href='http://msdn.microsoft.com/zh-cn/library/e1f13641(v=vs.71).aspx'>msdn.microsoft.com/zh-cn/library/e1f13641(v=vs.71).aspx</a>.</blockquote>

<h3>创建获取进度的页面</h3>
<blockquote>包含进度信息的对象 Uploader.UploadInfo 被保存在 Session 中, 因此可以随时从 Session 中获取进度信息:<br>
<pre><code>&lt;%@ WebHandler Language="C#" Class="uploader_getprec" %&gt;<br>
<br>
using System.Collections.Generic;<br>
using System.Web;<br>
using System.Web.Script.Serialization;<br>
using System.Web.SessionState;<br>
using zoyobar.shared.panzer.ui.jqueryui.plusin;<br>
<br>
public class uploader_getprec : IHttpHandler,<br>
	IReadOnlySessionState<br>
{<br>
<br>
	public void ProcessRequest ( HttpContext context )<br>
	{<br>
		context.Response.ContentType = "text/javascript";<br>
		context.Response.Cache.SetNoStore ( );<br>
<br>
		Uploader.UploadInfo info =<br>
			context.Session["myphotouploadinfo"] as Uploader.UploadInfo;<br>
<br>
		SortedDictionary&lt;string, object&gt; json =<br>
			new SortedDictionary&lt;string, object&gt; ( );<br>
<br>
		if ( null == info )<br>
			json.Add ( "prec", "-" );<br>
		else<br>
		{<br>
			json.Add ( "prec", info.Percent );<br>
			json.Add ( "total", info.ContentLength );<br>
			json.Add ( "posted", info.PostedLength );<br>
<br>
			if ( info.Percent == 100 )<br>
				json.Add ( "url", "photo.jpg" );<br>
<br>
			/*<br>
			 * {<br>
			 *	"prec": 20.23<br>
			 *	"total": 2000,<br>
			 *	"posted": 2<br>
			 * }<br>
			 * */<br>
		}<br>
<br>
		context.Response.Write (<br>
			new JavaScriptSerializer ( ).Serialize ( json )<br>
			);<br>
	}<br>
<br>
	...<br>
<br>
}<br>
</code></pre>
需要注意的是, uploader_getprec 实现了接口 IReadOnlySessionState, 而不是 IRequiresSessionState. 原因也是和设置 EnableSessionState 为 ReadOnly 类似的. 至于如何返回 JSON 数据, 请参考 <a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a>.</blockquote>

<h3>创建上传页面</h3>
<blockquote>最后一步就是创建一个上传页面, 在页面中添加 Uploader 控件:<br>
<pre><code>&lt;je:Uploader ID="uploader" runat="server" IsVariable="true"<br>
	UploadUrl="FileUpload.aspx"<br>
	ProgressUrl="getprec.ashx" ProgressChanged="<br>
function(data){<br>
<br>
	if(-:data.prec == '-')<br>
		$('#prec').text('没有进度!');<br>
	else<br>
		if(-:data.prec == 100){<br>
			uploader.__uploader('complete');<br>
			$('#prec').text('完成, 图片路径为: ' + -:data.url);<br>
<br>
			pb.hide();<br>
<br>
			$('#photo').show().attr('src', -:data.url);<br>
		}<br>
		else{<br>
			$('#prec').text(-:data.posted +<br>
				' bytes/' + -:data.total + ' bytes, ' +<br>
				-:data.prec + '%');<br>
			pb.progressbar('option', 'value', -:data.prec);<br>
		}<br>
<br>
}<br>
"&gt;<br>
&lt;/je:Uploader&gt;<br>
&lt;je:Button ID="cmdUpload" runat="server" IsVariable="true"<br>
	Label="开始" Click="<br>
function(){<br>
	cmdUpload.hide();<br>
	uploader.__uploader('hide').__uploader('upload');<br>
<br>
	pb.show();<br>
}"&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>设置保存页面</font></h4>
通过 Uploader 的 UploadUrl 属性, 可以选择保存页面, 示例中, 选择了页面 FileUpload.aspx, 这将自动生成一个 iframe 元素, iframe 的 src 属性指向 FileUpload.aspx 页面.</blockquote>

<blockquote>也可以自定义一个 iframe, 然后通过 Upload 属性选择此 iframe:<br>
<pre><code>&lt;iframe id="myIFrame" src="FileUpload.aspx"&gt;&lt;/iframe&gt;<br>
<br>
&lt;je:Uploader ID="uploader" runat="server" IsVariable="true"<br>
	Upload="#myIFrame"<br>
	...	&gt;<br>
&lt;/je:Uploader&gt;<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>设置获取进度的页面</font></h4>
通过属性 ProgressUrl 和 ProgressChanged 可以获取并显示上传进度, ProgressUrl 表示返回进度信息的页面地址, ProgressChanged 则用于处理返回的进度等信息.</blockquote>

<blockquote>此外 ProgressInterval 属性表示查询进度的时间间隔, 默认为 1000 毫秒.</blockquote>

<blockquote><h4><font color='green'>上传</font></h4>
调用 <b>uploader</b> 的 upload 方法, 即可触发上传操作:<br>
<pre><code>&lt;je:Button ID="cmdUpload" runat="server" IsVariable="true"<br>
	Label="开始" Click="<br>
function(){<br>
	uploader.__uploader('upload');<br>
}"&gt;<br>
&lt;/je:Button&gt;<br>
</code></pre>
默认情况下将对保存页面的第一个表单执行 submit 操作, 可以通过 UploadForm 属性来调整需要提交的表单的索引.</blockquote>

<blockquote><h4><font color='green'>隐藏保存页面</font></h4>
调用 <b>uploader</b> 的 hide 方法, 即可隐藏保存页面:<br>
<pre><code>...<br>
	uploader.__uploader('hide');<br>
...<br>
</code></pre></blockquote>

<blockquote><h4><font color='green'>停止获取进度</font></h4>
在 Uploader 的 ProgressChanged 中, 可以在文件上传完成时调用 <b>uploader</b> 的 complete 方法来停止获取进度:<br>
<pre><code>&lt;je:Uploader ID="uploader" runat="server" IsVariable="true"<br>
	UploadUrl="FileUpload.aspx"<br>
	ProgressUrl="getprec.ashx"<br>
	ProgressChanged="<br>
function(data){<br>
<br>
	if(-:data.prec == 100)<br>
		uploader.__uploader('complete');<br>
<br>
}<br>
"&gt;<br>
&lt;/je:Uploader&gt;<br>
</code></pre></blockquote>

<h3>相关内容</h3>
<blockquote><a href='AjaxReturnJSON.md'>在不同的 .NET 版本中返回 JSON</a></blockquote>

<blockquote><a href='JEBase.md'>JQueryElement 基本属性参考</a></blockquote>

<blockquote><a href='ResourceLoader.md'>自动添加脚本和样式</a>
<h3>修订历史</h3>
2011-12-31: 增加停止获取进度一节.</blockquote>

<blockquote>2012-1-26: 增加关于 ResourceLoader 的链接.</blockquote>

</font>
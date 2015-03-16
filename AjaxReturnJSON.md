﻿#summary 在不同的 .NET 版本中返回 JSON
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/AjaxReturnJSON'>Translate this page</a></font>

<h3>简介/目录</h3>
<blockquote>请到 <a href='Download.md'>下载资源</a> 的 JQueryElement 示例下载一节<b>下载示例代码</b>, 目录 /returnjson/Default.aspx.</blockquote>

<blockquote>视频演示: <a href='http://www.tudou.com/programs/view/rHCYHX9cmcI/'>www.tudou.com/programs/view/rHCYHX9cmcI/</a></blockquote>

<blockquote>本文将说明如何通过一般处理程序 ashx 和 WebService 来向客户端 javascript 返回 JSON:</blockquote>

<ul><li>准备<br>
</li><li>一般处理程序/ashx<br>
</li><li>WebService/asmx</li></ul>

<h3>准备</h3>
<blockquote>如果希望通过 ashx 或者 asmx 来返回 JSON, 那么<b>需要引用程序集 System.Web.Extensions.dll</b>, 在 .NET 3.5, 4.0 中已经默认包含. 对于 .NET 2.0, 3.0, 需要安装 ASP.NET 2.0 AJAX, 可以在 <a href='http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=883'>www.microsoft.com/download/en/details.aspx?displaylang=en&amp;id=883</a> 下载.</blockquote>

<h3>一般处理程序/ashx</h3>
<blockquote>使用一般处理程序返回 JSON, 对于不同版本的 .NET 都是类似, 请看下面的 handler.ashx 的代码:<br>
<pre><code>&lt;%@ WebHandler Language="C#" Class="handler" %&gt;

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;

public class handler : IHttpHandler
{

	public void ProcessRequest(HttpContext context)
	{
		context.Response.ContentType = "text/javascript";
		context.Response.Cache.SetNoStore ( );

		string name = context.Request["name"];

		SortedDictionary&lt;string, object&gt; values = new SortedDictionary&lt;string, object&gt;();
		values.Add("message",
			string.IsNullOrEmpty(name) ? "无名氏" :
			string.Format("你好 {0}, {1}", name, DateTime.Now));

		context.Response.Write(new JavaScriptSerializer().Serialize(values));
	}

	public bool IsReusable
	{
		get { return false; }
	}

}
</code></pre>
上面的例子中, 通过 JavaScriptSerializer 类的 Serialize 方法, 将对象转化为 JSON 对应的字符串. 而转化的对象是 SortedDictionary, 会生成 <code>{ "message": "你好 x, 20xx-xx-xx xx:xx:xx" }</code> 这样类似的字符串. 如果需要返回数组, 可以定义 object<a href='.md'>.md</a> 来转换. 代码中还使用了 <code>context.Response.Cache.SetNoStore ( );</code> 来让浏览器每次请求 ashx 时都重新访问, 而不是使用缓存.</blockquote>

<blockquote>如果使用 jQuery, 可以使用下面的函数来接收 JSON:<br>
<pre><code>function(data){
	alert(data.message);
}
</code></pre></blockquote>

<h3>WebService/asmx</h3>
<blockquote>在不同版本的 .NET 中, 通过 javascript 访问 WebService 并返回 JSON 是略有不同的. 首先, 可以分别采用不同的 Web.config 文件.</blockquote>

<blockquote><h5>.NET 2.0, 3.0 Web.config</h5>
<pre><code>&lt;?xml version="1.0"?&gt;
&lt;configuration&gt;
	&lt;system.web&gt;
		&lt;compilation debug="true"&gt;
			&lt;assemblies&gt;
				&lt;add
assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
			&lt;/assemblies&gt;
		&lt;/compilation&gt;
		&lt;pages/&gt;
		&lt;httpHandlers&gt;
			&lt;remove verb="*" path="*.asmx"/&gt;
			&lt;add verb="*" path="*.asmx"
				type="System.Web.Script.Services.ScriptHandlerFactory"
				 validate="false"/&gt;
		&lt;/httpHandlers&gt;
	&lt;/system.web&gt;
&lt;/configuration&gt;
</code></pre></blockquote>

<blockquote><h5>.NET 3.5 Web.config</h5>
<pre><code>&lt;?xml version="1.0"?&gt;
&lt;configuration&gt;
	&lt;configSections&gt;
		&lt;sectionGroup name="system.web.extensions" type="System.Web.Configuration.SystemWebExtensionsSectionGroup, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"&gt;
			&lt;sectionGroup name="scripting" type="System.Web.Configuration.ScriptingSectionGroup, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"&gt;
				&lt;section name="scriptResourceHandler" type="System.Web.Configuration.ScriptingScriptResourceHandlerSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication"/&gt;
				&lt;sectionGroup name="webServices" type="System.Web.Configuration.ScriptingWebServicesSectionGroup, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"&gt;
					&lt;section name="jsonSerialization" type="System.Web.Configuration.ScriptingJsonSerializationSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="Everywhere"/&gt;
					&lt;section name="profileService" type="System.Web.Configuration.ScriptingProfileServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication"/&gt;
					&lt;section name="authenticationService" type="System.Web.Configuration.ScriptingAuthenticationServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication"/&gt;
					&lt;section name="roleService" type="System.Web.Configuration.ScriptingRoleServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication"/&gt;
				&lt;/sectionGroup&gt;
			&lt;/sectionGroup&gt;
		&lt;/sectionGroup&gt;
	&lt;/configSections&gt;
	&lt;system.web&gt;
		&lt;compilation debug="true"&gt;
			&lt;assemblies&gt;
				&lt;add assembly="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/&gt;
				&lt;add assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
				&lt;add assembly="System.Xml.Linq, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/&gt;
				&lt;add assembly="System.Data.DataSetExtensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/&gt;
			&lt;/assemblies&gt;
		&lt;/compilation&gt;
		&lt;pages&gt;
			&lt;controls&gt;
				&lt;add tagPrefix="asp" namespace="System.Web.UI" assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
				&lt;add tagPrefix="asp" namespace="System.Web.UI.WebControls" assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
			&lt;/controls&gt;
		&lt;/pages&gt;
		&lt;httpHandlers&gt;
			&lt;remove verb="*" path="*.asmx"/&gt;
			&lt;add verb="*" path="*.asmx" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" validate="false"/&gt;
			&lt;add verb="*" path="*_AppService.axd" validate="false" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
			&lt;add verb="GET,HEAD" path="ScriptResource.axd" validate="false" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
		&lt;/httpHandlers&gt;
		&lt;httpModules&gt;
			&lt;add name="ScriptModule" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
		&lt;/httpModules&gt;
	&lt;/system.web&gt;
	&lt;system.codedom&gt;
		&lt;compilers&gt;
			&lt;compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CSharp.CSharpCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" warningLevel="4"&gt;
				&lt;providerOption name="CompilerVersion" value="v3.5"/&gt;
				&lt;providerOption name="WarnAsError" value="false"/&gt;
			&lt;/compiler&gt;
			&lt;compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" type="Microsoft.VisualBasic.VBCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" warningLevel="4"&gt;
				&lt;providerOption name="CompilerVersion" value="v3.5"/&gt;
				&lt;providerOption name="OptionInfer" value="true"/&gt;
				&lt;providerOption name="WarnAsError" value="false"/&gt;
			&lt;/compiler&gt;
		&lt;/compilers&gt;
	&lt;/system.codedom&gt;
	&lt;system.webServer&gt;
		&lt;validation validateIntegratedModeConfiguration="false"/&gt;
		&lt;modules&gt;
			&lt;remove name="ScriptModule"/&gt;
			&lt;add name="ScriptModule" preCondition="managedHandler" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
		&lt;/modules&gt;
		&lt;handlers&gt;
			&lt;remove name="WebServiceHandlerFactory-Integrated"/&gt;
			&lt;remove name="ScriptHandlerFactory"/&gt;
			&lt;remove name="ScriptHandlerFactoryAppServices"/&gt;
			&lt;remove name="ScriptResource"/&gt;
			&lt;add name="ScriptHandlerFactory" verb="*" path="*.asmx" preCondition="integratedMode" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
			&lt;add name="ScriptHandlerFactoryAppServices" verb="*" path="*_AppService.axd" preCondition="integratedMode" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
			&lt;add name="ScriptResource" verb="GET,HEAD" path="ScriptResource.axd" preCondition="integratedMode" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/&gt;
		&lt;/handlers&gt;
	&lt;/system.webServer&gt;
	&lt;runtime&gt;
		&lt;assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1" appliesTo="v2.0.50727"&gt;
			&lt;dependentAssembly&gt;
				&lt;assemblyIdentity name="System.Web.Extensions" publicKeyToken="31bf3856ad364e35"/&gt;
				&lt;bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0"/&gt;
			&lt;/dependentAssembly&gt;
			&lt;dependentAssembly&gt;
				&lt;assemblyIdentity name="System.Web.Extensions.Design" publicKeyToken="31bf3856ad364e35"/&gt;
				&lt;bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0"/&gt;
			&lt;/dependentAssembly&gt;
		&lt;/assemblyBinding&gt;
	&lt;/runtime&gt;
&lt;/configuration&gt;
</code></pre></blockquote>

<blockquote><h5>.NET 4.0 Web.config</h5>
<pre><code>&lt;?xml version="1.0"?&gt;
&lt;configuration&gt;
	&lt;system.web&gt;
		&lt;compilation debug="true" targetFramework="4.0"&gt;
		&lt;/compilation&gt;
		&lt;pages controlRenderingCompatibilityVersion="3.5" clientIDMode="AutoID"/&gt;&lt;/system.web&gt;
&lt;/configuration&gt;
</code></pre></blockquote>

<blockquote>下面是 webservice.asmx/webservice.cs 的代码:<br>
<pre><code>&lt;%@ WebService Language="C#" CodeBehind="~/App_Code/webservice.cs" Class="webservice" %&gt;
</code></pre>
<pre><code>using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;

[WebService ( Namespace = "http://tempuri.org/" )]
[WebServiceBinding ( ConformsTo = WsiProfiles.BasicProfile1_1 )]
[ScriptService]
public class webservice : System.Web.Services.WebService
{

	[WebMethod]
	[ScriptMethod]
	public SortedDictionary&lt;string, object&gt; Save ( string name )
	{
		this.Context.Response.Cache.SetNoStore ( );

		SortedDictionary&lt;string, object&gt; values = new SortedDictionary&lt;string, object&gt; ( );
		values.Add ( "message",
			string.IsNullOrEmpty ( name ) ? "无名氏" :
			string.Format ( "你好 {0}, {1}", name, DateTime.Now ) );

		return values;
	}

}
</code></pre>
为类添加属性 ScriptService, 并对类中的方法使用属性 ScriptMethod, 可以让 javascript 来调用这些方法. 这里不需要再使用 JavaScriptSerializer 将对象转化为 JSON 字符串, 而是直接返回对象即可. 上面的代码中返回了 SortedDictionary, 在 .NET 2.0, 3.0 中将类似于 <code>{ "message": "你好 x, 20xx-xx-xx xx:xx:xx" }</code> 的形式, 而对于 .NET 3.5, 4.0 则是 <code>{ "d": { "message": "你好 x, 20xx-xx-xx xx:xx:xx" } }</code>, 因此可以分别在 jQuery 中使用下面的函数来接受 JSON:<br>
<pre><code>function(data){
	alert(data.message);
}

function(data){
	alert(data.d.message);
}
</code></pre>
如果 javascript 函数写在属性中, 则可以使用 <b><code>-:data</code></b> 来表示 JSON, 在不同版本中将自动替换为 data 或者 data.d:<br>
<pre><code>&lt;je:Button ID="cmdWNet4" runat="server" Label="all version"&gt;
	&lt;ClickAsync Url="webservice.asmx" MethodName="Save" Success="
	function(data){
		alert(-:data.message);
	}
	"&gt;
	&lt;/ClickAsync&gt;
&lt;/je:Button&gt;
</code></pre></blockquote>

<h3>相关内容</h3>
<blockquote><a href='AjaxDataType.md'>Ajax 与服务器的数据类型转换</a></blockquote>

<blockquote><a href='JEParameter.md'>通过 Parameter 对象添加 Ajax 请求时的参数</a></blockquote>

<h3>修订历史</h3>
<blockquote>2011-12-5: 修改下载的链接.</blockquote>

<blockquote>2011-12-9: 增加 -:data 的使用说明.</blockquote>

</font>
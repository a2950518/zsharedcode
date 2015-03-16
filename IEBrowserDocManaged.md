﻿#summary IEBrowser 执行托管代码
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocManaged'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web.ib;

// 从当前的 WebBrowser 控件创建 IEBrowser 对象.
IEBrowser ie = new IEBrowser ( this.webBrowser, scripting: new ManagedForScript ( ) );

// 安装跟踪脚本, 执行 jquery 和调用托管代码必需.
ie.InstallTrace ( );

// 安装本地的 jquery 脚本.
ie.InstallScript ( Properties.Resources.jquery_1_5_2_min );

// 得到搜索框的内容.
string key = ie.ExecuteJQuery&lt;string&gt; ( JQuery.Create ( "'[name=q]:text'" ).Val ( ) );

// 通过 javascript 调用托管的对象 ManagedForScript 的 MakeCondition, 生成新的搜索内容, 其实可以直接调用 MakeCondition, 这里只是演示如何调用托管代码.
key = ie.ExecuteManaged&lt;string&gt; ( "MakeCondition", parameters: new string[] { "'" + key + "'" } );

// 将新的搜索内容填写入搜索框.
ie.ExecuteJQuery ( JQuery.Create ( "'[name=q]:text'" ).Val ( "'" + key + "'" ) );
</code></pre>

<pre><code>// 在 javascript 脚本中调用的对象的 ComVisible 必须设置为 true.
[ComVisible ( true )]
public class ManagedForScript
{

	// 为搜索条件增加 site:www.baidu.com.
	public string MakeCondition ( string key )
	{

		if ( string.IsNullOrEmpty ( key ) )
		{
			// 当 javascript 调用时, 将类似于 alert 函数.
			MessageBox.Show ( "关键字为空" );
			return string.Empty;
		}

		return string.Format ( "{0} site:www.baidu.com", key );
	}

}
</code></pre>

<h3>说明</h3>
<blockquote>使用 <a href='IEBrowser.md'>IEBrowser</a> 的 ExecuteManaged 方法可以在使页面通过 javascript 来调用托管代码, 比如: <code>key = ie.ExecuteManaged&lt;string&gt; ( "MakeCondition", parameters: new string[] { "'" + key + "'" } );</code>, 这行代码通过 javascript 调用 ManagedForScript 类的 MakeCondition 方法.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
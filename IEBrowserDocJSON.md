#summary IEBrowser 获取设置 json 数据
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocJSON'>Translate this page</a></font>

<h3>代码</h3>
<pre><code>// 需要引用 using zoyobar.shared.panzer.web;<br>
// 需要引用 using zoyobar.shared.panzer.web.ib;<br>
<br>
// 从当前的 WebBrowser 控件创建 IEBrowser 对象.<br>
IEBrowser ie = new IEBrowser ( this.webBrowser );<br>
<br>
// 向页面添加一个 json 数据.<br>
ie.ExecuteScript ( "var student = { name: '小小', age: 10, scores: [90, 89, 100] }" );<br>
<br>
// 安装跟踪脚本, 以便获取设置 json 数据.<br>
ie.InstallTrace();<br>
<br>
// 获取页面中的 student 并作为 JSON 对象返回.<br>
JSON json = ie.__GetJSON ( "student" );<br>
<br>
// 显示 json 数据.<br>
Console.WriteLine ( "修改前, 姓名: {0}, 年龄: {1}, 分数1: {2}, 分数2: {3}, 分数3: {4}", json["name"].Value, json["age"].Value, json["scores"][0].Value, json["scores"][1].Value, json["scores"][2].Value );<br>
<br>
// 修改 json 中的数据.<br>
json["name"].Value = "'小红'";<br>
json["age"].Value = 12;<br>
<br>
// 将修改后的 json 数据返回到页面中.<br>
ie.__SetJSON ( "student", json );<br>
<br>
// 重新从页面获取刚才修改的 json.<br>
json = ie.__GetJSON ( "student" );<br>
<br>
// 显示修改后的 json 数据.<br>
Console.WriteLine ( "修改后, 姓名: {0}, 年龄: {1}, 分数1: {2}, 分数2: {3}, 分数3: {4}", json["name"].Value, json["age"].Value, json["scores"][0].Value, json["scores"][1].Value, json["scores"][2].Value );<br>
</code></pre>

<h3>说明</h3>
<blockquote>由于使用 Get, Set 方法不针对复杂的 javascript 数据, 所以 <a href='IEBrowser.md'>IEBrowser</a> 另外提供了 GetJSON 和 SetJSON 方法来获取和设置 json 格式的数据.</blockquote>

<blockquote>使用 <a href='IEBrowser.md'>IEBrowser</a> 的 GetJSON 方法可以获取页面中的 json 数据, 并返回对应的 <a href='JSON.md'>JSON</a>, 比如: <code>JSON json = ie.__GetJSON ( "student" );</code>, 而 SetJSON 则是将 json 数据写回到页面中, 比如: <code>ie.__SetJSON ( "student", json );</code>, 其中的 student 也就是变量的名称.</blockquote>

<blockquote>在执行 SetJSON 或者 GetJSON 方法前, 需要先执行 InstallTrace 方法.</blockquote>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i></blockquote>

<h3>使用</h3>
<blockquote>如果需要单独使用 <a href='IEBrowser.md'>IEBrowser</a>, 可以在 <a href='Download.md'>下载资源</a> 中的 IEBrowser.dll 下载一节下载 dll.</blockquote>

<blockquote>如果下载整个 <b>panzer</b> 项目, 请参考 <a href='HowToDownloadAndUse.md'>如何下载使用</a>.</blockquote>

<h3>需求</h3>
<blockquote>可能需要引用 System.Web 以及相关程序集.<br>
</font>
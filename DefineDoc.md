#summary 编译符号参考
#labels Phase-Design,Phase-Implementation
<font size='2' face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/DefineDoc'>Translate this page</a></font>

<h3><code>PARAM</code></h3>
<blockquote>在项目中定义 <code>PARAM</code> 编译符号, 将采用方法参数有默认值的书写风格, 比如:<br>
<pre><code> public void Test(string name = null, int age = 10) { }<br>
</code></pre>
这种风格在 Visual Studio 2010 可以使用, Visual Student 2008 和之前的版本请在项目属性的生成中的 <code>PARAM</code> 改为 <code>NOPARAM</code>, 此时将采用如下风格:<br>
<pre><code> public void Test() { }<br>
 public void Test(string name) { }<br>
 public void Test(string name, int age) { }<br>
 public void Test(int age) { }<br>
</code></pre></blockquote>

<h3><code>V2, V3, V3_5, V4</code></h3>
<blockquote>在项目中定义 <code>V2, V3, V3_5, V4</code> 编译符号, 将采用不同的编码风格, 分别适用在不同的 .NET 版本下, 如果你的项目采用 .NET 4.0, 那么你可以定义 <code>V2, V3, V3_5, V4</code> 中的任意一种. 如果你的项目采用 .NET 2.0, 那么你不能定义 <code>V3, V3_5, V4</code> 中的任意一种, 这可能导致编译无法通过.<br>
</font>
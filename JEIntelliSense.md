﻿#summary 配置 Visual Studio 的 JQueryElement 智能提示
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JEIntelliSense'>Translate this page</a></font>

<h3>配置 Visual Studio 智能提示</h3>
<blockquote>JQueryElement 中具有自定义标签属性, 比如在 Repeater 控件的模板中使用的 je-class 等, 默认情况下 Visual Studio 并不会自动提示这些属性, 而且验证也不会通过.</blockquote>

<blockquote>如果希望 Visual Studio 支持 JQueryElement 中的标签属性, 在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 的 zip 压缩包, 解压缩其中的 IntelliSense.zip, 并将其中的 xsd 文件复制到 <Visual Studio 安装目录>\Common7\Packages\schemas\html\ 目录中覆盖原有文件, 覆盖前请备份.</blockquote>

<blockquote>覆盖完成后, 请重新启动 Visual Studio.<br>
</font>
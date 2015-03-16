﻿#summary IEBrowser 页面流程控制
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/IEBrowserDocFlow'>Translate this page</a></font>

<h3>简介</h3>
<blockquote><a href='IEBrowser.md'>IEBrowser</a> 可以控制浏览器完成一系列的操作, 而不需要用户操作.</blockquote>

<h3>页面状态</h3>
<blockquote>我们将浏览器执行的一系列操作分为若干个页面状态, 各个页面状态直接可以相互的跳转. 而一个页面状态中可以包含一些动作, 自身是否已经完成的判断条件, 可以跳转到的状态.</blockquote>

<blockquote><h4>动作</h4>
<blockquote>在页面状态开始, 完成, 失败后可以选择执行一些动作. 这些动作可以是页面跳转到某个地址, 执行 javascript 脚本, 安装执行 jquery 脚本等.</blockquote></blockquote>

<blockquote><h4>判断条件</h4>
<blockquote>判断条件用于判断页面状态是否完成, 可以对载入的地址进行判断, 或者使用 jquery 进行更复杂的判断, 比如: 页面上是否存在某个元素等. 另外, 可以设置超时时间, 如果超时后页面状态仍然没有完成, 则认为页面状态失败.</blockquote></blockquote>

<blockquote><h4>跳转到的状态</h4>
<blockquote>在页面状态完成或者失败后, 可以选择从当前的状态跳转到其他页面状态, 如果不指定任何跳转到的状态, 则视为所有操作结束.</blockquote></blockquote>

<h3>示例</h3>
<ul><li><a href='IEBrowserDocFlowNWPC.md'>页面载入后跳转</a>
</font>
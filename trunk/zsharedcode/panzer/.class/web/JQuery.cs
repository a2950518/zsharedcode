/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQuery
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// JQuery 用于编写构造 jQuery 脚本, 包含了 jQuery 中的方法等.
	/// </summary>
	public class JQuery
		: ScriptHelper
	{

		/// <summary>
		/// 获取 1.4.2 版本的 jQuery 脚本官方地址.
		/// </summary>
		public static string Script_1_4_2_Url
		{
			get { return "http://code.jquery.com/jquery-1.4.2.min.js"; }
		}

		/// <summary>
		/// 获取 1.4.1 版本的 jQuery 脚本 zoyobar.googlecode.com 地址.
		/// </summary>
		public static string Script_1_4_1_Url
		{
			get { return "http://zoyobar.googlecode.com/files/jquery-1.4.1.min.js"; }
		}

		#region " 构造 "

		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( JQuery jQuery )
		{ return new JQuery ( jQuery ); }

		/// <summary>
		/// 创建使用别名的空的 JQuery.
		/// </summary>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ()
		{ return Create ( null, null, true ); }
		/// <summary>
		/// 创建空的 JQuery.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( bool isAlias )
		{ return Create ( null, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI )
		{ return Create ( expressionI, null, true ); }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, bool isAlias )
		{ return Create ( expressionI, null, isAlias ); }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, string expressionII )
		{ return Create ( expressionI, expressionII, true ); }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( string expressionI, string expressionII, bool isAlias )
		{ return new JQuery ( expressionI, expressionII, isAlias ); }

		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery 实例.
		/// </summary>
		/// <param name="jQuery">jQuery 实例, 新实例将复制其 Code 属性.</param>
		public JQuery ( JQuery jQuery )
			: base ( ScriptType.JavaScript )
		{

			if ( null == jQuery )
				return;

			this.code = jQuery.code;
		}

		/// <summary>
		/// 创建使用别名的空的 JQuery.
		/// </summary>
		public JQuery ()
			: this ( null, null, true )
		{ }
		/// <summary>
		/// 创建空的 JQuery.
		/// </summary>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( bool isAlias )
			: this ( null, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		public JQuery ( string expressionI )
			: this ( expressionI, null, true )
		{ }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( string expressionI, bool isAlias )
			: this ( expressionI, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		public JQuery ( string expressionI, string expressionII )
			: this ( expressionI, expressionII, true )
		{ }
		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( string expressionI, string expressionII, bool isAlias )
			: base ( ScriptType.JavaScript )
		{

			string constructor;

			if ( isAlias )
				constructor = "$";
			else
				constructor = "jQuery";

			if ( string.IsNullOrEmpty ( expressionI ) )
				this.AppendCode ( string.Format ( "{0}()", constructor ) );
			else
				if ( string.IsNullOrEmpty ( expressionII ) )
					this.AppendCode ( string.Format ( "{0}({1})", constructor, expressionI ) );
				else
					this.AppendCode ( string.Format ( "{0}({1}, {2})", constructor, expressionI, expressionII ) );

		}

		#endregion

		#region " 基本 "

		/// <summary>
		/// 创建当前 JQuery 的副本, 拥有相同的 Code 属性.
		/// </summary>
		/// <returns>JQuery 的副本.</returns>
		public JQuery Copy ()
		{ return new JQuery(this); }

		/// <summary>
		/// 添加语句的结尾符号.
		/// </summary>
		/// <returns>添加结尾符号后的 JQuery.</returns>
		public JQuery EndLine ()
		{
			this.AppendCode ( this.EndOfLine );
			return this;
		}

		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName )
		{ return this.Execute ( methodName, null, null, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI )
		{ return this.Execute ( methodName, expressionI, null, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII )
		{ return this.Execute ( methodName, expressionI, expressionII, null, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <param name="expressionIII">方法的第 3 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( methodName, expressionI, expressionII, expressionIII, null ); }
		/// <summary>
		/// 添加执行 jQuery 方法的代码.
		/// </summary>
		/// <param name="methodName">jQuery 方法名称, 比如: "css".</param>
		/// <param name="expressionI">方法的第 1 个参数的表达式.</param>
		/// <param name="expressionII">方法的第 2 个参数的表达式.</param>
		/// <param name="expressionIII">方法的第 3 个参数的表达式.</param>
		/// <param name="expressionIV">方法的第 4 个参数的表达式.</param>
		/// <returns>添加执行代码后的 JQuery.</returns>
		public JQuery Execute ( string methodName, string expressionI, string expressionII, string expressionIII, string expressionIV )
		{

			if ( string.IsNullOrEmpty ( methodName ) )
				return this;

			if ( string.IsNullOrEmpty ( expressionI ) )
				this.AppendCode ( string.Format ( ".{0}()", methodName ) );
			else
				if ( string.IsNullOrEmpty ( expressionII ) )
					this.AppendCode ( string.Format ( ".{0}({1})", methodName, expressionI ) );
				else
					if ( string.IsNullOrEmpty ( expressionIII ) )
						this.AppendCode ( string.Format ( ".{0}({1}, {2})", methodName, expressionI, expressionII ) );
					else
						if ( string.IsNullOrEmpty ( expressionIV ) )
							this.AppendCode ( string.Format ( ".{0}({1}, {2}, {3})", methodName, expressionI, expressionII, expressionIII ) );
						else
							this.AppendCode ( string.Format ( ".{0}({1}, {2}, {3}, {4})", methodName, expressionI, expressionII, expressionIII, expressionIV ) );

			return this;
		}

		#endregion

		#region " 方法 A "

		/// <summary>
		/// 合并新的元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 或者是一段 html 代码, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Add ( string expressionI )
		{ return this.Execute ( "add", expressionI, null ); }
		/// <summary>
		/// 合并新的元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">选择器, 比如: "'body table .red'".</param>
		/// <param name="expressionII">document 元素, 指定选择器搜索的文档.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Add ( string expressionI, string expressionII )
		{ return this.Execute ( "add", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的包含的页面元素添加新的样式.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 可以是多个样式的名称, 比如: "'box red'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AddClass ( string expression )
		{ return this.Execute ( "addClass", expression ); }

		/// <summary>
		/// 合并 jQuery 匹配到的上一批元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AndSelf ( )
		{ return this.Execute ( "andSelf" ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的属性, 或者设置所有元素的多个属性.
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'", 也可以是属性集合, 比如: "{type: 'text', title: 'test'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Attr ( string expressionI )
		{ return this.Attr ( expressionI, null ); }
		/// <summary>
		/// 设置 jQuery 中元素的属性.
		/// </summary>
		/// <param name="expressionI">可以是属性名称, 比如: "'title'".</param>
		/// <param name="expressionII">返回属性名称的表达式, 比如: "'just test'", 或者返回属性值的函数, 比如: "function(i, a){ return 'my_' + i.toString(); }". (如果使用函数需要 1.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Attr ( string expressionI, string expressionII )
		{ return this.Execute ( "attr", expressionI, expressionII ); }

		#endregion

		#region " 方法 C "

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级子元素, 不包含文本元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Children ( )
		{ return this.Children ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素中符合选择器的第一级子元素, 不包含文本元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Children ( string expression )
		{ return this.Execute ( "children", expression ); }

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Contents ( )
		{ return this.Execute ( "contents" ); }

		#endregion

		#region " 方法 E "

		/// <summary>
		/// 添加执行按照索引选择元素的 eq 方法的代码.
		/// </summary>
		/// <param name="expression">元素的索引值, 比如: "0", 如果是 "-1", 则表示最后一个元素.</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Eq ( string expression )
		{ return this.Execute ( "eq", expression ); }
		
		#endregion

		#region " 方法 F "

		/// <summary>
		/// 添加执行通过选择器, 测试函数等选择元素的 filter 方法的代码.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')", 或者是另一个 jQuery 对象, 比如: "$('#li64')".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Filter ( string expression )
		{ return this.Execute ( "filter", expression ); }

		public JQuery Find ( string expression )
		{ return this.Execute ( "find", expression ); }

		/// <summary>
		/// 添加执行选择第一个元素的 first 方法的代码.
		/// </summary>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery First ()
		{ return this.Execute ( "first" ); }

		#endregion

		#region " 方法 H "

		/// <summary>
		/// 添加执行通过判断子元素是否符合选择器, DOM 元素从而选择元素的 has 方法的代码.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 或者是 DOM 元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Has ( string expression )
		{ return this.Execute ( "has", expression ); }

		/// <summary>
		/// 判断样式是否存在.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 比如: "'box'", 将判断样式是否存在.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery HasClass ( string expression )
		{ return this.Execute ( "hasClass", expression ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 innerHTML 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Html ( )
		{ return this.Html ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含元素的 innerHTML 属性.
		/// </summary>
		/// <param name="expression">返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 或者返回 html 代码的函数, 比如: "function(i, h){ return '&lt;stong&gt;&lt;/stong&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Html ( string expression )
		{ return this.Execute ( "html", expression ); }

		#endregion

		#region " 方法 I "

		/// <summary>
		/// 添加执行判断元素是否符合选择器的 is 方法的代码.
		/// </summary>
		/// <param name="expression">选择器, 比如: "'.box'".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Is ( string expression )
		{ return this.Execute ( "is", expression ); }

		#endregion

		#region " 方法 L "

		/// <summary>
		/// 添加执行选择最后一个元素的 last 方法的代码.
		/// </summary>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Last ()
		{ return this.Execute ( "last" ); }

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Length ()
		{
			this.AppendCode ( ".length" );
			return this;
		}

		#endregion

		#region " 方法 M "

		/// <summary>
		/// 添加执行对元素使用函数的 map 方法的代码.
		/// </summary>
		/// <param name="expression">对元素调用的函数, 比如: "function(i, o){ return 'my_' + i.toString(); }".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Map ( string expression )
		{ return this.Execute ( "map", expression ); }

		#endregion

		#region " 方法 N "

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Next ( )
		{ return this.Execute ( "next" ); }

		/// <summary>
		/// 卸载 jQuery 在页面中 $ 的定义.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NoConflict ( )
		{ return this.NoConflict ( null ); }
		/// <summary>
		/// 卸载 jQuery 在页面中 $ 的定义.
		/// </summary>
		/// <param name="expression">一个返回布尔值的表达式, 比如: "true", "1 > 2" 或者 "isOK", 其中 isOK 是 javascript 脚本中的变量, 如果表达式为 true, 则卸载 $ 和 jQuery 的定义, 否则只卸载 $ 的定义.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NoConflict ( string expression )
		{ return this.Execute ( "noConflict", expression ); }

		/// <summary>
		/// 添加执行选择不符合条件的元素的 not 方法的代码.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'li'", 也可以是 DOM 元素, 比如: "document.getElementById('li51')", 或者是测试函数, 比如: "function(i){ return i == 3; }".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Not ( string expression )
		{ return this.Execute ( "not", expression ); }

		#endregion

		#region " 方法 R "

		/// <summary>
		/// 删除 jQuery 中包含的元素的属性.
		/// </summary>
		/// <param name="expression">返回属性名称的表达式, 比如: "'title'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveAttr ( string expression )
		{ return this.Execute ( "removeAttr", expression ); }

		/// <summary>
		/// 删除 jQuery 中包含的元素的所有样式.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveClass ( )
		{ return this.RemoveClass ( null ); }
		/// <summary>
		/// 删除 jQuery 中包含的元素的指定样式.
		/// </summary>
		/// <param name="expression">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveClass ( string expression )
		{ return this.Execute ( "removeClass", expression ); }

		#endregion

		#region " 方法 S "

		/// <summary>
		/// 添加执行选择某个位置开始到结束范围的元素的 slice 方法的代码, 0 是第 1 个元素, -1 是最后一个元素.
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Slice ( string expressionI )
		{ return this.Slice ( expressionI, null ); }
		/// <summary>
		/// 添加执行选择某个范围的元素的 slice 方法的代码, 0 是第 1 个元素, -1 是最后一个元素.
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <param name="expressionII">结束索引, 比如: "2", 结束位置的元素不会被选择.</param>
		/// <returns>添加代码后的 JQuery.</returns>
		public JQuery Slice ( string expressionI, string expressionII )
		{ return this.Execute ( "slice", expressionI, expressionII ); }

		/// <summary>
		/// 创建主 jQuery 对象的副本.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Sub ( )
		{ return this.Execute ( "sub" ); }

		#endregion

		#region " 方法 T "

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Text ()
		{ return this.Text ( null ); }
		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <param name="expression">尚未编辑.</param>
		/// <returns>尚未编辑.</returns>
		public JQuery Text ( string expression )
		{ return this.Execute ( "text", expression ); }

		/// <summary>
		/// 切换 jQuery 中包含的元素的样式, 样式存在则删除, 如果不存在则添加.
		/// </summary>
		/// <param name="expressionI">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ToggleClass ( string expressionI )
		{ return this.ToggleClass ( expressionI, null ); }
		/// <summary>
		/// 添加或者删除 jQuery 中包含的元素的样式. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">返回样式名称的表达式, 比如: "'box'", 或者返回样式名称的函数, 比如: "function(i, c){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <param name="expressionII">返回布尔值的表达式, 表示添加还是删除样式.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ToggleClass ( string expressionI, string expressionII )
		{ return this.Execute ( "toggleClass", expressionI, expressionII ); }

		public JQuery Trigger ( string expressionI )
		{ return this.Trigger ( expressionI, null ); }
		public JQuery Trigger ( string expressionI, string expressionII )
		{ return this.Execute ( "trigger", expressionI, expressionII ); }

		#endregion

		#region " 方法 V "

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 value 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Val ( )
		{ return this.Val ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含的元素 value 属性.
		/// </summary>
		/// <param name="expression">一个表达式, 比如: "'my name'", 或者是一个返回值的函数, 比如: "function(i, v){ return 'my_' + i.toString(); }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Val ( string expression )
		{ return this.Execute ( "val", expression ); }
		
		#endregion

		#region " 方法 W "

		/// <summary>
		/// 调用 when 方法, 传递一个或者多个 javascript 对象, 之后可再通过 done, then 等方法编写这些对象载入后的处理方法. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expression">一个或者多个对象的表达式, 比如: "$.ajax('test.aspx')", 或者 "{ testing: 123 }, { name: 'jack' }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery When ( string expression )
		{ return this.Execute ( "when", expression ); }

		#endregion

	}

}
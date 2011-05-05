/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQuery
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
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
	/// JQuery 用于编写构造 jQuery 脚本, 包含了 jQuery 中的方法等, 支持 1.6 版本. (尚未包含 Effects, Utilities 的部分方法)
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
		public static JQuery Create ( )
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
		/// 创建 JQuery.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( bool isInstance, bool isAlias )
		{ return new JQuery ( isInstance, isAlias ); }


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
		public JQuery ( )
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

		/// <summary>
		/// 创建 JQuery.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">是否在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQuery ( bool isInstance, bool isAlias )
			: base ( ScriptType.JavaScript )
		{

			if ( isAlias )
				this.AppendCode ( "$" );
			else
				this.AppendCode ( "jQuery" );

			if ( isInstance )
				this.AppendCode ( "()" );

		}

		#endregion

		#region " 基本 "

		/// <summary>
		/// 创建当前 JQuery 的副本, 拥有相同的 Code 属性.
		/// </summary>
		/// <returns>JQuery 的副本.</returns>
		public JQuery Copy ( )
		{ return new JQuery ( this ); }

		/// <summary>
		/// 添加语句的结尾符号.
		/// </summary>
		/// <returns>添加结尾符号后的 JQuery.</returns>
		public JQuery EndLine ( )
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
		{ return this.Add ( expressionI, null ); }
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
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i) { return this.className + i.toString;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery After ( string expressionI )
		{ return this.After ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery After ( string expressionI, string expressionII )
		{ return this.Execute ( "after", expressionI, expressionII ); }

		/// <summary>
		/// 执行 ajax 操作, 并返回 jqXHR javascript 对象.
		/// </summary>
		/// <param name="expressionI">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ajax ( string expressionI )
		{ return this.Ajax ( expressionI, null ); }
		/// <summary>
		/// 执行 ajax 操作, 并返回 jqXHR javascript 对象. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "'js/test.js'".</param>
		/// <param name="expressionII">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ajax ( string expressionI, string expressionII )
		{ return this.Execute ( "ajax", expressionI, expressionII ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求完成的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxComplete ( string expression )
		{ return this.Execute ( "ajaxComplete", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求失败的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, g, a, t){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxError ( string expression )
		{ return this.Execute ( "ajaxError", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加 ajax 请求发出的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSend ( string expression )
		{ return this.Execute ( "ajaxSend", expression ); }

		/// <summary>
		/// 设置之后 ajax 操作的默认设置. (需要 1.1 版本以上)
		/// </summary>
		/// <param name="expression">返回对象的表达式, 包含 ajax 操作的设置, 比如: "{url: 'js/test.js'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSetup ( string expression )
		{ return this.Execute ( "ajaxSetup", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加第一个 ajax 请求的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxStart ( string expression )
		{ return this.Execute ( "ajaxStart", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加所有 ajax 请求结束的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxStop ( string expression )
		{ return this.Execute ( "ajaxStop", expression ); }

		/// <summary>
		/// 在当前 jQuery 中包含的元素添加所有 ajax 请求成功的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(e, x, a){alert('ajax');}"</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AjaxSuccess ( string expression )
		{ return this.Execute ( "ajaxSuccess", expression ); }

		/// <summary>
		/// 合并 jQuery 匹配到的上一批元素和当前 jQuery 中的元素, 生成一个新的 jQuery 对象. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AndSelf ( )
		{ return this.Execute ( "andSelf" ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i, h) { return 'old html is ' + h;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Append ( string expressionI )
		{ return this.Append ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之后添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Append ( string expressionI, string expressionII )
		{ return this.Execute ( "append", expressionI, expressionII ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素追加到指定目标之后.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'.red'", 可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery AppendTo ( string expression )
		{ return this.Execute ( "appendTo", expression ); }

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

		#region " 方法 B "

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i) { return this.className + i.toString;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Before ( string expressionI )
		{ return this.Before ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为兄弟元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Before ( string expressionI, string expressionII )
		{ return this.Execute ( "before", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加事件. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI )
		{ return this.Bind ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示停止事件的冒泡. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI, string expressionII )
		{ return this.Bind ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示停止事件的冒泡. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Bind ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "bind", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加失去焦点事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( )
		{ return this.Blur ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加失去焦点的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( string expressionI )
		{ return this.Blur ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加失去焦点的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Blur ( string expressionI, string expressionII )
		{ return this.Execute ( "blur", expressionI, expressionII ); }

		#endregion

		#region " 方法 C "

		/// <summary>
		/// 触发 jQuery 中的元素的添加数据改变事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( )
		{ return this.Change ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加数据改变的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( string expressionI )
		{ return this.Change ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加数据改变的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Change ( string expressionI, string expressionII )
		{ return this.Execute ( "change", expressionI, expressionII ); }

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
		/// 触发 jQuery 中的元素的添加单击事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( )
		{ return this.Click ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加单击的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( string expressionI )
		{ return this.Click ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加单击的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Click ( string expressionI, string expressionII )
		{ return this.Execute ( "click", expressionI, expressionII ); }

		/// <summary>
		/// 复制当前 jQuery 中包含的元素, 对于是否复制元素的事件和数据, 1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false, 不复制元素的子元素的事件和数据.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( )
		{ return this.Clone ( null, null ); }
		/// <summary>
		/// 复制当前 jQuery 中包含的元素, 不复制元素的子元素的事件和数据.
		/// </summary>
		/// <param name="expressionI">一个布尔表达式, 比如: "true", 表示是否复制元素的事件和数据. (1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( string expressionI )
		{ return this.Clone ( expressionI, null ); }
		/// <summary>
		/// 复制当前 jQuery 中包含的元素. (需要 1.5 版本以上)
		/// </summary>
		/// <param name="expressionI">一个布尔表达式, 比如: "true", 表示是否复制元素的事件和数据. (1.5.0 版本默认 true, 低版本和 1.5.1 以及更高版本默认为 false)</param>
		/// <param name="expressionII">一个布尔表达式, 比如: "true", 表示是否复制元素的子元素的事件和数据.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Clone ( string expressionI, string expressionII )
		{ return this.Execute ( "clone", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中元素的第一个符合选择器的父元素, 从当前 jQuery 元素开始搜索. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是一个选择器, 比如: "'strong'", 或者选择器的数组, 比如: "['body', 'ul']", 也可以是一个 jQuery, 比如: "__myJQuery", 也可以是 DOM 元素, 比如: "document.getElementById('name')". (如果使用数组需要 1.4 版本以上, 如果使用 jQuery 或者 DOM 元素需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Closest ( string expressionI )
		{ return this.Closest ( expressionI, null ); }
		/// <summary>
		/// 获取当前 jQuery 中元素的第一个符合选择器的父元素, 从当前 jQuery 元素开始搜索. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是一个选择器, 比如: "'strong'", 或者选择器的数组, 比如: "['body', 'ul']".</param>
		/// <param name="expressionII">返回页面元素的表达式, 指定搜索的位置.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Closest ( string expressionI, string expressionII )
		{ return this.Execute ( "closest", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有子元素, 包含文本和注释. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Contents ( )
		{ return this.Execute ( "contents" ); }

		/// <summary>
		/// 获取当前 jQuery 中第一个元素的样式或者设置所有元素的多个样式.
		/// </summary>
		/// <param name="expressionI">返回要获取的样式名称的表达式, 比如: "'color'", 或者要设置的多个样式, 比如: "{'background-color' : '#ddd', 'font-weight' : '', 'color' : 'rgb(0,40,244)'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Css ( string expressionI )
		{ return this.Css ( expressionI, null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的样式.
		/// </summary>
		/// <param name="expressionI">返回要设置的样式名称的表达式, 比如: "'color'".</param>
		/// <param name="expressionII">返回样式值的表达式, 比如: "'red'", 或者返回值的函数, 比如: "function(i, v){return i.toString() + 'px';}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Css ( string expressionI, string expressionII )
		{ return this.Execute ( "css", expressionI, expressionII ); }

		/// <summary>
		/// 获得 jQuery 的 cssHooks 属性, 用于设置新的样式规则. (需要 1.4.3 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery CssHooks ( )
		{
			this.AppendCode ( ".cssHooks" );
			return this;
		}

		#endregion

		#region " 方法 D "

		/// <summary>
		/// 触发 jQuery 中的元素的添加双击事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( )
		{ return this.Dblclick ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加双击的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( string expressionI )
		{ return this.Dblclick ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加双击的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Dblclick ( string expressionI, string expressionII )
		{ return this.Execute ( "dblclick", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Delegate ( string expressionI, string expressionII, string expressionIII )
		{ return this.Delegate ( expressionI, expressionII, expressionIII, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIV">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Delegate ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "delegate", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 将当前 jQuery 中的元素从页面中删除, 但仍保存在 jQuery 中. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Detach ( )
		{ return this.Detach ( null ); }
		/// <summary>
		/// 将当前 jQuery 中符合选择器的元素从页面中删除, 但仍保存在 jQuery 中. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择删除元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Detach ( string expression )
		{ return this.Execute ( "detach", expression ); }

		/// <summary>
		/// 取消所有使用 live 方法绑定的事件. (需要 1.4.1 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( )
		{ return this.Die ( null, null ); }
		/// <summary>
		/// 取消使用 live 方法绑定的指定事件. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( string expressionI )
		{ return this.Die ( expressionI, null ); }
		/// <summary>
		/// 取消使用 live 方法绑定的指定事件的某个函数. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "clickfunction", 将取消函数作为事件的处理.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Die ( string expressionI, string expressionII )
		{ return this.Execute ( "die", expressionI, expressionII ); }

		#endregion

		#region " 方法 E "

		/// <summary>
		/// 对当前 jQuery 中包含的元素执行对应的 javascript 函数.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(i, e){ $(e).html(i.toString()); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Each ( string expression )
		{ return this.Execute ( "each", expression ); }

		/// <summary>
		/// 将当前 jQuery 中元素的子元素从页面中删除, 包含文本.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Empty ( )
		{ return this.Execute ( "empty" ); }

		/// <summary>
		/// 将最初搜索的一批元素恢复到 jQuery 中. 
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery End ( )
		{ return this.Execute ( "end" ); }

		/// <summary>
		/// 获取当前 jQuery 中指定索引的元素. (需要 1.1.2 版本以上)
		/// </summary>
		/// <param name="expression">返回元素的索引值的表达式, 比如: "0", 如果是 "-1", 则表示最后一个元素. (如果使用负数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Eq ( string expression )
		{ return this.Execute ( "eq", expression ); }

		/// <summary>
		/// 为 jQuery 中的元素添加处理错误的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Error ( string expressionI )
		{ return this.Error ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加处理错误的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Error ( string expressionI, string expressionII )
		{ return this.Execute ( "error", expressionI, expressionII ); }

		#endregion

		#region " 方法 F "

		/// <summary>
		/// 选择当前 jQuery 中符合选择器, 筛选函数, 元素或者 jQuery 中元素的元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')", 或者是另一个 jQuery 对象, 比如: "$('#li64')". (如果元素或者 jQuery 需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Filter ( string expression )
		{ return this.Execute ( "filter", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中包含元素的符合选择器的子元素.
		/// </summary>
		/// <param name="expression">用于筛选子元素的选择器, 比如: "'strong'", 也可以是一个 jQuery, 比如: "__myJQuery", 也可以是 DOM 元素, 比如: "document.getElementById('name')". (如果使用 jQuery 或者 DOM 元素需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Find ( string expression )
		{ return this.Execute ( "find", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中第一个元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery First ( )
		{ return this.Execute ( "first" ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加获取焦点事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( )
		{ return this.Focus ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取焦点的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( string expressionI )
		{ return this.Focus ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取焦点的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Focus ( string expressionI, string expressionII )
		{ return this.Execute ( "focus", expressionI, expressionII ); }

		#endregion

		#region " 方法 G "

		/// <summary>
		/// 使用 GET 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Get ( string expressionI )
		{ return this.Get ( expressionI, null, null, null ); }
		/// <summary>
		/// 使用 GET 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <param name="expressionIV">指定获取数据类型的字符串, "'xml'", "'json'", "'script'", "'html'" 中的一种.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Get ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "get", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 使用 GET 获取请求 json 数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "test.aspx".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetJSON ( string expressionI )
		{ return this.GetJSON ( expressionI, null, null ); }
		/// <summary>
		/// 使用 GET 获取请求 json 数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "test.aspx".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetJSON ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "getJSON", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 使用 GET 获取请求 javascript 脚本并执行.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetScript ( string expressionI )
		{ return this.GetScript ( expressionI, null ); }
		/// <summary>
		/// 使用 GET 获取请求 javascript 脚本并执行.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery GetScript ( string expressionI, string expressionII)
		{ return this.Execute ( "getScript", expressionI, expressionII ); }

		#endregion

		#region " 方法 H "

		/// <summary>
		/// 选择 jQuery 中元素, 其子元素符合选择器或者元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 或者是元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
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
		/// 获取当前 jQuery 中包含的第一个元素的高度数值.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Height ( )
		{ return this.Height ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的高度.
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110", 或者一个返回数值的函数, 比如: "function(i, h){ return i + h; }". (如果使用函数需要 1.4.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Height ( string expression )
		{ return this.Execute ( "height", expression ); }

		/// <summary>
		/// 是否让 ready 等待执行. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expression">返回布尔值的表达式, 比如: "true", 表示阻止 ready 执行.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery HoldReady ( string expression )
		{ return this.Execute ( "holdReady", expression ); }

		/// <summary>
		/// 设置当前 jQuery 元素的鼠标进入和离开的事件. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标进入和离开的共同事件.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Hover ( string expressionI )
		{ return this.Hover ( expressionI, null ); }
		/// <summary>
		/// 设置当前 jQuery 元素的鼠标进入和离开的事件. (需要 1.4.1 版本以上)
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标进入事件.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }", 作为鼠标离开事件.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Hover ( string expressionI, string expressionII )
		{ return this.Execute ( "hover", expressionI, expressionII ); }

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
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 不包含边框. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InnerHeight ( )
		{ return this.Execute ( "innerHeight" ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 不包含边框. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InnerWidth ( )
		{ return this.Execute ( "innerWidth" ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素添加到目标之后作为兄弟元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InsertAfter ( string expression )
		{ return this.Execute ( "insertAfter", expression ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素添加到目标之前作为兄弟元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery InsertBefore ( string expression )
		{ return this.Execute ( "insertBefore", expression ); }

		/// <summary>
		///判断当前 jQuery 元素是否符合选择器, 如果至少一个符合时, 将在 javascript 中返回 true.
		/// </summary>
		/// <param name="expression">选择器, 比如: "'.box'", 也可以是一个 jQuery, 比如: "__myJQuery", 也可以是 DOM 元素, 比如: "document.getElementById('name')". (如果使用 jQuery 或者 DOM 元素需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Is ( string expression )
		{ return this.Execute ( "is", expression ); }

		#endregion

		#region " 方法 K "

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘按下事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( )
		{ return this.Keydown ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按下的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( string expressionI )
		{ return this.Keydown ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按下的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keydown ( string expressionI, string expressionII )
		{ return this.Execute ( "keydown", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘按住事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( )
		{ return this.Keypress ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按住的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( string expressionI )
		{ return this.Keypress ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘按住的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keypress ( string expressionI, string expressionII )
		{ return this.Execute ( "keypress", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加键盘松开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( )
		{ return this.Keyup ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘松开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( string expressionI )
		{ return this.Keyup ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加获取键盘松开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Keyup ( string expressionI, string expressionII )
		{ return this.Execute ( "keyup", expressionI, expressionII ); }

		#endregion

		#region " 方法 L "

		/// <summary>
		/// 选择当前 jQuery 中最后一个元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Last ( )
		{ return this.Execute ( "last" ); }

		/// <summary>
		/// 尚未编辑.
		/// </summary>
		/// <returns>尚未编辑.</returns>
		public JQuery Length ( )
		{
			this.AppendCode ( ".length" );
			return this;
		}

		/// <summary>
		/// 为 jQuery 中的元素添加事件, 可以用 die 方法取消. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI )
		{ return this.Live ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件, 可以用 die 方法取消. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI, string expressionII )
		{ return this.Live ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中符合选择器的元素添加事件, 可以用 die 方法取消. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Live ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "live", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加载入的事件, 或者使用 GET 请求 html 代码.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }", 或者返回地址的表达式, 比如: "'test.html'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI )
		{ return this.Load ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加载入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI, string expressionII )
		{ return this.Load ( expressionI, expressionII, null ); }
		/// <summary>
		/// 使用 GET 请求 html 代码.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "'test.html'".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回完成时回调函数的表达式, 比如: "function(r, t, x){alert('ajax');}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Load ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "load", expressionI, expressionII, expressionIII ); }

		#endregion

		#region " 方法 M "

		/// <summary>
		/// 对当前 jQuery 中的元素执行函数, 并将执行的结果返回为一个 javascript 数组. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expressionI">返回调用函数的表达式, 比如: "function(i, o){ return 'my_' + i.toString(); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Map ( string expressionI )
		{ return this.Map ( expressionI ); }
		/// <summary>
		/// 对一个数组或者对象执行函数.
		/// </summary>
		/// <param name="expressionI">返回对象或者数组的表达式, 比如: "['a', 'b', 'c']". (如果使用对象元素需要 1.6 版本以上)</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(elementOfArray, indexInArray){}" 或者 "function(value, indexOrKey){}". (如果使用后一个函数需要 1.6 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Map ( string expressionI, string expressionII )
		{ return this.Execute ( "map", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标按下事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( )
		{ return this.Mousedown ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标按下的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( string expressionI )
		{ return this.Mousedown ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标按下的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousedown ( string expressionI, string expressionII )
		{ return this.Execute ( "mousedown", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标进入事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( )
		{ return this.Mouseenter ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标进入的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( string expressionI )
		{ return this.Mouseenter ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标进入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseenter ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseenter", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标离开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( )
		{ return this.Mouseleave ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标离开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( string expressionI )
		{ return this.Mouseleave ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标离开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseleave ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseleave", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑动事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( )
		{ return this.Mousemove ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑动的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( string expressionI )
		{ return this.Mousemove ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑动的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mousemove ( string expressionI, string expressionII )
		{ return this.Execute ( "mousemove", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑出事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( )
		{ return this.Mouseout ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑出的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( string expressionI )
		{ return this.Mouseout ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑出的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseout ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseout", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标滑入事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( )
		{ return this.Mouseover ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑入的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( string expressionI )
		{ return this.Mouseover ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标滑入的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseover ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseover", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加鼠标松开事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( )
		{ return this.Mouseup ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标松开的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( string expressionI )
		{ return this.Mouseup ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加鼠标松开的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Mouseup ( string expressionI, string expressionII )
		{ return this.Execute ( "mouseup", expressionI, expressionII ); }

		#endregion

		#region " 方法 N "

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的第一个兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Next ( )
		{ return this.Next ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的符合选择器的第一个兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Next ( string expression )
		{ return this.Execute ( "next", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextAll ( )
		{ return this.NextAll ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向后的符合选择器的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextAll ( string expression )
		{ return this.Execute ( "nextAll", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素向后的所有兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextUntil ( )
		{ return this.NextUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素向后的所有兄弟元素, 出现符合选择器的兄弟元素为止, 不包含此符合选择器的兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery NextUntil ( string expression )
		{ return this.Execute ( "nextUntil", expression ); }

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
		/// 去除当前 jQuery 中符合条件的元素.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'strong'", 也可以是测试函数, 比如: "function(i){return (i == 0) || (i == 4);}", 也可以是 DOM 元素, 比如: "document.getElementById('li51')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Not ( string expression )
		{ return this.Execute ( "not", expression ); }

		#endregion

		#region " 方法 O "

		/// <summary>
		/// 获取当前 jQuery 中第一个元素相对于 document 的位置, 返回值保存一个拥有 top 和 left 属性的对象中.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Offset ( )
		{ return this.Offset ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素相对于 document 的位置.
		/// </summary>
		/// <param name="expression">返回具有 top 和 left 属性的对象的表达式, 比如: "{ top: 10, left: 20 }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Offset ( string expression )
		{ return this.Execute ( "offset", expression ); }

		/// <summary>
		/// 获取 jQuery 中包含元素的第一个设置了 position 样式为 relative, absolute 或者 fixed 的父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OffsetParent ( )
		{ return this.Execute ( "offsetParent" ); }

		/// <summary>
		/// 为 jQuery 中的元素添加只执行一次的事件. (需要 1.1 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery One ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "one", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 包含边框, padding. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterHeight ( )
		{ return this.OuterHeight ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的高度数值, 包含边框, padding, 可选 margin. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个布尔表达式, 比如: "true", 指定是否包含 margin, 默认为 false.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterHeight ( string expression )
		{ return this.Execute ( "outerHeight", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 包含边框, padding. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterWidth ( )
		{ return this.OuterWidth ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值, 包含边框, padding, 可选 margin. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个布尔表达式, 比如: "true", 指定是否包含 margin, 默认为 false.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery OuterWidth ( string expression )
		{ return this.Execute ( "outerWidth", expression ); }

		#endregion

		#region " 方法  P "

		/// <summary>
		/// 将对象或者数组转化为 url 参数.
		/// </summary>
		/// <param name="expressionI">对象或者数组, 比如: "{name: 'abc', age: 12}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Param ( string expressionI )
		{ return this.Param ( expressionI, null ); }
		/// <summary>
		/// 将对象或者数组转化为 url 参数.
		/// </summary>
		/// <param name="expressionI">对象或者数组, 比如: "{name: 'abc', age: 12}".</param>
		/// <param name="expressionII">返回布尔值的表达式, 比如: "true", 指示是否深度转化.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Param ( string expressionI, string expressionII )
		{ return this.Execute ( "param", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parent ( )
		{ return this.Parent ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的第一级符合选择器的父元素.
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parent ( string expression )
		{ return this.Execute ( "parent", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有父元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parents ( )
		{ return this.Parents ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有符合选择器的父元素.
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Parents ( string expression )
		{ return this.Execute ( "parents", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的所有父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ParentsUntil ( )
		{ return this.ParentsUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的所有父元素, 出现符合选择器的父元素为止, 不包含此符合选择器的父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择父元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ParentsUntil ( string expression )
		{ return this.Execute ( "parentsUntil", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中第一个元素相对于父元素的位置, 返回值保存一个拥有 top 和 left 属性的对象中.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Position ( )
		{ return this.Execute ( "position" ); }

		/// <summary>
		/// 使用 POST 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Post ( string expressionI )
		{ return this.Post ( expressionI, null, null, null ); }
		/// <summary>
		/// 使用 POST 获取请求数据.
		/// </summary>
		/// <param name="expressionI">返回地址的表达式, 比如: "js/test.js".</param>
		/// <param name="expressionII">返回对象或字符串的表达式, 比如: "{name: 'abc'}", 将传送给服务器.</param>
		/// <param name="expressionIII">返回成功时回调函数的表达式, 比如: "function(d, t, j){alert('ajax');}".</param>
		/// <param name="expressionIV">指定获取数据类型的字符串, "'xml'", "'json'", "'script'", "'html'" 中的一种.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Post ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "post", expressionI, expressionII, expressionIII, expressionIV ); }

		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是返回 html 代码的函数, 比如: "function(i, h) { return 'old html is ' + h;}". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prepend ( string expressionI )
		{ return this.Prepend ( expressionI, null ); }
		/// <summary>
		/// 在当前 jQuery 中包含的所有元素之前添加新的内容作为子元素.
		/// </summary>
		/// <param name="expressionI">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <param name="expressionII">作用同第一个参数, 不过以数组的形式存在, 比如: "['&lt;stong&gt;ok&lt;/stong&gt;', '&lt;span&gt;ok&lt;/span&gt;']".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prepend ( string expressionI, string expressionII )
		{ return this.Execute ( "prepend", expressionI, expressionII ); }

		/// <summary>
		/// 将当前 jQuery 中包含的元素追加到指定目标之前.
		/// </summary>
		/// <param name="expression">可以是选择器, 比如: "'.red'", 可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrependTo ( string expression )
		{ return this.Execute ( "prependTo", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的第一个兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prev ( )
		{ return this.Prev ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的符合选择器的第一个兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prev ( string expression )
		{ return this.Execute ( "prev", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevAll ( )
		{ return this.PrevAll ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素的向前的符合选择器的所有兄弟元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevAll ( string expression )
		{ return this.Execute ( "prevAll", expression ); }

		/// <summary>
		/// 得到当前 jQuery 中包含元素向前的所有兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevUntil ( )
		{ return this.PrevUntil ( null ); }
		/// <summary>
		/// 得到当前 jQuery 中包含元素向前的所有兄弟元素, 出现符合选择器的兄弟元素为止, 不包含此符合选择器的兄弟元素. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery PrevUntil ( string expression )
		{ return this.Execute ( "prevUntil", expression ); }

		/// <summary>
		/// 返回承若对象. (需要 1.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Promise ( )
		{ return this.Promise ( null, null ); }
		/// <summary>
		/// 返回承若对象. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">观察的类型.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Promise ( string expressionI )
		{ return this.Promise ( expressionI, null ); }
		/// <summary>
		/// 返回承若对象. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">观察的类型.</param>
		/// <param name="expressionII">承若附加的对象.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Promise ( string expressionI, string expressionII )
		{ return this.Execute ( "promise", expressionI, expressionII ); }

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的属性, 与 Attr 不同的是返回的值不单单为字符串, 或者设置所有元素的多个属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'", 也可以是属性集合, 比如: "{type: 'text', title: 'test'}".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prop ( string expressionI )
		{ return this.Prop ( expressionI, null ); }
		/// <summary>
		/// 设置 jQuery 中元素的属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">可以是属性名称, 比如: "'title'".</param>
		/// <param name="expressionII">返回属性名称的表达式, 比如: "'just test'", 或者返回属性值的函数, 比如: "function(i, a){ return 'my_' + i.toString(); }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Prop ( string expressionI, string expressionII )
		{ return this.Execute ( "prop", expressionI, expressionII ); }

		/// <summary>
		/// 产生新的函数, 并指定新的上下文. (需要 1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">函数的原型, 比如: "function(){ return this.toString(); }", 如果 expressionII 是函数名称, 也可以是新的上下文的表达式, 比如: "someobj".</param>
		/// <param name="expressionII">新的上下文的表达式, 比如: "someobj", 如果 expressionI 是上下文的表达式, 也可以是函数名称, 比如: "'test'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Proxy ( string expressionI, string expressionII )
		{ return this.Execute ( "proxy", expressionI, expressionII ); }

		#endregion

		#region " 方法 R "

		/// <summary>
		/// 添加当整个页面载入后的事件.
		/// </summary>
		/// <param name="expression">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Ready ( string expression )
		{ return this.Execute ( "", expression ); }

		/// <summary>
		/// 将当前 jQuery 中的元素从页面中删除.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Remove ( )
		{ return this.Remove ( null ); }
		/// <summary>
		/// 将当前 jQuery 中符合选择器的元素从页面中删除.
		/// </summary>
		/// <param name="expression">用于选择删除元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Remove ( string expression )
		{ return this.Execute ( "remove", expression ); }

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

		/// <summary>
		/// 删除通过 Prop 添加的属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveProp ( string expressionI )
		{ return this.RemoveProp ( expressionI, null ); }
		/// <summary>
		/// 删除通过 Prop 添加的属性. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">返回属性名称的表达式, 比如: "'title'".</param>
		/// <param name="expressionII">用于匹配属性的值, 比如: "'happy.gif'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery RemoveProp ( string expressionI, string expressionII )
		{ return this.Execute ( "removeProp", expressionI, expressionII ); }

		/// <summary>
		/// 使用当前 jQuery 中的元素替换符合选择器的元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">选择被替换到的元素的选择器, 比如: "'li'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ReplaceAll ( string expression )
		{ return this.Execute ( "replaceAll", expression ); }

		/// <summary>
		/// 使用新的元素替换当前 jQuery 中的元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;ok&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(){ document.getElementById('abc') }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ReplaceWith ( string expression )
		{ return this.Execute ( "replaceWith", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加大小改变事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( )
		{ return this.Resize ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加大小改变的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( string expressionI )
		{ return this.Resize ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加大小改变的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Resize ( string expressionI, string expressionII )
		{ return this.Execute ( "resize", expressionI, expressionII ); }

		#endregion

		#region " 方法 S "

		/// <summary>
		/// 触发 jQuery 中的元素的添加滚动轴事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( )
		{ return this.Scroll ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加滚动轴的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( string expressionI )
		{ return this.Scroll ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加滚动轴的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Scroll ( string expressionI, string expressionII )
		{ return this.Execute ( "scroll", expressionI, expressionII ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的水平滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollLeft ( )
		{ return this.ScrollLeft ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的水平滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollLeft ( string expression )
		{ return this.Execute ( "scrollLeft", expression ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的垂直滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollTop ( )
		{ return this.ScrollTop ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的垂直滚动轴位置. (需要 1.2.6 版本以上)
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery ScrollTop ( string expression )
		{ return this.Execute ( "scrollTop", expression ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加选择事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( )
		{ return this.Select ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加选择的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( string expressionI )
		{ return this.Select ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加选择的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Select ( string expressionI, string expressionII )
		{ return this.Execute ( "select", expressionI, expressionII ); }

		/// <summary>
		/// 将表单中包含的值转化为 url 参数字符串.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Serialize ( )
		{ return this.Execute ( "serialize" ); }

		/// <summary>
		/// 将表单中包含的值转化为数组.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery SerializeArray ( )
		{ return this.Execute ( "serializeArray" ); }

		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有兄弟元素.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Siblings ( )
		{ return this.Siblings ( null ); }
		/// <summary>
		/// 获取当前 jQuery 中包含的元素的所有符合选择器的兄弟元素.
		/// </summary>
		/// <param name="expression">用于选择兄弟元素的选择器, 比如: "'strong'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Siblings ( string expression )
		{ return this.Execute ( "siblings", expression ); }

		/// <summary>
		/// 选择当前 jQuery 中从某个位置开始到结束范围的元素, 0 是第 1 个元素, -1 是最后一个元素. (需要 1.1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Slice ( string expressionI )
		{ return this.Slice ( expressionI, null ); }
		/// <summary>
		/// 选择当前 jQuery 中某个范围的元素, 0 是第 1 个元素, -1 是最后一个元素. (需要 1.1.4 版本以上)
		/// </summary>
		/// <param name="expressionI">开始索引, 比如: "1".</param>
		/// <param name="expressionII">结束索引, 比如: "2", 结束位置的元素不会被选择.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Slice ( string expressionI, string expressionII )
		{ return this.Execute ( "slice", expressionI, expressionII ); }

		/// <summary>
		/// 创建主 jQuery 对象的副本.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Sub ( )
		{ return this.Execute ( "sub" ); }

		/// <summary>
		/// 触发 jQuery 中的元素的添加提交事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( )
		{ return this.Submit ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加提交的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( string expressionI )
		{ return this.Submit ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加提交的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionI">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Submit ( string expressionI, string expressionII )
		{ return this.Execute ( "submit", expressionI, expressionII ); }

		#endregion

		#region " 方法 T "

		/// <summary>
		/// 获取 jQuery 中包含的第一个元素的 innerText 属性.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Text ( )
		{ return this.Text ( null ); }
		/// <summary>
		/// 设置 jQuery 中包含元素的 innerText 属性.
		/// </summary>
		/// <param name="expression">一个字符串表达式, 比如: "'this is abc'", 或者返回字符串的函数, 比如: "function(i, t){ return 'old text is ' + t; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Text ( string expression )
		{ return this.Execute ( "text", expression ); }

		/// <summary>
		/// 为当前 jQuery 元素添加多个点击事件, 将根据点击次数在这些事件中切换.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <param name="expressionII">同 expressionI, 可以为 null.</param>
		/// <param name="expressionIII">同 expressionI, 可以为 null.</param>
		/// <param name="expressionIV">同 expressionI, 可以为 null.</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Toggle ( string expressionI, string expressionII, string expressionIII, string expressionIV )
		{ return this.Execute ( "toggle", expressionI, expressionII, expressionIII, expressionIV ); }

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

		/// <summary>
		/// 触发 jQuery 中元素的事件. (需要 1.3 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Trigger ( string expressionI )
		{ return this.Trigger ( expressionI, null ); }
		/// <summary>
		/// 触发 jQuery 中元素的事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">扩展的参数数组, 比如: "[age: 10, size: 100]".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Trigger ( string expressionI, string expressionII )
		{ return this.Execute ( "trigger", expressionI, expressionII ); }

		/// <summary>
		/// 触发 jQuery 中第一个元素的事件, 不引发元素的默认行文. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">扩展的参数数组, 比如: "[age: 10, size: 100]".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery TriggerHandler ( string expressionI, string expressionII )
		{ return this.Execute ( "triggerHandler", expressionI, expressionII ); }

		#endregion

		#region " 方法 U "

		/// <summary>
		/// 为 jQuery 中的元素取消所有事件.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( )
		{ return this.Unbind ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件.
		/// </summary>
		/// <param name="expressionI">可以是事件类型, 比如: "'click'", "'click mouseover'", 也可以是包含多个事件的对象, 比如: "{ click: function(){}, mouseover: function(){} }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( string expressionI )
		{ return this.Unbind ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件.
		/// </summary>
		/// <param name="expressionI">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionII">可以是返回函数的表达式, 比如: "function(){ return false; }", 或者为 "false", 表示取消停止冒泡的事件. (如果使用 false 需要 1.4.3 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unbind ( string expressionI, string expressionII )
		{ return this.Execute ( "unbind", expressionI, expressionII ); }

		/// <summary>
		/// 为 jQuery 中的元素取消所有事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( )
		{ return this.Undelegate ( null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消命名空间下的事件. (需要 1.6 版本以上)
		/// </summary>
		/// <param name="expressionI">事件所在的命名空间, 比如: "'.whatever'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI )
		{ return this.Undelegate ( expressionI, null, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI, string expressionII )
		{ return this.Undelegate ( expressionI, expressionII, null ); }
		/// <summary>
		/// 为 jQuery 中的元素取消事件. (需要 1.4.2 版本以上)
		/// </summary>
		/// <param name="expressionI">选择元素的选择器, 比如: "'li'".</param>
		/// <param name="expressionII">事件的类型, 比如: "'click'", "'click mouseover'".</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Undelegate ( string expressionI, string expressionII, string expressionIII )
		{ return this.Execute ( "undelegate", expressionI, expressionII, expressionIII ); }

		/// <summary>
		/// 为 jQuery 中的元素添加卸载的事件.
		/// </summary>
		/// <param name="expressionI">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unload ( string expressionI )
		{ return this.Unload ( expressionI, null ); }
		/// <summary>
		/// 为 jQuery 中的元素添加卸载的事件. (需要 1.4.3 版本以上)
		/// </summary>
		/// <param name="expressionII">一个返回值的表达式, 比如: "{age: 10, name: 'lili'}", 值将传递给事件, 并通过 event.data 访问.</param>
		/// <param name="expressionIII">返回函数的表达式, 比如: "function(){ return false; }".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unload ( string expressionI, string expressionII )
		{ return this.Execute ( "unload", expressionI, expressionII ); }

		/// <summary>
		/// 删除调用 wrap 方法产生的父元素. (需要 1.4 版本以上)
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Unwrap ( )
		{ return this.Execute ( "unwrap" ); }

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

		/// <summary>
		/// 获取当前 jQuery 中包含的第一个元素的宽度数值.
		/// </summary>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Width ( )
		{ return this.Width ( null ); }
		/// <summary>
		/// 设置当前 jQuery 中元素的宽度.
		/// </summary>
		/// <param name="expression">一个数值的表达式, 比如: "110", 或者一个返回数值的函数, 比如: "function(i, w){ return i + w; }". (如果使用函数需要 1.4.1 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Width ( string expression )
		{ return this.Execute ( "width", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的每一个元素添加父元素.
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(i){ return '&lt;div&gt;&lt;/div&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery Wrap ( string expression )
		{ return this.Execute ( "wrap", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的元素添加一个共同的父元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')".</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery WrapAll ( string expression )
		{ return this.Execute ( "wrapAll", expression ); }

		/// <summary>
		/// 为当前 jQuery 中的每一个元素添加一个子元素, 这个子元素包含原来所有的子元素. (需要 1.2 版本以上)
		/// </summary>
		/// <param name="expression">可以是返回 html 代码的表达式, 比如: "'&lt;stong&gt;&lt;/stong&gt;'", 也可以是元素, 比如: "document.getElementById('myTable')" 或者是 jQuery 对象, 比如: "$('a')", 还可以是一个返回元素的函数, 比如: "function(){ return '&lt;div&gt;&lt;/div&gt;'; }". (如果使用函数需要 1.4 版本以上)</param>
		/// <returns>更新后的 JQuery 对象.</returns>
		public JQuery WrapInner ( string expression )
		{ return this.Execute ( "wrapInner", expression ); }

		#endregion

	}

}
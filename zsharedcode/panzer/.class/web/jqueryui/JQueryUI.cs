/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/JQueryUI.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */


using zoyobar.shared.panzer.web.jqueryui.plusin;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " JQueryUI "
	/// <summary>
	/// jQuery UI 辅助类.
	/// </summary>
	public sealed class JQueryUI
		: JQuery
	{

		/// <summary>
		/// 从选项中得到一个 javascript 对象.
		/// </summary>
		/// <param name="options">选项.</param>
		/// <returns>javascript 对象.</returns>
		public static string MakeOptionExpression ( Option[] options )
		{

			if ( null == options || options.Length == 0 )
				return string.Empty;

			string optionExpression = "{";

			foreach ( Option option in options )
				if ( null != option && option.Type != OptionType.none && option.Value != string.Empty )
					optionExpression += string.Format ( " {0}: {1},", option.Type, option.Value );

			return optionExpression.TrimEnd ( ',' ) + " }";
		}

		private static string makeParameterExpression ( Parameter[] parameters, bool isWebService, string quote )
		{

			if ( null == quote )
				quote = string.Empty;

			if ( null == parameters || parameters.Length == 0 )
				if ( isWebService )
					return quote + "{ }" + quote;
				else
					return "{ }";


			string parameterExpression = string.Empty;

			foreach ( Parameter parameter in parameters )
				if ( null != parameter && parameter.Value != string.Empty )
					switch ( parameter.Type )
					{
						case ParameterType.Selector:

							if ( isWebService )
							{

								if ( parameterExpression != string.Empty )
									parameterExpression += string.Format ( " + {0} ,{0}", quote );

								parameterExpression += string.Format ( " + {0}{1}: {0} + jQuery.panzer.encodeValue({2}, {3}, {0}{4}{0}, {5})", quote, parameter.Name, JQuery.Create ( string.Format ( "jQuery.panzer.createJQuery({0})", UISetting.CreateJQuerySelector ( parameter.Value ) ) ).Val ( ).Code, parameter.Default, parameter.DataType.ToString ( ).ToLower ( ), parameter.Provider );
							}
							else
								parameterExpression += string.Format ( " {1}: jQuery.panzer.convert({2}, {3}, {0}{4}{0}, {5}),", quote, parameter.Name, JQuery.Create ( string.Format ( "jQuery.panzer.createJQuery({0})", UISetting.CreateJQuerySelector ( parameter.Value ) ) ).Val ( ).Code, parameter.Default, parameter.DataType.ToString ( ).ToLower ( ), parameter.Provider );

							break;

						case ParameterType.Expression:

							if ( isWebService )
							{

								if ( parameterExpression != string.Empty )
									parameterExpression += string.Format ( " + {0} ,{0}", quote );

								parameterExpression += string.Format ( " + {0}{1}: {0} + jQuery.panzer.encodeValue({2}, {3}, {0}{4}{0}, {5})", quote, parameter.Name, parameter.Value, parameter.Default, parameter.DataType.ToString ( ).ToLower ( ), parameter.Provider );
							}
							else
								parameterExpression += string.Format ( " {1}: jQuery.panzer.convert({2}, {3}, {0}{4}{0}, {5}),", quote, parameter.Name, parameter.Value, parameter.Default, parameter.DataType.ToString ( ).ToLower ( ), parameter.Provider );

							break;
					}

			if ( isWebService )
				parameterExpression = quote + "{" + quote + parameterExpression + " + " + quote + "}" + quote;
			else
				parameterExpression = "{" + parameterExpression.TrimEnd ( ',' ) + "}";

			return parameterExpression;
		}

		#region " 构造 "
		/// <summary>
		/// 从 Ajax 设置创建一个 JQuery 实例, 如果设置中的请求地址为空, 则返回 null.
		/// </summary>
		/// <param name="setting">Ajax 相关设置.</param>
		/// <returns>JQuery 实例.</returns>
		public static JQuery Create ( AjaxSetting setting )
		{

			if ( string.IsNullOrEmpty ( setting.Url ) )
				return null;

			string quote;

			if ( setting.IsSingleQuote )
				quote = "'";
			else
				quote = "\"";

			string data;
			bool isWebService = !string.IsNullOrEmpty ( setting.MethodName );

			if ( !string.IsNullOrEmpty ( setting.Data ) )
				data = setting.Data;
			else if ( string.IsNullOrEmpty ( setting.Form ) )
				data = makeParameterExpression ( setting.Parameters, isWebService, quote );
			else
				data = JQuery.Create ( setting.Form, false ).Serialize ( ).Code;

			string map = string.Format ( "url: {0}{1}{0}, dataType: {0}{2}{0}, data: {3}, type: {0}{4}{0}",
				quote,
				setting.Url + ( isWebService ? "/" + setting.MethodName : string.Empty ),
				setting.DataType,
				data,
				setting.Type
				);

			if ( !string.IsNullOrEmpty ( setting.ContentType ) )
				map += string.Format ( ", contentType: {0}{1}{0}", quote, setting.ContentType );

			foreach ( Event @event in setting.SettingHelper.Events )
				if ( @event.Type != EventType.none && @event.Type != EventType.__init && !string.IsNullOrEmpty ( @event.Value ) )
					map += ", " + @event.Type + ": " + @event.Value;

			return JQuery.Create ( false, false ).Ajax ( "{" + map + "}" );
		}

		/// <summary>
		/// 从另一个 JQueryUI 上创建具有相同 Code 属性的 JQuery UI 实例.
		/// </summary>
		/// <param name="jQuery">JQueryUI 实例, 新实例将复制其 Code 属性.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static JQueryUI Create ( JQueryUI jQuery )
		{ return new JQueryUI ( jQuery ); }

		/// <summary>
		/// 创建使用别名 $ 的空的 JQuery UI.
		/// </summary>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( )
		{ return Create ( null, null, true ); }
		/// <summary>
		/// 创建空的 JQuery UI.
		/// </summary>
		/// <param name="isAlias">如果为 true, 则在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( bool isAlias )
		{ return Create ( null, null, isAlias ); }
		/// <summary>
		/// 创建使用别名 $ 的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( string expressionI )
		{ return Create ( expressionI, null, true ); }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">如果为 true, 则在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( string expressionI, bool isAlias )
		{ return Create ( expressionI, null, isAlias ); }
		/// <summary>
		/// 创建使用别名 $ 的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( string expressionI, string expressionII )
		{ return Create ( expressionI, expressionII, true ); }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">如果为 true, 则在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( string expressionI, string expressionII, bool isAlias )
		{ return new JQueryUI ( expressionI, expressionII, isAlias ); }

		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">如果为 true, 则在脚本中使用 $ 作为 jQuery 的别名.</param>
		/// <returns>JQuery UI 实例.</returns>
		public static new JQueryUI Create ( bool isInstance, bool isAlias )
		{ return new JQueryUI ( isInstance, isAlias ); }


		/// <summary>
		/// 从另一个 JQuery 上创建具有相同 Code 属性的 JQuery UI 实例.
		/// </summary>
		/// <param name="jQuery">JQuery UI 实例, 新实例将复制其 Code 属性.</param>
		public JQueryUI ( JQueryUI jQuery )
			: base ( jQuery )
		{ }

		/// <summary>
		/// 创建使用别名 $ 的空的 JQuery UI.
		/// </summary>
		public JQueryUI ( )
			: this ( null, null, true )
		{ }
		/// <summary>
		/// 创建空的 JQuery UI.
		/// </summary>
		/// <param name="isAlias">如果为 true, 则在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( bool isAlias )
			: this ( null, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名 $ 的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		public JQueryUI ( string expressionI )
			: this ( expressionI, null, true )
		{ }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 也可以是 DOM 元素, 比如: "document.getElementById('myTable')", "[document.getElementById('myTable1'), document.getElementById('myTable2')]", 也可以是脚本中另一个 jQuery 实例, 比如: "myJQuery", 也可以是页面载入的回调函数, 比如: "function(){}", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="isAlias">如果为 true, 则在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( string expressionI, bool isAlias )
			: this ( expressionI, null, isAlias )
		{ }
		/// <summary>
		/// 创建使用别名的 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		public JQueryUI ( string expressionI, string expressionII )
			: this ( expressionI, expressionII, true )
		{ }
		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="expressionI">可以是选择器, 比如: "'body table .red'", 或者是一段要添加的 html 代码, 比如: "'&lt;stong&gt;&lt;/stong&gt;'".</param>
		/// <param name="expressionII">当 expressionI 是选择器时, expressionII 是一个 DOM 元素, 指定搜索上下文, 比如: "document.body", 当 expressionI 是一段 html 代码时, expressionII 可以是 document 元素, 指定 html 代码创建位置, 比如: "document", 也可以是属性集合, 用来初始化只包含单一元素 html 代码元素, 比如: "{type: 'text'}".</param>
		/// <param name="isAlias">如果为 true, 则在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( string expressionI, string expressionII, bool isAlias )
			: base ( expressionI, expressionII, isAlias )
		{ }

		/// <summary>
		/// 创建 JQuery UI.
		/// </summary>
		/// <param name="isInstance">是否创建为实例, 为 false, 则创建为 $, 否则为 $().</param>
		/// <param name="isAlias">如果为 true, 则在脚本中使用 $ 作为 jQuery 的别名.</param>
		public JQueryUI ( bool isInstance, bool isAlias )
			: base ( isInstance, isAlias )
		{ }

		#endregion

		#region " jquery ui "
		/// <summary>
		/// 在 jQuery 中包含的页面元素的某个事件中执行或者直接执行 Ajax 调用.
		/// </summary>
		/// <param name="setting">Ajax 相关设置.</param>
		/// <returns>更新后的 JQueryUI.</returns>
		public JQueryUI Ajax ( AjaxSetting setting )
		{

			if ( setting.EventType == EventType.none )
				return this;

			string code;

			if ( string.IsNullOrEmpty ( setting.ClientFunction ) )
			{
				JQuery ajax = JQueryUI.Create ( setting );

				if ( null == ajax )
					return this;

				code = "function(e){" + ajax.EndLine ( ).Code + "}";
			}
			else
				code = setting.ClientFunction;

			if ( setting.EventType == EventType.__init )
			{

				if ( this.code != string.Empty )
					this.EndLine ( );

				this.AppendCode ( code );
			}
			else
				this.Bind ( string.Format ( "'{0}'", setting.EventType ), code );

			return this;
		}

		/// <summary>
		/// 使 jQuery 中包含的页面元素转变为 je 中的自定义插件.
		/// </summary>
		/// <param name="setting">自定义插件相关设置, 为 TimerSetting, RepeaterSetting 等.</param>
		/// <returns>更新后的 JQueryUI.</returns>
		public JQueryUI Plusin ( PlusinSetting setting )
		{
			// 这个方法引用了命名空间 plusin 里面的类, 可以新建一个 JQueryUIPlusin 类, 再将 Plusin 放到 JQueryUIPlusin 中.

			if ( null == setting || setting.PlusinType == PlusinType.custom )
				return this;

			setting.Recombine ( );

			return this.Execute ( "__" + setting.PlusinType.ToString ( ), MakeOptionExpression ( setting.SettingHelper.CreateOptions ( ) ) ) as JQueryUI;
		}

		/// <summary>
		/// 使 jQuery 中包含的页面元素具有某种交互效果.
		/// </summary>
		/// <param name="setting">交互相关设置, 为 DraggableSetting, DroppableSetting 等.</param>
		/// <returns>更新后的 JQueryUI.</returns>
		public JQueryUI Interaction ( InteractionSetting setting )
		{

			if ( null == setting )
				return this;

			return this.Execute ( setting.InteractionType.ToString ( ), MakeOptionExpression ( setting.SettingHelper.CreateOptions ( ) ) ) as JQueryUI;
		}

		/// <summary>
		/// 使 jQuery 中包含的页面元素转变为某种插件.
		/// </summary>
		/// <param name="setting">插件相关设置, 为 ButtonSetting, DatepickerSetting 等.</param>
		/// <returns>更新后的 JQueryUI.</returns>
		public JQueryUI Widget ( WidgetSetting setting )
		{
			// If this is the plusin, do not execute this method
			if ( null == setting || setting.WidgetType == WidgetType.custom )
				return this;

			setting.Recombine ( );

			// Append WIDGET script
			this.Execute ( setting.WidgetType.ToString ( ), MakeOptionExpression ( setting.SettingHelper.CreateOptions ( ) ) );

			// Append event, such as: click( ... )
			foreach ( Event @event in setting.SettingHelper.Events )
				if ( @event.Type != EventType.none && @event.Type != EventType.__init )
					this.Execute ( @event.Type.ToString ( ), @event.Value );

			// Append ajax calls
			foreach ( AjaxSetting ajax in setting.Ajaxs )
				this.Ajax ( ajax );

			return this;
		}
		#endregion

	}
	#endregion

}

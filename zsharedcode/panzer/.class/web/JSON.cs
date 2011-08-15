/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JSON.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.Collections.Generic;

using zoyobar.shared.panzer.code;

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// JSON 数据类型.
	/// </summary>
	public enum JSONType
	{
		/// <summary>
		/// 对象.
		/// </summary>
		Object = 1,
		/// <summary>
		/// 数组.
		/// </summary>
		Array,
		/// <summary>
		/// 字符串.
		/// </summary>
		String,
		/// <summary>
		/// 布尔值.
		/// </summary>
		Boolean,
		/// <summary>
		/// 数值.
		/// </summary>
		Number,
		/// <summary>
		/// 日期.
		/// </summary>
		Date
	}

	/// <summary>
	/// 和页面对应的 JSON 数据类型.
	/// </summary>
	public class JSON
	{

		private static void pushJSON ( ref JSON currentJSON, JSON newJSON, Stack<JSON> jsonStack )
		{

			if ( null == newJSON || null == jsonStack )
				return;

			if ( null != currentJSON )
				jsonStack.Push ( currentJSON );

			currentJSON = newJSON;
		}

		private static void popJSON ( ref JSON currentJSON, Stack<JSON> jsonStack )
		{

			if ( null == jsonStack || jsonStack.Count == 0 )
				return;

			jsonStack.Peek ( ).AppendChild ( currentJSON );

			currentJSON = jsonStack.Pop ( );
		}

		private static T getValue<T> ( string command )
		{

			if ( string.IsNullOrEmpty ( command ) )
				return default ( T );

			string[] parts = command.Split ( new string[] { "`:`" }, StringSplitOptions.None );

			if ( parts.Length < 2 )
				return default ( T );

			return StringConvert.ToObject<T> ( parts[1] );
		}

		private static string getName ( string command )
		{

			if ( string.IsNullOrEmpty ( command ) )
				return null;

			string[] parts = command.Split ( new string[] { "`:`" }, StringSplitOptions.None );

			if ( parts.Length < 3 )
				return null;

			return parts[2];
		}

		/// <summary>
		/// 从字符串创建一个 JSON 对象.
		/// </summary>
		/// <param name="expression">用于创建 JSON 的字符串.</param>
		/// <returns>JSON 对象.</returns>
		public static JSON Create ( string expression )
		{

			if ( string.IsNullOrEmpty ( expression ) )
				return null;

			Stack<JSON> jsons = new Stack<JSON> ( );
			JSON currentJSON = null;

			foreach ( string command in expression.Split ( new string[] { "`;`" }, StringSplitOptions.None ) )
				if ( command.StartsWith ( "create-array" ) )
					pushJSON ( ref currentJSON, new JSON ( JSONType.Array, getName ( command ) ), jsons );
				else if ( command.StartsWith ( "create-object" ) )
					pushJSON ( ref currentJSON, new JSON ( JSONType.Object, getName ( command ) ), jsons );
				else if ( command == "add-array" || command == "add-object" )
					popJSON ( ref currentJSON, jsons );
				else if ( command.StartsWith ( "add-string" ) && null != currentJSON )
					currentJSON.AppendChild ( new JSON ( getValue<string> ( command ), getName ( command ) ) );
				else if ( command.StartsWith ( "add-number" ) && null != currentJSON )
					currentJSON.AppendChild ( new JSON ( getValue<decimal> ( command ), getName ( command ) ) );
				else if ( command.StartsWith ( "add-boolean" ) && null != currentJSON )
					currentJSON.AppendChild ( new JSON ( getValue<bool> ( command ), getName ( command ) ) );
				else if ( command.StartsWith ( "add-date" ) && null != currentJSON )
					currentJSON.AppendChild ( new JSON ( getValue<DateTime> ( command ), getName ( command ) ) );

			return currentJSON;
		}

		private readonly SortedList<string, JSON> attributes = new SortedList<string, JSON> ( );
		private readonly List<JSON> values = new List<JSON> ( );
		private readonly JSONType type;
		private object value;
		private string name;

		private JSON ( JSONType type, object value, string name )
		{
			this.type = type;
			this.value = value;
			this.name = name;
		}

		/// <summary>
		/// 创建一个具有指定类型的 JSON 对象.
		/// </summary>
		/// <param name="type">JSON 的类型.</param>
		public JSON ( JSONType type )
			: this ( type, null, null )
		{ }

		/// <summary>
		/// 创建一个具有指定类型和名称的 JSON 对象.
		/// </summary>
		/// <param name="type">JSON 的类型.</param>
		public JSON ( JSONType type, string name )
			: this ( type, null, name )
		{ }

		/// <summary>
		/// 创建字符串类型的 JSON 对象.
		/// </summary>
		/// <param name="value">字符串值.</param>
		public JSON ( string value )
			: this ( JSONType.String, value, null )
		{ }

		/// <summary>
		/// 创建数值类型的 JSON 对象.
		/// </summary>
		/// <param name="value">数值.</param>
		public JSON ( decimal value )
			: this ( JSONType.Number, value, null )
		{ }

		/// <summary>
		/// 创建布尔类型的 JSON 对象.
		/// </summary>
		/// <param name="value">布尔值.</param>
		public JSON ( bool value )
			: this ( JSONType.Boolean, value, null )
		{ }

		/// <summary>
		/// 创建日期类型的 JSON 对象.
		/// </summary>
		/// <param name="value">日期.</param>
		public JSON ( DateTime value )
			: this ( JSONType.Date, value, null )
		{ }

		/// <summary>
		/// 创建字符串类型并具有名称的 JSON 对象.
		/// </summary>
		/// <param name="value">字符串值.</param>
		/// <param name="name">名称.</param>
		public JSON ( string value, string name )
			: this ( JSONType.String, value, name )
		{ }

		/// <summary>
		/// 创建数值类型并具有名称的 JSON 对象.
		/// </summary>
		/// <param name="value">数值.</param>
		/// <param name="name">名称.</param>
		public JSON ( decimal value, string name )
			: this ( JSONType.Number, value, name )
		{ }

		/// <summary>
		/// 创建布尔类型并具有名称的 JSON 对象.
		/// </summary>
		/// <param name="value">布尔值.</param>
		/// <param name="name">名称.</param>
		public JSON ( bool value, string name )
			: this ( JSONType.Boolean, value, name )
		{ }

		/// <summary>
		/// 创建日期类型并具有名称的 JSON 对象.
		/// </summary>
		/// <param name="value">日期.</param>
		/// <param name="name">名称.</param>
		public JSON ( DateTime value, string name )
			: this ( JSONType.Date, value, name )
		{ }

		/// <summary>
		/// 获取 JSON 中的属性, Type 应为 Object.
		/// </summary>
		public SortedList<string, JSON> Attributes
		{
			get
			{

				if ( this.type != JSONType.Object )
					throw new Exception ( "JSONType 不为 Object 的 JSON 不能访问 Attributes 属性" );

				return this.attributes;
			}
		}

		/// <summary>
		/// 获取 JSON 中的数组, Type 应为 Array.
		/// </summary>
		public List<JSON> Values
		{
			get
			{

				if ( this.type != JSONType.Array )
					throw new Exception ( "JSONType 不为 Array 的 JSON 不能访问 Values 属性" );

				return this.values;
			}
		}

		/// <summary>
		/// 获取 JSON 中的数组或属性.
		/// </summary>
		/// <param name="key">索引或者属性名称.</param>
		/// <returns>值.</returns>
		public JSON this[object key]
		{
			get
			{

				switch ( this.type )
				{
					case JSONType.Array:

						if ( !( key is int ) || ( int ) key >= this.values.Count )
							return null;

						return this.values[( int ) key];

					case JSONType.Object:

						if ( !( key is string ) || !this.attributes.ContainsKey ( key as string ) )
							return null;

						return this.attributes[key as string];

					default:
						throw new Exception ( "JSONType 不为 Object, Array 的 JSON 不能访问 this 属性" );
				}

			}
		}

		/// <summary>
		/// 获取或设置 JSON 中的值, Type 不应该为 Object, Array.
		/// </summary>
		public object Value
		{
			get
			{

				if ( this.type == JSONType.Object || this.type == JSONType.Array )
					throw new Exception ( "JSONType 为 Object, Array 的 JSON 不能访问 Value 属性" );

				return this.value;
			}
			set
			{

				if ( this.type == JSONType.Object || this.type == JSONType.Array )
					throw new Exception ( "JSONType 为 Object, Array 的 JSON 不能访问 Value 属性" );

				this.value = value;
			}
		}

		/// <summary>
		/// 获取 JSON 的类型.
		/// </summary>
		public JSONType Type
		{
			get { return this.type; }
		}

		/// <summary>
		/// 获取或设置 JSON 名称.
		/// </summary>
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		/// <summary>
		/// 追加一个 JSON 对象, Type 应该为 Object, Array.
		/// </summary>
		/// <param name="child">追加的 JSON 对象.</param>
		public void AppendChild ( JSON child )
		{

			if ( null == child )
				return;

			switch ( this.type )
			{
				case JSONType.Array:
					this.values.Add ( child );
					break;

				case JSONType.Object:

					if ( string.IsNullOrEmpty ( child.name ) || this.attributes.ContainsKey ( child.name ) )
						return;

					this.attributes.Add ( child.name, child );
					break;
			}

		}

		/// <summary>
		/// 将 JSON 中的值转换为指定的类型, Type 不应该为 Object, Array.
		/// </summary>
		/// <typeparam name="T">转化为的类型.</typeparam>
		/// <returns>转化后的值.</returns>
		public T ConvertTo<T> ( )
		{

			if ( this.type == JSONType.Object || this.type == JSONType.Array )
				throw new Exception ( "JSONType 为 Object, Array 的 JSON 不能访问 ConvertTo 方法" );

			try
			{ return ( T ) this.value; }
			catch
			{ return default ( T ); }

		}

		/// <summary>
		/// 将 JSON 对象转化为字符串.
		/// </summary>
		/// <returns>转化后的字符串.</returns>
		public override string ToString ( )
		{
			string expression = ( string.IsNullOrEmpty ( this.name ) ? string.Empty : string.Format ( "{0}:", this.name ) );

			switch ( this.type )
			{
				case JSONType.Boolean:
					expression += this.value.ToString ( ).ToLower ( );
					break;

				case JSONType.Date:
					DateTime date = ( DateTime ) this.value;

					expression += string.Format ( "new Date({0},{1},{2},{3},{4},{5})", date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second );
					break;

				case JSONType.Number:
					expression += this.value.ToString ( );
					break;

				case JSONType.String:
					expression += string.Format ( "'{0}'", ScriptHelper.EscapeCharacter ( this.value.ToString ( ) ) );
					break;

				case JSONType.Array:
					string arrayExpression = "[";

					foreach ( JSON json in this.values )
						arrayExpression += json.ToString ( ) + ",";

					expression += arrayExpression.TrimEnd ( ',' ) + "]";
					break;

				case JSONType.Object:
					string objectExpression = "{";

					foreach ( string key in this.attributes.Keys )
						objectExpression += this.attributes[key].ToString ( ) + ",";

					expression += objectExpression.TrimEnd ( ',' ) + "}";
					break;

				default:
					return base.ToString ( );
			}

			return expression;
		}

	}

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SettingHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.Collections.Generic;

namespace zoyobar.shared.panzer.web.jqueryui
{

	/// <summary>
	/// Option 和 Event 的辅助编辑类.
	/// </summary>
	public sealed class SettingHelper
	{

		#region " convert method "
		private static T toEnum<T> ( string text, T defalutValue )
			where T : struct
		{
			T value;

			if ( string.IsNullOrEmpty ( text ) )
				value = defalutValue;
			// HACK: 可能需要添加 V5
#if V4
			else if ( !Enum.TryParse ( text.Trim ( '\'' ).Trim ( '"' ), out value ) )
				value = defalutValue;
#else
			else
				try
				{ value = ( T ) Enum.Parse ( typeof ( T ), text.Trim ( '\'' ).Trim ( '"' ), true ); }
				catch
				{ value = defalutValue; }
#endif

			return value;
		}

		private static double toDouble ( string text, double defaultValue )
		{
			double value;

			if ( string.IsNullOrEmpty ( text ) || !double.TryParse ( text, out value ) )
				value = defaultValue;

			return value;
		}

		private static bool toBoolean ( string text, bool defaultValue )
		{
			bool value;

			if ( string.IsNullOrEmpty ( text ) || !bool.TryParse ( text, out value ) )
				value = defaultValue;

			return value;
		}

		private static int toInteger ( string text, int defaultValue )
		{
			int value;

			if ( string.IsNullOrEmpty ( text ) || !int.TryParse ( text, out value ) )
				value = defaultValue;

			return value;
		}

		private static string toString ( string value, string defaultValue )
		{

			if ( string.IsNullOrEmpty ( value ) )
				return defaultValue;

			return value.Trim ( '\'' );
		}

		/// <summary>
		/// 将字符串转化为 javascript 字符串.
		/// </summary>
		/// <param name="value">字符串.</param>
		/// <returns>javascript 字符串.</returns>
		private static string toString ( string value )
		{

			if ( string.IsNullOrEmpty ( value ) )
				return string.Empty;

			return "'" + value + "'";
		}

		/// <summary>
		/// 将布尔值转化为 javascript 布尔值.
		/// </summary>
		/// <param name="value">布尔值.</param>
		/// <returns>javascript 布尔值.</returns>
		private static string toString ( bool value )
		{ return value.ToString ( ).ToLower ( ); }
		#endregion

		private string customOption = string.Empty;
		private readonly SortedList<OptionType, Option> options = new SortedList<OptionType, Option> ( );
		private readonly SortedList<EventType, Event> events = new SortedList<EventType, Event> ( );

		/// <summary>
		/// 获取修改的事件的个数.
		/// </summary>
		public int EventCount
		{
			get
			{
				int count = 0;

				foreach ( Event @event in this.events.Values )
					if ( @event.Value != string.Empty )
						count++;

				return count;
			}
		}

		/// <summary>
		/// 获取修改的选项的个数
		/// </summary>
		public int OptionCount
		{
			get
			{
				int count = 0;

				foreach ( Option option in this.options.Values )
					if ( option.Value != string.Empty )
						count++;

				return count;
			}
		}

		/// <summary>
		/// 获取或设置事件.
		/// </summary>
		public Event[] Events
		{
			get { return new List<Event> ( this.events.Values ).ToArray ( ); }
			set
			{

				if ( null == value )
					return;

				this.options.Clear ( );

				foreach ( Event @event in value )
					if ( null != @event && !this.events.ContainsKey ( @event.Type ) )
						this.events.Add ( @event.Type, @event );

			}
		}

		/// <summary>
		/// 获取或设置选项, 不包含自定义选项.
		/// </summary>
		public Option[] Options
		{
			get { return new List<Option> ( this.options.Values ).ToArray ( ); }
			set
			{

				if ( null == value )
					return;

				this.options.Clear ( );

				foreach ( Option option in value )
					if ( null != option && !this.options.ContainsKey ( option.Type ) )
						this.options.Add ( option.Type, option );

			}
		}

		/// <summary>
		/// 获取或设置自定义选项, 比如: "helper = __jsVariable", 多个选项请用 ; 号分隔, 如果需要在表达式中使用 ; 或 = 可用 /; 或 /= 表示.
		/// </summary>
		public string CustomOption
		{
			get { return this.customOption; }
			set { this.customOption = value; }
		}

		/// <summary>
		/// 返回包含自定义在内的选项.
		/// </summary>
		/// <returns>选项数组.</returns>
		public Option[] CreateOptions ( )
		{
			List<Option> options = new List<Option> ( this.options.Values );

			string expression = this.customOption.Replace ( "/;", "/semicolon/" ).Replace ( "/=", "/equal/" );

			if ( !string.IsNullOrEmpty ( expression ) )
				foreach ( string subExpression in expression.Split ( ';' ) )
				{
					string[] parts = subExpression.Split ( '=' );

					if ( parts.Length != 2 )
						continue;

					try
					{ options.Add ( new Option ( ( OptionType ) Enum.Parse ( typeof ( OptionType ), parts[0].Trim ( ) ), parts[1].Trim ( ).Replace ( "/semicolon/", "/;" ).Replace ( "/equal/", "/=" ) ) ); }
					catch { }

				}

			return options.ToArray ( );
		}

		/// <summary>
		/// 得到 Option 的值.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <returns>事件值.</returns>
		public string GetOptionValue ( OptionType type )
		{ return this.GetOptionValue ( type, string.Empty ); }
		/// <summary>
		/// 得到 Option 的值.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <param name="defaultValue">如果值等于默认值, 则设置为空字符串.</param>
		/// <returns>事件值.</returns>
		public string GetOptionValue ( OptionType type, string defaultValue )
		{

			if ( !this.options.ContainsKey ( type ) )
				return defaultValue;
			else
				return this.options[type].Value;

		}

		#region " convert option value "
		/// <summary>
		/// 将 Option 的值转化为布尔值.
		/// </summary>
		/// <param name="type">选项的类型.</param>
		/// <param name="defalutValue">默认值.</param>
		/// <returns>选项对应的布尔值.</returns>
		public bool GetOptionValueToBoolean ( OptionType type, bool defalutValue )
		{ return toBoolean ( this.GetOptionValue ( type ), defalutValue ); }

		/// <summary>
		/// 将 Option 的值转化为数值.
		/// </summary>
		/// <param name="type">选项的类型.</param>
		/// <param name="defalutValue">默认值.</param>
		/// <returns>选项对应的数值.</returns>
		public double GetOptionValueToDouble ( OptionType type, double defalutValue )
		{ return toDouble ( this.GetOptionValue ( type ), defalutValue ); }

		/// <summary>
		/// 将 Option 的值转化为枚举值.
		/// </summary>
		/// <typeparam name="T">枚举值的类型.</typeparam>
		/// <param name="type">选项的类型.</param>
		/// <param name="defalutValue">枚举值的默认值.</param>
		/// <returns>枚举值.</returns>
		public T GetOptionValueToEnum<T> ( OptionType type, T defalutValue )
			where T : struct
		{ return toEnum<T> ( this.GetOptionValue ( type ), defalutValue ); }

		/// <summary>
		/// 将 Option 的值转化为整型值.
		/// </summary>
		/// <param name="type">选项的类型.</param>
		/// <param name="defalutValue">默认值.</param>
		/// <returns>选项对应的整型值.</returns>
		public int GetOptionValueToInteger ( OptionType type, int defalutValue )
		{ return toInteger ( this.GetOptionValue ( type ), defalutValue ); }

		/// <summary>
		/// 将 Option 的值转化为字符串.
		/// </summary>
		/// <param name="type">选项的类型.</param>
		/// <param name="defalutValue">默认值.</param>
		/// <returns>选项对应的字符串.</returns>
		public string GetOptionValueToString ( OptionType type, string defalutValue )
		{ return toString ( this.GetOptionValue ( type ), defalutValue ); }
		#endregion

		/// <summary>
		/// 得到 Event 的值.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <returns>事件值.</returns>
		public string GetEventValue ( EventType type )
		{

			if ( !this.events.ContainsKey ( type ) )
				return string.Empty;
			else
				return this.events[type].Value;

		}

		#region " set option "
		/// <summary>
		/// 设置 Option 的值.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">选项值.</param>
		/// <param name="defaultValue">如果值等于默认值, 则设置为空字符串.</param>
		public void SetOptionValue ( OptionType type, string value, string defaultValue )
		{

			if ( value == defaultValue )
				value = string.Empty;

			if ( this.options.ContainsKey ( type ) )
				this.options[type].Value = value;
			else
				this.options.Add ( type, new Option ( type, value ) );

		}

		/// <summary>
		/// 设置 Option 的值为一个 javascript 布尔值.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">选项值.</param>
		/// <param name="defaultValue">如果值等于默认值, 则设置为空字符串.</param>
		public void SetOptionValueToBoolean ( OptionType type, bool value, bool defaultValue )
		{ this.SetOptionValue ( type, toString ( value ), toString ( defaultValue ) ); }

		/// <summary>
		/// 设置 Option 的值为一个 javascript 字符串.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">字符串.</param>
		/// <param name="defaultValue">如果值等于默认值, 则设置为空字符串.</param>
		public void SetOptionValueToString ( OptionType type, string value, string defaultValue )
		{ this.SetOptionValue ( type, toString ( value ), toString ( defaultValue ) ); }
		#endregion

		/// <summary>
		/// 设置 Event 的内容.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <param name="value">事件内容.</param>
		public void SetEventValue ( EventType type, string value )
		{

			if ( this.events.ContainsKey ( type ) )
				this.events[type].Value = value;
			else
				this.events.Add ( type, new Event ( type, value ) );

		}

		/// <summary>
		/// 转化不包括自定义的内容为等效的字符串.
		/// </summary>
		/// <returns>字符串.</returns>
		public override string ToString ( )
		{
			string optionExpression = string.Empty;

			foreach ( Option option in this.options.Values )
				if ( option.Value != string.Empty )
				{

					if ( optionExpression != string.Empty )
						optionExpression += "`,";

					optionExpression += string.Format ( "{0}`:{1}", option.Type, option.Value );
				}

			optionExpression = "`|" + optionExpression + "|``;";

			string eventExpression = string.Empty;

			foreach ( Event @event in this.events.Values )
				if ( @event.Value != string.Empty )
				{

					if ( eventExpression != string.Empty )
						eventExpression += "`,";

					eventExpression += string.Format ( "{0}`:{1}", @event.Type, @event.Value );
				}

			eventExpression = "`|" + eventExpression + "|`";

			return optionExpression + eventExpression;
		}

		/// <summary>
		/// 从 ExpressionHelper 转化为选项和事件, 不包含自定义内容.
		/// </summary>
		/// <param name="optionHelper">选项的 ExpressionHelper.</param>
		/// <param name="eventHelper">事件的 ExpressionHelper.</param>
		public void FromExpressionHelper ( ExpressionHelper optionHelper, ExpressionHelper eventHelper )
		{

			if ( null != optionHelper )
			{
				this.options.Clear ( );

				for ( int index = 0; index < optionHelper.ChildCount; index++ )
					try
					{ this.SetOptionValue ( ( OptionType ) Enum.Parse ( typeof ( OptionType ), optionHelper[index].Name ), optionHelper[index].Value, string.Empty ); }
					catch { }
			}

			if ( null != eventHelper )
			{
				this.events.Clear ( );

				for ( int index = 0; index < eventHelper.ChildCount; index++ )
					try
					{ this.SetEventValue ( ( EventType ) Enum.Parse ( typeof ( EventType ), eventHelper[index].Name ), eventHelper[index].Value ); }
					catch { }

			}

		}

	}

}

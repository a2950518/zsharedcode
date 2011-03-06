/*
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace zoyobar.shared.panzer.code
{

	/// <summary>
	/// 字符串转换器.
	/// </summary>
	public sealed class StringConvert
	{

		/// <summary>
		/// 将对象转化为字符串.
		/// </summary>
		/// <param name="value">需要转化的对象.</param>
		/// <returns>转化后的字符串.</returns>
		public static string ToString ( object value )
		{

			if ( null == value )
				return string.Empty;

			if ( value.GetType ( ) == typeof ( Color ) )
				return ( ( Color ) value ).ToArgb ( ).ToString ( );
			else
				return value.ToString ( );

		}

		/// <summary>
		/// 将字符串转化为指定类型的对象.
		/// </summary>
		/// <param name="value">需要转化的字符串.</param>
		/// <returns>转化后的对象.</returns>
		public static T ToObject<T> ( string value )
		{

			if ( null == value )
				return default ( T );

			Type type = typeof ( T );

			try
			{

				if ( type == typeof ( Guid ) )
					return ( T ) ( object ) new Guid ( value );
				else if ( type == typeof ( Color ) )
					return ( T ) ( object ) Color.FromArgb ( Convert.ToInt32 ( value ) );
				else
					return ( T ) ( object ) value;

			}
			catch
			{ return default ( T ); }

		}

	}

}

/*
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/xml/XmlSeriationManager.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zoyobar.shared.panzer.xml
{

	/// <summary>
	/// Xml 序列化管理类, 用于管理多个 Xml 序列化类.
	/// </summary>
	public sealed partial class XmlSeriationManager
	{
		private static readonly SortedList<string, XmlSeriation> seriations = new SortedList<string, XmlSeriation> ( );

		/// <summary>
		/// 获取 Xml 序列化类.
		/// </summary>
		public static SortedList<string, XmlSeriation> Seriations
		{
			get { return seriations; }
		}

		/// <summary>
		/// 获取指定 id 的 Xml 序列化类是否存在.
		/// </summary>
		/// <param name="id">Xml 序列化类的 ID.</param>
		public static bool IsExist ( string id )
		{ return !string.IsNullOrEmpty ( id ) && seriations.ContainsKey ( id ); }

#if PARAM
		/// <summary>
		/// 载入 Xml 文件, 生成一个 Xml 序列化类.
		/// </summary>
		/// <param name="filePath">Xml 文件路径.</param>
		/// <param name="isReload">如果 Xml 序列化类已经存在, 是否重新载入, 默认为 true.</param>
		/// <returns>Xml 序列化类</returns>
		public static XmlSeriation Open ( string filePath, bool isReload = true )
#else
		/// <summary>
		/// 载入 Xml 文件, 生成一个 Xml 序列化类.
		/// </summary>
		/// <param name="filePath">Xml 文件路径.</param>
		/// <param name="isReload">如果 Xml 序列化类已经存在, 是否重新载入.</param>
		/// <returns>Xml 序列化类</returns>
		public static XmlSeriation Open ( string filePath, bool isReload )
#endif
		{

			if ( string.IsNullOrEmpty( filePath ))
				return null;


			XmlSeriation seriation = new XmlSeriation ( filePath );

			string id = null;

			if ( seriation.IsIDNull )
				id = filePath;
			else
				id = seriation.ID;

			if ( IsExist ( id ) )
			{

				if ( !isReload )
					return seriations [ id ];

				seriations.Remove ( id );
			}

			seriations.Add ( id, seriation );

			return seriation;
		}

	}

	partial class XmlSeriationManager
	{
#if !PARAM
		/// <summary>
		/// 载入 Xml 文件, 生成一个 Xml 序列化类.
		/// </summary>
		/// <param name="filePath">Xml 文件路径.</param>
		/// <param name="isReload">如果 Xml 序列化类已经存在, 是否重新载入.</param>
		/// <returns>Xml 序列化类</returns>
		public static XmlSeriation Open ( string filePath )
		{ return Open ( filePath, true ); }
#endif
	}

}

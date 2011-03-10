/*
 * 参考文档: http://blog.sina.com.cn/s/blog_604c436d0100o07v.html (目前已经停止更新同步)
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://blog.sina.com.cn/s/blog_604c436d0100o04s.html
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/data/DataSetHelper.cs
 * 测试文件: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/TestDataSetHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
* */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System.Data;
using System.IO;

namespace zoyobar.shared.panzer.data
{

	/// <summary>
	/// 这个类将完成辅助的 DataSet 操作.
	/// </summary>
	public sealed partial class DataSetHelper
	{

#if PARAM
		/// <summary>
		/// 将指定的 XML 数据载入到拥有架构的 DataTable 中.
		/// </summary>
		/// <param name="table">要载入数据的 DataTable.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		/// <param name="isClear">当指定 XML 文件存在时, 是否清空原有数据, 默认为 true.</param>
		public static void Load ( DataTable table, string xmlFilePath, bool isClear = true )
#else
		/// <summary>
		/// 将指定的 XML 数据载入到拥有架构的 DataTable 中.
		/// </summary>
		/// <param name="table">要载入数据的 DataTable.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		/// <param name="isClear">当指定 XML 文件存在时, 是否清空原有数据.</param>
		public static void Load ( DataTable table, string xmlFilePath, bool isClear )
#endif
		{

			try
			{

				if ( null == table || string.IsNullOrEmpty ( xmlFilePath ) || !File.Exists ( xmlFilePath ) )
					return;

				if ( isClear )
					table.Clear ();

				table.ReadXml ( xmlFilePath );
			}
			catch { }

		}

#if PARAM
		/// <summary>
		/// 将指定的 XML 数据载入到 DataSet 中.
		/// </summary>
		/// <param name="dataSet">要载入数据的 DataSet.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		/// <param name="isClear">当指定 XML 文件存在时, 是否清空原有数据, 默认为 true.</param>
		/// <param name="mode">读取模式, 默认为 Auto.</param>
		public static void Load ( DataSet dataSet, string xmlFilePath, bool isClear = true, XmlReadMode mode = XmlReadMode.Auto )
#else
		/// <summary>
		/// 将指定的 XML 数据载入到 DataSet 中.
		/// </summary>
		/// <param name="dataSet">要载入数据的 DataSet.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		/// <param name="isClear">当指定 XML 文件存在时, 是否清空原有数据.</param>
		/// <param name="mode">读取模式.</param>
		public static void Load ( DataSet dataSet, string xmlFilePath, bool isClear, XmlReadMode mode )
#endif
		{

			try
			{

				if ( null == dataSet || string.IsNullOrEmpty ( xmlFilePath ) || !File.Exists ( xmlFilePath ) )
					return;

				if ( isClear )
					dataSet.Clear ();

				dataSet.ReadXml ( xmlFilePath, mode );
			}
			catch { }

		}

		/// <summary>
		/// 将指定的 DataTable 中数据保存到 XML 文件中.
		/// </summary>
		/// <param name="table">要保存数据的 DataTable.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		public static void Save ( DataTable table, string xmlFilePath )
		{

			if ( null == table || string.IsNullOrEmpty ( xmlFilePath ) )
				return;

			try
			{ table.WriteXml ( xmlFilePath ); }
			catch { }

		}

		/// <summary>
		/// 将指定的 DataSet 中数据保存到 XML 文件中.
		/// </summary>
		/// <param name="dataSet">要保存数据的 DataSet.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		public static void Save ( DataSet dataSet, string xmlFilePath )
		{

			if ( null == dataSet || string.IsNullOrEmpty ( xmlFilePath ) )
				return;

			try
			{ dataSet.WriteXml ( xmlFilePath ); }
			catch { }

		}

	}

	partial class DataSetHelper
	{

#if !PARAM
		/// <summary>
		/// 将指定的 XML 数据载入到 DataSet 中, 如果指定 XML 文件存在则清空原有数据.
		/// </summary>
		/// <param name="dataSet">要载入数据的 DataSet.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		public static void Load ( DataSet dataSet, string xmlFilePath )
		{ Load ( dataSet, xmlFilePath, true, XmlReadMode.Auto ); }
		/// <summary>
		/// 将指定的 XML 数据载入到 DataSet 中, 如果指定 XML 文件存在则清空原有数据.
		/// </summary>
		/// <param name="dataSet">要载入数据的 DataSet.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		/// <param name="mode">读取模式.</param>
		public static void Load ( DataSet dataSet, string xmlFilePath, XmlReadMode mode )
		{ Load ( dataSet, xmlFilePath, true, mode ); }
		/// <summary>
		/// 将指定的 XML 数据载入到 DataSet 中.
		/// </summary>
		/// <param name="dataSet">要载入数据的 DataSet.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		/// <param name="isClear">当指定 XML 文件存在时, 是否清空原有数据.</param>
		public static void Load ( DataSet dataSet, string xmlFilePath, bool isClear )
		{ Load ( dataSet, xmlFilePath, isClear, XmlReadMode.Auto ); }

		/// <summary>
		/// 将指定的 XML 数据载入到拥有架构的 DataTable 中, 如果指定 XML 文件存在则清空原有数据.
		/// </summary>
		/// <param name="table">要载入数据的 DataTable.</param>
		/// <param name="xmlFilePath">XML 文件路径.</param>
		public static void Load ( DataTable table, string xmlFilePath )
		{ Load ( table, xmlFilePath, true ); }
#endif

	}

}
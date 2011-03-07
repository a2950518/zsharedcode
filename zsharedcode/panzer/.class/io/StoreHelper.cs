/*
 * 参考文档: http://blog.sina.com.cn/s/blog_604c436d0100o054.html (目前已经停止更新同步)
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://blog.sina.com.cn/s/blog_604c436d0100o04s.html
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/io/StoreHelper.cs
 * */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace zoyobar.shared.panzer.io
{

	/// <summary>
	/// 存储辅助类, 帮助 File, Directory 类完成存储工作.
	/// </summary>
	public sealed class StoreHelper
	{

		/// <summary>
		/// 读取文件中的内容.
		/// </summary>
		/// <param name="filePath">文件路径.</param>
		/// <returns>读取的文件中的内容.</returns>
		public static string Read(string filePath)
		{ return Read(filePath, Encoding.Default); }
		/// <summary>
		/// 以指定的编码格式读取文件中的内容.
		/// </summary>
		/// <param name="filePath">文件路径.</param>
		/// <param name="encoding">文件编码.</param>
		/// <returns>读取的文件中的内容.</returns>
		public static string Read(string filePath, Encoding encoding)
		{

			if (string.IsNullOrEmpty(filePath))
				return null;

			try
			{
				filePath = Path.GetFullPath(filePath);

				if (!File.Exists(filePath))
					return null;

				return File.ReadAllText(filePath, encoding);
			}
			catch
			{ return null; }

		}

		/// <summary>
		/// 将内容写入到文件, 如果目录不存在将创建目录.
		/// </summary>
		/// <param name="filePath">文件路径.</param>
		/// <param name="content">要写入文件的文本.</param>
		public static void Write(string filePath, string content)
		{ Write(filePath, content, Encoding.Default); }
		/// <summary>
		/// 将内容以指定的编码格式写入到文件, 如果目录不存在将创建目录.
		/// </summary>
		/// <param name="filePath">文件路径.</param>
		/// <param name="content">要写入文件的文本.</param>
		/// <param name="encoding">文件编码.</param>
		public static void Write(string filePath, string content, Encoding encoding)
		{

			if (string.IsNullOrEmpty(filePath) || null == content)
				return;

			try
			{
				filePath = Path.GetFullPath(filePath);

				Directory.CreateDirectory(Path.GetDirectoryName(filePath));

				File.WriteAllText(filePath, content, encoding);
			}
			catch { }

		}

	}

}

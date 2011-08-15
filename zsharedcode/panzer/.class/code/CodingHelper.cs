/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/CodingHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Text;
using System.Text.RegularExpressions;

using zoyobar.shared.panzer.io;

namespace zoyobar.shared.panzer.code
{

	/// <summary>
	/// 可以完成代码辅助编写等工作.
	/// </summary>
	public sealed class CodingHelper
	{

		/// <summary>
		/// 提供模板, 数据文件, 提取数据的正则表达式生成脚本.
		/// </summary>
		/// <param name="template">模板文本.</param>
		/// <param name="dataRegex">提取数据的正则表达式.</param>
		/// <param name="dataFilePath">数据文件路径.</param>
		/// <returns>脚本.</returns>
		public static string Build ( string template, Regex dataRegex, string dataFilePath )
		{ return Build ( template, dataRegex, dataFilePath, Encoding.Default ); }
		/// <summary>
		/// 提供模板, 数据文件, 编码格式, 提取数据的正则表达式生成脚本.
		/// </summary>
		/// <param name="template">模板文本.</param>
		/// <param name="dataRegex">提取数据的正则表达式.</param>
		/// <param name="dataFilePath">数据文件路径.</param>
		/// <param name="dataFileEncoding">数据文件编码.</param>
		/// <returns>脚本.</returns>
		public static string Build ( string template, Regex dataRegex, string dataFilePath, Encoding dataFileEncoding )
		{ return Build ( template, StoreHelper.Read ( dataFilePath, dataFileEncoding ), dataRegex ); }
		/// <summary>
		/// 提供模板, 数据, 提取数据的正则表达式生成脚本.
		/// </summary>
		/// <param name="template">模板文本.</param>
		/// <param name="data">数据文本.</param>
		/// <param name="dataRegex">提取数据的正则表达式.</param>
		/// <returns>脚本.</returns>
		public static string Build ( string template, string data, Regex dataRegex )
		{

			if ( string.IsNullOrEmpty ( template ) || string.IsNullOrEmpty ( data ) || null == dataRegex )
				return string.Empty;

			string code = string.Empty;

			try
			{

				foreach ( Match dataMatch in dataRegex.Matches ( data ) )
					code += dataMatch.Result ( template );

			}
			catch { }

			return code;
		}


		/// <summary>
		/// 提供模板, 数据文件, 提取数据的正则表达式生成脚本并输出到文件.
		/// </summary>
		/// <param name="template">模板文本.</param>
		/// <param name="dataRegex">提取数据的正则表达式.</param>
		/// <param name="dataFilePath">数据文件路径.</param>
		/// <param name="outputFilePath">输出文件路径.</param>
		public static void BuildToFile ( string template, Regex dataRegex, string dataFilePath, string outputFilePath )
		{ BuildToFile ( template, dataRegex, dataFilePath, Encoding.Default, outputFilePath, Encoding.Default ); }
		/// <summary>
		/// 提供模板, 数据文件, 编码格式, 提取数据的正则表达式生成脚本并输出到文件.
		/// </summary>
		/// <param name="template">模板文本.</param>
		/// <param name="dataRegex">提取数据的正则表达式.</param>
		/// <param name="dataFilePath">数据文件路径.</param>
		/// <param name="outputFilePath">输出文件路径.</param>
		/// <param name="outputFileEncoding">输出文件编码.</param>
		public static void BuildToFile ( string template, Regex dataRegex, string dataFilePath, string outputFilePath, Encoding outputFileEncoding )
		{ BuildToFile ( template, dataRegex, dataFilePath, Encoding.Default, outputFilePath, outputFileEncoding ); }
		/// <summary>
		/// 提供模板, 数据文件, 编码格式, 提取数据的正则表达式生成脚本并输出到文件.
		/// </summary>
		/// <param name="template">模板文本.</param>
		/// <param name="dataRegex">提取数据的正则表达式.</param>
		/// <param name="dataFilePath">数据文件路径.</param>
		/// <param name="dataFileEncoding">数据文件编码.</param>
		/// <param name="outputFilePath">输出文件路径.</param>
		public static void BuildToFile ( string template, Regex dataRegex, string dataFilePath, Encoding dataFileEncoding, string outputFilePath )
		{ BuildToFile ( template, dataRegex, dataFilePath, dataFileEncoding, outputFilePath, Encoding.Default ); }
		/// <summary>
		/// 提供模板, 数据文件, 编码格式, 提取数据的正则表达式生成脚本并输出到文件.
		/// </summary>
		/// <param name="template">模板文本.</param>
		/// <param name="dataRegex">提取数据的正则表达式.</param>
		/// <param name="dataFilePath">数据文件路径.</param>
		/// <param name="dataFileEncoding">数据文件编码.</param>
		/// <param name="outputFilePath">输出文件路径.</param>
		/// <param name="outputFileEncoding">输出文件编码.</param>
		public static void BuildToFile ( string template, Regex dataRegex, string dataFilePath, Encoding dataFileEncoding, string outputFilePath, Encoding outputFileEncoding )
		{ BuildToFile ( template, StoreHelper.Read ( dataFilePath, dataFileEncoding ), dataRegex, outputFilePath, outputFileEncoding ); }
		/// <summary>
		/// 提供模板, 数据, 提取数据的正则表达式生成脚本并输出到文件.
		/// </summary>
		/// <param name="template">模板文本.</param>
		/// <param name="data">数据文本.</param>
		/// <param name="dataRegex">提取数据的正则表达式.</param>
		/// <param name="outputFilePath">输出文件路径.</param>
		public static void BuildToFile ( string template, string data, Regex dataRegex, string outputFilePath )
		{ BuildToFile ( template, data, dataRegex, outputFilePath, Encoding.Default ); }
		/// <summary>
		/// 提供模板, 数据, 编码格式, 提取数据的正则表达式生成脚本并输出到文件.
		/// </summary>
		/// <param name="template">模板文本.</param>
		/// <param name="data">数据文本.</param>
		/// <param name="dataRegex">提取数据的正则表达式.</param>
		/// <param name="outputFilePath">输出文件路径.</param>
		/// <param name="outputFileEncoding">输出文件编码.</param>
		public static void BuildToFile ( string template, string data, Regex dataRegex, string outputFilePath, Encoding outputFileEncoding )
		{ StoreHelper.Write ( outputFilePath, Build ( template, data, dataRegex ), outputFileEncoding ); }

	}

}

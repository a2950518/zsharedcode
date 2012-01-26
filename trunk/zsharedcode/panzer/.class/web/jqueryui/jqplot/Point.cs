/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Point.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " Point "
	/// <summary>
	/// 点.
	/// </summary>
	public sealed class Point
	{
		private string param1;
		private string param2;
		private string param3;
		private string param4;

		/// <summary>
		/// 获取或设置第一个参数, 一般为 x 轴的值.
		/// </summary>
		[Category ( "数据" )]
		[Description ( "第一个参数, 一般为 x 轴的值" )]
		public string Param1
		{
			get { return this.param1; }
			set { this.param1 = value; }
		}

		/// <summary>
		/// 获取或设置第二个参数, 一般为 y 轴.
		/// </summary>
		[Category ( "数据" )]
		[Description ( "第二个参数, 一般为 y 轴的值" )]
		public string Param2
		{
			get { return this.param2; }
			set { this.param2 = value; }
		}

		/// <summary>
		/// 获取或设置第三个参数.
		/// </summary>
		[Category ( "数据" )]
		[Description ( "第三个参数" )]
		public string Param3
		{
			get { return this.param3; }
			set { this.param3 = value; }
		}

		/// <summary>
		/// 获取或设置第四个参数.
		/// </summary>
		[Category ( "数据" )]
		[Description ( "第四个参数" )]
		public string Param4
		{
			get { return this.param4; }
			set { this.param4 = value; }
		}

		//! 这里没有使用 partial

		/// <summary>
		/// 创建一个点.
		/// </summary>
		/// <param name="param1">第一个参数.</param>
		/// <param name="param2">第二个参数.</param>
		public Point ( decimal param1, DateTime param2 )
			: this ( param1.ToString ( ), param2.ToString ( "yyyy-MM-dd HH:mm:ss" ) )
		{ }
		/// <summary>
		/// 创建一个点.
		/// </summary>
		/// <param name="param1">第一个参数.</param>
		/// <param name="param2">第二个参数.</param>
		public Point ( DateTime param1, decimal param2 )
			: this ( param2.ToString ( "yyyy-MM-dd HH:mm:ss" ), param1.ToString ( ) )
		{ }

		/// <summary>
		/// 创建一个点.
		/// </summary>
		/// <param name="param1">第一个参数.</param>
		public Point ( decimal param1 )
			: this ( param1.ToString ( ), null, null, null )
		{ }
		/// <summary>
		/// 创建一个点.
		/// </summary>
		/// <param name="param1">第一个参数.</param>
		/// <param name="param2">第二个参数.</param>
		public Point ( decimal param1, decimal param2 )
			: this ( param1.ToString ( ), param2.ToString ( ), null, null )
		{ }

		/// <summary>
		/// 创建一个点.
		/// </summary>
		public Point ( )
			: this ( null, null, null, null )
		{ }
		/// <summary>
		/// 创建一个点.
		/// </summary>
		/// <param name="param1">第一个参数.</param>
		public Point ( string param1 )
			: this ( param1, null, null, null )
		{ }
		/// <summary>
		/// 创建一个点.
		/// </summary>
		/// <param name="param1">第一个参数.</param>
		/// <param name="param2">第二个参数.</param>
		public Point ( string param1, string param2 )
			: this ( param1, param2, null, null )
		{ }
		/// <summary>
		/// 创建一个点.
		/// </summary>
		/// <param name="param1">第一个参数.</param>
		/// <param name="param2">第二个参数.</param>
		/// <param name="param3">第三个参数.</param>
		public Point ( string param1, string param2, string param3 )
			: this ( param1, param2, param3, null )
		{ }
		/// <summary>
		/// 创建一个点.
		/// </summary>
		/// <param name="param1">第一个参数.</param>
		/// <param name="param2">第二个参数.</param>
		/// <param name="param3">第三个参数.</param>
		/// <param name="param4">第四个参数.</param>
		public Point ( string param1, string param2, string param3, string param4 )
		{
			this.param1 = param1;
			this.param2 = param2;
			this.param3 = param3;
			this.param4 = param4;
		}

	}
	#endregion

}

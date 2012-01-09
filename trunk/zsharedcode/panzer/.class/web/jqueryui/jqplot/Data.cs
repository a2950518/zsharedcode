/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/Data.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " Data "
	/// <summary>
	/// 数据.
	/// </summary>
	[ParseChildren ( true, "PointList" )]
	[DefaultProperty ( "PointList" )]
	public sealed class Data
	{
		private readonly List<Point> points = new List<Point> ( );

		/// <summary>
		/// 获取或设置数据.
		/// </summary>
		[Browsable ( false )]
		[Category ( "数据" )]
		[Description ( "数据" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerDefaultProperty )]
		[NotifyParentProperty ( true )]
		public List<Point> PointList
		{
			get { return this.points; }
		}

		//! 这里没有使用 partial
		/// <summary>
		/// 创建一个数据.
		/// </summary>
		public Data ( )
			: this ( null )
		{ }
		/// <summary>
		/// 创建一个带有点的数据.
		/// </summary>
		/// <param name="points">点的数组.</param>
		public Data ( params Point[] points )
		{

			if ( null != points )
				foreach ( Point point in points )
					if ( null != point )
						this.PointList.Add ( point );

		}

	}
	#endregion

}

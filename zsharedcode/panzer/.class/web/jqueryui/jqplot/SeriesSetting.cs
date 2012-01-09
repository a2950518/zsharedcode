/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/SeriesSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " SeriesSetting "
	/// <summary>
	/// 序列的设置.
	/// </summary>
	[ParseChildren ( true, "SeriesList" )]
	[DefaultProperty ( "SeriesList" )]
	public sealed class SeriesSetting
	{
		private readonly List<Series> series = new List<Series> ( );

		/// <summary>
		/// 获取或设置序列列表.
		/// </summary>
		[Browsable ( false )]
		[Category ( "序列" )]
		[Description ( "一系列的数据" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerDefaultProperty )]
		[NotifyParentProperty ( true )]
		public List<Series> SeriesList
		{
			get { return this.series; }
		}

		/// <summary>
		/// 创建一个序列的设置.
		/// </summary>
		public SeriesSetting ( )
		{ }


	}
	#endregion

}

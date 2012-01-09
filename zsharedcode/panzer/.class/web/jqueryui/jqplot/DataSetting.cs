/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/DataSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " DataSetting "
	/// <summary>
	/// 数据的设置.
	/// </summary>
	[ParseChildren ( true, "DataList" )]
	[DefaultProperty ( "DataList" )]
	public sealed class DataSetting
	{
		private readonly List<Data> datas = new List<Data> ( );

		/// <summary>
		/// 获取或设置数据列表.
		/// </summary>
		[Browsable ( false )]
		[Category ( "数据" )]
		[Description ( "数据列表" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerDefaultProperty )]
		[NotifyParentProperty ( true )]
		public List<Data> DataList
		{
			get { return this.datas; }
		}

		/// <summary>
		/// 创建一个数据的设置.
		/// </summary>
		public DataSetting ( )
		{ }


	}
	#endregion

}

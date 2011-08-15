/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.interface/ui/dweb/IDataWeb.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;

using zoyobar.shared.panzer.ui.dwindow;

namespace zoyobar.shared.panzer.ui.dweb
{

	/// <summary>
	/// 实现 DataWebCore 类工作平台的功能.
	/// </summary>
	/// <typeparam name="P">PagerSetting 的类型</typeparam>
	public interface IDataWeb<P>
		: IDataWindow<P>
		where P : PagerSetting
	{

		/// <summary>
		/// 将 DataTable 绑定到 Web 界面.
		/// </summary>
		/// <param name="tableSetting">DataTable 的相关设置.</param>
		/// <param name="actionType">数据行为类型.</param>
		void DataBind ( TableSetting<P> tableSetting, DataActionType actionType );

		/// <summary>
		/// 将查询条件绑定到 Web 界面.
		/// </summary>
		/// <param name="querySettings">查询条件设置列表.</param>
		void SetQuerys ( SortedList<string, QuerySetting> querySettings );

	}
	
}

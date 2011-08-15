/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.interface/ui/dwindow/IDataWindow.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;

namespace zoyobar.shared.panzer.ui.dwindow
{

	/// <summary>
	/// 实现 DataWindowCore 类工作平台的功能.
	/// </summary>
	/// <typeparam name="P">PagerSetting 的类型.</typeparam>
	public interface IDataWindow<P>
		: IWindow
		where P : PagerSetting
	{

		/// <summary>
		/// 设置 DataTable 到界面, 可以在此方法中编写数据绑定等代码.
		/// </summary>
		/// <param name="tableSettings">DataTable 的相关设置.</param>
		void SetTables ( SortedList<string, TableSetting<P>> tableSettings );

		/// <summary>
		/// 得到对应 DataTable 的过滤条件.
		/// </summary>
		/// <param name="tableSetting">DataTable 的相关设置.</param>
		/// <returns>过滤条件, 比如: "name = 'jack'".</returns>
		string GetViewFilter ( TableSetting<P> tableSetting );

		/// <summary>
		/// 得到对应 DataTable 的排序条件.
		/// </summary>
		/// <param name="tableSetting">DataTable 的相关设置.</param>
		/// <returns>排序条件, 比如: "age desc".</returns>
		string GetViewSort ( TableSetting<P> tableSetting );

		/// <summary>
		/// 得到对应 DataTable 的分页索引.
		/// </summary>
		/// <param name="tableSetting">DataTable 的相关设置.</param>
		int GetPagerIndex ( TableSetting<P> tableSetting );

		/// <summary>
		/// 设置对应 DataTable 数据行为是否可被激活, 比如: 如果不可以删除数据, 则设置删除按钮不可用.
		/// </summary>
		/// <param name="tableSetting">DataTable 的相关设置.</param>
		/// <param name="actionType">数据行为类型.</param>
		/// <param name="isEnabled">数据相关行为是否可以被激活.</param>
		void SetIsDataActionEnabled ( TableSetting<P> tableSetting, DataActionType actionType, bool isEnabled );

		/// <summary>
		/// 设置页码相关控件是否可用.
		/// </summary>
		/// <param name="tableSetting">DataTable 的相关设置.</param>
		/// <param name="actionType">分页行为类型.</param>
		/// <param name="isEnabled">控件是否可用.</param>
		void SetIsPagerControlEnabled ( TableSetting<P> tableSetting, PagerActionType actionType, bool isEnabled );

		/// <summary>
		/// 设置分页信息到界面.
		/// </summary>
		/// <param name="tableSetting">DataTable 的相关设置, 包含了分页设置.</param>
		void SetPager ( TableSetting<P> tableSetting );
	}

}

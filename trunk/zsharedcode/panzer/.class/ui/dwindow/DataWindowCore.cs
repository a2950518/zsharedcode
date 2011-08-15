/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/dwindow/DataWindowCore.cs
 * 版本: 2.1, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

// HACK: 如果代码不能编译, 请尝试在项目中定义编译符号 V4, V3_5, V3, V2 以表示不同的 .NET 版本

// HACK: DataWindowCore 需要 V4 或者 V3_5

using System;
using System.Collections.Generic;
using System.Data;

namespace zoyobar.shared.panzer.ui.dwindow
{

	#region " DataActionType "
	/// <summary>
	/// 数据行为类型.
	/// </summary>
	public enum DataActionType
	{
		/// <summary>
		/// 填充数据.
		/// </summary>
		Fill = 1,
		/// <summary>
		/// 修改数据.
		/// </summary>
		Modify = 2,
		/// <summary>
		/// 删除数据.
		/// </summary>
		Delete = 3,
		/// <summary>
		/// 添加数据.
		/// </summary>
		Add = 4,
		/// <summary>
		/// 更新数据, 包括添加删除和修改.
		/// </summary>
		Update = 5
	}
	#endregion

	#region " PagerActionType "
	/// <summary>
	/// 分页行为类型.
	/// </summary>
	public enum PagerActionType
	{
		/// <summary>
		/// 不进行任何操作.
		/// </summary>
		None = 0,
		/// <summary>
		/// 转到首页.
		/// </summary>
		First = 1,
		/// <summary>
		/// 转到下一页.
		/// </summary>
		Next = 2,
		/// <summary>
		/// 转到上一页.
		/// </summary>
		Prev = 3,
		/// <summary>
		/// 转到末页.
		/// </summary>
		Last = 4,
		/// <summary>
		/// 转到指定页.
		/// </summary>
		GoTo = 5
	}
	#endregion

	#region " TableSetting "
	/// <summary>
	/// DataTable 的相关设置.
	/// </summary>
	/// <typeparam name="P">PagerSetting 的类型.</typeparam>
	public class TableSetting<P>
		where P : PagerSetting
	{

		/// <summary>
		/// 将设置数组转化为 DataTable 数组.
		/// </summary>
		/// <param name="tableSettings">DataTable 设置数组.</param>
		/// <returns>DataTable 数组.</returns>
		public static DataTable[] ToTables ( TableSetting<P>[] tableSettings )
		{

			if ( null == tableSettings )
				return new DataTable[] { };

			List<DataTable> tables = new List<DataTable> ( );

			foreach ( TableSetting<P> tableSetting in tableSettings )
				tables.Add ( tableSetting.Table );

			return tables.ToArray ( );
		}

		/// <summary>
		/// 名称对应的 DataTable 设置的索引.
		/// </summary>
		/// <param name="tableSettings">DataTable 设置数组.</param>
		/// <param name="name">设置的名称.</param>
		/// <returns>对应的 DataTable 设置的索引.</returns>
		public static int IndexOf ( TableSetting<P>[] tableSettings, string name )
		{

			if ( null == tableSettings || tableSettings.Length == 0 || string.IsNullOrEmpty ( name ) )
				return -1;

			for ( int index = 0; index < tableSettings.Length; index++ )
				if ( null != tableSettings[index] && tableSettings[index].Name == name )
					return index;

			return -1;
		}

		/// <summary>
		/// 名称对应的 DataTable 设置是否存在.
		/// </summary>
		/// <param name="tableSettings">DataTable 设置数组.</param>
		/// <param name="name">设置的名称.</param>
		/// <returns>DataTable 设置是否存在.</returns>
		public static bool IsExist ( TableSetting<P>[] tableSettings, string name )
		{ return ( IndexOf ( tableSettings, name ) != -1 ); }

		/// <summary>
		/// 得到名称对应的 DataTable 设置.
		/// </summary>
		/// <param name="tableSettings">DataTable 设置数组.</param>
		/// <param name="name">设置的名称.</param>
		/// <returns>对应的 DataTable 设置.</returns>
		public static TableSetting<P> GetTableSetting ( TableSetting<P>[] tableSettings, string name )
		{
			int index = IndexOf ( tableSettings, name );

			if ( index == -1 )
				return null;

			return tableSettings[index];
		}

		/// <summary>
		/// 得到名称对应的 DataTable.
		/// </summary>
		/// <param name="tableSettings">DataTable 设置数组.</param>
		/// <param name="name">设置的名称.</param>
		/// <returns>对应的 DataTable.</returns>
		public static DataTable GetTable ( TableSetting<P>[] tableSettings, string name )
		{
			TableSetting<P> tableSetting = GetTableSetting ( tableSettings, name );

			if ( null == tableSetting )
				return null;

			return tableSetting.Table;
		}

		/// <summary>
		/// 将多个包含 DataRow 的列表合并, 以数组返回.
		/// </summary>
		/// <param name="rowLists">包含 DataRow 的列表.</param>
		/// <returns>DataRow 的数组.</returns>
		public static DataRow[] Combine ( params List<DataRow>[] rowLists )
		{

			if ( null == rowLists )
				return new DataRow[] { };

			List<DataRow> rows = new List<DataRow> ( );

			foreach ( List<DataRow> rowList in rowLists )
				if ( null != rowList )
					rows.AddRange ( rowList );

			return rows.ToArray ( );
		}

		/// <summary>
		/// 设置的名称, 不一定与 DataTable 表名一致.
		/// </summary>
		public readonly string Name;
		/// <summary>
		/// DataTable, 数据表.
		/// </summary>
		public readonly DataTable Table;
		/// <summary>
		/// 表中表示该行是否被选中的列名.
		/// </summary>
		public readonly string IsCheckedColumnName;
		/// <summary>
		/// 表中表示该行状态的列名.
		/// </summary>
		public readonly string StateColumnName;
		/// <summary>
		/// 表中被过滤的行.
		/// </summary>
		public readonly List<DataRow> FilterRows = new List<DataRow> ( );
		/// <summary>
		/// 表中被过滤的处于添加状态的行.
		/// </summary>
		public readonly List<DataRow> FilterAddedRows = new List<DataRow> ( );
		/// <summary>
		/// 表中处于添加状态的行.
		/// </summary>
		public readonly List<DataRow> AddedRows = new List<DataRow> ( );
		/// <summary>
		/// 表中被过滤的处于删除状态的行.
		/// </summary>
		public readonly List<DataRow> FilterDeletedRows = new List<DataRow> ( );
		/// <summary>
		/// 表中处于删除状态的行.
		/// </summary>
		public readonly List<DataRow> DeletedRows = new List<DataRow> ( );
		/// <summary>
		/// 表中被过滤的处于修改状态的行.
		/// </summary>
		public readonly List<DataRow> FilterModifiedRows = new List<DataRow> ( );
		/// <summary>
		/// 表中处于修改状态的行.
		/// </summary>
		public readonly List<DataRow> ModifiedRows = new List<DataRow> ( );
		/// <summary>
		/// 分页设置.
		/// </summary>
		public readonly P PagerSetting;

		/// <summary>
		/// 创建一个 DataTable 设置.
		/// </summary>
		/// <param name="name">设置的名称, 不一定与 DataTable 表名一致.</param>
		/// <param name="table">DataTable, 数据表.</param>
		/// <param name="isCheckedColumnName">表中表示该行是否被选中的列名, 默认为 "IsChecked".</param>
		/// <param name="stateColumnName">表中表示该行状态的列名, 默认为 "State".</param>
		/// <param name="pagerSetting">数据分页设置, 将决定分页的大小等.</param>
		public TableSetting ( string name, DataTable table, string isCheckedColumnName, string stateColumnName, P pagerSetting )
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", "名称不能为空" );

			if ( null == table )
				throw new ArgumentNullException ( "table", "表不能为空" );

			if ( string.IsNullOrEmpty ( isCheckedColumnName ) )
				isCheckedColumnName = "IsChecked";

			if ( string.IsNullOrEmpty ( stateColumnName ) )
				stateColumnName = "State";

			this.Name = name;
			this.Table = table;
			this.IsCheckedColumnName = isCheckedColumnName;
			this.StateColumnName = stateColumnName;
			this.PagerSetting = pagerSetting;
		}

	}
	#endregion

	#region " PagerSetting "
	/// <summary>
	/// 分页的相关设置.
	/// </summary>
	public class PagerSetting
	{
		protected int index;
		protected int itemCount;

		/// <summary>
		/// 每页包含的数据条数.
		/// </summary>
		public readonly int PaginalCount;

		/// <summary>
		/// 获取或设置当前页的索引, 如果小于等于 0, 则默认为 1.
		/// </summary>
		public int Index
		{
			get { return this.index; }
			set
			{

				if ( value <= 0 )
					value = 1;

				this.index = value;
			}
		}

		/// <summary>
		/// 获取总页数.
		/// </summary>
		public int Count
		{
			get
			{

				if ( this.IsEmpty )
					return 0;

				return ( int ) Math.Ceiling ( ( double ) this.itemCount / ( double ) this.PaginalCount );
			}
		}

		/// <summary>
		/// 获取或设置总条目数, 如果小于 0, 则默认为 0.
		/// </summary>
		public int ItemCount
		{
			get { return this.itemCount; }
			set
			{

				if ( value < 0 )
					value = 0;

				this.itemCount = value;

				if ( this.index > this.Count )
					this.Index = this.Count;

			}
		}

		/// <summary>
		/// 获取条目数是否为 0.
		/// </summary>
		public bool IsEmpty
		{
			get { return ( this.itemCount == 0 ); }
		}

		/// <summary>
		/// 获取当前页的开始行号.
		/// </summary>
		public int BeginRowNO
		{
			get { return ( this.index - 1 ) * this.PaginalCount + 1; }
		}

		/// <summary>
		/// 获取当前页的结束行号.
		/// </summary>
		public int EndRowNO
		{
			get { return this.index * this.PaginalCount; }
		}

		/// <summary>
		/// 获取当前是否为第一页.
		/// </summary>
		public bool IsFirst
		{
			get { return ( this.index == 1 ); }
		}

		/// <summary>
		/// 获取当前是否为最后一页.
		/// </summary>
		public bool IsLast
		{
			get { return ( this.index == this.Count ); }
		}

		/// <summary>
		/// 创建一个分页设置.
		/// </summary>
		/// <param name="index">当前页的索引, 如果小于等于 0, 则默认为 1.</param>
		/// <param name="paginalCount">每页包含的数据条数, 如果小于等于 0, 则默认为 20.</param>
		public PagerSetting ( int index, int paginalCount )
		{

			if ( paginalCount <= 0 )
				paginalCount = 20;

			this.PaginalCount = paginalCount;
			this.Index = index;
		}

	}
	#endregion

	/// <summary>
	/// 处理 DataTable 和界面的关系, 包括界面绑定, 数据更新等.
	/// </summary>
	/// <typeparam name="IW">界面实现的接口类型.</typeparam>
	/// <typeparam name="P">PagerSetting 的类型.</typeparam>
	public partial class DataWindowCore<IW, P>
		: WindowCore<IW>
		where P : PagerSetting
		where IW : IDataWindow<P>
	{
		protected virtual void fillData ( TableSetting<P>[] tableSettings ) { }
		protected virtual void modifyData ( TableSetting<P>[] tableSettings ) { }
		protected virtual void addData ( TableSetting<P>[] tableSettings ) { }
		protected virtual void deleteData ( TableSetting<P>[] tableSettings ) { }
		protected virtual void updateData ( TableSetting<P>[] tableSettings ) { }

		protected readonly SortedList<string, TableSetting<P>> tableSettings = new SortedList<string, TableSetting<P>> ( );

		/// <summary>
		/// 获取 TableSetting 数组.
		/// </summary>
		public SortedList<string, TableSetting<P>> TableSettings
		{
			get { return this.tableSettings; }
		}

		/// <summary>
		/// 创建一个 DataWindowCore.
		/// </summary>
		/// <param name="window">实现 IDataWindow 接口的类, 一般是窗体或控件.</param>
		/// <param name="tableSettings">DataTable 设置数组, 其中的 DataTable 将和 IDataWindow 表示的类协作.</param>
		public DataWindowCore ( IW window, TableSetting<P>[] tableSettings )
			: base ( window )
		{

			if ( null == tableSettings || tableSettings.Length == 0 )
				throw new ArgumentNullException ( "tableSettings", "表不能为空" );

			foreach ( TableSetting<P> tableSetting in tableSettings )
				if ( null != tableSetting && !this.tableSettings.ContainsKey ( tableSetting.Name ) )
					this.tableSettings.Add ( tableSetting.Name, tableSetting );

			window.SetTables ( this.tableSettings );
		}

		protected void checkDataActionEnabled ( TableSetting<P> tableSetting, DataActionType actionType )
		{
			bool isHasRow = this.getView ( tableSetting, null, false ).Count != 0;

			switch ( actionType )
			{
				case DataActionType.Add:
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Update, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Modify, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Delete, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Add, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Fill, true );
					break;

				case DataActionType.Delete:
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Update, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Modify, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Delete, isHasRow );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Add, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Fill, true );
					break;

				case DataActionType.Fill:
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Update, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Modify, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Delete, isHasRow );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Add, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Fill, true );
					break;

				case DataActionType.Modify:
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Update, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Modify, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Delete, isHasRow );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Add, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Fill, true );
					break;

				case DataActionType.Update:
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Update, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Modify, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Delete, isHasRow );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Add, true );
					this.window.SetIsDataActionEnabled ( tableSetting, DataActionType.Fill, true );
					break;
			}

		}

		protected DataView getView ( TableSetting<P> tableSetting, string viewFilter, bool isUseChecked )
		{

			if ( null == tableSetting )
				return new DataView ( );

			DataView view = new DataView ( tableSetting.Table );

			viewFilter = string.IsNullOrEmpty ( viewFilter ) ? this.window.GetViewFilter ( tableSetting ) : viewFilter;

			if ( isUseChecked )
				if ( tableSetting.Table.Columns.Contains ( tableSetting.IsCheckedColumnName ) && tableSetting.Table.Columns[tableSetting.IsCheckedColumnName].DataType == typeof ( bool ) )
					if ( string.IsNullOrEmpty ( viewFilter ) )
						viewFilter = string.Format ( "{0} = true", tableSetting.IsCheckedColumnName );
					else
						viewFilter = string.Format ( "({0}) and {1} = true", viewFilter, tableSetting.IsCheckedColumnName );

			view.RowFilter = viewFilter;
			view.Sort = this.window.GetViewSort ( tableSetting );

			return view;
		}

		protected virtual void setIsRowChecked ( TableSetting<P> tableSetting, bool? isChecked, string viewFilter )
		{

			if ( null == tableSetting || !tableSetting.Table.Columns.Contains ( tableSetting.IsCheckedColumnName ) || tableSetting.Table.Columns[tableSetting.IsCheckedColumnName].DataType != typeof ( bool ) )
				return;

			foreach ( DataRowView rowView in this.getView ( tableSetting, viewFilter, false ) )
				try
				{

					if ( isChecked.HasValue )
						rowView[tableSetting.IsCheckedColumnName] = isChecked;
					else if ( rowView.Row.IsNull ( tableSetting.IsCheckedColumnName ) )
						rowView[tableSetting.IsCheckedColumnName] = true;
					else
						rowView[tableSetting.IsCheckedColumnName] = !Convert.ToBoolean ( rowView[tableSetting.IsCheckedColumnName] );

				}
				catch
				{ }

		}

		protected virtual void dataCompleted ( TableSetting<P> tableSetting, DataActionType actionType )
		{
			this.setPager ( tableSetting, PagerActionType.None, 0 );

			this.checkDataActionEnabled ( tableSetting, actionType );
		}

		protected virtual void setPager ( TableSetting<P> tableSetting, PagerActionType actionType, int pagerIndex )
		{

			if ( null == tableSetting || null == tableSetting.PagerSetting )
				return;

			P pagerSetting = tableSetting.PagerSetting;

			switch ( actionType )
			{
				case PagerActionType.First:
					pagerSetting.Index = 1;
					break;

				case PagerActionType.Next:

					if ( !pagerSetting.IsLast )
						pagerSetting.Index += 1;

					break;

				case PagerActionType.Prev:

					if ( !pagerSetting.IsFirst )
						pagerSetting.Index -= 1;

					break;

				case PagerActionType.Last:

					if ( pagerSetting.Count > 0 )
						pagerSetting.Index = pagerSetting.Count;

					break;

				case PagerActionType.GoTo:

					if ( pagerIndex <= 0 || ( pagerSetting.Count > 0 && pagerIndex > pagerSetting.Count ) )
						return;

					pagerSetting.Index = pagerIndex;
					break;
			}

			this.window.SetIsPagerControlEnabled ( tableSetting, PagerActionType.First, !pagerSetting.IsEmpty && !pagerSetting.IsFirst );
			this.window.SetIsPagerControlEnabled ( tableSetting, PagerActionType.Last, !pagerSetting.IsEmpty && !pagerSetting.IsLast );
			this.window.SetIsPagerControlEnabled ( tableSetting, PagerActionType.Next, !pagerSetting.IsEmpty && !pagerSetting.IsLast );
			this.window.SetIsPagerControlEnabled ( tableSetting, PagerActionType.Prev, !pagerSetting.IsEmpty && !pagerSetting.IsFirst );
			this.window.SetIsPagerControlEnabled ( tableSetting, PagerActionType.GoTo, !pagerSetting.IsEmpty && !( pagerSetting.IsFirst && pagerSetting.IsLast ) );

			this.window.SetPager ( tableSetting );
		}

		/// <summary>
		/// 绑定可以触发 DataTable 数据事件到某个静态事件.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="type">目标类型.</param>
		/// <param name="eventName">静态事件名称, 比如: "Loaded".</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler.</param>
		/// <param name="actionType">行为的类型.</param>
		/// <param name="tableNames">表格的名称, 与 TableSetting 的 Name 一致.</param>
		public void BindDataEvent<A> ( Type type, string eventName, EventHandlerType eventType, DataActionType actionType, params string[] tableNames ) where A : EventArgs
		{ this.bindDataEvent<A> ( null, type, eventName, eventType, actionType, tableNames ); }
		/// <summary>
		/// 绑定可以触发 DataTable 数据事件, 比如: Button 的 Click 事件, 当按钮被点击时, 填充 DataTable.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="target">目标实例, 比如: 窗口上的 Button.</param>
		/// <param name="eventName">事件名称, 比如: "Click".</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler.</param>
		/// <param name="actionType">行为的类型.</param>
		/// <param name="tableNames">表格的名称, 与 TableSetting 的 Name 一致.</param>
		public void BindDataEvent<A> ( object target, string eventName, EventHandlerType eventType, DataActionType actionType, params string[] tableNames ) where A : EventArgs
		{ this.bindDataEvent<A> ( target, null, eventName, eventType, actionType, tableNames ); }
		protected void bindDataEvent<A> ( object target, Type type, string eventName, EventHandlerType eventType, DataActionType actionType, params string[] tableNames ) where A : EventArgs
		{

#if V3_5 || V4
			this.BindEvent<A> ( target, type, eventName, eventType,
				delegate ( object sender, A e )
				{

					if ( null == tableNames )
						return;

					List<TableSetting<P>> tableSettings = new List<TableSetting<P>> ( );

					foreach ( string tableName in tableNames )
						if ( !string.IsNullOrEmpty ( tableName ) && this.tableSettings.ContainsKey ( tableName ) )
						{
							TableSetting<P> tableSetting = this.tableSettings[tableName];
							tableSetting.FilterRows.Clear ( );
							tableSetting.FilterAddedRows.Clear ( );
							tableSetting.FilterDeletedRows.Clear ( );
							tableSetting.FilterModifiedRows.Clear ( );
							tableSetting.AddedRows.Clear ( );
							tableSetting.DeletedRows.Clear ( );
							tableSetting.ModifiedRows.Clear ( );

							foreach ( DataRowView rowView in this.getView ( tableSetting, null, true ) )
							{
								tableSetting.FilterRows.Add ( rowView.Row );

								switch ( rowView.Row.RowState )
								{
									case DataRowState.Added:
										tableSetting.FilterAddedRows.Add ( rowView.Row );
										break;

									case DataRowState.Deleted:
										tableSetting.FilterDeletedRows.Add ( rowView.Row );
										break;

									case DataRowState.Modified:
										tableSetting.FilterModifiedRows.Add ( rowView.Row );
										break;

								}

							}

							foreach ( DataRow row in tableSetting.Table.Rows )
								switch ( row.RowState )
								{
									case DataRowState.Added:
										tableSetting.AddedRows.Add ( row );
										break;

									case DataRowState.Deleted:
										tableSetting.DeletedRows.Add ( row );
										break;

									case DataRowState.Modified:
										tableSetting.ModifiedRows.Add ( row );
										break;

								}

							tableSettings.Add ( tableSetting );
						}

					switch ( actionType )
					{
						case DataActionType.Fill:
							this.fillData ( tableSettings.ToArray ( ) );
							break;

						case DataActionType.Add:
							this.addData ( tableSettings.ToArray ( ) );
							break;

						case DataActionType.Delete:
							this.deleteData ( tableSettings.ToArray ( ) );
							break;

						case DataActionType.Modify:
							this.modifyData ( tableSettings.ToArray ( ) );
							break;

						case DataActionType.Update:
							this.updateData ( tableSettings.ToArray ( ) );
							break;
					}

					foreach ( TableSetting<P> tableSetting in tableSettings )
						this.dataCompleted ( tableSetting, actionType );

				}
				);
#else
			this.BindEvent<A> ( target, type, eventName, eventType, null );
#endif

		}

#if PARAM
		/// <summary>
		/// 绑定可以触发设置行选中状态的事件到某个静态事件.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="type">目标类型.</param>
		/// <param name="eventName">事件名称, 比如: "Click".</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler</param>
		/// <param name="tableName">表格的名称, 与 TableSetting 的 Name 一致.</param>
		/// <param name="isChecked">行是否被选中, 可以为 null, 则取反.</param>
		/// <param name="viewFilter">过滤条件, 只有符合条件的行才会设置选中状态, 可以为 null, 则使用 IWindow 提供的条件, 默认为 null.</param>
		public void BindSetIsRowCheckedEvent<A> ( Type type, string eventName, EventHandlerType eventType, string tableName, bool? isChecked, string viewFilter = null ) where A : EventArgs
#else
		/// <summary>
		/// 绑定可以触发设置行选中状态的事件到某个静态事件.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="type">目标类型.</param>
		/// <param name="eventName">事件名称, 比如: "Click".</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler</param>
		/// <param name="tableName">表格的名称, 与 TableSetting 的 Name 一致.</param>
		/// <param name="isChecked">行是否被选中, 可以为 null, 则取反.</param>
		/// <param name="viewFilter">过滤条件, 只有符合条件的行才会设置选中状态, 可以为 null, 则使用 IWindow 提供的条件.</param>
		public void BindSetIsRowCheckedEvent<A> ( Type type, string eventName, EventHandlerType eventType, string tableName, bool? isChecked, string viewFilter ) where A : EventArgs
#endif
		{ this.bindSetIsRowCheckedEvent<A> ( null, type, eventName, eventType, tableName, isChecked, viewFilter ); }

#if PARAM
		/// <summary>
		/// 绑定可以触发设置行选中状态的事件, 比如: Button 的 Click 事件.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="target">目标实例, 比如: 窗口上的 Button.</param>
		/// <param name="eventName">事件名称, 比如: "Click".</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler.</param>
		/// <param name="tableName">表格的名称, 与 TableSetting 的 Name 一致.</param>
		/// <param name="isChecked">行是否被选中, 可以为 null, 则取反.</param>
		/// <param name="viewFilter">过滤条件, 只有符合条件的行才会设置选中状态, 可以为 null, 则使用 IWindow 提供的条件, 默认为 null.</param>
		public void BindSetIsRowCheckedEvent<A> ( object target, string eventName, EventHandlerType eventType, string tableName, bool? isChecked, string viewFilter = null ) where A : EventArgs
#else
		/// <summary>
		/// 绑定可以触发设置行选中状态的事件, 比如: Button 的 Click 事件.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="target">目标实例, 比如: 窗口上的 Button.</param>
		/// <param name="eventName">事件名称, 比如: "Click".</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler.</param>
		/// <param name="tableName">表格的名称, 与 TableSetting 的 Name 一致.</param>
		/// <param name="isChecked">行是否被选中, 可以为 null, 则取反.</param>
		/// <param name="viewFilter">过滤条件, 只有符合条件的行才会设置选中状态, 可以为 null, 则使用 IWindow 提供的条件.</param>
		public void BindSetIsRowCheckedEvent<A> ( object target, string eventName, EventHandlerType eventType, string tableName, bool? isChecked, string viewFilter ) where A : EventArgs
#endif
		{ this.bindSetIsRowCheckedEvent<A> ( target, null, eventName, eventType, tableName, isChecked, viewFilter ); }
		protected void bindSetIsRowCheckedEvent<A> ( object target, Type type, string eventName, EventHandlerType eventType, string tableName, bool? isChecked, string viewFilter ) where A : EventArgs
		{

#if V3_5 || V4
			this.BindEvent<A> ( target, type, eventName, eventType,
				delegate ( object sender, A e )
				{

					if ( !string.IsNullOrEmpty ( tableName ) && this.tableSettings.ContainsKey ( tableName ) )
						this.setIsRowChecked ( this.tableSettings[tableName], isChecked, viewFilter );

				}
				);
#else
			this.BindEvent<A> ( target, type, eventName, eventType, null );
#endif

		}

		/// <summary>
		/// 绑定可以触发分页相关操作的事件到某个静态事件.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="type">目标类型.</param>
		/// <param name="eventName">事件名称, 比如: "Click".</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler.</param>
		/// <param name="tableName">表格的名称, 与 TableSetting 的 Name 一致.</param>
		/// <param name="actionType">分页操作类型.</param>
		public void BindPagerEvent<A> ( Type type, string eventName, EventHandlerType eventType, string tableName, PagerActionType actionType ) where A : EventArgs
		{ this.bindPagerEvent<A> ( null, type, eventName, eventType, tableName, actionType ); }
		/// <summary>
		/// 绑定可以触发分页相关操作的事件, 比如: Button 的 Click 事件.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="target">目标实例, 比如: 窗口上的 Button.</param>
		/// <param name="eventName">事件名称, 比如: "Click".</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler.</param>
		/// <param name="tableName">表格的名称, 与 TableSetting 的 Name 一致.</param>
		/// <param name="actionType">分页操作类型.</param>
		public void BindPagerEvent<A> ( object target, string eventName, EventHandlerType eventType, string tableName, PagerActionType actionType ) where A : EventArgs
		{ this.bindPagerEvent<A> ( target, null, eventName, eventType, tableName, actionType ); }
		protected void bindPagerEvent<A> ( object target, Type type, string eventName, EventHandlerType eventType, string tableName, PagerActionType actionType ) where A : EventArgs
		{

#if V3_5 || V4
			this.BindEvent<A> ( target, type, eventName, eventType,
				delegate ( object sender, A e )
				{

					if ( !string.IsNullOrEmpty ( tableName ) && this.tableSettings.ContainsKey ( tableName ) )
						this.setPager ( this.tableSettings[tableName], actionType, this.window.GetPagerIndex ( this.tableSettings[tableName] ) );

				}
				);
#else
			this.BindEvent<A> ( target, type, eventName, eventType, null );
#endif

		}

	}

	partial class DataWindowCore<IW, P>
	{
#if !PARAM
		/// <summary>
		/// 绑定可以触发设置行选中状态的事件, 比如: Button 的 Click 事件.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="target">目标实例, 比如: 窗口上的 Button.</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler.</param>
		/// <param name="eventName">事件名称, 比如: "Click".</param>
		/// <param name="tableName">表格的名称, 与 TableSetting 的 Name 一致.</param>
		/// <param name="isChecked">行是否被选中, 可以为 null, 则取反.</param>
		public void BindSetIsRowCheckedEvent<A> ( object target, string eventName, EventHandlerType eventType, string tableName, bool? isChecked ) where A : EventArgs
		{ this.bindSetIsRowCheckedEvent<A> ( target, null, eventName, eventType, tableName, isChecked, null ); }

		/// <summary>
		/// 绑定可以触发设置行选中状态的事件到某个静态事件.
		/// </summary>
		/// <typeparam name="A">事件的参数类型, 必须从 EventArgs 派生.</typeparam>
		/// <param name="type">目标类型.</param>
		/// <param name="eventName">事件名称, 比如: "Click".</param>
		/// <param name="eventType">事件的类型, 比如: EventHandler</param>
		/// <param name="tableName">表格的名称, 与 TableSetting 的 Name 一致.</param>
		/// <param name="isChecked">行是否被选中, 可以为 null, 则取反.</param>
		public void BindSetIsRowCheckedEvent<A> ( Type type, string eventName, EventHandlerType eventType, string tableName, bool? isChecked ) where A : EventArgs
		{ this.bindSetIsRowCheckedEvent<A> ( null, type, eventName, eventType, tableName, isChecked, null ); }
#endif
	}

}

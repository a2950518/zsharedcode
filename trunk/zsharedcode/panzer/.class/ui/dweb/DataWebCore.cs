/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/dweb/DataWebCore.cs
 * 版本: 1.1, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Collections.Generic;
using System.Web;

using zoyobar.shared.panzer.ui.dwindow;

namespace zoyobar.shared.panzer.ui.dweb
{

	#region " PagerStoreType "
	/// <summary>
	/// 分页设置的存储类型.
	/// </summary>
	public enum PagerStoreType
	{
		/// <summary>
		/// 存储在 Session 中.
		/// </summary>
		Session = 1,
		/// <summary>
		/// 存储在 Cookie 中.
		/// </summary>
		Cookie = 2,
		/// <summary>
		/// 存储在 Url 中.
		/// </summary>
		Query = 3
	}
	#endregion

	#region " PagerSetting "
	/// <summary>
	/// 分页的相关设置.
	/// </summary>
	public class PagerSetting
		: dwindow.PagerSetting
	{
		protected readonly PagerStoreType storeType;
		protected readonly string storeKey;

		/// <summary>
		/// 分页设置的存储方式.
		/// </summary>
		public PagerStoreType StoreType
		{
			get { return this.storeType; }
		}

		/// <summary>
		/// 分页设置的存储关键字.
		/// </summary>
		public string StoreKey
		{
			get { return this.storeKey; }
		}

		/// <summary>
		/// 创建一个分页设置.
		/// </summary>
		/// <param name="storeType">分页设置的存储方式.</param>
		/// <param name="storeKey">分页设置的存储关键字.</param>
		/// <param name="paginalCount">每页包含的数据条数, 如果小于等于 0, 则默认为 20.</param>
		public PagerSetting ( PagerStoreType storeType, string storeKey, int paginalCount )
			: base ( PagerBuilder.GetIndex ( storeType, storeKey ), paginalCount )
		{

			if ( string.IsNullOrEmpty ( storeKey ) )
				throw new ArgumentNullException ( "storeKey", "分页设置的存储关键字不能为空" );

			this.storeType = storeType;
			this.storeKey = storeKey;
			this.ItemCount = PagerBuilder.GetItemCount ( storeType, storeKey );
		}

	}
	#endregion

	#region " PagerBuilder "
	/// <summary>
	/// 分页构造器.
	/// </summary>
	public class PagerBuilder
	{

		private static string makeIndexStoreKey ( string storeKey )
		{ return string.Format ( "pi{0}", string.IsNullOrEmpty ( storeKey ) ? string.Empty : storeKey ); }

		private static string makeItemCountStoreKey ( string storeKey )
		{ return string.Format ( "pic{0}", string.IsNullOrEmpty ( storeKey ) ? string.Empty : storeKey ); }

		/// <summary>
		/// 获取分页的索引.
		/// </summary>
		/// <param name="storeType">分页设置的存储方式.</param>
		/// <param name="storeKey">分页设置的存储关键字.</param>
		/// <returns>分页的索引.</returns>
		public static int GetIndex ( PagerStoreType storeType, string storeKey )
		{

			if ( string.IsNullOrEmpty ( storeKey ) )
				return 1;

			switch ( storeType )
			{
				case PagerStoreType.Cookie:

					try
					{ return Convert.ToInt32 ( HttpContext.Current.Request.Cookies[makeIndexStoreKey ( storeKey )].Value ); }
					catch
					{ return 1; }

				case PagerStoreType.Session:

					try
					{ return Convert.ToInt32 ( HttpContext.Current.Session[makeIndexStoreKey ( storeKey )] ); }
					catch
					{ return 1; }

				case PagerStoreType.Query:

					try
					{ return Convert.ToInt32 ( HttpContext.Current.Request[makeIndexStoreKey ( storeKey )] ); }
					catch
					{ return 1; }

				default:
					return 1;
			}

		}

		/// <summary>
		/// 获取总条目数.
		/// </summary>
		/// <param name="storeType">分页设置的存储方式.</param>
		/// <param name="storeKey">分页设置的存储关键字.</param>
		/// <returns>总条目数.</returns>
		public static int GetItemCount ( PagerStoreType storeType, string storeKey )
		{

			if ( string.IsNullOrEmpty ( storeKey ) )
				return 0;

			switch ( storeType )
			{
				case PagerStoreType.Cookie:

					try
					{ return Convert.ToInt32 ( HttpContext.Current.Request.Cookies[makeItemCountStoreKey ( storeKey )].Value ); }
					catch
					{ return 0; }

				case PagerStoreType.Session:

					try
					{ return Convert.ToInt32 ( HttpContext.Current.Session[makeItemCountStoreKey ( storeKey )] ); }
					catch
					{ return 0; }

				case PagerStoreType.Query:

					try
					{ return Convert.ToInt32 ( HttpContext.Current.Request[makeItemCountStoreKey ( storeKey )] ); }
					catch
					{ return 0; }

				default:
					return 0;
			}

		}

		/// <summary>
		/// 存储分页的设置.
		/// </summary>
		/// <param name="pagerSetting">分页设置.</param>
		public static void SetPagerSetting ( PagerSetting pagerSetting )
		{

			if ( null == pagerSetting )
				return;

			switch ( pagerSetting.StoreType )
			{
				case PagerStoreType.Cookie:

					try
					{
						HttpContext.Current.Response.Cookies.Set ( new HttpCookie ( makeIndexStoreKey ( pagerSetting.StoreKey ), pagerSetting.Index.ToString ( ) ) );

						HttpContext.Current.Response.Cookies.Set ( new HttpCookie ( makeItemCountStoreKey ( pagerSetting.StoreKey ), pagerSetting.ItemCount.ToString ( ) ) );
					}
					catch
					{ }

					break;

				case PagerStoreType.Session:

					try
					{
						HttpContext.Current.Session[makeIndexStoreKey ( pagerSetting.StoreKey )] = pagerSetting.Index;

						HttpContext.Current.Session[makeItemCountStoreKey ( pagerSetting.StoreKey )] = pagerSetting.ItemCount;
					}
					catch
					{ }

					break;

				case PagerStoreType.Query:
					break;
			}

		}

		/// <summary>
		/// 为 StoreType 属性为 Query 的 PagerSetting 生成分页的 HTML 代码.
		/// </summary>
		/// <param name="htmlTemplate">HTML 模板.</param>
		/// <param name="pagerSetting">分页设置.</param>
		/// <param name="actionType">分页操作的类型.</param>
		/// <param name="querySettings">查询条件设置列表.</param>
		/// <returns>分页 HTML 代码.</returns>
		public static string MakePagerHTML ( string htmlTemplate, PagerSetting pagerSetting, PagerActionType actionType, IList<QuerySetting> querySettings )
		{

			if ( string.IsNullOrEmpty ( htmlTemplate ) || null == pagerSetting || pagerSetting.StoreType != PagerStoreType.Query )
				return string.Empty;

			string query = string.Empty;

			switch ( actionType )
			{
				case PagerActionType.First:
					query = string.Format ( "{0}=1&{1}={2}", makeIndexStoreKey ( pagerSetting.StoreKey ), makeItemCountStoreKey ( pagerSetting.StoreKey ), pagerSetting.ItemCount );
					break;

				case PagerActionType.Last:
					query = string.Format ( "{0}={1}&{2}={3}", makeIndexStoreKey ( pagerSetting.StoreKey ), pagerSetting.Count, makeItemCountStoreKey ( pagerSetting.StoreKey ), pagerSetting.ItemCount );
					break;

				case PagerActionType.Next:
					query = string.Format ( "{0}={1}&{2}={3}", makeIndexStoreKey ( pagerSetting.StoreKey ), pagerSetting.Index + 1, makeItemCountStoreKey ( pagerSetting.StoreKey ), pagerSetting.ItemCount );
					break;

				case PagerActionType.Prev:
					query = string.Format ( "{0}={1}&{2}={3}", makeIndexStoreKey ( pagerSetting.StoreKey ), pagerSetting.Index - 1, makeItemCountStoreKey ( pagerSetting.StoreKey ), pagerSetting.ItemCount );
					break;
			}

			query += QueryBuilder.MakeQueryString ( querySettings );

			return string.Format ( htmlTemplate, query );
		}

	}
	#endregion

	#region " QuerySetting "
	/// <summary>
	/// 查询条件的设置.
	/// </summary>
	public class QuerySetting
	{
		/// <summary>
		/// 查询条件的名称.
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// 查询条件的值.
		/// </summary>
		public string Value;

		/// <summary>
		/// 条件在页面中的 id 属性.
		/// </summary>
		public readonly string ClientID;

		/// <summary>
		/// 条件在地址中的关键字.
		/// </summary>
		public readonly string QueryID;

		/// <summary>
		/// 创建一个条件设置.
		/// </summary>
		/// <param name="name">查询条件的名称.</param>
		/// <param name="clientID">条件在页面中的 id 属性.</param>
		/// <param name="queryID">条件在地址中的关键字.</param>
		public QuerySetting ( string name, string clientID, string queryID )
		{

			if ( string.IsNullOrEmpty ( name ) || string.IsNullOrEmpty ( clientID ) || string.IsNullOrEmpty ( queryID ) )
				throw new ArgumentNullException ( "name, clientID, queryID", "查询条件的名称, 条件在页面中的 id, 在地址中的关键字不能为空" );

			this.Name = name;
			this.ClientID = clientID;
			this.QueryID = queryID;
		}

	}
	#endregion

	#region " QueryBuilder "
	/// <summary>
	/// 条件构造器.
	/// </summary>
	public class QueryBuilder
	{

		/// <summary>
		/// 生成可以地址中的条件字符串.
		/// </summary>
		/// <param name="querySettings">查询条件设置列表.</param>
		/// <returns>条件字符串.</returns>
		public static string MakeQueryString ( IList<QuerySetting> querySettings )
		{

			if ( null == querySettings )
				return string.Empty;

			string query = string.Empty;

			foreach ( QuerySetting querySetting in querySettings )
				if ( null != querySetting && !string.IsNullOrEmpty ( querySetting.Value ) )
					query += string.Format ( "&{0}={1}", querySetting.QueryID, querySetting.Value );

			return query;
		}

		/// <summary>
		/// 更新查询条件的值.
		/// </summary>
		/// <param name="querySettings">查询条件设置列表.</param>
		public static void UpdateQueryValue ( IList<QuerySetting> querySettings )
		{

			if ( null == querySettings )
				return;

			foreach ( QuerySetting querySetting in querySettings )
				if ( null != querySetting )
					try
					{ querySetting.Value = HttpContext.Current.Request[querySetting.ClientID]; }
					catch { }

		}

		/// <summary>
		/// 得到名称对应的查询条件设置.
		/// </summary>
		/// <param name="querySettings">查询条件设置列表.</param>
		/// <param name="name">查询条件的名称.</param>
		/// <returns>对应的查询条件设置.</returns>
		public static QuerySetting GetQuerySetting ( SortedList<string, QuerySetting> querySettings, string name )
		{

			if ( null == querySettings || string.IsNullOrEmpty ( name ) || !querySettings.ContainsKey ( name ) )
				return null;

			return querySettings[name];
		}

		/// <summary>
		/// 得到名称对应的查询条件的值.
		/// </summary>
		/// <param name="querySettings">查询条件设置列表.</param>
		/// <param name="name">查询条件的名称.</param>
		/// <returns>查询条件的值.</returns>
		public static string GetQueryValue ( SortedList<string, QuerySetting> querySettings, string name )
		{
			QuerySetting querySetting = GetQuerySetting ( querySettings, name );

			if ( null == querySetting )
				return null;

			return querySetting.Value;
		}

	}
	#endregion

	/// <summary>
	/// 处理 DataTable 和 Web 页面的关系, 包括界面绑定, 数据更新等.
	/// </summary>
	/// <typeparam name="IW">界面实现的接口类型.</typeparam>
	/// <typeparam name="P">PagerSetting 的类型.</typeparam>
	public partial class DataWebCore<IW, P>
		: DataWindowCore<IW, P>
		where P : PagerSetting
		where IW : IDataWeb<P>
	{
		protected readonly SortedList<string, QuerySetting> querySettings = new SortedList<string, QuerySetting> ( );

		/// <summary>
		/// 获取查询条件设置数组.
		/// </summary>
		public SortedList<string, QuerySetting> QuerySettings
		{
			get { return this.querySettings; }
		}

#if PARAM
		/// <summary>
		/// 创建一个 DataWebCore.
		/// </summary>
		/// <param name="window">实现 IDataWeb 接口的类, 一般是窗体或控件.</param>
		/// <param name="tableSettings">DataTable 设置数组, 其中的 DataTable 将和 IDataWeb 表示的类协作.</param>
		/// <param name="querySettings">查询条件的设置数组, 用于在 PagerSetting 的 StoreType 属性为 Query 时, 传递搜索条件, 默认没有条件.</param>
		public DataWebCore ( IW window, TableSetting<P>[] tableSettings, QuerySetting[] querySettings = null )
#else
		/// <summary>
		/// 创建一个 DataWebCore.
		/// </summary>
		/// <param name="window">实现 IDataWeb 接口的类, 一般是窗体或控件.</param>
		/// <param name="tableSettings">DataTable 设置数组, 其中的 DataTable 将和 IDataWeb 表示的类协作.</param>
		/// <param name="querySettings">查询条件的设置数组, 用于在 PagerSetting 的 StoreType 属性为 Query 时, 传递搜索条件.</param>
		public DataWebCore ( IW window, TableSetting<P>[] tableSettings, QuerySetting[] querySettings )
#endif
			: base ( window, tableSettings )
		{

			if ( null != querySettings && querySettings.Length != 0 )
				foreach ( QuerySetting querySetting in querySettings )
					if ( null != querySetting && !this.querySettings.ContainsKey ( querySetting.Name ) )
						this.querySettings.Add ( querySetting.Name, querySetting );

			QueryBuilder.UpdateQueryValue ( this.querySettings.Values );
			this.window.SetQuerys ( this.querySettings );
		}

		protected override void dataCompleted ( TableSetting<P> tableSetting, DataActionType actionType )
		{
			base.dataCompleted ( tableSetting, actionType );

			this.window.DataBind ( tableSetting, actionType );
		}

		protected override void setPager ( TableSetting<P> tableSetting, PagerActionType actionType, int pagerIndex )
		{
			base.setPager ( tableSetting, actionType, pagerIndex );

			PagerBuilder.SetPagerSetting ( tableSetting.PagerSetting );
		}

	}

	partial class DataWebCore<IW, P>
	{
#if !PARAM
		/// <summary>
		/// 创建一个 DataWebCore.
		/// </summary>
		/// <param name="window">实现 IDataWeb 接口的类, 一般是窗体或控件.</param>
		/// <param name="tableSettings">DataTable 设置数组, 其中的 DataTable 将和 IDataWeb 表示的类协作.</param>
		public DataWebCore ( IW window, TableSetting<P>[] tableSettings )
			: this ( window, tableSettings, null )
		{ }
#endif
	}

}

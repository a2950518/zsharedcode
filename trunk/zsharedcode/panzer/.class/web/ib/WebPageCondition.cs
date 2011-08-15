/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageCondition.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;

using zoyobar.shared.panzer.flow;

namespace zoyobar.shared.panzer.web.ib
{

	#region " WebPageConditionType "
	/// <summary>
	/// 条件类型.
	/// </summary>
	public enum WebPageConditionType
	{
		/// <summary>
		/// 地址条件.
		/// </summary>
		Url = 1,
		/// <summary>
		/// jQuery 条件.
		/// </summary>
		JQuery = 2
	}
	#endregion

	#region " WebPageCondition "
	/// <summary>
	/// 用于 IEBrowser 判断状态是否成功的条件.
	/// </summary>
	public abstract class WebPageCondition
		: FlowCondition
	{
		/// <summary>
		/// 条件的类型.
		/// </summary>
		public readonly WebPageConditionType Type;

		protected WebPageCondition ( WebPageConditionType type, string name )
			: base ( name )
		{ this.Type = type; }

	}
	#endregion

	#region " UrlCondition "
	/// <summary>
	/// IEBrowser 判断页面是否载入的地址条件.
	/// </summary>
	public sealed class UrlCondition
		: WebPageCondition
	{
		/// <summary>
		/// 用于判断的地址.
		/// </summary>
		public readonly string Url;
		/// <summary>
		/// 地址的判断模式.
		/// </summary>
		public readonly StringCompareMode CompareMode;

		/// <summary>
		/// 创建一个判断页面是否载入的地址条件.
		/// </summary>
		/// <param name="name">条件的名称.</param>
		/// <param name="url">用于判断的地址.</param>
		/// <param name="compareMode">地址的判断模式.</param>
		public UrlCondition ( string name, string url, StringCompareMode compareMode )
			: base ( WebPageConditionType.Url, name )
		{

			if ( null == url )
				url = string.Empty;

			this.Url = url.ToLower ( );
			this.CompareMode = compareMode;
		}

	}
	#endregion

	#region " JQueryCondition "
	/// <summary>
	/// IEBrowser 判断页面是否载入的 jQuery 测试条件.
	/// </summary>
	public sealed class JQueryCondition
		: WebPageCondition
	{
		/// <summary>
		/// 用于测试执行的 jQuery 命令.
		/// </summary>
		public readonly JQuery JQuery;
		/// <summary>
		/// 期望结果.
		/// </summary>
		public readonly object Result;

		/// <summary>
		/// 创建一个 jQuery 测试条件.
		/// </summary>
		/// <param name="name">条件的名称.</param>
		/// <param name="jQuery">用于测试执行的 jQuery 命令.</param>
		/// <param name="result">期望结果.</param>
		public JQueryCondition ( string name, JQuery jQuery, object result )
			: base ( WebPageConditionType.JQuery, name )
		{

			if ( null == jQuery || null == result )
				throw new ArgumentNullException ( "jQuery, result", "jQuery 命令或者期望结果不能为空" );

			this.JQuery = jQuery;
			this.Result = result;
		}

	}
	#endregion

}

/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/IBCustomRecordAction
 * http://code.google.com/p/zsharedcode/wiki/IBNavigateRecordAction
 * http://code.google.com/p/zsharedcode/wiki/IBRecordAction
 * http://code.google.com/p/zsharedcode/wiki/IBRecordActionType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/RecordAction.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Collections.Generic;

using zoyobar.shared.panzer.flow;

namespace zoyobar.shared.panzer.web.ib
{

	#region " RecordActionType "
	/// <summary>
	/// 记录行为类型.
	/// </summary>
	public enum RecordActionType
	{
		/// <summary>
		/// 地址跳转记录.
		/// </summary>
		Navigate = 1,
		/// <summary>
		/// 用户操作记录.
		/// </summary>
		Custom = 2,
	}
	#endregion

	#region " RecordAction "
	/// <summary>
	/// 记录操作的基础类.
	/// </summary>
	public abstract class RecordAction
	{
		/// <summary>
		/// 记录行为类型.
		/// </summary>
		public readonly RecordActionType Type;

		protected RecordAction ( RecordActionType type )
		{ this.Type = type; }

	}
	#endregion

	#region " NavigateRecordAction "
	/// <summary>
	/// 导航操作记录.
	/// </summary>
	public sealed class NavigateRecordAction
		: RecordAction
	{
		/// <summary>
		/// 导航的地址.
		/// </summary>
		public readonly string Url;

		/// <summary>
		/// 创建一个导航操作记录.
		/// </summary>
		/// <param name="url">导航的地址.</param>
		public NavigateRecordAction ( string url )
			: base ( RecordActionType.Navigate )
		{

			if ( string.IsNullOrEmpty ( url ) )
				throw new ArgumentNullException ( "url", "地址不能为空" );

			this.Url = url;
		}

	}
	#endregion

	#region " CustomRecordAction "
	/// <summary>
	/// 用户操作记录.
	/// </summary>
	public sealed class CustomRecordAction
		: RecordAction
	{
		/// <summary>
		/// 用户操作的类型.
		/// </summary>
		public readonly string CustomType;
		/// <summary>
		/// 操作的成员.
		/// </summary>
		public readonly string Member;
		/// <summary>
		/// 操作目标的索引.
		/// </summary>
		public readonly int Index;
		/// <summary>
		/// 操作目标的路径.
		/// </summary>
		public readonly string Path;
		/// <summary>
		/// 操作的值.
		/// </summary>
		public readonly string Value;
		/// <summary>
		/// 操作的等待时间.
		/// </summary>
		public readonly int Wait;
		/// <summary>
		/// 确定搜索目标的条件.
		/// </summary>
		public readonly string Condition;

		/// <summary>
		/// 创建一个用户操作记录.
		/// </summary>
		/// <param name="customType">用户操作的类型.</param>
		/// <param name="memeber">操作的成员.</param>
		/// <param name="condition">确定搜索目标的条件.</param>
		/// <param name="path">操作目标的路径.</param>
		/// <param name="value">操作的值.</param>
		/// <param name="wait">操作的等待时间.</param>
		/// <param name="index">操作目标的索引.</param>
		public CustomRecordAction ( string customType, string memeber, string condition, string path, string value, int wait, int index )
			: base ( RecordActionType.Custom )
		{

			if ( string.IsNullOrEmpty ( customType ) || string.IsNullOrEmpty ( memeber ) || string.IsNullOrEmpty ( condition ) || string.IsNullOrEmpty ( path ) )
				throw new ArgumentNullException ( "customType, memeber, condition, path", "相关参数不能为空" );

			this.CustomType = customType;
			this.Member = memeber;
			this.Condition = condition;
			this.Path = path;
			this.Value = string.IsNullOrEmpty ( value ) ? "null" : value;
			this.Wait = wait < 1 ? 1 : wait;
			this.Index = index < 0 ? 0 : index;
		}

	}
	#endregion

}

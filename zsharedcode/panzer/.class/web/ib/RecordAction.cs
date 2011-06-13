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
using System.ComponentModel;

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
		private readonly RecordActionType type;

		/// <summary>
		/// 获取记录行为类型.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "记录行为类型" )]
		public RecordActionType Type
		{
			get { return this.type; }
		}

		protected RecordAction ( RecordActionType type )
		{ this.type = type; }

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
		/// 创建一个导航操作记录.
		/// </summary>
		/// <param name="expression">表达式.</param>
		/// <returns>导航操作记录.</returns>
		public static NavigateRecordAction Create ( string expression )
		{

			if ( string.IsNullOrEmpty ( expression ) )
				return null;

			try
			{ return new NavigateRecordAction ( expression.Substring( expression.IndexOf('&') + 1) ); }
			catch
			{ return null; }

		}

		private string url;

		/// <summary>
		/// 获取或设置导航的地址.
		/// </summary>
		[Category ( "行为" )]
		[Description ( "导航的地址" )]
		public string Url
		{
			get { return this.url; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.url = value;

			}
		}

		/// <summary>
		/// 创建一个导航操作记录.
		/// </summary>
		/// <param name="url">导航的地址.</param>
		public NavigateRecordAction ( string url )
			: base ( RecordActionType.Navigate )
		{

			if ( string.IsNullOrEmpty ( url ) )
				throw new ArgumentNullException ( "url", "地址不能为空" );

			this.url = url;
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>字符串.</returns>
		public override string ToString ( )
		{
			return string.Format ( "{0}&{1}", RecordActionType.Navigate, this.url );
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
		/// 创建一个用户操作记录.
		/// </summary>
		/// <param name="expression">表达式.</param>
		/// <returns>用户操作记录.</returns>
		public static CustomRecordAction Create ( string expression )
		{

			if ( string.IsNullOrEmpty ( expression ) )
				return null;

			string[] parts = expression.Split ( '&' );

			try
			{ return new CustomRecordAction ( parts[1], parts[2], parts[3], parts[4], parts[5], Convert.ToInt32 ( parts[6] ), Convert.ToInt32 ( parts[7] ) ); }
			catch
			{ return null; }

		}

		private string customType;
		private string member;
		private int index;
		private string path;
		private string value;
		private int wait;
		private string condition;

		/// <summary>
		/// 获取或设置用户操作的类型.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "用户操作的类型" )]
		public string CustomType
		{
			get { return this.customType; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.customType = value;

			}
		}

		/// <summary>
		/// 获取或设置操作的成员.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "操作的成员" )]
		public string Member
		{
			get { return this.member; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.member = value;

			}
		}

		/// <summary>
		/// 获取或设置操作目标的索引.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "目标的索引" )]
		public int Index
		{
			get { return this.index; }
			set
			{

				if ( value >= 0 )
					this.index = value;

			}
		}

		/// <summary>
		/// 获取或设置操作目标的路径.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "操作目标的路径" )]
		public string Path
		{
			get { return this.path; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.path = value;

			}
		}

		/// <summary>
		/// 获取或设置操作的值.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "操作的值" )]
		public string Value
		{
			get { return this.value; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.value = value;

			}
		}

		/// <summary>
		/// 获取或设置操作的等待时间.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "操作的等待时间" )]
		public int Wait
		{
			get { return this.wait; }
			set
			{

				if ( value >= 0 )
					this.wait = value;

			}
		}

		/// <summary>
		/// 获取或设置确定搜索目标的条件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "确定搜索目标的条件" )]
		public string Condition
		{
			get { return this.condition; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.condition = value;

			}
		}

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

			this.customType = customType;
			this.member = memeber;
			this.condition = condition;
			this.path = path;
			this.value = string.IsNullOrEmpty ( value ) ? "null" : value;
			this.wait = wait < 1 ? 1 : wait;
			this.index = index < 0 ? 0 : index;
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>字符串.</returns>
		public override string ToString ( )
		{ return string.Format ( "{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}", RecordActionType.Custom, this.customType, this.member, this.condition, this.path, this.value, this.wait, this.index ); }

	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/RecordAction.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
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
				throw new ArgumentNullException ( "expression", "表达式不能为空" );

			string[] parts = expression.Split ( new string[] { "`,`" }, StringSplitOptions.RemoveEmptyEntries );

			if ( parts.Length < 2 )
				throw new ArgumentException ( "表达式应至少包含 2 项内容", "expression" );

			return new NavigateRecordAction ( parts[1] );
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
			return string.Format ( "{0}`&`{1}", RecordActionType.Navigate, this.url );
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
				throw new ArgumentNullException ( "expression", "表达式不能为空" );

			string[] parts = expression.Split ( new string[] { "`,`" }, StringSplitOptions.RemoveEmptyEntries );

			if ( parts.Length < 2 )
				throw new ArgumentException ( "表达式应至少包含 2 项内容", "expression" );

			try
			{ return new CustomRecordAction ( parts[1], parts[2], parts[3], Convert.ToInt32 ( parts[4] ), ElementMark.Create ( parts[5] ) ); }
			catch
			{ throw new ArgumentException ( "wait, mark", "表达式中的格式可能不正确" ); }
		}

		private string customType;
		private string member;
		private string value;
		private int wait;
		private ElementMark mark;

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
		/// 获取确定搜索目标的条件.
		/// </summary>
		[Category ( "基本" )]
		[Description ( "确定搜索目标的条件" )]
		public ElementMark Mark
		{
			get { return this.mark; }
		}

		/// <summary>
		/// 创建一个用户操作记录.
		/// </summary>
		/// <param name="customType">用户操作的类型.</param>
		/// <param name="memeber">操作的成员.</param>
		/// <param name="value">操作的值.</param>
		/// <param name="wait">操作的等待时间.</param>
		/// <param name="mark">确定搜索目标的条件.</param>
		public CustomRecordAction ( string customType, string memeber, string value, int wait, ElementMark mark )
			: base ( RecordActionType.Custom )
		{

			if ( string.IsNullOrEmpty ( customType ) || string.IsNullOrEmpty ( memeber ) || null == mark )
				throw new ArgumentNullException ( "customType, memeber, mark", "相关参数不能为空" );

			this.customType = customType;
			this.member = memeber;
			this.value = string.IsNullOrEmpty ( value ) ? "null" : value;
			this.wait = wait < 0 ? 0 : wait;
			this.mark = mark;
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>字符串.</returns>
		public override string ToString ( )
		{ return string.Format ( "{0}`&`{1}`&`{2}`&`{3}`&`{4}`&`{5}", RecordActionType.Custom, this.customType, this.member, this.value, this.wait, this.mark ); }

	}
	#endregion

}

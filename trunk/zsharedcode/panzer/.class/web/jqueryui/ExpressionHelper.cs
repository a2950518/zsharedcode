/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.Collections.Generic;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ExpressionHelper "
	/// <summary>
	/// jQuery UI 的表达式辅助类, 可将字符串解析为一个树形结构.
	/// </summary>
	public sealed class ExpressionHelper
	{
		private readonly List<ExpressionHelper> childExpressionHelpers = new List<ExpressionHelper> ( );

		private readonly string value = string.Empty;
		private readonly string name = string.Empty;

		/// <summary>
		/// 子表达式辅助类, 也就是叶子结点.
		/// </summary>
		public List<ExpressionHelper> ChildExpressionHelpers
		{
			get { return this.childExpressionHelpers; }
		}

		/// <summary>
		/// 获取数据项名称.
		/// </summary>
		public string Name
		{
			get { return this.name; }
		}

		/// <summary>
		/// 获取数据项值.
		/// </summary>
		public string Value
		{
			get { return this.value; }
		}

		/// <summary>
		/// 获取是否有叶子结点.
		/// </summary>
		public bool IsHasChild
		{
			get { return this.ChildCount != 0; }
		}

		/// <summary>
		/// 获取叶子结点个数.
		/// </summary>
		public int ChildCount
		{
			get { return this.childExpressionHelpers.Count; }
		}

		/// <summary>
		/// 获取叶子结点, 每个结点为一个 ExpressionHelper.
		/// </summary>
		/// <param name="index">子结点的索引.</param>
		/// <returns>ExpressionHelper 辅助类.</returns>
		public ExpressionHelper this[int index]
		{
			get
			{

				if ( index < 0 || index >= this.ChildCount )
					return null;

				return this.childExpressionHelpers[index];
			}
		}

		/// <summary>
		/// 创建一个 jQuery UI 的表达式辅助类.
		/// </summary>
		/// <param name="expression">需要解析的为树结构的字符串.</param>
		public ExpressionHelper ( string expression )
		{

			if ( null == expression )
				throw new ArgumentNullException ( "expression", "表达式不能为空" );

			expression = expression.Trim ( );

			if ( expression.Contains ( "`;" ) )
				foreach ( string part in expression.Split ( new string[] { "`;" }, StringSplitOptions.RemoveEmptyEntries ) )
					this.childExpressionHelpers.Add ( new ExpressionHelper ( part ) );
			else if ( expression.StartsWith ( "`|" ) && expression.EndsWith ( "|`" ) )
			{
				expression = expression.Trim ( '`' ).Trim ( '|' );

				foreach ( string part in expression.Split ( new string[] { "`," }, StringSplitOptions.RemoveEmptyEntries ) )
					this.childExpressionHelpers.Add ( new ExpressionHelper ( part ) );

			}
			else if ( expression.Contains ( "`:" ) )
			{
				string[] parts = expression.Split ( new string[] { "`:" }, StringSplitOptions.RemoveEmptyEntries );

				this.name = parts[0].Trim ( );
				this.value = parts[1].Trim ( );
			}
			else
				this.value = expression;


		}

	}
	#endregion

}

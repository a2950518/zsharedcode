/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " ParameterType "
	/// <summary>
	/// jQuery UI 的参数类型.
	/// </summary>
	public enum ParameterType
	{
		/// <summary>
		/// 表达式.
		/// </summary>
		Expression = 1,
		/// <summary>
		/// 选择器.
		/// </summary>
		Selector = 2,
	}
	#endregion

	#region " Parameter "
	/// <summary>
	/// jQuery UI 的参数.
	/// </summary>
	public sealed class Parameter
	{
		private ParameterType type;
		private string value;
		private string name;
		private string @default;

		/// <summary>
		/// 获取或设置参数的名称.
		/// </summary>
		[Category ( "参数" )]
		[Description ( "参数的名称" )]
		public string Name
		{
			get { return this.name; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
					this.name = value;

			}
		}

		/// <summary>
		/// 获取或设置参数的类型.
		/// </summary>
		[Category ( "参数" )]
		[Description ( "参数的类型" )]
		public ParameterType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置参数的数据.
		/// </summary>
		[Category ( "参数" )]
		[Description ( "参数的数据" )]
		public string Value
		{
			get { return this.value; }
			set { this.value = ( null == value ? string.Empty : value ); }
		}

		/// <summary>
		/// 获取或设置默认的数据.
		/// </summary>
		[Category ( "参数" )]
		[Description ( "默认的数据" )]
		public string Default
		{
			get { return this.@default; }
			set { this.@default = ( null == value ? string.Empty : value ); }
		}

		/// <summary>
		/// 创建一个空的 jQuery UI 参数, 参数值采用选择器.
		/// </summary>
		public Parameter ( )
			: this ( "new parameter", ParameterType.Selector, null, null )
		{ }
		/// <summary>
		/// 创建一个 jQuery UI 参数, 参数值对应一个选择器.
		/// </summary>
		/// <param name="name">参数名称.</param>
		/// <param name="value">一个选择器.</param>
		public Parameter ( string name, string value )
			: this ( name, ParameterType.Selector, value, null )
		{ }
		/// <summary>
		/// 创建一个 jQuery UI 参数, 参数值对应一个选择器.
		/// </summary>
		/// <param name="name">参数名称.</param>
		/// <param name="value">一个选择器.</param>
		/// <param name="default">默认值.</param>
		public Parameter ( string name, string value, string @default )
			: this ( name, ParameterType.Selector, value, @default )
		{ }
		/// <summary>
		/// 创建一个 jQuery UI 参数.
		/// </summary>
		/// <param name="name">参数名称.</param>
		/// <param name="type">参数类型.</param>
		/// <param name="value">参数值.</param>
		public Parameter ( string name, ParameterType type, string value )
			: this ( name, type, value, null )
		{ }
		/// <summary>
		/// 创建一个 jQuery UI 参数.
		/// </summary>
		/// <param name="name">参数名称.</param>
		/// <param name="type">参数类型.</param>
		/// <param name="value">参数值.</param>
		/// <param name="default">默认值.</param>
		public Parameter ( string name, ParameterType type, string value, string @default )
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", "参数名称不能为空" );

			this.type = type;
			this.name = name;

			this.Default = @default;
			this.Value = value;
		}

	}
	#endregion

}

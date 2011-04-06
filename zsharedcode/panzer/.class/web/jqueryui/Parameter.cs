/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameter
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIParameterType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;

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
		/// <summary>
		/// 参数名称.
		/// </summary>
		public readonly string Name;
		/// <summary>
		/// 参数类型.
		/// </summary>
		public readonly ParameterType Type;
		/// <summary>
		/// 参数值.
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// 创建一个 jQuery UI 参数.
		/// </summary>
		/// <param name="name">参数名称.</param>
		/// <param name="type">参数类型.</param>
		/// <param name="value">参数值.</param>
		public Parameter ( string name, ParameterType type, string value )
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", "参数名称不能为空" );

			if ( null == value )
				value = string.Empty;

			this.Name = name;
			this.Type = type;
			this.Value = value;
		}

	}
	#endregion

}

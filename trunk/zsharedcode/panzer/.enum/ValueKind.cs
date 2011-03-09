/*
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/ValueKind.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * */

namespace zoyobar.shared.panzer
{

	/// <summary>
	/// 类型的种类.
	/// </summary>
	public enum ValueKind
	{
		/// <summary>
		/// 没有任何种类.
		/// </summary>
		None = 0,
		/// <summary>
		/// 结构.
		/// </summary>
		Structure = 1,
		/// <summary>
		/// 类.
		/// </summary>
		Class = 2,
		/// <summary>
		/// 枚举.
		/// </summary>
		Enum = 3
	}

}
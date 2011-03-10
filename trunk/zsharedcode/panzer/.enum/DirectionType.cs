/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/DirectionType
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/DirectionType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * */

namespace zoyobar.shared.panzer
{

	/// <summary>
	/// 方向.
	/// </summary>
	public enum DirectionType
	{
		/// <summary>
		/// 没有方向.
		/// </summary>
		None = 0,

		/// <summary>
		/// 输入.
		/// </summary>
		Input = 1,
		/// <summary>
		/// 输出.
		/// </summary>
		Output = 2,
		/// <summary>
		/// 输入和输出.
		/// </summary>
		InputNOutput = 3
	}

}
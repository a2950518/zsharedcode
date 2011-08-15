/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/DirectionType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
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
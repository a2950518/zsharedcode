/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/ValueKind.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
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
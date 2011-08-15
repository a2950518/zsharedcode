/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/StringCompareMode.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer
{

	/// <summary>
	/// 字符串的对比模式.
	/// </summary>
	public enum StringCompareMode
	{
		/// <summary>
		/// 完全相等.
		/// </summary>
		Equal = 1,
		/// <summary>
		/// 开头匹配.
		/// </summary>
		StartWith = 2,
		/// <summary>
		/// 结尾匹配.
		/// </summary>
		EndWith = 3,
		/// <summary>
		/// 包含.
		/// </summary>
		Contain = 4
	}

}
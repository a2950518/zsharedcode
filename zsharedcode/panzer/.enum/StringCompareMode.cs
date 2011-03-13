/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/StringCompareMode
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/StringCompareMode.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
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
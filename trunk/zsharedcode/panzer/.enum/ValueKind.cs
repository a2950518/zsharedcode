/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/ValueKind
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/ValueKind.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 你使用此文件, 需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
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
/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/FunctionType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/FunctionType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer
{

	/// <summary>
	/// 函数或者方法的类型.
	/// </summary>
	public enum FunctionType
	{
		/// <summary>
		/// 方法.
		/// </summary>
		Method = 1,
		/// <summary>
		/// 构造函数.
		/// </summary>
		Constructor = 2
	}

}
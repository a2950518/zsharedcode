/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/ValueStamp.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer
{

	/// <summary>
	/// 值的类型.
	/// </summary>
	public enum ValueStamp
	{
		/// <summary>
		/// 空的类型.
		/// </summary>
		None = 0,

		/// <summary>
		/// 字符串类型.
		/// </summary>
		String = 1,
		/// <summary>
		/// 整型.
		/// </summary>
		Integer = 2,
		/// <summary>
		/// 短整型.
		/// </summary>
		Short = 3,
		/// <summary>
		/// 长整型.
		/// </summary>
		Long = 4,
		/// <summary>
		/// 数字型.
		/// </summary>
		Decimal = 5,
		/// <summary>
		/// 布尔型.
		/// </summary>
		Boolean = 6,
		/// <summary>
		/// Guid 类型.
		/// </summary>
		Guid = 7,
		/// <summary>
		/// 颜色类型.
		/// </summary>
		Color = 8,
		/// <summary>
		/// 日期类型.
		/// </summary>
		DateTime = 9,
		/// <summary>
		/// 单精度类型.
		/// </summary>
		Single = 10,
		/// <summary>
		/// 双精度类型.
		/// </summary>
		Double = 11
	}

}
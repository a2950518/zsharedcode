/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOption
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIOptionType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " OptionType "
	/// <summary>
	/// jQuery UI 的选项类型.
	/// </summary>
	public enum OptionType
	{
		/// <summary>
		/// 空的选项.
		/// </summary>
		none = 0,

		/// <summary>
		/// 禁用, 对应一个 javascript 布尔值.
		/// </summary>
		disabled = 1,

		/// <summary>
		/// 是否添加默认样式, 对应一个 javascript 布尔值.
		/// </summary>
		addClasses = 2,

		/// <summary>
		/// 追加位置, 对应一个 javascript 元素或者选择器.
		/// </summary>
		appendTo = 3,

		/// <summary>
		/// 指定 x/y 轴, 对应一个 javascript 字符串, 'x' 或者 'y'.
		/// </summary>
		axis = 4,

		/// <summary>
		/// 在符合选择器的元素上取消操作, 对应选择器.
		/// </summary>
		cancel = 5,

		/// <summary>
		/// 关联符合选择器的排序, 对应选择器.
		/// </summary>
		connectToSortable = 6,

		/// <summary>
		/// 操作所在的容器, 对应选择器, javascript 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		containment = 7,

		/// <summary>
		/// 鼠标样式, 对应一个 javascript 字符串.
		/// </summary>
		cursor = 8,

		/// <summary>
		/// 鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性.
		/// </summary>
		cursorAt = 9,

		/// <summary>
		/// 以毫秒计算的延迟, 对应一个 javascript 数值.
		/// </summary>
		delay = 10,

		/// <summary>
		/// 距离, 对应一个 javascript 数值.
		/// </summary>
		distance = 11,

		/// <summary>
		/// 表格, 对应一个 javascript 数组, [10, 20].
		/// </summary>
		grid = 12,

		/// <summary>
		/// 限制或者相关的句柄, 对应一个 javascript 元素或者选择器.
		/// </summary>
		handle = 13,

		/// <summary>
		/// 行为方式, 对应一个 javascript 字符串或者返回字符串的函数, 'original' 针对元素本身, 'clone' 针对元素的副本.
		/// </summary>
		helper = 14,

		/// <summary>
		/// 是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器.
		/// </summary>
		iframeFix = 15,

		/// <summary>
		/// 透明度, 对应一个 javascript 数值, 0 到 1 之间.
		/// </summary>
		opacity = 16,

		/// <summary>
		/// 刷新位置, 对应一个 javascript 布尔值.
		/// </summary>
		refreshPositions = 17,

		/// <summary>
		/// 恢复原始状态, 对应一个 javascript 布尔值.
		/// </summary>
		revert = 18,

		/// <summary>
		/// 恢复原始状态的延迟, 以毫秒计算, 对应一个 javascript 数值.
		/// </summary>
		revertDuration = 19,

		/// <summary>
		/// 使用范围, 将各种操作功能关联, 对应一个 javascript 字符串.
		/// </summary>
		scope = 20,

		/// <summary>
		/// 使用滚动轴, 对应一个 javascript 布尔值.
		/// </summary>
		scroll = 21,

		/// <summary>
		/// 滚动轴灵敏度, 对应一个 javascript 数值.
		/// </summary>
		scrollSensitivity = 22,

		/// <summary>
		/// 滚动轴速度, 对应一个 javascript 数值.
		/// </summary>
		scrollSpeed = 23,

		/// <summary>
		/// 附着, 对应一个 javascript 布尔值或选择器.
		/// </summary>
		snap = 24,

		/// <summary>
		/// 附着模式, 对应一个 javascript 字符串, 可以是 'inner', 'outer', 'both'.
		/// </summary>
		snapMode = 25,

		/// <summary>
		/// 附着距离, 对应一个 javascript 数值.
		/// </summary>
		snapTolerance = 26,

		/// <summary>
		/// 控制 z 轴顺序, 对应一个选择器.
		/// </summary>
		stack = 27,

		/// <summary>
		/// z 轴顺序, 对应一个 javascript 数值.
		/// </summary>
		zIndex = 28,

		/// <summary>
		/// 被创建时, 对应一个 javascript 函数.
		/// </summary>
		create = 29,

		/// <summary>
		/// 动作开始时, 对应一个 javascript 函数.
		/// </summary>
		start = 30,

		/// <summary>
		/// 拖动时, 对应一个 javascript 函数.
		/// </summary>
		drag = 31,

		/// <summary>
		/// 动作停止时, 对应一个 javascript 函数.
		/// </summary>
		stop = 32,
	}
	#endregion

	#region " Option "
	/// <summary>
	/// jQuery UI 的选项.
	/// </summary>
	public sealed partial class Option
	{
		/// <summary>
		/// 选项类型.
		/// </summary>
		public readonly OptionType Type;
		/// <summary>
		/// 选项值.
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// 创建一个 jQuery UI 选项.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">选项值.</param>
		public Option ( OptionType type, string value )
		{

			if ( null == value )
				value = string.Empty;

			this.Type = type;
			this.Value = value;
		}

	}
	#endregion

}

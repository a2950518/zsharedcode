/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;

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
		none,

		/// <summary>
		/// 禁用, 对应一个 javascript 布尔值或者数组.
		/// </summary>
		disabled,

		/// <summary>
		/// 是否添加默认样式, 对应一个 javascript 布尔值.
		/// </summary>
		addClasses,

		/// <summary>
		/// 追加位置, 对应一个 javascript 元素或者选择器.
		/// </summary>
		appendTo,

		/// <summary>
		/// 指定 x/y 轴, 对应一个 javascript 字符串, 'x' 或者 'y'.
		/// </summary>
		axis,

		/// <summary>
		/// 在符合选择器的元素上取消操作, 对应选择器.
		/// </summary>
		cancel,

		/// <summary>
		/// 关联符合选择器的排序, 对应选择器.
		/// </summary>
		connectToSortable,

		/// <summary>
		/// 操作所在的容器, 对应选择器, javascript 元素, 字符串, 'parent', 'document', 'window' 中的一种, 或者数组, 比如: [0, 0, 300, 400].
		/// </summary>
		containment,

		/// <summary>
		/// 鼠标样式, 对应一个 javascript 字符串.
		/// </summary>
		cursor,

		/// <summary>
		/// 鼠标的相对位置, 对应一个 javascript 对象, { top: 1, left: 2, right: 3, bottom: 4 }, 需要具有选择其中的一个或者两个属性.
		/// </summary>
		cursorAt,

		/// <summary>
		/// 以毫秒计算的延迟, 对应一个 javascript 数值.
		/// </summary>
		delay,

		/// <summary>
		/// 距离, 对应一个 javascript 数值.
		/// </summary>
		distance,

		/// <summary>
		/// 表格, 对应一个 javascript 数组, [10, 20].
		/// </summary>
		grid,

		/// <summary>
		/// 限制或者相关的句柄, 对应一个 javascript 元素或者选择器.
		/// </summary>
		handle,

		/// <summary>
		/// 行为方式, 对应一个 javascript 字符串或者返回字符串的函数, 'original' 针对元素本身, 'clone' 针对元素的副本.
		/// </summary>
		helper,

		/// <summary>
		/// 是否引发 iframe 中的事件, 对应一个 javascript 布尔值或选择器.
		/// </summary>
		iframeFix,

		/// <summary>
		/// 透明度, 对应一个 javascript 数值, 0 到 1 之间.
		/// </summary>
		opacity,

		/// <summary>
		/// 刷新位置, 对应一个 javascript 布尔值.
		/// </summary>
		refreshPositions,

		/// <summary>
		/// 恢复原始状态, 对应一个 javascript 布尔值, 或者恢复的毫秒数.
		/// </summary>
		revert,

		/// <summary>
		/// 恢复原始状态的延迟, 以毫秒计算, 对应一个 javascript 数值.
		/// </summary>
		revertDuration,

		/// <summary>
		/// 使用范围, 将各种操作功能关联, 对应一个 javascript 字符串.
		/// </summary>
		scope,

		/// <summary>
		/// 使用滚动轴, 对应一个 javascript 布尔值.
		/// </summary>
		scroll,

		/// <summary>
		/// 滚动轴灵敏度, 对应一个 javascript 数值.
		/// </summary>
		scrollSensitivity,

		/// <summary>
		/// 滚动轴速度, 对应一个 javascript 数值.
		/// </summary>
		scrollSpeed,

		/// <summary>
		/// 附着, 对应一个 javascript 布尔值或选择器.
		/// </summary>
		snap,

		/// <summary>
		/// 附着模式, 对应一个 javascript 字符串, 可以是 'inner', 'outer', 'both'.
		/// </summary>
		snapMode,

		/// <summary>
		/// 附着距离, 对应一个 javascript 数值.
		/// </summary>
		snapTolerance,

		/// <summary>
		/// 控制 z 轴顺序, 对应一个选择器.
		/// </summary>
		stack,

		/// <summary>
		/// z 轴顺序, 对应一个 javascript 数值.
		/// </summary>
		zIndex,

		/// <summary>
		/// 被创建时, 对应一个 javascript 函数.
		/// </summary>
		create,

		/// <summary>
		/// 动作开始时, 对应一个 javascript 函数.
		/// </summary>
		start,

		/// <summary>
		/// 拖动时, 对应一个 javascript 函数.
		/// </summary>
		drag,

		/// <summary>
		/// 动作停止时, 对应一个 javascript 函数.
		/// </summary>
		stop,

		/// <summary>
		/// 动作接受的目标, 对应一个 javascript 函数或者选择器.
		/// </summary>
		accept,

		/// <summary>
		/// 提供可用时的样式, 对应一个 javascript 字符串.
		/// </summary>
		activeClass,

		/// <summary>
		/// 阻止事件的传播, 对应一个 javascript 布尔值.
		/// </summary>
		greedy,

		/// <summary>
		/// 提供悬浮样式, 对应一个 javascript 字符串.
		/// </summary>
		hoverClass,

		/// <summary>
		/// 接触的模式, 对应一个 javascript 字符串, 为 'fit', 'intersect', 'pointer', 'touch' 中的一种.
		/// </summary>
		tolerance,

		/// <summary>
		/// 被激活时, 对应一个 javascript 函数.
		/// </summary>
		activate,

		/// <summary>
		/// 取消激活时, 对应一个 javascript 函数.
		/// </summary>
		deactivate,

		/// <summary>
		/// 在元素上时, 对应一个 javascript 函数.
		/// </summary>
		over,

		/// <summary>
		/// 在元素之外时, 对应一个 javascript 函数.
		/// </summary>
		@out,

		/// <summary>
		/// 元素放下时, 对应一个 javascript 函数.
		/// </summary>
		drop,

		/// <summary>
		/// 关联的元素, 对应一个选择器.
		/// </summary>
		connectWith,

		/// <summary>
		/// 是否允许拖放目标为空, 对应一个 javascript 布尔值.
		/// </summary>
		dropOnEmpty,

		/// <summary>
		/// 强制 helper 拥有尺寸, 对应一个 javascript 布尔值.
		/// </summary>
		forceHelperSize,

		/// <summary>
		/// 强制 placeholder 拥有尺寸, 对应一个 javascript 布尔值.
		/// </summary>
		forcePlaceholderSize,

		/// <summary>
		/// 针对的条目, 对应一个选择器.
		/// </summary>
		items,

		/// <summary>
		/// 应用于空白的样式, 对应一个 javascript 字符串.
		/// </summary>
		placeholder,

		/// <summary>
		/// 排序时, 对应一个 javascript 函数.
		/// </summary>
		sort,

		/// <summary>
		/// 改变时, 对应一个 javascript 函数.
		/// </summary>
		change,

		/// <summary>
		/// 动作停止之前, 对应一个 javascript 函数.
		/// </summary>
		beforeStop,

		/// <summary>
		/// 更新后, 对应一个 javascript 函数.
		/// </summary>
		update,

		/// <summary>
		/// 接收时, 对应一个 javascript 函数.
		/// </summary>
		receive,

		/// <summary>
		/// 移除后, 对应一个 javascript 函数.
		/// </summary>
		remove,

		/// <summary>
		/// 自动刷新, 对应一个 javascript 布尔值.
		/// </summary>
		autoRefresh,

		/// <summary>
		/// 对目标的过滤, 对应选择器.
		/// </summary>
		filter,

		/// <summary>
		/// 选择后, 对应一个 javascript 函数.
		/// </summary>
		selected,

		/// <summary>
		/// 选择时, 对应一个 javascript 函数.
		/// </summary>
		selecting,

		/// <summary>
		/// 取消选择后, 对应一个 javascript 函数.
		/// </summary>
		unselected,

		/// <summary>
		/// 取消选择时, 对应一个 javascript 函数.
		/// </summary>
		unselecting,

		/// <summary>
		/// 同时缩放, 对应一个 javascript 元素, 选择器或者 jQuery.
		/// </summary>
		alsoResize,

		/// <summary>
		/// 播放动画, 对应一个 javascript 布尔值.
		/// </summary>
		animate,

		/// <summary>
		/// 播放动画延迟, 对应一个 javascript 数值.
		/// </summary>
		animateDuration,

		/// <summary>
		/// 动画效果, 对应一个 javascript 字符串.
		/// </summary>
		animateEasing,

		/// <summary>
		/// 宽高比例, 对应一个 javascript 布尔值或者数值.
		/// </summary>
		aspectRatio,

		/// <summary>
		/// 自动隐藏, 对应一个 javascript 布尔值.
		/// </summary>
		autoHide,

		/// <summary>
		/// 复制, 对应一个 javascript 布尔值.
		/// </summary>
		ghost,

		/// <summary>
		/// 缩放的方式, 对应一个 javascript 字符串或者对象.
		/// </summary>
		handles,

		/// <summary>
		/// 最大高度, 对应一个 javascript 数值.
		/// </summary>
		maxHeight,

		/// <summary>
		/// 最大宽度, 对应一个 javascript 数值.
		/// </summary>
		maxWidth,

		/// <summary>
		/// 最小高度, 对应一个 javascript 数值.
		/// </summary>
		minHeight,

		/// <summary>
		/// 最小宽度, 对应一个 javascript 数值.
		/// </summary>
		minWidth,

		/// <summary>
		/// 大小缩放时, 对应一个 javascript 函数.
		/// </summary>
		resize,

		/// <summary>
		/// 是否使用文本, 对应一个 javascript 布尔值.
		/// </summary>
		text,

		/// <summary>
		/// 图标, 对应一个 javascript 对象.
		/// </summary>
		icons,

		/// <summary>
		/// 标签, 对应一个 javascript 字符串.
		/// </summary>
		label,

		/// <summary>
		/// 激活的内容, 对应一个选择器, 元素, 数值或者布尔值.
		/// </summary>
		active,

		/// <summary>
		/// 动画, 对应一个 javascript 字符串或者布尔值.
		/// </summary>
		animated,

		/// <summary>
		/// 自动调整高度, 对应一个 javascript 布尔值.
		/// </summary>
		autoHeight,

		/// <summary>
		/// 清除样式, 对应一个 javascript 布尔值.
		/// </summary>
		clearStyle,

		/// <summary>
		/// 是否合并, 对应一个 javascript 布尔值.
		/// </summary>
		collapsible,

		/// <summary>
		/// 触发的事件, 对应一个 javascript 字符串.
		/// </summary>
		@event,

		/// <summary>
		/// 是否填充空白, 对应一个 javascript 布尔值.
		/// </summary>
		fillSpace,

		/// <summary>
		/// 标题内容, 对应一个选择器或者 jQuery.
		/// </summary>
		header,

		/// <summary>
		/// 是否导航, 对应一个 javascript 布尔值.
		/// </summary>
		navigation,

		/// <summary>
		/// 导航过滤, 对应一个 javascript 函数.
		/// </summary>
		navigationFilter,

		/// <summary>
		/// 改变开始时, 对应一个 javascript 函数.
		/// </summary>
		changestart,

		/// <summary>
		/// 自动获得焦点, 对应一个 javascript 布尔值.
		/// </summary>
		autoFocus,

		/// <summary>
		/// 最小长度, 对应一个 javascript 数值.
		/// </summary>
		minLength,

		/// <summary>
		/// 位置, 对应一个 javascript 对象.
		/// </summary>
		position,

		/// <summary>
		/// 源, 对应一个 javascript 字符串或者数组.
		/// </summary>
		source,

		/// <summary>
		/// 搜索时, 对应一个 javascript 函数.
		/// </summary>
		search,

		/// <summary>
		/// 打开时, 对应一个 javascript 函数.
		/// </summary>
		open,

		/// <summary>
		/// 获得焦点时, 对应一个 javascript 函数.
		/// </summary>
		focus,

		/// <summary>
		/// 选择时或者选中的, 对应一个 javascript 函数或者数组.
		/// </summary>
		select,

		/// <summary>
		/// 关闭时, 对应一个 javascript 函数.
		/// </summary>
		close,

		/// <summary>
		/// 进度值, 对应一个 javascript 数值.
		/// </summary>
		value,

		/// <summary>
		/// 完成时, 对应一个 javascript 函数.
		/// </summary>
		complete,

		/// <summary>
		/// 提示元素, 对应一个选择器或者元素.
		/// </summary>
		altField,

		/// <summary>
		/// 提示的格式, 对应一个 javascript 字符串.
		/// </summary>
		altFormat,

		/// <summary>
		/// 追加的文本, 对应一个 javascript 字符串.
		/// </summary>
		appendText,

		/// <summary>
		/// 自动改变大小, 对应一个 javascript 布尔值.
		/// </summary>
		autoSize,

		/// <summary>
		/// 按钮图片, 对应一个 javascript 字符串.
		/// </summary>
		buttonImage,

		/// <summary>
		/// 只显示按钮图片, 对应一个 javascript 布尔值.
		/// </summary>
		buttonImageOnly,

		/// <summary>
		/// 按钮文本, 对应一个 javascript 字符串.
		/// </summary>
		buttonText,

		/// <summary>
		/// 如何计算周.
		/// </summary>
		calculateWeek,

		/// <summary>
		/// 是否可以改变月份, 对应一个 javascript 布尔值.
		/// </summary>
		changeMonth,

		/// <summary>
		/// 是否可以改变年份, 对应一个 javascript 布尔值.
		/// </summary>
		changeYear,

		/// <summary>
		/// 关闭的文本, 对应一个 javascript 字符串.
		/// </summary>
		closeText,

		/// <summary>
		/// 是否限制输入, 对应一个 javascript 布尔值.
		/// </summary>
		constrainInput,

		/// <summary>
		/// 当前日期的显示文本, 对应一个 javascript 字符串.
		/// </summary>
		currentText,

		/// <summary>
		/// 日期格式, 对应一个 javascript 字符串.
		/// </summary>
		dateFormat,

		/// <summary>
		/// 星期的名称, 对应一个 javascript 数组.
		/// </summary>
		dayNames,

		/// <summary>
		/// 星期的最短名称, 对应一个 javascript 数组.
		/// </summary>
		dayNamesMin,

		/// <summary>
		/// 星期的短名称, 对应一个 javascript 数组.
		/// </summary>
		dayNamesShort,

		/// <summary>
		/// 默认的日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		defaultDate,

		/// <summary>
		/// 间隔, 对应一个 javascript 字符串.
		/// </summary>
		duration,

		/// <summary>
		/// 一周开始的一天, 对应一个 javascript 数值.
		/// </summary>
		firstDay,

		/// <summary>
		/// 是否当前时间为选中时间, 对应一个 javascript 布尔值.
		/// </summary>
		gotoCurrent,

		/// <summary>
		/// 是否隐藏上一和下一按钮, 对应一个 javascript 布尔值.
		/// </summary>
		hideIfNoPrevNext,

		/// <summary>
		/// 是否从右到左, 对应一个 javascript 布尔值.
		/// </summary>
		isRTL,

		/// <summary>
		/// 最大日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		maxDate,

		/// <summary>
		/// 最小日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		minDate,

		/// <summary>
		/// 月的名称, 对应一个 javascript 数组.
		/// </summary>
		monthNames,

		/// <summary>
		/// 月的短名称, 对应一个 javascript 数组.
		/// </summary>
		monthNamesShort,

		/// <summary>
		/// 导航应用日期格式, 对应一个 javascript 布尔值.
		/// </summary>
		navigationAsDateFormat,

		/// <summary>
		/// 下一个的文本, 对应一个 javascript 字符串.
		/// </summary>
		nextText,

		/// <summary>
		/// 显示的月数, 对应一个 javascript 数值.
		/// </summary>
		numberOfMonths,

		/// <summary>
		/// 上一个的文本, 对应一个 javascript 字符串.
		/// </summary>
		prevText,

		/// <summary>
		/// 是否可以选择其它月, 对应一个 javascript 布尔值.
		/// </summary>
		selectOtherMonths,

		/// <summary>
		/// 尚不明确, 对应一个 javascript 字符串或者数值.
		/// </summary>
		shortYearCutoff,

		/// <summary>
		/// 显示动画, 对应一个 javascript 字符串.
		/// </summary>
		showAnim,

		/// <summary>
		/// 是否显示按钮栏, 对应一个 javascript 布尔值.
		/// </summary>
		showButtonPanel,

		/// <summary>
		/// 当前月份显示的位置, 对应一个 javascript 数值.
		/// </summary>
		showCurrentAtPos,

		/// <summary>
		/// 是否在年后显示月份, 对应一个 javascript 布尔值.
		/// </summary>
		showMonthAfterYear,

		/// <summary>
		/// 是否显示按钮效果, 对应一个 javascript 字符串.
		/// </summary>
		showOn,

		/// <summary>
		/// 显示的样式, 对应一个 javascript 对象.
		/// </summary>
		showOptions,

		/// <summary>
		/// 是否显示其它月, 对应一个 javascript 布尔值.
		/// </summary>
		showOtherMonths,

		/// <summary>
		/// 是否显示周, 对应一个 javascript 布尔值.
		/// </summary>
		showWeek,

		/// <summary>
		/// 一次跳转的月份数, 对应一个 javascript 数值.
		/// </summary>
		stepMonths,

		/// <summary>
		/// 周的标题, 对应一个 javascript 字符串.
		/// </summary>
		weekHeader,

		/// <summary>
		/// 年的跨度, 对应一个 javascript 数值.
		/// </summary>
		yearRange,

		/// <summary>
		/// 年份的附加标题, 对应一个 javascript 字符串.
		/// </summary>
		yearSuffix,

		/// <summary>
		/// 显示之前, 对应一个 javascript 函数.
		/// </summary>
		beforeShow,

		/// <summary>
		/// 显示日期之前, 对应一个 javascript 函数.
		/// </summary>
		beforeShowDay,

		/// <summary>
		/// 改变月年时, 对应一个 javascript 函数.
		/// </summary>
		onChangeMonthYear,

		/// <summary>
		/// 关闭时, 对应一个 javascript 函数.
		/// </summary>
		onClose,

		/// <summary>
		/// 选择时, 对应一个 javascript 函数.
		/// </summary>
		onSelect,

		/// <summary>
		/// 是否自动打开, 对应一个 javascript 布尔值.
		/// </summary>
		autoOpen,

		/// <summary>
		/// 按钮, 对应一个 javascript 对象或者数组.
		/// </summary>
		buttons,

		/// <summary>
		/// 是否按下 Esc 建关闭, 对应一个 javascript 布尔值.
		/// </summary>
		closeOnEscape,

		/// <summary>
		/// 对话框的样式, 对应一个 javascript 字符串.
		/// </summary>
		dialogClass,

		/// <summary>
		/// 是否允许拖动, 对应一个 javascript 布尔值.
		/// </summary>
		draggable,

		/// <summary>
		/// 高度, 对应一个 javascript 数值.
		/// </summary>
		height,

		/// <summary>
		/// 关闭时的效果, 对应一个 javascript 字符串.
		/// </summary>
		hide,

		/// <summary>
		/// 是否使用 modal, 对应一个 javascript 布尔值.
		/// </summary>
		modal,

		/// <summary>
		/// 是否可以缩放, 对应一个 javascript 布尔值.
		/// </summary>
		resizable,

		/// <summary>
		/// 显示时的效果, 对应一个 javascript 字符串.
		/// </summary>
		show,

		/// <summary>
		/// 标题, 对应一个 javascript 字符串.
		/// </summary>
		title,

		/// <summary>
		/// 宽度, 对应一个 javascript 数值.
		/// </summary>
		width,

		/// <summary>
		/// 关闭之前, 对应一个 javascript 函数.
		/// </summary>
		beforeClose,

		/// <summary>
		/// 拖动开始, 对应一个 javascript 函数.
		/// </summary>
		dragStart,

		/// <summary>
		/// 拖动停止, 对应一个 javascript 函数.
		/// </summary>
		dragStop,

		/// <summary>
		/// 缩放开始, 对应一个 javascript 函数.
		/// </summary>
		resizeStart,

		/// <summary>
		/// 缩放停止, 对应一个 javascript 函数.
		/// </summary>
		resizeStop,

		/// <summary>
		/// 最大值, 对应一个 javascript 数值.
		/// </summary>
		max,

		/// <summary>
		/// 最小值, 对应一个 javascript 数值.
		/// </summary>
		min,

		/// <summary>
		/// 方向, 对应一个 javascript 字符串.
		/// </summary>
		orientation,

		/// <summary>
		/// 使用范围, 对应一个 javascript 字符串或者布尔值.
		/// </summary>
		range,

		/// <summary>
		/// 步长, 对应一个 javascript 数值.
		/// </summary>
		step,

		/// <summary>
		/// 值, 对应一个 javascript 数组.
		/// </summary>
		values,

		/// <summary>
		/// 滑动时, 对应一个 javascript 函数.
		/// </summary>
		slide,

		/// <summary>
		/// Ajax 选项, 对应一个 javascript 对象.
		/// </summary>
		ajaxOptions,

		/// <summary>
		/// 是否缓存, 对应一个 javascript 布尔值.
		/// </summary>
		cache,

		/// <summary>
		/// Cookie, 对应一个 javascript 对象.
		/// </summary>
		cookie,

		/// <summary>
		/// 应使用 collapsible.
		/// </summary>
		deselectable,

		/// <summary>
		/// 效果, 对应一个 javascript 对象或者数组.
		/// </summary>
		fx,

		/// <summary>
		/// id 前缀, 对应一个 javascript 字符串.
		/// </summary>
		idPrefix,

		/// <summary>
		/// 面板模板, 对应一个 javascript 字符串.
		/// </summary>
		panelTemplate,

		/// <summary>
		/// 载入条, 对应一个 javascript 字符串.
		/// </summary>
		spinner,

		/// <summary>
		/// 标签模板, 对应一个 javascript 字符串.
		/// </summary>
		tabTemplate,

		/// <summary>
		/// 载入时, 对应一个 javascript 函数.
		/// </summary>
		load,

		/// <summary>
		/// 添加时, 对应一个 javascript 函数.
		/// </summary>
		add,

		/// <summary>
		/// 可用时, 对应一个 javascript 函数.
		/// </summary>
		enable,

		/// <summary>
		/// 禁用时, 对应一个 javascript 函数.
		/// </summary>
		disable,






		/// <summary>
		/// 时钟触发的间隔.
		/// </summary>
		interval,
		/// <summary>
		/// 时钟触发时.
		/// </summary>
		tick,
		/// <summary>
		/// 字段.
		/// </summary>
		field,
		/// <summary>
		/// 验证字段的正则表达式.
		/// </summary>
		fieldmask,
		/// <summary>
		/// 尾.
		/// </summary>
		footer,
		/// <summary>
		/// 条目.
		/// </summary>
		item,
		/// <summary>
		/// 编辑条目.
		/// </summary>
		edititem,
		/// <summary>
		/// 空.
		/// </summary>
		empty,
		/// <summary>
		/// 行的名称.
		/// </summary>
		rowsname,
		/// <summary>
		/// 多行编辑.
		/// </summary>
		multipleedit,
		/// <summary>
		/// 选择多行.
		/// </summary>
		multipleselect,
		/// <summary>
		/// 移除之前.
		/// </summary>
		preremove,
		/// <summary>
		/// 移除后.
		/// </summary>
		removed,
		/// <summary>
		/// 更新之前.
		/// </summary>
		preupdate,
		/// <summary>
		/// 更新后.
		/// </summary>
		updated,
		/// <summary>
		/// 填充之前.
		/// </summary>
		prefill,
		/// <summary>
		/// 填充.
		/// </summary>
		fill,
		/// <summary>
		/// 填充后.
		/// </summary>
		filled,
		/// <summary>
		/// 添加之前.
		/// </summary>
		preinsert,
		/// <summary>
		/// 添加.
		/// </summary>
		insert,
		/// <summary>
		/// 添加后.
		/// </summary>
		inserted,
		/// <summary>
		/// 新建条目.
		/// </summary>
		newitem,
		/// <summary>
		/// 页大小.
		/// </summary>
		pagesize,
		/// <summary>
		/// 页码.
		/// </summary>
		pageindex,
		/// <summary>
		/// 导航变化.
		/// </summary>
		navigable,
		/// <summary>
		/// 被阻塞.
		/// </summary>
		blocked,
		/// <summary>
		/// 单线程.
		/// </summary>
		singlethread,
		/// <summary>
		/// 执行之前.
		/// </summary>
		preexecute,
		/// <summary>
		/// 执行完成.
		/// </summary>
		executed,
		/// <summary>
		/// 新建的行模板.
		/// </summary>
		inserteditem,
		/// <summary>
		/// 更新的行模板.
		/// </summary>
		updateditem,
		/// <summary>
		/// 删除的行模板.
		/// </summary>
		removeditem,
		/// <summary>
		/// 嵌入的模板.
		/// </summary>
		embed,
		/// <summary>
		/// 自定义之前.
		/// </summary>
		precustom,
		/// <summary>
		/// 自定义.
		/// </summary>
		custom,
		/// <summary>
		/// 自定义完成.
		/// </summary>
		customed,
		/// <summary>
		/// 分步开始前.
		/// </summary>
		presubstep,
		/// <summary>
		/// 分步进行时.
		/// </summary>
		substepping,
		/// <summary>
		/// 分步完成.
		/// </summary>
		substepped,
		/// <summary>
		/// 参与过滤的字段.
		/// </summary>
		filterfield,
		/// <summary>
		/// 参与过滤字段的默认值.
		/// </summary>
		filterfielddefault,
		/// <summary>
		/// 提示.
		/// </summary>
		tip,
		/// <summary>
		/// 分组模板.
		/// </summary>
		group,
		/// <summary>
		/// 分组字段.
		/// </summary>
		groupfield,
		/// <summary>
		/// 检测时.
		/// </summary>
		check,
		/// <summary>
		/// 检测后.
		/// </summary>
		@checked,
		/// <summary>
		/// 默认值.
		/// </summary>
		defaultvalue,
		/// <summary>
		/// 最大值的提示.
		/// </summary>
		maxtip,
		/// <summary>
		/// 最小值的提示.
		/// </summary>
		mintip,
		/// <summary>
		/// 名称.
		/// </summary>
		name,
		/// <summary>
		/// 是否必需.
		/// </summary>
		need,
		/// <summary>
		/// 缺少时的提示.
		/// </summary>
		needtip,
		/// <summary>
		/// 提供者.
		/// </summary>
		provider,
		/// <summary>
		/// 正则表达式.
		/// </summary>
		reg,
		/// <summary>
		/// 不符合正则表达式时的提示.
		/// </summary>
		regtip,
		/// <summary>
		/// 成功时的提示.
		/// </summary>
		successtip,
		/// <summary>
		/// 目标.
		/// </summary>
		target,
		/// <summary>
		/// 类型.
		/// </summary>
		type,
		/// <summary>
		/// 类型不符合时的提示.
		/// </summary>
		typetip,
		/// <summary>
		/// 显示提示.
		/// </summary>
		showtip,
		/// <summary>
		/// 等于.
		/// </summary>
		equal,
		/// <summary>
		/// 等于的提示.
		/// </summary>
		equaltip,

		/// <summary>
		/// 上传页面 iframe.
		/// </summary>
		upload,
		/// <summary>
		/// 上传页面的表单索引.
		/// </summary>
		uploadform,
		/// <summary>
		/// 时钟.
		/// </summary>
		timer,

		/// <summary>
		/// 数据.
		/// </summary>
		data,
		/// <summary>
		/// 选项.
		/// </summary>
		options,
		/// <summary>
		/// 序列的颜色.
		/// </summary>
		seriesColors,
		/// <summary>
		/// 序列堆栈.
		/// </summary>
		stackSeries,
		/// <summary>
		/// 轴.
		/// </summary>
		axes,
		/// <summary>
		/// x 轴.
		/// </summary>
		xaxis,
		/// <summary>
		/// y 轴.
		/// </summary>
		yaxis,
		/// <summary>
		/// x2 轴.
		/// </summary>
		x2axis,
		/// <summary>
		/// y2 轴.
		/// </summary>
		y2axis,
		/// <summary>
		/// 样式.
		/// </summary>
		style,
		/// <summary>
		/// 显示提示.
		/// </summary>
		showTooltip,
		/// <summary>
		/// 是否跟随鼠标.
		/// </summary>
		followMouse,
		/// <summary>
		/// 提示位置.
		/// </summary>
		tooltipLocation,
		/// <summary>
		/// 提示的偏移.
		/// </summary>
		tooltipOffset,
		/// <summary>
		/// 显示像素位置.
		/// </summary>
		showTooltipGridPosition,
		/// <summary>
		/// 显示数据位置.
		/// </summary>
		showTooltipUnitPosition,
		/// <summary>
		/// 提示的格式.
		/// </summary>
		tooltipFormatString,
		/// <summary>
		/// 是否使用轴的格式.
		/// </summary>
		useAxesFormatters,
		/// <summary>
		/// 显示提示的轴.
		/// </summary>
		tooltipAxesGroups,
		/// <summary>
		/// 颜色.
		/// </summary>
		color,
		/// <summary>
		/// 拖动的方向.
		/// </summary>
		constrainTo,
		/// <summary>
		/// 拖动设置.
		/// </summary>
		dragable,
		/// <summary>
		/// 字体.
		/// </summary>
		fontFamily,
		/// <summary>
		/// 字号.
		/// </summary>
		fontSize,
		/// <summary>
		/// 对齐方式.
		/// </summary>
		textAlign,
		/// <summary>
		/// 文字颜色.
		/// </summary>
		textColor,
		/// <summary>
		/// 绘制.
		/// </summary>
		renderer,
		/// <summary>
		/// 绘制选项.
		/// </summary>
		rendererOptions,
		/// <summary>
		/// 转化 html.
		/// </summary>
		escapeHtml,
		/// <summary>
		/// 转化 html.
		/// </summary>
		escapeHTML,
		/// <summary>
		/// 位置.
		/// </summary>
		location,
		/// <summary>
		/// 显示文字.
		/// </summary>
		showLabels,
		/// <summary>
		/// 颜色切换.
		/// </summary>
		showSwatch,
		/// <summary>
		/// 图例.
		/// </summary>
		legend,
		/// <summary>
		/// 位置.
		/// </summary>
		placement,
		/// <summary>
		/// x 偏移.
		/// </summary>
		xoffset,
		/// <summary>
		/// y 偏移.
		/// </summary>
		yoffset,
		/// <summary>
		/// 边框.
		/// </summary>
		border,
		/// <summary>
		/// 背景.
		/// </summary>
		background,
		/// <summary>
		/// 行间距.
		/// </summary>
		rowSpacing,
		/// <summary>
		/// 上方边距.
		/// </summary>
		marginTop,
		/// <summary>
		/// 下方边距.
		/// </summary>
		marginBottom,
		/// <summary>
		/// 右方边距.
		/// </summary>
		marginRight,
		/// <summary>
		/// 左方边距.
		/// </summary>
		marginLeft,
		/// <summary>
		/// 标签.
		/// </summary>
		labels,
		/// <summary>
		/// 调用 replot 时的动画.
		/// </summary>
		animateReplot,
		/// <summary>
		/// 对数据排序.
		/// </summary>
		sortData,
		/// <summary>
		/// 空数据指示器.
		/// </summary>
		noDataIndicator,
		/// <summary>
		/// 填充.
		/// </summary>
		fillBetween,
		/// <summary>
		/// 默认开始轴.
		/// </summary>
		defaultAxisStart,
		/// <summary>
		/// 序列默认设置.
		/// </summary>
		seriesDefaults,
		/// <summary>
		/// 轴默认设置.
		/// </summary>
		axesDefaults,
		/// <summary>
		/// 数据绘制选项.
		/// </summary>
		dataRendererOptions,
		/// <summary>
		/// 数据绘制.
		/// </summary>
		dataRenderer,
		/// <summary>
		/// 绘制网格.
		/// </summary>
		drawGridlines,
		/// <summary>
		/// 线的颜色.
		/// </summary>
		gridLineColor,
		/// <summary>
		/// 线的宽度.
		/// </summary>
		gridLineWidth,
		/// <summary>
		/// 边框颜色.
		/// </summary>
		borderColor,
		/// <summary>
		/// 边框宽度.
		/// </summary>
		borderWidth,
		/// <summary>
		/// 是否绘制边框.
		/// </summary>
		drawBorder,
		/// <summary>
		/// 是否显示阴影.
		/// </summary>
		shadow,
		/// <summary>
		/// 阴影的角度.
		/// </summary>
		shadowAngle,
		/// <summary>
		/// 阴影的偏移.
		/// </summary>
		shadowOffset,
		/// <summary>
		/// 阴影的宽度.
		/// </summary>
		shadowWidth,
		/// <summary>
		/// 阴影的深度.
		/// </summary>
		shadowDepth,
		/// <summary>
		/// 阴影的颜色.
		/// </summary>
		shadowColor,
		/// <summary>
		/// 阴影的透明度.
		/// </summary>
		shadowAlpha,
		/// <summary>
		/// 序列.
		/// </summary>
		series,
		/// <summary>
		/// 显示标题.
		/// </summary>
		showLabel,
		/// <summary>
		/// 填充区颜色.
		/// </summary>
		negativeColor,
		/// <summary>
		/// 线的宽度.
		/// </summary>
		lineWidth,
		/// <summary>
		/// 线的连接.
		/// </summary>
		lineJoin,
		/// <summary>
		/// 线的端点.
		/// </summary>
		lineCap,
		/// <summary>
		/// 直线类型.
		/// </summary>
		linePattern,
		/// <summary>
		/// 为空时断开.
		/// </summary>
		breakOnNull,
		/// <summary>
		/// 标记绘制.
		/// </summary>
		markerRenderer,
		/// <summary>
		/// 标记选项.
		/// </summary>
		markerOptions,
		/// <summary>
		/// 显示线.
		/// </summary>
		showLine,
		/// <summary>
		/// 是否显示标记
		/// </summary>
		showMarker,
		/// <summary>
		/// 索引.
		/// </summary>
		index,
		/// <summary>
		/// 填充色.
		/// </summary>
		fillColor,
		/// <summary>
		/// 填充透明度.
		/// </summary>
		fillAlpha,
		/// <summary>
		/// 描边.
		/// </summary>
		fillAndStroke,
		/// <summary>
		/// 禁止使用堆栈.
		/// </summary>
		disableStack,
		/// <summary>
		/// 临近阀值.
		/// </summary>
		neighborThreshold,
		/// <summary>
		/// 填充至 0.
		/// </summary>
		fillToZero,
		/// <summary>
		/// 填充至数值.
		/// </summary>
		fillToValue,
		/// <summary>
		/// 使用负色.
		/// </summary>
		useNegativeColors,
		/// <summary>
		/// 填充轴.
		/// </summary>
		fillAxis,
		/// <summary>
		/// 刻度绘制.
		/// </summary>
		tickRenderer,
		/// <summary>
		/// 刻度绘制选项.
		/// </summary>
		tickOptions,
		/// <summary>
		/// 标签绘制.
		/// </summary>
		labelRenderer,
		/// <summary>
		/// 标签绘制选项.
		/// </summary>
		labelOptions,
		/// <summary>
		/// 自动缩放.
		/// </summary>
		autoscale,
		/// <summary>
		/// 填充.
		/// </summary>
		pad,
		/// <summary>
		/// 最大填充.
		/// </summary>
		padMax,
		/// <summary>
		/// 最小填充.
		/// </summary>
		padMin,
		/// <summary>
		/// 刻度.
		/// </summary>
		ticks,
		/// <summary>
		/// 刻度个数.
		/// </summary>
		numberTicks,
		/// <summary>
		/// 刻度的间距.
		/// </summary>
		tickInterval,
		/// <summary>
		/// 显示刻度.
		/// </summary>
		showTicks,
		/// <summary>
		/// 显示刻度标记.
		/// </summary>
		showTickMarks,
		/// <summary>
		/// 显示最小刻度.
		/// </summary>
		showMinorTicks,
		/// <summary>
		/// 绘制主网格线.
		/// </summary>
		drawMajorGridlines,
		/// <summary>
		/// 绘制次要网格线.
		/// </summary>
		drawMinorGridlines,
		/// <summary>
		/// 绘制主要刻度标记.
		/// </summary>
		drawMajorTickMarks,
		/// <summary>
		/// 绘制次要刻度标记.
		/// </summary>
		drawMinorTickMarks,
		/// <summary>
		/// 使用序列的颜色.
		/// </summary>
		useSeriesColor,
		/// <summary>
		/// 同步刻度.
		/// </summary>
		syncTicks,
		/// <summary>
		/// 刻度空白.
		/// </summary>
		tickSpacing,
		/// <summary>
		/// 标记.
		/// </summary>
		mark,
		/// <summary>
		/// 显示标记.
		/// </summary>
		showMark,
		/// <summary>
		/// 显示网格线.
		/// </summary>
		showGridline,
		/// <summary>
		/// 是否为次要刻度.
		/// </summary>
		isMinorTick,
		/// <summary>
		/// 尺寸.
		/// </summary>
		size,
		/// <summary>
		/// 刻度尺寸.
		/// </summary>
		markSize,
		/// <summary>
		/// 格式化工具.
		/// </summary>
		formatter,
		/// <summary>
		/// 前缀.
		/// </summary>
		prefix,
		/// <summary>
		/// 格式化字符串.
		/// </summary>
		formatString,
		/// <summary>
		/// 断开点.
		/// </summary>
		breakPoints,
		/// <summary>
		/// 断开刻度标题.
		/// </summary>
		breakTickLabel,
		/// <summary>
		/// 绘制基线.
		/// </summary>
		drawBaseline,
		/// <summary>
		/// 基线宽度.
		/// </summary>
		baselineWidth,
		/// <summary>
		/// 基线颜色.
		/// </summary>
		baselineColor,
		/// <summary>
		/// 必须有 0 刻度.
		/// </summary>
		forceTickAt0,
		/// <summary>
		/// 必须有 100 刻度.
		/// </summary>
		forceTickAt100,
		/// <summary>
		/// 刻度内距.
		/// </summary>
		tickInset,
		/// <summary>
		/// 次要刻度.
		/// </summary>
		minorTicks,
		/// <summary>
		/// 对齐刻度.
		/// </summary>
		alignTicks,
		/// <summary>
		/// 阴影绘制.
		/// </summary>
		shadowRenderer,
		/// <summary>
		/// 形状绘制.
		/// </summary>
		shapeRenderer,
		/// <summary>
		/// 鼠标滑过高亮.
		/// </summary>
		highlightMouseOver,
		/// <summary>
		/// 鼠标按下高亮.
		/// </summary>
		highlightMouseDown,
		/// <summary>
		/// 高亮颜色.
		/// </summary>
		highlightColor,
		/// <summary>
		/// 柱状图内空白.
		/// </summary>
		barPadding,
		/// <summary>
		/// 柱状图外空白.
		/// </summary>
		barMargin,
		/// <summary>
		/// 柱状图的方向.
		/// </summary>
		barDirection,
		/// <summary>
		/// 柱状图宽度.
		/// </summary>
		barWidth,
		/// <summary>
		/// 瀑布.
		/// </summary>
		waterfall,
		/// <summary>
		/// 分组.
		/// </summary>
		groups,
		/// <summary>
		/// 使用不同颜色.
		/// </summary>
		varyBarColor,
		/// <summary>
		/// 高亮颜色.
		/// </summary>
		highlightColors,
		/// <summary>
		/// 换位数据.
		/// </summary>
		transposedData,
		/// <summary>
		/// 样式.
		/// </summary>
		css,
		/// <summary>
		/// 插入换行.
		/// </summary>
		insertBreaks,
		/// <summary>
		/// 使用不同颜色.
		/// </summary>
		varyBlockColors,
		/// <summary>
		/// 使用不同颜色.
		/// </summary>
		varyBubbleColors,
		/// <summary>
		/// 自动缩放泡泡.
		/// </summary>
		autoscaleBubbles,
		/// <summary>
		/// 自动缩放倍数.
		/// </summary>
		autoscaleMultiplier,
		/// <summary>
		/// 自动缩放因子.
		/// </summary>
		autoscalePointsFactor,
		/// <summary>
		/// 泡泡透明度.
		/// </summary>
		bubbleAlpha,
		/// <summary>
		/// 高亮透明度.
		/// </summary>
		highlightAlpha,
		/// <summary>
		/// 泡泡是否渐变.
		/// </summary>
		bubbleGradients,
		/// <summary>
		/// 角度.
		/// </summary>
		angle,
		/// <summary>
		/// 字体粗细.
		/// </summary>
		fontWeight,
		/// <summary>
		/// 字体压缩.
		/// </summary>
		fontStretch,
		/// <summary>
		/// 启动字体支持.
		/// </summary>
		enableFontSupport,
		/// <summary>
		/// pt 转 px.
		/// </summary>
		pt2px,
		/// <summary>
		/// 标签的位置.
		/// </summary>
		labelPosition,
		/// <summary>
		/// 排序合并的标签.
		/// </summary>
		sortMergedLabels,
	}
	#endregion

	#region " Option "
	/// <summary>
	/// jQuery UI 的选项.
	/// </summary>
	public sealed partial class Option
	{
		private OptionType type;
		private string value;

		/// <summary>
		/// 获取或设置选项类型.
		/// </summary>
		public OptionType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置选项值.
		/// </summary>
		public string Value
		{
			get { return this.value; }
			set { this.value = ( null == value ? string.Empty : value ); }
		}

		/// <summary>
		/// 创建一个 jQuery UI 选项.
		/// </summary>
		public Option ( )
			: this ( OptionType.none, null )
		{ }
		/// <summary>
		/// 创建一个 jQuery UI 选项.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">选项值.</param>
		public Option ( OptionType type, string value )
		{
			this.type = type;

			this.Value = value;
		}

	}
	#endregion

}


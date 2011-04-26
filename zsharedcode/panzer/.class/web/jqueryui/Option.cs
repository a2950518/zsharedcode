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
		/// 禁用, 对应一个 javascript 布尔值或者数组.
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
		/// 恢复原始状态, 对应一个 javascript 布尔值, 或者恢复的毫秒数.
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

		/// <summary>
		/// 动作接受的目标, 对应一个 javascript 函数或者选择器.
		/// </summary>
		accept = 33,

		/// <summary>
		/// 提供可用时的样式, 对应一个 javascript 字符串.
		/// </summary>
		activeClass = 34,

		/// <summary>
		/// 阻止事件的传播, 对应一个 javascript 布尔值.
		/// </summary>
		greedy = 35,

		/// <summary>
		/// 提供悬浮样式, 对应一个 javascript 字符串.
		/// </summary>
		hoverClass = 36,

		/// <summary>
		/// 接触的模式, 对应一个 javascript 字符串, 为 'fit', 'intersect', 'pointer', 'touch' 中的一种.
		/// </summary>
		tolerance = 37,

		/// <summary>
		/// 被激活时, 对应一个 javascript 函数.
		/// </summary>
		activate = 38,

		/// <summary>
		/// 取消激活时, 对应一个 javascript 函数.
		/// </summary>
		deactivate = 39,

		/// <summary>
		/// 在元素上时, 对应一个 javascript 函数.
		/// </summary>
		over = 40,

		/// <summary>
		/// 在元素之外时, 对应一个 javascript 函数.
		/// </summary>
		@out = 41,

		/// <summary>
		/// 元素放下时, 对应一个 javascript 函数.
		/// </summary>
		drop = 42,

		/// <summary>
		/// 关联的元素, 对应一个选择器.
		/// </summary>
		connectWith = 43,

		/// <summary>
		/// 是否允许拖放目标为空, 对应一个 javascript 布尔值.
		/// </summary>
		dropOnEmpty = 44,

		/// <summary>
		/// 强制 helper 拥有尺寸, 对应一个 javascript 布尔值.
		/// </summary>
		forceHelperSize = 45,

		/// <summary>
		/// 强制 placeholder 拥有尺寸, 对应一个 javascript 布尔值.
		/// </summary>
		forcePlaceholderSize = 46,

		/// <summary>
		/// 针对的条目, 对应一个选择器.
		/// </summary>
		items = 47,

		/// <summary>
		/// 应用于空白的样式, 对应一个 javascript 字符串.
		/// </summary>
		placeholder = 48,

		/// <summary>
		/// 排序时, 对应一个 javascript 函数.
		/// </summary>
		sort = 49,

		/// <summary>
		/// 改变时, 对应一个 javascript 函数.
		/// </summary>
		change = 50,

		/// <summary>
		/// 动作停止之前, 对应一个 javascript 函数.
		/// </summary>
		beforeStop = 51,

		/// <summary>
		/// 更新后, 对应一个 javascript 函数.
		/// </summary>
		update = 52,

		/// <summary>
		/// 接收时, 对应一个 javascript 函数.
		/// </summary>
		receive = 53,

		/// <summary>
		/// 移除后, 对应一个 javascript 函数.
		/// </summary>
		remove = 54,

		/// <summary>
		/// 自动刷新, 对应一个 javascript 布尔值.
		/// </summary>
		autoRefresh = 55,

		/// <summary>
		/// 对目标的过滤, 对应选择器.
		/// </summary>
		filter = 56,

		/// <summary>
		/// 选择后, 对应一个 javascript 函数.
		/// </summary>
		selected = 57,

		/// <summary>
		/// 选择时, 对应一个 javascript 函数.
		/// </summary>
		selecting = 58,

		/// <summary>
		/// 取消选择后, 对应一个 javascript 函数.
		/// </summary>
		unselected = 59,

		/// <summary>
		/// 取消选择时, 对应一个 javascript 函数.
		/// </summary>
		unselecting = 60,

		/// <summary>
		/// 同时缩放, 对应一个 javascript 元素, 选择器或者 jQuery.
		/// </summary>
		alsoResize = 61,

		/// <summary>
		/// 播放动画, 对应一个 javascript 布尔值.
		/// </summary>
		animate = 62,

		/// <summary>
		/// 播放动画延迟, 对应一个 javascript 数值.
		/// </summary>
		animateDuration = 63,

		/// <summary>
		/// 动画效果, 对应一个 javascript 字符串.
		/// </summary>
		animateEasing = 64,

		/// <summary>
		/// 宽高比例, 对应一个 javascript 布尔值或者数值.
		/// </summary>
		aspectRatio = 65,

		/// <summary>
		/// 自动隐藏, 对应一个 javascript 布尔值.
		/// </summary>
		autoHide = 66,

		/// <summary>
		/// 复制, 对应一个 javascript 布尔值.
		/// </summary>
		ghost = 67,

		/// <summary>
		/// 缩放的方式, 对应一个 javascript 字符串或者对象.
		/// </summary>
		handles = 68,

		/// <summary>
		/// 最大高度, 对应一个 javascript 数值.
		/// </summary>
		maxHeight = 69,

		/// <summary>
		/// 最大宽度, 对应一个 javascript 数值.
		/// </summary>
		maxWidth = 70,

		/// <summary>
		/// 最小高度, 对应一个 javascript 数值.
		/// </summary>
		minHeight = 71,

		/// <summary>
		/// 最小宽度, 对应一个 javascript 数值.
		/// </summary>
		minWidth = 72,

		/// <summary>
		/// 大小缩放时, 对应一个 javascript 函数.
		/// </summary>
		resize = 73,

		/// <summary>
		/// 是否使用文本, 对应一个 javascript 布尔值.
		/// </summary>
		text = 74,

		/// <summary>
		/// 图标, 对应一个 javascript 对象.
		/// </summary>
		icons = 75,

		/// <summary>
		/// 标签, 对应一个 javascript 字符串.
		/// </summary>
		label = 76,

		/// <summary>
		/// 激活的内容, 对应一个选择器, 元素, 数值或者布尔值.
		/// </summary>
		active = 77,

		/// <summary>
		/// 动画, 对应一个 javascript 字符串或者布尔值.
		/// </summary>
		animated = 78,

		/// <summary>
		/// 自动调整高度, 对应一个 javascript 布尔值.
		/// </summary>
		autoHeight = 79,

		/// <summary>
		/// 清除样式, 对应一个 javascript 布尔值.
		/// </summary>
		clearStyle = 80,

		/// <summary>
		/// 是否合并, 对应一个 javascript 布尔值.
		/// </summary>
		collapsible = 81,

		/// <summary>
		/// 触发的事件, 对应一个 javascript 字符串.
		/// </summary>
		@event = 82,

		/// <summary>
		/// 是否填充空白, 对应一个 javascript 布尔值.
		/// </summary>
		fillSpace = 83,

		/// <summary>
		/// 标题内容, 对应一个选择器或者 jQuery.
		/// </summary>
		header = 84,

		/// <summary>
		/// 是否导航, 对应一个 javascript 布尔值.
		/// </summary>
		navigation = 85,

		/// <summary>
		/// 导航过滤, 对应一个 javascript 函数.
		/// </summary>
		navigationFilter = 86,

		/// <summary>
		/// 改变开始时, 对应一个 javascript 函数.
		/// </summary>
		changestart = 87,

		/// <summary>
		/// 自动获得焦点, 对应一个 javascript 布尔值.
		/// </summary>
		autoFocus = 88,

		/// <summary>
		/// 最小长度, 对应一个 javascript 数值.
		/// </summary>
		minLength = 89,

		/// <summary>
		/// 位置, 对应一个 javascript 对象.
		/// </summary>
		position = 90,

		/// <summary>
		/// 源, 对应一个 javascript 字符串或者数组.
		/// </summary>
		source = 91,

		/// <summary>
		/// 搜索时, 对应一个 javascript 函数.
		/// </summary>
		search = 92,

		/// <summary>
		/// 打开时, 对应一个 javascript 函数.
		/// </summary>
		open = 93,

		/// <summary>
		/// 获得焦点时, 对应一个 javascript 函数.
		/// </summary>
		focus = 94,

		/// <summary>
		/// 选择时或者选中的, 对应一个 javascript 函数或者数组.
		/// </summary>
		select = 95,

		/// <summary>
		/// 关闭时, 对应一个 javascript 函数.
		/// </summary>
		close = 96,

		/// <summary>
		/// 进度值, 对应一个 javascript 数值.
		/// </summary>
		value = 97,

		/// <summary>
		/// 完成时, 对应一个 javascript 函数.
		/// </summary>
		complete = 98,

		/// <summary>
		/// 提示元素, 对应一个选择器或者元素.
		/// </summary>
		altField = 99,

		/// <summary>
		/// 提示的格式, 对应一个 javascript 字符串.
		/// </summary>
		altFormat = 100,

		/// <summary>
		/// 追加的文本, 对应一个 javascript 字符串.
		/// </summary>
		appendText = 101,

		/// <summary>
		/// 自动改变大小, 对应一个 javascript 布尔值.
		/// </summary>
		autoSize = 102,

		/// <summary>
		/// 按钮图片, 对应一个 javascript 字符串.
		/// </summary>
		buttonImage = 103,

		/// <summary>
		/// 只显示按钮图片, 对应一个 javascript 布尔值.
		/// </summary>
		buttonImageOnly = 104,

		/// <summary>
		/// 按钮文本, 对应一个 javascript 字符串.
		/// </summary>
		buttonText = 105,

		/// <summary>
		/// 如何计算周.
		/// </summary>
		calculateWeek = 106,

		/// <summary>
		/// 是否可以改变月份, 对应一个 javascript 布尔值.
		/// </summary>
		changeMonth = 107,

		/// <summary>
		/// 是否可以改变年份, 对应一个 javascript 布尔值.
		/// </summary>
		changeYear = 108,

		/// <summary>
		/// 关闭的文本, 对应一个 javascript 字符串.
		/// </summary>
		closeText = 109,

		/// <summary>
		/// 是否限制输入, 对应一个 javascript 布尔值.
		/// </summary>
		constrainInput = 110,

		/// <summary>
		/// 当前日期的显示文本, 对应一个 javascript 字符串.
		/// </summary>
		currentText = 111,

		/// <summary>
		/// 日期格式, 对应一个 javascript 字符串.
		/// </summary>
		dateFormat = 112,

		/// <summary>
		/// 星期的名称, 对应一个 javascript 数组.
		/// </summary>
		dayNames = 113,

		/// <summary>
		/// 星期的最短名称, 对应一个 javascript 数组.
		/// </summary>
		dayNamesMin = 114,

		/// <summary>
		/// 星期的短名称, 对应一个 javascript 数组.
		/// </summary>
		dayNamesShort = 115,

		/// <summary>
		/// 默认的日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		defaultDate = 116,

		/// <summary>
		/// 间隔, 对应一个 javascript 字符串.
		/// </summary>
		duration = 117,

		/// <summary>
		/// 一周开始的一天, 对应一个 javascript 数值.
		/// </summary>
		firstDay = 118,

		/// <summary>
		/// 是否当前时间为选中时间, 对应一个 javascript 布尔值.
		/// </summary>
		gotoCurrent = 119,

		/// <summary>
		/// 是否隐藏上一和下一按钮, 对应一个 javascript 布尔值.
		/// </summary>
		hideIfNoPrevNext = 120,

		/// <summary>
		/// 是否从右到左, 对应一个 javascript 布尔值.
		/// </summary>
		isRTL = 121,

		/// <summary>
		/// 最大日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		maxDate = 122,

		/// <summary>
		/// 最小日期, 对应一个 javascript 日期, 数字和字符串.
		/// </summary>
		minDate = 123,

		/// <summary>
		/// 月的名称, 对应一个 javascript 数组.
		/// </summary>
		monthNames = 124,

		/// <summary>
		/// 月的短名称, 对应一个 javascript 数组.
		/// </summary>
		monthNamesShort = 125,

		/// <summary>
		/// 导航应用日期格式, 对应一个 javascript 布尔值.
		/// </summary>
		navigationAsDateFormat = 126,

		/// <summary>
		/// 下一个的文本, 对应一个 javascript 字符串.
		/// </summary>
		nextText = 127,

		/// <summary>
		/// 显示的月数, 对应一个 javascript 数值.
		/// </summary>
		numberOfMonths = 128,

		/// <summary>
		/// 上一个的文本, 对应一个 javascript 字符串.
		/// </summary>
		prevText = 129,

		/// <summary>
		/// 是否可以选择其它月, 对应一个 javascript 布尔值.
		/// </summary>
		selectOtherMonths = 130,

		/// <summary>
		/// 尚不明确, 对应一个 javascript 字符串或者数值.
		/// </summary>
		shortYearCutoff = 131,

		/// <summary>
		/// 显示动画, 对应一个 javascript 字符串.
		/// </summary>
		showAnim = 132,

		/// <summary>
		/// 是否显示按钮栏, 对应一个 javascript 布尔值.
		/// </summary>
		showButtonPanel = 133,

		/// <summary>
		/// 当前月份显示的位置, 对应一个 javascript 数值.
		/// </summary>
		showCurrentAtPos = 134,

		/// <summary>
		/// 是否在年后显示月份, 对应一个 javascript 布尔值.
		/// </summary>
		showMonthAfterYear = 135,

		/// <summary>
		/// 是否显示按钮效果, 对应一个 javascript 字符串.
		/// </summary>
		showOn = 136,

		/// <summary>
		/// 显示的样式, 对应一个 javascript 对象.
		/// </summary>
		showOptions = 137,

		/// <summary>
		/// 是否显示其它月, 对应一个 javascript 布尔值.
		/// </summary>
		showOtherMonths = 138,

		/// <summary>
		/// 是否显示周, 对应一个 javascript 布尔值.
		/// </summary>
		showWeek = 139,

		/// <summary>
		/// 一次跳转的月份数, 对应一个 javascript 数值.
		/// </summary>
		stepMonths = 140,

		/// <summary>
		/// 周的标题, 对应一个 javascript 字符串.
		/// </summary>
		weekHeader = 141,

		/// <summary>
		/// 年的跨度, 对应一个 javascript 数值.
		/// </summary>
		yearRange = 142,

		/// <summary>
		/// 年份的附加标题, 对应一个 javascript 字符串.
		/// </summary>
		yearSuffix = 143,

		/// <summary>
		/// 显示之前, 对应一个 javascript 函数.
		/// </summary>
		beforeShow = 144,

		/// <summary>
		/// 显示日期之前, 对应一个 javascript 函数.
		/// </summary>
		beforeShowDay = 145,

		/// <summary>
		/// 改变月年时, 对应一个 javascript 函数.
		/// </summary>
		onChangeMonthYear = 146,

		/// <summary>
		/// 关闭时, 对应一个 javascript 函数.
		/// </summary>
		onClose = 147,

		/// <summary>
		/// 选择时, 对应一个 javascript 函数.
		/// </summary>
		onSelect = 148,

		/// <summary>
		/// 是否自动打开, 对应一个 javascript 布尔值.
		/// </summary>
		autoOpen = 149,

		/// <summary>
		/// 按钮, 对应一个 javascript 对象或者数组.
		/// </summary>
		buttons = 150,

		/// <summary>
		/// 是否按下 Esc 建关闭, 对应一个 javascript 布尔值.
		/// </summary>
		closeOnEscape = 151,

		/// <summary>
		/// 对话框的样式, 对应一个 javascript 字符串.
		/// </summary>
		dialogClass = 152,

		/// <summary>
		/// 是否允许拖动, 对应一个 javascript 布尔值.
		/// </summary>
		draggable = 153,

		/// <summary>
		/// 高度, 对应一个 javascript 数值.
		/// </summary>
		height = 154,

		/// <summary>
		/// 关闭时的效果, 对应一个 javascript 字符串.
		/// </summary>
		hide = 155,

		/// <summary>
		/// 是否使用 modal, 对应一个 javascript 布尔值.
		/// </summary>
		modal = 156,

		/// <summary>
		/// 是否可以缩放, 对应一个 javascript 布尔值.
		/// </summary>
		resizable = 157,

		/// <summary>
		/// 显示时的效果, 对应一个 javascript 字符串.
		/// </summary>
		show = 158,

		/// <summary>
		/// 标题, 对应一个 javascript 字符串.
		/// </summary>
		title = 161,

		/// <summary>
		/// 宽度, 对应一个 javascript 数值.
		/// </summary>
		width = 162,

		/// <summary>
		/// 关闭之前, 对应一个 javascript 函数.
		/// </summary>
		beforeClose = 163,

		/// <summary>
		/// 拖动开始, 对应一个 javascript 函数.
		/// </summary>
		dragStart = 164,

		/// <summary>
		/// 拖动停止, 对应一个 javascript 函数.
		/// </summary>
		dragStop = 165,

		/// <summary>
		/// 缩放开始, 对应一个 javascript 函数.
		/// </summary>
		resizeStart = 166,

		/// <summary>
		/// 缩放停止, 对应一个 javascript 函数.
		/// </summary>
		resizeStop = 166,

		/// <summary>
		/// 最大值, 对应一个 javascript 数值.
		/// </summary>
		max = 167,

		/// <summary>
		/// 最小值, 对应一个 javascript 数值.
		/// </summary>
		min = 168,

		/// <summary>
		/// 方向, 对应一个 javascript 字符串.
		/// </summary>
		orientation = 169,

		/// <summary>
		/// 使用范围, 对应一个 javascript 字符串或者布尔值.
		/// </summary>
		range = 170,

		/// <summary>
		/// 步长, 对应一个 javascript 数值.
		/// </summary>
		step = 171,

		/// <summary>
		/// 值, 对应一个 javascript 数组.
		/// </summary>
		values = 172,

		/// <summary>
		/// 滑动时, 对应一个 javascript 函数.
		/// </summary>
		slide = 173,

		/// <summary>
		/// Ajax 选项, 对应一个 javascript 对象.
		/// </summary>
		ajaxOptions = 174,

		/// <summary>
		/// 是否缓存, 对应一个 javascript 布尔值.
		/// </summary>
		cache = 175,

		/// <summary>
		/// Cookie, 对应一个 javascript 对象.
		/// </summary>
		cookie = 176,

		/// <summary>
		/// 应使用 collapsible.
		/// </summary>
		deselectable = 177,

		/// <summary>
		/// 效果, 对应一个 javascript 对象或者数组.
		/// </summary>
		fx = 179,

		/// <summary>
		/// id 前缀, 对应一个 javascript 字符串.
		/// </summary>
		idPrefix = 180,

		/// <summary>
		/// 面板模板, 对应一个 javascript 字符串.
		/// </summary>
		panelTemplate = 181,

		/// <summary>
		/// 载入条, 对应一个 javascript 字符串.
		/// </summary>
		spinner = 183,

		/// <summary>
		/// 标签模板, 对应一个 javascript 字符串.
		/// </summary>
		tabTemplate = 184,

		/// <summary>
		/// 载入时, 对应一个 javascript 函数.
		/// </summary>
		load = 185,
		
		/// <summary>
		/// 添加时, 对应一个 javascript 函数.
		/// </summary>
		add = 186,

		/// <summary>
		/// 可用时, 对应一个 javascript 函数.
		/// </summary>
		enable = 187,

		/// <summary>
		/// 禁用时, 对应一个 javascript 函数.
		/// </summary>
		disable = 188,
	}
	#endregion

	#region " Option "
	/// <summary>
	/// jQuery UI 的选项.
	/// </summary>
	public sealed class Option
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

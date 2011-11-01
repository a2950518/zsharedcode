/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
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

	#region " EventType "
	/// <summary>
	/// jQuery UI 的事件类型.
	/// </summary>
	public enum EventType
	{
		/// <summary>
		/// 没有任何事件.
		/// </summary>
		none,
		/// <summary>
		/// 完成时.
		/// </summary>
		complete,
		/// <summary>
		/// 出错时.
		/// </summary>
		error,
		/// <summary>
		/// 成功时.
		/// </summary>
		success,
		/// <summary>
		/// 点击时.
		/// </summary>
		click,
		/// <summary>
		/// 提交时.
		/// </summary>
		submit,
		/// <summary>
		/// 选中时.
		/// </summary>
		select,
		/// <summary>
		/// 滚动轴事件.
		/// </summary>
		scroll,
		/// <summary>
		/// document 准备好时.
		/// </summary>
		ready,
		/// <summary>
		/// 尺寸改变时.
		/// </summary>
		resize,
		/// <summary>
		/// 鼠标按下时.
		/// </summary>
		mousedown,
		/// <summary>
		/// 鼠标进入时.
		/// </summary>
		mouseenter,
		/// <summary>
		/// 鼠标离开时.
		/// </summary>
		mouseleave,
		/// <summary>
		/// 鼠标移动时.
		/// </summary>
		mousemove,
		/// <summary>
		/// 鼠标移出时.
		/// </summary>
		mouseout,
		/// <summary>
		/// 鼠标在其上时.
		/// </summary>
		mouseover,
		/// <summary>
		/// 鼠标松开时.
		/// </summary>
		mouseup,
		/// <summary>
		/// 载入时.
		/// </summary>
		load,
		/// <summary>
		/// 按键按下.
		/// </summary>
		keydown,
		/// <summary>
		/// 按键按住.
		/// </summary>
		keypress,
		/// <summary>
		/// 按键松开.
		/// </summary>
		keyup,
		/// <summary>
		/// 悬停.
		/// </summary>
		hover,
		/// <summary>
		/// 获得焦点.
		/// </summary>
		focus,
		/// <summary>
		/// 双击时.
		/// </summary>
		dblclick,
		/// <summary>
		/// 改变时.
		/// </summary>
		change,
		/// <summary>
		/// 失去焦点时.
		/// </summary>
		blur,
		/// <summary>
		/// 在定义后执行.
		/// </summary>
		__init,
		/// <summary>
		/// 开始时.
		/// </summary>
		start,
		/// <summary>
		/// 停止时.
		/// </summary>
		stop,
		/// <summary>
		/// 发送时.
		/// </summary>
		send,
		/// <summary>
		/// 按钮创建时.
		/// </summary>
		buttoncreate,
		/// <summary>
		/// 进度条创建时.
		/// </summary>
		progressbarcreate,
		/// <summary>
		/// 进度条改变时.
		/// </summary>
		progressbarchange,
		/// <summary>
		/// 进度条完成时.
		/// </summary>
		progressbarcomplete,
		/// <summary>
		/// 分组标签创建时.
		/// </summary>
		tabscreate,
		/// <summary>
		/// 分组标签选择时.
		/// </summary>
		tabsselect,
		/// <summary>
		/// 分组标签载入时.
		/// </summary>
		tabsload,
		/// <summary>
		/// 分组标签显示时.
		/// </summary>
		tabsshow,
		/// <summary>
		/// 分组标签添加时.
		/// </summary>
		tabsadd,
		/// <summary>
		/// 分组标签删除时.
		/// </summary>
		tabsremove,
		/// <summary>
		/// 分组标签可用时.
		/// </summary>
		tabsenable,
		/// <summary>
		/// 分组标签禁用时.
		/// </summary>
		tabsdisable,
		/// <summary>
		/// 对话框创建时.
		/// </summary>
		dialogcreate,
		/// <summary>
		/// 对话框关闭之前时.
		/// </summary>
		dialogbeforeclose,
		/// <summary>
		/// 对话框开始时.
		/// </summary>
		dialogopen,
		/// <summary>
		/// 对话框获得焦点时.
		/// </summary>
		dialogfocus,
		/// <summary>
		/// 对话框拖动开始时.
		/// </summary>
		dialogdragstart,
		/// <summary>
		/// 对话框拖动时.
		/// </summary>
		dialogdrag,
		/// <summary>
		/// 对话框拖动结束时.
		/// </summary>
		dialogdragstop,
		/// <summary>
		/// 对话框缩放开始时.
		/// </summary>
		dialogresizestart,
		/// <summary>
		/// 对话框缩放时.
		/// </summary>
		dialogresize,
		/// <summary>
		/// 对话框缩放结束时.
		/// </summary>
		dialogresizestop,
		/// <summary>
		/// 对话框关闭时.
		/// </summary>
		dialogclose,
		/// <summary>
		/// 分割条创建时.
		/// </summary>
		slidecreate,
		/// <summary>
		/// 分割条开始滑动时.
		/// </summary>
		slidestart,
		/// <summary>
		/// 分割条滑动时.
		/// </summary>
		slide,
		/// <summary>
		/// 分割条改变时.
		/// </summary>
		slidechange,
		/// <summary>
		/// 分割条停止滑动时.
		/// </summary>
		slidestop,
		/// <summary>
		/// 折叠列表创建时.
		/// </summary>
		accordioncreate,
		/// <summary>
		/// 折叠列表改变时.
		/// </summary>
		accordionchange,
		/// <summary>
		/// 折叠列表开始改变时.
		/// </summary>
		accordionchangestart,
		/// <summary>
		/// 日期框创建时.
		/// </summary>
		datepickercreate,
		/// <summary>
		/// 自动填充创建时.
		/// </summary>
		autocompletecreate,
		/// <summary>
		/// 自动填充搜索时.
		/// </summary>
		autocompletesearch,
		/// <summary>
		/// 自动填充打开时.
		/// </summary>
		autocompleteopen,
		/// <summary>
		/// 自动填充获得焦点时.
		/// </summary>
		autocompletefocus,
		/// <summary>
		/// 自动填充选择时时.
		/// </summary>
		autocompleteselect,
		/// <summary>
		/// 自动填充关闭时.
		/// </summary>
		autocompleteclose,
		/// <summary>
		/// 自动填充改变时.
		/// </summary>
		autocompletechange,


		/// <summary>
		/// 时钟触发时.
		/// </summary>
		tick,
		/// <summary>
		/// 移除.
		/// </summary>
		remove,
		/// <summary>
		/// 移除后.
		/// </summary>
		removed,
		/// <summary>
		/// 修改.
		/// </summary>
		update,
		/// <summary>
		/// 修改后.
		/// </summary>
		updated,
		/// <summary>
		/// 填充.
		/// </summary>
		fill,
		/// <summary>
		/// 填充后.
		/// </summary>
		filled,
		/// <summary>
		/// 添加.
		/// </summary>
		insert,
		/// <summary>
		/// 添加后.
		/// </summary>
		inserted,
		/// <summary>
		/// 自定义.
		/// </summary>
		custom,
		/// <summary>
		/// 自定义完成.
		/// </summary>
		customed,
		/// <summary>
		/// 检测时.
		/// </summary>
		check,
		/// <summary>
		/// 检测后.
		/// </summary>
		@checked,
	}
	#endregion

	#region " Event "
	/// <summary>
	/// jQuery UI 的事件.
	/// </summary>
	public sealed class Event
	{
		private EventType type;
		private string value;

		/// <summary>
		/// 获取或设置事件类型.
		/// </summary>
		public EventType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置事件内容.
		/// </summary>
		public string Value
		{
			get { return this.value; }
			set { this.value = ( null == value ? string.Empty : value ); }
		}

		/// <summary>
		/// 创建一个 jQuery UI 事件.
		/// </summary>
		public Event ( )
			: this ( EventType.none, null )
		{ }
		/// <summary>
		/// 创建一个 jQuery UI 事件.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <param name="value">事件内容.</param>
		public Event ( EventType type, string value )
		{
			this.type = type;

			this.Value = value;
		}

	}
	#endregion

}

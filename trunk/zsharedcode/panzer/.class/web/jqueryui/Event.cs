/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEvent
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIEventType
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

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
		none = 0,
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
	}
	#endregion

	#region " Event "
	/// <summary>
	/// jQuery UI 的事件.
	/// </summary>
	public sealed class Event
	{
		/// <summary>
		/// 事件类型.
		/// </summary>
		public readonly EventType Type;
		/// <summary>
		/// 事件内容.
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// 创建一个 jQuery UI 事件.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <param name="value">事件内容.</param>
		public Event ( EventType type, string value )
		{

			if ( null == value )
				value = string.Empty;

			this.Type = type;
			this.Value = value;
		}

	}
	#endregion

}

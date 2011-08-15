/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/WebPageCondition.cs
 * 版本: 1.2, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using zoyobar.shared.panzer.flow;

namespace zoyobar.shared.panzer.web.ib
{

	#region " WebPageNextStateSetting"
	/// <summary>
	/// 跳转状态设置.
	/// </summary>
	public sealed class WebPageNextStateSetting
		: NextStateSetting<WebPageAction, WebPageCondition>
	{

		/// <summary>
		/// 创建跳转状态设置.
		/// </summary>
		/// <param name="stateName">转到的状态的名称.</param>
		/// <param name="isAutoJump">是否跳自动转到下一状态.</param>
		public WebPageNextStateSetting ( string stateName, bool isAutoJump )
			: base ( stateName, isAutoJump )
		{ }

	}
	#endregion

	#region " WebPageState "
	/// <summary>
	/// 页面状态, IEBrowser 可以通过此状态控制浏览器.
	/// </summary>
	public sealed partial class WebPageState
		: FlowState<WebPageAction, WebPageCondition>
	{

		#region " ctor "

#if PARAM
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedAction">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">页面状态失败后的行为.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction[] startActions = null, WebPageAction completedAction = null, WebPageNextStateSetting completedStateSetting = null, WebPageAction failedAction = null, WebPageNextStateSetting failedStateSetting = null, WebPageCondition condition = null, int timeout = 0 )
			: this ( name, startActions, new WebPageAction[] { completedAction }, completedStateSetting, new WebPageAction[] { failedAction }, failedStateSetting, new WebPageCondition[] { condition }, 0 )
		{ }
#endif

#if PARAM
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedAction">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">页面状态失败后的行为.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction startAction = null, WebPageAction completedAction = null, WebPageNextStateSetting completedStateSetting = null, WebPageAction failedAction = null, WebPageNextStateSetting failedStateSetting = null, WebPageCondition condition = null, int timeout = 0 )
			: this ( name, new WebPageAction[] { startAction }, new WebPageAction[] { completedAction }, completedStateSetting, new WebPageAction[] { failedAction }, failedStateSetting, new WebPageCondition[] { condition }, 0 )
		{ }
#endif

#if PARAM
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedActions">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedActions">页面状态失败后的行为.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="conditions">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction[] startActions = null, WebPageAction[] completedActions = null, WebPageNextStateSetting completedStateSetting = null, WebPageAction[] failedActions = null, WebPageNextStateSetting failedStateSetting = null, WebPageCondition[] conditions = null, int timeout = 0 )
#else
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedActions">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedActions">页面状态失败后的行为.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="conditions">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageAction[] completedActions, WebPageNextStateSetting completedStateSetting, WebPageAction[] failedActions, WebPageNextStateSetting failedStateSetting, WebPageCondition[] conditions, int timeout )
#endif
			: base ( name, startActions, completedActions, completedStateSetting, failedActions, failedStateSetting, conditions, timeout )
		{ }
		#endregion

	}

	partial class WebPageState
	{
#if !PARAM
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		public WebPageState ( string name, WebPageAction[] startActions )
			: this ( name, startActions, null, null, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		public WebPageState ( string name, WebPageAction startAction )
			: this ( name, new WebPageAction[] { startAction }, null, null, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">页面状态失败后的行为.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageNextStateSetting completedStateSetting, WebPageAction failedAction, WebPageCondition condition, int timeout )
			: this ( name, null, null, completedStateSetting, new WebPageAction[] { failedAction }, null, new WebPageCondition[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageCondition condition, int timeout )
			: this ( name, new WebPageAction[] { startAction }, null, null, null, null, new WebPageCondition[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageNextStateSetting completedStateSetting, WebPageCondition condition )
			: this ( name, startActions, null, completedStateSetting, null, null, new WebPageCondition[] { condition }, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageNextStateSetting completedStateSetting, WebPageNextStateSetting failedStateSetting, WebPageCondition condition, int timeout )
			: this ( name, startActions, null, completedStateSetting, null, failedStateSetting, new WebPageCondition[] { condition }, timeout )
		{ }

		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting, WebPageNextStateSetting failedStateSetting, int timeout )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, failedStateSetting, null, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageNextStateSetting completedStateSetting, WebPageNextStateSetting failedStateSetting, WebPageCondition condition, int timeout )
			: this ( name, null, null, completedStateSetting, null, failedStateSetting, new WebPageCondition[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">页面状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting, WebPageNextStateSetting failedStateSetting, WebPageCondition condition, int timeout )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, failedStateSetting, new WebPageCondition[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startAction">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此页面状态的条件.</param>
		public WebPageState ( string name, WebPageAction startAction, WebPageNextStateSetting completedStateSetting, WebPageCondition condition )
			: this ( name, new WebPageAction[] { startAction }, null, completedStateSetting, null, null, new WebPageCondition[] { condition }, 0 )
		{ }

		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageNextStateSetting completedStateSetting )
			: this ( name, startActions, null, completedStateSetting, null, null, null, 0 )
		{ }

		/// <summary>
		/// 创建一个页面状态.
		/// </summary>
		/// <param name="name">页面状态的名称.</param>
		/// <param name="startActions">开始时的行为.</param>
		/// <param name="completedActions">页面状态完成后的行为.</param>
		/// <param name="completedStateSetting">页面状态完成后会转到的状态的名称.</param>
		/// <param name="conditions">成此页面状态的条件.</param>
		public WebPageState ( string name, WebPageAction[] startActions, WebPageAction[] completedActions, WebPageNextStateSetting completedStateSetting, WebPageCondition[] conditions )
			: this ( name, startActions, completedActions, completedStateSetting, null, null, conditions, 0 )
		{ }
#endif
	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/flow/Flow.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

// HACK: 避免在 allinone 文件中的名称冲突
using NTimer = System.Windows.Forms.Timer;

namespace zoyobar.shared.panzer.flow
{

	/// <summary>
	/// 剩余等待时间改变时.
	/// </summary>
	/// <param name="remainSecond">所剩的秒数.</param>
	public delegate void RemainWaitTimeChangedEventHandler ( int remainSecond );

	/// <summary>
	/// 状态改变时.
	/// </summary>
	/// <param name="state">改变的状态.</param>
	/// <param name="isStop">是否停止状态的自动跳转, 默认为 false.</param>
	/// <typeparam name="A">行为类型.</typeparam>
	/// <typeparam name="C">条件类型.</typeparam>
	public delegate void StateChangedEventHandler<A, C> ( FlowState<A, C> state, ref bool isStop )
		where A : FlowAction
		where C : FlowCondition;

	/// <summary>
	/// 当一个条件完成时.
	/// </summary>
	/// <param name="condition">完成的条件.</param>
	/// <param name="conditionCount">条件总数.</param>
	/// <param name="completedConditionCount">已经完成的条件个数.</param>
	public delegate void ConditionCompletedEventHandler<C> ( C condition, int conditionCount, int completedConditionCount )
		where C : FlowCondition;

	#region " FlowAction "
	/// <summary>
	/// 流程的某个环节执行的行为.
	/// </summary>
	public abstract class FlowAction
	{
		/// <summary>
		/// 行为执行后等待的时间.
		/// </summary>
		public readonly int WaitSecond;

		protected FlowAction ( int waitSecond )
		{

			if ( waitSecond < 0 )
				waitSecond = 0;

			this.WaitSecond = waitSecond;
		}

	}
	#endregion

	#region " FlowCondition "
	/// <summary>
	/// 判断状态是否成功的条件.
	/// </summary>
	public abstract class FlowCondition : IComparable
	{
		/// <summary>
		/// 条件的名称.
		/// </summary>
		public readonly string Name;

		protected FlowCondition ( string name )
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", "名称不能为空" );

			this.Name = name;
		}

		/// <summary>
		/// 比较两个条件.
		/// </summary>
		/// <param name="obj">被对比的地址条件.</param>
		/// <returns>对比后的值.</returns>
		int IComparable.CompareTo ( object obj )
		{

			if ( !( obj is FlowCondition ) )
				return 1;

			return this.Name.CompareTo ( ( ( FlowCondition ) obj ).Name );
		}

	}
	#endregion

	#region " NextStateSetting "
	/// <summary>
	/// 跳转状态设置.
	/// </summary>
	/// <typeparam name="A">行为类型.</typeparam>
	/// <typeparam name="C">条件类型.</typeparam>
	public class NextStateSetting<A, C>
		where A : FlowAction
		where C : FlowCondition
	{
		/// <summary>
		/// 转到的状态的名称.
		/// </summary>
		public readonly string StateName;
		/// <summary>
		/// 转到的状态.
		/// </summary>
		public FlowState<A, C> State;

		/// <summary>
		/// 是否跳自动转到下一状态.
		/// </summary>
		public readonly bool IsAutoJump;

		/// <summary>
		/// 创建跳转状态设置.
		/// </summary>
		/// <param name="stateName">转到的状态的名称.</param>
		/// <param name="isAutoJump">是否跳自动转到下一状态.</param>
		public NextStateSetting ( string stateName, bool isAutoJump )
		{

			if ( string.IsNullOrEmpty ( stateName ) )
				throw new ArgumentNullException ( "stateName", "转到的状态的名称不能为空" );

			this.StateName = stateName;
			this.IsAutoJump = isAutoJump;
		}

	}
	#endregion

	#region " FlowState "
	/// <summary>
	/// 流程中的某个状态.
	/// </summary>
	/// <typeparam name="A">行为类型.</typeparam>
	/// <typeparam name="C">条件类型.</typeparam>
	public partial class FlowState<A, C>
		where A : FlowAction
		where C : FlowCondition
	{
		/// <summary>
		/// 状态的名称.
		/// </summary>
		public readonly string Name;
		/// <summary>
		/// 状态开始时的行为.
		/// </summary>
		public readonly List<A> StartActions = new List<A> ( );
		/// <summary>
		/// 状态完成后的行为.
		/// </summary>
		public readonly List<A> CompletedActions = new List<A> ( );
		/// <summary>
		/// 状态失败后的行为.
		/// </summary>
		public readonly List<A> FailedActions = new List<A> ( );

		/// <summary>
		/// 完成跳转的状态的设置.
		/// </summary>
		public readonly NextStateSetting<A, C> CompletedStateSetting;
		/// <summary>
		/// 失败跳转的状态的设置.
		/// </summary>
		public readonly NextStateSetting<A, C> FailedStateSetting;

		/// <summary>
		/// 完成此状态的条件.
		/// </summary>
		public readonly SortedList<C, bool> Conditions = new SortedList<C, bool> ( );

		/// <summary>
		/// 超时秒数.
		/// </summary>
		public readonly int Timeout;

		/// <summary>
		/// 获取已经完成的条件个数.
		/// </summary>
		public int CompletedConditionCount
		{
			get
			{
				int count = 0;

				foreach ( bool value in this.Conditions.Values )
					if ( value )
						count++;

				return count;
			}
		}

		/// <summary>
		/// 获取状态完成后是否有转到的状态.
		/// </summary>
		public bool IsCompletedStateEmpty
		{
			get { return ( null == this.CompletedStateSetting ) || ( null == this.CompletedStateSetting.State ); }
		}

		/// <summary>
		/// 获取状态失败后是否有转到的状态.
		/// </summary>
		public bool IsFailedStateEmpty
		{
			get { return ( null == this.FailedStateSetting ) || ( null == this.FailedStateSetting.State ); }
		}

		#region " ctor "

#if PARAM
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedAction">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A[] startActions = null, A completedAction = null, NextStateSetting<A, C> completedStateSetting = null, A failedAction = null, NextStateSetting<A, C> failedStateSetting = null, C condition = null, int timeout = 0 )
			: this ( name, startActions, new A[] { completedAction }, completedStateSetting, new A[] { failedAction }, failedStateSetting, new C[] { condition }, timeout )
		{ }
#endif

#if PARAM
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedAction">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction = null, A completedAction = null, NextStateSetting<A, C> completedStateSetting = null, A failedAction = null, NextStateSetting<A, C> failedStateSetting = null, C condition = null, int timeout = 0 )
#else
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedAction">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction, A completedAction, NextStateSetting<A, C> completedStateSetting, A failedAction, NextStateSetting<A, C> failedStateSetting, C condition, int timeout )
#endif
			: this ( name, new A[] { startAction }, new A[] { completedAction }, completedStateSetting, new A[] { failedAction }, failedStateSetting, new C[] { condition }, timeout )
		{ }

#if PARAM
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedActions">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedActions">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="conditions">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A[] startActions = null, A[] completedActions = null, NextStateSetting<A, C> completedStateSetting = null, A[] failedActions = null, NextStateSetting<A, C> failedStateSetting = null, C[] conditions = null, int timeout = 0 )
#else
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedActions">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedActions">状态失败后的行为.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="conditions">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A[] startActions, A[] completedActions, NextStateSetting<A, C> completedStateSetting, A[] failedActions, NextStateSetting<A, C> failedStateSetting, C[] conditions, int timeout )
#endif
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", "状态的名称不能为空" );

			if ( null != startActions )
				foreach ( A action in startActions )
					if ( null != action )
						this.StartActions.Add ( action );

			if ( null != completedActions )
				foreach ( A action in completedActions )
					if ( null != action )
						this.CompletedActions.Add ( action );

			if ( null != failedActions )
				foreach ( A action in failedActions )
					if ( null != action )
						this.FailedActions.Add ( action );

			if ( null != conditions )
				foreach ( C condition in conditions )
					if ( null != condition )
						this.Conditions.Add ( condition, false );

			if ( timeout < 0 )
				timeout = 0;

			this.Name = name;
			this.CompletedStateSetting = completedStateSetting;
			this.FailedStateSetting = failedStateSetting;
			this.Timeout = timeout;
		}
		#endregion

	}

	partial class FlowState<A, C>
	{
#if !PARAM
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		public FlowState ( string name, A[] startActions, NextStateSetting<A, C> completedStateSetting, C condition )
			: this ( name, startActions, null, completedStateSetting, null, null, new C[] { condition }, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A[] startActions, NextStateSetting<A, C> completedStateSetting, NextStateSetting<A, C> failedStateSetting, C condition, int timeout )
			: this ( name, startActions, null, completedStateSetting, null, failedStateSetting, new C[] { condition }, timeout )
		{ }

		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		public FlowState ( string name, A startAction )
			: this ( name, new A[] { startAction }, null, null, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedAction">状态失败后的行为.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, NextStateSetting<A, C> completedStateSetting, A failedAction, C condition, int timeout )
			: this ( name, null, null, completedStateSetting, new A[] { failedAction }, null, new C[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction, C condition, int timeout )
			: this ( name, new A[] { startAction }, null, null, null, null, new C[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		public FlowState ( string name, A startAction, NextStateSetting<A, C> completedStateSetting )
			: this ( name, new A[] { startAction }, null, completedStateSetting, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction, NextStateSetting<A, C> completedStateSetting, NextStateSetting<A, C> failedStateSetting, int timeout )
			: this ( name, new A[] { startAction }, null, completedStateSetting, null, failedStateSetting, null, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, NextStateSetting<A, C> completedStateSetting, NextStateSetting<A, C> failedStateSetting, C condition, int timeout )
			: this ( name, null, null, completedStateSetting, null, failedStateSetting, new C[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="failedStateSetting">状态失败后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		/// <param name="timeout">超时秒数.</param>
		public FlowState ( string name, A startAction, NextStateSetting<A, C> completedStateSetting, NextStateSetting<A, C> failedStateSetting, C condition, int timeout )
			: this ( name, new A[] { startAction }, null, completedStateSetting, null, failedStateSetting, new C[] { condition }, timeout )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startAction">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="condition">成此状态的条件.</param>
		public FlowState ( string name, A startAction, NextStateSetting<A, C> completedStateSetting, C condition )
			: this ( name, new A[] { startAction }, null, completedStateSetting, null, null, new C[] { condition }, 0 )
		{ }

		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		public FlowState ( string name, A[] startActions )
			: this ( name, startActions, null, null, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		public FlowState ( string name, A[] startActions, NextStateSetting<A, C> completedStateSetting )
			: this ( name, startActions, null, completedStateSetting, null, null, null, 0 )
		{ }
		/// <summary>
		/// 创建一个状态.
		/// </summary>
		/// <param name="name">状态的名称.</param>
		/// <param name="startActions">地址跳转行为.</param>
		/// <param name="completedActions">状态完成后的行为.</param>
		/// <param name="completedStateSetting">状态完成后会转到的状态的名称.</param>
		/// <param name="conditions">成此状态的条件.</param>
		public FlowState ( string name, A[] startActions, A[] completedActions, NextStateSetting<A, C> completedStateSetting, C[] conditions )
			: this ( name, startActions, completedActions, completedStateSetting, null, null, conditions, 0 )
		{ }
#endif
	}

	#endregion

	#region " Flow "
	/// <summary>
	/// 流程类, 包含了多个状态, 可以控制状态之间的跳转.
	/// </summary>
	/// <typeparam name="A">行为类型.</typeparam>
	/// <typeparam name="C">条件类型.</typeparam>
	public abstract partial class Flow<A, C>
		where A : FlowAction
		where C : FlowCondition
	{

		/// <summary>
		/// 剩余等待时间改变时.
		/// </summary>
		public event RemainWaitTimeChangedEventHandler RemainWaitTimeChanged;

		/// <summary>
		/// 状态完成时.
		/// </summary>
		public event StateChangedEventHandler<A, C> StateCompleted;

		/// <summary>
		/// 状态失败时.
		/// </summary>
		public event StateChangedEventHandler<A, C> StateFailed;

		/// <summary>
		/// 当一个条件完成时.
		/// </summary>
		public event ConditionCompletedEventHandler<C> ConditionCompleted;

		private readonly SortedList<string, FlowState<A, C>> states = new SortedList<string, FlowState<A, C>> ( );
		private FlowState<A, C> currentState;

		private NTimer checkStateTimer = new NTimer ( );
		private NTimer checkTimeoutTimer = new NTimer ( );
		private bool checkStateTimerLocker;
		private bool checkTimeoutTimerLocker;

		/// <summary>
		/// 创建一个流程类.
		/// </summary>
		/// <param name="states">状态数组.</param>
		public Flow ( FlowState<A, C>[] states )
		{

			if ( null != states )
			{

				foreach ( FlowState<A, C> state in states )
					if ( null != state && !this.states.ContainsKey ( state.Name ) )
						this.states.Add ( state.Name, state );

				foreach ( FlowState<A, C> state in this.states.Values )
				{

					if ( null != state.CompletedStateSetting && !string.IsNullOrEmpty ( state.CompletedStateSetting.StateName ) && this.states.ContainsKey ( state.CompletedStateSetting.StateName ) )
						state.CompletedStateSetting.State = this.states[state.CompletedStateSetting.StateName];

					if ( null != state.FailedStateSetting && !string.IsNullOrEmpty ( state.FailedStateSetting.StateName ) && this.states.ContainsKey ( state.FailedStateSetting.StateName ) )
						state.FailedStateSetting.State = this.states[state.FailedStateSetting.StateName];

				}

			}

			this.checkStateTimer.Enabled = false;
			this.checkTimeoutTimer.Enabled = false;
			this.checkStateTimer.Tick += new EventHandler ( this.checkState );
			this.checkTimeoutTimer.Tick += new EventHandler ( this.checkTimeout );
		}

#if PARAM
		/// <summary>
		/// 等待条件的成立, 如果指定时间内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="condition">等待成立的条件.</param>
		/// <param name="second">等待的秒数, 默认 60 秒.</param>
		public void Wait ( C condition, int second = 60 )
#else
		/// <summary>
		/// 等待条件的成立, 如果指定时间内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="condition">等待成立的条件.</param>
		/// <param name="second">等待的秒数.</param>
		public void Wait ( C condition, int second )
#endif
		{ this.Wait ( second, new C[] { condition } ); }

#if PARAM
		/// <summary>
		/// 等待条件的成立, 如果指定时间内没有成立则, 抛出异常. 如果没有指定条件, 则只等待指定的时间, 不抛出异常.
		/// </summary>
		/// <param name="second">等待的秒数, 默认 60 秒.</param>
		/// <param name="conditions">等待成立的条件.</param>
		public void Wait ( int second = 60, C[] conditions = null )
#else
		/// <summary>
		/// 等待条件的成立, 如果指定时间内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="second">等待的秒数.</param>
		/// <param name="conditions">等待成立的条件.</param>
		public void Wait ( int second, C[] conditions )
#endif
		{

			if ( second <= 0 )
				return;

			int time = Environment.TickCount + ( second * 1000 );
			int oldRemainSecond = -1;

			while ( true )
			{
				int remainSecond = ( int ) ( ( time - Environment.TickCount ) / 1000 ) + 1;

				if ( oldRemainSecond == -1 || oldRemainSecond != remainSecond )
				{
					oldRemainSecond = remainSecond;

					if ( null != this.RemainWaitTimeChanged )
						this.RemainWaitTimeChanged ( remainSecond );

				}

				Application.DoEvents ( );
				Thread.Sleep ( 100 );

				if ( null != conditions )
				{
					bool isSuccess = true;

					foreach ( C condition in conditions )
						if ( !this.CheckState ( condition ) )
						{
							isSuccess = false;
							break;
						}

					if ( isSuccess )
						break;

				}

				if ( remainSecond <= 0 )
					if ( null == conditions )
						break;
					else
						throw new TimeoutException ( string.Format ( "在 {0} 秒内条件没有达成", second ) );

			}

		}

		private FlowState<A, C> getCompletedState ( )
		{

			if ( null != this.currentState && !this.currentState.Conditions.ContainsValue ( false ) )
				return this.currentState;

			return null;
		}

		protected abstract void executeAction ( A action );

		private void executeAction ( List<A> actions )
		{

			if ( null == actions )
				return;

			foreach ( A action in actions )
			{
				this.executeAction ( action );

				this.Wait ( action.WaitSecond );
			}

		}

		/// <summary>
		/// 停止状态的跳转.
		/// </summary>
		public virtual void StopJump ( )
		{
			this.currentState = null;
			this.checkStateTimer.Enabled = false;
			this.checkTimeoutTimer.Enabled = false;

			this.checkStateTimerLocker = false;
			this.checkTimeoutTimerLocker = false;
		}

		private void jumpToState ( FlowState<A, C> state )
		{

			if ( null == state )
				return;

			this.StopJump ( );
			this.currentState = state;

#if TRACE
			Console.WriteLine ( string.Format ( "jump to: <{0}>", state.Name ) );
#endif

			for ( int index = 0; index < state.Conditions.Count; index++ )
				state.Conditions[state.Conditions.Keys[index]] = false;

			this.executeAction ( state.StartActions );

			this.checkStateTimer.Interval = 1000;
			this.checkStateTimer.Enabled = true;

			if ( state.Timeout != 0 )
			{
				this.checkTimeoutTimer.Interval = state.Timeout * 1000;
				this.checkTimeoutTimer.Enabled = true;
			}

		}

		/// <summary>
		/// 跳转到指定的状态, 这些状态在声明时定义.
		/// </summary>
		/// <param name="stateName">状态的名称.</param>
		public void JumpToState ( string stateName )
		{

			if ( string.IsNullOrEmpty ( stateName ) || !this.states.ContainsKey ( stateName ) )
				return;

			this.jumpToState ( this.states[stateName] );
		}

		/// <summary>
		/// 检测某个条件是否成立.
		/// </summary>
		/// <param name="condition">检测的条件.</param>
		/// <returns>是否成立.</returns>
		public abstract bool CheckState ( C condition );

		private void checkState ( object sender, EventArgs e )
		{

			if ( this.checkStateTimerLocker )
				return;

			this.checkStateTimerLocker = true;

			try
			{

				if ( null == this.currentState )
					return;

#if TRACE
				Console.WriteLine ( string.Format ( "check state: <{0}>", this.currentState.Name ) );
#endif

				#region " 测试条件 "
				for ( int index = 0; index < this.currentState.Conditions.Count; index++ )
				{
					C condition = this.currentState.Conditions.Keys[index];

					if ( this.currentState.Conditions[condition] )
						continue;

					this.currentState.Conditions[condition] = this.CheckState ( condition );

					if ( this.currentState.Conditions[condition] && null != this.ConditionCompleted )
					{
#if TRACE
						Console.WriteLine ( string.Format ( "\tok condition: {0}", condition.Name ) );
#endif
						this.ConditionCompleted ( condition, this.currentState.Conditions.Count, this.currentState.CompletedConditionCount );
					}

				}
				#endregion

				FlowState<A, C> completedState = this.getCompletedState ( );

				if ( null == completedState )
					return;
#if TRACE
				Console.WriteLine ( string.Format ( "completed state: <{0}>", completedState.Name ) );
#endif

				this.executeAction ( completedState.CompletedActions );

				bool isStop = false;

				if ( null != this.StateCompleted )
					this.StateCompleted ( completedState, ref isStop );

				if ( isStop || completedState.IsCompletedStateEmpty || !completedState.CompletedStateSetting.IsAutoJump )
					this.StopJump ( );
				else
					this.jumpToState ( completedState.CompletedStateSetting.State );

			}
			catch ( Exception err )
			{ Console.WriteLine ( err.Message ); }
			finally
			{ this.checkStateTimerLocker = false; }

		}

		private void checkTimeout ( object sender, EventArgs e )
		{

			if ( this.checkTimeoutTimerLocker )
				return;

			this.checkTimeoutTimerLocker = true;

			try
			{

				if ( null == this.currentState )
					return;

#if TRACE
				Console.WriteLine ( string.Format ( "timeout: <{0}>", this.currentState.Name ) );
#endif

				this.executeAction ( this.currentState.FailedActions );

				bool isStop = false;

				if ( null != this.StateFailed )
					this.StateFailed ( this.currentState, ref isStop );

				if ( isStop || this.currentState.IsFailedStateEmpty || !this.currentState.FailedStateSetting.IsAutoJump )
					this.StopJump ( );
				else
					this.jumpToState ( this.currentState.FailedStateSetting.State );

			}
			catch ( Exception err )
			{ Console.WriteLine ( err.Message ); }
			finally
			{ this.checkTimeoutTimerLocker = false; }

		}

	}

	partial class Flow<A, C>
	{

#if !PARAM
		/// <summary>
		/// 等待条件的成立, 如果 60 秒内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="conditions">等待成立的条件.</param>
		public void Wait ( C[] conditions )
		{ this.Wait ( 60, conditions ); }
		/// <summary>
		/// 等待指定时间.
		/// </summary>
		/// <param name="second">等待的秒数.</param>
		public void Wait ( int second )
		{ this.Wait ( second, null ); }

		/// <summary>
		/// 等待条件的成立, 如果 60 秒内没有成立则, 抛出异常.
		/// </summary>
		/// <param name="condition">等待成立的条件.</param>
		public void Wait ( C condition )
		{ this.Wait ( condition, 60 ); }
#endif

	}

	#endregion

}

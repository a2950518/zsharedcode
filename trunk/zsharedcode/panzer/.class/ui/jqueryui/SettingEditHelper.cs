/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUISettingEditHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SettingEditHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs

 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.Collections.Generic;
using System.Web.UI;

using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 编辑 OptionEdit, EventEdit 的辅助类.
	/// </summary>
	public sealed class SettingEditHelper
		: IStateManager
	{
		/// <summary>
		/// 内部的 OptionEdit 集合.
		/// </summary>
		public readonly List<OptionEdit> InnerOptionEdits = new List<OptionEdit> ( );
		/// <summary>
		/// 内部的 EventEdit 集合.
		/// </summary>
		public readonly List<EventEdit> InnerEventEdits = new List<EventEdit> ( );
		/// <summary>
		/// 外部的 OptionEdit 集合.
		/// </summary>
		public readonly List<OptionEdit> OuterOptionEdits = new List<OptionEdit> ( );
		/// <summary>
		/// 外部的 EventEdit 集合.
		/// </summary>
		public readonly List<EventEdit> OuterEventEdits = new List<EventEdit> ( );

		/// <summary>
		/// 创建对应的 Option 数组.
		/// </summary>
		/// <returns>Option 数组</returns>
		public Option[] CreateOptions ( )
		{
			List<Option> options = new List<Option> ( );

			foreach ( OptionEdit edit in this.InnerOptionEdits )
				options.Add ( edit.CreateOption ( ) );

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				options.Add ( edit.CreateOption ( ) );

			return options.ToArray ( );
		}

		/// <summary>
		/// 创建对应的 Event 数组.
		/// </summary>
		/// <returns>Event 数组</returns>
		public Event[] CreateEvents ( )
		{
			List<Event> events = new List<Event> ( );

			foreach ( EventEdit edit in this.OuterEventEdits )
				events.Add ( edit.CreateEvent ( ) );

			foreach ( EventEdit edit in this.InnerEventEdits )
				events.Add ( edit.CreateEvent ( ) );

			return events.ToArray ( );
		}

		/// <summary>
		/// 得到外部 OptionEdit 的值.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <returns>选项值.</returns>
		public string GetOuterOptionEditValue ( OptionType type )
		{

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				if ( edit.Type == type )
					return edit.Value;

			return string.Empty;
		}

		/// <summary>
		/// 设置外部 OptionEdit 的值.
		/// </summary>
		/// <param name="type">选项类型.</param>
		/// <param name="value">选项值.</param>
		public void SetOuterOptionEditValue ( OptionType type, string value )
		{

			if ( null == value )
				return;

			bool isExist = false;

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				if ( edit.Type == type )
				{
					edit.Value = value;
					isExist = true;
				}

			if ( !isExist )
			{
				OptionEdit edit = new OptionEdit ( );
				edit.Type = type;
				edit.Value = value;

				this.OuterOptionEdits.Add ( edit );
			}

		}

		/// <summary>
		/// 得到外部 EventEdit 的值.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <returns>事件值.</returns>
		public string GetOuterEventEditValue ( EventType type )
		{

			foreach ( EventEdit edit in this.OuterEventEdits )
				if ( edit.Type == type )
					return edit.Value;

			return string.Empty;
		}

		/// <summary>
		/// 设置外部 EventEdit 的值.
		/// </summary>
		/// <param name="type">事件类型.</param>
		/// <param name="value">事件值.</param>
		public void SetOuterEventEditValue ( EventType type, string value )
		{

			if ( null == value )
				return;

			bool isExist = false;

			foreach ( EventEdit edit in this.OuterEventEdits )
				if ( edit.Type == type )
				{
					edit.Value = value;
					break;
				}

			if ( !isExist )
			{
				EventEdit edit = new EventEdit ( );
				edit.Type = type;
				edit.Value = value;

				this.OuterEventEdits.Add ( edit );
			}

		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>字符串</returns>
		public override string ToString ( )
		{
			string optionExpression = string.Empty;

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				if ( edit.Value != string.Empty )
					optionExpression += string.Format ( "{0}={1}`;", edit.Type, edit.Value );

			optionExpression = "{" + optionExpression + "}`;";

			string eventExpression = string.Empty;

			foreach ( EventEdit edit in this.OuterEventEdits )
				if ( edit.Value != string.Empty )
					eventExpression += string.Format ( "{0}={1}`;", edit.Type, edit.Value );

			eventExpression = "{" + eventExpression + "}`;";

			return optionExpression + eventExpression;
		}

		/// <summary>
		/// 从字符串转化.
		/// </summary>
		/// <param name="expression">字符串.</param>
		public void FromString ( string expression )
		{

			if ( string.IsNullOrEmpty ( expression ) )
				return;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );


			if ( expressionHelper.ChildCount == 2 )
			{
				this.OuterOptionEdits.Clear ( );

				for ( int index = 0; index < expressionHelper[0].ChildCount; index++ )
				{
					string[] parts = expressionHelper[0][index].Value.Split ( '=' );

					if ( parts.Length != 2 || parts[1] == string.Empty )
						continue;

					try
					{ this.SetOuterOptionEditValue ( ( OptionType ) Enum.Parse ( typeof ( OptionType ), parts[0] ), parts[1] ); }
					catch { }

				}

				this.OuterEventEdits.Clear ( );

				for ( int index = 0; index < expressionHelper[1].ChildCount; index++ )
				{
					string[] parts = expressionHelper[1][index].Value.Split ( '=' );

					if ( parts.Length != 2 || parts[1] == string.Empty )
						continue;

					try
					{ this.SetOuterEventEditValue ( ( EventType ) Enum.Parse ( typeof ( EventType ), parts[0] ), parts[1] ); }
					catch { }

				}

			}

		}

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{
			List<object> states = state as List<object>;

			if ( null == states )
				return;

			if ( states.Count >= 1 )
			{
				List<object> optionStates = states[0] as List<object>;

				if ( null != optionStates )
					for ( int index = 0; index < this.InnerOptionEdits.Count; index++ )
						if ( index < optionStates.Count )
							( this.InnerOptionEdits[index] as IStateManager ).LoadViewState ( optionStates[index] );
						else
							break;

			}

			if ( states.Count >= 2 )
			{
				List<object> eventStates = states[1] as List<object>;

				if ( null != eventStates )
					for ( int index = 0; index < this.InnerEventEdits.Count; index++ )
						if ( index < eventStates.Count )
							( this.InnerEventEdits[index] as IStateManager ).LoadViewState ( eventStates[index] );
						else
							break;

			}

			if ( states.Count >= 3 )
			{
				List<object> optionStates = states[2] as List<object>;

				if ( null != optionStates )
					for ( int index = 0; index < this.OuterOptionEdits.Count; index++ )
						if ( index < optionStates.Count )
							( this.OuterOptionEdits[index] as IStateManager ).LoadViewState ( optionStates[index] );
						else
							break;

			}

			if ( states.Count >= 4 )
			{
				List<object> eventStates = states[3] as List<object>;

				if ( null != eventStates )
					for ( int index = 0; index < this.OuterEventEdits.Count; index++ )
						if ( index < eventStates.Count )
							( this.OuterEventEdits[index] as IStateManager ).LoadViewState ( eventStates[index] );
						else
							break;

			}

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );

			List<object> optionStates = new List<object> ( );

			foreach ( OptionEdit edit in this.InnerOptionEdits )
				optionStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( optionStates );

			List<object> eventStates = new List<object> ( );

			foreach ( EventEdit edit in this.InnerEventEdits )
				eventStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( eventStates );

			optionStates = new List<object> ( );

			foreach ( OptionEdit edit in this.OuterOptionEdits )
				optionStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( optionStates );

			eventStates = new List<object> ( );

			foreach ( EventEdit edit in this.OuterEventEdits )
				eventStates.Add ( ( edit as IStateManager ).SaveViewState ( ) );

			states.Add ( eventStates );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}

}

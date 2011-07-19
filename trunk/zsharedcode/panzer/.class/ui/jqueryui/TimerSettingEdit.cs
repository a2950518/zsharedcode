/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITimerSettingEdit
 * http://code.google.com/p/zsharedcode/wiki/JQueryUITimerSettingEditConverter
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/TimerSettingEdit.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

// HACK: 避免在 allinone 文件中的名称冲突

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " TimerSettingEdit "
	/// <summary>
	/// jQuery UI Timer 的相关设置.
	/// </summary>
	[TypeConverter ( typeof ( TimerSettingEditConverter ) )]
	[ParseChildren ( true )]
	[PersistChildren ( false )]
	public sealed class TimerSettingEdit
		: IStateManager
	{
		private readonly AjaxSettingEdit tickAjax = new AjaxSettingEdit ( );
		private string tick = string.Empty;
		private int interval = 100;

		private bool isTimable = false;

		/// <summary>
		/// 获取或设置是否可以使用 Timer.
		/// </summary>
		[Category ( "jQuery UI" )]
		[DefaultValue ( false )]
		[Description ( "指示 Timer 是否可用" )]
		[NotifyParentProperty ( true )]
		public bool IsTimable
		{
			get { return this.isTimable; }
			set { this.isTimable = value; }
		}

		/// <summary>
		/// 获取或设置时钟触发的客户端事件.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示按钮被点击时的客户端事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Tick
		{
			get { return this.tick; }
			set
			{

				if ( null != value )
					this.tick = value;

			}
		}

		/// <summary>
		/// 获取或设置时钟触发的间隔, 以毫秒为单位.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 100 )]
		[Description ( "指示时钟触发的间隔, 以毫秒为单位" )]
		[NotifyParentProperty ( true )]
		public int Interval
		{
			get { return this.interval; }
			set
			{

				if ( value > 0 )
					this.interval = value;

			}
		}

		/// <summary>
		/// 获取 Tick 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Tick 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public AjaxSettingEdit TickAsync
		{
			get { return this.tickAjax; }
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>等效字符串.</returns>
		public override string ToString ( )
		{ return TypeDescriptor.GetConverter ( this.GetType ( ) ).ConvertToString ( this ); }

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
				this.Interval = (int) states[0];

			if ( states.Count >= 2 )
				this.isTimable = (bool) states[1];

			if ( states.Count >= 3 )
				this.Tick = states[2] as string;

		}

		object IStateManager.SaveViewState ( )
		{
			List<object> states = new List<object> ( );
			states.Add ( this.interval );
			states.Add ( this.isTimable );
			states.Add ( this.tick );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }

	}
	#endregion

	#region " TimerSettingEditConverter "
	/// <summary>
	/// jQuery UI Timer 设置编辑器的转换器.
	/// </summary>
	public sealed class TimerSettingEditConverter : ExpandableObjectConverter
	{

		public override bool CanConvertFrom ( ITypeDescriptorContext context, Type sourceType )
		{

			if ( sourceType == typeof ( string ) )
				return true;

			return base.CanConvertFrom ( context, sourceType );
		}

		public override bool CanConvertTo ( ITypeDescriptorContext context, Type destinationType )
		{

			if ( destinationType == typeof ( string ) )
				return true;

			return base.CanConvertTo ( context, destinationType );
		}

		public override object ConvertFrom ( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			TimerSettingEdit edit = new TimerSettingEdit ( );

			if ( null == value )
				return edit;

			if ( !( value is string ) )
				return base.ConvertFrom ( context, culture, value );

			string expression = value as string;

			if ( expression == string.Empty )
				return edit;

			ExpressionHelper expressionHelper = new ExpressionHelper ( expression );

			if ( expressionHelper.ChildCount == 3 )
				try
				{

					if ( expressionHelper[0].Value != string.Empty )
						edit.IsTimable = StringConvert.ToObject<bool> ( expressionHelper[0].Value );

					if ( expressionHelper[1].Value != string.Empty )
						edit.Interval = StringConvert.ToObject<int> ( expressionHelper[1].Value );

					if ( expressionHelper[2].Value != string.Empty )
						edit.Tick = expressionHelper[2].Value;

				}
				catch { }

			return edit;
		}

		public override object ConvertTo ( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{

			if ( null == value || !( value is TimerSettingEdit ) || destinationType != typeof ( string ) )
				return base.ConvertTo ( context, culture, value, destinationType ); ;

			TimerSettingEdit setting = value as TimerSettingEdit;

			return string.Format ( "{0}`;{1}`;{2}", setting.IsTimable, setting.Interval, setting.Tick );
		}

	}
	#endregion

}

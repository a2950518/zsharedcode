/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/DragableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;
using System.ComponentModel;

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " CursorSetting "
	/// <summary>
	/// 图表的拖动设置.
	/// </summary>
	public sealed class DragableSetting
	{
		#region " ConstrainToType "
		/// <summary>
		/// 拖动的方向.
		/// </summary>
		public enum ConstrainToType
		{
			/// <summary>
			/// 没有限制.
			/// </summary>
			none,
			/// <summary>
			/// x 轴方向.
			/// </summary>
			x,
			/// <summary>
			/// y 轴方向.
			/// </summary>
			y,
		}
		#endregion

		private readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " option "
		/// <summary>
		/// 获取或设置拖动时的颜色, 默认为空.
		/// </summary>
		[Category ( "外观" )]
		[Description ( "拖动时的颜色, 默认为空" )]
		public string Color
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.color, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.color, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置拖动的方向, 默认为 "none".
		/// </summary>
		[Category ( "外观" )]
		[Description ( "拖动的方向, 默认为 none" )]
		public ConstrainToType ConstrainTo
		{
			get { return this.settingHelper.GetOptionValueToEnum<ConstrainToType> ( OptionType.constrainTo, ConstrainToType.none ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.constrainTo, value.ToString ( ), ConstrainToType.none.ToString ( ) ); }
		}
		#endregion

		/// <summary>
		/// 创建一个图表的拖动设置.
		/// </summary>
		public DragableSetting ( )
		{ }

		/// <summary>
		/// 创建选项数组.
		/// </summary>
		/// <returns>选项数组.</returns>
		public Option[] CreateOptions ( )
		{ return this.settingHelper.CreateOptions ( ); }

	}
	#endregion

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/jqplot/AxesSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui.plusin.jqplot
{

	#region " AxesSetting "
	/// <summary>
	/// 图表 Axes 选项的设置.
	/// </summary>
	public sealed class AxesSetting
	{
		private readonly SettingHelper settingHelper = new SettingHelper ( );
		private Axis xAxisSetting;
		private Axis x2AxisSetting;
		private Axis yAxisSetting;
		private Axis y2AxisSetting;

		#region " option "
		/// <summary>
		/// 获取或设置 x 轴, 默认为空.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "x 轴" )]
		public string XAxis
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.xaxis, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.xaxis, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置 x 轴设置.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "x 轴设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public Axis XAxisSetting
		{
			get
			{

				if ( null == this.xAxisSetting )
					this.xAxisSetting = new Axis ( );

				return this.xAxisSetting;
			}
		}

		/// <summary>
		/// 获取或设置 y 轴, 默认为空.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "y 轴" )]
		public string YAxis
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.yaxis, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.yaxis, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置 y 轴设置.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "y 轴设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public Axis YAxisSetting
		{
			get
			{

				if ( null == this.yAxisSetting )
					this.yAxisSetting = new Axis ( );

				return this.yAxisSetting;
			}
		}

		/// <summary>
		/// 获取或设置 x2 轴, 默认为空.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "x2 轴" )]
		public string X2Axis
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.x2axis, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.x2axis, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置 x 2 轴设置.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "x 2 轴设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public Axis X2AxisSetting
		{
			get
			{

				if ( null == this.x2AxisSetting )
					this.x2AxisSetting = new Axis ( );

				return this.x2AxisSetting;
			}
		}

		/// <summary>
		/// 获取或设置 y2 轴, 默认为空.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "y2 轴" )]
		public string Y2Axis
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.y2axis, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.y2axis, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置 y 2 轴设置.
		/// </summary>
		[Category ( "设置" )]
		[Description ( "y 轴设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		public Axis Y2AxisSetting
		{
			get
			{

				if ( null == this.y2AxisSetting )
					this.y2AxisSetting = new Axis ( );

				return this.y2AxisSetting;
			}
		}
		#endregion

		/// <summary>
		/// 创建一个图表 Axes 选项的设置.
		/// </summary>
		public AxesSetting ( )
		{ }

		/// <summary>
		/// 创建选项数组.
		/// </summary>
		/// <returns>选项数组.</returns>
		public Option[] CreateOptions ( )
		{

			if ( this.XAxis == string.Empty && null != this.xAxisSetting )
				this.XAxis = JQueryUI.MakeOptionExpression ( this.xAxisSetting.CreateOptions ( ) );

			if ( this.X2Axis == string.Empty && null != this.x2AxisSetting )
				this.X2Axis = JQueryUI.MakeOptionExpression ( this.x2AxisSetting.CreateOptions ( ) );

			if ( this.YAxis == string.Empty && null != this.yAxisSetting )
				this.YAxis = JQueryUI.MakeOptionExpression ( this.yAxisSetting.CreateOptions ( ) );

			if ( this.Y2Axis == string.Empty && null != this.y2AxisSetting )
				this.Y2Axis = JQueryUI.MakeOptionExpression ( this.y2AxisSetting.CreateOptions ( ) );

			return this.settingHelper.CreateOptions ( );
		}

	}
	#endregion

}

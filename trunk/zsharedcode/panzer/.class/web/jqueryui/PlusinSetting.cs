/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/PlusinSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " PlusinType "
	/// <summary>
	/// 自定义插件类型.
	/// </summary>
	public enum PlusinType
	{
		/// <summary>
		/// 其它自定义插件.
		/// </summary>
		custom = 0,
		/// <summary>
		/// 折叠列表.
		/// </summary>
		repeater = 1,
		/// <summary>
		/// 自动填充.
		/// </summary>
		timer = 2,
	}
	#endregion

	/// <summary>
	/// 派生所有 jQuery UI 自定义插件设置的基础类.
	/// </summary>
	public abstract class PlusinSetting
		: WidgetSetting
	{
		private PlusinType plusinType;

		/// <summary>
		/// 获取自定义插件的安装脚本.
		/// </summary>
		/// <returns>自定义插件的安装脚本.</returns>
		public abstract string GetPlusinCode ( );

		/// <summary>
		/// 获取或设置自定义插件类型.
		/// </summary>
		public PlusinType PlusinType
		{
			get { return this.plusinType; }
			set { this.plusinType = value; }
		}

		protected PlusinSetting ( PlusinType plusinType, int ajaxCount )
			: base ( WidgetType.custom, ajaxCount )
		{ this.plusinType = plusinType; }


	}

}

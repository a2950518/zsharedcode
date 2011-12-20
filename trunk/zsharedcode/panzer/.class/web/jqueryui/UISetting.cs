/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/UISetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	/// <summary>
	/// 派生所有的 jQuery UI 相关设置, JQueryUI 使用其生成相应的代码.
	/// </summary>
	public abstract class UISetting
	{

		/// <summary>
		/// 从原有的选择器上创建新的选择器.
		/// </summary>
		/// <param name="selector">原有的选择器.</param>
		/// <returns>新的选择器.</returns>
		public static string CreateJQuerySelector ( string selector )
		{

			if ( string.IsNullOrEmpty ( selector ) )
				return string.Empty;

			if ( ( selector.StartsWith ( "'" ) && selector.EndsWith ( "'" ) ) || ( selector.StartsWith ( "\"" ) && selector.EndsWith ( "\"" ) ) )
				return selector;
			else
				return "{expression: '" + selector + "', analyze: true}";

		}

		protected readonly SettingHelper settingHelper = new SettingHelper ( );

		#region " property "
		/// <summary>
		/// 获取或设置自定义选项, 比如: "helper=__jsVariable", 多个选项请用 ; 号分隔, 如果需要在表达式中使用 ; 或 = 可用 /; 或 /= 表示.
		/// </summary>
		public string CustomOption
		{
			get { return this.settingHelper.CustomOption; }
			set { this.settingHelper.CustomOption = value; }
		}

		/// <summary>
		/// 获取已经修改的事件的个数.
		/// </summary>
		public int EventCount
		{
			get { return this.settingHelper.EventCount; }
		}

		/// <summary>
		/// 获取已经修改的选项的个数.
		/// </summary>
		public int OptionCount
		{
			get { return this.settingHelper.OptionCount; }
		}

		/// <summary>
		/// 获取 Option, Event 辅助类.
		/// </summary>
		public SettingHelper SettingHelper
		{
			get { return this.settingHelper; }
		}
		#endregion

		/// <summary>
		/// 创建一个不带任何选项的 jQuery UI 相关设置.
		/// </summary>
		public UISetting ( )
			: this ( null )
		{ }
		/// <summary>
		/// 创建一个 jQuery UI 相关设置.
		/// </summary>
		/// <param name="options">相关选项.</param>
		public UISetting ( Option[] options )
		{ this.settingHelper.Options = options; }

	}

}

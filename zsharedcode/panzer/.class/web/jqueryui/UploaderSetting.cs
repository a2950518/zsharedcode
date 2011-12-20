/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/UploaderSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Collections.Generic;

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui.plusin
{

	#region " UploaderSetting "
	/// <summary>
	/// 上传插件设置.
	/// </summary>
	public sealed class UploaderSetting
		: PlusinSetting
	{

		#region " option "
		/// <summary>
		/// 获取或设置时钟的选择器, 默认为空字符串.
		/// </summary>
		public string Timer
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.timer, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.timer, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置上传页面的选择器, 默认为空字符串.
		/// </summary>
		public string Upload
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.upload, string.Empty ); }
			set { this.settingHelper.SetOptionValue ( OptionType.upload, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置上传页面的表单索引, 默认为 0.
		/// </summary>
		public int UploadForm
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.uploadform, 0 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.uploadform, value < 0  ? "0" : value.ToString ( ), "0" ); }
		}
		#endregion
		
		/// <summary>
		/// 创建一个自定义上传插件设置.
		/// </summary>
		public UploaderSetting ( )
			: base ( PlusinType.uploader, 0 )
		{ }

		/// <summary>
		/// 获取上传插件所需的基础脚本.
		/// </summary>
		/// <returns>上传插件所需的基础脚本.</returns>
		public override Dictionary<string, string> GetDependentScripts ( )
		{
			Dictionary<string, string> plusins = base.GetDependentScripts ( );

			plusins.Add ( "timer", Resources.timer_min );
			plusins.Add ( "uploader", Resources.uploader_min );

			return plusins;
		}

	}
	#endregion

}

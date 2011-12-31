/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/PlusinSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;

namespace zoyobar.shared.panzer.web.jqueryui.plusin
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
		/// <summary>
		/// 基础插件.
		/// </summary>
		panzer = 3,
		/// <summary>
		/// 验证插件.
		/// </summary>
		validator = 4,
		/// <summary>
		/// 上传插件.
		/// </summary>
		uploader = 5,
		/// <summary>
		/// 图表插件.
		/// </summary>
		plot = 6,
	}
	#endregion

	#region " PlusinSetting "
	/// <summary>
	/// 派生所有 jQuery UI 自定义插件设置的基础类.
	/// </summary>
	public abstract class PlusinSetting
		: WidgetSetting
	{
		private PlusinType plusinType;

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

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine ( )
		{
			base.Recombine ( );

			foreach ( AjaxSetting ajax in this.ajaxs )
				if ( ajax.EventType != EventType.none && ajax.EventType != EventType.__init )
				{
					OptionType optionType;

					try
					{ optionType = ( OptionType ) Enum.Parse ( typeof ( OptionType ), ajax.EventType.ToString ( ), true ); }
					catch
					{ continue; }

					if ( !string.IsNullOrEmpty ( ajax.ClientFunction ) )
					{
						this.settingHelper.SetOptionValue ( optionType, ajax.ClientFunction, string.Empty );

						continue;
					}

					//!+ The following code is similar with AutocompleteSetting.Recombine

					if ( ajax.Data.StartsWith ( "e." ) )
						if ( string.IsNullOrEmpty ( ajax.MethodName ) )
							ajax.Data = string.Format ( "jQuery.extend({0}, {1})", "{}", ajax.Data );
						else
							ajax.Data = string.Format ( "jQuery.panzer.encodeData({0})", ajax.Data );

					JQuery jquery = JQueryUI.Create ( ajax );

					if ( null != jquery )
					{
						jquery.EndLine ( );
						this.settingHelper.SetOptionValue ( optionType, "function(pe, e) {" + jquery.Code + "}", string.Empty );
					}

				}

		}

	}
	#endregion

}

﻿/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/PlusinSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.Collections.Generic;

using zoyobar.shared.panzer.Properties;

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
		/// <summary>
		/// 基础插件.
		/// </summary>
		panzer = 3,
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
		/// 获取所需的基础自定义插件类型.
		/// </summary>
		/// <returns>基础自定义插件类型.</returns>
		public virtual Dictionary<PlusinType, string> GetDependentPlusins()
		{
			Dictionary<PlusinType, string> plusins = new Dictionary<PlusinType, string>();

			plusins.Add(PlusinType.panzer, Resources.panzer_min);

			return plusins;
		}

		/// <summary>
		/// 获取或设置自定义插件类型.
		/// </summary>
		public PlusinType PlusinType
		{
			get { return this.plusinType; }
			set { this.plusinType = value; }
		}

		protected PlusinSetting(PlusinType plusinType, int ajaxCount)
			: base(WidgetType.custom, ajaxCount)
		{ this.plusinType = plusinType; }

		/// <summary>
		/// 重新构造.
		/// </summary>
		public override void Recombine()
		{

			foreach (AjaxSetting ajax in this.ajaxs)
				if (ajax.EventType != EventType.none && ajax.EventType != EventType.__init)
				{
					OptionType optionType;

					try
					{ optionType = (OptionType)Enum.Parse(typeof(OptionType), ajax.EventType.ToString(), true); }
					catch
					{ continue; }

					string data;

					if (string.IsNullOrEmpty(ajax.MethodName))
						data = "data";
					else
					{

						if ( Environment.Version.Major <= 2 || ( Environment.Version.Major == 3 && Environment.Version.Minor == 0 ) )
							data = "data";
						else
							data = "data.d";

						if (ajax.Data.StartsWith("e."))
							ajax.Data = string.Format ( "jQuery.panzer.encodeData({0})", ajax.Data );

					}

					if (!string.IsNullOrEmpty(ajax.Success))
						ajax.Success = ajax.Success.Replace("-:data", data);

					if (!string.IsNullOrEmpty(ajax.Complete))
						ajax.Complete = ajax.Complete.Replace("-:data", data);

					if (!string.IsNullOrEmpty(ajax.Error))
						ajax.Error = ajax.Error.Replace("-:data", data);

					JQuery jquery = JQueryUI.Create(ajax);

					if (null != jquery)
					{
						jquery.EndLine();
						this.settingHelper.SetOptionValue(optionType, "function(pe, e) {" + jquery.Code + "}", string.Empty);
					}

				}

		}

	}
	#endregion

}
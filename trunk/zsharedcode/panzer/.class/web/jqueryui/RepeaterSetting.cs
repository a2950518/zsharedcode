/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/RepeaterSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " RepeaterSetting "
	/// <summary>
	/// 自定义 Repeater 设置.
	/// </summary>
	public sealed class RepeaterSetting
		: PlusinSetting
	{

		#region " plusin code "
		private static string repeaterPlusinCode =
		"var __installRepeater = function ($) {" +
		"$.fn.__repeater = function () {" +

		"	if (this.length == 0) { return this; }" +

		"	var tag = this.get(0);" +
		"	var action = 'create';" +

		"	if (typeof (arguments[0]) == 'string') {" +

		"		if (null == tag.__repeater) { return this; }" +

		"		if (arguments[0] == 'option') { action = (arguments.length == 2 ? 'get' : 'set'); } else { action = 'method'; }" +

		"	}" +
		"	else { arguments[0] = $.extend({}, $.fn.__repeater.defaults, arguments[0]); }" +

		"	switch (action) {" +
		"		case 'get':" +
		"			return tag.__repeater[arguments[1]];" +

		"		case 'set':" +
		"			return tag.__repeater[arguments[1]] = arguments[2];" +

		"		case 'method':" +

		"			switch (arguments[0]) {" +
		"				case 'bind':" +
		"					__bind.call(this, tag, arguments[1]);" +
		"					break;" +
		"			}" +

		"			return this;" +

		"		default:" +
		"			arguments[0].field = (null == arguments[0].field) ? [] : arguments[0].field;" +
		"			arguments[0].attribute = (null == arguments[0].attribute) ? [] : arguments[0].attribute;" +
		"			arguments[0].template = { header: (null == arguments[0].header) ? '' : arguments[0].header, footer: (null == arguments[0].footer) ? '' : arguments[0].footer, item: (null == arguments[0].item) ? '' : arguments[0].item, editItem: (null == arguments[0].editItem) ? '' : arguments[0].editItem, empty: (null == arguments[0].empty) ? '' : arguments[0].empty };" +
		"			arguments[0].setting = { rowsName: (null == arguments[0].rowsName) ? 'rows' : arguments[0].rowsName };" +
		"			tag.__repeater = arguments[0];" +
		"			return this;" +
		"	}" +

		"};" +
		"function __bind(tag, data) {" +
		"	var option = tag.__repeater;" +
		"	var html = '';" +
		"	var isEmpty = false;" +
		"	html += option.template.header;" +

		"	if (null == data) { isEmpty = true; }" +
		"	else {" +
		"		var rows = data[option.setting.rowsName];" +

		"		if (null == rows || rows.length == 0) { isEmpty = true; }" +
		"		else {" +

		"			try {" +

		"				for (var x = 0; x < rows.length; x++) {" +
		"					var row = rows[x];" +
		"					var rowHtml = option.template.item;" +

		"					for (var y = 0; y < option.field.length; y++) { rowHtml = rowHtml.replace(eval('/#' + option.field[y] + '/g'), row[option.field[y]]); }" +

		"					html += rowHtml;" +
		"				}" +

		"			}" +
		"			catch (err) { isEmpty = true; }" +

		"		}" +

		"	}" +

		"	if (isEmpty) { html += option.template.empty; }" +

		"	html += option.template.footer;" +

		"	for (var x = 0; x < option.attribute.length; x++) { html = html.replace(eval('/\\@' + option.attribute[x] + '/g'), data[option.attribute[x]]); }" +

		"	this.html(html);" +
		"}" +
		"$.fn.__repeater.defaults = {" +
		"	rowsName: 'rows'" +
		"};" +
		"};" +
		"__installRepeater(jQuery);";
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置包含的字段, 为一个数组, 默认为 "[]".
		/// </summary>
		public string Field
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.field, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.field, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置包含的属性, 为一个数组, 默认为 "[]".
		/// </summary>
		public string Attribute
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.attribute, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.attribute, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置头模板, 默认为空字符串.
		/// </summary>
		public string Header
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.header, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.header, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置尾模板, 默认为空字符串.
		/// </summary>
		public string Footer
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.footer, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.footer, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置条目模板, 默认为空字符串.
		/// </summary>
		public string Item
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.item, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.item, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置编辑条目模板, 默认为空字符串.
		/// </summary>
		public string EditItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.editItem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.editItem, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置空模板, 默认为空字符串.
		/// </summary>
		public string Empty
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.empty, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.empty, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置行的属性名称, 默认为 "rows".
		/// </summary>
		public string RowsName
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.rowsName, "rows" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.rowsName, value, "rows" ); }
		}
		#endregion

		/// <summary>
		/// 创建一个自定义 Repeater 设置.
		/// </summary>
		public RepeaterSetting ( )
			: base ( PlusinType.repeater, 0 )
		{ }

		/// <summary>
		/// 获取自定义 Repeater 的安装脚本.
		/// </summary>
		/// <returns>自定义 Repeater 的安装脚本.</returns>
		public override string GetPlusinCode ( )
		{ return repeaterPlusinCode; }

	}
	#endregion

}

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
		"(function(j){function m(b,d,a){var c=b.__repeater;if(null==a||a)c.index.edit.length=0,h.call(this,b,d);null!=c.filled&&c.filled.call(this,b,{data:d,isSuccess:a})}function h(b,d){var a=b.__repeater,c=\"\",e=!1;a.data=d;c+=a.template.header;c+=a.template.newItem;for(var g=0;g<a.field.length;g++)c=c.replace(eval(\"/&i:\"+a.field[g]+\"/g\"),a.field[g]+\"_i_0\");c=c.replace(eval(\"/!:insert/g\"),\"$('\"+a.selector+\"').__repeater('insert')\");if(null==d)e=!0;else{var h=d[a.setting.rowsName];if(null==h||h.length==0)e=" +
"!0;else try{for(var i=0;i<h.length;i++){var j=h[i],f,k;a:{for(var l=a.index.edit,n=0;n<l.length;n++)if(l[n]==i){k=!0;break a}k=!1}f=k?a.template.editItem:a.template.item;for(g=0;g<a.field.length;g++)f=f.replace(eval(\"/#:\"+a.field[g]+\"/g\"),null==j[a.field[g]]?\"\":j[a.field[g]]),f=f.replace(eval(\"/&u:\"+a.field[g]+\"/g\"),a.field[g]+\"_u_\"+i.toString()),f=f.replace(eval(\"/&r:\"+a.field[g]+\"/g\"),a.field[g]+\"_r_\"+i.toString());f=f.replace(eval(\"/!:beginedit/g\"),\"$('\"+a.selector+\"').__repeater('beginedit', #:__index)\");" +
"f=f.replace(eval(\"/!:endedit/g\"),\"$('\"+a.selector+\"').__repeater('endedit', #:__index)\");f=f.replace(eval(\"/!:remove/g\"),\"$('\"+a.selector+\"').__repeater('remove', #:__index)\");f=f.replace(eval(\"/!:update/g\"),\"$('\"+a.selector+\"').__repeater('update', #:__index)\");f=f.replace(eval(\"/#:__index/g\"),i.toString());c+=f}}catch(m){e=!0}}e&&(c+=a.template.empty);c+=a.template.footer;for(i=0;i<a.attribute.length;i++)c=c.replace(eval(\"/\\@:\"+a.attribute[i]+\"/g\"),d[a.attribute[i]]);this.html(c)}function l(b," +
"d,a){for(var c=0;c<b.length;c++){if(b[c]==d&&(b.splice(c,1),!a))break;a&&b[c]>d&&b[c]--}}function o(b,d,a,c){a=b.__repeater;if(null==c||c){if(null==a.data||null==a.data[a.setting.rowsName])return;a.data[a.setting.rowsName].splice(d,1);l.call(this,a.index.edit,d,!0);h.call(this,b,a.data)}null!=a.removed&&a.removed.call(this,b,{index:d,isSuccess:c})}function p(b,d,a,c){var e=b.__repeater;if(null==c||c)q.call(this,b,d,a),l.call(this,e.index.edit,d,!1),h.call(this,b,e.data);null!=e.updated&&e.updated.call(this," +
"b,{index:d,row:a,isSuccess:c})}function r(b,d,a){var c=b.__repeater;if(null==a||a)null!=c.data&&null!=c.data[c.setting.rowsName]&&c.data[c.setting.rowsName].push(d),h.call(this,b,c.data);null!=c.inserted&&c.inserted.call(this,b,{row:d,isSuccess:a})}function k(b,d,a){if(null==d||null==a)return{};for(var b=b.__repeater,c={},e=0;e<b.field.length;e++){var g=j(\"#\"+b.field[e]+\"_\"+a.toString()+\"_\"+d.toString());g.length!=0&&(c[b.field[e]]=g.val())}return c}function q(b,d,a){if(!(null==d||null==a))if(b=b.__repeater," +
"null!=b.data&&(b=b.data[b.setting.rowsName],null!=b))for(var c in a)b[d][c]=a[c]}j.fn.__repeater=function(){if(this.length==0)return this;var b=this.get(0),d=\"create\";if(typeof arguments[0]==\"string\"){if(null==b.__repeater)return this;d=arguments[0]==\"option\"?arguments.length==2?\"get\":\"set\":\"method\"}else arguments[0]=j.extend({},j.fn.__repeater.defaults,arguments[0]);switch(d){case \"get\":return b.__repeater[arguments[1]];case \"set\":return b.__repeater[arguments[1]]=arguments[2];case \"method\":switch(arguments[0]){case \"fill\":d=" +
"b.__repeater;null!=d.fill?d.fill.call(this,b,{callback:m}):m.call(this,b,data,!0);break;case \"bind\":h.call(this,b,arguments[1]);break;case \"beginedit\":var a=arguments[1];if(null!=a){d=b.__repeater;if(!d.multipleEdit)d.index.edit.length=0;b:{for(var c=d.index.edit,e=0;e<c.length;e++)if(c[e]==a)break b;else if(c[e]>a){c.splice(e,0,a);break b}c.push(a)}h.call(this,b,d.data)}break;case \"endedit\":d=arguments[1];if(null!=d)c=b.__repeater,l.call(this,c.index.edit,d,!1),h.call(this,b,c.data);break;case \"remove\":d=" +
"arguments[1];if(null!=d)c=b.__repeater,a=k.call(this,b,d,\"r\"),null!=c.remove?c.remove.call(this,b,{index:d,row:a,callback:o}):o.call(this,b,d,a,!0);break;case \"update\":d=arguments[1];if(null!=d)c=b.__repeater,a=k.call(this,b,d,\"u\"),null!=c.update?c.update.call(this,b,{index:d,row:a,callback:p}):p.call(this,b,d,a,!0);break;case \"insert\":d=b.__repeater;c=k.call(this,b,0,\"i\");null!=d.insert?d.insert.call(this,b,{row:c,callback:r}):r.call(this,b,c,!0);break;case \"setrow\":q.call(this,b,arguments[1],arguments[2]);" +
"break;case \"getrow\":k.call(this,b,arguments[1],arguments[2])}return this;default:return arguments[0].selector=this.selector,arguments[0].field=null==arguments[0].field?[]:arguments[0].field,arguments[0].attribute=null==arguments[0].attribute?[]:arguments[0].attribute,arguments[0].template={header:null==arguments[0].header?\"\":arguments[0].header,footer:null==arguments[0].footer?\"\":arguments[0].footer,item:null==arguments[0].item?\"\":arguments[0].item,editItem:null==arguments[0].editItem?\"\":arguments[0].editItem," +
"empty:null==arguments[0].empty?\"\":arguments[0].empty,newItem:null==arguments[0].newItem?\"\":arguments[0].newItem},arguments[0].setting={rowsName:null==arguments[0].rowsName?\"rows\":arguments[0].rowsName},arguments[0].index={edit:null==arguments[0].editIndex?[]:arguments[0].editIndex},b.__repeater=arguments[0],this}};j.fn.__repeater.encodeData=function(b){if(null==b)return\"\";var d=\"\",a;for(a in b)d!=\"\"&&(d+=\",\"),d+='\"'+a.toString()+'\": '+(null==b[a]?\"null\":'\"'+b[a].toString()+'\"');return\"{\"+d+\"}\"};j.fn.__repeater.defaults=" +
"{selector:null,field:null,attribute:null,header:null,footer:null,item:null,editItem:null,empty:null,newItem:null,rowsName:\"rows\",editIndex:null,multipleEdit:!1,fill:null,filled:null,remove:null,removed:null,update:null,updated:null}})(jQuery);";
		#endregion

		#region " option "
		/// <summary>
		/// 获取或设置包含的属性, 为一个数组, 默认为 "[]".
		/// </summary>
		public string Attribute
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.attribute, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.attribute, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置编辑条目模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string EditItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.editItem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.editItem, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置空模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string Empty
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.empty, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.empty, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置包含的字段, 为一个数组, 默认为 "[]".
		/// </summary>
		public string Field
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.field, "[]" ); }
			set { this.settingHelper.SetOptionValue ( OptionType.field, value, "[]" ); }
		}

		/// <summary>
		/// 获取或设置尾模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string Footer
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.footer, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.footer, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置头模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string Header
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.header, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.header, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置条目模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string Item
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.item, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.item, value, string.Empty ); }
		}

		/*
		/// <summary>
		/// 获取或设置是否可以多行编辑, 默认为 false.
		/// </summary>
		public bool MultipleEdit
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.multipleEdit, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.multipleEdit, value, false ); }
		}
		*/

		/// <summary>
		/// 获取或设置新建条目模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string NewItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.newItem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.newItem, value, string.Empty ); }
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

		#region " event "
		/// <summary>
		/// 获取或设置修改行时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Update
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.update ); }
			set { this.settingHelper.SetOptionValue ( OptionType.update, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置修改行后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Updated
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.updated ); }
			set { this.settingHelper.SetOptionValue ( OptionType.updated, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置删除行时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Remove
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.remove ); }
			set { this.settingHelper.SetOptionValue ( OptionType.remove, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置删除行后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Removed
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.removed ); }
			set { this.settingHelper.SetOptionValue ( OptionType.removed, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置填充时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Fill
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.fill ); }
			set { this.settingHelper.SetOptionValue ( OptionType.fill, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置填充后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Filled
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.filled ); }
			set { this.settingHelper.SetOptionValue ( OptionType.filled, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置新建行时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Insert
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.insert ); }
			set { this.settingHelper.SetOptionValue ( OptionType.insert, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置新建行后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Inserted
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.inserted ); }
			set { this.settingHelper.SetOptionValue ( OptionType.inserted, value, string.Empty ); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置删除行时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Remove.
		/// </summary>
		public AjaxSetting RemoveAsync
		{
			get { return this.ajaxs[0]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.remove;
				value.Data = "e.row";
				value.Success = "function(data){e.callback.call($(tag), tag, e.index, (null == -:data.row ? e.row : -:data.row), -:data.__success);}";
				value.Error = "function(){e.callback.call($(tag), tag, e.index, e.row, false);}";
				this.ajaxs[0] = value;
			}
		}

		/// <summary>
		/// 获取或设置修改行时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Update.
		/// </summary>
		public AjaxSetting UpdateAsync
		{
			get { return this.ajaxs[1]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.update;
				value.Data = "e.row";
				value.Success = "function(data){e.callback.call($(tag), tag, e.index, (null == -:data.row ? e.row : -:data.row), -:data.__success);}";
				value.Error = "function(){e.callback.call($(tag), tag, e.index, e.row, false);}";
				this.ajaxs[1] = value;
			}
		}

		/// <summary>
		/// 获取或设置填充时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Fill.
		/// </summary>
		public AjaxSetting FillAsync
		{
			get { return this.ajaxs[2]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.fill;

				value.Success = "function(data){e.callback.call($(tag), tag, -:data, -:data.__success);}";
				value.Error = "function(){e.callback.call($(tag), tag, {}, false);}";
				this.ajaxs[2] = value;
			}
		}

		/// <summary>
		/// 获取或设置填充时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Insert.
		/// </summary>
		public AjaxSetting InsertAsync
		{
			get { return this.ajaxs[3]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.insert;
				value.Data = "e.row";
				value.Success = "function(data){e.callback.call($(tag), tag, (null == -:data.row ? e.row : -:data.row), -:data.__success);}";
				value.Error = "function(){e.callback.call($(tag), tag, e.row, false);}";
				this.ajaxs[3] = value;
			}
		}
		#endregion

		/// <summary>
		/// 创建一个自定义 Repeater 设置.
		/// </summary>
		public RepeaterSetting ( )
			: base ( PlusinType.repeater, 4 )
		{
			this.RemoveAsync = this.ajaxs[0];
			this.UpdateAsync = this.ajaxs[1];
			this.FillAsync = this.ajaxs[2];
			this.InsertAsync = this.ajaxs[3];
		}

		/// <summary>
		/// 获取自定义 Repeater 的安装脚本.
		/// </summary>
		/// <returns>自定义 Repeater 的安装脚本.</returns>
		public override string GetPlusinCode ( )
		{ return repeaterPlusinCode; }

	}
	#endregion

}

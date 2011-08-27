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
		"(function(j){function n(c){var d=c.__repeater;if(null!=d.prefill){var b=d.prefill.call(this,c);if(null!=b&&!b)return}null!=d.fill?d.fill.call(this,c,{callback:o}):o.call(this,c,data,!0)}function o(c,d,b){var a=c.__repeater;if(null==b||b){a.index.edit.length=0;if(!a.fieldfixed)a.field.length=0;if(!a.attributefixed)a.attribute.length=0;if(null!=d){if(null!=d.itemcount)a.itemcount=new Number(d.itemcount),a.pagecount=Math.ceil(a.itemcount/a.pagesize),d.pagecount=a.pagecount;if(!a.fieldfixed){var e=d[a.setting.rowsname];" +
"if(null!=e||e.length!=0)for(var f in e[0])a.field.push(f)}if(!a.attributefixed)for(f in d)f!=a.setting.rowsname&&a.attribute.push(f)}h.call(this,c,d)}null!=a.filled&&a.filled.call(this,c,{data:d,isSuccess:b});null!=a.navigable&&a.navigable.call(this,c,{prev:a.pageindex!=1,next:a.pageindex!=a.pagecount})}function h(c,d){var b=c.__repeater,a=\"\",e=!1;b.data=d;a+=b.template.header;a+=b.template.newitem;for(var f=0;f<b.field.length;f++)a=a.replace(eval(\"/&i:\"+b.field[f]+\"/g\"),b.field[f]+\"_i_0\");a=a.replace(eval(\"/!:insert/g\")," +
"\"$('\"+b.selector+\"').__repeater('insert')\");if(null==d)e=!0;else{var h=d[b.setting.rowsname];if(null==h||h.length==0)e=!0;else try{for(var i=0;i<h.length;i++){var j=h[i],g,k;a:{for(var m=b.index.edit,l=0;l<m.length;l++)if(m[l]==i){k=!0;break a}k=!1}g=k?b.template.edititem:b.template.item;for(f=0;f<b.field.length;f++)g=g.replace(eval(\"/#:\"+b.field[f]+\"/g\"),null==j[b.field[f]]?\"\":j[b.field[f]]),g=g.replace(eval(\"/&u:\"+b.field[f]+\"/g\"),b.field[f]+\"_u_\"+i.toString()),g=g.replace(eval(\"/&r:\"+b.field[f]+" +
"\"/g\"),b.field[f]+\"_r_\"+i.toString());g=g.replace(eval(\"/!:beginedit/g\"),\"$('\"+b.selector+\"').__repeater('beginedit', #:__index)\");g=g.replace(eval(\"/!:endedit/g\"),\"$('\"+b.selector+\"').__repeater('endedit', #:__index)\");g=g.replace(eval(\"/!:remove/g\"),\"$('\"+b.selector+\"').__repeater('remove', #:__index)\");g=g.replace(eval(\"/!:update/g\"),\"$('\"+b.selector+\"').__repeater('update', #:__index)\");g=g.replace(eval(\"/#:__index/g\"),i.toString());a+=g}}catch(n){e=!0}}e&&(a+=b.template.empty);a+=b.template.footer;" +
"for(i=0;i<b.attribute.length;i++)a=a.replace(eval(\"/\\@:\"+b.attribute[i]+\"/g\"),d[b.attribute[i]]);this.html(a)}function m(c,d,b){for(var a=0;a<c.length;a++){if(c[a]==d&&(c.splice(a,1),!b))break;b&&c[a]>d&&c[a]--}}function p(c,d,b,a){b=c.__repeater;if(null==a||a){if(null==b.data||null==b.data[b.setting.rowsname])return;b.data[b.setting.rowsname].splice(d,1);m.call(this,b.index.edit,d,!0);h.call(this,c,b.data)}null!=b.removed&&b.removed.call(this,c,{index:d,isSuccess:a})}function q(c,d,b,a){var e=c.__repeater;" +
"if(null==a||a)r.call(this,c,d,b),m.call(this,e.index.edit,d,!1),h.call(this,c,e.data);null!=e.updated&&e.updated.call(this,c,{index:d,row:b,isSuccess:a})}function s(c,d,b){var a=c.__repeater;if(null==b||b)null!=a.data&&null!=a.data[a.setting.rowsname]&&a.data[a.setting.rowsname].push(d),h.call(this,c,a.data);null!=a.inserted&&a.inserted.call(this,c,{row:d,isSuccess:b})}function k(c,d,b){if(null==d||null==b)return{};for(var c=c.__repeater,a={},e=0;e<c.field.length;e++){var f=j(\"#\"+c.field[e]+\"_\"+b.toString()+" +
"\"_\"+d.toString());f.length!=0&&(a[c.field[e]]=f.val())}return a}function r(c,d,b){if(!(null==d||null==b))if(c=c.__repeater,null!=c.data&&(c=c.data[c.setting.rowsname],null!=c))for(var a in b)c[d][a]=b[a]}function l(c,d){var b=c.__repeater;if(d<=0)d=1;else if(null!=b.pagecount&&d>b.pagecount)d=b.pagecount;b.pageindex=d;n.call(this,c)}j.fn.__repeater=function(){if(this.length==0)return this;var c=this.get(0),d=\"create\";if(typeof arguments[0]==\"string\"){if(null==c.__repeater)return this;d=arguments[0]==" +
"\"option\"?arguments.length==2?\"get\":\"set\":\"method\"}else arguments[0]=j.extend({},j.fn.__repeater.defaults,arguments[0]);switch(d){case \"get\":return c.__repeater[arguments[1]];case \"set\":return c.__repeater[arguments[1]]=arguments[2];case \"method\":switch(arguments[0]){case \"fill\":n.call(this,c);break;case \"bind\":h.call(this,c,arguments[1]);break;case \"beginedit\":var b=arguments[1];if(null!=b){d=c.__repeater;if(!d.multipleedit)d.index.edit.length=0;b:{for(var a=d.index.edit,e=0;e<a.length;e++)if(a[e]==" +
"b)break b;else if(a[e]>b){a.splice(e,0,b);break b}a.push(b)}h.call(this,c,d.data)}break;case \"endedit\":d=arguments[1];if(null!=d)a=c.__repeater,m.call(this,a.index.edit,d,!1),h.call(this,c,a.data);break;case \"remove\":d=arguments[1];if(null!=d)a=c.__repeater,b=k.call(this,c,d,\"r\"),null!=a.preremove?a.preremove.call(this,c,{row:b}):null!=a.remove?a.remove.call(this,c,{index:d,row:b,callback:p}):p.call(this,c,d,b,!0);break;case \"update\":d=arguments[1];if(null!=d)a=c.__repeater,b=k.call(this,c,d,\"u\")," +
"null!=a.preupdate?a.preupdate.call(this,c,{row:b}):null!=a.update?a.update.call(this,c,{index:d,row:b,callback:q}):q.call(this,c,d,b,!0);break;case \"insert\":d=c.__repeater;a=k.call(this,c,0,\"i\");null!=d.preinsert?d.preinsert.call(this,c,{row:a}):null!=d.insert?d.insert.call(this,c,{row:a,callback:s}):s.call(this,c,a,!0);break;case \"setrow\":r.call(this,c,arguments[1],arguments[2]);break;case \"getrow\":k.call(this,c,arguments[1],arguments[2]);break;case \"goto\":l.call(this,c,arguments[1]);break;case \"prev\":l.call(this," +
"c,c.__repeater.pageindex-1);break;case \"next\":l.call(this,c,c.__repeater.pageindex+1)}return this;default:return arguments[0].selector=this.selector,arguments[0].pageindex=null==arguments[0].pageindex||arguments[0].pageindex<=0?1:arguments[0].pageindex,arguments[0].pagesize=null==arguments[0].pagesize||arguments[0].pagesize<=0?10:arguments[0].pagesize,arguments[0].field=null==arguments[0].field?[]:arguments[0].field,arguments[0].fieldfixed=arguments[0].field.length!=0,arguments[0].attribute=null==" +
"arguments[0].attribute?[]:arguments[0].attribute,arguments[0].attributefixed=arguments[0].attribute.length!=0,arguments[0].template={header:null==arguments[0].header?\"\":arguments[0].header,footer:null==arguments[0].footer?\"\":arguments[0].footer,item:null==arguments[0].item?\"\":arguments[0].item,edititem:null==arguments[0].edititem?\"\":arguments[0].edititem,empty:null==arguments[0].empty?\"\":arguments[0].empty,newitem:null==arguments[0].newitem?\"\":arguments[0].newitem},arguments[0].setting={rowsname:null==" +
"arguments[0].rowsname?\"rows\":arguments[0].rowsname},arguments[0].index={edit:null==arguments[0].editindex?[]:arguments[0].editindex},c.__repeater=arguments[0],this}};j.fn.__repeater.encodeData=function(c){if(null==c)return\"\";var d=\"\",b;for(b in c)d!=\"\"&&(d+=\",\"),d+='\"'+b.toString()+'\": '+(null==c[b]?\"null\":'\"'+c[b].toString()+'\"');return\"{\"+d+\"}\"};j.fn.__repeater.defaults={selector:null,pagesize:10,pageindex:1,pagecount:null,itemcount:null,field:null,fieldfixed:!1,attribute:null,attributefixed:!1," +
"header:null,footer:null,item:null,edititem:null,empty:null,newitem:null,rowsname:\"rows\",editindex:null,multipleedit:!1,prefill:null,fill:null,filled:null,preremove:null,remove:null,removed:null,preupdate:null,update:null,updated:null,preinsert:null,insert:null,inserted:null,navigable:null}})(jQuery);";
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
			get { return this.settingHelper.GetOptionValueToString ( OptionType.edititem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.edititem, value, string.Empty ); }
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
			get { return this.settingHelper.GetOptionValueToString ( OptionType.newitem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.newitem, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置页码, 默认为 1.
		/// </summary>
		public int PageIndex
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.pageindex, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.pageindex, value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置页的大小, 默认为 10.
		/// </summary>
		public int PageSize
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.pagesize, 10 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.pagesize, value.ToString ( ), "10" ); }
		}

		/// <summary>
		/// 获取或设置行的属性名称, 默认为 "rows".
		/// </summary>
		public string RowsName
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.rowsname, "rows" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.rowsname, value, "rows" ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置修改行之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreUpdate
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.preupdate ); }
			set { this.settingHelper.SetOptionValue ( OptionType.preupdate, value, string.Empty ); }
		}

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
		/// 获取或设置删除行之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreRemove
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.preremove ); }
			set { this.settingHelper.SetOptionValue ( OptionType.preremove, value, string.Empty ); }
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
		/// 获取或设置填充之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreFill
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.prefill ); }
			set { this.settingHelper.SetOptionValue ( OptionType.prefill, value, string.Empty ); }
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
		/// 获取或设置新建行之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreInsert
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.preinsert ); }
			set { this.settingHelper.SetOptionValue ( OptionType.preinsert, value, string.Empty ); }
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

		/// <summary>
		/// 获取或设置是否可以导航发生改变后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Navigable
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.navigable ); }
			set { this.settingHelper.SetOptionValue ( OptionType.navigable, value, string.Empty ); }
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
				value.Parameters = new Parameter[]
				{
					new Parameter("pageindex", ParameterType.Expression, "this.__repeater('option', 'pageindex')"),
					new Parameter("pagesize", ParameterType.Expression, "this.__repeater('option', 'pagesize')"),
				};

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

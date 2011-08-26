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
		"(function(j){function n(b){var d=b.__repeater;null!=d.fill?d.fill.call(this,b,{callback:o}):o.call(this,b,data,!0)}function o(b,d,c){var a=b.__repeater;if(null==c||c){a.index.edit.length=0;if(!a.fieldfixed)a.field.length=0;if(!a.attributefixed)a.attribute.length=0;if(null!=d){if(null!=d.itemcount)a.itemcount=new Number(d.itemcount),a.pagecount=Math.ceil(a.itemcount/a.pagesize),d.pagecount=a.pagecount;if(!a.fieldfixed){var e=d[a.setting.rowsname];if(null!=e||e.length!=0)for(var f in e[0])a.field.push(f)}if(!a.attributefixed)for(f in d)f!=" +
"a.setting.rowsname&&a.attribute.push(f)}h.call(this,b,d)}null!=a.filled&&a.filled.call(this,b,{data:d,isSuccess:c});null!=a.lastpage&&a.pageindex==a.pagecount&&a.lastpage.call(this,b,{pageindex:a.pageindex});null!=a.firstpage&&a.pageindex==1&&a.firstpage.call(this,b)}function h(b,d){var c=b.__repeater,a=\"\",e=!1;c.data=d;a+=c.template.header;a+=c.template.newitem;for(var f=0;f<c.field.length;f++)a=a.replace(eval(\"/&i:\"+c.field[f]+\"/g\"),c.field[f]+\"_i_0\");a=a.replace(eval(\"/!:insert/g\"),\"$('\"+c.selector+" +
"\"').__repeater('insert')\");if(null==d)e=!0;else{var h=d[c.setting.rowsname];if(null==h||h.length==0)e=!0;else try{for(var i=0;i<h.length;i++){var j=h[i],g,k;a:{for(var m=c.index.edit,l=0;l<m.length;l++)if(m[l]==i){k=!0;break a}k=!1}g=k?c.template.edititem:c.template.item;for(f=0;f<c.field.length;f++)g=g.replace(eval(\"/#:\"+c.field[f]+\"/g\"),null==j[c.field[f]]?\"\":j[c.field[f]]),g=g.replace(eval(\"/&u:\"+c.field[f]+\"/g\"),c.field[f]+\"_u_\"+i.toString()),g=g.replace(eval(\"/&r:\"+c.field[f]+\"/g\"),c.field[f]+" +
"\"_r_\"+i.toString());g=g.replace(eval(\"/!:beginedit/g\"),\"$('\"+c.selector+\"').__repeater('beginedit', #:__index)\");g=g.replace(eval(\"/!:endedit/g\"),\"$('\"+c.selector+\"').__repeater('endedit', #:__index)\");g=g.replace(eval(\"/!:remove/g\"),\"$('\"+c.selector+\"').__repeater('remove', #:__index)\");g=g.replace(eval(\"/!:update/g\"),\"$('\"+c.selector+\"').__repeater('update', #:__index)\");g=g.replace(eval(\"/#:__index/g\"),i.toString());a+=g}}catch(n){e=!0}}e&&(a+=c.template.empty);a+=c.template.footer;for(i=0;i<c.attribute.length;i++)a=" +
"a.replace(eval(\"/\\@:\"+c.attribute[i]+\"/g\"),d[c.attribute[i]]);this.html(a)}function m(b,d,c){for(var a=0;a<b.length;a++){if(b[a]==d&&(b.splice(a,1),!c))break;c&&b[a]>d&&b[a]--}}function p(b,d,c,a){c=b.__repeater;if(null==a||a){if(null==c.data||null==c.data[c.setting.rowsname])return;c.data[c.setting.rowsname].splice(d,1);m.call(this,c.index.edit,d,!0);h.call(this,b,c.data)}null!=c.removed&&c.removed.call(this,b,{index:d,isSuccess:a})}function q(b,d,c,a){var e=b.__repeater;if(null==a||a)r.call(this," +
"b,d,c),m.call(this,e.index.edit,d,!1),h.call(this,b,e.data);null!=e.updated&&e.updated.call(this,b,{index:d,row:c,isSuccess:a})}function s(b,d,c){var a=b.__repeater;if(null==c||c)null!=a.data&&null!=a.data[a.setting.rowsname]&&a.data[a.setting.rowsname].push(d),h.call(this,b,a.data);null!=a.inserted&&a.inserted.call(this,b,{row:d,isSuccess:c})}function k(b,d,c){if(null==d||null==c)return{};for(var b=b.__repeater,a={},e=0;e<b.field.length;e++){var f=j(\"#\"+b.field[e]+\"_\"+c.toString()+\"_\"+d.toString());" +
"f.length!=0&&(a[b.field[e]]=f.val())}return a}function r(b,d,c){if(!(null==d||null==c))if(b=b.__repeater,null!=b.data&&(b=b.data[b.setting.rowsname],null!=b))for(var a in c)b[d][a]=c[a]}function l(b,d){var c=b.__repeater;if(d<=0)d=1;else if(null!=c.pagecount&&d>c.pagecount)d=c.pagecount;c.pageindex=d;n.call(this,b)}j.fn.__repeater=function(){if(this.length==0)return this;var b=this.get(0),d=\"create\";if(typeof arguments[0]==\"string\"){if(null==b.__repeater)return this;d=arguments[0]==\"option\"?arguments.length==" +
"2?\"get\":\"set\":\"method\"}else arguments[0]=j.extend({},j.fn.__repeater.defaults,arguments[0]);switch(d){case \"get\":return b.__repeater[arguments[1]];case \"set\":return b.__repeater[arguments[1]]=arguments[2];case \"method\":switch(arguments[0]){case \"fill\":n.call(this,b);break;case \"bind\":h.call(this,b,arguments[1]);break;case \"beginedit\":var c=arguments[1];if(null!=c){d=b.__repeater;if(!d.multipleedit)d.index.edit.length=0;b:{for(var a=d.index.edit,e=0;e<a.length;e++)if(a[e]==c)break b;else if(a[e]>c){a.splice(e," +
"0,c);break b}a.push(c)}h.call(this,b,d.data)}break;case \"endedit\":d=arguments[1];if(null!=d)a=b.__repeater,m.call(this,a.index.edit,d,!1),h.call(this,b,a.data);break;case \"remove\":d=arguments[1];if(null!=d)a=b.__repeater,c=k.call(this,b,d,\"r\"),null!=a.remove?a.remove.call(this,b,{index:d,row:c,callback:p}):p.call(this,b,d,c,!0);break;case \"update\":d=arguments[1];if(null!=d)a=b.__repeater,c=k.call(this,b,d,\"u\"),null!=a.update?a.update.call(this,b,{index:d,row:c,callback:q}):q.call(this,b,d,c,!0);break;" +
"case \"insert\":d=b.__repeater;a=k.call(this,b,0,\"i\");null!=d.insert?d.insert.call(this,b,{row:a,callback:s}):s.call(this,b,a,!0);break;case \"setrow\":r.call(this,b,arguments[1],arguments[2]);break;case \"getrow\":k.call(this,b,arguments[1],arguments[2]);break;case \"goto\":l.call(this,b,arguments[1]);break;case \"prev\":l.call(this,b,b.__repeater.pageindex-1);break;case \"next\":l.call(this,b,b.__repeater.pageindex+1)}return this;default:return arguments[0].selector=this.selector,arguments[0].pageindex=null==" +
"arguments[0].pageindex||arguments[0].pageindex<=0?1:arguments[0].pageindex,arguments[0].pagesize=null==arguments[0].pagesize||arguments[0].pagesize<=0?10:arguments[0].pagesize,arguments[0].field=null==arguments[0].field?[]:arguments[0].field,arguments[0].fieldfixed=arguments[0].field.length!=0,arguments[0].attribute=null==arguments[0].attribute?[]:arguments[0].attribute,arguments[0].attributefixed=arguments[0].attribute.length!=0,arguments[0].template={header:null==arguments[0].header?\"\":arguments[0].header," +
"footer:null==arguments[0].footer?\"\":arguments[0].footer,item:null==arguments[0].item?\"\":arguments[0].item,edititem:null==arguments[0].edititem?\"\":arguments[0].edititem,empty:null==arguments[0].empty?\"\":arguments[0].empty,newitem:null==arguments[0].newitem?\"\":arguments[0].newitem},arguments[0].setting={rowsname:null==arguments[0].rowsname?\"rows\":arguments[0].rowsname},arguments[0].index={edit:null==arguments[0].editindex?[]:arguments[0].editindex},b.__repeater=arguments[0],this}};j.fn.__repeater.encodeData=" +
"function(b){if(null==b)return\"\";var d=\"\",c;for(c in b)d!=\"\"&&(d+=\",\"),d+='\"'+c.toString()+'\": '+(null==b[c]?\"null\":'\"'+b[c].toString()+'\"');return\"{\"+d+\"}\"};j.fn.__repeater.defaults={selector:null,pagesize:10,pageindex:1,pagecount:null,itemcount:null,field:null,fieldfixed:!1,attribute:null,attributefixed:!1,header:null,footer:null,item:null,edititem:null,empty:null,newitem:null,rowsname:\"rows\",editindex:null,multipleedit:!1,fill:null,filled:null,remove:null,removed:null,update:null,updated:null,lastpage:null," +
"firstpage:null}})(jQuery);";
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

		/// <summary>
		/// 获取或设置到达第一页时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string FirstPage
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.firstpage ); }
			set { this.settingHelper.SetOptionValue ( OptionType.firstpage, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置到达最后一页的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string LastPage
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.lastpage ); }
			set { this.settingHelper.SetOptionValue ( OptionType.lastpage, value, string.Empty ); }
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

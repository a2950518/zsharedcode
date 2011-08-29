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
		"(function(l){function q(b){if(n.call(this,b,\"fill\")){var d=b.__repeater;if(null!=d.prefill){var a=d.prefill.call(this,b);if(null!=a&&!a){h.call(this,b,\"fill\");return}}null!=d.fill?d.fill.call(this,b,{callback:r}):r.call(this,b,data,!0)}}function r(b,d,a){h.call(this,b,\"fill\");var c=b.__repeater;if(null==a||a){c.index.edit.length=0;if(!c.fieldfixed)c.field.length=0;if(!c.attributefixed)c.attribute.length=0;if(null!=d){if(null!=d.itemcount)c.itemcount=new Number(d.itemcount),c.pagecount=Math.ceil(c.itemcount/" +
"c.pagesize),d.pagecount=c.pagecount,d.pageindex=c.pageindex,d.pagesize=c.pagesize;c.inserteditemcount=0;c.updateditemcount=0;c.removeditemcount=0;if(!c.fieldfixed){var e=d[c.setting.rowsname];if(null!=e||e.length!=0)for(var f in e[0])c.field.push(f)}if(!c.attributefixed)for(f in d)f!=c.setting.rowsname&&c.attribute.push(f)}k.call(this,b,d);null!=c.filled&&c.filled.call(this,b,{data:d,isSuccess:a});null!=c.navigable&&c.navigable.call(this,b,{prev:c.pageindex!=1,next:c.pageindex!=c.pagecount})}}function k(b," +
"d){var a=b.__repeater,c=\"\",e=!1;a.data=d;c+=a.template.header;c+=a.template.newitem;for(var f=0;f<a.field.length;f++)c=c.replace(eval(\"/&i:\"+a.field[f]+\"/g\"),a.field[f]+\"_i_0\");c=c.replace(eval(\"/!:insert/g\"),\"$('\"+a.selector+\"').__repeater('insert')\");if(null==d)e=!0;else{var h=d[a.setting.rowsname];if(null==h||h.length==0)e=!0;else try{for(var k=\"\",l=\"\",n=\"\",i=0;i<h.length;i++){var j=h[i];if(null!=j){if(null==j.__state)j.__state=\"unchanged\";var g,m;a:{for(var p=a.index.edit,o=0;o<p.length;o++)if(p[o]==" +
"i){m=!0;break a}m=!1}g=m&&a.template.edititem!=\"\"?a.template.edititem:j.__state==\"inserted\"&&a.template.inserteditem!=\"\"?a.template.inserteditem:j.__state==\"removed\"?a.template.removeditem:j.__state==\"updated\"&&a.template.updateditem!=\"\"?a.template.updateditem:a.template.item;for(f=0;f<a.field.length;f++)g=g.replace(eval(\"/#:\"+a.field[f]+\"/g\"),null==j[a.field[f]]?\"\":j[a.field[f]]),g=g.replace(eval(\"/&u:\"+a.field[f]+\"/g\"),a.field[f]+\"_u_\"+i.toString()),g=g.replace(eval(\"/&r:\"+a.field[f]+\"/g\"),a.field[f]+" +
"\"_r_\"+i.toString());g=g.replace(eval(\"/!:beginedit/g\"),\"$('\"+a.selector+\"').__repeater('beginedit', #:__index)\");g=g.replace(eval(\"/!:endedit/g\"),\"$('\"+a.selector+\"').__repeater('endedit', #:__index)\");g=g.replace(eval(\"/!:remove/g\"),\"$('\"+a.selector+\"').__repeater('remove', #:__index)\");g=g.replace(eval(\"/!:update/g\"),\"$('\"+a.selector+\"').__repeater('update', #:__index)\");g=g.replace(eval(\"/#:__index/g\"),i.toString());g=g.replace(eval(\"/&s:/g\"),j.__state.toString()+\"-\");j.__state==\"inserted\"?k+=" +
"g:j.__state==\"removed\"?l+=g:n+=g}}c+=k+n+l}catch(q){e=!0}}e&&(c+=a.template.empty);c+=a.template.footer;for(i=0;i<a.attribute.length;i++)c=c.replace(eval(\"/\\@:\"+a.attribute[i]+\"/g\"),d[a.attribute[i]]);this.html(c)}function p(b,d,a){for(var c=0;c<b.length;c++){if(b[c]==d&&(b.splice(c,1),!a))break;a&&b[c]>d&&b[c]--}}function s(b,d,a,c){h.call(this,b,\"remove\");a=b.__repeater;if(null==c||c)if(!(null==a.data||null==a.data[a.setting.rowsname])){a.data[a.setting.rowsname][d].__state=\"removed\";if(null!=" +
"a.itemcount)a.itemcount--,a.inserteditemcount++,a.data.itemcount=a.itemcount,a.pagecount=Math.ceil(a.itemcount/a.pagesize),a.data.pagecount=a.pagecount;p.call(this,a.index.edit,d,!0);k.call(this,b,a.data);null!=a.removed&&a.removed.call(this,b,{index:d,isSuccess:c})}}function t(b,d,a,c){h.call(this,b,\"update\");var e=b.__repeater;if(null==c||c)u.call(this,b,d,a),e.data[e.setting.rowsname][d].__state=\"updated\",e.updateditemcount++,p.call(this,e.index.edit,d,!1),k.call(this,b,e.data),null!=e.updated&&" +
"e.updated.call(this,b,{index:d,row:a,isSuccess:c})}function v(b,d,a){h.call(this,b,\"insert\");var c=b.__repeater;if(null==a||a)if(!(null==c.data||null==c.data[c.setting.rowsname])){c.data[c.setting.rowsname].push(d);d.__state=\"inserted\";if(null!=c.itemcount)c.itemcount++,c.removeditemcount++,c.data.itemcount=c.itemcount,c.pagecount=Math.ceil(c.itemcount/c.pagesize),c.data.pagecount=c.pagecount;k.call(this,b,c.data);null!=c.inserted&&c.inserted.call(this,b,{row:d,isSuccess:a})}}function m(b,d,a){if(null==" +
"d||null==a)return{};for(var b=b.__repeater,c={},e=0;e<b.field.length;e++){var f=l(\"#\"+b.field[e]+\"_\"+a.toString()+\"_\"+d.toString());f.length!=0&&(c[b.field[e]]=f.val())}return c}function u(b,d,a){if(!(null==d||null==a))if(b=b.__repeater,null!=b.data&&(b=b.data[b.setting.rowsname],null!=b))for(var c in a)b[d][c]=a[c]}function o(b,d){var a=b.__repeater;if(d<=0)d=1;else if(null!=a.pagecount&&d>a.pagecount)d=a.pagecount;a.pageindex=d;q.call(this,b)}function n(b,d){var a=b.__repeater;if(a.singlethread&&" +
"a.busy)return null!=a.blocked&&a.blocked.call(this,b,{action:d}),!1;a.busy=!0;null!=a.preexecute&&a.preexecute.call(this,b,{action:d});return!0}function h(b,d){var a=b.__repeater;a.busy=!1;null!=a.executed&&a.executed.call(this,b,{action:d})}l.fn.__repeater=function(){if(this.length==0)return this;var b=this.get(0),d=\"create\";if(typeof arguments[0]==\"string\"){if(null==b.__repeater)return this;d=arguments[0]==\"option\"?arguments.length==2?\"get\":\"set\":\"method\"}else arguments[0]=l.extend({},l.fn.__repeater.defaults," +
"arguments[0]);switch(d){case \"get\":return b.__repeater[arguments[1]];case \"set\":return b.__repeater[arguments[1]]=arguments[2];case \"method\":switch(arguments[0]){case \"fill\":q.call(this,b);break;case \"bind\":k.call(this,b,arguments[1]);break;case \"beginedit\":var a=arguments[1];if(null!=a){d=b.__repeater;if(!d.multipleedit)d.index.edit.length=0;b:{for(var c=d.index.edit,e=0;e<c.length;e++)if(c[e]==a)break b;else if(c[e]>a){c.splice(e,0,a);break b}c.push(a)}k.call(this,b,d.data)}break;case \"endedit\":d=" +
"arguments[1];if(null!=d)c=b.__repeater,p.call(this,c.index.edit,d,!1),k.call(this,b,c.data);break;case \"remove\":a:if(d=arguments[1],n.call(this,b,\"remove\")&&null!=d){c=b.__repeater;a=m.call(this,b,d,\"r\");if(null!=c.preremove&&(e=c.preremove.call(this,b,{row:a}),null!=e&&!e)){h.call(this,b,\"remove\");break a}null!=c.remove?c.remove.call(this,b,{index:d,row:a,callback:s}):s.call(this,b,d,a,!0)}break;case \"update\":a:if(d=arguments[1],n.call(this,b,\"update\")&&null!=d){c=b.__repeater;a=m.call(this,b,d," +
"\"u\");if(null!=c.preupdate&&(e=c.preupdate.call(this,b,{row:a}),null!=e&&!e)){h.call(this,b,\"update\");break a}null!=c.update?c.update.call(this,b,{index:d,row:a,callback:t}):t.call(this,b,d,a,!0)}break;case \"insert\":a:if(n.call(this,b,\"insert\")){d=b.__repeater;c=m.call(this,b,0,\"i\");if(null!=d.preinsert&&(a=d.preinsert.call(this,b,{row:c}),null!=a&&!a)){h.call(this,b,\"insert\");break a}null!=d.insert?d.insert.call(this,b,{row:c,callback:v}):v.call(this,b,c,!0)}break;case \"setrow\":u.call(this,b,arguments[1]," +
"arguments[2]);break;case \"getrow\":m.call(this,b,arguments[1],arguments[2]);break;case \"goto\":o.call(this,b,arguments[1]);break;case \"prev\":o.call(this,b,b.__repeater.pageindex-1);break;case \"next\":o.call(this,b,b.__repeater.pageindex+1)}return this;default:return arguments[0].selector=this.selector,arguments[0].pageindex=null==arguments[0].pageindex||arguments[0].pageindex<=0?1:arguments[0].pageindex,arguments[0].pagesize=null==arguments[0].pagesize||arguments[0].pagesize<=0?10:arguments[0].pagesize," +
"arguments[0].field=null==arguments[0].field?[]:arguments[0].field,arguments[0].fieldfixed=arguments[0].field.length!=0,arguments[0].attribute=null==arguments[0].attribute?[]:arguments[0].attribute,arguments[0].attributefixed=arguments[0].attribute.length!=0,arguments[0].template={header:null==arguments[0].header?\"\":arguments[0].header,footer:null==arguments[0].footer?\"\":arguments[0].footer,item:null==arguments[0].item?\"\":arguments[0].item,edititem:null==arguments[0].edititem?\"\":arguments[0].edititem," +
"empty:null==arguments[0].empty?\"\":arguments[0].empty,newitem:null==arguments[0].newitem?\"\":arguments[0].newitem,inserteditem:null==arguments[0].inserteditem?\"\":arguments[0].inserteditem,updateditem:null==arguments[0].updateditem?\"\":arguments[0].updateditem,removeditem:null==arguments[0].removeditem?\"\":arguments[0].removeditem},arguments[0].setting={rowsname:null==arguments[0].rowsname?\"rows\":arguments[0].rowsname},arguments[0].index={edit:null==arguments[0].editindex?[]:arguments[0].editindex},b.__repeater=" +
"arguments[0],this}};l.fn.__repeater.encodeData=function(b){if(null==b)return\"\";var d=\"\",a;for(a in b)d!=\"\"&&(d+=\",\"),d+='\"'+a.toString()+'\": '+(null==b[a]?\"null\":'\"'+b[a].toString()+'\"');return\"{\"+d+\"}\"};l.fn.__repeater.defaults={selector:null,pagesize:10,pageindex:1,pagecount:null,itemcount:null,inserteditemcount:0,updateditemcount:0,deleteditemcount:0,field:null,fieldfixed:!1,attribute:null,attributefixed:!1,header:null,footer:null,item:null,edititem:null,inserteditem:null,updateditem:null,removeditem:null," +
"empty:null,newitem:null,rowsname:\"rows\",editindex:null,multipleedit:!1,prefill:null,fill:null,filled:null,preremove:null,remove:null,removed:null,preupdate:null,update:null,updated:null,preinsert:null,insert:null,inserted:null,navigable:null,busy:!1,blocked:null,singlethread:!0,preexecute:null,executed:null}})(jQuery);";
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
		/// 获取或设置编辑行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
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
		/// 获取或设置新建后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string InsertedItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.inserteditem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.inserteditem, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
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
		/// 获取或设置新建行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
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
		/// 获取或设置删除后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string RemovedItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.removeditem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.removeditem, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置行的属性名称, 默认为 "rows".
		/// </summary>
		public string RowsName
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.rowsname, "rows" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.rowsname, value, "rows" ); }
		}

		/// <summary>
		/// 获取或设置是否为单程处理, 默认为 true.
		/// </summary>
		public bool SingleThread
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.singlethread, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.singlethread, value, true ); }
		}

		/// <summary>
		/// 获取或设置更新后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string UpdatedItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.updateditem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.updateditem, value, string.Empty ); }
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

		/// <summary>
		/// 获取或设置发生阻塞时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Blocked
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.blocked ); }
			set { this.settingHelper.SetOptionValue ( OptionType.blocked, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行操作之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreExecute
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.preexecute ); }
			set { this.settingHelper.SetOptionValue ( OptionType.preexecute, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行操作之后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Executed
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.executed ); }
			set { this.settingHelper.SetOptionValue ( OptionType.executed, value, string.Empty ); }
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

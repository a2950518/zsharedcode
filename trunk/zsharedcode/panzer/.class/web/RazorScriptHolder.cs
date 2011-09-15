/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/RazorScriptHolder.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */
#if V4
using System.Collections.Generic;
using System.Web;
using System.Web.WebPages;

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// razor 页面容器.
	/// </summary>
	public sealed class RazorScriptHolder
		: ScriptHolder
	{
		private readonly WebPageBase page;

		/// <summary>
		/// 创建一个 razor 页面容器.
		/// </summary>
		/// <param name="page">表示页面的 WebPage 对象.</param>
		public RazorScriptHolder ( WebPageBase page )
		{

			if ( null != page && !page.PageData.ContainsKey ( "__ScriptKeys" ) )
				page.PageData["__ScriptKeys"] = new List<string> ( );

			this.page = page;
		}

		/// <summary>
		/// 与 IsClientScriptBlockRegistered 相同.
		/// </summary>
		/// <param name="key">脚本的关键字.</param>
		/// <returns>是否安装了脚本?</returns>
		public override bool IsStartupScriptRegistered ( string key )
		{ return this.IsClientScriptBlockRegistered ( key ); }

		/// <summary>
		/// 判断 razor 页面中是否安装了脚本.
		/// </summary>
		/// <param name="key">脚本的关键字.</param>
		/// <returns>是否安装了脚本?</returns>
		public override bool IsClientScriptBlockRegistered ( string key )
		{

			if ( null == page || string.IsNullOrEmpty ( key ) )
				return false;

			return ( this.page.PageData["__ScriptKeys"] as List<string> ).Contains ( key );
		}

		/// <summary>
		/// 将脚本安装为 aspx 页面的启动脚本.
		/// </summary>
		/// <param name="key">脚本的关键字.</param>
		/// <param name="script">脚本的代码.</param>
		public override void RegisterStartupScript ( string key, string script )
		{ this.RegisterClientScriptBlock ( key, script ); }

		/// <summary>
		/// 脚本安装到 razor 页面.
		/// </summary>
		/// <param name="key">脚本的关键字.</param>
		/// <param name="script">脚本的代码.</param>
		public override void RegisterClientScriptBlock ( string key, string script )
		{

			if ( null == page || string.IsNullOrEmpty ( script ) )
				return;

			this.page.Write ( new HtmlString ( script ) );

			if ( !string.IsNullOrEmpty ( key ) )
				( this.page.PageData["__ScriptKeys"] as List<string> ).Add ( key );

		}

	}

}
#endif

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ASPXScriptHolder.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

using System.Web.UI;

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 表示一个用于写入客户端脚本的 aspx 页面目标.
	/// </summary>
	public sealed class ASPXScriptHolder
		: ScriptHolder
	{
		private readonly Page page;

		/// <summary>
		/// 创建一个用于写入客户端脚本的 aspx 页面目标.
		/// </summary>
		/// <param name="control">控件, 其所在页面将写入客户端脚本.</param>
		public ASPXScriptHolder ( Control control )
			: this ( null == control ? null : control.Page )
		{ }
		/// <summary>
		/// 创建一个用于写入客户端脚本的 aspx 页面目标.
		/// </summary>
		/// <param name="page">将写入客户端脚本的 Page 对象.</param>
		public ASPXScriptHolder ( Page page )
		{ this.page = page; }

		/// <summary>
		/// 判断 aspx 页面中是否安装了指定关键字的脚本.
		/// </summary>
		/// <param name="key">区分不同脚本的关键字.</param>
		/// <returns>如果为 true, 则表示安装了脚本.</returns>
		public override bool IsClientScriptBlockRegistered ( string key )
		{

			if ( null == page || null == page.ClientScript )
				return false;

			return page.ClientScript.IsClientScriptBlockRegistered ( page.GetType ( ), key );
		}

		/// <summary>
		/// 判断 aspx 页面中是否安装了指定关键字的启动脚本.
		/// </summary>
		/// <param name="key">区分不同脚本的关键字.</param>
		/// <returns>如果为 true, 则表示安装了启动脚本.</returns>
		public override bool IsStartupScriptRegistered ( string key )
		{

			if ( null == page || null == page.ClientScript )
				return false;

			return this.page.ClientScript.IsStartupScriptRegistered ( this.page.GetType ( ), key );
		}

		/// <summary>
		/// 为 aspx 页面安装脚本.
		/// </summary>
		/// <param name="key">区分不同脚本的关键字.</param>
		/// <param name="script">脚本的代码.</param>
		public override void RegisterClientScriptBlock ( string key, string script )
		{

			if ( null != page && null != page.ClientScript )
				this.page.ClientScript.RegisterClientScriptBlock ( this.page.GetType ( ), key, script );

		}

		/// <summary>
		/// 为 aspx 页面安装启动脚本.
		/// </summary>
		/// <param name="key">区分不同脚本的关键字.</param>
		/// <param name="script">脚本的代码.</param>
		public override void RegisterStartupScript ( string key, string script )
		{

			if ( null != page && null != page.ClientScript )
				this.page.ClientScript.RegisterStartupScript ( this.page.GetType ( ), key, script );

		}

	}

}

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHolder.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 派生所有的客户端脚本的写入目标, 脚本助手 ScriptHelper 或派生类可以使用其写入脚本.
	/// </summary>
	public abstract class ScriptHolder
	{

		/// <summary>
		/// 判断目标中是否安装了指定关键字的脚本.
		/// </summary>
		/// <param name="key">区分不同脚本的关键字.</param>
		/// <returns>如果为 true, 则表示安装了脚本.</returns>
		public abstract bool IsClientScriptBlockRegistered ( string key );

		/// <summary>
		/// 判断目标中是否安装了指定关键字的启动脚本.
		/// </summary>
		/// <param name="key">区分不同脚本的关键字.</param>
		/// <returns>如果为 true, 则表示安装了启动脚本.</returns>
		public abstract bool IsStartupScriptRegistered ( string key );

		/// <summary>
		/// 为目标安装脚本.
		/// </summary>
		/// <param name="key">区分不同脚本的关键字.</param>
		/// <param name="script">脚本的代码.</param>
		public abstract void RegisterClientScriptBlock ( string key, string script );

		/// <summary>
		/// 为目标安装启动脚本.
		/// </summary>
		/// <param name="key">区分不同脚本的关键字.</param>
		/// <param name="script">脚本的代码.</param>
		public abstract void RegisterStartupScript ( string key, string script );

	}

}

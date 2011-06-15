/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/JQueryUIDraggableSetting
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System.Collections.Generic;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " DraggableSetting "
	/// <summary>
	/// jQuery UI 拖动的相关设置.
	/// </summary>
	public sealed class DraggableSetting
	{
		/// <summary>
		/// 拖动相关选项.
		/// </summary>
		public readonly List<Option> Options = new List<Option> ( );
		/// <summary>
		/// 是否可以拖动.
		/// </summary>
		public readonly bool IsDraggable;

		/// <summary>
		/// 创建 jQuery UI 拖动的相关设置.
		/// </summary>
		/// <param name="isDraggable">是否可以拖动.</param>
		/// <param name="options">拖动相关选项.</param>
		public DraggableSetting ( bool isDraggable, Option[] options )
		{

			if ( null != options )
				foreach ( Option option in options )
					if ( null != option )
						this.Options.Add ( option );

			this.IsDraggable = isDraggable;
		}

	}
	#endregion

}

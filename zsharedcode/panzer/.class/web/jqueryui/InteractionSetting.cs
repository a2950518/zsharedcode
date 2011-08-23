/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/InteractionSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " InteractionType "
	/// <summary>
	/// 交互类型.
	/// </summary>
	public enum InteractionType
	{
		/// <summary>
		/// 拖动.
		/// </summary>
		draggable = 0,
		/// <summary>
		/// 拖放.
		/// </summary>
		droppable = 1,
		/// <summary>
		/// 缩放.
		/// </summary>
		resizable = 2,
		/// <summary>
		/// 选中.
		/// </summary>
		selectable = 3,
		/// <summary>
		/// 排列.
		/// </summary>
		sortable = 4,
	}
	#endregion

	#region " InteractionSetting "
	/// <summary>
	/// 派生所有 jQuery UI 交互设置的基础类.
	/// </summary>
	public abstract class InteractionSetting
		: UISetting
	{

		#region " property "
		private InteractionType interactionType;

		/// <summary>
		/// 获取或设置交互的类型.
		/// </summary>
		public InteractionType InteractionType
		{
			get { return this.interactionType; }
			set { this.interactionType = value; }
		}
		#endregion

		protected InteractionSetting ( InteractionType interactionType, Option[] options )
			: base ( options )
		{ this.interactionType = interactionType; }

	}
	#endregion

}

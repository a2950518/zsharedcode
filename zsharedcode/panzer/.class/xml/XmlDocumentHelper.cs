/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/xml/XmlDocumentHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System.Xml;

namespace zoyobar.shared.panzer.xml
{

	/// <summary>
	/// 处理 XmlDocument 的辅助类.
	/// </summary>
	public sealed partial class XmlDocumentHelper
		: XmlNodeHelper<XmlDocument>
	{
		private string filePath;
		private XmlNodeHelper<XmlNode> fileNodeHelper;
		private XmlNodeHelper<XmlNode> rootNodeHelper;
		private XmlNodeHelper<XmlNode> currentNodeHelper;

		/// <summary>
		/// 获取文件节点辅助类.
		/// </summary>
		public XmlNodeHelper<XmlNode> FileNodeHelper
		{
			get { return this.fileNodeHelper; }
		}

		/// <summary>
		/// 获取根节点辅助类.
		/// </summary>
		public XmlNodeHelper<XmlNode> RootNodeHelper
		{
			get { return this.rootNodeHelper; }
		}

		/// <summary>
		/// 获取根节点.
		/// </summary>
		public XmlNode RootNode
		{
			get
			{

				if ( null == this.rootNodeHelper )
					return null;

				return this.rootNodeHelper.Node;
			}
		}

		/// <summary>
		/// 获取当前节点辅助类.
		/// </summary>
		public XmlNodeHelper<XmlNode> CurrentNodeHelper
		{
			get { return this.currentNodeHelper; }
		}

		/// <summary>
		/// 获取当前节点.
		/// </summary>
		public XmlNode CurrentNode
		{
			get
			{

				if ( null == this.currentNodeHelper )
					return null;

				return this.currentNodeHelper.Node;
			}
		}

		/// <summary>
		/// 获取根节点辅助类是否为空.
		/// </summary>
		public bool IsRootNodeHelperNull
		{
			get { return null == this.rootNodeHelper; }
		}

		/// <summary>
		/// 获取当前节点辅助类是否为空.
		/// </summary>
		public bool IsCurrentNodeHelperNull
		{
			get { return null == this.currentNodeHelper; }
		}

		/// <summary>
		/// 获取当前 Xml 文件的路径.
		/// </summary>
		public string FilePath
		{
			get { return this.filePath; }
		}

#if PARAM
		/// <summary>
		/// 创建一个 XmlDocument 辅助类.
		/// </summary>
		/// <param name="filePath">Xml 文件路径, 默认不载入任何文件.</param>
		public XmlDocumentHelper ( string filePath = null )
#else
		/// <summary>
		/// 创建一个 XmlDocument 辅助类.
		/// </summary>
		/// <param name="filePath">Xml 文件路径.</param>
		public XmlDocumentHelper ( string filePath )
#endif
			: base ( "xml" )
		{ this.Load ( filePath ); }

		/// <summary>
		/// 载入 Xml 文件.
		/// </summary>
		/// <param name="filePath">Xml 文件路径.</param>
		public void Load ( string filePath )
		{

			if ( string.IsNullOrEmpty ( filePath ) )
				return;

			try
			{

				if ( null == this.node )
					this.node = new XmlDocument ( );

				this.node.Load ( filePath );
				this.filePath = filePath;
			}
			catch { }

			if ( this.node.ChildNodes.Count == 2 )
				this.rootNodeHelper = new XmlNodeHelper<XmlNode> ( this.node.ChildNodes[1] );

			this.fileNodeHelper = new XmlNodeHelper<XmlNode> ( this.node );
		}

		/// <summary>
		/// 在 XmlDocument 中导航到指定的节点.
		/// </summary>
		/// <param name="xPath">导航的路径.</param>
		/// <returns>是否导航成功.</returns>
		public bool Navigate ( string xPath )
		{

			if ( null == this.currentNodeHelper )
			{

				if ( null == this.rootNodeHelper )
					return false;

				this.currentNodeHelper = this.rootNodeHelper;
			}

			return this.currentNodeHelper.FetchNodeHelper ( ref this.currentNodeHelper, xPath );
		}

#if PARAM
		/// <summary>
		/// 保存 Xml 文件.
		/// </summary>
		/// <param name="filePath">Xml 文件路径, 默认为载入时的路径.</param>
		public void Save ( string filePath = null )
#else
		/// <summary>
		/// 保存 Xml 文件.
		/// </summary>
		/// <param name="filePath">Xml 文件路径.</param>
		public void Save ( string filePath )
#endif
		{

			if ( null == filePath )
			{

				if ( null == this.filePath )
					return;

				filePath = this.filePath;
			}

			try
			{ this.node.Save ( filePath ); }
			catch { }

		}

		/// <summary>
		/// 重新设置当前节点的位置.
		/// </summary>
		public void Reset ( )
		{ this.currentNodeHelper = null; }

	}

	partial class XmlDocumentHelper
	{
#if !PARAM
		/// <summary>
		/// 创建一个 XmlDocument 辅助类.
		/// </summary>
		public XmlDocumentHelper ( )
			: this ( null )
		{ }

		/// <summary>
		/// 保存 Xml 文件.
		/// </summary>
		public void Save ( )
		{ this.Save ( null ); }
#endif
	}

}

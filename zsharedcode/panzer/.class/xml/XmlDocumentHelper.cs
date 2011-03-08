using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace zoyobar.shared.panzer.xml
{

	/// <summary>
	/// 处理 XmlDocument 的辅助类.
	/// </summary>
	public sealed class XmlDocumentHelper
		: XmlNodeHelper<XmlDocument>
	{
		private string filePath;
		private XmlNodeHelper<XmlNode> fileNodeHelper;
		private XmlNodeHelper<XmlNode> rootNodeHelper;
		private XmlNodeHelper<XmlNode> currentNodeHelper;

		public XmlNodeHelper<XmlNode> FileNodeHelper
		{
			get { return this.fileNodeHelper; }
		}

		public XmlNodeHelper<XmlNode> RootNodeHelper
		{
			get { return this.rootNodeHelper; }
		}

		public XmlNode RootNode
		{
			get
			{

				if ( null == this.rootNodeHelper )
					return null;

				return this.rootNodeHelper.Node;
			}
		}

		public XmlNodeHelper<XmlNode> CurrentNodeHelper
		{
			get { return this.currentNodeHelper; }
		}

		public XmlNode CurrentNode
		{
			get
			{

				if ( null == this.currentNodeHelper )
					return null;

				return this.currentNodeHelper.Node;
			}
		}

		public bool IsRootNodeHelperNull
		{
			get { return null == this.rootNodeHelper; }
		}

		public bool IsCurrentNodeHelperNull
		{
			get { return null == this.currentNodeHelper; }
		}

		public string FilePath
		{
			get { return this.filePath; }
		}

		public XmlDocumentHelper ( string filePath )
			: base ( "xml" )
		{ this.Load(filePath); }

		public void Load ( string filePath )
		{

			if ( string.IsNullOrEmpty ( filePath ) )
				return;

			try
			{
				this.node.Load ( filePath );
				this.filePath = filePath;
			}
			catch { }

			if ( this.node.ChildNodes.Count == 2 )
				this.rootNodeHelper = new XmlNodeHelper<XmlNode> ( this.node.ChildNodes [ 1 ] );
			
			this.fileNodeHelper = new XmlNodeHelper<XmlNode> ( this.node );
		}
	
		public bool Navigate(string xPath)
		{
	
			if (null == this.currentNodeHelper)
			{

				if (null == this.fileNodeHelper)
					return false;
				
				this.currentNodeHelper = this.fileNodeHelper;
			}

			return this.currentNodeHelper.FetchNodeHelper(ref this.currentNodeHelper, xPath);
		}

		public void Save ( string filePath )
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

		public void Reset ( )
		{ this.currentNodeHelper = null; }

	}

}

using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace zoyobar.shared.panzer.xml
{

	public sealed class XmlDocumentHelper
		: XmlNodeHelper<XmlDocument>
	{
		private string filePath;
		private XmlNodeHelper<XmlNode> fileNodeHelper;
		private XmlNodeHelper<XmlNode> rootNodeHelper;
		private XmlNodeHelper<XmlNode> currentNodeHelper;

		public XmlDocumentHelper ( string filePath )
			: base ( "xml" )
		{ this.Load(filePath); }

		public void Load ( string filePath = null )
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

	}

}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;

using zoyobar.shared.panzer.debug;
using zoyobar.shared.panzer.xml;

namespace zoyobar.shared.panzer.test
{

	public class TestXmlNodeHelper
	{
		private readonly Tracer tracer = new Tracer ( );

		public void Test ( )
		{

			if ( this.tracer.WaitInputAChar ( "是否测试 XmlNodeHelper.OuterXml 属性?" ) == 'y' )
				this.TestOuterXml ( );

		}

		public void TestOuterXml ( )
		{
			this.tracer.WriteLine ( "测试属性 OuterXml" );

			try
			{
				XmlNodeHelper<XmlNode> nodeClass = new XmlNodeHelper<XmlNode> ( "class" );

				nodeClass["name"] = "1.1";
				nodeClass["color"] = Color.Red;

				XmlNodeHelper<XmlNode> nodeStudent1 = new XmlNodeHelper<XmlNode> ( "student" );
				nodeStudent1["name"] = "小明";
				nodeStudent1["age"] = 12;

				XmlNodeHelper<XmlNode> nodeStudent2 = new XmlNodeHelper<XmlNode> ( "student" );
				nodeStudent2["name"] = "小红";
				nodeStudent2["age"] = 11;

				nodeClass.ChildNodeHelpers.Add ( nodeStudent1 );
				nodeClass.ChildNodeHelpers.Add ( nodeStudent2 );

				this.tracer.WriteLine ( nodeClass.OuterXml );
			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			this.tracer.WaitPressEnter ( );
		}

	}

}

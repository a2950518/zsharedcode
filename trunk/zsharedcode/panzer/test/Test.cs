using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using zoyobar.shared.panzer.test.ex.da;

namespace zoyobar.shared.panzer.test
{

	public class Test
	{

		[STAThread]
		public static void Main ()
		{
			// TODO: 如果需要测试 Tracer 类, 请使用下面的代码
			// new TestTracer().Test();

			// TODO: 如果需要测试 DataSetHelper 类和 DataSet 类, 请使用下面的代码
			// new TestDataSetHelper().Test();

			// TODO: 如果需要测试 CodingHelper 类, 请使用下面的代码
			// new TestCodingHelper().Test();

			// TODO: 如果需要测试 StoreHelper 类, 请使用下面的代码
			// new TestStoreHelper().Test();

			// TODO: 如果需要测试 DataAdapter 类, 请使用下面的代码
			// new TestDataAdapter().Test();

			// TODO: 如果需要测试 WindowCore 类, 请使用下面的代码
			// new ui.TestWindowCore ().Test ();

			// TODO: 如果需要测试 DataWindowCore 类, 请使用下面的代码
			// new ui.TestDataWindowCore ().Test ();

			// TODO: 如果需要测试 IEBrowser 类, 请使用下面的代码
			 new web.TestIEBrowser ().Test ();

			// TODO: 如果需要测试 EMail 类, 请使用下面的代码
			// new TestEMail ().Test ();

			// TODO: 如果需要测试 StringConvert 类, 请使用下面的代码
			// new TestStringConvert ( ).Test ( );

			// TODO: 如果需要测试 XmlNodeHelper 类, 请使用下面的代码
			// new TestXmlNodeHelper ( ).Test ( );

			// TODO: 如果需要测试 TestXmlSeriation 类, 请使用下面的代码
			// new TestXmlSeriation ( ).Test ( );

			// TODO: 如果需要测试 TestXmlSeriation 类, 请使用下面的代码
			// new web.TestHtmlEditor ( ).Test ( );
		}

	}

}

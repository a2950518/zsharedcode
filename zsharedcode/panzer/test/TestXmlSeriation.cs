using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using zoyobar.shared.panzer.debug;
using zoyobar.shared.panzer.xml;

namespace zoyobar.shared.panzer.test
{

	public class TestXmlSeriation
	{
		private readonly Tracer tracer = new Tracer ( );

		public void Test ( )
		{

			if ( this.tracer.WaitInputAChar ( "是否测试 StringConvert.ToObject<T> 方法?" ) == 'n' )
				return;

			try
			{
				XmlSeriation seriation = XmlSeriationManager.Open ( @"seriation.xml" );

				this.tracer.WriteLine ( string.Format ( "$name={0}, $age={1}", seriation.CreateObject<string> ( "$name" ), seriation.CreateObject<int> ( "$age" ) ) );

				Student student1 = seriation.CreateObject<Student> ( "$student1" );
			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			this.tracer.WaitPressEnter ( );
		}

		public class Student
		{
			private string name;
			private int age;

			public string Name
			{
				get { return this.name; }
				set { this.name = value; }
			}

			public int Age
			{
				get { return this.age; }
				set { this.age = value; }
			}

			public Student ( string name, int age )
			{
				this.name = name;
				this.age = age;
			}

		}

	}

}

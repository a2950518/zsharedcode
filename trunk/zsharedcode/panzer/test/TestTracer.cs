using System;
using System.Collections.Generic;
using System.Text;

using zoyobar.shared.panzer.debug;

namespace zoyobar.shared.panzer.test
{

	public class TestTracer
	{

		public class Student
		{

			public static void Print ( Student student )
			{

				if ( null == student )
					return;

				Console.WriteLine ( string.Format ( "姓名: {0}, 年龄: {1}", student.name, student.age ) );
			}

			private string name;
			private int age;

			public Student ( string name, int age )
			{

				if ( string.IsNullOrEmpty ( name ) )
					throw new NullReferenceException ( "姓名不能为空" );

				this.name = name;
				this.age = age;
			}

			public void GoToSchool ( )
			{ Console.WriteLine ( string.Format ( "{0} goto school", this.name ) ); }

			public string SetName ( string name )
			{

				if ( string.IsNullOrEmpty ( name ) )
					throw new NullReferenceException ( "姓名不能为空" );

				this.name = name;
				return name;
			}

			public string GetName ( )
			{ return name; }

			public string GetName ( int id )
			{ return id.ToString ( ) + name; }

		}

		public void Test ( )
		{
			this.TestConstructor ( );
			this.TestConvertNullToMessage ( );
			this.TestWriteLine ( );
			this.TestWaitPressEnter ( );
			this.TestWaitInputAChar ( );
			this.TestExecute ( );
		}

		public void TestConvertNullToMessage ( )
		{
			Console.WriteLine ( "测试方法 Tracer.ConvertNullToMessage(object)" );

			try
			{
				Console.WriteLine ( string.Format ( "成功: Tracer.ConvertNullToMessage(123), 返回: {0}", Tracer.ConvertNullToMessage ( 123 ) ) );
				Console.WriteLine ( string.Format ( "成功: Tracer.ConvertNullToMessage(null), 返回: {0}", Tracer.ConvertNullToMessage ( null ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 Tracer.ConvertNullToMessage(object, string)" );

			try
			{
				Console.WriteLine ( string.Format ( "成功: Tracer.ConvertNullToMessage(\"jack\", \"空\"), 返回: {0}", Tracer.ConvertNullToMessage ( "jack", "空" ) ) );
				Console.WriteLine ( string.Format ( "成功: Tracer.ConvertNullToMessage(null, \"空\"), 返回: {0}", Tracer.ConvertNullToMessage ( null, "空" ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestConstructor ( )
		{
			Console.WriteLine ( "测试构造函数 new Tracer()" );

			try
			{
				new Tracer ( );
				Console.WriteLine ( "成功: new Tracer()" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试构造函数 new Tracer(bool)" );

			try
			{
				new Tracer ( false );
				Console.WriteLine ( "成功: new Tracer(false)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestWriteLine ( )
		{
			Console.WriteLine ( "测试方法 WriteLine()" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( isDisplay: false );
				Console.WriteLine ( "成功: WriteLine(false)" );
				tracer.WriteLine ( isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(true)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(int)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( blankLineCount: 2 );
				Console.WriteLine ( "成功: WriteLine(2)" );
				tracer.WriteLine ( blankLineCount: 1 );
				Console.WriteLine ( "成功: WriteLine(1)" );
				tracer.WriteLine ( blankLineCount: 0 );
				Console.WriteLine ( "成功: WriteLine(0)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(int, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( blankLineCount: 2, isDisplay: false );
				Console.WriteLine ( "成功: WriteLine(2, false)" );
				tracer.WriteLine ( blankLineCount: 1, isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(1, true)" );
				tracer.WriteLine ( blankLineCount: 0, isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(0, true)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(string)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( "一行文字" );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\")" );
				tracer.WriteLine ( null );
				Console.WriteLine ( "成功: WriteLine(null)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(string, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( "一行文字", isDisplay: false );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", false)" );
				tracer.WriteLine ( "一行文字", isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", true)" );
				tracer.WriteLine ( null, isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(null, true)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(string, int)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( "一行文字", 3 );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", 3)" );
				tracer.WriteLine ( "一行文字", -1 );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", -1)" );
				tracer.WriteLine ( null, 2 );
				Console.WriteLine ( "成功: WriteLine(null, 2)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(string, int, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( "一行文字", 5, true );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", 5, true)" );
				tracer.WriteLine ( "一行文字", -1, true );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", -1, true)" );
				tracer.WriteLine ( "一行文字", 3, false );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", 3, false)" );
				tracer.WriteLine ( null, 2, true );
				Console.WriteLine ( "成功: WriteLine(null, 2, true)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestWaitPressEnter ( )
		{
			Console.WriteLine ( "测试方法 WaitPressEnter()" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WaitPressEnter ( );
				Console.WriteLine ( "成功: WaitPressEnter()" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitPressEnter(bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WaitPressEnter ( isDisplay: true );
				Console.WriteLine ( "成功: WaitPressEnter(true)" );
				tracer.WaitPressEnter ( isDisplay: false );
				Console.WriteLine ( "成功: WaitPressEnter(false)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitPressEnter(string)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WaitPressEnter ( "请按下您的 Enter !!!" );
				Console.WriteLine ( "成功: WaitPressEnter(\"请按下您的 Enter !!!\")" );
				tracer.WaitPressEnter ( null );
				Console.WriteLine ( "成功: WaitPressEnter(null)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitPressEnter(string, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WaitPressEnter ( "请按下您的 Enter !!!", true );
				Console.WriteLine ( "成功: WaitPressEnter(\"请按下您的 Enter !!!\", true)" );
				tracer.WaitPressEnter ( "请按下您的 Enter !!!", false );
				Console.WriteLine ( "成功: WaitPressEnter(\"请按下您的 Enter !!!\", false)" );
				tracer.WaitPressEnter ( null, true );
				Console.WriteLine ( "成功: WaitPressEnter(null, true)" );
				tracer.WaitPressEnter ( null, false );
				Console.WriteLine ( "成功: WaitPressEnter(null, false)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestWaitInputAChar ( )
		{
			Console.WriteLine ( "测试方法 WaitInputAChar()" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(), 返回: {0}", tracer.WaitInputAChar ( ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitInputAChar(string)" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\"), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下" ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null), 返回: {0}", tracer.WaitInputAChar ( null ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitInputAChar(string, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", true), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", isDisplay: true ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", false), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", isDisplay: false ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, true), 返回: {0}", tracer.WaitInputAChar ( null, isDisplay: true ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitInputAChar(string, string)" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", \"a/b\"), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", "a/b" ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", null), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", null ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, \"a/b\"), 返回: {0}", tracer.WaitInputAChar ( null, "a/b" ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, null), 返回: {0}", tracer.WaitInputAChar ( null, null ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitInputAChar(string, string, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", \"a/b\", false), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", "a/b", false ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", null, true), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", null, true ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, \"a/b\", false), 返回: {0}", tracer.WaitInputAChar ( null, "a/b", false ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, null, true), 返回: {0}", tracer.WaitInputAChar ( null, null, true ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestExecute ( )
		{
			Console.WriteLine ( "测试方法 Execute(object, Type, string, FunctionType, Type[], string, string, string, object[][], bool)" );

			try
			{
				Student jack = new Student ( "jack", 10 );
				Student tom = new Student ( "tom", 9 );

				Tracer tracer = new Tracer ( );

				tracer.Execute ( jack, null, "GoToSchool", FunctionType.Method, null, null, null, null,
					new object[][] {
						new object[] { }
					},
					true
					);

				Console.WriteLine ( "成功: Execute(jack, null, \"GoToSchool\", FunctionType.Method, null, null, null, null, new object[][] { new object[] { } }, true)" );

				foreach ( object result in tracer.Execute ( jack, null, "SetName", FunctionType.Method, null, "姓名: {0}", "返回: {0}", "是否测试 SetName ?",
					new object[][] {
						new object[] { "jack2" },
						new object[] { "jack3" }
					},
					false
					)
					)
					Console.WriteLine ( result );

				Console.WriteLine ( "成功: Execute(jack, null, \"SetName\", FunctionType.Method, null, \"姓名: <0>\", \"返回: <0>\", \"是否测试 SetName ?\", new object[][] { new object[] { \"jack2\" }, new object[] { \"jack3\" } }, false)" );

				foreach ( object result in tracer.Execute ( jack, null, "GetName", FunctionType.Method, new Type[] { }, null, "返回: {0}", null,
					new object[][] {
						new object[] { },
						new object[] { }
					},
					true
					)
					)
					Console.WriteLine ( result );

				Console.WriteLine ( "成功: Execute(jack, null, \"GetName\", FunctionType.Method, new Type[] { }, null, \"返回: <0>\", null, new object[][] { new object[] { }, new object[] { } }, true)" );

				foreach ( object result in tracer.Execute ( jack, null, "GetName", FunctionType.Method, new Type[] { typeof ( int ) }, null, "返回: {0}", null,
					new object[][] {
						new object[] { 1 },
						new object[] { 2 }
					},
					true
					)
					)
					Console.WriteLine ( result );

				Console.WriteLine ( "成功: Execute(jack, null, \"GetName\", FunctionType.Method, new Type[] { typeof(int) }, null, \"返回: <0>\", null, new object[][] { new object[] { 1 }, new object[] { 2 } }, true)" );

				foreach ( object result in tracer.Execute ( null, typeof ( Student ), null, FunctionType.Constructor, null, "姓名: {0}, 年龄: {1}", "返回: {0}", null,
					new object[][] {
						new object[] { "lili", 11 },
						new object[] { string.Empty, 12 }
					},
					true
					)
					)
					Console.WriteLine ( result );

				Console.WriteLine ( "成功: Execute(null, typeof(Student), null, FunctionType.Constructor, null, \"姓名: <0>, 年龄: <1>\", \"返回: <0>\", null, new object[][] { new object[] { \"lili\", 11 }, new object[] { \"lucy\", 11 } }, true)" );

				tracer.Execute ( null, typeof ( Student ), "Print", FunctionType.Method, null, null, null, null,
					new object[][] {
						new object[] { jack },
						new object[] { tom }
					},
					false
					);

				Console.WriteLine ( "成功: Execute(null, typeof(Student), \"Print\", FunctionType.Method, null, null, null, null, new object[][] { new object[] { jack }, new object[] { tom } }, false)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

	}

	public class SampleTracer
	{

		public static void Main ( )
		{
			new SampleTracer.TestDog ( ).Test ( );
		}

		public class Dog
		{
			string nickName;
			int price;
			int amount;

			public Dog ( string nickName, int price )
				: this ( nickName, price, 1 )
			{ }

			public Dog ( string nickName, int price, int amount )
			{

				if ( string.IsNullOrEmpty ( nickName ) )
					throw new ArgumentException ( "昵称不能为空", "nickName" );

				if ( price <= 0 || price > 10000 )
					throw new ArgumentException ( "价格不能太离奇", "price" );

				if ( amount <= 0 || amount > 10 )
					amount = 1;

				this.nickName = nickName;
				this.price = price;
				this.amount = amount;
			}

			public int Buy ( int money )
			{ return this.Buy ( money, false ); }
			public int Buy ( int money, bool isDiscount )
			{
				int price;

				if ( isDiscount )
					price = this.price / 2;
				else
					price = this.price;

				if ( this.amount < 0 )
					throw new Exception ( "对不起没有库存了" );

				if ( money < price )
					throw new ArgumentException ( "您支付钱太少了", "money" );

				this.amount--;
				return money - price;
			}

		}

		class TestDog
		{
			// 创建一个 Tracer 对象
			Tracer tracer = new Tracer ( true );

			public void Test ( )
			{
				// 如果不希望显示信息, 可以使用下面的语句
				// this.tracer.IsTraceable = false;

				// 换行 3 次并显示调试信息
				this.tracer.WriteLine ( "---- 开始测试 Dog ----", 3 );

				// 这是一条不显示的信息
				this.tracer.WriteLine ( "这条信息不显示", isDisplay: false );

				// 询问是否测试 Dog 的相关内容, 等待用户输入 g 或者 s, g 则继续
				if ( this.tracer.WaitInputAChar ( "是否测试 Dog 的相关内容?", "g/s" ) == 'g' )
				{
					// 使用 5 组不同的数据测试构造函数 Dog, 之前询问是否测试
					this.tracer.Execute ( null, typeof ( Dog ), null, FunctionType.Constructor, null, null, "返回: {0}", "测试构造函数?",
						new object[][] {
							new object[] {"求生犬", 200, 20},
							new object[] {"哈巴狗", 100},
							new object[] {"狼狗", 0},
							new object[] {"", 100},
							new object[] {"牧羊犬", 20000}
						},
						true
						);

					Dog dog = new Dog ( "狼狗", 200, 2 );

					// 使用 4 组不同的数据测试 Buy 方法, 之前询问是否测试
					this.tracer.Execute ( dog, null, "Buy", FunctionType.Method, new Type[] { typeof ( int ) }, "支付 {0} 元", "找 {0} 元", "测试 Buy(int) 方法?",
						new object[][] {
							new object[] {300},
							new object[] {100},
							new object[] {400},
							new object[] {300}
						},
						true
						);

					dog = new Dog ( "狼狗", 200, 2 );

					// 使用 4 组不同的数据测试打折的 Buy 方法, 之前询问是否测试
					this.tracer.Execute ( dog, null, "Buy", FunctionType.Method, new Type[] { typeof ( int ), typeof ( bool ) }, "支付 {0} 元", "找 {0} 元", "测试 Buy(int, bool) 方法?",
						new object[][] {
							new object[] {300, false},
							new object[] {100, true},
							new object[] {400, true},
							new object[] {300, true}
						},
						true
						);
				}

			}

		}

	}

}

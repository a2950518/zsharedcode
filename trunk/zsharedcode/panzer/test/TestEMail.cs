using System;
using System.Collections.Generic;
using System.Text;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.debug;

namespace zoyobar.shared.panzer.test
{

	public class TestEMail
	{
		private readonly Tracer tracer = new Tracer ();

		public void Test ()
		{

			if ( this.tracer.WaitInputAChar ( "是否测试 EMail 构造方法?" ) == 'y' )
				this.TestConstructor ();

			if ( this.tracer.WaitInputAChar ( "是否测试 EMail.Send 方法?" ) == 'y' )
				this.TestSend ();

		}

		public void TestConstructor ()
		{
			this.tracer.WriteLine ( "测试构造方法 EMail" );

			try
			{
				// TODO: 测试前请填写对应的账号信息

				this.tracer.Execute ( null, typeof ( EMail ), null, FunctionType.Constructor, null, null, null, null,
					new object[][] {
						new object[] { string.Empty, "***", "***", "***@sina.com", null },
						new object[] { "smtp.sina.com", "***", "***", "***@sina.com", "***" },
						new object[] { "smtp.sina.com", "***", "***", "***@sina.com", "***", Encoding.UTF8 }
					},
					false
					);

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			this.tracer.WaitPressEnter ();
		}

		public void TestSend ()
		{
			this.tracer.WriteLine ( "测试方法 Send(string, string, string, string)" );

			try
			{
				// TODO: 测试前请填写对应的账号信息
				EMail mail = new EMail ( "smtp.qq.com", "***", "***", "***@qq.com", "***", Encoding.UTF8 );

				this.tracer.Execute ( mail, null, "Send", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ), typeof ( string ), typeof ( string ) }, "主题: {0}, 接收地址: {1}, 接收人: {2}, 内容: {3}", null, null,
					new object[][] {
						new object[] { "Test", "***@126.com", "***", "测试, 邮件!!!" }
					},
					false
					);

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			this.tracer.WriteLine ( "测试方法 Send(string, string, string, string, bool)" );

			try
			{
				// TODO: 测试前请填写对应的账号信息
				EMail mail = new EMail ( "smtp.sina.com", "***", "***", "***@sina.com", "***", Encoding.UTF8 );

				this.tracer.Execute ( mail, null, "Send", FunctionType.Method, new Type[] { typeof ( string ), typeof ( string ), typeof ( string ), typeof ( string ), typeof ( bool ) }, "主题: {0}, 接收地址: {1}, 接收人: {2}, 内容: {3}, html 代码: {4}", null, null,
					new object[][] {
						new object[] { "Test", "***@126.com", "***", "<strong>测试, 邮件!!!</strong>", true }
					},
					false
					);

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			this.tracer.WaitPressEnter ();
		}

	}

}

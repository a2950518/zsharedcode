using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using zoyobar.shared.panzer.debug;
using zoyobar.shared.panzer.io;

namespace zoyobar.shared.panzer.test
{

	public class TestStoreHelper
	{
		private readonly Tracer tracer = new Tracer();

		public void Test()
		{

			if (this.tracer.WaitInputAChar("是否测试 StoreHelper.Write 方法?") == 'y')
				this.TestWrite();

			if (this.tracer.WaitInputAChar("是否测试 StoreHelper.Read 方法?") == 'y')
				this.TestRead();

		}

		public void TestWrite()
		{
			this.tracer.WriteLine("测试方法 Write(string, string)");

			try
			{
				StoreHelper.Write(@"temp.txt", "测试");

				this.tracer.WriteLine(string.Format("成功: 写入文件 temp.txt, 内容为 {0}", File.ReadAllText(@"temp.txt", Encoding.Default)));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }


			this.tracer.WriteLine("测试方法 Write(string, string, Encoding)");

			try
			{
				File.WriteAllText(@"temp.txt", "测试", Encoding.UTF8);

				this.tracer.WriteLine(string.Format("成功: 以 UTF8 写入文件 temp.txt, 内容为 {0}", File.ReadAllText(@"temp.txt", Encoding.UTF8)));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

			this.tracer.WaitPressEnter();
		}

		public void TestRead()
		{
			this.tracer.WriteLine("测试方法 Read(string)");

			try
			{ this.tracer.WriteLine(string.Format("成功: 读取文件 test.xml, {0}", StoreHelper.Read(@"test.xml"))); }
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }


			this.tracer.WriteLine("测试方法 Read(string, Encoding)");

			try
			{ this.tracer.WriteLine(string.Format("成功: 以 ASCII 读取文件 test.xml, {0}", StoreHelper.Read(@"test.xml", Encoding.ASCII))); }
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

			this.tracer.WaitPressEnter();
		}

	}

}

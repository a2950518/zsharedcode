using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using zoyobar.shared.panzer.debug;
using zoyobar.shared.panzer.code;

namespace zoyobar.shared.panzer.test
{

	public class TestCodingHelper
	{
		private readonly Tracer tracer = new Tracer();

		public void Test()
		{

			if (this.tracer.WaitInputAChar("是否测试 CodeHelper.Build 方法?") == 'y')
				this.TestBuild();

			if (this.tracer.WaitInputAChar("是否测试 CodeHelper.BuildToFile 方法?") == 'y')
				this.TestBuildToFile();

		}

		public void TestBuild()
		{
			this.tracer.WriteLine("测试方法 Build(string, Regex, string)");

			try
			{
				File.WriteAllText(@"temp.txt", "小马：22\n小红：25");

				this.tracer.WriteLine(string.Format("成功: 转化文件 temp.txt 为 sql 脚本 {0}, 由于没有指定编码, 所以可能出现乱码, 无法正常转化", CodingHelper.Build("INSERT INTO student (name, age) VALUES ('$1', $2)", new Regex("(\\w+)：(\\w+)$", RegexOptions.Multiline), @"temp.txt")));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }


			this.tracer.WriteLine("测试方法 Build(string, Regex, string, Encoding)");

			try
			{
				File.WriteAllText(@"temp.txt", "小马：22\n小红：25", Encoding.UTF8);

				this.tracer.WriteLine(string.Format("成功: 转化 UTF8 编码文件 temp.txt 为 sql 脚本 {0}", CodingHelper.Build("INSERT INTO student (name, age) VALUES ('$1', $2)", new Regex("(\\w+)：(\\w+)$", RegexOptions.Multiline), @"temp.txt", Encoding.UTF8)));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }


			this.tracer.WriteLine("测试方法 Build(string, string, Regex)");

			try
			{ this.tracer.WriteLine(string.Format("成功: 转化文本 '小马：22\\n小红：25' 为 sql 脚本 {0}", CodingHelper.Build("INSERT INTO student (name, age) VALUES ('$1', $2)", "小马：22\n小红：25", new Regex("(\\w+)：(\\w+)$", RegexOptions.Multiline)))); }
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

			this.tracer.WaitPressEnter();
		}

		public void TestBuildToFile()
		{
			this.tracer.WriteLine("测试方法 BuildToFile(string, Regex, string, string)");

			try
			{
				File.WriteAllText(@"temp.txt", "小马：22\n小红：25", Encoding.Default);
				CodingHelper.BuildToFile("INSERT INTO student (name, age) VALUES ('$1', $2)", new Regex("(\\w+)：(\\w+)$", RegexOptions.Multiline), @"temp.txt", @"output.txt");

				this.tracer.WriteLine(string.Format("成功: 转化文件 temp.txt 为 sql 脚本并输出到 output.txt, 内容为 {0}, 由于没有指定编码, 所以可能出现乱码, 无法正常转化", File.ReadAllText(@"output.txt", Encoding.Default)));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }


			this.tracer.WriteLine("测试方法 BuildToFile(string, Regex, string, string, Encoding)");

			try
			{
				File.WriteAllText(@"temp.txt", "小马：22\n小红：25", Encoding.Default);
				CodingHelper.BuildToFile("INSERT INTO student (name, age) VALUES ('$1', $2)", new Regex("(\\w+)：(\\w+)$", RegexOptions.Multiline), @"temp.txt", @"output.txt", Encoding.UTF8);

				this.tracer.WriteLine(string.Format("成功: 转化文件 temp.txt 为 sql 脚本并输出到编码为 UTF8 的 output.txt, 内容为 {0}", File.ReadAllText(@"output.txt", Encoding.UTF8)));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }


			this.tracer.WriteLine("测试方法 BuildToFile(string, Regex, string, Encoding, string)");

			try
			{
				File.WriteAllText(@"temp.txt", "小马：22\n小红：25", Encoding.UTF8);
				CodingHelper.BuildToFile("INSERT INTO student (name, age) VALUES ('$1', $2)", new Regex("(\\w+)：(\\w+)$", RegexOptions.Multiline), @"temp.txt", Encoding.UTF8, @"output.txt");

				this.tracer.WriteLine(string.Format("成功: 转化文件 UTF8 的 temp.txt 为 sql 脚本并输出到编码为 output.txt, 内容为 {0}", File.ReadAllText(@"output.txt", Encoding.Default)));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }


			this.tracer.WriteLine("测试方法 BuildToFile(string, Regex, string, Encoding, string, Encoding)");

			try
			{
				File.WriteAllText(@"temp.txt", "小马：22\n小红：25", Encoding.UTF8);
				CodingHelper.BuildToFile("INSERT INTO student (name, age) VALUES ('$1', $2)", new Regex("(\\w+)：(\\w+)$", RegexOptions.Multiline), @"temp.txt", Encoding.UTF8, @"output.txt", Encoding.UTF8);

				this.tracer.WriteLine(string.Format("成功: 转化文件 UTF8 的 temp.txt 为 sql 脚本并输出到编码为 UTF8 的 output.txt, 内容为 {0}", File.ReadAllText(@"output.txt", Encoding.UTF8)));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }


			this.tracer.WriteLine("测试方法 BuildToFile(string, string, Regex, string)");

			try
			{
				CodingHelper.BuildToFile("INSERT INTO student (name, age) VALUES ('$1', $2)", "小马：22\n小红：25", new Regex("(\\w+)：(\\w+)$", RegexOptions.Multiline), @"output.txt");

				this.tracer.WriteLine(string.Format("成功: 转化文本 '小马：22\\n小红：25' 为 sql 脚本并输出到 output.txt, 内容为 {0}, 由于没有指定编码, 所以可能出现乱码, 无法正常转化", File.ReadAllText(@"output.txt", Encoding.Default)));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }


			this.tracer.WriteLine("测试方法 BuildToFile(string, string, Regex, string, Encoding)");

			try
			{
				CodingHelper.BuildToFile("INSERT INTO student (name, age) VALUES ('$1', $2)", "小马：22\n小红：25", new Regex("(\\w+)：(\\w+)$", RegexOptions.Multiline), @"output.txt", Encoding.Unicode);

				this.tracer.WriteLine(string.Format("成功: 转化文本 '小马：22\\n小红：25' 为 sql 脚本并输出到 output.txt, 内容为 {0}", File.ReadAllText(@"output.txt", Encoding.Unicode)));
			}
			catch (Exception err)
			{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

			this.tracer.WaitPressEnter();
		}

	}

}

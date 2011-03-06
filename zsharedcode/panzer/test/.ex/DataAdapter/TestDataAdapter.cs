/*
 * 参考文档: http://mscxc.blog.com/2010/04/16/dadataadapter/
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://mscxc.blog.com/2010/01/28/panzernetsharedcode/
 * 在运行之前, 请确保已经下载数据库压缩文件并解压到本项目目录下 https://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/test.zip
 * */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlServerCe;

using zoyobar.shared.panzer.debug;

namespace zoyobar.shared.panzer.test.ex.da
{

	public partial class TestDataAdapter
	{
		private readonly Tracer tracer = new Tracer();
		private string connectionString = string.Empty;

		public void Test()
		{

			if (!EXTestHelper.InitDatabase(@"DataAdapterTest.mdf"))
			{
				this.tracer.WriteLine("错误: 初始化数据库失败, 无法继续测试");
				return;
			}

			try
			{
				// TODO:	请在此处修改数据库的位置
				this.connectionString = string.Format("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"{0}\";Integrated Security=True;User Instance=True", Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\", string.Empty), @"DataAdapterTest.mdf"));
			}
			catch { }

			if (this.tracer.WaitInputAChar("是否测试 DbCommand 对象?") == 'y')
				this.TestDbCommand();

			if (this.tracer.WaitInputAChar("是否测试 DbParameter 对象?") == 'y')
				this.TestDbParameter();

			if (this.tracer.WaitInputAChar("是否测试 DataAdapter 对象?") == 'y')
				this.Test_DataAdapter();

		}

	}

}

/*
 * 参考文档: http://mscxc.blog.com/2010/01/30/dsdataset/
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://mscxc.blog.com/2010/01/28/panzernetsharedcode/
 * */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlServerCe;

using zoyobar.shared.panzer.debug;

namespace zoyobar.shared.panzer.test.ex.ds
{

	public partial class TestDataSet
	{
		private readonly Tracer tracer = new Tracer();

		public void Test()
		{

			if (this.tracer.WaitInputAChar("是否测试 ReadXml 方法?") == 'y')
				this.TestReadXml();

			if (this.tracer.WaitInputAChar("是否测试 RowState 属性?") == 'y')
				this.TestRowState();

			if (this.tracer.WaitInputAChar("是否测试 DataRelation 对象?") == 'y')
				this.TestDataRelation();

		}

	}

}

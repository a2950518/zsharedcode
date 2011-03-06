/*
 * 参考文档: http://mscxc.blog.com/2010/01/30/dsdatasetreadxml/
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

	partial class TestDataSet
	{

		public void TestReadXml()
		{
			this.tracer.WriteLine("测试方法 ReadXml");

			#region "是否测试载入 xml 文件的格式要求?"
			if (this.tracer.WaitInputAChar("是否测试载入 xml 文件的格式要求?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						File.WriteAllText(@"temp.xml", string.Empty);
						this.tracer.WriteLine("写入空的字符串到 temp.xml");

						try
						{
							dataSet.ReadXml(@"temp.xml");
							this.tracer.WriteLine("读取 temp.xml");
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						File.WriteAllText(@"temp.xml", "<TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
							"<Student>" +
							"<Name>小明</Name>" +
							"<Age>12</Age>" +
							"</Student>" +
							"</TestDS>"
							);
						this.tracer.WriteLine("写入没有 <?xml?> 的 xml 到 temp.xml");

						try
						{
							dataSet.ReadXml(@"temp.xml");
							this.tracer.WriteLine("读取 temp.xml");

							foreach (DataRow row in dataSet.Tables["Student"].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试载入 xml 文件的编码区别?"
			if (this.tracer.WaitInputAChar("是否测试载入 xml 文件的编码区别?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						File.WriteAllText(@"temp.xml", "<?xml version=\"1.0\" encoding=\"utf-32\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
							"<Student>" +
							"<Name>小明</Name>" +
							"<Age>12</Age>" +
							"</Student>" +
							"</TestDS>",
							Encoding.UTF32
							);
						this.tracer.WriteLine("写入采用 utf-32 的 xml 到 temp.xml");

						try
						{
							dataSet.ReadXml(@"temp.xml");
							this.tracer.WriteLine("读取 temp.xml");

							foreach (DataRow row in dataSet.Tables["Student"].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						File.WriteAllText(@"temp.xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
							"<Student>" +
							"<Name>小明</Name>" +
							"<Age>12</Age>" +
							"</Student>" +
							"</TestDS>",
							Encoding.UTF32
							);
						this.tracer.WriteLine("写入标记为 utf-8 但采用 utf-32 的 xml 到 temp.xml");

						try
						{
							dataSet.ReadXml(@"temp.xml");
							this.tracer.WriteLine("读取 temp.xml");

							foreach (DataRow row in dataSet.Tables["Student"].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						File.WriteAllText(@"temp.xml", "<?xml version=\"1.0\" encoding=\"utf-32\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
							"<Student>" +
							"<Name>小明</Name>" +
							"<Age>12</Age>" +
							"</Student>" +
							"</TestDS>",
							Encoding.UTF8
							);
						this.tracer.WriteLine("写入标记为 utf-32 但采用 utf-8 的 xml 到 temp.xml");

						try
						{
							dataSet.ReadXml(@"temp.xml");
							this.tracer.WriteLine("读取 temp.xml");

							foreach (DataRow row in dataSet.Tables["Student"].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						File.WriteAllText(@"temp.xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
							"<Student>" +
							"<Name>小哈雷</Name>" +
							"<Age>12</Age>" +
							"</Student>" +
							"</TestDS>",
							Encoding.ASCII
							);
						this.tracer.WriteLine("写入标记为 utf-8 但采用 ASCII 的 xml 到 temp.xml");

						try
						{
							dataSet.ReadXml(@"temp.xml");
							this.tracer.WriteLine("读取 temp.xml");

							foreach (DataRow row in dataSet.Tables["Student"].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试 XmlReadMode 参数对 DataSet 读取 xml 文件的影响?"
			if (this.tracer.WaitInputAChar("是否测试 XmlReadMode 参数对 DataSet 读取 xml 文件的影响?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet("TestDS"))
					{
						dataSet.Namespace = "http://tempuri.org/TestDS.xsd";
						dataSet.Tables.Add("S1");

						dataSet.Tables.Add("T1").Columns.AddRange(
							new DataColumn[] {
						        new DataColumn("Name", typeof(string)),
						        new DataColumn("Age", typeof(int))
						    }
							);

						dataSet.Tables.Add("Student").Columns.AddRange(
							new DataColumn[] {
						        new DataColumn("Name", typeof(string)),
						        new DataColumn("Age", typeof(int))
						    }
							);

						dataSet.Tables.Add("Teacher");

						File.WriteAllText(@"temp.xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
							"<Student>" +
							"<Name>小明</Name>" +
							"<Age>12</Age>" +
							"</Student>" +
							"<Teacher>" +
							"<Name>王老师</Name>" +
							"<Age>32</Age>" +
							"</Teacher>" +
							"<Room>" +
							"<ID>123</ID>" +
							"</Room>" +
							"</TestDS>",
							Encoding.UTF8
							);
						this.tracer.WriteLine("写入包含表 Student(Name, Age), Teacher(Name, Age), Room(ID) 的 xml 到 temp.xml");
						this.tracer.WriteLine("数据集中定义了 S1, T1(Name, Age), Student(Name, Age), Teacher 表");

						try
						{
							dataSet.ReadXml(@"temp.xml");
							this.tracer.WriteLine("读取 temp.xml");

							foreach (DataTable table in dataSet.Tables)
							{
								this.tracer.WriteLine(string.Format("表 {0}", table.TableName));

								foreach (DataRow row in table.Rows)
									foreach (DataColumn column in table.Columns)
										this.tracer.WriteLine(string.Format("{0} = {1}", column.ColumnName, row[column]));

							}

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{

						File.WriteAllText(@"temp.xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
							"<Room>" +
							"<ID>123</ID>" +
							"</Room>" +
							"<Room>" +
							"<ID>123</ID>" +
							"<Name>储藏室</Name>" +
							"</Room>" +
							"</TestDS>",
							Encoding.UTF8
							);
						this.tracer.WriteLine("写入包含表 Room(ID, Name) 的 xml 到 temp.xml");

						try
						{
							dataSet.ReadXml(@"temp.xml");
							this.tracer.WriteLine("读取 temp.xml");

							this.tracer.WriteLine(string.Format("数据集名称: {0}, 命名空间: {1}", dataSet.DataSetName, dataSet.Namespace));

							foreach (DataTable table in dataSet.Tables)
							{
								this.tracer.WriteLine(string.Format("表 {0}", table.TableName));

								foreach (DataRow row in table.Rows)
									foreach (DataColumn column in table.Columns)
										this.tracer.WriteLine(string.Format("{0} = {1}", column.ColumnName, row[column]));

							}

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试载入 xml 字符串, byte[] 数组到 DataSet?"
			if (this.tracer.WaitInputAChar("是否测试载入 xml 字符串, byte[] 数组到 DataSet?") == 'y')
			{

				try
				{


					using (DataSet dataSet = new DataSet())
					{

						try
						{
							dataSet.ReadXml(new StringReader("<?xml version=\"1.0\" encoding=\"utf-8\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
								"<Student>" +
								"<Name>小明</Name>" +
								"<Age>12</Age>" +
								"</Student>" +
								"</TestDS>"
								)
								);
							this.tracer.WriteLine("读取标记为 utf-8 的字符串到数据集");

							this.tracer.WriteLine(string.Format("数据集名称: {0}, 命名空间: {1}", dataSet.DataSetName, dataSet.Namespace));

							foreach (DataRow row in dataSet.Tables[0].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{

						try
						{
							dataSet.ReadXml(new StringReader("<?xml version=\"1.0\" encoding=\"gb2312\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
								"<Student>" +
								"<Name>小明</Name>" +
								"<Age>12</Age>" +
								"</Student>" +
								"</TestDS>"
								)
								);
							this.tracer.WriteLine("读取标记为 gb2312 的字符串到数据集");

							this.tracer.WriteLine(string.Format("数据集名称: {0}, 命名空间: {1}", dataSet.DataSetName, dataSet.Namespace));

							foreach (DataRow row in dataSet.Tables[0].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{

						try
						{
							dataSet.ReadXml(new StringReader("<?xml version=\"1.0\" encoding=\"ascii\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
								"<Student>" +
								"<Name>小明</Name>" +
								"<Age>12</Age>" +
								"</Student>" +
								"</TestDS>"
								)
								);
							this.tracer.WriteLine("读取标记为 ascii 的字符串到数据集");

							this.tracer.WriteLine(string.Format("数据集名称: {0}, 命名空间: {1}", dataSet.DataSetName, dataSet.Namespace));

							foreach (DataRow row in dataSet.Tables[0].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{

						try
						{
							byte[] bytes = Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"utf-8\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
								"<Student>" +
								"<Name>小明</Name>" +
								"<Age>12</Age>" +
								"</Student>" +
								"</TestDS>"
								);

							dataSet.ReadXml(new MemoryStream(bytes));
							this.tracer.WriteLine("读取 UTF8 比特数组到数据集");

							foreach (DataRow row in dataSet.Tables[0].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{

						try
						{
							byte[] bytes = Encoding.UTF32.GetBytes("<?xml version=\"1.0\" encoding=\"utf-32\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
								"<Student>" +
								"<Name>小明</Name>" +
								"<Age>12</Age>" +
								"</Student>" +
								"</TestDS>"
								);

							dataSet.ReadXml(new MemoryStream(bytes));
							this.tracer.WriteLine("读取 UTF32 比特数组到数据集");

							foreach (DataRow row in dataSet.Tables[0].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{

						try
						{
							byte[] bytes = Encoding.BigEndianUnicode.GetBytes("<?xml version=\"1.0\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
								"<Student>" +
								"<Name>小明</Name>" +
								"<Age>12</Age>" +
								"</Student>" +
								"</TestDS>"
								);

							dataSet.ReadXml(new MemoryStream(bytes));
							this.tracer.WriteLine("读取 BigEndianUnicode 比特数组到数据集");

							foreach (DataRow row in dataSet.Tables[0].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{

						try
						{
							byte[] bytes = Encoding.ASCII.GetBytes("<?xml version=\"1.0\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
								"<Student>" +
								"<Name>小明</Name>" +
								"<Age>12</Age>" +
								"</Student>" +
								"</TestDS>"
								);

							dataSet.ReadXml(new MemoryStream(bytes));
							this.tracer.WriteLine("读取 ASCII 比特数组到数据集");

							foreach (DataRow row in dataSet.Tables[0].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}", row["Name"], row["Age"]));

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

		}

	}

}

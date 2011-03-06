/*
 * 参考文档: http://mscxc.blog.com/2010/02/02/dsdatarowrowstate/
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

		public void TestRowState()
		{
			this.tracer.WriteLine("测试属性 RowState");

			#region "是否测试从不同位置载入 DataRow 后 RowState 的状态?"
			if (this.tracer.WaitInputAChar("是否测试从不同位置载入 DataRow 后 RowState 的状态?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						File.WriteAllText(@"temp.xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?><TestDS xmlns=\"http://tempuri.org/TestDS.xsd\">" +
							"<Student>" +
							"<Name>小明</Name>" +
							"<Age>12</Age>" +
							"</Student>" +
							"</TestDS>");
						this.tracer.WriteLine("写入包含表 Student(Name, Age) 的 xml 到 temp.xml");

						try
						{
							dataSet.ReadXml(@"temp.xml");
							this.tracer.WriteLine("读取 temp.xml");

							foreach (DataTable table in dataSet.Tables)
							{
								this.tracer.WriteLine(string.Format("表 {0}", table.TableName));

								foreach (DataRow row in table.Rows)
									this.tracer.WriteLine(string.Format("状态: {0}", row.RowState));

							}

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int))
							}
							);

						this.tracer.WriteLine("创建表 Student(Name, Age) 到数据集");

						dataSet.Tables["Student"].Rows.Add("小明", "11");
						this.tracer.WriteLine("向表 Student 添加数据");

						foreach (DataTable table in dataSet.Tables)
						{
							this.tracer.WriteLine(string.Format("表 {0}", table.TableName));

							foreach (DataRow row in table.Rows)
								this.tracer.WriteLine(string.Format("状态: {0}", row.RowState));

						}

					}


					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							foreach (DataTable table in dataSet.Tables)
							{
								this.tracer.WriteLine(string.Format("表 {0}", table.TableName));

								foreach (DataRow row in table.Rows)
									this.tracer.WriteLine(string.Format("状态: {0}", row.RowState));

							}

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");
						adapter.AcceptChangesDuringFill = false;

						this.tracer.WriteLine(string.Format("将 AcceptChangesDuringFill 属性设置为 false"));

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							foreach (DataTable table in dataSet.Tables)
							{
								this.tracer.WriteLine(string.Format("表 {0}", table.TableName));

								foreach (DataRow row in table.Rows)
									this.tracer.WriteLine(string.Format("状态: {0}", row.RowState));

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

			#region "是否测试修改, 更改, 删除后的 DataRow.RowState 转化?"
			if (this.tracer.WaitInputAChar("是否测试修改, 更改, 删除后的 DataRow.RowState 转化?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", dataSet.Tables[0].Rows[0].RowState));

							int age = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Age"]);

							dataSet.Tables[0].Rows[0]["Age"] = 22;
							this.tracer.WriteLine(string.Format("修改表 Student 第 1 条记录的年龄后, 状态为: {0}", dataSet.Tables[0].Rows[0].RowState));

							dataSet.Tables[0].Rows[0]["Age"] = age;
							this.tracer.WriteLine(string.Format("修改表 Student 第 1 条记录的年龄为原值后, 状态为: {0}", dataSet.Tables[0].Rows[0].RowState));

							SqlCeCommandBuilder builder = new SqlCeCommandBuilder(adapter);
							adapter.UpdateCommand = builder.GetUpdateCommand();
							adapter.Update(dataSet);
							this.tracer.WriteLine("将数据集的修改更新到本地 Test.sdf 数据库");

							this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", dataSet.Tables[0].Rows[0].RowState));
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int))
							}
							);

						this.tracer.WriteLine("创建表 Student(Name, Age) 到数据集");

						dataSet.Tables["Student"].Rows.Add("小明", "11");
						this.tracer.WriteLine("向表 Student 添加数据");

						this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", dataSet.Tables["Student"].Rows[0].RowState));

						dataSet.Tables["Student"].Rows[0]["Age"] = 22;
						this.tracer.WriteLine(string.Format("修改表 Student 第 1 条记录的年龄后, 状态为: {0}", dataSet.Tables["Student"].Rows[0].RowState));

						dataSet.Tables["Student"].Rows[0]["Name"] = "jack";
						this.tracer.WriteLine(string.Format("修改表 Student 第 1 条记录的姓名后, 状态为: {0}", dataSet.Tables["Student"].Rows[0].RowState));
					}


					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");
						SqlCeCommandBuilder builder = new SqlCeCommandBuilder(adapter);
						adapter.DeleteCommand = builder.GetDeleteCommand();
						adapter.UpdateCommand = builder.GetUpdateCommand();
						adapter.InsertCommand = builder.GetInsertCommand();

						adapter.AcceptChangesDuringUpdate = false;

						this.tracer.WriteLine(string.Format("将 AcceptChangesDuringUpdate 属性设置为 false"));


						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							DataRow newRow = dataSet.Tables[0].Rows.Add("小心心", 10);

							dataSet.Tables[0].Rows[0]["Age"] = 22;
							dataSet.Tables[0].Rows[1].Delete();
							this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", dataSet.Tables[0].Rows[0].RowState));
							this.tracer.WriteLine(string.Format("表 Student 第 2 条记录的状态为: {0}", dataSet.Tables[0].Rows[1].RowState));
							this.tracer.WriteLine(string.Format("表 Student 第 3 条记录的状态为: {0}", dataSet.Tables[0].Rows[2].RowState));
							this.tracer.WriteLine(string.Format("表 Student 新记录的状态为: {0}", newRow.RowState));

							adapter.Update(dataSet);
							this.tracer.WriteLine("将数据集更新到本地 Test.sdf 数据库");

							this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", dataSet.Tables[0].Rows[0].RowState));
							this.tracer.WriteLine(string.Format("表 Student 第 2 条记录的状态为: {0}", dataSet.Tables[0].Rows[1].RowState));
							this.tracer.WriteLine(string.Format("表 Student 第 3 条记录的状态为: {0}", dataSet.Tables[0].Rows[2].RowState));
							this.tracer.WriteLine(string.Format("表 Student 新记录的状态为: {0}", newRow.RowState));
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", dataSet.Tables[0].Rows[0].RowState));
							this.tracer.WriteLine(string.Format("表 Student 第 2 条记录的状态为: {0}", dataSet.Tables[0].Rows[1].RowState));

							DataRow row1 = dataSet.Tables[0].Rows[0];
							DataRow row2 = dataSet.Tables[0].Rows[1];
							row1.Delete();
							this.tracer.WriteLine(string.Format("对第 1 条记录调用 Delete 方法后状态为 {0}", row1.RowState));
							dataSet.Tables[0].Rows.Remove(row2);
							this.tracer.WriteLine(string.Format("对第 2 条记录调用 Remove 方法后状态为 {0}", row2.RowState));
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int))
							}
							);

						this.tracer.WriteLine("创建表 Student(Name, Age) 到数据集");

						dataSet.Tables["Student"].Rows.Add("小明", "11");
						dataSet.Tables["Student"].Rows.Add("小哈", "13");
						this.tracer.WriteLine("向表 Student 添加数据");

						this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", dataSet.Tables["Student"].Rows[0].RowState));
						this.tracer.WriteLine(string.Format("表 Student 第 2 条记录的状态为: {0}", dataSet.Tables["Student"].Rows[1].RowState));

						DataRow row1 = dataSet.Tables["Student"].Rows[0];
						DataRow row2 = dataSet.Tables["Student"].Rows[1];
						row1.Delete();
						this.tracer.WriteLine(string.Format("对第 1 条记录调用 Delete 方法后状态为 {0}", row1.RowState));
						dataSet.Tables["Student"].Rows.Remove(row2);
						this.tracer.WriteLine(string.Format("对第 2 条记录调用 Remove 方法后状态为 {0}", row2.RowState));
					}


				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试使用 AcceptChanges, RejectChanges, SetAdded, SetModified 方法后 DataRow.RowState 的转化?"
			if (this.tracer.WaitInputAChar("是否测试使用 AcceptChanges, RejectChanges, SetAdded, SetModified 方法后 DataRow.RowState 的转化?") == 'y')
			{

				try
				{


					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							DataRow row1 = dataSet.Tables[0].Rows[0];
							DataRow row2 = dataSet.Tables[0].Rows[1];
							DataRow row3 = dataSet.Tables[0].Rows[2];
							DataRow row4 = dataSet.Tables[0].Rows[3];

							this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", row1.RowState));
							row1.AcceptChanges();
							this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 AcceptChanges 方法后的状态为: {0}", row1.RowState));

							row2["Age"] = 21;
							this.tracer.WriteLine(string.Format("对表 Student 第 2 条记录修改后的状态为: {0}", row2.RowState));
							row2.AcceptChanges();
							this.tracer.WriteLine(string.Format("对表 Student 第 2 条记录调用 AcceptChanges 方法后的状态为: {0}", row2.RowState));

							row3.SetAdded();
							this.tracer.WriteLine(string.Format("对表 Student 第 3 条记录调用 SetAdded 方法后的状态为: {0}", row3.RowState));
							row3.AcceptChanges();
							this.tracer.WriteLine(string.Format("对表 Student 第 3 条记录调用 AcceptChanges 方法后的状态为: {0}", row3.RowState));

							row4.Delete();
							this.tracer.WriteLine(string.Format("对表 Student 第 4 条记录调用 Delete 方法后的状态为: {0}", row4.RowState));
							row4.AcceptChanges();
							this.tracer.WriteLine(string.Format("对表 Student 第 4 条记录调用 AcceptChanges 方法后的状态为: {0}", row4.RowState));

							try
							{
								dataSet.Tables[0].Rows.Remove(row1);
								this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 Remove 方法后的状态为: {0}", row1.RowState));
								row1.AcceptChanges();
								this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 AcceptChanges 方法后的状态为: {0}", row1.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							DataRow row1 = dataSet.Tables[0].Rows[0];
							DataRow row2 = dataSet.Tables[0].Rows[1];
							DataRow row3 = dataSet.Tables[0].Rows[2];
							DataRow row4 = dataSet.Tables[0].Rows[3];

							this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", row1.RowState));
							row1.RejectChanges();
							this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 RejectChanges 方法后的状态为: {0}", row1.RowState));

							row2["Age"] = 21;
							this.tracer.WriteLine(string.Format("对表 Student 第 2 条记录修改后的状态为: {0}", row2.RowState));
							row2.RejectChanges();
							this.tracer.WriteLine(string.Format("对表 Student 第 2 条记录调用 RejectChanges 方法后的状态为: {0}", row2.RowState));

							row3.SetAdded();
							this.tracer.WriteLine(string.Format("对表 Student 第 3 条记录调用 SetAdded 方法后的状态为: {0}", row3.RowState));
							row3.RejectChanges();
							this.tracer.WriteLine(string.Format("对表 Student 第 3 条记录调用 RejectChanges 方法后的状态为: {0}", row3.RowState));

							row4.Delete();
							this.tracer.WriteLine(string.Format("对表 Student 第 4 条记录调用 Delete 方法后的状态为: {0}", row4.RowState));
							row4.RejectChanges();
							this.tracer.WriteLine(string.Format("对表 Student 第 4 条记录调用 RejectChanges 方法后的状态为: {0}", row4.RowState));

							dataSet.Tables[0].Rows.Remove(row1);
							this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 Remove 方法后的状态为: {0}", row1.RowState));
							row1.RejectChanges();
							this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 RejectChanges 方法后的状态为: {0}", row1.RowState));
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							DataRow row1 = dataSet.Tables[0].Rows[0];
							DataRow row2 = dataSet.Tables[0].Rows[1];
							DataRow row3 = dataSet.Tables[0].Rows[2];
							DataRow row4 = dataSet.Tables[0].Rows[3];

							try
							{
								this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", row1.RowState));
								row1.SetAdded();
								this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 SetAdded 方法后的状态为: {0}", row1.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

							try
							{
								row2["Age"] = 21;
								this.tracer.WriteLine(string.Format("对表 Student 第 2 条记录修改后的状态为: {0}", row2.RowState));
								row2.SetAdded();
								this.tracer.WriteLine(string.Format("对表 Student 第 2 条记录调用 SetAdded 方法后的状态为: {0}", row2.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

							try
							{
								row3.SetAdded();
								this.tracer.WriteLine(string.Format("对表 Student 第 3 条记录调用 SetAdded 方法后的状态为: {0}", row3.RowState));
								row3.SetAdded();
								this.tracer.WriteLine(string.Format("对表 Student 第 3 条记录调用 SetAdded 方法后的状态为: {0}", row3.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

							try
							{
								row4.Delete();
								this.tracer.WriteLine(string.Format("对表 Student 第 4 条记录调用 Delete 方法后的状态为: {0}", row4.RowState));
								row4.SetAdded();
								this.tracer.WriteLine(string.Format("对表 Student 第 4 条记录调用 SetAdded 方法后的状态为: {0}", row4.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

							try
							{
								dataSet.Tables[0].Rows.Remove(row1);
								this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 Remove 方法后的状态为: {0}", row1.RowState));
								row1.SetAdded();
								this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 SetAdded 方法后的状态为: {0}", row1.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							DataRow row1 = dataSet.Tables[0].Rows[0];
							DataRow row2 = dataSet.Tables[0].Rows[1];
							DataRow row3 = dataSet.Tables[0].Rows[2];
							DataRow row4 = dataSet.Tables[0].Rows[3];

							try
							{
								this.tracer.WriteLine(string.Format("表 Student 第 1 条记录的状态为: {0}", row1.RowState));
								row1.SetModified();
								this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 SetModified 方法后的状态为: {0}", row1.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

							try
							{
								row2["Age"] = 21;
								this.tracer.WriteLine(string.Format("对表 Student 第 2 条记录修改后的状态为: {0}", row2.RowState));
								row2.SetModified();
								this.tracer.WriteLine(string.Format("对表 Student 第 2 条记录调用 SetModified 方法后的状态为: {0}", row2.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

							try
							{
								row3.SetAdded();
								this.tracer.WriteLine(string.Format("对表 Student 第 3 条记录调用 SetAdded 方法后的状态为: {0}", row3.RowState));
								row3.SetModified();
								this.tracer.WriteLine(string.Format("对表 Student 第 3 条记录调用 SetModified 方法后的状态为: {0}", row3.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

							try
							{
								row4.Delete();
								this.tracer.WriteLine(string.Format("对表 Student 第 4 条记录调用 Delete 方法后的状态为: {0}", row4.RowState));
								row4.SetModified();
								this.tracer.WriteLine(string.Format("对表 Student 第 4 条记录调用 SetModified 方法后的状态为: {0}", row4.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

							try
							{
								dataSet.Tables[0].Rows.Remove(row1);
								this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 Remove 方法后的状态为: {0}", row1.RowState));
								row1.SetModified();
								this.tracer.WriteLine(string.Format("对表 Student 第 1 条记录调用 SetModified 方法后的状态为: {0}", row1.RowState));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

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

			#region "是否测试使用 ImportRow, Copy 方法后 DataRow.RowState 的转化?"
			if (this.tracer.WaitInputAChar("是否测试使用 ImportRow, Copy 方法后 DataRow.RowState 的转化?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int))
							}
							);

						this.tracer.WriteLine("创建表 Student(Name, Age) 到数据集 dataSet");

						DataSet dataSet1 = dataSet.Clone();
						this.tracer.WriteLine("克隆数据集 dataSet 到 dataSet1");

						DataRow row1 = dataSet.Tables["Student"].Rows.Add("小明", 12);

						DataRow row2 = dataSet.Tables["Student"].Rows.Add("小红", 10);
						row2.AcceptChanges();

						DataRow row3 = dataSet.Tables["Student"].Rows.Add("小刚", 15);
						row3.AcceptChanges();
						row3["Age"] = 14;

						DataRow row4 = dataSet.Tables["Student"].Rows.Add("小芳", 18);
						row4.AcceptChanges();
						row4.Delete();

						DataRow row5 = dataSet.Tables["Student"].NewRow();

						this.tracer.WriteLine("为 dataSet 中的表 Student 添加数据");
						this.tracer.WriteLine(string.Format("记录 row1 的状态为 {0}", row1.RowState));
						this.tracer.WriteLine(string.Format("记录 row2 的状态为 {0}", row2.RowState));
						this.tracer.WriteLine(string.Format("记录 row3 的状态为 {0}", row3.RowState));
						this.tracer.WriteLine(string.Format("记录 row4 的状态为 {0}", row4.RowState));
						this.tracer.WriteLine(string.Format("记录 row5 的状态为 {0}", row5.RowState));

						dataSet1.Tables["Student"].ImportRow(row1);
						dataSet1.Tables["Student"].ImportRow(row2);
						dataSet1.Tables["Student"].ImportRow(row3);
						dataSet1.Tables["Student"].ImportRow(row4);
						dataSet1.Tables["Student"].ImportRow(row5);

						this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 1 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[0].RowState));
						this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 2 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[1].RowState));
						this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 3 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[2].RowState));
						this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 4 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[3].RowState));

						try { this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 5 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[4].RowState)); }
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}

					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int))
							}
							);

						this.tracer.WriteLine("创建表 Student(Name, Age) 到数据集 dataSet");


						DataRow row1 = dataSet.Tables["Student"].Rows.Add("小明", 12);

						DataRow row2 = dataSet.Tables["Student"].Rows.Add("小红", 10);
						row2.AcceptChanges();

						DataRow row3 = dataSet.Tables["Student"].Rows.Add("小刚", 15);
						row3.AcceptChanges();
						row3["Age"] = 14;

						DataRow row4 = dataSet.Tables["Student"].Rows.Add("小芳", 18);
						row4.AcceptChanges();
						row4.Delete();

						DataRow row5 = dataSet.Tables["Student"].NewRow();

						this.tracer.WriteLine("为 dataSet 中的表 Student 添加数据");
						this.tracer.WriteLine(string.Format("记录 row1 的状态为 {0}", row1.RowState));
						this.tracer.WriteLine(string.Format("记录 row2 的状态为 {0}", row2.RowState));
						this.tracer.WriteLine(string.Format("记录 row3 的状态为 {0}", row3.RowState));
						this.tracer.WriteLine(string.Format("记录 row4 的状态为 {0}", row4.RowState));
						this.tracer.WriteLine(string.Format("记录 row5 的状态为 {0}", row5.RowState));

						DataSet dataSet1 = dataSet.Copy();
						this.tracer.WriteLine("复制数据集 dataSet 到 dataSet1");

						this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 1 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[0].RowState));
						this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 2 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[1].RowState));
						this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 3 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[2].RowState));
						this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 4 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[3].RowState));

						try { this.tracer.WriteLine(string.Format("dataSet1 表 Student 第 5 条记录的状态为: {0}", dataSet1.Tables["Student"].Rows[4].RowState)); }
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试访问不同 RowState 的 DataRow 中的数据?"
			if (this.tracer.WaitInputAChar("是否测试访问不同 RowState 的 DataRow 中的数据?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							DataRow row1 = dataSet.Tables[0].Rows[0];
							DataRow row2 = dataSet.Tables[0].Rows[1];

							this.tracer.WriteLine(string.Format("第 1 条记录, 姓名: {0}, 年龄: {1}", row1["Name"], row1["Age"]));

							row1["Age"] = 50;
							this.tracer.WriteLine(string.Format("修改并访问第 1 条记录当前数据, 姓名: {0}, 年龄: {1}", row1["Name"], row1["Age"]));

							row1.Delete();
							this.tracer.WriteLine(string.Format("对第 1 条记录调用 Delete 方法并访问, 姓名: {0}, 年龄: {1}", row1["Name", DataRowVersion.Original], row1["Age", DataRowVersion.Original]));


							try
							{
								dataSet.Tables[0].Rows.Remove(row2);
								this.tracer.WriteLine(string.Format("对第 2 条记录调用 Remove 方法并访问, 姓名: {0}, 年龄: {1}", row2["Name", DataRowVersion.Original], row2["Age", DataRowVersion.Original]));
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

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

			#region "是否测试获取 DataTable 中不同 RowState 的 DataRow?"
			if (this.tracer.WaitInputAChar("是否测试获取 DataTable 中不同 RowState 的 DataRow?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						/*
						 * Test.sdf 始终复制到 bin 目录下
						 * */
						SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Student", @"Data Source=|DataDirectory|\Test.sdf");

						try
						{
							adapter.Fill(dataSet);
							this.tracer.WriteLine("从本地 Test.sdf 数据库填充数据集");

							DataRow row4 = dataSet.Tables[0].Rows[3];

							dataSet.Tables[0].Rows[0]["Age"] = 21;
							this.tracer.WriteLine("修改第 1 条记录");

							dataSet.Tables[0].Rows[1].Delete();
							this.tracer.WriteLine("对第 2 条记录调用 Delete 方法");

							dataSet.Tables[0].Rows.Remove(dataSet.Tables[0].Rows[2]);
							this.tracer.WriteLine("移除第 3 条记录");

							dataSet.Tables[0].Rows.Add("小新", 10);
							this.tracer.WriteLine("添加新的记录");

							this.tracer.WriteLine("使用 GetChanges 方法获取状态为 Added 的记录的副本");

							foreach (DataRow row in dataSet.Tables[0].GetChanges(DataRowState.Added).Rows)
								this.tracer.WriteLine(string.Format("\t姓名: {0}, 年龄: {1}, 行状态: {2}", row["Name"], row["Age"], row.RowState));

							this.tracer.WriteLine("使用 GetChanges 方法获取状态为 Modified 的记录的副本");

							foreach (DataRow row in dataSet.Tables[0].GetChanges(DataRowState.Modified).Rows)
								this.tracer.WriteLine(string.Format("\t姓名: {0}, 年龄: {1}, 行状态: {2}", row["Name"], row["Age"], row.RowState));

							this.tracer.WriteLine("使用 GetChanges 方法获取状态为 Unchanged 的记录的副本");

							foreach (DataRow row in dataSet.Tables[0].GetChanges(DataRowState.Unchanged).Rows)
							{
								this.tracer.WriteLine(string.Format("\t姓名: {0}, 年龄: {1}, 行状态: {2}", row["Name"], row["Age"], row.RowState));

								row["Age"] = 22;
								this.tracer.WriteLine(string.Format("\t修改此副本记录为姓名: {0}, 年龄: {1}, 行状态: {2}", row["Name"], row["Age"], row.RowState));

								this.tracer.WriteLine(string.Format("\t原始记录为姓名: {0}, 年龄: {1}, 行状态: {2}", row4["Name"], row4["Age"], row4.RowState));
							}

							this.tracer.WriteLine("使用 GetChanges 方法获取状态为 Deleted 的记录的副本");

							foreach (DataRow row in dataSet.Tables[0].GetChanges(DataRowState.Deleted).Rows)
								this.tracer.WriteLine(string.Format("\t姓名: {0}, 年龄: {1}, 行状态: {2}", row["Name", DataRowVersion.Original], row["Age", DataRowVersion.Original], row.RowState));

							this.tracer.WriteLine("使用 GetChanges 方法获取状态为 Modified 和 Added 的记录的副本");

							foreach (DataRow row in dataSet.Tables[0].GetChanges(DataRowState.Modified | DataRowState.Added).Rows)
								this.tracer.WriteLine(string.Format("\t姓名: {0}, 年龄: {1}, 行状态: {2}", row["Name"], row["Age"], row.RowState));

							try
							{
								this.tracer.WriteLine("使用 GetChanges 方法获取状态为 Detached 的记录的副本");

								foreach (DataRow row in dataSet.Tables[0].GetChanges(DataRowState.Detached).Rows)
									this.tracer.WriteLine("发现一条状态为 Detached 的记录, 但无法访问");
							}
							catch (Exception err)
							{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

							this.tracer.WriteLine("使用没有参数的 GetChanges 方法获取记录的副本");

							foreach (DataRow row in dataSet.Tables[0].GetChanges().Rows)
								this.tracer.WriteLine(string.Format("\t行状态: {0}", row.RowState));

							this.tracer.WriteLine("使用没有参数的 GetChanges 方法获取记录的副本");

							foreach (DataRow row in dataSet.Tables[0].GetChanges().Rows)
								this.tracer.WriteLine(string.Format("\t行状态: {0}", row.RowState));

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

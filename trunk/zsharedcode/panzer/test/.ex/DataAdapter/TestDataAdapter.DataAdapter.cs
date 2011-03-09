/*
 * 参考文档: http://mscxc.blog.com/2010/05/07/daadapter/
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://mscxc.blog.com/2010/01/28/panzernetsharedcode/
 * 在运行之前, 请确保已经下载数据库压缩文件并解压到本项目目录下 https://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/test.zip
 * */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace zoyobar.shared.panzer.test.ex.da
{

	partial class TestDataAdapter
	{

		public void Test_DataAdapter()
		{

			#region "是否测试 SqlDataAdapter.SelectCommand, SqlDataAdapter.UpdateCommand, SqlDataAdapter.InsertCommand, SqlDataAdapter.DeleteCommand 属性?"
			if (this.tracer.WaitInputAChar("是否测试 SqlDataAdapter.SelectCommand, SqlDataAdapter.UpdateCommand, SqlDataAdapter.InsertCommand, SqlDataAdapter.DeleteCommand 属性?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						this.tracer.WriteLine("说明: 没有 SelectCommand 的 DataAdapter 使用 Fill 方法将导致异常");

						SqlDataAdapter adapter = new SqlDataAdapter();

						try
						{ adapter.Fill(dataSet); }
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}

					using (DataSet dataSet = new DataSet())
					{
						this.tracer.WriteLine("说明: 使用多个 select 语句返回多张表");

						SqlConnection connection = new SqlConnection(this.connectionString);

						this.tracer.WriteLine("创建拥有两个 select 语句的 SqlCommand");
						SqlCommand selectCommand = new SqlCommand("select name, age, classname from student;select name from class", connection);

						SqlDataAdapter adapter = new SqlDataAdapter();
						adapter.SelectCommand = selectCommand;

						adapter.Fill(dataSet);

						int index = 1;

						foreach (DataTable table in dataSet.Tables)
						{
							this.tracer.WriteLine(string.Format("表: {0}", table.TableName));

							foreach (DataRow row in table.Rows)
							{
								this.tracer.Write(string.Format("行 [{0}]:", index++));

								foreach (DataColumn column in table.Columns)
									this.tracer.Write(string.Format("{0} = <{1}>;", column.ColumnName, row[column]));

								this.tracer.WriteLine();
							}

						}

					}


					using (DataSet dataSet = new DataSet())
					{
						this.tracer.WriteLine("说明: 更新 DataSet 时, 如果存在 RowState 为 Added, Modified, Deleted 的 DataRow, 则 SqlDataAdapter 需要对应的 InsertCommand, UpdateCommand, DeleteCommand");

						SqlConnection connection = new SqlConnection(this.connectionString);
						connection.Open();

						SqlCommand selectCommand = new SqlCommand("select name, age, classname from student", connection);

						SqlDataAdapter adapter = new SqlDataAdapter();
						adapter.SelectCommand = selectCommand;

						SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
						adapter.UpdateCommand = builder.GetUpdateCommand();
						adapter.InsertCommand = builder.GetInsertCommand();
						adapter.DeleteCommand = builder.GetDeleteCommand();

						adapter.Fill(dataSet);

						this.tracer.WriteLine("对 student 修改, 删除, 新建");
						dataSet.Tables[0].Rows[0]["name"] = "haha";
						dataSet.Tables[0].Rows[1].Delete();
						dataSet.Tables[0].Rows.Add("我的学生", 10, "二年级一班");

						using (SqlTransaction transaction = connection.BeginTransaction())
						{
							adapter.UpdateCommand.Transaction = transaction;
							adapter.InsertCommand.Transaction = transaction;
							adapter.DeleteCommand.Transaction = transaction;

							this.tracer.WriteLine("更新数据库");
							adapter.Update(dataSet);

							this.tracer.WriteLine("回滚");
							transaction.Rollback();
						}

						connection.Close();
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

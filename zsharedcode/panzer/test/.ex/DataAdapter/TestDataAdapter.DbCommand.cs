/*
 * 参考文档: http://mscxc.blog.com/2010/07/07/dadbcommand/
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://mscxc.blog.com/2010/01/28/panzernetsharedcode/
 * 在运行之前, 请确保已经下载数据库压缩文件并解压到本项目目录下 https://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/test.zip
* */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace zoyobar.shared.panzer.test.ex.da
{

	partial class TestDataAdapter
	{

		public void TestDbCommand()
		{

			#region "是否测试使用不同方式获取数据?"
			if (this.tracer.WaitInputAChar("是否测试使用不同方式获取数据?") == 'y')
			{

				try
				{

					using (SqlCommand command = new SqlCommand())
					{
						this.tracer.WriteLine("说明: 执行 sql 语句读取数据");

						SqlConnection connection = new SqlConnection(this.connectionString);

						this.tracer.WriteLine("设置类型为 Text 的 SqlCommand");
						command.CommandType = CommandType.Text;
						command.CommandText = "select name, age, classname from student";
						command.Connection = connection;

						connection.Open();
						this.tracer.WriteLine("从数据库读取数据");
						SqlDataReader reader = command.ExecuteReader();

						while (reader.Read())
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", reader["name"], reader["age"], reader["classname"]));

						connection.Close();
					}

					using (SqlCommand command = new SqlCommand())
					{
						this.tracer.WriteLine("说明: 执行存储过程读取数据");

						SqlConnection connection = new SqlConnection(this.connectionString);

						this.tracer.WriteLine("设置类型为 StoredProcedure 的 SqlCommand");
						command.CommandType = CommandType.StoredProcedure;
						command.CommandText = "dbo.TestDbCommandStoredProcedure1";
						command.Connection = connection;

						connection.Open();
						this.tracer.WriteLine("从数据库读取数据");
						SqlDataReader reader = command.ExecuteReader();

						while (reader.Read())
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", reader["name"], reader["age"], reader["classname"]));

						connection.Close();
					}

					using (SqlCommand command = new SqlCommand())
					{
						this.tracer.WriteLine("说明: 执行多条 sql 语句");

						SqlConnection connection = new SqlConnection(this.connectionString);

						this.tracer.WriteLine("设置执行两条 select 语句");
						command.CommandType = CommandType.Text;
						command.CommandText = "select name, age, classname from student;select name from class";
						command.Connection = connection;

						connection.Open();
						this.tracer.WriteLine("从数据库读取多个表格的数据");
						SqlDataReader reader = command.ExecuteReader();

						while (reader.Read())
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", reader["name"], reader["age"], reader["classname"]));

						if(reader.NextResult())
							while(reader.Read())
								this.tracer.WriteLine(string.Format("班级: {0}", reader["name"]));

						connection.Close();
					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试 SqlCommand 执行时与 SqlConnection 的关系?"
			if (this.tracer.WaitInputAChar("是否测试 SqlCommand 执行与 SqlConnection 的关系?") == 'y')
			{

				try
				{

					using (SqlCommand command = new SqlCommand())
					{
						this.tracer.WriteLine("说明: SqlCommand.ExecuteReader 方法和 SqlDataReader 读取数据时需要 SqlConnection 处于打开状态");

						SqlConnection connection = new SqlConnection(this.connectionString);

						command.CommandType = CommandType.Text;
						command.CommandText = "select name, age, classname from student";
						command.Connection = connection;

						this.tracer.WriteLine("打开链接");
						connection.Open();

						this.tracer.WriteLine("从数据库读取数据");
						SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

						while (reader.Read())
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", reader["name"], reader["age"], reader["classname"]));

						this.tracer.WriteLine("关闭链接");
						connection.Close();
					}

					using (DataSet dataSet = new DataSet())
					{
						this.tracer.WriteLine("说明: 使用 SqlDataAdapter 填充数据集不影响 SqlConnection 的状态");

						SqlConnection connection = new SqlConnection(this.connectionString);

						SqlCommand command = new SqlCommand("select name, age, classname from student", connection);
						SqlDataAdapter adapter = new SqlDataAdapter(command);

						this.tracer.WriteLine("打开链接");
						connection.Open();

						this.tracer.WriteLine("从数据库读取数据");
						adapter.Fill(dataSet);

						foreach(DataRow row in dataSet.Tables[0].Rows)
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", row["name"], row["age"], row["classname"]));

						this.tracer.WriteLine(string.Format("链接当前的状态: {0}", connection.State));

						this.tracer.WriteLine("关闭链接");
						connection.Close();

						this.tracer.WriteLine("重置数据集");
						dataSet.Reset();

						this.tracer.WriteLine("从数据库读取数据");
						adapter.Fill(dataSet);

						foreach(DataRow row in dataSet.Tables[0].Rows)
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", row["name"], row["age"], row["classname"]));
						
						this.tracer.WriteLine(string.Format("链接当前的状态: {0}", connection.State));
					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试 SqlCommand 中的 SqlParameter 参数?"
			if (this.tracer.WaitInputAChar("是否测试 SqlCommand 中的 SqlParameter 参数?") == 'y')
			{

				try
				{

					using (SqlCommand command = new SqlCommand())
					{
						this.tracer.WriteLine("说明: 在存储过程中使用参数");

						SqlConnection connection = new SqlConnection(this.connectionString);

						this.tracer.WriteLine("为存储过程添加参数");
						command.CommandType = CommandType.StoredProcedure;
						command.CommandText = "dbo.TestDbCommandStoredProcedure2";
						command.Parameters.AddRange(
							new SqlParameter[] {
								new SqlParameter("@name", "小白"),
								new SqlParameter("@className", "二年级1班")
							}
							);

						command.Connection = connection;

						connection.Open();
						this.tracer.WriteLine("从数据库读取数据");
						SqlDataReader reader = command.ExecuteReader();

						while (reader.Read())
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", reader["name"], reader["age"], reader["classname"]));

						connection.Close();
					}

					using (SqlCommand command = new SqlCommand())
					{
						this.tracer.WriteLine("说明: 在 sql 语句中使用参数");

						SqlConnection connection = new SqlConnection(this.connectionString);

						this.tracer.WriteLine("为 sql 语句添加参数");
						command.CommandType = CommandType.Text;
						command.CommandText = "SELECT Name, Age, ClassName FROM Student WHERE (Name = @name) AND (ClassName = @className)";
						command.Parameters.AddRange(
							new SqlParameter[] {
								new SqlParameter("@className", "二年级1班"),
								new SqlParameter("@name", "小白")
							}
							);

						command.Connection = connection;

						connection.Open();
						this.tracer.WriteLine("从数据库读取数据");
						SqlDataReader reader = command.ExecuteReader();

						while (reader.Read())
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", reader["name"], reader["age"], reader["classname"]));

						connection.Close();
					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试 SqlCommand 的 ExecuteNonQuery 方法?"
			if (this.tracer.WaitInputAChar("是否测试 SqlCommand 的 ExecuteNonQuery 方法?") == 'y')
			{

				try
				{

					using (SqlCommand command = new SqlCommand())
					{
						this.tracer.WriteLine("说明: ExecuteNonQuery 方法返回所有 update, insert, delete 语句影响的行数");

						SqlConnection connection = new SqlConnection(this.connectionString);

						this.tracer.WriteLine("为 sql 语句添加参数");
						command.CommandType = CommandType.Text;
						command.CommandText = "update student set name = name;update student set name = name;insert into student(name, age, classname) values ('ha', 1, '没有年级')";

						command.Connection = connection;

						connection.Open();
						SqlTransaction transaction = connection.BeginTransaction();
						command.Transaction = transaction;
						this.tracer.WriteLine(string.Format("调用 ExecuteNonQuery 从数据库读取数据: {0}", command.ExecuteNonQuery()));

						transaction.Rollback();
						connection.Close();
					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试 DbCommand 在 Access 与 sql server 中的不同?"
			if (this.tracer.WaitInputAChar("是否测试 DbCommand 在 Access 与 sql server 中的不同?") == 'y')
			{

				try
				{

					using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"Test.accdb\";Persist Security Info=True"))
					{
						this.tracer.WriteLine("说明: Access 不识别参数名, 而是以参数出现的顺序为准");

						this.tracer.WriteLine("为 sql 语句添加参数");
						OleDbCommand command = new OleDbCommand();
						command.CommandType = CommandType.Text;
						command.CommandText = "select * from student where name = @name and classname = @classname";
						command.Parameters.AddRange(
							new OleDbParameter[] {
								new OleDbParameter("@name", "小小"),
								new OleDbParameter("@classname", "二年级三班")
							}
							);

						command.Connection = connection;

						OleDbCommand command2 = new OleDbCommand();
						command2.CommandType = CommandType.Text;
						command2.CommandText = "select * from student where name = @name and classname = @classname";
						command2.Parameters.AddRange(
							new OleDbParameter[] {
								new OleDbParameter("@classname", "二年级三班"),
								new OleDbParameter("@name", "小小")
							}
							);

						command2.Connection = connection;

						connection.Open();
						OleDbDataReader reader = command.ExecuteReader();

						while (reader.Read())
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", reader["name"], reader["age"], reader["classname"]));

						OleDbDataReader reader2 = command2.ExecuteReader();

						while (reader2.Read())
							this.tracer.WriteLine(string.Format("学生: {0}, {1}, {2}", reader2["name"], reader2["age"], reader2["classname"]));


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

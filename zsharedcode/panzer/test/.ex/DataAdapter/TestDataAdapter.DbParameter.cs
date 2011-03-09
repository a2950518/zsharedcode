/*
 * 参考文档: http://mscxc.blog.com/2010/04/14/dadbparameter/
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://mscxc.blog.com/2010/01/28/panzernetsharedcode/
 * 在运行之前, 请确保已经下载数据库压缩文件并解压到本项目目录下 https://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/test.zip
 * */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace zoyobar.shared.panzer.test.ex.da
{

	partial class TestDataAdapter
	{

		public void TestDbParameter()
		{
			this.tracer.WriteLine("测试对象 DbParameter");

			#region "是否测试 SqlDbType 对应的 DbType 和数据类型?"
			if (this.tracer.WaitInputAChar("是否测试 SqlDbType 对应的 DbType 和数据类型?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						SqlCommand command = new SqlCommand("TestDbParameterSqlDbTypeNDbType", new SqlConnection(this.connectionString));
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@p1", SqlDbType.BigInt), new SqlParameter("@p2", SqlDbType.Binary), new SqlParameter("@p3", SqlDbType.Binary), new SqlParameter("@p4", SqlDbType.Bit), new SqlParameter("@p5", SqlDbType.Char), new SqlParameter("@p6", SqlDbType.Char), new SqlParameter("@p7", SqlDbType.DateTime), new SqlParameter("@p8", SqlDbType.Decimal), new SqlParameter("@p9", SqlDbType.Float), new SqlParameter("@p10", SqlDbType.Image), new SqlParameter("@p11", SqlDbType.Int), new SqlParameter("@p12", SqlDbType.Money), new SqlParameter("@p13", SqlDbType.NChar), new SqlParameter("@p14", SqlDbType.NChar), new SqlParameter("@p15", SqlDbType.NText), new SqlParameter("@p16", SqlDbType.NVarChar), new SqlParameter("@p17", SqlDbType.NVarChar), new SqlParameter("@p18", SqlDbType.Real), new SqlParameter("@p19", SqlDbType.SmallDateTime), new SqlParameter("@p20", SqlDbType.SmallInt), new SqlParameter("@p21", SqlDbType.SmallMoney), new SqlParameter("@p22", SqlDbType.Text), new SqlParameter("@p23", SqlDbType.Timestamp), new SqlParameter("@p24", SqlDbType.TinyInt), new SqlParameter("@p25", SqlDbType.UniqueIdentifier), new SqlParameter("@p26", SqlDbType.VarBinary), new SqlParameter("@p27", SqlDbType.VarChar) });

						command.Parameters["@p1"].SqlValue = 123L;

						command.Parameters["@p2"].SqlValue = new byte[] { 0xAF, 0x9, 0xC8 };
						command.Parameters["@p2"].Size = 4;

						command.Parameters["@p3"].SqlValue = new byte[] { 0xAF, 0x9, 0xC8 };
						command.Parameters["@p3"].Size = 2;

						command.Parameters["@p4"].SqlValue = true;

						command.Parameters["@p5"].SqlValue = "My name is jack?";
						command.Parameters["@p5"].Size = 5;

						command.Parameters["@p6"].SqlValue = new char[] { 'M', 'y', ' ', 'n', 'a', 'm', 'e', ' ', 'i', 's', ' ', 'j', 'a', 'c', 'k', '?' };
						command.Parameters["@p6"].Size = 5;

						command.Parameters["@p7"].SqlValue = DateTime.Now;

						command.Parameters["@p8"].SqlValue = 92.32M;
						command.Parameters["@p9"].SqlValue = 92.32D;

						command.Parameters["@p10"].SqlValue = new byte[] { 0x1, 0x2, 0x3 };
						command.Parameters["@p10"].Size = 3;

						command.Parameters["@p11"].SqlValue = 92;

						command.Parameters["@p12"].SqlValue = 98.23M;

						command.Parameters["@p13"].SqlValue = "My";
						command.Parameters["@p13"].Size = 5;

						command.Parameters["@p14"].SqlValue = new char[] { 'M', 'y' };
						command.Parameters["@p14"].Size = 5;

						command.Parameters["@p15"].SqlValue = "hello";

						command.Parameters["@p16"].SqlValue = "My";
						command.Parameters["@p16"].Size = 5;

						command.Parameters["@p17"].SqlValue = new char[] { 'M', 'y' };
						command.Parameters["@p17"].Size = 5;

						command.Parameters["@p18"].SqlValue = 4.5F;

						command.Parameters["@p19"].SqlValue = DateTime.Now;

						command.Parameters["@p20"].SqlValue = (short)12;

						command.Parameters["@p21"].SqlValue = 11.2M;

						command.Parameters["@p22"].SqlValue = "hello";

						command.Parameters["@p23"].SqlValue = new byte[] { 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8 };

						command.Parameters["@p24"].SqlValue = (byte)2;

						command.Parameters["@p25"].SqlValue = Guid.NewGuid();

						command.Parameters["@p26"].SqlValue = new byte[] { 0x1, 0x2, 0x3 };
						command.Parameters["@p26"].Size = 4;

						command.Parameters["@p27"].SqlValue = "jack";
						command.Parameters["@p27"].Size = 4;


						this.tracer.WriteLine("SqlDbType\t\tDbType\t\tValue\t\tSqlValue");

						foreach (SqlParameter parameter in command.Parameters)
							this.tracer.WriteLine(string.Format("{0}\t\t{1}\t\t{2}\t\t{3}", parameter.SqlDbType, parameter.DbType, parameter.Value, parameter.SqlValue));

						SqlDataAdapter adapter = new SqlDataAdapter(command);
						adapter.Fill(dataSet);

						foreach (DataRow row in dataSet.Tables[0].Rows)
							foreach (DataColumn column in dataSet.Tables[0].Columns)
							{

								if (row[column] is IEnumerable)
								{
									IEnumerator valuer = (row[column] as IEnumerable).GetEnumerator();

									int index = 0;

									while (valuer.MoveNext())
										this.tracer.WriteLine(string.Format("{0}[{1}] = <{2}>", column.ColumnName, index++, valuer.Current));

								}
								else
									this.tracer.WriteLine(string.Format("{0} = <{1}>", column.ColumnName, row[column]));

							}

					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试 DbParameter.Size 属性?"
			if (this.tracer.WaitInputAChar("是否测试 DbParameter.Size 属性?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						SqlCommand command = new SqlCommand("TestDbParameterSize", new SqlConnection(this.connectionString));
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@p1", SqlDbType.Binary), new SqlParameter("@p2", SqlDbType.Binary) });

						command.Parameters["@p1"].SqlValue = new byte[] { 0xAF, 0x9, 0xC8, 0x8 };
						command.Parameters["@p1"].Size = 4;

						command.Parameters["@p2"].SqlValue = new byte[] { 0xAF, 0x9, 0xC8, 0x8 };
						command.Parameters["@p2"].Size = 2;


						SqlDataAdapter adapter = new SqlDataAdapter(command);
						adapter.Fill(dataSet);

						foreach (DataRow row in dataSet.Tables[0].Rows)
							foreach (DataColumn column in dataSet.Tables[0].Columns)
							{

								if (row[column] is IEnumerable)
								{
									IEnumerator valuer = (row[column] as IEnumerable).GetEnumerator();

									int index = 0;

									while (valuer.MoveNext())
										this.tracer.WriteLine(string.Format("{0}[{1}] = <{2}>", column.ColumnName, index++, valuer.Current));

								}
								else
									this.tracer.WriteLine(string.Format("{0} = <{1}>", column.ColumnName, row[column]));

							}

					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试 DbParameter.Precision, DbParameter.Scale, SqlParameter.Offset 属性?"
			if (this.tracer.WaitInputAChar("是否测试 DbParameter.Precision, DbParameter.Scale, SqlParameter.Offset 属性?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						SqlCommand command = new SqlCommand("TestDbParameterPrecisionScaleOffset", new SqlConnection(this.connectionString));
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@p1", SqlDbType.Decimal), new SqlParameter("@p2", SqlDbType.Decimal), new SqlParameter("@p3", SqlDbType.Decimal), new SqlParameter("@p4", SqlDbType.Decimal), new SqlParameter("@p5", SqlDbType.Decimal), new SqlParameter("@p6", SqlDbType.Decimal), new SqlParameter("@p7", SqlDbType.Decimal), new SqlParameter("@p8", SqlDbType.NVarChar) });

						command.Parameters["@p1"].SqlValue = 12345.6789M;
						command.Parameters["@p1"].Precision = 9;
						command.Parameters["@p1"].Scale = 4;

						command.Parameters["@p2"].SqlValue = 12345.67894M;
						command.Parameters["@p2"].Precision = 9;
						command.Parameters["@p2"].Scale = 4;

						command.Parameters["@p3"].SqlValue = 12345.67895M;
						command.Parameters["@p3"].Precision = 9;
						command.Parameters["@p3"].Scale = 4;

						command.Parameters["@p4"].SqlValue = 12345.67M;
						command.Parameters["@p4"].Precision = 9;
						command.Parameters["@p4"].Scale = 4;

						command.Parameters["@p5"].SqlValue = 12345.6789M;
						command.Parameters["@p5"].Precision = 9;
						command.Parameters["@p5"].Scale = 3;

						command.Parameters["@p6"].SqlValue = 45.6789M;
						command.Parameters["@p6"].Precision = 8;
						command.Parameters["@p6"].Scale = 4;

						command.Parameters["@p7"].SqlValue = 45.67899M;
						command.Parameters["@p7"].Precision = 10;
						command.Parameters["@p7"].Scale = 5;

						command.Parameters["@p8"].SqlValue = "My name is jack";
						command.Parameters["@p8"].Offset = 3;
						command.Parameters["@p8"].Size = 6;


						SqlDataAdapter adapter = new SqlDataAdapter(command);
						adapter.Fill(dataSet);

						foreach (DataRow row in dataSet.Tables[0].Rows)
							foreach (DataColumn column in dataSet.Tables[0].Columns)
							{

								if (row[column] is IEnumerable)
								{
									IEnumerator valuer = (row[column] as IEnumerable).GetEnumerator();

									int index = 0;

									while (valuer.MoveNext())
										this.tracer.WriteLine(string.Format("{0}[{1}] = <{2}>", column.ColumnName, index++, valuer.Current));

								}
								else
									this.tracer.WriteLine(string.Format("{0} = <{1}>", column.ColumnName, row[column]));

							}

					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试 DbParameter.Direction 属性?"
			if (this.tracer.WaitInputAChar("是否测试 DbParameter.Direction 属性?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						SqlCommand command = new SqlCommand("TestDbParameterDirection", new SqlConnection(this.connectionString));
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@onlyInput1", SqlDbType.Int), new SqlParameter("@onlyInput2", SqlDbType.Int), new SqlParameter("@onlyInput3", SqlDbType.Int), new SqlParameter("@inputNOutput1", SqlDbType.Int), new SqlParameter("@inputNOutput2", SqlDbType.Int), new SqlParameter("@inputNOutput3", SqlDbType.Int) });

						command.Parameters["@onlyInput1"].Direction = ParameterDirection.Input;

						/*
						 * 取消下面语句的注释, 将导致异常
						 * */

						// command.Parameters["@onlyInput2"].Direction = ParameterDirection.InputOutput;
						// command.Parameters["@onlyInput3"].Direction = ParameterDirection.Output;

						command.Parameters["@inputNOutput1"].Direction = ParameterDirection.Input;
						command.Parameters["@inputNOutput2"].Direction = ParameterDirection.InputOutput;
						command.Parameters["@inputNOutput3"].Direction = ParameterDirection.Output;

						SqlDataAdapter adapter = new SqlDataAdapter(command);
						adapter.Fill(dataSet);

						foreach (SqlParameter parameter in command.Parameters)
							this.tracer.WriteLine(string.Format("{0} = <{1}>", parameter.ParameterName, parameter.SqlValue));

						foreach (DataRow row in dataSet.Tables[0].Rows)
							foreach (DataColumn column in dataSet.Tables[0].Columns)
							{

								if (row[column] is IEnumerable)
								{
									IEnumerator valuer = (row[column] as IEnumerable).GetEnumerator();

									int index = 0;

									while (valuer.MoveNext())
										this.tracer.WriteLine(string.Format("{0}[{1}] = <{2}>", column.ColumnName, index++, valuer.Current));

								}
								else
									this.tracer.WriteLine(string.Format("{0} = <{1}>", column.ColumnName, row[column]));

							}

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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using zoyobar.shared.panzer.debug;
using zoyobar.shared.panzer.data;
using zoyobar.shared.panzer.test.ex.ds;

namespace zoyobar.shared.panzer.test
{

	public class TestDataSetHelper
	{
		private readonly Tracer tracer = new Tracer ();

		public void Test ()
		{

			if ( this.tracer.WaitInputAChar ( "是否进行扩展的 DataSet 测试?" ) == 'y' )
				new TestDataSet ().Test ();

			if ( this.tracer.WaitInputAChar ( "是否测试 DataSetHelper.Load 方法?" ) == 'y' )
				this.TestLoad ();

		}

		public void TestLoad ()
		{
			this.tracer.WriteLine ( "测试方法 Load(DataTable, string)" );

			try
			{
				DataSet dataSet = new DataSet ();
				dataSet.Namespace = "http://tempuri.org/TestDS.xsd";
				DataTable table = dataSet.Tables.Add ( "Student" );
				table.Columns.Add ( "Name" );
				table.Columns.Add ( "Age" );

				this.tracer.Execute ( null, typeof ( DataSetHelper ), "Load", FunctionType.Method, new Type[] { typeof ( DataTable ), typeof ( string ) }, "表: {0}, Xml: {1}", null, null,
					new object[][] {
						new object[] { table, @"test.xml" },
						new object[] { null, @"test.xml" },
						new object[] { table, null }
					},
					false
					);

				foreach ( DataRow row in table.Rows )
					this.tracer.WriteLine ( string.Format ( "姓名: {0}, 年龄: {1}", row["Name"], row["Age"] ) );

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			this.tracer.WriteLine ( "测试方法 Load(DataTable, string, bool)" );

			try
			{
				DataSet dataSet = new DataSet ();
				dataSet.Namespace = "http://tempuri.org/TestDS.xsd";
				DataTable table = dataSet.Tables.Add ( "Student" );
				table.Columns.Add ( "Name" );
				table.Columns.Add ( "Age" );

				this.tracer.Execute ( null, typeof ( DataSetHelper ), "Load", FunctionType.Method, new Type[] { typeof ( DataTable ), typeof ( string ), typeof ( bool ) }, "表: {0}, Xml: {1}, 清除: {2}", null, null,
					new object[][] {
						new object[] { table, @"test.xml", true },
						new object[] { table, @"test.xml", false }
					},
					false
					);

				foreach ( DataRow row in table.Rows )
					this.tracer.WriteLine ( string.Format ( "姓名: {0}, 年龄: {1}", row["Name"], row["Age"] ) );

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			this.tracer.WriteLine ( "测试方法 Load(DataSet, string)" );

			try
			{
				DataSet dataSet = new DataSet ();

				this.tracer.Execute ( null, typeof ( DataSetHelper ), "Load", FunctionType.Method, new Type[] { typeof ( DataSet ), typeof ( string ) }, "数据集: {0}, Xml: {1}", null, null,
					new object[][] {
						new object[] { dataSet, @"test.xml" },
						new object[] { dataSet, null }
					},
					false
					);

				foreach ( DataRow row in dataSet.Tables["Student"].Rows )
					this.tracer.WriteLine ( string.Format ( "姓名: {0}, 年龄: {1}", row["Name"], row["Age"] ) );

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			this.tracer.WriteLine ( "测试方法 Load(DataSet, string, bool)" );

			try
			{
				DataSet dataSet = new DataSet ();

				this.tracer.Execute ( null, typeof ( DataSetHelper ), "Load", FunctionType.Method, new Type[] { typeof ( DataSet ), typeof ( string ), typeof ( bool ) }, "数据集: {0}, Xml: {1}, 清除: {2}", null, null,
					new object[][] {
						new object[] { dataSet, @"test.xml", false },
						new object[] { dataSet, @"test.xml", true }
					},
					false
					);

				foreach ( DataRow row in dataSet.Tables["Student"].Rows )
					this.tracer.WriteLine ( string.Format ( "姓名: {0}, 年龄: {1}", row["Name"], row["Age"] ) );

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			this.tracer.WriteLine ( "测试方法 Load(DataSet, string, XmlReadMode)" );

			try
			{
				DataSet dataSet = new DataSet ();

				this.tracer.Execute ( null, typeof ( DataSetHelper ), "Load", FunctionType.Method, new Type[] { typeof ( DataSet ), typeof ( string ), typeof ( XmlReadMode ) }, "数据集: {0}, Xml: {1}, 模式: {2}", null, null,
					new object[][] {
						new object[] { dataSet, @"test.xml", XmlReadMode.Auto }
					},
					false
					);

				foreach ( DataRow row in dataSet.Tables["Student"].Rows )
					this.tracer.WriteLine ( string.Format ( "姓名: {0}, 年龄: {1}", row["Name"], row["Age"] ) );

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			this.tracer.WriteLine ( "测试方法 Load(DataSet, string, bool, XmlReadMode)" );

			try
			{
				DataSet dataSet = new DataSet ();

				this.tracer.Execute ( null, typeof ( DataSetHelper ), "Load", FunctionType.Method, new Type[] { typeof ( DataSet ), typeof ( string ), typeof ( bool ), typeof ( XmlReadMode ) }, "数据集: {0}, Xml: {1}, 清除: {2}, 模式: {3}", null, null,
					new object[][] {
						new object[] { dataSet, @"test.xml", false, XmlReadMode.Auto }
					},
					false
					);

				foreach ( DataRow row in dataSet.Tables["Student"].Rows )
					this.tracer.WriteLine ( string.Format ( "姓名: {0}, 年龄: {1}", row["Name"], row["Age"] ) );

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			this.tracer.WriteLine ( "测试方法 Save(DataTable, string)" );

			try
			{
				DataSet dataSet = new DataSet ();
				DataTable table = dataSet.Tables.Add ( "Student1" );
				table.Columns.Add ( "Name" );
				table.Rows.Add ( "1" );

				this.tracer.Execute ( null, typeof ( DataSetHelper ), "Save", FunctionType.Method, new Type[] { typeof ( DataTable ), typeof ( string ) }, "表: {0}, Xml: {1}", null, null,
					new object[][] {
						new object[] { table, @"test.datasethelper.1.xml" }
					},
					false
					);

			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			this.tracer.WriteLine ( "测试方法 Save(DataTable, string)" );

			try
			{
				DataSet dataSet = new DataSet ();
				DataTable table = dataSet.Tables.Add ( "Student1" );
				table.Columns.Add ( "Name" );
				table.Rows.Add ( "1" );

				this.tracer.Execute ( null, typeof ( DataSetHelper ), "Save", FunctionType.Method, new Type[] { typeof ( DataSet ), typeof ( string ) }, "数据集: {0}, Xml: {1}", null, null,
					new object[][] {
						new object[] { dataSet, @"test.datasethelper.2.xml" }
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

using zoyobar.shared.panzer.ui;
using zoyobar.shared.panzer.ui.dwindow;
using zoyobar.shared.panzer.debug;

namespace zoyobar.shared.panzer.test.ui
{

	public class TestDataWindowCore
	{

		// 定义从 WindowCore 派生的类
		public class StudentCore
			: DataWindowCore<IDataWindow<PagerSetting>, PagerSetting>
		{

			public StudentCore ( IDataWindow<PagerSetting> dataWindow, TableSetting<PagerSetting>[] tableSettings )
				: base ( dataWindow, tableSettings )
			{ }

			// 重写填充数据的方法
			protected override void fillData ( TableSetting<PagerSetting>[] tableSettings )
			{

				using ( OleDbConnection connection = new OleDbConnection ( "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"Test.accdb\";Persist Security Info=True" ) )
				{
					OleDbCommand command = new OleDbCommand ();
					command.CommandType = CommandType.Text;
					command.CommandText = "select * from student";
					command.Connection = connection;

					OleDbDataAdapter adapter = new OleDbDataAdapter ( command );

					// 得到需要填充数据的 DataTable
					DataTable table = TableSetting<PagerSetting>.GetTable ( tableSettings, "Student" );
					table.Clear ();

					connection.Open ();

					try
					{ adapter.Fill ( table ); }
					catch
					{ MessageBox.Show ( "获取失败!" ); }
					finally
					{ connection.Close (); }

					connection.Close ();
				}

			}

			// 重写更新数据的方法
			protected override void updateData ( TableSetting<PagerSetting>[] tableSettings )
			{

				using ( OleDbConnection connection = new OleDbConnection ( "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"Test.accdb\";Persist Security Info=True" ) )
				{
					// 定义修改, 添加, 删除的 DbCommand
					OleDbCommand modifyCommand = new OleDbCommand ();
					modifyCommand.CommandType = CommandType.Text;
					modifyCommand.CommandText = "update student set age = @age, classname = @className where name = @name";

					OleDbParameter ageParameter = modifyCommand.Parameters.Add ( "@age", OleDbType.WChar, 255 );
					ageParameter.SourceColumn = "Age";
					ageParameter.SourceVersion = DataRowVersion.Current;

					OleDbParameter classNameParameter = modifyCommand.Parameters.Add ( "@className", OleDbType.WChar, 255 );
					classNameParameter.SourceColumn = "ClassName";
					classNameParameter.SourceVersion = DataRowVersion.Current;

					OleDbParameter nameParameter = modifyCommand.Parameters.Add ( "@name", OleDbType.WChar, 255 );
					nameParameter.SourceColumn = "Name";
					nameParameter.SourceVersion = DataRowVersion.Original;

					modifyCommand.Connection = connection;

					OleDbCommand addCommand = new OleDbCommand ();
					addCommand.CommandType = CommandType.Text;
					addCommand.CommandText = "insert into student(name, age, classname) values(@name, @age, @className)";

					nameParameter = addCommand.Parameters.Add ( "@name", OleDbType.WChar, 255 );
					nameParameter.SourceColumn = "Name";
					nameParameter.SourceVersion = DataRowVersion.Current;

					ageParameter = addCommand.Parameters.Add ( "@age", OleDbType.WChar, 255 );
					ageParameter.SourceColumn = "Age";
					ageParameter.SourceVersion = DataRowVersion.Current;

					classNameParameter = addCommand.Parameters.Add ( "@className", OleDbType.WChar, 255 );
					classNameParameter.SourceColumn = "ClassName";
					classNameParameter.SourceVersion = DataRowVersion.Current;

					addCommand.Connection = connection;

					OleDbCommand deleteCommand = new OleDbCommand ();
					deleteCommand.CommandType = CommandType.Text;
					deleteCommand.CommandText = "delete from student where name = @name";

					nameParameter = deleteCommand.Parameters.Add ( "@name", OleDbType.WChar, 255 );
					nameParameter.SourceColumn = "Name";
					nameParameter.SourceVersion = DataRowVersion.Current;

					deleteCommand.Connection = connection;

					OleDbDataAdapter adapter = new OleDbDataAdapter ();
					adapter.UpdateCommand = modifyCommand;
					adapter.InsertCommand = addCommand;
					adapter.DeleteCommand = deleteCommand;
					connection.Open ();

					// 得到需要更新数据的 DataTable
					TableSetting<PagerSetting> tableSetting = TableSetting<PagerSetting>.GetTableSetting ( tableSettings, "Student" );

					// 将用户添加, 删除的行, 以及选中并且被修改的行合并为一个 DataRow 数组, 接下来要对数组中的行更新
					DataRow[] rows = TableSetting<PagerSetting>.Combine ( tableSetting.AddedRows, tableSetting.DeletedRows, tableSetting.FilterModifiedRows );

					try
					{ MessageBox.Show ( string.Format ( "更新成功, 共有 {0} 条, 更新 {1} 条, 成功 {2} 条!", tableSetting.Table.Rows.Count, rows.Length, adapter.Update ( rows ) ) ); }
					catch
					{ MessageBox.Show ( "更新失败!" ); }
					finally
					{ connection.Close (); }

				}

			}

		}

		private readonly Tracer tracer = new Tracer ();

		public void Test ()
		{

			if ( this.tracer.WaitInputAChar ( "是否测试 DataWindowCore?" ) != 'y' )
				return;

			this.tracer.WriteLine ( "创建窗体并添加表格, 绑定" );
			new dwc.FormStudent ().ShowDialog ();
		}


	}

	public class SampleDataWindowCore
	{

		public static void Main ()
		{ new FormStudent ().ShowDialog (); }

		public class StudentCore
			: DataWindowCore<IDataWindow<PagerSetting>, PagerSetting>
		{

			public StudentCore ( IDataWindow<PagerSetting> dataWindow, TableSetting<PagerSetting>[] tableSettings )
				: base ( dataWindow, tableSettings )
			{ }

			// 重写填充数据的方法
			protected override void fillData ( TableSetting<PagerSetting>[] tableSettings )
			{

				using ( OleDbConnection connection = new OleDbConnection ( "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"Test.accdb\";Persist Security Info=True" ) )
				{
					OleDbCommand command = new OleDbCommand ();
					command.CommandType = CommandType.Text;
					command.CommandText = "select * from student";
					command.Connection = connection;

					OleDbDataAdapter adapter = new OleDbDataAdapter ( command );

					// 得到需要填充数据的 DataTable, DataTable 是由实现的 IDataWindow 的窗口或控件返回
					DataTable table = TableSetting<PagerSetting>.GetTable ( tableSettings, "Student" );
					table.Clear ();

					connection.Open ();

					try
					{ adapter.Fill ( table ); }
					catch
					{ MessageBox.Show ( "获取失败!" ); }
					finally
					{ connection.Close (); }

					connection.Close ();
				}

			}

		}

		public class FormStudent : Form, IDataWindow<PagerSetting>
		{
			private readonly DataGridView gridStudent = new DataGridView ();
			private readonly DataSet dsStudent = new DataSet ();

			public FormStudent ()
				: base ()
			{
				this.gridStudent.Name = "gridStudent";
				this.gridStudent.Dock = DockStyle.Top;

				// 添加 DataGridView 到窗口
				this.Controls.AddRange ( new Control[] { this.gridStudent } );

				// 添加 Student 表格到 DataSet
				this.dsStudent.Tables.Add ( "Student" );
				this.dsStudent.Tables["Student"].Columns.AddRange (
					new DataColumn[]
					{
						new DataColumn("Name"), new DataColumn("Age"), new DataColumn("ClassName")
					}
					);

				// 创建 StudentCore
				StudentCore core = new StudentCore ( this,
					new TableSetting<PagerSetting>[]
					{
						new TableSetting<PagerSetting>("Student", this.dsStudent.Tables["Student"], null, null, null)
					}
					);

				// 绑定填充方法到窗口的 Load 事件
				core.BindDataEvent<EventArgs> ( this, "Load", EventHandlerType.EventHandler, DataActionType.Fill, "Student" );
			}

			// 将 Student 表绑定到 gridStudent
			void IDataWindow<PagerSetting>.SetTables ( SortedList<string, TableSetting<PagerSetting>> tableSettings )
			{ this.gridStudent.DataSource = tableSettings["Student"].Table; }

			string IDataWindow<PagerSetting>.GetViewFilter ( TableSetting<PagerSetting> tableSetting )
			{ return string.Empty; }

			string IDataWindow<PagerSetting>.GetViewSort ( TableSetting<PagerSetting> tableSetting )
			{ return string.Empty; }

			int IDataWindow<PagerSetting>.GetPagerIndex ( TableSetting<PagerSetting> tableSetting )
			{ return 0; }

			void IDataWindow<PagerSetting>.SetIsDataActionEnabled ( TableSetting<PagerSetting> tableSetting, DataActionType actionType, bool isEnabled )
			{ }

			void IDataWindow<PagerSetting>.SetIsPagerControlEnabled ( TableSetting<PagerSetting> tableSetting, PagerActionType actionType, bool isEnabled )
			{ }

			void IDataWindow<PagerSetting>.SetPager ( TableSetting<PagerSetting> tableSetting )
			{ }

			object IWindow.Platform
			{
				get { return this; }
			}

		}

	}

}

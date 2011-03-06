/*
 * 参考文档: http://mscxc.blog.com/2010/02/05/dsdatarelation/
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://mscxc.blog.com/2010/01/28/panzernetsharedcode/
 * */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

using zoyobar.shared.panzer.debug;

namespace zoyobar.shared.panzer.test.ex.ds
{

	partial class TestDataSet
	{

		public void TestDataRelation()
		{
			this.tracer.WriteLine("测试对象 DataRelation");

			#region "是否测试 DataRelation 和约束?"
			if (this.tracer.WaitInputAChar("是否测试 DataRelation 和约束?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集");
						this.tracer.WriteLine(string.Format("表 Class 包含 {0} 个约束, 表 Student 包含 {1} 个约束", dataSet.Tables["Class"].Constraints.Count, dataSet.Tables["Student"].Constraints.Count));


						dataSet.Relations.AddRange(
							new DataRelation[] {
								new DataRelation("Name-ClassName", dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"])
							}
							);

						this.tracer.WriteLine("添加关系 Class::Name - Student::ClassName 到数据集, 同时创建约束");

						this.tracer.WriteLine(string.Format("在表 Class 中创建了 {0} 个约束", dataSet.Tables["Class"].Constraints.Count));

						foreach (Constraint constraint in dataSet.Tables["Class"].Constraints)
							switch (constraint.GetType().ToString())
							{
								case "System.Data.ForeignKeyConstraint":
									ForeignKeyConstraint foreignKeyConstraint = constraint as ForeignKeyConstraint;
									this.tracer.WriteLine(string.Format("在表 Class 中找到了外键约束 {0}, 删除规则 {1}, 更新规则 {2}", foreignKeyConstraint.ConstraintName, foreignKeyConstraint.DeleteRule, foreignKeyConstraint.UpdateRule));
									break;

								case "System.Data.UniqueConstraint":
									UniqueConstraint uniqueConstraint = constraint as UniqueConstraint;
									this.tracer.WriteLine(string.Format("在表 Class 中找到了唯一约束 {0}", uniqueConstraint.ConstraintName));
									break;
							}

						this.tracer.WriteLine(string.Format("在表 Student 中创建了 {0} 个约束", dataSet.Tables["Student"].Constraints.Count));

						foreach (Constraint constraint in dataSet.Tables["Student"].Constraints)
							switch (constraint.GetType().ToString())
							{
								case "System.Data.ForeignKeyConstraint":
									ForeignKeyConstraint foreignKeyConstraint = constraint as ForeignKeyConstraint;
									this.tracer.WriteLine(string.Format("在表 Student 中找到了外键约束 {0}, 删除规则 {1}, 更新规则 {2}", foreignKeyConstraint.ConstraintName, foreignKeyConstraint.DeleteRule, foreignKeyConstraint.UpdateRule));
									break;

								case "System.Data.UniqueConstraint":
									UniqueConstraint uniqueConstraint = constraint as UniqueConstraint;
									this.tracer.WriteLine(string.Format("在表 Student 中找到了唯一约束 {0}", uniqueConstraint.ConstraintName));
									break;
							}

					}


					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集");
						this.tracer.WriteLine(string.Format("表 Class 包含 {0} 个约束, 表 Student 包含 {1} 个约束", dataSet.Tables["Class"].Constraints.Count, dataSet.Tables["Student"].Constraints.Count));

						dataSet.Relations.AddRange(
							new DataRelation[] {
								new DataRelation("Name-ClassName", dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"], false)
							}
							);

						this.tracer.WriteLine("添加关系 Class::Name - Student::ClassName 到数据集, 但不创建约束");
						this.tracer.WriteLine(string.Format("表 Class 包含 {0} 个约束, 表 Student 包含 {1} 个约束", dataSet.Tables["Class"].Constraints.Count, dataSet.Tables["Student"].Constraints.Count));

					}


					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集并添加唯一约束");

						dataSet.Tables["Class"].Constraints.Add(new UniqueConstraint("UniqueName", dataSet.Tables["Class"].Columns["Name"]));

						this.tracer.WriteLine(string.Format("表 Class 包含 {0} 个约束, 表 Student 包含 {1} 个约束", dataSet.Tables["Class"].Constraints.Count, dataSet.Tables["Student"].Constraints.Count));

						dataSet.Relations.AddRange(
							new DataRelation[] {
								new DataRelation("Name-ClassName", dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"])
							}
							);

						this.tracer.WriteLine("添加关系 Class::Name - Student::ClassName 到数据集, 同时创建约束");

						this.tracer.WriteLine(string.Format("在表 Class 中创建了 {0} 个约束", dataSet.Tables["Class"].Constraints.Count));

						foreach (Constraint constraint in dataSet.Tables["Class"].Constraints)
							switch (constraint.GetType().ToString())
							{
								case "System.Data.ForeignKeyConstraint":
									ForeignKeyConstraint foreignKeyConstraint = constraint as ForeignKeyConstraint;
									this.tracer.WriteLine(string.Format("在表 Class 中找到了外键约束 {0}, 删除规则 {1}, 更新规则 {2}", foreignKeyConstraint.ConstraintName, foreignKeyConstraint.DeleteRule, foreignKeyConstraint.UpdateRule));
									break;

								case "System.Data.UniqueConstraint":
									UniqueConstraint uniqueConstraint = constraint as UniqueConstraint;
									this.tracer.WriteLine(string.Format("在表 Class 中找到了唯一约束 {0}", uniqueConstraint.ConstraintName));
									break;
							}

						this.tracer.WriteLine(string.Format("在表 Student 中创建了 {0} 个约束", dataSet.Tables["Student"].Constraints.Count));

						foreach (Constraint constraint in dataSet.Tables["Student"].Constraints)
							switch (constraint.GetType().ToString())
							{
								case "System.Data.ForeignKeyConstraint":
									ForeignKeyConstraint foreignKeyConstraint = constraint as ForeignKeyConstraint;
									this.tracer.WriteLine(string.Format("在表 Student 中找到了外键约束 {0}, 删除规则 {1}, 更新规则 {2}", foreignKeyConstraint.ConstraintName, foreignKeyConstraint.DeleteRule, foreignKeyConstraint.UpdateRule));
									break;

								case "System.Data.UniqueConstraint":
									UniqueConstraint uniqueConstraint = constraint as UniqueConstraint;
									this.tracer.WriteLine(string.Format("在表 Student 中找到了唯一约束 {0}", uniqueConstraint.ConstraintName));
									break;
							}

					}


					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集");

						dataSet.Relations.AddRange(
							new DataRelation[] {
								new DataRelation("Name-ClassName", dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"], false)
							}
							);

						this.tracer.WriteLine("添加关系 Class::Name - Student::ClassName 到数据集, 但不创建约束");

						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小明, 10, 二年级一班) 到 Student");
						dataSet.Tables["Student"].Rows.Add("小红", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小红, 10, 二年级一班) 到 Student");
						dataSet.Tables["Class"].Rows.Add("二年级一班");
						this.tracer.WriteLine("添加 (二年级一班) 到 Class");

						dataSet.Tables["Student"].Rows.Add("小黑", "12", "二年级二班");
						this.tracer.WriteLine("添加 (小黑, 10, 二年级二班) 到 Student");
						dataSet.Tables["Student"].Rows.Add("小莎", "13", "二年级二班");
						this.tracer.WriteLine("添加 (小莎, 10, 二年级二班) 到 Student");
						dataSet.Tables["Class"].Rows.Add("二年级二班");
						this.tracer.WriteLine("添加 (二年级二班) 到 Class");

						dataSet.Tables["Class"].Rows.Add("二年级二班");
						this.tracer.WriteLine("添加 (二年级二班) 到 Class");

						this.tracer.WriteLine("得到 二年级一班 的学生");

						foreach (DataRow row in dataSet.Tables["Class"].Rows[0].GetChildRows("Name-ClassName"))
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						this.tracer.WriteLine("得到 二年级二班 的学生");

						foreach (DataRow row in dataSet.Tables["Class"].Rows[1].GetChildRows("Name-ClassName"))
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						this.tracer.WriteLine("得到学生 小明 所在的班级");

						this.tracer.WriteLine(string.Format("学生 {0} 所在班级为 {1}", dataSet.Tables["Student"].Rows[0]["Name"], dataSet.Tables["Student"].Rows[0].GetParentRow("Name-ClassName")["Name"]));


					}


				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试约束的作用?"
			if (this.tracer.WaitInputAChar("是否测试约束的作用?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集");

						ForeignKeyConstraint foreignKeyConstraint = new ForeignKeyConstraint(dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"]);

						dataSet.Tables["Student"].Constraints.Add(foreignKeyConstraint);

						this.tracer.WriteLine(string.Format("添加外键约束 Class::Name - Student::ClassName 到表 Student, 更新规则为 {0}, 删除规则为 {1}", foreignKeyConstraint.UpdateRule, foreignKeyConstraint.DeleteRule));

						dataSet.Tables["Class"].Rows.Add("二年级一班");
						this.tracer.WriteLine("添加 (二年级一班) 到 Class");

						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小明, 10, 二年级一班) 到 Student");
						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小花, 12, 二年级一班) 到 Student");

						dataSet.Tables["Class"].Rows.Add("二年级二班");
						this.tracer.WriteLine("添加 (二年级二班) 到 Class");

						dataSet.Tables["Student"].Rows.Add("小红", "10", "二年级二班");
						this.tracer.WriteLine("添加 (小红, 13, 二年级二班) 到 Student");

						this.tracer.WriteLine("所有的班级");

						foreach (DataRow row in dataSet.Tables["Class"].Rows)
							this.tracer.WriteLine(string.Format("班级 {0}", row["Name"]));

						this.tracer.WriteLine("所有的学生");

						foreach (DataRow row in dataSet.Tables["Student"].Rows)
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						dataSet.Tables["Class"].Rows[0]["Name"] = "二年级三班";
						this.tracer.WriteLine("修改 二年级一班 为 二年级三班");

						this.tracer.WriteLine("所有的班级");

						foreach (DataRow row in dataSet.Tables["Class"].Rows)
							this.tracer.WriteLine(string.Format("班级 {0}", row["Name"]));

						this.tracer.WriteLine("所有的学生");

						foreach (DataRow row in dataSet.Tables["Student"].Rows)
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						dataSet.Tables["Class"].Rows[0].Delete();
						this.tracer.WriteLine("删除 二年级一班");

						this.tracer.WriteLine(string.Format("班级有 {0} 个", dataSet.Tables["Class"].Rows.Count));
						this.tracer.WriteLine(string.Format("学生有 {0} 个", dataSet.Tables["Student"].Rows.Count));

					}


					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集");

						ForeignKeyConstraint foreignKeyConstraint = new ForeignKeyConstraint(dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"]);
						foreignKeyConstraint.UpdateRule = Rule.None;
						foreignKeyConstraint.DeleteRule = Rule.None;

						dataSet.Tables["Student"].Constraints.Add(foreignKeyConstraint);

						this.tracer.WriteLine(string.Format("添加外键约束 Class::Name - Student::ClassName 到表 Student, 更新规则为 {0}, 删除规则为 {1}", foreignKeyConstraint.UpdateRule, foreignKeyConstraint.DeleteRule));

						dataSet.Tables["Class"].Rows.Add("二年级一班");
						this.tracer.WriteLine("添加 (二年级一班) 到 Class");

						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小明, 10, 二年级一班) 到 Student");
						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小花, 12, 二年级一班) 到 Student");

						dataSet.Tables["Class"].Rows.Add("二年级二班");
						this.tracer.WriteLine("添加 (二年级二班) 到 Class");

						dataSet.Tables["Student"].Rows.Add("小红", "10", "二年级二班");
						this.tracer.WriteLine("添加 (小红, 13, 二年级二班) 到 Student");

						this.tracer.WriteLine("所有的班级");

						foreach (DataRow row in dataSet.Tables["Class"].Rows)
							this.tracer.WriteLine(string.Format("班级 {0}", row["Name"]));

						this.tracer.WriteLine("所有的学生");

						foreach (DataRow row in dataSet.Tables["Student"].Rows)
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						try
						{
							dataSet.Tables["Class"].Rows[0]["Name"] = "二年级三班";
							this.tracer.WriteLine("修改 二年级一班 为 二年级三班");

							this.tracer.WriteLine("所有的班级");

							foreach (DataRow row in dataSet.Tables["Class"].Rows)
								this.tracer.WriteLine(string.Format("班级 {0}", row["Name"]));

							this.tracer.WriteLine("所有的学生");

							foreach (DataRow row in dataSet.Tables["Student"].Rows)
								this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

						try
						{

							dataSet.Tables["Class"].Rows[0].Delete();
							this.tracer.WriteLine("删除 二年级一班");

							this.tracer.WriteLine(string.Format("班级有 {0} 个", dataSet.Tables["Class"].Rows.Count));
							this.tracer.WriteLine(string.Format("学生有 {0} 个", dataSet.Tables["Student"].Rows.Count));
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

					}


					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集");

						ForeignKeyConstraint foreignKeyConstraint = new ForeignKeyConstraint(dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"]);
						foreignKeyConstraint.UpdateRule = Rule.SetNull;
						foreignKeyConstraint.DeleteRule = Rule.SetNull;

						dataSet.Tables["Student"].Constraints.Add(foreignKeyConstraint);

						this.tracer.WriteLine(string.Format("添加外键约束 Class::Name - Student::ClassName 到表 Student, 更新规则为 {0}, 删除规则为 {1}", foreignKeyConstraint.UpdateRule, foreignKeyConstraint.DeleteRule));

						dataSet.Tables["Class"].Rows.Add("二年级一班");
						this.tracer.WriteLine("添加 (二年级一班) 到 Class");

						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小明, 10, 二年级一班) 到 Student");
						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小花, 12, 二年级一班) 到 Student");

						dataSet.Tables["Class"].Rows.Add("二年级二班");
						this.tracer.WriteLine("添加 (二年级二班) 到 Class");

						dataSet.Tables["Student"].Rows.Add("小红", "10", "二年级二班");
						this.tracer.WriteLine("添加 (小红, 13, 二年级二班) 到 Student");

						this.tracer.WriteLine("所有的班级");

						foreach (DataRow row in dataSet.Tables["Class"].Rows)
							this.tracer.WriteLine(string.Format("班级 {0}", row["Name"]));

						this.tracer.WriteLine("所有的学生");

						foreach (DataRow row in dataSet.Tables["Student"].Rows)
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						dataSet.Tables["Class"].Rows[0]["Name"] = "二年级三班";
						this.tracer.WriteLine("修改 二年级一班 为 二年级三班");

						this.tracer.WriteLine("所有的班级");

						foreach (DataRow row in dataSet.Tables["Class"].Rows)
							this.tracer.WriteLine(string.Format("班级 {0}", row["Name"]));

						this.tracer.WriteLine("所有的学生");

						foreach (DataRow row in dataSet.Tables["Student"].Rows)
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						dataSet.Tables["Class"].Rows[0].Delete();
						this.tracer.WriteLine("删除 二年级一班");

						this.tracer.WriteLine(string.Format("班级有 {0} 个", dataSet.Tables["Class"].Rows.Count));
						this.tracer.WriteLine(string.Format("学生有 {0} 个", dataSet.Tables["Student"].Rows.Count));

					}


					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集");

						ForeignKeyConstraint foreignKeyConstraint = new ForeignKeyConstraint(dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"]);
						foreignKeyConstraint.UpdateRule = Rule.SetDefault;
						foreignKeyConstraint.DeleteRule = Rule.SetDefault;

						dataSet.Tables["Student"].Constraints.Add(foreignKeyConstraint);

						this.tracer.WriteLine(string.Format("添加外键约束 Class::Name - Student::ClassName 到表 Student, 更新规则为 {0}, 删除规则为 {1}", foreignKeyConstraint.UpdateRule, foreignKeyConstraint.DeleteRule));

						dataSet.Tables["Class"].Rows.Add("二年级一班");
						this.tracer.WriteLine("添加 (二年级一班) 到 Class");

						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小明, 10, 二年级一班) 到 Student");
						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小花, 12, 二年级一班) 到 Student");

						dataSet.Tables["Class"].Rows.Add("二年级二班");
						this.tracer.WriteLine("添加 (二年级二班) 到 Class");

						dataSet.Tables["Student"].Rows.Add("小红", "10", "二年级二班");
						this.tracer.WriteLine("添加 (小红, 13, 二年级二班) 到 Student");

						this.tracer.WriteLine("所有的班级");

						foreach (DataRow row in dataSet.Tables["Class"].Rows)
							this.tracer.WriteLine(string.Format("班级 {0}", row["Name"]));

						this.tracer.WriteLine("所有的学生");

						foreach (DataRow row in dataSet.Tables["Student"].Rows)
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						dataSet.Tables["Class"].Rows[0]["Name"] = "二年级三班";
						this.tracer.WriteLine("修改 二年级一班 为 二年级三班");

						this.tracer.WriteLine("所有的班级");

						foreach (DataRow row in dataSet.Tables["Class"].Rows)
							this.tracer.WriteLine(string.Format("班级 {0}", row["Name"]));

						this.tracer.WriteLine("所有的学生");

						foreach (DataRow row in dataSet.Tables["Student"].Rows)
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						dataSet.Tables["Class"].Rows[0].Delete();
						this.tracer.WriteLine("删除 二年级一班");

						this.tracer.WriteLine(string.Format("班级有 {0} 个", dataSet.Tables["Class"].Rows.Count));
						this.tracer.WriteLine(string.Format("学生有 {0} 个", dataSet.Tables["Student"].Rows.Count));

					}


				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试约束对添加数据的影响以及可用性?"
			if (this.tracer.WaitInputAChar("是否测试约束对添加数据的影响以及可用性?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集");

						dataSet.Relations.AddRange(
							new DataRelation[] {
								new DataRelation("Name-ClassName", dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"], false)
							}
							);

						this.tracer.WriteLine("添加关系 Class::Name - Student::ClassName 到数据集");

						try
						{
							this.tracer.WriteLine("准备添加 (小明, 10, 二年级一班) 到 Student");
							dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

						this.tracer.WriteLine(string.Format("表 Student 中包含 {0} 条数据", dataSet.Tables["Student"].Rows.Count));

						try
						{
							dataSet.Tables["Class"].Rows.Add("二年级一班");
							this.tracer.WriteLine("添加 (二年级一班) 到 Class");
							dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
							this.tracer.WriteLine("添加 (小明, 10, 二年级一班) 到 Student");
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

						dataSet.EnforceConstraints = false;
						this.tracer.WriteLine("设置 EnforceConstraints 为 false");

						dataSet.Tables["Student"].Rows.Add("小红", "10", "二年级二班");
						this.tracer.WriteLine("添加 (小红, 10, 二年级二班) 到 Student");

						try
						{
							dataSet.EnforceConstraints = true;
							this.tracer.WriteLine("设置 EnforceConstraints 为 true");
						}
						catch (Exception err)
						{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

						this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", dataSet.Tables["Student"].Rows[0]["Name"], dataSet.Tables["Student"].Rows[0]["Age"], dataSet.Tables["Student"].Rows[0]["ClassName"]));
					}

				}
				catch (Exception err)
				{ this.tracer.WriteLine(string.Format("异常: {0}", err.Message)); }

				this.tracer.WaitPressEnter();
			}
			#endregion

			#region "是否测试 DataRelation 的用途?"
			if (this.tracer.WaitInputAChar("是否测试 DataRelation 的用途?") == 'y')
			{

				try
				{

					using (DataSet dataSet = new DataSet())
					{
						dataSet.Tables.Add("Class");
						dataSet.Tables["Class"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string))
							}
							);

						dataSet.Tables.Add("Student");
						dataSet.Tables["Student"].Columns.AddRange(
							new DataColumn[] {
								new DataColumn("Name", typeof(string)),
								new DataColumn("Age", typeof(int)),
								new DataColumn("ClassName", typeof(string))
							}
							);

						this.tracer.WriteLine("创建表 Class(Name), Student(Name, Age, ClassName) 到数据集");

						dataSet.Relations.AddRange(
							new DataRelation[] {
								new DataRelation("Name-ClassName", dataSet.Tables["Class"].Columns["Name"], dataSet.Tables["Student"].Columns["ClassName"], false)
							}
							);

						this.tracer.WriteLine("添加关系 Class::Name - Student::ClassName 到数据集");

						dataSet.Tables["Class"].Rows.Add("二年级一班");
						this.tracer.WriteLine("添加 (二年级一班) 到 Class");
						dataSet.Tables["Student"].Rows.Add("小明", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小明, 10, 二年级一班) 到 Student");
						dataSet.Tables["Student"].Rows.Add("小红", "10", "二年级一班");
						this.tracer.WriteLine("添加 (小红, 10, 二年级一班) 到 Student");

						dataSet.Tables["Class"].Rows.Add("二年级二班");
						this.tracer.WriteLine("添加 (二年级二班) 到 Class");
						dataSet.Tables["Student"].Rows.Add("小黑", "12", "二年级二班");
						this.tracer.WriteLine("添加 (小黑, 10, 二年级二班) 到 Student");
						dataSet.Tables["Student"].Rows.Add("小莎", "13", "二年级二班");
						this.tracer.WriteLine("添加 (小莎, 10, 二年级二班) 到 Student");

						this.tracer.WriteLine("得到 二年级一班 的学生");

						foreach (DataRow row in dataSet.Tables["Class"].Rows[0].GetChildRows("Name-ClassName"))
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						this.tracer.WriteLine("得到 二年级二班 的学生");

						foreach (DataRow row in dataSet.Tables["Class"].Rows[1].GetChildRows("Name-ClassName"))
							this.tracer.WriteLine(string.Format("姓名: {0}, 年龄: {1}, 班级: {2}", row["Name"], row["Age"], row["ClassName"]));

						this.tracer.WriteLine("得到学生 小明 所在的班级");

						this.tracer.WriteLine(string.Format("学生 {0} 所在班级为 {1}", dataSet.Tables["Student"].Rows[0]["Name"], dataSet.Tables["Student"].Rows[0].GetParentRow("Name-ClassName")["Name"]));

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

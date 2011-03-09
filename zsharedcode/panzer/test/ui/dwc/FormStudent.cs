using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using zoyobar.shared.panzer.ui;
using zoyobar.shared.panzer.ui.dwindow;

namespace zoyobar.shared.panzer.test.ui.dwc
{
	public partial class FormStudent : Form, IDataWindow<PagerSetting>
	{
		private readonly StudentDS dsStudent = new StudentDS ();

		public FormStudent ()
		{
			InitializeComponent ();

			// 创建核心类, 将 DataTable 传递给 StudentCore
			TestDataWindowCore.StudentCore core = new TestDataWindowCore.StudentCore ( this,
				new TableSetting<PagerSetting>[]
				{
					new TableSetting<PagerSetting>("Student", this.dsStudent.Student, null, null, null)
				}
				);

			// 将更新, 填充等操作绑定到按钮上
			core.BindDataEvent<EventArgs> ( this, "Load", EventHandlerType.EventHandler, DataActionType.Fill, "Student" );
			core.BindDataEvent<EventArgs> ( this.cmdFill, "Click", EventHandlerType.EventHandler, DataActionType.Fill, "Student" );
			core.BindDataEvent<EventArgs> ( this.cmdSave, "Click", EventHandlerType.EventHandler, DataActionType.Update, "Student" );

			// 将各种选中操作绑定到按钮上
			core.BindSetIsRowCheckedEvent<EventArgs> ( this.cmdNone, "Click", EventHandlerType.EventHandler, "Student", false );
			core.BindSetIsRowCheckedEvent<EventArgs> ( this.cmdAll, "Click", EventHandlerType.EventHandler, "Student", true );
			core.BindSetIsRowCheckedEvent<EventArgs> ( this.cmdTurn, "Click", EventHandlerType.EventHandler, "Student", null );
		}

		// 在 SetTables 中将 DataTable 绑定到控件
		void IDataWindow<PagerSetting>.SetTables ( SortedList<string, TableSetting<PagerSetting>> tableSettings )
		{ this.gridStudent.DataSource = tableSettings["Student"].Table; }

		string IDataWindow<PagerSetting>.GetViewFilter ( TableSetting<PagerSetting> tableSetting )
		{ return string.Empty; }

		string IDataWindow<PagerSetting>.GetViewSort ( TableSetting<PagerSetting> tableSetting )
		{ return string.Empty; }

		int IDataWindow<PagerSetting>.GetPagerIndex ( TableSetting<PagerSetting> tableSetting )
		{ return 0; }

		// 在 SetIsDataActionEnabled 中设置各个按钮是否可用
		void IDataWindow<PagerSetting>.SetIsDataActionEnabled ( TableSetting<PagerSetting> tableSetting, DataActionType actionType, bool isEnabled )
		{

			switch ( tableSetting.Name )
			{
				case "Student":

					switch ( actionType )
					{
						case DataActionType.Fill:
							this.cmdFill.Enabled = isEnabled;
							break;

						case DataActionType.Update:
							this.cmdSave.Enabled = isEnabled;
							break;
					}

					break;
			}

		}

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

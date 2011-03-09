using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using zoyobar.shared.panzer.ui;

namespace zoyobar.shared.panzer.test.ui.wc
{
	public partial class FormStudent : Form, IWindow
	{
		public FormStudent ()
		{
			InitializeComponent ();

			// 创建核心类
			TestWindowCore.StudentCore core = new TestWindowCore.StudentCore ( this );

			// 将弹出消息绑定到各个控件上
			core.BindPopMessageEvent<EventArgs> ( this.button1, null, "Click", EventHandlerType.EventHandler, "点击我了" );
			core.BindPopMessageEvent<EventArgs> ( this.button2, null, "MouseDown", EventHandlerType.MouseEventHandler, "鼠标按下" );

			core.BindPopMessageEvent<EventArgs> ( null, null, "Click", EventHandlerType.EventHandler, null );
			core.BindPopMessageEvent<EventArgs> ( this.button1, null, "Click123", EventHandlerType.EventHandler, "点击我了123" );
		}

		object IWindow.Platform
		{
			get { return this; }
		}

	}
}

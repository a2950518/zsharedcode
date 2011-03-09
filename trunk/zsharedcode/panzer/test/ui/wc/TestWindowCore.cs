using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using zoyobar.shared.panzer.ui;
using zoyobar.shared.panzer.debug;

// HACK: 如果代码不能编译, 请尝试在项目中定义编译符号 V4, V3_5, V3, V2 以表示不同的 .NET 版本

// HACK: DataWindowCore 需要 V4 或者 V3_5

namespace zoyobar.shared.panzer.test.ui
{

	public class TestWindowCore
	{

		// 定义从 WindowCore 派生的类
		public class StudentCore
			: WindowCore<IWindow>
		{

			public StudentCore ( IWindow window )
				: base ( window )
			{ }

			// 创建绑定弹出消息的方法
			public void BindPopMessageEvent<A> ( object target, Type type, string eventName, EventHandlerType eventType, string message )
				where A : EventArgs
			{
#if V3_5 || V4
				this.BindEvent<A> ( target, type, eventName, eventType,
					delegate ( object sender, A e )
					{ MessageBox.Show ( message ); }
					);
#endif
			}

		}

		private readonly Tracer tracer = new Tracer ( );

		public void Test ( )
		{

			if ( this.tracer.WaitInputAChar ( "是否测试 WindowCore?" ) != 'y' )
				return;

			this.tracer.WriteLine ( "创建窗体, 在窗体中使用 StudentCore 设置事件" );
			new wc.FormStudent ( ).ShowDialog ( );
		}


	}

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using zoyobar.shared.panzer.debug;
using zoyobar.shared.panzer.code;

namespace zoyobar.shared.panzer.test
{

	public class TestStringConvert
	{
		private readonly Tracer tracer = new Tracer ( );

		public void Test ( )
		{

			if ( this.tracer.WaitInputAChar ( "是否测试 StringConvert.ToObject<T> 方法?" ) == 'y' )
				this.TestToObject ( );

			if ( this.tracer.WaitInputAChar ( "是否测试 StringConvert.TestToString 方法?" ) == 'y' )
				this.TestToString ( );

		}

		public void TestToObject ( )
		{
			this.tracer.WriteLine ( "测试方法 ToObject<T>(string)" );

			try
			{
				this.tracer.WriteLine ( string.Format ( "成功: {0}", StringConvert.ToObject<int> ( "123" ) ) );
				this.tracer.WriteLine ( string.Format ( "成功: {0}", StringConvert.ToObject<Guid> ( Guid.NewGuid ( ).ToString() ) ) );
			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			this.tracer.WaitPressEnter ( );
		}

		public void TestToString ( )
		{
			this.tracer.WriteLine ( "测试方法 TestToString(object)" );

			try
			{
				this.tracer.WriteLine ( string.Format ( "成功: {0}", StringConvert.ToString ( SystemColors.ButtonFace ) ) );
			}
			catch ( Exception err )
			{ this.tracer.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			this.tracer.WaitPressEnter ( );
		}

	}

}

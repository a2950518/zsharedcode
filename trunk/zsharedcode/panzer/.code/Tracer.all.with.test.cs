/*allinone合并了多个文件,下载使用多个allinone代码,可能会遇到重复的类型定义,可以下载对应的zip文件*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using zoyobar.shared.panzer.debug;
// .class/debug/Tracer.cs
/*
 * 参考文档: http://blog.sina.com.cn/s/blog_604c436d0100o04w.html (目前已经停止更新同步)
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://blog.sina.com.cn/s/blog_604c436d0100o04s.html
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/debug/Tracer.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/FunctionType.cs
 * 测试文件: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/test/TestTracer.cs
 * 合并下载:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/Tracer.all.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.code/Tracer.all.with.test.cs (包含测试)
 * 打包下载:
 * http://zsharedcode.googlecode.com/files/Tracer.zip (目前已经停止更新同步)
 * http://zsharedcode.googlecode.com/files/Tracer.with.test.zip (包含测试) (目前已经停止更新同步)
 * 版本: .net 4.0, 其它版本可能有所不同
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.


namespace zoyobar.shared.panzer.debug
{

	/// <summary>
	/// 这是一个帮助你测试的类, 可以完成输出控制, 连续调用方法等功能.
	/// </summary>
	public sealed partial class Tracer
	{

#if PARAM
		/// <summary>
		/// 将对象转化为字符串, 并处理对象为空的情况.
		/// </summary>
		/// <param name="value">要转化的对象.</param>
		/// <param name="nullMessage">如果对象为 null 时返回的字符串, 如果不填则默认为 "[null]".</param>
		/// <returns>转化后的字符串.</returns>
		public static string ConvertNullToMessage ( object value, string nullMessage = null )
#else
		/// <summary>
		/// 将对象转化为字符串, 并处理对象为空的情况.
		/// </summary>
		/// <param name="value">要转化的对象.</param>
		/// <param name="nullMessage">如果对象为 null 时返回的字符串.</param>
		/// <returns>转化后的字符串.</returns>
		public static string ConvertNullToMessage ( object value, string nullMessage )
#endif
		{

			if ( null != value )
				return value.ToString ();

			if ( null == nullMessage )
				nullMessage = "[null]";

			return nullMessage;
		}

		private bool isTraceable;

		/// <summary>
		/// 获取或设置 Tracer 是否可以追踪, 如果为 false, 则  Tracer 大部分功能不再有效.
		/// </summary>
		public bool IsTraceable
		{
			get { return this.isTraceable; }
			set { this.isTraceable = value; }
		}

#if PARAM
		/// <summary>
		/// 创建一个 Tracer.
		/// </summary>
		/// <param name="isTraceable">指定 IsTraceable 属性, 如果为 false, 则  Tracer 大部分功能不再有效, 默认为 true.</param>
		public Tracer ( bool isTraceable = true )
#else
		/// <summary>
		/// 创建一个 Tracer.
		/// </summary>
		/// <param name="isTraceable">指定 IsTraceable 属性, 如果为 false, 则  Tracer 大部分功能不再有效.</param>
		public Tracer ( bool isTraceable )
#endif
		{ this.isTraceable = isTraceable; }

		/// <summary>
		/// 执行某个类的方法或构造函数.
		/// </summary>
		/// <param name="instance">要执行方法或构造函数的类, 如果执行构造函数, 则可以为 null.</param>
		/// <param name="type">类的类型, 可以为 null, 将从 instance 得到类型.</param>
		/// <param name="functionName">要执行方法的名称, 如果 functionType 指定为构造函数, 则可以为 null.</param>
		/// <param name="functionType">要执行方法的类型.</param>
		/// <param name="parameterTypes">如果 functionType 指定为方法, 而且方法被重载, 可以用 parameterTypes 指定方法的参数列表, 否则可以为 null.</param>
		/// <param name="parameterMessage">显示参数信息的文字, 如: "参数1:{0}, 参数2:{1}", 可以为 null, 则不显示.</param>
		/// <param name="resultMessage">显示结果信息的文字, 如: "返回值为:{0}", 可以为 null, 则不显示.</param>
		/// <param name="askMessage">提示用户是否继续执行的文字, 可以为 null, 则不提示.</param>
		/// <param name="parameterList">提供给方法的参数, 可以指定多组参数, 如: [['jack', 12], ['tom', 16]].</param>
		/// <param name="isStoppable">是否在方法执行完一次后停止.</param>
		/// <returns>执行的结果, 为类的方法返回值, 执行方法时遇到的异常或空.</returns>
		public object[] Execute ( object instance, Type type, string functionName, FunctionType functionType, Type[] parameterTypes, string parameterMessage, string resultMessage, string askMessage, object[][] parameterList, bool isStoppable )
		{

			if ( !this.isTraceable || null == parameterList || parameterList.Length == 0 || ( !string.IsNullOrEmpty ( askMessage ) && this.WaitInputAChar ( askMessage ) == 'n' ) )
				return new object[] { };

			if ( null == type )
			{

				if ( null == instance )
					return new object[] { };

				type = instance.GetType ();
			}

			MethodInfo method = null;

			switch ( functionType )
			{
				case FunctionType.Method:

					if ( string.IsNullOrEmpty ( functionName ) )
						return new object[] { };

					if ( null == parameterTypes )
						method = type.GetMethod ( functionName );
					else
						method = type.GetMethod ( functionName, parameterTypes );

					if ( null == method )
						return new object[] { };

					break;

				case FunctionType.Constructor:
					functionName = type.Name;
					break;
			}

			object[] results = new object[parameterList.Length];
			object[] parameterCopies;
			int index = 0;

			if ( !string.IsNullOrEmpty ( parameterMessage ) )
				parameterMessage = string.Format ( "[参数] {0}", parameterMessage );

			if ( !string.IsNullOrEmpty ( resultMessage ) )
				resultMessage = string.Format ( "[结果] {0}", resultMessage );

			foreach ( object[] parameters in parameterList )
			{

				if ( null == parameters )
					continue;

				if ( !string.IsNullOrEmpty ( parameterMessage ) )
				{
					parameterCopies = ( object[] ) ( parameters.Clone () );

					for ( int indexEX = 0; indexEX < parameterCopies.Length; indexEX++ )
						if ( null == parameterCopies[indexEX] )
							parameterCopies[indexEX] = ConvertNullToMessage ( parameterCopies[indexEX] );

					try
					{ this.WriteLine ( string.Format ( "[调用] {0}.{1} ", ( index + 1 ), functionName ) + string.Format ( parameterMessage, parameterCopies ) ); }
					catch { }

				}

				try
				{

					switch ( functionType )
					{
						case FunctionType.Method:
							results[index] = method.Invoke ( instance, parameters );
							break;

						case FunctionType.Constructor:
							results[index] = type.Assembly.CreateInstance ( type.FullName, true, BindingFlags.CreateInstance, null, parameters, null, null );
							break;
					}

				}
				catch ( Exception err )
				{ results[index] = err; }


				if ( !string.IsNullOrEmpty ( resultMessage ) )
					try
					{ this.WriteLine ( string.Format ( resultMessage, ConvertNullToMessage ( results[index] ) ) ); }
					catch { }

				index++;

				if ( isStoppable )
					this.WaitPressEnter ();

			}

			return results;
		}

#if PARAM
		/// <summary>
		/// 等待用户按下回车键.
		/// </summary>
		/// <param name="message">给与用户的提示信息, 默认为 "[等待] 请按回车键继续...".</param>
		/// <param name="isDisplay">指定是否显示等待信息, 如果为 false, 则不显示, 默认为 true.</param>
		public void WaitPressEnter ( string message = null, bool isDisplay = true )
#else
		/// <summary>
		/// 等待用户按下回车键.
		/// </summary>
		/// <param name="message">给与用户的提示信息.</param>
		/// <param name="isDisplay">指定是否显示等待信息, 如果为 false, 则不显示.</param>
		public void WaitPressEnter ( string message, bool isDisplay )
#endif
		{

			if ( !this.isTraceable || !isDisplay )
				return;

			if ( string.IsNullOrEmpty ( message ) )
				message = "[等待] 请按回车键继续...";

			this.WriteLine ( string.Format ( "\n{0}", message ) );
			Console.ReadLine ();
		}

#if PARAM
		/// <summary>
		/// 等待并显示用户输入一个字符.
		/// </summary>
		/// <param name="message">给与用户的提示信息, 默认空白信息.</param>
		/// <param name="charList">允许输入的字符表, 默认为 "y/n".</param>
		/// <param name="isDisplay">指定是否显示等待信息, 如果为 false, 则不等待, 默认为 true.</param>
		/// <returns>输入的字符.</returns>
		public char WaitInputAChar ( string message = null, string charList = null, bool isDisplay = true )
#else
		/// <summary>
		/// 等待并显示用户输入一个字符.
		/// </summary>
		/// <param name="message">给与用户的提示信息.</param>
		/// <param name="charList">允许输入的字符表, 如: "y/n".</param>
		/// <param name="isDisplay">指定是否显示等待信息, 如果为 false, 则不等待.</param>
		/// <returns>输入的字符.</returns>
		public char WaitInputAChar ( string message, string charList, bool isDisplay )
#endif
		{

			if ( !this.isTraceable || !isDisplay )
				return char.MinValue;

			if ( !string.IsNullOrEmpty ( message ) )
				this.WriteLine ( message );

			if ( string.IsNullOrEmpty ( charList ) )
				charList = "y/n";

			this.WriteLine ( string.Format ( "[等待] 请按 {0} 继续...", charList ) );

			charList = charList.Replace ( "/", string.Empty ).ToLower ();

			char inputChar;

			while ( true )
			{
				inputChar = Console.ReadKey ().KeyChar;

				if ( charList.Contains ( inputChar.ToString ().ToLower () ) )
					return inputChar;

			}

		}

#if PARAM
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="message">信息文字内容, 默认空白信息.</param>
		/// <param name="isDisplay">指定是否显示信息, 默认为 true.</param>
		public void Write ( string message = null, bool isDisplay = true )
#else
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="message">信息文字内容.</param>
		/// <param name="isDisplay">指定是否显示信息.</param>
		public void Write ( string message, bool isDisplay )
#endif
		{

			if ( !this.isTraceable || !isDisplay || null == message )
				return;

			Console.Write ( message );
		}

#if PARAM
		/// <summary>
		/// 输出一行信息.
		/// </summary>
		/// <param name="message">信息文字内容, 默认空白信息.</param>
		/// <param name="blankLineCount">信息前的换行次数, 默认 1 次.</param>
		/// <param name="isDisplay">指定是否显示信息, 默认为 true.</param>
		public void WriteLine ( string message = null, int blankLineCount = 1, bool isDisplay = true )
#else
		/// <summary>
		/// 输出一行信息.
		/// </summary>
		/// <param name="message">信息文字内容.</param>
		/// <param name="blankLineCount">信息前的换行次数.</param>
		/// <param name="isDisplay">指定是否显示信息.</param>
		public void WriteLine ( string message, int blankLineCount, bool isDisplay )
#endif
		{

			if ( !this.isTraceable || !isDisplay || null == message )
				return;

			// message = string.Format("{0}: {1}", DateTime.Now.ToString("T"), message);

			while ( --blankLineCount > 0 )
				message = "\n" + message;

			Console.WriteLine ( message );
		}

	}

	partial class Tracer
	{

#if !PARAM
		/// <summary>
		/// 将对象转化为字符串, 并处理对象为空的情况.
		/// </summary>
		/// <param name="value">要转化的对象.</param>
		/// <returns>转化后的字符串.</returns>
		public static string ConvertNullToMessage ( object value )
		{ return ConvertNullToMessage ( value, null ); }
		
		/// <summary>
		/// 创建一个 Tracer, 默认 IsTraceable 为 true.
		/// </summary>
		public Tracer () : this ( true ) { }

		/// <summary>
		/// 等待用户按下回车键.
		/// </summary>
		public void WaitPressEnter ()
		{ this.WaitPressEnter ( null, true ); }
		/// <summary>
		/// 等待用户按下回车键.
		/// </summary>
		/// <param name="isDisplay">指定是否显示等待信息, 如果为 false, 则不显示.</param>
		public void WaitPressEnter ( bool isDisplay )
		{ this.WaitPressEnter ( null, isDisplay ); }
		/// <summary>
		/// 等待用户按下回车键.
		/// </summary>
		/// <param name="message">给与用户的提示信息.</param>
		public void WaitPressEnter ( string message )
		{ this.WaitPressEnter ( message, true ); }

		/// <summary>
		/// 等待并显示用户输入一个字符, 输入 y 或 n 有效.
		/// </summary>
		/// <returns>输入的字符.</returns>
		public char WaitInputAChar ()
		{ return this.WaitInputAChar ( null, null, true ); }
		/// <summary>
		/// 等待并显示用户输入一个字符, 输入 y 或 n 有效.
		/// </summary>
		/// <param name="message">给与用户的提示信息.</param>
		/// <returns>输入的字符.</returns>
		public char WaitInputAChar ( string message )
		{ return this.WaitInputAChar ( message, null, true ); }
		/// <summary>
		/// 等待并显示用户输入一个字符, 输入 y 或 n 有效.
		/// </summary>
		/// <param name="message">给与用户的提示信息.</param>
		/// <param name="isDisplay">指定是否显示等待信息, 如果为 false, 则不等待.</param>
		/// <returns>输入的字符.</returns>
		public char WaitInputAChar ( string message, bool isDisplay )
		{ return this.WaitInputAChar ( message, null, isDisplay ); }
		/// <summary>
		/// 等待并显示用户输入一个字符.
		/// </summary>
		/// <param name="message">给与用户的提示信息.</param>
		/// <param name="charList">允许输入的字符表, 如: "y/n".</param>
		/// <returns>输入的字符.</returns>
		public char WaitInputAChar ( string message, string charList )
		{ return this.WaitInputAChar ( message, charList, true ); }
		
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="message">信息文字内容.</param>
		public void Write ( string message )
		{ this.Write ( message, true ); }

		/// <summary>
		/// 输出一个换行.
		/// </summary>
		public void WriteLine ()
		{ this.WriteLine ( string.Empty, 1, true ); }
		/// <summary>
		/// 输出一个换行.
		/// </summary>
		/// <param name="isDisplay">指定是否显示信息.</param>
		public void WriteLine ( bool isDisplay )
		{ this.WriteLine ( string.Empty, 1, isDisplay ); }
		/// <summary>
		/// 输出换行.
		/// </summary>
		/// <param name="blankLineCount">换行的个数.</param>
		public void WriteLine ( int blankLineCount )
		{ this.WriteLine ( string.Empty, blankLineCount, true ); }
		/// <summary>
		/// 输出换行.
		/// </summary>
		/// <param name="blankLineCount">换行的个数.</param>
		/// <param name="isDisplay">指定是否显示信息.</param>
		public void WriteLine ( int blankLineCount, bool isDisplay )
		{ this.WriteLine ( string.Empty, blankLineCount, isDisplay ); }
		/// <summary>
		/// 输出一行信息, 前跟一个换行.
		/// </summary>
		/// <param name="message">信息文字内容.</param>
		public void WriteLine ( string message )
		{ this.WriteLine ( message, 1, true ); }
		/// <summary>
		/// 输出一行信息, 前跟一个换行.
		/// </summary>
		/// <param name="message">信息文字内容.</param>
		/// <param name="isDisplay">指定是否显示信息.</param>
		public void WriteLine ( string message, bool isDisplay )
		{ this.WriteLine ( message, 1, isDisplay ); }
		/// <summary>
		/// 输出一行信息.
		/// </summary>
		/// <param name="message">信息文字内容.</param>
		/// <param name="blankLineCount">信息前的换行次数.</param>
		public void WriteLine ( string message, int blankLineCount )
		{ this.WriteLine ( message, blankLineCount, true ); }
#endif

	}

}
// .enum/FunctionType.cs
/*
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/FunctionType.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * */

namespace zoyobar.shared.panzer
{

	/// <summary>
	/// 函数或者方法的类型.
	/// </summary>
	public enum FunctionType
	{
		/// <summary>
		/// 方法.
		/// </summary>
		Method = 1,
		/// <summary>
		/// 构造函数.
		/// </summary>
		Constructor = 2
	}

}
// test/TestTracer.cs


namespace zoyobar.shared.panzer.test
{

	public class TestTracer
	{

		public class Student
		{

			public static void Print ( Student student )
			{

				if ( null == student )
					return;

				Console.WriteLine ( string.Format ( "姓名: {0}, 年龄: {1}", student.name, student.age ) );
			}

			private string name;
			private int age;

			public Student ( string name, int age )
			{

				if ( string.IsNullOrEmpty ( name ) )
					throw new NullReferenceException ( "姓名不能为空" );

				this.name = name;
				this.age = age;
			}

			public void GoToSchool ( )
			{ Console.WriteLine ( string.Format ( "{0} goto school", this.name ) ); }

			public string SetName ( string name )
			{

				if ( string.IsNullOrEmpty ( name ) )
					throw new NullReferenceException ( "姓名不能为空" );

				this.name = name;
				return name;
			}

			public string GetName ( )
			{ return name; }

			public string GetName ( int id )
			{ return id.ToString ( ) + name; }

		}

		public void Test ( )
		{
			this.TestConstructor ( );
			this.TestConvertNullToMessage ( );
			this.TestWriteLine ( );
			this.TestWaitPressEnter ( );
			this.TestWaitInputAChar ( );
			this.TestExecute ( );
		}

		public void TestConvertNullToMessage ( )
		{
			Console.WriteLine ( "测试方法 Tracer.ConvertNullToMessage(object)" );

			try
			{
				Console.WriteLine ( string.Format ( "成功: Tracer.ConvertNullToMessage(123), 返回: {0}", Tracer.ConvertNullToMessage ( 123 ) ) );
				Console.WriteLine ( string.Format ( "成功: Tracer.ConvertNullToMessage(null), 返回: {0}", Tracer.ConvertNullToMessage ( null ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 Tracer.ConvertNullToMessage(object, string)" );

			try
			{
				Console.WriteLine ( string.Format ( "成功: Tracer.ConvertNullToMessage(\"jack\", \"空\"), 返回: {0}", Tracer.ConvertNullToMessage ( "jack", "空" ) ) );
				Console.WriteLine ( string.Format ( "成功: Tracer.ConvertNullToMessage(null, \"空\"), 返回: {0}", Tracer.ConvertNullToMessage ( null, "空" ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestConstructor ( )
		{
			Console.WriteLine ( "测试构造函数 new Tracer()" );

			try
			{
				new Tracer ( );
				Console.WriteLine ( "成功: new Tracer()" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试构造函数 new Tracer(bool)" );

			try
			{
				new Tracer ( false );
				Console.WriteLine ( "成功: new Tracer(false)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestWriteLine ( )
		{
			Console.WriteLine ( "测试方法 WriteLine()" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( isDisplay: false );
				Console.WriteLine ( "成功: WriteLine(false)" );
				tracer.WriteLine ( isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(true)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(int)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( blankLineCount: 2 );
				Console.WriteLine ( "成功: WriteLine(2)" );
				tracer.WriteLine ( blankLineCount: 1 );
				Console.WriteLine ( "成功: WriteLine(1)" );
				tracer.WriteLine ( blankLineCount: 0 );
				Console.WriteLine ( "成功: WriteLine(0)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(int, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( blankLineCount: 2, isDisplay: false );
				Console.WriteLine ( "成功: WriteLine(2, false)" );
				tracer.WriteLine ( blankLineCount: 1, isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(1, true)" );
				tracer.WriteLine ( blankLineCount: 0, isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(0, true)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(string)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( "一行文字" );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\")" );
				tracer.WriteLine ( null );
				Console.WriteLine ( "成功: WriteLine(null)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(string, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( "一行文字", isDisplay: false );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", false)" );
				tracer.WriteLine ( "一行文字", isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", true)" );
				tracer.WriteLine ( null, isDisplay: true );
				Console.WriteLine ( "成功: WriteLine(null, true)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(string, int)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( "一行文字", 3 );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", 3)" );
				tracer.WriteLine ( "一行文字", -1 );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", -1)" );
				tracer.WriteLine ( null, 2 );
				Console.WriteLine ( "成功: WriteLine(null, 2)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WriteLine(string, int, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WriteLine ( "一行文字", 5, true );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", 5, true)" );
				tracer.WriteLine ( "一行文字", -1, true );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", -1, true)" );
				tracer.WriteLine ( "一行文字", 3, false );
				Console.WriteLine ( "成功: WriteLine(\"一行文字\", 3, false)" );
				tracer.WriteLine ( null, 2, true );
				Console.WriteLine ( "成功: WriteLine(null, 2, true)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestWaitPressEnter ( )
		{
			Console.WriteLine ( "测试方法 WaitPressEnter()" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WaitPressEnter ( );
				Console.WriteLine ( "成功: WaitPressEnter()" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitPressEnter(bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WaitPressEnter ( isDisplay: true );
				Console.WriteLine ( "成功: WaitPressEnter(true)" );
				tracer.WaitPressEnter ( isDisplay: false );
				Console.WriteLine ( "成功: WaitPressEnter(false)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitPressEnter(string)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WaitPressEnter ( "请按下您的 Enter !!!" );
				Console.WriteLine ( "成功: WaitPressEnter(\"请按下您的 Enter !!!\")" );
				tracer.WaitPressEnter ( null );
				Console.WriteLine ( "成功: WaitPressEnter(null)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitPressEnter(string, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				tracer.WaitPressEnter ( "请按下您的 Enter !!!", true );
				Console.WriteLine ( "成功: WaitPressEnter(\"请按下您的 Enter !!!\", true)" );
				tracer.WaitPressEnter ( "请按下您的 Enter !!!", false );
				Console.WriteLine ( "成功: WaitPressEnter(\"请按下您的 Enter !!!\", false)" );
				tracer.WaitPressEnter ( null, true );
				Console.WriteLine ( "成功: WaitPressEnter(null, true)" );
				tracer.WaitPressEnter ( null, false );
				Console.WriteLine ( "成功: WaitPressEnter(null, false)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestWaitInputAChar ( )
		{
			Console.WriteLine ( "测试方法 WaitInputAChar()" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(), 返回: {0}", tracer.WaitInputAChar ( ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitInputAChar(string)" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\"), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下" ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null), 返回: {0}", tracer.WaitInputAChar ( null ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitInputAChar(string, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", true), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", isDisplay: true ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", false), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", isDisplay: false ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, true), 返回: {0}", tracer.WaitInputAChar ( null, isDisplay: true ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitInputAChar(string, string)" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", \"a/b\"), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", "a/b" ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", null), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", null ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, \"a/b\"), 返回: {0}", tracer.WaitInputAChar ( null, "a/b" ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, null), 返回: {0}", tracer.WaitInputAChar ( null, null ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }


			Console.WriteLine ( "测试方法 WaitInputAChar(string, string, bool)" );

			try
			{
				Tracer tracer = new Tracer ( );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", \"a/b\", false), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", "a/b", false ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(\"请您敲一下\", null, true), 返回: {0}", tracer.WaitInputAChar ( "请您敲一下", null, true ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, \"a/b\", false), 返回: {0}", tracer.WaitInputAChar ( null, "a/b", false ) ) );
				Console.WriteLine ( string.Format ( "成功: WaitInputAChar(null, null, true), 返回: {0}", tracer.WaitInputAChar ( null, null, true ) ) );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

		public void TestExecute ( )
		{
			Console.WriteLine ( "测试方法 Execute(object, Type, string, FunctionType, Type[], string, string, string, object[][], bool)" );

			try
			{
				Student jack = new Student ( "jack", 10 );
				Student tom = new Student ( "tom", 9 );

				Tracer tracer = new Tracer ( );

				tracer.Execute ( jack, null, "GoToSchool", FunctionType.Method, null, null, null, null,
					new object[][] {
						new object[] { }
					},
					true
					);

				Console.WriteLine ( "成功: Execute(jack, null, \"GoToSchool\", FunctionType.Method, null, null, null, null, new object[][] { new object[] { } }, true)" );

				foreach ( object result in tracer.Execute ( jack, null, "SetName", FunctionType.Method, null, "姓名: {0}", "返回: {0}", "是否测试 SetName ?",
					new object[][] {
						new object[] { "jack2" },
						new object[] { "jack3" }
					},
					false
					)
					)
					Console.WriteLine ( result );

				Console.WriteLine ( "成功: Execute(jack, null, \"SetName\", FunctionType.Method, null, \"姓名: <0>\", \"返回: <0>\", \"是否测试 SetName ?\", new object[][] { new object[] { \"jack2\" }, new object[] { \"jack3\" } }, false)" );

				foreach ( object result in tracer.Execute ( jack, null, "GetName", FunctionType.Method, new Type[] { }, null, "返回: {0}", null,
					new object[][] {
						new object[] { },
						new object[] { }
					},
					true
					)
					)
					Console.WriteLine ( result );

				Console.WriteLine ( "成功: Execute(jack, null, \"GetName\", FunctionType.Method, new Type[] { }, null, \"返回: <0>\", null, new object[][] { new object[] { }, new object[] { } }, true)" );

				foreach ( object result in tracer.Execute ( jack, null, "GetName", FunctionType.Method, new Type[] { typeof ( int ) }, null, "返回: {0}", null,
					new object[][] {
						new object[] { 1 },
						new object[] { 2 }
					},
					true
					)
					)
					Console.WriteLine ( result );

				Console.WriteLine ( "成功: Execute(jack, null, \"GetName\", FunctionType.Method, new Type[] { typeof(int) }, null, \"返回: <0>\", null, new object[][] { new object[] { 1 }, new object[] { 2 } }, true)" );

				foreach ( object result in tracer.Execute ( null, typeof ( Student ), null, FunctionType.Constructor, null, "姓名: {0}, 年龄: {1}", "返回: {0}", null,
					new object[][] {
						new object[] { "lili", 11 },
						new object[] { string.Empty, 12 }
					},
					true
					)
					)
					Console.WriteLine ( result );

				Console.WriteLine ( "成功: Execute(null, typeof(Student), null, FunctionType.Constructor, null, \"姓名: <0>, 年龄: <1>\", \"返回: <0>\", null, new object[][] { new object[] { \"lili\", 11 }, new object[] { \"lucy\", 11 } }, true)" );

				tracer.Execute ( null, typeof ( Student ), "Print", FunctionType.Method, null, null, null, null,
					new object[][] {
						new object[] { jack },
						new object[] { tom }
					},
					false
					);

				Console.WriteLine ( "成功: Execute(null, typeof(Student), \"Print\", FunctionType.Method, null, null, null, null, new object[][] { new object[] { jack }, new object[] { tom } }, false)" );
			}
			catch ( Exception err )
			{ Console.WriteLine ( string.Format ( "异常: {0}", err.Message ) ); }

			Console.WriteLine ( "请按回车键继续..." );
			Console.ReadLine ( );
		}

	}

	public class SampleTracer
	{

		public static void Main ( )
		{
			new SampleTracer.TestDog ( ).Test ( );
		}

		public class Dog
		{
			string nickName;
			int price;
			int amount;

			public Dog ( string nickName, int price )
				: this ( nickName, price, 1 )
			{ }

			public Dog ( string nickName, int price, int amount )
			{

				if ( string.IsNullOrEmpty ( nickName ) )
					throw new ArgumentException ( "昵称不能为空", "nickName" );

				if ( price <= 0 || price > 10000 )
					throw new ArgumentException ( "价格不能太离奇", "price" );

				if ( amount <= 0 || amount > 10 )
					amount = 1;

				this.nickName = nickName;
				this.price = price;
				this.amount = amount;
			}

			public int Buy ( int money )
			{ return this.Buy ( money, false ); }
			public int Buy ( int money, bool isDiscount )
			{
				int price;

				if ( isDiscount )
					price = this.price / 2;
				else
					price = this.price;

				if ( this.amount < 0 )
					throw new Exception ( "对不起没有库存了" );

				if ( money < price )
					throw new ArgumentException ( "您支付钱太少了", "money" );

				this.amount--;
				return money - price;
			}

		}

		class TestDog
		{
			// 创建一个 Tracer 对象
			Tracer tracer = new Tracer ( true );

			public void Test ( )
			{
				// 如果不希望显示信息, 可以使用下面的语句
				// this.tracer.IsTraceable = false;

				// 换行 3 次并显示调试信息
				this.tracer.WriteLine ( "---- 开始测试 Dog ----", 3 );

				// 这是一条不显示的信息
				this.tracer.WriteLine ( "这条信息不显示", isDisplay: false );

				// 询问是否测试 Dog 的相关内容, 等待用户输入 g 或者 s, g 则继续
				if ( this.tracer.WaitInputAChar ( "是否测试 Dog 的相关内容?", "g/s" ) == 'g' )
				{
					// 使用 5 组不同的数据测试构造函数 Dog, 之前询问是否测试
					this.tracer.Execute ( null, typeof ( Dog ), null, FunctionType.Constructor, null, null, "返回: {0}", "测试构造函数?",
						new object[][] {
							new object[] {"求生犬", 200, 20},
							new object[] {"哈巴狗", 100},
							new object[] {"狼狗", 0},
							new object[] {"", 100},
							new object[] {"牧羊犬", 20000}
						},
						true
						);

					Dog dog = new Dog ( "狼狗", 200, 2 );

					// 使用 4 组不同的数据测试 Buy 方法, 之前询问是否测试
					this.tracer.Execute ( dog, null, "Buy", FunctionType.Method, new Type[] { typeof ( int ) }, "支付 {0} 元", "找 {0} 元", "测试 Buy(int) 方法?",
						new object[][] {
							new object[] {300},
							new object[] {100},
							new object[] {400},
							new object[] {300}
						},
						true
						);

					dog = new Dog ( "狼狗", 200, 2 );

					// 使用 4 组不同的数据测试打折的 Buy 方法, 之前询问是否测试
					this.tracer.Execute ( dog, null, "Buy", FunctionType.Method, new Type[] { typeof ( int ), typeof ( bool ) }, "支付 {0} 元", "找 {0} 元", "测试 Buy(int, bool) 方法?",
						new object[][] {
							new object[] {300, false},
							new object[] {100, true},
							new object[] {400, true},
							new object[] {300, true}
						},
						true
						);
				}

			}

		}

	}

}

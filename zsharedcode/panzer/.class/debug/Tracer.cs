/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/debug/Tracer.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Reflection;

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

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryCoder.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.Reflection;
using System.Web;
using System.Web.UI;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 此类用于解释 JQueryElement 以及相关控件中的内嵌语法.
	/// </summary>
	public sealed class JQueryCoder
	{

		/// <summary>
		/// 解释内嵌语法, 分别有 [%id:服务器控件 ID%], [%param:Request 中的 ID%], [%fun:页面中的方法%].
		/// </summary>
		/// <param name="control">控件, 其所在的页面将输出脚本.</param>
		/// <param name="code">包含内嵌语法的代码.</param>
		/// <returns>解释后的代码.</returns>
		public static string Encode ( Control control, string code )
		{

			if ( string.IsNullOrEmpty ( code ) || null == control || null == control.Page )
				return string.Empty;

			int beginIndex;
			int endIndex;

			while ( true )
			{
				endIndex = code.IndexOf ( "%]" );

				if ( endIndex == -1 )
					break;

				beginIndex = code.LastIndexOf ( "[%", endIndex );

				if ( beginIndex == -1 )
					break;

				string expression = code.Substring ( beginIndex, endIndex - beginIndex + 2 );

				string command = expression.Replace ( "[%", string.Empty ).Replace ( "%]", string.Empty ).Trim ( );

				beginIndex = command.IndexOf ( ':' );

				if ( beginIndex <= 0 || beginIndex == command.Length - 1 )
					break;

				string commandName = command.Substring ( 0, beginIndex ).Trim ( ).ToLower ( );
				string commandParameter = command.Substring ( beginIndex + 1 ).Trim ( );

				if ( commandName == string.Empty || commandParameter == string.Empty )
					break;

				string result = null;

				switch ( commandName )
				{
					case "id":
						Control aimControl = control.Page.FindControl ( commandParameter );

						if ( null != aimControl )
							result = aimControl.ClientID;

						break;

					case "param":

						try
						{ result = control.Page.Request[commandParameter]; }
						catch { }

						break;

					case "fun":
						MethodInfo methodInfo;
						Control currentControl = control;

						while ( true )
						{
							methodInfo = currentControl.GetType ( ).GetMethod ( commandParameter, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic );

							if ( null != methodInfo || null == currentControl.Parent )
								break;

							currentControl = currentControl.Parent;
						}

						if ( null != methodInfo )
							if ( methodInfo.IsStatic )
								result = methodInfo.Invoke ( null, null ) as string;
							else
								result = methodInfo.Invoke ( currentControl, null ) as string;

						break;

					case "\\'":
						result = "' + " + commandParameter + " + '";
						break;

					case "\\\"":
						result = "\" + " + commandParameter + " + \"";
						break;
				}

				code = code.Replace ( expression, string.IsNullOrEmpty ( result ) ? "null" : result );
			}

			return code.Replace ( "!sq!", "'" ).Replace ( "!dq!", "'" );
		}

	}

}

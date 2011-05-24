/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryCoder
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryCoder.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System.Reflection;
using System.Web;
using System.Web.UI;

// HACK: 避免在 allinone 文件中的名称冲突
using NControl = System.Web.UI.Control;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// 为 JQueryElement 以及相关控件中的内嵌语法执行操作.
	/// </summary>
	public sealed class JQueryCoder
	{

		/// <summary>
		/// 编码内嵌语法.
		/// </summary>
		/// <param name="control">控件.</param>
		/// <param name="code">包含内嵌语法的代码.</param>
		/// <returns>编码后的代码.</returns>
		public static string Encode ( NControl control, string code )
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
						NControl aimControl = control.Page.FindControl ( commandParameter );

						if ( null != aimControl )
							result = aimControl.ClientID;

						break;

					case "param":

						try
						{ result = HttpContext.Current.Request[commandParameter]; }
						catch { }

						break;

					case "fun":
						MethodInfo methodInfo;
						NControl currentControl = control;

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

/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ib/ElementMark.cs
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.Windows.Forms;

namespace zoyobar.shared.panzer.web.ib
{

	/// <summary>
	/// 用于标记 HtmlElement 对象.
	/// </summary>
	public sealed class ElementMark
	{

		/// <summary>
		/// 根据 HtmlElement 创建标记对象.
		/// </summary>
		/// <param name="element">用于创建标记对象的 HtmlElement.</param>
		/// <returns>ElementMark 对象.</returns>
		public static ElementMark Create ( HtmlElement element )
		{

			if ( null == element )
				throw new ArgumentNullException ( "element", "HtmlElement 不能为空" );

			return new ElementMark ( element.Id, element.TagName, element.Name, element.GetAttribute ( "class" ), element.GetAttribute ( "type" ), ( element.GetAttribute ( "type" ) == "text" || element.GetAttribute ( "type" ) == "password" ) ? string.Empty : element.GetAttribute ( "value" ), element.GetAttribute ( "href" ), IEBrowser.GetFramePath ( element ) );
		}

		/// <summary>
		/// 根据表达式创建标记对象.
		/// </summary>
		/// <param name="element">用于创建标记对象的表达式.</param>
		/// <returns>ElementMark 对象.</returns>
		public static ElementMark Create ( string expression )
		{

			if ( string.IsNullOrEmpty ( expression ) )
				throw new ArgumentNullException ( "expression", "表达式不能为空" );

			string[] parts = expression.Split ( new string[] { "`,`" }, StringSplitOptions.RemoveEmptyEntries );

			if ( parts.Length < 8 )
				throw new ArgumentException ( "表达式应至少包含 8 项内容", "expression" );

			return new ElementMark ( parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7] );
		}

		/// <summary>
		/// 元素的 id 属性.
		/// </summary>
		public string ID;
		/// <summary>
		/// 元素的 tagName 属性.
		/// </summary>
		public string TagName;
		/// <summary>
		/// 元素的 name 属性.
		/// </summary>
		public string Name;
		/// <summary>
		/// 元素的 class 属性.
		/// </summary>
		public string Class;
		/// <summary>
		/// 元素的 type 属性.
		/// </summary>
		public string Type;
		/// <summary>
		/// 元素的 value 属性.
		/// </summary>
		public string Value;
		/// <summary>
		/// 元素的 href 属性.
		/// </summary>
		public string Href;

		/// <summary>
		/// 元素所在的 document 的路径.
		/// </summary>
		public string FramePath;

		/// <summary>
		/// 创建一个用于标记 HtmlElement 的对象.
		/// </summary>
		/// <param name="id">元素的 id 属性.</param>
		/// <param name="tagName">元素的 tagName 属性.</param>
		/// <param name="name">元素的 name 属性.</param>
		/// <param name="class">元素的 class 属性.</param>
		/// <param name="type">元素的 type 属性.</param>
		/// <param name="value">元素的 value 属性.</param>
		/// <param name="href">元素的 href 属性.</param>
		/// <param name="framePath">元素所在的 document 的路径.</param>
		public ElementMark ( string id, string tagName, string name, string @class, string type, string value, string href, string framePath )
		{
			this.ID = id;
			this.TagName = tagName;
			this.Name = name;
			this.Class = @class;
			this.Type = type;
			this.Value = value;
			this.Href = href;
			this.FramePath = framePath;
		}

		/// <summary>
		/// 转化为等效的字符串.
		/// </summary>
		/// <returns>字符串.</returns>
		public override string ToString ( )
		{ return string.Format ( "{0}`,`{1}`,`{2}`,`{3}`,`{4}`,`{5}`,`{6}`,`{7}", this.ID, this.TagName, this.Name, this.Class, this.Type, this.Value, this.Href, this.FramePath ); }

	}

}

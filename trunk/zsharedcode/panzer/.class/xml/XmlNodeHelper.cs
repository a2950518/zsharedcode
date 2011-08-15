/*
 * wiki: http://code.google.com/p/zsharedcode/wiki/XmlNodeHelper
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/xml/XmlNodeHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Collections.Generic;
using System.Xml;

using zoyobar.shared.panzer.code;

namespace zoyobar.shared.panzer.xml
{

	/// <summary>
	/// XmlNode 辅助类, 可以设置读取属性, 或者查找节点等.
	/// </summary>
	/// <typeparam name="N">XmlNode 或者其派生类.</typeparam>
	public partial class XmlNodeHelper<N>
		where N : XmlNode
	{
		private static readonly List<XmlNodeHelper<XmlNode>> sharedFetchedNodeHelpers = new List<XmlNodeHelper<XmlNode>> ( );

		/// <summary>
		/// 获取共享的得到的 XmlNode 子节点辅助类.
		/// </summary>
		public static List<XmlNodeHelper<XmlNode>> SharedFetchedNodeHelpers
		{
			get { return sharedFetchedNodeHelpers; }
		}

		#region " GetAttributeValue "
#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 null.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNodeHelper<XmlNode> nodeHelper, string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNodeHelper<XmlNode> nodeHelper, string name, object defaultValue )
#endif
		{ return GetAttributeValue<object> ( nodeHelper, name, defaultValue ); }

#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 default(T).</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNodeHelper<XmlNode> nodeHelper, string name = null, T defaultValue = default(T) )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNodeHelper<XmlNode> nodeHelper, string name, T defaultValue )
#endif
		{

			if ( null == nodeHelper )
				return default ( T );

			return GetAttributeValue<T> ( nodeHelper.node, name, defaultValue );
		}

#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 null.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNode node, string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNode node, string name, object defaultValue )
#endif
		{ return GetAttributeValue<object> ( node, name, defaultValue ); }

#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 default(T).</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNode node, string name = null, T defaultValue = default(T) )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNode node, string name, T defaultValue )
#endif
		{
			T value = default ( T );

			FetchAttributeValue<T> ( ref value, node, name, defaultValue );
			return value;
		}
		#endregion

		#region " FetchAttributeValue "
#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 null.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<XmlNode> nodeHelper, string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<XmlNode> nodeHelper, string name, object defaultValue )
#endif
		{ return FetchAttributeValue<object> ( ref value, nodeHelper, name, defaultValue ); }

#if PARAM
		/// <summary>
		/// 获取辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 default(T).</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<XmlNode> nodeHelper, string name = null, T defaultValue = default(T) )
#else
		/// <summary>
		/// 获取辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<XmlNode> nodeHelper, string name, T defaultValue )
#endif
		{

			if ( null == nodeHelper )
				return false;

			return FetchAttributeValue<T> ( ref value, nodeHelper.node, name, defaultValue );
		}

#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 null.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNode node, string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNode node, string name, object defaultValue )
#endif
		{ return FetchAttributeValue<object> ( ref value, node, name, defaultValue ); }

#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 default(T).</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNode node, string name = null, T defaultValue = default(T) )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNode node, string name, T defaultValue )
#endif
		{

			if ( null == node )
				return false;

			if ( string.IsNullOrEmpty ( name ) )
				name = "value";

			XmlAttribute attribute = node.Attributes[name];

			if ( null != attribute )
				try
				{
					value = StringConvert.ToObject<T> ( attribute.Value );

					return true;
				}
				catch
				{ }

			if ( null == defaultValue )
				value = default ( T );
			else
				value = defaultValue;

			return false;
		}
		#endregion

		#region " FlushAttributeValue "
#if PARAM
		/// <summary>
		/// 设置辅助类所表示 XmlNode 的属性值. 
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="value">属性值.</param>
		/// <param name="name">属性的名称, 默认为 null.</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( XmlNodeHelper<XmlNode> nodeHelper, object value, string name = null )
#else
		/// <summary>
		/// 设置辅助类所表示 XmlNode 的属性值. 
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="value">属性值.</param>
		/// <param name="name">属性的名称.</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( XmlNodeHelper<XmlNode> nodeHelper, object value, string name )
#endif
		{

			if ( null == nodeHelper )
				return false;

			return FlushAttributeValue ( nodeHelper.node, value, name );
		}

#if PARAM
		/// <summary>
		/// 设置辅助类所表示 XmlNode 的属性值. 
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="value">属性值.</param>
		/// <param name="name">属性的名称, 默认为 "value".</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( XmlNode node, object value, string name = null )
#else
		/// <summary>
		/// 设置辅助类所表示 XmlNode 的属性值. 
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="value">属性值.</param>
		/// <param name="name">属性的名称.</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( XmlNode node, object value, string name )
#endif
		{

			if ( null == value || null == node )
				return false;

			if ( null == name )
				name = "value";

			XmlAttribute attribute = node.Attributes[name];

			if ( null == attribute )
				return false;

			attribute.Value = StringConvert.ToString ( value );
			return true;
		}
		#endregion

		#region " Fetch(Get)NodeHelper(s) "
		/// <summary>
		/// 得到 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="beginNodeHelper">开始的 XmlNode 辅助类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>搜索到子节点辅助类.</returns>
		public static XmlNodeHelper<XmlNode> GetNodeHelper ( XmlNodeHelper<XmlNode> beginNodeHelper, string xPath )
		{

			if ( null == beginNodeHelper )
				return null;

			return GetNodeHelper ( beginNodeHelper.node, xPath );
		}
		/// <summary>
		/// 得到 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="beginNode">开始的 XmlNode 类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>搜索到子节点辅助类.</returns>
		public static XmlNodeHelper<XmlNode> GetNodeHelper ( XmlNode beginNode, string xPath )
		{
			XmlNodeHelper<XmlNode> nodeHelper = null;

			FetchNodeHelper ( ref nodeHelper, beginNode, xPath );
			return nodeHelper;
		}
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelper">返回的子节点的辅助类.</param>
		/// <param name="beginNodeHelper">开始的 XmlNode 辅助类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public static bool FetchNodeHelper ( ref XmlNodeHelper<XmlNode> nodeHelper, XmlNodeHelper<XmlNode> beginNodeHelper, string xPath )
		{
			if ( null == beginNodeHelper )
				return false;

			return FetchNodeHelper ( ref nodeHelper, beginNodeHelper.node, xPath );
		}
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="beginNode">开始的 XmlNode 类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public static bool FetchNodeHelper ( XmlNode beginNode, string xPath )
		{
			XmlNodeHelper<XmlNode> nodeHelper = null;

			return FetchNodeHelper ( ref nodeHelper, beginNode, xPath );
		}
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelper">返回的子节点的辅助类.</param>
		/// <param name="beginNode">开始的 XmlNode 类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public static bool FetchNodeHelper ( ref XmlNodeHelper<XmlNode> nodeHelper, XmlNode beginNode, string xPath )
		{
			List<XmlNodeHelper<XmlNode>> nodeHelpers = GetNodeHelpers ( beginNode, xPath );

			if ( nodeHelpers.Count == 0 )
				return false;

			nodeHelper = nodeHelpers[0];
			sharedFetchedNodeHelpers.Clear ( );
			sharedFetchedNodeHelpers.Add ( nodeHelper );
			return true;
		}

		/// <summary>
		/// 得到 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="beginNodeHelper">开始的 XmlNode 辅助类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>搜索到子节点辅助类.</returns>
		public static List<XmlNodeHelper<XmlNode>> GetNodeHelpers ( XmlNodeHelper<XmlNode> beginNodeHelper, string xPath )
		{

			if ( null == beginNodeHelper )
				return new List<XmlNodeHelper<XmlNode>> ( );

			return GetNodeHelpers ( beginNodeHelper.node, xPath );
		}
		/// <summary>
		/// 得到 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="beginNode">开始的 XmlNode 类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>搜索到子节点辅助类.</returns>
		public static List<XmlNodeHelper<XmlNode>> GetNodeHelpers ( XmlNode beginNode, string xPath )
		{
			List<XmlNodeHelper<XmlNode>> nodeHelpers = new List<XmlNodeHelper<XmlNode>> ( );

			FetchNodeHelpers ( ref nodeHelpers, beginNode, xPath );
			return nodeHelpers;
		}
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelpers">返回的子节点的辅助类.</param>
		/// <param name="beginNodeHelper">开始的 XmlNode 辅助类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public static bool FetchNodeHelpers ( ref List<XmlNodeHelper<XmlNode>> nodeHelpers, XmlNodeHelper<XmlNode> beginNodeHelper, string xPath )
		{

			if ( null == beginNodeHelper )
				return false;

			return FetchNodeHelpers ( ref nodeHelpers, beginNodeHelper.node, xPath );
		}
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="beginNode">开始的 XmlNode 类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public static bool FetchNodeHelpers ( XmlNode beginNode, string xPath )
		{
			List<XmlNodeHelper<XmlNode>> nodeHelpers = null;

			return FetchNodeHelpers ( ref nodeHelpers, beginNode, xPath );
		}
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelpers">返回的子节点的辅助类.</param>
		/// <param name="beginNode">开始的 XmlNode 类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public static bool FetchNodeHelpers ( ref List<XmlNodeHelper<XmlNode>> nodeHelpers, XmlNode beginNode, string xPath )
		{

			if ( null == nodeHelpers )
				nodeHelpers = new List<XmlNodeHelper<XmlNode>> ( );

			if ( null == beginNode || string.IsNullOrEmpty ( xPath ) )
				return false;

			try
			{

				foreach ( XmlNode node in beginNode.SelectNodes ( xPath ) )
					nodeHelpers.Add ( new XmlNodeHelper<XmlNode> ( node ) );

			}
			catch { }

			if ( nodeHelpers.Count == 0 )
				return false;

			sharedFetchedNodeHelpers.Clear ( );
			sharedFetchedNodeHelpers.AddRange ( nodeHelpers.ToArray() );
			return true;
		}
		#endregion

		#region " AppendNode "
		/// <summary>
		/// 添加 Xml 节点.
		/// </summary>
		/// <param name="parentNodeHelper">添加到的节点的辅助类.</param>
		/// <param name="childNodeHelper">添加节点的辅助类.</param>
		public static void AppendNode ( XmlNodeHelper<XmlNode> parentNodeHelper, XmlNodeHelper<XmlNode> childNodeHelper )
		{

			if ( null == parentNodeHelper || null == parentNodeHelper.node || null == childNodeHelper )
				return;

			try
			{ parentNodeHelper.node.InnerXml += childNodeHelper.OuterXml; }
			catch { }

		}
		#endregion

		private readonly string name;
		protected N node;
		private readonly List<XmlNodeHelper<XmlNode>> childNodeHelpers = new List<XmlNodeHelper<XmlNode>> ( );

		private readonly SortedList<string, object> attributes = new SortedList<string, object> ( );

		private readonly List<XmlNodeHelper<XmlNode>> fetchedNodeHelpers = new List<XmlNodeHelper<XmlNode>> ( );

		/// <summary>
		/// 获取节点名称.
		/// </summary>
		public string Name
		{
			get { return this.name; }
		}

		/// <summary>
		/// 获取继承自 XmlNode 的节点.
		/// </summary>
		public N Node
		{
			get { return this.node; }
		}

		/// <summary>
		/// 获取子节点的 XmlNodeHelper.
		/// </summary>
		public List<XmlNodeHelper<XmlNode>> ChildNodeHelpers
		{
			get { return this.childNodeHelpers; }
		}

		/// <summary>
		/// 获取 XmlNodeHelper 以及 ChildNodeHelpers 生成的 OuterXml.
		/// </summary>
		public string OuterXml
		{
			get
			{
				string xml = string.Format ( "<{0}", this.name );

				foreach ( string attributeName in this.attributes.Keys )
					xml += string.Format ( " {0}=\"{1}\"", attributeName, StringConvert.ToString ( this.attributes[attributeName] ) );

				if ( this.childNodeHelpers.Count == 0 )
					xml += " />";
				else
				{
					xml += ">";

					foreach ( XmlNodeHelper<XmlNode> childNodeHelper in this.childNodeHelpers )
						if ( null != childNodeHelper )
							xml += childNodeHelper.OuterXml;

					xml += string.Format ( "</{0}>", this.name );
				}

				return xml;
			}
		}

		/// <summary>
		/// 获取得到的 XmlNode 子节点辅助类.
		/// </summary>
		public List<XmlNodeHelper<XmlNode>> FetchedNodeHelpers
		{
			get { return this.fetchedNodeHelpers; }
		}

		/// <summary>
		/// 获取设置节点的属性.
		/// </summary>
		/// <param name="attributeName">属性名称.</param>
		/// <returns>属性值.</returns>
		public object this[string attributeName]
		{
			get
			{

				if ( string.IsNullOrEmpty ( attributeName ) || !this.attributes.ContainsKey ( attributeName ) )
					return string.Empty;

				return this.attributes[attributeName];
			}
			set
			{

				if ( string.IsNullOrEmpty ( attributeName ) )
					return;

				if ( this.attributes.ContainsKey ( attributeName ) )
					this.attributes[attributeName] = value;
				else
					this.attributes.Add ( attributeName, value );

			}
		}

		/// <summary>
		/// 从 XmlNode 创建一个辅助类.
		/// </summary>
		/// <param name="node">XmlNode.</param>
		public XmlNodeHelper ( N node )
		{

			if ( null == node )
				throw new ArgumentNullException ( "node", " Xml 节点不能为空" );

			this.name = node.Name;
			this.node = node;
		}

		/// <summary>
		/// 创建拥有名称和子节点的 XmlNode 辅助类.
		/// </summary>
		/// <param name="name">节点名称.</param>
		/// <param name="childNodeHelpers">子节点的 XmlNode 辅助类.</param>
		public XmlNodeHelper ( string name, params XmlNodeHelper<XmlNode>[] childNodeHelpers )
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", " 节点名称不能为空" );

			if ( null != childNodeHelpers )
				foreach ( XmlNodeHelper<XmlNode> childNodeHelper in childNodeHelpers )
					if ( null != childNodeHelper )
						this.childNodeHelpers.Add ( childNodeHelper );

			this.name = name;
		}

		#region " GetAttributeValue "
#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 null.</param>
		/// <returns>属性值.</returns>
		public object GetAttributeValue ( string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public object GetAttributeValue ( string name, object defaultValue )
#endif
		{ return GetAttributeValue<object> ( this.node, name, defaultValue ); }

#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 default(T).</param>
		/// <returns>属性值.</returns>
		public T GetAttributeValue<T> ( string name = null, T defaultValue = default(T) )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public T GetAttributeValue<T> ( string name, T defaultValue )
#endif
		{ return GetAttributeValue<T> ( this.node, name, defaultValue ); }
		#endregion

		#region " FetchAttributeValue "
#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 null.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue ( ref object value, string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue ( ref object value, string name, object defaultValue )
#endif
		{ return FetchAttributeValue<object> ( ref value, this.node, name, defaultValue ); }

#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 default(T).</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue<T> ( ref T value, string name=null, T defaultValue = default(T) )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue<T> ( ref T value, string name, T defaultValue )
#endif
		{ return FetchAttributeValue<T> ( ref value, this.node, name, defaultValue ); }
		#endregion

		#region " FlushAttributeValue "
		/// <summary>
		/// 设置辅助类所表示 XmlNode 的 value 属性值. 
		/// </summary>
		/// <param name="value">属性值.</param>
		/// <returns>是否成功设置.</returns>
		public bool FlushAttributeValue ( object value )
		{
			// 无法使用 FlushAttributeValue ( this.node, value );
			return FlushAttributeValue ( this.node, value, null );
		}
		/// <summary>
		/// 设置辅助类所表示 XmlNode 的属性值. 
		/// </summary>
		/// <param name="value">属性值.</param>
		/// <param name="name">属性的名称, 默认为 "value".</param>
		/// <returns>是否成功设置.</returns>
		public bool FlushAttributeValue ( object value, string name )
		{ return FlushAttributeValue ( this.node, value, name ); }
		#endregion

		#region " Fetch(Get)NodeHelper(s) "
		/// <summary>
		/// 得到 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>搜索到子节点辅助类.</returns>
		public XmlNodeHelper<XmlNode> GetNodeHelper ( string xPath )
		{ return GetNodeHelper ( this.node, xPath ); }
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public bool FetchNodeHelper ( string xPath )
		{ return FetchNodeHelper ( this.node, xPath ); }
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelper">返回的子节点的辅助类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public bool FetchNodeHelper ( ref XmlNodeHelper<XmlNode> nodeHelper, string xPath )
		{
			bool isSuccess = FetchNodeHelper ( ref nodeHelper, this.node, xPath );

			this.fetchedNodeHelpers.Clear ( );
			this.fetchedNodeHelpers.Add ( nodeHelper );

			return isSuccess;
		}
		/// <summary>
		/// 得到 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>搜索到子节点辅助类.</returns>
		public List<XmlNodeHelper<XmlNode>> GetNodeHelpers ( string xPath )
		{ return GetNodeHelpers ( this.node, xPath ); }
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public bool FetchNodeHelpers ( string xPath )
		{return FetchNodeHelpers ( this.node, xPath ); }
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelpers">返回的子节点的辅助类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public bool FetchNodeHelpers ( ref List<XmlNodeHelper<XmlNode>> nodeHelpers, string xPath )
		{
			bool isSuccess = FetchNodeHelpers ( ref nodeHelpers, this.node, xPath );

			this.fetchedNodeHelpers.Clear ( );
			this.fetchedNodeHelpers.AddRange ( nodeHelpers.ToArray ( ) );

			return isSuccess;
		}
		#endregion

		#region " AppendNode "
		/// <summary>
		/// 添加 Xml 节点.
		/// </summary>
		/// <param name="childNodeHelper">添加节点的辅助类.</param>
		public void AppendNode ( XmlNodeHelper<XmlNode> childNodeHelper )
		{ /* AppendNode ( this, childNodeHelper ); */ }
		#endregion

	}

	partial class XmlNodeHelper<N>
	{
#if !PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNodeHelper<XmlNode> nodeHelper )
		{ return GetAttributeValue<object> ( nodeHelper, null, null ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNodeHelper<XmlNode> nodeHelper, object defaultValue )
		{ return GetAttributeValue<object> ( nodeHelper, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNodeHelper<XmlNode> nodeHelper, string name )
		{ return GetAttributeValue<object> ( nodeHelper, name, null ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNodeHelper<XmlNode> nodeHelper )
		{ return GetAttributeValue<T> ( nodeHelper, null, default ( T ) ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNodeHelper<XmlNode> nodeHelper, T defaultValue )
		{ return GetAttributeValue<T> ( nodeHelper, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNodeHelper<XmlNode> nodeHelper, string name )
		{ return GetAttributeValue<T> ( nodeHelper, name, default ( T ) ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNode node )
		{ return GetAttributeValue<object> ( node, null, null ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNode node, object defaultValue )
		{ return GetAttributeValue<object> ( node, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNode node, string name )
		{ return GetAttributeValue<object> ( node, name, null ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="node">XmlNode 类.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNode node )
		{ return GetAttributeValue<T> ( node, null, default ( T ) ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNode node, T defaultValue )
		{ return GetAttributeValue<T> (node,  null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNode node, string name )
		{ return GetAttributeValue<T> ( node, name, default ( T ) ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNode node )
		{ return FetchAttributeValue<T> ( ref value, node, null, default ( T ) ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNode node, T defaultValue )
		{ return FetchAttributeValue<T> ( ref value, node, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNode node, string name )
		{ return FetchAttributeValue<T> ( ref value, node, name, default ( T ) ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNode node )
		{ return FetchAttributeValue<object> ( ref value, node, null, null ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNode node, object defaultValue )
		{ return FetchAttributeValue<object> ( ref value, node, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNode node, string name )
		{ return FetchAttributeValue<object> ( ref value, node, name, null ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<XmlNode> nodeHelper )
		{ return FetchAttributeValue<T> ( ref value, nodeHelper, null, default ( T ) ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<XmlNode> nodeHelper, T defaultValue )
		{ return FetchAttributeValue<T> ( ref value, nodeHelper, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<XmlNode> nodeHelper, string name )
		{ return FetchAttributeValue<T> ( ref value, nodeHelper, name, default ( T ) ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<XmlNode> nodeHelper )
		{ return FetchAttributeValue<object> ( ref value, nodeHelper, null, null ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<XmlNode> nodeHelper, object defaultValue )
		{ return FetchAttributeValue<object> ( ref value, nodeHelper, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<XmlNode> nodeHelper, string name )
		{ return FetchAttributeValue<object> ( ref value, nodeHelper, name, null ); }

		/// <summary>
		/// 设置辅助类所表示 XmlNode 的 value 属性值. 
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="value">属性值.</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( XmlNode node, object value )
		{ return FlushAttributeValue ( node, value, null ); }

		/// <summary>
		/// 设置辅助类所表示 XmlNode 的 value 属性值. 
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="value">属性值.</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( XmlNodeHelper<XmlNode> nodeHelper, object value )
		{ return FlushAttributeValue ( nodeHelper, value, null ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <returns>属性值.</returns>
		public object GetAttributeValue ( )
		{ return GetAttributeValue<object> ( this.node ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public object GetAttributeValue ( object defaultValue )
		{ return GetAttributeValue<object> ( this.node, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public object GetAttributeValue ( string name )
		{ return GetAttributeValue<object> ( this.node, name ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <returns>属性值.</returns>
		public T GetAttributeValue<T> ( )
		{ return GetAttributeValue<T> ( this.node ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public T GetAttributeValue<T> ( T defaultValue )
		{ return GetAttributeValue<T> ( this.node, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public T GetAttributeValue<T> ( string name )
		{ return GetAttributeValue<T> ( this.node, name ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue ( ref object value )
		{ return FetchAttributeValue<object> ( ref value, this.node ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue ( ref object value, object defaultValue )
		{ return FetchAttributeValue<object> ( ref value, this.node, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue ( ref object value, string name )
		{ return FetchAttributeValue<object> ( ref value, this.node, name ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue<T> ( ref T value )
		{ return FetchAttributeValue<T> ( ref value, this.node ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue<T> ( ref T value, T defaultValue )
		{ return FetchAttributeValue<T> ( ref value, this.node, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public bool FetchAttributeValue<T> ( ref T value, string name )
		{ return FetchAttributeValue<T> ( ref value, this.node, name ); }
#endif
	}

}

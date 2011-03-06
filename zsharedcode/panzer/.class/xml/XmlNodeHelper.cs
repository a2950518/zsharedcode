using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

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

		#region " GetAttributeValue "
#if PARAM
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称, 默认为 "value".</param>
		/// <param name="defaultValue">属性默认值, 默认为 null.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNodeHelper<N> nodeHelper, string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNodeHelper<N> nodeHelper, string name, object defaultValue )
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
		public static T GetAttributeValue<T> ( XmlNodeHelper<N> nodeHelper, string name = null, T defaultValue = default(T) )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNodeHelper<N> nodeHelper, string name, T defaultValue )
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
		public static object GetAttributeValue ( N node, string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( N node, string name, object defaultValue )
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
		public static T GetAttributeValue<T> ( N node, string name = null, T defaultValue = default(T) )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( N node, string name, T defaultValue )
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
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<N> nodeHelper, string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<N> nodeHelper, string name, object defaultValue )
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
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<N> nodeHelper, string name = null, T defaultValue = default(T) )
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
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<N> nodeHelper, string name, T defaultValue )
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
		public static bool FetchAttributeValue ( ref object value, N node, string name = null, object defaultValue = null )
#else
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, N node, string name, object defaultValue )
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
		public static bool FetchAttributeValue<T> ( ref T value, N node, string name = null, T defaultValue = default(T) )
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
		public static bool FetchAttributeValue<T> ( ref T value, N node, string name, T defaultValue )
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
		public static bool FlushAttributeValue ( XmlNodeHelper<N> nodeHelper, object value, string name = null )
#else
		/// <summary>
		/// 设置辅助类所表示 XmlNode 的属性值. 
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="value">属性值.</param>
		/// <param name="name">属性的名称.</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( XmlNodeHelper<N> nodeHelper, object value, string name )
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
		public static bool FlushAttributeValue ( N node, object value, string name = null )
#else
		/// <summary>
		/// 设置辅助类所表示 XmlNode 的属性值. 
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="value">属性值.</param>
		/// <param name="name">属性的名称.</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( N node, object value, string name )
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
		public static XmlNodeHelper<N> GetNodeHelper ( XmlNodeHelper<N> beginNodeHelper, string xPath )
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
		public static XmlNodeHelper<N> GetNodeHelper ( N beginNode, string xPath )
		{
			XmlNodeHelper<N> nodeHelper = null;

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
		public static bool FetchNodeHelper ( ref XmlNodeHelper<N> nodeHelper, XmlNodeHelper<N> beginNodeHelper, string xPath )
		{
			if ( null == beginNodeHelper )
				return false;

			return FetchNodeHelper ( ref nodeHelper, beginNodeHelper.node, xPath );
		}
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelper">返回的子节点的辅助类.</param>
		/// <param name="beginNode">开始的 XmlNode 类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public static bool FetchNodeHelper ( ref XmlNodeHelper<N> nodeHelper, N beginNode, string xPath )
		{
			List<XmlNodeHelper<N>> nodeHelpers = GetNodeHelpers ( beginNode, xPath );

			if ( nodeHelpers.Count == 0 )
				return false;

			nodeHelper = nodeHelpers[0];
			return true;
		}

		/// <summary>
		/// 得到 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="beginNodeHelper">开始的 XmlNode 辅助类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>搜索到子节点辅助类.</returns>
		public static List<XmlNodeHelper<N>> GetNodeHelpers ( XmlNodeHelper<N> beginNodeHelper, string xPath )
		{

			if ( null == beginNodeHelper )
				return new List<XmlNodeHelper<N>> ( );

			return GetNodeHelpers ( beginNodeHelper.node, xPath );
		}
		/// <summary>
		/// 得到 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="beginNode">开始的 XmlNode 类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>搜索到子节点辅助类.</returns>
		public static List<XmlNodeHelper<N>> GetNodeHelpers ( N beginNode, string xPath )
		{
			List<XmlNodeHelper<N>> nodeHelpers = new List<XmlNodeHelper<N>> ( );

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
		public static bool FetchNodeHelpers ( ref List<XmlNodeHelper<N>> nodeHelpers, XmlNodeHelper<N> beginNodeHelper, string xPath )
		{

			if ( null == beginNodeHelper )
				return false;

			return FetchNodeHelpers ( ref nodeHelpers, beginNodeHelper.node, xPath );
		}
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelpers">返回的子节点的辅助类.</param>
		/// <param name="beginNode">开始的 XmlNode 类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public static bool FetchNodeHelpers ( ref List<XmlNodeHelper<N>> nodeHelpers, N beginNode, string xPath )
		{

			if ( null == nodeHelpers )
				nodeHelpers = new List<XmlNodeHelper<N>> ( );

			if ( null == beginNode || string.IsNullOrEmpty ( xPath ) )
				return false;

			try
			{

				foreach ( N node in beginNode.SelectNodes ( xPath ) )
					nodeHelpers.Add ( new XmlNodeHelper<N> ( node ) );

			}
			catch { }

			return nodeHelpers.Count != 0;
		}
		#endregion

		private readonly string name;
		protected N node;
		private readonly List<XmlNodeHelper<N>> childNodeHelpers = new List<XmlNodeHelper<N>> ( );

		private readonly SortedList<string, object> attributes = new SortedList<string, object> ( );

		/// <summary>
		/// 获取节点名称.
		/// </summary>
		public string Name
		{
			get { return this.name; }
		}

		/// <summary>
		/// 获取 XmlNode.
		/// </summary>
		public N Node
		{
			get { return this.node; }
		}

		/// <summary>
		/// 获取子节点的 XmlNodeHelper.
		/// </summary>
		public List<XmlNodeHelper<N>> ChildNodeHelpers
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

					foreach ( XmlNodeHelper<N> childNodeHelper in this.childNodeHelpers )
						if ( null != childNodeHelper )
							xml += childNodeHelper.OuterXml;

					xml += string.Format ( "</{0}>", this.name );
				}

				return xml;
			}
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
		public XmlNodeHelper ( string name, params XmlNodeHelper<N>[] childNodeHelpers )
		{

			if ( string.IsNullOrEmpty ( name ) )
				throw new ArgumentNullException ( "name", " 节点名称不能为空" );

			if ( null != childNodeHelpers )
				foreach ( XmlNodeHelper<N> childNodeHelper in childNodeHelpers )
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
		{ return FlushAttributeValue ( this.node, value ); }
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
		public XmlNodeHelper<N> GetNodeHelper ( string xPath )
		{ return GetNodeHelper ( this.node, xPath ); }
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelper">返回的子节点的辅助类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public bool FetchNodeHelper ( ref XmlNodeHelper<N> nodeHelper, string xPath )
		{ return FetchNodeHelper ( ref nodeHelper, this.node, xPath ); }
		/// <summary>
		/// 得到 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>搜索到子节点辅助类.</returns>
		public List<XmlNodeHelper<N>> GetNodeHelpers ( string xPath )
		{ return GetNodeHelpers ( this.node, xPath ); }
		/// <summary>
		/// 获取 XmlNode 的子节点的辅助类.
		/// </summary>
		/// <param name="nodeHelpers">返回的子节点的辅助类.</param>
		/// <param name="xPath">用于搜索的 xpath.</param>
		/// <returns>是否搜索到子节点.</returns>
		public bool FetchNodeHelpers ( ref List<XmlNodeHelper<N>> nodeHelpers, string xPath )
		{ return FetchNodeHelpers ( ref nodeHelpers, this.node, xPath ); }
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
		public static object GetAttributeValue ( XmlNodeHelper<N> nodeHelper )
		{ return GetAttributeValue<object> ( nodeHelper, null, null ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNodeHelper<N> nodeHelper, object defaultValue )
		{ return GetAttributeValue<object> ( nodeHelper, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( XmlNodeHelper<N> nodeHelper, string name )
		{ return GetAttributeValue<object> ( nodeHelper, name, null ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNodeHelper<N> nodeHelper )
		{ return GetAttributeValue<T> ( nodeHelper, null, default ( T ) ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNodeHelper<N> nodeHelper, T defaultValue )
		{ return GetAttributeValue<T> ( nodeHelper, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( XmlNodeHelper<N> nodeHelper, string name )
		{ return GetAttributeValue<T> ( nodeHelper, name, default ( T ) ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( N node )
		{ return GetAttributeValue<object> ( node, null, null ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( N node, object defaultValue )
		{ return GetAttributeValue<object> ( node, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public static object GetAttributeValue ( N node, string name )
		{ return GetAttributeValue<object> ( node, name, null ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="node">XmlNode 类.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( N node )
		{ return GetAttributeValue<T> ( node, null, default ( T ) ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( N node, T defaultValue )
		{ return GetAttributeValue<T> (node,  null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>属性值.</returns>
		public static T GetAttributeValue<T> ( N node, string name )
		{ return GetAttributeValue<T> ( node, name, default ( T ) ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, N node )
		{ return FetchAttributeValue<T> ( ref value, node, null, default ( T ) ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, N node, T defaultValue )
		{ return FetchAttributeValue<T> ( ref value, node, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, N node, string name )
		{ return FetchAttributeValue<T> ( ref value, node, name, default ( T ) ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, N node )
		{ return FetchAttributeValue<object> ( ref value, node, null, null ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, N node, object defaultValue )
		{ return FetchAttributeValue<object> ( ref value, node, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, N node, string name )
		{ return FetchAttributeValue<object> ( ref value, node, name, null ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<N> nodeHelper )
		{ return FetchAttributeValue<T> ( ref value, nodeHelper, null, default ( T ) ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<N> nodeHelper, T defaultValue )
		{ return FetchAttributeValue<T> ( ref value, nodeHelper, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <typeparam name="T">属性的类型.</typeparam>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue<T> ( ref T value, XmlNodeHelper<N> nodeHelper, string name )
		{ return FetchAttributeValue<T> ( ref value, nodeHelper, name, default ( T ) ); }

		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<N> nodeHelper )
		{ return FetchAttributeValue<object> ( ref value, nodeHelper, null, null ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的 value 属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="defaultValue">属性默认值.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<N> nodeHelper, object defaultValue )
		{ return FetchAttributeValue<object> ( ref value, nodeHelper, null, defaultValue ); }
		/// <summary>
		/// 得到辅助类所表示 XmlNode 的属性值.
		/// </summary>
		/// <param name="value">返回的属性值.</param>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="name">属性名称.</param>
		/// <returns>是否成功获取到 XmlNode 的属性.</returns>
		public static bool FetchAttributeValue ( ref object value, XmlNodeHelper<N> nodeHelper, string name )
		{ return FetchAttributeValue<object> ( ref value, nodeHelper, name, null ); }

		/// <summary>
		/// 设置辅助类所表示 XmlNode 的 value 属性值. 
		/// </summary>
		/// <param name="node">XmlNode 类.</param>
		/// <param name="value">属性值.</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( N node, object value )
		{ return FlushAttributeValue ( node, value, null ); }

		/// <summary>
		/// 设置辅助类所表示 XmlNode 的 value 属性值. 
		/// </summary>
		/// <param name="nodeHelper">XmlNode 辅助类.</param>
		/// <param name="value">属性值.</param>
		/// <returns>是否成功设置.</returns>
		public static bool FlushAttributeValue ( XmlNodeHelper<N> nodeHelper, object value )
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

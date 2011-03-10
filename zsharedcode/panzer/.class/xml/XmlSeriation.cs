/*
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/xml/XmlSeriation.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Reflection;

using zoyobar.shared.panzer;

namespace zoyobar.shared.panzer.xml
{

	/// <summary>
	/// Xml 序列化类, 可以从 Xml 文件创建对象, 之后可以将对象写回到 Xml 中.
	/// </summary>
	public sealed partial class XmlSeriation
	{

		private static XmlNode getNode ( string id, XmlDocumentHelper documentHelper, ValueKind valueKind )
		{

			if ( string.IsNullOrEmpty ( id ) )
				return null;

			string xPath = string.Empty;

			switch ( valueKind )
			{
				case ValueKind.None:
					xPath = string.Format ( "//*[@id='{0}']", id );
					break;
				default:
					xPath = string.Format ( "//*[@id='{0}' and @kind='{1}']", id, valueKind );
					break;
			}

			if ( !documentHelper.Navigate ( xPath ) )
				return null;

			return documentHelper.CurrentNode;
		}

		private static bool fetchQuoteNode ( ref XmlNode node, XmlDocumentHelper documentHelper, string quoteAttributeName )
		{

			if ( null == node )
				return false;

			if ( null == documentHelper )
				return true;

			if ( string.IsNullOrEmpty ( quoteAttributeName ) )
				quoteAttributeName = "quote";

			string quoteID = string.Empty;

			if ( !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref quoteID, node, quoteAttributeName ) )
				return true;

			string quoteSeriationID = string.Empty;

			if ( XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref quoteSeriationID, node, "quote-seriation" ) && XmlSeriationManager.IsExist ( quoteSeriationID ) )
				documentHelper = XmlSeriationManager.Seriations[quoteSeriationID].documentHelper;

			node = getNode ( quoteID, documentHelper, ValueKind.None );
			return ( null != node );
		}

		private static bool fetchAssemblyName ( ref string assemblyName, XmlNode node, XmlDocumentHelper documentHelper )
		{

			if ( !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref assemblyName, node, "assembly" ) && ( !fetchQuoteNode ( ref node, documentHelper, "type" ) || !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref assemblyName, node, "assembly" ) ) )
				return false;

			return true;
		}

		private static DirectionType getDirectionType ( XmlNode node )
		{

			if ( null == node )
				return DirectionType.None;

			string typeName = string.Empty;

			if ( !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref typeName, node, "direction" ) || !Enum.IsDefined ( typeof ( DirectionType ), typeName ) )
				return DirectionType.InputNOutput;

			return ( DirectionType ) Enum.Parse ( typeof ( DirectionType ), typeName, true );
		}

		private static ValueStamp getValueStamp ( XmlNode node )
		{

			if ( null == node )
				return ValueStamp.None;

			string stampName = string.Empty;

			if ( !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref stampName, node, "type" ) || !Enum.IsDefined ( typeof ( ValueStamp ), stampName ) )
				return ValueStamp.None;

			return ( ValueStamp ) Enum.Parse ( typeof ( ValueStamp ), stampName, true );
		}

		private static ValueKind getValueKind ( XmlNode node )
		{

			if ( null == node )
				return ValueKind.None;

			string kindName = string.Empty;

			if ( !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref kindName, node, "kind" ) || !Enum.IsDefined ( typeof ( ValueKind ), kindName ) )
				return ValueKind.None;

			return ( ValueKind ) Enum.Parse ( typeof ( ValueKind ), kindName, true );
		}

#if PARAM
		/// <summary>
		/// 创建一个枚举值.
		/// </summary>
		/// <typeparam name="T">枚举的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>枚举值.</returns>
		public static T CreateEnum<T> ( XmlNodeHelper<XmlNode> nodeHelper, XmlDocumentHelper documentHelper = null )
#else
		/// <summary>
		/// 创建一个枚举值.
		/// </summary>
		/// <typeparam name="T">枚举的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>枚举值.</returns>
		public static T CreateEnum<T> ( XmlNodeHelper<XmlNode> nodeHelper, XmlDocumentHelper documentHelper )
#endif
		{

			if ( null == nodeHelper )
				return default ( T );

			return CreateEnum<T> ( nodeHelper.Node, documentHelper );
		}

#if PARAM
		/// <summary>
		/// 创建一个枚举值.
		/// </summary>
		/// <typeparam name="T">枚举的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>枚举值.</returns>
		public static T CreateEnum<T> ( XmlNode node, XmlDocumentHelper documentHelper = null )
#else
		/// <summary>
		/// 创建一个枚举值.
		/// </summary>
		/// <typeparam name="T">枚举的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>枚举值.</returns>
		public static T CreateEnum<T> ( XmlNode node, XmlDocumentHelper documentHelper )
#endif
		{

			if ( null == node )
				return default ( T );

			fetchQuoteNode ( ref node, documentHelper, null );

			string assemblyName = string.Empty;
			string value = string.Empty;

			if ( !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref value, node ) || !fetchAssemblyName ( ref assemblyName, node, documentHelper ) )
				return default ( T );

			Type type = Type.GetType ( assemblyName, false, true );

			if ( null == type )
				return default ( T );

			try
			{ return ( T ) Enum.Parse ( type, value, true ); }
			catch
			{ return default ( T ); }

		}

#if PARAM
		/// <summary>
		/// 创建一个结构.
		/// </summary>
		/// <typeparam name="T">结构的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>结构.</returns>
		public static T CreateStructure<T> ( XmlNodeHelper<XmlNode> nodeHelper, XmlDocumentHelper documentHelper = null )
#else
		/// <summary>
		/// 创建一个结构.
		/// </summary>
		/// <typeparam name="T">结构的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>结构.</returns>
		public static T CreateStructure<T> ( XmlNodeHelper<XmlNode> nodeHelper, XmlDocumentHelper documentHelper )
#endif
		{

			if ( null == nodeHelper )
				return default ( T );

			return CreateStructure<T> ( nodeHelper.Node, documentHelper );
		}

#if PARAM
		/// <summary>
		/// 创建一个结构.
		/// </summary>
		/// <typeparam name="T">结构的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>结构.</returns>
		public static T CreateStructure<T> ( XmlNode node, XmlDocumentHelper documentHelper = null )
#else
		/// <summary>
		/// 创建一个结构.
		/// </summary>
		/// <typeparam name="T">结构的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>结构.</returns>
		public static T CreateStructure<T> ( XmlNode node, XmlDocumentHelper documentHelper )
#endif
		{
			fetchQuoteNode ( ref node, documentHelper, null );

			object value = null;

			switch ( getValueStamp ( node ) )
			{
				case ValueStamp.String:
					value = XmlNodeHelper<XmlNode>.GetAttributeValue<string> ( node );
					break;

				case ValueStamp.Integer:
					value = XmlNodeHelper<XmlNode>.GetAttributeValue<int> ( node );
					break;

				case ValueStamp.Short:
					value = XmlNodeHelper<XmlNode>.GetAttributeValue<short> ( node );
					break;

				case ValueStamp.Boolean:
					value = XmlNodeHelper<XmlNode>.GetAttributeValue<bool> ( node );
					break;

				case ValueStamp.Decimal:
					value = XmlNodeHelper<XmlNode>.GetAttributeValue<decimal> ( node );
					break;

				case ValueStamp.Guid:
					value = XmlNodeHelper<XmlNode>.GetAttributeValue<Guid> ( node );
					break;

				case ValueStamp.Color:
					value = XmlNodeHelper<XmlNode>.GetAttributeValue<Color> ( node );
					break;

				case ValueStamp.Single:
					value = XmlNodeHelper<XmlNode>.GetAttributeValue<float> ( node );
					break;

				case ValueStamp.Double:
					value = XmlNodeHelper<XmlNode>.GetAttributeValue<double> ( node );
					break;
			}

			try
			{ return ( T ) value; }
			catch
			{ return default ( T ); }

		}

		private static object[] getIndexs ( XmlNode node )
		{

			if ( null == node )
				return null;

			List<object> indexs = new List<object> ( );

			foreach ( XmlNode indexNode in node.SelectNodes ( "child::index" ) )
				indexs.Add ( CreateObject<object> ( indexNode ) );

			if ( indexs.Count == 0 )
				return null;

			return indexs.ToArray ( );
		}

		private static object[] getParameters ( XmlNode node, XmlDocumentHelper documentHelper )
		{

			if ( null == node )
				return new object[] { };

			List<object> parameters = new List<object> ( );

			foreach ( XmlNode parameterNode in node.SelectNodes ( "child::param" ) )
				parameters.Add ( CreateObject<object> ( parameterNode, documentHelper ) );

			return parameters.ToArray ( );
		}

		private static XmlNodeList getAttributeNodes ( XmlNode node )
		{

			if ( null == node )
				return null;

			return node.SelectNodes ( "child::attr" );
		}

#if PARAM
		/// <summary>
		/// 创建一个类.
		/// </summary>
		/// <typeparam name="T">类的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>类.</returns>
		public static T CreateClass<T> ( XmlNodeHelper<XmlNode> nodeHelper, XmlDocumentHelper documentHelper = null )
#else
		/// <summary>
		/// 创建一个类.
		/// </summary>
		/// <typeparam name="T">类的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>类.</returns>
		public static T CreateClass<T> ( XmlNodeHelper<XmlNode> nodeHelper, XmlDocumentHelper documentHelper )
#endif
		{

			if ( null == nodeHelper )
				return default ( T );

			return CreateClass<T> ( nodeHelper.Node, documentHelper );
		}

#if PARAM
		/// <summary>
		/// 创建一个类.
		/// </summary>
		/// <typeparam name="T">类的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>类.</returns>
		public static T CreateClass<T> ( XmlNode node, XmlDocumentHelper documentHelper = null )
#else
		/// <summary>
		/// 创建一个类.
		/// </summary>
		/// <typeparam name="T">类的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>类.</returns>
		public static T CreateClass<T> ( XmlNode node, XmlDocumentHelper documentHelper )
#endif
		{

			if ( null == node )
				return default ( T );

			fetchQuoteNode ( ref  node, documentHelper, null );

			string assemblyName = string.Empty;

			if ( !fetchAssemblyName ( ref assemblyName, node, documentHelper ) )
				return default ( T );

			Type type = Type.GetType ( assemblyName, false, true );

			if ( null == type )
				return default ( T );

			T o = default ( T );

			try
			{ o = ( T ) Assembly.GetAssembly ( type ).CreateInstance ( type.FullName, true, BindingFlags.CreateInstance, null, getParameters ( node, documentHelper ), null, null ); }
			catch
			{ return o; }

			string name = string.Empty;

			foreach ( XmlNode attributeNode in getAttributeNodes ( node ) )
			{
				XmlNode quoteAttributeNode = attributeNode;

				fetchQuoteNode ( ref quoteAttributeNode, documentHelper, null );

#if V4
				if ( !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref name, quoteAttributeNode, "name" ) || !getDirectionType ( attributeNode ).HasFlag ( DirectionType.Output ) )
#else
				if ( !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref name, quoteAttributeNode, "name" ) || ( getDirectionType ( attributeNode ) & DirectionType.Output ) != DirectionType.Output )
#endif

					continue;

				try
				{
					PropertyInfo propertyInfo = type.GetProperty ( name );

					if ( null != propertyInfo )
						propertyInfo.SetValue ( o, CreateClass<object> ( attributeNode, documentHelper ), getIndexs ( attributeNode ) );

				}
				catch { }

			}

			foreach ( XmlNode callNode in node.SelectNodes ( "child::call" ) )
			{
				XmlNode quoteCallNode = callNode;

				fetchQuoteNode ( ref quoteCallNode, documentHelper, null );

				if ( !XmlNodeHelper<XmlNode>.FetchAttributeValue<string> ( ref name, callNode, "name" ) )
					continue;

				try
				{
					MethodInfo methodInfo = type.GetMethod ( name );

					if ( null != methodInfo )
						methodInfo.Invoke ( o, getParameters ( callNode, documentHelper ) ); 

				}
				catch { }

			}

			return o;
		}

#if PARAM
		/// <summary>
		/// 创建一个对象.
		/// </summary>
		/// <typeparam name="T">对象的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>对象.</returns>
		public static T CreateObject<T> ( XmlNodeHelper<XmlNode> nodeHelper, XmlDocumentHelper documentHelper = null )
#else
		/// <summary>
		/// 创建一个对象.
		/// </summary>
		/// <typeparam name="T">对象的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>对象.</returns>
		public static T CreateObject<T> ( XmlNodeHelper<XmlNode> nodeHelper, XmlDocumentHelper documentHelper )
#endif
		{

			if ( null == nodeHelper )
				return default ( T );

			return CreateObject<T> ( nodeHelper.Node, documentHelper );
		}

#if PARAM
		/// <summary>
		/// 创建一个对象.
		/// </summary>
		/// <typeparam name="T">对象的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>对象.</returns>
		public static T CreateObject<T> ( XmlNode node, XmlDocumentHelper documentHelper = null )
#else
		/// <summary>
		/// 创建一个对象.
		/// </summary>
		/// <typeparam name="T">对象的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <param name="documentHelper">XmlDocument 辅助类.</param>
		/// <returns>对象.</returns>
		public static T CreateObject<T> ( XmlNode node, XmlDocumentHelper documentHelper )
#endif
		{
			fetchQuoteNode ( ref node, documentHelper, null );

			switch ( getValueKind ( node ) )
			{
				case ValueKind.Structure:
					return CreateStructure<T> ( node, documentHelper );

				case ValueKind.Enum:
					return CreateEnum<T> ( node, documentHelper );

				case ValueKind.Class:
					return CreateClass<T> ( node, documentHelper );

				case ValueKind.None:
				default:
					return default ( T );
			}

		}

		private readonly XmlDocumentHelper documentHelper;
		private readonly string id;

		/// <summary>
		/// 获取 Xml 序列化类的 ID.
		/// </summary>
		public string ID
		{
			get { return this.id; }
		}

		/// <summary>
		/// 获取 Xml 序列化类 ID 是否为空.
		/// </summary>
		public bool IsIDNull
		{
			get { return string.IsNullOrEmpty ( this.id ); }
		}

		/// <summary>
		/// 创建一个 Xml 序列化类.
		/// </summary>
		/// <param name="filePath">Xml 文件路径.</param>
		public XmlSeriation ( string filePath )
		{
			this.documentHelper = new XmlDocumentHelper ( filePath );

			if ( this.documentHelper.FetchNodeHelper ( "child::[@id='K.ID']" ) )
				this.id = this.documentHelper.FetchedNodeHelpers[0].GetAttributeValue<string> ( "value" );

			string folderPath = Path.GetDirectoryName ( this.documentHelper.FilePath );

			if ( this.documentHelper.FetchNodeHelpers ( "//imports/import" ) )
				foreach ( XmlNodeHelper<XmlNode> fetchedNode in this.documentHelper.FetchedNodeHelpers )
					XmlSeriationManager.Open ( Path.Combine ( folderPath, fetchedNode.GetAttributeValue<string> ( "path" ) ) );

		}

		/// <summary>
		/// 创建一个结构.
		/// </summary>
		/// <param name="id">Xml 节点的 id 属性, 将从此节点创建值.</param>
		/// <returns>结构.</returns>
		public object CreateStructure ( string id )
		{ return this.CreateStructure<object> ( id ); }
		/// <summary>
		/// 创建一个结构.
		/// </summary>
		/// <typeparam name="T">结构的类型.</typeparam>
		/// <param name="id">Xml 节点的 id 属性, 将从此节点创建值.</param>
		/// <returns>结构.</returns>
		public T CreateStructure<T> ( string id )
		{ return CreateStructure<T> ( getNode ( id, this.documentHelper, ValueKind.Structure ), this.documentHelper ); }

		/// <summary>
		/// 创建一个枚举.
		/// </summary>
		/// <param name="id">Xml 节点的 id 属性, 将从此节点创建值.</param>
		/// <returns>枚举.</returns>
		public object CreateEnum ( string id )
		{ return this.CreateEnum<object> ( id ); }
		/// <summary>
		/// 创建一个枚举.
		/// </summary>
		/// <typeparam name="T">枚举的类型.</typeparam>
		/// <param name="id">Xml 节点的 id 属性, 将从此节点创建值.</param>
		/// <returns>枚举.</returns>
		public T CreateEnum<T> ( string id )
		{ return CreateEnum<T> ( getNode ( id, this.documentHelper, ValueKind.Enum ), this.documentHelper ); }

		/// <summary>
		/// 创建一个类.
		/// </summary>
		/// <param name="id">Xml 节点的 id 属性, 将从此节点创建值.</param>
		/// <returns>类.</returns>
		public object CreateClass ( string id )
		{ return this.CreateClass<object> ( id ); }
		/// <summary>
		/// 创建一个类.
		/// </summary>
		/// <typeparam name="T">类的类型.</typeparam>
		/// <param name="id">Xml 节点的 id 属性, 将从此节点创建值.</param>
		/// <returns>类.</returns>
		public T CreateClass<T> ( string id )
		{ return CreateClass<T> ( getNode ( id, this.documentHelper, ValueKind.Class ), this.documentHelper ); }

		/// <summary>
		/// 创建一个对象.
		/// </summary>
		/// <param name="id">Xml 节点的 id 属性, 将从此节点创建值.</param>
		/// <returns>对象.</returns>
		public object CreateObject ( string id )
		{ return this.CreateObject<object> ( id ); }
		/// <summary>
		/// 创建一个对象.
		/// </summary>
		/// <typeparam name="T">对象的类型.</typeparam>
		/// <param name="id">Xml 节点的 id 属性, 将从此节点创建值.</param>
		/// <returns>对象.</returns>
		public T CreateObject<T> ( string id )
		{ return CreateObject<T> ( getNode ( id, this.documentHelper, ValueKind.None ), this.documentHelper ); }

	}

	partial class XmlSeriation
	{
#if !PARAM
		/// <summary>
		/// 创建一个枚举值.
		/// </summary>
		/// <typeparam name="T">枚举的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <returns>枚举值.</returns>
		public static T CreateEnum<T> ( XmlNodeHelper<XmlNode> nodeHelper )
		{ return CreateEnum<T> ( nodeHelper, null ); }
		/// <summary>
		/// 创建一个枚举值.
		/// </summary>
		/// <typeparam name="T">枚举的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <returns>枚举值.</returns>
		public static T CreateEnum<T> ( XmlNode node )
		{ return CreateEnum<T> ( node, null ); }

		/// <summary>
		/// 创建一个结构.
		/// </summary>
		/// <typeparam name="T">结构的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <returns>结构.</returns>
		public static T CreateStructure<T> ( XmlNodeHelper<XmlNode> nodeHelper )
		{ return CreateStructure<T> ( nodeHelper, null ); }
		/// <summary>
		/// 创建一个结构.
		/// </summary>
		/// <typeparam name="T">结构的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <returns>结构.</returns>
		public static T CreateStructure<T> ( XmlNode node )
		{ return CreateStructure<T> ( node, null ); }

		/// <summary>
		/// 创建一个类.
		/// </summary>
		/// <typeparam name="T">类的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <returns>类.</returns>
		public static T CreateClass<T> ( XmlNodeHelper<XmlNode> nodeHelper )
		{ return CreateClass<T> ( nodeHelper, null ); }
		/// <summary>
		/// 创建一个类.
		/// </summary>
		/// <typeparam name="T">类的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <returns>类.</returns>
		public static T CreateClass<T> ( XmlNode node )
		{ return CreateClass<T> ( node ); }

		/// <summary>
		/// 创建一个对象.
		/// </summary>
		/// <typeparam name="T">对象的类型.</typeparam>
		/// <param name="nodeHelper">Xml 节点辅助类, 将从此节点创建值.</param>
		/// <returns>对象.</returns>
		public static T CreateObject<T> ( XmlNodeHelper<XmlNode> nodeHelper )
		{ return CreateObject<T> ( nodeHelper, null ); }
		/// <summary>
		/// 创建一个对象.
		/// </summary>
		/// <typeparam name="T">对象的类型.</typeparam>
		/// <param name="node">Xml 节点, 将从此节点创建值.</param>
		/// <returns>对象.</returns>
		public static T CreateObject<T> ( XmlNode node )
		{ return CreateObject<T> ( node, null ); }
#endif
	}

}

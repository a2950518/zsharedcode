/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ViewStateHelper.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// 视图状态辅助类.
	/// </summary>
	public sealed class ViewStateHelper
		: IStateManager
	{
		private readonly Control control;
		private string storeProperty;

		/// <summary>
		/// 获取或设置存储的属性列表, 多个属性可用 ; 号分割, 比如: "Student.Name;Student.Age".
		/// </summary>
		public string StoreProperty
		{
			get { return this.storeProperty; }
			set { this.storeProperty = value; }
		}

		/// <summary>
		/// 创建一个视图状态辅助类.
		/// </summary>
		/// <param name="control">需要保存属性的控件.</param>
		public ViewStateHelper ( Control control )
		{

			if ( null == control )
				throw new ArgumentNullException ( "control", "控件不能为空" );

			this.control = control;
		}

		private object getPropertyValue ( string expression )
		{

			if ( expression == string.Empty )
				return null;

			object current = this.control;

			foreach ( string part in expression.Split ( '.' ) )
			{
				PropertyInfo property = current.GetType ( ).GetProperty ( part );

				if ( null == property )
					return string.Empty;

				current = property.GetValue ( current, null );
			}

			return current;
		}

		private void setPropertyValue ( string expression, object value )
		{

			if ( expression == string.Empty )
				return;

			object current = this.control;
			string[] parts = expression.Split ( '.' );

			for ( int index = 0; index < parts.Length; index++ )
			{
				PropertyInfo property = current.GetType ( ).GetProperty ( parts[index] );

				if ( null == property )
					break;

				if ( index == parts.Length - 1 )
					property.SetValue ( current, value, null );
				else
					current = property.GetValue ( current, null );

			}

		}

		bool IStateManager.IsTrackingViewState
		{
			get { return false; }
		}

		void IStateManager.LoadViewState ( object state )
		{

			if ( string.IsNullOrEmpty ( this.storeProperty ) )
				return;

			SortedList<string, object> states = state as SortedList<string, object>;

			if ( null == states )
				return;

			foreach ( string expression in this.storeProperty.Split ( ';' ) )
				if ( states.ContainsKey ( expression ) )
					this.setPropertyValue ( expression, states[expression] );

		}

		object IStateManager.SaveViewState ( )
		{
			SortedList<string, object> states = new SortedList<string, object> ( );

			if ( !string.IsNullOrEmpty ( this.storeProperty ) )
				foreach ( string expression in this.storeProperty.Split ( ';' ) )
					if ( !states.ContainsKey ( expression ) )
						states.Add ( expression, this.getPropertyValue ( expression ) );

			return states;
		}

		void IStateManager.TrackViewState ( )
		{ }
	}

}

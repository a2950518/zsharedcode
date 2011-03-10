using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace zoyobar.shared.panzer.ui
{

	public sealed class UILoader
	{

		/// <summary>
		/// ListBox 控件的相关设置.
		/// </summary>
		public sealed partial class ListBoxSetting
		{
			/// <summary>
			/// ListBox 控件.
			/// </summary>
			public readonly Control ListBox;

			/// <summary>
			/// 保存 ListBox 数据的 DataTable.
			/// </summary>
			public readonly DataTable Table;

			/// <summary>
			/// 存储 ListBox 条目文本属性的字段名.
			/// </summary>
			public readonly string TextColumnName;

			/// <summary>
			/// 存储 ListBox 数据的 XML 文件路径.
			/// </summary>
			public readonly string XmlFilePath;

#if PARAM
			/// <summary>
			/// 创建 ListBoxSetting.
			/// </summary>
			/// <param name="listBox">ListBox 控件.</param>
			/// <param name="table">保存 ListBox 数据的 DataTable, 如果为 null, 则自动创建.</param>
			/// <param name="textColumnName">存储 ListBox 条目文本属性的字段名, 可以为 null, 默认 "Text".</param>
			/// <param name="xmlFilePath">存储 ListBox 数据的 XML 文件路径, 可以为 null, 默认以 ListBox.Name 命名.</param>
			public ListBoxSetting ( Control listBox, DataTable table, string textColumnName, string xmlFilePath = null )
#else
			/// <summary>
			/// 创建 ListBoxSetting.
			/// </summary>
			/// <param name="listBox">ListBox 控件.</param>
			/// <param name="table">保存 ListBox 数据的 DataTable, 如果为 null, 则自动创建.</param>
			/// <param name="textColumnName">存储 ListBox 条目文本属性的字段名, 可以为 null, 默认 "Text".</param>
			/// <param name="xmlFilePath">存储 ListBox 数据的 XML 文件路径, 可以为 null, 默认以 ListBox.Name 命名.</param>
			public ListBoxSetting(Control listBox, DataTable table, string textColumnName, string xmlFilePath)
#endif
			{

				if ( null == listBox )
					throw new ArgumentNullException ( "listBox", "ListBox 不能为空" );

				if ( null == table )
					table = new DataTable ( listBox.Name );

				if ( string.IsNullOrEmpty ( textColumnName ) )
					textColumnName = "Text";

				if ( !table.Columns.Contains ( textColumnName ) )
					table.Columns.Add ( textColumnName );

				if ( string.IsNullOrEmpty ( xmlFilePath ) )
					xmlFilePath = string.Format ( "{0}.xml", listBox.Name );

			}

		}

		//private readonly Form window;

		private readonly List<Control> listBoxes = new List<Control> ( );

		public UILoader ( Form window )
		{

			if ( null == window )
				throw new ArgumentNullException ( "window", "窗口不能为空" );

			window.Load += new EventHandler ( this.onWindowLoad );
			window.FormClosed += new FormClosedEventHandler ( this.onWindowClosed );
		}

		private void onWindowLoad ( object sender, EventArgs e )
		{
		}

		private void onWindowClosed ( object sender, FormClosedEventArgs e )
		{
		}

		partial class ListBoxSetting
		{
	#if !PARAM
				/// <summary>
				/// 创建 ListBoxSetting.
				/// </summary>
				/// <param name="listBox">ListBox 控件.</param>
				/// <param name="table">保存 ListBox 数据的 DataTable, 如果为 null, 则自动创建.</param>
				/// <param name="textColumnName">存储 ListBox 条目文本属性的字段名, 可以为 null, 默认 "Text".</param>
				public ListBoxSetting ( Control listBox, DataTable table, string textColumnName )
					: this ( listBox, table, textColumnName, null )
				{ }
	#endif
		}

	}

}

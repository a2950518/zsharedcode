/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryScript.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using zoyobar.shared.panzer.ui.jqueryui.plusin.jqplot;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	#region " ResourceAttribute "
	/// <summary>
	/// 描述所需要的资源.
	/// </summary>
	[AttributeUsage ( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
	public class ResourceAttribute
		: Attribute
	{
		private bool isOnce = true;
		private string singleScript;
		private string multipleScript;
		private string singleStyle;

		/// <summary>
		/// 获取或设置是否只检查一次, 遇到重复的实例不再检查, 默认为 true.
		/// </summary>
		public bool IsOnce
		{
			get { return this.isOnce; }
			set { this.isOnce = value; }
		}

		/// <summary>
		/// 获取或设置单一脚本的关键字, 用分号分隔, 关键字应该包含在 web.config 中.
		/// </summary>
		public string SingleScript
		{
			get { return this.singleScript; }
			set { this.singleScript = value; }
		}

		/// <summary>
		/// 获取或设置分布式脚本的关键字, 用分号分隔, 关键字应该包含在 web.config 中.
		/// </summary>
		public string MultipleScript
		{
			get { return this.multipleScript; }
			set { this.multipleScript = value; }
		}

		/// <summary>
		/// 获取或设置样式的关键字, 关键字应该包含在 web.config 中.
		/// </summary>
		public string SingleStyle
		{
			get { return this.singleStyle; }
			set { this.singleStyle = value; }
		}

	}
	#endregion

	#region " ResourceLoader "
	/// <summary>
	/// 载入页面所需要的脚本.
	/// </summary>
	[ToolboxData ( "<{0}:ResourceLoader runat=server></{0}:ResourceLoader>" )]
	[ParseChildren ( true )]
	public class ResourceLoader
		: Control, INamingContainer
	{
		private readonly Dictionary<string, bool> scripts = new Dictionary<string, bool> ( );
		private readonly Dictionary<string, bool> styles = new Dictionary<string, bool> ( );

		private bool jquery = false;
		private bool jqueryUI = false;
		private bool jqPlot = false;

		private bool jqPlotDateAxisRenderer = false;

		/// <summary>
		/// 获取或设置是否载入 jQuery 所需的脚本和样式.
		/// </summary>
		public bool JQuery
		{
			get { return this.jquery; }
			set { this.jquery = value; }
		}

		/// <summary>
		/// 获取或设置是否载入 jQuery UI 所需的脚本和样式, 默认为 false, 如果为 true, 则 JQuery 将无效.
		/// </summary>
		public bool JQueryUI
		{
			get { return this.jqueryUI; }
			set { this.jqueryUI = value; }
		}

		/// <summary>
		/// 获取或设置是否载入 jqplot 所需的脚本和样式, 默认为 false, 如果为 true, 则 JQueryUI 和 JQuery 将无效.
		/// </summary>
		public bool JQPlot
		{
			get { return this.jqPlot; }
			set { this.jqPlot = value; }
		}

		/// <summary>
		/// 获取或设置是否载入 jqplot 日期轴插件所需的脚本, 默认为 false.
		/// </summary>
		public bool JQPlotDateAxisRenderer
		{
			get { return this.jqPlotDateAxisRenderer; }
			set { this.jqPlotDateAxisRenderer = value; }
		}

		/// <summary>
		/// 创建载入页面所需要的脚本的实例.
		/// </summary>
		public ResourceLoader ( )
		{
			this.styles.Add ( "je.jquery.ui.css", false );
			this.styles.Add ( "je.jqplot.css", false );

			this.scripts.Add ( "je.jquery.js", false );
			this.scripts.Add ( "je.jquery.ui.js", false );
			this.scripts.Add ( "je.jqplot.excanvas.js", false );
			this.scripts.Add ( "je.jqplot.js", false );
		}

		/// <summary>
		/// 追加所需的脚本.
		/// </summary>
		/// <param name="key">脚本的关键字, 关键字应该包含在 web.config 中.</param>
		public void AppendScript ( string key )
		{

			if ( string.IsNullOrEmpty ( key ) )
				return;

			if ( this.scripts.ContainsKey ( key ) )
				this.scripts[key] = true;
			else
				this.scripts.Add ( key, true );

		}

		/// <summary>
		/// 追加所需的样式.
		/// </summary>
		/// <param name="key">样式的关键字, 关键字应该包含在 web.config 中.</param>
		public void AppendStyle ( string key )
		{

			if ( string.IsNullOrEmpty ( key ) )
				return;

			if ( this.styles.ContainsKey ( key ) )
				this.styles[key] = true;
			else
				this.styles.Add ( key, true );

		}

		private bool checkResource ( string keyList )
		{

			if ( string.IsNullOrEmpty ( keyList ) )
				return false;

			foreach ( string key in keyList.Split ( ';' ) )
				if ( !string.IsNullOrEmpty ( key ) && string.IsNullOrEmpty ( WebConfigurationManager.AppSettings[key] ) )
					return false;

			return true;
		}

		private void checkControl ( Control control, List<string> types )
		{
			//! No need to check scripts and styles parameters

			if ( null == control )
				return;

			Type type = control.GetType ( );
			object[] attributes = type.GetCustomAttributes ( typeof ( ResourceAttribute ), true );

			if ( attributes.Length > 0 )
			{
				ResourceAttribute resourceAttribute = attributes[0] as ResourceAttribute;

				//! Variable resourceAttribute can't be null

				if ( !resourceAttribute.IsOnce || !types.Contains ( type.FullName ) )
				{

					if ( !types.Contains ( type.FullName ) )
						types.Add ( type.FullName );

					foreach ( string part in resourceAttribute.SingleStyle.Split ( ';' ) )
						this.AppendStyle ( part );

					if ( this.checkResource ( resourceAttribute.MultipleScript ) )
						foreach ( string part in resourceAttribute.MultipleScript.Split ( ';' ) )
							this.AppendScript ( part );
					else
						foreach ( string part in resourceAttribute.SingleScript.Split ( ';' ) )
							this.AppendScript ( part );

				}

			}

			if ( control.HasControls ( ) )
				foreach ( Control childControl in control.Controls )
					this.checkControl ( childControl, types );

		}

		protected override void CreateChildControls ( )
		{

			if ( null == this.Page || null == this.Page.Header )
			{
				base.CreateChildControls ( );
				return;
			}

			List<string> types = new List<string> ( );

			this.checkControl ( this.Page, types );

			if ( this.jqPlot )
			{
				this.AppendScript ( "je.jquery.js" );
				this.AppendScript ( "je.jquery.ui.js" );
				this.AppendScript ( "je.jqplot.excanvas.js" );
				this.AppendScript ( "je.jqplot.js" );

				this.AppendStyle ( "je.jquery.ui.css" );
				this.AppendStyle ( "je.jqplot.css" );
			}
			else if ( this.jqueryUI )
			{
				this.AppendScript ( "je.jquery.js" );
				this.AppendScript ( "je.jquery.ui.js" );

				this.AppendStyle ( "je.jquery.ui.css" );
			}
			else if ( this.jquery )
				this.AppendScript ( "je.jquery.js" );

			if ( this.jqPlotDateAxisRenderer )
				this.AppendScript ( "je.jqplot.DateAxisRenderer.js" );

			foreach ( KeyValuePair<string, bool> style in this.styles )
				if ( style.Value )
				{
					string url = WebConfigurationManager.AppSettings[style.Key];

					if ( string.IsNullOrEmpty ( url ) )
						return;

					HtmlGenericControl tag = new HtmlGenericControl ( "link" );
					tag.Attributes["type"] = "text/css";
					tag.Attributes["rel"] = "stylesheet";

					try
					{ tag.Attributes["href"] = this.ResolveClientUrl ( url ); }
					catch { }

					this.Page.Header.Controls.Add ( tag );
				}

			foreach ( KeyValuePair<string, bool> script in this.scripts )
				if ( script.Value )
				{
					string url = WebConfigurationManager.AppSettings[script.Key];

					if ( string.IsNullOrEmpty ( url ) )
						return;

					HtmlGenericControl tag = new HtmlGenericControl ( "script" );
					tag.Attributes["type"] = "text/javascript";

					try
					{ tag.Attributes["src"] = this.ResolveClientUrl ( url ); }
					catch { }

					this.Page.Header.Controls.Add ( tag );
				}

		}

	}
	#endregion

}

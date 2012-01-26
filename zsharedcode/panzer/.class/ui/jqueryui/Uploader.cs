/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Uploader.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.web.jqueryui;
using zoyobar.shared.panzer.web.jqueryui.plusin;

using NParameter = zoyobar.shared.panzer.web.jqueryui.Parameter;

namespace zoyobar.shared.panzer.ui.jqueryui.plusin
{

	/// <summary>
	/// 自定义上传插件.
	/// </summary>
	[ToolboxData ( "<{0}:Uploader runat=server></{0}:Uploader>" )]
	public partial class Uploader
		: JQueryPlusin<UploaderSetting>
	{

		#region " class: UploadInfo "
		/// <summary>
		/// 上传的信息.
		/// </summary>
		public class UploadInfo
		{
			private int contentLength = 0;
			private int postedLength = 0;
			private decimal percent = 0;

			/// <summary>
			/// 获取或设置文件总长度, 小于 0 则默认为 0.
			/// </summary>
			public int ContentLength
			{
				get { return this.contentLength; }
				set
				{

					if ( value < 0 )
						value = 0;

					this.contentLength = value;
				}
			}

			/// <summary>
			/// 获取或设置已经上传的长度, 小于 0 则默认为 0.
			/// </summary>
			public int PostedLength
			{
				get { return this.postedLength; }
				set
				{

					if ( value < 0 )
						value = 0;

					if ( value == 0 || value >= this.contentLength )
						this.percent = 100;
					else
					{
						this.percent = decimal.Round ( ( ( decimal ) value / ( decimal ) this.contentLength ) * 100, 2 );

						if ( this.percent >= 100 )
							this.percent = 99.99M;

					}

					this.postedLength = value;
				}
			}

			/// <summary>
			/// 获取上传百分比.
			/// </summary>
			public decimal Percent
			{
				get { return this.percent; }
			}

			/// <summary>
			/// 创建一个上传信息.
			/// </summary>
			public UploadInfo ( )
			{ }

		}
		#endregion

		#region " static "
#if PARAM
		/// <summary>
		/// 保存上传的文件.
		/// </summary>
		/// <param name="filePath">文件的保存位置, 需要一个绝对路径.</param>
		/// <param name="postedFile">上传的文件, 可以从表单或者控件获得.</param>
		/// <param name="uploadInfo">包含文件上传进度信息的类.</param>
		/// <param name="bufferSize">保存文件时的缓存大小, 以 kb 为单位, 如果小于 0, 则改为 128 kb, 默认为 0.</param>
		/// <param name="waitSecond">每次包含字节时的等待秒数, 只用于调试时使用, 默认为 0.</param>
		public static void Save ( string filePath, HttpPostedFile postedFile, UploadInfo uploadInfo, int bufferSize = 0, int waitSecond = 0 )
#else
		/// <summary>
		/// 保存上传的文件.
		/// </summary>
		/// <param name="filePath">文件的保存位置, 需要一个绝对路径.</param>
		/// <param name="postedFile">上传的文件, 可以从表单或者控件获得.</param>
		/// <param name="uploadInfo">包含文件上传进度信息的类.</param>
		/// <param name="bufferSize">保存文件时的缓存大小, 以 kb 为单位, 如果小于 0, 则默认 128 kb.</param>
		/// <param name="waitSecond">每次包含字节时的等待时间, 只用于调试时使用.</param>
		public static void Save ( string filePath, HttpPostedFile postedFile, UploadInfo uploadInfo, int bufferSize, int waitSecond )
#endif
		{

			if ( string.IsNullOrEmpty ( filePath ) || null == postedFile || null == uploadInfo )
				return;

			if ( bufferSize <= 0 )
				bufferSize = 128;

			bufferSize = bufferSize * 1024;

			FileStream file = null;
			uploadInfo.ContentLength = postedFile.ContentLength;
			uploadInfo.PostedLength = 0;

			try
			{
				file = new FileStream ( filePath, FileMode.Create );

				while ( uploadInfo.PostedLength < uploadInfo.ContentLength )
				{
					byte[] buffers = new byte[bufferSize];

					int byteCount = postedFile.InputStream.Read ( buffers, 0, bufferSize );

					file.Write ( buffers, 0, byteCount );
					uploadInfo.PostedLength += byteCount;

					if ( waitSecond >= 0 )
						Thread.Sleep ( 1000 * waitSecond );

				}

			}
			finally
			{

				if ( null != file )
					file.Close ( );

			}

		}
		#endregion

		private readonly Timer timer = new Timer ( );
		private readonly HtmlGenericControl iframe = new HtmlGenericControl ( "IFRAME" );
		private string uploadKey = string.Empty;

		#region " option "
		/// <summary>
		/// 获取或设置上传页面的选择器, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "上传页面的选择器, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		public string Upload
		{
			get { return this.uiSetting.Upload; }
			set { this.uiSetting.Upload = value; }
		}

		/// <summary>
		/// 获取或设置上传页面的表单索引, 默认为 0.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "上传页面的表单索引, 默认为 0" )]
		[NotifyParentProperty ( true )]
		public int UploadForm
		{
			get { return this.uiSetting.UploadForm; }
			set { this.uiSetting.UploadForm = value; }
		}
		#endregion

		#region " extended option "
		/// <summary>
		/// 获取或设置进度刷新的间隔, 以毫秒为单位, 默认为 1000.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "进度刷新的间隔, 以毫秒为单位, 默认为 1000" )]
		[NotifyParentProperty ( true )]
		public int ProgressInterval
		{
			get { return this.timer.Interval; }
			set { this.timer.Interval = value; }
		}

		/// <summary>
		/// 获取或设置进度的地址, 默认为空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "获取进度的地址, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		[UrlProperty ( )]
		public string ProgressUrl
		{
			get { return this.timer.TickAsync.Url; }
			set
			{

				try
				{ this.timer.TickAsync.Url = this.ResolveClientUrl ( value ); }
				catch { }

			}
		}

		/// <summary>
		/// 获取或设置上传页面是否具有边框, 默认 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "上传页面是否具有边框, 默认 false" )]
		[NotifyParentProperty ( true )]
		public bool UploadFrameBorder
		{
			get
			{

				if ( this.iframe.Attributes["frameborder"] == "0" )
					return false;
				else
					return true;

			}
			set { this.iframe.Attributes["frameborder"] = value ? "1" : "0"; }
		}

		/// <summary>
		/// 获取或设置上传页面的高度, 默认 50.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 50 )]
		[Description ( "上传页面的高度, 默认 50px" )]
		[NotifyParentProperty ( true )]
		public Unit UploadHeight
		{
			get
			{

				try
				{ return Unit.Parse ( this.iframe.Attributes["height"] ); }
				catch
				{ return Unit.Empty; }

			}
			set { this.iframe.Attributes["height"] = value.ToString ( ); }
		}

		/// <summary>
		/// 获取或设置上传关键字, 用于区分不同的上传类型, 默认空字符串.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "上传关键字, 用于区分不同的上传类型, 默认空字符串" )]
		[NotifyParentProperty ( true )]
		public string UploadKey
		{
			get { return this.uploadKey; }
			set { this.uploadKey = null == value ? string.Empty : value; }
		}

		/// <summary>
		/// 获取或设置上传页面是否具有边框, 默认 "no".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "no" )]
		[Description ( "上传页面是否具有边框, 默认 no" )]
		[NotifyParentProperty ( true )]
		public string UploadScrolling
		{
			get { return this.iframe.Attributes["scrolling"]; }
			set { this.iframe.Attributes["scrolling"] = value; }
		}

		/// <summary>
		/// 获取或设置上传页面的地址, 默认为空字符串.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( "" )]
		[Description ( "上传页面的地址, 默认为空字符串" )]
		[NotifyParentProperty ( true )]
		[UrlProperty ( )]
		public string UploadUrl
		{
			get { return this.iframe.Attributes["src"]; }
			set
			{

				try
				{ this.iframe.Attributes["src"] = this.ResolveClientUrl ( value ); }
				catch { }

			}
		}

		/// <summary>
		/// 获取或设置上传页面的宽度, 默认 300.
		/// </summary>
		[Category ( "布局" )]
		[DefaultValue ( 300 )]
		[Description ( "上传页面的宽度, 默认 300px" )]
		[NotifyParentProperty ( true )]
		public Unit UploadWidth
		{
			get
			{

				try
				{ return Unit.Parse ( this.iframe.Attributes["width"] ); }
				catch
				{ return Unit.Empty; }

			}
			set { this.iframe.Attributes["width"] = value.ToString ( ); }
		}
		#endregion

		#region " extended event "
		/// <summary>
		/// 获取或设置进度改变时的事件, 类似于: "function(data) { }".
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "进度改变时的事件, 类似于: function(data) { }" )]
		[NotifyParentProperty ( true )]
		public string ProgressChanged
		{
			get { return this.timer.TickAsync.Success; }
			set { this.timer.TickAsync.Success = value; }
		}
		#endregion

		/// <summary>
		/// 创建一个自定义上传插件.
		/// </summary>
		public Uploader ( )
			: base ( new UploaderSetting ( ), HtmlTextWriterTag.Div )
		{
			this.UploadFrameBorder = false;
			this.UploadScrolling = "no";
			this.UploadHeight = 50;
			this.UploadWidth = 300;
			this.timer.ID = "timer";
		}

		protected override void renderJQuery ( JQueryUI jquery )
		{
			//!+ We do not reset these properties in the UploaderSetting.Recombine, because we use the ClientID

			if ( string.IsNullOrEmpty ( this.Upload ) )
				this.Upload = string.Format ( "'#{0} iframe'", this.ClientID );
			else
				this.Upload = UISetting.CreateJQuerySelector ( this.Upload );

			this.uiSetting.Timer = string.Format ( "'#{0}'", this.timer.ClientID );

			if ( !string.IsNullOrEmpty ( this.uploadKey ) )
				WidgetSetting.AppendParameter ( this.timer.TickAsync,
					new NParameter[]
					{
						new NParameter("key", ParameterType.Expression, string.Format("'{0}'", this.uploadKey), ParameterDataType.String)
					} );

			base.renderJQuery ( jquery );
		}

		protected override bool isFaceless ( )
		{ return this.DesignMode; }

		protected override bool isFace ( )
		{ return false; }

		protected override string facelessPrefix ( )
		{ return "Uploader"; }

		protected override string facelessPostfix ( )
		{
			string postfix = string.Empty;

			postfix += string.Format ( " <span style=\"color: #660066\">{0}</span>", this.ProgressUrl );

			return base.facelessPostfix ( ) + postfix;
		}

		protected override void CreateChildControls ( )
		{
			base.CreateChildControls ( );

			this.Controls.Add ( this.iframe );
			this.Controls.Add ( this.timer );
		}

	}

	partial class Uploader
	{
#if !PARAM
		/// <summary>
		/// 保存上传的文件, 缓存为 128 kb.
		/// </summary>
		/// <param name="filePath">文件的保存位置, 需要一个绝对路径.</param>
		/// <param name="postedFile">上传的文件, 可以从表单或者控件获得.</param>
		/// <param name="uploadInfo">包含文件上传进度信息的类.</param>
		public static void Save ( string filePath, HttpPostedFile postedFile, UploadInfo uploadInfo )
		{ Save ( filePath, postedFile, uploadInfo, 0, 0 ); }
		/// <summary>
		/// 保存上传的文件.
		/// </summary>
		/// <param name="filePath">文件的保存位置, 需要一个绝对路径.</param>
		/// <param name="postedFile">上传的文件, 可以从表单或者控件获得.</param>
		/// <param name="uploadInfo">包含文件上传进度信息的类.</param>
		/// <param name="bufferSize">保存文件时的缓存大小, 以 kb 为单位, 如果小于 0, 则默认 128 kb.</param>
		public static void Save ( string filePath, HttpPostedFile postedFile, UploadInfo uploadInfo, int bufferSize )
		{ Save ( filePath, postedFile, uploadInfo, bufferSize, 0 ); }
#endif
	}
}

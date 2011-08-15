/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/EMail.cs
 * 版本: 1.0, .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
* */

// HACK: 在项目中定义编译符号 PARAM, 使用提供默认参数的方法.

using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace zoyobar.shared.panzer.web
{

	/// <summary>
	/// EMail 可以使用开通 SMTP 服务的邮箱发送电子邮件.
	/// </summary>
	public sealed partial class EMail
	{
		private readonly NetworkCredential credential;
		private readonly string hostAddress;
		private readonly MailAddress senderMailAddress;
		private readonly Encoding encoding;

		/// <summary>
		/// 创建一个 EMail 类, 标题和内容使用默认编码.
		/// </summary>
		/// <param name="hostAddress">邮件服务器地址, 如: "smtp.tom.com".</param>
		/// <param name="userName">所使用的邮件账户用户名, 如: "jack".</param>
		/// <param name="password">所使用的邮件账户密码, 如: "123".</param>
		/// <param name="displayAddress">显示的发送地址, 如: "jack@tom.com".</param>
		/// <param name="displayName">显示的发送人, 如: "jack".</param>
		public EMail ( string hostAddress, string userName, string password, string displayAddress, string displayName )
			: this ( hostAddress, userName, password, displayAddress, displayName, Encoding.Default )
		{ }
		/// <summary>
		/// 创建一个 EMail 类.
		/// </summary>
		/// <param name="hostAddress">邮件服务器地址, 如: "smtp.tom.com".</param>
		/// <param name="userName">所使用的邮件账户用户名, 如: "jack".</param>
		/// <param name="password">所使用的邮件账户密码, 如: "123".</param>
		/// <param name="displayAddress">显示的发送地址, 如: "jack@tom.com".</param>
		/// <param name="displayName">显示的发送人, 如: "jack".</param>
		/// <param name="encoding">标题和内容使用的编码.</param>
		public EMail ( string hostAddress, string userName, string password, string displayAddress, string displayName, Encoding encoding )
		{

			if ( string.IsNullOrEmpty ( hostAddress ) || string.IsNullOrEmpty ( userName ) || string.IsNullOrEmpty ( password ) || string.IsNullOrEmpty ( displayAddress ) || string.IsNullOrEmpty ( displayName ) )
				throw new ArgumentNullException ( "hostAddress, userName, password, displayAddress, displayName", "服务器地址, 用户名, 密码, 显示发送地址和发送人不能为空" );

			this.credential = new NetworkCredential ( userName, password );
			this.hostAddress = hostAddress;
			this.senderMailAddress = new MailAddress ( displayAddress, displayName, encoding );

			this.encoding = encoding;
		}

#if PARAM
		/// <summary>
		/// 发送一封邮件.
		/// </summary>
		/// <param name="subject">邮件主题.</param>
		/// <param name="receiverAddress">接收地址, 如: "lili@tom.com".</param>
		/// <param name="receiverName">接收人, 如: "lili".</param>
		/// <param name="body">邮件内容, 如果是 html 代码, 需要设置 isBodyHTML 参数为 true.</param>
		/// <param name="isBodyHTML">指示邮件内容是否为 html 代码, 默认为 false.</param>
		public void Send ( string subject, string receiverAddress, string receiverName, string body, bool isBodyHTML = false )
#else
		/// <summary>
		/// 发送一封邮件.
		/// </summary>
		/// <param name="subject">邮件主题.</param>
		/// <param name="receiverAddress">接收地址, 如: "lili@tom.com".</param>
		/// <param name="receiverName">接收人, 如: "lili".</param>
		/// <param name="body">邮件内容, 如果是 html 代码, 需要设置 isBodyHTML 参数为 true.</param>
		/// <param name="isBodyHTML">指示邮件内容是否为 html 代码.</param>
		public void Send ( string subject, string receiverAddress, string receiverName, string body, bool isBodyHTML )
#endif
		{

			if ( string.IsNullOrEmpty ( subject ) || string.IsNullOrEmpty ( receiverAddress ) || string.IsNullOrEmpty ( receiverName ) || string.IsNullOrEmpty ( body ) )
				throw new ArgumentNullException ( "subject, receiverAddress, receiverName, body", "主题, 接收地址, 接收人和内容不能为空" );

			SmtpClient client = new SmtpClient ( this.hostAddress );
			client.Credentials = this.credential;

			MailMessage message = new MailMessage ( this.senderMailAddress, new MailAddress ( receiverAddress, receiverName ) );

			message.BodyEncoding = this.encoding;
			message.SubjectEncoding = this.encoding;
			message.IsBodyHtml = isBodyHTML;

			message.Body = body;
			message.Subject = subject;

			message.Headers.Add ( "X-Mailer", "Microsoft Office Outlook, Build 11.0.5510" );
			message.Headers.Add ( "X-MimeOLE", "Produced By Microsoft MimeOLE V6.00.3790.4325" );

			try
			{ client.Send ( message ); }
			catch { }

		}

	}

	partial class EMail
	{
#if !PARAM
		/// <summary>
		/// 发送一封邮件, 内容为普通文本.
		/// </summary>
		/// <param name="subject">邮件主题.</param>
		/// <param name="receiverAddress">接收地址, 如: "lili@tom.com".</param>
		/// <param name="receiverName">接收人, 如: "lili".</param>
		/// <param name="body">邮件内容, 如果是 html 代码, 需要设置 isBodyHTML 参数为 true.</param>
		public void Send ( string subject, string receiverAddress, string receiverName, string body )
		{ this.Send ( subject, receiverAddress, receiverName, body, false ); }
#endif
	}

}

namespace zoyobar.shared.panzer.test.web.ib
{
	partial class FormIEBrowserDoc
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.webBrowser = new System.Windows.Forms.WebBrowser ( );
			this.cmdNavigate = new System.Windows.Forms.Button ( );
			this.cmdExecuteJavscript = new System.Windows.Forms.Button ( );
			this.cmdInstallJavascript = new System.Windows.Forms.Button ( );
			this.cmdDataExchange = new System.Windows.Forms.Button ( );
			this.cmdInvokeJavascript = new System.Windows.Forms.Button ( );
			this.cmdFlowNWPC = new System.Windows.Forms.Button ( );
			this.cmdExecuteJQuery = new System.Windows.Forms.Button ( );
			this.cmd163Blog = new System.Windows.Forms.Button ( );
			this.cmdNoConflict = new System.Windows.Forms.Button ( );
			this.cmdCopyImage = new System.Windows.Forms.Button ( );
			this.pictureBox = new System.Windows.Forms.PictureBox ( );
			this.cmdDZ = new System.Windows.Forms.Button ( );
			this.cmdRecord = new System.Windows.Forms.Button ( );
			( ( System.ComponentModel.ISupportInitialize ) ( this.pictureBox ) ).BeginInit ( );
			this.SuspendLayout ( );
			// 
			// webBrowser
			// 
			this.webBrowser.Location = new System.Drawing.Point ( 12, 12 );
			this.webBrowser.MinimumSize = new System.Drawing.Size ( 20, 20 );
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size ( 250, 250 );
			this.webBrowser.TabIndex = 0;
			this.webBrowser.Url = new System.Uri ( "about:blank", System.UriKind.Absolute );
			// 
			// cmdNavigate
			// 
			this.cmdNavigate.Location = new System.Drawing.Point ( 268, 12 );
			this.cmdNavigate.Name = "cmdNavigate";
			this.cmdNavigate.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdNavigate.TabIndex = 1;
			this.cmdNavigate.Text = "页面跳转";
			this.cmdNavigate.UseVisualStyleBackColor = true;
			this.cmdNavigate.Click += new System.EventHandler ( this.cmdNavigate_Click );
			// 
			// cmdExecuteJavscript
			// 
			this.cmdExecuteJavscript.Location = new System.Drawing.Point ( 268, 41 );
			this.cmdExecuteJavscript.Name = "cmdExecuteJavscript";
			this.cmdExecuteJavscript.Size = new System.Drawing.Size ( 130, 23 );
			this.cmdExecuteJavscript.TabIndex = 1;
			this.cmdExecuteJavscript.Text = "执行 javascript";
			this.cmdExecuteJavscript.UseVisualStyleBackColor = true;
			this.cmdExecuteJavscript.Click += new System.EventHandler ( this.cmdExecuteJavscript_Click );
			// 
			// cmdInstallJavascript
			// 
			this.cmdInstallJavascript.Location = new System.Drawing.Point ( 268, 70 );
			this.cmdInstallJavascript.Name = "cmdInstallJavascript";
			this.cmdInstallJavascript.Size = new System.Drawing.Size ( 130, 23 );
			this.cmdInstallJavascript.TabIndex = 1;
			this.cmdInstallJavascript.Text = "安装 javascript";
			this.cmdInstallJavascript.UseVisualStyleBackColor = true;
			this.cmdInstallJavascript.Click += new System.EventHandler ( this.cmdInstallJavascript_Click );
			// 
			// cmdDataExchange
			// 
			this.cmdDataExchange.Location = new System.Drawing.Point ( 268, 128 );
			this.cmdDataExchange.Name = "cmdDataExchange";
			this.cmdDataExchange.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdDataExchange.TabIndex = 1;
			this.cmdDataExchange.Text = "数据交互";
			this.cmdDataExchange.UseVisualStyleBackColor = true;
			this.cmdDataExchange.Click += new System.EventHandler ( this.cmdDataExchange_Click );
			// 
			// cmdInvokeJavascript
			// 
			this.cmdInvokeJavascript.Location = new System.Drawing.Point ( 268, 99 );
			this.cmdInvokeJavascript.Name = "cmdInvokeJavascript";
			this.cmdInvokeJavascript.Size = new System.Drawing.Size ( 130, 23 );
			this.cmdInvokeJavascript.TabIndex = 1;
			this.cmdInvokeJavascript.Text = "调用 javascript";
			this.cmdInvokeJavascript.UseVisualStyleBackColor = true;
			this.cmdInvokeJavascript.Click += new System.EventHandler ( this.cmdInvokeJavascript_Click );
			// 
			// cmdFlowNWPC
			// 
			this.cmdFlowNWPC.Location = new System.Drawing.Point ( 268, 186 );
			this.cmdFlowNWPC.Name = "cmdFlowNWPC";
			this.cmdFlowNWPC.Size = new System.Drawing.Size ( 130, 23 );
			this.cmdFlowNWPC.TabIndex = 1;
			this.cmdFlowNWPC.Text = "页面载入跳转";
			this.cmdFlowNWPC.UseVisualStyleBackColor = true;
			this.cmdFlowNWPC.Click += new System.EventHandler ( this.cmdFlowNWPC_Click );
			// 
			// cmdExecuteJQuery
			// 
			this.cmdExecuteJQuery.Location = new System.Drawing.Point ( 268, 157 );
			this.cmdExecuteJQuery.Name = "cmdExecuteJQuery";
			this.cmdExecuteJQuery.Size = new System.Drawing.Size ( 130, 23 );
			this.cmdExecuteJQuery.TabIndex = 1;
			this.cmdExecuteJQuery.Text = "执行 jquery";
			this.cmdExecuteJQuery.UseVisualStyleBackColor = true;
			this.cmdExecuteJQuery.Click += new System.EventHandler ( this.cmdExecuteJQuery_Click );
			// 
			// cmd163Blog
			// 
			this.cmd163Blog.Location = new System.Drawing.Point ( 268, 215 );
			this.cmd163Blog.Name = "cmd163Blog";
			this.cmd163Blog.Size = new System.Drawing.Size ( 130, 23 );
			this.cmd163Blog.TabIndex = 1;
			this.cmd163Blog.Text = "发布 163 日志";
			this.cmd163Blog.UseVisualStyleBackColor = true;
			this.cmd163Blog.Click += new System.EventHandler ( this.cmd163Blog_Click );
			// 
			// cmdNoConflict
			// 
			this.cmdNoConflict.Location = new System.Drawing.Point ( 268, 244 );
			this.cmdNoConflict.Name = "cmdNoConflict";
			this.cmdNoConflict.Size = new System.Drawing.Size ( 130, 23 );
			this.cmdNoConflict.TabIndex = 1;
			this.cmdNoConflict.Text = "解决 $ 定义冲突";
			this.cmdNoConflict.UseVisualStyleBackColor = true;
			this.cmdNoConflict.Click += new System.EventHandler ( this.cmdNoConflict_Click );
			// 
			// cmdCopyImage
			// 
			this.cmdCopyImage.Location = new System.Drawing.Point ( 430, 12 );
			this.cmdCopyImage.Name = "cmdCopyImage";
			this.cmdCopyImage.Size = new System.Drawing.Size ( 130, 23 );
			this.cmdCopyImage.TabIndex = 2;
			this.cmdCopyImage.Text = "复制并获取图片";
			this.cmdCopyImage.UseVisualStyleBackColor = true;
			this.cmdCopyImage.Click += new System.EventHandler ( this.cmdCopyImage_Click );
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point ( 430, 43 );
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size ( 130, 50 );
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox.TabIndex = 3;
			this.pictureBox.TabStop = false;
			// 
			// cmdDZ
			// 
			this.cmdDZ.Location = new System.Drawing.Point ( 430, 99 );
			this.cmdDZ.Name = "cmdDZ";
			this.cmdDZ.Size = new System.Drawing.Size ( 130, 23 );
			this.cmdDZ.TabIndex = 2;
			this.cmdDZ.Text = "在 DZ 论坛发帖";
			this.cmdDZ.UseVisualStyleBackColor = true;
			this.cmdDZ.Click += new System.EventHandler ( this.cmdDZ_Click );
			// 
			// cmdRecord
			// 
			this.cmdRecord.Location = new System.Drawing.Point ( 268, 273 );
			this.cmdRecord.Name = "cmdRecord";
			this.cmdRecord.Size = new System.Drawing.Size ( 130, 23 );
			this.cmdRecord.TabIndex = 1;
			this.cmdRecord.Text = "记录和回放";
			this.cmdRecord.UseVisualStyleBackColor = true;
			this.cmdRecord.Click += new System.EventHandler ( this.cmdRecord_Click );
			// 
			// FormIEBrowserDoc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 572, 324 );
			this.Controls.Add ( this.pictureBox );
			this.Controls.Add ( this.cmdDZ );
			this.Controls.Add ( this.cmdCopyImage );
			this.Controls.Add ( this.cmdExecuteJQuery );
			this.Controls.Add ( this.cmdRecord );
			this.Controls.Add ( this.cmdNoConflict );
			this.Controls.Add ( this.cmd163Blog );
			this.Controls.Add ( this.cmdFlowNWPC );
			this.Controls.Add ( this.cmdInvokeJavascript );
			this.Controls.Add ( this.cmdDataExchange );
			this.Controls.Add ( this.cmdInstallJavascript );
			this.Controls.Add ( this.cmdExecuteJavscript );
			this.Controls.Add ( this.cmdNavigate );
			this.Controls.Add ( this.webBrowser );
			this.Name = "FormIEBrowserDoc";
			this.Text = "FormIEBrowserDoc";
			( ( System.ComponentModel.ISupportInitialize ) ( this.pictureBox ) ).EndInit ( );
			this.ResumeLayout ( false );

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.Button cmdNavigate;
		private System.Windows.Forms.Button cmdExecuteJavscript;
		private System.Windows.Forms.Button cmdInstallJavascript;
		private System.Windows.Forms.Button cmdDataExchange;
		private System.Windows.Forms.Button cmdInvokeJavascript;
		private System.Windows.Forms.Button cmdFlowNWPC;
		private System.Windows.Forms.Button cmdExecuteJQuery;
		private System.Windows.Forms.Button cmd163Blog;
		private System.Windows.Forms.Button cmdNoConflict;
		private System.Windows.Forms.Button cmdCopyImage;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button cmdDZ;
		private System.Windows.Forms.Button cmdRecord;
	}
}
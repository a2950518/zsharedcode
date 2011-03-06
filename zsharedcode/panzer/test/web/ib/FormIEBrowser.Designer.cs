namespace zoyobar.shared.panzer.test.web.ib
{
	partial class FormIEBrowser
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
				components.Dispose ();
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.webBrowser = new System.Windows.Forms.WebBrowser ();
			this.cmdTest = new System.Windows.Forms.Button ();
			this.cmdInstall = new System.Windows.Forms.Button ();
			this.cmdSpider = new System.Windows.Forms.Button ();
			this.lblInfo = new System.Windows.Forms.Label ();
			this.lblCN = new System.Windows.Forms.Label ();
			this.txtMarketCN = new System.Windows.Forms.TextBox ();
			this.cmdStop = new System.Windows.Forms.Button ();
			this.txtContentCN = new System.Windows.Forms.TextBox ();
			this.checkIsThrow = new System.Windows.Forms.CheckBox ();
			this.txtJQuery = new System.Windows.Forms.TextBox ();
			this.SuspendLayout ();
			// 
			// webBrowser
			// 
			this.webBrowser.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.webBrowser.Location = new System.Drawing.Point ( 12, 12 );
			this.webBrowser.MinimumSize = new System.Drawing.Size ( 20, 20 );
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size ( 847, 309 );
			this.webBrowser.TabIndex = 0;
			this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler ( this.webBrowser_DocumentCompleted );
			// 
			// cmdTest
			// 
			this.cmdTest.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdTest.Enabled = false;
			this.cmdTest.Location = new System.Drawing.Point ( 784, 410 );
			this.cmdTest.Name = "cmdTest";
			this.cmdTest.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdTest.TabIndex = 1;
			this.cmdTest.Text = "测试脚本";
			this.cmdTest.UseVisualStyleBackColor = true;
			this.cmdTest.Click += new System.EventHandler ( this.cmdTest_Click );
			// 
			// cmdInstall
			// 
			this.cmdInstall.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdInstall.Enabled = false;
			this.cmdInstall.Location = new System.Drawing.Point ( 784, 381 );
			this.cmdInstall.Name = "cmdInstall";
			this.cmdInstall.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdInstall.TabIndex = 1;
			this.cmdInstall.Text = "安装脚本";
			this.cmdInstall.UseVisualStyleBackColor = true;
			this.cmdInstall.Click += new System.EventHandler ( this.cmdInstall_Click );
			// 
			// cmdSpider
			// 
			this.cmdSpider.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdSpider.Enabled = false;
			this.cmdSpider.Location = new System.Drawing.Point ( 703, 381 );
			this.cmdSpider.Name = "cmdSpider";
			this.cmdSpider.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdSpider.TabIndex = 1;
			this.cmdSpider.Text = "开始";
			this.cmdSpider.UseVisualStyleBackColor = true;
			this.cmdSpider.Click += new System.EventHandler ( this.cmdSpider_Click );
			// 
			// lblInfo
			// 
			this.lblInfo.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point ( 12, 386 );
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size ( 29, 12 );
			this.lblInfo.TabIndex = 2;
			this.lblInfo.Text = "就绪";
			// 
			// lblCN
			// 
			this.lblCN.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.lblCN.AutoSize = true;
			this.lblCN.Location = new System.Drawing.Point ( 12, 330 );
			this.lblCN.Name = "lblCN";
			this.lblCN.Size = new System.Drawing.Size ( 65, 12 );
			this.lblCN.TabIndex = 3;
			this.lblCN.Text = "连接字符串";
			// 
			// txtMarketCN
			// 
			this.txtMarketCN.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtMarketCN.Location = new System.Drawing.Point ( 83, 354 );
			this.txtMarketCN.Name = "txtMarketCN";
			this.txtMarketCN.Size = new System.Drawing.Size ( 776, 21 );
			this.txtMarketCN.TabIndex = 4;
			this.txtMarketCN.Text = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Aim.mdb";
			// 
			// cmdStop
			// 
			this.cmdStop.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdStop.Enabled = false;
			this.cmdStop.Location = new System.Drawing.Point ( 622, 381 );
			this.cmdStop.Name = "cmdStop";
			this.cmdStop.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdStop.TabIndex = 1;
			this.cmdStop.Text = "停止";
			this.cmdStop.UseVisualStyleBackColor = true;
			this.cmdStop.Click += new System.EventHandler ( this.cmdStop_Click );
			// 
			// txtContentCN
			// 
			this.txtContentCN.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtContentCN.Location = new System.Drawing.Point ( 83, 327 );
			this.txtContentCN.Name = "txtContentCN";
			this.txtContentCN.Size = new System.Drawing.Size ( 776, 21 );
			this.txtContentCN.TabIndex = 4;
			this.txtContentCN.Text = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SpiderResult.mdb";
			// 
			// checkIsThrow
			// 
			this.checkIsThrow.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.checkIsThrow.AutoSize = true;
			this.checkIsThrow.Location = new System.Drawing.Point ( 544, 385 );
			this.checkIsThrow.Name = "checkIsThrow";
			this.checkIsThrow.Size = new System.Drawing.Size ( 72, 16 );
			this.checkIsThrow.TabIndex = 5;
			this.checkIsThrow.Text = "抛出异常";
			this.checkIsThrow.UseVisualStyleBackColor = true;
			// 
			// txtJQuery
			// 
			this.txtJQuery.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtJQuery.Location = new System.Drawing.Point ( 83, 412 );
			this.txtJQuery.Name = "txtJQuery";
			this.txtJQuery.Size = new System.Drawing.Size ( 695, 21 );
			this.txtJQuery.TabIndex = 4;
			this.txtJQuery.Text = "try{alert(\'成功, 页面上共有 \' + $(\'*\').length + \' 个元素\');}catch(err){alert(\'脚本尚未成功安装, 请稍后" +
				"测试\');}";
			this.txtJQuery.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler ( this.txtJQuery_MouseDoubleClick );
			// 
			// FormIEBrowser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 871, 445 );
			this.Controls.Add ( this.checkIsThrow );
			this.Controls.Add ( this.txtContentCN );
			this.Controls.Add ( this.txtJQuery );
			this.Controls.Add ( this.txtMarketCN );
			this.Controls.Add ( this.lblCN );
			this.Controls.Add ( this.lblInfo );
			this.Controls.Add ( this.cmdInstall );
			this.Controls.Add ( this.cmdStop );
			this.Controls.Add ( this.cmdSpider );
			this.Controls.Add ( this.cmdTest );
			this.Controls.Add ( this.webBrowser );
			this.Name = "FormIEBrowser";
			this.Text = "FormIEBrowser";
			this.ResumeLayout ( false );
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.Button cmdTest;
		private System.Windows.Forms.Button cmdInstall;
		private System.Windows.Forms.Button cmdSpider;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Label lblCN;
		private System.Windows.Forms.TextBox txtMarketCN;
		private System.Windows.Forms.Button cmdStop;
		private System.Windows.Forms.TextBox txtContentCN;
		private System.Windows.Forms.CheckBox checkIsThrow;
		private System.Windows.Forms.TextBox txtJQuery;
	}
}
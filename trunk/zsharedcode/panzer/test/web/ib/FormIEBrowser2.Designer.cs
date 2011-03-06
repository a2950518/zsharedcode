namespace zoyobar.shared.panzer.test.web.ib
{
	partial class FormIEBrowser2
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
			this.cmdSearch = new System.Windows.Forms.Button ( );
			this.txtKeyWord = new System.Windows.Forms.TextBox ( );
			this.lblKeyWord = new System.Windows.Forms.Label ( );
			this.split1 = new System.Windows.Forms.SplitContainer ( );
			this.split2 = new System.Windows.Forms.SplitContainer ( );
			this.numericPageCount = new System.Windows.Forms.NumericUpDown ( );
			this.cmdStop = new System.Windows.Forms.Button ( );
			this.label1 = new System.Windows.Forms.Label ( );
			this.status = new System.Windows.Forms.StatusStrip ( );
			this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel ( );
			this.lblTime = new System.Windows.Forms.ToolStripStatusLabel ( );
			this.listPage = new System.Windows.Forms.ListBox ( );
			this.cmdSpider = new System.Windows.Forms.Button ( );
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog ( );
			( ( System.ComponentModel.ISupportInitialize ) ( this.split1 ) ).BeginInit ( );
			this.split1.Panel1.SuspendLayout ( );
			this.split1.Panel2.SuspendLayout ( );
			this.split1.SuspendLayout ( );
			( ( System.ComponentModel.ISupportInitialize ) ( this.split2 ) ).BeginInit ( );
			this.split2.Panel1.SuspendLayout ( );
			this.split2.Panel2.SuspendLayout ( );
			this.split2.SuspendLayout ( );
			( ( System.ComponentModel.ISupportInitialize ) ( this.numericPageCount ) ).BeginInit ( );
			this.status.SuspendLayout ( );
			this.SuspendLayout ( );
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.Location = new System.Drawing.Point ( 0, 0 );
			this.webBrowser.MinimumSize = new System.Drawing.Size ( 20, 20 );
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size ( 362, 287 );
			this.webBrowser.TabIndex = 1;
			// 
			// cmdSearch
			// 
			this.cmdSearch.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdSearch.Location = new System.Drawing.Point ( 440, 8 );
			this.cmdSearch.Name = "cmdSearch";
			this.cmdSearch.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdSearch.TabIndex = 2;
			this.cmdSearch.Text = "开始";
			this.cmdSearch.UseVisualStyleBackColor = true;
			this.cmdSearch.Click += new System.EventHandler ( this.cmdSearch_Click );
			// 
			// txtKeyWord
			// 
			this.txtKeyWord.Location = new System.Drawing.Point ( 60, 10 );
			this.txtKeyWord.Name = "txtKeyWord";
			this.txtKeyWord.Size = new System.Drawing.Size ( 120, 21 );
			this.txtKeyWord.TabIndex = 3;
			// 
			// lblKeyWord
			// 
			this.lblKeyWord.AutoSize = true;
			this.lblKeyWord.Font = new System.Drawing.Font ( "宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 134 ) ) );
			this.lblKeyWord.Location = new System.Drawing.Point ( 3, 13 );
			this.lblKeyWord.Name = "lblKeyWord";
			this.lblKeyWord.Size = new System.Drawing.Size ( 51, 12 );
			this.lblKeyWord.TabIndex = 4;
			this.lblKeyWord.Text = "关键字:";
			// 
			// split1
			// 
			this.split1.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.split1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.split1.Location = new System.Drawing.Point ( 12, 12 );
			this.split1.Name = "split1";
			this.split1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// split1.Panel1
			// 
			this.split1.Panel1.Controls.Add ( this.split2 );
			// 
			// split1.Panel2
			// 
			this.split1.Panel2.Controls.Add ( this.numericPageCount );
			this.split1.Panel2.Controls.Add ( this.txtKeyWord );
			this.split1.Panel2.Controls.Add ( this.cmdSpider );
			this.split1.Panel2.Controls.Add ( this.cmdStop );
			this.split1.Panel2.Controls.Add ( this.cmdSearch );
			this.split1.Panel2.Controls.Add ( this.label1 );
			this.split1.Panel2.Controls.Add ( this.lblKeyWord );
			this.split1.Panel2MinSize = 100;
			this.split1.Size = new System.Drawing.Size ( 518, 392 );
			this.split1.SplitterDistance = 287;
			this.split1.TabIndex = 5;
			// 
			// split2
			// 
			this.split2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.split2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.split2.Location = new System.Drawing.Point ( 0, 0 );
			this.split2.Name = "split2";
			// 
			// split2.Panel1
			// 
			this.split2.Panel1.Controls.Add ( this.webBrowser );
			// 
			// split2.Panel2
			// 
			this.split2.Panel2.Controls.Add ( this.listPage );
			this.split2.Panel2MinSize = 150;
			this.split2.Size = new System.Drawing.Size ( 518, 287 );
			this.split2.SplitterDistance = 362;
			this.split2.TabIndex = 2;
			// 
			// numericPageCount
			// 
			this.numericPageCount.Location = new System.Drawing.Point ( 60, 37 );
			this.numericPageCount.Maximum = new decimal ( new int[] {
            10,
            0,
            0,
            0} );
			this.numericPageCount.Minimum = new decimal ( new int[] {
            1,
            0,
            0,
            0} );
			this.numericPageCount.Name = "numericPageCount";
			this.numericPageCount.Size = new System.Drawing.Size ( 40, 21 );
			this.numericPageCount.TabIndex = 5;
			this.numericPageCount.Value = new decimal ( new int[] {
            1,
            0,
            0,
            0} );
			// 
			// cmdStop
			// 
			this.cmdStop.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdStop.Enabled = false;
			this.cmdStop.Location = new System.Drawing.Point ( 440, 34 );
			this.cmdStop.Name = "cmdStop";
			this.cmdStop.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdStop.TabIndex = 2;
			this.cmdStop.Text = "停止";
			this.cmdStop.UseVisualStyleBackColor = true;
			this.cmdStop.Click += new System.EventHandler ( this.cmdStop_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font ( "宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 134 ) ) );
			this.label1.Location = new System.Drawing.Point ( 16, 39 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size ( 38, 12 );
			this.label1.TabIndex = 4;
			this.label1.Text = "页数:";
			// 
			// status
			// 
			this.status.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo,
            this.lblTime} );
			this.status.Location = new System.Drawing.Point ( 0, 407 );
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size ( 542, 22 );
			this.status.TabIndex = 6;
			this.status.Text = "statusStrip1";
			// 
			// lblInfo
			// 
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size ( 17, 17 );
			this.lblInfo.Text = "...";
			// 
			// lblTime
			// 
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size ( 17, 17 );
			this.lblTime.Text = "...";
			// 
			// listPage
			// 
			this.listPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listPage.FormattingEnabled = true;
			this.listPage.ItemHeight = 12;
			this.listPage.Location = new System.Drawing.Point ( 0, 0 );
			this.listPage.Name = "listPage";
			this.listPage.Size = new System.Drawing.Size ( 152, 287 );
			this.listPage.TabIndex = 0;
			// 
			// cmdSpider
			// 
			this.cmdSpider.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdSpider.Enabled = false;
			this.cmdSpider.Location = new System.Drawing.Point ( 440, 63 );
			this.cmdSpider.Name = "cmdSpider";
			this.cmdSpider.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdSpider.TabIndex = 2;
			this.cmdSpider.Text = "采集";
			this.cmdSpider.UseVisualStyleBackColor = true;
			this.cmdSpider.Click += new System.EventHandler ( this.cmdSpider_Click );
			// 
			// FormIEBrowser2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 542, 429 );
			this.Controls.Add ( this.status );
			this.Controls.Add ( this.split1 );
			this.Name = "FormIEBrowser2";
			this.Text = "FormIEBrowser2";
			this.split1.Panel1.ResumeLayout ( false );
			this.split1.Panel2.ResumeLayout ( false );
			this.split1.Panel2.PerformLayout ( );
			( ( System.ComponentModel.ISupportInitialize ) ( this.split1 ) ).EndInit ( );
			this.split1.ResumeLayout ( false );
			this.split2.Panel1.ResumeLayout ( false );
			this.split2.Panel2.ResumeLayout ( false );
			( ( System.ComponentModel.ISupportInitialize ) ( this.split2 ) ).EndInit ( );
			this.split2.ResumeLayout ( false );
			( ( System.ComponentModel.ISupportInitialize ) ( this.numericPageCount ) ).EndInit ( );
			this.status.ResumeLayout ( false );
			this.status.PerformLayout ( );
			this.ResumeLayout ( false );
			this.PerformLayout ( );

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.Button cmdSearch;
		private System.Windows.Forms.TextBox txtKeyWord;
		private System.Windows.Forms.Label lblKeyWord;
		private System.Windows.Forms.SplitContainer split1;
		private System.Windows.Forms.StatusStrip status;
		private System.Windows.Forms.ToolStripStatusLabel lblInfo;
		private System.Windows.Forms.ToolStripStatusLabel lblTime;
		private System.Windows.Forms.NumericUpDown numericPageCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdStop;
		private System.Windows.Forms.SplitContainer split2;
		private System.Windows.Forms.ListBox listPage;
		private System.Windows.Forms.Button cmdSpider;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
	}
}
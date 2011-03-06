namespace zoyobar.shared.panzer.test.web.ib
{
	partial class FormIEBrowser3
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
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog ( );
			this.webBrowser = new System.Windows.Forms.WebBrowser ( );
			this.split1 = new System.Windows.Forms.SplitContainer ( );
			this.cmdTest = new System.Windows.Forms.Button ( );
			( ( System.ComponentModel.ISupportInitialize ) ( this.split1 ) ).BeginInit ( );
			this.split1.Panel1.SuspendLayout ( );
			this.split1.Panel2.SuspendLayout ( );
			this.split1.SuspendLayout ( );
			this.SuspendLayout ( );
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.Location = new System.Drawing.Point ( 0, 0 );
			this.webBrowser.MinimumSize = new System.Drawing.Size ( 20, 20 );
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size ( 542, 312 );
			this.webBrowser.TabIndex = 2;
			// 
			// split1
			// 
			this.split1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.split1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.split1.Location = new System.Drawing.Point ( 0, 0 );
			this.split1.Name = "split1";
			this.split1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// split1.Panel1
			// 
			this.split1.Panel1.Controls.Add ( this.webBrowser );
			// 
			// split1.Panel2
			// 
			this.split1.Panel2.Controls.Add ( this.cmdTest );
			this.split1.Panel2MinSize = 100;
			this.split1.Size = new System.Drawing.Size ( 542, 429 );
			this.split1.SplitterDistance = 312;
			this.split1.TabIndex = 3;
			// 
			// cmdTest
			// 
			this.cmdTest.Location = new System.Drawing.Point ( 455, 3 );
			this.cmdTest.Name = "cmdTest";
			this.cmdTest.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdTest.TabIndex = 0;
			this.cmdTest.Text = "test";
			this.cmdTest.UseVisualStyleBackColor = true;
			this.cmdTest.Click += new System.EventHandler ( this.cmdTest_Click );
			// 
			// FormIEBrowser3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 542, 429 );
			this.Controls.Add ( this.split1 );
			this.Name = "FormIEBrowser3";
			this.Text = "FormIEBrowser3";
			this.split1.Panel1.ResumeLayout ( false );
			this.split1.Panel2.ResumeLayout ( false );
			( ( System.ComponentModel.ISupportInitialize ) ( this.split1 ) ).EndInit ( );
			this.split1.ResumeLayout ( false );
			this.ResumeLayout ( false );

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.SplitContainer split1;
		private System.Windows.Forms.Button cmdTest;
	}
}
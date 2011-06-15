namespace zoyobar.shared.panzer.test.web.ib
{
	partial class FormIEBrowser5
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
			this.textBox1 = new System.Windows.Forms.TextBox ( );
			this.button1 = new System.Windows.Forms.Button ( );
			this.cmdReplay = new System.Windows.Forms.Button ( );
			this.cmdEnd = new System.Windows.Forms.Button ( );
			this.cmdGetActions = new System.Windows.Forms.Button ( );
			this.cmdN = new System.Windows.Forms.Button ( );
			this.cmdBegin = new System.Windows.Forms.Button ( );
			this.button2 = new System.Windows.Forms.Button ( );
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
			this.webBrowser.Url = new System.Uri ( "http://www.baidu.com", System.UriKind.Absolute );
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
			this.split1.Panel2.Controls.Add ( this.textBox1 );
			this.split1.Panel2.Controls.Add ( this.button1 );
			this.split1.Panel2.Controls.Add ( this.button2 );
			this.split1.Panel2.Controls.Add ( this.cmdReplay );
			this.split1.Panel2.Controls.Add ( this.cmdEnd );
			this.split1.Panel2.Controls.Add ( this.cmdGetActions );
			this.split1.Panel2.Controls.Add ( this.cmdN );
			this.split1.Panel2.Controls.Add ( this.cmdBegin );
			this.split1.Panel2MinSize = 100;
			this.split1.Size = new System.Drawing.Size ( 542, 429 );
			this.split1.SplitterDistance = 312;
			this.split1.TabIndex = 3;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point ( 12, 80 );
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size ( 450, 21 );
			this.textBox1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point ( 455, 3 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size ( 75, 23 );
			this.button1.TabIndex = 0;
			this.button1.Text = "Replay";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler ( this.button1_Click );
			// 
			// cmdReplay
			// 
			this.cmdReplay.Location = new System.Drawing.Point ( 174, 2 );
			this.cmdReplay.Name = "cmdReplay";
			this.cmdReplay.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdReplay.TabIndex = 0;
			this.cmdReplay.Text = "Replay";
			this.cmdReplay.UseVisualStyleBackColor = true;
			this.cmdReplay.Click += new System.EventHandler ( this.cmdReplay_Click );
			// 
			// cmdEnd
			// 
			this.cmdEnd.Location = new System.Drawing.Point ( 93, 2 );
			this.cmdEnd.Name = "cmdEnd";
			this.cmdEnd.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdEnd.TabIndex = 0;
			this.cmdEnd.Text = "End";
			this.cmdEnd.UseVisualStyleBackColor = true;
			this.cmdEnd.Click += new System.EventHandler ( this.cmdEnd_Click );
			// 
			// cmdGetActions
			// 
			this.cmdGetActions.Location = new System.Drawing.Point ( 93, 31 );
			this.cmdGetActions.Name = "cmdGetActions";
			this.cmdGetActions.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdGetActions.TabIndex = 0;
			this.cmdGetActions.Text = "GetActions";
			this.cmdGetActions.UseVisualStyleBackColor = true;
			this.cmdGetActions.Click += new System.EventHandler ( this.cmdGetActions_Click );
			// 
			// cmdN
			// 
			this.cmdN.Location = new System.Drawing.Point ( 12, 31 );
			this.cmdN.Name = "cmdN";
			this.cmdN.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdN.TabIndex = 0;
			this.cmdN.Text = "N";
			this.cmdN.UseVisualStyleBackColor = true;
			this.cmdN.Click += new System.EventHandler ( this.cmdN_Click );
			// 
			// cmdBegin
			// 
			this.cmdBegin.Location = new System.Drawing.Point ( 12, 2 );
			this.cmdBegin.Name = "cmdBegin";
			this.cmdBegin.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdBegin.TabIndex = 0;
			this.cmdBegin.Text = "Begin";
			this.cmdBegin.UseVisualStyleBackColor = true;
			this.cmdBegin.Click += new System.EventHandler ( this.cmdBegin_Click );
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point ( 255, 3 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size ( 75, 23 );
			this.button2.TabIndex = 0;
			this.button2.Text = "EReplay";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler ( this.button2_Click );
			// 
			// FormIEBrowser5
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 542, 429 );
			this.Controls.Add ( this.split1 );
			this.Name = "FormIEBrowser5";
			this.Text = "FormIEBrowser5";
			this.split1.Panel1.ResumeLayout ( false );
			this.split1.Panel2.ResumeLayout ( false );
			this.split1.Panel2.PerformLayout ( );
			( ( System.ComponentModel.ISupportInitialize ) ( this.split1 ) ).EndInit ( );
			this.split1.ResumeLayout ( false );
			this.ResumeLayout ( false );

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.SplitContainer split1;
		private System.Windows.Forms.Button cmdBegin;
		private System.Windows.Forms.Button cmdReplay;
		private System.Windows.Forms.Button cmdEnd;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button cmdN;
		private System.Windows.Forms.Button cmdGetActions;
		private System.Windows.Forms.Button button2;
	}
}
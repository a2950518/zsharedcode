namespace zoyobar.shared.panzer.test.web.ib
{
	partial class FormVCode
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
			this.pictureBox = new System.Windows.Forms.PictureBox ( );
			this.cmdOK = new System.Windows.Forms.Button ( );
			this.txtVCode = new System.Windows.Forms.TextBox ( );
			( ( System.ComponentModel.ISupportInitialize ) ( this.pictureBox ) ).BeginInit ( );
			this.SuspendLayout ( );
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.pictureBox.Location = new System.Drawing.Point ( 12, 12 );
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size ( 260, 209 );
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Location = new System.Drawing.Point ( 197, 227 );
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "确定";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler ( this.cmdOK_Click );
			// 
			// txtVCode
			// 
			this.txtVCode.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtVCode.Location = new System.Drawing.Point ( 12, 229 );
			this.txtVCode.Name = "txtVCode";
			this.txtVCode.Size = new System.Drawing.Size ( 179, 21 );
			this.txtVCode.TabIndex = 2;
			// 
			// FormVCode
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 284, 262 );
			this.Controls.Add ( this.txtVCode );
			this.Controls.Add ( this.cmdOK );
			this.Controls.Add ( this.pictureBox );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormVCode";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormVCode";
			this.TopMost = true;
			( ( System.ComponentModel.ISupportInitialize ) ( this.pictureBox ) ).EndInit ( );
			this.ResumeLayout ( false );
			this.PerformLayout ( );

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.TextBox txtVCode;
	}
}
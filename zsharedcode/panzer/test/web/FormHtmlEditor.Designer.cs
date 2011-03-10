namespace zoyobar.shared.panzer.test.web
{
	partial class FormHtmlEditor
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
			this.browser = new System.Windows.Forms.WebBrowser ( );
			this.cmdBackColor = new System.Windows.Forms.Button ( );
			this.cmdBold = new System.Windows.Forms.Button ( );
			this.toolStrip1 = new System.Windows.Forms.ToolStrip ( );
			this.SuspendLayout ( );
			// 
			// browser
			// 
			this.browser.Location = new System.Drawing.Point ( 161, 12 );
			this.browser.MinimumSize = new System.Drawing.Size ( 20, 20 );
			this.browser.Name = "browser";
			this.browser.Size = new System.Drawing.Size ( 250, 250 );
			this.browser.TabIndex = 0;
			// 
			// cmdBackColor
			// 
			this.cmdBackColor.Location = new System.Drawing.Point ( 417, 227 );
			this.cmdBackColor.Name = "cmdBackColor";
			this.cmdBackColor.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdBackColor.TabIndex = 1;
			this.cmdBackColor.Text = "背景色";
			this.cmdBackColor.UseVisualStyleBackColor = true;
			this.cmdBackColor.Click += new System.EventHandler ( this.cmdBackColor_Click );
			// 
			// cmdBold
			// 
			this.cmdBold.Location = new System.Drawing.Point ( 417, 185 );
			this.cmdBold.Name = "cmdBold";
			this.cmdBold.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdBold.TabIndex = 1;
			this.cmdBold.Text = "粗体";
			this.cmdBold.UseVisualStyleBackColor = true;
			this.cmdBold.Click += new System.EventHandler ( this.cmdBold_Click );
			// 
			// toolStrip1
			// 
			this.toolStrip1.Location = new System.Drawing.Point ( 0, 0 );
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size ( 504, 25 );
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// FormHtmlEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 504, 298 );
			this.Controls.Add ( this.toolStrip1 );
			this.Controls.Add ( this.cmdBold );
			this.Controls.Add ( this.cmdBackColor );
			this.Controls.Add ( this.browser );
			this.Name = "FormHtmlEditor";
			this.Text = "FormHtmlEditor";
			this.ResumeLayout ( false );
			this.PerformLayout ( );

		}

		#endregion

		private System.Windows.Forms.WebBrowser browser;
		private System.Windows.Forms.Button cmdBackColor;
		private System.Windows.Forms.Button cmdBold;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
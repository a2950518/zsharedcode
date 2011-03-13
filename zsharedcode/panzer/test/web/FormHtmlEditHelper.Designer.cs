namespace zoyobar.shared.panzer.test.web
{
	partial class FormHtmlEditHelper
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
			this.htmlEditor1 = new zoyobar.shared.panzer.test.web.HtmlEditor ( );
			this.SuspendLayout ( );
			// 
			// htmlEditor1
			// 
			this.htmlEditor1.Location = new System.Drawing.Point ( 12, 12 );
			this.htmlEditor1.Name = "htmlEditor1";
			this.htmlEditor1.Size = new System.Drawing.Size ( 375, 247 );
			this.htmlEditor1.TabIndex = 0;
			// 
			// FormHtmlEditHelper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 504, 298 );
			this.Controls.Add ( this.htmlEditor1 );
			this.Name = "FormHtmlEditHelper";
			this.Text = "FormHtmlEditor";
			this.ResumeLayout ( false );

		}

		#endregion

		private HtmlEditor htmlEditor1;

	}
}
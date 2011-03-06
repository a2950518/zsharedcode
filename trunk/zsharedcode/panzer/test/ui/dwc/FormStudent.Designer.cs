namespace zoyobar.shared.panzer.test.ui.dwc
{
	partial class FormStudent
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
			this.gridStudent = new System.Windows.Forms.DataGridView ();
			this.cmdSave = new System.Windows.Forms.Button ();
			this.cmdFill = new System.Windows.Forms.Button ();
			this.cmdAll = new System.Windows.Forms.Button ();
			this.cmdNone = new System.Windows.Forms.Button ();
			this.cmdTurn = new System.Windows.Forms.Button ();
			( ( System.ComponentModel.ISupportInitialize ) ( this.gridStudent ) ).BeginInit ();
			this.SuspendLayout ();
			// 
			// gridStudent
			// 
			this.gridStudent.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.gridStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridStudent.Location = new System.Drawing.Point ( 12, 12 );
			this.gridStudent.Name = "gridStudent";
			this.gridStudent.RowTemplate.Height = 23;
			this.gridStudent.Size = new System.Drawing.Size ( 586, 258 );
			this.gridStudent.TabIndex = 0;
			// 
			// cmdSave
			// 
			this.cmdSave.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdSave.Location = new System.Drawing.Point ( 523, 276 );
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdSave.TabIndex = 1;
			this.cmdSave.Text = "保存";
			this.cmdSave.UseVisualStyleBackColor = true;
			// 
			// cmdFill
			// 
			this.cmdFill.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.cmdFill.Location = new System.Drawing.Point ( 12, 276 );
			this.cmdFill.Name = "cmdFill";
			this.cmdFill.Size = new System.Drawing.Size ( 75, 23 );
			this.cmdFill.TabIndex = 1;
			this.cmdFill.Text = "重新载入";
			this.cmdFill.UseVisualStyleBackColor = true;
			// 
			// cmdAll
			// 
			this.cmdAll.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdAll.Location = new System.Drawing.Point ( 477, 276 );
			this.cmdAll.Name = "cmdAll";
			this.cmdAll.Size = new System.Drawing.Size ( 40, 23 );
			this.cmdAll.TabIndex = 1;
			this.cmdAll.Text = "全选";
			this.cmdAll.UseVisualStyleBackColor = true;
			// 
			// cmdNone
			// 
			this.cmdNone.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdNone.Location = new System.Drawing.Point ( 431, 276 );
			this.cmdNone.Name = "cmdNone";
			this.cmdNone.Size = new System.Drawing.Size ( 40, 23 );
			this.cmdNone.TabIndex = 1;
			this.cmdNone.Text = "不选";
			this.cmdNone.UseVisualStyleBackColor = true;
			// 
			// cmdTurn
			// 
			this.cmdTurn.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmdTurn.Location = new System.Drawing.Point ( 385, 276 );
			this.cmdTurn.Name = "cmdTurn";
			this.cmdTurn.Size = new System.Drawing.Size ( 40, 23 );
			this.cmdTurn.TabIndex = 1;
			this.cmdTurn.Text = "反选";
			this.cmdTurn.UseVisualStyleBackColor = true;
			// 
			// FormStudent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 610, 311 );
			this.Controls.Add ( this.cmdFill );
			this.Controls.Add ( this.cmdTurn );
			this.Controls.Add ( this.cmdNone );
			this.Controls.Add ( this.cmdAll );
			this.Controls.Add ( this.cmdSave );
			this.Controls.Add ( this.gridStudent );
			this.Name = "FormStudent";
			this.Text = "FormStudent";
			( ( System.ComponentModel.ISupportInitialize ) ( this.gridStudent ) ).EndInit ();
			this.ResumeLayout ( false );

		}

		#endregion

		private System.Windows.Forms.DataGridView gridStudent;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.Button cmdFill;
		private System.Windows.Forms.Button cmdAll;
		private System.Windows.Forms.Button cmdNone;
		private System.Windows.Forms.Button cmdTurn;
	}
}
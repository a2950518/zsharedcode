using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using zoyobar.shared.panzer.web;

namespace zoyobar.shared.panzer.test.web
{

	public partial class HtmlEditor : UserControl
	{
		private readonly HtmlEditHelper editHelper;
		private Color selectedBackColor = Color.Empty;
		private Color selectedForeColor = Color.Empty;
		private string selectedFontName = string.Empty;
		private int selectedFontSize = 0;
		private string selectedJust = string.Empty;

		public HtmlEditor ( )
		{
			InitializeComponent ( );

			this.editHelper = new HtmlEditHelper ( this.browser, "web/html.editor.htm" );
		}

		private void setFont ( string name, int size )
		{

			if ( name == string.Empty && size == 0 )
			{
				this.toolFont.ToolTipText = "请选择一种字体或者大小";
				return;
			}

			if ( null != string.Empty )
			{
				this.selectedFontName = name;
				this.editHelper.FontName ( name );
			}

			if ( size != 0 )
			{
				this.selectedFontSize = size;
				this.editHelper.FontSize ( size );
			}

			this.toolFont.Text = name + ( size == 0 ? string.Empty : " " + size.ToString ( ) );
			this.toolFont.ToolTipText = string.Format ( "设置字体 {0}", this.toolFont.Text );
		}

		private void setJust ( string just )
		{

			if ( just == string.Empty )
			{
				this.toolJust.ToolTipText = "请选择一种对齐方式";
				return;
			}

			this.selectedJust = just;

			this.toolJust.Text = just;
			this.toolJust.ToolTipText = string.Format ( "设置对齐方式 {0}", just );

			switch ( just )
			{
				case "左对齐":
					this.editHelper.JustifyLeft ( );
					break;

				case "居中":
					this.editHelper.JustifyCenter ( );
					break;

				case "右对齐":
					this.editHelper.JustifyRight ( );
					break;
			}

		}

		private void setBackColor ( Color color )
		{

			if ( color == Color.Empty )
			{
				this.toolBackColor.ToolTipText = "请选择一种背景色";
				return;
			}

			this.selectedBackColor = color;

			this.toolBackColor.ForeColor = color;
			this.toolBackColor.ToolTipText = string.Format ( "设置背景色 {0}", color );
			this.editHelper.BackColor ( color );
		}

		private void setForeColor ( Color color )
		{

			if ( color == Color.Empty )
			{
				this.toolForeColor.ToolTipText = "请选择一种前景色";
				return;
			}

			this.selectedForeColor = color;

			this.toolForeColor.ForeColor = color;
			this.toolForeColor.ToolTipText = string.Format ( "设置前景色 {0}", color );
			this.editHelper.ForeColor ( color );
		}

		private void toolBold_Click ( object sender, EventArgs e )
		{ this.editHelper.Bold ( ); }

		private void toolBackColor_ButtonClick ( object sender, EventArgs e )
		{ this.setBackColor ( this.selectedBackColor ); }

		private void toolSelectBackColor_Click ( object sender, EventArgs e )
		{

			if ( this.colorDialog.ShowDialog ( ) == DialogResult.Cancel )
				return;

			this.setBackColor ( this.colorDialog.Color );
		}

		private void toolForeColorRed_Click ( object sender, EventArgs e )
		{ this.setForeColor ( Color.Red ); }

		private void toolForeColorBlue_Click ( object sender, EventArgs e )
		{ this.setForeColor ( Color.DarkSlateBlue ); }

		private void toolForeColorGreen_Click ( object sender, EventArgs e )
		{ this.setForeColor ( Color.ForestGreen ); }

		private void toolSelectForeColor_Click ( object sender, EventArgs e )
		{

			if ( this.colorDialog.ShowDialog ( ) == DialogResult.Cancel )
				return;

			this.setForeColor ( this.colorDialog.Color );
		}

		private void toolForeColor_ButtonClick ( object sender, EventArgs e )
		{ this.setForeColor ( this.selectedForeColor ); }

		private void toolForeColorOlive_Click ( object sender, EventArgs e )
		{ this.setForeColor ( Color.Olive ); }

		private void toolForeColorGray_Click ( object sender, EventArgs e )
		{ this.setForeColor ( Color.DimGray ); }

		private void toolBackColorGray_Click ( object sender, EventArgs e )
		{ this.setBackColor ( Color.DarkGray ); }

		private void toolBackColorBlack_Click ( object sender, EventArgs e )
		{ this.setBackColor ( Color.Black ); }

		private void toolBackColorGoldenrod_Click ( object sender, EventArgs e )
		{ this.setBackColor ( Color.PaleGoldenrod ); }

		private void toolBackColorLightSteelBlue_Click ( object sender, EventArgs e )
		{ this.setBackColor ( Color.LightSteelBlue ); }

		private void toolBackColorThistle_Click ( object sender, EventArgs e )
		{ this.setBackColor ( Color.Thistle ); }

		private void toolItalic_Click ( object sender, EventArgs e )
		{ this.editHelper.Italic ( ); }

		private void toolUnderline_Click ( object sender, EventArgs e )
		{ this.editHelper.Underline ( ); }

		private void toolJustLeft_Click ( object sender, EventArgs e )
		{ this.setJust ( this.toolJustLeft.Text ); }

		private void toolJustCenter_Click ( object sender, EventArgs e )
		{ this.setJust ( this.toolJustCenter.Text ); }

		private void toolJustRight_Click ( object sender, EventArgs e )
		{ this.setJust ( this.toolJustRight.Text ); }

		private void toolLink_Click ( object sender, EventArgs e )
		{ this.editHelper.CreateLink ( ); }

		private void toolImage_Click ( object sender, EventArgs e )
		{ this.editHelper.InsertImage ( ); }

		private void toolFont_Click ( object sender, EventArgs e )
		{ this.setFont ( this.selectedFontName, this.selectedFontSize ); }

		private void toolFontHead1_Click ( object sender, EventArgs e )
		{ this.setFont ( string.Empty, 6 ); }

		private void toolFontHead2_Click ( object sender, EventArgs e )
		{ this.setFont ( string.Empty, 5 ); }

		private void toolFontHead3_Click ( object sender, EventArgs e )
		{ this.setFont ( string.Empty, 4 ); }

		private void toolFontHead4_Click ( object sender, EventArgs e )
		{ this.setFont ( string.Empty, 3 ); }

		private void toolSelectFont_Click ( object sender, EventArgs e )
		{

			if ( this.fontDialog.ShowDialog ( ) == DialogResult.Cancel )
				return;

			this.setFont ( this.fontDialog.Font.Name, 0 );
		}

		private void toolEditCopy_Click ( object sender, EventArgs e )
		{ this.editHelper.Copy ( ); }

		private void toolEditCut_Click ( object sender, EventArgs e )
		{ this.editHelper.Cut ( ); }

		private void toolEditPaste_Click ( object sender, EventArgs e )
		{ this.editHelper.Paste ( ); }

		private void toolEditDelete_Click ( object sender, EventArgs e )
		{ this.editHelper.Delete ( ); }

		private void toolEditRemoveFormat_Click ( object sender, EventArgs e )
		{ this.editHelper.RemoveFormat ( ); }

		private void menuUndo_Click ( object sender, EventArgs e )
		{ this.editHelper.Undo ( ); }

		private void toolIndent_Click ( object sender, EventArgs e )
		{ this.editHelper.Indent ( ); }

		private void toolOutdent_Click ( object sender, EventArgs e )
		{ this.editHelper.Outdent ( ); }

		private void toolInsertP_Click ( object sender, EventArgs e )
		{ this.editHelper.InsertParagraph ( ); }

		private void toolInsertOrderedList_Click ( object sender, EventArgs e )
		{ this.editHelper.InsertOrderedList ( ); }

		private void toolInsertUnorderedList_Click ( object sender, EventArgs e )
		{ this.editHelper.InsertUnorderedList ( ); }

	}

}

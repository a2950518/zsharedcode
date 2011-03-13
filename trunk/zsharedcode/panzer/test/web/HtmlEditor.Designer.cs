namespace zoyobar.shared.panzer.test.web
{
	partial class HtmlEditor
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent ( )
		{
			this.tool = new System.Windows.Forms.ToolStrip ( );
			this.toolFont = new System.Windows.Forms.ToolStripSplitButton ( );
			this.toolFontHead1 = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolFontHead2 = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolFontHead3 = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolFontHead4 = new System.Windows.Forms.ToolStripMenuItem ( );
			this.line3 = new System.Windows.Forms.ToolStripSeparator ( );
			this.toolSelectFont = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolEdit = new System.Windows.Forms.ToolStripSplitButton ( );
			this.menuUndo = new System.Windows.Forms.ToolStripMenuItem ( );
			this.line6 = new System.Windows.Forms.ToolStripSeparator ( );
			this.toolEditCopy = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolEditCut = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolEditPaste = new System.Windows.Forms.ToolStripMenuItem ( );
			this.line4 = new System.Windows.Forms.ToolStripSeparator ( );
			this.toolEditDelete = new System.Windows.Forms.ToolStripMenuItem ( );
			this.line5 = new System.Windows.Forms.ToolStripSeparator ( );
			this.toolEditRemoveFormat = new System.Windows.Forms.ToolStripMenuItem ( );
			this.line7 = new System.Windows.Forms.ToolStripSeparator ( );
			this.toolIndent = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolOutdent = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolBold = new System.Windows.Forms.ToolStripButton ( );
			this.toolItalic = new System.Windows.Forms.ToolStripButton ( );
			this.toolUnderline = new System.Windows.Forms.ToolStripButton ( );
			this.toolForeColor = new System.Windows.Forms.ToolStripSplitButton ( );
			this.toolForeColorRed = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolForeColorBlue = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolForeColorGreen = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolForeColorOlive = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolForeColorGray = new System.Windows.Forms.ToolStripMenuItem ( );
			this.line2 = new System.Windows.Forms.ToolStripSeparator ( );
			this.toolSelectForeColor = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolBackColor = new System.Windows.Forms.ToolStripSplitButton ( );
			this.toolBackColorThistle = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolBackColorLightSteelBlue = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolBackColorGoldenrod = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolBackColorGray = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolBackColorBlack = new System.Windows.Forms.ToolStripMenuItem ( );
			this.line1 = new System.Windows.Forms.ToolStripSeparator ( );
			this.toolSelectBackColor = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolImage = new System.Windows.Forms.ToolStripButton ( );
			this.toolLink = new System.Windows.Forms.ToolStripButton ( );
			this.toolInsert = new System.Windows.Forms.ToolStripSplitButton ( );
			this.toolInsertP = new System.Windows.Forms.ToolStripMenuItem ( );
			this.line8 = new System.Windows.Forms.ToolStripSeparator ( );
			this.toolInsertOrderedList = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolInsertUnorderedList = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolJust = new System.Windows.Forms.ToolStripSplitButton ( );
			this.toolJustLeft = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolJustCenter = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolJustRight = new System.Windows.Forms.ToolStripMenuItem ( );
			this.browser = new System.Windows.Forms.WebBrowser ( );
			this.colorDialog = new System.Windows.Forms.ColorDialog ( );
			this.fontDialog = new System.Windows.Forms.FontDialog ( );
			this.tool.SuspendLayout ( );
			this.SuspendLayout ( );
			// 
			// tool
			// 
			this.tool.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tool.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.toolFont,
            this.toolEdit,
            this.toolBold,
            this.toolItalic,
            this.toolUnderline,
            this.toolForeColor,
            this.toolBackColor,
            this.toolImage,
            this.toolLink,
            this.toolInsert,
            this.toolJust} );
			this.tool.Location = new System.Drawing.Point ( 0, 0 );
			this.tool.Name = "tool";
			this.tool.Size = new System.Drawing.Size ( 547, 25 );
			this.tool.TabIndex = 4;
			this.tool.Text = "toolStrip1";
			// 
			// toolFont
			// 
			this.toolFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolFont.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.toolFontHead1,
            this.toolFontHead2,
            this.toolFontHead3,
            this.toolFontHead4,
            this.line3,
            this.toolSelectFont} );
			this.toolFont.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolFont.Name = "toolFont";
			this.toolFont.Size = new System.Drawing.Size ( 48, 22 );
			this.toolFont.Text = "字体";
			this.toolFont.ToolTipText = "请选择一种字体";
			this.toolFont.Click += new System.EventHandler ( this.toolFont_Click );
			// 
			// toolFontHead1
			// 
			this.toolFontHead1.Name = "toolFontHead1";
			this.toolFontHead1.Size = new System.Drawing.Size ( 152, 22 );
			this.toolFontHead1.Text = "标题 1";
			this.toolFontHead1.Click += new System.EventHandler ( this.toolFontHead1_Click );
			// 
			// toolFontHead2
			// 
			this.toolFontHead2.Name = "toolFontHead2";
			this.toolFontHead2.Size = new System.Drawing.Size ( 152, 22 );
			this.toolFontHead2.Text = "标题 2";
			this.toolFontHead2.Click += new System.EventHandler ( this.toolFontHead2_Click );
			// 
			// toolFontHead3
			// 
			this.toolFontHead3.Name = "toolFontHead3";
			this.toolFontHead3.Size = new System.Drawing.Size ( 152, 22 );
			this.toolFontHead3.Text = "标题 3";
			this.toolFontHead3.Click += new System.EventHandler ( this.toolFontHead3_Click );
			// 
			// toolFontHead4
			// 
			this.toolFontHead4.Name = "toolFontHead4";
			this.toolFontHead4.Size = new System.Drawing.Size ( 152, 22 );
			this.toolFontHead4.Text = "标题 4";
			this.toolFontHead4.Click += new System.EventHandler ( this.toolFontHead4_Click );
			// 
			// line3
			// 
			this.line3.Name = "line3";
			this.line3.Size = new System.Drawing.Size ( 149, 6 );
			// 
			// toolSelectFont
			// 
			this.toolSelectFont.Name = "toolSelectFont";
			this.toolSelectFont.Size = new System.Drawing.Size ( 152, 22 );
			this.toolSelectFont.Text = "选择字体 ...";
			this.toolSelectFont.Click += new System.EventHandler ( this.toolSelectFont_Click );
			// 
			// toolEdit
			// 
			this.toolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolEdit.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.menuUndo,
            this.line6,
            this.toolEditCopy,
            this.toolEditCut,
            this.toolEditPaste,
            this.line4,
            this.toolEditDelete,
            this.line5,
            this.toolEditRemoveFormat,
            this.line7,
            this.toolIndent,
            this.toolOutdent} );
			this.toolEdit.Name = "toolEdit";
			this.toolEdit.Size = new System.Drawing.Size ( 48, 22 );
			this.toolEdit.Text = "编辑";
			// 
			// menuUndo
			// 
			this.menuUndo.Name = "menuUndo";
			this.menuUndo.Size = new System.Drawing.Size ( 124, 22 );
			this.menuUndo.Text = "撤销";
			this.menuUndo.Click += new System.EventHandler ( this.menuUndo_Click );
			// 
			// line6
			// 
			this.line6.Name = "line6";
			this.line6.Size = new System.Drawing.Size ( 121, 6 );
			// 
			// toolEditCopy
			// 
			this.toolEditCopy.Name = "toolEditCopy";
			this.toolEditCopy.Size = new System.Drawing.Size ( 124, 22 );
			this.toolEditCopy.Text = "复制";
			this.toolEditCopy.Click += new System.EventHandler ( this.toolEditCopy_Click );
			// 
			// toolEditCut
			// 
			this.toolEditCut.Name = "toolEditCut";
			this.toolEditCut.Size = new System.Drawing.Size ( 124, 22 );
			this.toolEditCut.Text = "剪切";
			this.toolEditCut.Click += new System.EventHandler ( this.toolEditCut_Click );
			// 
			// toolEditPaste
			// 
			this.toolEditPaste.Name = "toolEditPaste";
			this.toolEditPaste.Size = new System.Drawing.Size ( 124, 22 );
			this.toolEditPaste.Text = "粘贴";
			this.toolEditPaste.Click += new System.EventHandler ( this.toolEditPaste_Click );
			// 
			// line4
			// 
			this.line4.Name = "line4";
			this.line4.Size = new System.Drawing.Size ( 121, 6 );
			// 
			// toolEditDelete
			// 
			this.toolEditDelete.Name = "toolEditDelete";
			this.toolEditDelete.Size = new System.Drawing.Size ( 124, 22 );
			this.toolEditDelete.Text = "删除";
			this.toolEditDelete.Click += new System.EventHandler ( this.toolEditDelete_Click );
			// 
			// line5
			// 
			this.line5.Name = "line5";
			this.line5.Size = new System.Drawing.Size ( 121, 6 );
			// 
			// toolEditRemoveFormat
			// 
			this.toolEditRemoveFormat.Name = "toolEditRemoveFormat";
			this.toolEditRemoveFormat.Size = new System.Drawing.Size ( 124, 22 );
			this.toolEditRemoveFormat.Text = "清楚格式";
			this.toolEditRemoveFormat.Click += new System.EventHandler ( this.toolEditRemoveFormat_Click );
			// 
			// line7
			// 
			this.line7.Name = "line7";
			this.line7.Size = new System.Drawing.Size ( 121, 6 );
			// 
			// toolIndent
			// 
			this.toolIndent.Name = "toolIndent";
			this.toolIndent.Size = new System.Drawing.Size ( 124, 22 );
			this.toolIndent.Text = "缩进";
			this.toolIndent.Click += new System.EventHandler ( this.toolIndent_Click );
			// 
			// toolOutdent
			// 
			this.toolOutdent.Name = "toolOutdent";
			this.toolOutdent.Size = new System.Drawing.Size ( 124, 22 );
			this.toolOutdent.Text = "反缩进";
			this.toolOutdent.Click += new System.EventHandler ( this.toolOutdent_Click );
			// 
			// toolBold
			// 
			this.toolBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolBold.Font = new System.Drawing.Font ( "微软雅黑", 9F, System.Drawing.FontStyle.Bold );
			this.toolBold.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBold.Name = "toolBold";
			this.toolBold.Size = new System.Drawing.Size ( 23, 22 );
			this.toolBold.Text = "B";
			this.toolBold.ToolTipText = "切换粗体样式";
			this.toolBold.Click += new System.EventHandler ( this.toolBold_Click );
			// 
			// toolItalic
			// 
			this.toolItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolItalic.Font = new System.Drawing.Font ( "微软雅黑", 9F, System.Drawing.FontStyle.Italic );
			this.toolItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolItalic.Name = "toolItalic";
			this.toolItalic.Size = new System.Drawing.Size ( 23, 22 );
			this.toolItalic.Text = "I";
			this.toolItalic.ToolTipText = "切换斜体样式";
			this.toolItalic.Click += new System.EventHandler ( this.toolItalic_Click );
			// 
			// toolUnderline
			// 
			this.toolUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolUnderline.Font = new System.Drawing.Font ( "微软雅黑", 9F, System.Drawing.FontStyle.Underline );
			this.toolUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolUnderline.Name = "toolUnderline";
			this.toolUnderline.Size = new System.Drawing.Size ( 23, 22 );
			this.toolUnderline.Text = "U";
			this.toolUnderline.Click += new System.EventHandler ( this.toolUnderline_Click );
			// 
			// toolForeColor
			// 
			this.toolForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolForeColor.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.toolForeColorRed,
            this.toolForeColorBlue,
            this.toolForeColorGreen,
            this.toolForeColorOlive,
            this.toolForeColorGray,
            this.line2,
            this.toolSelectForeColor} );
			this.toolForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolForeColor.Name = "toolForeColor";
			this.toolForeColor.Size = new System.Drawing.Size ( 60, 22 );
			this.toolForeColor.Text = "前景色";
			this.toolForeColor.ToolTipText = "请选择一种前景色";
			this.toolForeColor.ButtonClick += new System.EventHandler ( this.toolForeColor_ButtonClick );
			// 
			// toolForeColorRed
			// 
			this.toolForeColorRed.ForeColor = System.Drawing.Color.OrangeRed;
			this.toolForeColorRed.Name = "toolForeColorRed";
			this.toolForeColorRed.Size = new System.Drawing.Size ( 113, 22 );
			this.toolForeColorRed.Text = "红色";
			this.toolForeColorRed.Click += new System.EventHandler ( this.toolForeColorRed_Click );
			// 
			// toolForeColorBlue
			// 
			this.toolForeColorBlue.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.toolForeColorBlue.Name = "toolForeColorBlue";
			this.toolForeColorBlue.Size = new System.Drawing.Size ( 113, 22 );
			this.toolForeColorBlue.Text = "紫色";
			this.toolForeColorBlue.Click += new System.EventHandler ( this.toolForeColorBlue_Click );
			// 
			// toolForeColorGreen
			// 
			this.toolForeColorGreen.ForeColor = System.Drawing.Color.ForestGreen;
			this.toolForeColorGreen.Name = "toolForeColorGreen";
			this.toolForeColorGreen.Size = new System.Drawing.Size ( 113, 22 );
			this.toolForeColorGreen.Text = "绿色";
			this.toolForeColorGreen.Click += new System.EventHandler ( this.toolForeColorGreen_Click );
			// 
			// toolForeColorOlive
			// 
			this.toolForeColorOlive.ForeColor = System.Drawing.Color.Olive;
			this.toolForeColorOlive.Name = "toolForeColorOlive";
			this.toolForeColorOlive.Size = new System.Drawing.Size ( 113, 22 );
			this.toolForeColorOlive.Text = "棕色";
			this.toolForeColorOlive.Click += new System.EventHandler ( this.toolForeColorOlive_Click );
			// 
			// toolForeColorGray
			// 
			this.toolForeColorGray.ForeColor = System.Drawing.Color.DimGray;
			this.toolForeColorGray.Name = "toolForeColorGray";
			this.toolForeColorGray.Size = new System.Drawing.Size ( 113, 22 );
			this.toolForeColorGray.Text = "灰色";
			this.toolForeColorGray.Click += new System.EventHandler ( this.toolForeColorGray_Click );
			// 
			// line2
			// 
			this.line2.Name = "line2";
			this.line2.Size = new System.Drawing.Size ( 110, 6 );
			// 
			// toolSelectForeColor
			// 
			this.toolSelectForeColor.Name = "toolSelectForeColor";
			this.toolSelectForeColor.Size = new System.Drawing.Size ( 113, 22 );
			this.toolSelectForeColor.Text = "更多 ...";
			this.toolSelectForeColor.Click += new System.EventHandler ( this.toolSelectForeColor_Click );
			// 
			// toolBackColor
			// 
			this.toolBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolBackColor.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.toolBackColorThistle,
            this.toolBackColorLightSteelBlue,
            this.toolBackColorGoldenrod,
            this.toolBackColorGray,
            this.toolBackColorBlack,
            this.line1,
            this.toolSelectBackColor} );
			this.toolBackColor.Name = "toolBackColor";
			this.toolBackColor.Size = new System.Drawing.Size ( 60, 22 );
			this.toolBackColor.Text = "背景色";
			this.toolBackColor.ToolTipText = "请选择一种背景色";
			this.toolBackColor.ButtonClick += new System.EventHandler ( this.toolBackColor_ButtonClick );
			// 
			// toolBackColorThistle
			// 
			this.toolBackColorThistle.BackColor = System.Drawing.Color.Thistle;
			this.toolBackColorThistle.ForeColor = System.Drawing.Color.Black;
			this.toolBackColorThistle.Name = "toolBackColorThistle";
			this.toolBackColorThistle.Size = new System.Drawing.Size ( 113, 22 );
			this.toolBackColorThistle.Text = "粉色";
			this.toolBackColorThistle.Click += new System.EventHandler ( this.toolBackColorThistle_Click );
			// 
			// toolBackColorLightSteelBlue
			// 
			this.toolBackColorLightSteelBlue.BackColor = System.Drawing.Color.LightSteelBlue;
			this.toolBackColorLightSteelBlue.ForeColor = System.Drawing.Color.Black;
			this.toolBackColorLightSteelBlue.Name = "toolBackColorLightSteelBlue";
			this.toolBackColorLightSteelBlue.Size = new System.Drawing.Size ( 113, 22 );
			this.toolBackColorLightSteelBlue.Text = "蓝色";
			this.toolBackColorLightSteelBlue.Click += new System.EventHandler ( this.toolBackColorLightSteelBlue_Click );
			// 
			// toolBackColorGoldenrod
			// 
			this.toolBackColorGoldenrod.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.toolBackColorGoldenrod.ForeColor = System.Drawing.Color.Black;
			this.toolBackColorGoldenrod.Name = "toolBackColorGoldenrod";
			this.toolBackColorGoldenrod.Size = new System.Drawing.Size ( 113, 22 );
			this.toolBackColorGoldenrod.Text = "黄色";
			this.toolBackColorGoldenrod.Click += new System.EventHandler ( this.toolBackColorGoldenrod_Click );
			// 
			// toolBackColorGray
			// 
			this.toolBackColorGray.BackColor = System.Drawing.Color.DarkGray;
			this.toolBackColorGray.ForeColor = System.Drawing.Color.White;
			this.toolBackColorGray.Name = "toolBackColorGray";
			this.toolBackColorGray.Size = new System.Drawing.Size ( 113, 22 );
			this.toolBackColorGray.Text = "灰色";
			this.toolBackColorGray.Click += new System.EventHandler ( this.toolBackColorGray_Click );
			// 
			// toolBackColorBlack
			// 
			this.toolBackColorBlack.BackColor = System.Drawing.Color.Black;
			this.toolBackColorBlack.ForeColor = System.Drawing.Color.White;
			this.toolBackColorBlack.Name = "toolBackColorBlack";
			this.toolBackColorBlack.Size = new System.Drawing.Size ( 113, 22 );
			this.toolBackColorBlack.Text = "黑色";
			this.toolBackColorBlack.Click += new System.EventHandler ( this.toolBackColorBlack_Click );
			// 
			// line1
			// 
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size ( 110, 6 );
			// 
			// toolSelectBackColor
			// 
			this.toolSelectBackColor.Name = "toolSelectBackColor";
			this.toolSelectBackColor.Size = new System.Drawing.Size ( 113, 22 );
			this.toolSelectBackColor.Text = "更多 ...";
			this.toolSelectBackColor.Click += new System.EventHandler ( this.toolSelectBackColor_Click );
			// 
			// toolImage
			// 
			this.toolImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolImage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolImage.Name = "toolImage";
			this.toolImage.Size = new System.Drawing.Size ( 36, 22 );
			this.toolImage.Text = "图像";
			this.toolImage.ToolTipText = "插入或设置图像";
			this.toolImage.Click += new System.EventHandler ( this.toolImage_Click );
			// 
			// toolLink
			// 
			this.toolLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolLink.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolLink.Name = "toolLink";
			this.toolLink.Size = new System.Drawing.Size ( 48, 22 );
			this.toolLink.Text = "超链接";
			this.toolLink.ToolTipText = "插入或设置超链接";
			this.toolLink.Click += new System.EventHandler ( this.toolLink_Click );
			// 
			// toolInsert
			// 
			this.toolInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolInsert.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.toolInsertP,
            this.line8,
            this.toolInsertOrderedList,
            this.toolInsertUnorderedList} );
			this.toolInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolInsert.Name = "toolInsert";
			this.toolInsert.Size = new System.Drawing.Size ( 48, 22 );
			this.toolInsert.Text = "插入";
			// 
			// toolInsertP
			// 
			this.toolInsertP.Name = "toolInsertP";
			this.toolInsertP.Size = new System.Drawing.Size ( 124, 22 );
			this.toolInsertP.Text = "段落";
			this.toolInsertP.Click += new System.EventHandler ( this.toolInsertP_Click );
			// 
			// line8
			// 
			this.line8.Name = "line8";
			this.line8.Size = new System.Drawing.Size ( 121, 6 );
			// 
			// toolInsertOrderedList
			// 
			this.toolInsertOrderedList.Name = "toolInsertOrderedList";
			this.toolInsertOrderedList.Size = new System.Drawing.Size ( 124, 22 );
			this.toolInsertOrderedList.Text = "顺序列表";
			this.toolInsertOrderedList.Click += new System.EventHandler ( this.toolInsertOrderedList_Click );
			// 
			// toolInsertUnorderedList
			// 
			this.toolInsertUnorderedList.Name = "toolInsertUnorderedList";
			this.toolInsertUnorderedList.Size = new System.Drawing.Size ( 124, 22 );
			this.toolInsertUnorderedList.Text = "无序列表";
			this.toolInsertUnorderedList.Click += new System.EventHandler ( this.toolInsertUnorderedList_Click );
			// 
			// toolJust
			// 
			this.toolJust.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolJust.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.toolJustLeft,
            this.toolJustCenter,
            this.toolJustRight} );
			this.toolJust.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolJust.Name = "toolJust";
			this.toolJust.Size = new System.Drawing.Size ( 48, 22 );
			this.toolJust.Text = "对齐";
			this.toolJust.ToolTipText = "请选择一种对齐方式";
			// 
			// toolJustLeft
			// 
			this.toolJustLeft.Name = "toolJustLeft";
			this.toolJustLeft.Size = new System.Drawing.Size ( 112, 22 );
			this.toolJustLeft.Text = "左对齐";
			this.toolJustLeft.Click += new System.EventHandler ( this.toolJustLeft_Click );
			// 
			// toolJustCenter
			// 
			this.toolJustCenter.Name = "toolJustCenter";
			this.toolJustCenter.Size = new System.Drawing.Size ( 112, 22 );
			this.toolJustCenter.Text = "居中";
			this.toolJustCenter.Click += new System.EventHandler ( this.toolJustCenter_Click );
			// 
			// toolJustRight
			// 
			this.toolJustRight.Name = "toolJustRight";
			this.toolJustRight.Size = new System.Drawing.Size ( 112, 22 );
			this.toolJustRight.Text = "右对齐";
			this.toolJustRight.Click += new System.EventHandler ( this.toolJustRight_Click );
			// 
			// browser
			// 
			this.browser.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.browser.Location = new System.Drawing.Point ( 3, 28 );
			this.browser.MinimumSize = new System.Drawing.Size ( 20, 20 );
			this.browser.Name = "browser";
			this.browser.Size = new System.Drawing.Size ( 541, 238 );
			this.browser.TabIndex = 3;
			// 
			// HtmlEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add ( this.tool );
			this.Controls.Add ( this.browser );
			this.Name = "HtmlEditor";
			this.Size = new System.Drawing.Size ( 547, 269 );
			this.tool.ResumeLayout ( false );
			this.tool.PerformLayout ( );
			this.ResumeLayout ( false );
			this.PerformLayout ( );

		}

		#endregion

		private System.Windows.Forms.ToolStrip tool;
		private System.Windows.Forms.WebBrowser browser;
		private System.Windows.Forms.ToolStripButton toolBold;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.ToolStripSplitButton toolBackColor;
		private System.Windows.Forms.ToolStripMenuItem toolSelectBackColor;
		private System.Windows.Forms.ToolStripMenuItem toolForeColorRed;
		private System.Windows.Forms.ToolStripSeparator line1;
		private System.Windows.Forms.ToolStripMenuItem toolForeColorBlue;
		private System.Windows.Forms.ToolStripMenuItem toolForeColorGreen;
		private System.Windows.Forms.ToolStripSplitButton toolForeColor;
		private System.Windows.Forms.ToolStripSeparator line2;
		private System.Windows.Forms.ToolStripMenuItem toolSelectForeColor;
		private System.Windows.Forms.ToolStripMenuItem toolForeColorOlive;
		private System.Windows.Forms.ToolStripMenuItem toolForeColorGray;
		private System.Windows.Forms.ToolStripMenuItem toolBackColorGray;
		private System.Windows.Forms.ToolStripMenuItem toolBackColorBlack;
		private System.Windows.Forms.ToolStripMenuItem toolBackColorGoldenrod;
		private System.Windows.Forms.ToolStripMenuItem toolBackColorLightSteelBlue;
		private System.Windows.Forms.ToolStripMenuItem toolBackColorThistle;
		private System.Windows.Forms.ToolStripButton toolItalic;
		private System.Windows.Forms.ToolStripButton toolUnderline;
		private System.Windows.Forms.ToolStripSplitButton toolJust;
		private System.Windows.Forms.ToolStripMenuItem toolJustLeft;
		private System.Windows.Forms.ToolStripMenuItem toolJustCenter;
		private System.Windows.Forms.ToolStripMenuItem toolJustRight;
		private System.Windows.Forms.ToolStripButton toolLink;
		private System.Windows.Forms.ToolStripButton toolImage;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.ToolStripSplitButton toolFont;
		private System.Windows.Forms.ToolStripMenuItem toolFontHead1;
		private System.Windows.Forms.ToolStripMenuItem toolFontHead2;
		private System.Windows.Forms.ToolStripMenuItem toolFontHead3;
		private System.Windows.Forms.ToolStripMenuItem toolFontHead4;
		private System.Windows.Forms.ToolStripSeparator line3;
		private System.Windows.Forms.ToolStripMenuItem toolSelectFont;
		private System.Windows.Forms.ToolStripSplitButton toolEdit;
		private System.Windows.Forms.ToolStripMenuItem toolEditCopy;
		private System.Windows.Forms.ToolStripMenuItem toolEditCut;
		private System.Windows.Forms.ToolStripMenuItem toolEditPaste;
		private System.Windows.Forms.ToolStripSeparator line4;
		private System.Windows.Forms.ToolStripMenuItem toolEditDelete;
		private System.Windows.Forms.ToolStripSeparator line5;
		private System.Windows.Forms.ToolStripMenuItem toolEditRemoveFormat;
		private System.Windows.Forms.ToolStripMenuItem menuUndo;
		private System.Windows.Forms.ToolStripSeparator line6;
		private System.Windows.Forms.ToolStripSeparator line7;
		private System.Windows.Forms.ToolStripMenuItem toolIndent;
		private System.Windows.Forms.ToolStripMenuItem toolOutdent;
		private System.Windows.Forms.ToolStripSplitButton toolInsert;
		private System.Windows.Forms.ToolStripMenuItem toolInsertP;
		private System.Windows.Forms.ToolStripSeparator line8;
		private System.Windows.Forms.ToolStripMenuItem toolInsertOrderedList;
		private System.Windows.Forms.ToolStripMenuItem toolInsertUnorderedList;
	}
}

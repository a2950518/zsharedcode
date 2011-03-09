using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.ib;

namespace zoyobar.shared.panzer.test.web.ib
{

	public partial class FormIEBrowser : Form
	{
		private readonly IEBrowser ie;
		private bool isStop;
		private int testJQueryCount = 0;

		public FormIEBrowser ()
		{
			InitializeComponent ();

			this.ie = new IEBrowser ( this.webBrowser );
			this.ie.Navigate ( "about:blank" );
		}

		private void webBrowser_DocumentCompleted ( object sender, WebBrowserDocumentCompletedEventArgs e )
		{

			if ( e.Url.AbsoluteUri == "about:blank" )
				this.cmdInstall.Enabled = true;

		}

		private string analyse ( string title, string publishDateString, string content, out string deliverySpot, out string steelType, out DateTime publishDate, out SortedList<int, string> columns, out List<List<string>> valueLists )
		{
			deliverySpot = null;
			steelType = null;
			publishDate = DateTime.Now;
			columns = new SortedList<int, string> ();
			valueLists = new List<List<string>> ();

			if ( string.IsNullOrEmpty ( title ) || string.IsNullOrEmpty ( publishDateString ) || string.IsNullOrEmpty ( content ) )
				return "title, publishDateString 或者 content 为空";

			if ( !title.Contains ( "日" ) || !title.Contains ( "市场" ) || !title.Contains ( "价格" ) )
				return "无法分析的标题";

			try
			{

				if ( publishDateString.Length > 10 )
					publishDate = Convert.ToDateTime ( publishDateString );
				else
					publishDate = Convert.ToDateTime ( publishDateString + DateTime.Now.ToString ( " hh:mm:ss" ) );

			}
			catch
			{ return "发布日期无效"; }

			this.ie.ExecuteJQuery ( JQuery.Create ( "'body'" ).Html ( content ) );

			this.ie.ExecuteJQuery ( JQuery.Create ( "'tr'" ), "trJQuery" );

			int tdCount = this.ie.ExecuteJQuery<int> ( JQuery.Create ( "trJQuery" ).Children ( "'td'" ).Length () );

			int thCount = this.ie.ExecuteJQuery<int> ( JQuery.Create ( "'tr:first-child'" ).Children ( "'td'" ).Length () );

			if ( tdCount % thCount != 0 )
				return "table 中每个 tr 包含的 td 个数可能不同";

			int usableThCount = 0;

			for ( int tdIndex = 0; tdIndex < thCount; tdIndex++ )
			{
				string text = this.ie.ExecuteJQuery<string> ( JQuery.Create ( "trJQuery" ).Children ( string.Format ( "'td:eq({0})'", tdIndex ) ).Text () );

				usableThCount++;

				if ( text.Contains ( "品名" ) )
					columns.Add ( columns.Count, "sv" );
				else if ( text.Contains ( "规格" ) )
					columns.Add ( columns.Count, "ss" );
				else if ( text.Contains ( "材质" ) )
					columns.Add ( columns.Count, "sq" );
				else if ( text.Contains ( "产地" ) )
					columns.Add ( columns.Count, "pa" );
				else if ( text.Contains ( "价格" ) )
					columns.Add ( columns.Count, "p" );
				else if ( text.Contains ( "涨跌" ) )
					columns.Add ( columns.Count, "r" );
				else if ( text.Contains ( "备注" ) )
					columns.Add ( columns.Count, "re" );
				else
				{
					columns.Add ( columns.Count, columns.Count.ToString () );
					usableThCount--;
				}

			}

			if ( usableThCount < 7 )
				return "符合标准的字段不足 7 个";

			try
			{
				deliverySpot = title.Substring ( title.IndexOf ( "日" ) + 1, title.IndexOf ( "市场" ) - title.IndexOf ( "日" ) - 1 );
				steelType = title.Substring ( title.IndexOf ( "市场" ) + 2, title.IndexOf ( "价格" ) - title.IndexOf ( "市场" ) - 2 );
			}
			catch
			{ return "标题分析错误"; }

			if ( string.IsNullOrEmpty ( deliverySpot ) || string.IsNullOrEmpty ( steelType ) )
				return "城市或者种类为空";

			if ( deliverySpot.Length > 5 )
				return "城市名称过长";

			List<string> values = null;

			for ( int tdIndex = thCount; tdIndex < tdCount; tdIndex++ )
			{
				string text = this.ie.ExecuteJQuery<string> ( JQuery.Create ( "trJQuery" ).Children ( string.Format ( "'td:eq({0})'", tdIndex ) ).Text () );

				if ( tdIndex % thCount == 0 )
				{
					values = new List<string> ();
					valueLists.Add ( values );
				}

				values.Add ( text );
			}

			return string.Empty;
		}

		private void cmdInstall_Click ( object sender, EventArgs e )
		{
			this.ie.InstallTrace ();
			this.ie.InstallJQuery ();
			this.cmdTest.Enabled = true;
			MessageBox.Show ( "已经执行下载 jQuery 脚本的命令, 根据下载速度的不同可能有数秒不等的延迟, 请在数秒后测试脚本是否工作正常" );
		}

		private void cmdTest_Click ( object sender, EventArgs e )
		{
			this.ie.ExecuteScript ( this.txtJQuery.Text );
			this.cmdSpider.Enabled = true;
			this.cmdStop.Enabled = true;
		}

		private void cmdSpider_Click ( object sender, EventArgs e )
		{

			OleDbConnection contentConnection;
			OleDbConnection marketConnection;

			try
			{
				//this.txtContentCN.Text = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\\Users\\M.S.cxc\\Documents\\工作\\SpiderResult\\SpiderResult.mdb";
				//this.txtMarketCN.Text = "Data Source=127.0.0.1;Initial Catalog=database;Persist Security Info=True;User ID=sa;Password=sa";
				contentConnection = new OleDbConnection ( this.txtContentCN.Text );
				marketConnection = new OleDbConnection ( this.txtMarketCN.Text );
			}
			catch ( Exception err )
			{

				if ( this.checkIsThrow.Checked )
					throw err;
				else
				{
					MessageBox.Show ( err.Message );
					return;
				}

			}

			OleDbCommand getIDCommand = new OleDbCommand ( "select ID from content where 已发 = 0", contentConnection );
			OleDbCommand getContentCommand = new OleDbCommand ( "select 标题 as Title, 内容 as Content, 时间 as PublishDate from content where ID = @id", contentConnection );
			getContentCommand.Parameters.Add ( "@id", OleDbType.BigInt );

			OleDbCommand setContentCommand = new OleDbCommand ( "update content set result = @result, 已发 = @ok where ID = @id", contentConnection );
			setContentCommand.Parameters.Add ( "@result", OleDbType.VarWChar, 255 );
			setContentCommand.Parameters.Add ( "@ok", OleDbType.Boolean );
			setContentCommand.Parameters.Add ( "@id", OleDbType.BigInt );

			OleDbCommand addMarketCommand = new OleDbCommand ( "INSERT INTO Market (SteelType, DeliverySpot, PublishDate, SteelVariety, SteelSpec, SteelQuality, ProducingArea, Price, Range, Remark) VALUES   (@steelType, @deliverySpot, @publishDate, @steelVariety, @steelSpec, @steelQuality, @producingArea, @price, @range, @remark)", marketConnection );
			addMarketCommand.Parameters.Add ( "@steelType", OleDbType.VarWChar, 50 );
			addMarketCommand.Parameters.Add ( "@deliverySpot", OleDbType.VarWChar, 50 );
			addMarketCommand.Parameters.Add ( "@publishDate", OleDbType.Date );
			addMarketCommand.Parameters.Add ( "@steelVariety", OleDbType.VarWChar, 50 );
			addMarketCommand.Parameters.Add ( "@steelSpec", OleDbType.VarWChar, 50 );
			addMarketCommand.Parameters.Add ( "@steelQuality", OleDbType.VarWChar, 50 );
			addMarketCommand.Parameters.Add ( "@producingArea", OleDbType.VarWChar, 50 );
			addMarketCommand.Parameters.Add ( "@price", OleDbType.VarWChar, 50 );
			addMarketCommand.Parameters.Add ( "@range", OleDbType.VarWChar, 50 );
			addMarketCommand.Parameters.Add ( "@remark", OleDbType.VarWChar, 50 );

			this.isStop = false;

			try
			{
				contentConnection.Open ();

				OleDbDataReader idReader = getIDCommand.ExecuteReader ();
				int contentCount = 0;
				int marketCount = 0;

				while ( idReader.Read () )
				{
					getContentCommand.Parameters["@id"].Value = idReader["ID"];

					OleDbDataReader contentReader = getContentCommand.ExecuteReader ();

					if ( !contentReader.Read () )
						continue;

					if ( contentReader.IsDBNull ( 0 ) || contentReader.IsDBNull ( 1 ) || contentReader.IsDBNull ( 2 ) )
						continue;

					SortedList<int, string> columns;
					List<List<string>> valueLists;
					string deliverySpot;
					string steelType;
					DateTime publishDate;

					string result = this.analyse ( contentReader["Title"].ToString (), contentReader["PublishDate"].ToString (), string.Format ( "'{0}'", IEBrowser.EscapeCharacter(contentReader["Content"].ToString ()).Replace ( "'", "\\'" ) ), out deliverySpot, out steelType, out publishDate, out columns, out valueLists );

					contentReader.Close ();

					marketConnection.Open ();

					if ( result == string.Empty )
						foreach ( List<string> values in valueLists )
						{
							addMarketCommand.Parameters["@steelType"].Value = steelType;
							addMarketCommand.Parameters["@deliverySpot"].Value = deliverySpot;
							addMarketCommand.Parameters["@publishDate"].Value = publishDate;

							addMarketCommand.Parameters["@steelVariety"].Value = values[columns.IndexOfValue ( "sv" )];
							addMarketCommand.Parameters["@steelSpec"].Value = values[columns.IndexOfValue ( "ss" )];
							addMarketCommand.Parameters["@steelQuality"].Value = values[columns.IndexOfValue ( "sq" )];
							addMarketCommand.Parameters["@producingArea"].Value = values[columns.IndexOfValue ( "pa" )];
							addMarketCommand.Parameters["@price"].Value = values[columns.IndexOfValue ( "p" )];
							addMarketCommand.Parameters["@range"].Value = values[columns.IndexOfValue ( "r" )];
							addMarketCommand.Parameters["@remark"].Value = values[columns.IndexOfValue ( "re" )];

							addMarketCommand.ExecuteNonQuery ();
							marketCount++;
							Application.DoEvents ();
						}

					marketConnection.Close ();

					setContentCommand.Parameters["@result"].Value = result;
					setContentCommand.Parameters["@ok"].Value = ( result == string.Empty );
					setContentCommand.Parameters["@id"].Value = idReader["ID"];

					setContentCommand.ExecuteNonQuery ();

					Application.DoEvents ();
					this.lblInfo.Text = string.Format ( "共分析 {0} 个页面, 导入 {1} 条行情", ++contentCount, marketCount );

					if ( this.isStop )
						break;

				}

				this.lblInfo.Text = string.Format ( "已经停止或完毕, 共分析 {0} 个页面, 导入 {1} 条行情", ++contentCount, marketCount );
				idReader.Close ();
			}
			catch ( Exception err )
			{

				if ( this.checkIsThrow.Checked )
					throw err;
				else
				{
					MessageBox.Show ( err.Message );
					return;
				}

			}
			finally
			{
				contentConnection.Close ();
				marketConnection.Close ();
			}

		}

		private void cmdStop_Click ( object sender, EventArgs e )
		{ this.isStop = true; }

		private void txtJQuery_MouseDoubleClick ( object sender, MouseEventArgs e )
		{

			switch ( this.testJQueryCount++ )
			{
				case 0:
					this.txtJQuery.Text = "$('body').html('<table><tr><td>A</td></tr><tr><td>B</td></tr><tr><td>C</td></tr></table>');";
					break;
			}

		}

	}

}

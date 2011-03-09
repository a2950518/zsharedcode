using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.ib;
using zoyobar.shared.panzer.flow;

namespace zoyobar.shared.panzer.test.web.ib
{

	public partial class FormIEBrowser2 : Form
	{
		private const string loadGoogleStateName = "load google";
		private const string homePageInstallJQueryStateName = "home page install jquery";
		private const string testJQueryStateName = "test jquery";
		private const string searchStateName = "search";
		private const string resultPageInstallJQueryStateName = "result page install jquery";
		private const string nextPageStateName = "next page";

		private bool isStop;
		private int currentPageIndex;
		private readonly SortedList<string, string> results = new SortedList<string, string> ( );
		private readonly IEBrowser ie;

		private readonly WebPageState loadGoogleState = new WebPageState (
			loadGoogleStateName,
			new NavigateAction ( "http://www.google.com.hk/", 2 ),
			completedStateSetting: new WebPageNextStateSetting ( homePageInstallJQueryStateName, true ),
			condition: new UrlCondition ( "url google", "http://www.google.com.hk/", StringCompareMode.StartWith )
			);

		private readonly WebPageState homePageInstallJQueryState = new WebPageState (
			homePageInstallJQueryStateName,
			new InstallJQueryAction ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory, @"jquery-1.5.min.js" ), 1 ),
			completedStateSetting: new WebPageNextStateSetting ( testJQueryStateName, true )
			);

		private readonly WebPageState testJQueryState = new WebPageState (
			testJQueryStateName,
			new ExecuteJavaScriptAction ( "try{alert('jQuery 安装成功, 页面上共有 ' + $('*').length + ' 个元素');}catch(err){alert('jQuery 脚本尚未成功安装, 请重新开始!');}" ),
			completedStateSetting: new WebPageNextStateSetting ( searchStateName, true )
			);

		private readonly WebPageState searchState = new WebPageState (
			searchStateName,
			new WebPageAction[] {
				new ExecuteJQueryAction ( JQuery.Create ( ) ),
				new ExecuteJQueryAction ( JQuery.Create ( "'input[name=btnG]'" ).Trigger ( "'click'" ) )
			},
			completedStateSetting: new WebPageNextStateSetting ( resultPageInstallJQueryStateName, true ),
			condition: new UrlCondition ( "url search", "http://www.google.com.hk/search", StringCompareMode.StartWith )
			);

		private readonly WebPageState resultPageInstallJQueryState = new WebPageState (
			resultPageInstallJQueryStateName,
			new InstallJQueryAction ( Path.Combine ( AppDomain.CurrentDomain.BaseDirectory, @"jquery-1.5.min.js" ), 1 ),
			completedStateSetting: new WebPageNextStateSetting ( nextPageStateName, true )
			);

		private readonly WebPageState nextPageState = new WebPageState (
			nextPageStateName,
			new ExecuteJavaScriptAction ( null ),
			completedStateSetting: new WebPageNextStateSetting ( resultPageInstallJQueryStateName, true ),
			condition: new UrlCondition ( "url search", "http://www.google.com.hk/search", StringCompareMode.StartWith )
			);

		public FormIEBrowser2 ( )
		{
			InitializeComponent ( );

			this.ie = new IEBrowser ( this.webBrowser, new WebPageState[] {
					this.loadGoogleState, this.homePageInstallJQueryState, this.testJQueryState, this.searchState,
					this.resultPageInstallJQueryState, this.nextPageState
				}
				);

			this.ie.IEFlow.ConditionCompleted += new ConditionCompletedEventHandler<WebPageCondition> ( this.ieConditionCompleted );
			this.ie.IEFlow.RemainWaitTimeChanged += new RemainWaitTimeChangedEventHandler ( this.ieRemainWaitTimeChanged );

			this.ie.IEFlow.StateCompleted += new StateChangedEventHandler<WebPageAction, WebPageCondition> ( this.ieStateCompleted );
		}

		private void ieConditionCompleted ( WebPageCondition condition, int conditionCount, int completedConditionCount )
		{ this.lblInfo.Text = string.Format ( "条件 {0} ({1}/{2}) 完成 ...", condition.Name, completedConditionCount, conditionCount ); }

		private void ieRemainWaitTimeChanged ( int remainSecond )
		{

			if ( remainSecond <= 0 )
				this.lblTime.Text = "...";
			else
				this.lblTime.Text = string.Format ( "等待 {0} 秒 ...", remainSecond );

		}

		private void ieStateCompleted ( FlowState<WebPageAction, WebPageCondition> state, ref bool isStop )
		{

			if ( this.isStop )
			{
				isStop = true;
				return;
			}

			switch ( state.Name )
			{
				case resultPageInstallJQueryStateName:
					this.ie.ExecuteJQuery ( JQuery.Create ( "'li.g'" ), "__jlis" );

					int resultCount = this.ie.ExecuteJQuery<int> ( JQuery.Create ( "__jlis" ).Length ( ), "__jfSearch" );

					for ( int index = 0; index < resultCount; index++ )
					{
						this.ie.ExecuteJQuery ( JQuery.Create ( "__jlis" ).Eq ( index.ToString ( ) ), "__jli" );

						string title = this.ie.ExecuteJQuery<string> ( JQuery.Create ( "__jli" ).Find ( "'.r'" ).Text ( ), "__jfSearch" );
						string url = this.ie.ExecuteJQuery<string> ( JQuery.Create ( "__jli" ).Find ( "'a.l'" ).Attr ( "'href'" ), "__jfSearch" );

						if ( !string.IsNullOrEmpty ( title ) && !string.IsNullOrEmpty ( url ) && !this.results.ContainsKey ( url ) )
						{
							this.listPage.Items.Add ( title + "-" + url );
							this.results.Add ( url, title );
						}

					}

					(this.nextPageState.StartActions[0] as ExecuteJavaScriptAction).Code = string.Format ( "window.location = '{0}';", this.ie.ExecuteJQuery<string> ( JQuery.Create ( "'#pnnext'" ).Attr ( "'href'" ), "__jfSearch" ) );

					if ( this.currentPageIndex++ >= this.numericPageCount.Value )
					{
						this.stopSearch ( );
						isStop = true;
					}

					break;
			}

		}

		private void stopSearch ( )
		{
			this.ie.IEFlow.StopJump ( );
			this.isStop = true;

			this.cmdSearch.Enabled = true;
			this.cmdStop.Enabled = false;
			this.cmdSpider.Enabled = true;

			this.txtKeyWord.Enabled = true;
			this.numericPageCount.Enabled = true;
			this.lblInfo.Text = "...";
			this.lblTime.Text = "...";
		}

		private void cmdSearch_Click ( object sender, EventArgs e )
		{
			string keyWord = this.txtKeyWord.Text.Trim ( );

			if ( keyWord == string.Empty )
			{
				this.lblInfo.Text = "请填写关键字";
				return;
			}

			this.isStop = false;

			this.cmdSearch.Enabled = false;
			this.cmdStop.Enabled = true;
			this.cmdSpider.Enabled = false;

			this.txtKeyWord.Enabled = false;
			this.numericPageCount.Enabled = false;

			this.results.Clear ( );
			this.listPage.Items.Clear ( );

			this.currentPageIndex = 1;
			(this.searchState.StartActions[0] as ExecuteJQueryAction).JQuery = JQuery.Create ( "'input[name=q]'" ).Val ( string.Format ( "'{0}'", keyWord ) );
			this.ie.IEFlow.JumpToState ( loadGoogleStateName );
		}

		private void cmdStop_Click ( object sender, EventArgs e )
		{ this.stopSearch ( ); }

		private void cmdSpider_Click ( object sender, EventArgs e )
		{

			if ( this.folderBrowserDialog.ShowDialog ( ) == DialogResult.Cancel )
				return;

			WebClient client = new WebClient ( );

			foreach ( string url in this.results.Keys )
				try
				{
					this.lblInfo.Text = string.Format ( "采集 {0}", url );
					this.status.Refresh ( );
					Application.DoEvents ( );

					File.WriteAllText ( Path.Combine ( this.folderBrowserDialog.SelectedPath, this.results[url] + ".htm" ), new StreamReader ( client.OpenRead ( url ), Encoding.Default ).ReadToEnd ( ), Encoding.Default );
				}
				catch { }

				this.lblInfo.Text = "采集完成";
		}

	}

}

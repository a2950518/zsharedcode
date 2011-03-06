<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestJQuery.aspx.cs" Inherits="TestJQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>TestJQuery</title>
	<style type="text/css">
		.box
		{
			border: 1px solid #0000ff;
		}
		.happy
		{
			background-color: #000000;
			color: #ffffff;
		}
		.big
		{
			font-size: x-large;
		}
	</style>
	<script type="text/javascript" language="javascript" src="http://code.jquery.com/jquery-1.4.2.min.js"></script>
</head>
<body>
	<form id="formTestJQuery" runat="server">
	<div>
		<asp:Button ID="cmdTestConstructor" runat="server" OnClick="cmdTestConstructor_Click"
			Text="TestConstructor" />
		&nbsp;<asp:Button ID="cmdTestCreate" runat="server" OnClick="cmdTestCreate_Click"
			Text="TestCreate" />
		&nbsp;<asp:Button ID="cmdTestClone" runat="server" OnClick="cmdTestClone_Click" Text="TestClone" />
		&nbsp;<asp:Button ID="cmdTestEndLine" runat="server" OnClick="cmdTestEndLine_Click" Text="TestEndLine" />
		&nbsp;<asp:Button ID="cmdTestAddClass" runat="server" OnClick="cmdTestAddClass_Click"
			Text="TestAddClass" />
		&nbsp;<asp:Button ID="cmdTestAttr" runat="server" OnClick="cmdTestAttr_Click" Text="TestAttr" />
		&nbsp;
		<asp:Button ID="cmdTestHasClass" runat="server" OnClick="cmdTestHasClass_Click" Text="TestHasClass" />
		&nbsp;
		<asp:Button ID="cmdTestHtml" runat="server" OnClick="cmdTestHtml_Click" Text="TestHtml" />
		&nbsp;
		<asp:Button ID="cmdTestRemoveAttr" runat="server" OnClick="cmdTestRemoveAttr_Click"
			Text="TestRemoveAttr" />
		&nbsp;
		<asp:Button ID="cmdTestRemoveClass" runat="server" OnClick="cmdTestRemoveClass_Click"
			Text="TestRemoveClass" />
		&nbsp;
		<asp:Button ID="cmdTestToggleClass" runat="server" OnClick="cmdTestToggleClass_Click"
			Text="TestToggleClass" />
		&nbsp;
		<asp:Button ID="cmdTestVal" runat="server" OnClick="cmdTestVal_Click" Text="TestVal" />
		&nbsp;
		<asp:Button ID="cmdTestEq" runat="server" OnClick="cmdTestEq_Click" 
			Text="TestEq" />
	&nbsp;
		<asp:Button ID="cmdTestFilter" runat="server" OnClick="cmdTestFilter_Click" 
			Text="TestFilter" />
	&nbsp;
		<asp:Button ID="cmdTestHas" runat="server" OnClick="cmdTestHas_Click" 
			Text="TestHas" />
	&nbsp;
		<asp:Button ID="cmdTestIs" runat="server" OnClick="cmdTestIs_Click" 
			Text="TestIs" />
	&nbsp;
		<asp:Button ID="cmdTestFirst" runat="server" OnClick="cmdTestFirst_Click" 
			Text="TestFirst" />
	&nbsp;
		<asp:Button ID="cmdTestLast" runat="server" OnClick="cmdTestLast_Click" 
			Text="TestLast" />
	&nbsp;
		<asp:Button ID="cmdTestMap" runat="server" OnClick="cmdTestMap_Click" 
			Text="TestMap" />
	&nbsp;
		<asp:Button ID="cmdTestNot" runat="server" OnClick="cmdTestNot_Click" 
			Text="TestNot" />
	&nbsp;
		<asp:Button ID="cmdTestSlice" runat="server" OnClick="cmdTestSlice_Click" 
			Text="TestSlice" />
	</div>
	<asp:Literal ID="lblResult" runat="server"></asp:Literal><br />
	<br />
	<table id="myTable1" style="width: 500px;">
		<tr>
			<td>
				姓名
			</td>
			<td>
				年龄
			</td>
			<td>
				班级
			</td>
		</tr>
		<tr>
			<td>
				小小
			</td>
			<td>
				11
			</td>
			<td>
				五三班
			</td>
		</tr>
		<tr>
			<td>
				大大
			</td>
			<td>
				12
			</td>
			<td>
				六五班
			</td>
		</tr>
	</table>
	<br />
	<br />
	<table id="myTable2" class="big" style="width: 500px;">
		<tr>
			<td>
				昵称
			</td>
			<td>
				价格
			</td>
		</tr>
		<tr>
			<td>
				哈奇森
			</td>
			<td>
				1300
			</td>
		</tr>
		<tr>
			<td>
				杰克
			</td>
			<td>
				1230
			</td>
		</tr>
	</table>
	<br />
	<input id="myTextBox1" type="text" value="tom" />
	<br />
	<ul>
		<li>条目1</li>
		<li class="happy">条目2</li>
		<li>条目3</li>
		<li>条目4</li>
		<li>条目5</li>
	</ul>
	<br />
	</form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestJQueryUI.aspx.cs" Inherits="TestJQueryUI" %>

<%@ Register Assembly="zoyobar.shared.panzer" Namespace="zoyobar.shared.panzer.ui.jqueryui"
	TagPrefix="ui" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link rel="stylesheet" href="css/ui-lightness/jquery-ui-1.8.11.custom.css" />
	<script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>
	<script type="text/javascript" src="js/jquery-ui-1.8.11.custom.min.js"></script>
</head>
<body>
	<form id="formTestJQueryUI" runat="server">
	<div>
		<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
		<asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" /><asp:DropDownList
			ID="DropDownList1" runat="server">
			<asp:ListItem></asp:ListItem>
		</asp:DropDownList>
		<ui:JQueryElement ID="JQueryElement1" runat="server">
		</ui:JQueryElement>
	</div>
	</form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestJQueryUI.aspx.cs" Inherits="TestJQueryUI"
	UICulture="af" %>

<%@ Register Assembly="zoyobar.shared.panzer" Namespace="zoyobar.shared.panzer.ui.jqueryui"
	TagPrefix="ui" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link rel="stylesheet" href="css/ui-lightness/jquery-ui-1.8.11.custom.css" />
	<script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>
	<script type="text/javascript" src="js/jquery-ui-1.8.11.custom.min.js"></script>
	<style type="text/css">
		.draggable-box
		{
			padding: 10px;
			width: 80px;
			height: 60px;
			background-color: #cccccc;
		}
		.droppable-box
		{
			padding: 10px;
			width: 160px;
			height: 120px;
			background-color: #aaaaaa;
		}
	</style>
</head>
<body>
	<form id="formTestJQueryUI" runat="server">
	<ui:Autocomplete ID="a" runat="server" Source="['a','aa']" Change="
	function()
	{
	alert();
	}
	">
	</ui:Autocomplete>
	<ui:JQueryElement ID="aa" runat="server">
	</ui:JQueryElement>
	<ui:Progressbar ID="Progressbar1" runat="server" IsVariable="True" Value="20">
	</ui:Progressbar>
	</form>
</body>
</html>

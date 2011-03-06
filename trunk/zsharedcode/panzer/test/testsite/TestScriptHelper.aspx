<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestScriptHelper.aspx.cs"
	Inherits="TestScriptHelper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>TestScriptHelper</title>
</head>
<body>
	<form id="formTestScriptHelper" runat="server">
	<div>
		<asp:Button ID="cmdTestConstructor" runat="server" OnClick="cmdTestConstructor_Click"
			Text="TestConstructor" />
		&nbsp;<asp:Button ID="cmdTestAlert" runat="server" OnClick="cmdTestAlert_Click" Text="TestAlert" />
		&nbsp;<asp:Button ID="cmdTestConfirm" runat="server" OnClick="cmdTestConfirm_Click"
			Text="TestConfirm" />
		&nbsp;<asp:Button ID="cmdTestPrompt" runat="server" OnClick="cmdTestPrompt_Click"
			Text="TestPrompt" />
		&nbsp;<asp:Button ID="cmdTestNavigate" runat="server" OnClick="cmdTestNavigate_Click"
			Text="TestNavigate" />
		&nbsp;<asp:Button ID="cmdTestAppendScript" runat="server" OnClick="cmdTestAppendScript_Click"
			Text="TestAppendScript" />
		&nbsp;<asp:Button ID="cmdTestClear" runat="server" OnClick="cmdTestClear_Click" Text="TestClear" />
		&nbsp;<asp:Button ID="cmdTestBuild" runat="server" OnClick="cmdTestBuild_Click" Text="TestBuild" />
		<br />
		<asp:Button ID="cmdTestSetInterval" runat="server" OnClick="cmdTestSetInterval_Click"
			Text="TestSetInterval" />
		&nbsp;<asp:Button ID="cmdTestSetTimeout" runat="server" OnClick="cmdTestSetTimeout_Click"
			Text="TestSetTimeout" />
		&nbsp;<asp:Button ID="cmdTestClearInterval" runat="server" OnClick="cmdTestClearInterval_Click"
			Text="TestClearInterval" />
		&nbsp;<asp:Button ID="cmdTestClearTimeout" runat="server" OnClick="cmdTestClearTimeout_Click"
			Text="TestClearTimeout" />
		<br />
		<asp:Button ID="cmdTestRegisterArray" runat="server" OnClick="cmdTestRegisterArray_Click"
			Text="TestRegisterArray" />
		&nbsp;<asp:Button ID="cmdTestRegisterInclude" runat="server" OnClick="cmdTestRegisterInclude_Click"
			Text="TestRegisterInclude" />
		&nbsp;<asp:Button ID="cmdTestRegisterAttribute" runat="server" OnClick="cmdTestRegisterAttribute_Click"
			Text="TestRegisterAttribute" />
		&nbsp;<asp:Button ID="cmdTestRegisterHidden" runat="server" OnClick="cmdTestRegisterHidden_Click"
			Text="TestRegisterHidden" />
		&nbsp;<asp:Button ID="cmdTestRegisterSubmit" runat="server" OnClick="cmdTestRegisterSubmit_Click"
			Text="TestRegisterSubmit" />
	&nbsp;
		<asp:Button ID="cmdTestMakeKey" runat="server" OnClick="cmdTestMakeKey_Click"
			Text="TestMakeKey" />
	</div>
	<asp:Literal ID="lblResult" runat="server"></asp:Literal><br />
	<span id="spanTest"></span>
	<input id="mysub" type="submit" value="填好了!" />
	<br />
	<hr />
	<br />
	示例 1: 提交数据到数据库 ScriptHelper 返回结果提示.<br />
	姓名:
	<asp:TextBox ID="txtName1" runat="server"></asp:TextBox>
	<br />
	年龄:
	<asp:TextBox ID="txtAge1" runat="server"></asp:TextBox>
	<asp:Button ID="cmdAdd1" runat="server" OnClick="cmdAdd1_Click" Text="添加" />
	<span id="span1">
		<br />
	</span>
	<br />
	<br />
	示例 2: 用户在文本框中输入 javascript 脚本, 点击执行脚本传到服务器后返回至浏览器运行, 同时在标签显示脚本.<br />
	<asp:TextBox ID="txtCode2" runat="server" Height="300px" TextMode="MultiLine" Width="400px">alert(&#39;你好&#39;);</asp:TextBox>
	<asp:Button ID="cmdRun2" runat="server" Text="执行" OnClick="cmdRun2_Click" />
	<asp:Label ID="lblCode2" runat="server"></asp:Label>
	<br />
	<br />
	<br />
	示例 3: 演示注册过程.<br />
	<div id="r1">
		第一步, 用户名:
		<asp:TextBox ID="txtName3" runat="server"></asp:TextBox>
		&nbsp;<asp:Button ID="cmdNext3" runat="server" Text="继续" OnClick="cmdNext3_Click" />
	</div>
	<div id="r2" style="display: none;">
		第二步, 密码:
		<asp:TextBox ID="txtPassword3" runat="server" TextMode="Password"></asp:TextBox>
		&nbsp;<asp:Button ID="cmdOK3" runat="server" Text="好了" OnClick="cmdOK3_Click" />
	</div>
	<div id="r3" style="display: none;">
		<span id="rr1"></span>
	</div>
	<br />
	<br />
	示例 4: 使用时钟修改字体颜色.<br />
	<span id="span4">会变色的文字</span><asp:Button ID="cmdOK4" runat="server" Text="变色" OnClick="cmdOK4_Click" />
	<br />
	<br />
	<br />
	</form>
</body>
</html>

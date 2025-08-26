<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWord.aspx.cs" Inherits="Hackathon2.Hackathon2.AddWord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1 style="color: #663300">Adding word</h1>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="lblword" runat="server" BorderColor="#33CC33" BorderStyle="Dashed" Height="119px" Text="Label" Width="464px"></asp:Label>
        </p>
        <div>
            <asp:TextBox ID="txtTranslate" runat="server" Width="301px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAdd" runat="server" BorderColor="#3366FF" BorderWidth="3px" OnClick="btnAdd_Click" style="margin-left: 0px" Text="Add to my  words" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>

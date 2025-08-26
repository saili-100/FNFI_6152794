<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Searchword.aspx.cs" Inherits="Hackathon2.Hackathon2.Searchword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1 style="color: #663300">Search Word</h1>
    <form id="form1" runat="server">
        <p>
            <strong>English Word</strong><asp:TextBox ID="txtWord" runat="server" Height="16px" style="margin-left: 12px" Width="273px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSerach" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="3px" OnClick="btnSerach_Click" Text="Search" />
        </p>
        <p>
            &nbsp;</p>
        <div>
        </div>
    </form>
</body>
</html>

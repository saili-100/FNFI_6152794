<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Hackathon2.Hackathon2.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1 style="color: #FF0000">Error</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
            <a href ="Searchword.aspx">Go Back</a>
        </div>
    </form>
</body>
</html>

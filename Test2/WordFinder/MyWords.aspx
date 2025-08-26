<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWords.aspx.cs" Inherits="Hackathon2.Hackathon2.MyWords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1 style="color: #663300">My Words</h1>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
        <asp:GridView ID="gvWords" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Word" HeaderText="Word" />
                <asp:BoundField DataField="Translation" HeaderText="Translation" />


            </Columns>
        </asp:GridView>
       
    </form>
</body>
</html>

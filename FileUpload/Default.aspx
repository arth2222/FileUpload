<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUpload.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <h1>uke 37 plakat</h1>

    ditt bilde her<br />
    <img height="300" src="mittbilde.jpg" />

    <form id="form1" runat="server">

        <p>
        <asp:Label ID="LabelText" runat="server" Text="Label"></asp:Label>
        </p>

        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <img height="300" src="<%# Container.DataItem %>" />
                <br />
                <asp:Button ID="ButtonDelete" CommandName="<%# Container.DataItem %>" runat="server" Text="Delete" />
            </ItemTemplate>
        </asp:DataList>
    </form>
</body>
</html>

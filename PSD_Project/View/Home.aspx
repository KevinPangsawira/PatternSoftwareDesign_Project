<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PSD_Project.View.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <asp:Button ID="homeNav" runat="server" Text="Home" />
                <asp:Button ID="loginNav" runat="server" Text="Login" />
                <asp:Button ID="registerNav" runat="server" Text="Register" />
                <asp:Button ID="cartNav" runat="server" Text="Cart" />
                <asp:Button ID="myOrdersNav" runat="server" Text="My Orders" />
                <asp:Button ID="addNav" runat="server" Text="Add Jewel" />
                <asp:Button ID="reportsNav" runat="server" Text="Reports" />
                <asp:Button ID="handleOrdersNav" runat="server" Text="Handle Orders" />
                <asp:Button ID="profileNav" runat="server" Text="Profile" />
                <asp:Button ID="logoutNav" runat="server" Text="Logout" />
        </div>

        <div>
            <br />
            <asp:Label ID="userNow" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>

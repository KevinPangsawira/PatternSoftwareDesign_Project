<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PSD_Project.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Login</h2>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Email : ">
            </asp:Label><asp:TextBox ID="emailTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password : ">
            </asp:Label><asp:TextBox ID="passwordTB" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <asp:CheckBox ID="rememberMeCB" runat="server" Text="Remember Me" />
        <br />
        <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
    </form>
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
</body>
</html>

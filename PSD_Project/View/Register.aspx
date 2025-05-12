<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PSD_Project.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Register</h2>

        <div>
            <asp:Label ID="Label1" runat="server" Text="Email : ">
            </asp:Label><asp:TextBox ID="emailTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Username : ">
            </asp:Label><asp:TextBox ID="usernameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password : ">
            </asp:Label><asp:TextBox TextMode="Password" ID="passwordTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Confirm Password : ">
            </asp:Label><asp:TextBox TextMode="Password" ID="cpasswordTB" runat="server"></asp:TextBox>
        </div>

        <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButtonList ID="genderList" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>

        <asp:Label ID="lblDOB" runat="server" Text="DOB"></asp:Label>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        <asp:Button ID="registerBtn" OnClick="registerBtn_Click" runat="server" Text="Register" />

    </form>
      <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</body>
</html>

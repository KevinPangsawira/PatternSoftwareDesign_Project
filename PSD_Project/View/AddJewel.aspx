<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddJewel.aspx.cs" Inherits="PSD_Project.View.AddJewel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Edit Jewel</h2>
    <form id="form1" runat="server">

        <div>
            <asp:Label ID="Label1" runat="server" Text="Jewel Name: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label2" runat="server" Text="Category: "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        </div>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Brand: "></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
        </div>

        <div>
            <asp:Label ID="Label4" runat="server" Text="Price: "></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label5" runat="server" Text="Release Year: "></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red">
        </asp:Label>
        <br />
        <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click"/>
        <asp:Button ID="addBtn" runat="server" Text="Add" OnClick="addBtn_Click"/>
    </form>
</body>
</html>

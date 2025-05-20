<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditJewel.aspx.cs" Inherits="PSD_Project.View.EditJewel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Edit Jewel:</h2>
   
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Jewel Name: "></asp:Label>
            <asp:TextBox ID="jnameTB" runat="server"></asp:TextBox>
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
            <asp:Label ID="Label6" runat="server" Text="Price: "></asp:Label>
            <asp:TextBox ID="jpriceTB" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label7" runat="server" Text="Release Year: "></asp:Label>
            <asp:TextBox ID="jyearTB" runat="server"></asp:TextBox>
        </div>

        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="editBtn" runat="server" Text="Confirm Edit" OnClick="editBtn_Click" />
    </form>
</body>
</html>

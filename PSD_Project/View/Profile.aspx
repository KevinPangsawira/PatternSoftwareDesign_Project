<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PSD_Project.View.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Profile</h2>
    <div>
        <asp:Label ID="lblUserName" runat="server" Text="User Name: "></asp:Label>
        <asp:Label ID="lblUserNameValue" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
        <asp:Label ID="lblEmailValue" runat="server"></asp:Label>
    </div>

    <div>
        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth: "></asp:Label>
        <asp:Label ID="lblDOBValue" runat="server"></asp:Label>
    </div>

    <div>
        <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label>
        <asp:Label ID="lblGenderValue" runat="server"></asp:Label>
    </div>

    <div>
        <asp:Label ID="lblRole" runat="server" Text="Role: "></asp:Label>
        <asp:Label ID="lblRoleValue" runat="server"></asp:Label>
    </div>

    <div>
        <asp:Label ID="lblOld" runat="server" Text="Old Password: "></asp:Label>
        <asp:TextBox ID="oldTB" runat="server" TextMode="Password"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lblNew" runat="server" Text="New Password: "></asp:Label>
        <asp:TextBox ID="newTB" runat="server" TextMode="Password"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password: "></asp:Label>
        <asp:TextBox ID="confirmTB" runat="server" TextMode="Password"></asp:TextBox>
    </div>


    <div>
        <asp:Button ID="btnEditPassword" UseSubmitBehavior="false" runat="server" Text="Edit Password" OnClick="btnEditPassword_Click" />
    </div>

    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>

</asp:Content>

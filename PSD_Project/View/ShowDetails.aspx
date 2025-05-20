<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="ShowDetails.aspx.cs" Inherits="PSD_Project.View.ShowDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detail Page</h2>

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
        OnRowCommand="GridView2_RowCommand"
        OnRowDeleting="GridView2_RowDeleting"
        OnRowEditing="GridView2_RowEditing"
        OnRowDataBound="GridView2_RowDataBound" DataKeyNames="JewelID">

        <Columns>
            <%--<asp:BoundField DataField="JewelID" HeaderText="Jewel Id" />--%>
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
            <asp:BoundField DataField="MsCategory.CategoryName" HeaderText="Category Name" />
            <asp:BoundField DataField="MsBrand.BrandName" HeaderText="Brand Name" />
            <asp:BoundField DataField="MsBrand.BrandCountry" HeaderText="Country of Origin" />
            <asp:BoundField DataField="MsBrand.BrandClass" HeaderText="Class" />
            <asp:BoundField DataField="JewelPrice" DataFormatString="${0:N2}" HeaderText="Price" />
            <asp:BoundField DataField="JewelReleaseYear" HeaderText="Release Year" />

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="addBtn" runat="server" Text="Add to Cart" UseSubmitBehavior="false" CommandName="Add" CommandArgument='<%# Eval("JewelID") %>' />
                    <asp:Button ID="editBtn" runat="server" Text="Edit" UseSubmitBehavior="false" CommandName="Edit" />
                    <asp:Button ID="deleteBtn" runat="server" Text="Delete" UseSubmitBehavior="false" CommandName="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>



</asp:Content>

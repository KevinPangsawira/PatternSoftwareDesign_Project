<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="ShowDetails.aspx.cs" Inherits="PSD_Project.View.ShowDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detail Page</h2>

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName" />
            <asp:BoundField DataField="CategoryName" HeaderText="Jewel Category Name" SortExpression="CategoryName" />
            <asp:BoundField DataField="BrandName" HeaderText="Brand Name" SortExpression="BrandName" />
            <asp:BoundField DataField="BrandCountry" HeaderText="Country of Origin" SortExpression="BrandCountry" />
            <asp:BoundField DataField="BrandClass" HeaderText="Class" SortExpression="BrandClass" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Price" SortExpression="JewelPrice" />
            <asp:BoundField DataField="JewelReleaseYear" HeaderText="Release Year" SortExpression="JewelReleaseYear" />
            <asp:TemplateField HeaderText="Button"></asp:TemplateField>
        </Columns>


    </asp:GridView>


</asp:Content>

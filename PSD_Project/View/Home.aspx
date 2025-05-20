<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PSD_Project.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" SortExpression="JewelID" />
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Jewel Price" DataFormatString="${0:N2}" SortExpression="JewelPrice" />
           
            <asp:TemplateField HeaderText="Detail">
                <ItemTemplate>
                    <asp:Button ID="detailBtn" runat="server" Text="View detail" CommandName="viewDetail" CommandArgument='<%# Eval("JewelID") %>'  UseSubmitBehavior="false" />
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>

    </asp:GridView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="ViewTransactionDetail.aspx.cs" Inherits="PSD_Project.View.ViewDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" SortExpression="TransactionID" />
            <asp:BoundField DataField="MsJewel.JewelName" HeaderText="Jewel Name" SortExpression="MsJewel.JewelName" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        </Columns>

    </asp:GridView>

</asp:Content>

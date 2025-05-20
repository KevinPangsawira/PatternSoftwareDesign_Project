<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="PSD_Project.View.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
        DataKeyNames="TransactionID" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" SortExpression="TransactionID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
            <asp:BoundField DataField="PaymentMethod" HeaderText="Payment" SortExpression="PaymentMethod" />

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="statusNow" runat="server" Text='<%# Eval("TransactionStatus")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="detailBtn" runat="server" Text="View Details" UseSubmitBehavior="false" CommandName="Detail" CommandArgument='<%# Eval("TransactionID")  %>'/>
                    <asp:Button ID="confirmBtn" runat="server" Text="Confirm Package" UseSubmitBehavior="false" CommandName="Confirm" CommandArgument='<%# Eval("TransactionID")  %>' />
                    <asp:Button ID="rejectBtn" runat="server" Text="Reject Package" UseSubmitBehavior="false" CommandName="Reject" CommandArgument='<%# Eval("TransactionID")  %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</asp:Content>

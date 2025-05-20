<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="HandleOrders.aspx.cs" Inherits="PSD_Project.View.HandleOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    \

    <h2>Handle Orders</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" SortExpression="TransactionID" />
            <asp:BoundField DataField="UserID" HeaderText="User Id" SortExpression="UserID" />
            
            <asp:TemplateField HeaderText="Transaction Status">
                <ItemTemplate>
                    <asp:Label ID="statusNow" runat="server" Text='<%# Eval("TransactionStatus") %>'  ></asp:Label>
                   
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="shipPackageBtn" runat="server" CommandName="ShipPackage" Text="Ship Package" CommandArgument='<%# Eval("TransactionID") %>' UseSubmitBehavior="false" />
                    <asp:Button ID="confirmPaymentBtn" runat="server" CommandName="Confirm" Text="Confirm Payment" CommandArgument='<%# Eval("TransactionID") %>' UseSubmitBehavior="false" />
                    <asp:Label ID="confirmationLbl" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</asp:Content>

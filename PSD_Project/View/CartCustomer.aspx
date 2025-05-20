<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="CartCustomer.aspx.cs" Inherits="PSD_Project.View.CartCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="customerCart" Font-Bold="true" Font-Size="Larger" runat="server" Text=""></asp:Label>
    <%--<form id="form1" runat="server">--%>
         <asp:Label ID="Label1" Font-Bold="true" Font-Size="Larger" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="JewelID" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False"
            OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Id">
                    <itemtemplate>
                        <%# Eval("JewelID") %>
                    </itemtemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name">
                    <itemtemplate>
                        <%# Eval("MsJewel.JewelName") %>
                    </itemtemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Price">
                    <itemtemplate>
                        <%# Eval("MsJewel.JewelPrice", "${0:N2}") %>
                    </itemtemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Brand">
                    <itemtemplate>
                        <%# Eval("MsJewel.MsBrand.BrandName") %>
                    </itemtemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity">
                    <itemtemplate>
                        <asp:TextBox ID="quantityTB" runat="server" Width="35%" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                    </itemtemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Subtotal">
                    <itemtemplate>
                        <asp:Label ID="subtotalLBL" runat="server" Text=""></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Actions">
                    <itemtemplate>
                        <asp:Button ID="updateBtn" runat="server" Text="Update" UseSubmitBehavior="false"
                            CommandName="UpdateCustom" CommandArgument='<%# Eval("JewelId") %>' />
                        <asp:Button ID="removeBtn" runat="server" Text="Remove" UseSubmitBehavior="false"
                            CommandName="Delete" CommandArgument='<%# Eval("JewelId") %>' />
                    </itemtemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Selected="True" disabled="disabled">Choose Payment Method</asp:ListItem>
        <asp:ListItem>Visa</asp:ListItem>
        <asp:ListItem>Paypal</asp:ListItem>
        <asp:ListItem>Cash</asp:ListItem>

    </asp:DropDownList>

        <asp:Label ID="lblError" runat="server" Text="" ForeColor="red"></asp:Label>

        <br />
        <br />
        <asp:Label ID="lblTotal" Font-Size="Larger" runat="server" Text=""></asp:Label>
       
        <asp:Button ID="clearCartBtn" runat="server" Text="Clear Cart" BackColor="#808080" ForeColor="White" UseSubmitBehavior="false" OnClick="clearCartBtn_Click" />
        <asp:Button ID="checkoutBtn" runat="server" BackColor="#0099ff" ForeColor="White" Text="Proceed to checkout" UseSubmitBehavior="false" OnClick="checkoutBtn_Click" />


       

    <%--</form>--%>

</asp:Content>

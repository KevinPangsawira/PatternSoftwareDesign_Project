using PSD_Project.Controller;
using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class CartCustomer : System.Web.UI.Page
    {
        JewelController jewelController = new JewelController();
        TransactionController transactionController = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {

            MsUser user = (MsUser)Session["user"];
            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (user.UserRole.Equals("Admin"))
            {
                Response.Redirect("Home.aspx");
            }
            if (!IsPostBack)
            {
                //MsUser user = (MsUser)Session["user"];
                customerCart.Text = user.UserName + "'s Cart";

                GridView1.DataSource = jewelController.getCarts(user.UserID);
                GridView1.DataBind();
                

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MsUser user = (MsUser)Session["user"];
            int jewelId = (int)(GridView1.DataKeys[e.RowIndex].Value);
            jewelController.deleteCartOnly1(user.UserID, jewelId);
            Response.Redirect("CartCustomer.aspx");


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("UpdateCustom"))
            {
                MsUser user = (MsUser)Session["user"];
                // Buat ambil button yang ditekan
                Button buttonLokasi = (Button)e.CommandSource;

                // Buat ambil row tempat button berada
                GridViewRow row = (GridViewRow)buttonLokasi.NamingContainer;

                int jewelId = int.Parse(e.CommandArgument.ToString());
                TextBox quantity = (TextBox)row.FindControl("quantityTB");
                String quantityValue = Convert.ToString(quantity.Text);

                string response = jewelController.updateQuantity(user.UserID, jewelId, quantityValue);
                if (response.Equals("success"))
                {
                    Response.Redirect("CartCustomer.aspx");
                }
                else lblError.Text = response;


            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            MsUser user = (MsUser)Session["user"];
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PSD_Project.Model.Cart cartItem = (PSD_Project.Model.Cart)e.Row.DataItem;

                Label subtotalLBL = (Label)e.Row.FindControl("subtotalLBL");

                int quantity = cartItem.Quantity;
                int price = cartItem.MsJewel.JewelPrice;

                int subtotal = quantity * price;
                //subtotalLBL.Text = subtotal.ToString();
                subtotalLBL.Text = "$" + subtotal.ToString("N2");

            }

            lblTotal.Text = "Total: $" + jewelController.getTotalPrice(user.UserID).ToString("N2");
        }

        protected void clearCartBtn_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["user"];
            jewelController.removeAllCart(user.UserID);
            Response.Redirect("CartCustomer.aspx");
        }

        protected void checkoutBtn_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["user"];

            string payment = DropDownList1.SelectedValue;

            string response = transactionController.checkout(user.UserID, payment);
            if (response.Equals("success"))
            {
                jewelController.removeAllCart(user.UserID);
                Response.Redirect("CartCustomer.aspx");
            }
            else if (response.Equals("fail"))
            {
                lblError.Text = "Please fill in your cart before checkout!";
            }
            else lblError.Text = response;


        }
    }
}
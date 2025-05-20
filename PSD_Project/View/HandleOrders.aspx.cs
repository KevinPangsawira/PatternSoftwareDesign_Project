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
    public partial class HandleOrders : System.Web.UI.Page
    {
        TransactionController transactionController = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["user"];
            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (user.UserRole.Equals("Customer"))
            {
                Response.Redirect("Home.aspx");
            }
            if (!IsPostBack)
            {
                //MsUser user = (MsUser)Session["user"];
                GridView1.DataSource = transactionController.getUnfinishedTransaction();
                GridView1.DataBind();
            }



        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string status = "";
            //string id = e.CommandArgument.ToString();
            // Buat ambil button yang ditekan
            Button buttonLokasi = (Button)e.CommandSource;

            // Buat ambil row tempat button berada
            GridViewRow row = (GridViewRow)buttonLokasi.NamingContainer;

            int transactionId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName.Equals("ShipPackage"))
            {
                status = "Arrived";

            }
            else if (e.CommandName.Equals("Confirm"))
            {
                status = "Shipment Pending";

            }
            transactionController.updateTransactionStatus( transactionId, status);

            Response.Redirect("HandleOrders.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Button ShipPackageBtn = (Button)e.Row.FindControl("shipPackageBtn");
                Button ConfirmBtn = (Button)e.Row.FindControl("confirmPaymentBtn");
                Label confirmationLbl = (Label)e.Row.FindControl("confirmationLbl");

                Label statusLbl = (Label)e.Row.FindControl("statusNow");
                if (statusLbl.Text.Equals("Payment Pending"))
                {
                    ShipPackageBtn.Visible = false;
                }
                else if (statusLbl.Text.Equals("Shipment Pending"))
                {
                    ConfirmBtn.Visible = false;
                }
                else if (statusLbl.Text.Equals("Arrived"))
                {
                    ShipPackageBtn.Visible = false;
                    ConfirmBtn.Visible = false;
                    confirmationLbl.Text = "Waiting for user confirmation…";
                }
            }

        }
    }
}
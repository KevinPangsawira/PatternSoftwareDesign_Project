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
    public partial class MyOrders : System.Web.UI.Page
    {
        TransactionController transactionController = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MsUser user = (MsUser)Session["user"];
                GridView1.DataSource = transactionController.GetTransactionHeaderList(user.UserID);
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            string status = "";
            int transactionid = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Detail"))
            {
                Response.Redirect("ViewTransactiondetail.aspx?tId="+transactionid);
            }
            else if (e.CommandName.Equals("Confirm"))
            {
                status = "Done";
                transactionController.updateTransactionStatus(transactionid, status);
            }
            else if(e.CommandName.Equals("Reject"))
            {
                status = "Rejected";
                transactionController.updateTransactionStatus(transactionid, status);
            }

            Response.Redirect("MyOrders.aspx");

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Button detailBtn = (Button) e.Row.FindControl("detailBtn");
                Button confirmBtn = (Button)e.Row.FindControl("confirmBtn");
                Button rejectBtn = (Button)e.Row.FindControl("rejectBtn");
                Label statusNow = (Label)e.Row.FindControl("statusNow");
                string status = statusNow.Text;
                if ( !status.Equals("Arrived") || status.Equals("Done")  || status.Equals("Rejected") )
                {
                    confirmBtn.Visible = false;
                    rejectBtn.Visible = false;
                }

                
               
            }
        }
    }
}
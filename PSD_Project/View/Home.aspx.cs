using PSD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class Home : System.Web.UI.Page
    {
        JewelController jewelController = new JewelController();
        protected void Page_Load(object sender, EventArgs e)
        {
            bindData();

        }

        public void bindData()
        {
            GridView1.DataSource = jewelController.getAllJewels();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect("ShowDetails.aspx?jewelId="+id);
        }
    }
}
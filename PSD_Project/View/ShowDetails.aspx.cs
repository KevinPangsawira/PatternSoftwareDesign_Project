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
    public partial class ShowDetails : System.Web.UI.Page
    {
        JewelController jewelController = new JewelController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string id = Request["jewelId"];
                if (id == null) {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Object jewel = jewelController.getJewelById(int.Parse(id));
                    GridView2.DataSource = new List<Object> { jewel };
                    GridView2.DataBind();

                }
            }
        }

       
    }
}
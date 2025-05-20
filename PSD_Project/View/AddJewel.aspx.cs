using PSD_Project.Controller;
using PSD_Project.Handler;
using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class AddJewel : System.Web.UI.Page
    {
       JewelController jewelController = new JewelController();
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
            if (!IsPostBack) { 

                //MsCategory
                DropDownList1.DataSource = jewelController.getCategories();
                DropDownList1.DataTextField = "CategoryName"; // yang ditampilkan
                DropDownList1.DataValueField = "CategoryID";  // value (ID)
                DropDownList1.DataBind();
                ListItem defaultItem1 = new ListItem("Choose category", "0");
                defaultItem1.Attributes.Add("disabled", "disabled"); //  tidak bisa diselect 
                defaultItem1.Selected = true; //  item yang muncul pertama kali
                DropDownList1.Items.Insert(0, defaultItem1);


                //MsBrand
                DropDownList2.DataSource = jewelController.getBrands();
                DropDownList2.DataTextField = "BrandName"; // yang ditampilkan
                DropDownList2.DataValueField = "BrandID";  // value (ID)
                DropDownList2.DataBind();
                ListItem defaultItem2 = new ListItem("Choose brand", "0");
                defaultItem2.Attributes.Add("disabled", "disabled"); //  tidak bisa diselect 
                defaultItem2.Selected = true; //  item yang muncul pertama kali
                DropDownList2.Items.Insert(0, defaultItem2);



            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            int categoryId = int.Parse(DropDownList1.SelectedValue); 
            int brandId = int.Parse(DropDownList2.SelectedValue);
            string price = TextBox4.Text;
            string year = TextBox5.Text;

            string response = jewelController.createJewel(name, categoryId, brandId, price, year);

            if (response.Equals("success"))
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblError.Text = response;
            }

        }
    }
}
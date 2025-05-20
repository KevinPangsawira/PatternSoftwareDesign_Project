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
    public partial class EditJewel : System.Web.UI.Page
    {
        JewelController jewelController = new JewelController();
        MsJewel currentJewel = new MsJewel();
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

                string id = Request["jewelId"];

                if (id == null)
                {

                }
                else 
                { 
                
                    currentJewel = jewelController.getJewelById(int.Parse(id));

                    jnameTB.Text = currentJewel.JewelName;
                    DropDownList1.DataSource = jewelController.getCategories();
                    DropDownList1.DataTextField = "CategoryName"; // yang ditampilkan
                    DropDownList1.DataValueField = "CategoryID";  // value (ID)
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Choose category", ""));
                    DropDownList1.Items[0].Attributes.Add("disabled", "disabled");

                    // Set selected value sesuai dengan category dari currentJewel
                    DropDownList1.SelectedValue = currentJewel.MsCategory.CategoryID.ToString();


                    DropDownList2.DataSource = jewelController.getBrands();
                    DropDownList2.DataTextField = "BrandName"; // yang ditampilkan
                    DropDownList2.DataValueField = "BrandID";  // value (ID)
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(0, new ListItem("Choose brand", ""));
                    DropDownList2.Items[0].Attributes.Add("disabled", "disabled");
                    DropDownList2.SelectedValue = currentJewel.MsBrand.BrandID.ToString();
                    

                    jpriceTB.Text = Convert.ToString( currentJewel.JewelPrice);
                    jyearTB.Text = Convert.ToString( currentJewel.JewelReleaseYear);
                }
            }



        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["jewelId"]);

            string response = jewelController.editJewel(id,
                jnameTB.Text,
                int.Parse(DropDownList1.SelectedValue),
                int.Parse(DropDownList2.SelectedValue),
                jpriceTB.Text,
                jyearTB.Text
                );

            if ( response.Equals("success"))
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
using PSD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class Register : System.Web.UI.Page
    {
        //RegisterController userController = new RegisterController();
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.VisibleDate = new DateTime(2010, 1, 1);
            }
            else
            { 
                passwordTB.Attributes["value"] = passwordTB.Text;
                cpasswordTB.Attributes["value"] = cpasswordTB.Text;
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string email = emailTB.Text;
            string username = usernameTB.Text;
            string password = passwordTB.Text;
            string cpw = cpasswordTB.Text;
            string gender = genderList.SelectedValue.ToString();
            DateTime dob = Calendar1.SelectedDate;

            string response =  userController.register(email, username, password, cpw, gender, dob);
            if (response.Equals("success"))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblError.Text = response;
            }
            
        }
    }
}
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
    public partial class Profile : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["user"];
            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }

            oldTB.Attributes["value"] = oldTB.Text;
            newTB.Attributes["value"] = newTB.Text;
            confirmTB.Attributes["value"] = confirmTB.Text;

            if (!IsPostBack)
            {
                lblUserNameValue.Text = user.UserName;
                lblEmailValue.Text = user.UserEmail;
                lblDOBValue.Text = user.UserDOB.ToString("yyyy-MM-dd");
                lblGenderValue.Text = user.UserGender;
                lblRoleValue.Text = user.UserRole;
            }
        }

        protected void btnEditPassword_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["user"];
            string oldPassword = oldTB.Text;
            string newPassword = newTB.Text;
            string confirmPassword = confirmTB.Text;
            string currentPassword = user.UserPassword;
            string response = userController.changePassword( user.UserID, oldPassword, newPassword, confirmPassword, currentPassword);

            if (response.Equals("success"))
            {
                lblError.ForeColor = System.Drawing.Color.Green;   
                lblError.Text = "Password changed successfully";
            }
            else
            {
                //lblError.ForeColor = ;
                lblError.Text = response;
            }


        }
    }
}
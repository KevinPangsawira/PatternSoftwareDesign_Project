using PSD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class Login : System.Web.UI.Page
    {
        LoginController loginController = new LoginController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailTB.Text;
            string password = passwordTB.Text;
            bool rememberMe = rememberMeCB.Checked;
            string response = loginController.validationLogin(email, password);
            if ( response.Equals(""))
            {

                Session["user"] = loginController.getUser(email, password);

                if (rememberMe) { 
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = (loginController.getUser(email, password).UserID).ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);

                }

                Response.Redirect("Home.aspx");
            }
            else
            {
                lblError.Text = response;
            }
        }
    }
}
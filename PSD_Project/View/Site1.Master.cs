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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //LoginHandler loginHandler = new LoginHandler();
            UserController userController = new UserController();
            MsUser user = new MsUser();
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                //Response.Redirect("Home.aspx");
                user = null;
            }

            else
            {
                if (Session["user"] == null)
                {
                    int id = int.Parse(Request.Cookies["user_cookie"].Value);
                    user = userController.getUserById(id);
                    Session["user"] = user;
                }
                else
                {
                    user = (MsUser)Session["user"];

                }
            }

            if (user != null)
            {
                if (user.UserName != null) userNow.Text = user.UserName;

                if (user.UserRole.Equals("Customer"))
                {
                    loginNav.Visible = false;
                    registerNav.Visible = false;
                    addNav.Visible = false;
                    reportsNav.Visible = false;
                    handleOrdersNav.Visible = false;
                }
                else if (user.UserRole.Equals("Admin"))
                {
                    loginNav.Visible = false;
                    registerNav.Visible = false;
                    myOrdersNav.Visible = false;
                }

            }

            else
            {
                cartNav.Visible = false;
                myOrdersNav.Visible = false;
                profileNav.Visible = false;
                logoutNav.Visible = false;
                addNav.Visible = false;
                reportsNav.Visible = false;
                handleOrdersNav.Visible = false;



            }
        }
    }
}
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
                    cartNav.Visible = false;
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

        protected void loginNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");
        }

        protected void homeNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void registerNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void cartNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartCustomer.aspx");
        }

        protected void myOrdersNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyOrders.aspx");
        }

        protected void addNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddJewel.aspx");
        }

        protected void reportsNav_Click(object sender, EventArgs e)
        {

        }

        protected void handleOrdersNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("HandleOrders.aspx");
        }

        protected void profileNav_Click(object sender, EventArgs e)
        {

        }

        protected void logoutNav_Click(object sender, EventArgs e)
        {

        }
    }
}
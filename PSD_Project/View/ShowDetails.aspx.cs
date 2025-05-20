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
        MsUser user = new MsUser();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (MsUser)Session["user"];
            if (!IsPostBack) {
                string id = Request["jewelId"];
                if (id == null) {
                    //jika mencoba akses 'ShowDetails.aspx' dari url akan kembali ke 'Home.aspx' karena 
                    //    tidak lewat tombol View Detail
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    MsJewel jewel = jewelController.getJewelById(int.Parse(id));
                    GridView2.DataSource = new List<MsJewel> { jewel };
                    GridView2.DataBind();

                }
                //Hilangkan kolom button untuk Guest
                if ( user == null)
                {
                    int buttonCol = GridView2.Columns.Count - 1;
                    GridView2.Columns[buttonCol].Visible = false;
                }

            }
            
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            

            jewelController.addToCart( user.UserID,  int.Parse(id));

            Response.Redirect("CartCustomer.aspx");
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int jewelId = (int)GridView2.DataKeys[e.RowIndex].Value;
            jewelController.removeJewel(jewelId);
            Response.Redirect("Home.aspx");
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // int.Parse untuk dari string ke int
            int jewelId = (int)(GridView2.DataKeys[e.NewEditIndex].Value );
            Response.Redirect("./EditJewel.aspx?jewelId=" + jewelId);
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //RowDataBound supaya bisa modifikasi tiap baris setelah dirender   

            Button addBtn = (Button)e.Row.FindControl("addBtn");
            Button editBtn = (Button)e.Row.FindControl("editBtn");
            Button deleteBtn = (Button)e.Row.FindControl("deleteBtn");

            

            if (e.Row.RowType == DataControlRowType.DataRow) {
                if (user == null)
                {
                    //hilangkan button

                }
                else
                {
                    if (user.UserRole.Equals("Customer"))
                    {
                        editBtn.Visible = false;
                        deleteBtn.Visible = false;
                    }
                    else
                    {
                        addBtn.Visible = false;
                    }
                }
            }
            
        }
    }
}
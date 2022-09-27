using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class Login : System.Web.UI.Page
    {
        //Note: add method for admin/client login
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUsername.Focus();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["username"] = txtUsername.Text;
            Session["password"] = txtPassword.Text;
            Response.Redirect("HomePage.aspx");

        }
    }
}
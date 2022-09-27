using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class DeleteSupplier : System.Web.UI.Page
    {
        //Note: add method to display data
        //Method to filter data
        //Method to populate dropdown list
        //Method to delete
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Supplier deleted";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
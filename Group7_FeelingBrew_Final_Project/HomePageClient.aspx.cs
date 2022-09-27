using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class HomePageClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPlaceSO_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesOrderClient.aspx");
        }

        protected void btnViewSO_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewSOClient.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ClientHelp.pdf");
        }
    }
}
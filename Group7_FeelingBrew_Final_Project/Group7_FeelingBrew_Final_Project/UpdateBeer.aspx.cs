using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class UpdateBeer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Session["beerName"] = txtBeerName.Text;
            Session["beerDesc"] = txtBeerDesc.Text;
            Session["beerPrice"] = txtBeerPrice.Text;
            Session["beerSize"] = txtBottleSize.Text;
            Session["beerQty"] = txtQtyOnHand.Text;

            lblMessage.Text = "Beer updated!";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddClient.aspx");
        }

        protected void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSupplier.aspx");
        }

        protected void btnAddBeer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBeer.aspx");
        }

        protected void btnAddIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddIngredient.aspx");
        }

        protected void btnUpdateClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateClient.aspx");
        }

        protected void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateSupplier.aspx");
        }

        protected void btnUpdateBeer_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateBeer.aspx");
        }

        protected void btnUpdateIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateIngredient.aspx");
        }

        protected void btnDeleteClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteClient.aspx");
        }

        protected void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteSupplier.aspx");
        }

        protected void btnDeleteBeer_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteBeer.aspx");
        }

        protected void btnDeleteIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteIngredient.aspx");
        }

        protected void btnPlaceSO_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesOrderAdmin.aspx");
        }

        protected void btnViewSO_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewSOAdmin.aspx");
        }

        protected void btnPlacePO_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseOrder.aspx");
        }

        protected void btnViewPO_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPO.aspx");
        }

        protected void btnCustom_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports.aspx");
        }
    }
}
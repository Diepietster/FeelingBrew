using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class UpdateIngredient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Session["ingrDesc"] = txtIngrDesc.Text;
            Session["ingrCost"] = txtIngrCost.Text;
            Session["ingrQty"] = txtQtyOnHand.Text;
            Session["ingrUnitType"] = ddListIngrUnitType.SelectedValue;
            Session["ingrSupplier"] = ddListSupplier.SelectedValue;

            lblMessage.Text = "Ingredient updated!";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
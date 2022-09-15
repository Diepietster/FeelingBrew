using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    //Note: method to add ingredient
    //Note: method to populate ingrUnitType dropdown list
    //Note: method to populate supplier dropdown list
    public partial class AddIngredient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                txtIngrDesc.Focus();
                txtIngrDesc.Text = string.Empty;
                txtIngrCost.Text = string.Empty;
                txtQtyOnHand.Text = string.Empty;
                ddListIngrUnitType.SelectedIndex = 0;
                ddListSupplier.SelectedIndex = 0;
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["ingrDesc"] = txtIngrDesc.Text;
            Session["ingrCost"] = txtIngrCost.Text;
            Session["ingrQty"] = txtQtyOnHand.Text;
            Session["ingrUnitType"] = ddListIngrUnitType.SelectedValue;
            Session["ingrSupplier"] = ddListSupplier.SelectedValue;
            lblMessage.Text = "Ingredient added!";
        }
    }
}
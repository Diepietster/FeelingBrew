using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    //Note: method to add beer
    public partial class AddBeer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                txtBeerName.Focus();
                txtBeerName.Text = string.Empty;
                txtBeerDesc.Text = string.Empty;
                txtBeerPrice.Text = string.Empty;
                txtBottleSize.Text = string.Empty;
                txtQtyOnHand.Text = string.Empty;
                lblMessage.Text = string.Empty;
            }
        }

        private SqlConnection conn = new SqlConnection(@"Data Source=feelingbrewwebapp.database.windows.net;Database=FeelingBrewWebDb;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5");
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["beerName"] = txtBeerName.Text;
            Session["beerDesc"] = txtBeerDesc.Text;
            Session["beerPrice"] = txtBeerPrice.Text;
            Session["beerSize"] = txtBottleSize.Text;
            Session["beerQty"] = txtQtyOnHand.Text;
            conn.Open();
            cmd = new SqlCommand($"INSERT INTO Beers(BeerName, BeerDescription, BeerUnitPricePerBottle, BeerBottleSize, BeerQtyOnHand) VALUES('{Session["beerName"]}','{Session["beerDesc"]}','{Session["beerPrice"]}','{Session["beerSize"]}','{Session["beerQty"]}')", conn);
            adapter.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
            lblMessage.Text = "Beer added!";
        }
    }
}
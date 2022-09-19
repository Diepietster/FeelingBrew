using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                populateIngrUnitTypeList();
                populateSupplierList();
            }
        }

        private void populateIngrUnitTypeList()
        {
            ddListIngrUnitType.Items.Clear();
            conn.Open();
            cmd = new SqlCommand(@"SELECT IngrUnitTypeCode, IngrUnitTypeDesc FROM IngredientUnitType", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ddListIngrUnitType.Items.Add("ID: " + reader.GetValue(0) + " - Ingredient Unit Type Name: " + reader.GetValue(1));
            }
            conn.Close();
        }

        private void populateSupplierList()
        {
            ddListSupplier.Items.Clear();
            conn.Open();
            cmd = new SqlCommand(@"SELECT SplrCode, SplrName FROM Suppliers", conn);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                ddListSupplier.Items.Add("ID: " + reader.GetValue(0) + " - Supplier Name: " + reader.GetValue(1));
            }
            conn.Close();
        }

        private SqlConnection conn = new SqlConnection(@"Data Source=feelingbrewwebapp.database.windows.net;Database=FeelingBrewWebDb;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5");
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["ingrDesc"] = txtIngrDesc.Text;
            Session["ingrCost"] = txtIngrCost.Text;
            Session["ingrQty"] = txtQtyOnHand.Text;

            String[] strIngrUnitType;
            strIngrUnitType = ddListIngrUnitType.SelectedItem.Text.Split(' ');
            string ingrUnitTypeIDString = strIngrUnitType[1];
            int ingrUnitTypeID = int.Parse(ingrUnitTypeIDString);

            String[] strSupplier;
            strSupplier = ddListSupplier.SelectedItem.Text.Split(' ');
            string ingrSupplierString = strSupplier[1];
            int ingrSupplierID = int.Parse(ingrSupplierString);

            conn.Open();
            cmd = new SqlCommand($"INSERT INTO Ingredients (IngrDescription, IngrLatestCost, QtyOnHand, IngrUnitTypeCode, SplrCode) VALUES('{Session["ingrDesc"]}','{Session["ingrCost"]}','{Session["ingrQty"]}','{ingrUnitTypeID}','{ingrSupplierID}')", conn);
            DataSet ds = new DataSet();
            adapter.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();

            lblMessage.Text = "Ingredient added!";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class DeleteIngredient : System.Web.UI.Page
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
                fillDropDownList();
                fillGridView();
            }
        }

        private SqlConnection conn = new SqlConnection(@"Data Source=feelingbrewwebapp.database.windows.net;Database=FeelingBrewWebDb;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5");
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;

        private void fillDropDownList()
        {
            ddListIngredient.Items.Clear();
            conn.Open();
            cmd = new SqlCommand(@"SELECT IngredientCode,IngrDescription FROM Ingredients", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ddListIngredient.Items.Add("ID: " + reader.GetValue(0) + " - Ingredient Description: " + reader.GetValue(1));
            }
            conn.Close();
        }

        private void fillGridView()
        {
            conn.Open();
            cmd = new SqlCommand(@"SELECT IngredientCode AS [Ingredient Code], IngrDescription AS [Ingredient Description], IngrLatestCost AS [Ingredient - Latest Cost], QtyOnHand AS [Ingredient - Quantity on Hand], IngrUnitTypeCode AS [Ingredient Unit Type Code], SplrCode AS [Supplier Code] FROM Ingredients", conn);
            DataSet ds = new DataSet();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            gridViewIngredients.DataSource = ds;
            gridViewIngredients.DataBind();
            conn.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String[] str;
            str = ddListIngredient.SelectedItem.Text.Split(' ');
            string ingrIDString = str[1];
            int ingrID = int.Parse(ingrIDString);
            conn.Open();
            cmd = new SqlCommand($"DELETE FROM Ingredients WHERE IngredientCode = '{ingrID}'", conn);
            adapter.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
            fillDropDownList();
            fillGridView();
            lblMessage.Text = "Ingredient deleted!";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["filterIngredient"] = txtFilterIngredient.Text;
            conn.Open();
            if (txtFilterIngredient.Text != "")
            {
                cmd = new SqlCommand($"SELECT IngredientCode AS [Ingredient Code], IngrDescription AS [Ingredient Description], IngrLatestCost AS [Ingredient - Latest Cost], QtyOnHand AS [Ingredient - Quantity on Hand], IngrUnitTypeCode AS [Ingredient Unit Type Code], SplrCode AS [Supplier Code] FROM Ingredients WHERE IngrDescription LIKE '%{Session["filterIngredient"]}%' OR IngrLatestCost LIKE '%{Session["filterIngredient"]}%' OR QtyOnHand LIKE '%{Session["filterIngredient"]}%' OR IngrUnitTypeCode LIKE '%{Session["filterIngredient"]}%' OR SplrCode LIKE '%{Session["filterIngredient"]}%'", conn);
            }
            else
            {
                cmd = new SqlCommand($"SELECT IngredientCode AS [Ingredient Code], IngrDescription AS [Ingredient Description], IngrLatestCost AS [Ingredient - Latest Cost], QtyOnHand AS [Ingredient - Quantity on Hand], IngrUnitTypeCode AS [Ingredient Unit Type Code], SplrCode AS [Supplier Code] FROM Ingredients", conn);
            }
            DataSet ds = new DataSet();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            gridViewIngredients.DataSource = ds;
            gridViewIngredients.DataBind();
            conn.Close();
        }
    }
}
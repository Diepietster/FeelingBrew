using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class UpdateIngredient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblMessage.Text = string.Empty;
                fillGridView();
                fillDropDownList();
                populateIngrUnitTypeList();
                populateSupplierList();
            }
        }

        private SqlConnection conn = new SqlConnection(@"Data Source=feelingbrewwebapp.database.windows.net;Database=FeelingBrewWebDb;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5");
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;

        private List<T> Getlist<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                var type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                foreach (var prop in type.GetProperties())
                {
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                }
                list.Add(obj);
            }
            return list;
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
            while (reader.Read())
            {
                ddListSupplier.Items.Add("ID: " + reader.GetValue(0) + " - Supplier Name: " + reader.GetValue(1));
            }
            conn.Close();
        }

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Session["ingrDesc"] = txtIngrDesc.Text;
            Session["ingrCost"] = txtIngrCost.Text;
            Session["ingrQty"] = txtQtyOnHand.Text;
            Session["ingrUnitType"] = ddListIngrUnitType.SelectedValue;
            Session["ingrSupplier"] = ddListSupplier.SelectedValue;

            conn.Open();
            String[] str;
            str = ddListIngredient.SelectedItem.Text.Split(' ');
            string ingrIDString = str[1];
            int ingrID = int.Parse(ingrIDString);
            str = ddListSupplier.SelectedItem.Text.Split(' ');
            string splrIDString = str[1];
            int splrID = int.Parse(splrIDString);
            str = ddListIngrUnitType.SelectedItem.Text.Split(' ');
            string unitTypeIDString = str[1];
            int unitTypeID = int.Parse(unitTypeIDString);
            cmd = new SqlCommand($"UPDATE Ingredients SET IngrDescription = '{Session["ingrDesc"]}', IngrLatestCost = '{Session["ingrCost"]}', QtyOnHand = '{Session["ingrQty"]}', IngrUnitTypeCode = '{unitTypeID}', SplrCode = '{splrID}' WHERE IngredientCode = '{ingrID}'", conn);
            adapter.UpdateCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
            lblMessage.Text = "Beer updated!";
            fillDropDownList();
            fillGridView();

            lblMessage.Text = "Ingredient updated!";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
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

        protected void ddListIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Ingredient> ingrList = null;
            String[] str;
            str = ddListIngredient.SelectedItem.Text.Split(' ');
            string ingrIDString = str[1];
            int ingrID = int.Parse(ingrIDString);

            int ingrMaximum = 0; // Maximum amount of rows in Ingredients Table
            int splrMaximum = 0; // Maximum amount of suppliers in Suppliers Table

            conn.Open();
            cmd = new SqlCommand($"SELECT COUNT(IngredientCode) FROM Ingredients", conn); // Count amount of rows in Ingredients Table
            ingrMaximum = (int)cmd.ExecuteScalar(); // Assign Count to Integer using cmd.ExecuteScalar()
            cmd = new SqlCommand($"SELECT COUNT(SplrCode) FROM Suppliers", conn); // Count amount of rows in Suppliers Table
            splrMaximum = (int)cmd.ExecuteScalar(); // Assign Count to Integer using cmd.ExecuteScalar()
            cmd = new SqlCommand($"SELECT * FROM Ingredients WHERE IngredientCode = '{ingrID}'", conn);
            var dataReader = cmd.ExecuteReader();
            ingrList = Getlist<Ingredient>(dataReader);


            if (ingrList != null)
            {
                txtIngrDesc.Text = ingrList[0].IngrDescription;
                txtIngrCost.Text = ingrList[0].IngrLatestCost.ToString();
                int ingrUnitTypeToSelect = ingrList[0].IngrUnitTypeCode;
                int splrToSelect = ingrList[0].SplrCode;
                bool stop = false;
                int counter = 0;
                while(!stop && counter < ingrMaximum) // See when sub-string of drop down matches ingrUnitTypeToSelect
                {
                    String[] strUnitType;
                    ddListIngrUnitType.SelectedIndex = counter;
                    strUnitType = ddListIngrUnitType.SelectedItem.Text.Split(' ');
                    string ingrUnitTypeString = strUnitType[1];
                    int ingrUnitTypeID = int.Parse(ingrUnitTypeString);
                    if (ingrUnitTypeID.Equals(ingrUnitTypeToSelect))
                    {
                        stop = true;
                        ddListIngredient.SelectedIndex = counter;
                    }
                    counter++;
                }
                stop = false;
                counter = 0;
                while (!stop && counter < splrMaximum) // See when sub-string of drop down matches ingrUnitTypeToSelect
                {
                    String[] strSplrType;
                    ddListSupplier.SelectedIndex = counter;
                    strSplrType = ddListSupplier.SelectedItem.Text.Split(' ');
                    string splrTypeString = strSplrType[1];
                    int splrTypeID = int.Parse(splrTypeString);
                    if (splrTypeID.Equals(splrToSelect))
                    {
                        stop = true;
                        ddListSupplier.SelectedIndex = counter;
                    }
                    counter++;
                }
                txtQtyOnHand.Text = ingrList[0].QtyOnHand.ToString();
            }

            conn.Close();
        }
    }
}
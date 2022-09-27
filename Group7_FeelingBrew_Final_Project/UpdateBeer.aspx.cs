using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                fillDropDownList();
                fillGridView();
            }
        }

        private List<T> Getlist<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            while(reader.Read())
            {
                var type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                foreach(var prop in type.GetProperties())
                {
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                }
                list.Add(obj);
            }
            return list;
        }

        private void fillDropDownList()
        {
            ddListBeer.Items.Clear();
            conn.Open();
            cmd = new SqlCommand(@"SELECT BeerCode,BeerName FROM Beers", conn);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                ddListBeer.Items.Add("ID: " + reader.GetValue(0) + " - Beer Name: " + reader.GetValue(1));
            }
            conn.Close();
        }

        private void fillGridView()
        {
            conn.Open();
            cmd = new SqlCommand(@"SELECT * FROM Beers", conn);
            DataSet ds = new DataSet();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            gridViewBeers.DataSource = ds;
            gridViewBeers.DataBind();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Session["beerName"] = txtBeerName.Text;
            Session["beerDesc"] = txtBeerDesc.Text;
            Session["beerPrice"] = txtBeerPrice.Text;
            Session["beerSize"] = txtBottleSize.Text;
            Session["beerQty"] = txtQtyOnHand.Text;
            String[] str;
            str = ddListBeer.SelectedItem.Text.Split(' ');
            string beerIDString = str[1];
            int beerID = int.Parse(beerIDString);
            conn.Open();
            cmd = new SqlCommand($"UPDATE Beers SET BeerName = '{Session["beerName"]}', BeerDescription = '{Session["beerDesc"]}', BeerUnitPricePerBottle = '{Session["beerPrice"]}', BeerBottleSize = '{Session["beerSize"]}', BeerQtyOnHand = '{Session["beerQty"]}' WHERE BeerCode = '{beerID}'", conn);
            adapter.UpdateCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
            lblMessage.Text = "Beer updated!";
            fillDropDownList();
            fillGridView();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["filterBeer"] = txtFilterBeer.Text;
            conn.Open();
            if (txtFilterBeer.Text != "")
            {
                cmd = new SqlCommand($"SELECT * FROM Beers WHERE BeerName LIKE '%{Session["filterBeer"]}%' OR BeerDescription LIKE '%{Session["filterBeer"]}%' OR BeerUnitPricePerBottle LIKE '%{Session["filterBeer"]}%' OR BeerBottleSize LIKE '%{Session["filterBeer"]}%' OR BeerQtyOnHand LIKE '%{Session["filterBeer"]}%'", conn);
            }
            else
            {
                cmd = new SqlCommand($"SELECT * FROM Beers", conn);
            }
            DataSet ds = new DataSet();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            gridViewBeers.DataSource = ds;
            gridViewBeers.DataBind();
            conn.Close();
        }

        protected void ddListBeer_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Beer> beerList = null;
            String[] str;
            str = ddListBeer.SelectedItem.Text.Split(' ');
            string beerIDString = str[1];
            int beerID = int.Parse(beerIDString);

            conn.Open();
            cmd = new SqlCommand($"SELECT * FROM Beers WHERE BeerCode = '{beerID}'", conn);
            var dataReader = cmd.ExecuteReader();
            beerList = Getlist<Beer>(dataReader);

            if(beerList != null)
            {
                txtBeerName.Text = beerList[0].BeerName;
                txtBeerDesc.Text = beerList[0].BeerDescription;
                txtBeerPrice.Text = beerList[0].BeerUnitPricePerBottle.ToString();
                txtBottleSize.Text = beerList[0].BeerBottleSize.ToString();
                txtQtyOnHand.Text = beerList[0].BeerQtyOnHand.ToString();
            }

            conn.Close();
        }
    }
}
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
    public partial class DeleteBeer : System.Web.UI.Page
    {
        //Note: add method to display data
        //Method to filter data
        //Method to populate dropdown list
        //Method to delete
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Page.IsPostBack == false)
            {
                lblMessage.Text = string.Empty;
                fillDropDownList();
                fillGridView();
            }
            
        }

        private void fillDropDownList()
        {
            ddListBeer.Items.Clear();
            conn.Open();
            cmd = new SqlCommand(@"SELECT BeerCode,BeerName FROM Beers", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ddListBeer.Items.Add("ID: " + reader.GetValue(0) + " - Beer Name: " + reader.GetValue(1));
            }
            conn.Close();
        }

        private void fillGridView()
        {
            conn.Open();
            cmd = new SqlCommand(@"SELECT BeerCode AS [Beer Code], BeerName AS [Beer Name], BeerDescription AS [Beer Description], BeerUnitPricePerBottle AS [Beer Unit Price Per Bottle], BeerBottleSize AS [Beer Bottle Size - ml], BeerQtyOnHand AS [Beer - Quantity On Hand] FROM Beers", conn);
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String[] str;
            str = ddListBeer.SelectedItem.Text.Split(' ');
            string beerIDString = str[1];
            int beerID = int.Parse(beerIDString);
            conn.Open();
            cmd = new SqlCommand($"DELETE FROM Beers WHERE BeerCode = '{beerID}'", conn);
            adapter.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
            lblMessage.Text = "Beer deleted!";
            fillDropDownList();
            fillGridView();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["filterBeer"] = txtFilterBeer.Text;
            conn.Open();
            if (txtFilterBeer.Text != "")
            {
                cmd = new SqlCommand($"SELECT BeerCode AS [Beer Code], BeerName AS [Beer Name], BeerDescription AS [Beer Description], BeerUnitPricePerBottle AS [Beer Unit Price Per Bottle], BeerBottleSize AS [Beer Bottle Size - ml], BeerQtyOnHand AS [Beer - Quantity On Hand] FROM Beers WHERE BeerName LIKE '%{Session["filterBeer"]}%' OR BeerDescription LIKE '%{Session["filterBeer"]}%' OR BeerUnitPricePerBottle LIKE '%{Session["filterBeer"]}%' OR BeerBottleSize LIKE '%{Session["filterBeer"]}%' OR BeerQtyOnHand LIKE '%{Session["filterBeer"]}%'", conn);
            }
            else
            {
                cmd = new SqlCommand($"SELECT BeerCode AS [Beer Code], BeerName AS [Beer Name], BeerDescription AS [Beer Description], BeerUnitPricePerBottle AS [Beer Unit Price Per Bottle], BeerBottleSize AS [Beer Bottle Size - ml], BeerQtyOnHand AS [Beer - Quantity On Hand] FROM Beers", conn);
            }
            DataSet ds = new DataSet();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            gridViewBeers.DataSource = ds;
            gridViewBeers.DataBind();
            conn.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class DeleteClient : System.Web.UI.Page
    {
        //public string connStr = @"Server=tcp:feelingbrewwebapp.database.windows.net,1433;Initial Catalog=FeelingBrewWebDb;Persist Security Info=False;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string connStr = @"Server=localhost; Database=FeelingBrewWebDb; Trusted_Connection=True;";
        public SqlConnection myConn;
        public SqlCommand myCommand;
        public DataSet myData;
        public SqlDataAdapter myAdapter;
        public SqlDataReader myReader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblMessage.Text = string.Empty;
                populateClientList();
                viewData();
            }  
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Session["cCode"] = ddListClients.SelectedValue;
            
            myConn = new SqlConnection(connStr);
            myConn.Open();

            
            string sqlDelete = $"DELETE FROM Client" +
                $" WHERE ClientCode = '{Session["cCode"]}'";

            myCommand = new SqlCommand(sqlDelete, myConn);

            myAdapter = new SqlDataAdapter();
            myData = new DataSet();

            myAdapter.DeleteCommand = myCommand;
            myAdapter.DeleteCommand.ExecuteNonQuery();
 
            viewData();
            populateClientList();

            myCommand.Dispose();
            myConn.Close();
            lblMessage.Text = "Client deleted!";
            txtFilterClients.Text = string.Empty;
        }        

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Session["txtFilter"] = txtFilterClients.Text;

            myConn = new SqlConnection(connStr);
            myConn.Open();

            string sql_Filter = $"SELECT  Cl.ClientCode , Cl.ClientName , Cl.ClientSurname  , Cl.ClientCellphone  , Cl.ClientStreetNumber   , Cl.ClientStreetName   , Cl.ClientType    , Ct.CityName,     P.ProvinceName  " +
                $"FROM  Client Cl " +
                $"LEFT JOIN City Ct  " +
                $"ON Cl.CityCode = Ct.CityCode " +
                $"LEFT JOIN Province P " +
                $"ON Cl.ProvinceCode = P.ProvinceCode " +
                $"WHERE Cl.ClientCode LIKE '%{Session["txtFilter"]}%' OR Cl.ClientName LIKE '%{Session["txtFilter"]}%' " +
                $"OR Cl.ClientSurname LIKE '%{Session["txtFilter"]}%' OR Cl.ClientCellphone LIKE '%{Session["txtFilter"]}%' " +
                $"OR Cl.ClientStreetNumber LIKE '%{Session["txtFilter"]}%' OR Cl.ClientStreetName LIKE '%{Session["txtFilter"]}%' " +
                $"OR Cl.ClientType LIKE '%{Session["txtFilter"]}%' OR Ct.CityName LIKE '%{Session["txtFilter"]}%' OR P.ProvinceName LIKE '%{Session["txtFilter"]}%' ;";


            myCommand = new SqlCommand(sql_Filter, myConn);

            ShowData();
            myCommand.Dispose();
            myConn.Close();
        }

        public void populateClientList()
        {
            ddListClients.Items.Clear();
            myConn = new SqlConnection(connStr);
            myConn.Open();

            string sqlClients = $"SELECT ClientCode " +
                $"FROM Client;";

            myCommand = new SqlCommand(sqlClients, myConn);

            myAdapter = new SqlDataAdapter();
            myData = new DataSet();
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                ddListClients.Items.Insert(0, new ListItem(myReader.GetValue(0).ToString(), myReader.GetValue(0).ToString()));
            }

            ddListClients.Items.Insert(0, new ListItem("Please Select", string.Empty));
            ddListClients.SelectedIndex = 0;

            myCommand.Dispose();
            myConn.Close();
        }

        public void viewData()
        {
            myConn = new SqlConnection(connStr);
            myConn.Open();

            string sqlView = $"SELECT Cl.ClientCode , Cl.ClientName , Cl.ClientSurname  , Cl.ClientCellphone  , Cl.ClientStreetNumber   , Cl.ClientStreetName   , Cl.ClientType    , Ct.CityName,     P.ProvinceName  " +
                $" FROM  Client Cl, City Ct,  Province P Where Cl.CityCode = Ct.CityCode and Cl.ProvinceCode = P.ProvinceCode; ";

            myCommand = new SqlCommand(sqlView, myConn);

            ShowData();

            myConn.Close();
        }

        public void ShowData()
        {
            myAdapter = new SqlDataAdapter();
            myData = new DataSet();
            myAdapter.SelectCommand = myCommand;
            myAdapter.Fill(myData);

            gridViewClient.DataSource = myData;
            gridViewClient.DataBind();
        }
    }
}
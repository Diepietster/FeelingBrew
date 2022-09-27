using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group7_FeelingBrew_Final_Project.Entities;
using Group7_FeelingBrew_Final_Project.Helper_Methods;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class UpdateClient : System.Web.UI.Page
    {
        //public string connStr = @"Server=tcp:feelingbrewwebapp.database.windows.net,1433;Initial Catalog=FeelingBrewWebDb;Persist Security Info=False;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string connStr = @"Server=localhost; Database=FeelingBrewWebDb; Trusted_Connection=True;";
        public SqlConnection myConn;
        public SqlCommand myCommand;
        public DataSet myData;
        public SqlDataAdapter myAdapter;
        public SqlDataReader myReader;
        public HelperMethods _helper_Methods = new HelperMethods();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblMessage.Text = string.Empty;
                populateCity();
                populateProvince();
                viewData();
                populateClientList();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Session["cCode"] = ddListClients.SelectedValue; 
            Session["clientName"] = txtCName.Text;
            Session["clientSurname"] = txtCSurname.Text;
            Session["cCellNo"] = txtCCellphone.Text;
            Session["cProvince"] = ddListProvince.SelectedValue;
            Session["cStreetNo"] = txtCStreetNo.Text;
            Session["cStreetname"] = txtCStreetName.Text;
            Session["cCity"] = ddListCity.SelectedValue;
            Session["cType"] = ddListClientType.SelectedValue;

            myConn = new SqlConnection(connStr);
            myConn.Open();
            string sqlUpdate = $"UPDATE Client " +
                $"SET ClientName = '{Session["clientName"]}', ClientSurname = '{Session["clientSurname"]}', ClientCellphone = '{Session["cCellNo"]}', ClientStreetNumber = '{Session["cStreetNo"]}', ClientStreetName = '{Session["cStreetname"]}', ClientType = '{Session["cType"]}', CityCode = '{Session["cCity"]}', ProvinceCode = '{Session["cProvince"]}' " +
                $" WHERE ClientCode = '{Session["cCode"]}'"; 
;
            myCommand = new SqlCommand(sqlUpdate, myConn);

            myCommand.ExecuteNonQuery();

            populateCity();
            populateProvince();
            viewData();
            populateClientList();
            myCommand.Dispose();
            myConn.Close();

            lblMessage.Text = "Client updated!";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        public void populateCity()
        {
            ddListCity.Items.Clear();
            List<City> cityList = _helper_Methods.populateCity();

            foreach (var city in cityList)
            {
                ddListCity.Items.Insert(0, new ListItem(city.CityName, city.CityCode.ToString()));
            }

            ddListCity.Items.Insert(0, new ListItem("Please Select", string.Empty));
            ddListCity.SelectedIndex = 0;

        }

        public void populateProvince()
        {
            ddListProvince.Items.Clear();

            List<Province> provinceList = _helper_Methods.populateProvince();

            foreach (var province in provinceList)
            {
                ddListProvince.Items.Insert(0, new ListItem(province.ProvinceName, province.ProvinceCode.ToString()));
            }  

            ddListProvince.Items.Insert(0, new ListItem("Please Select", string.Empty));
            ddListProvince.SelectedIndex = 0;

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
                $"WHERE Cl.ClientCode LIKE '%{Session["txtFilter"]}%' OR Cl.ClientName LIKE '%{Session["txtFilter"]}%' OR Cl.ClientSurname LIKE '%{Session["txtFilter"]}%' OR Cl.ClientCellphone LIKE '%{Session["txtFilter"]}%' OR Cl.ClientStreetNumber LIKE '%{Session["txtFilter"]}%' OR Cl.ClientStreetName LIKE '%{Session["txtFilter"]}%' OR Cl.ClientType LIKE '%{Session["txtFilter"]}%' OR Ct.CityName LIKE '%{Session["txtFilter"]}%' OR P.ProvinceName LIKE '%{Session["txtFilter"]}%' ;";

            myCommand = new SqlCommand(sql_Filter, myConn);

            ShowData();
            myCommand.Dispose();
            myConn.Close();
        }

        protected void ddListClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Client> clientList = null;
            Session["cCode"] = ddListClients.SelectedValue;

            myConn = new SqlConnection(connStr);
            myConn.Open();

            string sqlSelectName = $"SELECT * " +
                $"FROM Client " +
                $" WHERE ClientCode = '{Session["cCode"]}'";

            myCommand = new SqlCommand(sqlSelectName, myConn);
            var dataReader = myCommand.ExecuteReader();
            clientList = _helper_Methods.Getlist<Client>(dataReader);

            if (clientList != null)
            {
                txtCName.Text = clientList[0].ClientName;
                txtCSurname.Text = clientList[0].ClientSurname;
                txtCCellphone.Text = clientList[0].ClientCellphone;
                txtCStreetNo.Text = clientList[0].ClientStreetNumber;
                txtCStreetName.Text = clientList[0].ClientStreetName;
                var provinceToSelect = clientList[0].ProvinceCode;
                var clientToSelect = clientList[0].ClientType;
                var cityToSelect = clientList[0].CityCode;

                try
                {
                    ddListProvince.SelectedValue = Convert.ToString(provinceToSelect);
                    ddListCity.SelectedValue = Convert.ToString(cityToSelect);
                    ddListClientType.SelectedValue = clientToSelect;

                }
                catch (Exception)
                {
                    
                }
            }
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

        public void populateClientList()
        {
            ddListClients.Items.Clear();
            myConn = new SqlConnection(connStr);
            myConn.Open();

            string sqlClients = $"SELECT ClientCode " +
                $"FROM Client ORDER BY ClientCode ASC;";

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
        
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Group7_FeelingBrew_Final_Project.Helper_Methods;
using Group7_FeelingBrew_Final_Project.Entities;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class AddClient : System.Web.UI.Page
    {
        //public string connStr = @"Server=tcp:feelingbrewwebapp.database.windows.net,1433;Initial Catalog=FeelingBrewWebDb;Persist Security Info=False;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string connStr = @"Server=localhost; Database=FeelingBrewWebDb; Trusted_Connection=True;";
        public SqlConnection myConn;
        public SqlCommand myCommand;
        public DataSet myData;
        public SqlDataAdapter myAdapter;
        public SqlDataReader myReader;
        public HelperMethods _helperMethods = new HelperMethods();

        //Note: method to add client
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                txtCName.Focus();
                txtCName.Text = string.Empty;
                txtCSurname.Text = string.Empty;
                txtCCellphone.Text = string.Empty;
                ddListProvince.SelectedIndex = 0;
                txtCStreetNo.Text = string.Empty;
                txtCStreetName.Text = string.Empty;
                ddListCity.SelectedIndex = 0;
                ddListClientType.SelectedIndex =0;
                lblMessage.Text = string.Empty;

                populateCity();
                populateProvince();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
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
            string sqlView = $"INSERT INTO Client " +
                $"VALUES ('{Session["clientName"]}', '{Session["clientSurname"]}', '{Session["cCellNo"]}', '{Session["cStreetNo"]}', '{Session["cStreetname"]}', " +
                $"'{Session["cType"]}', {Session["cCity"]}, {Session["cProvince"]});";

            myCommand = new SqlCommand(sqlView, myConn);

            myAdapter = new SqlDataAdapter();
            myAdapter.InsertCommand = myCommand;
            myAdapter.InsertCommand.ExecuteNonQuery();

            myCommand.Dispose();
            myConn.Close();

            lblMessage.Text = "Client added!";
        }

        public void populateCity()
        {
            ddListCity.Items.Clear();

            List<City> cityList = _helperMethods.populateCity();

            if (cityList != null)
            {
                foreach (var city in cityList)
                {
                    ddListCity.Items.Insert(0, new ListItem(city.CityName, city.CityCode.ToString()));
                }
            }

            ddListCity.Items.Insert(0, new ListItem("Please Select", string.Empty));
            ddListCity.SelectedIndex = 0;

        }

        public void populateProvince()
        {
            ddListProvince.Items.Clear();
            List<Province> provinceList = _helperMethods.populateProvince();

            foreach (var province in provinceList)
            {
                ddListProvince.Items.Insert(0, new ListItem(province.ProvinceName, province.ProvinceCode.ToString()));
            }

            ddListProvince.Items.Insert(0, new ListItem("Please Select", string.Empty));
            ddListProvince.SelectedIndex = 0;
        }
    }
}
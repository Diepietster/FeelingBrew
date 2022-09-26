using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group7_FeelingBrew_Final_Project.Entities;
using Group7_FeelingBrew_Final_Project.Helper_Methods;

namespace Group7_FeelingBrew_Final_Project
{

    public partial class AddSupplier : System.Web.UI.Page
    {
        //public string connStr = @"Server=tcp:feelingbrewwebapp.database.windows.net,1433;Initial Catalog=FeelingBrewWebDb;Persist Security Info=False;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string connStr = @"Server=localhost; Database=FeelingBrewWebDb; Trusted_Connection=True;";
        public SqlConnection myConn;
        public SqlCommand myCommand;
        public DataSet myData;
        public SqlDataAdapter myAdapter;
        public SqlDataReader myReader;
        public HelperMethods _helperMethods = new HelperMethods();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                txtCompanyNameS.Focus();
                txtCompanyNameS.Text = string.Empty;
                ddListProvince.SelectedIndex = 0;
                txtSStreetName.Text = string.Empty;
                txtSStreetNo.Text = string.Empty;
                ddListCity.SelectedIndex = 0;
                lblMessage.Text = string.Empty;
                calStartDate.SelectedDate = DateTime.Today;
                lblErrorStartDate.Text = string.Empty;
                lblErrorEndDate.Text = string.Empty;
                populateCity();
                populateProvince();
            }  
        }

        protected void calStartDate_SelectionChanged(object sender, EventArgs e)
        {
            lblErrorStartDate.Text = string.Empty;

            DateTime todayDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            DateTime startDate = calStartDate.SelectedDate;

            if (DateTime.Compare(startDate, todayDate) < 0)
            {
                lblErrorStartDate.Text = "Please select an upcoming date";
            }
            else
            {
                Session["startDate"] = startDate;
            }
        }

        protected void calEndDate_SelectionChanged(object sender, EventArgs e)
        {
            lblErrorEndDate.Text = string.Empty;

            DateTime startDate = Convert.ToDateTime(Session["startDate"]);
            DateTime endDate = calEndDate.SelectedDate;
            
            if (DateTime.Compare(endDate, startDate) < 0)
            {
                lblErrorEndDate.Text = "Please select a date after start date of agreement";
                calEndDate.SelectedDate = startDate;
            }
            else
            {
                Session["endDate"] = endDate;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnAddSupplier_Click(object sender, EventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(Session["startDate"]);
            DateTime endDate = Convert.ToDateTime(Session["endDate"]);
            Session["companyName"] = txtCompanyNameS.Text;
            Session["sProvince"] = ddListProvince.SelectedValue;
            Session["sStreetNo"] = txtSStreetNo.Text;
            Session["sStreetname"] = txtSStreetName.Text;
            Session["sCity"] = ddListCity.SelectedValue;
            lblMessage.Text = "Supplier added!";

            myConn = new SqlConnection(connStr);
            myConn.Open();
            string sqlView = $"INSERT INTO Suppliers " +
                $"VALUES ('{Session["companyName"]}', '{Session["sStreetNo"]}', '{Session["sStreetname"]}', '{Session["startDate"]}', '{Session["endDate"]}', {Session["sCity"]}, {Session["sProvince"]});";

            myCommand = new SqlCommand(sqlView, myConn);

            myAdapter = new SqlDataAdapter();
            myAdapter.InsertCommand = myCommand;
            myAdapter.InsertCommand.ExecuteNonQuery();

            myCommand.Dispose();
            myConn.Close();
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
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
    public partial class UpdateSupplier : System.Web.UI.Page
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
                lblErrorStartDate.Text = string.Empty;
                lblErrorEndDate.Text = string.Empty;
                lblMessage.Text = string.Empty;

                populateCity();
                populateProvince();
                populateSplrList();
                viewData();
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

        protected void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(Session["startDate"]);
            DateTime endDate = Convert.ToDateTime(Session["endDate"]);
            Session["sCode"] = ddListSupplier.SelectedValue;
            Session["companyName"] = txtCompanyNameS.Text;
            Session["sProvince"] = ddListProvince.SelectedValue;
            Session["sStreetNo"] = txtSStreetNo.Text;
            Session["sStreetname"] = txtSStreetName.Text;
            Session["sCity"] = ddListCity.SelectedValue;

            myConn = new SqlConnection(connStr);
            myConn.Open();
            string sqlUpdate = $"UPDATE Suppliers " +
                $"SET SplrName = '{Session["companyName"]}', SplrStreetNumber = '{Session["sStreetNo"]}', SplrStreetName = '{Session["sStreetname"]}', SplrAgreementStartDate = '{Session["startDate"]}', " +
                $"SplrAgreementEndDate = '{Session["endDate"]}', CityCode = '{Session["sCity"]}', ProvinceCode = '{Session["sProvince"]}'" +
                $" WHERE SplrCode = '{Session["sCode"]}'";
            ;
            myCommand = new SqlCommand(sqlUpdate, myConn);

            myCommand.ExecuteNonQuery();

            populateCity();
            populateProvince();
            viewData();
            populateSplrList();
            myCommand.Dispose();
            myConn.Close();

            lblMessage.Text = "Supplier updated!";
        }

        protected void ddListSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Supplier> splrList = null;
            Session["sCode"] = ddListSupplier.SelectedValue;

            myConn = new SqlConnection(connStr);
            myConn.Open();

            string sqlSelectName = $"SELECT * " +
                $"FROM Suppliers " +
                $" WHERE SplrCode = '{Session["sCode"]}';";

            myCommand = new SqlCommand(sqlSelectName, myConn);
            var dataReader = myCommand.ExecuteReader();
            splrList = _helperMethods.Getlist<Supplier>(dataReader);

            if (splrList != null)
            {
                txtCompanyNameS.Text = splrList[0].SplrName;
                txtSStreetNo.Text = splrList[0].SplrStreetNumber;
                txtSStreetName.Text = splrList[0].SplrStreetName;
                var provinceToSelect = splrList[0].ProvinceCode;
                var cityToSelect = splrList[0].CityCode;

                try { 


                    ddListCity.SelectedValue = Convert.ToString(cityToSelect);
                    calStartDate.SelectedDate = Convert.ToDateTime(splrList[0].SplrAgreementStartDate);
                    calStartDate.VisibleDate = calStartDate.SelectedDate;
                    calEndDate.SelectedDate = Convert.ToDateTime(splrList[0].SplrAgreementEndDate);
                    calEndDate.VisibleDate = calEndDate.SelectedDate;
                    ddListProvince.SelectedValue = Convert.ToString(provinceToSelect);

                }
                catch (Exception)
                {

                }
            }
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
        public void viewData()
        {
            myConn = new SqlConnection(connStr);
            myConn.Open();


            string sqlView = $"SELECT Spl.SplrCode AS 'Supplier Code', Spl.SplrName, Spl.SplrStreetNumber, Spl.SplrStreetName, Spl.SplrAgreementStartDate, Spl.SplrAgreementEndDate, Ct.CityName, P.ProvinceName " +
            $"FROM Suppliers Spl, City Ct,  Province P Where Spl.CityCode = Ct.CityCode and Spl.ProvinceCode = P.ProvinceCode;";

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

            gridViewSupplier.DataSource = myData;
            gridViewSupplier.DataBind();
        }

        public void populateSplrList()
        {
            ddListSupplier.Items.Clear();
            myConn = new SqlConnection(connStr);
            myConn.Open();

            string sqlSplr = $"SELECT SplrCode " +
                $"FROM Suppliers;";

            myCommand = new SqlCommand(sqlSplr, myConn);

            myAdapter = new SqlDataAdapter();
            myData = new DataSet();
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                ddListSupplier.Items.Insert(0, new ListItem(myReader.GetValue(0).ToString(), myReader.GetValue(0).ToString()));
            }

            ddListSupplier.Items.Insert(0, new ListItem("Please Select", string.Empty));
            ddListSupplier.SelectedIndex = 0;

            myCommand.Dispose();
            myConn.Close();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Session["txtFilter"] = txtFilterSuppliers.Text;

            myConn = new SqlConnection(connStr);
            myConn.Open();


            string sql_Filter = $"SELECT Spl.SplrCode AS 'Supplier Code', Spl.SplrName, Spl.SplrStreetNumber, Spl.SplrStreetName, Spl.SplrAgreementStartDate, Spl.SplrAgreementEndDate, Ct.CityName, P.ProvinceName " +
                                $"FROM Suppliers Spl " +
                                $"LEFT JOIN City Ct " +
                                $"ON Spl.CityCode = Ct.CityCode " +
                                $"LEFT JOIN Province P " +
                                $"ON Spl.ProvinceCode = P.ProvinceCode " +
                                $"WHERE  Spl.SplrCode LIKE '%{Session["txtFilter"]}%' OR Spl.SplrName LIKE '%{Session["txtFilter"]}%' OR Spl.SplrStreetNumber LIKE '%{Session["txtFilter"]}%' " +
                                $"OR Spl.SplrStreetName LIKE '%{Session["txtFilter"]}%' OR Spl.SplrAgreementStartDate LIKE '%{Session["txtFilter"]}%' OR " +
                                $" Spl.SplrAgreementEndDate LIKE '%{Session["txtFilter"]}%' OR Ct.CityName LIKE '%{Session["txtFilter"]}%' OR P.ProvinceName LIKE '%{Session["txtFilter"]}%';";

            myCommand = new SqlCommand(sql_Filter, myConn);

            ShowData();
            myCommand.Dispose();
            myConn.Close();
        }

    }
}
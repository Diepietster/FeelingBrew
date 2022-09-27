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
    public partial class DeleteSupplier : System.Web.UI.Page
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
                populateSupplierList();
                viewData();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Session["sCode"] = ddListSupplier.SelectedValue;

            myConn = new SqlConnection(connStr);
            myConn.Open();


            string sqlDelete = $"DELETE FROM Suppliers" +
                $" WHERE SplrCode = '{Session["sCode"]}'";

            myCommand = new SqlCommand(sqlDelete, myConn);

            myAdapter = new SqlDataAdapter();
            myData = new DataSet();

            myAdapter.DeleteCommand = myCommand;
            myAdapter.DeleteCommand.ExecuteNonQuery();

            viewData();
            populateSupplierList();

            myCommand.Dispose();
            myConn.Close();
            lblMessage.Text = "Supplier deleted";
            txtFilterSupplier.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Session["txtFilter"] = txtFilterSupplier.Text;

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

        public void populateSupplierList()
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

            gridViewSuppliers.DataSource = myData;
            gridViewSuppliers.DataBind();
        }
    }
}
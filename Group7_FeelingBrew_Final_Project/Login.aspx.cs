using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Group7_FeelingBrew_Final_Project.Entities;
using Group7_FeelingBrew_Final_Project.Helper_Methods;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class Login : System.Web.UI.Page
    {
        public string connStr = @"Server=tcp:feelingbrewwebapp.database.windows.net,1433;Initial Catalog=FeelingBrewWebDb;Persist Security Info=False;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public SqlConnection myConn;
        public SqlCommand myCommand;
        public DataSet myData;
        public SqlDataAdapter myAdapter;
        public HelperMethods _helper_Methods = new HelperMethods();

        //Note: add method for admin/client login
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUsername.Focus();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginUser loginUser = null;

            Session["userName"] = txtUsername.Text;
            Session["userPassword"] = txtPassword.Text;

            try
            {
                myConn = new SqlConnection(connStr);
                myConn.Open();

                string sqlIsAdmin = $"SELECT * " +
                $"FROM UserInfo " +
                $"WHERE Username = '{Session["userName"]}' AND UserPassword = '{Session["userPassword"]}';";

                //myCommand = new SqlCommand(sqlSelectName, myConn);
                //var dataReader = myCommand.ExecuteReader();
                //clientList = _helper_Methods.Getlist<Client>(dataReader);


                myCommand = new SqlCommand(sqlIsAdmin, myConn);
                var dataReader = myCommand.ExecuteReader();
                loginUser = _helper_Methods.Getlist<LoginUser>(dataReader).FirstOrDefault();

                if(loginUser != null && loginUser.isAdmin)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Redirect("HomePageClient.aspx");
                }

                myConn.Close();
            }
            catch (SqlException)
            {
                Response.Redirect("Login.aspx");
                throw;
            }
           

            
        }
    }
}
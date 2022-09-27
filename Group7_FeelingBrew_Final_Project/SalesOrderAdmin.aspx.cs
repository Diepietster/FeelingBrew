using Group7_FeelingBrew_Final_Project.Email_Class;
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
    public partial class SalesOrder : System.Web.UI.Page
    {
        public DataSet ds;
        public string connectStr = "Server=tcp:feelingbrewwebapp.database.windows.net,1433;Initial Catalog=FeelingBrewWebDb;Persist Security Info=False;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblUnitPrice.Text = string.Empty;
                lblTotal.Text = string.Empty;
                lblTotalExclVAT.Text = string.Empty;
                lblVAT.Text = string.Empty;
                lblInclVAT.Text = string.Empty;
                populateDropBoxes();
                ddListBeer.SelectedIndex = 0;
                ddListClients.SelectedIndex = 0;
                lblMessage.Text = string.Empty;

            }
        }

        public void insertData() //Method activates when btnPlaceOrder is clicked.
        {
            if (txtQty.Text != "")
            {
                try
                {

                    //Insert data into SalesOrders
                    string insert_query = $"INSERT INTO SalesOrders (SoDate, DateReceived, ClientCode) VALUES('{Session["date"]}','{Session["next_date"]}','{Session["Client_sales_order"]}')";
                    SqlConnection sqlConn = new SqlConnection(connectStr);
                    sqlConn.Open();
                    SqlDataAdapter apdapter = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(insert_query, sqlConn);
                    apdapter.InsertCommand = cmd;
                    apdapter.InsertCommand.ExecuteNonQuery();
                    sqlConn.Close();

                    //Insert data into SalesOrdersDetails
                    string insert_query_ = $"INSERT INTO SalesOrdersDetails (BeerCode, BeerUnitPricePerBottle, QtySold) VALUES('{Session["BeerCode"]}','{Session["BeerUnitPricePerBottle"]}','{Session["UnitQty"]}')";
                    SqlConnection sqlConn_ = new SqlConnection(connectStr);
                    sqlConn_.Open();
                    SqlDataAdapter apdapter_ = new SqlDataAdapter();
                    SqlCommand cmd_ = new SqlCommand(insert_query_, sqlConn_);
                    apdapter_.InsertCommand = cmd_;
                    apdapter_.InsertCommand.ExecuteNonQuery();
                    sqlConn_.Close(); 

                     //Update Quantity of the Beers table          
                    string update_query = "UPDATE Beers SET BeerQtyOnHand = '" + Session["NewQtyOnHand"] + "' WHERE BeerName = '" + ddListBeer.Text + "' ";
                    SqlConnection sqlConn_0 = new SqlConnection(connectStr);
                    sqlConn_0.Open();
                    SqlDataAdapter apdapter_0 = new SqlDataAdapter();
                    SqlCommand cmd_0 = new SqlCommand(update_query, sqlConn_0);
                    apdapter_0.UpdateCommand = cmd_0;
                    apdapter_0.UpdateCommand.ExecuteNonQuery();
                    sqlConn_0.Close();

<<<<<<< HEAD
                    //Email
                    string message = "New Sales Order has been finalised for :/n" + "Beer: " + ddListBeer.Text + "/n" + "Quantity Ordered: " + txtQty.Text + "/n" +
                        "Unit Price: R" + (string)Session["BeerUnitPricePerBottle"] + "/n" + "Total excl VAT: R" + lblTotalExclVAT.Text + "/n" + "VAT: R" + lblVAT.Text + "/n" +
                        "Total incl VAT: R" + lblInclVAT.Text + "/n" + "SODate: " + (string)Session["date"];
                    Email email = new Email();
                    email.SendEmail(message, "Sales Order finalised!");

=======
>>>>>>> 11c7fc89c8f61208d0b12d43bb8d5756c53d74da
                    lblMessage.Text = "Order placed!";
                }
                catch (SqlException ex) //error message SQL
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblMessage.Text = "Error: Please make sure you have selected a beer and quantity"; //Error message validation
            }
        }

        public void populateDropBoxes() //This method will populate the dropdown list with the data from tblBeers
        {
            try
            {
                //Poplulate ddlistbeers with Beer
                DataTable dt = new DataTable();
                SqlConnection sqlConn = new SqlConnection(connectStr);
                sqlConn.Open();

                string SQLstringu = "Select BeerName from Beers";
                SqlCommand cmd = new SqlCommand(SQLstringu, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                ddListBeer.DataSource = dt;
                ddListBeer.DataTextField = "BeerName";
                ddListBeer.DataValueField = "BeerName";
                ddListBeer.DataBind();
                sqlConn.Close();

                //Populate ddlistClients
                DataTable dt_ = new DataTable();
                SqlConnection sqlConn_ = new SqlConnection(connectStr);
                sqlConn_.Open();

                string SQLstringu_ = "Select ClientCode from Client";
                SqlCommand cmd_ = new SqlCommand(SQLstringu_, sqlConn_);
                SqlDataAdapter da_ = new SqlDataAdapter(cmd_);
                da_.Fill(dt_);

                ddListClients.DataSource = dt_;
                ddListClients.DataTextField = "ClientCode";
                ddListClients.DataValueField = "ClientCode";
                ddListClients.DataBind();
                sqlConn_.Close();

            }
            catch (SqlException ex) //error message SQL
            {
                lblMessage.Text = "Error: " + ex.Message;
            }

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            DateTime todayDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            DateTime nextMonth = new DateTime(DateTime.Today.AddDays(30).Year, DateTime.Today.AddDays(30).Month, DateTime.Today.AddDays(30).Day);
            Session["date"] = todayDate;
            Session["next_date"] = nextMonth;
            Session["Client_sales_order"] = ddListClients.Text;
            insertData();


            lblMessage.Text = "Order placed!";
        }

        protected void btnCheckPrice_Click(object sender, EventArgs e)
        {
            double total, vat, orderTotalExclVat, orderTotalWithVat;
            lblUnitPrice.Text = string.Empty;
            lblTotal.Text = string.Empty;


            if ((txtQty.Text != "") && (ddListBeer.SelectedIndex != -1))
            {

                SqlConnection sqlConn = new SqlConnection(connectStr);
                sqlConn.Open();

                string SQLstring = "Select * from Beers Where BeerName = '" + ddListBeer.Text + "' ";
                SqlCommand cmd = new SqlCommand(SQLstring, sqlConn);
                SqlDataReader myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    Session["BeerCode"] = int.Parse(myReader["BeerCode"].ToString());
                    Session["BeerUnitPricePerBottle"] = double.Parse(myReader["BeerUnitPricePerBottle"].ToString());
                    Session["UnitQty"] = int.Parse(txtQty.Text);
                    Session["BeerQtyOnHand"] = int.Parse(myReader["BeerQtyOnHand"].ToString());
                }

                //Calculate total and display
                Session["NewQtyOnHand"] = (int)Session["BeerQtyOnHand"] - (int)Session["UnitQty"];
                lblUnitPrice.Text = "R " + Session["BeerUnitPricePerBottle"].ToString();
                total = (double)Session["BeerUnitPricePerBottle"] * (int)Session["UnitQty"];
                lblTotal.Text = "R " + total.ToString();

                //Calculate vat, orderTotal and orderTotal including VAT 15% and display
                vat = total * 0.15;
                orderTotalExclVat = total;
                orderTotalWithVat = orderTotalExclVat + vat;

                lblVAT.Text = vat.ToString();
                lblTotalExclVAT.Text = orderTotalExclVat.ToString();
                lblInclVAT.Text = orderTotalWithVat.ToString();

                sqlConn.Close();
            }
        }
    }
}
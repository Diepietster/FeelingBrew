using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Group7_FeelingBrew_Final_Project
{
    
    public partial class PurchaseOrder : System.Web.UI.Page
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
                ddListIngr.SelectedIndex = 0;
                lblMessage.Text = string.Empty;               
            }      
        }
        public void insertData() //Method activates when btnPlaceOrder is clicked.
        {
            if (txtQty.Text != "") 
            {
                try
                {
                  
                    //Insert data into PurchaseOrders
                    string insert_query = $"INSERT INTO PurchaseOrder (PODate, SplrCode, DateReceived) VALUES('{Session["date"]}','{Session["SplrCode"]}','{Session["next_date"]}')";
                    SqlConnection sqlConn = new SqlConnection(connectStr);
                    sqlConn.Open();
                    SqlDataAdapter apdapter = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(insert_query, sqlConn);
                    apdapter.InsertCommand = cmd;
                    apdapter.InsertCommand.ExecuteNonQuery();
                    sqlConn.Close(); 

                    //Insert data into PurchaseOrderDetails
                    string insert_query_ = $"INSERT INTO PurchaseOrderDetails (IngrCode, IngrUnitPrice, QtyOrdered) VALUES('{Session["IngrCode"]}','{Session["IngrLatestCost"]}','{Session["UnitQty"]}')";
                    SqlConnection sqlConn_ = new SqlConnection(connectStr);
                    sqlConn_.Open();
                    SqlDataAdapter apdapter_ = new SqlDataAdapter();
                    SqlCommand cmd_ = new SqlCommand(insert_query_, sqlConn_);
                    apdapter_.InsertCommand = cmd_;
                    apdapter_.InsertCommand.ExecuteNonQuery();
                    sqlConn_.Close();

                     //Update Quantity of the ingredients table          
                     string update_query = "UPDATE Ingredients SET QtyOnHand = '" + Session["NewQtyOnHand"] + "' WHERE IngrDescription = '" + ddListIngr.Text + "' ";
                     SqlConnection sqlConn_0 = new SqlConnection(connectStr);
                     sqlConn_0.Open();
                     SqlDataAdapter apdapter_0 = new SqlDataAdapter();
                     SqlCommand cmd_0 = new SqlCommand(update_query, sqlConn_0);
                     apdapter_0.UpdateCommand = cmd_0;
                     apdapter_0.UpdateCommand.ExecuteNonQuery();
                     sqlConn_0.Close();



                    lblMessage.Text = "Order placed!";
                }
                 catch (SqlException ex) //error message SQL
                {
                    lblMessage.Text = "Error: " + ex.Message;
                } 
            }
             else
            {
                lblMessage.Text = "Error: Please make sure you have selected an ingredient and quantity"; //Error message validation
            } 
        }

        public void populateDropBoxes() //This method will populate the dropdown list with the data from tblIngredients
        {
            try
            {
              DataTable dt = new DataTable();
              SqlConnection sqlConn = new SqlConnection(connectStr);
              sqlConn.Open();

              string SQLstringu = "Select IngrDescription from Ingredients ";
              SqlCommand cmd = new SqlCommand(SQLstringu, sqlConn);
              SqlDataAdapter da = new SqlDataAdapter(cmd);
              da.Fill(dt);

              ddListIngr.DataSource = dt;
              ddListIngr.DataTextField = "IngrDescription";
              ddListIngr.DataValueField = "IngrDescription";
              ddListIngr.DataBind();

             
              sqlConn.Close();
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
            insertData();
        }

       

        protected void btnCheckPrice_Click(object sender, EventArgs e) //Get ingredient latest cost from database
        {
            double total, vat, orderTotalExclVat, orderTotalWithVat;
            lblUnitPrice.Text = string.Empty;      
            lblTotal.Text = string.Empty;


            if ((txtQty.Text != "") && (ddListIngr.SelectedIndex != -1))
            {

                SqlConnection sqlConn = new SqlConnection(connectStr);
                sqlConn.Open();

                string SQLstring = "Select * from Ingredients Where IngrDescription = '" + ddListIngr.Text + "' ";
                SqlCommand cmd = new SqlCommand(SQLstring, sqlConn);
                SqlDataReader myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {                                                   
                    Session["IngrCode"] = int.Parse(myReader["IngredientCode"].ToString());
                    Session["IngrLatestCost"] = double.Parse(myReader["IngrLatestCost"].ToString());
                    Session["UnitQty"] = int.Parse(txtQty.Text);
                    Session["QtyOnHand"] = int.Parse(myReader["QtyOnHand"].ToString());
                    Session["SplrCode"] = int.Parse(myReader["SplrCode"].ToString());   
                    
                }

                //Calculate new Qty
                Session["NewQtyOnHand"] = (int)Session["QtyOnHand"] + (int)Session["UnitQty"];

                //Calculate total and display
                lblUnitPrice.Text = "R " + Session["IngrLatestCost"].ToString(); 
                total = (double)Session["IngrLatestCost"] * (int)Session["UnitQty"];
                lblTotal.Text = "R "+total.ToString();

                //Calculate vat, orderTotal and orderTotal including VAT 15% and display
                vat = total * 0.15;               
                orderTotalExclVat =  total;
                orderTotalWithVat = orderTotalExclVat + vat;
                
                lblVAT.Text = vat.ToString();
                lblTotalExclVAT.Text = orderTotalExclVat.ToString();
                lblInclVAT.Text = orderTotalWithVat.ToString();

                sqlConn.Close();
            }

           

        }
            protected void txtQty_TextChanged(object sender, EventArgs e)
            { 
            
            }

            protected void txtQty0_TextChanged(object sender, EventArgs e)
            {   
            
            }
    }
}
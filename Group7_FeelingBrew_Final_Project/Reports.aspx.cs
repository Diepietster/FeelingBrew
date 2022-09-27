using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private SqlConnection conn = new SqlConnection(@"Data Source=feelingbrewwebapp.database.windows.net;Database=FeelingBrewWebDb;User ID=admin-sql;Password=5+&8ePF43M5%J$1,YWT&KetA=-a_O6y5");
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;

        private void updateGridView()
        {
            updateGridView("");
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "DESC"; // Default direction
            string sortExpression = (string)ViewState["SortExpression"];

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = (string)ViewState["SortDirection"];
                    if ((lastDirection != null) && (lastDirection == "DESC"))
                    {
                        sortDirection = "ASC";
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void gridViewData_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = ((DataSet)Session["myDataSet"]).Tables[0];
            dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            gridViewData.DataSource = dt;
            gridViewData.DataBind();
        }

        private void updateGridView(string str) // str will be used to see if user typed in the filter box or not
        {
            int select = int.Parse(Session["select"].ToString()); // Assign saved session value to an Integer to See if "Top Beers" or "Purchase Orders" or "Sales Orders" has been selected
            if(select == 0) // When the user selected "Top Beers"
            {
                conn.Open();
                if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                {
                    DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                    DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                    cmd = new SqlCommand($"SELECT b.beerName AS [Beer Name], SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId AND sod.BeerCode = b.BeerCode AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY b.beerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
                    if(str != "") // Search has been specified
                    {
                        cmd = new SqlCommand($"SELECT b.beerName AS [Beer Name], SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId AND sod.BeerCode = b.BeerCode AND (b.beerName LIKE '%{str}%' OR ((sod.QtySold * sod.BeerUnitPricePerBottle) LIKE '%{str}%')) AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY b.beerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
                    }
                }
                else
                {
                    cmd = new SqlCommand($"SELECT b.beerName AS [Beer Name], SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId AND sod.BeerCode = b.BeerCode GROUP BY b.beerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
                    if(str != "") // Search has been specified
                    {
                        cmd = new SqlCommand($"SELECT b.beerName AS [Beer Name], SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId AND sod.BeerCode = b.BeerCode AND (b.beerName LIKE '%{str}%' OR ((sod.QtySold * sod.BeerUnitPricePerBottle) LIKE '%{str}%')) GROUP BY b.beerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
                    }
                }
                DataSet ds = new DataSet();
                Session["myDataSet"] = ds; // Store DataSet for sorting columns
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                gridViewData.DataSource = ds;
                gridViewData.DataBind();

                conn.Close();
            }
            if(select == 1) // When the user selected "Purchase Orders"
            {
                conn.Open();
                if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                {
                    DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                    DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                    cmd = new SqlCommand($"SELECT po.PurchaseOrderId AS [Purchase Order ID], po.PODate AS [Purchase Order - Date], po.SplrCode AS [Supplier Code], po.DateReceived AS [Date Received], SUM(pod.IngrUnitPrice * pod.QtyOrdered) AS [Total Amount] FROM PurchaseOrder po, PurchaseOrderDetails pod WHERE po.PurchaseOrderID = pod.PurchaseOrderId AND po.PoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY po.PurchaseOrderId, po.PoDate, po.SplrCode, po.DateReceived", conn);
                    if(str != "")
                    {
                        cmd = new SqlCommand($"SELECT po.PurchaseOrderId AS [Purchase Order ID], po.PODate AS [Purchase Order - Date], po.SplrCode AS [Supplier Code], po.DateReceived AS [Date Received], SUM(pod.IngrUnitPrice * pod.QtyOrdered) AS [Total Amount] FROM PurchaseOrder po, PurchaseOrderDetails pod WHERE po.PurchaseOrderID = pod.PurchaseOrderId AND (po.PurchaseOrderId LIKE '%{str}%' OR po.PODate LIKE '%{str}%' OR po.SplrCode LIKE '%{str}%' OR po.DateReceived LIKE '%{str}%' OR ((pod.IngrUnitPrice * pod.QtyOrdered) LIKE '%{str}%')) AND po.PoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY po.PurchaseOrderId, po.PoDate, po.SplrCode, po.DateReceived", conn);
                    }
                }
                else
                {
                    cmd = new SqlCommand($"SELECT po.PurchaseOrderId AS [Purchase Order ID], po.PODate AS [Purchase Order - Date], po.SplrCode AS [Supplier Code], po.DateReceived AS [Date Received], SUM(pod.IngrUnitPrice * pod.QtyOrdered) AS [Total Amount] FROM PurchaseOrder po, PurchaseOrderDetails pod WHERE po.PurchaseOrderID = pod.PurchaseOrderId GROUP BY po.PurchaseOrderId, po.PoDate, po.SplrCode, po.DateReceived", conn);
                    if(str != "")
                    {
                        cmd = new SqlCommand($"SELECT po.PurchaseOrderId AS [Purchase Order ID], po.PODate AS [Purchase Order - Date], po.SplrCode AS [Supplier Code], po.DateReceived AS [Date Received], SUM(pod.IngrUnitPrice * pod.QtyOrdered) AS [Total Amount] FROM PurchaseOrder po, PurchaseOrderDetails pod WHERE po.PurchaseOrderID = pod.PurchaseOrderId AND (po.PurchaseOrderId LIKE '%{str}%' OR po.PODate LIKE '%{str}%' OR po.SplrCode LIKE '%{str}%' OR po.DateReceived LIKE '%{str}%' OR ((pod.IngrUnitPrice * pod.QtyOrdered) LIKE '%{str}%')) GROUP BY po.PurchaseOrderId, po.PoDate, po.SplrCode, po.DateReceived", conn);
                    }
                }
                DataSet ds = new DataSet();
                Session["myDataSet"] = ds; // Store DataSet for sorting columns
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                gridViewData.DataSource = ds;
                gridViewData.DataBind();
                conn.Close();
            }
            if(select == 2) // When the user selected "Sales Orders"
            {
                conn.Open();
                if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                {
                    DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                    DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                    cmd = new SqlCommand($"SELECT so.SoNumber AS [Sales Order - Number], so.SoDate AS [Sales Order - Date], so.DateReceived AS [Date Received], so.ClientCode AS [Client Code], SUM(sod.BeerUnitPricePerBottle * sod.QtySold) AS [Total Amount] FROM SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY so.SoNumber, so.SoDate, so.DateReceived, so.ClientCode", conn);
                    if(str != "")
                    {
                        cmd = new SqlCommand($"SELECT so.SoNumber AS [Sales Order - Number], so.SoDate AS [Sales Order - Date], so.DateReceived AS [Date Received], so.ClientCode AS [Client Code], SUM(sod.BeerUnitPricePerBottle * sod.QtySold) AS [Total Amount] FROM SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId AND (so.SoNumber LIKE '%{str}%' OR so.SoDate LIKE '%{str}%' OR so.DateReceived LIKE '%{str}%' OR so.ClientCode LIKE '%{str}%' OR ((sod.BeerUnitPricePerBottle * sod.QtySold) LIKE '%{str}%')) AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY so.SoNumber, so.SoDate, so.DateReceived, so.ClientCode", conn);
                    }
                }
                else
                {
                    cmd = new SqlCommand($"SELECT so.SoNumber AS [Sales Order - Number], so.SoDate AS [Sales Order - Date], so.DateReceived AS [Date Received], so.ClientCode AS [Client Code], SUM(sod.BeerUnitPricePerBottle * sod.QtySold) AS [Total Amount] FROM SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId GROUP BY so.SoNumber, so.SoDate, so.DateReceived, so.ClientCode", conn);
                    if(str != "")
                    {
                        cmd = new SqlCommand($"SELECT so.SoNumber AS [Sales Order - Number], so.SoDate AS [Sales Order - Date], so.DateReceived AS [Date Received], so.ClientCode AS [Client Code], SUM(sod.BeerUnitPricePerBottle * sod.QtySold) AS [Total Amount] FROM SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId AND (so.SoNumber LIKE '%{str}%' OR ((sod.BeerUnitPricePerBottle * sod.QtySold) LIKE '%{str}%') OR so.SoDate LIKE '%{str}%' OR so.DateReceived LIKE '%{str}%' OR so.ClientCode LIKE '%{str}%') GROUP BY so.SoNumber, so.SoDate, so.DateReceived, so.ClientCode", conn);
                    }
                }
                DataSet ds = new DataSet();
                Session["myDataSet"] = ds; // Store DataSet for sorting columns
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                gridViewData.DataSource = ds;
                gridViewData.DataBind();
                conn.Close();
            }
        }

        protected void gridViewData_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gridViewData.PageIndex = e.NewPageIndex;
            updateGridView(Session["search"].ToString());
        }

        protected void btnTopBeers_Click(object sender, EventArgs e)
        {
            Session["select"] = 0;
            updateGridView();

            conn.Open();
            if (txtDateFrom.Text != "" && txtDateTo.Text != "")
            {
                DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                cmd = new SqlCommand($"SELECT b.BeerName, SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE sod.BeerCode = b.BeerCode AND so.SoNumber = sod.SalesOrderId AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY b.BeerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
                dataChart.Titles[0].Text = "Top Beers - By Amount Sold from " + dateFrom + " to " + dateTo;
            }
            else
            {
                cmd = new SqlCommand($"SELECT b.BeerName, SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE sod.BeerCode = b.BeerCode AND so.SoNumber = sod.SalesOrderId GROUP BY b.BeerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
                dataChart.Titles[0].Text = "Top Beers - By Amount Sold";
            }
            reader = cmd.ExecuteReader();
            dataChart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            dataChart.Series["Series1"].Points.Clear(); // Prevents graph from adding new points on PostBack
            dataChart.Series["Series1"].IsValueShownAsLabel = false;
            dataChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            dataChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            int counter = 0;
            while (reader.Read() && counter < 10)
            {
                dataChart.Series["Series1"].Points.AddXY(reader.GetValue(0), reader.GetValue(1));
                counter++;
            }
            conn.Close();
        }

        protected void btnPO_Click(object sender, EventArgs e)
        {
            Session["select"] = 1;
            updateGridView();

            conn.Open();
            if (txtDateFrom.Text != "" && txtDateTo.Text != "")
            {
                DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                cmd = new SqlCommand($"SELECT po.PODate, SUM(pod.IngrUnitPrice * pod.QtyOrdered) FROM PurchaseOrder po, PurchaseOrderDetails pod WHERE po.PurchaseOrderID = pod.PurchaseOrderId AND po.PODate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY po.PODate", conn);
                dataChart.Titles[0].Text = "Purchase Orders - By Date from " + dateFrom + " to " + dateTo;
            }
            else
            {
                cmd = new SqlCommand($"SELECT po.PODate, SUM(pod.IngrUnitPrice * pod.QtyOrdered) FROM PurchaseOrder po, PurchaseOrderDetails pod WHERE po.PurchaseOrderID = pod.PurchaseOrderId GROUP BY po.PODate", conn);
                dataChart.Titles[0].Text = "Purchase Orders - By Date";
            }

            reader = cmd.ExecuteReader();
            dataChart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            dataChart.Series["Series1"].Points.Clear(); // Prevents graph from adding new points on PostBack
            dataChart.Series["Series1"].IsValueShownAsLabel = false;
            dataChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            dataChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            while (reader.Read())
            {
                dataChart.Series["Series1"].Points.AddXY(reader.GetValue(0), reader.GetValue(1));
            }
            conn.Close();
        }

        protected void btnSO_Click(object sender, EventArgs e)
        {
            Session["select"] = 2;
            updateGridView();
            conn.Open();
            if (txtDateFrom.Text != "" && txtDateTo.Text != "")
            {
                DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                cmd = new SqlCommand($"SELECT so.SoDate, SUM(sod.BeerUnitPricePerBottle * sod.QtySold) FROM SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY so.SoDate", conn);
                dataChart.Titles[0].Text = "Sale Orders - By Date from " + dateFrom + " to " + dateTo;
            }
            else
            {
                cmd = new SqlCommand($"SELECT so.SoDate, SUM(sod.BeerUnitPricePerBottle * sod.QtySold) FROM SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = sod.SalesOrderId GROUP BY so.SoDate", conn);
                dataChart.Titles[0].Text = "Sale Orders - By Date";
            }

            reader = cmd.ExecuteReader();
            dataChart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            dataChart.Series["Series1"].Points.Clear(); // Prevents graph from adding new points on PostBack
            dataChart.Series["Series1"].IsValueShownAsLabel = false;
            dataChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            dataChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            while (reader.Read())
            {
                dataChart.Series["Series1"].Points.AddXY(reader.GetValue(0), reader.GetValue(1));
            }
            conn.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string str = txtFilterPO.Text;
            Session["search"] = str;
            updateGridView(Session["search"].ToString());
        }
    }
}
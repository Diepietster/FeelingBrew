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

        protected void gridViewData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewData.PageIndex = e.NewPageIndex;
        }

        protected void btnTopBeers_Click(object sender, EventArgs e)
        {
            conn.Open();
            if(txtDateFrom.Text != "" && txtDateTo.Text != "")
            {
                DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                cmd = new SqlCommand($"SELECT sod.BeerCode AS [Beer Code], SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE sod.BeerCode = b.BeerCode AND so.SoNumber = sod.SalesOrderId AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY sod.BeerCode ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
            } else
            {
                cmd = new SqlCommand($"SELECT sod.BeerCode AS [Beer Code], SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE sod.BeerCode = b.BeerCode AND so.SoNumber = sod.SalesOrderId GROUP BY sod.BeerCode ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
            }
            DataSet ds = new DataSet();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            gridViewData.DataSource = ds;
            gridViewData.DataBind();
            conn.Close();

            conn.Open();
            if (txtDateFrom.Text != "" && txtDateTo.Text != "")
            {
                DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                cmd = new SqlCommand($"SELECT b.BeerName, SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE sod.BeerCode = b.BeerCode AND so.SoNumber = sod.SalesOrderId AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY b.BeerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
            }
            else
            {
                cmd = new SqlCommand($"SELECT b.BeerName, SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE sod.BeerCode = b.BeerCode AND so.SoNumber = sod.SalesOrderId GROUP BY b.BeerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
            }
            reader = cmd.ExecuteReader();
            dataChart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            dataChart.Series["Series1"].Points.Clear(); // Prevents graph from adding new points on PostBack
            dataChart.Titles[0].Text = "Top Beers - By Amount Sold";
            dataChart.Series["Series1"].IsValueShownAsLabel = false;
            dataChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            dataChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            while (reader.Read())
            {
                dataChart.Series["Series1"].Points.AddXY(reader.GetValue(0), reader.GetValue(1));
            }
            conn.Close();
        }

        protected void btnPO_Click(object sender, EventArgs e)
        {
            conn.Open();
            if(txtDateFrom.Text != "" && txtDateTo.Text != "")
            {
                DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                cmd = new SqlCommand($"SELECT PurchaseOrderId AS [Purchase Order ID], PODate AS [Purchase Order - Date], SplrCode AS [Supplier Code], DateReceived AS [Date Received] FROM PurchaseOrder WHERE PoDate BETWEEN '{dateFrom}' AND '{dateTo}'", conn);
            }
            else
            {
                cmd = new SqlCommand($"SELECT PurchaseOrderId AS [Purchase Order ID], PODate AS [Purchase Order - Date], SplrCode AS [Supplier Code], DateReceived AS [Date Received] FROM PurchaseOrder", conn);
            }
            DataSet ds = new DataSet();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            gridViewData.DataSource = ds;
            gridViewData.DataBind();
            conn.Close();

            conn.Open();
            if (txtDateFrom.Text != "" && txtDateTo.Text != "")
            {
                DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                cmd = new SqlCommand($"SELECT po.PODate, SUM(pod.IngrUnitPrice * pod.QtyOrdered) FROM PurchaseOrder po, PurchaseOrderDetails pod GROUP BY po.PODate", conn);
            }
            else
            {
                cmd = new SqlCommand($"SELECT po.PODate, SUM(pod.IngrUnitPrice * pod.QtyOrdered) FROM PurchaseOrder po, PurchaseOrderDetails pod GROUP BY po.PODate", conn);
            }
            reader = cmd.ExecuteReader();
            dataChart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            dataChart.Series["Series1"].Points.Clear(); // Prevents graph from adding new points on PostBack
            dataChart.Titles[0].Text = "All Clients Price Paid ($) - By Date";
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
            conn.Open();
            if (txtDateFrom.Text != "" && txtDateTo.Text != "")
            {
                DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                cmd = new SqlCommand($"SELECT SoNumber AS [Sales Order - Number], SoDate AS [Sales Order - Date], DateReceived AS [Date Received], ClientCode AS [Client Code] FROM SalesOrders WHERE SoDate BETWEEN '{dateFrom}' AND '{dateTo}'", conn);
            }
            else
            {
                cmd = new SqlCommand($"SELECT SoNumber AS [Sales Order - Number], SoDate AS [Sales Order - Date], DateReceived AS [Date Received], ClientCode AS [Client Code] FROM SalesOrders", conn);
            }
            DataSet ds = new DataSet();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            gridViewData.DataSource = ds;
            gridViewData.DataBind();
            conn.Close();
        }
    }
}
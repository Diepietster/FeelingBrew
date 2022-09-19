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
            int select = int.Parse(Session["select"].ToString());
            if(select == 0)
            {
                conn.Open();
                if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                {
                    DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                    DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                    cmd = new SqlCommand($"SELECT b.beerName AS [Beer Name], SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE sod.BeerCode = b.BeerCode AND so.SoNumber = sod.SalesOrderId AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY b.beerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
                }
                else
                {
                    cmd = new SqlCommand($"SELECT b.beerName AS [Beer Name], SUM(sod.QtySold * sod.BeerUnitPricePerBottle) AS [Amount Of Sales] FROM Beers b, SalesOrders so, SalesOrdersDetails sod WHERE sod.BeerCode = b.BeerCode AND so.SoNumber = sod.SalesOrderId GROUP BY b.beerName ORDER BY SUM(sod.QtySold * sod.BeerUnitPricePerBottle) DESC", conn);
                }
                DataSet ds = new DataSet();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                gridViewData.DataSource = ds;
                gridViewData.DataBind();
                conn.Close();
            }
            if(select == 1)
            {
                conn.Open();
                if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                {
                    DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                    DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                    cmd = new SqlCommand($"SELECT po.PurchaseOrderId AS [Purchase Order ID], po.PODate AS [Purchase Order - Date], po.SplrCode AS [Supplier Code], po.DateReceived AS [Date Received], SUM(pod.IngrUnitPrice * pod.QtyOrdered) AS [Total Amount] FROM PurchaseOrder po, PurchaseOrderDetails pod WHERE po.PurchaseOrderID = pod.PurchaseOrderId AND po.PoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY po.PurchaseOrderId, po.PoDate, po.SplrCode, po.DateReceived", conn);
                }
                else
                {
                    cmd = new SqlCommand($"SELECT po.PurchaseOrderId AS [Purchase Order ID], po.PODate AS [Purchase Order - Date], po.SplrCode AS [Supplier Code], po.DateReceived AS [Date Received], SUM(pod.IngrUnitPrice * pod.QtyOrdered) AS [Total Amount] FROM PurchaseOrder po, PurchaseOrderDetails pod WHERE po.PurchaseOrderID = pod.PurchaseOrderId GROUP BY po.PurchaseOrderId, po.PoDate, po.SplrCode, po.DateReceived", conn);
                }
                DataSet ds = new DataSet();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                gridViewData.DataSource = ds;
                gridViewData.DataBind();
                conn.Close();
            }
            if(select == 2)
            {
                conn.Open();
                if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                {
                    DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
                    DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
                    cmd = new SqlCommand($"SELECT so.SoNumber AS [Sales Order - Number], so.SoDate AS [Sales Order - Date], so.DateReceived AS [Date Received], so.ClientCode AS [Client Code], SUM(sod.BeerUnitPricePerBottle * sod.QtySold) AS [Total Amount] FROM SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = SalesOrderId AND so.SoDate BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY so.SoNumber, so.SoDate, so.DateReceived, so.ClientCode", conn);
                }
                else
                {
                    cmd = new SqlCommand($"SELECT so.SoNumber AS [Sales Order - Number], so.SoDate AS [Sales Order - Date], so.DateReceived AS [Date Received], so.ClientCode AS [Client Code], SUM(sod.BeerUnitPricePerBottle * sod.QtySold) AS [Total Amount] FROM SalesOrders so, SalesOrdersDetails sod WHERE so.SoNumber = SalesOrderId GROUP BY so.SoNumber, so.SoDate, so.DateReceived, so.ClientCode", conn);
                }
                DataSet ds = new DataSet();
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
            updateGridView();
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
           
        }
    }
}
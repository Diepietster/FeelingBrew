﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        //Method to populate dropdown list
        //Method to add data to tables
        //Method to get price for ingredient selected to display unit price
        //Calculate unitPrice * qty = total
        //Calculate total excl vat, vat and total incl vat
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblUnitPrice.Text = string.Empty;
                lblUnitPrice0.Text = string.Empty;
                lblUnitPrice1.Text = string.Empty;
                lblUnitPrice2.Text = string.Empty;
                lblTotal.Text = string.Empty;
                lblTotal0.Text = string.Empty;
                lblTotal1.Text = string.Empty;
                lblTotal2.Text = string.Empty;
                lblTotalExclVAT.Text = string.Empty;
                lblVAT.Text = string.Empty;
                lblInclVAT.Text = string.Empty;
                ddListIngr.SelectedIndex = 0;
                ddListIngr0.SelectedIndex = 0;
                ddListIngr1.SelectedIndex = 0;
                ddListIngr2.SelectedIndex = 0;
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            DateTime todayDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            Session["date"] = todayDate;
            Session["beer"] = ddListIngr.SelectedIndex;
            Session["beer0"] = ddListIngr0.SelectedIndex;
            Session["beer1"] = ddListIngr1.SelectedIndex;
            Session["beer2"] = ddListIngr2.SelectedIndex;

            Session["beerQty"] = txtQty.Text;
            Session["beerQty0"] = txtQty0.Text;
            Session["beerQty1"] = txtQty1.Text;
            Session["beerQty2"] = txtQty2.Text;

            lblMessage.Text = "Order placed!";
        }
    }
}
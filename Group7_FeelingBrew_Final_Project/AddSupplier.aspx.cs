using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class AddSupplier : System.Web.UI.Page
    {
        //Note: method to add supplier
        //Note: method to populate city/province
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
                //Display current date when page loads
                calStartDate.SelectedDate = DateTime.Today;
                //Clear text of error lables
                lblErrorStartDate.Text = string.Empty;
                lblErrorEndDate.Text = string.Empty;
            }
        }

        protected void calStartDate_SelectionChanged(object sender, EventArgs e)
        {
            //Clear label error message
            lblErrorStartDate.Text = string.Empty;

            //Get current date
            DateTime todayDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            //Get selected date
            DateTime startDate = calStartDate.SelectedDate;

            //Error message if date selected is before current date
            if (DateTime.Compare(startDate, todayDate) < 0)
            {
                lblErrorStartDate.Text = "Please select an upcoming date";
            }
            else
            {
                //Store start date in session
                Session["startDate"] = startDate;
            }
        }

        protected void calEndDate_SelectionChanged(object sender, EventArgs e)
        {
            //Clear label error message
            lblErrorEndDate.Text = string.Empty;

            //Ensure date selected is after check in date selected
            DateTime startDate = Convert.ToDateTime(Session["startDate"]);
            DateTime endDate = calEndDate.SelectedDate;
            
            if (DateTime.Compare(endDate, startDate) < 0)
            {
                //Error message if date is incorrect
                lblErrorEndDate.Text = "Please select a date after start date of agreement";
                calEndDate.SelectedDate = startDate;
            }
            else
            {
                //Store end date in session
                Session["endDate"] = endDate;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Session["companyName"] = txtCompanyNameS.Text;
            Session["sProvince"] = ddListProvince.SelectedValue;
            Session["sStreetNo"] = txtSStreetNo.Text;
            Session["sStreetname"] = txtSStreetName.Text;
            Session["sCity"] = ddListCity.SelectedValue;
            lblMessage.Text = "Supplier added!";
        }
    }
}
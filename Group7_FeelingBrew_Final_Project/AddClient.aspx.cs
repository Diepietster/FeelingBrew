using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class AddClient : System.Web.UI.Page
    {
        //Note: method to add client
        //Note: method to populate city/province
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                txtCName.Focus();
                txtCName.Text = string.Empty;
                txtCSurname.Text = string.Empty;
                txtCompanyName.Text = string.Empty;
                txtCCellphone.Text = string.Empty;
                ddListProvince.SelectedIndex = 0;
                txtCStreetNo.Text = string.Empty;
                txtCStreetName.Text = string.Empty;
                ddListCity.SelectedIndex = 0;
                ddListClientType.SelectedIndex =0;
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            Session["clientName"] = txtCName.Text;
            Session["clientSurname"] = txtCSurname.Text;
            Session["cCompanyName"] = txtCompanyName.Text;
            Session["cCellNo"] = txtCCellphone.Text;
            Session["cProvince"] = ddListProvince.SelectedValue;
            Session["cStreetNo"] = txtCStreetNo.Text;
            Session["cStreetname"] = txtCStreetName.Text;
            Session["cCity"] = ddListCity.SelectedValue;
            Session["cType"] = ddListClientType.SelectedValue;
            lblMessage.Text = "Client added!";
        }
    }
}
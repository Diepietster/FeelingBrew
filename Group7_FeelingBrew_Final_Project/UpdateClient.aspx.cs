using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group7_FeelingBrew_Final_Project
{
    public partial class UpdateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Session["cCode"] = ddListClients.SelectedIndex; 
            Session["clientName"] = txtCName.Text;
            Session["clientSurname"] = txtCSurname.Text;
            Session["cCompanyName"] = txtCompanyName.Text;
            Session["cCellNo"] = txtCCellphone.Text;
            Session["cProvince"] = ddListProvince.SelectedValue;
            Session["cStreetNo"] = txtCStreetNo.Text;
            Session["cStreetname"] = txtCStreetName.Text;
            Session["cCity"] = ddListCity.SelectedValue;
            Session["cType"] = ddListClientType.SelectedValue;

            lblMessage.Text = "Client updated!";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
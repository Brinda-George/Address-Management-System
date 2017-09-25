using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressManagementSystem
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Convert.ToString(Session["Name"])))
            {
                ((Site)this.Master).LblUserName = "Welcome, " + Convert.ToString(Session["Name"]);
            }
        }
    }
}
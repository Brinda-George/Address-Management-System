using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressManagementSystem
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string LblUserName
        {

            // Find label in master page and Return its text
            get
            {
                var lblMyLabel = (Label)lvUserInfo.FindControl("lblUserName");
                return lblMyLabel.Text;
            }

            // Find label in master page and set its text
            set
            {
                var lblMyLabel = (Label)lvUserInfo.FindControl("lblUserName");
                lblMyLabel.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Logout_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            // Clear session
            Session.Clear();

            // Destroys all objects stored in a Session object and releases their resources
            Session.Abandon();

            // Removes the forms-authentication ticket from the browser.
            FormsAuthentication.SignOut();

            // Redirects the browser to the login URL.
            FormsAuthentication.RedirectToLoginPage();
        }
        
    }
}
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
        //public Label LblUserName
        //{
        //    get
        //    {
        //        return this.lvUserInfo.FindControl("lblUserName") != null ? (Label)lvUserInfo.FindControl("lblUserName") : null;
        //    }
        //}
        public string LblUserName
        {
            get
            {
                var lblMyLabel = (Label)lvUserInfo.FindControl("lblUserName");
                return lblMyLabel.Text;
            }
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
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}
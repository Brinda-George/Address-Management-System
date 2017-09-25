using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AddressManagementSystem
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }
        //public void Session_End(object s, EventArgs e)
        //{
        //    Session.Clear();
        //    Session.Abandon();
        //    Session.RemoveAll();
        //    FormsAuthentication.SignOut();
        //    FormsAuthentication.RedirectToLoginPage();
        //    Roles.DeleteCookie();
        //}
    }
}
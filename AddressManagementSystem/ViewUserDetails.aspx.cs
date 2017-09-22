using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressManagementSystem
{
    public partial class ViewUserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindData();
            //}
        }
        //private void BindData()
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    SqlConnection con = new SqlConnection(CS);
        //    SqlDataAdapter da = new SqlDataAdapter("spGetUserDetailsbyUserId", con);
        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter userId = new SqlParameter();
        //    userId.ParameterName = "@UserId";
        //    userId.Value = GetUserId();
        //    da.SelectCommand.Parameters.Add(userId);

        //    DataSet DS = new DataSet();
        //    da.Fill(DS);
        //    GridViewUser.DataSource = DS;
        //    GridViewUser.DataBind();
        //}
    }
}
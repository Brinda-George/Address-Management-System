using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressManagementSystem
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtEmail")).ToList();
            int i = 1;
            foreach (string key in keys)
            {
                this.CreateTextBox("txtEmail" + i);
                i++;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddTextBox(object sender, EventArgs e)
        {
            int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBox("txtEmail" + index);
        }

        private void CreateTextBox(string id)
        {
            TextBox txt = new TextBox();
            txt.ID = id;
            pnlTextBoxes.Controls.Add(txt);

            Literal lt = new Literal();
            lt.Text = "<br />";
            pnlTextBoxes.Controls.Add(lt);
        }
        //protected void Save(object sender, EventArgs e)
        //{
        //    foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
        //    {
        //        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //        using (SqlConnection con = new SqlConnection(constr))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("INSERT INTO Names(Name) VALUES(@Name)"))
        //            {
        //                cmd.Connection = con;
        //                cmd.Parameters.AddWithValue("@Name", textBox.Text);
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //        }
        //    }
        //}
        //foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
        //    {
        //        message += textBox.ID + ": " + textBox.Text + "\\n";
        //    }
}
}
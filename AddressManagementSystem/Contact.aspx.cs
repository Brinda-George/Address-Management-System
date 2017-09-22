using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressManagementSystem
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("YourGmailID@gmail.com");
                    mailMessage.To.Add("AdministratorID@YourCompany.com");
                    mailMessage.Subject = txtSubject.Text;

                    mailMessage.Body = "<b>Sender Name : </b>" + txtName.Text + "<br/>"
                      + "<b>Sender Email : </b>" + txtEmail.Text + "<br/>"
                      + "<b>Comments : </b>" + txtComments.Text;
                    mailMessage.IsBodyHtml = true;


                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new
                      System.Net.NetworkCredential("YourGmailID@gmail.com", "YourGmailPassowrd");
                    smtpClient.Send(mailMessage);

                    Label1.ForeColor = System.Drawing.Color.Blue;
                    Label1.Text = "Thank you for contacting us";

                    txtName.Enabled = false;
                    txtEmail.Enabled = false;
                    txtComments.Enabled = false;
                    txtSubject.Enabled = false;
                    Button1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception information to 
                // database table or event viewer
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "There is an unkwon problem. Please try later";
            }
        }
    }
}
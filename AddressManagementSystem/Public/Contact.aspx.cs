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
                    // Create the message object to be sent
                    MailMessage mailMessage = new MailMessage();

                    // Add your email address to the recipients
                    mailMessage.From = new MailAddress("YourGmailID@gmail.com");

                    // Configure the address we are sending the mail from
                    mailMessage.To.Add("AdministratorID@YourCompany.com");

                    mailMessage.Subject = txtSubject.Text;
                    mailMessage.Body = "<b>Sender Name : </b>" + txtName.Text + "<br/>"
                      + "<b>Sender Email : </b>" + txtEmail.Text + "<br/>"
                      + "<b>Comments : </b>" + txtComments.Text;
                    mailMessage.IsBodyHtml = true;

                    // Configure an SmtpClient to send the mail.
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;

                    // Setup credentials to login to our sender email address ("UserName", "Password")
                    smtpClient.Credentials = new System.Net.NetworkCredential("YourGmailID@gmail.com", "YourGmailPassowrd");

                    // Send the message
                    smtpClient.Send(mailMessage);

                    // Display some feedback to the user to let them know it was sent
                    lblMessage.ForeColor = System.Drawing.Color.Blue;
                    lblMessage.Text = "Thank you for contacting us";

                    // Clear the form and disable submit button
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtComments.Text = "";
                    txtSubject.Text = "";
                    btnSubmit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception information to event viewer
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Your message failed to send, please try later.";
            }
        }
    }
}
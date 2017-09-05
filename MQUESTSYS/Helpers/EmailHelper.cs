using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using MQUESTSYS.BF;

namespace MQUESTSYS.Helpers
{
    public class EmailHelper
    {

        public void SendEmail(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage("noreply@psinformatika.com", email);
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = Convert.ToString(message);
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("tiar.agisti@gmail.com", "bismillah31081990");
            client.Send(mail);
        }
    }
}
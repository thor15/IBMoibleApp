using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace IBCompSciApp.Models
{
    public class SendEmail
    {
        public static void EmailUser(string email, int code)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("aiden.p.carr@gmail.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Password Reset Code";
                message.Body = "Here is your code: " + code;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                //smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}

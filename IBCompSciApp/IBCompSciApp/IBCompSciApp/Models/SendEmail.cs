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
                object boo = null;
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("ibbookapp@gmail.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Password Reset Code";
                message.Body = "Here is your code: " + code;
                smtp.Port = 465;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ibbookapp@gmail", "s3ndEm@ilsThroughCod3!");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.SendAsync(message, boo);
            }
            catch(Exception e)
            {
                Debug.WriteLine("ERROR IN SENDING: " + e);
                Debug.WriteLine("");
                Debug.WriteLine("");
            }
        }
    }
}

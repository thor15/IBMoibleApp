using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                MailMessage mail = new MailMessage();
                mail.From = new System.Net.Mail.MailAddress("ibbookapp@gmail.com");

                // The important part -- configuring the SMTP client
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
                smtp.UseDefaultCredentials = false; // [3] Changed this
                smtp.Credentials = new NetworkCredential("ibbookapp@gmail.com", "npgetelhwyrplixa");  // [4] Added this. Note, first parameter is NOT string.
                smtp.Host = "smtp.gmail.com";

                //recipient address
                mail.To.Add(new MailAddress(email));

                //Formatted mail body
                mail.IsBodyHtml = true;
                mail.Subject = "Password Reset Code";
                mail.Body = "Here is your code: " + code;

                object boo = null;
                smtp.SendAsync(mail, boo);
                
                //MailMessage message = new MailMessage();
                //SmtpClient smtp = new SmtpClient();
                //message.From = new MailAddress();
                //message.To.Add(new MailAddress(email));
                //message.Subject = "Password Reset Code";
                //message.Body = "Here is your code: " + code;
                //smtp.Port = 465;
                //smtp.Host = "smtp.gmail.com"; //for gmail host  
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;
                //smtp.SendCompleted += SendCompletedCallback;
                //smtp.Credentials = new NetworkCredential("ibbookapp@gmail", "s3ndEm@ilsThroughCod3!");
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Send(message);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FaultAlert
{
    public class EmailSender : ISender
    {
        private SmtpClient smtpClient;

        public EmailSender()
        {
            smtpClient = new SmtpClient(Settings.MailHost);
            //port number for Yahoo
            smtpClient.Port = Settings.MailPort;
            //credentials to login in to yahoo account
            smtpClient.Credentials = new NetworkCredential(Settings.MailUser, Settings.MailPass);
            //enabled SSL
            smtpClient.EnableSsl = Settings.MailRequireSSL;
        }

        public bool Send(string subject, string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Settings.MailUser);

                foreach (var to in Settings.MailTo)
                {
                    //receiver email adress
                    mailMessage.To.Add(to);
                }                

                //subject of the email
                mailMessage.Subject = subject;

                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                
                //Send an email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {

            }

            return true;
        }
    }
}

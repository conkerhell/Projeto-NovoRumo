using System;
using System.Configuration;
using System.Net.Mail;

namespace NovoRumoProjeto.Utilities.EmailCreator
{
    public class EmailCreator : IEmailCreator
    {
        private static string SMTPPassword = ConfigurationManager.AppSettings[Consts.SMTP_Password];
        private static string SMTPMail = ConfigurationManager.AppSettings[Consts.SMTP_Mail];
        private MailMessage mailMessage = new MailMessage();

        private EmailCreator(string fromAddress)
        {
            mailMessage.Sender = new MailAddress(fromAddress);
        }

        public static IEmailCreator CreateEmailFrom(string fromAddress)
        {
            return new EmailCreator(fromAddress);
        }

        public IEmailCreator BCC(params string[] bccAddresses)
        {
            foreach (string bccAddress in bccAddresses)
            {
                mailMessage.Bcc.Add(new MailAddress(bccAddress));
            }

            return this;
        }

        public IEmailCreator CC(params string[] ccAddresses)
        {
            foreach (string ccAddress in ccAddresses)
            {
                mailMessage.CC.Add(new MailAddress(ccAddress));
            }

            return this;
        }

        public IEmailCreator From(string fromAddress)
        {
            return this;
        }

        public void Send()
        {
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(SMTPMail, SMTPPassword);
            client.Port = 587;
            client.Host = "smtp.umbler.com";
            client.EnableSsl = true;
            client.Send(mailMessage);
        }

        public IEmailCreator To(params string[] toAddresses)
        {
            foreach (string toAddress in toAddresses)
            {
                mailMessage.To.Add(new MailAddress(toAddress));
            }

            return this;
        }

        public IEmailCreator WithBody(string body)
        {
            mailMessage.Body = body;

            return this;
        }

        public IEmailCreator SetHTML()
        {
            mailMessage.IsBodyHtml = true;

            return this;
        }

        public IEmailCreator WithSubject(string subject)
        {
            mailMessage.Subject = subject;

            return this;
        }
    }
}

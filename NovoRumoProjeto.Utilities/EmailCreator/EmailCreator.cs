using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NovoRumoProjeto.Utilities.EmailCreator
{
    public class EmailCreator : IEmailCreator
    {
        private MailMessage mailMessage = new MailMessage();

        public IEmailCreator BCC(params string[] bccAddresses)
        {
            throw new NotImplementedException();
        }

        public IEmailCreator CC(params string[] ccAddresses)
        {
            throw new NotImplementedException();
        }

        public IEmailCreator From(string fromAddress)
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Credentials = cre
            smtpClient.Timeout = 100;
            smtpClient.Send(mailMessage);
        }

        public IEmailCreator To(params string[] toAddresses)
        {
            throw new NotImplementedException();
        }

        public IEmailCreator WithBody(string body)
        {
            throw new NotImplementedException();
        }

        public IEmailCreator WithSubject(string subject)
        {
            throw new NotImplementedException();
        }
    }
}

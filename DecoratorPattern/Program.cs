using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Component;
using Decorator;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailMessage = getMailMessage();

            // This is our component that can be decorated
            var certificateProvider = new CacheCertificateProvider(new DatabaseCertificateProvider(new CertificateProvider()));

            var messageEncryptor = new MessageEncryptor(mailMessage, certificateProvider);
            var encryptedMessage = messageEncryptor.Encrypt();

            MessageSender.Send(encryptedMessage);
        }




        static MailMessage getMailMessage()
        {
            // Let's pretend this actually returns something meaningful
            return new MailMessage();
        }
    }
}

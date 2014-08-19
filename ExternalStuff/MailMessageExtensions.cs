using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace ExternalStuff
{
    public static class MailMessageExtensions
    {
        public static  MailMessage Clone(this MailMessage mailMessage)
        {
            return mailMessage;
        }

        public static MailMessage Encrypt(this MailMessage mailMessage, X509Certificate2 certificate)
        {
            return mailMessage;
        }
    }
}
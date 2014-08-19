using System.Net.Mail;
using ExternalStuff;
using Interfaces;

namespace DecoratorPattern
{
    public class MessageEncryptor
    {
        private readonly ICertificateProvider _certificateProvider;
        private readonly MailMessage _message;

        public MessageEncryptor(MailMessage message, ICertificateProvider certificateProvider)
        {
            _message = message;
            _certificateProvider = certificateProvider;
        }

        public MailMessage Encrypt()
        {
            var message = _message.Clone();
            foreach (var recipient in _message.To)
            {
                var certificate = _certificateProvider.GetCertificate(recipient.Address);
                message = message.Encrypt(certificate);
            }

            return message;
        }
    }
}
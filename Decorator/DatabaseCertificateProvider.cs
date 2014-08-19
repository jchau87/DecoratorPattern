using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using ExternalStuff;
using Interfaces;

namespace Decorator
{
    public class DatabaseCertificateProvider : CertificateProviderDecorator
    {
        public DatabaseCertificateProvider(ICertificateProvider certificateProvider) : base(certificateProvider)
        {
        }

        public override X509Certificate2 GetCertificate(string commonName)
        {
            // Try to read from database
            var certificate = Certificate.Where(commonName: commonName);

            if (certificate == null)
            {
                certificate = _certificateProvider.GetCertificate(commonName);

                // Save to database
                Certificate.Create(commonName: commonName, certificate: certificate);
            }

            return certificate;
        }
    }
}
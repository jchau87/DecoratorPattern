using System.Security.Cryptography.X509Certificates;
using ExternalStuff;
using Interfaces;

namespace Component
{
    /// <summary>
    /// Concreate Component
    /// </summary>
    public class CertificateProvider : ICertificateProvider
    {
        public X509Certificate2 GetCertificate(string commonName)
        {
            var dnsCertResolver = new DnsCertResolver();

            // This makes external calls and stuff so its slow
            return dnsCertResolver.Resolve(commonName);
        }
    }
}
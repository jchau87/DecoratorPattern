using System.Security.Cryptography.X509Certificates;
using ExternalStuff;
using Interfaces;

namespace Decorator
{
    public class CacheCertificateProvider : CertificateProviderDecorator
    {
        public CacheCertificateProvider(ICertificateProvider certificateProvider) : base(certificateProvider)
        {
        }

        public override X509Certificate2 GetCertificate(string commonName)
        {
            var key = string.Format("__certificate__{0}", commonName);

            // Try to read from cache
            var certificate = (X509Certificate2)Cache.Get(key);

            if (certificate == null)
            {
                certificate = _certificateProvider.GetCertificate(commonName);

                // Save to cache
                Cache.Store(key, certificate);
            }

            return certificate;
        }
    }
}
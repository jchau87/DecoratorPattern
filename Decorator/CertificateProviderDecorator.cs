using System.Security.Cryptography.X509Certificates;
using Interfaces;

namespace Decorator
{
    /// <summary>
    /// Decorator class
    /// </summary>
    public abstract class CertificateProviderDecorator : ICertificateProvider
    {
        protected readonly ICertificateProvider _certificateProvider;

        protected CertificateProviderDecorator(ICertificateProvider certificateProvider)
        {
            _certificateProvider = certificateProvider;
        }

        virtual public X509Certificate2 GetCertificate(string commonName)
        {
            return _certificateProvider.GetCertificate(commonName);
        }
    }
}
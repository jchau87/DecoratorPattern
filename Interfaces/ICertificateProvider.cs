using System.Security.Cryptography.X509Certificates;

namespace Interfaces
{
    public interface ICertificateProvider
    {
        X509Certificate2 GetCertificate(string commonName);
    }
}
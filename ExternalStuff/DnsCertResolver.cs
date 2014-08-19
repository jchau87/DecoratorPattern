using System.Security.Cryptography.X509Certificates;

namespace ExternalStuff
{
    public class DnsCertResolver
    {
        public X509Certificate2 Resolve(string commonName)
        {
            return new X509Certificate2();
        }
    }
}
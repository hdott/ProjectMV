using System;
using System.Security.Cryptography;

namespace AsymmetricEncriptionAssembly
{
    public class AsymmetricEncription
    {
        private RSACryptoServiceProvider rsa = null;
        private string _publicKey;
        private string _privateKey;
        public AsymmetricEncription()
        {
            rsa = new RSACryptoServiceProvider();

            _publicKey = rsa.ToXmlString(false);
            _privateKey = rsa.ToXmlString(true);
        }

        public string getPublicKey()
        {
            return _publicKey;
        }

        public string getPrivateKey()
        {
            return _privateKey;
        }

        public byte[] Encription(string publicKey, byte[] data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);

                return rsa.Encrypt(data, false);
            }
        }

        public byte[] Decription(string privateKey, byte[] data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);

                try
                {
                    return rsa.Decrypt(data, false);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdigiousTest.Security
{
    public class BaseSecurity : IBaseSecurity
    {
        private Login login;
        private Cryptography cryptography;

        public BaseSecurity()
        {
            login = new Login();
            cryptography = new Cryptography();
        }
        public void Login(string User, string Password)
        {
            throw new NotImplementedException();
        }
        public string Encrypt(string text)
        {
            return cryptography.Encrypt(text);
        }
        public string Decrypt(string text)
        {
            return cryptography.Decrypt(text);
        }
    }
}

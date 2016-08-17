namespace ProdigiousTest.Security
{
    public interface IBaseSecurity
    {
        void Login(string User, string Password);
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
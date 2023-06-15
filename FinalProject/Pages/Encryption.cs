using System.Security.Cryptography;
using System.Text;

namespace FinalProject.Pages
{
    public class Encryption
    {
        public string Encrypt(string value)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] data = MD5.Create().ComputeHash(utf8.GetBytes(value));
            return Convert.ToBase64String(data);
        }
    }
}

using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace Front.Helpers
{
    public static class Encryption
    {
        public static string SHA256(string plaintext)
        {
            byte[] source = Encoding.Default.GetBytes(plaintext);
            byte[] encryted3 = new SHA256Managed().ComputeHash(source);

            string ciphertext = string.Concat(
                encryted3.Select(
                    x => x.ToString("X2")
                )
            );
            

            return ciphertext.ToUpper();
        }
    }
}

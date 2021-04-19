using System.Security.Cryptography;
using System.Text;

namespace overDeRhein.Classes
{
    public class Cryptography
    {
        public string CreateHash(string password)
        {
            var bytes = Encoding.ASCII.GetBytes(password);
            var sha512 = new SHA512Managed();
            var hash = sha512.ComputeHash(bytes);

            string returnHash = "";
            foreach (byte hashToString in hash)
            {
                returnHash = $"{returnHash}{hashToString.ToString("x2")}";
            }

            return returnHash;
        }
    }
}
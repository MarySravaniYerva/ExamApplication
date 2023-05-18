using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EA.Repository.Utilities
{
    public class SaltHash
    {
        public static string Createsalt(int size)
        {
            RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();
            byte[] Buffer = new byte[size];
            Rand.GetBytes(Buffer);
            return Convert.ToBase64String(Buffer);
        }
        public static string CreateHash(string password, string Salt)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] PasswordBytes = Encoding.Unicode.GetBytes(password);
            byte[] SaltBytes = Convert.FromBase64String(Salt);
            byte[] PasswordAndSalt = new byte[SaltBytes.Length + PasswordBytes.Length];
            Array.Copy(PasswordBytes, 0, PasswordAndSalt, 0, PasswordBytes.Length);
            Array.Copy(SaltBytes, 0, PasswordAndSalt, PasswordBytes.Length, SaltBytes.Length);
            return Convert.ToBase64String(sha1.ComputeHash(PasswordAndSalt));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoService.Interface;
using System.Security.Cryptography;


namespace CryptoService
{
    public class PasswordService : IPasswordService
    {
        private int SaltLength = 128;

        public string GetSalt()
        {
            var cryptoService = new RNGCryptoServiceProvider();
            var saltBytes = new byte[SaltLength];
            cryptoService.GetNonZeroBytes(saltBytes);
            return Encoding.Unicode.GetString(saltBytes);
        }

        public string GetHash(string password, string salt)
        {
            var bytes = Encoding.Unicode.GetBytes(password + salt);
            var hashed = MD5.Create().ComputeHash(bytes);
            return Encoding.Unicode.GetString(hashed);
        }

        public bool VerifyPassword(string password, string salt, string hash)
        {
            return hash == GetHash(password, salt);
        }
    }
}

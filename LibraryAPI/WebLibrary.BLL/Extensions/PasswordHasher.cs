using System.Text;
using WebLibrary.BLL.Resources;
using System.Security.Cryptography;
using WebLibrary.BLL.Exceptions;

namespace WebLibrary.BLL.Extensions
{
    public static class PasswordHasher
    {
        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;

        private const int SaltSize = 16;

        private const int HashSize = 20;

        public static string Hash(string password, int iterations)
        {
            byte[] salt;

            salt = RandomNumberGenerator.GetBytes(SaltSize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                HashAlgorithm,
                HashSize
                );

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);

            return $"$FORMALHASH${iterations}${base64Hash}";
        }

        public static string Hash(string password)
        {
            var randomValue = new Random().Next(10000,15000);

            return Hash(password, randomValue);
        }

        public static bool IsHashSupported(string hash)
        {
            var isValid = hash.Equals("$FORMALHASH$");

            return isValid;
        }

        public static bool IsHashVerified(string password, string hashedPassword)
        {
            if(!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException(HashExceptionMessages.HashIsNotSupported);
            }

            var splittedHash = hashedPassword.Replace("$FORMALHASH$", "").Split("$");
            var iterations = int.Parse(splittedHash[0]);
            var base64Hash = splittedHash[1];

            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                HashAlgorithm,
                HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

using EnterpriseApi.Application.Interfaces;
using System;
using System.Security.Cryptography;

namespace EnterpriseApi.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100000;

        public string Hash(string value)
        {
            using var algorithm =
                new Rfc2898DeriveBytes(
                    value,
                    SaltSize,
                    Iterations,
                    HashAlgorithmName.SHA256);

            var key = algorithm.GetBytes(KeySize);

            var salt = algorithm.Salt;

            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(key)}";
        }

        public bool Verify(string value, string hash)
        {
            var parts = hash.Split('.', 3);

            if (parts.Length != 3)
                return false;

            var iterations = int.Parse(parts[0]);

            var salt = Convert.FromBase64String(parts[1]);

            var key = Convert.FromBase64String(parts[2]);

            using var algorithm =
                new Rfc2898DeriveBytes(
                    value,
                    salt,
                    iterations,
                    HashAlgorithmName.SHA256);

            var keyToCheck = algorithm.GetBytes(KeySize);

            return CryptographicOperations.FixedTimeEquals(
                keyToCheck,
                key);
        }
    }
}
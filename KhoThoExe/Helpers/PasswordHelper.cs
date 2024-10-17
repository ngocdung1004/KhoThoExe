using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace KhoThoExe.Helpers
{
    public class PasswordHelper
    {
        // Hàm băm mật khẩu
        public static string HashPassword(string password)
        {
            // Tạo salt
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Băm mật khẩu với salt
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Ghép salt với mật khẩu đã băm và trả về
            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        // Hàm xác thực mật khẩu
        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var parts = hashedPassword.Split('.');
            if (parts.Length != 2) return false;

            var salt = Convert.FromBase64String(parts[0]);
            var hash = parts[1];

            // Băm mật khẩu người dùng cung cấp với salt đã lưu
            string providedHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: providedPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // So sánh mật khẩu đã băm
            return hash == providedHash;
        }
    }
}


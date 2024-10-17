using KhoThoExe.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KhoThoExe.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(int userId, string email, string userType)
        {
            // Kiểm tra null cho các giá trị đầu vào
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), "Email cannot be null or empty");
            }

            if (string.IsNullOrEmpty(userType))
            {
                throw new ArgumentNullException(nameof(userType), "User type cannot be null or empty");
            }

            // Tạo mã thông báo dựa trên userId, email, và userType
            var tokenData = $"{userId}:{email}:{userType}";
            var tokenBytes = Encoding.UTF8.GetBytes(tokenData);
            var token = Convert.ToBase64String(tokenBytes);

            return token;
        }

    }
}

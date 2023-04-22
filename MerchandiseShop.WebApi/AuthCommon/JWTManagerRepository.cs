using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MerchandiseShop.WebApi.AuthCommon
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration _configuration;

        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            this._configuration = iconfiguration;
        }

        public Tokens GenerateRefreshToken(TokenData tokenData)
        {
            return GenerateToken(tokenData);
        }

        public Tokens GenerateToken(TokenData tokenData)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = "";
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("Id", tokenData.UserId.ToString()),
                        new Claim("Email", tokenData.Email),
                        new Claim("RoleName", tokenData.RoleName)
                }),
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();
            return new Tokens {AccessToken = jwtToken, RefreshToken = refreshToken };
        }

        public TokenData GetPrincipalFromExpiredToken(string token)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = "";
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = issuer,
                ValidAudience = audience,
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            
            return new TokenData
            {
                UserId = Guid.Parse(principal.Claims.FirstOrDefault(i => i.Type == "Id").Value),
                Email = principal.Claims.FirstOrDefault(i => i.Type == "Email").Value,
                RoleName = principal.Claims.FirstOrDefault(i => i.Type == "RoleName").Value
            };
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}

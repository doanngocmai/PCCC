using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PCCC.Common.Utils;
using PCCC.Service.Services;

namespace PCCC.API.Middleware
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration Configuration;

        public JWTMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            Configuration = configuration;
        }

        public PayloadModel CheckToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var secretKey = Configuration["AppSettings:Secret"];
                var key = Encoding.ASCII.GetBytes(secretKey);
                // Giải mã Key Truyền lên
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                return new PayloadModel
                {
                    ID = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value),
                    TokenType = jwtToken.Claims.First(x => x.Type == "type").Value
                };
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new PayloadModel
                {
                    ID = 0,
                    TokenType = PCCCConsts.TOKEN_TYPE_CUSTOMER
                };
            }
        }
    }
}

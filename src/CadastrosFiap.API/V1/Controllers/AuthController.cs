using CadastrosFiap.API.Controllers;
using CadastrosFiap.API.Extensions;
using CadastrosFiap.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CadastrosFiap.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/autenticacao")]
    public class AuthController : MainController
    {
        public readonly AppSettings _appSettings;

        public AuthController(INotificador notificador, IOptions<AppSettings> appSettings) : base(notificador)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Obter token JWT para autenticaçao
        /// </summary>
        [HttpGet]
        public string GetJwt()
        {
            var jwt = GerarJwt();

            if (string.IsNullOrEmpty(jwt))
            {
                return string.Empty;
            }

            return jwt;
        }

        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                //Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }
    }
}

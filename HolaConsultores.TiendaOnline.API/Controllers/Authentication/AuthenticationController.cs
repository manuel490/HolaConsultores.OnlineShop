using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using System.Text;
using NuGet.Common;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IServices;
using HolaConsultores.TiendaOnline.Domain.Resources.User;

namespace HolaConsultores.TiendaOnline.API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string? secretKey;
        private readonly string? adminEmail;
        private readonly string? adminPassword;
        private readonly IUserService<UserResource, UserResource> _service;

        public AuthenticationController(IConfiguration config,
                                        IUserService<UserResource, UserResource> service)
        {
            secretKey = config?.GetSection("settings")["secretKey"].ToString();
            adminEmail = config?.GetSection("settings")["adminEmail"];
            adminPassword = config?.GetSection("settings")["adminPassword"];
            
            _service = service;
        }

        [HttpPost]
        [Route("Validate")]
        public async Task<ActionResult> Validate(UserResource resource)
        {
            if (!string.IsNullOrWhiteSpace(secretKey) &&
                !string.IsNullOrWhiteSpace(adminEmail) &&
                !string.IsNullOrWhiteSpace(adminPassword))
            {
                var userExist = await _service.UserExist(resource);
                var isAdmin = resource.Email.Equals(adminEmail) && resource.Password.Equals(adminPassword);
                if (userExist || isAdmin)
                {
                    var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                    var claims = new ClaimsIdentity();

                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, resource.Email));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                    string createdToken = tokenHandler.WriteToken(tokenConfig);

                    return Ok(new { token = createdToken });
                }
            }
            return Unauthorized();
        }

    }
}

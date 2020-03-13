using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sys3.Web.API.Login.Models;

namespace Sys3.Web.API.Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario request)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Usu_Nome)
                //new Claim(ClaimTypes.Role, "Admin")
            };
                
            //recebe uma instancia da classe SymmetricSecurityKey 
            //armazenando a chave de criptografia usada na criação do token
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "macoratti.net",
                audience: "macoratti.net",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return Ok(new{ token = new JwtSecurityTokenHandler().WriteToken(token) });

        }
    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys3.Web.API.Login.Models;

namespace Sys3.Web.API.Login.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]    
    public class LoginController : ControllerBase
    {
        #region Consultar
        [Route("Consultas/ConsultarUsuario")]
        [HttpPost]
        public IActionResult ConsultarUsuario(Usuario users)
        {
            if (users.Usu_Nome == null)
            {
                return BadRequest("Nome de usuário inválido.");
            }

            var retorno = Business.Consultas.ValidaUsuario(users);
            if (retorno.ToString().Contains("Erro: "))
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }
        #endregion

    }
}

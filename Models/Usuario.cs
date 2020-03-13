using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys3.Web.API.Login.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public int Usu_Codigo { get; set; }
        public string Usu_Nome { get; set; }
        public string usuario { get; set; }
        public string Usu_Senha { get; set; }
        public DateTime Usu_DataCadastrado { get; set; }

    }
}

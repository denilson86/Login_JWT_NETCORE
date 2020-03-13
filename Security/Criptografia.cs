using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys3.Web.API.Login.Security
{
    public class Criptografia
    {
        public static string CriptografarDados(string Dados)
        {
            try
            {
                SysCob.Library.Criptografia crpt = new SysCob.Library.Criptografia();
                crpt.Dados(Dados);
                string DadosCript = crpt.CriptografarDados();
                return DadosCript;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
        }
    }
}

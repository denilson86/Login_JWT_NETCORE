using System;
using System.Collections.Generic;
using Sys3.Web.API.Login.Models;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using RestSharp;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Sys3.Web.API.Login.Business
{
    public class Consultas
    {
        #region Usuario
        public static Object ValidaUsuario(Usuario users)
        {
            try
            {
                DataSet ds = new DataSet();

                string sSql = "SELECT * FROM usuarios WHERE usu_nome= '" + users.Usu_Nome + "'";                
                ds = Connections.ConnPostgreSql.Select(sSql, 1);

                if (ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dataRows in ds.Tables[0].Rows)
                    {
                        Usuario user = new Usuario();
                        //Comparar Senhas
                        if (users.Usu_Senha != dataRows["usu_senha"].ToString())
                        {
                            return ("Erro: Senha inválida.");
                        }
                        else
                        {
                            try
                            {
                                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44316/api/Token");
                                httpWebRequest.ContentType = "application/json";
                                httpWebRequest.Method = "POST";
                                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                {
                                    streamWriter.Write("{\"Usu_Nome\":\"" + users.Usu_Nome + "\"}");
                                    streamWriter.Flush();
                                    streamWriter.Close();
                                }

                                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                {
                                    var result = streamReader.ReadToEnd();
                                    return result;
                                }
                            }
                            catch (WebException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                    }                    

                }
                else
                {
                    return ("Erro: Credenciais inválidas.");
                }

                return ("Erro: TimeOut.");
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}

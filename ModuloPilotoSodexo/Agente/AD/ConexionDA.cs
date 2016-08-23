using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.Agente.AD
{
    public static class ConexionDA
    {
        public static string CadenaConexion
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Viatecla.Factory.Scriptor.ConnectionString"]);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
namespace ServicioOracleWCF
{
    /// <summary>
    /// Descripción breve de ConexionBD
    /// </summary>
    /// 
    public class ConexionBD
    {

        private OracleConnection cnx = new OracleConnection();

        public string conexionString =
            ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString.ToString();

        public OracleConnection conectar()
        {
            string cadena = conexionString;
            OracleConnection conexion = new OracleConnection(cadena);
            return conexion;
        }

        public string NombrePaqueteSeguimientoPedido()
        {
            return ConfigurationManager.AppSettings["NombrePaqueteSeguimientoPedido"].ToString();
        }


        //public void conectar()
        //{
        //    cnx = conectar_aux();
        //    cnx.Open();
        //}

        public void conexionClose()
        {
            cnx.Close();
            cnx.Dispose();
        }
    }
}
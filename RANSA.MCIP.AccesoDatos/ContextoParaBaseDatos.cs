using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
//using GR.COMEX.Comercial.Entidades.Core;
//using GR.COMEX.Comun.Entidades.Core;
//using GR.COMEX.Facturacion.Entidades.Core;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
//using GR.COMEX.Facturacion.Entidades.Integracion.Sodimac;
using System.Data;

namespace RANSA.MCIP.AccesoDatos
{
    public class ContextoParaBaseDatos : DbContext
    {
        public static string DecryptedConnectionString(string Servidor = null)
        {
            //get
            //{
            string cadenaconexion = "";
            if (string.IsNullOrEmpty(Servidor))
            {
                if (ConfigurationManager.AppSettings["TrabajarConContextoLocal"].ToString().ToUpper() == "TRUE")
                {
                    cadenaconexion = ConfigurationManager.ConnectionStrings["ContextoParaBaseDatosLocal"].ToString();
                }
                else
                {
                    cadenaconexion = RANSA.MCIP.Framework.ManejadorEncriptacion.Desencriptar(ConfigurationManager.ConnectionStrings["ContextoParaBaseDatosEncriptado"].ToString());
                }
            }
            else if (Servidor == "ANTP")
            {
                cadenaconexion = ConfigurationManager.ConnectionStrings["ANTP"].ToString();
            }
            
            return cadenaconexion;
            //}
        }

        public ContextoParaBaseDatos(string Servidor = null)
            : base(DecryptedConnectionString(Servidor))
        {
            Database.SetInitializer<ContextoParaBaseDatos>(null);

        }
        public ContextoParaBaseDatos(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        public void CrearConexion()
        {
            if (((IObjectContextAdapter)this).ObjectContext.Connection.State != ConnectionState.Open)
                ((IObjectContextAdapter)this).ObjectContext.Connection.Open();

            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["TimeOutWcfMinutos"]) * 60;
        }

        public void CerrarConexion()
        {
            if (((IObjectContextAdapter)this).ObjectContext.Connection.State == System.Data.ConnectionState.Open)
                ((IObjectContextAdapter)this).ObjectContext.Connection.Close();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}

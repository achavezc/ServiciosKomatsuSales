using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.Entidades.Constantes
{
    public class ConstantesConfig
    {
        #region Canales

        public static string GuidCanalTipoPedido
        {
            get { return (ConfigurationManager.AppSettings["GuidCanalTipoPedido"].ToString()); }
        }

        public static string GuidCanalCuenta
        {
            get { return (ConfigurationManager.AppSettings["GuidCanalCuenta"].ToString()); }
        }

        public static string GuidCanalNegocio
        {
            get { return (ConfigurationManager.AppSettings["GuidCanalNegocio"].ToString()); }
        }

        public static string GuidCanalAlmacen
        {
            get { return (ConfigurationManager.AppSettings["GuidCanalAlmacen"].ToString()); }
        }

        public static string GuidCanalCliente
        {
            get { return (ConfigurationManager.AppSettings["GuidCanalCliente"].ToString()); }
        }

        #endregion
    }
}

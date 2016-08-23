using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.Framework
{
    public class ManejadorUrl
    {
        public static string obtenerUrlServicio(string nombreParametro)
        {
            string urlIp = ConfigurationManager.AppSettings["ipServicioWcf"];
            string urlParteServicio = ConfigurationManager.AppSettings[nombreParametro];

            return urlIp + urlParteServicio;
        }

        public static string obtenerUrlServicioSeguridad(string nombreParametro)
        {
            string urlIp = ConfigurationManager.AppSettings["ipServicioSeguridad"];
            string urlParteServicio = ConfigurationManager.AppSettings[nombreParametro];

            return urlIp + urlParteServicio;
        }

        public static string obtenerUrlServicioBroker(string nombreParametro)
        {
            string urlIp = ConfigurationManager.AppSettings["ipServicioBroker"];
            string urlParteServicio = ConfigurationManager.AppSettings[nombreParametro];

            return urlIp + urlParteServicio;
        }

        public static string obtenerUrlServicioSUNAT(string nombreParametro)
        {
            string urlIp = ConfigurationManager.AppSettings["ipServicioSUNAT"];
            string urlParteServicio = ConfigurationManager.AppSettings[nombreParametro];

            return urlIp + urlParteServicio;
        }
    }
}

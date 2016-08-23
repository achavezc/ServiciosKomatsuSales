using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ModuloPilotoSodexo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(
              name: "ModuloPilotoSodexo",
              url: "ModuloPilotoSodexo/{action}/{id}",
              defaults: new { controller = "ModuloPilotoSodexo", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
           name: "FrameworkGR",
           url: "FrameworkGR/{action}/{id}",
           defaults: new { controller = "FrameworkGR", action = "Index", id = UrlParameter.Optional }
       );
            routes.MapRoute(
                name: "Maestros",
                url: "Maestros/{action}/{id}",
                defaults: new { controller = "Maestros", action = "Index", id = UrlParameter.Optional }
           );
            //path = "es-PE/sistema/pedidos/pedido_individual/" 
            routes.MapRoute(
              name: "SeguridadLocal",
              url: "SeguridadLocal/{action}/{id}",
              defaults: new { controller = "SeguridadLocal", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "AdjuntarArchivos",
             url: "AdjuntarArchivos/{action}/{id}",
             defaults: new { controller = "AdjuntarArchivos", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
              name: "PedidoIndividual",
              url: "PedidoIndividual/{action}/{id}",
              defaults: new { controller = "PedidoIndividual", action = "Index", id = UrlParameter.Optional }
          );

        }
        public static string GetIpAddress()  // Get IP Address
        {
            string ip = "";
            IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
            IPAddress[] addr = ipEntry.AddressList;
            if (addr.Length > 1)
            {
                ip = addr[2].ToString();
            }
            return ip;
        }
        public static string GetCompCode()  // Get Computer Name
        {
            string strHostName = "";
            strHostName = Dns.GetHostName();
            return strHostName;
        }
    }
}
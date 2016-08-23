using GR.Scriptor.Comun.Controladoras.Proxys;
using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.Maestros;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.Proxy
{
    public class MaestroProxyRest : ProxyBaseRest
    {   
        string urlListarCliente = ConfigurationManager.AppSettings["UrlListarCliente"];
        string urlListarCuenta = ConfigurationManager.AppSettings["UrlListarCuenta"];
        string urlListarTipoPedido = ConfigurationManager.AppSettings["UrlListarTipoPedido"];
        string urlListarNegocio = ConfigurationManager.AppSettings["UrlListarNegocio"];
        string urlListarAlmacen = ConfigurationManager.AppSettings["UrlListarAlmacen"];
        string urlObtenerCorrelativoMaestro = ConfigurationManager.AppSettings["UrlObtenerCorrelativoMaestro"];

        public ResponseListarClienteDTO ListarCliente()
        {           
            //var request = String.Empty;
            var response = DeserializarJSON<String, ResponseListarClienteDTO>(String.Empty, urlListarCliente);
            return response;
        }
        public ResponseObtenerCorrelativoMaestro ObtenerCorrelativoMaestro(RequestObtenerCorrelativoMaestro requestObtenerCorrelativoMaestro)
        {
            //var request = String.Empty;
            var response = DeserializarJSON<RequestObtenerCorrelativoMaestro, ResponseObtenerCorrelativoMaestro>(requestObtenerCorrelativoMaestro, urlObtenerCorrelativoMaestro);
            return response;
        }
        public ResponseListarCuentaDTO ListarCuenta()
        {
            //var request = String.Empty;
            var response = DeserializarJSON<String, ResponseListarCuentaDTO>(String.Empty, urlListarCuenta);
            return response;
        }

        public ResponseListarTipoPedidoDTO ListarTipoPedido()
        {
            //var request = String.Empty;
            var response = DeserializarJSON<String, ResponseListarTipoPedidoDTO>(String.Empty, urlListarTipoPedido);
            return response;
        }

        public ResponseListarNegocioDTO ListarNegocio()
        {
            //var request = String.Empty;
            var response = DeserializarJSON<String, ResponseListarNegocioDTO>(String.Empty, urlListarNegocio);
            return response;
        }

        public ResponseListarAlmacenDTO ListarAlmacen()
        {
            //var request = String.Empty;
            var response = DeserializarJSON<String, ResponseListarAlmacenDTO>(String.Empty, urlListarAlmacen);
            return response;
        }        
    }
}
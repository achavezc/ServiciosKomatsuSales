using GR.Scriptor.Comun.Controladoras.Proxys;
using RANSA.MCIP.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using RANSA.MCIP.DTO.Maestros;

namespace ModuloPilotoSodexo.Proxy
{
    public class PedidoProxyRest : ProxyBaseRest
    {

        public ResponseRegistarPedidoDTO RegistrarPedido(RequestRegistroPedidoIndividualDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlRegistrarPedido"];

            var response = DeserializarJSON<RequestRegistroPedidoIndividualDTO, ResponseRegistarPedidoDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }
        public ResponseRegistarPedidoDTO EliminarPedido(List<EliminarPedidoDTO> request)
        {
            var url = ConfigurationManager.AppSettings["UrlEliminarPedido"];

            var response = DeserializarJSON<List<EliminarPedidoDTO>, ResponseRegistarPedidoDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }
        public ResponseValidarCamposDTO ObtenerCamposPedido(RequestValidarCamposDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlValidarPedido"];

            var response = DeserializarJSON<RequestValidarCamposDTO, ResponseValidarCamposDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }
        public ResponseRegistarPedidoDTO ActualizarPedido(RequestRegistroPedidoIndividualDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlActualizarPedido"];

            var response = DeserializarJSON<RequestRegistroPedidoIndividualDTO, ResponseRegistarPedidoDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }
        public ResponseListarPedidoDTO ListarPedido(RequestListarPedidoIndividualDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlListarPedido"];

            var response = DeserializarJSON<RequestListarPedidoIndividualDTO, ResponseListarPedidoDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }
        public ResponseDetallePedidoDTO ObtenerDetallePedido(RequestDetallePedidoIndividualDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlObtenerDetallePedido"];

            var response = DeserializarJSON<RequestDetallePedidoIndividualDTO, ResponseDetallePedidoDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }

        public ResponseRegistarPedidoDTO RegistrarPedidoMasivo(List<RequestRegistroPedidoIndividualDTO> request)
        {
            var url = ConfigurationManager.AppSettings["UrlRegistrarPedidoMasivo"];

            var response = DeserializarJSON<List<RequestRegistroPedidoIndividualDTO>, ResponseRegistarPedidoDTO>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }
        public ResponseObtenerCorrelativoMaestro ObtenerNumeroPedido(RequestObtenerCorrelativoMaestro request)
        {
            var url = ConfigurationManager.AppSettings["UrlObtenerNumeroPedido"];

            var response = DeserializarJSON<RequestObtenerCorrelativoMaestro, ResponseObtenerCorrelativoMaestro>(request, url);
            if (response == null)
                throw new Exception(string.Format("Problemas con el servicio: {0}", url));

            return response;
        }
    }
}
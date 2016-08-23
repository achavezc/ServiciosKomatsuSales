/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:29 p.m.
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Framework;
using RANSA.MCIP.DTO.Maestros;


namespace RANSA.MCIP.AgenteServicios
{
    public class AgenteServicioOracle : BaseAgenteServicios
    {

        public ResponseRegistarPedidoDTO RegistrarPedidoIndividual(RequestRegistroPedidoIndividualDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlRegistrarPedido"];
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            response = DeserializarJSON<RequestRegistroPedidoIndividualDTO, ResponseRegistarPedidoDTO>(request, url);
            return response;
        }
        public ResponseRegistarPedidoDTO EliminarPedidoIndividual(List<EliminarPedidoDTO> request)
        {
            var url = ConfigurationManager.AppSettings["UrlEliminarpedido"];
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            response = DeserializarJSON<List<EliminarPedidoDTO>, ResponseRegistarPedidoDTO>(request, url);
            return response;
        }
        public ResponseRegistarPedidoDTO ActualizarPedidoIndividual(RequestRegistroPedidoIndividualDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlActualizarPedido"];
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            response = DeserializarJSON<RequestRegistroPedidoIndividualDTO, ResponseRegistarPedidoDTO>(request, url);
            return response;
        }
        public ResponseListarPedidoDTO ListarPedidoIndividual(RequestListarPedidoIndividualDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlListarPedido"];
            ResponseListarPedidoDTO response = new ResponseListarPedidoDTO();
            response = DeserializarJSON<RequestListarPedidoIndividualDTO, ResponseListarPedidoDTO>(request, url);
            return response;
        }

        public ResponseDetallePedidoDTO ObtenerDetallePedidoIndividual(RequestDetallePedidoIndividualDTO request)
        {
            var url = ConfigurationManager.AppSettings["UrlObtenerDetallePedido"];
            ResponseDetallePedidoDTO response = new ResponseDetallePedidoDTO();
            response = DeserializarJSON<RequestDetallePedidoIndividualDTO, ResponseDetallePedidoDTO>(request, url);
            return response;
        }


        public ResponseRegistarPedidoDTO RegistrarPedidoIndividualMasivo(List<RequestRegistroPedidoIndividualDTO> request)
        {
            var url = ConfigurationManager.AppSettings["UrlRegistrarPedidoMasivo"];
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            response = DeserializarJSON<List<RequestRegistroPedidoIndividualDTO>, ResponseRegistarPedidoDTO>(request, url);
            return response;
        }

        /// <summary>
        ///  Nuevo
        /// </summary>
        /// <returns></returns>
        public ResponseObtenerCorrelativoMaestro ObtenerCorrelativoPedido()
        {
            var url = ConfigurationManager.AppSettings["UrlObtenerCorrelativoPedido"];
            ResponseObtenerCorrelativoMaestro response = new ResponseObtenerCorrelativoMaestro();
            response = DeserializarJSON<string,ResponseObtenerCorrelativoMaestro>("", url);
            return response;
        }
    }
}
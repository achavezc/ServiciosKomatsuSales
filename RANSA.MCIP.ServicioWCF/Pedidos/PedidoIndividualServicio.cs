using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Framework;
using RANSA.MCIP.LogicaNegocio;


namespace RANSA.MCIP.ServicioWCF
{
    public class PedidoIndividualServicio : IPedidoIndividualServicio
    {

        public ResponseRegistarPedidoDTO RegistrarPedidoIndividual(RequestRegistroPedidoIndividualDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                PedidoIndividualBL pedidoBL = new PedidoIndividualBL();
                response = pedidoBL.RegistrarPedidoIndividual(request);
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
            }

            return response;
        }

        public ResponseRegistarPedidoDTO ActualizarPedidoIndividual(RequestRegistroPedidoIndividualDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                PedidoIndividualBL pedidoBL = new PedidoIndividualBL();
                response = pedidoBL.ActualizarPedidoIndividual(request);
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
            }

            return response;
        }

        public ResponseListarPedidoDTO ListarPedidoIndividual(RequestListarPedidoIndividualDTO request)
        {
            ResponseListarPedidoDTO response = new ResponseListarPedidoDTO();
            try
            {
                PedidoIndividualBL pedidoBL = new PedidoIndividualBL();
                response = pedidoBL.ListarPedidoIndividual(request);
            }
            catch (Exception ex)
            {

                response.Resultado = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
            }

            return response;
        }

        public ResponseDetallePedidoDTO ObtenerDetallePedidoIndividual(RequestDetallePedidoIndividualDTO request)
        {
            ResponseDetallePedidoDTO response = new ResponseDetallePedidoDTO();
            try
            {
                PedidoIndividualBL pedidoBL = new PedidoIndividualBL();
                response = pedidoBL.ObtenerDetallePedidoIndividual(request);
            }
            catch (Exception ex)
            {

                response.Resultado = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
            }

            return response;
        }

        public ResponseRegistarPedidoDTO EliminarPedidoIndividual(List<EliminarPedidoDTO> request)
        {

            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                PedidoIndividualBL pedidoBL = new PedidoIndividualBL();
                response = pedidoBL.EliminarPedidoIndividual(request);
            }
            catch (Exception ex)
            {
                response.Result = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
            }
            return response;
        }

        public ResponseValidarCamposDTO ValidarPedidoIndividual(RequestValidarCamposDTO request)
        {

            ResponseValidarCamposDTO response = new ResponseValidarCamposDTO();
            try
            {
                PedidoIndividualBL pedidoBL = new PedidoIndividualBL();
                response = pedidoBL.ValidarCamposPedido(request);
            }
            catch (Exception ex)
            {
                response.Resultado = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
            }
            return response;
        }
        
        public ResponseRegistarPedidoDTO RegistrarPedidoIndividualMasivo(List<RequestRegistroPedidoIndividualDTO> request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                PedidoIndividualBL pedidoBL = new PedidoIndividualBL();
                response = pedidoBL.RegistrarPedidoIndividualMasivo(request);
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
            }

            return response;
        }

         


        public ResponseRegistarPedidoDTO CambiarEstadoPedidoIndivial(CambiarEstadoPedidoDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                PedidoIndividualBL pedidoBL = new PedidoIndividualBL();
                response = pedidoBL.CambiarEstadoPedidoIndividual(request);
            }
            catch (Exception ex)
            {
                response.Result = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
            }
            return response;
        }
    }
}

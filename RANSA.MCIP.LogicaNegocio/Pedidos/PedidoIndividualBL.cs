using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RANSA.MCIP.AccesoDatos;
using RANSA.MCIP.Entidades;
using GR.Scriptor.Framework;
using RANSA.MCIP.AccesoDatos.Pedidos;
using RANSA.MCIP.AgenteServicios;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades.Constantes;
using RANSA.MCIP.DTO.Maestros;


namespace RANSA.MCIP.LogicaNegocio
{
    public class PedidoIndividualBL
    {
        private PedidoDA objDA;
        public PedidoIndividualBL()
        {
            objDA = new PedidoDA(new ContextoParaBaseDatos());
        }

        public ResponseRegistarPedidoDTO RegistrarPedidoIndividual(RequestRegistroPedidoIndividualDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                var agente = new AgenteServicioOracle();
                response = agente.RegistrarPedidoIndividual(request);


            }
            catch (Exception ex)
            {
                response.Result = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return response;
        }
        public ResponseRegistarPedidoDTO EliminarPedidoIndividual(List<EliminarPedidoDTO> request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                var agente = new AgenteServicioOracle();
                response = agente.EliminarPedidoIndividual(request);
            }
            catch (Exception ex)
            {
                response.Result = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return response;
        }
        public ResponseRegistarPedidoDTO ActualizarPedidoIndividual(RequestRegistroPedidoIndividualDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                var agente = new AgenteServicioOracle();
                response = agente.ActualizarPedidoIndividual(request);
            }
            catch (Exception ex)
            {
                response.Result = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return response;
        }
        public ResponseListarPedidoDTO ListarPedidoIndividual(RequestListarPedidoIndividualDTO request)
        {
            var response = new ResponseListarPedidoDTO();
            var cuentaBl = new CuentaBL();
            var negocioBl = new NegocioBL();
            var tipoPedidoBl = new TipoPedidoBL();

            try
            {
                var agente = new AgenteServicioOracle();
                var requestPaginacionDto = new RequestPaginacionBaseDTO();
                int totalRegistros, cantPaginas;
                response = agente.ListarPedidoIndividual(request);

                var lstNegocio = negocioBl.ListarNegocio();
                var lstCuenta = cuentaBl.ListarCuenta();
                var lstTipoPedido = tipoPedidoBl.ListarTipoPedido();
                response.ListaPedidos.ForEach(x =>
                {
                    var firstOrDefault = lstNegocio.Negocios.FirstOrDefault(c => c.CodigoNegocio.Equals(x.CodigoNegocio));
                    if (firstOrDefault != null)
                        x.Negocio = firstOrDefault.Descripcion;

                    var orDefault = lstCuenta.Cuentas.FirstOrDefault(c => c.CodigoCuenta.Equals(x.CodigoCuenta));
                    if (orDefault != null)
                        x.Cuenta = orDefault.Nombre;

                    var tipoPedidoDto = lstTipoPedido.TipoPedidos.FirstOrDefault(c => c.CodigoTipoPedido.Equals(x.CodigoTipoPedido));
                    if (tipoPedidoDto != null)
                        x.TipoPedido = tipoPedidoDto.DescripcionBreve;
                });

                requestPaginacionDto.HabilitarPaginacion = true;
                requestPaginacionDto.OrdenCampo = request.OrdenCampo;
                requestPaginacionDto.OrdenOrientacion = request.OrdenOrientacion;
                requestPaginacionDto.PaginaActual = request.PaginaActual;
                requestPaginacionDto.NroRegistrosPorPagina = request.NroRegistrosPorPagina;
                response.ListaPedidos = PaginacionBL.PaginarLista(response.ListaPedidos, requestPaginacionDto, out totalRegistros, out cantPaginas, "NroPedido");
                //response.TotalRegistros = totalRegistros;
                //response.CantidadPaginas = cantPaginas;
            }
            catch (Exception ex)
            {
                response.Resultado = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return response;
        }
        public ResponseDetallePedidoDTO ObtenerDetallePedidoIndividual(RequestDetallePedidoIndividualDTO request)
        {
            var response = new ResponseDetallePedidoDTO();
            var cuentaBl = new CuentaBL();
            var negocioBl = new NegocioBL();
            var tipoPedidoBl = new TipoPedidoBL();
            var almacenl = new AlmacenBL();
            var clientebl = new ClienteBL();
            var materialbl = new MaterialBL();
            try
            {
                var agente = new AgenteServicioOracle();

                response = agente.ObtenerDetallePedidoIndividual(request);

                var lstNegocio = negocioBl.ListarNegocio();
                var lstCuenta = cuentaBl.ListarCuenta();
                var lstTipoPedido = tipoPedidoBl.ListarTipoPedido();
                var lstAlmacen = almacenl.ListarAlmacen();
                var lstCliente = clientebl.ListarCliente();


                var firstOrDefault = lstNegocio.Negocios.FirstOrDefault(c => c.CodigoNegocio.Equals(response.CodigoNegocio));
                if (firstOrDefault != null)
                    response.Negocio = firstOrDefault.Descripcion;

                var orDefault = lstCuenta.Cuentas.FirstOrDefault(c => c.CodigoCuenta.Equals(response.CodigoCuenta));
                if (orDefault != null)
                    response.Cuenta = orDefault.Nombre;

                var tipoPedidoDto = lstTipoPedido.TipoPedidos.FirstOrDefault(c => c.CodigoTipoPedido.Equals(response.CodigoTipoPedido));
                if (tipoPedidoDto != null)
                    response.TipoPedido = tipoPedidoDto.DescripcionBreve;

                var almacenDto = lstAlmacen.Almacenes.FirstOrDefault(c => c.CodigoAlmacen.Equals(response.CodigoPuntoOrigen));
                if (almacenDto != null)
                    response.NombrePuntoOrigen = almacenDto.Nombre;

                var clienteDto = lstCliente.Clientes.FirstOrDefault(c => c.CodigoCliente.Equals(response.CodigoPuntoDestino));
                if (clienteDto != null)
                    response.NombrePuntoDestino = clienteDto.Nombre;

                response.ListaDetallePedidos.ForEach(x =>
                {
                    var lstMaterial = materialbl.ListarMaterial(x.CodigoMaterial);
                    if (lstMaterial.Materiales.Count > 0)
                    {
                        x.DescripcionMaterial = lstMaterial.Materiales[0].DescripcionBreve;
                    }
                });


            }
            catch (Exception ex)
            {
                response.Resultado = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return response;
        }

        public ResponseValidarCamposDTO ValidarCamposPedido(RequestValidarCamposDTO request)
        {
            var response = new ResponseValidarCamposDTO();
            try
            {
                response.campos = objDA.ValidarCamposPedido(request);
                response.Resultado.Satisfactorio = true;
            }
            catch (Exception ex)
            {
                response.Resultado = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return response;
        }


        // MASIVO JM
        public ResponseRegistarPedidoDTO RegistrarPedidoIndividualMasivo(List<RequestRegistroPedidoIndividualDTO> request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                var agente = new AgenteServicioOracle();
                response = agente.RegistrarPedidoIndividualMasivo(request);
            }
            catch (Exception ex)
            {
                response.Result = new Resultado
                {
                    IdError = Guid.NewGuid(),
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio"
                };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return response;
        }

        public ResponseObtenerCorrelativoMaestro ObtenerCorrelativoPedido()
        {
            ResponseObtenerCorrelativoMaestro response = new ResponseObtenerCorrelativoMaestro();
            try
            {
                var agente = new AgenteServicioOracle();
                response = agente.ObtenerCorrelativoPedido();
            }
            catch (Exception ex)
            {
                response = null;
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }
            return response;

        }

    }
}

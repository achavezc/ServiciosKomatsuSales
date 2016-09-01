using ModuloPilotoSodexo.Agente.AD;
using ModuloPilotoSodexo.Agente.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GR.Scriptor.Framework;
using ModuloPilotoSodexo.Proxy;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades;
using RANSA.MCIP.ViewModel.Pedidos;
using System.Data;
using System.Configuration;
using RANSA.MCIP.DTO.Maestros;

namespace ModuloPilotoSodexo.Agente.BL
{
    public class PedidoBL
    {
        /// <summary>
        /// Registro de Tarifas Locales
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResponseRegistarPedidoViewModel RegistroPedidoIndividual(RequestRegistroPedidoIndividualViewModel request)
        {
            var responseRegistroPedido = new ResponseRegistarPedidoViewModel();
            try
            {
                Mapper.CreateMap<DetallePedidoViewModel, DetallePedidoDTO>();
                Mapper.CreateMap<DetalleAnexoPedidoViewModel, DetalleAnexoPedidoDTO>();
                Mapper.CreateMap<DetalleAnexoAdjuntoPedidoViewModel, DetalleAnexoAdjuntoPedidoDTO>();
                var requestAgente = GR.Scriptor.Framework.Helper.MiMapper<RequestRegistroPedidoIndividualViewModel, RequestRegistroPedidoIndividualDTO>(request);

                var responseRegistroPedidoDto = new PedidoProxyRest().RegistrarPedido(requestAgente);

                responseRegistroPedido.Result.Satisfactorio = responseRegistroPedidoDto.Result.Satisfactorio;
                responseRegistroPedido.Result.idPedido = responseRegistroPedidoDto.Result.idPedido;
                responseRegistroPedido.Result.Mensaje = responseRegistroPedidoDto.Result.Mensaje;
            }
            catch (Exception ex)
            {
                responseRegistroPedido.Result = new RANSA.MCIP.DTO.Result { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return responseRegistroPedido;
        }
        public ResponseValidarCamposViewModel ObtenerCamposPedido(string codigoTipoPedido, string codigoCuenta)
        {
            var responseValidarCamposPedido = new ResponseValidarCamposViewModel();
            try
            {

                var requestAgente = new RequestValidarCamposDTO();
                requestAgente.CodigoCuenta = codigoCuenta;
                requestAgente.CodigoTipoPedido = codigoTipoPedido;
                var responseRegistroPedidoDto = new PedidoProxyRest().ObtenerCamposPedido(requestAgente);
                responseRegistroPedidoDto.campos.ForEach(x =>
                {
                    responseValidarCamposPedido.campos.Add(new ConfiguracionCamposPedidosViewModel
                    {
                        Valor = x.Valor,
                        FlagInhabilitado = x.FlagInhabilitado,
                        FlagObligatorio = x.FlagObligatorio,
                        TipoCampo = x.TipoCampo
                    });
                });

                responseValidarCamposPedido.Resultado.Satisfactorio = responseRegistroPedidoDto.Resultado.Satisfactorio;
                responseValidarCamposPedido.Resultado.Mensaje = responseRegistroPedidoDto.Resultado.Mensaje;
            }
            catch (Exception ex)
            {
                responseValidarCamposPedido.Resultado = new RANSA.MCIP.DTO.Resultado { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return responseValidarCamposPedido;
        }
        public ResponseRegistarPedidoViewModel EliminarPedidoIndividual(List<EliminarPedidoViewModel> request)
        {
            var responseRegistroPedido = new ResponseRegistarPedidoViewModel();
            try
            {


                var requestAgente = new List<EliminarPedidoDTO>();
                request.ForEach(x =>
                {
                    requestAgente.Add(new EliminarPedidoDTO() { Id = x.Id });
                });
                var responseRegistroPedidoDto = new PedidoProxyRest().EliminarPedido(requestAgente);

                responseRegistroPedido.Result.Satisfactorio = responseRegistroPedidoDto.Result.Satisfactorio;
                responseRegistroPedido.Result.idPedido = responseRegistroPedidoDto.Result.idPedido;
                responseRegistroPedido.Result.Mensaje = responseRegistroPedidoDto.Result.Mensaje;
            }
            catch (Exception ex)
            {
                responseRegistroPedido.Result = new RANSA.MCIP.DTO.Result { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return responseRegistroPedido;
        }
        public ResponseRegistarPedidoViewModel ActualizaPedidoIndividual(RequestRegistroPedidoIndividualViewModel request)
        {
            var responseRegistroPedido = new ResponseRegistarPedidoViewModel();
            try
            {

                //Mapper.CreateMap<DetallePedidoViewModel, DetallePedidoDTO>();
                Mapper.CreateMap<DetallePedidoViewModel, DetallePedidoDTO>();
                Mapper.CreateMap<DetalleAnexoPedidoViewModel, DetalleAnexoPedidoDTO>();
                Mapper.CreateMap<DetalleAnexoAdjuntoPedidoViewModel, DetalleAnexoAdjuntoPedidoDTO>();
                var requestAgente = GR.Scriptor.Framework.Helper.MiMapper<RequestRegistroPedidoIndividualViewModel, RequestRegistroPedidoIndividualDTO>(request);
                //var requestAgente = GR.Scriptor.Framework.Helper.MiMapper<RequestRegistroPedidoIndividualViewModel, RequestRegistroPedidoIndividualDTO>(request);
                var responseRegistroPedidoDto = new PedidoProxyRest().ActualizarPedido(requestAgente);

                responseRegistroPedido.Result.Satisfactorio = responseRegistroPedidoDto.Result.Satisfactorio;
                responseRegistroPedido.Result.idPedido = responseRegistroPedidoDto.Result.idPedido;
                responseRegistroPedido.Result.Mensaje = responseRegistroPedidoDto.Result.Mensaje;
            }
            catch (Exception ex)
            {
                responseRegistroPedido.Result = new RANSA.MCIP.DTO.Result { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return responseRegistroPedido;
        }

        public ResponseBusquedaPedidoViewModel BusquedaPedidoIndividual(RequestBusquedaPedidosViewModel request, PaginacionDTO paginacionDTO)
        {
            var responsePedido = new ResponseBusquedaPedidoViewModel();
            try
            {
                var requestAgente = new RequestListarPedidoIndividualDTO()
                {
                    CodigoTipoPedido = request.filtro.CodigoTipoPedido,
                    NroPedido = request.filtro.NroPedido,
                    NumeroReferencia = request.filtro.NumeroReferencia,
                    CodigoNegocio = request.filtro.CodigoNegocio,
                    CodigoCuenta = request.filtro.CodigoCuenta,
                    //EstadoPedido = request.filtro.EstadoPedido,
                    EstadoPedido = request.filtro.Estado,
                    FechaInicioSolicitud = request.filtro.FechaSolicitudInicio,
                    FechaFinSolicitud = request.filtro.FechaSolicitudFin,
                    NroRegistrosPorPagina = paginacionDTO.rows,
                    OrdenCampo = paginacionDTO.sidx,
                    OrdenOrientacion = paginacionDTO.sord,
                    PaginaActual = paginacionDTO.page
                };
                var listapedidos = new PedidoProxyRest().ListarPedido(requestAgente);
                if (listapedidos.ListaPedidos.Count > 0)
                {
                    responsePedido.CantidadPaginas = listapedidos.CantidadPaginas;
                    responsePedido.TotalRegistros = listapedidos.TotalRegistros;
                    responsePedido.NroPagina = listapedidos.NroPagina;
                    responsePedido.Resultado = listapedidos.Resultado;
                    foreach (var item in listapedidos.ListaPedidos)
                    {
                        var objet = new ListaPedidosViewModel();
                        objet.CodigoTipoPedido = item.CodigoTipoPedido;
                        objet.TipoPedido = item.TipoPedido;
                        objet.NroPedido = item.NroPedido;
                        objet.FechaSolicitud = item.FechaSolicitud;
                        objet.HoraSolicitud = item.HoraSolicitud;
                        objet.CodigoCuenta = item.CodigoCuenta;
                        objet.Cuenta = item.Cuenta;
                        objet.CodigoNegocio = item.CodigoNegocio;
                        objet.Negocio = item.Negocio;
                        objet.FechaEstimadaEntrega = item.FechaEstimadaEntrega;
                        objet.NroReferencia = item.NroReferencia;
                        objet.CodigoPuntoOrigen = item.CodigoPuntoOrigen;
                        objet.CodigoPuntoDestino = item.CodigoPuntoDestino;
                        objet.ImpTotalDocumento = item.ImpTotalDocumento;
                        objet.CodigoCondicionPago = item.CodigoCondicionPago;
                        objet.CodigoMonedaPago = item.CodigoMonedaPago;
                        objet.CodigoAreaSolicitante = item.CodigoAreaSolicitante;
                        objet.NumeroFactura = item.NumeroFactura;
                        objet.ClaveSeguimiento = item.ClaveSeguimiento;
                        objet.ObservacionesComentarios = item.ObservacionesComentarios;
                        objet.FechaRegistro = item.FechaRegistro;
                        objet.UsuarioRegistro = item.UsuarioRegistro;
                        objet.FechaModificacion = item.FechaModificacion;
                        objet.UsuarioModificacion = item.UsuarioModificacion;
                        objet.EstadoRegistro = item.EstadoRegistro;
                        objet.IdPedido = item.IdPedido;
                        objet.EstadoPedido = item.EstadoPedido;
                        objet.DireccionOrigen = item.DireccionOrigen;
                        objet.DireccionDestino = item.DireccionDestino;
                        responsePedido.ListaPedidos.Add(objet);
                    }
                }

            }
            catch (Exception ex)
            {
                responsePedido.Resultado = new RANSA.MCIP.DTO.Resultado { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return responsePedido;
        }

        public ResponseDetallePedidoViewModel ObtenerDetallePedidoIndividual(string idpedido)
        {
            var responseDetallePedido = new ResponseDetallePedidoViewModel();
            try
            {
                var requestAgente = new RequestDetallePedidoIndividualDTO()
                {
                    idPedido = idpedido
                };
                var detallePedidoDTO = new PedidoProxyRest().ObtenerDetallePedido(requestAgente);

                responseDetallePedido.CodigoTipoPedido = detallePedidoDTO.CodigoTipoPedido;
                responseDetallePedido.TipoPedido = detallePedidoDTO.TipoPedido;
                responseDetallePedido.NroPedido = detallePedidoDTO.NroPedido;
                responseDetallePedido.FechaSolicitud = string.Format("{0:dd/MM/yyyy}", detallePedidoDTO.FechaSolicitud);
                responseDetallePedido.HoraSolicitud = detallePedidoDTO.HoraSolicitud;
                responseDetallePedido.CodigoCuenta = detallePedidoDTO.CodigoCuenta;
                responseDetallePedido.Cuenta = detallePedidoDTO.Cuenta;
                responseDetallePedido.CodigoNegocio = detallePedidoDTO.CodigoNegocio;
                responseDetallePedido.Negocio = detallePedidoDTO.Negocio;
                responseDetallePedido.FechaEstimadaEntrega = string.Format("{0:dd/MM/yyyy}", detallePedidoDTO.FechaEstimadaEntrega);
                responseDetallePedido.NroReferencia = detallePedidoDTO.NroReferencia;
                responseDetallePedido.CodigoPuntoOrigen = detallePedidoDTO.CodigoPuntoOrigen;
                responseDetallePedido.NombrePuntoOrigen = detallePedidoDTO.NombrePuntoOrigen;
                responseDetallePedido.CodigoPuntoDestino = detallePedidoDTO.CodigoPuntoDestino;
                responseDetallePedido.NombrePuntoDestino = detallePedidoDTO.NombrePuntoDestino;
                responseDetallePedido.ImporteTotalDocumento = detallePedidoDTO.ImpTotalDocumento;
                responseDetallePedido.CondicionPago = detallePedidoDTO.CodigoCondicionPago;
                responseDetallePedido.MonedaPago = detallePedidoDTO.CodigoMonedaPago;
                responseDetallePedido.AreaSolicitante = detallePedidoDTO.CodigoAreaSolicitante;
                responseDetallePedido.NroFactura = detallePedidoDTO.NumeroFactura;
                responseDetallePedido.ClaveSeguimiento = detallePedidoDTO.ClaveSeguimiento;
                responseDetallePedido.Observaciones = detallePedidoDTO.ObservacionesComentarios;
                responseDetallePedido.FechaRegistro = detallePedidoDTO.FechaRegistro;
                responseDetallePedido.UsuarioRegistro = detallePedidoDTO.UsuarioRegistro;
                responseDetallePedido.FechaModificacion = detallePedidoDTO.FechaModificacion;
                responseDetallePedido.UsuarioModificacion = detallePedidoDTO.UsuarioModificacion;
                responseDetallePedido.EstadoRegistro = detallePedidoDTO.EstadoRegistro;
                responseDetallePedido.IdPedido = detallePedidoDTO.IdPedido;
                responseDetallePedido.EstadoPedido = detallePedidoDTO.EstadoPedido;
                responseDetallePedido.DireccionOrigen = detallePedidoDTO.DireccionOrigen;
                responseDetallePedido.DireccionDestino = detallePedidoDTO.DireccionDestino;

                detallePedidoDTO.ListaDetallePedidos.ForEach(x =>
                {
                    var item = new DetallePedidoViewModel();
                    item.IdDetallePedido = x.IdDetallePedido;
                    item.Item = x.Item;
                    item.CodigoMaterial = x.CodigoMaterial;
                    item.DescripcionMaterial = x.DescripcionMaterial;
                    item.Cantidad = x.Cantidad;
                    item.UnidadMedida = x.UnidadMedida;
                    item.Observaciones = x.Observaciones;
                    item.IdPedido = x.IdPedido;
                    item.FechaRegistro = x.FechaRegistro;
                    item.UsuarioRegistro = x.UsuarioRegistro;
                    item.FechaModificacion = x.FechaModificacion;
                    item.UsuarioModificacion = x.UsuarioModificacion;
                    item.EstadoRegistro = x.EstadoRegistro;

                    responseDetallePedido.ListaDetallePedido.Add(item);
                });
                int contador = 0;
                detallePedidoDTO.ListaPedidoAnexos.ForEach(x =>
                {
                    var item = new DetalleAnexoPedidoViewModel();
                    contador = contador + 1;
                    item.FileName = x.FileName;
                    item.Descripcion = x.Descripcion;
                    item.IdPedidoAnexo = x.IdPedidoAnexo;
                    item.Item = Convert.ToString(contador);
                    item.IdPedido = x.IdPedido;
                    item.FechaRegistro = x.FechaRegistro;
                    item.UsuarioRegistro = x.UsuarioRegistro;
                    item.FechaModificacion = x.FechaModificacion;
                    item.UsuarioModificacion = x.UsuarioModificacion;
                    item.EstadoRegistro = x.EstadoRegistro;

                    responseDetallePedido.ListaPedidoAnexos.Add(item);
                });
                var count = 0;
                detallePedidoDTO.ListaPedidoAnexosAdjuntos.ForEach(x =>
                {
                    var item = new DetalleAnexoAdjuntoPedidoViewModel();
                    item.IdPedidoAnexoAdjuntoTemp = count + 1;
                    item.IdPedidoAnexo = x.IdPedidoAnexo;
                    item.IdPedidoAnexoAdjunto = x.IdPedidoAnexoAdjunto;
                    item.ArchivoRealNombre = x.ArchivoRealNombre;
                    item.ArchivoVisualNombre = x.ArchivoVisualNombre;
                    item.ArchivoRutaDescarga = x.ArchivoRutaDescarga;
                    item.ArchivoExtension = x.ArchivoExtension;
                    item.EstadoRegistro = x.EstadoRegistro;

                    responseDetallePedido.ListaPedidoAnexosAdjuntos.Add(item);
                });
            }
            catch (Exception ex)
            {
                responseDetallePedido.Resultado = new RANSA.MCIP.DTO.Resultado { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return responseDetallePedido;
        }

        public ResponseObtenerCorrelativoMaestroViewModel ObtenerNumeroPedido()
        {
            ResponseObtenerCorrelativoMaestroViewModel response = new ResponseObtenerCorrelativoMaestroViewModel();
            try
            {
                var requestAgente = new RequestObtenerCorrelativoMaestro();
                requestAgente.Tipo = "pedido";
                var responseDTO = new PedidoProxyRest().ObtenerNumeroPedido(requestAgente);

                response.Correlativo = responseDTO.Correlativo;
            }
            catch (Exception ex)
            {
                response.Result = new RANSA.MCIP.DTO.Result { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return response;
        }


        #region Carga Masivo Pedido Individual

        public ResponseRegistarPedidoViewModel RegistroMasivoPedidoIndividualMasivo(RequestRegistroMasivoPedidoIndividualViewModel request)
        {
            var responseRegistroMasivoPedido = new ResponseRegistarPedidoViewModel();
            try
            {
                var ListRequesAgente = new List<RequestRegistroPedidoIndividualDTO>();
                foreach (var item in request.ListaCargaMasiva)
                {
                    Mapper.CreateMap<DetallePedidoViewModel, DetallePedidoDTO>();
                    var requestAgente = GR.Scriptor.Framework.Helper.MiMapper<RequestRegistroPedidoIndividualViewModel, RequestRegistroPedidoIndividualDTO>(item);
                    ListRequesAgente.Add(requestAgente);
                }
                var responseRegistroMasivoPedidoDto = new PedidoProxyRest().RegistrarPedidoMasivo(ListRequesAgente);

                responseRegistroMasivoPedido.Result.Satisfactorio = responseRegistroMasivoPedidoDto.Result.Satisfactorio;
                responseRegistroMasivoPedido.Result.idPedido = responseRegistroMasivoPedidoDto.Result.idPedido;
                responseRegistroMasivoPedido.Result.Mensaje = responseRegistroMasivoPedidoDto.Result.Mensaje;
            }
            catch (Exception ex)
            {
                responseRegistroMasivoPedido.Result = new RANSA.MCIP.DTO.Result { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return responseRegistroMasivoPedido;
        }


        public List<RequestRegistroPedidoIndividualViewModel> CargarDatosMasivos(HttpPostedFileBase upload)
        {
            List<RequestRegistroPedidoIndividualViewModel> ListaPedidoIndividualMasivo = new List<RequestRegistroPedidoIndividualViewModel>();
            var usuario = Helper.HelperCtrl.ObtenerUsuario();
            DataSet DTsCargaMAsivo = new DataSet("CargaMasiva");
            bool hasHeader = true;
            try
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    using (var pck = new OfficeOpenXml.ExcelPackage())
                    {
                        using (var stream = upload.InputStream)
                        {
                            pck.Load(stream);
                        }
                        var CantidadWS = pck.Workbook.Worksheets.Count();
                        // Cargando los Datos --
                        for (int i = 1; i <= CantidadWS; i++)
                        {
                            var ws = pck.Workbook.Worksheets[i];
                            DataTable tbl = new DataTable(ws.Name);
                            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                            {
                                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                            }
                            var startRow = hasHeader ? 2 : 1;
                            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                            {
                                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                                DataRow row = tbl.Rows.Add();
                                foreach (var cell in wsRow)
                                {
                                    row[cell.Start.Column - 1] = cell.Text;
                                }
                            }
                            DTsCargaMAsivo.Tables.Add(tbl);
                        }
                    }
                }
                if (DTsCargaMAsivo.Tables.Count > 0)
                {
                    foreach (DataRow ItemCab in DTsCargaMAsivo.Tables["CabeceraPedido"].Rows)
                    {
                        var oPedido = new RequestRegistroPedidoIndividualViewModel();
                        oPedido.IdPedidoTemp = ItemCab["IDPEDIDO"].ToString(); // temporal Excel
                        oPedido.CodigoTipoPedido = ItemCab["CODIGOTIPOPEDIDO"].ToString();
                        oPedido.NroPedido = ItemCab["NROPEDIDO"].ToString();
                        oPedido.FechaSolicitud = Convert.ToDateTime(ItemCab["FECHASOLICITUD"]);
                        oPedido.HoraSolicitud = ItemCab["HORASOLICITUD"].ToString();
                        oPedido.CodigoCuenta = ItemCab["CODIGOCUENTA"].ToString();
                        oPedido.CodigoNegocio = ItemCab["CODIGONEGOCIO"].ToString();
                        oPedido.FechaEstimadaEntrega = Convert.ToDateTime(ItemCab["FECHAESTIMADAENTREGA"]);
                        oPedido.NroReferencia = ItemCab["NROREFERENCIA"].ToString();
                        oPedido.CodigoPuntoOrigen = ItemCab["CODIGOPUNTOORIGEN"].ToString();
                        oPedido.CodigoPuntoDestino = ItemCab["CODIGOPUNTODESTINO"].ToString();
                        oPedido.ImporteTotalDocumento = Convert.ToDouble(ItemCab["IMPTOTALDOCUMENTO"]);
                        oPedido.CondicionPago = ItemCab["CODIGOCONDICIONPAGO"].ToString();
                        oPedido.MonedaPago = ItemCab["CODIGOMONEDAPAGO"].ToString();
                        oPedido.AreaSolicitante = ItemCab["CODIGOAREASOLICITANTE"].ToString();
                        oPedido.NroFactura = ItemCab["NUMEROFACTURA"].ToString();
                        oPedido.ClaveSeguimiento = ItemCab["CLAVESEGUIMIENTO"].ToString();
                        oPedido.Observaciones = ItemCab["OBSERVACIONESCOMENTARIOS"].ToString();
                        oPedido.FechaRegistro = DateTime.Today;
                        oPedido.UsuarioRegistro = usuario;
                        oPedido.EstadoPedido = ConfigurationManager.AppSettings["EstadoPedidoMasivo"].ToString();
                        oPedido.EstadoRegistro = 1;
                        oPedido.DireccionOrigen = ItemCab["DIRECCIONORIGEN"].ToString();
                        oPedido.DireccionDestino = ItemCab["DIRECCIONDESTINO"].ToString();

                        var dtDetallePedido = DTsCargaMAsivo.Tables["DetallePedido"];
                        DataRow[] rowDetallePedido = dtDetallePedido.Select("IDPEDIDO =" + oPedido.IdPedidoTemp);
                        foreach (DataRow ItemDet in rowDetallePedido)
                        {
                            oPedido.ListaDetallePedido.Add(new DetallePedidoViewModel
                            {
                                Item = ItemDet["POSICION"].ToString(),
                                CodigoMaterial = ItemDet["CODIGOMATERIAL"].ToString(),
                                Cantidad = Convert.ToDouble(ItemDet["CANTIDAD"]),
                                UnidadMedida = ItemDet["CODIGOUNIDAD"].ToString(),
                                Observaciones = ItemDet["OBSERVACION"].ToString(),
                                EstadoRegistro = 1,
                                FechaRegistro = DateTime.Today,
                                UsuarioRegistro = usuario,
                            });
                        }
                        ListaPedidoIndividualMasivo.Add(oPedido);
                        // Paginacion Memory
                        //ListaResponse = ListaPedidoIndividualMasivo.Skip(Convert.ToInt32(PaginacionDTO.page) * 10).Take(10).ToList();
                    }
                }
            }
            catch (Exception)
            {
                ListaPedidoIndividualMasivo = null;
            }
            return ListaPedidoIndividualMasivo;
        }


        #endregion


        public ResponseRegistarPedidoViewModel CambiarEstadoPedidoIndivial(CambiarEstadoPedidoViewModel request)
        {
            var responseRegistroPedido = new ResponseRegistarPedidoViewModel();
            try
            {
                var requestAgente = GR.Scriptor.Framework.Helper.MiMapper<CambiarEstadoPedidoViewModel, CambiarEstadoPedidoDTO>(request);
                var responseRegistroPedidoDto = new PedidoProxyRest().CambiarEstadoPedidoIndividual(requestAgente);
                responseRegistroPedido.Result.Satisfactorio = responseRegistroPedidoDto.Result.Satisfactorio;
                responseRegistroPedido.Result.idPedido = responseRegistroPedidoDto.Result.idPedido;
                responseRegistroPedido.Result.Mensaje = responseRegistroPedidoDto.Result.Mensaje;
            }
            catch (Exception ex)
            {
                responseRegistroPedido.Result = new RANSA.MCIP.DTO.Result { Satisfactorio = false };
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AgenteServicios);
            }
            return responseRegistroPedido;
        }
    }
}
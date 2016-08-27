using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.Maestros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Transactions;
using System.Web;

namespace ServicioOracleWCF
{
    public class Service1 : IService1
    {
        public ResponseRegistarPedidoDTO RegistrarPedidoIndividual(RequestRegistroPedidoIndividualDTO request)
        {
            ServicioOracleBL servicioBL = new ServicioOracleBL();
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                //using (TransactionScope Transaccion = new TransactionScope())
                //{
                response = servicioBL.RegistraCabeceraPedido(request);
                request.ListaDetallePedido.ForEach(x =>
                {
                    x.IdPedido = response.Result.idPedido;
                    x.UsuarioRegistro = request.UsuarioModificacion;
                    servicioBL.RegistrarDetallePedido(x);
                });

                request.ListaPedidoAnexos.ForEach(x =>
                {
                    x.IdPedido = response.Result.idPedido;
                    x.UsuarioRegistro = request.UsuarioRegistro;
                    var responseAdjunto = servicioBL.RegistrarDetalleAnexoPedido(x);
                    request.ListaPedidoAnexosAdjuntos.ForEach(c =>
                    {
                        if (c.IdPedidoAnexo == x.IdPedidoAnexo)
                        {
                            c.IdPedidoAnexo = responseAdjunto.Result.idPedidoAnexo;
                            servicioBL.RegistrarDetalleAnexoAdjuntoPedido(c);
                        }
                    });
                });
                //Transaccion.Complete();
                //}
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

        public ResponseRegistarPedidoDTO ActualizarPedidoIndividual(RequestRegistroPedidoIndividualDTO request)
        {
            ServicioOracleBL servicioBL = new ServicioOracleBL();
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                //using (TransactionScope Transaccion = new TransactionScope())
                //{
                response = servicioBL.ActualizarCabeceraPedido(request);

                request.ListaDetallePedido.ForEach(x =>
                {
                    string idTemporal = string.IsNullOrEmpty(x.IdDetallePedido) ? "" : x.IdDetallePedido;
                    if (idTemporal.Length < 4)
                    {
                        x.IdPedido = request.IdPedido;
                        x.UsuarioRegistro = request.UsuarioRegistro;
                        servicioBL.RegistrarDetallePedido(x);
                    }
                    else
                    {
                        x.UsuarioModificacion = request.UsuarioModificacion;
                        servicioBL.ActualizarDetallePedido(x);
                    }
                });

                request.ListaPedidoAnexos.ForEach(x =>
                {
                    string idTemporal = x.IdPedidoAnexo;
                    if (idTemporal.Length < 4)
                    {
                        x.IdPedido = request.IdPedido;
                        x.UsuarioRegistro = request.UsuarioRegistro;
                        var responseAdjunto = servicioBL.RegistrarDetalleAnexoPedido(x);
                        request.ListaPedidoAnexosAdjuntos.ForEach(y =>
                            {
                                if (y.IdPedidoAnexo == idTemporal)
                                {
                                    y.IdPedidoAnexo = responseAdjunto.Result.idPedidoAnexo;
                                }
                            });
                    }
                    else
                    {
                        x.UsuarioModificacion = request.UsuarioModificacion;
                        servicioBL.ActualizarDetalleAnexoPedido(x);
                    }
                });

                request.ListaPedidoAnexosAdjuntos.ForEach(c =>
                {
                    string idTemporal = string.IsNullOrEmpty(c.IdPedidoAnexoAdjunto) ? "" : (c.IdPedidoAnexoAdjunto);
                    if (idTemporal.Length < 4)
                    {
                        servicioBL.RegistrarDetalleAnexoAdjuntoPedido(c);
                    }
                    else
                    {
                        servicioBL.ActualizarDetalleAnexoAdjuntoPedido(c);
                    }
                });
                //Transaccion.Complete();
                //}
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

        public ResponseListarPedidoDTO ListarPedidoIndividual(RequestListarPedidoIndividualDTO request)
        {
            ResponseListarPedidoDTO response = new ResponseListarPedidoDTO();
            bool result = false;
            var conexion = new OracleConnection();
            var cnx = new ConexionBD();
            conexion = cnx.conectar();
            var command = new OracleCommand();
            command.Connection = conexion;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidos_listar";

            command.Parameters.Add("v_result", OracleType.Cursor).Direction = ParameterDirection.Output;
            command.Parameters.AddWithValue("v_codigotipopedido", string.IsNullOrEmpty(request.CodigoTipoPedido) ? (object)DBNull.Value : request.CodigoTipoPedido);
            command.Parameters.AddWithValue("v_nropedido", string.IsNullOrEmpty(request.NroPedido) ? (object)DBNull.Value : request.NroPedido);
            command.Parameters.AddWithValue("v_codigonegocio", string.IsNullOrEmpty(request.CodigoNegocio) ? (object)DBNull.Value : request.CodigoNegocio);
            command.Parameters.AddWithValue("v_estadopedido", string.IsNullOrEmpty(request.EstadoPedido) ? (object)DBNull.Value : request.EstadoPedido);
            command.Parameters.AddWithValue("v_fechainiciosolicitud", request.FechaInicioSolicitud == null ? (object)DBNull.Value : request.FechaInicioSolicitud);
            command.Parameters.AddWithValue("v_fechafinsolicitud", request.FechaFinSolicitud == null ? (object)DBNull.Value : request.FechaFinSolicitud);
            conexion.Open();
            try
            {
                using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        var pedido = new PedidoDTO();

                        pedido.CodigoTipoPedido = reader.IsDBNull(reader.GetOrdinal("codigotipopedido")) ? "" : reader.GetString(reader.GetOrdinal("codigotipopedido")).Trim();
                        pedido.NroPedido = reader.IsDBNull(reader.GetOrdinal("nropedido")) ? "" : reader.GetString(reader.GetOrdinal("nropedido")).Trim();
                        pedido.FechaSolicitud = reader.IsDBNull(reader.GetOrdinal("fechasolicitud")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fechasolicitud"));
                        pedido.HoraSolicitud = reader.IsDBNull(reader.GetOrdinal("horasolicitud")) ? "" : reader.GetString(reader.GetOrdinal("horasolicitud")).Trim();
                        pedido.CodigoCuenta = reader.IsDBNull(reader.GetOrdinal("codigocuenta")) ? "" : reader.GetString(reader.GetOrdinal("codigocuenta")).Trim();
                        pedido.CodigoNegocio = reader.IsDBNull(reader.GetOrdinal("codigonegocio")) ? "" : reader.GetString(reader.GetOrdinal("codigonegocio")).Trim();
                        pedido.FechaEstimadaEntrega = reader.IsDBNull(reader.GetOrdinal("fechaestimadaentrega")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fechaestimadaentrega"));
                        pedido.NroReferencia = reader.IsDBNull(reader.GetOrdinal("nroreferencia")) ? "" : reader.GetString(reader.GetOrdinal("nroreferencia")).Trim();
                        pedido.CodigoPuntoOrigen = reader.IsDBNull(reader.GetOrdinal("codigopuntoorigen")) ? "" : reader.GetString(reader.GetOrdinal("codigopuntoorigen")).Trim();
                        pedido.CodigoPuntoDestino = reader.IsDBNull(reader.GetOrdinal("codigopuntodestino")) ? "" : reader.GetString(reader.GetOrdinal("codigopuntodestino")).Trim();
                        pedido.ImpTotalDocumento = reader.IsDBNull(reader.GetOrdinal("imptotaldocumento")) ? 0 : reader.GetDouble(reader.GetOrdinal("imptotaldocumento"));
                        pedido.CodigoCondicionPago = reader.IsDBNull(reader.GetOrdinal("codigocondicionpago")) ? "" : reader.GetString(reader.GetOrdinal("codigocondicionpago")).Trim();
                        pedido.CodigoMonedaPago = reader.IsDBNull(reader.GetOrdinal("codigomonedapago")) ? "" : reader.GetString(reader.GetOrdinal("codigomonedapago")).Trim();
                        pedido.CodigoAreaSolicitante = reader.IsDBNull(reader.GetOrdinal("codigoareasolicitante")) ? "" : reader.GetString(reader.GetOrdinal("codigoareasolicitante")).Trim();
                        pedido.NumeroFactura = reader.IsDBNull(reader.GetOrdinal("numerofactura")) ? "" : reader.GetString(reader.GetOrdinal("numerofactura")).Trim();
                        pedido.ClaveSeguimiento = reader.IsDBNull(reader.GetOrdinal("claveseguimiento")) ? "" : reader.GetString(reader.GetOrdinal("claveseguimiento")).Trim();
                        pedido.ObservacionesComentarios = reader.IsDBNull(reader.GetOrdinal("observacionescomentarios")) ? "" : reader.GetString(reader.GetOrdinal("observacionescomentarios")).Trim();
                        pedido.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("fecharegistro")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fecharegistro"));
                        pedido.UsuarioRegistro = reader.IsDBNull(reader.GetOrdinal("usuarioregistro")) ? "" : reader.GetString(reader.GetOrdinal("usuarioregistro")).Trim();
                        pedido.FechaModificacion = reader.IsDBNull(reader.GetOrdinal("fechamodificacion")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fechamodificacion"));
                        pedido.UsuarioModificacion = reader.IsDBNull(reader.GetOrdinal("usuariomodificacion")) ? "" : reader.GetString(reader.GetOrdinal("usuariomodificacion")).Trim();
                        pedido.EstadoRegistro = reader.IsDBNull(reader.GetOrdinal("estadoregistro")) ? 0 : reader.GetInt32(reader.GetOrdinal("estadoregistro"));
                        pedido.IdPedido = reader.IsDBNull(reader.GetOrdinal("idpedido")) ? "" : reader.GetString(reader.GetOrdinal("idpedido")).Trim();
                        pedido.EstadoPedido = reader.IsDBNull(reader.GetOrdinal("estadopedido")) ? "" : reader.GetString(reader.GetOrdinal("estadopedido")).Trim();
                        pedido.DireccionOrigen = reader.IsDBNull(reader.GetOrdinal("direccionorigen")) ? "" : reader.GetString(reader.GetOrdinal("direccionorigen")).Trim();
                        pedido.DireccionDestino = reader.IsDBNull(reader.GetOrdinal("direcciondestino")) ? "" : reader.GetString(reader.GetOrdinal("direcciondestino")).Trim();
                        response.ListaPedidos.Add(pedido);

                    }
                }
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
                throw ex;
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

            return response;
        }

        public ResponseDetallePedidoDTO ObtenerDetallePedidoIndividual(RequestDetallePedidoIndividualDTO request)
        {
            ServicioOracleBL servicioBL = new ServicioOracleBL();
            ResponseDetallePedidoDTO response = new ResponseDetallePedidoDTO();
            try
            {

                response = servicioBL.ObetenerCabeceraPedidoIndividual(request);
                var lstDetalle = servicioBL.ListarDetallePedido(request.idPedido);
                var lstDetalleAnexo = servicioBL.ListarDetalleAnexosPedido(request.idPedido);
                var lstDetalleAnexoAdjunto = new List<DetalleAnexoAdjuntoPedidoDTO>();
                lstDetalleAnexo.ForEach(x =>
                {
                    var lstAdjuntos = servicioBL.ListarDetalleAnexosAdjuntosPedido(x.IdPedidoAnexo);
                    lstDetalleAnexoAdjunto.AddRange(lstAdjuntos);
                });
                response.ListaDetallePedidos = lstDetalle;
                response.ListaPedidoAnexos = lstDetalleAnexo;
                response.ListaPedidoAnexosAdjuntos = lstDetalleAnexoAdjunto;



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


        public ResponseRegistarPedidoDTO EliminarPedidoIndividual(List<EliminarPedidoDTO> request)
        {
            ServicioOracleBL servicioBL = new ServicioOracleBL();
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                request.ForEach(x =>
                {
                    response = servicioBL.EliminarCabeceraPedido(x);
                });
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


        public ResponseRegistarPedidoDTO RegistrarPedidoIndividualMasivo(List<RequestRegistroPedidoIndividualDTO> request)
        {
            ServicioOracleBL servicioBL = new ServicioOracleBL();
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                var ListaPedidos = request;
                ListaPedidos.ForEach(delegate(RequestRegistroPedidoIndividualDTO Pedido)
                {
                    response = servicioBL.RegistraCabeceraPedido(Pedido);
                    Pedido.ListaDetallePedido.ForEach(x =>
                    {
                        x.IdPedido = response.Result.idPedido;

                        servicioBL.RegistrarDetallePedido(x);
                    });

                });
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

        public ResponseObtenerCorrelativoMaestro ObtenerCorrelativoPedido()
        {
            ServicioOracleBL servicioBL = new ServicioOracleBL();
            ResponseObtenerCorrelativoMaestro response = new ResponseObtenerCorrelativoMaestro();
            try
            {
                response = servicioBL.obtenerCorrelativoPedido();
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }

        public ResponseRegistarPedidoDTO CambiarEstadoPedidoIndivial(CambiarEstadoPedidoDTO request)
        {
            ServicioOracleBL servicioBL = new ServicioOracleBL();
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            try
            {
                response = servicioBL.CambiarEstadoPedido(request);
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
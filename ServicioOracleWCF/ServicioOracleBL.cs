using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.Maestros;

namespace ServicioOracleWCF
{
    public class ServicioOracleBL
    {
        public ResponseRegistarPedidoDTO RegistraCabeceraPedido(RequestRegistroPedidoIndividualDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            double tmpImporte;

            try
            {
                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidos_registrar", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_codigotipopedido", string.IsNullOrEmpty(request.CodigoTipoPedido) ? (object)DBNull.Value : request.CodigoTipoPedido);
                    cmd.Parameters.AddWithValue("v_nropedido", string.IsNullOrEmpty(request.NroPedido) ? (object)DBNull.Value : request.NroPedido);
                    cmd.Parameters.AddWithValue("v_fechasolicitud", request.FechaSolicitud == null ? (object)DBNull.Value : request.FechaSolicitud);
                    cmd.Parameters.AddWithValue("v_horasolicitud", string.IsNullOrEmpty(request.HoraSolicitud) ? (object)DBNull.Value : request.HoraSolicitud);
                    cmd.Parameters.AddWithValue("v_codigocuenta", string.IsNullOrEmpty(request.CodigoCuenta) ? (object)DBNull.Value : request.CodigoCuenta);
                    cmd.Parameters.AddWithValue("v_codigonegocio", string.IsNullOrEmpty(request.CodigoNegocio) ? (object)DBNull.Value : request.CodigoNegocio);
                    cmd.Parameters.AddWithValue("v_fechaestimadaentrega", request.FechaEstimadaEntrega);
                    cmd.Parameters.AddWithValue("v_nroreferencia", string.IsNullOrEmpty(request.NroReferencia) ? (object)DBNull.Value : request.NroReferencia);
                    cmd.Parameters.AddWithValue("v_codigopuntoorigen", string.IsNullOrEmpty(request.CodigoPuntoOrigen) ? (object)DBNull.Value : request.CodigoPuntoOrigen);
                    cmd.Parameters.AddWithValue("v_codigopuntodestino", string.IsNullOrEmpty(request.CodigoPuntoDestino) ? (object)DBNull.Value : request.CodigoPuntoDestino);
                    cmd.Parameters.AddWithValue("v_imptotaldocumento", double.TryParse(request.ImporteTotalDocumento.ToString(), out tmpImporte) == false ? (object)DBNull.Value : request.ImporteTotalDocumento);
                    cmd.Parameters.AddWithValue("v_codigocondicionpago", string.IsNullOrEmpty(request.CondicionPago) ? (object)DBNull.Value : request.CondicionPago);
                    cmd.Parameters.AddWithValue("v_codigomonedapago", string.IsNullOrEmpty(request.MonedaPago) ? (object)DBNull.Value : request.MonedaPago);
                    cmd.Parameters.AddWithValue("v_codigoareasolicitante", string.IsNullOrEmpty(request.AreaSolicitante) ? (object)DBNull.Value : request.AreaSolicitante);
                    cmd.Parameters.AddWithValue("v_numerofactura", string.IsNullOrEmpty(request.NroFactura) ? (object)DBNull.Value : request.NroFactura);
                    cmd.Parameters.AddWithValue("v_claveseguimiento", string.IsNullOrEmpty(request.ClaveSeguimiento) ? (object)DBNull.Value : request.ClaveSeguimiento);
                    cmd.Parameters.AddWithValue("v_observacionescomentarios", string.IsNullOrEmpty(request.Observaciones) ? (object)DBNull.Value : request.Observaciones);
                    cmd.Parameters.AddWithValue("v_fecharegistro", request.FechaRegistro == null ? (object)DBNull.Value : request.FechaRegistro);
                    cmd.Parameters.AddWithValue("v_usuarioregistro", string.IsNullOrEmpty(request.UsuarioRegistro) ? (object)DBNull.Value : request.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("v_fechamodificacion", request.FechaModificacion == null ? (object)DBNull.Value : request.FechaModificacion);
                    cmd.Parameters.AddWithValue("v_usuariomodificacion", string.IsNullOrEmpty(request.UsuarioModificacion) ? (object)DBNull.Value : request.UsuarioModificacion);
                    cmd.Parameters.AddWithValue("v_estadoregistro", request.EstadoRegistro);
                    cmd.Parameters.AddWithValue("v_estadopedido", string.IsNullOrEmpty(request.EstadoPedido) ? (object)DBNull.Value : request.EstadoPedido);
                    cmd.Parameters.AddWithValue("v_direccionorigen", string.IsNullOrEmpty(request.DireccionOrigen) ? (object)DBNull.Value : request.DireccionOrigen);
                    cmd.Parameters.AddWithValue("v_direcciondestino", string.IsNullOrEmpty(request.DireccionDestino) ? (object)DBNull.Value : request.DireccionDestino);
                    cmd.Parameters.AddWithValue("v_campopersonalizado1", string.IsNullOrEmpty(request.CodigoGenerico1) ? (object)DBNull.Value : request.CodigoGenerico1);
                    cmd.Parameters.AddWithValue("v_campopersonalizado2", string.IsNullOrEmpty(request.CodigoGenerico2) ? (object)DBNull.Value : request.CodigoGenerico2);
                    cmd.Parameters.AddWithValue("v_campopersonalizado3", string.IsNullOrEmpty(request.CodigoGenerico3) ? (object)DBNull.Value : request.CodigoGenerico3);
                    cmd.Parameters.AddWithValue("v_campopersonalizado4", string.IsNullOrEmpty(request.CodigoGenerico4) ? (object)DBNull.Value : request.CodigoGenerico4);
                    cmd.Parameters.AddWithValue("v_campopersonalizado5", string.IsNullOrEmpty(request.CodigoGenerico5) ? (object)DBNull.Value : request.CodigoGenerico5);
                    cmd.Parameters.AddWithValue("v_campopersonalizado6", string.IsNullOrEmpty(request.CodigoGenerico6) ? (object)DBNull.Value : request.CodigoGenerico6);
                    cmd.Parameters.AddWithValue("v_campopersonalizado7", string.IsNullOrEmpty(request.CodigoGenerico7) ? (object)DBNull.Value : request.CodigoGenerico7);
                    cmd.Parameters.AddWithValue("v_campopersonalizado8", string.IsNullOrEmpty(request.CodigoGenerico8) ? (object)DBNull.Value : request.CodigoGenerico8);
                    cmd.Parameters.AddWithValue("v_campopersonalizado9", string.IsNullOrEmpty(request.CodigoGenerico9) ? (object)DBNull.Value : request.CodigoGenerico9);
                    cmd.Parameters.AddWithValue("v_campopersonalizado10", string.IsNullOrEmpty(request.CodigoGenerico10) ? (object)DBNull.Value : request.CodigoGenerico10);
                    cmd.Parameters.AddWithValue("v_campopersonalizado11", string.IsNullOrEmpty(request.CodigoGenerico11) ? (object)DBNull.Value : request.CodigoGenerico11);
                    cmd.Parameters.AddWithValue("v_campopersonalizado12", string.IsNullOrEmpty(request.CodigoGenerico12) ? (object)DBNull.Value : request.CodigoGenerico12);
                    cmd.Parameters.AddWithValue("v_campopersonalizado13", string.IsNullOrEmpty(request.CodigoGenerico13) ? (object)DBNull.Value : request.CodigoGenerico13);
                    cmd.Parameters.AddWithValue("v_campopersonalizado14", string.IsNullOrEmpty(request.CodigoGenerico14) ? (object)DBNull.Value : request.CodigoGenerico14);
                    cmd.Parameters.AddWithValue("v_campopersonalizado15", string.IsNullOrEmpty(request.CodigoGenerico15) ? (object)DBNull.Value : request.CodigoGenerico15);
                    cmd.Parameters.AddWithValue("v_campopersonalizado16", string.IsNullOrEmpty(request.CodigoGenerico16) ? (object)DBNull.Value : request.CodigoGenerico16);
                    cmd.Parameters.AddWithValue("v_campopersonalizado17", string.IsNullOrEmpty(request.CodigoGenerico17) ? (object)DBNull.Value : request.CodigoGenerico17);
                    cmd.Parameters.AddWithValue("v_campopersonalizado18", string.IsNullOrEmpty(request.CodigoGenerico18) ? (object)DBNull.Value : request.CodigoGenerico18);
                    cmd.Parameters.AddWithValue("v_campopersonalizado19", string.IsNullOrEmpty(request.CodigoGenerico19) ? (object)DBNull.Value : request.CodigoGenerico19);
                    cmd.Parameters.AddWithValue("v_campopersonalizado20", string.IsNullOrEmpty(request.CodigoGenerico20) ? (object)DBNull.Value : request.CodigoGenerico20);
                    cmd.Parameters.AddWithValue("v_campopersonalizado21", string.IsNullOrEmpty(request.CodigoGenerico21) ? (object)DBNull.Value : request.CodigoGenerico21);
                    cmd.Parameters.AddWithValue("v_campopersonalizado22", string.IsNullOrEmpty(request.CodigoGenerico22) ? (object)DBNull.Value : request.CodigoGenerico22);
                    cmd.Parameters.AddWithValue("v_campopersonalizado23", string.IsNullOrEmpty(request.CodigoGenerico23) ? (object)DBNull.Value : request.CodigoGenerico23);
                    cmd.Parameters.AddWithValue("v_campopersonalizado24", string.IsNullOrEmpty(request.CodigoGenerico24) ? (object)DBNull.Value : request.CodigoGenerico24);
                    cmd.Parameters.AddWithValue("v_campopersonalizado25", string.IsNullOrEmpty(request.CodigoGenerico25) ? (object)DBNull.Value : request.CodigoGenerico25);
                    cmd.Parameters.AddWithValue("v_campopersonalizado26", string.IsNullOrEmpty(request.CodigoGenerico26) ? (object)DBNull.Value : request.CodigoGenerico26);
                    cmd.Parameters.AddWithValue("v_campopersonalizado27", string.IsNullOrEmpty(request.CodigoGenerico27) ? (object)DBNull.Value : request.CodigoGenerico27);
                    cmd.Parameters.AddWithValue("v_campopersonalizado28", string.IsNullOrEmpty(request.CodigoGenerico28) ? (object)DBNull.Value : request.CodigoGenerico28);
                    cmd.Parameters.AddWithValue("v_campopersonalizado29", string.IsNullOrEmpty(request.CodigoGenerico29) ? (object)DBNull.Value : request.CodigoGenerico29);
                    cmd.Parameters.AddWithValue("v_campopersonalizado30", string.IsNullOrEmpty(request.CodigoGenerico30) ? (object)DBNull.Value : request.CodigoGenerico30);

                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("v_idGenerado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    response.Result.idPedido = cmd.Parameters["v_idGenerado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
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
        public ResponseRegistarPedidoDTO ActualizarCabeceraPedido(RequestRegistroPedidoIndividualDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            double tmpImporte;

            try
            {

                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidos_actualizar", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_codigotipopedido", string.IsNullOrEmpty(request.CodigoTipoPedido) ? (object)DBNull.Value : request.CodigoTipoPedido);
                    cmd.Parameters.AddWithValue("v_nropedido", string.IsNullOrEmpty(request.NroPedido) ? (object)DBNull.Value : request.NroPedido);
                    cmd.Parameters.AddWithValue("v_fechasolicitud", request.FechaSolicitud == null ? (object)DBNull.Value : request.FechaSolicitud);
                    cmd.Parameters.AddWithValue("v_horasolicitud", string.IsNullOrEmpty(request.HoraSolicitud) ? (object)DBNull.Value : request.HoraSolicitud);
                    cmd.Parameters.AddWithValue("v_codigocuenta", string.IsNullOrEmpty(request.CodigoCuenta) ? (object)DBNull.Value : request.CodigoCuenta);
                    cmd.Parameters.AddWithValue("v_codigonegocio", string.IsNullOrEmpty(request.CodigoNegocio) ? (object)DBNull.Value : request.CodigoNegocio);
                    cmd.Parameters.AddWithValue("v_fechaestimadaentrega", request.FechaEstimadaEntrega);
                    cmd.Parameters.AddWithValue("v_nroreferencia", string.IsNullOrEmpty(request.NroReferencia) ? (object)DBNull.Value : request.NroReferencia);
                    cmd.Parameters.AddWithValue("v_codigopuntoorigen", string.IsNullOrEmpty(request.CodigoPuntoOrigen) ? (object)DBNull.Value : request.CodigoPuntoOrigen);
                    cmd.Parameters.AddWithValue("v_codigopuntodestino", string.IsNullOrEmpty(request.CodigoPuntoDestino) ? (object)DBNull.Value : request.CodigoPuntoDestino);
                    cmd.Parameters.AddWithValue("v_imptotaldocumento", double.TryParse(request.ImporteTotalDocumento.ToString(), out tmpImporte) == false ? (object)DBNull.Value : request.ImporteTotalDocumento);
                    cmd.Parameters.AddWithValue("v_codigocondicionpago", string.IsNullOrEmpty(request.CondicionPago) ? (object)DBNull.Value : request.CondicionPago);
                    cmd.Parameters.AddWithValue("v_codigomonedapago", string.IsNullOrEmpty(request.MonedaPago) ? (object)DBNull.Value : request.MonedaPago);
                    cmd.Parameters.AddWithValue("v_codigoareasolicitante", string.IsNullOrEmpty(request.AreaSolicitante) ? (object)DBNull.Value : request.AreaSolicitante);
                    cmd.Parameters.AddWithValue("v_numerofactura", string.IsNullOrEmpty(request.NroFactura) ? (object)DBNull.Value : request.NroFactura);
                    cmd.Parameters.AddWithValue("v_claveseguimiento", string.IsNullOrEmpty(request.ClaveSeguimiento) ? (object)DBNull.Value : request.ClaveSeguimiento);
                    cmd.Parameters.AddWithValue("v_observacionescomentarios", string.IsNullOrEmpty(request.Observaciones) ? (object)DBNull.Value : request.Observaciones);
                    cmd.Parameters.AddWithValue("v_fecharegistro", request.FechaRegistro == null ? (object)DBNull.Value : request.FechaRegistro);
                    cmd.Parameters.AddWithValue("v_usuarioregistro", string.IsNullOrEmpty(request.UsuarioRegistro) ? (object)DBNull.Value : request.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("v_fechamodificacion", request.FechaModificacion == null ? (object)DBNull.Value : request.FechaModificacion);
                    cmd.Parameters.AddWithValue("v_usuariomodificacion", string.IsNullOrEmpty(request.UsuarioModificacion) ? (object)DBNull.Value : request.UsuarioModificacion);
                    cmd.Parameters.AddWithValue("v_estadoregistro", request.EstadoRegistro);
                    cmd.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(request.IdPedido) ? (object)DBNull.Value : request.IdPedido);
                    cmd.Parameters.AddWithValue("v_estadopedido", string.IsNullOrEmpty(request.EstadoPedido) ? (object)DBNull.Value : request.EstadoPedido);
                    cmd.Parameters.AddWithValue("v_direccionorigen", string.IsNullOrEmpty(request.DireccionOrigen) ? (object)DBNull.Value : request.DireccionOrigen);
                    cmd.Parameters.AddWithValue("v_direcciondestino", string.IsNullOrEmpty(request.DireccionDestino) ? (object)DBNull.Value : request.DireccionDestino);
                    cmd.Parameters.AddWithValue("v_campopersonalizado1", string.IsNullOrEmpty(request.CodigoGenerico1) ? (object)DBNull.Value : request.CodigoGenerico1);
                    cmd.Parameters.AddWithValue("v_campopersonalizado2", string.IsNullOrEmpty(request.CodigoGenerico2) ? (object)DBNull.Value : request.CodigoGenerico2);
                    cmd.Parameters.AddWithValue("v_campopersonalizado3", string.IsNullOrEmpty(request.CodigoGenerico3) ? (object)DBNull.Value : request.CodigoGenerico3);
                    cmd.Parameters.AddWithValue("v_campopersonalizado4", string.IsNullOrEmpty(request.CodigoGenerico4) ? (object)DBNull.Value : request.CodigoGenerico4);
                    cmd.Parameters.AddWithValue("v_campopersonalizado5", string.IsNullOrEmpty(request.CodigoGenerico5) ? (object)DBNull.Value : request.CodigoGenerico5);
                    cmd.Parameters.AddWithValue("v_campopersonalizado6", string.IsNullOrEmpty(request.CodigoGenerico6) ? (object)DBNull.Value : request.CodigoGenerico6);
                    cmd.Parameters.AddWithValue("v_campopersonalizado7", string.IsNullOrEmpty(request.CodigoGenerico7) ? (object)DBNull.Value : request.CodigoGenerico7);
                    cmd.Parameters.AddWithValue("v_campopersonalizado8", string.IsNullOrEmpty(request.CodigoGenerico8) ? (object)DBNull.Value : request.CodigoGenerico8);
                    cmd.Parameters.AddWithValue("v_campopersonalizado9", string.IsNullOrEmpty(request.CodigoGenerico9) ? (object)DBNull.Value : request.CodigoGenerico9);
                    cmd.Parameters.AddWithValue("v_campopersonalizado10", string.IsNullOrEmpty(request.CodigoGenerico10) ? (object)DBNull.Value : request.CodigoGenerico10);
                    cmd.Parameters.AddWithValue("v_campopersonalizado11", string.IsNullOrEmpty(request.CodigoGenerico11) ? (object)DBNull.Value : request.CodigoGenerico11);
                    cmd.Parameters.AddWithValue("v_campopersonalizado12", string.IsNullOrEmpty(request.CodigoGenerico12) ? (object)DBNull.Value : request.CodigoGenerico12);
                    cmd.Parameters.AddWithValue("v_campopersonalizado13", string.IsNullOrEmpty(request.CodigoGenerico13) ? (object)DBNull.Value : request.CodigoGenerico13);
                    cmd.Parameters.AddWithValue("v_campopersonalizado14", string.IsNullOrEmpty(request.CodigoGenerico14) ? (object)DBNull.Value : request.CodigoGenerico14);
                    cmd.Parameters.AddWithValue("v_campopersonalizado15", string.IsNullOrEmpty(request.CodigoGenerico15) ? (object)DBNull.Value : request.CodigoGenerico15);
                    cmd.Parameters.AddWithValue("v_campopersonalizado16", string.IsNullOrEmpty(request.CodigoGenerico16) ? (object)DBNull.Value : request.CodigoGenerico16);
                    cmd.Parameters.AddWithValue("v_campopersonalizado17", string.IsNullOrEmpty(request.CodigoGenerico17) ? (object)DBNull.Value : request.CodigoGenerico17);
                    cmd.Parameters.AddWithValue("v_campopersonalizado18", string.IsNullOrEmpty(request.CodigoGenerico18) ? (object)DBNull.Value : request.CodigoGenerico18);
                    cmd.Parameters.AddWithValue("v_campopersonalizado19", string.IsNullOrEmpty(request.CodigoGenerico19) ? (object)DBNull.Value : request.CodigoGenerico19);
                    cmd.Parameters.AddWithValue("v_campopersonalizado20", string.IsNullOrEmpty(request.CodigoGenerico20) ? (object)DBNull.Value : request.CodigoGenerico20);
                    cmd.Parameters.AddWithValue("v_campopersonalizado21", string.IsNullOrEmpty(request.CodigoGenerico21) ? (object)DBNull.Value : request.CodigoGenerico21);
                    cmd.Parameters.AddWithValue("v_campopersonalizado22", string.IsNullOrEmpty(request.CodigoGenerico22) ? (object)DBNull.Value : request.CodigoGenerico22);
                    cmd.Parameters.AddWithValue("v_campopersonalizado23", string.IsNullOrEmpty(request.CodigoGenerico23) ? (object)DBNull.Value : request.CodigoGenerico23);
                    cmd.Parameters.AddWithValue("v_campopersonalizado24", string.IsNullOrEmpty(request.CodigoGenerico24) ? (object)DBNull.Value : request.CodigoGenerico24);
                    cmd.Parameters.AddWithValue("v_campopersonalizado25", string.IsNullOrEmpty(request.CodigoGenerico25) ? (object)DBNull.Value : request.CodigoGenerico25);
                    cmd.Parameters.AddWithValue("v_campopersonalizado26", string.IsNullOrEmpty(request.CodigoGenerico26) ? (object)DBNull.Value : request.CodigoGenerico26);
                    cmd.Parameters.AddWithValue("v_campopersonalizado27", string.IsNullOrEmpty(request.CodigoGenerico27) ? (object)DBNull.Value : request.CodigoGenerico27);
                    cmd.Parameters.AddWithValue("v_campopersonalizado28", string.IsNullOrEmpty(request.CodigoGenerico28) ? (object)DBNull.Value : request.CodigoGenerico28);
                    cmd.Parameters.AddWithValue("v_campopersonalizado29", string.IsNullOrEmpty(request.CodigoGenerico29) ? (object)DBNull.Value : request.CodigoGenerico29);
                    cmd.Parameters.AddWithValue("v_campopersonalizado30", string.IsNullOrEmpty(request.CodigoGenerico30) ? (object)DBNull.Value : request.CodigoGenerico30);

                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("v_idGenerado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    //response.Result.idPedido = cmd.Parameters["v_idGenerado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();


            }
            catch (Exception ex)
            {
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

        public ResponseRegistarPedidoDTO RegistrarDetallePedido(DetallePedidoDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            double tmpCantidad;
            Guid idPedidoTemp;
            try
            {
                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidodetalle_registrar", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_posicion", string.IsNullOrEmpty(request.Item) ? (object)DBNull.Value : request.Item);
                    cmd.Parameters.AddWithValue("v_codigomaterial", string.IsNullOrEmpty(request.CodigoMaterial) ? (object)DBNull.Value : request.CodigoMaterial);
                    cmd.Parameters.AddWithValue("v_cantidad", double.TryParse(request.Cantidad.ToString(), out tmpCantidad) == false ? (object)DBNull.Value : request.Cantidad);
                    cmd.Parameters.AddWithValue("v_codigounidad", string.IsNullOrEmpty(request.UnidadMedida) ? (object)DBNull.Value : request.UnidadMedida);
                    cmd.Parameters.AddWithValue("v_observacion", string.IsNullOrEmpty(request.Observaciones) ? (object)DBNull.Value : request.Observaciones);
                    cmd.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(request.IdPedido) ? (object)DBNull.Value : request.IdPedido);
                    cmd.Parameters.AddWithValue("v_fecharegistro", DateTime.Now);
                    cmd.Parameters.AddWithValue("v_usuarioregistro", string.IsNullOrEmpty(request.UsuarioRegistro) ? (object)DBNull.Value : request.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("v_fechamodificacion", request.FechaModificacion == null ? (object)DBNull.Value : request.FechaModificacion);
                    cmd.Parameters.AddWithValue("v_usuariomodificacion", string.IsNullOrEmpty(request.UsuarioModificacion) ? (object)DBNull.Value : request.UsuarioModificacion);

                    cmd.Parameters.AddWithValue("v_estadoregistro", request.EstadoRegistro);

                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();


            }
            catch (Exception ex)
            {
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

        public ResponseRegistarPedidoDTO ActualizarDetallePedido(DetallePedidoDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            double tmpCantidad;
            Guid idPedidoTemp;
            try
            {

                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidodetalle_actualiza", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_iddetallepedido", string.IsNullOrEmpty(request.IdDetallePedido) ? (object)DBNull.Value : request.IdDetallePedido);
                    cmd.Parameters.AddWithValue("v_posicion", string.IsNullOrEmpty(request.Item) ? (object)DBNull.Value : request.Item);
                    cmd.Parameters.AddWithValue("v_codigomaterial", string.IsNullOrEmpty(request.CodigoMaterial) ? (object)DBNull.Value : request.CodigoMaterial);
                    cmd.Parameters.AddWithValue("v_cantidad", double.TryParse(request.Cantidad.ToString(), out tmpCantidad) == false ? (object)DBNull.Value : request.Cantidad);
                    cmd.Parameters.AddWithValue("v_codigounidad", string.IsNullOrEmpty(request.UnidadMedida) ? (object)DBNull.Value : request.UnidadMedida);
                    cmd.Parameters.AddWithValue("v_observacion", string.IsNullOrEmpty(request.Observaciones) ? (object)DBNull.Value : request.Observaciones);
                    cmd.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(request.IdPedido) ? (object)DBNull.Value : request.IdPedido);
                    cmd.Parameters.AddWithValue("v_fecharegistro", request.FechaRegistro == null ? (object)DBNull.Value : request.FechaRegistro);
                    cmd.Parameters.AddWithValue("v_usuarioregistro", string.IsNullOrEmpty(request.UsuarioRegistro) ? (object)DBNull.Value : request.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("v_fechamodificacion", request.FechaModificacion == null ? (object)DBNull.Value : request.FechaModificacion);
                    cmd.Parameters.AddWithValue("v_usuariomodificacion", string.IsNullOrEmpty(request.UsuarioModificacion) ? (object)DBNull.Value : request.UsuarioModificacion);
                    cmd.Parameters.AddWithValue("v_estadoregistro", request.EstadoRegistro);

                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();


            }
            catch (Exception ex)
            {
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

        public ResponseDetallePedidoDTO ObetenerCabeceraPedidoIndividual(RequestDetallePedidoIndividualDTO request)
        {
            ResponseDetallePedidoDTO response = new ResponseDetallePedidoDTO();
            bool result = false;
            var conexion = new OracleConnection();
            var cnx = new ConexionBD();
            conexion = cnx.conectar();
            var command = new OracleCommand();
            command.Connection = conexion;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidos_listar_uno";

            command.Parameters.Add("v_result", OracleType.Cursor).Direction = ParameterDirection.Output;
            command.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(request.idPedido.ToUpper()) ? (object)DBNull.Value : request.idPedido.ToUpper());

            conexion.Open();
            try
            {
                using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {

                        response.CodigoTipoPedido = reader.IsDBNull(reader.GetOrdinal("codigotipopedido")) ? "" : reader.GetString(reader.GetOrdinal("codigotipopedido")).Trim();
                        response.NroPedido = reader.IsDBNull(reader.GetOrdinal("nropedido")) ? "" : reader.GetString(reader.GetOrdinal("nropedido")).Trim();
                        response.FechaSolicitud = reader.IsDBNull(reader.GetOrdinal("fechasolicitud")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fechasolicitud"));
                        response.HoraSolicitud = reader.IsDBNull(reader.GetOrdinal("horasolicitud")) ? "" : reader.GetString(reader.GetOrdinal("horasolicitud")).Trim();
                        response.CodigoCuenta = reader.IsDBNull(reader.GetOrdinal("codigocuenta")) ? "" : reader.GetString(reader.GetOrdinal("codigocuenta")).Trim();
                        response.CodigoNegocio = reader.IsDBNull(reader.GetOrdinal("codigonegocio")) ? "" : reader.GetString(reader.GetOrdinal("codigonegocio")).Trim();
                        response.FechaEstimadaEntrega = reader.IsDBNull(reader.GetOrdinal("fechaestimadaentrega")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fechaestimadaentrega"));
                        response.NroReferencia = reader.IsDBNull(reader.GetOrdinal("nroreferencia")) ? "" : reader.GetString(reader.GetOrdinal("nroreferencia")).Trim();
                        response.CodigoPuntoOrigen = reader.IsDBNull(reader.GetOrdinal("codigopuntoorigen")) ? "" : reader.GetString(reader.GetOrdinal("codigopuntoorigen")).Trim();
                        response.CodigoPuntoDestino = reader.IsDBNull(reader.GetOrdinal("codigopuntodestino")) ? "" : reader.GetString(reader.GetOrdinal("codigopuntodestino")).Trim();
                        response.ImpTotalDocumento = reader.IsDBNull(reader.GetOrdinal("imptotaldocumento")) ? 0 : reader.GetDouble(reader.GetOrdinal("imptotaldocumento"));
                        response.CodigoCondicionPago = reader.IsDBNull(reader.GetOrdinal("codigocondicionpago")) ? "" : reader.GetString(reader.GetOrdinal("codigocondicionpago")).Trim();
                        response.CodigoMonedaPago = reader.IsDBNull(reader.GetOrdinal("codigomonedapago")) ? "" : reader.GetString(reader.GetOrdinal("codigomonedapago")).Trim();
                        response.CodigoAreaSolicitante = reader.IsDBNull(reader.GetOrdinal("codigoareasolicitante")) ? "" : reader.GetString(reader.GetOrdinal("codigoareasolicitante")).Trim();
                        response.NumeroFactura = reader.IsDBNull(reader.GetOrdinal("numerofactura")) ? "" : reader.GetString(reader.GetOrdinal("numerofactura")).Trim();
                        response.ClaveSeguimiento = reader.IsDBNull(reader.GetOrdinal("claveseguimiento")) ? "" : reader.GetString(reader.GetOrdinal("claveseguimiento")).Trim();
                        response.ObservacionesComentarios = reader.IsDBNull(reader.GetOrdinal("observacionescomentarios")) ? "" : reader.GetString(reader.GetOrdinal("observacionescomentarios")).Trim();
                        response.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("fecharegistro")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fecharegistro"));
                        response.UsuarioRegistro = reader.IsDBNull(reader.GetOrdinal("usuarioregistro")) ? "" : reader.GetString(reader.GetOrdinal("usuarioregistro")).Trim();
                        response.FechaModificacion = reader.IsDBNull(reader.GetOrdinal("fechamodificacion")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fechamodificacion"));
                        response.UsuarioModificacion = reader.IsDBNull(reader.GetOrdinal("usuariomodificacion")) ? "" : reader.GetString(reader.GetOrdinal("usuariomodificacion")).Trim();
                        response.EstadoRegistro = reader.IsDBNull(reader.GetOrdinal("estadoregistro")) ? 0 : reader.GetInt32(reader.GetOrdinal("estadoregistro"));
                        response.IdPedido = reader.IsDBNull(reader.GetOrdinal("idpedido")) ? "" : reader.GetString(reader.GetOrdinal("idpedido")).Trim();
                        response.EstadoPedido = reader.IsDBNull(reader.GetOrdinal("estadopedido")) ? "" : reader.GetString(reader.GetOrdinal("estadopedido")).Trim();
                        response.DireccionOrigen = reader.IsDBNull(reader.GetOrdinal("direccionorigen")) ? "" : reader.GetString(reader.GetOrdinal("direccionorigen")).Trim();
                        response.DireccionDestino = reader.IsDBNull(reader.GetOrdinal("direcciondestino")) ? "" : reader.GetString(reader.GetOrdinal("direcciondestino")).Trim();


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

        public List<DetallePedidoDTO> ListarDetallePedido(string idPedido)
        {
            List<DetallePedidoDTO> response = new List<DetallePedidoDTO>();
            bool result = false;
            var conexion = new OracleConnection();
            var cnx = new ConexionBD();
            conexion = cnx.conectar();
            var command = new OracleCommand();
            command.Connection = conexion;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidodetalle_listar";

            command.Parameters.Add("v_result", OracleType.Cursor).Direction = ParameterDirection.Output;
            command.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(idPedido.ToUpper()) ? (object)DBNull.Value : idPedido.ToUpper());

            conexion.Open();
            try
            {
                using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        DetallePedidoDTO item = new DetallePedidoDTO();
                        item.IdDetallePedido = reader.IsDBNull(reader.GetOrdinal("iddetallepedido")) ? "" : reader.GetString(reader.GetOrdinal("iddetallepedido")).Trim();
                        item.Item = reader.IsDBNull(reader.GetOrdinal("posicion")) ? "" : reader.GetString(reader.GetOrdinal("posicion")).Trim();
                        item.CodigoMaterial = reader.IsDBNull(reader.GetOrdinal("codigomaterial")) ? "" : reader.GetString(reader.GetOrdinal("codigomaterial")).Trim();
                        item.Cantidad = reader.IsDBNull(reader.GetOrdinal("cantidad")) ? 0 : reader.GetDouble(reader.GetOrdinal("cantidad"));
                        item.UnidadMedida = reader.IsDBNull(reader.GetOrdinal("codigounidad")) ? "" : reader.GetString(reader.GetOrdinal("codigounidad")).Trim();
                        item.Observaciones = reader.IsDBNull(reader.GetOrdinal("observacion")) ? "" : reader.GetString(reader.GetOrdinal("observacion")).Trim();
                        item.IdPedido = reader.IsDBNull(reader.GetOrdinal("idpedido")) ? "" : reader.GetString(reader.GetOrdinal("idpedido")).Trim();
                        item.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("fecharegistro")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fecharegistro"));
                        item.UsuarioRegistro = reader.IsDBNull(reader.GetOrdinal("usuarioregistro")) ? "" : reader.GetString(reader.GetOrdinal("usuarioregistro")).Trim();
                        item.FechaModificacion = reader.IsDBNull(reader.GetOrdinal("fechamodificacion")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fechamodificacion"));
                        item.UsuarioModificacion = reader.IsDBNull(reader.GetOrdinal("usuariomodificacion")) ? "" : reader.GetString(reader.GetOrdinal("usuariomodificacion")).Trim();
                        item.EstadoRegistro = reader.IsDBNull(reader.GetOrdinal("estadoregistro")) ? 0 : reader.GetInt32(reader.GetOrdinal("estadoregistro"));

                        response.Add(item);

                    }
                }

            }

            catch (Exception ex)
            {
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

        public ResponseRegistarPedidoDTO RegistrarDetalleAnexoPedido(DetalleAnexoPedidoDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            double tmpCantidad;
            Guid idPedidoTemp;
            try
            {

                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidoanexos_registrar", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_descripcion", string.IsNullOrEmpty(request.Descripcion) ? (object)DBNull.Value : request.Descripcion);
                    cmd.Parameters.AddWithValue("v_nombre", string.IsNullOrEmpty(request.FileName) ? (object)DBNull.Value : request.FileName);
                    cmd.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(request.IdPedido) ? (object)DBNull.Value : request.IdPedido);
                    cmd.Parameters.AddWithValue("v_fecharegistro", request.FechaRegistro == null ? (object)DBNull.Value : request.FechaRegistro);
                    cmd.Parameters.AddWithValue("v_usuarioregistro", string.IsNullOrEmpty(request.UsuarioRegistro) ? (object)DBNull.Value : request.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("v_fechamodificacion", request.FechaModificacion == null ? (object)DBNull.Value : request.FechaModificacion);
                    cmd.Parameters.AddWithValue("v_usuariomodificacion", string.IsNullOrEmpty(request.UsuarioModificacion) ? (object)DBNull.Value : request.UsuarioModificacion);
                    cmd.Parameters.AddWithValue("v_estadoregistro", request.EstadoRegistro);

                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("v_idGenerado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    response.Result.idPedidoAnexo = cmd.Parameters["v_idGenerado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
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

        public ResponseRegistarPedidoDTO RegistrarDetalleAnexoAdjuntoPedido(DetalleAnexoAdjuntoPedidoDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            double tmpCantidad;
            Guid idPedidoTemp;
            try
            {

                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_pedidoanexoadjunto_registra", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_idpedidoanexo", string.IsNullOrEmpty(request.IdPedidoAnexo) ? (object)DBNull.Value : request.IdPedidoAnexo);
                    cmd.Parameters.AddWithValue("v_archivorealnombre", string.IsNullOrEmpty(request.ArchivoRealNombre) ? (object)DBNull.Value : request.ArchivoRealNombre);
                    cmd.Parameters.AddWithValue("v_archivovisualnombre", string.IsNullOrEmpty(request.ArchivoVisualNombre) ? (object)DBNull.Value : request.ArchivoVisualNombre);
                    cmd.Parameters.AddWithValue("v_archivoextension", string.IsNullOrEmpty(request.ArchivoExtension) ? (object)DBNull.Value : request.ArchivoExtension);
                    cmd.Parameters.AddWithValue("v_archivorutadescarga", string.IsNullOrEmpty(request.ArchivoRutaDescarga) ? (object)DBNull.Value : request.ArchivoRutaDescarga);
                    cmd.Parameters.AddWithValue("v_estadoregistro", request.EstadoRegistro);

                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();


            }
            catch (Exception ex)
            {
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

        public ResponseRegistarPedidoDTO ActualizarDetalleAnexoPedido(DetalleAnexoPedidoDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            double tmpCantidad;
            Guid idPedidoTemp;
            try
            {

                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidoanexos_actualizar", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_idpedidoanexo", string.IsNullOrEmpty(request.IdPedidoAnexo) ? (object)DBNull.Value : request.IdPedidoAnexo);
                    cmd.Parameters.AddWithValue("v_descripcion", string.IsNullOrEmpty(request.Descripcion) ? (object)DBNull.Value : request.Descripcion);
                    cmd.Parameters.AddWithValue("v_nombre", string.IsNullOrEmpty(request.FileName) ? (object)DBNull.Value : request.FileName);
                    cmd.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(request.IdPedido) ? (object)DBNull.Value : request.IdPedido);
                    cmd.Parameters.AddWithValue("v_fechamodificacion", DateTime.Today);
                    cmd.Parameters.AddWithValue("v_usuariomodificacion", string.IsNullOrEmpty(request.UsuarioModificacion) ? (object)DBNull.Value : request.UsuarioModificacion);
                    cmd.Parameters.AddWithValue("v_estadoregistro", request.EstadoRegistro);

                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();


            }
            catch (Exception ex)
            {
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

        public ResponseRegistarPedidoDTO ActualizarDetalleAnexoAdjuntoPedido(DetalleAnexoAdjuntoPedidoDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            double tmpCantidad;
            Guid idPedidoTemp;
            try
            {

                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_pedianexoadjunto_actualizar", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_idpedidoanexo", string.IsNullOrEmpty(request.IdPedidoAnexo) ? (object)DBNull.Value : request.IdPedidoAnexo);
                    cmd.Parameters.AddWithValue("v_idpedidoanexoadjuntos", string.IsNullOrEmpty(request.IdPedidoAnexoAdjunto) ? (object)DBNull.Value : request.IdPedidoAnexoAdjunto);
                    cmd.Parameters.AddWithValue("v_archivorealnombre", string.IsNullOrEmpty(request.ArchivoRealNombre) ? (object)DBNull.Value : request.ArchivoRealNombre);
                    cmd.Parameters.AddWithValue("v_archivovisualnombre", string.IsNullOrEmpty(request.ArchivoVisualNombre) ? (object)DBNull.Value : request.ArchivoVisualNombre);
                    cmd.Parameters.AddWithValue("v_archivoextension", string.IsNullOrEmpty(request.ArchivoExtension) ? (object)DBNull.Value : request.ArchivoExtension);
                    cmd.Parameters.AddWithValue("v_archivorutadescarga", string.IsNullOrEmpty(request.ArchivoRutaDescarga) ? (object)DBNull.Value : request.ArchivoRutaDescarga);
                    cmd.Parameters.AddWithValue("v_estadoregistro", request.EstadoRegistro);

                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();


            }
            catch (Exception ex)
            {
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

        public List<DetalleAnexoPedidoDTO> ListarDetalleAnexosPedido(string idPedido)
        {
            List<DetalleAnexoPedidoDTO> response = new List<DetalleAnexoPedidoDTO>();
            bool result = false;
            var conexion = new OracleConnection();
            var cnx = new ConexionBD();
            conexion = cnx.conectar();
            var command = new OracleCommand();
            command.Connection = conexion;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidoanexos_listar";

            command.Parameters.Add("v_result", OracleType.Cursor).Direction = ParameterDirection.Output;
            command.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(idPedido.ToUpper()) ? (object)DBNull.Value : idPedido.ToUpper());

            conexion.Open();
            try
            {
                using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        DetalleAnexoPedidoDTO item = new DetalleAnexoPedidoDTO();
                        item.IdPedidoAnexo = reader.IsDBNull(reader.GetOrdinal("idpedidoanexo")) ? "" : reader.GetString(reader.GetOrdinal("idpedidoanexo")).Trim();
                        item.FileName = reader.IsDBNull(reader.GetOrdinal("nombre")) ? "" : reader.GetString(reader.GetOrdinal("nombre")).Trim();
                        item.Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? "" : reader.GetString(reader.GetOrdinal("descripcion")).Trim();
                        item.IdPedido = reader.IsDBNull(reader.GetOrdinal("idpedido")) ? "" : reader.GetString(reader.GetOrdinal("idpedido")).Trim();
                        item.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("fecharegistro")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fecharegistro"));
                        item.UsuarioRegistro = reader.IsDBNull(reader.GetOrdinal("usuarioregistro")) ? "" : reader.GetString(reader.GetOrdinal("usuarioregistro")).Trim();
                        item.FechaModificacion = reader.IsDBNull(reader.GetOrdinal("fechamodificacion")) ? new Nullable<DateTime>() : reader.GetDateTime(reader.GetOrdinal("fechamodificacion"));
                        item.UsuarioModificacion = reader.IsDBNull(reader.GetOrdinal("usuariomodificacion")) ? "" : reader.GetString(reader.GetOrdinal("usuariomodificacion")).Trim();
                        item.EstadoRegistro = reader.IsDBNull(reader.GetOrdinal("estadoregistro")) ? 0 : reader.GetInt32(reader.GetOrdinal("estadoregistro"));
                        response.Add(item);

                    }
                }
            }

            catch (Exception ex)
            {
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

        public List<DetalleAnexoAdjuntoPedidoDTO> ListarDetalleAnexosAdjuntosPedido(string idPedidoAnexo)
        {
            List<DetalleAnexoAdjuntoPedidoDTO> response = new List<DetalleAnexoAdjuntoPedidoDTO>();
            bool result = false;
            var conexion = new OracleConnection();
            var cnx = new ConexionBD();
            conexion = cnx.conectar();
            var command = new OracleCommand();
            command.Connection = conexion;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = cnx.NombrePaqueteSeguimientoPedido() + "pa_pedidoanexoadjunto_listar";

            command.Parameters.Add("v_result", OracleType.Cursor).Direction = ParameterDirection.Output;
            command.Parameters.AddWithValue("v_idpedidoanexo", string.IsNullOrEmpty(idPedidoAnexo.ToUpper()) ? (object)DBNull.Value : idPedidoAnexo.ToUpper());

            conexion.Open();
            try
            {
                using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        DetalleAnexoAdjuntoPedidoDTO item = new DetalleAnexoAdjuntoPedidoDTO();
                        item.IdPedidoAnexo = reader.IsDBNull(reader.GetOrdinal("idpedidoanexo")) ? "" : reader.GetString(reader.GetOrdinal("idpedidoanexo")).Trim();
                        item.IdPedidoAnexoAdjunto = reader.IsDBNull(reader.GetOrdinal("idpedidoanexoadjuntos")) ? "" : reader.GetString(reader.GetOrdinal("idpedidoanexoadjuntos")).Trim();
                        item.ArchivoRealNombre = reader.IsDBNull(reader.GetOrdinal("archivorealnombre")) ? "" : reader.GetString(reader.GetOrdinal("archivorealnombre")).Trim();
                        item.ArchivoVisualNombre = reader.IsDBNull(reader.GetOrdinal("archivovisualnombre")) ? "" : reader.GetString(reader.GetOrdinal("archivovisualnombre")).Trim();
                        item.ArchivoExtension = reader.IsDBNull(reader.GetOrdinal("archivoextension")) ? "" : reader.GetString(reader.GetOrdinal("archivoextension")).Trim();
                        item.ArchivoRutaDescarga = reader.IsDBNull(reader.GetOrdinal("archivorutadescarga")) ? "" : reader.GetString(reader.GetOrdinal("archivorutadescarga")).Trim();
                        item.EstadoRegistro = reader.IsDBNull(reader.GetOrdinal("estadoregistro")) ? 0 : reader.GetInt32(reader.GetOrdinal("estadoregistro"));
                        response.Add(item);

                    }
                }

            }

            catch (Exception ex)
            {
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

        public ResponseRegistarPedidoDTO EliminarCabeceraPedido(EliminarPedidoDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            try
            {

                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidos_eliminar", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(request.Id) ? (object)DBNull.Value : request.Id);

                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();


            }
            catch (Exception ex)
            {
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

        public ResponseObtenerCorrelativoMaestro obtenerCorrelativoPedido()
        {
            ResponseObtenerCorrelativoMaestro response = new ResponseObtenerCorrelativoMaestro();
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            try
            {
                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_mcippedidos_obtenerpedido", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("v_result", OracleType.Cursor).Direction = ParameterDirection.Output;

                    using (OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            response.Correlativo = reader.GetString(reader.GetOrdinal("Correlativo"));
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
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

        public ResponseRegistarPedidoDTO CambiarEstadoPedido(CambiarEstadoPedidoDTO request)
        {
            ResponseRegistarPedidoDTO response = new ResponseRegistarPedidoDTO();
            bool result = false;
            var cnx = new ConexionBD();
            OracleConnection conexion = new OracleConnection();
            conexion = cnx.conectar();
            try
            {
                conexion.Open();
                using (OracleCommand cmd = new OracleCommand(cnx.NombrePaqueteSeguimientoPedido() + "pa_pedido_cambio_estado", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("v_idpedido", string.IsNullOrEmpty(request.Id) ? (object)DBNull.Value : request.Id);
                    cmd.Parameters.AddWithValue("v_estadopedido", string.IsNullOrEmpty(request.EstadoPedido) ? (object)DBNull.Value : request.EstadoPedido);
                    cmd.Parameters.AddWithValue("v_usuariomodificacion", string.IsNullOrEmpty(request.UsuarioModificacion) ? (object)DBNull.Value : request.UsuarioModificacion);
                    cmd.Parameters.AddWithValue("v_fechamodificacion", DateTime.Now);
                    cmd.Parameters.Add("v_xestado", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response.Result.Mensaje = cmd.Parameters["v_xestado"].Value.ToString();
                    response.Result.Satisfactorio = true;
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
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
    }
}
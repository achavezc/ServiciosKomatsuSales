/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:11 p.m.
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades.Core;
using RANSA.MCIP.Framework;

namespace RANSA.MCIP.AccesoDatos
{
    public class RepositorioDetalleCatalogo : RepositorioBase<DetalleCatalogo>
    {
        public RepositorioDetalleCatalogo(ContextoParaBaseDatos contexto)
            : base(contexto)
        {
        }

        //public ResponseActualizarDetalleCatalogo ActualizarDetalleCatalogo(RequestActualizarDetalleCatalogo request)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public ResponseEliminarDetalleCatalogo EliminarDetalleCatalogo(RequestEliminarDetalleCatalogo request)
        //{
        //    throw new System.NotImplementedException();
        //}

        /* Obtiene un detalle o todo el detalle o todo el detalle filtrado por su id padre.*/
        public ResponseObtenerDetalleCatalogo ObtenerDetalleCatalogo(RequestObtenerDetalleCatalogo request)
        {
            var response = new ResponseObtenerDetalleCatalogo();
            try
            {
                // Inputs
                SqlParameter pIdDetalleCatalogo = createParameter("@IdDetalleCatalogo", SqlDbType.VarChar, request.idDetalleCatalogo);
                SqlParameter pIdCatalogo = createParameter("@IdCatalogo", SqlDbType.VarChar, request.idCatalogoTabla);
                SqlParameter pUsuario = createParameter("@Usuario", SqlDbType.VarChar, null);
                // Outputs
                SqlParameter pxEstado = createParameter("@xEstado", SqlDbType.Char, string.Empty, ParameterDirection.Output, 1);
                SqlParameter pxMsg = createParameter("@xMsg", SqlDbType.VarChar, string.Empty, ParameterDirection.Output);
                // Consulta
                //DetalleCatalogo
                var catalogos = Contexto.Database.SqlQuery<
                    DetalleCatalogoDTO
                    >(
                    @"  USP_DetalleCatalogo_OBTENER 
                    @IdDetalleCatalogo,     @IdCatalogo,   @Usuario,   @xEstado output,
                    @xMsg output",
                    pIdDetalleCatalogo, pIdCatalogo, pUsuario, pxEstado,
                    pxMsg);
                // Respuesta
                var respuestas = catalogos.ToList();
                response.resultadoBusqueda = respuestas;
                response.nroRegistros = response.resultadoBusqueda.Count;
                //response.paginasTotales = Convert.ToInt32(pxCantidadPaginas.Value);
                //response.mensajes 
                //response.codigoEstadoOperacion 
                //response.estadoOperacion 
                //response.errores 
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
            }
            return response;
        }

        public ResponseRegistrarDetalleCatalogo RegistrarDetalleCatalogo(RequestRegistrarDetalleCatalogo request)
        {
            throw new System.NotImplementedException();
        }

        public List<DetalleCatalogo> ListarDetalleCatalogo(int idCatalogo, string codigoSociedadPropietaria)
        {
            List<DetalleCatalogo> listaDetalle = new List<DetalleCatalogo>();
            try
            {
                SqlParameter paramIdCatalogo = new SqlParameter("@IdCatalogo", SqlDbType.Int);
                paramIdCatalogo.Value = idCatalogo;
                SqlParameter paramCodSociedadPropietaria = new SqlParameter("@CodSociedadPropietaria", SqlDbType.VarChar);
                paramCodSociedadPropietaria.Value = codigoSociedadPropietaria;

                var detalleCatalogo = Contexto.Database.SqlQuery<
                    DetalleCatalogo
                    >("usp_ListarDetalleCatalogo @IdCatalogo, @CodSociedadPropietaria",
                    paramIdCatalogo,
                    paramCodSociedadPropietaria);
                listaDetalle = detalleCatalogo.ToList();
            }
            catch (Exception)
            {
                throw;
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
            }
            return listaDetalle;
        }






        // Graba y Actualiza.
        public ResponseRegistrarDetalleCatalogoMasivo GrabarDetalleCatalogoMasivo(RequestRegistrarDetalleCatalogoMasivo request)
        {
            var response = new ResponseRegistrarDetalleCatalogoMasivo();
            try
            {
                DataTable dtDetalle = new DataTable();
                dtDetalle.Columns.Add("IdDetalleCatalogo", typeof(int));
                dtDetalle.Columns.Add("IdCatalogo", typeof(int));
                dtDetalle.Columns.Add("Codigo", typeof(string));
                dtDetalle.Columns.Add("Label", typeof(string));
                dtDetalle.Columns.Add("Descripcion", typeof(string));
                dtDetalle.Columns.Add("Mnemonico", typeof(string));
                dtDetalle.Columns.Add("Val1", typeof(string));
                dtDetalle.Columns.Add("Val2", typeof(string));
                dtDetalle.Columns.Add("SociedadPropietaria", typeof(string));
                dtDetalle.Columns.Add("Val3", typeof(string));
                dtDetalle.Columns.Add("Usuario", typeof(string));
                dtDetalle.Columns.Add("EstadoRegistro", typeof(bool));
                dtDetalle.Columns.Add("Val4", typeof(string));
                dtDetalle.Columns.Add("val4_ficheroReal", typeof(string));
                dtDetalle.Columns.Add("val4_ficheroVisual", typeof(string));

                //
                DataTable dtDetalleEliminados = new DataTable();
                dtDetalleEliminados.Columns.Add("IdDetalleCatalogo", typeof(int));
                dtDetalleEliminados.Columns.Add("IdCatalogo", typeof(int));
                dtDetalleEliminados.Columns.Add("Codigo", typeof(string));
                dtDetalleEliminados.Columns.Add("Label", typeof(string));
                dtDetalleEliminados.Columns.Add("Descripcion", typeof(string));
                dtDetalleEliminados.Columns.Add("Mnemonico", typeof(string));
                dtDetalleEliminados.Columns.Add("Val1", typeof(string));
                dtDetalleEliminados.Columns.Add("Val2", typeof(string));
                dtDetalleEliminados.Columns.Add("SociedadPropietaria", typeof(string));
                dtDetalleEliminados.Columns.Add("Val3", typeof(string));
                dtDetalleEliminados.Columns.Add("Usuario", typeof(string));
                dtDetalleEliminados.Columns.Add("EstadoRegistro", typeof(bool));
                dtDetalleEliminados.Columns.Add("Val4", typeof(string));
                dtDetalleEliminados.Columns.Add("val4_ficheroReal", typeof(string));
                dtDetalleEliminados.Columns.Add("val4_ficheroVisual", typeof(string));

                foreach (GrabarDetalleCatalogoDTO item in request.listaGrabarDetalleCatalogoDTO)
                {
                    if (item.eliminado)
                    {
                        dtDetalleEliminados.Rows.Add(item.idDetalleCatalogo);
                    }
                    else
                    {
                        dtDetalle.Rows.Add(item.idDetalleCatalogo
                        , item.idCatalogo
                        , item.codigo
                        , item.label
                        , item.descripcion
                        , item.mnemonico
                        , item.val1
                        , item.val2
                        , item.sociedadPropietaria
                        , item.val3                        
                        , item.usuario
                        , item.estadoRegistro
                        , item.val4
                        , item.val4_ficheroReal
                        , item.val4_ficheroVisual
                        );
                    }
                }

                char xTipoEliminacion = 'F';
                string Usuario = "vf";
                int? idCatalogo = null;
                string xEstado = "";
                string xMsg = "";

                List<InputEF> lstInputBD = new List<InputEF>();
                // Filtros Búsqueda
                lstInputBD.Add(new InputEF("@TipoMaestroDetalleCatalogo", dtDetalleEliminados, "dbo.TipoMaestroDetalleCatalogo"));
                lstInputBD.Add(new InputEF("@Usuario", Usuario, DbType.String));
                lstInputBD.Add(new InputEF("@xTipoEliminacion", xTipoEliminacion, DbType.String));
                // Outputs
                lstInputBD.Add(new InputEF("@xEstado", xEstado, DbType.String, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xMsg", xMsg, DbType.String, ParameterDirection.Output));

                new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento("USP_DetalleCatalogo_ELIMINAR", lstInputBD);

                lstInputBD.Clear();


                // Filtros Búsqueda
                lstInputBD.Add(new InputEF("@TipoMaestroDetalleCatalogo", dtDetalle, "dbo.TipoMaestroDetalleCatalogo"));
                // Outputs

                lstInputBD.Add(new InputEF("@xIdCatalogo", idCatalogo, DbType.Int32, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xEstado", xEstado, DbType.String, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xMsg", xMsg, DbType.String, ParameterDirection.Output));
                // Grabar
                new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento("USP_DetalleCatalogoMasivo_GRABAR", lstInputBD);


            }
            catch (Exception)
            {
                throw;
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
            }
            return response;
        }
    }
}
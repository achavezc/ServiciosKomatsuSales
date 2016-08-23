using Microsoft.SqlServer.Server;
/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:02 p.m.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades.Constantes;
using RANSA.MCIP.Entidades.Core;
using RANSA.MCIP.Framework;

namespace RANSA.MCIP.AccesoDatos
{
    public class RepositorioCatalogoTablas : RepositorioBase<CatalogoTablas>
    {
        public RepositorioCatalogoTablas(ContextoParaBaseDatos contexto) : base(contexto) { }

        // Búqueda. Recibe parámetros de búsqueda.
        public ResponseBusquedaCatalogoTablasDTO BuscarCatalogoTablas(RequestBusquedaCatalogoTablasDTO request)
        {
            ResponseBusquedaCatalogoTablasDTO response = new ResponseBusquedaCatalogoTablasDTO();
            try
            {
                List<InputEF> lstInputBD = new List<InputEF>();
                // Filtros Búsqueda
                lstInputBD.Add(new InputEF("@FindIdCatalogo", null, DbType.String));
                lstInputBD.Add(new InputEF("@FindCodigo", request.filtros.codigo, DbType.String));
                lstInputBD.Add(new InputEF("@FindNombre", null, DbType.String));
                lstInputBD.Add(new InputEF("@FindDescripcion", request.filtros.nombre, DbType.String));
                lstInputBD.Add(new InputEF("@FindCodigoTabla", null, DbType.String));
                lstInputBD.Add(new InputEF("@FindEstadoRegistro", request.filtros.estadoRegistro, DbType.String));
                lstInputBD.Add(new InputEF("@xUsuarioConsulta", null, DbType.String));
                // Ordenamiento
                lstInputBD.Add(new InputEF("@xOrdenCampo", request.PaginacionDTO.sidx, DbType.String));
                lstInputBD.Add(new InputEF("@xOrdenOrientacion", request.PaginacionDTO.sord, DbType.String));
                // Paginación
                lstInputBD.Add(new InputEF("@xPaginaActual", request.PaginacionDTO.getNroPagina(), DbType.Int32));
                lstInputBD.Add(new InputEF("@xNroRegistrosPorPagina", request.PaginacionDTO.getNroFilas(), DbType.Int32));
                // Outputs
                lstInputBD.Add(new InputEF("@xEstado", "", DbType.String, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xMsg", "", DbType.String, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xTotalRegistros", 0, DbType.Int32, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xCantidadPaginas", 0, DbType.Int32, ParameterDirection.Output));

                response.resultadoBusqueda = new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento<CatalogoTablasDTO>("USP_CatalogoTablas_BUSCAR", lstInputBD);
                response.nroRegistros = Convert.ToInt32(lstInputBD.Find(x => x.NombreAtributo == "@xTotalRegistros").Valor);
                response.paginasTotales = Convert.ToInt32(lstInputBD.Find(x => x.NombreAtributo == "@xCantidadPaginas").Valor);
            }
            catch (Exception)
            {
                throw;
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
            }
            return response;
        }
        /* public class DataCollection<T> : List<T>, IEnumerable<SqlDataRecord>
         {
             IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
             {
                
                 var sqlDataRecord = new SqlDataRecord(new SqlMetaData("SerieNumero", SqlDbType.Text));
                 foreach (T reg in this)
                 {
                     sqlDataRecord.SetString(0, TipoListaDocumentositem.SerieNumero);
                     yield return sqlDataRecord;
                 }
                 
             }
         }
         */
        // Búqueda. Recibe parámetros de búsqueda masivo.
        public ResponseBusquedaCatalogoTablasMasivoDTO BuscarCatalogoTablasMasivo(RequestBusquedaCatalogoTablasDTO request)
        {
            ResponseBusquedaCatalogoTablasMasivoDTO response = new ResponseBusquedaCatalogoTablasMasivoDTO();
            try
            {
                List<InputEF> lstInputBD = new List<InputEF>();
                // Filtros Búsqueda
                lstInputBD.Add(new InputEF("@FindIdCatalogo", null, DbType.String));
                lstInputBD.Add(new InputEF("@FindCodigo", request.filtros.codigo, DbType.String));
                lstInputBD.Add(new InputEF("@FindNombre", null, DbType.String));
                lstInputBD.Add(new InputEF("@FindDescripcion", request.filtros.nombre, DbType.String));
                lstInputBD.Add(new InputEF("@FindCodigoTabla", null, DbType.String));
                lstInputBD.Add(new InputEF("@FindEstadoRegistro", request.filtros.estadoRegistro, DbType.String));
                lstInputBD.Add(new InputEF("@xUsuarioConsulta", null, DbType.String));
                // Ordenamiento
                lstInputBD.Add(new InputEF("@xOrdenCampo", request.PaginacionDTO.sidx, DbType.String));
                lstInputBD.Add(new InputEF("@xOrdenOrientacion", request.PaginacionDTO.sord, DbType.String));
                // Paginación
                lstInputBD.Add(new InputEF("@xPaginaActual", request.PaginacionDTO.getNroPagina(), DbType.Int32));
                lstInputBD.Add(new InputEF("@xNroRegistrosPorPagina", request.PaginacionDTO.getNroFilas(), DbType.Int32));
                // Outputs
                lstInputBD.Add(new InputEF("@xEstado", "", DbType.String, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xMsg", "", DbType.String, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xTotalRegistros", 0, DbType.Int32, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xCantidadPaginas", 0, DbType.Int32, ParameterDirection.Output));

                //response.resultadoBusqueda = new HelperEF().EjecutarFuncionOProcedimiento<CatalogoTablasDTO>("USP_CatalogoTablas_BUSCAR_MASIVO", lstInputBD);

                SqlParameter[] lstSqlParameter = new HelperEF().GetInputSqlParameterTradicional(lstInputBD);
                SqlConnection con = new SqlConnection();
                try
                {
                    con.ConnectionString = ContextoParaBaseDatos.DecryptedConnectionString();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("USP_CatalogoTablas_BUSCAR_MASIVO");
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(lstSqlParameter);


                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        response.resultadoBusqueda = new List<CatalogoTablasDTO>();
                        while (dataReader.Read())
                        {
                            CatalogoTablasDTO item = new CatalogoTablasDTO();
                            item.codigo = new HelperEF().GetStringNull(dataReader, "codigo");
                            item.codigoTabla = new HelperEF().GetStringNull(dataReader, "codigoTabla");
                            item.descripcion = new HelperEF().GetStringNull(dataReader, "descripcion");
                            item.estadoRegistro = new HelperEF().GetBoolean(dataReader, "estadoRegistro");
                            item.estadoRegistroCadena = new HelperEF().GetStringNull(dataReader, "estadoRegistroCadena");
                            item.idCatalogo = new HelperEF().GetInt32Null(dataReader, "idCatalogo");
                            item.nombre = new HelperEF().GetStringNull(dataReader, "nombre");
                            response.resultadoBusqueda.Add(item);
                        }
                        dataReader.NextResult();

                        response.listaDetalleCatalogo = new List<ResultadoFilaDetalleCatalogoDTO>();
                        while (dataReader.Read())
                        {
                            ResultadoFilaDetalleCatalogoDTO regfila = new ResultadoFilaDetalleCatalogoDTO();
                            //DetalleCatalogoDTO item = new DetalleCatalogoDTO();
                            regfila.codigo = new HelperEF().GetStringNull(dataReader, "codigo");
                            regfila.descripcion = new HelperEF().GetStringNull(dataReader, "descripcion");
                            regfila.estadoRegistro = new HelperEF().GetBoolean(dataReader, "estadoRegistro");
                            regfila.estadoRegistroCadena = new HelperEF().GetStringNull(dataReader, "estadoRegistroCadena");
                            regfila.idCatalogo = new HelperEF().GetInt(dataReader, "idCatalogo");
                            regfila.idDetalleCatalogo = new HelperEF().GetInt(dataReader, "idDetalleCatalogo");
                            regfila.label = new HelperEF().GetStringNull(dataReader, "label");
                            regfila.mnemonico = new HelperEF().GetStringNull(dataReader, "mnemonico");
                            regfila.sociedadPropietaria = new HelperEF().GetStringNull(dataReader, "sociedadPropietaria");
                            regfila.val1 = new HelperEF().GetStringNull(dataReader, "val1");
                            regfila.val2 = new HelperEF().GetStringNull(dataReader, "val2");
                            regfila.val3 = new HelperEF().GetStringNull(dataReader, "val3");
                            regfila.val4 = new HelperEF().GetStringNull(dataReader, "val4");
                            regfila.val4_ficheroReal = new HelperEF().GetStringNull(dataReader, "val4_ficheroReal");
                            regfila.val4_ficheroVisual = new HelperEF().GetStringNull(dataReader, "val4_ficheroVisual");
                            response.listaDetalleCatalogo.Add(regfila);
                        }
                    }

                    new HelperEF().SetOutputSqlParameter(lstInputBD, lstSqlParameter);

                    response.nroRegistros = Convert.ToInt32(lstInputBD.Find(x => x.NombreAtributo == "@xTotalRegistros").Valor);
                    response.paginasTotales = Convert.ToInt32(lstInputBD.Find(x => x.NombreAtributo == "@xCantidadPaginas").Valor);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        // Elimina Lógicamente y Fisicamente.
        public ResponseEliminarCatalogoTablas EliminarCatalogoTablas(RequestEliminarCatalogoTablas request)
        {
            var response = new ResponseEliminarCatalogoTablas();
            return response;
        }

        // Graba y Actualiza.
        public ResponseRegistrarCatalogoTablas GrabarCatalogoTablas(RequestRegistrarCatalogoTablas request)
        {
            var response = new ResponseRegistrarCatalogoTablas();
            try
            {
                // Inputs
                DataTable dtCatalogo = new DataTable();
                dtCatalogo.Columns.Add("IdCatalogo", typeof(int));
                dtCatalogo.Columns.Add("Codigo", typeof(string));
                dtCatalogo.Columns.Add("Nombre", typeof(string));
                dtCatalogo.Columns.Add("Descripcion", typeof(string));
                dtCatalogo.Columns.Add("CodigoTabla", typeof(string));
                dtCatalogo.Columns.Add("Usuario", typeof(string));
                dtCatalogo.Columns.Add("EstadoRegistro", typeof(bool)); // sólo para guardar (no para modificar)

                /* A considerar: 
                 * 1.- Si se puede enviar null. (no hay necesidad de convertir los null a DBNull.Value
                 * 2.- 
                */
                dtCatalogo.Rows.Add(request.GrabarCatalogoTablaDTO.IdCatalogo
                    , request.GrabarCatalogoTablaDTO.Codigo
                    , request.GrabarCatalogoTablaDTO.Nombre
                    , request.GrabarCatalogoTablaDTO.Descripcion
                    , request.GrabarCatalogoTablaDTO.CodigoTabla
                    , request.GrabarCatalogoTablaDTO.Usuario
                    , request.GrabarCatalogoTablaDTO.EstadoRegistro);

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
                        , item.estadoRegistro);
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
                lstInputBD.Add(new InputEF("@TipoMaestroCatalogoTablas", dtCatalogo, "dbo.TipoMaestroCatalogoTablas"));
                lstInputBD.Add(new InputEF("@TipoMaestroDetalleCatalogo", dtDetalle, "dbo.TipoMaestroDetalleCatalogo"));
                // Outputs

                lstInputBD.Add(new InputEF("@xIdCatalogo", idCatalogo, DbType.Int32, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xEstado", xEstado, DbType.String, ParameterDirection.Output));
                lstInputBD.Add(new InputEF("@xMsg", xMsg, DbType.String, ParameterDirection.Output));
                // Grabar
                new HelperEF(Contexto.Database).EjecutarFuncionOProcedimiento("USP_CatalogoTablas_GRABAR", lstInputBD);

                response.idCatalogo = Convert.ToInt32(lstInputBD.Find(x => x.NombreAtributo == "@xIdCatalogo").Valor);
            }
            catch (Exception)
            {
                throw;
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
            }
            return response;
        }



        // Obtiene cabecera de un catálogo y lista todo su detalle.
        public ResponseObtenerCatalogoTablasDTO ObtenerCatalogoTablas(RequestObtenerCatalogoTablasDTO request)
        {
            var response = new ResponseObtenerCatalogoTablasDTO();
            try
            {
                // Inputs
                SqlParameter pIdCatalogo = createParameter("@IdCatalogo", SqlDbType.VarChar, request.idCatalogo);
                SqlParameter pUsuario = createParameter("@Usuario", SqlDbType.VarChar, null);
                // Outputs
                SqlParameter pxEstado = createParameter("@xEstado", SqlDbType.Char, string.Empty, ParameterDirection.Output, 1);
                SqlParameter pxMsg = createParameter("@xMsg", SqlDbType.VarChar, string.Empty, ParameterDirection.Output);
                // Consulta
                var catalogos = Contexto.Database.SqlQuery<
                    CatalogoTablas
                    >(
                    @"  USP_CatalogoTablas_OBTENER 
                    @IdCatalogo,    @Usuario,   @xEstado output, @xMsg output",
                    pIdCatalogo, pUsuario, pxEstado,
                    pxMsg);
                // Respuesta
                //  Cabecera
                var respuestas = catalogos.ToList();
                response.catalogoTabla = new CatalogoTablasDTO();
                response.catalogoTabla.codigo = respuestas[0].codigo;
                response.catalogoTabla.codigoTabla = respuestas[0].codigoTabla;
                response.catalogoTabla.descripcion = respuestas[0].descripcion;
                response.catalogoTabla.estadoRegistro = respuestas[0].estadoRegistro;
                response.catalogoTabla.idCatalogo = respuestas[0].idCatalogo;
                response.catalogoTabla.nombre = respuestas[0].nombre;

                //  Detalle
                var repoDetalle = new RepositorioDetalleCatalogo(Contexto);
                var requestDetalle = new RequestObtenerDetalleCatalogo();
                requestDetalle.idCatalogoTabla = response.catalogoTabla.idCatalogo;
                var responseDetalle = repoDetalle.ObtenerDetalleCatalogo(requestDetalle).resultadoBusqueda;
                response.listaDetalleCatalogo = (from lista in responseDetalle
                                                 select new ResultadoFilaDetalleCatalogoDTO
                                                 {
                                                     codigo = lista.codigo,
                                                     descripcion = lista.descripcion,
                                                     idCatalogo = lista.idCatalogo,
                                                     idDetalleCatalogo = lista.idDetalleCatalogo,
                                                     label = lista.label,
                                                     mnemonico = lista.mnemonico,
                                                     sociedadPropietaria = lista.sociedadPropietaria,
                                                     val1 = lista.val1,
                                                     val2 = lista.val2,
                                                     val3 = lista.val3,
                                                     val4 = lista.val4,
                                                     val4_ficheroReal = lista.val4_ficheroReal,
                                                     val4_ficheroVisual = lista.val4_ficheroVisual,
                                                     estadoRegistro = lista.estadoRegistro,
                                                     estadoRegistroCadena = lista.estadoRegistroCadena
                                                 }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

    }
}
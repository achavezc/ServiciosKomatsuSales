/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:37:22 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RANSA.MCIP.AccesoDatos;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades.Constantes;
using RANSA.MCIP.Framework;

namespace RANSA.MCIP.LogicaNegocio
{
    public class CatalogoTablasBL
    {


        // Búqueda. Recibe parámetros de búsqueda.
        public ResponseBusquedaCatalogoTablasDTO BuscarCatalogoTablas(RequestBusquedaCatalogoTablasDTO request)
        {
            ResponseBusquedaCatalogoTablasDTO response = new ResponseBusquedaCatalogoTablasDTO();
            try
            {
                var contextoParaBaseDatos = new ContextoParaBaseDatos();
                RepositorioCatalogoTablas repo = new RepositorioCatalogoTablas(contextoParaBaseDatos);
                response = repo.BuscarCatalogoTablas(request);
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioCorrecto;
            }
            catch (Exception)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioError;
                throw; 
            }
            return response;
        }
        // Búqueda. Recibe parámetros de búsqueda de catalogo y detalle catalogo asociados.
        public ResponseBusquedaCatalogoTablasMasivoDTO BuscarCatalogoTablasMasivo(RequestBusquedaCatalogoTablasDTO request)
        {
            ResponseBusquedaCatalogoTablasMasivoDTO response = new ResponseBusquedaCatalogoTablasMasivoDTO();
            try
            {
                var contextoParaBaseDatos = new ContextoParaBaseDatos();
                RepositorioCatalogoTablas repo = new RepositorioCatalogoTablas(contextoParaBaseDatos);
                response = repo.BuscarCatalogoTablasMasivo(request);
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioCorrecto;
            }
            catch (Exception)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioError;
                throw;
            }
            return response;
        }


        // Elimina Lógicamente y Fisicamente.
        public ResponseEliminarCatalogoTablas EliminarCatalogoTablas(RequestEliminarCatalogoTablas request)
        {
            throw new System.NotImplementedException();
        }

        // Graba y Actualiza.
        public ResponseRegistrarCatalogoTablas GrabarCatalogoTablas(RequestRegistrarCatalogoTablas request)
        {
            var response = new ResponseRegistrarCatalogoTablas();
            try
            {
                var contextoParaBaseDatos = new ContextoParaBaseDatos();
                RepositorioCatalogoTablas repo = new RepositorioCatalogoTablas(contextoParaBaseDatos);

                request.listaGrabarDetalleCatalogoDTO.ForEach(reg =>
                {
                    if (!String.IsNullOrEmpty(reg.val4))
                    {
                        string rutafisica = Helper.GetAppSetting("RUTAFISICA") + reg.val4_ficheroReal;
                        reg.val4_bytes = Helper.LeerArchivo(rutafisica);
                    }
                }
                );


                response = repo.GrabarCatalogoTablas(request);
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioCorrecto;
                response.GrabarRespuestas("Se grabó satisfactoriamente.", ConstantesSistema.EstadoOperacionServicioCorrecto, null);
            }
            catch (Exception)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioError;
                throw; 
            }
            return response;
        }
        
        // Obtiene cabecera de un catálogo y lista todo su detalle.
        public ResponseObtenerCatalogoTablasDTO ObtenerCatalogoTablas(RequestObtenerCatalogoTablasDTO request)
        {
            var response = new ResponseObtenerCatalogoTablasDTO();
            try
            {
                var contextoParaBaseDatos = new ContextoParaBaseDatos();
                RepositorioCatalogoTablas repo = new RepositorioCatalogoTablas(contextoParaBaseDatos);
                response = repo.ObtenerCatalogoTablas(request);
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioCorrecto;
            }
            catch (Exception)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
                response.estadoOperacion = ConstantesSistema.EstadoOperacionServicioError;
                throw; 
            }
            return response;
        }
    }
}
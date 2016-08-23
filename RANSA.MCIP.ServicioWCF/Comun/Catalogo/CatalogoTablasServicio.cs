/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:37:27 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RANSA.MCIP.DTO;
using RANSA.MCIP.LogicaNegocio;

namespace RANSA.MCIP.ServicioWCF
{
    public class CatalogoTablasServicio : ICatalogoTablasServicio
    {


        // Búqueda. Recibe parámetros de búsqueda.
        //[Log]
        public ResponseBusquedaCatalogoTablasDTO BuscarCatalogoTablas(RequestBusquedaCatalogoTablasDTO request)
        {
            try
            {
                var catalogoTablasBL = new CatalogoTablasBL();
                var catalogos = catalogoTablasBL.BuscarCatalogoTablas(request);
                return catalogos;
            }
            catch (Exception ex)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }
        public ResponseBusquedaCatalogoTablasMasivoDTO BuscarCatalogoTablasMasivo(RequestBusquedaCatalogoTablasDTO request)
        {
            try
            {
                var catalogoTablasBL = new CatalogoTablasBL();
                var catalogos = catalogoTablasBL.BuscarCatalogoTablasMasivo(request);

                return catalogos;
            }
            catch (Exception ex)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }
        // Elimina Lógicamente y Fisicamente.
        //[Log]
        public ResponseEliminarCatalogoTablas EliminarCatalogoTablas(RequestEliminarCatalogoTablas request)
        {
            return null;
        }

        // Graba y Actualiza.
        //[Log]
        public ResponseRegistrarCatalogoTablas GrabarCatalogoTablas(RequestRegistrarCatalogoTablas request)
        {
            try
            {
                var catalogoTablasBL = new CatalogoTablasBL();
                var catalogos = catalogoTablasBL.GrabarCatalogoTablas(request);
                return catalogos;
            }
            catch (Exception ex)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }

       

        // Obtiene cabecera de un catálogo y lista todo su detalle.
        //[Log]
        public ResponseObtenerCatalogoTablasDTO ObtenerCatalogoTablas(RequestObtenerCatalogoTablasDTO request)
        {
            try
            {
                var catalogoTablasBL = new CatalogoTablasBL();
                var catalogos = catalogoTablasBL.ObtenerCatalogoTablas(request);
                return catalogos;
            }
            catch (Exception ex)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }
    }
}
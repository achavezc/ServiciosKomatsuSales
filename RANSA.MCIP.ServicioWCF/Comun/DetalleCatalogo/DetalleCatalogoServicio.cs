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
using RANSA.MCIP.Entidades.Core;
using RANSA.MCIP.LogicaNegocio;

namespace RANSA.MCIP.ServicioWCF
{
	public class DetalleCatalogoServicio : IDetalleCatalogoServicio
	{
        //public ResponseObtenerUnoDetalleCatalogo ObtenerUnoDetalleCatalogo(RequestObtenerUnoDetalleCatalogo request)
        //{
        //    throw new System.NotImplementedException();
        //}

        //[Log]
        public List<DetalleCatalogo> ListarDetalleCatalogo(Dictionary<string, string> request)
        {
            try
            {
                var detalleCatalogoBL = new DetalleCatalogoBL();

                var detalleCatalogo = detalleCatalogoBL.ListarDetalleCatalogo(request);

                return detalleCatalogo;
            }
            catch (Exception ex)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }

        public ResponseRegistrarDetalleCatalogoMasivo GrabarDetalleCatalogoMasivo(RequestRegistrarDetalleCatalogoMasivo request)
        {
            try
            {
                var detalleCatalogoBL = new DetalleCatalogoBL();
                var response = detalleCatalogoBL.GrabarDetalleCatalogoMasivo(request);
                return response;
            }
            catch (Exception ex)
            {
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }
	}
}
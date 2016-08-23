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
using RANSA.MCIP.Entidades.Core;
using RANSA.MCIP.Framework;

namespace RANSA.MCIP.LogicaNegocio
{
    public class DetalleCatalogoBL
    {
        // Graba y Actualiza.
        public ResponseRegistrarDetalleCatalogoMasivo GrabarDetalleCatalogoMasivo(RequestRegistrarDetalleCatalogoMasivo request)
        {
            var response = new ResponseRegistrarDetalleCatalogoMasivo();
            try
            {
                var contextoParaBaseDatos = new ContextoParaBaseDatos();
                RepositorioDetalleCatalogo repo = new RepositorioDetalleCatalogo(contextoParaBaseDatos);


                request.listaGrabarDetalleCatalogoDTO.ForEach(reg =>
                {
                    if (!String.IsNullOrEmpty(reg.val4))
                    {
                        string rutafisica = Helper.GetAppSetting("RUTAFISICA") + "/" + reg.val4_ficheroReal;
                        reg.val4_bytes = Helper.LeerArchivo(rutafisica);
                    }
                }
                );

                response = repo.GrabarDetalleCatalogoMasivo(request);

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

        public List<DetalleCatalogo> ListarDetalleCatalogo(Dictionary<string, string> request)
        {
            List<DetalleCatalogo> listaDetalleCatalogo = new List<DetalleCatalogo>();

            try
            {
                ManejadorCache manejadorCache = new ManejadorCache();
                string keyCache = Convert.ToString(request["KeyCache"]);

                listaDetalleCatalogo = manejadorCache.ObtenerValorCache<List<DetalleCatalogo>>(keyCache);

                if (listaDetalleCatalogo == null)
                {
                    var codigoCatalogo = Convert.ToInt32(request["CodigoCatalogo"]);
                    var sociedadPropietaria = Convert.ToString(request["sociedadPropietaria"]);

                    var contextoParaBaseDatos = new ContextoParaBaseDatos();
                    var repositorio = new RepositorioDetalleCatalogo(contextoParaBaseDatos);

                    listaDetalleCatalogo = repositorio.ListarDetalleCatalogo(codigoCatalogo, sociedadPropietaria).ToList();

                    if (listaDetalleCatalogo != null && listaDetalleCatalogo.Count > 0)
                    {
                        manejadorCache.InsertarValorCache(keyCache, listaDetalleCatalogo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
                //ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return listaDetalleCatalogo;
        }
    }
}
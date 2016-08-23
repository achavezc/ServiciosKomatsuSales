using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using RANSA.MCIP.DTO;
using RANSA.MCIP.LogicaNegocio;
using RANSA.MCIP.Framework;

namespace RANSA.MCIP.ServicioWCF
{
    /// <summary>
    /// Servicio para Adjuntar Archivos desde una adenda, cotización o acuerdo comercial
    /// </summary>
    public class AdjuntarArchivosServicio : IAdjuntarArchivosServicio
    {
        /// <summary>
        /// Sube un archivo adjunto y lo registra en COMEX para Acuerdos Comerciales, Adendas o Cotizaciones
        /// <br/><b>URL Invocación:</b> <a href="http://tramoldev01.tramarsa.com.pe:2020/AdjuntarArchivosServicio.svc/AgregarArchivo">http://tramoldev01.tramarsa.com.pe:2020/AdjuntarArchivosServicio.svc/AgregarArchivo</a>
        /// <br/><b>Request JSON:</b> {"SociedadPropietaria":"301","filtros":{"archivoStream":[80,75,3,4,20,0,6,0,8,0,0,0,33,0,213,115,223,97,167,1,0,0,116,7,0,0,19,0,8,2,91,67,111,110,116,101,110,0,0],"filename":"Cuadre de Caja_reporte_v2.xlsx"}}
        /// <br/><b>Response JSON:</b> {"error":"Error de inicio de sesión: nombre de usuario desconocido o contraseña incorrecta.\u000d\u000a","ficheroReal":"Cuadre de Caja_reporte_v2.xlsx","ficheroVisual":"Cuadre de Caja_reporte_v2.xlsx","link":null}
        /// </summary>
        /// <param name="requestAdjuntarArchivosDTO">Entidad con el archivo expresado en bytes</param>
        /// <returns>Entidad con el resultado del proceso</returns>
        [Log]
        public ResponseAdjuntarArchivoDTO AgregarArchivo(RequestAdjuntarArchivosDTO requestAdjuntarArchivosDTO)
        {
            try
            {
                var BL = new AdjuntarArchivosBL();
                ResponseAdjuntarArchivoDTO resultado = BL.AgregarArchivo(requestAdjuntarArchivosDTO);
                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }

        [Obsolete]
        [Log]
        public ResponseEliminarAdjuntarArchivoDTO EliminarArchivos(EliminarArchivoAdjuntoDTO requestAdjuntarArchivosDTO)
        {
            try
            {
                var BL = new AdjuntarArchivosBL();
                ResponseEliminarAdjuntarArchivoDTO resultado = BL.EliminarArchivo(requestAdjuntarArchivosDTO);
                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }

        /// <summary>
        /// Obtiene un arreglo de bytes de un archivo adjunto para ser descargado
        /// <br/><b>URL Invocación:</b> <a href="http://tramoldev01.tramarsa.com.pe:2020/AdjuntarArchivosServicio.svc/DescargarArchivo">http://tramoldev01.tramarsa.com.pe:2020/AdjuntarArchivosServicio.svc/DescargarArchivo</a>
        /// <br/><b>Request JSON:</b> {"ArchivoVisual":"\\29012014100608-89792338CuadredeCaja_reporte_v2.xlsx","SociedadPropietaria":"301"}
        /// <br/><b>Response JSON:</b> {"Errores":[],"EstadoOperacion":"Correcto","ListaRespuestas":null,"Mensajes":null,"archivoBytes":[80,75,3,4,20,0,6,0,8,0,0,0,33,0,213,115,223,97,167,1,0,0,116,7,0,0,19,0,8,2,91,67,111,110,116,101,110,116,95,84,121,112,101,115,93,46,120,109,108,36,98,105,110,80,75,5,6,0,0,0,0,17,0,17,0,119,4,0,0,169,62,0,0,0,0],"ficheroVisual":"\\29012014100608-89792338CuadredeCaja_reporte_v2.xlsx"}
        /// </summary>
        /// <param name="request">Entidad con los parámetros para descargar el archivo</param>
        /// <returns>Entidad con el archivo solicitado en bytes</returns>
        [Log]
        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                var BL = new AdjuntarArchivosBL();
                ResponseDescargarArchivoDTO resultado = BL.DescargarArchivo(request);
                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                return null;
            }
        }

        //[Obsolete]
        //public ResponseParametrosDTO ObtenerParametros(String SociedadPropietaria)
        //{
        //    try
        //    {
        //        var BL = new AdjuntarArchivosBL();
        //        ResponseParametrosDTO resultado = BL.ObtenerParametros(SociedadPropietaria);
        //        return resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
        //        return null;
        //    }
        //}
    }
}

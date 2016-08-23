using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RANSA.MCIP.Framework
{
    /// <summary>
    /// Clase que centraliza el Manejo de Excepciones utilizando el Enterprise Library Exception Handling Application Block
    /// </summary>
    public class ManejadorExcepciones
    {

        /// <summary>
        /// Publica la Excepción teniendo la configuración asociada a una determinada Política de Excepción
        /// </summary>
        /// <param name="exception">Exception a publicar</param>
        /// <param name="politicaExcepcion">Politica de Excepcion</param>
        /// <returns></returns>
        public static bool PublicarExcepcion(Exception exception, PoliticaExcepcion politicaExcepcion)
        {
            ManejadorLog manejadorLog = new ManejadorLog();
            manejadorLog.GrabarLog(string.Format(politicaExcepcion.ToString()+": {0}{1}StackTrace: {2}{3}Inner Exception:{4}", 
                                                exception.Message
                                                , Environment.NewLine
                                                , exception.StackTrace
                                                , Environment.NewLine
                                                , exception.InnerException));
            return true;
        }

        public static bool PublicarExcepcion(Exception exception, Guid guid, string mensaje = "")
        {
            (new ManejadorLog()).GrabarLog(string.Format("Codigo:{0}{1}{2}{3}StackTrace: {4}{5}InnerException: {6}",
                                                    guid.ToString(),
                                                    Environment.NewLine,
                                                    exception.Message,
                                                    Environment.NewLine,
                                                    exception.StackTrace,
                                                    Environment.NewLine,
                                                    exception.InnerException));
            return true;
        }
        public static bool PublicarExcepcion(Exception exception, Guid guid, string numeroFacturaSD, string numeroSunat)
        {
            (new ManejadorLog()).GrabarExceptionSodimacIntegracion(string.Format("ErrorId: {0}{1}ErrorFechaHora: {2}{3}Número FacturaSD: {4}{5}Número Sunat: {6}{7}Error Descripción: {8}{9}StackTrace: {10}{11}InnerException{12}{13}{14}",
                                                    guid,
                                                    Environment.NewLine,
                                                    DateTime.Now,
                                                    Environment.NewLine,
                                                    numeroFacturaSD,
                                                    Environment.NewLine,
                                                    numeroSunat,
                                                    Environment.NewLine,
                                                    exception.Message,
                                                    Environment.NewLine,
                                                    exception.StackTrace,
                                                    Environment.NewLine,
                                                    exception.InnerException,
                                                    Environment.NewLine,
                                                    "-".PadRight(40,'-')
                                        ));
            return true;
        }
    }

    /// <summary>
    /// Enum de Politicas de Excepciones.
    /// </summary>
    public enum PoliticaExcepcion
    {
        /// <summary>
        /// Enum AccesoDatos
        /// </summary>
        AccesoDatos,
        /// <summary>
        /// Enum AgenteServicios
        /// </summary>
        AgenteServicios,
        /// <summary>
        /// Enum LogicaNegocio
        /// </summary>
        LogicaNegocio,
        /// <summary>
        /// Enum ServicioWCF
        /// </summary>
        ServicioWCF,
        /// <summary>
        /// Enum Web
        /// </summary>
        Web,
        /// <summary>
        /// Enum Win
        /// </summary>
        Win,
        /// <summary>
        /// Enum Framework
        /// </summary>
        Framework,
        /// <summary>
        /// Describe la integracion con SODIMAC
        /// </summary>
        IntegracionSodimac
    }
}

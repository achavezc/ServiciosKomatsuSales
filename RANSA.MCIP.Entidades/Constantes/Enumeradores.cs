using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RANSA.MCIP.Entidades.Constantes
{
    /// <summary>
    /// Tabla Tablas
    /// Tipo: enum 
    /// </summary>
    public enum TablaTablas
    {
        EstadoRegistro = 1,
    }

    /// <summary>
    /// Constantes Parametros Negocio
    /// Tipo: enum 
    /// </summary>
    public enum ConstantesParametrosNegocio
    {
    }

    public enum ConstantesParametrosSistema
    {
        NumeroFilasGrid = 1,
        ExpiracionCacheHoras = 2,      
        RutaFisicaArchivos = 9,
        MaxFiles = 10,
        MaxSize = 11,
        RutaLogicaArchivos = 10,
        ExtensionesPermitidas = 13,
        EntornoEjecucion = 16
    }
    /// <summary>
    /// Modo Acceso Pagina
    /// Tipo: enum 
    /// </summary>
    public enum ModoAccesoPagina
    {
        Visualizar,
        Modificar,
        Nuevo
    }
  
    /// <summary>
    /// Estado Registro
    /// Tipo: enum 
    /// </summary>
    public enum EstadoRegistro
    {
        Activo = 1,
        Inactivo = 0
    }

    /// <summary>
    /// Estado
    /// Tipo: enum 
    /// </summary>
    public enum Estado
    {
        Activo = 1,
        Inactivo = 0
    }

   
    /// <summary>
    /// Notificaciones
    /// Tipo: enum 
    /// </summary>
    public enum Notificaciones
    {
       
    }
    /// <summary>
    /// Tipo Accion Registro
    /// Tipo: enum 
    /// </summary>
    public enum TipoAccionRegistro
    {
        Nuevo = 1,
        Actualizar = 2,
        Ninguno = 0
    }

  
    /// <summary>
    /// clase para Tipo Usuario Seguridad
    /// </summary>
    public class TipoUsuarioSeguridad
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Interno = "I", Externo = "E", Todos = null;
    }

   

}

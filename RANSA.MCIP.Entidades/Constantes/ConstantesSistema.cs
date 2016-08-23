using System;
using System.Collections.Generic;
using System.Linq;

namespace RANSA.MCIP.Entidades.Constantes
{
    /// <summary>
    /// clase para Constantes Sistema
    /// </summary>
    public class ConstantesSistema
    {

        public const string EstadoOperacionServicioCorrecto = "Correcto";

        public const string EstadoOperacionServicioError = "Incorrecto";

        public static bool TraerSAP = true;

        public const int PseudoNull = -1;

        public const string FormatoFechaSAP = "dd.MM.yyyy";

        public const string MensajeErrorWindows = "Se ha originado un error en el sistema. \n\nPulse el botón aceptar para volver a la ventana.";

        public const string CaracterTodos = "*";

        public const string FlagMasivo = "X";

        public const string EstadoPendiente = "PENDIENTE";
        
        public const string ErrorGenerico = "Ha ocurrido un error";
    }
  
  

    /// <summary>
    /// clase para Constante Semaforo
    /// </summary>
    public class ConstanteSemaforo
    {

        public static string Verde = "V";

        public static string Amarillo = "A";

        public static string Rojo = "R";
    }
    

    /// <summary>
    /// clase para Constantes Estado
    /// </summary>
    public class ConstantesEstado
    {

        public static string Activo = "001";

        public static string Inactivo = "002";
    }


    /// <summary>
    /// clase para Constantes Tipo Cambio
    /// </summary>
    public class ConstantesTipoCambio
    {

        public static string M = "M";

        public static string PEN = "PEN";

        public static string USD = "USD";
    }

    /// <summary>
    /// clase para Constantes Monedas
    /// </summary>
    public class ConstantesMonedas
    {

        public static string Soles = "PEN";

        public static string Dolares = "USD";
    }
   

    /// <summary>
    /// clase para Constantes Parametro Sistema
    /// </summary>
    public class ConstantesParametroSistema
    {
        public static string ejemplo = "74";

    }

    public class ConstantesDB
    {
        public const string PPM = "PPM";
        
    }

}

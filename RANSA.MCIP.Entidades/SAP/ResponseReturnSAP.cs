using System;
using System.Collections.Generic;
using System.Linq;

namespace RANSA.MCIP.Entidades
{
    /// <summary>
    /// clase para Response Return SAP
    /// </summary>
    public class ResponseReturnSAP
    {
        /// <summary>
        /// Tipo mensaje: S Success, E Error, W Warning, I Info A Abort
        /// Tipo: String
        /// Longitud: 1
        /// </summary>
        public string TYPE
        {
            get;
            set;
        }

        /// <summary>
        /// Clase de mensajes
        /// Tipo: String
        /// Longitud: variable
        /// </summary>
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        /// Número de mensaje
        /// Tipo: NUMC
        /// </summary>
        public int NUMBER
        {
            get;
            set;
        }

        /// <summary>
        /// Texto de mensaje
        /// Tipo: String2
        /// Longitud: variable
        /// </summary>
        public string MESSAGE
        {
            get;
            set;
        }

        /// <summary>
        /// Log de aplicación: Número de log
        /// Tipo: String
        /// Longitud: variable
        /// </summary>
        public string LOG_NO
        {
            get;
            set;
        }

        /// <summary>
        /// Log aplicación: Número consecutivo interno de mensaje
        /// Tipo: NUMC
        /// </summary>
        public string LOG_MSG_NO
        {
            get;
            set;
        }

        /// <summary>
        /// Variable de mensaje
        /// Tipo: String
        /// Longitud: variable
        /// </summary>
        public string MESSAGE_V1
        {
            get;
            set;
        }

        /// <summary>
        /// Variable de mensaje
        /// Tipo: String
        /// Longitud: variable
        /// </summary>
        public string MESSAGE_V2
        {
            get;
            set;
        }

        /// <summary>
        /// Variable de mensaje
        /// Tipo: String
        /// Longitud: variable
        /// </summary>
        public string MESSAGE_V3
        {
            get;
            set;
        }

        /// <summary>
        /// Variable de mensaje
        /// Tipo: String
        /// Longitud: variable
        /// </summary>
        public string MESSAGE_V4
        {
            get;
            set;
        }

        /// <summary>
        /// Parámetro
        /// Tipo: String
        /// Longitud: 2
        /// </summary>
        public string PARAMETER
        {
            get;
            set;
        }

        /// <summary>
        /// Línea en el parámetro
        /// Tipo: INT4
        /// </summary>
        public int ROW
        {
            get;
            set;
        }

        /// <summary>
        /// Campo en parámetro
        /// Tipo: String
        /// Longitud: variable
        /// </summary>
        public string FIELD
        {
            get;
            set;
        }

        /// <summary>
        /// Sistema (lógico) del que procede el mensaje
        /// Tipo: String
        /// Longitud: variable
        /// </summary>
        public string SYSTEM
        {
            get;
            set;
        }
    }
}


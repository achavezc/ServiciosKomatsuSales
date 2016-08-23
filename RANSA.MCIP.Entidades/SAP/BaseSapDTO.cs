using System;
using System.Collections.Generic;

namespace RANSA.MCIP.Entidades
{
    /// <summary>
    /// Clase para Base Sap
    /// </summary>
    //[Serializable]
    public abstract class BaseSapDTO
    {
        public BaseSapDTO()
        {
            this.ListaRespuestas = new List<ResponseReturnSAP>();
        }
        /// <summary>
        /// Lista Respuestas
        /// Lista de ResponseReturnSAP
        /// <br/><b>Tipo:</b> List<ResponseReturnSAP> 
        /// </summary>
        public List<ResponseReturnSAP> ListaRespuestas
        {
            get;
            set;
        }

        /// <summary>
        /// Estado Operacion
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 10
        /// </summary>
        public string EstadoOperacion
        {
            get;
            set;
        }
    }
}
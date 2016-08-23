using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace RANSA.MCIP.Entidades
{
    /// <summary>
    /// clase para Maestro Base
    /// </summary>
    //[Serializable]
    //[DataContract]
    public class MaestroBase
    {
        /// <summary>
        /// Codigo
        /// Tipo: string 
        /// Longitud: 10
        /// </summary>
        //[DataMember]
        public string Codigo { get; set; }

        /// <summary>
        /// Descripcion
        /// Tipo: string 
        /// Longitud: 250
        /// </summary>
        //[DataMember]
        public string Descripcion { get; set; }
    }
}


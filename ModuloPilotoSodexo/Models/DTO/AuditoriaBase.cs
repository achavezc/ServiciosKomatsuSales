using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ModuloPilotoSodexo.Models
{
    /// <summary>
    /// Clase para Auditoria Base
    /// </summary>
    ////[Serializable]
    //[DataContract]
    public abstract class AuditoriaBase
    {
        /// <summary>
        /// Usuario Creacion
        /// Tipo: string 
        /// Longitud: 20
        /// </summary>
        //[DataMember]
        public string UsuarioCreacion { get; set; }
        /// <summary>
        /// Fecha Hora Creacion
        /// Tipo: DateTime 
        /// </summary>
        //[DataMember]
        public DateTime FechaHoraCreacion { get; set; }
        /// <summary>
        /// Usuario Actualizacion
        /// Tipo: string 
        /// Longitud: 20
        /// </summary>
        //[DataMember]
        public string UsuarioActualizacion { get; set; }
        /// <summary>
        /// Fecha Hora Actualizacion
        /// Tipo: DateTime? 
        /// </summary>
        //[DataMember]
        public DateTime? FechaHoraActualizacion { get; set; }
        /// <summary>
        /// Estado Registro
        /// Tipo: bool 
        /// </summary>
        //[DataMember]
        public bool EstadoRegistro { get; set; }

    }
}

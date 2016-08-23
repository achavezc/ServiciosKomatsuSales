using System;
using System.Collections.Generic;
using System.Linq;

namespace RANSA.MCIP.DTO
{
    /// <summary>
    /// Clase para Request Adjuntar Archivos
    /// </summary>
    public class RequestAdjuntarArchivosDTO : RANSA.MCIP.DTO.RequestBaseDTO
    {

        /// <summary>
        /// filtros
        /// <br/><b>Tipo:</b> AdjuntarArchivosDTO 
        /// </summary>
        public AdjuntarArchivosDTO filtros { get; set; }

        /// <summary>
        /// Sociedad Propietaria
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 4
        ///</summary>
        public string SociedadPropietaria { get; set; }
    }
}

namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseConsultaCabeceraGuiaRemisionDTO
    {
        public Result Result { get; set; }
        public DatosCabeceraGuiaRemision CabeceraGuiaRemision { get; set; }
        public int NroPagina { get; set; }
    }

    public class DatosCabeceraGuiaRemision
    {
        public string GuiaRemision { get; set; }
        public string FechaGuia { get; set; }
        public string CodigoTransportista { get; set; }
        public string Transportista { get; set; }
        public string NumeroBreveteChofer { get; set; }
        public string NombreChofer { get; set; }

    }
}



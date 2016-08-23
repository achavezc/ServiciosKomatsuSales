namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseConsultaGuiaRemisionDTO
    {
        public Result Result { get; set; }
        public List<DatosConsultaGuiaRemision> ConsultaGuiaRemision { get; set; }
        public int NroPagina { get; set; }
    }

    public class DatosConsultaGuiaRemision
    {
        public int NroRegistro { get; set; }
        public double GuiaRemision { get; set; }
        public double FechaGuia { get; set; }
        public string CodigoTransportista { get; set; }
        public string Transportista { get; set; }
        public string NumeroBreveteChofer { get; set; }
        public string NombreChofer { get; set; }
        public string NumeroAutorizacion { get; set; }
        public decimal CantidadAtendida { get; set; }
        public string UnidadMedida { get; set; }
        public decimal NumeroSolicitudSalida { get; set; }
    }
}



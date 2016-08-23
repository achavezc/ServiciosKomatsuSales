namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseConsultarDetalleGuiaRemisionDTO
    {
        public Result Result { get; set; }
        public List<DatosConsultaDetalleGuiaRemision> ListarDetalleGuiaRemision { get; set; }
        public int NroPagina { get; set; }
    }

    public class DatosConsultaDetalleGuiaRemision
    {
        public decimal NroItem { get; set; }
        public string CodigoMercaderia { get; set; }
        public string DescripcionMercaderia { get; set; }
        public double OrdenServicio { get; set; }
        public double NroSolicitud { get; set; }
        public double Autorizacion { get; set; }
        public decimal CantidadAtendida { get; set; }
        public string UnidadMedida { get; set; }

    }
}



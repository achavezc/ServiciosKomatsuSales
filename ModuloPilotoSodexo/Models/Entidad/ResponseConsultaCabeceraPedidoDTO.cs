namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseConsultaCabeceraPedidoDTO
    {
        public Result Result { get; set; }
        public DatosCabeceraPedido CabeceraPedido { get; set; }
        public int NroPagina { get; set; }
    }

    public class DatosCabeceraPedido
    {
        public string NroPedido { get; set; }
        public string FechaPedido { get; set; }
        public string FechaTransmision { get; set; }
        public string Referencia { get; set; }
        public string Observacion { get; set; }
        public string Planta { get; set; }
        public decimal CodigoPlanta { get; set; }
        public string DireccionPlanta { get; set; }

    }
}



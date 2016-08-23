namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseConsultaPedidoDTO
    {
        public Result Result { get; set; }
        public List<DatosConsultaPedido> ListarConsultaPedido { get; set; }
        public int nroPagina { get; set; }
    }

    public class DatosConsultaPedido
    {
        public string NroRegistro { get; set; }
        public string NroPedido { get; set; }
        public string FechaPedido { get; set; }
        public string FechaTransmision { get; set; }
        public string Referencia { get; set; }
        public string Observacion { get; set; }
        public string Planta { get; set; }
        public string CodigoPlanta { get; set; }
        public string DireccionPlanta { get; set; }
        
    }
}


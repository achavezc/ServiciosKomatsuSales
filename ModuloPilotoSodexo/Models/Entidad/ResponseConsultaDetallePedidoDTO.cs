
namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseConsultaDetallePedidoDTO
    {
        public Result Result { get; set; }
        public List<DatosListarDetallePedido> ListarDetallePedido { get; set; }
        public int NroPagina { get; set; }
    }

    public class DatosListarDetallePedido
    {
        public string NroRegistro { get; set; }
        public string NroItem { get; set; }
        public string CodigoMercaderia { get; set; }
        public string Descripcion { get; set; }
        public string OrdenServicio { get; set; }
        public decimal CantidadSolicitada { get; set; }
        public decimal CantidadAtendida { get; set; }
        public decimal CantidadPendiente { get; set; }
        public string UnidadMedida { get; set; }
    }
}



namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseCabeceraItemPedidoDTO
    {
        public Result Result { get; set; }
        public DatosCabeceraItemPedido CabeceraItemPedido { get; set; }
    }

    public class DatosCabeceraItemPedido
    {
        public string NroItem { get; set; }
        public string CodigoMercaderia { get; set; }
        public string Descripcion { get; set; }
        public string OrdenServicio { get; set; }
        public string CantidadSolicitada { get; set; }
        public string CantidadAtendida { get; set; }
        public string CantidadPendiente { get; set; }
        public string UnidadMedida { get; set; }
    }
}


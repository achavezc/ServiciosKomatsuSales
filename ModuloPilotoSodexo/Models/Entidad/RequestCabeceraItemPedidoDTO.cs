namespace ModuloPilotoSodexo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class RequestCabeceraItemPedidoDTO : AuditoriaBase
    {

        public int CodigoCliente { get; set; }
        public int CodigoEstado { get; set; }
        public int CodigoZona { get; set; }
        public int NroItem { get; set; }
        public long NroPedido { get; set; }

    }
}


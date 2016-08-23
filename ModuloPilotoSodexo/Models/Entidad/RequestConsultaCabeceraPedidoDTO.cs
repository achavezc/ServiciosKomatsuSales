namespace ModuloPilotoSodexo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class RequestConsultaCabeceraPedidoDTO : AuditoriaBase
    {

        public int CodigoCliente { get; set; }
        public int CodigoEstado { get; set; }
        public int CodigoZona { get; set; }
        public long NumeroPedido { get; set; }

    }
}


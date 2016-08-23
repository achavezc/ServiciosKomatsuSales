namespace ModuloPilotoSodexo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class RequestListarResumenPedidoDTO : AuditoriaBase
    {

        public int CodigoCliente { get; set; }

        public int CodigoZona { get; set; }

        public int FechaFin { get; set; }

        public int FechaInicio { get; set; }
    }
}


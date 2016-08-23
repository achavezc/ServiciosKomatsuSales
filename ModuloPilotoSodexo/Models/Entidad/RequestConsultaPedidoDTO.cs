namespace ModuloPilotoSodexo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class RequestConsultaPedidoDTO : AuditoriaBase
    {

        public int CodigoCliente { get; set; }
        public int CodigoEstado { get; set; }
        public int CodigoZona { get; set; }
        public int FechaFin { get; set; }
        public int FechaInicio { get; set; }

        public string ColumnaOrden { get; set; }
        public int PaginaActual { get; set; }
        public int TamanoPagina { get; set; }

    }
}


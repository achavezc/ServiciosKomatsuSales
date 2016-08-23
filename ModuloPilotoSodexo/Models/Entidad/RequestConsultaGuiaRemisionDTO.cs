namespace ModuloPilotoSodexo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class RequestConsultaGuiaRemisionDTO : AuditoriaBase
    {

        public int CodigoCliente { get; set; }
        public long NroItem { get; set; }
        public int CodigoZona { get; set; }
        public long NumeroPedido { get; set; }
        public long OrdenServicio { get; set; }

        public string ColumnaOrdenamiento { get; set; }
       // public string ColumnaOrden { get; set; }
        public int PaginaActual { get; set; }
        public int TamanoPagina { get; set; }

    }
}


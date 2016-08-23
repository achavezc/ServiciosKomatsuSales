namespace ModuloPilotoSodexo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class RequestConsultaCabeceraGuiaRemisionDTO : AuditoriaBase
    {

        public int CodigoCliente { get; set; }
        public int CodigoZona { get; set; }
        public Int64 NumeroPedido { get; set; }

    }
}


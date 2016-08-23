namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using ModuloPilotoSodexo.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseConsultaClienteDTO
    {
        public Result Result { get; set; }
        public List<Clientes> ListarConsultaCliente { get; set; }
        public int nroPagina { get; set; }
    }


}


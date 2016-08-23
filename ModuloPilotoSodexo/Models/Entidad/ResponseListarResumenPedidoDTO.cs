namespace ModuloPilotoSodexo.Models
{
    using ModuloPilotoSodexo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    ////[Serializable]
    public class ResponseListarResumenPedidoDTO
    {
        public ResponseListarResumenPedidoDTO()
        {
            this.Result = new Result();
            this.Result.Success = false;
        }
        public Result Result { get; set; }
        public List<DatosListarResumenPedido> ListarResumenPedido { get; set; }
        public int NroPagina { get; set; }
    }

    public class DatosListarResumenPedido
    {
        public int? idEstado { get; set; }
        public string Estado { get; set; }
        public decimal Cantidad { get; set; }
    }
}



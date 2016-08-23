using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class DetalleAnexoPedidoDTO
    {
        public string IdPedidoAnexo { get; set; }
        public string IdPedido { get; set; }
        public string Item { get; set; }
        public string Descripcion { get; set; }
        public string FileName { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int EstadoRegistro { get; set; }
    }
}

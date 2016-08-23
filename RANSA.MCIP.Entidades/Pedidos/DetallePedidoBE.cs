using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.Entidades
{
    public class DetallePedidoBE
    {
        public int IdDetallePedido { get; set; }
        public string Posicion { get; set; }
        public string CodigoMaterial { get; set; }
        public double Cantidad { get; set; }
        public string CodigoUnidad { get; set; }
        public string Observacion { get; set; }
        public int IdPedido { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int EstadoRegistro { get; set; }
    }
}

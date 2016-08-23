using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class Resultado
    {
        public bool Satisfactorio { get; set; }

        /// <summary>
        /// Describe el código de error de negocio
        /// </summary>
        public string CodigoError { get; set; }

        /// <summary>
        /// Describe el mensaje de error 
        /// </summary>
        public string Mensaje { get; set; }
        public string idPedido { get; set; }
        public string idPedidoAnexo { get; set; }
        public Guid IdError { get; set; }
    }
}

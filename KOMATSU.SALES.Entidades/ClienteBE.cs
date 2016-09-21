using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KOMATSU.SALES.Entidades
{
    public class ClienteBE
    {
        public int IdCliente { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string TipoCliente { get; set; }
        public string TipoPago { get; set; }

    }
}

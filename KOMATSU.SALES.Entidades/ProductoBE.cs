using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KOMATSU.SALES.Entidades
{
    public class ProductoBE
    {
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Stock { get; set; }
        public double PrecioLista { get; set; }
        public string Marca { get; set; }
        
    }
}

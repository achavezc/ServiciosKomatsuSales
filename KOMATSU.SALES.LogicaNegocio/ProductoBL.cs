using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOMATSU.SALES.AccesoDatos;
using KOMATSU.SALES.Entidades;

namespace KOMATSU.SALES.LogicaNegocio
{
    public class ProductoBL
    {
        public List<ProductoBE> ObtenerProductos(string codigoProducto, string nombreProducto)
        {
            return new ProductoDA().ObtenerProductos(codigoProducto,nombreProducto);
        }
    }
}

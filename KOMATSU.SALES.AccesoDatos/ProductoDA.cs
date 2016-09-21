using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using KOMATSU.SALES.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace KOMATSU.SALES.AccesoDatos
{
    public class ProductoDA
    {
        public List<ProductoBE> ObtenerProductos(string codigoProducto, string nombreProducto)
        {
            List<ProductoBE> resultado = new List<ProductoBE>();
            Database objDB = Util.CrearBaseDatos();
            using (DbCommand objCMD = objDB.GetStoredProcCommand("PA_LISTAR_PRODUCTOS"))
            {

                try
                {
                    objDB.AddInParameter(objCMD, "@CodigoProducto", DbType.String, codigoProducto);
                    objDB.AddInParameter(objCMD, "@NombreProducto", DbType.String, nombreProducto);
                    using (IDataReader oDataReader = objDB.ExecuteReader(objCMD))
                    {
                        while (oDataReader.Read())
                        {
                            ProductoBE producto = new ProductoBE();
                            producto.CodigoProducto = (string)oDataReader["CodigoProducto"];
                            producto.NombreProducto = (string)oDataReader["NombreProducto"];
                            producto.Stock = (int)oDataReader["Stock"];
                            producto.PrecioLista = (double)oDataReader["PrecioLista"];
                            producto.Marca = (string)oDataReader["Marca"];

                            resultado.Add(producto);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            
            return resultado;
        }
    }
}

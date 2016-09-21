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
    public class ClienteDA
    {
        public List<ClienteBE> ObtenerClientes(string ruc, string razonsocial)
        {
            List<ClienteBE> resultado = new List<ClienteBE>();

            
            Database objDB = Util.CrearBaseDatos();
            using (DbCommand objCMD = objDB.GetStoredProcCommand("PA_LISTAR_CLIENTES"))
            {

                try
                {
                    objDB.AddInParameter(objCMD, "@Ruc", DbType.String, ruc);
                    objDB.AddInParameter(objCMD, "@RazonSocial", DbType.String, razonsocial);
                    using (IDataReader oDataReader = objDB.ExecuteReader(objCMD))
                    {
                        while (oDataReader.Read())
                        {
                            ClienteBE cliente = new ClienteBE();
                            cliente.IdCliente = (int)oDataReader["IdCliente"];
                            cliente.Ruc = (string)oDataReader["Ruc"];
                            cliente.RazonSocial = (string)oDataReader["RazonSocial"];
                            cliente.Direccion = (string)oDataReader["Direccion"];
                            cliente.Telefono = (string)oDataReader["Telefono"];
                            cliente.Email = (string)oDataReader["Email"];
                            cliente.Referencia = (string)oDataReader["Referencia"];
                            cliente.Descripcion = (string)oDataReader["Descripcion"];
                            cliente.TipoCliente = (string)oDataReader["TipoCliente"];
                            cliente.TipoPago = (string)oDataReader["TipoPago"];

                            resultado.Add(cliente);
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

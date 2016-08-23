using ModuloPilotoSodexo.Agente.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.Agente.AD
{
    public class ClientesDA
    {
        public List<BusquedaClientesDTO> BusquedaClientes(string textoBusqueda)
        {
            List<BusquedaClientesDTO> resultado = new List<BusquedaClientesDTO>();
            BusquedaClientesDTO oBusquedaClientesDTO;
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConexionDA.CadenaConexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("PA_GRSCRIPTOR_BUSQUEDACLIENTES", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter par1 = new SqlParameter("@Busqueda", textoBusqueda);
                cmd.Parameters.Add(par1);

                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        oBusquedaClientesDTO = new BusquedaClientesDTO();

                        oBusquedaClientesDTO.CodigoCliente = dataReader["CodigoCliente"] != null ? dataReader["CodigoCliente"].ToString() : "";
                        oBusquedaClientesDTO.NombreCliente = dataReader["NombreCliente"] != null ? dataReader["NombreCliente"].ToString() : "";
                        oBusquedaClientesDTO.NombreGrupo = dataReader["NombreGrupo"] != null ? dataReader["NombreGrupo"].ToString() : "";


                        resultado.Add(oBusquedaClientesDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            finally
            {
                con.Close();
            }
            return resultado;
        }


    }
}
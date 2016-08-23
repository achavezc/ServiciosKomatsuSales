using Microsoft.SqlServer.Server;
using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using RANSA.MCIP.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.AccesoDatos.MaestrosMasivos
{
    public class ClienteMasivoDA
    {

        public ResponseClienteMasivoDTO RegistrarClienteMasivo(List<MasivoClienteDTO> ListaCliente)
        {
            ResponseClienteMasivoDTO response = new ResponseClienteMasivoDTO();
            int idError = 0;
            string mensaje = "";

            TipoListaClienteCollection datos = new TipoListaClienteCollection();
            foreach (MasivoClienteDTO item in ListaCliente)
            {
                datos.Add(item);
            }
            SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString());
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            try
            {
                string nombreProcedure = "PA_GRSCRIPTOR_CARGAMASIVA_CLIENTES";
                SqlCommand cmd = new SqlCommand(nombreProcedure, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@ListaClientes", SqlDbType.Structured);
                par1.TypeName = "dbo.TP_ListaClientes";
                par1.Value = datos;
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response.Result.Satisfactorio = false;
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.AccesoDatos);
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return response;
        }
    }

    public class TipoListaClienteCollection : List<MasivoClienteDTO>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlDataRecord = new SqlDataRecord(
                new SqlMetaData("Direccion", SqlDbType.Text),
                new SqlMetaData("IdPais", SqlDbType.Text),
                new SqlMetaData("IdDepartamento", SqlDbType.Text),
                new SqlMetaData("IdProvincia", SqlDbType.Text),
                new SqlMetaData("IdDistrito", SqlDbType.Text),
                new SqlMetaData("FlagAnulacion", SqlDbType.Text),
                new SqlMetaData("CodigoTipoDocumento", SqlDbType.Text),
                new SqlMetaData("CodigoCliente", SqlDbType.Text),
                new SqlMetaData("Nombre", SqlDbType.Text)
                //new SqlMetaData("IdEsquema", SqlDbType.UniqueIdentifier), new SqlMetaData("IdCreator", SqlDbType.UniqueIdentifier),
                //new SqlMetaData("EstadoFlujo", SqlDbType.Text), new SqlMetaData("IdCanal", SqlDbType.UniqueIdentifier)
            );
            foreach (MasivoClienteDTO ListaClienteitem in this)
            {
                sqlDataRecord.SetString(0, ListaClienteitem.Direccion);
                sqlDataRecord.SetString(1, ListaClienteitem.IdPais);
                sqlDataRecord.SetString(2, ListaClienteitem.IdDepartamento);
                sqlDataRecord.SetString(3, ListaClienteitem.IdProvincia);
                sqlDataRecord.SetString(4, ListaClienteitem.IdDistrito);
                sqlDataRecord.SetString(5, ListaClienteitem.FlagAnulacion);
                sqlDataRecord.SetString(6, ListaClienteitem.CodigoTipoDocumento);
                sqlDataRecord.SetString(7, ListaClienteitem.CodigoCliente);
                sqlDataRecord.SetString(8, ListaClienteitem.Nombre);
                yield return sqlDataRecord;
            }
        }
    }
}

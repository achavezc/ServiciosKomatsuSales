using Microsoft.SqlServer.Server;
using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.MaestrosMasivos.AlmacenMasivo;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using RANSA.MCIP.DTO.MaestrosMasivos.MaterialMasivo;
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
                SqlParameter par1 = new SqlParameter("@ListaClientesExcel", SqlDbType.Structured);
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

        public ResponseMaterialMasivoDTO RegistrarMaterialMasivo(List<MasivoMaterialDTO> ListaMaterial)
        {
            var response = new ResponseMaterialMasivoDTO();
            int idError = 0;
            string mensaje = "";

            TipoListaMaterialCollection datos = new TipoListaMaterialCollection();
            foreach (MasivoMaterialDTO item in ListaMaterial)
            {
                datos.Add(item);
            }
            SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString());
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            try
            {
                string nombreProcedure = "PA_GRSCRIPTOR_CARGAMASIVA_MATERIAL";
                SqlCommand cmd = new SqlCommand(nombreProcedure, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@ListaMaterialesExcel", SqlDbType.Structured);
                par1.TypeName = "dbo.TP_ListaMateriales";
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

        public ResponseAlmacenMasivoDTO RegistrarAlmacenMasivo(List<MasivoAlmacenDTO> ListaAlamacen)
        {
            var response = new ResponseAlmacenMasivoDTO();
            int idError = 0;
            string mensaje = "";

            TipoListaAlmacenCollection datos = new TipoListaAlmacenCollection();
            foreach (MasivoAlmacenDTO item in ListaAlamacen)
            {
                datos.Add(item);
            }
            SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString());
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            try
            {
                string nombreProcedure = "PA_GRSCRIPTOR_CARGAMASIVA_ALMACENES";
                SqlCommand cmd = new SqlCommand(nombreProcedure, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@ListaClientesExcel", SqlDbType.Structured);
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
                new SqlMetaData("Nombre", SqlDbType.Text),
                new SqlMetaData("CodigoCliente", SqlDbType.Text),
                new SqlMetaData("NumDocumento", SqlDbType.Text),
                new SqlMetaData("CodigoCuenta", SqlDbType.Text),
                new SqlMetaData("CodigoNegocio", SqlDbType.Text)
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
                sqlDataRecord.SetString(7, ListaClienteitem.Nombre);
                sqlDataRecord.SetString(8, ListaClienteitem.CodigoCliente);
                sqlDataRecord.SetString(9, ListaClienteitem.NumDocumento);
                sqlDataRecord.SetString(10, ListaClienteitem.CodigoCuenta);
                sqlDataRecord.SetString(11, ListaClienteitem.CodigoNegocio);
                yield return sqlDataRecord;
            }
        }
    }

    public class TipoListaMaterialCollection : List<MasivoMaterialDTO>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlDataRecord = new SqlDataRecord(
                new SqlMetaData("CodigoUnidadPeso", SqlDbType.Text),
                new SqlMetaData("PesoNeto", SqlDbType.Float),
                new SqlMetaData("PesoBruto", SqlDbType.Float),
                new SqlMetaData("Volumen", SqlDbType.Float),
                new SqlMetaData("CodigoUnidadVolumen", SqlDbType.Text),
                new SqlMetaData("Ancho", SqlDbType.Float),
                new SqlMetaData("Altura", SqlDbType.Float),
                new SqlMetaData("UnidadXCaja", SqlDbType.Float),
                new SqlMetaData("CajaXPallet", SqlDbType.Float),
                new SqlMetaData("CajaXCama", SqlDbType.Float),
                new SqlMetaData("CamaXPallet", SqlDbType.Float),
                new SqlMetaData("Descripcion", SqlDbType.Text),
                new SqlMetaData("DescripcionBreve", SqlDbType.Text),
                new SqlMetaData("CodigoMaterial", SqlDbType.Text),
                new SqlMetaData("CodigoUnidadMedidaBase", SqlDbType.Text),
                new SqlMetaData("Longitud", SqlDbType.Float),
                new SqlMetaData("CodigoCuenta", SqlDbType.Text)
            );
            foreach (MasivoMaterialDTO ListaMaterialitem in this)
            {
                sqlDataRecord.SetString(0, ListaMaterialitem.CodigoUnidadPeso);
                sqlDataRecord.SetDouble(1, ListaMaterialitem.PesoNeto);
                sqlDataRecord.SetDouble(2, ListaMaterialitem.PesoBruto);
                sqlDataRecord.SetDouble(3, ListaMaterialitem.Volumen);
                sqlDataRecord.SetString(4, ListaMaterialitem.CodigoUnidadVolumen);
                sqlDataRecord.SetDouble(5, ListaMaterialitem.Ancho);
                sqlDataRecord.SetDouble(6, ListaMaterialitem.Altura);
                sqlDataRecord.SetDouble(7, ListaMaterialitem.UnidadesPorCaja);
                sqlDataRecord.SetDouble(8, ListaMaterialitem.CajaXPallet);
                sqlDataRecord.SetDouble(9, ListaMaterialitem.CajaXCama);
                sqlDataRecord.SetDouble(10, ListaMaterialitem.CamaXPallet);
                sqlDataRecord.SetString(11, ListaMaterialitem.Descripcion);
                sqlDataRecord.SetString(12, ListaMaterialitem.DescripcionBreve);
                sqlDataRecord.SetString(13, ListaMaterialitem.CodigoMaterial);
                sqlDataRecord.SetString(14, ListaMaterialitem.CodigoUnidadMedidaBase);
                sqlDataRecord.SetDouble(15, ListaMaterialitem.Longitud);
                sqlDataRecord.SetString(16, ListaMaterialitem.CodigoCuenta);
                yield return sqlDataRecord;
            }
        }
    }

    public class TipoListaAlmacenCollection : List<MasivoAlmacenDTO>, IEnumerable<SqlDataRecord>
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
                new SqlMetaData("Nombre", SqlDbType.Text),
                new SqlMetaData("CodigoCliente", SqlDbType.Text),
                new SqlMetaData("NumDocumento", SqlDbType.Text),
                new SqlMetaData("CodigoCuenta", SqlDbType.Text),
                new SqlMetaData("CodigoNegocio", SqlDbType.Text)
            );
            foreach (MasivoAlmacenDTO ListaAlmacenitem in this)
            {
                //sqlDataRecord.SetString(0, ListaClienteitem.Direccion);
                //sqlDataRecord.SetString(1, ListaClienteitem.IdPais);
                //sqlDataRecord.SetString(2, ListaClienteitem.IdDepartamento);
                //sqlDataRecord.SetString(3, ListaClienteitem.IdProvincia);
                //sqlDataRecord.SetString(4, ListaClienteitem.IdDistrito);
                //sqlDataRecord.SetString(5, ListaClienteitem.FlagAnulacion);
                //sqlDataRecord.SetString(6, ListaClienteitem.CodigoTipoDocumento);
                //sqlDataRecord.SetString(7, ListaClienteitem.Nombre);
                //sqlDataRecord.SetString(8, ListaClienteitem.CodigoCliente);
                //sqlDataRecord.SetString(9, ListaClienteitem.NumDocumento);
                //sqlDataRecord.SetString(10, ListaClienteitem.CodigoCuenta);
                //sqlDataRecord.SetString(11, ListaClienteitem.CodigoNegocio);
                yield return sqlDataRecord;
            }
        }
    }

}

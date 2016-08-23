using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace RANSA.MCIP.Framework
{
    public class HelperEF
    {
        private Database ContextoDatabase;

        public HelperEF()
        { }

        public HelperEF(Database ContextoDatabase)
        {
            this.ContextoDatabase = ContextoDatabase;
        }
        public List<T> EjecutarFuncionOProcedimiento<T>(string NombreFuncionOProcedimiento, List<InputEF> lstInputBD)
        {
            string querySQL = "";
            SqlParameter[] lstSqlParameter = GetInputSqlParameter(NombreFuncionOProcedimiento, lstInputBD, out querySQL);
            var queryResult = ContextoDatabase.SqlQuery<T>(
                   querySQL,
                   lstSqlParameter
                );

            var salida = queryResult.ToList();

            SetOutputSqlParameter(lstInputBD, lstSqlParameter);
            return salida;
        }

        //public List<T> EjecutarFuncionOProcedimientoTradicional<T>(string NombreFuncionOProcedimiento, List<InputEF> lstInputBD)
        //{
        //    string querySQL = "";


        //    var dataNumeros = new TipoListaDocumentosCollection();
        //    foreach (string numserie in lstVentasNumeros)
        //    {
        //        dataNumeros.Add(new TipoListaDocumentos(numserie));
        //    }


        //    SqlParameter[] lstSqlParameter = GetInputSqlParameterTradicional(lstInputBD);
        //    SqlConnection con = new SqlConnection();           
        //    try
        //    {
        //        con.ConnectionString = Conexion.connectionString;
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(NombreFuncionOProcedimiento);
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddRange(lstSqlParameter);


        //        using (IDataReader dataReader = cmd.ExecuteReader())
        //        {
        //            while (dataReader.Read())
        //            {
        //                EmpleadoBE empleadoBE = new EmpleadoBE();
        //                LlenarEntidadEmpleado(empleadoBE, dataReader);
        //                empleado.Add(empleadoBE);
        //            }
        //            dataReader.NextResult();
        //            while (dataReader.Read())
        //            {
        //                EmpleadoBE empleadoBE = new EmpleadoBE();
        //                LlenarEntidadEmpleado(empleadoBE, dataReader);
        //                empleado.Add(empleadoBE);
        //            }
        //        }

        //        cmd.res


        //        int IdEjecucion = Convert.ToInt32(retval.Value.ToString());
        //        return IdEjecucion;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }









        //    var queryResult = ContextoDatabase.SqlQuery<T>(
        //           querySQL,
        //           lstSqlParameter
        //        );

        //    var salida = queryResult.ToList();

        //    SetOutputSqlParameter(lstInputBD, lstSqlParameter);
        //    return salida;
        //}


        public int EjecutarFuncionOProcedimiento(string NombreFuncionOProcedimiento, List<InputEF> lstInputBD)
        {
            string querySQL = "";
            SqlParameter[] lstSqlParameter = GetInputSqlParameter(NombreFuncionOProcedimiento, lstInputBD, out querySQL);

            var queryResult = ContextoDatabase.ExecuteSqlCommand(
                   querySQL,
                   lstSqlParameter
                );

            var salida = queryResult;
            SetOutputSqlParameter(lstInputBD, lstSqlParameter);
            return salida;
        }

        public int EjecutarFuncionOProcedimiento2(string NombreFuncionOProcedimiento, List<InputEF> lstInputBD)
        {
            string querySQL = "";
            SqlParameter[] lstSqlParameter = GetInputSqlParameter(NombreFuncionOProcedimiento, lstInputBD, out querySQL);

            SqlConnection sqlConnection = (SqlConnection)this.ContextoDatabase.Connection;

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            SqlCommand cmd = new SqlCommand(querySQL, sqlConnection);
            cmd.Parameters.AddRange(lstSqlParameter);
            cmd.CommandTimeout = 300;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreFuncionOProcedimiento;

            var queryResult = cmd.ExecuteNonQuery();

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            var salida = queryResult;
            SetOutputSqlParameter(lstInputBD, lstSqlParameter);
            return salida;
        }



        public void SetOutputSqlParameter(List<InputEF> lstInputBD, SqlParameter[] lstSqlParameter)
        {
            for (int i = 0; i < lstInputBD.Count; i++)
                if (lstInputBD[i].ParametroDireccionGrabado == ParameterDirection.Output)
                    lstInputBD[i].Valor = lstSqlParameter.ToList().Find(x => x.ParameterName == lstInputBD[i].NombreAtributo).Value;

        }
        public SqlParameter[] GetInputSqlParameter(string NombreFuncionOProcedimiento, List<InputEF> lstInputBD, out string querySQL)
        {
            SqlParameter[] lstSqlParameter = new SqlParameter[lstInputBD.Count];
            querySQL = NombreFuncionOProcedimiento + " ";
            for (int i = 0; i < lstInputBD.Count; i++)
            {
                var item = lstInputBD[i];
                querySQL = querySQL + item.NombreAtributo;
                if (item.ParametroDireccionGrabado == ParameterDirection.Output)
                    querySQL = querySQL + " OUTPUT";
                if (i < lstInputBD.Count - 1)
                    querySQL = querySQL + ", ";

                lstSqlParameter[i] = AgregarParametroBD(item);
            }
            return lstSqlParameter;
        }
        public int? GetInt32Null(IDataReader dataReader, string nombrecampo)
        {
            return (dataReader.IsDBNull(dataReader.GetOrdinal(nombrecampo)) == true ? (int?)null : (int?)dataReader.GetInt32(dataReader.GetOrdinal(nombrecampo)));
        }
        public string GetStringNull(IDataReader dataReader, string nombrecampo)
        {
            return (dataReader.IsDBNull(dataReader.GetOrdinal(nombrecampo)) == true ? null : dataReader.GetString(dataReader.GetOrdinal(nombrecampo)));
        }
        public int GetInt(IDataReader dataReader, string nombrecampo)
        {
            return (dataReader.IsDBNull(dataReader.GetOrdinal(nombrecampo)) == true ? 0 : dataReader.GetInt32(dataReader.GetOrdinal(nombrecampo)));
        }
        public Boolean GetBoolean(IDataReader dataReader, string nombrecampo)
        {
            return (dataReader.IsDBNull(dataReader.GetOrdinal(nombrecampo)) == true ? false : dataReader.GetBoolean(dataReader.GetOrdinal(nombrecampo)));
        }
        public SqlParameter[] GetInputSqlParameterTradicional(List<InputEF> lstInputBD)
        {
            SqlParameter[] lstSqlParameter = new SqlParameter[lstInputBD.Count];

            for (int i = 0; i < lstInputBD.Count; i++)
            {
                var item = lstInputBD[i];
                lstSqlParameter[i] = AgregarParametroBD(item);
            }
            return lstSqlParameter;
        }
        private SqlParameter AgregarParametroBD(
            InputEF inputBD
            )
        {
            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = inputBD.NombreAtributo,
                Value = (inputBD.Valor == null ? DBNull.Value : inputBD.Valor),
                DbType = inputBD.DbTipo
            };

            if (inputBD.SqlDbTipo.HasValue)
                parameter.SqlDbType = inputBD.SqlDbTipo.Value;


            parameter.Direction = inputBD.ParametroDireccionGrabado;
            if (inputBD.Tamaño != null)
                parameter.Size = inputBD.Tamaño.Value;
            if (inputBD.CantidadDecimales != null)
                parameter.Scale = inputBD.CantidadDecimales.Value;
            if (inputBD.TipoNombre != null)
                parameter.TypeName = inputBD.TipoNombre;
            return parameter;
        }


        private static DbType ConvertToDbType(Type t)
        {
            System.Collections.Hashtable dbTypeTable = new System.Collections.Hashtable();
            dbTypeTable.Add(typeof(System.Boolean), DbType.Boolean);
            dbTypeTable.Add(typeof(System.Int16), DbType.Int16);
            dbTypeTable.Add(typeof(System.Int32), DbType.Int32);
            dbTypeTable.Add(typeof(System.Int64), DbType.Int64);
            dbTypeTable.Add(typeof(System.Double), DbType.Double);
            dbTypeTable.Add(typeof(System.Decimal), DbType.Decimal);
            dbTypeTable.Add(typeof(System.String), DbType.String);
            dbTypeTable.Add(typeof(System.Char), DbType.String);
            dbTypeTable.Add(typeof(System.DateTime), DbType.DateTime);
            dbTypeTable.Add(typeof(System.Byte[]), DbType.Binary);
            dbTypeTable.Add(typeof(System.Guid), DbType.Guid);

            DbType dbtype;
            try
            {
                dbtype = (DbType)dbTypeTable[t];
            }
            catch
            {
                dbtype = DbType.Object;
            }
            return dbtype;
        }
    }
}

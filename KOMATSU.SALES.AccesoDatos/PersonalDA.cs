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
    public class PersonalDA
    {
        public PersonalBE Login(string usuario,string password)
        {
            PersonalBE resultado = new PersonalBE();

            
            Database objDB = Util.CrearBaseDatos();
            using (DbCommand objCMD = objDB.GetStoredProcCommand("PA_LOGIN"))
            {

                try
                {
                    objDB.AddInParameter(objCMD, "@Usuario", DbType.String, usuario);
                    objDB.AddInParameter(objCMD, "@Password", DbType.String, password);
                    using (IDataReader oDataReader = objDB.ExecuteReader(objCMD))
                    {
                        while (oDataReader.Read())
                        {

                            resultado.Nombre = (string)oDataReader["Nombre"];
                            resultado.Apellidos = (string)oDataReader["Apellidos"];
                            resultado.DNI = (string)oDataReader["DNI"];
                            resultado.Sexo = (string)oDataReader["Sexo"];
                            resultado.Telefono = (string)oDataReader["Telefono"];
                            resultado.Email = (string)oDataReader["Email"];
                            resultado.Cargo = (string)oDataReader["Cargo"];
                            resultado.IdCargo = (int)oDataReader["IdCargo"];
                            resultado.IdPersonal = (int)oDataReader["IdPersonal"];
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

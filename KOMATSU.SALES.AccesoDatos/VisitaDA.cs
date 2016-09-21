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
    public class VisitaDA
    {
        public List<VisitaBE> ObtenerVisitas(string nombrePersonal, string dni)
        {
            List<VisitaBE> resultado = new List<VisitaBE>();
            Database objDB = Util.CrearBaseDatos();
            using (DbCommand objCMD = objDB.GetStoredProcCommand("PA_LISTAR_VISITAS"))
            {

                try
                {
                    objDB.AddInParameter(objCMD, "@NombrePersonal", DbType.String,nombrePersonal);
                    objDB.AddInParameter(objCMD, "@DNI", DbType.String, dni);
                    using (IDataReader oDataReader = objDB.ExecuteReader(objCMD))
                    {
                        while (oDataReader.Read())
                        {
                            VisitaBE visita = new VisitaBE();
                            visita.Descripcion = (string)oDataReader["Descripcion"];
                            visita.UrlGoogleMaps = (string)oDataReader["UrlGoogleMaps"];
                            visita.NombrePersonal = (string)oDataReader["NombrePersonal"];
                            visita.ApellidosPersonal = (string)oDataReader["ApellidosPersonal"];
                            visita.DNI = (string)oDataReader["DNI"];
                            visita.Sexo = (string)oDataReader["Sexo"];
                            visita.Telefono = (string)oDataReader["Telefono"];
                            visita.Email = (string)oDataReader["Email"];

                            resultado.Add(visita);
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

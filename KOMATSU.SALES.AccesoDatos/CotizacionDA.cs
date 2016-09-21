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
    public class CotizacionDA
    {
        public List<CotizacionBE> ObtenerCotizacion(string numeroCotizacion, DateTime fechaEmision,string estado,string nombrePersonal,string dni)
        {
            List<CotizacionBE> resultado = new List<CotizacionBE>();
            Database objDB = Util.CrearBaseDatos();
            using (DbCommand objCMD = objDB.GetStoredProcCommand("PA_LISTAR_COTIZACIONES"))
            {

                try
                {
                    objDB.AddInParameter(objCMD, "@NumeroCotizacion", DbType.String, numeroCotizacion);
                    objDB.AddInParameter(objCMD, "@FechaEmision", DbType.DateTime, fechaEmision);
                    objDB.AddInParameter(objCMD, "@Estado", DbType.String, estado);
                    objDB.AddInParameter(objCMD, "@NombrePersonal", DbType.String, nombrePersonal);
                    objDB.AddInParameter(objCMD, "@DNI", DbType.String, dni);
                    using (IDataReader oDataReader = objDB.ExecuteReader(objCMD))
                    {
                        while (oDataReader.Read())
                        {
                            CotizacionBE cotizacion = new CotizacionBE();
                            cotizacion.NumeroCotizacion = (string) oDataReader["NumeroCotizacion"];
                            cotizacion.FechaEmision = (DateTime)oDataReader["FechaEmision"];
                            cotizacion.FechaOfertaValida = (DateTime)oDataReader["FechaOfertaValida"];
                            cotizacion.Estado = (string)oDataReader["Estado"];
                            cotizacion.Observacion = (string)oDataReader["Observacion"];
                            cotizacion.ValorVenta = (double)oDataReader["ValorVenta"];
                            cotizacion.IGV = (double)oDataReader["IGV"];
                            cotizacion.PrecioTotal = (double)oDataReader["PrecioTotal"];
                            cotizacion.NombrePersonal = (string)oDataReader["NombrePersonal"];
                            cotizacion.ApellidoPersonal = (string)oDataReader["ApellidoPersonal"];
                            cotizacion.DNI = (string)oDataReader["DNI"];

                            resultado.Add(cotizacion);
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

        public List<DetalleCotizacionBE> ObtenerDetalleCotizacion(string numeroCotizacion)
        {
            List<DetalleCotizacionBE> resultado = new List<DetalleCotizacionBE>();
            Database objDB = Util.CrearBaseDatos();
            using (DbCommand objCMD = objDB.GetStoredProcCommand("PA_LISTAR_DETALLE_COTIZACIONES"))
            {

                try
                {
                    objDB.AddInParameter(objCMD, "@NumeroCotizacion", DbType.String, numeroCotizacion);
                    using (IDataReader oDataReader = objDB.ExecuteReader(objCMD))
                    {
                        while (oDataReader.Read())
                        {
                            DetalleCotizacionBE detalleCotizacion = new DetalleCotizacionBE();
                            detalleCotizacion.IdDetalleCotizacion = (int)oDataReader["IdDetalleCotizacion"];
                            detalleCotizacion.Cantidad = (int)oDataReader["Cantidad"];
                            detalleCotizacion.CostoTotal = (double)oDataReader["CostoTotal"];
                            detalleCotizacion.NumeroCotizacion = (string)oDataReader["NumeroCotizacion"];
                            detalleCotizacion.CodigoProducto = (string)oDataReader["CodigoProducto"];
                            detalleCotizacion.NombreProducto = (string)oDataReader["NombreProducto"];
                            resultado.Add(detalleCotizacion);
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

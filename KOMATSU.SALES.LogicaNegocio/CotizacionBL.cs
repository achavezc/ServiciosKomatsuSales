using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOMATSU.SALES.AccesoDatos;
using KOMATSU.SALES.Entidades;

namespace KOMATSU.SALES.LogicaNegocio
{
    public class CotizacionBL
    {

        public List<CotizacionBE> ObtenerCotizaciones(string numeroCotizacion, DateTime fechaEmision,string estado,string nombrePersonal,string dni)
        {
            return new CotizacionDA().ObtenerCotizacion(numeroCotizacion,fechaEmision,estado,nombrePersonal,dni);
        }

        public List<DetalleCotizacionBE> ObtenerDetalleCotizacion(string numeroCotizacion)
        {
            return new CotizacionDA().ObtenerDetalleCotizacion(numeroCotizacion);
        }

    }
}

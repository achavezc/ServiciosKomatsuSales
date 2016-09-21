using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOMATSU.SALES.Entidades
{
    public class RequestObtenerCotizaciones
    {
        public string NumeroCotizacion { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Estado { get; set; }
        public string NombrePersonal { get;set; }
        public string DNI { get; set; }
    }
}

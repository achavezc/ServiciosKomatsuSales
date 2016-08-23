using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    
    public class RequestPaginacionBaseDTO
    {
    
        public string OrdenCampo { get; set; }
    
        public string OrdenOrientacion { get; set; }
    
        public int? PaginaActual { get; set; }
    
        public int? NroRegistrosPorPagina { get; set; }


        /// <summary>
        /// Obtiene el número de página
        /// Tipo: Int
        /// </summary>
        /// <returns></returns>
        public int GetNroPagina()
        {
            return PaginaActual.Value;
        }

        /// <summary>
        /// obtiene el número de filas
        /// Tipo: int
        /// </summary>
        /// <returns></returns>
        public int GetNroFilas()
        {
            return NroRegistrosPorPagina.Value;
        }


        /// <summary>
        /// Obtiene la sentencia de ordenamiento en formato texto
        /// Tipo: String
        /// Longitud: Variable
        /// </summary>
        /// <param name="CampoDefecto"></param>
        /// <returns></returns>
        public String GetOrdenamiento(String CampoDefecto = "")
        {
            var salida = string.Empty;
            if (String.IsNullOrEmpty(OrdenCampo))
            {
                OrdenCampo = CampoDefecto;
            }
            if (String.IsNullOrEmpty(OrdenOrientacion))
            {
                OrdenOrientacion = "asc";
            }

            if (Convert.ToString(string.Empty + OrdenCampo).Length > 0 && Convert.ToString(string.Empty + OrdenOrientacion).Length > 0)
            {
                salida = String.Format("{0} {1}", OrdenCampo, OrdenOrientacion);
            }
            return salida;
        }

        /// <summary>
        /// si los resultados se devolverán todos los resultados o solo los que correspondan a la página consultada
        /// Tipo: Boolean
        /// </summary>
        public bool HabilitarPaginacion { get; set; }


    }
}

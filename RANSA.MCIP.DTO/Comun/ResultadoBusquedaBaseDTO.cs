/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:43 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RANSA.MCIP.DTO
{
    public abstract class ResultadoBusquedaBaseDTO : BaseDTO
    {
        /// <summary>
        /// <br/><b>Nombre:</b> 'nroRegistros'
        /// <br/><b>Tipo:</b> int
        ///</summary>
        public int nroRegistros { get; set; }

        /// <summary>
        /// <br/><b>Cantidad de Páginas Totales:</b> 'Cantidad de Páginas Totales'
        /// <br/><b>Tipo:</b> int
        ///</summary>
        public int paginasTotales { get; set; }
    }
}
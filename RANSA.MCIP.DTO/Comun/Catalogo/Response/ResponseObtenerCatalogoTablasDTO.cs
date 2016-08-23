/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:44 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RANSA.MCIP.Entidades.Core;

namespace RANSA.MCIP.DTO
{
    public class ResponseObtenerCatalogoTablasDTO : ResultadoBusquedaBaseDTO
    {
        /// <summary>
        /// <br/><b>Nombre:</b> 'catalogoTablasDTO'
        /// <br/><b>Tipo:</b> CatalogoTablasDTO
        ///</summary>
        public CatalogoTablasDTO catalogoTabla { get; set; }

        /// <summary>
        /// <br/><b>Nombre:</b> 'listaDetalleCatalogo'
        /// <br/><b>Tipo:</b> List<ResultadoFilaDetalleCatalogoDTO>
        ///</summary>
        public List<ResultadoFilaDetalleCatalogoDTO> listaDetalleCatalogo { get; set; }
    }
}
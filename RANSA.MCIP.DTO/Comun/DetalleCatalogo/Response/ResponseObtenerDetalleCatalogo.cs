/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:45 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RANSA.MCIP.Entidades.Core;

namespace RANSA.MCIP.DTO
{
    //public class ResponseObtenerDetalleCatalogo : BaseDTO
    public class ResponseObtenerDetalleCatalogo : ResultadoBusquedaBaseDTO
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'detalleCatalogoDTO'
		/// <br/><b>Tipo:</b> DetalleCatalogoDTO
		///</summary>
        public List<DetalleCatalogoDTO> resultadoBusqueda
		{
			get;
			set;
		}
	}
}
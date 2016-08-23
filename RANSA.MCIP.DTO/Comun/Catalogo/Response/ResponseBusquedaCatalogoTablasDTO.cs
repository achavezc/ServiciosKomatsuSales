/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:43 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RANSA.MCIP.Entidades.Core;

namespace RANSA.MCIP.DTO
{
	public class ResponseBusquedaCatalogoTablasDTO : ResultadoBusquedaBaseDTO
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'resultadoBusqueda'
		/// <br/><b>Tipo:</b> List<CatalogoTablasDTO>
		///</summary>
		public List<CatalogoTablasDTO> resultadoBusqueda
		{
			get;
			set;
		}
	}
}
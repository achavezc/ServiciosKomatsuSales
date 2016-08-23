/*
PROYECTO: 
AUTOR: 
FECHA: 06/05/2014 12:59:10 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades;
using RANSA.MCIP.Entidades.Core;

namespace RANSA.MCIP.ViewModel
{
	public class RegistrarCatalogoTablasViewModel
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'detalleCatalogo'
		/// <br/><b>Tipo:</b> List<ResultadoFilaDetalleCatalogoDTO>
		///</summary>
		public List<ResultadoFilaDetalleCatalogoDTO> detalleCatalogo
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'estadosRegistro'
		/// <br/><b>Tipo:</b> List<DetalleCatalogo>
		///</summary>
		public List<DetalleCatalogo> estadosRegistro
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'catalogoTablasDTO'
		/// <br/><b>Tipo:</b> CatalogoTablasDTO
		///</summary>
		public CatalogoTablasDTO catalogoTablasDTO
		{
			get;
			set;
		}

        public bool SoloLectura { get; set; }
	}
}
/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:44 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RANSA.MCIP.DTO
{
	public class RequestObtenerCatalogoTablasDTO : RequestBaseDTO
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'idCatalogo'
		/// <br/><b>Tipo:</b> int
		///</summary>
		public int idCatalogo
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'codigoSociedadPropietaria'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string codigoSociedadPropietaria
		{
			get;
			set;
		}
	}
}
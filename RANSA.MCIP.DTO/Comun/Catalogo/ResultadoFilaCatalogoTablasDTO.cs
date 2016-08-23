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
	public class ResultadoFilaCatalogoTablasDTO
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'idCatalogo'
		/// <br/><b>Tipo:</b> object
		///</summary>
		public virtual object idCatalogo
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'codigo'
		/// <br/><b>Tipo:</b> object
		///</summary>
		public virtual object codigo
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'nombre'
		/// <br/><b>Tipo:</b> object
		///</summary>
		public virtual object nombre
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'descripcion'
		/// <br/><b>Tipo:</b> object
		///</summary>
		public virtual object descripcion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'codigoTabla'
		/// <br/><b>Tipo:</b> object
		///</summary>
		public virtual object codigoTabla
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'estadoRegistro'
		/// <br/><b>Tipo:</b> object
		///</summary>
		public virtual object estadoRegistro
		{
			get;
			set;
		}
	}
}
/*
PROYECTO: 
AUTOR: 
FECHA: 06/05/2014 12:58:56 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RANSA.MCIP.Entidades.Core
{
	public class AuditoriaBase
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'usuarioCreacion'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string usuarioCreacion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'fechaHoraCreacion'
		/// <br/><b>Tipo:</b> DateTime
		///</summary>
		public DateTime fechaHoraCreacion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'usuarioActualizacion'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string usuarioActualizacion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'fechaHoraActualizacion'
		/// <br/><b>Tipo:</b> DateTime
		///</summary>
		public DateTime? fechaHoraActualizacion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'estadoRegistro'
		/// <br/><b>Tipo:</b> bool
		///</summary>
		public bool estadoRegistro
		{
			get;
			set;
		}
	}
}
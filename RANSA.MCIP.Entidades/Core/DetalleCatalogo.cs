/*
PROYECTO: 
AUTOR: 
FECHA: 06/05/2014 12:58:57 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RANSA.MCIP.Entidades.Core
{
	public class DetalleCatalogo : AuditoriaBase
	{

        /// <summary>
        /// Link del archivo
        /// </summary>
        public string val4
        {
            get;
            set;
        }


        /// <summary>
        /// Fichero visual (No se guarda en BD)
        /// </summary>
        public string val4_ficheroVisual
        {
            get;
            set;
        }

        /// <summary>
        /// Fichero real(No se guarda en BD)
        /// </summary>
        public string val4_ficheroReal
        {
            get;
            set;
        }

		/// <summary>
		/// <br/><b>Nombre:</b> 'val3'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string val3
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'val2'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string val2
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'val1'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string val1
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'label'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string label
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'sociedadPropietaria'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string sociedadPropietaria
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'mnemonico'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string mnemonico
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'descripcion'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string descripcion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'codigo'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string codigo
		{
			get;
			set;
		}

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
		/// <br/><b>Nombre:</b> 'idDetalleCatalogo'
		/// <br/><b>Tipo:</b> int
		///</summary>
		public int idDetalleCatalogo
		{
			get;
			set;
		}
	}
}
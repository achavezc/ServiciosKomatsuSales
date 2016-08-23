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
	public class PaginacionDTO
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'page'
		/// <br/><b>Tipo:</b> int?
		///</summary>
		public int? page
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'rows'
		/// <br/><b>Tipo:</b> int?
		///</summary>
		public int? rows
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'sidx'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string sidx
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'sord'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string sord
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'habilitarPaginacion'
		/// <br/><b>Tipo:</b> bool
		///</summary>
		public bool habilitarPaginacion
		{
			get;
			set;
		}
        public Guid IdGrilla { get; set; }

		/// <summary>
		/// <br/><b>Nombre:</b> 'm_rows'
		/// <br/><b>Tipo:</b> int?
		///</summary>
		private int? m_rows
		{
			get;
			set;
		}

		public int getNroPagina()
		{
            //return page.Value;
            return page.Value;
		}

		public int getNroFilas()
		{
            //return rows.Value;
            return rows.Value;
		}

		public string getOrdenamiento()
		{
            var salida = string.Empty;
            //if (String.IsNullOrEmpty(sidx))
            //{
            //    sidx = CampoDefecto;
            //}
            //if (String.IsNullOrEmpty(sord))
            //{
            //    sord = "asc";
            //}

            //if (Convert.ToString(string.Empty + sidx).Length > 0 && Convert.ToString(string.Empty + sord).Length > 0)
            //{
            //    salida = String.Format("{0} {1}", sidx, sord);
            //}
            return salida;
		}
	}
}
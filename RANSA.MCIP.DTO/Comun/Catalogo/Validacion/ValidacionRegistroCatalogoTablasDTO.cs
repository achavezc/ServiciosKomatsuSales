/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:43 p.m.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RANSA.MCIP.DTO
{
    public class ValidacionRegistroCatalogoTablasDTO
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'idCatalogo'
		/// <br/><b>Tipo:</b> int
		///</summary>
		public int? idCatalogo
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'codigo'
		/// <br/><b>Tipo:</b> string
		///</summary>
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código es requerido.")]
        public string codigo
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'descripcion'
		/// <br/><b>Tipo:</b> string
		///</summary>
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Descripción es requerido.")]
        public string descripcion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'nombre'
		/// <br/><b>Tipo:</b> string
		///</summary>
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre es requerido.")]
        public string nombre
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'codigoTabla'
		/// <br/><b>Tipo:</b> string
		///</summary>
        [Display(Name = "Código de Tabla")]
        [Required(ErrorMessage = "Código de Tabla es requerido.")]
        public string codigoTabla
		{
			get;
			set;
		}

        public bool estadoRegistro
        {
            get;
            set;
        }

        public string estadoRegistroCadena
        {
            get;
            set;
        }
	}
}
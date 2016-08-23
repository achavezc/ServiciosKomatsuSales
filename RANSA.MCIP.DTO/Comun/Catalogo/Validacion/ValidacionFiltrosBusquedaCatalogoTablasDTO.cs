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
    /// <summary>
    /// Clase para Validacion Filtros Busqueda Catalogo Tablas
    /// </summary>
    public class ValidacionFiltrosBusquedaCatalogoTablasDTO
	{
        [Display(Name = "Código de Sociedad")]
		public string codigoSociedadPropietaria { get; set; }

        [Display(Name = "Código")]
		public string codigo { get; set; }

        //[Display(Name = "Descripción")]
        //public string descripcion { get; set;}

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Estado")]
        public int? estadoRegistro { get; set; }
	}
}
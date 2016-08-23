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
    [MetadataType(typeof(ValidacionFiltrosBusquedaCatalogoTablasDTO))]
    public class FiltrosBusquedaCatalogoTablasDTO
    {
        /// <summary>
        /// <br/><b>Nombre:</b> 'codigoSociedadPropietaria'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string codigoSociedadPropietaria
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

        ///// <summary>
        ///// <br/><b>Nombre:</b> 'descripcion'
        ///// <br/><b>Tipo:</b> string
        /////</summary>
        //public string descripcion
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// <br/><b>nombre:</b> 'nombre'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string nombre { get; set; }

        /// <summary>
        /// <br/><b>Nombre:</b> 'estadoRegistro'
        /// <br/><b>Tipo:</b> Boolean?
        ///</summary>
        public int? estadoRegistro
        {
            get;
            set;
        }
    }
}
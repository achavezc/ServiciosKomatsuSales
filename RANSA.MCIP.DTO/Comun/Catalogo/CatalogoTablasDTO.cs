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
using RANSA.MCIP.Entidades.Core;

namespace RANSA.MCIP.DTO
{
    [MetadataType(typeof(ValidacionRegistroCatalogoTablasDTO))]
    public class CatalogoTablasDTO
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
        public string codigo
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
        /// <br/><b>Nombre:</b> 'nombre'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string nombre
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'codigoTabla'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string codigoTabla
        {
            get;
            set;
        }
        public bool estadoRegistro { get; set; }

        public string estadoRegistroCadena
        {
            get;
            set;
        }
    }
}
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
    /// Clase para Validación Registrar Detalle Catálogo
    /// </summary>
    public class ValidacionRegistrarDetalleCatalogoDTO
    {
        /// <summary>
        /// <br/><b>Nombre:</b> 'val3'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [Display(Name = "Valor 4")]
        public string val4
        {
            get;
            set;
        }
        /// <summary>
        /// <br/><b>Nombre:</b> 'val3'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [Display(Name = "Valor 3")]
        public string val3
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'val2'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [Display(Name = "Valor 2")]
        public string val2
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'val1'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [Display(Name = "Valor 1")]
        public string val1
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'label'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [Display(Name = "Label")]
        public string label
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'sociedadPropietaria'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [Display(Name = "Sociedad Propietaria")]
        public string sociedadPropietaria
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'mnemonico'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [Display(Name = "Mnemónico")]
        public string mnemonico
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'descripcion'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [Display(Name = "Descripción")]
        public string descripcion
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'codigo'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [Display(Name = "Código")]
        public string codigo
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'estadoRegistro'
        /// <br/><b>Tipo:</b> int
        ///</summary>
        [Display(Name = "Estado")]
        public bool estadoRegistro
        {
            get;
            set;
        }
    }
}
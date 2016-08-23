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
    public class GrabarCatalogoTablaDTO
    {
        /// <summary>
        /// <br/><b>Nombre:</b> 'nombre'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string Nombre { get; set; }

        /// <summary>
        /// <br/><b>Nombre:</b> 'idCatalogo'
        /// <br/><b>Tipo:</b> int
        ///</summary>
        public int? IdCatalogo { get; set; }

        /// <summary>
        /// <br/><b>Nombre:</b> 'codigo'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string Codigo { get; set; }

        /// <summary>
        /// <br/><b>Nombre:</b> 'descripcion'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// <br/><b>Nombre:</b> 'codigoTabla'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string CodigoTabla { get; set; }

        /// <summary>
        /// <br/><b>Nombre:</b> 'Usuario'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string Usuario { get; set; }

        /// <summary>
        /// <br/><b>Nombre:</b> 'EstadoRegistro'
        /// <br/><b>Tipo:</b> bool
        ///</summary>
        public bool EstadoRegistro { get; set; }
    }
}
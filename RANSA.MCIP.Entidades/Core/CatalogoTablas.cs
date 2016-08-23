/*
PROYECTO: 
AUTOR: 
FECHA: 06/05/2014 12:58:53 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RANSA.MCIP.Entidades.Core
{
    public class CatalogoTablas : AuditoriaBase
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
    }
}
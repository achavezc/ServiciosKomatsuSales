//using GR.COMEX.Comun.Entidades.SAP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RANSA.MCIP.DTO
{
    /// <summary>
    /// Clase para Usuario
    /// </summary>
    public class UsuarioDTO
    {
        /// <summary>
        /// Código de Usuario
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 100
        /// </summary>
        public string CodigoUsuario { get; set; }

        /// <summary>
        /// Nombre Persona
        /// <br/><b>Tipo:</b> String 
        /// <br/><b>Longitud:</b> 70
        /// </summary>
        public String NombrePersona { get; set; }

        /// <summary>
        /// Nombre Completo de Usuario
        /// <br/><b>Tipo:</b> String 
        /// <br/><b>Longitud:</b> 120
        /// </summary>
        public String NombreUsuario { get; set; }     

        ///// <summary>
        ///// Lista de String
        ///// <br/><b>Tipo:</b> List<String> 
        ///// </summary>
        //public List<String> SociedadesPermitidas { get; set; }

        ///// <summary>
        ///// Lista de String
        ///// <br/><b>Tipo:</b> List<String> 
        ///// </summary>
        //public List<String> UnidadesNegocioPermitidas { get; set; }

        ///// <summary>
        ///// Código de Cargo
        ///// <br/><b>Tipo:</b> string 
        ///// <br/><b>Longitud:</b> 20
        ///// </summary>
        //public string CodigoCargo { get; set; }

        ///// <summary>
        ///// Cargo
        ///// <br/><b>Tipo:</b> string 
        ///// <br/><b>Longitud:</b> 50
        ///// </summary>
        //public string Cargo { get; set; }

        ///// <summary>
        ///// Id Usuario
        ///// <br/><b>Tipo:</b> string 
        ///// <br/><b>Longitud:</b> 100
        ///// </summary>
        //public string IdUsuario { get; set; }

        ///// <summary>
        ///// Lista de string
        ///// <br/><b>Tipo:</b> List<string> 
        ///// </summary>
        //public List<string> SedesPermitidas { get; set; }

        ///// <summary>
        ///// Lista de ResponseOpcionUI
        ///// <br/><b>Tipo:</b> List<ResponseOpcionUI> 
        ///// </summary>
        //public List<ResponseOpcionUI> Menu { get; set; }

        ///// <summary>
        ///// Lista de string
        ///// <br/><b>Tipo:</b> List<string> 
        ///// </summary>
        //public List<string> Permisos { get; set; }

        ///// <summary>
        ///// Cuenta Red
        ///// <br/><b>Tipo:</b> string 
        ///// <br/><b>Longitud:</b> 50
        ///// </summary>
        //public string CuentaRed { get; set; }

        ///// <summary>
        ///// Id Perfil Usuario
        ///// <br/><b>Tipo:</b> string 
        ///// <br/><b>Longitud:</b> 50
        ///// </summary>
        //public string IdPerfilUsuario { get; set; }

        ///// <summary>
        ///// Email
        ///// <br/><b>Tipo:</b> string 
        ///// <br/><b>Longitud:</b> 140
        ///// </summary>
        //public string Email { get; set; }

        ///// <summary>
        ///// Rol Descripcion
        ///// <br/><b>Tipo:</b> string 
        ///// <br/><b>Longitud:</b> 50
        ///// </summary>
        //public string RolDescripcion { get; set; } //10-10-2013
    }
}


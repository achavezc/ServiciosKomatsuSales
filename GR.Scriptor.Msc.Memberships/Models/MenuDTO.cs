using ModuloPilotoSodexo;
using GR.Scriptor.Msc.Memberships.Agente.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GR.Scriptor.Msc.Memberships.Models
{
    public class MenuDTO : Result
    {
        public List<ResponseOpcionUI> MenuIzquierdo { get; set; }
        public string NombreUsuario { get; set; }
        public string RolUsuario { get; set; }
    }
}
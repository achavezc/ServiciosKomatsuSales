using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOMATSU.SALES.Entidades
{
    public class PersonalBE
    {
        public int IdPersonal { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public int IdCargo { get; set; }
    }
}

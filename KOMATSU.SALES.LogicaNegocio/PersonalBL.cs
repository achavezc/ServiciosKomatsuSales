using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOMATSU.SALES.AccesoDatos;
using KOMATSU.SALES.Entidades;

namespace KOMATSU.SALES.LogicaNegocio
{
    public class PersonalBL
    {

        public PersonalBE Login(string usuario, string password)
        {
            return new PersonalDA().Login(usuario,password);
        }

    }
}

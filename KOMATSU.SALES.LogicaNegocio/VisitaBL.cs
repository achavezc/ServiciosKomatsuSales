using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOMATSU.SALES.AccesoDatos;
using KOMATSU.SALES.Entidades;

namespace KOMATSU.SALES.LogicaNegocio
{
    public class VisitaBL
    {
        public List<VisitaBE> ObtenerVisitas(string nombrePersonal, string dni)
        {
            return new VisitaDA().ObtenerVisitas(nombrePersonal, dni);
        }
    }
}

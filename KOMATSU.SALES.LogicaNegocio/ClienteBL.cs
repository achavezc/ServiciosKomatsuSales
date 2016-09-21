using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOMATSU.SALES.AccesoDatos;
using KOMATSU.SALES.Entidades;

namespace KOMATSU.SALES.LogicaNegocio
{
    public class ClienteBL
    {

        public List<ClienteBE> ObtenerClientes(string ruc, string razonsocial)
        {
            return new ClienteDA().ObtenerClientes(ruc,razonsocial);
        }

    }
}

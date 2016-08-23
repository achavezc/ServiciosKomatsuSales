using ModuloPilotoSodexo.Agente.AD;
using ModuloPilotoSodexo.Agente.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPilotoSodexo.Agente.BL
{
    public class ClientesBL
    {
        public List<BusquedaClientesDTO> BusquedaClientes(string textoBusqueda)
        {
            return new ClientesDA().BusquedaClientes(textoBusqueda);
        }
    }
}
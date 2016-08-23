﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.DTO
{
    public class DetalleAnexoAdjuntoPedidoDTO
    {
        public string IdPedidoAnexoAdjunto { get; set; }
        public string IdPedidoAnexo { get; set; }
        public string ArchivoRealNombre { get; set; }
        public string ArchivoVisualNombre { get; set; }
        public string ArchivoExtension { get; set; }
        public string ArchivoRutaDescarga { get; set; }
        public int EstadoRegistro { get; set; }
    }
}
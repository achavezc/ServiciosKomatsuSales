namespace ModuloPilotoSodexo
{
    using ModuloPilotoSodexo;
    using GR.Scriptor.Comun.Entidades.Constantes;
    using ModuloPilotoSodexo.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// clase base para DTO
    /// <br/><b>Tipo:</b> abstract 
    /// </summary>
    public class BaseDTO
    {
        public BaseDTO()
        {
            this.ListaRespuestas = new List<ResponseReturnSAP>();
            this.Errores = new Dictionary<string, string>();
            this.Mensajes = new Dictionary<string, string>();
        }
        /// <summary>
        /// Lista de errores captados durante el proceso
        /// </summary>
        public Dictionary<string, string> Errores
        {
            get;
            set;
        }

        /// <summary>
        /// Determina el estado de la operación {Correcto|Incorrecto}
        /// </summary>
        public string EstadoOperacion
        {
            get;
            set;
        }

       
        /// <summary>
        /// Determina los mensajes devueltos por el servicio
        /// </summary>
        public Dictionary<string, string> Mensajes
        {
            get;
            set;
        }

        /// <summary>
        /// graba las respuestas con error.
        /// </summary>
        /// <param name="ex"></param>
        public void GrabarRespuestas(Exception ex)
        {
            this.EstadoOperacion = ConstantesSistema.EstadoOperacionServicioError;
            
            if (this.Errores == null)
            {
                this.Errores = new Dictionary<string, string>();
            }
            this.Errores.Add("1", ex.Message);
        }
   

       

       
        /// <summary>
        /// Lista de respuestas de SAP
        /// </summary>
        public List<ResponseReturnSAP> ListaRespuestas
        {
            get;
            set;
        }
    }
}
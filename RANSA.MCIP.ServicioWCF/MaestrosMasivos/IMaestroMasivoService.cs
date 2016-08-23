using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RANSA.MCIP.ServicioWCF.MaestrosMasivos
{

    [ServiceContract]
    public interface IMaestroMasivoService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/RegistrarClienteMasivo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseClienteMasivoDTO RegistrarClienteMasivo(RequestClienteMasivoDTO request);
    }
}

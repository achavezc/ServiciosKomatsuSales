﻿using RANSA.MCIP.DTO;
using RANSA.MCIP.DTO.MaestrosMasivos.ClienteMasivo;
using RANSA.MCIP.DTO.MaestrosMasivos.MaterialMasivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RANSA.MCIP.ServicioWCF
{
    [ServiceContract]
    public interface IMaestroMasivoService
    {

        [OperationContract]
        [WebInvoke(UriTemplate = "/RegistraMasivocliente", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseClienteMasivoDTO RegistraMasivocliente(RequestClienteMasivoDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/RegistraMasivoMaterial", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseMaterialMasivoDTO RegistraMasivoMaterial(RequestMaterialMasivoDTO request);


    }
}

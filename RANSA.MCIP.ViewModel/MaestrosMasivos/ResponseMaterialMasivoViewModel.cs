﻿using RANSA.MCIP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.ViewModel.MaestrosMasivos
{
    public class ResponseMaterialMasivoViewModel
    {
        public Result Result { get; set; }
        public ResponseMaterialMasivoViewModel()
        {
            this.Result = new Result();
        }

    }
}

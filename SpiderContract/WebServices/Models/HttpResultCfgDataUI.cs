﻿using HttpTaskModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpiderContract.WebServices.Models
{
    [DataContractAttribute(IsReference = true)]
    public class HttpResultCfgDataUI : HttpResponseCfg
    {
    }
}

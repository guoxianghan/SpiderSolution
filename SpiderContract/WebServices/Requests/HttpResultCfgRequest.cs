using HttpTaskModel;
using SpiderContract.WebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
namespace SpiderContract.WebServices.Requests
{
   public class HttpResultCfgRequest
    {
        public HttpResultCfgDataUI data { get; set; }
        public long id { get; set; }
        public TaskStatus Status { get; set; }
    }
}

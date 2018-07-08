using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SpiderContract
{
    public interface IResponseCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnResponseHtml(string html, DateTime timestamp);
    }
}

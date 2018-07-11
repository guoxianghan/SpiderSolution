using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderContract.WebServices
{
    public class ResponseDataBase : ResponseBase
    {
        public List<string> data { get; set; } = new List<string>();
    }
    public class ResponseDataBase<T> : ResponseBase
    {
        public List<T> data { get; set; } = new List<T>();
    }
    public class ResponseBoolBase : ResponseBase
    {
        public bool IsSuccess { get; set; }
    }
}

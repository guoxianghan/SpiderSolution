using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace CommonUtl
{
    public static class JSONHelper
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static string ToJsonString(this Object obj)
        {
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, jsSettings);
        }

    } 
}

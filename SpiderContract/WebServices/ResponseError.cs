using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpiderContract.WebServices
{
   public class ResponseError
    { /// <summary>
      /// The string resource constant (language text constant) to be used
      /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Arguments to dynamically put in to the resource constant
        /// </summary>
        [DataMember]
        public string[] Arguments { get; set; }
    }
}

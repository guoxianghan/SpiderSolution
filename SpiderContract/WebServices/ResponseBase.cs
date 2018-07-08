using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderContract.WebServices
{
    public class ResponseBase
    {
        public ResponseError Error { get; set; }

        public string err { get; set; }
        /// <summary>
        /// Helper function to easily return general error message in case 
        /// of an unexpected exception. 
        /// </summary>
        /// <param name="e">Unhandled Exception caught</param>
        /// <returns>Response object of given type with error and arguments set.</returns>
        public static T GetResponseByException<T>(Exception e) where T : ResponseBase, new()
        {
            var ret = new T();
            ret.Error = new ResponseError();
            if (e != null && !string.IsNullOrWhiteSpace(e.Message))
            {
                if (e.InnerException != null && !string.IsNullOrWhiteSpace(e.InnerException.Message))
                {
                    ret.Error.Arguments = new string[2];
                    ret.Error.Message = Constants.ErrorMessages.ExceptionOccured_P2;
                    ret.Error.Arguments[1] = e.InnerException.Message;
                }
                else
                {
                    ret.Error.Arguments = new string[1];
                    ret.Error.Message = Constants.ErrorMessages.ExceptionOccured_P1;
                }
                ret.Error.Arguments[0] = e.Message;
            }
            return ret;
        }


    }

}


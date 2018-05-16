using HttpHelper;
using HttpTaskDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTask
{
   public class HttpSpiderTask
    {
        HttpServer _LoginServer = new HttpServer();
        public HttpResultCfg HttpSpiderTaskReq(HttpRequestCfg item, System.Net.CookieContainer Cookies = null)
        {

            _LoginServer.Url = item.Url;
            _LoginServer.Method = item.Method.ToString();
            _LoginServer.Accept = item.Accept;
            _LoginServer.Origin = item.Origin;
            _LoginServer.Referer = item.Referer;
            _LoginServer.ContentType = item.ContentType;
            _LoginServer.PostData = item.PostData;
            _LoginServer.AcceptEncoding = item.Accept_Encoding;
            _LoginServer.AcceptLanguage = item.Accept_Language;
            _LoginServer.CerPath = item.CrePath;
            _LoginServer.Allowautoredirect = item.Allowautoredirect;
            _LoginServer.Host = item.Host;
            _LoginServer.PostDataType = (HttpHelper.PostDataType)Enum.ToObject(typeof(HttpHelper.PostDataType), (int)(item.PostDataType));
            _LoginServer.KeepAlive = item.KeepAlive;
            _LoginServer.x_requested_with = item.x_requested_with;
            _LoginServer.UserAgent = item.UserAgent;
            _LoginServer.UACPU = item.UACPU;
            _LoginServer.PostdataByte = item.PostdataByte;

            _LoginServer.Cookies = new System.Net.CookieContainer();
            foreach (var coo in item.CookieCollection)
            {
                _LoginServer.Cookies.Add(new System.Net.Cookie(coo.Name, coo.Value) { Domain = coo.Domain });
            }
            foreach (var head in item.Headers)
            {
                _LoginServer.HeaderCollection.Add(head.Key, head.Value);
            }
            if (Cookies != null) _LoginServer.Cookies = Cookies;
            var result = _LoginServer.GetHttpResult();
            HttpResultCfg re = NewMethod1(item, result);
            return re;
        }

        private static HttpResultCfg NewMethod1(HttpRequestCfg item, HttpResult result)
        {
            HttpResultCfg re = new HttpResultCfg();
            re.Binary = result.ResultStream.ToArray();
            re.CreateTime = DateTime.Now;
            re.FullText = result.Html;
            re.HttpStatusCode = (int)result.StatusCode;
            re.Key = item.Key;
            re.TaskId = item.Id;
            return re;
        }

        public HttpResultCfg HttpSpiderTaskReq(HttpRequestChildCfg item, System.Net.CookieContainer Cookies = null)
        {
            _LoginServer.Url = item.Url;
            _LoginServer.Method = item.Method.ToString();
            _LoginServer.Accept = item.Accept;
            _LoginServer.Origin = item.Origin;
            _LoginServer.Referer = item.Referer;
            _LoginServer.ContentType = item.ContentType;
            _LoginServer.PostData = item.PostData;
            _LoginServer.AcceptEncoding = item.Accept_Encoding;
            _LoginServer.AcceptLanguage = item.Accept_Language;
            _LoginServer.CerPath = item.CrePath;
            _LoginServer.Allowautoredirect = item.Allowautoredirect;
            _LoginServer.Host = item.Host;
            _LoginServer.PostDataType = (HttpHelper.PostDataType)Enum.ToObject(typeof(HttpHelper.PostDataType), (int)(item.PostDataType));
            _LoginServer.KeepAlive = item.KeepAlive;
            _LoginServer.x_requested_with = item.x_requested_with;
            _LoginServer.UserAgent = item.UserAgent;
            _LoginServer.UACPU = item.UACPU;
            _LoginServer.PostdataByte = item.PostdataByte;

            _LoginServer.Cookies = new System.Net.CookieContainer();
            foreach (var coo in item.CookieCollection)
            {
                _LoginServer.Cookies.Add(new System.Net.Cookie(coo.Name, coo.Value) { Domain = coo.Domain });
            }
            foreach (var head in item.Headers)
            {
                _LoginServer.HeaderCollection.Add(head.Key, head.Value);
            }
            if (Cookies != null) _LoginServer.Cookies = Cookies;
            var result = _LoginServer.GetHttpResult();
            HttpResultCfg re = NewMethod(item, result);
            return re;
        }

        private static HttpResultCfg NewMethod(HttpRequestChildCfg item, HttpResult result)
        {
            HttpResultCfg re = new HttpResultCfg();
            re.Binary = result.ResultStream.ToArray();
            re.CreateTime = DateTime.Now;
            re.FullText = result.Html;
            re.HttpStatusCode = (int)result.StatusCode;
            re.Key = item.Key;
            re.TaskId = item.Id;
            re.TaskStatus = HttpTaskDataBase.TaskStatus.Complete;
            return re;
        }
    }
}

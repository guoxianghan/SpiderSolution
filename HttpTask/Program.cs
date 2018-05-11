using HttpHelper;
using HttpTaskManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpTaskDbContext db = new HttpTaskDbContext("HttpTaskConnectionString");
            var e = new HttpRequestCfg() { Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8", ContentType = "12", CreateTime = DateTime.Now, Url = "http://m.ctrip.com/html5/hotel/sitemap-qingdao7", Host = "m.ctrip.com", Cookie = "", Encoding = "utf-8", Method = HttpMethod.GET, Referer = "", Origin = "", UACPU = "", UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.221 Safari/537.36 SE 2.X MetaSr 1.0", x_requested_with = "", WebName = "", ResponseType = FilenameExtension.Text, Upgrade_Insecure_Requests = "1", Accept_Encoding = "gzip, deflate, sdch", Accept_Language = "zh-CN,zh;q=0.8", Cache_Control = "max-age=0", Connection = "keep-live" };

            db.HttpRequestCfg.Add(e);
            db.SaveChanges();
            var t = db.HttpRequestCfg.ToList();
            foreach (var item in t)
            {
                HttpServer _LoginServer = new HttpServer()
                {
                    Url = item.Url,
                    Method = item.Method.ToString(),
                    Accept = item.Accept,
                    Origin = item.Origin,
                    Referer = item.Referer,
                    ContentType = item.ContentType,
                    PostData = item.PostData,
                    AcceptEncoding = item.Accept_Encoding,
                    AcceptLanguage = item.Accept_Language,
                    CerPath = item.CrePath,
                    Allowautoredirect = item.Allowautoredirect,
                    Host = item.Host,
                    PostDataType = (HttpHelper.PostDataType)Enum.ToObject(typeof(HttpHelper.PostDataType), (int)(item.PostDataType)),
                    KeepAlive = item.KeepAlive,
                    x_requested_with = item.x_requested_with,
                    UserAgent = item.UserAgent,
                    UACPU = item.UACPU,
                    PostdataByte = item.PostdataByte
                };
                _LoginServer.Cookies = new System.Net.CookieContainer();
                foreach (var coo in item.CookieCollection)
                {
                    _LoginServer.Cookies.Add(new System.Net.Cookie(coo.Name, coo.Value) { Domain = coo.Domain });
                }
                foreach (var head in item.Headers)
                {
                    _LoginServer.HeaderCollection.Add(head.Key, head.Value);
                }
            }
        }
    }
}

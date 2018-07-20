//using HttpHelper;
using SpiderContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HttpHelper;

namespace SpiderClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IRequestContract> channelFactory = new ChannelFactory<IRequestContract>("Request");
            var client = channelFactory.CreateChannel();

            while (true)
            {
                var list = client.HttpRequestCfgGet("", -1);
                if (list != null)
                    foreach (var items in list.data)
                    {
                        HttpServer _HotelServer = new HttpServer();
                        HttpResult _Result;
                        foreach (var item in items.HttpRequestChildCfgs)
                        {
                            _HotelServer = new HttpServer()
                            {
                                Url = item.Url,
                                Method = item.Method.ToString(),
                                UserAgent = item.UserAgent,
                                Accept = item.Accept,
                                AcceptEncoding = item.Accept_Encoding,
                                AcceptLanguage = item.Accept_Language,
                                Allowautoredirect = item.Allowautoredirect,
                                CerPath = item.CerPath,
                                Host = item.Host,
                                PostData = item.PostData,
                                x_requested_with = item.x_requested_with,
                                Origin = item.Origin,
                                PostDataType = (PostDataType)(int)item.PostDataType,
                                Referer = item.Referer,
                                UACPU = item.UACPU,
                                ContentType = item.ContentType
                            };
                            _HotelServer.Cookies = item.CookieContainer;
                            foreach (var c in item.Cookie)
                            {

                            }
                            _Result = _HotelServer.GetHttpResult();

                        }
                    }
            }
        }
    }
}

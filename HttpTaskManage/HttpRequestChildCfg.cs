using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace HttpTaskModel
{
    public class HttpRequestChildCfg : EntityBase
    {
        public string WebName { get; set; }
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string ProcessName { get; set; }
        /// <summary>
        /// 请求规则:1默认一次,0无限次
        /// </summary>
        public byte RequestRule { get; set; } = 1;
        /// <summary>
        /// 请求规则表达式,后期扩展
        /// </summary>
        public string Quartz { get; set; } 
        /// <summary>
        /// 响应的文件类型 默认Text
        /// </summary>
        public FilenameExtension ResponseType { get; set; } = FilenameExtension.Text;
        /// <summary>
        /// 任务超时时间 /min
        /// </summary>
        public int TaskTimeOut { get; set; } = 10;
        /// <summary>
        /// Post请求时要发送的字符串Post数据
        /// </summary>
        public string PostData { get; set; }
        /// <summary>
        /// Post请求时要发送的Byte类型的Post数据
        /// </summary>
        public byte[] PostdataByte { get; set; }
        /// <summary>
        /// 上传的文件绝对路径
        /// </summary>
        public string FilePath { get; set; }
        public PostDataType PostDataType { get; set; } = PostDataType.String;
        public string Host { get; set; }
        public HttpMethod Method { get; set; } = HttpMethod.GET;
        public string Url { get; set; }
        public string Referer { get; set; }
        public string Origin { get; set; }
        public string UACPU { get; set; }
        public string x_requested_with { get; set; }
        public string ContentType { get; set; }
        public string UserAgent { get; set; }
        /// <summary>
        ///  获取或设置一个值 默认值true，该值指示是否与 Internet 资源建立持久性连接默认为true。
        /// </summary>
        public Boolean KeepAlive { get; set; }
        /// <summary>
        /// 请求标头值 默认为text/html, application/xhtml+xml, */*
        /// </summary>
        public string Accept { get; set; }
        public string Encoding { get; set; }
        public string Accept_Encoding { get; set; }
        /// <summary>
        /// 默认请求超时时间 默认150000
        /// </summary>
        public int Timeout { get; set; } = 150000;
        /// <summary>
        /// 最大连接数 默认1024
        /// </summary>
        public int Connectionlimit { get; set; } = 1024;
        public string Upgrade_Insecure_Requests { get; set; }
        public string Accept_Language { get; set; }
        public string Cache_Control { get; set; }
        public string Connection { get; set; }
        /// <summary>
        /// json cookie
        /// </summary>
        public string Cookie { get; set; }
        [NotMapped]
        public ICollection<Cookie> CookieCollection
        {
            get
            {
                if (string.IsNullOrEmpty(Cookie))
                    return new List<Cookie>();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<Cookie>>(Cookie);
            }
        }

        /// <summary>
        /// 证书路径
        /// </summary>
        public string CrePath { get; set; }
        /// <summary>
        /// 是否重定向
        /// </summary>
        public bool Allowautoredirect { get; set; } = false;
        public string Header { get; set; }
        [NotMapped]
        public Dictionary<string, string> Headers
        {
            get
            {
                if (string.IsNullOrEmpty(Cookie))
                    return new Dictionary<string, string>();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(Header);
            }
        }
         
    }
}

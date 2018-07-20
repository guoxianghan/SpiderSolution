using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace HttpTaskModel
{
    [DataContract(IsReference = true)]
    public class HttpRequestChildCfg : EntityBase
    {
        public HttpRequestChildCfg()
        {
            Console.WriteLine(this.GetHashCode());
        }
        [DataMember]
        public HttpRequestCfg Target { get; set; }

        [DataMember]
        [ForeignKey("Target")]
        public long HttpRequestId { get; set; }
        [DataMember]
        public string WebName { get; set; }
        [DataMember]
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string ProcessName { get; set; }
        [DataMember]
        /// <summary>
        /// 请求规则:1默认一次,0无限次
        /// </summary>
        public byte RequestRule { get; set; } = 1;
        [DataMember]
        /// <summary>
        /// 请求规则表达式,后期扩展
        /// </summary>
        public string Quartz { get; set; }
        [DataMember]
        /// <summary>
        /// 响应的文件类型 默认Text
        /// </summary>
        public FilenameExtension ResponseType { get; set; } = FilenameExtension.Text;
        [DataMember]
        /// <summary>
        /// 任务超时时间 /min
        /// </summary>
        public int TaskTimeOut { get; set; } = 10;
        [DataMember]
        /// <summary>
        /// Post请求时要发送的字符串Post数据
        /// </summary>
        public string PostData { get; set; }
        [DataMember]
        /// <summary>
        /// Post请求时要发送的Byte类型的Post数据
        /// </summary>
        public byte[] PostdataByte { get; set; }
        [DataMember]
        /// <summary>
        /// 上传的文件绝对路径
        /// </summary>
        public string FilePath { get; set; }
        [DataMember]
        public PostDataType PostDataType { get; set; } = PostDataType.String;
        [DataMember]
        public string Host { get; set; }
        [DataMember]
        public HttpMethod Method { get; set; } = HttpMethod.GET;
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Referer { get; set; }
        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        public string UACPU { get; set; }
        [DataMember]
        public string x_requested_with { get; set; }
        [DataMember]
        public string ContentType { get; set; }
        [DataMember]
        public string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";

        [DataMember]
        /// <summary>
        ///  获取或设置一个值 默认值true，该值指示是否与 Internet 资源建立持久性连接默认为true。
        /// </summary>
        public Boolean KeepAlive { get; set; }
        [DataMember]
        /// <summary>
        /// 请求标头值 默认为text/html, application/xhtml+xml, */*
        /// </summary>
        public string Accept { get; set; }
        [DataMember]
        public string Encoding { get; set; }
        [DataMember]
        public string Accept_Encoding { get; set; }
        [DataMember]
        /// <summary>
        /// 默认请求超时时间 默认150000
        /// </summary>
        public int Timeout { get; set; } = 150000;
        [DataMember]
        /// <summary>
        /// 最大连接数 默认1024
        /// </summary>
        public int Connectionlimit { get; set; } = 1024;
        [DataMember]
        public string Upgrade_Insecure_Requests { get; set; }
        [DataMember]
        public string Accept_Language { get; set; }
        [DataMember]
        public string Cache_Control { get; set; }
        [DataMember]
        public string Connection { get; set; }
        [DataMember]
        /// <summary>
        /// json cookie
        /// </summary>
        public string Cookie { get; set; }
        //[JsonIgnore]
        //[NotMapped]
        public ICollection<Cookie> CookieCollection()
        {
            if (string.IsNullOrEmpty(Cookie))
                return new List<Cookie>();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<Cookie>>(Cookie);

        }
        public System.Net.CookieContainer CookieContainer
        {
            get
            {
                System.Net.CookieContainer c = new CookieContainer();
                foreach (var item in CookieCollection())
                {
                    c.Add(new System.Net.Cookie() { Domain = Host, Name = item.Name, Value = item.Value });
                }
                return c;
            }
        }

        [DataMember]
        /// <summary>
        /// 证书路径
        /// </summary>
        public string CrePath { get; set; }
        [DataMember]
        /// <summary>
        /// 是否重定向
        /// </summary>
        public bool Allowautoredirect { get; set; } = true;
        [DataMember]
        public string Header { get; set; }
        [DataMember]
        public string CerPath { get; set; }

        public Dictionary<string, string> Headers()
        {

            if (string.IsNullOrEmpty(Header))
                return new Dictionary<string, string>();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(Header);

        }

    }
}

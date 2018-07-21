using HttpTaskManage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace HttpTaskModel
{
    [DataContractAttribute(IsReference = true)]
    public class HttpRequestCfg : EntityBase
    {
        public HttpRequestCfg()
        {
            //Console.WriteLine(this.GetHashCode());
        }
        [DataMember]
        public List<HttpRequestChildCfg> HttpRequestChildCfgs { get; set; } = new List<HttpRequestChildCfg>();
        [DataMember]
        public string WebName { get; set; }
        [DataMember]
        public SchedulerType SchedulerType { get; set; } = SchedulerType.Single;
        [DataMember]
        /// <summary>
        /// 优先级
        /// </summary>
        public int Level { get; set; }
        [DataMember]
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string ProcessName { get; set; }
        [DataMember]
        /// <summary>
        /// 请求规则表达式,后期扩展 SchedulerRule
        /// </summary>
        public string Quartz { get; set; }
        [DataMember]
        /// <summary>
        /// 是否有子任务
        /// </summary>
        public bool HasChildTask { get; set; } = false;
        [DataMember]
        /// <summary>
        /// 任务超时时间 /min
        /// </summary>
        public int TaskTimeOut { get; set; } = 10;
        [DataMember]
        public string Host { get; set; }

        #region 当使用此参数时,与HttpRequestChildCfg 为1V1
        [DataMember]
        /// <summary>
        /// 已经查询到第几页
        /// </summary>
        public int CurrentPage { get; set; } = -1;
        [DataMember]
        /// <summary>
        /// 从第几页开始
        /// </summary>
        public int PageMin { get; set; } = -1;
        [DataMember]
        /// <summary>
        /// 到第几页结束
        /// </summary>
        public int PageMax { get; set; } = -1;
        [DataMember]
        /// <summary>
        /// 已经查询到当前参数
        /// </summary>
        public string SearchKey { get; set; } = string.Empty;
        [DataMember]
        /// <summary>
        /// 总共多少参数
        /// </summary>
        public string SearchKeys { get; set; } = string.Empty;
        #endregion

        #region
        [DataMember]
        public DateTime? CurrentDate { get; set; }
        [DataMember]
        public DateTime? DateMin { get; set; }
        [DataMember]
        public DateTime? DateMax { get; set; }
        #endregion

        [DataMember]
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
        [NotMapped]
        public System.Net.CookieContainer CookieContainer
        {
            get
            {
                System.Net.CookieContainer c = new CookieContainer();
                foreach (var item in CookieCollection)
                {
                    c.Add(new System.Net.Cookie() { Domain = Host, Name = item.Name, Value = item.Value });
                }
                return c;
            }
        }

    }
}
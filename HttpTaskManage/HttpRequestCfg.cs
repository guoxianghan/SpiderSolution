using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HttpTaskModel
{
    public class HttpRequestCfg : EntityBase
    {
        public List<HttpRequestChildCfg> HttpRequestChildCfgs { get; set; } = new List<HttpRequestChildCfg>();
        public string WebName { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int Level { get; set; }
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
        /// 是否有子任务
        /// </summary>
        public bool HasChildTask { get; set; } = false;
        /// <summary>
        /// 响应的文件类型 默认Text
        /// </summary>
        public FilenameExtension ResponseType { get; set; } = FilenameExtension.Text;
        /// <summary>
        /// 任务超时时间 /min
        /// </summary>
        public int TaskTimeOut { get; set; } = 10;

        public string Host { get; set; }

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

    }
}